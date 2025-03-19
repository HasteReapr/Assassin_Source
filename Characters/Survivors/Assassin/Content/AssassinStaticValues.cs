using RoR2.Skills;
using System;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinStaticValues
    {
        public const float daggerDamageCoef = 1f;

        public const float cutterDamageCoef = 1.5f;

        public const float poisonDamageCoef = 2.5f;

        public const float poisonDOTDamageCoef = 5f;

        public const float venomDamageCoef = 12.5f; //5

        public const float backstabDamageCoef = 7.5f;

        public const float decoyExplodeDamageCoef = 15f;

        public static SkillDef ragePassiveDef;
        public static SkillDef poisonPassiveDef;
        public static SkillDef decoyPassiveDef;
    }
}