using System;
using AssassinMod.Modules;
using AssassinMod.Survivors.Assassin.Achievements;
using R2API;
using static AssassinMod.Survivors.Assassin.AssassinStaticValues;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinTokens
    {
        public static void Init()
        {
            AddAssassinTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Henry.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddAssassinTokens()
        {
            string prefix = AssassinPlr.ASSASSIN_PREFIX;

            string desc = "The assassin fights at medium range and uses poison to damage their enemies over time.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Daggers are great for dealing with singular targets." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Poisons are great to deal with crowds of enemies." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Teleporting can be tricky to aim, though it arcs so aim it a bit above where you actually want to land." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > War Cry is great to use when you activate the teleporter" + Environment.NewLine + Environment.NewLine;

            string TheLorax = "Once revered as an alchemical prodigy, the Assassin was destined to leave an indelible mark on history.They displayed an unparalleled affinity for brewing potions that could do anything one could ask for. Under the mentorship of esteemed alchemists, they honed their craft and earned a reputation as the most capable alchemist there was.However over time, they became fueled by greed, something the alchemical society heavily frowned on. This led to them abandoning the society that mentored them.\n\n" +
                              "Their immense greed and a hatred for the alchemical society they grew up in led the Assassin down a dark path they could have never imagined. Consumed by greed and the desire to be famous, they turned their expertise to a darker purpose. They spent months brewing their deadliest potion, a neurotoxin so deadly it drained the life of any who inhaled the fumes. Knowing they couldn’t survive this, they made an anti-venom and infused their cloak with it.\n\n" +
                              "They gained notoriety as a relentless and elusive bounty hunter. Their services were sought by criminals and warlords alike, their poison becoming their signature assassination style, effectively serving as a calling card.They harnessed their brewing skills to make other potions, ones that could move their molecular structure around, and others that could make their body disappear in the blink of an eye.\n\n" +
                              "Iterating on their previous poison, they had come up with something much more virulent.This new poison was able to deliver all of its toxins almost instantly, with the side effect that it would linger in the air.This allowed them to kill entire rooms of people with a single potion.\n\n" +
                              "They were tasked with killing the Captain of the U.S.S. Safe Travels, however upon landing they felt a powerful otherwordly presence drawing them down a path ever darker, ever deeper.";


            string outro = "..and so they left, to claim their highest bounty.";
            string outroFailure = "..and so they vanished, with a not a trace of smoke to be seen.";

            Language.Add(prefix + "NAME", "Assassin");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "Silent Poisonous Professional");
            Language.Add(prefix + "LORE", TheLorax);
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Decoy
            Language.Add(prefix + "EXPLOSIVEDECOY_NAME", "Assassin Decoy");
            #endregion

            #region Keywords
            string WarcryAdd = "\n<style=cIsUtility>While under the influence of War Cry, </style>";
            LanguageAPI.Add("KEYWORD_DAGGER_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "throw 4 daggers.");
            LanguageAPI.Add("KEYWORD_GHOSTLY_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + $"minimum damage is increased to <style=cIsDamage>{100 * cutterDamageCoef * 0.5f}%</style>.");
            LanguageAPI.Add("KEYWORD_POISON_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "throw a clustered potion with weaker children.");
            LanguageAPI.Add("KEYWORD_VENOM_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "throw 2 potions in a loose fan");
            LanguageAPI.Add("KEYWORD_TELEPORT_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "throw the teleport potion faster, and explode in a poisonous cloud upon teleporting.");
            LanguageAPI.Add("KEYWORD_ROLL_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "rolling applies the warbanner effect.");
            LanguageAPI.Add("KEYWORD_DECOY_WC", "<style=cKeywordName>Inspired</style>" + WarcryAdd + "throw poisons in your wake.");
            #endregion

            #region Skins
            Language.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Exalted");
            Language.Add(prefix + "GRAND_MASTERY_SKIN_NAME", "Divine");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Mad God's Rage");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "Getting hit below <style=cIsHealth>60% maximum health</style> will increase your attack speed and damage by <style=cIsDamage>7.5% per stack</style>, for <style=cIsUtility>3 seconds.</style>");
            
            LanguageAPI.Add(prefix + "ALT_PASSIVE_NAME", "Toxic Terror");
            LanguageAPI.Add(prefix + "ALT_PASSIVE_DESCRIPTION", $"Getting hit throws a poison to the direction of damage, dealing <style=cIsDamage>{100 * poisonDamageCoef}% damage</style> plus an additional <style=cIsDamage>{100 * poisonDOTDamageCoef}% damage over time</style>.");
            
            LanguageAPI.Add(prefix + "ALT1_PASSIVE_NAME", "Trickster's Ruse");
            LanguageAPI.Add(prefix + "ALT1_PASSIVE_DESCRIPTION", $"Getting hit has a <style=cIsUtility>5%</style> chance to spawn a decoy that lives for 5 seconds, and explodes dealing <style=cIsDamage>{100 * decoyExplodeDamageCoef}% damage</style>.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_DAGGER_NAME", "Dagger");
            LanguageAPI.Add(prefix + "PRIMARY_DAGGER_DESCRIPTION", Tokens.agilePrefix + $"Throw 2 daggers for <style=cIsDamage>{100 * daggerDamageCoef}% damage</style>.");
            #endregion
            
            #region AltPrimary
            LanguageAPI.Add(prefix + "PRIMARY_CUTTER_NAME", "Ghostly Dagger");
            LanguageAPI.Add(prefix + "PRIMARY_CUTTER_DESCRIPTION", Tokens.agilePrefix + $"Throw 1 dagger for <style=cIsDamage>{100 * cutterDamageCoef * 0.2f}% to {100 * cutterDamageCoef * (2f/cutterDamageCoef)}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_POISON_NAME", "Poison");
            LanguageAPI.Add(prefix + "SECONDARY_POISON_DESCRIPTION", Tokens.agilePrefix + $"Throw a poisonous potion for <style=cIsDamage>{100 * poisonDamageCoef}% damage</style> plus an additional <style=cIsDamage>{100 * poisonDOTDamageCoef}% damage over time.</style>");
            LanguageAPI.Add(prefix + "SECONDARY_POISON_DESCRIPTION_SCEPTER", Tokens.agilePrefix + $"Throw a clustered poisonous potion for <style=cIsDamage>{100 * poisonDamageCoef}% damage</style> plus an additional <style=cIsDamage>{100 * poisonDOTDamageCoef}% damage over time, each.</style> \n\n<style=cKeywordName>While under the influence of War Cry, throw a recursively clustered potion, with weaker children.</style>");
            #endregion

            #region AltSecondary
            LanguageAPI.Add(prefix + "SECONDARY_POISON_NAME_ALT", "Virulent Venom");
            LanguageAPI.Add(prefix + "SECONDARY_POISON_DESCRIPTION_ALT", Tokens.agilePrefix + $"Throw a lingering potion for <style=cIsDamage>{100 * venomDamageCoef}% damage.</style> <style=cIsUtility>Toxins linger for 5 seconds.</style> <style=cDeath>Does not inflict poison.</style>");
            LanguageAPI.Add(prefix + "SCEPTER_SECONDARY_POISON_DESCRIPTION_ALT", Tokens.agilePrefix + $"Throw 2 lingering potions in a loose fan for <style=cIsDamage>{100 * venomDamageCoef}% damage.</style> <style=cIsUtility>Toxins linger for 5 seconds.</style> <style=cDeath>Does not inflict poison.</style>");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_CLOAK_NAME", "Teleport");
            LanguageAPI.Add(prefix + "UTILITY_CLOAK_DESCRIPTION", "Throw a potion towards your cursor <style=cIsUtility>teleporting you to where it lands,</style> then throw a potion onto the ground, <style=cIsUtility>exploding into a cloud of smoke, gaining the Cloak Speed buff.</style>");
            #endregion

            #region AltUtility
            LanguageAPI.Add(prefix + "UTILITY_ROLL_NAME", "Cloaking Roll");
            LanguageAPI.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Roll forward, becoming invisible and gaining a small movespeed boost.");
            
            LanguageAPI.Add(prefix + "UTILITY_DECOY_NAME", "Decoy Prism");
            LanguageAPI.Add(prefix + "UTILITY_DECOY_DESCRIPTION", "Dash forward, leaving an exploding decoy at your old position.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_POISON_SPAM_NAME", "War Cry");
            LanguageAPI.Add(prefix + "SPECIAL_POISON_SPAM_DESCRIPTION", $"<style=cIsUtility>Buff yourself, and all of your abilities for 5 seconds.</style>");// <style=cIsUtility>Throw 3 knives, a recursive poison, and more potent smoke bomb</style> during the duration.");
            #endregion

            #region AltSpecial
            LanguageAPI.Add(prefix + "SPECIAL_BACKSTAB_NAME", "Spinal Tap");
            LanguageAPI.Add(prefix + "SPECIAL_BACKSTAB_DESCRIPTION", $"Stab your enemies for <style=cIsDamage>{100 * backstabDamageCoef}% damage. </style><style=cIsUtility>When stabbing a lesser enemy from behind,</style> <style=cIsHealth>instantly kill your target.</style> On stabbing a boss from behind, have a <style=cIsUtility>{AssassinConfig.BackstabChance.Value}%</style> to <style=cIsHealth>instantly kill your target.</style> If this fails, deal <style=cIsDamage>20% of the targets health.</style>");// <style=cIsUtility>Throw 3 knives, a recursive poison, and more potent smoke bomb</style> during the duration.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(AssassinMasteryAchievement.identifier), "Assassin: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(AssassinMasteryAchievement.identifier), "As Assassin, beat the game or obliterate on Monsoon or higher.");
            
            Language.Add(Tokens.GetAchievementNameToken(AssassinGrandMasteryAchievement.identifier), "Assassin: Grand Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(AssassinGrandMasteryAchievement.identifier), "As Assassin, beat the game or obliterate on Typhoon or higher.");
            
            Language.Add(Tokens.GetAchievementNameToken(AssassinPoisonAchievement.identifier), "Assassin: Deathly Concoction");
            Language.Add(Tokens.GetAchievementDescriptionToken(AssassinPoisonAchievement.identifier), "As Assassin, apply 10 stacks of Assassin's Poison on a single enemy.");
            #endregion
        }
    }
}
