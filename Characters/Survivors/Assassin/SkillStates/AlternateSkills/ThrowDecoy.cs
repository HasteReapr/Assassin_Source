﻿using EntityStates;
using RoR2;
using RoR2.Audio;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AssassinMod.Survivors.Assassin;
using AssassinMod.Characters.Entities.Decoy;
using R2API.Networking.Interfaces;
using RoR2.Projectile;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills
{
    // From https://github.com/MonsterSkinMan/GOTCE/blob/main/GOTCE/EntityStatesCustom/AltSkills/Bandit/SpawnDecoy.cs
    public class ThrowDecoy : BaseSkillState
    {
        public static float duration = 0.5f;
        public static float initialSpeedCoefficient = 10f;
        public static float finalSpeedCoefficient = 1.25f;

        public static string dodgeSoundString = "Play_dodgeroll";
        public static float dodgeFOV = EntityStates.Commando.DodgeState.dodgeFOV;

        private float rollSpeed;
        private Vector3 forwardDirection;
        private Animator animator;
        private Vector3 previousPosition;

        public override void OnEnter()
        {
            base.OnEnter();
            animator = base.GetModelAnimator();

            if (base.isAuthority && base.inputBank && base.characterDirection)
            {
                forwardDirection = ((base.inputBank.moveVector == Vector3.zero) ? base.characterDirection.forward : base.inputBank.moveVector).normalized;
            }

            Vector3 rhs = base.characterDirection ? base.characterDirection.forward : forwardDirection;
            Vector3 rhs2 = Vector3.Cross(Vector3.up, rhs);

            float num = Vector3.Dot(forwardDirection, rhs);
            float num2 = Vector3.Dot(forwardDirection, rhs2);

            RecalculateRollSpeed();

            if (base.characterMotor && base.characterDirection)
            {
                base.characterMotor.velocity.y = 0f;
                base.characterMotor.velocity = forwardDirection * rollSpeed;
            }

            Vector3 b = base.characterMotor ? base.characterMotor.velocity : Vector3.zero;
            previousPosition = base.transform.position - b;

            base.PlayAnimation("FullBody, Override", "Roll", "Roll.playbackRate", Roll.duration);
            animator.SetBool("inCombat", true);
            Util.PlaySound(Roll.dodgeSoundString, base.gameObject);

            if (NetworkServer.active)
            {
                characterBody.AddTimedBuff(AssassinBuffs.armorBuff, 1.25f * Roll.duration);
                characterBody.AddTimedBuff(RoR2Content.Buffs.HiddenInvincibility, 0.5f * Roll.duration);

                new DecoySync(base.gameObject).Send(R2API.Networking.NetworkDestination.Server);
            }
        }

        private void RecalculateRollSpeed()
        {
            rollSpeed = moveSpeedStat * Mathf.Lerp(Roll.initialSpeedCoefficient, Roll.finalSpeedCoefficient, base.fixedAge / Roll.duration);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            RecalculateRollSpeed();

            if (base.characterDirection) base.characterDirection.forward = forwardDirection;
            if (base.cameraTargetParams) base.cameraTargetParams.fovOverride = Mathf.Lerp(Roll.dodgeFOV, 60f, base.fixedAge / Roll.duration);

            Vector3 normalized = (base.transform.position - previousPosition).normalized;
            if (base.characterMotor && base.characterDirection && normalized != Vector3.zero)
            {
                Vector3 vector = normalized * rollSpeed;
                float d = Mathf.Max(Vector3.Dot(vector, forwardDirection), 0f);
                vector = forwardDirection * d;
                vector.y = 0f;

                base.characterMotor.velocity = vector;
            }
            previousPosition = base.transform.position;

            if (base.HasBuff(AssassinBuffs.assassinDrugsBuff))
            {
                if(fixedAge % 0.05f == 0)
                {
                    FireProjectileInfo poison = new FireProjectileInfo()
                    {
                        owner = characterBody.gameObject,
                        damage = (AssassinStaticValues.poisonDamageCoef * characterBody.damage) * 0.3f,
                        //damageTypeOverride = (DamageType?)poisonDmgType,
                        force = 0,
                        position = GetComponent<Rigidbody>().position,
                        rotation = Quaternion.Euler(0, 0, 0),
                        projectilePrefab = AssassinAssets.poison,
                        speedOverride = 16,
                        //damageTypeOverride = characterBody.HasBuff(Modules.Buffs.assassinDrugsBuff) ? (DamageType?)Modules.Projectiles.poisonDmgType : (DamageType?)Modules.Projectiles.poisonDmgType,
                    };

                    ProjectileManager.instance.FireProjectile(poison);
                }
            }

            if (base.isAuthority && base.fixedAge >= Roll.duration)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override void OnExit()
        {
            if (base.cameraTargetParams) base.cameraTargetParams.fovOverride = -1f;
            base.OnExit();
            animator.SetBool("inCombat", false);

            base.characterMotor.disableAirControlUntilCollision = false;
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
            writer.Write(forwardDirection);
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            forwardDirection = reader.ReadVector3();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Pain;
        }
    }
}