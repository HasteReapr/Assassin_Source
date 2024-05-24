using AssassinMod.Survivors.Assassin.Achievements;
using RoR2;
using UnityEngine;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;
        public static UnlockableDef grandMasterySkinUnlockableDef = null;
        public static UnlockableDef poisonAchievementUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                AssassinMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(AssassinMasteryAchievement.identifier),
                AssassinPlr.instance.assetBundle.LoadAsset<Sprite>("texMasterySkin"));

            grandMasterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                AssassinGrandMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(AssassinGrandMasteryAchievement.identifier),
                AssassinPlr.instance.assetBundle.LoadAsset<Sprite>("texGrandMasterySkin"));
            
            poisonAchievementUnlockableDef= Modules.Content.CreateAndAddUnlockbleDef(
                AssassinPoisonAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(AssassinPoisonAchievement.identifier),
                AssassinPlr.instance.assetBundle.LoadAsset<Sprite>("texGrandMasterySkin"));
        }
    }
}
