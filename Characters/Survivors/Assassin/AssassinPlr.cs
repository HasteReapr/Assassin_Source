using BepInEx.Configuration;
using AssassinMod.Modules;
using AssassinMod.Modules.Characters;
using AssassinMod.Survivors.Assassin.Components;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;
using AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills;
using AssassinMod.Characters.Survivors.Assassin.SkillStates.ScepterSkills;
using AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills;
using System.Reflection;
using System.IO;
using AssassinMod.Components;

namespace AssassinMod.Survivors.Assassin
{
    public class AssassinPlr : SurvivorBase<AssassinPlr>
    {
        public override string assetBundleName => "ror2assassin";

        public override string bodyName => "AssassinSurvivorBody";

        public override string masterName => "AssassinMonsterMaster";

        public override string modelPrefabName => "mdlAssassin";
        public override string displayPrefabName => "AssassinDisplay";

        public const string ASSASSIN_PREFIX = AssassinPlugin.DEVELOPER_PREFIX + "_ASSASSIN_";

        public override string survivorTokenPrefix => ASSASSIN_PREFIX;

        private const string csProjName = "AssassinMod";

        public static GameObject AssassinPrefab;

        public override BodyInfo bodyInfo => new BodyInfo
        {
            bodyName = bodyName,
            bodyNameToken = ASSASSIN_PREFIX + "NAME",
            subtitleNameToken = ASSASSIN_PREFIX + "SUBTITLE",

            characterPortrait = assetBundle.LoadAsset<Texture>("texAssassinIcon"),
            bodyColor = new Color(0.25882352941176470588235294117647f, 0.25882352941176470588235294117647f, 0.42352941176470588235294117647059f), //(66, 66, 108)
            sortPosition = 100,

            crosshair = Assets.LoadCrosshair("Standard"),
            podPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/SurvivorPod"),

            maxHealth = 125f,
            healthRegen = 1.5f,
            armor = 0f,
            moveSpeed = 9f,
            damage = 12.5f,
            attackSpeed = 1,

            jumpCount = 1,
        };

        public override CustomRendererInfo[] customRendererInfos => new CustomRendererInfo[]
        {
                new CustomRendererInfo
                {
                    childName = "Body",
                    material = assetBundle.LoadMaterial("assassinMtrl"),
                },
                new CustomRendererInfo
                {
                    childName = "Cloak",
                    material = assetBundle.LoadMaterial("assassinMtrl"),
                },
                new CustomRendererInfo
                {
                    childName = "Knife_L",
                    material = assetBundle.LoadMaterial("assassinMtrl"),
                },
                new CustomRendererInfo
                {
                    childName = "Knife_R",
                    material = assetBundle.LoadMaterial("assassinMtrl"),
                },
        };

        public override UnlockableDef characterUnlockableDef => AssassinUnlockables.characterUnlockableDef;
        
        public override ItemDisplaysBase itemDisplays => new AssassinItemDisplays();

        //set in base classes
        public override AssetBundle assetBundle { get; protected set; }

        public override GameObject bodyPrefab { get; protected set; }
        public override CharacterBody prefabCharacterBody { get; protected set; }
        public override GameObject characterModelObject { get; protected set; }
        public override CharacterModel prefabCharacterModel { get; protected set; }
        public override GameObject displayPrefab { get; protected set; }

        public override void Initialize()
        {
            //uncomment if you have multiple characters
            //ConfigEntry<bool> characterEnabled = Config.CharacterEnableConfig("Survivors", "Henry");

            //if (!characterEnabled.Value)
            //    return;

            base.Initialize();
        }

