using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.HarmonyMain;
using ChallengerOS.Utils.Option;
using Steamworks;
using UnityEngine.Networking.Types;
using UnityEngine.SocialPlatforms.Impl;

namespace ChallengerMod.Pressets
{
    internal class Start2
    {
        [HarmonyPatch(typeof(GameStartManager))]
        public static class GameStartManagerPatch
        {
            [HarmonyPatch(nameof(GameStartManager.Start))]
            [HarmonyPrefix]
            public static void StartPatch(ref GameStartManager __instance)
            {


                if (ChallengerMod.HarmonyMain.EventConfig.Value == "Lover") { ChallengerMod.Challenger.LoverEvent = true; }
               else { ChallengerMod.Challenger.LoverEvent = false; }

                if (AmongUsClient.Instance.AmHost)
                {
                    if (Challenger.IsrankedGame == true) 
                    {
                        Ranked.updateSelection(1);
                        Challenger.isRankedGame = true;
                    }
                    if (Challenger.IsrankedGame == false) 
                    {
                        Ranked.updateSelection(0);
                        Challenger.isRankedGame = false;
                    }


                    if (PlayerControl.GameOptions.MaxPlayers < 10) { PlayerControl.GameOptions.MaxPlayers = 10; }

                    

                    //SAVE LAST CONFIG

                    if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 2 && BetterMapPL.getSelection() == 0) { Challenger._MapID = 0; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 2 && BetterMapPL.getSelection() == 1 ) { Challenger._MapID = 1; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 2 && BetterMapPL.getSelection() == 2 && NuclearTimerMod.getBool() == false) { Challenger._MapID = 2; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 2 && BetterMapPL.getSelection() == 2 && NuclearTimerMod.getBool() == true) { Challenger._MapID = 3; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 0 && BetterMapSK.getSelection() == 0) { Challenger._MapID = 4; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 0 && BetterMapSK.getSelection() == 1) { Challenger._MapID = 5; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 1 && BetterMapHQ.getSelection() == 0) { Challenger._MapID = 6; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 1 && BetterMapHQ.getSelection() == 1) { Challenger._MapID = 7; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId == 4) { Challenger._MapID = 8; }
                   if (Challenger.IsrankedGame && PlayerControl.GameOptions.MapId > 4) { Challenger._MapID = 9; }

                    if (Challenger.IsrankedGame && PlayerControl.GameOptions.NumImpostors == 1) 
                    { 
                        Challenger._IMP = 1;
                        QTImp.updateSelection(1);
                    }
                    if (Challenger.IsrankedGame && PlayerControl.GameOptions.NumImpostors == 2)
                    {
                        Challenger._IMP = 2;
                        QTImp.updateSelection(2);
                    }
                    if (Challenger.IsrankedGame && PlayerControl.GameOptions.NumImpostors == 3)
                    {
                        Challenger._IMP = 3;
                        QTImp.updateSelection(3);
                    }



                    if (Challenger.IsrankedGame && QTDuo.getSelection() == 0) { Challenger._DUO = 0; }
                    if (Challenger.IsrankedGame && QTDuo.getSelection() == 1) { Challenger._DUO = 1; }
                    if (Challenger.IsrankedGame && QTDuo.getSelection() == 2) { Challenger._DUO = 2; }
                    if (Challenger.IsrankedGame && QTDuo.getSelection() == 3) { Challenger._DUO = 3; }

                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 0) { Challenger._SPE = 0; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 1) { Challenger._SPE = 1; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 2) { Challenger._SPE = 2; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 3) { Challenger._SPE = 3; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 4) { Challenger._SPE = 4; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 5) { Challenger._SPE = 5; }
                    if (Challenger.IsrankedGame && QTSpe.getSelection() == 6) { Challenger._SPE = 6; }

                }
                else
                {
                    if (Challenger.IsrankedGame == true)
                    {
                        Challenger.isRankedGame = true;
                    }
                    if (Challenger.IsrankedGame == false)
                    {
                        Challenger.isRankedGame = false;
                    }

                    

                }
                    
            }
        }
    }
}