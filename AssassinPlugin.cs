using BepInEx;
using AssassinMod.Survivors.Assassin;
using R2API.Utils;
using RoR2;
using RoR2.Skills;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using AssassinMod.Characters.Survivors.Assassin;

using R2API;
using System.Runtime.CompilerServices;
using RoR2.Skills;
using AssassinMod.Survivors.Assassin.Components;
using RoR2.Projectile;
using AssassinMod.Characters.Entities.Decoy;
using R2API.Networking.Interfaces;
using System.Reflection;
using System.Linq;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

//rename this namespace
namespace AssassinMod
{
    //LoadNPCs and ValidateEnemy from https://github.com/MonsterSkinMan/GOTCE/blob/1b12c95e9857b4a79da86e7b533488a234f72ac5/GOTCE/Main.cs

    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class AssassinPlugin : BaseUnityPlugin
    {
        // if you do not change this, you are giving permission to deprecate the mod-
        //  please change the names to your own stuff, thanks
        //   this shouldn't even have to be said
        public const string MODUID = "com.HasteReapr.AssassinMod";
        public const string MODNAME = "AssassinMod";
        public const string MODVERSION = "2.0.0";

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string DEVELOPER_PREFIX = "HASTEREAPR";

        public static AssassinPlugin instance;

        public static bool emoteAPILoaded = false;
        public static bool scepterStandaloneLoaded = false;

        void Awake()
        {
            instance = this;

            emoteAPILoaded = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.weliveinasociety.CustomEmotesAPI");
            scepterStandaloneLoaded = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.DestroyedClone.AncientScepter");

            //easy to use logger
            Log.Init(Logger);

            // used when you want to properly set up language folders
            Modules.Language.Init();

            // character initialization
            new AssassinPlr().Initialize();

            // Hooks into things like ServerOnTakeDamage
            Hook();

            // Adds compatability for Emote API (Badass Emotes)
            if (emoteAPILoaded)
            {
                EmoteAPICompat();
            }
            
            // Loads AssassinDecoy
            new AssassinDecoy().Create();

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        }

        private void Hook()
        {
            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
            On.RoR2.CharacterBody.OnTakeDamageServer += CharacterBody_OnTakeDamageServer;
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
            EmotesAPI.CustomEmotesAPI.animChanged += CustomEmotesAPI_animChanged;
        }

        private void EmoteAPICompat()
        {
            On.RoR2.SurvivorCatalog.Init += (orig) =>
            {
                orig();
                foreach (var item in SurvivorCatalog.allSurvivorDefs)
                {
                    if (item.bodyPrefab.name == "AssassinSurvivorBody")
                    {
                        var skele = AssassinAssets.emoteAPISkeleton;
                        EmotesAPI.CustomEmotesAPI.ImportArmature(item.bodyPrefab, skele, jank: false);
                        skele.GetComponentInChildren<BoneMapper>().scale = 1f;
                    }
                }
            };
        }

        private void CustomEmotesAPI_animChanged(string newAnimation, BoneMapper mapper)
        {
            if (newAnimation != "none")
            {
                if (mapper.transform.name == "rogue_emote_skeleton" || mapper.transform.name == "rogue_emote_skeleton_tiny")
                {
                    //mapper.transform.parent.Find("Knife.L").gameObject.SetActive(false);
                    //mapper.transform.parent.Find("Knife.R").gameObject.SetActive(false);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_L").gameObject.SetActive(false);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_R").gameObject.SetActive(false);
                }
            }
            else
            {
                if (mapper.transform.name == "rogue_emote_skeleton" || mapper.transform.name == "rogue_emote_skeleton_tiny")
                {
                    //mapper.transform.parent.Find("Knife.L").gameObject.SetActive(true);
                    //mapper.transform.parent.Find("Knife.R").gameObject.SetActive(true);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_L").gameObject.SetActive(true);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_R").gameObject.SetActive(true);
                }
            }
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);

            if (self)
            {
                if (self.HasBuff(AssassinBuffs.madGodBuff))
                {
                    self.damage *= 1 + (0.075f * self.GetBuffCount(AssassinBuffs.madGodBuff));
                    self.attackSpeed *= 1 + (0.075f * self.GetBuffCount(AssassinBuffs.madGodBuff));
                }

                if (self.HasBuff(AssassinBuffs.hardcoreDrugsBuff))
                {
                    self.damage *= 1.05f;
                    self.attackSpeed *= 1.05f;
                    self.maxHealth *= 1.05f;
                    self.moveSpeed *= 1.05f;
                    self.regen *= 1.05f;
                }

                /*if (self.HasBuff(AssassinBuffs.poisonDebuff))
                {
                    self.armor *= 1 - (0.1f * self.GetBuffCount(AssassinBuffs.poisonDebuff));
                }*/
            }
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            if (self.body.HasBuff(AssassinBuffs.poisonDebuff))
            {
                damageInfo.damage *= 1f + (0.1f * self.body.GetBuffCount(AssassinBuffs.poisonDebuff));
            }

            orig(self, damageInfo);
        }

