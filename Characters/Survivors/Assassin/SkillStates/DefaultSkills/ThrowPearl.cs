using AssassinMod.Survivors.Assassin;
using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills
{
    public class ThrowPearl : BaseSkillState
    {
        private Ray aimRay;
        public float baseDuration = 0.5f;
        public float duration;
        private float initialFireTime;
        private float secondFireTime;
        public float recoil = 0f;
        private bool thrownSmoke;
        private bool thrownPearl;
        private Animator animator;

        public override void OnEnter()
        {
            base.OnEnter();
            thrownSmoke = false;
            thrownPearl = false;

            aimRay = base.GetAimRay();
            duration = baseDuration;// / attackSpeedStat;

            initialFireTime = 0;//(27*duration)/(67*duration); //27/67 because thats the frame the smoke bomb should spawn
            secondFireTime = 0.6f;//(62*duration)/(67*duration); //62/67 because thats the frame the pearl is thrown

            base.characterBody.SetAimTimer(duration);

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            animator.SetBool("inCombat", true);
            GetModelAnimator().SetFloat("EnderPearl.playbackRate", attackSpeedStat);
            PlayCrossfade("Gesture, Override", "ThrowEnderPearl", "EnderPearl.playbackRate", duration, 0.1f);
        }

        public override void OnExit()
        {
            base.OnExit();
            animator.SetBool("inCombat", false);
        }

        private void ThrowSmoke()
        {
            Ray aimRay = GetAimRay();
            if (Util.HasEffectiveAuthority(gameObject))
            {
                FireProjectileInfo smokeBomb = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = 2.5f * characterBody.damage,
                    force = 0,
                    position = aimRay.origin,//FindModelChild("Hand_R").position,
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                    projectilePrefab = AssassinAssets.cloudyPotion,
                    speedOverride = 0,
                };

                ProjectileManager.instance.FireProjectile(smokeBomb);
                thrownSmoke = true;
            }
        }

        private void ThrowPearlProjectile()
        {
            Ray aimRay = GetAimRay();
            if (Util.HasEffectiveAuthority(gameObject))
            {
                FireProjectileInfo enderPearl = new FireProjectileInfo()
                {
                    owner = gameObject,
                    damage = 0,
                    force = 0,
                    position = aimRay.origin,//FindModelChild("Hand_L").position,
                    rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                    projectilePrefab = AssassinAssets.enderPearl,
                    speedOverride = characterBody.HasBuff(AssassinBuffs.assassinDrugsBuff) ? 128 : 96,
                };

                ProjectileManager.instance.FireProjectile(enderPearl);
                thrownPearl = true;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (fixedAge >= initialFireTime && !thrownPearl)
            {
                ThrowPearlProjectile();
            }
            if (fixedAge >= secondFireTime && !thrownSmoke)
            {
                ThrowSmoke();
            }

            if (base.fixedAge >= duration && isAuthority && thrownSmoke)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Pain;
        }
    }
}