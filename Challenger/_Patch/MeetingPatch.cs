using HarmonyLib;
using Hazel;
using System;
using UnityEngine;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using UnhollowerBaseLib;
using System.Collections.Generic;
using ChallengerMod.RPC;
using ChallengerOS.Utils;
using ChallengerMod.CustomButton;
using Reactor.Extensions;
using Rewired;
using System.Linq;
using ChallengerMod.Rnd;
using ChallengerOS;
using static ChallengerOS.Arrow;

namespace Challenger
{




    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public static class StartMeetingPatch
    {

        public static void Postfix(MeetingHud __instance)
        {
            if (ChallengerMod.Challenger.localArrows.Count() >= 1) 
            { 
                foreach (Arrow A in ChallengerMod.Challenger.localArrows)
                {
                   UnityEngine.Object.Destroy(A.arrow);
                }
                ChallengerMod.Challenger.localArrows = new List<Arrow>(); 
            }
            if (ChallengerMod.Challenger.DroneController != null) { ChallengerMod.Challenger.DroneController = null; }

            if (Basilisk.Role != null && Basilisk.Petrified != null && !Basilisk.Role.Data.IsDead && PlayerControl.LocalPlayer == Basilisk.Petrified)
            {
                ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 0 / 255f, 0 / 255f), 4f);
            }
            else { }

            if (Cultist.Role != null)
            {
                foreach (PlayerControl Player in PlayerControl.AllPlayerControls)
                {
                    if (Player.Data.IsDead)
                    {
                        if (CultePlayers.Contains(Player)) { CultePlayers.Remove(Player); }
                    }
                    else
                    {
                        if (Cultist.Role != null && Player == Cultist.Role && !CultePlayers.Contains(Player)) { CultePlayers.Add(Player); }
                        if (Cultist.Culte1 != null && Player == Cultist.Culte1 && !CultePlayers.Contains(Player)) { CultePlayers.Add(Player); }
                        if (Cultist.Culte2 != null && Player == Cultist.Culte2 && !CultePlayers.Contains(Player)) { CultePlayers.Add(Player); }
                        if (Cultist.Culte3 != null && Player == Cultist.Culte3 && !CultePlayers.Contains(Player)) { CultePlayers.Add(Player); }
                    }
                }
            }
                        

