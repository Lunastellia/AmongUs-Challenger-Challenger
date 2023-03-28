/*using HarmonyLib;
using PowerTools;
using UnityEngine;

namespace ChallengerMod.TasksUpdate
{
    internal class LeafPatches
    {
        [HarmonyPatch(typeof(LeafMinigame))]
        private static class LeafMinigamePatch
        {
            [HarmonyPatch(nameof(LeafMinigame.FixedUpdate))]
            [HarmonyPostfix]
            private static void Prefix(LeafMinigame __instance)
            {
                if (__instance.enabled)
                {
                    if (Challenger.LeafPPos != new Vector3(0f, 0f, 0f))
                    {
                        PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                        PlayerControl.LocalPlayer.transform.position = Challenger.LeafPPos;

                    }
                    else
                    {
                        Challenger.LeafPPos = PlayerControl.LocalPlayer.transform.position;
                    }


                }
            }
        }
    }
    internal class LeafPatchesStart
    {
        [HarmonyPatch(typeof(LeafMinigame))]
        private static class LeafMinigamePatch
        {
            [HarmonyPatch(nameof(LeafMinigame.Begin))]
            [HarmonyPostfix]
            private static void Prefix(LeafMinigame __instance)
            {
                Challenger.LeafPPos = PlayerControl.LocalPlayer.transform.position;
            }
        }
    }
    internal class LeafPatchesClose
    {
        [HarmonyPatch(typeof(LeafMinigame))]
        private static class LeafMinigamePatch
        {
            [HarmonyPatch(nameof(LeafMinigame.Close))]
            [HarmonyPostfix]
            private static void Prefix(LeafMinigame __instance)
            {
                Challenger.LeafPPos = new Vector3(0f, 0f, 0f);
            }
        }
    }
    internal class LeafPatchesFClose
    {
        [HarmonyPatch(typeof(LeafMinigame))]
        private static class LeafMinigamePatch
        {
            [HarmonyPatch(nameof(LeafMinigame.ForceClose))]
            [HarmonyPostfix]
            private static void Prefix(LeafMinigame __instance)
            {
                Challenger.LeafPPos = new Vector3(0f, 0f, 0f);
            }
        }
    }
}
*/