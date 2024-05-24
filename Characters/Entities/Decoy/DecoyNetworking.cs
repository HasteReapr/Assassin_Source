using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;
using System.Collections.Generic;
using RoR2.CharacterAI;
using RoR2.Skills;
using R2API.Networking.Interfaces;
using R2API.Networking;
using UnityEngine.Networking;

namespace AssassinMod.Characters.Entities.Decoy
{
    // Taken from https://github.com/MonsterSkinMan/GOTCE/blob/1b12c95e9857b4a79da86e7b533488a234f72ac5/GOTCE/EntityStatesCustom/AltSkills/Bandit/DecoyNetworking.cs
    public class DecoyNetworking
    {
        //[RunMethod(RunAfter.Start)]
        public static void RegisterNetworkMessages()
        {
            NetworkingAPI.RegisterMessageType<DecoySync>();
            ContentAddition.AddEntityState<DecoyDeath>(out bool _);
            ContentAddition.AddEntityState<DecoyTimer>(out bool _);
        }
    }

    public class DecoySync : INetMessage
    {
        GameObject owner;
        public void Deserialize(NetworkReader reader)
        {
            owner = reader.ReadGameObject();
        }
        public void Serialize(NetworkWriter writer)
        {
            writer.Write(owner);
        }
        public void OnReceived()
        {
            CharacterBody characterBody = owner.GetComponent<CharacterBody>();
            try
            {
                MasterSummon masterSummon2 = new MasterSummon()
                {
                    position = characterBody.corePosition,
                    ignoreTeamMemberLimit = true,
                    masterPrefab = AssassinDecoy.Instance.prefabMaster,
                    summonerBodyObject = characterBody.gameObject,
                    rotation = Quaternion.LookRotation(characterBody.transform.forward),
                };

                // thanks RandomlyAwesome
                var skinc = characterBody.GetComponent<ModelSkinController>();
                var decoyMaster = masterSummon2.Perform();
                skinc.skins[skinc.currentSkinIndex].Apply(decoyMaster.GetBody().gameObject);
            }
            catch
            {
                Log.Message("Failed to spawn Exploding Decoy used by player: " + characterBody.GetUserName());
            }
        }
        public DecoySync()
        {

        }
        public DecoySync(GameObject _owner)
        {
            owner = _owner;
        }
    }
}