            if (Leader.Role != null && Leader.Target != null && Leader.Target2 == null && (Leader.Role.Data.IsDead || LeaderTaskEnd.getBool() == true && Leader.TaskEND == true) && PlayerControl.LocalPlayer == Leader.Role && !Leader.Used2)
            {
                //IMPOSTOR
                if (Leader.Target.Data.Role.IsImpostor)
                {
                    foreach (PlayerControl Player in PlayerControl.AllPlayerControls)
                    {
                        if (!Player.Data.IsDead && !Player.Data.Role.IsImpostor && Player != Leader.Target && Player != Leader.Role)
                        {
                            if (!LeaderList.Contains(Player)) { LeaderList.Add(Player); }
                        }
                    }
                }
                //NOT_IMPOSTOR
                else
                {
                    foreach (PlayerControl Player in PlayerControl.AllPlayerControls)
                    {
                        //SPECIAL+NEUTRE
                        if ((Jester.Role != null && Player == Jester.Role)
                                || (Eater.Role != null && Player == Eater.Role)
                                || (Arsonist.Role != null && Player == Arsonist.Role)
                                || (Outlaw.Role != null && Player == Outlaw.Role)
                                || (Cursed.Role != null && Player == Cursed.Role)
                                || (Cupid.Role != null && Player == Cupid.Role && LeaderAffectCupid.getBool() == true)
                                || (Survivor.Role != null && Player == Survivor.Role)
                                )
                        {
                            if (!Player.Data.IsDead && Player != Leader.Target && Player != Leader.Role)
                            {
                                if (!LeaderList.Contains(Player)) { LeaderList.Add(Player); }
                            }
                        }
                        //CULTE
                        else if ((Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                )
                        {
                            if (!Player.Data.IsDead
                                && Player != Leader.Target
                                && Player != Leader.Role
                                && Player != Cultist.Role
                                && Player != Cultist.Culte1
                                && Player != Cultist.Culte2
                                && Player != Cultist.Culte3)
                            {
                                if (!LeaderList.Contains(Player)) { LeaderList.Add(Player); }
                            }
                        }
                        //CREWMATE
                        else
                        {
                            if (!Player.Data.IsDead
                                && Player != Leader.Target
                                && Player != Leader.Role
                                && (Player.Data.Role.IsImpostor
                                || (Jester.Role != null && Player == Jester.Role)
                                || (Eater.Role != null && Player == Eater.Role)
                                || (Arsonist.Role != null && Player == Arsonist.Role)
                                || (Outlaw.Role != null && Player == Outlaw.Role)
                                || (Cursed.Role != null && Player == Cursed.Role)
                                || (Cupid.Role != null && Player == Cupid.Role)
                                || (Survivor.Role != null && Player == Survivor.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Culte1 != null && Player == Cultist.Culte1)
                                || (Cultist.Culte2 != null && Player == Cultist.Culte3)
                                || (Cultist.Culte3 != null && Player == Cultist.Culte2)
                                ))
                            {
                                if (!LeaderList.Contains(Player)) { LeaderList.Add(Player); }
                            }
                        }
                    }
                }

                if (LeaderList.Count() >= 1) 
                {
                    LeaderList.Shuffle();
                    var rnd = new System.Random();
                    var randomizedLeaderList = LeaderList.OrderBy(item => rnd.Next());

                    //Check and remove 
                    LeaderList.RemoveRange(0, LeaderList.Count - 1);

                    if (LeaderList.Count > 0)
                    {
                        var PlayerTarget2 = rng.Next(0, LeaderList.Count);
                        Leader.Target2 = LeaderList[PlayerTarget2];
                        LeaderList.RemoveAt(PlayerTarget2);
                        byte playerId = Leader.Target2.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssignTarget2, Hazel.SendOption.Reliable, -1);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.assignTarget2(playerId);
                    }
                }
            }
            if (CopyCat.Role != null && CopyCat.Target != null && CopyCat.Target2 == null && (CopyCat.Role.Data.IsDead || LeaderTaskEnd.getBool() == true && CopyCat.TaskEND == true)
                && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.CopyStart == true && CopyCat.copyRole == 21 && !CopyCat.Used2)
            {
                //IMPOSTOR
                if (CopyCat.Target.Data.Role.IsImpostor)
                {
                    foreach (PlayerControl Player in PlayerControl.AllPlayerControls)
                    {
                        if (!Player.Data.IsDead && !Player.Data.Role.IsImpostor && Player != CopyCat.Target && Player != CopyCat.Role)
                        {
                            if (!LeaderCopyList.Contains(Player)) { LeaderCopyList.Add(Player); }
                        }
                    }
                }
                //NOT_IMPOSTOR
                else
                {
                    foreach (PlayerControl Player in PlayerControl.AllPlayerControls)
                    {
                        //SPECIAL+NEUTRE
                        if ((Jester.Role != null && Player == Jester.Role)
                                || (Eater.Role != null && Player == Eater.Role)
                                || (Arsonist.Role != null && Player == Arsonist.Role)
                                || (Outlaw.Role != null && Player == Outlaw.Role)
                                || (Cursed.Role != null && Player == Cursed.Role)
                                || (Cupid.Role != null && Player == Cupid.Role && LeaderAffectCupid.getBool() == true)
                                || (Survivor.Role != null && Player == Survivor.Role)
                                )
                        {
                            if (!Player.Data.IsDead && Player != CopyCat.Target && Player != CopyCat.Role)
                            {
                                if (!LeaderCopyList.Contains(Player)) { LeaderCopyList.Add(Player); }
                            }
                        }
                        //CULTE
                        else if ((Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                )
                        {
                            if (!Player.Data.IsDead
                                && Player != CopyCat.Target
                                && Player != Leader.Role
                                && Player != Cultist.Role
                                && Player != Cultist.Culte1
                                && Player != Cultist.Culte2
                                && Player != Cultist.Culte3)
                            {
                                if (!LeaderCopyList.Contains(Player)) { LeaderCopyList.Add(Player); }
                            }
                        }
                        //CREWMATE
                        else
                        {
                            if (!Player.Data.IsDead
                                && Player != CopyCat.Target
                                && Player != CopyCat.Role
                                && (Player.Data.Role.IsImpostor
                                || (Jester.Role != null && Player == Jester.Role)
                                || (Eater.Role != null && Player == Eater.Role)
                                || (Arsonist.Role != null && Player == Arsonist.Role)
                                || (Outlaw.Role != null && Player == Outlaw.Role)
                                || (Cursed.Role != null && Player == Cursed.Role)
                                || (Cupid.Role != null && Player == Cupid.Role)
                                || (Survivor.Role != null && Player == Survivor.Role)
                                || (Cultist.Role != null && Player == Cultist.Role)
                                || (Cultist.Culte1 != null && Player == Cultist.Culte1)
                                || (Cultist.Culte2 != null && Player == Cultist.Culte3)
                                || (Cultist.Culte3 != null && Player == Cultist.Culte2)
                                ))
                            {
                                if (!LeaderCopyList.Contains(Player)) { LeaderCopyList.Add(Player); }
                            }
                        }
                    }
                }

                if (LeaderCopyList.Count() >= 1)
                {
                    LeaderCopyList.Shuffle();
                    var rnd = new System.Random();
                    var randomizedLeaderCopyList = LeaderCopyList.OrderBy(item => rnd.Next());

                    //Check and remove 
                    LeaderCopyList.RemoveRange(0, LeaderCopyList.Count - 1);

                    if (LeaderCopyList.Count > 0)
                    {
                        var PlayerCopyTarget2 = rng.Next(0, LeaderCopyList.Count);
                        CopyCat.Target2 = LeaderCopyList[PlayerCopyTarget2];
                        LeaderCopyList.RemoveAt(PlayerCopyTarget2);
                        byte playerId = CopyCat.Target2.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssignCopyTarget2, Hazel.SendOption.Reliable, -1);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.assignCopyTarget2(playerId);
                    }
                }
            }

            


