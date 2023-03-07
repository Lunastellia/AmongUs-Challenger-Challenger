
using HarmonyLib;
using Il2CppSystem;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ChallengerMod.Utility.Server
{
    [HarmonyPatch]


    public static class Server
    {
        //SetTask

        

        public static void CheckServer()
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string realPath = appPath + @"BepInEx\config\servers.data";

            string ID = File.ReadAllText(realPath);
            ChallengerMod.HarmonyMain.ServerID = ID;
        }


    }
}