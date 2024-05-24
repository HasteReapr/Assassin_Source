using RoR2;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AssassinMod.Modules.Characters
{
    internal class AssassinItemDisplays : ItemDisplaysBase
    {
        protected override void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules)
        {
            //paste all your displays here
            //sotv item displays not added yet. you can add them yourself from DLC1Content if you like. I believe in ya

            /* this is for corpsebloom but idk where that is
             * childName = "chest_bone",
             * localPos = new Vector3(-0.15451F, 1.54772F, 0.26434F),
             * localAngles = new Vector3(46.77417F, 344.7418F, 13.74543F),
             * localScale = new Vector3(0.3F, 0.3F, 0.3F)
             */

            #region Item Displays
            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.UtilitySkillMagazine,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(-0.08746F, 0.25501F, -0.2093F),
                            localAngles = new Vector3(316.4518F, 267.9371F, 240.5115F),
                            localScale = new Vector3(0.90546F, 0.95356F, 0.95356F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(0.08404F, 0.23266F, -0.16715F),
                            localAngles = new Vector3(322.2377F, 108.6782F, 114.7392F),
                            localScale = new Vector3(1.02635F, 1.02635F, 1.02635F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Lightning,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadDisplay("DisplayLightningArmRight"),
                                childName = "shoulder_bone.R",
                                localPos = new Vector3(-0.21382F, 0.13353F, -0.13642F),
                                localAngles = new Vector3(344.9889F, 228.7604F, 109.1015F),
                                localScale = new Vector3(0.15201F, 0.13203F, 0.12098F),
                                limbMask = LimbFlags.None
                            }
                        }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.CritGlasses,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGlasses"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00488F, 0.29433F, 0.21152F),
                            localAngles = new Vector3(353.6147F, 2.88389F, 181.8088F),
                            localScale = new Vector3(0.38293F, 0.38562F, 0.38562F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BarrierOnKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrooch"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(-0.0589F, 0.07879F, 0.39305F),
                            localAngles = new Vector3(332.0203F, 289.3985F, 270.0164F),
                            localScale = new Vector3(0.80132F, 0.80132F, 0.80132F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.FlatHealth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.21382F, 0.13353F, -0.13642F),
                            localAngles = new Vector3(344.9889F, 228.7604F, 109.1015F),
                            localScale = new Vector3(0.15201F, 0.13203F, 0.12098F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ChainLightning,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayUkulele"),
                            childName = "sash_bone",
                            localPos = new Vector3(-0.02734F, 0.17692F, 0.03425F),
                            localAngles = new Vector3(355.5147F, 266.609F, 355.2962F),
                            localScale = new Vector3(0.98839F, 0.98839F, 0.98839F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Missile,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.7842F, 0.29916F, -0.21048F),
                            localAngles = new Vector3(12.70373F, 355.2516F, 265.129F),
                            localScale = new Vector3(0.19094F, 0.19094F, 0.14041F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.FreeChest,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShippingRequestForm"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(0.27995F, 0.2384F, 0.08781F),
                            localAngles = new Vector3(283.7428F, 188.2156F, 58.43387F),
                            localScale = new Vector3(1.0066F, 1.0066F, 1.0066F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.GhostOnKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMask"),
                            childName = "head_bone",
                            localPos = new Vector3(0.16017F, 0.28562F, 0.13773F),
                            localAngles = new Vector3(343.869F, 59.40257F, 355.3245F),
                            localScale = new Vector3(1.03927F, 1.03927F, 1.14147F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.HealOnCrit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayScythe"),
                            childName = "arm_bone1.R",
                            localPos = new Vector3(-0.14952F, 0.26562F, -0.07885F),
                            localAngles = new Vector3(286.6102F, 132.7851F, 324.033F),
                            localScale = new Vector3(0.3F, 0.3F, 0.3F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.MissileVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMissileLauncherVoid"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.7842F, 0.29916F, -0.21048F),
                            localAngles = new Vector3(12.70373F, 355.2516F, 265.129F),
                            localScale = new Vector3(0.19094F, 0.19094F, 0.14041F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.WarCryOnMultiKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPauldron"),
                            childName = "arm_bone1.R",
                            localPos = new Vector3(-0.10274F, 0.38418F, -0.06262F),
                            localAngles = new Vector3(72.61224F, 267.1974F, 17.22925F),
                            localScale = new Vector3(0.64969F, 0.51654F, 0.64969F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Thorns,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                            childName = "arm_bone2.L",
                            localPos = new Vector3(0.03271F, 0.06816F, 0.02364F),
                            localAngles = new Vector3(286.4488F, 163.4678F, 55.57799F),
                            localScale = new Vector3(1.07279F, 1.07279F, 0.71519F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.AttackSpeedOnCrit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                            childName = "head_bone",
                            localPos = new Vector3(0.03633F, 0.54505F, -0.00281F),
                            localAngles = new Vector3(349.2842F, 355.4055F, 355.4931F),
                            localScale = new Vector3(0.70716F, 0.70716F, 0.84246F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.IncreaseHealing,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAntler"),
                            childName = "head_bone",
                            localPos = new Vector3(0.20504F, 0.39353F, 0.04143F),
                            localAngles = new Vector3(357.4268F, 83.94082F, 335.9606F),
                            localScale = new Vector3(0.36603F, 0.36603F, 0.36603F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAntler"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.23151F, 0.37162F, 0.03578F),
                            localAngles = new Vector3(7.39772F, 104.8897F, 338.7216F),
                            localScale = new Vector3(0.3353F, 0.3353F, -0.3353F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.KillEliteFrenzy,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.01843F, 0.13057F, 0.24075F),
                            localAngles = new Vector3(284.7835F, 137.9824F, 50.95368F),
                            localScale = new Vector3(0.44628F, 0.44628F, 0.44628F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.NovaOnHeal,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                            childName = "head_bone",
                            localPos = new Vector3(0.15708F, 0.46505F, -0.03626F),
                            localAngles = new Vector3(296.659F, 227.2176F, 302.4652F),
                            localScale = new Vector3(-0.64423F, 0.64423F, 0.64423F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.17434F, 0.44496F, -0.03913F),
                            localAngles = new Vector3(285.0626F, 109.0266F, 95.69797F),
                            localScale = new Vector3(0.63383F, 0.63383F, 0.63383F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.CritGlassesVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGlassesVoid"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00488F, 0.29433F, 0.21152F),
                            localAngles = new Vector3(353.6147F, 2.88389F, 181.8088F),
                            localScale = new Vector3(0.38293F, 0.38562F, 0.38562F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.ChainLightningVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayUkuleleVoid"),
                            childName = "sash_bone",
                            localPos = new Vector3(-0.02734F, 0.17692F, 0.03425F),
                            localAngles = new Vector3(355.5147F, 266.609F, 355.2962F),
                            localScale = new Vector3(0.98839F, 0.98839F, 0.98839F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.GoldOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00419F, 0.38614F, -0.07557F),
                            localAngles = new Vector3(0.80009F, 356.5351F, 2.95024F),
                            localScale = new Vector3(2.02998F, 2.02998F, 2.07482F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.RepeatHeal,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCorpseFlower"),
                            childName = "Body",
                            localPos = new Vector3(0.26814F, 0.11961F, -0.00742F),
                            localAngles = new Vector3(90F, 90F, 0F),
                            localScale = new Vector3(0.3F, 0.3F, 0.3F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Bear,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBear"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.37746F, 0.24388F, 0.12479F),
                            localAngles = new Vector3(19.59721F, 350.8814F, 284.6606F),
                            localScale = new Vector3(0.30041F, 0.30041F, 0.30041F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ExtraLife,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHippo"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(-0.03257F, 0.33779F, -0.23812F),
                            localAngles = new Vector3(3.13984F, 178.4565F, 178.3929F),
                            localScale = new Vector3(0.27304F, 0.27304F, 0.27304F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.BearVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBearVoid"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.37746F, 0.24388F, 0.12479F),
                            localAngles = new Vector3(19.59721F, 350.8814F, 284.6606F),
                            localScale = new Vector3(0.30041F, 0.30041F, 0.30041F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.ExtraLifeVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHippoVoid"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(-0.03257F, 0.33779F, -0.23812F),
                            localAngles = new Vector3(3.13984F, 178.4565F, 178.3929F),
                            localScale = new Vector3(0.27304F, 0.27304F, 0.27304F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.FireballsOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.03637F, 0.47647F, -0.28881F),
                            localAngles = new Vector3(331.1805F, 205.0947F, 204.4009F),
                            localScale = new Vector3(0.05448F, 0.05448F, 0.05448F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.LightningStrikeOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayChargedPerforator"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.01755F, 0.0963F, 0.31849F),
                            localAngles = new Vector3(304.0607F, 24.69852F, 341.3582F),
                            localScale = new Vector3(1.34008F, 1.34008F, 1.34008F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Clover,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayClover"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.01329F, 0.57845F, -0.03745F),
                            localAngles = new Vector3(341.3203F, 154.3943F, 349.66F),
                            localScale = new Vector3(1.06664F, 1.06664F, 1.06664F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.ImmuneToDebuff,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRainCoatBelt"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.03132F, 0.9936F, 0.10103F),
                            localAngles = new Vector3(22.17636F, 8.20519F, 353.5109F),
                            localScale = new Vector3(2.33336F, 2.33336F, 2.33336F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.IceRing,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayIceRing"),
                            childName = "Hand_R",
                            localPos = new Vector3(0.00506F, 0.31799F, 0.10338F),
                            localAngles = new Vector3(337.8216F, 73.71067F, 277.3688F),
                            localScale = new Vector3(0.3517F, 0.3517F, 0.3517F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.FireRing,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFireRing"),
                            childName = "Hand_L",
                            localPos = new Vector3(-0.00157F, 0.31568F, 0.10528F),
                            localAngles = new Vector3(14.79725F, 107.3559F, 265.6024F),
                            localScale = new Vector3(0.38109F, 0.38109F, 0.38109F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.ElementalRingVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayVoidRing"),
                            childName = "Hand_L",
                            localPos = new Vector3(0.00019F, 0.31669F, 0.10443F),
                            localAngles = new Vector3(345.3617F, 287.6479F, 341.6338F),
                            localScale = new Vector3(0.3786F, 0.3786F, 0.3786F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayVoidRing"),
                            childName = "Hand_R",
                            localPos = new Vector3(0.01291F, 0.31783F, 0.1075F),
                            localAngles = new Vector3(345.4598F, 69.00956F, 7.03533F),
                            localScale = new Vector3(0.40511F, 0.40511F, 0.40511F),
                            limbMask = LimbFlags.None
                        }

                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.FallBoots,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravBoots"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(-0.00437F, 0.76508F, 0.01359F),
                            localAngles = new Vector3(17.52023F, 172.7221F, 0.26291F),
                            localScale = new Vector3(0.39918F, 0.39918F, 0.39918F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravBoots"),
                            childName = "leg_bone2.L",
                            localPos = new Vector3(-0.01436F, 0.87874F, -0.02053F),
                            localAngles = new Vector3(10.05663F, 172.9236F, 357.2649F),
                            localScale = new Vector3(0.37387F, 0.37387F, 0.37387F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.CommandMissile,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMissileRack"),
                            childName = "arm_bone2.L",
                            localPos = new Vector3(0.07645F, 0.45884F, -0.06014F),
                            localAngles = new Vector3(66.88813F, 115.5367F, 355.6285F),
                            localScale = new Vector3(0.44833F, 0.84029F, 0.84029F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Recycle,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRecycler"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(-0.00964F, 0.33494F, -0.25537F),
                            localAngles = new Vector3(276.3258F, 180F, 171.5145F),
                            localScale = new Vector3(0.0939F, 0.0939F, 0.0939F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.QuestVolatileBattery,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.00495F, 0.69081F, -0.57207F),
                            localAngles = new Vector3(338.8339F, 182.8084F, 359.3503F),
                            localScale = new Vector3(0.55468F, 0.55468F, 0.55468F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Hoof,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHoof"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(-0.01419F, 0.57201F, 0.2566F),
                            localAngles = new Vector3(70.38567F, 7.04479F, 274.0982F),
                            localScale = new Vector3(0.09996F, 0.09996F, 0.09996F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule {
                            ruleType = ItemDisplayRuleType.LimbMask,
                            limbMask = LimbFlags.RightCalf
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SprintBonus,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySoda"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.35856F, 0.08423F, -0.12438F),
                            localAngles = new Vector3(354.2379F, 344.1017F, 242.2419F),
                            localScale = new Vector3(0.4551F, 0.4551F, 0.4551F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ArmorPlate,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                            childName = "leg_bone1.L",
                            localPos = new Vector3(-0.03232F, 0.60566F, -0.13327F),
                            localAngles = new Vector3(82.77757F, 116.377F, 131.0579F),
                            localScale = new Vector3(0.59759F, 0.59759F, 0.61124F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.NearbyDamageBonus,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDiamond"),
                            childName = "sash_bone",
                            localPos = new Vector3(-0.13714F, 0.03576F, 0.05731F),
                            localAngles = new Vector3(45.2856F, 341.1931F, 41.96426F),
                            localScale = new Vector3(0.11563F, 0.11563F, 0.11563F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.DeathMark,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDeathMark"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00363F, 0.31351F, 0.09729F),
                            localAngles = new Vector3(272.7928F, 204.4545F, 153.627F),
                            localScale = new Vector3(0.09976F, 0.09976F, 0.09976F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.WardOnLevel,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarbanner"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(-0.14265F, 0.33153F, -0.16599F),
                            localAngles = new Vector3(19.16613F, 108.9511F, 177.3409F),
                            localScale = new Vector3(0.34321F, 0.40218F, 0.34321F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.TeamWarCry,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.04354F, 0.47865F, -0.59812F),
                            localAngles = new Vector3(347.4275F, 181.334F, 0F),
                            localScale = new Vector3(0.17975F, 0.17975F, 0.17975F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Phasing,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStealthkit"),
                            childName = "arm_bone2.L",
                            localPos = new Vector3(0.0594F, 0.60096F, -0.05848F),
                            localAngles = new Vector3(74.79876F, 108.0372F, 153.355F),
                            localScale = new Vector3(0.25524F, 0.3871F, 0.25F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.DeathProjectile,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                            childName = "leg_bone2.L",
                            localPos = new Vector3(0.15301F, 0.70715F, -0.00001F),
                            localAngles = new Vector3(358.5305F, 87.07259F, 174.9816F),
                            localScale = new Vector3(0.1F, 0.1F, 0.1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.CritOnUse,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00968F, 0.25027F, 0.46826F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(0.37583F, 0.37583F, 0.37583F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Jetpack,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBugWings"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.00001F, 0.61836F, -0.49258F),
                            localAngles = new Vector3(42.74896F, 0F, 0F),
                            localScale = new Vector3(0.30397F, 0.30397F, 0.30397F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Scanner,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayScanner"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(-0.01084F, 0.5262F, -0.02976F),
                            localAngles = new Vector3(13.13619F, 124.0224F, 272.7651F),
                            localScale = new Vector3(0.53807F, 0.53807F, 0.53807F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SprintOutOfCombat,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWhip"),
                            childName = "leg_bone1.L",
                            localPos = new Vector3(-0.19348F, 0.40192F, -0.04665F),
                            localAngles = new Vector3(34.77676F, 351.4819F, 196.2655F),
                            localScale = new Vector3(0.64153F, 0.64153F, 0.64153F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.PersonalShield,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                            childName = "head_bone",
                            localPos = new Vector3(0F, 0.32625F, -0.26907F),
                            localAngles = new Vector3(77.35704F, 0F, 0F),
                            localScale = new Vector3(0.24902F, 0.24902F, 0.24902F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.GoldGat,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGoldGat"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.32607F, 0.24003F, -0.16686F),
                            localAngles = new Vector3(288.5011F, 345.4368F, 55.98213F),
                            localScale = new Vector3(0.15532F, 0.15532F, 0.15532F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.AttackSpeedAndMoveSpeed,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCoffee"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.04919F, 0.32066F, -0.387F),
                            localAngles = new Vector3(325.7024F, 143.2338F, 128.0885F),
                            localScale = new Vector3(0.33884F, 0.33884F, 0.33884F),
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.LifestealOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.05145F, 0.78955F, -0.29861F),
                            localAngles = new Vector3(51.34856F, 49.90535F, 300.5026F),
                            localScale = new Vector3(0.14432F, 0.14432F, 0.14432F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BossDamageBonus,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAPRound"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.19564F, 0.46103F, 0.37411F),
                            localAngles = new Vector3(65.112F, 318.5601F, 322.5167F),
                            localScale = new Vector3(0.5F, 0.5F, 0.5F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.LaserTurbine,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.99269F, 1.56637F, -0.74151F),
                            localAngles = new Vector3(280.0347F, 183.033F, 0.23934F),
                            localScale = new Vector3(0.94241F, 0.94241F, 0.94241F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SprintWisp,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.16427F, 0.40111F, 0.04106F),
                            localAngles = new Vector3(319.5838F, 264.1793F, 155.2075F),
                            localScale = new Vector3(0.3337F, 0.3337F, 0.3337F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BarrierOnOverHeal,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAegis"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.04183F, 0.53054F, -0.55556F),
                            localAngles = new Vector3(277.1357F, 322.6791F, 213.4772F),
                            localScale = new Vector3(0.54146F, 0.54146F, 0.54146F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Talisman,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTalisman"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.11769F, 2.71215F, -0.4493F),
                            localAngles = new Vector3(341.5118F, 16.99598F, 1.46124F),
                            localScale = new Vector3(0.75F, 0.75F, 0.75F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.FireBallDash,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEgg"),
                            childName = "head_bone",
                            localPos = new Vector3(0F, 0.6324F, 0.05405F),
                            localAngles = new Vector3(271.3991F, 0F, 0F),
                            localScale = new Vector3(0.3F, 0.3F, 0.3F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Fruit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFruit"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(-0.23042F, 0.30119F, 0.04917F),
                            localAngles = new Vector3(67.04493F, 226.011F, 141.4427F),
                            localScale = new Vector3(0.33818F, 0.33818F, 0.33818F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.GainArmor,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.07509F, 0.75129F, -1.96506F),
                            localAngles = new Vector3(286.3719F, 0F, 0F),
                            localScale = new Vector3(1.30865F, 1.30865F, 1.30865F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Cleanse,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWaterPack"),
                            childName = "leg_bone1.L",
                            localPos = new Vector3(-0.23068F, 0.88037F, -0.03597F),
                            localAngles = new Vector3(2.09493F, 257.5988F, 169.3906F),
                            localScale = new Vector3(0.11473F, 0.11473F, 0.11473F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.DroneBackup,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRadio"),
                            childName = "sash_bone",
                            localPos = new Vector3(0.00256F, -0.05873F, -0.02196F),
                            localAngles = new Vector3(89.35109F, 348.0216F, 169.7081F),
                            localScale = new Vector3(0.65609F, 0.65609F, 0.65609F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Lightning,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            childName = "chest_bone",
                            localPos = new Vector3(0.89093F, 0.94549F, -0.40136F),
                            localAngles = new Vector3(356.2512F, 93.22958F, 272.3396F),
                            localScale = new Vector3(-2.02392F, 2.02392F, 2.02392F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.IgniteOnKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGasoline"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.33352F, 0.60081F, -0.07657F),
                            localAngles = new Vector3(75.57418F, 315.9392F, 133.5293F),
                            localScale = new Vector3(1.06896F, 1.06896F, 1.06896F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Pearl,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPearl"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.06234F, 0.92513F, -0.21484F),
                            localAngles = new Vector3(90F, 0F, 0F),
                            localScale = new Vector3(0.68467F, 0.68467F, 0.68467F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ShinyPearl,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                            childName = "chest_bone",
                            localPos = new Vector3(0F, 0F, 0F),
                            localAngles = new Vector3(279.3386F, 219.4737F, 132.1919F),
                            localScale = new Vector3(0.63429F, 0.63429F, 0.63429F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Blackhole,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravCube"),
                            childName = "chest_bone",
                            localPos = new Vector3(-1.17189F, 2.79983F, -0.10942F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Saw,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySawmerangFollower"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.00001F, 0.47033F, -1.35286F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(0.20537F, 0.20537F, 0.20537F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.CloverVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCloverVoid"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.01329F, 0.57845F, -0.03745F),
                            localAngles = new Vector3(341.3203F, 154.3943F, 349.66F),
                            localScale = new Vector3(1.06664F, 1.06664F, 1.06664F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Icicle,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0585F, 1.52552F, -1.06152F),
                            localAngles = new Vector3(277.5662F, 180F, 180F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.BleedOnHitVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTriTipVoid"),
                            childName = "head_bone",
                            localPos = new Vector3(0.45581F, 0.34966F, 0.17757F),
                            localAngles = new Vector3(13.34309F, 252.2794F, 155.7867F),
                            localScale = new Vector3(0.42693F, 0.42693F, 0.42693F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.CritDamage,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLaserSight"),
                            childName = "arm_bone2.R",
                            localPos = new Vector3(-0.0987F, 0.21847F, -0.07741F),
                            localAngles = new Vector3(353.1146F, 159.2933F, 280.144F),
                            localScale = new Vector3(0.15F, 0.15F, 0.15F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Dagger,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDagger"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.1021F, 0.19523F, -0.0001F),
                            localAngles = new Vector3(344.8068F, 356.9446F, 127.41F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BleedOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTriTip"),
                            childName = "head_bone",
                            localPos = new Vector3(0.45581F, 0.34966F, 0.17757F),
                            localAngles = new Vector3(13.34309F, 252.2794F, 155.7867F),
                            localScale = new Vector3(0.42693F, 0.42693F, 0.42693F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Meteor,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMeteor"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.4722F, 1.30402F, -1.36033F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Tonic,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTonic"),
                            childName = "stomach_bone",
                            localPos = new Vector3(-0.11843F, 0.40578F, 0.29072F),
                            localAngles = new Vector3(354.4241F, 352.4884F, 323.6143F),
                            localScale = new Vector3(0.25F, 0.25F, 0.25F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.Molotov,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMolotov"),
                            childName = "stomach_bone",
                            localPos = new Vector3(-0.11823F, 0.30453F, 0.32006F),
                            localAngles = new Vector3(346.3069F, 344.5025F, 316.6638F),
                            localScale = new Vector3(0.33582F, 0.33582F, 0.33582F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.Gateway,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayVase"),
                            childName = "Hand_R",
                            localPos = new Vector3(0.04065F, 0.44896F, 0.21435F),
                            localAngles = new Vector3(31.12077F, 44.29528F, 57.779F),
                            localScale = new Vector3(0.50439F, 0.50439F, 0.50439F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.GummyClone,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGummyClone"),
                            childName = "foot_bone.R",
                            localPos = new Vector3(0.00001F, 0.39506F, -0.11244F),
                            localAngles = new Vector3(353.8331F, 0F, 0F),
                            localScale = new Vector3(0.29392F, 0.29392F, 0.29392F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.MultiShopCard,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayExecutiveCard"),
                            childName = "Body",
                            localPos = new Vector3(0.63366F, 0.73318F, 3.64661F),
                            localAngles = new Vector3(52.78926F, 89.14806F, 323.3451F),
                            localScale = new Vector3(1.54142F, 1.54142F, 1.54142F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.VendingMachine,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayVendingMachine"),
                            childName = "sash_bone",
                        localPos = new Vector3(0F, -0.02508F, 0.12244F),
                        localAngles = new Vector3(87.10693F, 180F, 180F),
                        localScale = new Vector3(0.24177F, 0.24177F, 0.24177F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.EliteVoidEquipment,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAffixVoid"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.0188F, 0.49841F, 0.13849F),
                            localAngles = new Vector3(24.03837F, 355.3085F, 4.26067F),
                            localScale = new Vector3(0.2F, 0.2F, 0.2F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.AffixRed,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.25119F, 0.33307F, 0.01042F),
                            localAngles = new Vector3(45.45317F, 307.1295F, 88.64592F),
                            localScale = new Vector3(0.1F, 0.1F, 0.1F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                            childName = "head_bone",
                            localPos = new Vector3(0.22282F, 0.30855F, 0.00433F),
                            localAngles = new Vector3(303.2574F, 239.1796F, 80.74187F),
                            localScale = new Vector3(0.1F, 0.1F, -0.1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.AffixWhite,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                            childName = "head_bone",
                            localPos = new Vector3(0.00764F, 0.83172F, -0.09156F),
                            localAngles = new Vector3(270F, 357.8918F, 0F),
                            localScale = new Vector3(0.04511F, 0.04511F, 0.04511F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.AffixBlue,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.0053F, 0.38352F, 0.20727F),
                            localAngles = new Vector3(346.6182F, 359.1546F, 358.3831F),
                            localScale = new Vector3(0.2F, 0.2F, 0.2F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.0072F, 0.28652F, 0.24488F),
                            localAngles = new Vector3(345.3463F, 2.33069F, 357.8633F),
                            localScale = new Vector3(0.25F, 0.25F, 0.25F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.BossHunter,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTricornGhost"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.02847F, 0.62079F, -0.16016F),
                            localAngles = new Vector3(29.93746F, 2.60287F, 3.39484F),
                            localScale = new Vector3(2.02989F, 2.02989F, 2.02989F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBlunderbuss"),
                            childName = "chest_bone",
                            localPos = new Vector3(-1.69271F, 1.27093F, -0.27204F),
                            localAngles = new Vector3(86.2029F, 180F, 151.4552F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Equipment.BossHunterConsumed,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTricornUsed"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.02847F, 0.62079F, -0.16016F),
                            localAngles = new Vector3(29.93746F, 2.60287F, 3.39484F),
                            localScale = new Vector3(2.02989F, 2.02989F, 2.02989F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/DLC1/EliteEarth/EliteEarthEquipment.asset").WaitForCompletion(),
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteMendingAntlers"),
                            childName = "Cloak",
                            localPos = new Vector3(0.00443F, 0.18664F, 0.00001F),
                            localAngles = new Vector3(0F, 90F, 0F),
                            localScale = new Vector3(0.75F, 0.75F, 0.75F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.AffixPoison,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.01301F, 0.59266F, -0.03136F),
                            localAngles = new Vector3(270F, 90F, 0F),
                            localScale = new Vector3(0.05F, 0.05F, 0.05F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.AffixHaunted,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.00019F, 0.49415F, -0.00011F),
                            localAngles = new Vector3(270.1678F, 78.8234F, 275.191F),
                            localScale = new Vector3(0.07613F, 0.07613F, 0.07613F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.OutOfCombatArmor,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayOddlyShapedOpal"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(0.03758F, 0.01019F, 0.3854F),
                            localAngles = new Vector3(350.2323F, 160.0014F, 263.7628F),
                            localScale = new Vector3(0.33817F, 0.33817F, 0.33817F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Bandolier,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBandolier"),
                            childName = "stomach_bone",
                            localPos = new Vector3(-0.03029F, 0.23928F, -0.02112F),
                            localAngles = new Vector3(278.1374F, 158.3377F, 3.20215F),
                            localScale = new Vector3(0.9722F, 1.07161F, 0.88318F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Behemoth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBehemoth"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.30261F, 0.25273F, -0.0075F),
                            localAngles = new Vector3(351.6104F, 270.1623F, 69.90057F),
                            localScale = new Vector3(0.14669F, 0.14669F, 0.14669F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.FragileDamageBonus,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDelicateWatch"),
                            childName = "arm_bone2.R",
                            localPos = new Vector3(-0.01547F, 0.48986F, -0.00839F),
                            localAngles = new Vector3(79.9189F, 238.2563F, 350.3607F),
                            localScale = new Vector3(0.68182F, 1.31732F, 0.8906F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.BFG,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBFG"),
                            childName = "arm_bone2.R",
                            localPos = new Vector3(-0.00572F, 0.10615F, -0.06234F),
                            localAngles = new Vector3(276.009F, 333.5269F, 81.75227F),
                            localScale = new Vector3(0.5F, 0.5F, 0.5F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ArmorReductionOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.41218F, 1.0173F, 0.09631F),
                            localAngles = new Vector3(273.18F, 220.8306F, 238.2861F),
                            localScale = new Vector3(0.35851F, 0.35851F, 0.35851F),
                            limbMask= LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SprintArmor,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBuckler"),
                            childName = "Hand_L",
                            localPos = new Vector3(0.02166F, 0.20737F, 0.00523F),
                            localAngles = new Vector3(345.1746F, 111.4334F, 249.7901F),
                            localScale = new Vector3(0.28085F, 0.28085F, 0.28085F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Feather,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFeather"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.28191F, 0.2814F, -0.01221F),
                            localAngles = new Vector3(18.50289F, 8.38873F, 72.41968F),
                            localScale = new Vector3(0.02706F, 0.02706F, 0.02706F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Mushroom,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMushroom"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.05263F, 0.71433F, -0.42739F),
                            localAngles = new Vector3(6.92186F, 98.59971F, 312.4862F),
                            localScale = new Vector3(0.07876F, 0.07876F, 0.07876F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.MushroomVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMushroomVoid"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.0403F, 0.77694F, -0.38558F),
                            localAngles = new Vector3(12.1926F, 107.316F, 313.325F),
                            localScale = new Vector3(0.08434F, 0.08434F, 0.08434F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Crowbar,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCrowbar"),
                            childName = "arm_bone2.L",
                            localPos = new Vector3(0.11624F, 0.36546F, -0.02587F),
                            localAngles = new Vector3(3.54169F, 358.9952F, 7.41696F),
                            localScale = new Vector3(0.3704F, 0.3704F, 0.3704F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.EquipmentMagazine,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBattery"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(0.13307F, 0.46018F, -0.00326F),
                            localAngles = new Vector3(84.07951F, 31.55985F, 149.9839F),
                            localScale = new Vector3(0.2F, 0.2F, 0.2F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.EquipmentMagazineVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFuelCellVoid"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(0.13307F, 0.46018F, -0.00326F),
                            localAngles = new Vector3(84.07951F, 31.55985F, 149.9839F),
                            localScale = new Vector3(0.2F, 0.2F, 0.2F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ShockNearby,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.01545F, 0.57462F, -0.33286F),
                            localAngles = new Vector3(68.44849F, 192.0109F, 7.37866F),
                            localScale = new Vector3(0.3F, 0.3F, 0.3F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ShieldOnly,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldBug"),
                            childName = "head_bone",
                            localPos = new Vector3(0.21236F, 0.4103F, 0.15153F),
                            localAngles = new Vector3(3.79712F, 197.4274F, 56.7166F),
                            localScale = new Vector3(0.23566F, 0.23566F, 0.23566F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldBug"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.20133F, 0.43623F, 0.13292F),
                            localAngles = new Vector3(354.9525F, 148.9149F, 288.3136F),
                            localScale = new Vector3(-0.15F, 0.15F, 0.15F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.MoreMissile,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayICBM"),
                            childName = "foot_bone.R",
                            localPos = new Vector3(0.11007F, 0.08872F, 0.08643F),
                            localAngles = new Vector3(349.0779F, 267.9904F, 131.398F),
                            localScale = new Vector3(0.08111F, 0.08111F, 0.08111F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayICBM"),
                            childName = "foot_bone.R",
                            localPos = new Vector3(-0.09989F, 0.01752F, 0.10636F),
                            localAngles = new Vector3(65.32842F, 12.09799F, 182.7718F),
                            localScale = new Vector3(0.0751F, 0.0751F, 0.0751F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayICBM"),
                            childName = "foot_bone.L",
                            localPos = new Vector3(-0.10176F, 0.09744F, 0.0865F),
                            localAngles = new Vector3(356.1411F, 265.1335F, 131.7341F),
                            localScale = new Vector3(0.07437F, 0.07437F, 0.07437F),
                            limbMask = LimbFlags.None
                        },

                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayICBM"),
                            childName = "foot_bone.L",
                            localPos = new Vector3(0.09349F, 0.09601F, 0.069F),
                            localAngles = new Vector3(46.36808F, 355.2546F, 176.809F),
                            localScale = new Vector3(0.07175F, 0.07175F, 0.07175F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.HalfSpeedDoubleHealth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLunarShoulderStone"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(0.08339F, -0.01481F, -0.16342F),
                            localAngles = new Vector3(352.9684F, 79.28011F, 196.0405F),
                            localScale = new Vector3(0.84657F, 0.84657F, 0.84657F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.PrimarySkillShuriken,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShuriken"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.15743F, 0.37332F, 0.39523F),
                            localAngles = new Vector3(339.8979F, 358.2234F, 7.85798F),
                            localScale = new Vector3(0.40232F, 0.40232F, 0.40232F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.HeadHunter,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySkullcrown"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.01871F, 0.63311F, 0.02643F),
                            localAngles = new Vector3(0F, 0F, 2.38478F),
                            localScale = new Vector3(1.21688F, 0.34861F, 0.18726F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.RegeneratingScrap,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRegeneratingScrap"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.16443F, 0.56894F, 0.27631F),
                            localAngles = new Vector3(21.86574F, 162.4645F, 159.5438F),
                            localScale = new Vector3(0.25F, 0.25F, 0.25F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.StrengthenBurn,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGasTank"),
                            childName = "leg_bone2.L",
                            localPos = new Vector3(-0.26068F, 0.37576F, 0.04531F),
                            localAngles = new Vector3(3.09221F, 180F, 194.2072F),
                            localScale = new Vector3(0.23436F, 0.23436F, 0.23436F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BounceNearby,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHook"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.1808F, 0.23044F, -0.16321F),
                            localAngles = new Vector3(355.6339F, 218.5981F, 270.3764F),
                            localScale = new Vector3(0.27369F, 0.27369F, 0.27369F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.JumpBoost,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWaxBird"),
                            childName = "head_bone",
                            localPos = new Vector3(0.00284F, -0.23308F, -0.1199F),
                            localAngles = new Vector3(0.63011F, 359.5909F, 359.6263F),
                            localScale = new Vector3(1.31116F, 1.31116F, 1.31116F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Infusion,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayInfusion"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.10666F, 0.04038F, -0.17465F),
                            localAngles = new Vector3(357.705F, 124.5509F, 178.0862F),
                            localScale = new Vector3(0.79745F, 0.79745F, 0.79745F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Plant,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.04457F, 0.67758F, -0.1953F),
                            localAngles = new Vector3(270F, 0F, 0F),
                            localScale = new Vector3(0.1F, 0.1F, 0.1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Syringe,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.06894F, 0.62643F, 0.29985F),
                            localAngles = new Vector3(343.0648F, 89.67523F, 83.26337F),
                            localScale = new Vector3(0.15F, 0.15F, 0.15F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ExecuteLowHealthElite,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGuillotine"),
                            childName = "stomach_bone",
                            localPos = new Vector3(0.49639F, 0.40753F, -0.2234F),
                            localAngles = new Vector3(281.9876F, 147.1306F, 317.0216F),
                            localScale = new Vector3(0.37511F, 0.37511F, 0.37511F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Medkit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMedkit"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.20131F, 0.21538F, -0.32027F),
                            localAngles = new Vector3(70.16709F, 33.11423F, 27.43604F),
                            localScale = new Vector3(0.7333F, 0.7333F, 0.7333F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Seed,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySeed"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(0.0543F, 0.24017F, 0.26735F),
                            localAngles = new Vector3(20.22448F, 357.4559F, 151.4534F),
                            localScale = new Vector3(0.08254F, 0.08254F, 0.08254F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.StunChanceOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                            childName = "stomach_bone",
                            localPos = new Vector3(-0.08295F, 0.37321F, 0.31268F),
                            localAngles = new Vector3(307.839F, 106.0993F, 148.758F),
                            localScale = new Vector3(0.87384F, 0.87384F, 0.87384F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.HealWhileSafe,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySnail"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.11611F, 0.03129F, -0.28092F),
                            localAngles = new Vector3(27.49218F, 321.4192F, 72.7935F),
                            localScale = new Vector3(0.08489F, 0.08489F, 0.08489F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Tooth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0568F, 0.67399F, 0.34767F),
                            localAngles = new Vector3(36.71989F, 37.81435F, 206.8527F),
                            localScale = new Vector3(2F, 2F, 2F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0568F, 0.67399F, 0.34767F),
                            localAngles = new Vector3(36.71989F, 37.81435F, 206.8527F),
                            localScale = new Vector3(2F, 2F, 2F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0568F, 0.67399F, 0.34767F),
                            localAngles = new Vector3(36.71989F, 37.81435F, 206.8527F),
                            localScale = new Vector3(2F, 2F, 2F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0568F, 0.67399F, 0.34767F),
                            localAngles = new Vector3(36.71989F, 37.81435F, 206.8527F),
                            localScale = new Vector3(2F, 2F, 2F),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.0568F, 0.67399F, 0.34767F),
                            localAngles = new Vector3(36.71989F, 37.81435F, 206.8527F),
                            localScale = new Vector3(2F, 2F, 2F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.TitanGoldDuringTP,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(0.20041F, 0.46078F, 0.18045F),
                            localAngles = new Vector3(343.1166F, 83.82623F, 268.8954F),
                            localScale = new Vector3(0.25F, 0.25F, 0.25F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SlowOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBauble"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(-0.14819F, 0.36805F, -0.01483F),
                            localAngles = new Vector3(10.0684F, 149.3445F, 72.35251F),
                            localScale = new Vector3(0.48073F, 0.48073F, 0.48073F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.SlowOnHitVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBaubleVoid"),
                            childName = "leg_bone2.R",
                            localPos = new Vector3(-0.14819F, 0.36805F, -0.01483F),
                            localAngles = new Vector3(10.0684F, 149.3445F, 72.35251F),
                            localScale = new Vector3(0.48073F, 0.48073F, 0.48073F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Firework,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFirework"),
                            childName = "leg_bone2.L",
                            localPos = new Vector3(-0.33802F, 0.22481F, 0.09448F),
                            localAngles = new Vector3(72.4771F, 279.0273F, 312.3333F),
                            localScale = new Vector3(0.59854F, 0.59854F, 0.59854F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.GoldOnHurt,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRollOfPennies"),
                            childName = "chest_bone",
                            localPos = new Vector3(0.34057F, 0.49371F, 0.34244F),
                            localAngles = new Vector3(350.2252F, 356.5322F, 2.7449F),
                            localScale = new Vector3(0.7F, 0.7F, 0.7F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.HalfAttackSpeedHalfCooldowns,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLunarShoulderNature"),
                            childName = "leg_bone2.L",
                            localPos = new Vector3(-0.02223F, 0.15818F, -0.10775F),
                            localAngles = new Vector3(8.355F, 76.51034F, 232.6104F),
                            localScale = new Vector3(1.43888F, 1.43888F, 1.43888F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BeetleGland,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.16056F, 0.42054F, -0.13934F),
                            localAngles = new Vector3(20.8357F, 40.75114F, 120.0425F),
                            localScale = new Vector3(0.1F, 0.1F, 0.1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Knurl,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayKnurl"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.11613F, 0.09321F, -0.25915F),
                            localAngles = new Vector3(22.62041F, 26.94908F, 94.8151F),
                            localScale = new Vector3(0.07F, 0.07F, 0.07F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.CrippleWard,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEffigy"),
                            childName = "Clothes",
                            localPos = new Vector3(0.1326F, 0.00825F, 0.01472F),
                            localAngles = new Vector3(-0.00001F, 180F, 270F),
                            localScale = new Vector3(0, 0, 0),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Equipment.BurnNearby,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPotion"),
                            childName = "stomach_bone",
                            localPos = new Vector3(0.28451F, -0.28811F, -0.22044F),
                            localAngles = new Vector3(353.5342F, 153.7475F, 291.9261F),
                            localScale = new Vector3(0.05469F, 0.05469F, 0.05469F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.HealingPotion,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHealingPotion"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.35487F, 0.11751F, -0.15063F),
                            localAngles = new Vector3(343.2088F, 358.3968F, 192.6443F),
                            localScale = new Vector3(0.08307F, 0.08307F, 0.08307F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.EnergizedOnEquipmentUse,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarHorn"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(-0.02265F, 0.11564F, 0.25131F),
                            localAngles = new Vector3(322.351F, 180.1151F, 180.1427F),
                            localScale = new Vector3(0.65949F, 0.65949F, 0.65949F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ExplodeOnDeath,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.29316F, 0.00079F, -0.0037F),
                            localAngles = new Vector3(1.54117F, 168.7114F, 181.6139F),
                            localScale = new Vector3(0.11587F, 0.11587F, 0.11587F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.ExplodeOnDeathVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWillowWispVoid"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.29316F, 0.00079F, -0.0037F),
                            localAngles = new Vector3(1.54117F, 168.7114F, 181.6139F),
                            localScale = new Vector3(0.11587F, 0.11587F, 0.11587F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.StickyBomb,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.40225F, 0.34297F, -0.08829F),
                            localAngles = new Vector3(0F, 0F, 352.248F),
                            localScale = new Vector3(0.38889F, 0.38889F, 0.38889F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SecondarySkillMagazine,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                            childName = "Hand_R",
                            localPos = new Vector3(-0.10905F, 0.21145F, 0.00205F),
                            localAngles = new Vector3(282.1141F, 151.6371F, 195.1426F),
                            localScale = new Vector3(0.07824F, 0.07824F, 0.07824F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.RandomEquipmentTrigger,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBottledChaos"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.09151F, 0.31489F, -0.39151F),
                            localAngles = new Vector3(8.76136F, 181.8586F, 195.2739F),
                            localScale = new Vector3(0.24003F, 0.24003F, 0.25518F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.Squid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                            childName = "leg_bone1.L",
                            localPos = new Vector3(-0.0286F, 0.16283F, 0.27993F),
                            localAngles = new Vector3(79.90451F, 26.35448F, 58.03141F),
                            localScale = new Vector3(0.09641F, 0.09641F, 0.09641F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.TreasureCache,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayKey"),
                            childName = "arm_bone1.R",
                            localPos = new Vector3(-0.22615F, 0.34024F, 0.09742F),
                            localAngles = new Vector3(316.0501F, 212.6656F, 341.9942F),
                            localScale = new Vector3(1.17775F, 1.17775F, 1.17775F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.TreasureCacheVoid,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayKeyVoid"),
                            childName = "arm_bone1.R",
                            localPos = new Vector3(-0.21677F, 0.34249F, 0.09647F),
                            localAngles = new Vector3(322.5188F, 213.1655F, 343.9277F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.TPHealingNova,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.00973F, 0.28517F, -0.23263F),
                            localAngles = new Vector3(359.6195F, 168.6004F, 286.3517F),
                            localScale = new Vector3(0.5F, 0.5F, 0.5F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BonusGoldPackOnKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTome"),
                            childName = "shoulder_bone.L",
                            localPos = new Vector3(0.20254F, 0.39158F, -0.10693F),
                            localAngles = new Vector3(330.7632F, 98.53088F, 176.3517F),
                            localScale = new Vector3(0.12362F, 0.12362F, 0.12362F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.MoveSpeedOnKill,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGrappleHook"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.17348F, 0.24339F, -0.68171F),
                            localAngles = new Vector3(78.8014F, 265.1343F, 58.37302F),
                            localScale = new Vector3(0.21953F, 0.21953F, 0.21953F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.AlienHead,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAlienHead"),
                            childName = "head_bone",
                            localPos = new Vector3(-0.2444F, 0.478F, -0.1563F),
                            localAngles = new Vector3(312.0929F, 299.6355F, 271.5399F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask= LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.PermanentDebuffOnHit,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayScorpion"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.02524F, 0.33971F, 0.32804F),
                            localAngles = new Vector3(2.34891F, 179.0455F, 175.549F),
                            localScale = new Vector3(1.27216F, 1.27216F, 1.27216F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.AutoCastEquipment,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFossil"),
                            childName = "shoulder_bone.R",
                            localPos = new Vector3(-0.05529F, 0.2724F, -0.28929F),
                            localAngles = new Vector3(319.0316F, 110.2584F, 20.48453F),
                            localScale = new Vector3(0.62838F, 0.62838F, 0.62838F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.ParentEgg,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayParentEgg"),
                            childName = "leg_bone1.R",
                            localPos = new Vector3(0.30602F, -0.00001F, 0F),
                            localAngles = new Vector3(23.37225F, 180F, 180F),
                            localScale = new Vector3(0.12F, 0.12F, 0.12F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.NovaOnLowHealth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.00114F, 0.55985F, -0.62488F),
                            localAngles = new Vector3(3.30072F, 181.5135F, 312.9967F),
                            localScale = new Vector3(0.09242F, 0.07394F, 0.07394F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.VoidMegaCrabItem,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMegaCrabItem"),
                            childName = "pelvis_bone",
                            localPos = new Vector3(0.06409F, 0.52349F, -0.28978F),
                            localAngles = new Vector3(346.6952F, 166.2384F, 176.4017F),
                            localScale = new Vector3(0.2F, 0.2F, 0.2F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.RandomDamageZone,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                            childName = "stomach_bone",
                            localPos = new Vector3(-0.2188F, 0.09743F, -0.34826F),
                            localAngles = new Vector3(312.6506F, 310.4938F, 277.5623F),
                            localScale = new Vector3(0.07225F, 0.07225F, 0.07225F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = DLC1Content.Items.RandomlyLunar,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDomino"),
                            childName = "chest_bone",
                            localPos = new Vector3(1.00156F, 2.12846F, -0.80902F),
                            localAngles = new Vector3(293.2354F, 196.5023F, 18.38937F),
                            localScale = new Vector3(1F, 1F, 1F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.FocusConvergence,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                            childName = "Body",
                            localPos = new Vector3(0.01679F, 0.1948F, 6.17888F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(0.11F, 0.11F, 0.11F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.BleedOnHitAndExplode,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                            childName = "arm_bone1.L",
                            localPos = new Vector3(0.02505F, 0.31024F, -0.16726F),
                            localAngles = new Vector3(5.18205F, 232.5757F, 181.6572F),
                            localScale = new Vector3(0.07793F, 0.07793F, 0.07793F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            itemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = RoR2Content.Items.SiphonOnLowHealth,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                            childName = "chest_bone",
                            localPos = new Vector3(-0.26228F, 0.54092F, -0.53892F),
                            localAngles = new Vector3(8.74586F, 359.7306F, 1.2685F),
                            localScale = new Vector3(0.11249F, 0.11249F, 0.11249F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });
            #endregion
        }
    }
}