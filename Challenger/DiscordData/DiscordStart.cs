using System;
using Discord;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using DiscordConnect;

namespace Challenger.Utility.Discord
{
    [HarmonyPatch]
    public class DiscordPatches
    {
        [HarmonyPatch(typeof(DiscordManager), nameof(DiscordManager.Start))]
        [HarmonyPrefix]
        public static bool CustomDiscordRPCPrefix(DiscordManager __instance)
        {


            return false;
        }


    }
}