using EntityStates;
using AssassinMod.Survivors.Assassin;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills
{
    public class DrugSelf : GenericProjectileBaseState
    {
        private Animator animator;

        public override void OnEnter()
        {
            base.OnEnter();

            duration = 0.8f;

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            GetModelAnimator().SetFloat("PoisonFlurry.playbackRate", attackSpeedStat);

            PlayCrossfade("Gesture, Override", "Enrage", "PoisonFlurry.playbackRate", duration, 0.1f);
        }

        public override void OnExit()
        {
            base.OnExit();
            if (NetworkServer.active)
                characterBody.AddTimedBuff(AssassinBuffs.assassinDrugsBuff, 5);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Pain;
        }
    }
}