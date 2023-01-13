using HarmonyLib;
using InnerNet;

namespace ChallengerMod.Item
{

    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.Update))]
    class InnerNetClient_Update
    {
        static void Postfix(InnerNetClient __instance)
        {
            RunUpdate();
        }

       

        static void RunUpdate()
        {



          

            if (!AmongUsClient.Instance.IsGameStarted && ChallengerMod.HarmonyMain.Instance != null)
            {
                foreach (_MapItems wItem in ChallengerMod.HarmonyMain.Instance.AllItems) wItem.Delete();
                
                War1Item.HasSpawned = false;
                War2Item.HasSpawned = false;
                War3Item.HasSpawned = false;
                War4Item.HasSpawned = false;
                War5Item.HasSpawned = false;
                War6Item.HasSpawned = false;
                War7Item.HasSpawned = false;
                War8Item.HasSpawned = false;
                War9Item.HasSpawned = false;
                War10Item.HasSpawned = false;
                War11Item.HasSpawned = false;
                War12Item.HasSpawned = false;
                War13Item.HasSpawned = false;
                War14Item.HasSpawned = false;


                ChallengerMod.HarmonyMain.Instance.AllItems.Clear();
                ChallengerMod.HarmonyMain.Instance.PossibleItemPositions1 = ChallengerMod.HarmonyMain.Instance.DefaultItemPositons1;
                ChallengerMod.HarmonyMain.Instance.PossibleItemPositions2 = ChallengerMod.HarmonyMain.Instance.DefaultItemPositons2;
                ChallengerMod.HarmonyMain.Instance.PossibleItemPositions3 = ChallengerMod.HarmonyMain.Instance.DefaultItemPositons3;
                ChallengerMod.HarmonyMain.Instance.PossibleItemPositions4 = ChallengerMod.HarmonyMain.Instance.DefaultItemPositons4;
                ChallengerMod.HarmonyMain.Instance.PossibleRefuelPositions1 = ChallengerMod.HarmonyMain.Instance.RefuelPosition1;
                ChallengerMod.HarmonyMain.Instance.PossibleRefuelPositions2 = ChallengerMod.HarmonyMain.Instance.RefuelPosition2;
                ChallengerMod.HarmonyMain.Instance.PossibleRefuelPositions3 = ChallengerMod.HarmonyMain.Instance.RefuelPosition3;
                ChallengerMod.HarmonyMain.Instance.PossibleSafeAreaPosition1 = ChallengerMod.HarmonyMain.Instance.SafeAreaPosition1;
                ChallengerMod.HarmonyMain.Instance.PossibleSafeAreaPosition2 = ChallengerMod.HarmonyMain.Instance.SafeAreaPosition2;
                ChallengerMod.HarmonyMain.Instance.PossibleSafeAreaPosition3 = ChallengerMod.HarmonyMain.Instance.SafeAreaPosition3;
                ChallengerMod.HarmonyMain.Instance.PossibleSafeAreaPosition4 = ChallengerMod.HarmonyMain.Instance.SafeAreaPosition4;
                ChallengerMod.HarmonyMain.Instance.PossibleGunPosition1 = ChallengerMod.HarmonyMain.Instance.GunPosition;
                ChallengerMod.HarmonyMain.Instance.PossibleGunPosition2 = ChallengerMod.HarmonyMain.Instance.GunPosition;
                ChallengerMod.HarmonyMain.Instance.PossibleGunPosition3 = ChallengerMod.HarmonyMain.Instance.GunPosition;


                return;
            }

            
        }
    }
}