        public override void InitializeCharacter()
        {
            //need the character unlockable before you initialize the survivordef
            AssassinUnlockables.Init();

            base.InitializeCharacter();

            AssassinConfig.Init();
            AssassinStates.Init();
            AssassinTokens.Init();

            AssassinAssets.Init(assetBundle);
            AssassinBuffs.Init(assetBundle);

            InitializeEntityStateMachines();
            InitializeSkills();
            InitializeSkins();
            InitializeCharacterMaster();

            AdditionalBodySetup();

            AddHooks();
        }
        /*internal static void LoadSoundbank()
        {
            using (Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{csProjName}.AssassinSoundBank.bnk"))
            {
                byte[] array = new byte[manifestResourceStream2.Length];
                manifestResourceStream2.Read(array, 0, array.Length);
                SoundAPI.SoundBanks.Add(array);
            }
        }*/

        private void AdditionalBodySetup()
        {
            AddHitboxes();
            bodyPrefab.AddComponent<AssassinPassiveController>();

            AssassinPrefab = bodyPrefab;

            if (displayPrefab) displayPrefab.AddComponent<MenuSoundComponent>();
        }

        public void AddHitboxes()
        {
            //example of how to create a HitBoxGroup. see summary for more details
            //Prefabs.SetupHitBoxGroup(characterModelObject, "BackstabGroup", "backstabHitbox");

            ChildLocator childLocator = characterModelObject.GetComponent<ChildLocator>();

            //example of how to create a hitbox
            Transform backstabTransform = childLocator.FindChild("backstabHitbox");
            Prefabs.SetupHitbox(prefabCharacterModel.gameObject, backstabTransform, "BackstabHitBox");
        }

        public override void InitializeEntityStateMachines() 
        {
            //clear existing state machines from your cloned body (probably commando)
            //omit all this if you want to just keep theirs
            Prefabs.ClearEntityStateMachines(bodyPrefab);

            //the main "Body" state machine has some special properties
            Prefabs.AddMainEntityStateMachine(bodyPrefab, "Body", typeof(EntityStates.GenericCharacterMain), typeof(EntityStates.SpawnTeleporterState));
            //if you set up a custom main characterstate, set it up here
                //don't forget to register custom entitystates in your HenryStates.cs

            Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon");
            Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon2");
        }

        #region skills
        public override void InitializeSkills()
        {
            //remove the genericskills from the commando body we cloned
            Skills.ClearGenericSkills(bodyPrefab);
            //add our own
            AddPassiveSkill();
            AddPrimarySkills();
            AddSecondarySkills();
            AddUtiitySkills();
            AddSpecialSkills();
        }

        //skip if you don't have a passive
        //also skip if this is your first look at skills
        private void AddPassiveSkill()
        {
            //option 1. fake passive icon just to describe functionality we will implement elsewhere
            /*bodyPrefab.GetComponent<SkillLocator>().passiveSkill = new SkillLocator.PassiveSkill
            {
                enabled = true,
                skillNameToken = ASSASSIN_PREFIX + "PASSIVE_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "PASSIVE_DESCRIPTION",
                keywordToken = "KEYWORD_STUNNING",
                icon = assetBundle.LoadAsset<Sprite>("texPassiveIcon"),
            };*/

            //option 2. a new SkillFamily for a passive, used if you want multiple selectable passives
            GenericSkill passiveGenericSkill = Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, "PassiveSkill");

