﻿using System;
using System.Collections.Generic;
using System.Text;
using R2API;
using RoR2;
using UnityEngine;
using RoR2.CharacterAI;
using EntityStates;
using AssassinMod.Survivors.Assassin;
using RoR2.Skills;
using AssassinMod.Characters.Entities.Decoy;
using System.Runtime.CompilerServices;

namespace AssassinMod.Characters.Entities.Decoy
{
    // Taken from https://github.com/MonsterSkinMan/GOTCE/blob/main/GOTCE/Enemies/EnemyBase.cs
    public class AssassinDecoy : DecoyBase<AssassinDecoy>
    {
        public override string PathToClone => "RoR2/Junk/Bandit/BanditBody.prefab";
        public override string CloneName => "ExplosiveDecoy";
        public override string PathToCloneMaster => "RoR2/Base/Beetle/BeetleMaster.prefab";
        public CharacterBody body;
        public CharacterMaster master;

        /*private void Start()
        {
            // Play a random emote
            if (AssassinPlugin.emoteAPILoaded)
            {
                int rand = UnityEngine.Random.Range(0, allClipNames.Count);
                while (blacklistedClips.Contains(rand))
                {
                    rand = UnityEngine.Random.Range(0, allClipNames.Count);
                }
                PlayAnimation(allClipNames[rand]);
            }
        }*/

        public override void CreatePrefab()
        {
            base.CreatePrefab();
            body = prefab.GetComponent<CharacterBody>();
            body.baseArmor = 0;
            body.attackSpeed = 1f;
            body.damage = 15;
            body.baseMaxHealth = 125f;
            body.autoCalculateLevelStats = true;
            body.baseNameToken = AssassinPlr.ASSASSIN_PREFIX + "EXPLOSIVEDECOY_NAME";
            body.baseRegen = 0f;
        }

        public override void AddSpawnCard()
        {
            base.AddSpawnCard();
            isc.directorCreditCost = int.MaxValue;
            isc.eliteRules = SpawnCard.EliteRules.Default;
            isc.forbiddenFlags = RoR2.Navigation.NodeFlags.None;
            isc.requiredFlags = RoR2.Navigation.NodeFlags.None;
            isc.hullSize = HullClassification.Human;
            isc.occupyPosition = true;
            isc.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
            isc.sendOverNetwork = true;
            isc.prefab = prefabMaster;
            isc.name = "cscDecoy";
        }

        public override void Modify()
        {
            base.Modify();
            prefab.GetComponents<EntityStateMachine>();
            if (!prefab.GetComponent<TeamComponent>())
            {
                TeamComponent team = prefab.AddComponent<TeamComponent>();
                team.teamIndex = TeamIndex.Player;
            }
            foreach (EntityStateMachine esm in prefab.GetComponents<EntityStateMachine>())
            {
                esm.initialStateType = new SerializableEntityStateType(typeof(DecoyTimer));
                esm.mainStateType = new SerializableEntityStateType(typeof(DecoyTimer));
            }

            prefab.GetComponent<SetStateOnHurt>().targetStateMachine = prefab.GetComponent<EntityStateMachine>();
            prefab.GetComponent<SetStateOnHurt>().canBeFrozen = false;
            prefab.GetComponent<SetStateOnHurt>().canBeStunned = false;
            prefab.GetComponent<SetStateOnHurt>().canBeHitStunned = false;
            prefab.GetComponent<SetStateOnHurt>().idleStateMachine = prefab.GetComponents<EntityStateMachine>();

            prefab.GetComponent<CharacterDeathBehavior>().deathState = new SerializableEntityStateType(typeof(DecoyDeath));
            prefabMaster.GetComponent<CharacterMaster>().bodyPrefab = prefab;
            prefabMaster.AddComponent<AIOwnership>();

            foreach (var skin in prefab.GetComponent<ModelLocator>().modelTransform.gameObject.GetComponent<ModelSkinController>().skins)
            {
                HG.ArrayUtils.ArrayAppend(ref skin.minionSkinReplacements, new SkinDef.MinionSkinReplacement
                {
                    minionBodyPrefab = prefab,
                    minionSkin = skin
                });
            }
        }

        public override void PostCreation()
        {
            base.PostCreation();
            RegisterEnemy(prefab, prefabMaster, null, DirectorAPI.MonsterCategory.BasicMonsters, false);

            //if (AssassinPlugin.emoteAPILoaded)
            //    EmoteAPIComp();
        }

        /*[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void EmoteAPIComp()
        {
            GameObject skele = AssassinAssets.emoteAPIDecoySkeleton;
            EmotesAPI.CustomEmotesAPI.ImportArmature(prefab, skele, jank: true);
            skele.GetComponentInChildren<BoneMapper>().scale = 1f;
        }*/

        public override void AddDirectorCard()
        {
            base.AddDirectorCard();
            card.minimumStageCompletions = int.MaxValue;
            card.selectionWeight = int.MinValue;
            card.spawnDistance = DirectorCore.MonsterSpawnDistance.Standard;
        }
    }
}