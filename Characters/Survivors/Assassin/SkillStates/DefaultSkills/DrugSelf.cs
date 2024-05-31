using EntityStates;
using AssassinMod.Survivors.Assassin;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills
{
    public class DrugSelf : GenericProjectileBaseState
    {
        private Animator animator;
        private bool hasFired;

        public override void OnEnter()
        {
            base.OnEnter();

            duration = 0.8f;
            hasFired = false;

            animator = GetModelAnimator();
            animator.SetBool("attacking", true);
            GetModelAnimator().SetFloat("PoisonFlurry.playbackRate", attackSpeedStat);

            PlayCrossfade("Gesture, Override", "Enrage", "PoisonFlurry.playbackRate", duration, 0.1f);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!hasFired)
            {
                if (NetworkServer.active)
                {
                    float radiusSqr = 20 * 20;

                    Vector3 position = transform.position;

                    hasFired = true;
                    for (TeamIndex teamIndex = TeamIndex.Neutral; teamIndex < TeamIndex.Count; teamIndex += 1)
                    {
                        if (teamIndex == teamComponent.teamIndex)
                        {
                            BlessThineShield(TeamComponent.GetTeamMembers(teamIndex), radiusSqr, position);
                        }
                    }
                }
            }

            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        private void BlessThineShield(IEnumerable<TeamComponent> recipients, float radiusSqr, Vector3 currentPosition) //I couldn't think of a name for this method, it basically handles dealing damage to enemies
        {
            if (!NetworkServer.active) return;

            foreach (TeamComponent teamComponent in recipients)
            {
                if ((teamComponent.transform.position - currentPosition).sqrMagnitude <= radiusSqr)
                {
                    CharacterBody charBody = teamComponent.body;
                    if (charBody)
                    {
                        charBody.AddTimedBuff(RoR2Content.Buffs.Warbanner, 5);
                    }
                }
            }
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