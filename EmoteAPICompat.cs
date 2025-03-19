using AssassinMod.Survivors.Assassin;
using RoR2;
using System.Runtime.CompilerServices;

namespace AssassinMod
{
    public static class EmoteAPICompat
    {
        private static bool? _enabled;

        public static bool enabled
        {
            get
            {
                if (_enabled == null)
                {
                    _enabled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.weliveinasociety.CustomEmotesAPI");
                }
                return (bool)_enabled;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void EmoteHook()
        {
            EmotesAPI.CustomEmotesAPI.animChanged += CustomEmotesAPI_animChanged;
            On.RoR2.SurvivorCatalog.Init += SurvivorCatalog_Init;
        }
        private static void SurvivorCatalog_Init(On.RoR2.SurvivorCatalog.orig_Init orig)
        {
            orig();
            foreach (var item in SurvivorCatalog.allSurvivorDefs)
            {
                if (item.bodyPrefab.name == "AssassinSurvivorBody")
                {
                    var skele = AssassinAssets.emoteAPISkeleton;
                    EmotesAPI.CustomEmotesAPI.ImportArmature(item.bodyPrefab, skele, jank: false);
                    skele.GetComponentInChildren<BoneMapper>().scale = 1f;
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static void CustomEmotesAPI_animChanged(string newAnimation, BoneMapper mapper)
        {
            if (newAnimation != "none")
            {
                if (mapper.transform.name == "rogue_emote_skeleton" || mapper.transform.name == "rogue_emote_skeleton_tiny")
                {
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_L").gameObject.SetActive(false);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_R").gameObject.SetActive(false);
                }
            }
            else
            {
                if (mapper.transform.name == "rogue_emote_skeleton" || mapper.transform.name == "rogue_emote_skeleton_tiny")
                {
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_L").gameObject.SetActive(true);
                    mapper.transform.parent.GetComponent<ChildLocator>().FindChild("Knife_R").gameObject.SetActive(true);
                }
            }
        }
    }

}
