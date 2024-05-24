using UnityEngine;
using RoR2;
using static RoR2.CameraTargetParams;
using AssassinMod.Modules;
using BepInEx.Configuration;
using System;
using EntityStates;
using AssassinMod.Modules.BaseStates;

namespace AssassinMod.Survivors.Assassin.EmoteStates
{
    public class EmoteMenu : BaseEmote
    {
        private const float thumpSoundDelay = 1.5f;
        private const float loadSoundDelay = 8f / 30f;

        private bool playedThump = false;
        private bool playedLoad = false;

        public override void OnEnter()
        {
            animString = "Emote_CSS_In";
            duration = -1;
            base.OnEnter();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            /*if (!playedLoad && base.fixedAge >= loadSoundDelay)
            {
                playedLoad = true;
                Util.PlaySound("Play_Moffein_RocketSurvivor_Shift_Rearm", base.gameObject);
            }
            if (!playedThump && base.fixedAge >= thumpSoundDelay)
            {
                playedThump = true;
                Util.PlaySound("Play_MULT_shift_hit", base.gameObject);
            }*/
        }
    }
}
