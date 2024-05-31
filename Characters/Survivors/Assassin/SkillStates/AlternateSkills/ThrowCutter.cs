using EntityStates;
using AssassinMod.Survivors.Assassin;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills
{
    public class ThrowCutter : BaseSkillState
    {
        private Ray aimRay;
        public float baseDuration = 0.2f;
        public float duration;
        public float fireTime;
        public float recoil = 0f;
        private string handString;
        private Animator animator;
        private bool hasFired;
        private float damageCoef = AssassinStaticValues.cutterDamageCoef;

        public override void OnEnter()
        {
            base.OnEnter();
            aimRay = base.GetAimRay();
            duration = baseDuration / attackSpeedStat;
            fireTime = 0;//duration;
            hasFired = false;

            base.characterBody.SetAimTimer(duration);

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            animator.SetBool("inCombat", true);
            GetModelAnimator().SetFloat("ThrowKnife.playbackRate", attackSpeedStat);

            string[] animStringList = { "ThrowKnife1", "ThrowKnife2", "ThrowKnife3", "ThrowKnife4" };
            int chosenNum = Random.RandomRangeInt(0, 4);
            string[] handStringList = { "Hand_R", "Hand_L", "Hand_R", "Hand_L" };
            handString = handStringList[chosenNum];
            PlayCrossfade("Gesture, Override", animStringList[chosenNum], "ThrowKnife.playbackRate", duration, 0.1f);
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
            animator.SetBool("attacking", false);
            //PlayAnimation("Gesture, Override", "BufferEmpty");
        }

        private void Fire()
        {
            hasFired = true;
            Ray aimRay = GetAimRay();
            if (isAuthority)
            {
                float lowVal = base.HasBuff(AssassinBuffs.assassinDrugsBuff) ? 0.5f : 0.2f;

                float highVal = 2f / damageCoef;
                FireProjectileInfo info = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = (damageCoef * characterBody.damage) * Random.Range(lowVal, highVal),
                    force = 0,
                    position = aimRay.origin,
                    crit = characterBody.RollCrit(),
                    //position = FindModelChild(handString).position,
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction) * Quaternion.Euler(0, -0.5f, 0),
                    projectilePrefab = AssassinAssets.cutter,
                    speedOverride = 256,
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

            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }
    }
}