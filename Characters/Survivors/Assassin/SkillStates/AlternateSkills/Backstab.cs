using AssassinMod.Modules.BaseStates;
using AssassinMod.Survivors.Assassin;
using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills
{
    public class Backstab : BaseMeleeAttack
    {
        public override void OnEnter()
        {
            hitboxGroupName = "BackstabHitBox";
            damageType = DamageType.Generic;
            damageCoefficient = AssassinStaticValues.backstabDamageCoef;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = Vector3.zero;
            baseDuration = 0.5f;
            attackStartPercentTime = 0.2f;
            attackEndPercentTime= 0.5f;
            earlyExitPercentTime = 0.35f;
            hitStopDuration = 0.012f;
            attackRecoil = 0.25f;
            hitHopVelocity = 1f;
            hitSoundString = "Play_Backstab";

            duration = baseDuration;

            base.characterBody.SetAimTimer(duration);

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            animator.SetBool("inCombat", true);
            GetModelAnimator().SetFloat("Backstab.playbackRate", 1);

            PlayCrossfade("Gesture, Override", "Backstab", "Backstab.playbackRate", duration, 0.1f);

            base.OnEnter();

            R2API.DamageAPI.AddModdedDamageType(attack, AssassinAssets.backStabDmg);
        }

        public override void OnExit()
        {
            base.OnExit();
            animator.SetBool("inCombat", false);
            //if we are cloaked, uncloak when the attack ends, so we have a chance to get away
            if (characterBody.HasBuff(RoR2Content.Buffs.Cloak))
                characterBody.ClearTimedBuffs(RoR2Content.Buffs.Cloak);
            if (characterBody.HasBuff(RoR2Content.Buffs.CloakSpeed))
                characterBody.ClearTimedBuffs(RoR2Content.Buffs.CloakSpeed);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= duration && isAuthority)
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
