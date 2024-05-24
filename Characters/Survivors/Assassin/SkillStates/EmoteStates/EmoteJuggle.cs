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
    public class EmoteJuggle : BaseEmote
    {
        public override void OnEnter()
        {
            animString = "Emote_Juggle";
            duration = -1;
            base.OnEnter();
        }
    }
}
