using UnityEngine;
using RoR2;
using static RoR2.CameraTargetParams;
using AssassinMod.Survivors.Assassin.EmoteStates;
using BepInEx.Configuration;
using System;
using EntityStates;
using AssassinMod.Survivors.Assassin;

namespace AssassinMod.Modules.BaseStates
{
    public class BaseEmote : BaseState
    {
        //taken from https://github.com/Moffein/RocketSurvivor/blob/cb8af82b32f105fdcef66301860b602e0d0f7d68/HenryMod/SkillStates/RocketSurvivor/BaseEmote.cs
        public string soundString;
        public string animString;
        public float duration;
        public float animDuration;

        private uint activePlayID;
        private Animator animator;
        private ChildLocator childLocator;

        public LocalUser localUser;

        private CharacterCameraParamsData emoteCameraParams = new CharacterCameraParamsData()
        {
            maxPitch = 70,
            minPitch = -70,
            pivotVerticalOffset = 0.5f,
            idealLocalCameraPos = emoteCameraPosition,
            wallCushion = 0.1f,
        };

        public static Vector3 emoteCameraPosition = new Vector3(0, -0.5f, -8.9f);

        private CameraParamsOverrideHandle camOverrideHandle;

        public override void OnEnter()
        {
            base.OnEnter();
            animator = base.GetModelAnimator();
            childLocator = base.GetModelChildLocator();
            FindLocalUser();

            base.characterBody.hideCrosshair = true;

            if (base.GetAimAnimator()) base.GetAimAnimator().enabled = false;
            //animator.SetLayerWeight(animator.GetLayerIndex("AimPitch"), 0);
            //animator.SetLayerWeight(animator.GetLayerIndex("AimYaw"), 0);

            if (duration == 0 && animDuration == 0)
            {
                duration = GetAnimatorClipDuration();
            }

            if (animDuration == 0 && duration != 0) animDuration = duration;

            if (animDuration > 0)
            {
                base.PlayAnimation("FullBody, Override", animString, "Emote.playbackRate", animDuration);
            }
            else
            {
                base.PlayAnimation("FullBody, Override", animString);
            }

            activePlayID = Util.PlaySound(soundString, base.gameObject);

            CameraParamsOverrideRequest request = new CameraParamsOverrideRequest
            {
                cameraParamsData = emoteCameraParams,
                priority = 0,
            };

            camOverrideHandle = base.cameraTargetParams.AddParamsOverride(request, 0.5f);

        }

        private float GetAnimatorClipDuration()
        {

            Animator modelAnimator = GetModelAnimator();

            modelAnimator.speed = 1f;
            modelAnimator.Update(0f);
            int layerIndex = modelAnimator.GetLayerIndex("FullBody, Override");
            if (layerIndex >= 0)
            {
                //modelAnimator.SetFloat(playbackRateParam, 1f);
                modelAnimator.PlayInFixedTime(animString, layerIndex, 0f);
                modelAnimator.Update(0f);
                float length = modelAnimator.GetCurrentAnimatorStateInfo(layerIndex).length;
                return length;
            }

            return 0;
        }

        private void FindLocalUser()
        {
            if (localUser == null)
            {
                if (base.characterBody)
                {
                    foreach (LocalUser lu in LocalUserManager.readOnlyLocalUsersList)
                    {
                        if (lu.cachedBody == base.characterBody)
                        {
                            localUser = lu;
                            break;
                        }
                    }
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            base.characterBody.hideCrosshair = false;

            if (base.GetAimAnimator()) base.GetAimAnimator().enabled = true;
            animator.SetLayerWeight(animator.GetLayerIndex("AimPitch"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("AimYaw"), 1);

            base.PlayAnimation("FullBody, Override", "BufferEmpty");
            if (activePlayID != 0) AkSoundEngine.StopPlayingID(activePlayID);

            base.cameraTargetParams.RemoveParamsOverride(camOverrideHandle, 0.5f);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            bool flag = false;

            if (base.characterMotor)
            {
                if (!base.characterMotor.isGrounded) flag = true;
                if (base.characterMotor.velocity != Vector3.zero) flag = true;
            }

            if (base.inputBank)
            {
                if (base.inputBank.skill1.down) flag = true;
                if (base.inputBank.skill2.down) flag = true;
                if (base.inputBank.skill3.down) flag = true;
                if (base.inputBank.skill4.down) flag = true;
                if (base.inputBank.jump.down) flag = true;

                if (base.inputBank.moveVector != Vector3.zero) flag = true;
            }

            //emote cancels
            if (base.isAuthority && base.characterMotor.isGrounded)
            {
                CheckEmote<EmoteSit>(AssassinConfig.KeybindEmoteJuggle);
                CheckEmote<EmoteJuggle>(AssassinConfig.KeybindEmoteJuggle);
                CheckEmote<EmoteMenu>(AssassinConfig.KeybindEmoteCSS);
            }

            if (duration > 0 && base.fixedAge >= duration) flag = true;

            if (flag)
            {
                outer.SetNextStateToMain();
            }
        }

        private void CheckEmote<T>(ConfigEntry<KeyboardShortcut> keybind) where T : EntityState, new()
        {
            if (AssassinConfig.GetKeyPressed(keybind))
            {
                FindLocalUser();

                if (localUser != null && !localUser.isUIFocused)
                {
                    outer.SetInterruptState(new T(), InterruptPriority.Any);
                }
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Any;
        }
    }
}
