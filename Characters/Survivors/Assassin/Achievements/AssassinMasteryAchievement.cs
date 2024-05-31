using RoR2;
using AssassinMod.Modules.Achievements;

namespace AssassinMod.Survivors.Assassin.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, null)]
    public class AssassinMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = AssassinPlr.ASSASSIN_PREFIX + "masteryAchievement";
        public const string description = AssassinPlr.ASSASSIN_PREFIX + "As Assassin, beat the game or obliterate on Monsoon or higher.";
        public const string unlockableIdentifier = AssassinPlr.ASSASSIN_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => AssassinPlr.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }

    public class AssassinGrandMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = AssassinPlr.ASSASSIN_PREFIX + "grandMasteryAchievement";
        public const string unlockableIdentifier = AssassinPlr.ASSASSIN_PREFIX + "grandMasteryUnlockable";
        public override string RequiredCharacterBody => AssassinPlr.instance.bodyName;

        public override float RequiredDifficultyCoefficient => 3.5f;
    }
}