using AssassinMod.Modules.BaseStates;
using AssassinMod.Survivors.Assassin;
using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills
{
    public class ThrowPoison : BaseSkillState
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
            string[] handStringList = { "Hand_R", "Hand_L" };
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
                GameObject thrownPoison = characterBody.HasBuff(AssassinBuffs.assassinDrugsBuff) ? AssassinAssets.clusterPoison : AssassinAssets.poison;
                FireProjectileInfo info = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = AssassinStaticValues.poisonDamageCoef * characterBody.damage,
                    //damageTypeOverride = (DamageType?)AssassinAssets.poisonDmgType,
                    force = 0,
                    crit = characterBody.RollCrit(),
                    position = aimRay.origin,//FindModelChild(handString).position,
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                    projectilePrefab = thrownPoison,
                    speedOverride = 96,
                };

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