using RoR2;
using AssassinMod.Modules.Achievements;

namespace AssassinMod.Survivors.Assassin.Achievements
{
    [RegisterAchievement(identifier, unlockableIdentifier, null, null)]
    public class AssassinGrandMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = AssassinPlr.ASSASSIN_PREFIX + "grandMasteryAchievement";
        public const string unlockableIdentifier = AssassinPlr.ASSASSIN_PREFIX + "grandMasteryUnlockable";
        public override string RequiredCharacterBody => AssassinPlr.instance.bodyName;

        public override float RequiredDifficultyCoefficient => 3.5f;
    }
}
