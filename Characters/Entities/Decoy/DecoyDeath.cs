﻿using RoR2;
using EntityStates;
using System;
using RoR2.Projectile;
using Unity;
using UnityEngine;
using UnityEngine.Networking;
using AssassinMod.Survivors.Assassin;

namespace AssassinMod.Characters.Entities.Decoy
{
    // Taken from https://github.com/MonsterSkinMan/GOTCE/blob/main/GOTCE/Enemies/EnemyBase.cs

    public class DecoyDeath : GenericCharacterDeath
    {
        public override void OnEnter()
        {
            if (NetworkServer.active)
            {
                if (base.characterBody && base.characterBody.master)
                {
                    CharacterMaster master = base.characterBody.master;
                    if (master.minionOwnership && master.minionOwnership.ownerMaster)
                    {
                        CharacterMaster ownerMaster = master.minionOwnership.ownerMaster;
                        if (ownerMaster.GetBody() && base.isAuthority)
                        {
                            BlastAttack blast = new BlastAttack()
                            {
                                radius = 15f,
                                baseDamage = ownerMaster.GetBody().damage * AssassinStaticValues.decoyExplodeDamageCoef,
                                attacker = ownerMaster.GetBodyObject(),
                                position = base.characterBody.corePosition,
                                crit = Util.CheckRoll(ownerMaster.GetBody().crit, ownerMaster),
                                damageType = DamageType.Stun1s,
                                procChainMask = new ProcChainMask(),
                                procCoefficient = 1f,
                                teamIndex = ownerMaster.teamIndex,
                                falloffModel = BlastAttack.FalloffModel.None
                            };

                            EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/OmniEffect/OmniExplosionVFXQuick"), new EffectData
                            {
                                origin = base.characterBody.corePosition,
                                scale = 7,
                                rotation = Quaternion.identity
                            }, transmit: true);

                            blast.Fire();
                        }
                    }
                }
            }

            if (base.modelLocator)
            {
                if (base.modelLocator.modelBaseTransform)
                {
                    base.modelLocator.modelTransform.gameObject.SetActive(false);
                    base.modelLocator.modelBaseTransform.gameObject.SetActive(false);
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Death;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