            SkillDef ragePassiveDef = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "AssassinRagePassive",
                skillNameToken = ASSASSIN_PREFIX + "PASSIVE_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "PASSIVE_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texPassiveIcon"),
            });
            AssassinStaticValues.ragePassiveDef = ragePassiveDef;
            Skills.AddSkillsToFamily(passiveGenericSkill.skillFamily, ragePassiveDef);

            SkillDef poisonPassiveDef = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "AssassinPoisonPassive",
                skillNameToken = ASSASSIN_PREFIX + "ALT_PASSIVE_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "ALT_PASSIVE_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texPoisonPassiveIcon"),
            });
            AssassinStaticValues.poisonPassiveDef = poisonPassiveDef;

            /*UnlockableDef poisonPassiveUnlock = ScriptableObject.CreateInstance<UnlockableDef>();
            poisonPassiveUnlock.cachedName = "Skills.Assassin.PoisonPassive";
            poisonPassiveUnlock.nameToken = "ACHIEVEMENT_ASSASSINPOISONPASSIVE_NAME";
            poisonPassiveUnlock.achievementIcon = poisonPassiveDef.icon;
            ContentPacks.unlockableDefs.Add(poisonPassiveUnlock);*/

            Skills.AddSkillsToFamily(passiveGenericSkill.skillFamily, poisonPassiveDef);

            SkillDef decoyPassiveDef = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "AssassinDecoyPassive",
                skillNameToken = ASSASSIN_PREFIX + "ALT1_PASSIVE_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "ALT1_PASSIVE_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texDecoyPassiveIcon"),
            });
            AssassinStaticValues.decoyPassiveDef = decoyPassiveDef;
            Skills.AddSkillsToFamily(passiveGenericSkill.skillFamily, decoyPassiveDef);
        }

        //if this is your first look at skilldef creation, take a look at Secondary first
        private void AddPrimarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Primary);

            //the primary skill is created using a constructor for a typical primary
            //it is also a SteppedSkillDef. Custom Skilldefs are very useful for custom behaviors related to casting a skill. see ror2's different skilldefs for reference
            SteppedSkillDef daggerSkillDef = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
                (
                    "AssassinDaggerThrow",
                    ASSASSIN_PREFIX + "PRIMARY_DAGGER_NAME",
                    ASSASSIN_PREFIX + "PRIMARY_DAGGER_DESCRIPTION",
                    assetBundle.LoadAsset<Sprite>("texPrimaryIcon"),
                    new EntityStates.SerializableEntityStateType(typeof(ThrowDagger)),
                    "Weapon",
                    true
                ));

            daggerSkillDef.keywordTokens = new string[]
            {
                "KEYWORD_AGILE",
                "KEYWORD_DAGGER_WC"
            };

            Skills.AddPrimarySkills(bodyPrefab, daggerSkillDef);

            SteppedSkillDef cutterSkillDef = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
                (
                    "AssassinDaggerThrow",
                    ASSASSIN_PREFIX + "PRIMARY_CUTTER_NAME",
                    ASSASSIN_PREFIX + "PRIMARY_CUTTER_DESCRIPTION",
                    assetBundle.LoadAsset<Sprite>("texGhostlyPrimaryIcon"),
                    new EntityStates.SerializableEntityStateType(typeof(ThrowCutter)),
                    "Weapon",
                    true
                ));

            cutterSkillDef.keywordTokens = new string[]
            {
                "KEYWORD_AGILE",
                "KEYWORD_GHOSTLY_WC"
            };

            Skills.AddPrimarySkills(bodyPrefab, cutterSkillDef);
        }

        private void AddSecondarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Secondary);

            // Default Poison
            SkillDef poisonSkillDef = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME",
                skillNameToken = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "SECONDARY_POISON_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowPoison)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE", "KEYWORD_POISON_WC" }
            });

            Skills.AddSecondarySkills(bodyPrefab, poisonSkillDef);

            //Scepter Poison
            SkillDef scepterPoisonDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME",
                skillNameToken = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "SECONDARY_POISON_DESCRIPTION_SCEPTER",
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIconScepter"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(ScepterPoison)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE" }
            });

            Modules.Content.AddSkillDef(scepterPoisonDef);
            AssassinPlugin.SetupScepterStandalone("AssassinSurvivorBody", scepterPoisonDef, SkillSlot.Secondary, 0);

            // Virulent Venom
            SkillDef venomSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME_ALT",
                skillNameToken = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME_ALT",
                skillDescriptionToken = ASSASSIN_PREFIX + "SECONDARY_POISON_DESCRIPTION_ALT",
                skillIcon = assetBundle.LoadAsset<Sprite>("texAltSecondaryIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowVirulent)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE", "KEYWORD_VENOM_WC" }
            });

            Skills.AddSecondarySkills(bodyPrefab, venomSkillDef);

            SkillDef venomScepterSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME_ALT",
                skillNameToken = ASSASSIN_PREFIX + "SECONDARY_POISON_NAME_ALT",
                skillDescriptionToken = ASSASSIN_PREFIX + "SCEPTER_SECONDARY_POISON_DESCRIPTION_ALT",
                skillIcon = assetBundle.LoadAsset<Sprite>("texAltScepterSecondaryIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(ScepterVenom)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE" }
            });

            Modules.Content.AddSkillDef(venomScepterSkillDef);
            AssassinPlugin.SetupScepterStandalone("AssassinSurvivorBody", venomScepterSkillDef, SkillSlot.Secondary, 1);
        }

        private void AddUtiitySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Utility);

            //here's a skilldef of a typical movement skill.
            SkillDef pearlSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "UTILITY_CLOAK_NAME",
                skillNameToken = ASSASSIN_PREFIX + "UTILITY_CLOAK_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "UTILITY_CLOAK_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texUtilityIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowPearl)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = true,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            });

            pearlSkillDef.keywordTokens = new string[]
            {
                "KEYWORD_AGILE",
                "KEYWORD_TELEPORT_WC"
            };

            Skills.AddUtilitySkills(bodyPrefab, pearlSkillDef);

            SkillDef rollSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "UTILITY_ROLL_NAME",
                skillNameToken = ASSASSIN_PREFIX + "UTILITY_ROLL_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "UTILITY_ROLL_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texAltUtilityIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(Roll)),
                activationStateMachineName = "Body",
                baseMaxStock = 1,
                baseRechargeInterval = 5f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = true,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            });

            /*UnlockableDef rollUnlock = ScriptableObject.CreateInstance<UnlockableDef>();
            rollUnlock.cachedName = "Skills.Assassin.Roll";
            rollUnlock.nameToken = "ACHIEVEMENT_ASSASSINROLLUNLOCK_NAME";
            rollUnlock.achievementIcon = rollSkillDef.icon;
            Modules.ContentPacks.unlockableDefs.Add(rollUnlock);*/
            rollSkillDef.keywordTokens = new string[]
            {
                "KEYWORD_AGILE",
                "KEYWORD_ROLL_WC"
            };

           Skills.AddUtilitySkills(bodyPrefab, rollSkillDef);

           SkillDef decoySkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
           {
               skillName = ASSASSIN_PREFIX + "UTILITY_DECOY_NAME",
               skillNameToken = ASSASSIN_PREFIX + "UTILITY_DECOY_NAME",
               skillDescriptionToken = ASSASSIN_PREFIX + "UTILITY_DECOY_DESCRIPTION",
               skillIcon = assetBundle.LoadAsset<Sprite>("texDecoyUtilityIcon"),
               activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowDecoy)),
               activationStateMachineName = "Body",
               baseMaxStock = 1,
               baseRechargeInterval = 12f,
               beginSkillCooldownOnSkillEnd = false,
               canceledFromSprinting = false,
               forceSprintDuringState = false,
               fullRestockOnAssign = true,
               interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
               resetCooldownTimerOnUse = false,
               isCombatSkill = false,
               mustKeyPress = false,
               cancelSprintingOnActivation = false,
               rechargeStock = 1,
               requiredStock = 1,
               stockToConsume = 1
           });

           decoySkillDef.keywordTokens = new string[]
           {
               "KEYWORD_AGILE",
               "KEYWORD_DECOY_WC"
           };

           Skills.AddUtilitySkills(bodyPrefab, decoySkillDef);
        }

        private void AddSpecialSkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Special);

            SkillDef warCrySkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SPECIAL_POISON_SPAM_NAME",
                skillNameToken = ASSASSIN_PREFIX + "SPECIAL_POISON_SPAM_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "SPECIAL_POISON_SPAM_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texSpecialIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(DrugSelf)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = 15f,
                beginSkillCooldownOnSkillEnd = true,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE" }
            });

            Skills.AddSpecialSkills(bodyPrefab, warCrySkillDef);

            SkillDef backstabSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = ASSASSIN_PREFIX + "SPECIAL_BACKSTAB_NAME",
                skillNameToken = ASSASSIN_PREFIX + "SPECIAL_BACKSTAB_NAME",
                skillDescriptionToken = ASSASSIN_PREFIX + "SPECIAL_BACKSTAB_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texAltSpecialIcon"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(Backstab)),
                activationStateMachineName = "Weapon",
                baseMaxStock = 1,
                baseRechargeInterval = AssassinConfig.BackstabInsta.Value ? 30 : 15,
                beginSkillCooldownOnSkillEnd = true,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE" }
            });

            /*UnlockableDef backstabUnlock = ScriptableObject.CreateInstance<UnlockableDef>();
            backstabUnlock.cachedName = "Skills.Assassin.BackStab";
            backstabUnlock.nameToken = "ACHIEVEMENT_ASSASSINBACKSTABUNLOCK_NAME";
            backstabUnlock.achievementIcon = backstabSkillDef.icon;
            ContentPacks.unlockableDefs.Add(backstabUnlock);*/
            Skills.AddSpecialSkills(bodyPrefab, backstabSkillDef);
        }
        #endregion skills
        
        #region skins
        public override void InitializeSkins()
        {
            ModelSkinController skinController = prefabCharacterModel.gameObject.AddComponent<ModelSkinController>();
            ChildLocator childLocator = prefabCharacterModel.GetComponent<ChildLocator>();

            CharacterModel.RendererInfo[] defaultRendererinfos = prefabCharacterModel.baseRendererInfos;

            List<SkinDef> skins = new List<SkinDef>();

            #region DefaultSkin
            //this creates a SkinDef with all default fields
            SkinDef defaultSkin = Skins.CreateSkinDef("DEFAULT_SKIN",
                assetBundle.LoadAsset<Sprite>("texMainSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            //these are your Mesh Replacements. The order here is based on your CustomRendererInfos from earlier
                //pass in meshes as they are named in your assetbundle
            //currently not needed as with only 1 skin they will simply take the default meshes
                //uncomment this when you have another skin
            //defaultSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshHenrySword",
            //    "meshHenryGun",
            //    "meshHenry");

            //add new skindef to our list of skindefs. this is what we'll be passing to the SkinController
            skins.Add(defaultSkin);
            #endregion

            #region MasterySkin

            ////creating a new skindef as we did before
            SkinDef masterySkin = Skins.CreateSkinDef(ASSASSIN_PREFIX + "MASTERY_SKIN_NAME",
               assetBundle.LoadAsset<Sprite>("texMasterySkin"),
               defaultRendererinfos,
               prefabCharacterModel.gameObject,
               AssassinUnlockables.masterySkinUnlockableDef);

            ////adding the mesh replacements as above. 
            ////if you don't want to replace the mesh (for example, you only want to replace the material), pass in null so the order is preserved
            masterySkin.meshReplacements = Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
                "MasteryChest",
                "MasteryCloak",
                "MasteryKnife",
                "MasteryKnife");

            ////masterySkin has a new set of RendererInfos (based on default rendererinfos)
            ////you can simply access the RendererInfos' materials and set them to the new materials for your skin.
            masterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("assassinMasteryMtrl");
            masterySkin.rendererInfos[1].defaultMaterial = assetBundle.LoadMaterial("assassinMasteryMtrl");
            masterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("assassinMasteryMtrl");
            masterySkin.rendererInfos[3].defaultMaterial = assetBundle.LoadMaterial("assassinMasteryMtrl");

            masterySkin.projectileGhostReplacements = new SkinDef.ProjectileGhostReplacement[]
            {
                new SkinDef.ProjectileGhostReplacement
                {
                    projectilePrefab = AssassinAssets.dagger,
                    projectileGhostReplacementPrefab = AssassinAssets.masteryDagger
                },
                new SkinDef.ProjectileGhostReplacement
                {
                    projectilePrefab = AssassinAssets.cutter,
                    projectileGhostReplacementPrefab = AssassinAssets.masteryDagger
                }
            };

            ////here's a barebones example of using gameobjectactivations that could probably be streamlined or rewritten entirely, truthfully, but it works
            //masterySkin.gameObjectActivations = new SkinDef.GameObjectActivation[]
            //{
            //    new SkinDef.GameObjectActivation
            //    {
            //        gameObject = childLocator.FindChildGameObject("GunModel"),
            //        shouldActivate = false,
            //    }
            //};
            ////simply find an object on your child locator you want to activate/deactivate and set if you want to activate/deacitvate it with this skin

            skins.Add(masterySkin);

            #endregion

            #region GrandMasterySkin

            ////creating a new skindef as we did before
            SkinDef grandMasterySkin = Skins.CreateSkinDef(ASSASSIN_PREFIX + "GRAND_MASTERY_SKIN_NAME",
               assetBundle.LoadAsset<Sprite>("texGrandMasterySkin"),
               defaultRendererinfos,
               prefabCharacterModel.gameObject,
               AssassinUnlockables.grandMasterySkinUnlockableDef);

            ////adding the mesh replacements as above. 
            ////if you don't want to replace the mesh (for example, you only want to replace the material), pass in null so the order is preserved
            grandMasterySkin.meshReplacements = Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
                "GrandMasteryChest",
                "GrandMasteryCloak",
                "GrandMasteryKnife",
                "GrandMasteryKnife");

            ////masterySkin has a new set of RendererInfos (based on default rendererinfos)
            ////you can simply access the RendererInfos' materials and set them to the new materials for your skin.
            grandMasterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("assassinGMMaterial");
            grandMasterySkin.rendererInfos[1].defaultMaterial = assetBundle.LoadMaterial("assassinGMMaterial");
            grandMasterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("assassinGMMaterial");
            grandMasterySkin.rendererInfos[3].defaultMaterial = assetBundle.LoadMaterial("assassinGMMaterial");

            grandMasterySkin.projectileGhostReplacements = new SkinDef.ProjectileGhostReplacement[]
            {
                new SkinDef.ProjectileGhostReplacement
                {
                    projectilePrefab = AssassinAssets.dagger,
                    projectileGhostReplacementPrefab = AssassinAssets.grandMasteryDagger
                },
                new SkinDef.ProjectileGhostReplacement
                {
                    projectilePrefab = AssassinAssets.cutter,
                    projectileGhostReplacementPrefab = AssassinAssets.grandMasteryDagger
                }
            };

            ////here's a barebones example of using gameobjectactivations that could probably be streamlined or rewritten entirely, truthfully, but it works
            //masterySkin.gameObjectActivations = new SkinDef.GameObjectActivation[]
            //{
            //    new SkinDef.GameObjectActivation
            //    {
            //        gameObject = childLocator.FindChildGameObject("GunModel"),
            //        shouldActivate = false,
            //    }
            //};
            ////simply find an object on your child locator you want to activate/deactivate and set if you want to activate/deacitvate it with this skin

            skins.Add(grandMasterySkin);

            #endregion

            skinController.skins = skins.ToArray();
        }
        #endregion skins

        //Character Master is what governs the AI of your character when it is not controlled by a player (artifact of vengeance, goobo)
        public override void InitializeCharacterMaster()
        {
            //you must only do one of these. adding duplicate masters breaks the game.

            //if you're lazy or prototyping you can simply copy the AI of a different character to be used
            //Modules.Prefabs.CloneDopplegangerMaster(bodyPrefab, masterName, "Merc");

            //how to set up AI in code
            AssassinAI.Init(bodyPrefab, masterName);

            //how to load a master set up in unity, can be an empty gameobject with just AISkillDriver components
            //assetBundle.LoadMaster(bodyPrefab, masterName);
        }

        private void AddHooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, R2API.RecalculateStatsAPI.StatHookEventArgs args)
        {

            if (sender.HasBuff(AssassinBuffs.armorBuff))
            {
                args.armorAdd += 300;
            }
        }
    }
}