using RoR2;
using R2API;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinBuffs
    {
        // armor buff gained during roll
        internal static BuffDef armorBuff;

        internal static BuffDef poisonDebuff;
        //internal static DotController.DotIndex poisonDoT;

        internal static DotController.DotIndex poisonDoT;

        internal static BuffDef assassinDrugsBuff;
        internal static BuffDef hardcoreDrugsBuff;
        internal static BuffDef madGodBuff;
        internal static BuffDef terrorCD;

        internal static void Init(AssetBundle assetBundle)
        {
            armorBuff = Modules.Content.CreateAndAddBuff("HenryArmorBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.white,
                false,
                false);

            poisonDebuff = Modules.Content.CreateAndAddBuff("AssassinPoison",
                //LegacyResourcesAPI.Load<BuffDef>("BuffDefs/texBuffSuperBleedIcon").iconSprite,
                assetBundle.LoadAsset<Sprite>("texBuffSuperBleedIcon"),
                Color.green,
                true,
                true);

            terrorCD = Modules.Content.CreateAndAddBuff("AssassinTerrorCD",
                assetBundle.LoadAsset<Sprite>("texToxinCooldown"),
                Color.red,
                false,
                true);

            assassinDrugsBuff = Modules.Content.CreateAndAddBuff("AssassinDrugsBuff",
                //LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite, //make the thing do the thing as above
                assetBundle.LoadAsset<Sprite>("texDrugsBuff"),
                Color.red,
                false,
                false);

            hardcoreDrugsBuff = Modules.Content.CreateAndAddBuff("hardcoreDrugsBuff",
                //LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite, //make the thing do the thing as above
                assetBundle.LoadAsset<Sprite>("texDrugsBuff"),
                Color.yellow,
                false,
                false);

            madGodBuff = Modules.Content.CreateAndAddBuff("MadGodBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite, //make the thing do the thing as above
                                                                                             //Assets.mainAssetBundle.LoadAsset<Sprite>("texFireMask"),
                Color.black,
                true,
                false
                );

            RegisterDoTs();
        }

        private static void RegisterDoTs()
        {
            var poisonDef = new DotController.DotDef
            {
                interval = 0.1f,
                damageCoefficient = AssassinStaticValues.poisonDOTDamageCoef,
                damageColorIndex = DamageColorIndex.Poison,
                associatedBuff = poisonDebuff,
                terminalTimedBuffDuration = 10f,
                resetTimerOnAdd = true
            };

            poisonDoT = DotAPI.RegisterDotDef(poisonDef);
        }
    }
}