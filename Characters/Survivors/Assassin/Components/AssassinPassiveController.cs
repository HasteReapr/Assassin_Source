using System;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace AssassinMod.Survivors.Assassin.Components
{
    public class AssassinPassiveController : MonoBehaviour
    {
        public GenericSkill passiveSkillSlot;
        public SkillDef poisonPassiveDef;
        public SkillDef decoyPassiveDef;

        private void Awake()
        {
            LocateSkillThing();
        }

        private void LocateSkillThing()
        {
            var skillLoc = base.GetComponent<CharacterBody>().GetComponent<SkillLocator>();
            //passiveSkillSlot = skillLocator.FindSkillByFamilyName("PassiveSkill");

            foreach (var skill in skillLoc.allSkills)
            {
                if (skill._skillFamily != skillLoc.primary && skill._skillFamily != skillLoc.secondary && skill._skillFamily != skillLoc.special && skill._skillFamily != skillLoc.utility)
                {
                    Log.Message("Found the passiveskill.");
                    passiveSkillSlot = skill;
                    break;
                }
            }
        }

        public int GetPassiveType()
        {
            if(passiveSkillSlot == null)
            {
                LocateSkillThing();
            }

            if(passiveSkillSlot.skillDef == AssassinStaticValues.poisonPassiveDef)
            {
                return 1; // "PoisonPassive";
            }
            else if(passiveSkillSlot.skillDef == AssassinStaticValues.decoyPassiveDef)
            {
                return 2; // "DecoyPassive";
            }
            else
            {
                return 0; // "RagePassive";
            }
        }
    }
}