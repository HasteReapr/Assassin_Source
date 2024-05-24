using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using static R2API.DamageAPI;
using AssassinMod.Survivors.Assassin;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills
{
    internal class ThrowVirulent : BaseSkillState
    {
        private Ray aimRay;
        public float baseDuration = 0.25f;
        public float duration;
        public float fireTime;
        public float recoil = 0f;
        private string handString;
        private Animator animator;
        private bool hasFired;

        public override void OnEnter()
        {
            base.OnEnter();

            aimRay = base.GetAimRay();
            duration = baseDuration / attackSpeedStat;
            fireTime = 0;
            hasFired = false;

            base.characterBody.SetAimTimer(duration);

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            animator.SetBool("inCombat", true);
            GetModelAnimator().SetFloat("ThrowPoison.playbackRate", attackSpeedStat);

            string[] animStringList = { "ThrowPoison", "ThrowPoison2" };
            int chosenNum = Random.RandomRangeInt(0, 2);
            string[] handStringList = { "Hand_R", "Hand_R" };
            handString = handStringList[chosenNum];
            PlayCrossfade("Gesture, Override", animStringList[chosenNum], "ThrowPoison.playbackRate", duration, 0.1f);
            Util.PlaySound("Play_dagger_sfx", gameObject);
            //if we are cloaked, uncloak upon attacking
            if (characterBody.HasBuff(RoR2Content.Buffs.Cloak))
                characterBody.ClearTimedBuffs(RoR2Content.Buffs.Cloak);
            if (characterBody.HasBuff(RoR2Content.Buffs.CloakSpeed))
                characterBody.ClearTimedBuffs(RoR2Content.Buffs.CloakSpeed);
        }

        public override void OnExit()
        {
            base.OnExit();
            animator.SetBool("inCombat", false);
        }

        private void Fire()
        {
            hasFired = true;
            Ray aimRay = GetAimRay();
            if (Util.HasEffectiveAuthority(gameObject))
            {
                FireProjectileInfo info = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = AssassinStaticValues.venomDamageCoef * characterBody.damage,
                    force = 0,
                    position = aimRay.origin,//FindModelChild(handString).position,
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                    projectilePrefab = AssassinAssets.virulentPoison,
                    speedOverride = 96,
                };
                FireProjectileInfo info_R = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = AssassinStaticValues.venomDamageCoef * characterBody.damage,
                    force = 0,
                    position = aimRay.origin,//FindModelChild(handString).position,
                    crit = characterBody.RollCrit(),
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction) * Quaternion.Euler(0, 5f, 0),
                    projectilePrefab = AssassinAssets.virulentPoison,
                    speedOverride = 96,
                };
                FireProjectileInfo info_L = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = AssassinStaticValues.venomDamageCoef * characterBody.damage,
                    force = 0,
                    position = aimRay.origin,//FindModelChild(handString).position,
                    crit = characterBody.RollCrit(),
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction) * Quaternion.Euler(0, -5f, 0),
                    projectilePrefab = AssassinAssets.virulentPoison,
                    speedOverride = 96,
                };



                if (characterBody.HasBuff(AssassinBuffs.assassinDrugsBuff))
                {
                    ProjectileManager.instance.FireProjectile(info_L);
                    ProjectileManager.instance.FireProjectile(info_R);
                }
                else
                    ProjectileManager.instance.FireProjectile(info);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (fixedAge >= fireTime && !hasFired)
            {
                Fire();
            }

            if (base.fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}
