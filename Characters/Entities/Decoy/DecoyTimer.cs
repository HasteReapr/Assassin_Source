using RoR2;
using EntityStates;
using System;
using RoR2.Projectile;
using Unity;
using UnityEngine;
using RoR2.CharacterAI;
using UnityEngine.Networking;
using System.Collections.Generic;
//using static EmotesAPI.CustomEmotesAPI;
using System.Runtime.CompilerServices;
using AssassinMod.Survivors.Assassin;

namespace AssassinMod.Characters.Entities.Decoy
{
    // Taken from https://github.com/MonsterSkinMan/GOTCE/blob/main/GOTCE/EntityStatesCustom/AltSkills/Bandit/Decoy/DecoyTimer.cs
    public class DecoyTimer : BaseState
    {
        public float duration = 3.5f;
        public float stopwatch = 0f;
        public float delay = 0.5f;

        public override void OnEnter()
        {
            base.OnEnter();

            var owner = characterBody?.master?.GetComponent<AIOwnership>()?.ownerMaster?.GetBody();
            if (owner)
            {
                // This is for setting the skin of the decoy to whatever skin the player has.
                var skinc = owner.modelLocator.modelTransform.GetComponent<ModelSkinController>();
                skinc.skins[skinc.currentSkinIndex].Apply(modelLocator.modelTransform.gameObject);
            }

            //This was to play a random emote whenever the decoy spawned, however this is apparently fucking impossible to do
            //if(AssassinPlugin.emoteAPILoaded)
            //    PlayEmote();
        }

        /*[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void PlayEmote()
        {
            // Play a random emote
            int rand = UnityEngine.Random.Range(0, allClipNames.Count);
            while (blacklistedClips.Contains(rand))
            {
                rand = UnityEngine.Random.Range(0, allClipNames.Count);
            }

            EmotesAPI.CustomEmotesAPI.PlayAnimation(allClipNames[rand], gameObject.GetComponentInParent<BoneMapper>());
        }*/

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
            if (base.fixedAge >= duration)
            {
                if (NetworkServer.active)
                {
                    base.characterBody.healthComponent.Suicide();
                }
                outer.SetNextStateToMain();
            }
            stopwatch += Time.fixedDeltaTime;
            if (stopwatch >= delay)
            {
                stopwatch = 0f;
                if (NetworkServer.active)
                {
                    List<HurtBox> buffer = new List<HurtBox>();
                    SphereSearch search = new SphereSearch()
                    {
                        radius = 200f,
                        origin = base.characterBody.corePosition,
                        mask = LayerIndex.entityPrecise.mask
                    };
                    search.RefreshCandidates();
                    search.FilterCandidatesByHurtBoxTeam(TeamMask.AllExcept(TeamIndex.Player));
                    search.FilterCandidatesByDistinctHurtBoxEntities();
                    search.OrderCandidatesByDistance();
                    search.GetHurtBoxes(buffer);
                    search.ClearCandidates();

                    foreach (HurtBox box in buffer)
                    {
                        if (box.healthComponent && box.healthComponent.body && box.healthComponent.body.master)
                        {
                            foreach (BaseAI ai in box.healthComponent.body.master.aiComponents)
                            {
                                ai.currentEnemy.gameObject = base.gameObject;
                            }
                        }
                    }
                }
            }
        }
    }
}
