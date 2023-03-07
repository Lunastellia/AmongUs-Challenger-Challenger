using Assets.InnerNet;
using HarmonyLib;
using Reactor;

namespace ChallengerMod.Cosmetics
{
    [HarmonyPatch(typeof(SaveManager), nameof(SaveManager.GetPrefsName))]
    public class SaveManagerPatch
    {
        public static void Postfix(ref string __result)
        {
            __result += ".challenger";
        }
    }
    
}