using BepInEx.Configuration;
using AssassinMod.Modules;
using UnityEngine;

namespace AssassinMod.Survivors.Assassin
{
    public static class AssassinConfig
    {
        public static ConfigEntry<KeyboardShortcut> KeybindEmoteSit { get; private set; }
        public static ConfigEntry<KeyboardShortcut> KeybindEmoteJuggle { get; private set; }
        public static ConfigEntry<KeyboardShortcut> KeybindEmoteCSS { get; private set; }
        public static ConfigEntry<bool> BackstabInsta { get; private set; }
        public static ConfigEntry<float> BackstabChance { get; private set; }
        public static ConfigEntry<float> RechargeChance { get; private set; }

        public static void Init()
        {
            string section = "Assassin";

            BackstabInsta = Config.BindAndOptions(
                "Skills",
                "Spinal Tap Always Instakills",
                false,
                "Whether or not Spinal Tap always instakills on bosses. If false Spinal Tap has a percent chance to instakill, which can be affected by clover.");

            BackstabChance = Config.BindAndOptions(
                "Skills",
                "Spinal Tap Instakill Chance",
                2f,
                "The percent chance for Spinal Tap to insakill bosses.");

            RechargeChance = Config.BindAndOptions(
                "Skills",
                "Spinal Tap Recharge Chance",
                10f,
                "The percent chance for Spinal Tap to instantly recharge on a succesful backstab.");

            KeybindEmoteSit = Config.BindAndOptions(
                "Emote Binds",
                "Emote Sit",
                new KeyboardShortcut(KeyCode.Alpha1),
                "Button to play this emote");

            KeybindEmoteJuggle = Config.BindAndOptions(
                "Emote Binds",
                "Emote Juggle",
                new KeyboardShortcut(KeyCode.Alpha2),
                "Button to play this emote");

            KeybindEmoteCSS = Config.BindAndOptions(
                "Emote Binds",
                "Emote Dropin",
                new KeyboardShortcut(KeyCode.Alpha3),
                "Button to play this emote");
        }

        public static bool GetKeyPressed(ConfigEntry<KeyboardShortcut> entry)
        {
            foreach (var item in entry.Value.Modifiers)
            {
                if (!Input.GetKey(item))
                {
                    return false;
                }
            }
            return Input.GetKeyDown(entry.Value.MainKey);
        }
    }
}
