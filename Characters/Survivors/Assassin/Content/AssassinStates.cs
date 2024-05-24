using AssassinMod.Characters.Survivors.Assassin.SkillStates.DefaultSkills;
using AssassinMod.Characters.Survivors.Assassin.SkillStates.AlternateSkills;
using AssassinMod.Characters.Survivors.Assassin.SkillStates.ScepterSkills;
using AssassinMod.Modules.BaseStates;
using AssassinMod.Survivors.Assassin.EmoteStates;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(ThrowCutter));

            Modules.Content.AddEntityState(typeof(ThrowPoison));
            Modules.Content.AddEntityState(typeof(ScepterPoison));
            Modules.Content.AddEntityState(typeof(ThrowVirulent));
            Modules.Content.AddEntityState(typeof(ScepterVenom));

            Modules.Content.AddEntityState(typeof(ThrowPearl));
            Modules.Content.AddEntityState(typeof(Roll));
            Modules.Content.AddEntityState(typeof(ThrowDecoy));

            Modules.Content.AddEntityState(typeof(DrugSelf));
            Modules.Content.AddEntityState(typeof(Backstab));

            Modules.Content.AddEntityState(typeof(BaseEmote));
            Modules.Content.AddEntityState(typeof(EmoteSit));
            Modules.Content.AddEntityState(typeof(EmoteJuggle));
            Modules.Content.AddEntityState(typeof(EmoteMenu));
        }
    }
}