            SetNuclearTimeOn = false;
            SetNuclearSabTimeOn = false;
            StartTimer = true;
            ChallengerMod.Challenger.IsMeeting = true;
            SoundManager.Instance.StopSound(ALN);
            SoundManager.Instance.StopSound(Tic);
            SoundManager.Instance.StopSound(Shadow);
            SoundManager.Instance.StopSound(PoisonClip);
            SoundManager.Instance.StopSound(PoisonDelay);
            Camera.main.orthographicSize = 3f;
            if (Barghest.Role != null && PlayerControl.LocalPlayer == Barghest.Role)
            {
                Barghest.VentUse = false;
            }
                
            
            if (Cursed.Role != null)
            {
                Cursed.CurseStart = false;
                Cursed.NoCurse = false;

            }

            if (Bait.Role != null)
            {
                Bait.active = new Dictionary<ChallengerOS.Utils.Helpers.DeadPlayer, float>();
            }
            if (Vector.Role != null && Vector.Infected != null)
            {
                Vector.Infected = null;
            }

            

            if ( !ChallengerMod.Challenger.FirstTurn) // Wait 2nd meeting for second turn
            {
                ChallengerMod.Challenger.SecondTurn = true;
            }

            if (Revenger.Role != null && Revenger.Role.Data.IsDead && !Revenger.Exiled) //Proc if kill
            {
                if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    //AbilityDisabled = true;
                }
            }

            if (BuzzCommon.getSelection() != 0)
            {
                if (PlayerControl.LocalPlayer.RemainingEmergencies < QTEmergency)
                {
                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncEmergency, Hazel.SendOption.Reliable);
                    writer.Write(PlayerControl.LocalPlayer.RemainingEmergencies);
                    writer.EndMessage();
                    RPCProcedure.syncEmergency(PlayerControl.LocalPlayer.RemainingEmergencies);
                }
            }

            if (VitalTimeOn.getSelection() == 2)
            {
                ChallengerMod.Challenger.SetVitalTime = VitalTime.getFloat() + 0f;
            }
            if (CamTimeOn.getSelection() == 2)
            {
                ChallengerMod.Challenger.SetCamTime = CamTime.getFloat() + 0f;
            }
            if (AdminTimeOn.getSelection() == 2)
            {
                ChallengerMod.Challenger.SetAdminTime = AdminTime.getFloat() + 0f;
            }


            //FORCE OFF

            if (Sorcerer.Role != null && PlayerControl.LocalPlayer == Sorcerer.Role)
            {
                Sorcerer.ButtonCircle = false;
                Sorcerer.CircleEnabled = false;
            }

            LobbyTimeStop = false;
            LobbyLightOff = false;
            
            if (Eater.Role != null && PlayerControl.LocalPlayer == Eater.Role)
            {
                Eater.DistBody = 0;

            }

            if (Guardian.Role != null && Guardian.Protected != null && Guardian.TryKill)
            {
                Guardian.shieldattempt = true;
            }
            if (Guardian.Role != null && Guardian.ProtectedMystic != null && Guardian.TryKill)
            {
                Guardian.shieldattempt = true;
            }

            if (Spy.Role != null && Spy.Use && PlayerControl.LocalPlayer == Spy.Role)
            {
                RPCProcedure.spyOff();
            }
            if (Mentalist.Role != null && Mentalist.AdminVisibility && PlayerControl.LocalPlayer == Mentalist.Role)
            {
                RPCProcedure.mentalistColorOff();
            }
            if (Timelord.Role != null && Timelord.TimeStopped)
            {
                RPCProcedure.timeStop_End();
            }

            if (Timelord.Role != null && Timelord.TimeStopped)
            {
                RPCProcedure.timeStop_End();
            }
            if (Barghest.Role != null && Barghest.Shadow)
            {
                RPCProcedure.shadowOff();
            }
            if (Scrambler.Role != null && Scrambler.Camo)
            {
                RPCProcedure.camoOff();
            }
            if (Morphling.Role != null && Morphling.Morphed)
            {
                Morphling.Morphed = false;
                Morphling.StopMorphed = true;
            }

            
         

            //CULTIST DIE OR NOT
            if (Cultist.Role != null && Cultist.CulteTargetFail && Cultistdie.getSelection() == 2 && (PlayerControl.LocalPlayer == Cultist.Role) && !Cultist.Role.Data.IsDead)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CultistDie, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.cultistDie();
                GLMod.GLMod.currentGame.addAction(Cultist.Role.Data.PlayerName, "", "cultist_die");
            }
                        
        }
    }

    [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Destroy), new Type[] { typeof(UnityEngine.Object) })]
    class MeetingExiledEnd
    {

        static void Prefix(UnityEngine.Object obj)
        {
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Jester.Role != null)
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Jester.Role.PlayerId)
                    {

                            //ExileController.Instance.exiled = null;
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.JesterWin, Hazel.SendOption.None, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.jesterWin();
                        
                    }
                }
            }





            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Spirit.Role != null)
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Spirit.Role.PlayerId)
                    {

                        if (ChallengerMod.Set.Data.TotalPlayerAlive <= 7 && ChallengerMod.Set.Data.TotalImpoAlive >= 3)
                        { return; }
                        else if (ChallengerMod.Set.Data.TotalPlayerAlive <= 5 && ChallengerMod.Set.Data.TotalImpoAlive >= 2)
                        { return; }
                        else if (ChallengerMod.Set.Data.TotalPlayerAlive <= 3 && ChallengerMod.Set.Data.TotalImpoAlive >= 1)
                        { return; }
                        else
                        {
                            //ExileController.Instance.exiled = null;
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SpiritRevive, Hazel.SendOption.None, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.spiritRevive();
                            GLMod.GLMod.currentGame.addAction(Spirit.Role.Data.PlayerName, "", "spiritrevive");
                        }
                    }
                }
            }
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (CopyCat.Role != null && CopyCat.copyRole == 7 && CopyCat.CopyStart)
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == CopyCat.Role.PlayerId)
                    {

                        if (ChallengerMod.Set.Data.TotalPlayerAlive <= 7 && ChallengerMod.Set.Data.TotalImpoAlive >= 3)
                        { return; }
                        else if (ChallengerMod.Set.Data.TotalPlayerAlive <= 5 && ChallengerMod.Set.Data.TotalImpoAlive >= 2)
                        { return; }
                        else if (ChallengerMod.Set.Data.TotalPlayerAlive <= 3 && ChallengerMod.Set.Data.TotalImpoAlive >= 1)
                        { return; }
                        else
                        {
                            //ExileController.Instance.exiled = null;
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatRevive, Hazel.SendOption.None, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.copyCatRevive();
                            GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "spiritrevive");
                        }
                    }
                }
            }

            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Revenger.Role != null)
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Revenger.Role.PlayerId)
                    {
                        Revenger.isImpostor = true;
                    }
                }
            }

            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Hunter.Role != null && Hunter.Tracked != null) // Hunter Exiled = Player Tracked die
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Hunter.Role.PlayerId)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.HunterTrackedDie, Hazel.SendOption.None, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.hunterTrackedDie();
                        GLMod.GLMod.currentGame.addAction(Hunter.Role.Data.PlayerName, Hunter.Tracked.Data.PlayerName, "player_tracked_exil");
                    }
                }
            }
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (CopyCat.Role != null && Hunter.CopyTracked != null) // Hunter Exiled = Player Tracked die
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == CopyCat.Role.PlayerId)
                    {
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.HunterCopyTrackedDie, Hazel.SendOption.None, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.hunterCopyTrackedDie();
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, CopyCat.CopiedPlayer.Data.PlayerName, "player_tracked_exil");
                    }
                }
            }


            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null) // Cupid Sets Loved1>Loved2
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Cupid.Lover1.PlayerId)
                    {

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.LoversExiled, Hazel.SendOption.None, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.loversExiled();
                        GLMod.GLMod.currentGame.addAction(Cupid.Lover2.Data.PlayerName, Cupid.Lover1.Data.PlayerName, "lover_exile");
                        
                        Cupid.Fail = true;
                    }
                }
            }
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null) // Cupid Sets Loved1>Loved2
                {
                    if (ExileController.Instance.exiled != null && ExileController.Instance.exiled.PlayerId == Cupid.Lover2.PlayerId)
                    {

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.LoversExiled, Hazel.SendOption.None, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.loversExiled();

                        GLMod.GLMod.currentGame.addAction(Cupid.Lover1.Data.PlayerName, Cupid.Lover2.Data.PlayerName, "lover_exile");
                        Cupid.Fail = true;
                    }
                }
            }
        }
    }




    [HarmonyPatch(typeof(ExileController), nameof(ExileController.Begin))]
    class ExileControllerBeginPatch
    {
        public static void Prefix(ExileController __instance, [HarmonyArgument(0)] ref GameData.PlayerInfo exiled, [HarmonyArgument(1)] bool tie)
        {


            if (StartSabNuclear && !StartNuclear)
            {
                ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 2.5f);
                HudManager.Instance.FullScreen.color = new Color(0, 0f, 0f, 0f);
                SoundManager.Instance.StopSound(ALN);
                SoundManager.Instance.PlaySound(Burned, false, 100f); // a modif par explosion

                var SnowParticles = GameObject.Find("PolusShip(Clone)").transform.FindChild("SnowParticles");
                if (SnowParticles != null)
                {
                    UnityEngine.ParticleSystem SnowParticlesRend = SnowParticles.GetComponent<UnityEngine.ParticleSystem>();
                    SnowParticlesRend.startColor = blackColor;
                }
                IsMapPolusV2 = true;
                EmergencyDestroy = false;
                SetNuclearTimeOn = false;
                SetNuclearSabTimeOn = false;
                StartNuclear = true;
            }
            else
            {
                SetNuclearTimeOn = true;
            }

            
            ChallengerMod.Challenger.FirstTurn = false;
            ChallengerMod.Challenger.IsMeeting = false;

            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
            {
                if (ChallengerMod.Challenger.ComSab && StartComSabUnk)
                {
                    if (!PlayerControl.LocalPlayer.Data.IsDead)
                    {
                        players.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToCom, "", "", "", "");
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                    }
                }
                else
                {
                    if (!PlayerControl.LocalPlayer.Data.IsDead)
                    {
                        players.setDefaultLook();
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                    }
                }
            }

            if (Engineer.Role != null)
            {

                if (RepairSettings.getSelection() == 1)
                {
                    Engineer.RepairUsed = false; // Repair Round 
                }

            }
            if (Mystic.Role != null)
            {
                Mystic.ShieldButton = true;
                Mystic.selfShield = false;
            }
            

            if (Dictator.Role != null)
            {
                if (DictatorAbility.getSelection() != 1)
                {
                    if (DictatorMeeting.getSelection() == 0) // passif
                    {
                        Dictator.NoSkipButton = false;
                        Dictator.NoSkipUsed = true;
                        Dictator.HMActive = true;
                        CopyCat.HMActive = true;
                    }
                    if (DictatorMeeting.getSelection() == 1) // round
                    {
                        Dictator.NoSkipButton = true;
                        Dictator.NoSkipUsed = false;
                        Dictator.HMActive = false;
                        CopyCat.HMActive = false;


                    }
                    if (DictatorMeeting.getSelection() == 2) // Single
                    {
                        Dictator.NoSkipButton = true;
                        Dictator.HMActive = false;
                        CopyCat.HMActive = false;

                    }
                }
                else
                {
                    Dictator.NoSkipButton = false;
                    Dictator.NoSkipUsed = true;
                    Dictator.HMActive = false;
                    CopyCat.HMActive = false;
                }
            }
            if (Dictator.VotedFor != null)
            {
                Dictator.VotedFor = null;
            }

            if (Sheriff1.Role != null && SherifKillSettings.getSelection() != 2)
            {
                Sheriff1.CanKill = true;
            }
            if (Sheriff2.Role != null && SherifKillSettings.getSelection() != 2)
            {
                Sheriff2.CanKill = true;
            }
            if (Sheriff3.Role != null && SherifKillSettings.getSelection() != 2)
            {
                Sheriff3.CanKill = true;
            }


            if (Spy.Role != null)
            {
                Spy.SpyUsed = false;
            }
            if (Nightwatch.Role != null)
            {
                Nightwatch.LightBuff = false;
            }
            if (Detective.Role != null)
            {
                Detective.FindFP = false;
            }
            if (Ghost.Role != null)
            {
                Ghost.Role.Visible = true;
            }
            if (Mentalist.Role != null && AdminSetting.getSelection() == 1)
            {
                Mentalist.AdminUsed = false;
            }
            if (Informant.Role != null && InforAnalyseMod.getSelection() == 1)
            {
                Informant.Used = false;
            }
            if (Sentinel.Role != null)
            {
                Sentinel.Scan = false;
                Sentinel.ScanPlayerDie = 0;
                ChallengerMod.Challenger.bodys.Clear();
                ChallengerMod.Challenger.bodys = new List<Byte>();
            }
            if (CopyCat.Role != null)
            {
                CopyCat.ScanPlayerDie = 0;
                ChallengerMod.Challenger.bodys2.Clear();
                ChallengerMod.Challenger.bodys2 = new List<Byte>();
            }
            if (Eater.Role != null)
            {
                ChallengerMod.Challenger.EatedID.Clear();
                ChallengerMod.Challenger.EatedID = new List<Byte>();
            }
            if (Builder.Role != null)
            {
                Builder.round = false;
            }
            if (Lawkeeper.Role != null)
            {
                Lawkeeper.AbilityEnable = false;
            }
            if (Basilisk.Petrified != null)
            {
                Basilisk.Petrified = null;
                Basilisk.Used = false;
                Basilisk.PetrifyAndShield = false;
            }


            foreach (Vent vent in ChallengerMod.Challenger.ventsToSeal)
            {
                PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                animator?.Stop();
                vent.EnterVentAnim = vent.ExitVentAnim = null;
                vent.myRend.sprite = animator == null ? ChallengerMod.Unity.getStaticVentSealedSprite() : ChallengerMod.Unity.getAnimatedVentSealedSprite();
                vent.myRend.color = Color.white;
                vent.name = "SealedVent_" + vent.name;
            }
            if (Basilisk.Role != null)
            {
                Basilisk.PetrifyCount += Basilisk.DoseMeet;
            }

            ChallengerMod.Challenger.ventsToSeal = new List<Vent>();
            CustomButton.MeetingEndedUpdate();

        }
    }

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Close))]
    public class MeetingHud_Close
    {
        public static void Postfix(MeetingHud __instance)
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte)CustomRPC.RemoveAllBodies, SendOption.Reliable, -1);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            var buggedBodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
            foreach (var body in buggedBodies)
            {
                body.gameObject.Destroy();
            }
        }
    }
    [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.SetCosmetics))]
    public static class NameplateCosmetics
    {
        public static void Postfix(PlayerVoteArea __instance, [HarmonyArgument(0)] GameData.PlayerInfo playerInfo)
        {
            if (ChallengerMod.HarmonyMain.ServerID == "0"|| ChallengerMod.HarmonyMain.ServerID == "1" || ChallengerMod.HarmonyMain.ServerID == "2")
            {
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = true;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(true);
            }
            else
            {
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = false;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
            }
                
            
        }
    }

    [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.PreviewNameplate))]
    public static class NameplatePreview
    {
        public static void Postfix(PlayerVoteArea __instance, [HarmonyArgument(0)] string plateId)
        {

            if (ChallengerMod.HarmonyMain.ServerID == "0" || ChallengerMod.HarmonyMain.ServerID == "1" || ChallengerMod.HarmonyMain.ServerID == "2")
            {
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = true;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(true);
            }
            else
            {
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().enabled = false;
                __instance.LevelNumberText.GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString), new Type[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    class TranslationPatch
    {
        static void Postfix(ref string __result, StringNames __0)
        {
            if (ExileController.Instance != null && ExileController.Instance.exiled != null)
            {
                if (__0 == StringNames.ExileTextPN || __0 == StringNames.ExileTextSN)
                {
                    if (Guardian.Role != null && ExileController.Instance.exiled.Object.PlayerId == Guardian.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Guardian.";
                    else if (Engineer.Role != null && ExileController.Instance.exiled.Object.PlayerId == Engineer.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Engineer.";
                    else if (Cupid.Role != null && ExileController.Instance.exiled.Object.PlayerId == Cupid.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Cupid.";
                    else if (Cultist.Role != null && ExileController.Instance.exiled.Object.PlayerId == Cultist.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Cultiste.";
                    else if (Sheriff1.Role != null && ExileController.Instance.exiled.Object.PlayerId == Sheriff1.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Sherif.";
                    else if (Sheriff2.Role != null && ExileController.Instance.exiled.Object.PlayerId == Sheriff2.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Sherif.";
                    else if (Sheriff3.Role != null && ExileController.Instance.exiled.Object.PlayerId == Sheriff3.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Sherif.";
                    else if (Jester.Role != null && ExileController.Instance.exiled.Object.PlayerId == Jester.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Jester.";
                    else if (Cursed.Role != null && ExileController.Instance.exiled.Object.PlayerId == Cursed.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Cursed.";
                    else if (Builder.Role != null && ExileController.Instance.exiled.Object.PlayerId == Builder.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Builder.";
                    else if (Eater.Role != null && ExileController.Instance.exiled.Object.PlayerId == Eater.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Eater.";
                    else if (Survivor.Role != null && ExileController.Instance.exiled.Object.PlayerId == Survivor.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Survivor.";
                    else if (Mystic.Role != null && ExileController.Instance.exiled.Object.PlayerId == Mystic.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Mystic.";
                    else if (Nightwatch.Role != null && ExileController.Instance.exiled.Object.PlayerId == Nightwatch.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Nightwatch.";
                    else if (Spirit.Role != null && ExileController.Instance.exiled.Object.PlayerId == Spirit.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Spirit.";
                    else if (Mentalist.Role != null && ExileController.Instance.exiled.Object.PlayerId == Mentalist.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Mentalist.";
                    else if (Detective.Role != null && ExileController.Instance.exiled.Object.PlayerId == Detective.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Detective.";
                    else if (Mayor.Role != null && ExileController.Instance.exiled.Object.PlayerId == Mayor.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Mayor.";
                    else if (Spy.Role != null && ExileController.Instance.exiled.Object.PlayerId == Spy.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Spy.";
                    else if (Vector.Role != null && ExileController.Instance.exiled.Object.PlayerId == Vector.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Slayer.";
                    else if (Mercenary.Role != null && ExileController.Instance.exiled.Object.PlayerId == Mercenary.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Mercenary.";
                    else if (Timelord.Role != null && ExileController.Instance.exiled.Object.PlayerId == Timelord.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The TimeLord.";
                    else if (Assassin.Role != null && ExileController.Instance.exiled.Object.PlayerId == Assassin.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Assassin.";
                    else if (Bait.Role != null && ExileController.Instance.exiled.Object.PlayerId == Bait.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Bait.";
                    else if (Barghest.Role != null && ExileController.Instance.exiled.Object.PlayerId == Barghest.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Barghest.";
                    else if (Ghost.Role != null && ExileController.Instance.exiled.Object.PlayerId == Ghost.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Ghost.";
                    else if (Guesser.Role != null && ExileController.Instance.exiled.Object.PlayerId == Guesser.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Guesser.";
                    else if (Sorcerer.Role != null && ExileController.Instance.exiled.Object.PlayerId == Sorcerer.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Impostor.";
                    else if (Impostor1.Role != null && ExileController.Instance.exiled.Object.PlayerId == Impostor1.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Impostor.";
                    else if (Impostor2.Role != null && ExileController.Instance.exiled.Object.PlayerId == Impostor2.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Impostor.";
                    else if (Impostor3.Role != null && ExileController.Instance.exiled.Object.PlayerId == Impostor3.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Sorcerer.";
                    else if (Morphling.Role != null && ExileController.Instance.exiled.Object.PlayerId == Morphling.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Morphling.";
                    else if (Mesmer.Role != null && ExileController.Instance.exiled.Object.PlayerId == Mesmer.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Mesmer.";
                    else if (Scrambler.Role != null && ExileController.Instance.exiled.Object.PlayerId == Scrambler.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Camouflager.";
                    else if (Hunter.Role != null && ExileController.Instance.exiled.Object.PlayerId == Hunter.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Hunter.";
                    else if (Informant.Role != null && ExileController.Instance.exiled.Object.PlayerId == Informant.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Informant.";
                    else if (Dictator.Role != null && ExileController.Instance.exiled.Object.PlayerId == Dictator.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Dictator.";
                    else if (Sentinel.Role != null && ExileController.Instance.exiled.Object.PlayerId == Sentinel.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Sentienl.";
                    else if (Teammate1.Role != null && ExileController.Instance.exiled.Object.PlayerId == Teammate1.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Teammate.";
                    else if (Teammate2.Role != null && ExileController.Instance.exiled.Object.PlayerId == Teammate2.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Teammate.";
                    else if (Outlaw.Role != null && ExileController.Instance.exiled.Object.PlayerId == Outlaw.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Outlaw.";
                    else if (Arsonist.Role != null && ExileController.Instance.exiled.Object.PlayerId == Arsonist.Role.PlayerId)
                        __result = ExileController.Instance.exiled.PlayerName + " was The Arsonist.";
                    else
                        __result = ExileController.Instance.exiled.PlayerName + " was not The Impostor.";
                }
                if (__0 == StringNames.ImpostorsRemainP || __0 == StringNames.ImpostorsRemainS)
                {
                    if (Jester.Role != null && ExileController.Instance.exiled.Object.PlayerId == Jester.Role.PlayerId)
                        __result = "";
                }
            }
        }
    }
}