        private void CharacterBody_OnTakeDamageServer(On.RoR2.CharacterBody.orig_OnTakeDamageServer orig, CharacterBody self, DamageReport damageReport)
        {
            orig(self, damageReport);
            //"com.HasteReapr.AssassinMod_AssassinBody_0(Clone)"
            if (self.TryGetComponent(out AssassinPassiveController passiveCtrl))
            {
                if (passiveCtrl.GetPassiveType() == 0) // Rage Passive
                {
                    if (self.healthComponent.combinedHealth <= (self.healthComponent.fullCombinedHealth) * 0.6f)
                    {
                        self.AddTimedBuff(AssassinBuffs.madGodBuff, 3);
                    }
                }
                else if (passiveCtrl.GetPassiveType() == 1) // Poison Passive
                {
                    // If we do not have the cooldown debuff or we are drugged we can shoot, otherwise we have a 4.5 second cooldown
                    if (!self.HasBuff(AssassinBuffs.terrorCD) || self.HasBuff(AssassinBuffs.assassinDrugsBuff))
                    {
                        // This isn't 100% throwing in the direction of the attacker, and it does end up being kinda random, however this is the closest I can get right now.
                        var forward = self.corePosition;
                        var toOther = damageReport.attackerBody.corePosition;
                        var potDir = Vector3.Dot(forward, toOther);

                        ProjectileManager.instance.FireProjectile(new FireProjectileInfo()
                        {
                            owner = self.gameObject,
                            damage = AssassinStaticValues.poisonDamageCoef * self.damage,
                            force = 0,
                            position = new Vector3(self.gameObject.transform.position.x, self.gameObject.transform.position.y + 2, self.gameObject.transform.position.z),
                            rotation = Quaternion.Euler(0, potDir, 0),
                            projectilePrefab = AssassinAssets.poison,
                            speedOverride = 32,
                        });

                        // If we have the drugs buff we throw poison out regardless of cooldown, and don't apply the cooldown
                        if (!self.HasBuff(AssassinBuffs.assassinDrugsBuff))
                        {
                            self.AddTimedBuff(AssassinBuffs.terrorCD, 4.5f);
                        }
                        
                    }

                }
                else if (passiveCtrl.GetPassiveType() == 2) // Decoy Passive
                {
                    if(RoR2.Util.CheckRoll(5 + damageReport.damageInfo.procCoefficient, self.master))
                    {
                        new DecoySync(self.gameObject).Send(R2API.Networking.NetworkDestination.Server);
                    }
                }
            };

            //if the victim is hit by any of the poison stuff
            if (DamageAPI.HasModdedDamageType(damageReport.damageInfo, AssassinAssets.poisonDmgType))
            {
                DotController.InflictDot(self.gameObject, damageReport.attacker, AssassinBuffs.poisonDoT, 10, 0.1f);
            }

            //if the victim is hit by the smokebomb AOE apply stun
            if (DamageAPI.HasModdedDamageType(damageReport.damageInfo, AssassinAssets.smokeDmgType))
            {
                //damageReport.victimBody.AddTimedBuff(RoR2Content.Buffs., 2);
                RoR2.SetStateOnHurt.SetStunOnObject(damageReport.victimBody.gameObject, 2.5f);
            }

            //if the victim is hit by backstab damage type
            if (DamageAPI.HasModdedDamageType(damageReport.damageInfo, AssassinAssets.backStabDmg))
            { //then checks if its a backstab
                if (BackstabManager.IsBackstab(damageReport.attackerBody.characterDirection.forward, damageReport.victimBody))
                {
                    float curHP = damageReport.victimBody.healthComponent.combinedHealth;
                    float maxHP = damageReport.victimBody.healthComponent.fullCombinedHealth;
                    float dmg = 0;

                    if (AssassinConfig.BackstabInsta.Value || !damageReport.victimBody.isBoss)
                    {
                        //if we arent a boss, then do the damage thing
                        //just making sure we dont overflow & do negative damage
                        if ((curHP + maxHP) * 6 <= int.MaxValue)
                            dmg = (curHP + maxHP) * 6;
                        else
                            dmg = int.MaxValue;
                    }
                    else
                    {
                        if (RoR2.Util.CheckRoll(AssassinConfig.BackstabChance.Value, damageReport.attackerMaster))
                        {
                            //just making sure we dont overflow & do negative damage
                            if ((curHP + maxHP) * 6 <= int.MaxValue)
                                dmg = (curHP + maxHP) * 6;
                            else
                                dmg = int.MaxValue;
                        }
                        else
                            dmg = damageReport.victimBody.healthComponent.fullHealth * 0.25f + damageReport.victimBody.healthComponent.adaptiveArmorValue;
                    }

                    DamageInfo dmgInfo = new DamageInfo()
                    {
                        attacker = damageReport.attackerBody.gameObject,
                        crit = false,
                        damage = dmg,
                        damageColorIndex = DamageColorIndex.Bleed,
                        force = Vector3.zero,
                        procCoefficient = 0,
                        damageType = DamageType.Generic,
                        position = damageReport.victimBody.corePosition,
                        inflictor = damageReport.attackerBody.gameObject
                    };
                    damageReport.victimBody.healthComponent.TakeDamage(dmgInfo);
                    damageReport.attackerBody.AddTimedBuff(RoR2Content.Buffs.CloakSpeed, 2.5f);

                    //if (RoR2.Util.CheckRoll(Modules.Config.RechargeChance.Value, damageReport.attackerMaster)
                }
            }
        }

        public static void SetupScepterStandalone(string bodyName, SkillDef scepterSkill, SkillSlot skillSlot, int skillIndex)
        {
            if (scepterStandaloneLoaded) SetupScepterStandaloneInternal(bodyName, scepterSkill, skillSlot, skillIndex);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static void SetupScepterStandaloneInternal(string bodyName, SkillDef scepterSkill, SkillSlot skillSlot, int skillIndex)
        {
            AncientScepter.AncientScepterItem.instance.RegisterScepterSkill(scepterSkill, bodyName, skillSlot, skillIndex);
        }
    }
}
