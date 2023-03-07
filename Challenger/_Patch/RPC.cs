using HarmonyLib;
using Hazel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using ChallengerOS.Utils;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.Set.Data;
using ChallengerMod.Item;
using Reactor.Extensions;
using ChallengerOS.Object;
using ChallengerMod.Rnd;
using ChallengerOS.Objects;
using UnityEngine.Networking.Types;
using static UnityEngine.GraphicsBuffer;
using ChallengerOS;

namespace ChallengerMod.RPC
{
    enum RPC
    {
        PlayAnimation = 0,
        CompleteTask = 1,
        SyncSettings = 2,
        SetInfected = 3,
        Exiled = 4,
        CheckName = 5,
        SetName = 6,
        CheckColor = 7,
        SetColor = 8,
        SetHat = 9,
        SetSkin = 10,
        ReportDeadBody = 11,
        MurderPlayer = 12,
        SendChat = 13,
        StartMeeting = 14,
        SetScanner = 15,
        SendChatNote = 16,
        SetPet = 17,
        SetStartCounter = 18,
        EnterVent = 19,
        ExitVent = 20,
        SnapTo = 21,
        Close = 22,
        VotingComplete = 23,
        CastVote = 24,
        ClearVote = 25,
        AddVote = 26,
        CloseDoorsOfType = 27,
        RepairSystem = 28,
        SetTasks = 29,
        UpdateGameData = 30,
    }
    enum SetRoleID
    {
        SetSheriff1 = 1,
        SetSheriff2,
        SetSheriff3,
        SetGuardian,
        SetEngineer,
        SetHunter,
        SetTimelord,
        SetMystic,
        SetSpirit,
        SetMayor,
        SetDetective,
        SetNightwatch,
        SetSpy,
        SetInformant,
        SetBait,
        SetMentalist,
        SetBuilder,
        SetDictator,
        SetSentinel,
        SetTeammate1,
        SetTeammate2,
        SetLawkeeper,
        SetFake,
        SetTraveler,
        SetLeader,
        SetDoctor,
        SetSlave,

        SetCrewmate1,
        SetCrewmate2,
        SetCrewmate3,
        SetCrewmate4,
        SetCrewmate5,
        SetCrewmate6,
        SetCrewmate7,
        SetCrewmate8,
        SetCrewmate9,
        SetCrewmate10,
        SetCrewmate11,
        SetCrewmate12,
        SetCrewmate13,
        SetCrewmate14,

        SetCupid,
        SetCultist,
        SetOutlaw,
        SetJester,
        SetEater,
        SetArsonist,
        SetCursed,

        SetMercenary,
        SetCopyCat,
        SetRevenger,
        SetSurvivor,


        SetAssassin,
        SetVector,
        SetMorphling,
        SetScrambler,
        SetBarghest,
        SetGhost,
        SetSorcerer,
        SetGuesser,
        SetMesmer,
        SetBasilisk,
        SetReaper,
        SetSaboteur,

        SetImpostor1,
        SetImpostor2,
        SetImpostor3,
    }


    enum CustomRPC
    {
        // Main Controls
        
        ShareAllRoles = 72,
        ShareNewPLayerSlot,
        ShareNewMapID,
        SyncTimer,
        SyncMap,
        SyncDie,
        SyncEmergency,
        RemoveAllBodies,
        SetLocalPlayers,
        SetRole,
        SetVisorColor,

        //winner
        SetWinLove,
        SetLooseLove,
        SetWinCrewmatesByTask,
        SetWinCrewmatesByKill,
        SetWinImpostorsByKill,
        SetWinImpostorsBySab,
        SetWinJester,
        SetWinEater,
        SetWinOutlaw,
        SetWinArsonist,
        SetWinCulte,
        SetWinCursed,

        //Items
        SpawnItem,
        DestroyItem,

        //MIRA
        ShareDronePosition,
        StopDrone,

        //sheriff
        Sheriff1Kill,
        Sheriff2Kill,
        Sheriff3Kill,

        //guardian
        ShieldedMurderAttempt,
        SetProtectedPlayer,
        SetProtectedMystic,
        SetProtectedCopyMystic,

        //engineer
        EngineerRepair,
        EngineerFixLight,

        //timelord
        TimeStop_Start,
        TimeStop_End,

        //hunter
        SetTrackedPlayer,
        HunterTrackedDie,
        HunterTrackedKill,
        SetCopyTrackedPlayer,
        HunterCopyTrackedDie,
        HunterCopyTrackedKill,

        //Mystic 
        MysticDoubleShield,
        MysticShieldOn,
        MysticShieldOff,

        //spirit
        SpiritRevive,
        CopyCatRevive,

        //Mayor
        MayorBuzz,

        //Detective
        DetectiveFindFPOn,
        DetectiveFindFPOff,

        //Nightwatch
        NightwatchLightOn,
        NightwatchLightOff,


        //Spy
        SpyOn,
        SpyOff,

        //Informant
        SetInfoPlayer,

        //Bait
        BaitBalise,
        BaitBaliseEnable,
        AddArrow,

        //Mentalist
        MentalistColorOn,
        MentalistColorOff,

        //Sentinel
        SentinelScanOn,
        SentinelScanOff,

        //Builder
        SealVent,

        //Dictator
        DictatorNoSkipVote,

        //Leader
        AssignTarget1,
        AssignTarget2,
        AssignCopyTarget1,
        AssignCopyTarget2,

        //Jester
        JesterFakeKill,
        JesterWin,

        //Eater
        CleanBody,

        //Cupid
        LoversExiled,
        KillLover1,
        KillLover2,

        //Cultist
        SetCulte1Player,
        SetCulte2Player,
        SetCulte3Player,
        CultistDie,

        //Eater
        DraggBody,
        DropBody,
        EatBody,

        //Cursed
        CursedWin,
        CurseSync,

        //Mercenary
        MercenaryKill,
        MercenaryTryKill,

        //CopyCat
        SetCopyPlayer,
        CopyCatDie,
        CopyCatKill,

        //Outlaw
        OutlawKill,

        //Arsonist
        ArsonistWin,
        ArsonistAddOil,

        //Revenger
        SetEMP1Player,
        SetEMP2Player,
        SetEMP3Player,

        //Sorcerer
        SetScan1Player,
        SetScan2Player,
        SetExtPlayer,
        SabAdmin,

        //Vector
        SetInfectePlayer,
        KillInfected,

        //Morphling
        SetMorphPlayer,
        MorphOn,
        MorphOff,


        //Scrambler
        CamoOn,
        CamoOff,

        //Barghest
        ShadowOn,
        ShadowOff,
        CreateVent,

        //Ghost
        GhostOn,
        GhostOff,

        //Sorcerer
        War1,
        War2,
        War3,
        War4,

        //Guesser
        GuesserShoot,
        GuesserFail,

        //Basilisk
        SetPetrifyPlayer,
        SetPetrifyAndShieldPlayer,

        //Impostors NormalKill
        VectorKill,
        Impostor1Kill,
        Impostor2Kill,
        Impostor3Kill,
        MorphlingKill,
        ScramblerKill,
        BarghestKill,
        GhostKill,
        SorcererKill,
        GuesserKill,
        BasiliskKill,
        ReaperKill,
        SaboteurKill,

        //Assassin
        AssassinKill,
        AssassinShield,

        //Mesmer
        MindControlOn,
        MindControl,

       
    }
    public static class RPCProcedure
    {
        public static void setRole(byte roleId, byte playerId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == playerId)
                {
                    switch ((SetRoleID)roleId)
                    {
                       
                        case SetRoleID.SetSheriff1:
                            Sheriff1.Role = player;
                            break;
                        case SetRoleID.SetSheriff2:
                            Sheriff2.Role = player;
                            break;
                        case SetRoleID.SetSheriff3:
                            Sheriff3.Role = player;
                            break;
                        case SetRoleID.SetGuardian:
                            Guardian.Role = player;
                            break;
                        case SetRoleID.SetEngineer:
                            Engineer.Role = player;
                            break;
                        case SetRoleID.SetTimelord:
                            Timelord.Role = player;
                            break;
                        case SetRoleID.SetHunter:
                            Hunter.Role = player;
                            break;
                        case SetRoleID.SetMystic:
                            Mystic.Role = player;
                            break;
                        case SetRoleID.SetSpirit:
                            Spirit.Role = player;
                            break;
                        case SetRoleID.SetMayor:
                            Mayor.Role = player;
                            break;
                        case SetRoleID.SetDetective:
                            Detective.Role = player;
                            break;
                        case SetRoleID.SetNightwatch:
                            Nightwatch.Role = player;
                            break;
                        case SetRoleID.SetSpy:
                            Spy.Role = player;
                            break;
                        case SetRoleID.SetInformant:
                            Informant.Role = player;
                            break;
                        case SetRoleID.SetBait:
                            Bait.Role = player;
                            break;
                        case SetRoleID.SetMentalist:
                            Mentalist.Role = player;
                            break;
                        case SetRoleID.SetBuilder:
                            Builder.Role = player;
                            break;
                        case SetRoleID.SetDictator:
                            Dictator.Role = player;
                            break;
                        case SetRoleID.SetSentinel:
                            Sentinel.Role = player;
                            break;
                        case SetRoleID.SetTeammate1:
                            Teammate1.Role = player;
                            break;
                        case SetRoleID.SetTeammate2:
                            Teammate2.Role = player;
                            break;
                        case SetRoleID.SetLawkeeper:
                            Lawkeeper.Role = player;
                            break;
                        case SetRoleID.SetFake:
                            Fake.Role = player;
                            break;
                        case SetRoleID.SetTraveler:
                            Traveler.Role = player;
                            break;
                        case SetRoleID.SetLeader:
                            Leader.Role = player;
                            break;
                        case SetRoleID.SetDoctor:
                            Doctor.Role = player;
                            break;
                        case SetRoleID.SetSlave:
                            Slave.Role = player;
                            break;
                        case SetRoleID.SetCrewmate1:
                            Crewmate1.Role = player;
                            break;
                        case SetRoleID.SetCrewmate2:
                            Crewmate2.Role = player;
                            break;
                        case SetRoleID.SetCrewmate3:
                            Crewmate3.Role = player;
                            break;
                        case SetRoleID.SetCrewmate4:
                            Crewmate4.Role = player;
                            break;
                        case SetRoleID.SetCrewmate5:
                            Crewmate5.Role = player;
                            break;
                        case SetRoleID.SetCrewmate6:
                            Crewmate6.Role = player;
                            break;
                        case SetRoleID.SetCrewmate7:
                            Crewmate7.Role = player;
                            break;
                        case SetRoleID.SetCrewmate8:
                            Crewmate8.Role = player;
                            break;
                        case SetRoleID.SetCrewmate9:
                            Crewmate9.Role = player;
                            break;
                        case SetRoleID.SetCrewmate10:
                            Crewmate10.Role = player;
                            break;
                        case SetRoleID.SetCrewmate11:
                            Crewmate11.Role = player;
                            break;
                        case SetRoleID.SetCrewmate12:
                            Crewmate12.Role = player;
                            break;
                        case SetRoleID.SetCrewmate13:
                            Crewmate13.Role = player;
                            break;
                        case SetRoleID.SetCrewmate14:
                            Crewmate14.Role = player;
                            break;
                        case SetRoleID.SetCupid:
                            Cupid.Role = player;
                            break;
                        case SetRoleID.SetCultist:
                            Cultist.Role = player;
                            break;
                        case SetRoleID.SetOutlaw:
                            Outlaw.Role = player;
                            break;
                        case SetRoleID.SetJester:
                            Jester.Role = player;
                            break;
                        case SetRoleID.SetEater:
                            Eater.Role = player;
                            break;
                        case SetRoleID.SetArsonist:
                            Arsonist.Role = player;
                            break;
                        case SetRoleID.SetCursed:
                            Cursed.Role = player;
                            break;
                        case SetRoleID.SetMercenary:
                            Mercenary.Role = player;
                            break;
                        case SetRoleID.SetCopyCat:
                            CopyCat.Role = player;
                            break;
                        case SetRoleID.SetSurvivor:
                            Survivor.Role = player;
                            break;
                        case SetRoleID.SetRevenger:
                            Revenger.Role = player;
                            break;
                        case SetRoleID.SetAssassin:
                            Assassin.Role = player;
                            break;
                        case SetRoleID.SetVector:
                            Vector.Role = player;
                            break;
                        case SetRoleID.SetMorphling:
                            Morphling.Role = player;
                            break;
                        case SetRoleID.SetScrambler:
                            Scrambler.Role = player;
                            break;
                        case SetRoleID.SetBarghest:
                            Barghest.Role = player;
                            break;
                        case SetRoleID.SetGhost:
                            Ghost.Role = player;
                            break;
                        case SetRoleID.SetSorcerer:
                            Sorcerer.Role = player;
                            break;
                        case SetRoleID.SetGuesser:
                            Guesser.Role = player;
                            break;
                        case SetRoleID.SetMesmer:
                            Mesmer.Role = player;
                            break;
                        case SetRoleID.SetBasilisk:
                            Basilisk.Role = player;
                            break;
                        case SetRoleID.SetReaper:
                            Reaper.Role = player;
                            break;
                        case SetRoleID.SetSaboteur:
                            Saboteur.Role = player;
                            break;
                        case SetRoleID.SetImpostor1:
                            Impostor1.Role = player;
                            break;
                        case SetRoleID.SetImpostor2:
                            Impostor2.Role = player;
                            break;
                        case SetRoleID.SetImpostor3:
                            Impostor3.Role = player;
                            break;
                    }
                }
        }
        // Main Controls
        public static void setVisorColor(byte PlayerColor, int ColorID)
        {
            int _ColorID = 0;
            _ColorID = ColorID;
            PlayerControl _Player = Helpers.playerById(PlayerColor);
            
            int _Player_ColorID = _Player.Data.DefaultOutfit.ColorId;

            if (_Player_ColorID == 18)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Bloody.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 19)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Earth.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 21)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Chedard.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 22)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Sun.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 23)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Leef.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 24)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Radian.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 25)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Swamp.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 26)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Ice.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 27)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Lagoon.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 28)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Ocean.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 29)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Night.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 30)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Dawn.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 31)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Candy.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 32)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Galaxy.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 33)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Snow.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 33)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Cender.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 34)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Dark.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
            if (_Player_ColorID == 35)
            {
                ChallengerOS.Utils.Option.CustomOptionHolder.Color_Rainbow.updateSelection(_ColorID);
                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
            }
        }

        public static void shareNewPLayerSlot(int Value)
        {
            PlayerControl.GameOptions.MaxPlayers = Value;
        }
        public static void shareNewMapID(byte ID)
        {
            PlayerControl.GameOptions.MapId = ID;
        }
        public static void syncTimer(float TimerSyncro)
        {
            Challenger.NuclearTimer = TimerSyncro + 2f;
            //ChallengerMod.CustomButton.HudManagerStartPatch.setCustomButtonCooldowns();
            ReSyncIntro = true;

        }
        public static void syncMap()
        {
            ChallengerMod.Challenger.NuclearMap = true;

        }

        
        public static void syncDie(byte Player)
        {
            PlayerControl PlayerDie = Helpers.playerById(Player);
            if (PlayerDie != null)
            {
                PlayerDie.Die(DeathReason.Kill);
                PlayerDie.Data.IsDead = true;
            }
        }
        public static void syncEmergency(int Emergency)
        {
            Challenger.QTEmergency = Emergency;
            PlayerControl.LocalPlayer.RemainingEmergencies = Emergency;
        }
        
        
       
       
        
        public static void shareAllRoles()
        {
            RoleAssigned = true;
            Challenger._Alls = PlayerControl.AllPlayerControls.ToArray().ToList().OrderBy(x => Guid.NewGuid()).ToList();
            return;
        }


        //WINNER
        public static void setWinLove()
        {
            LoveWinthegame = true;
            CupidWin = true;
            return;
        }
        public static void setlooseLove()
        {
            LoveWinthegame = false;
            CupidWin = false;
            return;
        }
        public static void setWinCrewmatesByTask()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = true;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = true;
            Sheriff2Win = true;
            Sheriff3Win = true;
            GuardianWin = true;
            EngineerWin = true;
            HunterWin = true;
            TimelordWin = true;
            MysticWin = true;
            SpiritWin = true;
            MayorWin = true;
            DetectiveWin = true;
            NightwatchWin = true;
            SpyWin = true;
            InformantWin = true;
            BaitWin = true;
            MentalistWin = true;
            BuilderWin = true;
            DictatorWin = true;
            SentinelWin = true;
            Teammate1Win = true;
            Teammate2Win = true;
            LawkeeperWin = true;
            FakeWin = true;
            TravelerWin = true;
            LeaderWin = true;
            DoctorWin = true;
            SlaveWin = true;

            //CREWMATE VANILLA
            Crewmate1Win = true;
            Crewmate2Win = true;
            Crewmate3Win = true;
            Crewmate4Win = true;
            Crewmate5Win = true;
            Crewmate6Win = true;
            Crewmate7Win = true;
            Crewmate8Win = true;
            Crewmate9Win = true;
            Crewmate10Win = true;
            Crewmate11Win = true;
            Crewmate12Win = true;
            Crewmate13Win = true;
            Crewmate14Win = true;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            if (MercenaryICount == true) { MercenaryWin = false; MercenaryCWin = false; }
            else { MercenaryWin = false; MercenaryCWin = true; }
            if (CopyCatICount == true) { CopyCatWin = false; CopyCatCWin = false; }
            else { CopyCatWin = false; CopyCatCWin = true; }
            if (RevengerICount == true) { RevengerWin = false; RevengerCWin = false; }
            else { RevengerWin = false; RevengerCWin = true; }

            if (Survivor_Alive == 1) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;


            return;
        }
        public static void setWinCrewmatesByKill()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = true;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = true;
            Sheriff2Win = true;
            Sheriff3Win = true;
            GuardianWin = true;
            EngineerWin = true;
            HunterWin = true;
            TimelordWin = true;
            MysticWin = true;
            SpiritWin = true;
            MayorWin = true;
            DetectiveWin = true;
            NightwatchWin = true;
            SpyWin = true;
            InformantWin = true;
            BaitWin = true;
            MentalistWin = true;
            BuilderWin = true;
            DictatorWin = true;
            SentinelWin = true;
            Teammate1Win = true;
            Teammate2Win = true;
            LawkeeperWin = true;
            FakeWin = true;
            TravelerWin = true;
            LeaderWin = true;
            DoctorWin = true;
            SlaveWin = true;

            //CREWMATE VANILLA
            Crewmate1Win = true;
            Crewmate2Win = true;
            Crewmate3Win = true;
            Crewmate4Win = true;
            Crewmate5Win = true;
            Crewmate6Win = true;
            Crewmate7Win = true;
            Crewmate8Win = true;
            Crewmate9Win = true;
            Crewmate10Win = true;
            Crewmate11Win = true;
            Crewmate12Win = true;
            Crewmate13Win = true;
            Crewmate14Win = true;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            if (MercenaryICount == true) { MercenaryWin = false; MercenaryCWin = false; }
            else { MercenaryWin = false; MercenaryCWin = true; }
            if (CopyCatICount == true) { CopyCatWin = false; CopyCatCWin = false; }
            else { CopyCatWin = false; CopyCatCWin = true; }
            if (RevengerICount == true) { RevengerWin = false; RevengerCWin = false; }
            else { RevengerWin = false; RevengerCWin = true; }

            if (Survivor_Alive == 1) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinImpostorByKill()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = true;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            if (MercenaryICount == true) { MercenaryWin = true; MercenaryCWin = false; }
            else { MercenaryWin = false; MercenaryCWin = false; }
            if (CopyCatICount == true) { CopyCatWin = true; CopyCatCWin = false; }
            else { CopyCatWin = false; CopyCatCWin = false; }
            if (RevengerICount == true) { RevengerWin = true; RevengerCWin = false; }
            else { RevengerWin = false; RevengerCWin = false; }

            if (Survivor_Alive == 1) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = true;
            VectorWin = true;
            MorphlingWin = true;
            ScramblerWin = true;
            BarghestWin = true;
            GhostWin = true;
            SorcererWin = true;
            GuesserWin = true;
            MesmerWin = true;
            BasiliskWin = true;
            ReaperWin = true;
            SaboteurWin = true;

            //IMPOSTOR VANILLA
            Impostor1Win = true;
            Impostor2Win = true;
            Impostor3Win = true;

            return;
        }
        public static void setWinImpostorBySab()
        {
            Challenger.debugg = "RPC OK";
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = true;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            if (MercenaryICount == true) { MercenaryWin = true; MercenaryCWin = false; }
            else { MercenaryWin = false; MercenaryCWin = false; }
            if (CopyCatICount == true) { CopyCatWin = true; CopyCatCWin = false; }
            else { CopyCatWin = false; CopyCatCWin = false; }
            if (RevengerICount == true) { RevengerWin = true; RevengerCWin = false; }
            else { RevengerWin = false; RevengerCWin = false; }

            if (Survivor_Alive == 1) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = true;
            VectorWin = true;
            MorphlingWin = true;
            ScramblerWin = true;
            BarghestWin = true;
            GhostWin = true;
            SorcererWin = true;
            GuesserWin = true;
            MesmerWin = true;
            BasiliskWin = true;
            ReaperWin = true;
            SaboteurWin = true;

            //IMPOSTOR VANILLA
            Impostor1Win = true;
            Impostor2Win = true;
            Impostor3Win = true;

            return;
        }
        public static void setWinJester()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = true;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = true;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinJester.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinEater()
        {
            CulteWinthegame = false;
            EaterWinthegame = true;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = true;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinEater.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinOutlaw()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = true;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = true;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinOutlaw.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinArsonist()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = true;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = true;
            CultistWin = false;
            CursedWin = false;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinArsonist.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinCulte()
        {
            CulteWinthegame = true;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = true;
            CursedWin = false;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinCulte.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }
        public static void setWinCursed()
        {
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = true;

            //CREWMATES ROLE
            Sheriff1Win = false;
            Sheriff2Win = false;
            Sheriff3Win = false;
            GuardianWin = false;
            EngineerWin = false;
            HunterWin = false;
            TimelordWin = false;
            MysticWin = false;
            SpiritWin = false;
            MayorWin = false;
            DetectiveWin = false;
            NightwatchWin = false;
            SpyWin = false;
            InformantWin = false;
            BaitWin = false;
            MentalistWin = false;
            BuilderWin = false;
            DictatorWin = false;
            SentinelWin = false;
            Teammate1Win = false;
            Teammate2Win = false;
            LawkeeperWin = false;
            FakeWin = false;
            TravelerWin = false;
            LeaderWin = false;
            DoctorWin = false;
            SlaveWin = false;

            //CREWMATE VANILLA
            Crewmate1Win = false;
            Crewmate2Win = false;
            Crewmate3Win = false;
            Crewmate4Win = false;
            Crewmate5Win = false;
            Crewmate6Win = false;
            Crewmate7Win = false;
            Crewmate8Win = false;
            Crewmate9Win = false;
            Crewmate10Win = false;
            Crewmate11Win = false;
            Crewmate12Win = false;
            Crewmate13Win = false;
            Crewmate14Win = false;

            //SPECIAL
            JesterWin = false;
            EaterWin = false;
            OutlawWin = false;
            ArsonistWin = false;
            CultistWin = false;
            CursedWin = true;

            //HYBRID
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;

            if (Survivor_Alive == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinCursed.getBool() == true) { SurvivorWin = true; }
            else { SurvivorWin = false; }


            //IMPOSTOR ROLE
            AssassinWin = false;
            VectorWin = false;
            MorphlingWin = false;
            ScramblerWin = false;
            BarghestWin = false;
            GhostWin = false;
            SorcererWin = false;
            GuesserWin = false;
            MesmerWin = false;
            BasiliskWin = false;
            ReaperWin = false;
            SaboteurWin = false;

            //IMPOSTOR VANILLA
            Impostor1Win = false;
            Impostor2Win = false;
            Impostor3Win = false;

            return;
        }

        //ITEM

        //SHERIFF
        public static void sheriff1kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Sheriff1.Role.PlayerId)
                {
                    Sheriff1.Suicide = true;
                   GLMod.GLMod.currentGame.addAction(Sheriff1.Role.Data.PlayerName, "", "suicide_sheriff");
                }
                if (player.PlayerId == targetId)
                {
                    
                    Sheriff1.Role.MurderPlayer(player);
                    Sheriff1.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Sheriff1.Role.Data.PlayerName, player.Data.PlayerName, "kill_sheriff");

                    return;
                }
                
            }
        }
        public static void sheriff2kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Sheriff2.Role.PlayerId)
                {
                    Sheriff2.Suicide = true;
                    GLMod.GLMod.currentGame.addAction(Sheriff2.Role.Data.PlayerName, "", "suicide_sheriff");
                }
                if (player.PlayerId == targetId)
                {
                    Sheriff2.Role.MurderPlayer(player);
                    Sheriff2.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Sheriff2.Role.Data.PlayerName, player.Data.PlayerName, "kill_sheriff");

                    return;
                }
            }
        }
        public static void sheriff3kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Sheriff3.Role.PlayerId)
                {
                    Sheriff3.Suicide = true;
                    GLMod.GLMod.currentGame.addAction(Sheriff3.Role.Data.PlayerName, "", "suicide_sheriff");
                }
                if (player.PlayerId == targetId)
                {
                    Sheriff3.Role.MurderPlayer(player);
                    Sheriff3.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Sheriff3.Role.Data.PlayerName, player.Data.PlayerName, "kill_sheriff");

                    return;
                }
            }
        }
       

        public static void setProtectedPlayer(byte protectedId)
        {
           
            Guardian.ShieldUsed = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == protectedId)
                {
                    Guardian.Protected = player;
                    if (!Guardian.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(Guardian.Role.Data.PlayerName, player.Data.PlayerName, "player_shielded");
                    }
                    if (Guardian.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "player_shielded");
                    }
                }

            }
        }
        public static void setProtectedMystic(byte protectedmysticId)
        {
            Guardian.ShieldUsed = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == protectedmysticId)
                {
                    Guardian.ProtectedMystic = player;
                    Mystic.DoubleShield = true;
                    Guardian.Protected = player;
                    
                    if (!Guardian.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(Guardian.Role.Data.PlayerName, player.Data.PlayerName, "player_supershielded");
                    }
                    if (Guardian.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "player_supershielded");
                    }
                }
            }
        }
        public static void setProtectedCopyMystic()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == CopyCat.Role.PlayerId)
                {
                    Guardian.ProtectedMystic = player;
                    Mystic.DoubleShield = true;
                    Mystic.selfShield = true;

                    
                    GLMod.GLMod.currentGame.addAction(Guardian.Role.Data.PlayerName, player.Data.PlayerName, "player_supershielded");
                    
                }
                    
            }
                
        }

        //ENGINEER
        public static void engineerRepair()
        {
            Engineer.RepairUsed = true;
            GLMod.GLMod.currentGame.addAction(Engineer.Role.Data.PlayerName, "", "sabotage_repair");

        }

        public static void engineerFixLight()
        {
            SwitchSystem switchSystem = ShipStatus.Instance.Systems[SystemTypes.Electrical].Cast<SwitchSystem>();
            switchSystem.ActualSwitches = switchSystem.ExpectedSwitches;
        }

        //TIMELORD

        public static void timeStop_Start(int WhoStopTime)
        {
            HudManager.Instance.FullScreen.gameObject.SetActive(true);
            HudManager.Instance.FullScreen.enabled = true;
            HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0.8f, 0.3f);
            SoundManager.Instance.PlaySound(breakClip, false, 100f);
            SoundManager.Instance.PlaySound(Tic, true, 100f);
            Timelord.TimeStopped = true;

            if (WhoStopTime == 1)
            {
                Timelord.TimeLordStopTime = true;
                GLMod.GLMod.currentGame.addAction(Timelord.Role.Data.PlayerName, "", "timestopped");
            }
            if (WhoStopTime == 2)
            {
                Timelord.CopyCatStopTime = true;
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "timestopped");
            }
            if (WhoStopTime == 3)
            {
                Timelord.AssassinStopTime = true;
                GLMod.GLMod.currentGame.addAction(Assassin.Role.Data.PlayerName, "", "timestopped");
            }


            if (Timelord.Role != null && (PlayerControl.LocalPlayer == Timelord.Role)
                || (Timelord.Role.Data.IsDead && CopyCat.Role != null && CopyCat.copyRole == 4 && (PlayerControl.LocalPlayer == CopyCat.Role) && CopyCat.CopyStart == true)
                || (Assassin.Role != null && Assassin.StealTime == true && PlayerControl.LocalPlayer == Assassin.Role))
            {
                PlayerControl.LocalPlayer.moveable = true;
            }
            else
            {
                if (PlayerControl.LocalPlayer.Data.IsDead)
                {
                    PlayerControl.LocalPlayer.moveable = true;
                }
                else
                {
                    PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                    if (Minigame.Instance)
                    {
                        Minigame.Instance.enabled = false;
                        if (VitalsMinigame.Instance.isActiveAndEnabled)
                        { VitalsMinigame.Instance.Close(); }
                        if (PlanetSurveillanceMinigame.Instance.isActiveAndEnabled)
                        { PlanetSurveillanceMinigame.Instance.Close(); }
                        PlayerControl.LocalPlayer.moveable = false;
                        Challenger.LobbyTimeStop = true;
                    }

                    else
                    {
                        if (PlayerControl.LocalPlayer.inVent)
                        {
                            PlayerControl.LocalPlayer.inVent = false;
                            Challenger.InVent = true;
                            Challenger.LobbyTimeStop = true;
                            PlayerControl.LocalPlayer.moveable = false;
                        }
                        else
                        {
                            Challenger.LobbyTimeStop = true;
                            PlayerControl.LocalPlayer.moveable = false;
                        }
                    }


                }
            }
        }

        public static void timeStop_End()
        {

            

            if (Barghest.Shadow)
            {
                HudManager.Instance.FullScreen.gameObject.SetActive(true);
                HudManager.Instance.FullScreen.enabled = true;
                HudManager.Instance.FullScreen.color = new Color(0.2f, 0.2f, 0.4f, 0.3f);
            }
            else
            {
                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0f);
            }

            SoundManager.Instance.PlaySound(timeoff, false, 100f);
            SoundManager.Instance.StopSound(Tic);
            Timelord.TimeLordStopTime = false;
            Timelord.CopyCatStopTime = false;
            Timelord.AssassinStopTime = false;
            Timelord.TimeStopped = false;

            if (Minigame.Instance)
            {
                Minigame.Instance.enabled = true;
                PlayerControl.LocalPlayer.moveable = true;
                Challenger.LobbyTimeStop = false;
            }
            else
            {
                if (Challenger.InVent == true)
                {
                    PlayerControl.LocalPlayer.inVent = true;
                    Challenger.InVent = false;
                    PlayerControl.LocalPlayer.moveable = false;
                    Challenger.LobbyTimeStop = false;
                }
                else
                {
                    if (Spy.Role != null && PlayerControl.LocalPlayer == Spy.Role)
                    {
                        if (Spy.Use == true)
                        {
                            Challenger.LobbyTimeStop = false;
                        }
                        else
                        {
                            PlayerControl.LocalPlayer.moveable = true;
                            Challenger.LobbyTimeStop = false;
                        }
                    }
                    else
                    {
                        PlayerControl.LocalPlayer.moveable = true;
                        Challenger.LobbyTimeStop = false;
                    }

                }
            }

        }
        //HUNTER
        public static void setTrackedPlayer(byte TrackedId)
        {
            Hunter.TrackUsed = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == TrackedId)
                {
                    Hunter.Tracked = player;
                    GLMod.GLMod.currentGame.addAction(Hunter.Role.Data.PlayerName, player.Data.PlayerName, "player_tracked");
                }
            }
                
                   
        }
        public static void hunterTrackedDie()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Hunter.Tracked)
                {
                    player.Die(DeathReason.Exile);
                    
                }
                Hunter.Role.Data.IsDead = true;
                Hunter.Tracked.Data.IsDead = true;
            }
        }
        public static void hunterTrackedKill()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Hunter.Tracked)
                {
                    Hunter.KilledByHunter = true;
                    Hunter.Tracked.MurderPlayer(Hunter.Tracked);
                    

                }
                Hunter.Role.Data.IsDead = true;
                Hunter.Tracked.Data.IsDead = true;

            }
        }
        public static void setCopyTrackedPlayer(byte CopyTrackedId)
        {
            Hunter.CopyTrackUsed = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == CopyTrackedId)
                {
                    Hunter.CopyTracked = player;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "player_tracked");

                }

            }
                
        }
        public static void hunterCopyTrackedDie()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Hunter.CopyTracked)
                {
                    player.Die(DeathReason.Exile);
                   

                }
                CopyCat.Role.Data.IsDead = true;
                Hunter.CopyTracked.Data.IsDead = true;
            }
        }
        public static void hunterCopyTrackedKill()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Hunter.CopyTracked)
                {
                    Hunter.KilledByCopyHunter = true;
                    Hunter.CopyTracked.MurderPlayer(Hunter.CopyTracked);
                   

                }
                CopyCat.Role.Data.IsDead = true;
                Hunter.CopyTracked.Data.IsDead = true;

            }
        }

        //MYSTIC 

        public static void mysticShieldOn()
        {
            Mystic.selfShield = true;
            
            
            if (Mystic.Role.Data.IsDead && CopyCat.Role != null)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "mysticshield");
            }
            else
            {
                GLMod.GLMod.currentGame.addAction(Mystic.Role.Data.PlayerName, "", "mysticshield");
            }
        }
        public static void mysticShieldOff()
        {
            Mystic.selfShield = false;
        }


        //SPIRIT
        public static void spiritRevive()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                //Spirit Cancel Exile
                if (player == Spirit.Role)
                {
                    player.Revive();
                    player.Data.IsDead = false;
                    Spirit.Role.Data.IsDead = false;
                }
                else if (player != Spirit.Role)
                {
                    Spirit.Role.Data.IsDead = false;
                }
            }
            Spirit.Role.Data.IsDead = false;
            

        }
        public static void copyCatRevive()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                //Spirit Cancel Exile
                if (player == CopyCat.Role)
                {
                    player.Revive();
                    player.Data.IsDead = false;
                    CopyCat.Role.Data.IsDead = false;
                }
                else if (player != CopyCat.Role)
                {
                    CopyCat.Role.Data.IsDead = false;
                }
            }
            CopyCat.Role.Data.IsDead = false;
           
        }
        //MAYOR
        public static void mayorBuzz()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                if (!Mayor.Role.Data.IsDead)
                {
                    MeetingRoomManager.Instance.reporter = Mayor.Role;
                    MeetingRoomManager.Instance.target = null;
                    DestroyableSingleton<HudManager>.Instance.OpenMeetingRoom(Mayor.Role);
                    Mayor.Role.RpcStartMeeting(null);
                    Mayor.BuzzUsed = true;
                    GLMod.GLMod.currentGame.addAction(Mayor.Role.Data.PlayerName, "", "buzz_used");
                }
                else
                {
                    MeetingRoomManager.Instance.reporter = CopyCat.Role;
                    MeetingRoomManager.Instance.target = null;
                    DestroyableSingleton<HudManager>.Instance.OpenMeetingRoom(CopyCat.Role);
                    CopyCat.Role.RpcStartMeeting(null);
                    Mayor.BuzzUsed = true;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "buzz_used");

                }
            }
        }
        //DETECTIVE
        public static void detectiveFindFPOn()
        {
            Detective.FindFP = true;
            if (!Detective.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Detective.Role.Data.PlayerName, "", "find_footprint");
            }
            if (Detective.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "find_footprint");
            }

        }
        public static void detectiveFindFPOff()
        {
            Detective.FindFP = false;
        }
        //NIGHTWATCH
        public static void nightwatchLightOn()
        {
            
            Nightwatch.LightBuff = true;
            
            if (!Nightwatch.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Nightwatch.Role.Data.PlayerName, "", "light_used");
            }
            if (Nightwatch.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "light_used");
            }
        }
        public static void nightwatchLightOff()
        {
            Nightwatch.LightBuff = false;
        }
        //SPY
        public static void spyOn()
        {
            if (PlayerControl.LocalPlayer == Spy.Role || PlayerControl.LocalPlayer == CopyCat.Role && Spy.Role.Data.IsDead && CopyCat.copyRole == 11 && CopyCat.CopyStart)
            {
                Camera.main.orthographicSize = Spy.Range;
                DestroyableSingleton<HudManager>.Instance.ShadowQuad.gameObject.SetActive(false);
                SoundManager.Instance.PlaySound(Used, false, 100f);
                PlayerControl.LocalPlayer.moveable = false;
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                Spy.Use = true;
            }
            else 
            { 
                Spy.Use = true;
            }
            
            if (!Spy.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Spy.Role.Data.PlayerName, "", "spy_used");
            }
            if (Spy.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "spy_used");
            }
        }
        public static void spyOff()
        {
            if (PlayerControl.LocalPlayer == Spy.Role || PlayerControl.LocalPlayer == CopyCat.Role && Spy.Role.Data.IsDead && CopyCat.copyRole == 11 && CopyCat.CopyStart)
            {
                Camera.main.orthographicSize = 3f;
                DestroyableSingleton<HudManager>.Instance.ShadowQuad.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead);
                SoundManager.Instance.PlaySound(Used, false, 100f);

                Spy.Use = false;
                Spy.SpyUsed = true;
                if (Challenger.LobbyTimeStop == true)
                {

                }
                else
                {
                    PlayerControl.LocalPlayer.moveable = true;
                    

                }

            }
            else
            {
                Spy.Use = false;
                Spy.SpyUsed = true;
            }

            

        }

        //INFORMANT
        public static void setInfoPlayer(byte infoId)
        {
            if (InforAnalyseMod.getSelection() != 2)
            {
                Informant.Used = true;
            }
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == infoId)
                {
                    Informant.Informed = player;
                    
                    if (!Informant.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(Informant.Role.Data.PlayerName, player.Data.PlayerName, "check_byinformant");
                    }
                    if (Informant.Role.Data.IsDead)
                    {
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "check_byinformant");
                    }

                }

            }

        }
        //MENTALIST
        public static void mentalistColorOn()
        {
            Mentalist.AdminVisibility = true;
            
            if (!Mentalist.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Mentalist.Role.Data.PlayerName, "", "admincolor_used");
            }
            if (Mentalist.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "admincolor_used");
            }
        }
        public static void mentalistColorOff()
        {
            Mentalist.AdminVisibility = false;
            Mentalist.AdminUsed = true;
        }
       
        //BUILDER

        public static void sealVent(int ventId)
        {
            Vent vent = ShipStatus.Instance.AllVents.FirstOrDefault((x) => x != null && x.Id == ventId);
            if (vent == null) return;


            if (PlayerControl.LocalPlayer == Builder.Role || PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 15 && CopyCat.CopyStart)
            {
                PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                animator?.Stop();
                vent.EnterVentAnim = vent.ExitVentAnim = null;
                vent.myRend.sprite = animator == null ? ChallengerMod.Unity.getStaticVentSealedSpriteuse() : ChallengerMod.Unity.getAnimatedVentSealedSpriteuse();
                //if (SubmergedCompatibility.IsSubmerged && vent.Id == 0) vent.myRend.sprite = SecurityGuard.getSubmergedCentralUpperSealedSprite();
                //if (SubmergedCompatibility.IsSubmerged && vent.Id == 14) vent.myRend.sprite = SecurityGuard.getSubmergedCentralLowerSealedSprite();
                vent.myRend.color = new Color(1f, 1f, 1f, 0.5f);
                vent.name = "LockedVent_" + vent.name;
            }
            
            if (!Builder.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Builder.Role.Data.PlayerName, "", "vent_sealed");
            }
            if (Builder.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "vent_sealed");
            }

            ventsToSeal.Add(vent);

        }
        //DICTATOR
        public static void dictatorNoSkipVote()
        {
            Dictator.HMActive = true;
            CopyCat.HMActive = true;
           
            if (!Dictator.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Dictator.Role.Data.PlayerName, "", "noskipvote_used");
            }
            if (Dictator.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "noskipvote_used");
            }
        }
        //SENTINEL
        public static void sentinelScanOn()
        {
           
                Sentinel.Scan = true;
            if (!Sentinel.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Sentinel.Role.Data.PlayerName, "", "scanmap_start");
            }
            if (Sentinel.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "scanmap_start");
            }
        }
        public static void sentinelScanOff()
        {
            
                Sentinel.Scan = false;
        }
        //LEADER
        public static void assignTarget1(byte target1Id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == target1Id)
                {
                    Leader.Target = player;
                    GLMod.GLMod.currentGame.addAction(Leader.Role.Data.PlayerName, player.Data.PlayerName, "leader_target");
                }
            }
        }
        public static void assignTarget2(byte target1Id)
        {
            Leader.Used2 = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == target1Id)
                {
                   Leader.Target2 = player;
                   GLMod.GLMod.currentGame.addAction(Leader.Role.Data.PlayerName, player.Data.PlayerName, "leader_target2");
                   GLMod.GLMod.currentGame.addAction("", "", "leader_start");
                }
            }
        }
        public static void assignCopyTarget1(byte target1Id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == target1Id)
                {
                    CopyCat.Target = player;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "leader_target");
                }
            }
        }
        public static void assignCopyTarget2(byte target1Id)
        {
            CopyCat.Used2 = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == target1Id)
                {
                    CopyCat.Target2 = player;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "leader_target2");
                    GLMod.GLMod.currentGame.addAction("", "", "leader_start");
                }
            }
        }

        //JESTER
        public static void jesterFakeKill()
        {
            if (PlayerControl.LocalPlayer.Data.IsDead)
            {

            }
            
            else
            {
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                SoundManager.Instance.PlaySound(jesterkill, false, 100f);
                HudManager.Instance.KillOverlay.ShowKillAnimation(PlayerControl.LocalPlayer.Data, PlayerControl.LocalPlayer.Data);
            }
            GLMod.GLMod.currentGame.addAction(Jester.Role.Data.PlayerName, "", "fakekill_used");

        }
        public static void jesterWin()
        {
            Jester.Exiled = true;
            SoundManager.Instance.PlaySound(JesterWinSound, false, 100f);
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                //Spirit Cancel Exile
                if (player == Jester.Role)
                {
                    player.Revive();
                    player.Data.IsDead = false;
                    Jester.Role.Data.IsDead = false;
                }
                else if (player != Jester.Role)
                {
                    Jester.Role.Data.IsDead = false;

                }
            }
            Jester.Role.Data.IsDead = false;
        }
        
        //EATER
        public static void cleanBody(byte playerId)
        {
            DeadBody[] array = UnityEngine.Object.FindObjectsOfType<DeadBody>();
            for (int i = 0; i < array.Length; i++)
            {
                if (GameData.Instance.GetPlayerById(array[i].ParentId).PlayerId == playerId)
                {
                    UnityEngine.Object.Destroy(array[i].gameObject);
                    ChallengerMod.Set.Data.EaterTask += 1;
                    new ChallengerOS.EaterMark(999f, Eater.Role);
                    GLMod.GLMod.currentGame.addAction(Eater.Role.Data.PlayerName, "", "player_eated");

                }
            }
        }

       //CUPID

        public static void loversExiled()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (Cupid.Lover1 != null && Cupid.Lover2 != null)
                {
                    if (player == Cupid.Lover1 || player == Cupid.Lover2)
                    {
                        if (Loverdie.getBool() == true)
                        {
                            player.Die(DeathReason.Exile);
                            Cupid.Lover1.Data.IsDead = true;
                            Cupid.Lover2.Data.IsDead = true;
                            


                        }
                        else
                        {
                            Cupid.Fail = true;
                        }

                    }
                }
            }
        }
        public static void killLover1()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Cupid.Lover1)
                {

                    Cupid.lover1Suicide = true;
                    Cupid.Lover1.MurderPlayer(Cupid.Lover1);
                   

                }
                Cupid.Lover1.Data.IsDead = true;
                Cupid.Lover2.Data.IsDead = true;
                Cupid.Fail = true;

            }
        }
        public static void killLover2()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Cupid.Lover1)
                {

                    Cupid.lover2Suicide = true;
                    Cupid.Lover2.MurderPlayer(Cupid.Lover2);
                    

                }
                Cupid.Lover1.Data.IsDead = true;
                Cupid.Lover2.Data.IsDead = true;
                Cupid.Fail = true;
            }
        }

        //CULTIST
        public static void setCulte1Player(byte culted1Id)
        {
            Cultist.Culte1Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == culted1Id)
                {
                    Cultist.Culte1 = player;
                    GLMod.GLMod.currentGame.addAction(Cultist.Role.Data.PlayerName, player.Data.PlayerName, "add_cultemember");

                }
            }
                    
            if (ChallengerOS.Utils.Option.CustomOptionHolder.CulteMember.getFloat() <= 1)
            {
                Cultist.CulteUsed = true;
            }
        }
        public static void setCulte2Player(byte culted2Id)
        {
            Cultist.Culte1Used = true;
            Cultist.Culte2Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == culted2Id)
                {
                    Cultist.Culte2 = player;
                    GLMod.GLMod.currentGame.addAction(Cultist.Role.Data.PlayerName, player.Data.PlayerName, "add_cultemember");
                }
            }
            
                    
            if (ChallengerOS.Utils.Option.CustomOptionHolder.CulteMember.getFloat() <= 2)
            {
                Cultist.CulteUsed = true;
            }
        }
        public static void setCulte3Player(byte culted3Id)
        {
            Cultist.Culte1Used = true;
            Cultist.Culte2Used = true;
            Cultist.Culte3Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == culted3Id)
                {
                    Cultist.Culte3 = player;
                    GLMod.GLMod.currentGame.addAction(Cultist.Role.Data.PlayerName, player.Data.PlayerName, "add_cultemember");

                }
            }
                
                 
            if (ChallengerOS.Utils.Option.CustomOptionHolder.CulteMember.getFloat() <= 3)
            {
                Cultist.CulteUsed = true;
            }
        }
        public static void cultistDie()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == Cultist.Role)
                {
                    if (PlayerControl.LocalPlayer == Cultist.Role)
                    {
                        Cultist.Die = true;
                    }
                    Cultist.Role.MurderPlayer(Cultist.Role);
                }
                Cultist.Role.Data.IsDead = true;
                
                Cultist.Suicide = true;

            }
        }

        //EATER
        public static void draggBody(int Get)
        {
            var body = ChallengerOS.Utils.Helpers.GetDeadBody(Get);
            if (body != null)
            {
                ChallengerMod.Challenger.draggers.Add(Eater.Role.PlayerId);
                ChallengerMod.Challenger.corpse.Add(body.ParentId);
                MoveBody(body.ParentId);
            }
        }
        public static void dropBody(int Get)
        {
            ChallengerMod.Challenger.corpse.Remove(ChallengerMod.Challenger.corpse[ChallengerMod.Challenger.draggers.IndexOf(Eater.Role.PlayerId)]);
            ChallengerMod.Challenger.draggers.Remove(Eater.Role.PlayerId);
        }
        public static void MoveBody(int bodyid)
        {
            if (Eater.Role.transform == null) return;
            if (draggers.Contains(Eater.Role.PlayerId))
            {
                var body = ChallengerOS.Utils.Helpers.GetDeadBody(bodyid);
                if (body == null) return;
                if (!Eater.Role.inVent)
                {
                    var pos = Eater.Role.transform.position;
                    pos.Set(pos.x, pos.y, pos.z + .001f);
                    body.transform.position = (Vector3.Lerp(ChallengerOS.Utils.Helpers.GetDeadBody(corpse[(draggers.IndexOf(Eater.Role.PlayerId))]).transform.position, pos, Time.deltaTime + 0.05f));
                }
                else
                    body.transform.position = (Eater.Role.transform.position);
                return;
            }
        }


        //COPYCAT
        public static void setCopyPlayer(byte TargerID, int CopyID)
        {
            CopyCat.CopyUsed = true;
            CopyCat.copyRole = CopyID;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == TargerID)
                {
                    CopyCat.CopiedPlayer = player;
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "try_copyplayer");

                }
            }
               
                    

        }
        public static void copyCatDie()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player == CopyCat.Role)
                {
                    CopyCat.Role.MurderPlayer(CopyCat.Role);
                }
                CopyCat.Role.Data.IsDead = true;
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "copycat_failandsuicide");

            }
        }
        public static void copyCatKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == CopyCat.Role.PlayerId)

                {
                    if (CopyCat.Role.Data.Role.IsImpostor)
                    {
                        CopyCat.SuicideShield = true;
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "suicide_byshield");
                    }
                    if (!CopyCat.Role.Data.Role.IsImpostor)
                    {
                        CopyCat.Suicide = true;
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "suicide_sheriff");
                    }
                        
                }
                if (player.PlayerId == targetId)
                {

                    CopyCat.Role.MurderPlayer(player);
                    CopyCat.Role.transform.position = player.transform.position;
                    if (CopyCat.Role.Data.Role.IsImpostor)
                    {
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "kill");
                    }
                    if (!CopyCat.Role.Data.Role.IsImpostor)
                    {
                        GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, player.Data.PlayerName, "kill_sheriff");
                    }


                    return;
                }
            }
        }
        //OUTLAW
        public static void outlawKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {

                if (targetId == Outlaw.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Outlaw.Role.Data.PlayerName, "", "suicide_byshield");
                    Outlaw.SuicideShield = true;

                }
                if (player.PlayerId == targetId)
                {
                    Outlaw.Role.MurderPlayer(player);
                    Outlaw.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Outlaw.Role.Data.PlayerName, player.Data.PlayerName, "kill_outlaw");

                    return;
                }
            }
        }

        //ARSONIST
        public static void arsonistWin()
        {

            ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 200f / 255f, 0f / 255f), 1f);
            SoundManager.Instance.PlaySound(Burned, false, 100f);
            Arsonist.Win = true;
            GLMod.GLMod.currentGame.addAction(Arsonist.Role.Data.PlayerName, "", "burn_allplayer");
            if (!PlayerControl.LocalPlayer.Data.IsDead)
            {
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                PlayerControl.LocalPlayer.moveable = false;
            }
            

        }
        public static void arsonistAddOil(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == targetId)
                {
                    Arsonist.Oiled = player;
                    GLMod.GLMod.currentGame.addAction(Arsonist.Role.Data.PlayerName, player.Data.PlayerName, "oil_player");

                    if (!OiledPlayers.Contains(player))
                    {
                        OiledPlayers.Add(player);
                    }
                }
            }
        }
        //CURSE
        public static void cursedWin()
        {

            ChallengerOS.Utils.Helpers.showFlash(new Color(50f / 255f, 150f / 255f, 50f / 255f), 1f);
            SoundManager.Instance.PlaySound(PoisonClip, false, 100f);
            Cursed.Win = true;
            GLMod.GLMod.currentGame.addAction(Cursed.Role.Data.PlayerName, "", "fullcurse");
            
            if (!PlayerControl.LocalPlayer.Data.IsDead)
            {
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                PlayerControl.LocalPlayer.moveable = false;
            }


        }
        public static void curseSync(int percentValue)
        {
            Cursed.CursePercent = percentValue;
        }

        //MERCENARY
        public static void mercenaryKill(byte targetId)
        {
            if (!Mercenary.Role.Data.Role.IsImpostor)
            {
                GLMod.GLMod.currentGame.addAction(Mercenary.Role.Data.PlayerName, "", "mercenary_impostor");
            }
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Mercenary.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Mercenary.Role.Data.PlayerName, "", "suicide_byshield");
                    Mercenary.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Mercenary.Role.MurderPlayer(player);
                    Mercenary.Role.transform.position = player.transform.position;
                    Mercenary.Temp = true;
                    Mercenary.isImpostor = true;
                    GLMod.GLMod.currentGame.addAction(Mercenary.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void mercenaryTryKill()
        {
            
            if (!Mercenary.Role.Data.Role.IsImpostor)
            {
                GLMod.GLMod.currentGame.addAction(Mercenary.Role.Data.PlayerName, "", "mercenary_impostor");
                GLMod.GLMod.currentGame.addAction(Mercenary.Role.Data.PlayerName, "", "fail_kill");
            }
            Mercenary.Temp = true;
            Mercenary.isImpostor = true;


        }
        //REVENGER

        public static void setEMP1Player(byte EMP1Id)
        {
            Revenger.EMP1_Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == EMP1Id)
                {
                    Revenger.EMP1 = player;
                    GLMod.GLMod.currentGame.addAction(Revenger.Role.Data.PlayerName, player.Data.PlayerName, "emp_target");
                }
            }
                
                    
        }
        public static void setEMP2Player(byte EMP2Id)
        {
            Revenger.EMP2_Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == EMP2Id)
                {
                    Revenger.EMP2 = player;
                    GLMod.GLMod.currentGame.addAction(Revenger.Role.Data.PlayerName, player.Data.PlayerName, "emp_target");
                }
                   
            }
                

        }
        public static void setEMP3Player(byte EMP3Id)
        {
            Revenger.EMP3_Used = true;
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == EMP3Id)
                {
                    Revenger.EMP3 = player;
                    GLMod.GLMod.currentGame.addAction(Revenger.Role.Data.PlayerName, player.Data.PlayerName, "emp_target");
                }
            }
           
                    

        }
        public static void sabAdmin()
        {
            Sorcerer.AdminSab = true;
            GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "destroy_admin");

        }

        //SORCERER

        public static void setScan1Player(byte Scan1Id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {

                if (player.PlayerId == Scan1Id)
                { 
                    Sorcerer.Scan1 = player;
                    GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, player.Data.PlayerName, "getrole_player");

                }
            }
                    
        }
        public static void setScan2Player(byte Scan2Id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {

                if (player.PlayerId == Scan2Id)
                {
                    Sorcerer.Scan2 = player;
                    GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, player.Data.PlayerName, "getrole_player");


                }
            }
                   
        }
        public static void setExtPlayer(byte Scan3Id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == Scan3Id)
                {
                    Sorcerer.Exterminated = player;
                    GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, player.Data.PlayerName, "destroy_player");
                }
            }
                
                    
        }

        //VECTOR
        public static void setInfectePlayer(byte InfectId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == InfectId)
                {
                    Vector.Infected = player;
                    GLMod.GLMod.currentGame.addAction(Vector.Role.Data.PlayerName, player.Data.PlayerName, "infect");

                }

            }
               
        }
        public static void createVent(byte[] buff)
        {
            Vector3 position = Vector3.zero;
            position.x = BitConverter.ToSingle(buff, 0 * sizeof(float));
            position.y = BitConverter.ToSingle(buff, 1 * sizeof(float));
            new BarghestVentObject(position);
            GLMod.GLMod.currentGame.addAction(Barghest.Role.Data.PlayerName, "", "vent_create");
        }
        public static void killInfected()
        {
            GLMod.GLMod.currentGame.addAction(Vector.Role.Data.PlayerName, Vector.Infected.Data.PlayerName, "kill_infected");

            if (PlayerControl.LocalPlayer == Vector.Infected)
            {
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                Vector.Role.MurderPlayer(Vector.Infected);
                SoundManager.Instance.PlaySound(agony, false, 100f);
                
                if (!Challenger.Vectorkill.Contains(Vector.Infected))
                {
                    Challenger.Vectorkill.Add(Vector.Infected);
                }

            }
            else
            {
                 Vector.Infected.MurderPlayer(Vector.Infected);
                 SoundManager.Instance.PlaySound(agony, false, 100f);
               
                if (!Challenger.Vectorkill.Contains(Vector.Infected))
                {
                    Challenger.Vectorkill.Add(Vector.Infected);
                }
            }
           


            if (Bait.Role != null && Bait.Role.PlayerId == Vector.Infected.PlayerId)
            {
                Vector.KillBait = true;
            }
        }
        //MORPHLING

        public static void setMorphPlayer(byte ScanId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == ScanId)
                {
                    Morphling.Morph = player;
                    GLMod.GLMod.currentGame.addAction(Morphling.Role.Data.PlayerName, player.Data.PlayerName, "setmorph");

                }

            }
                
        }
        public static void morphOn()
        {
            Morphling.Morphed = true;
            GLMod.GLMod.currentGame.addAction(Morphling.Role.Data.PlayerName, Morphling.Morph.Data.PlayerName, "morph_toplayer");

            if (ComSab && StartComSabUnk)
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToScrambler, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToCom, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                }
            }
            if (!ComSab || (ComSab && !StartComSabUnk))
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToScrambler, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(Morphling.Morph.Data.PlayerName, Morphling.Morph.Data.DefaultOutfit.ColorId, Morphling.Morph.Data.DefaultOutfit.HatId, Morphling.Morph.Data.DefaultOutfit.VisorId, Morphling.Morph.Data.DefaultOutfit.SkinId, Morphling.Morph.Data.DefaultOutfit.PetId);
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
            }
        }
        public static void morphOff()
        {
            Morphling.Morphed = false;

            if (ComSab && StartComSabUnk)
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToScrambler, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToCom, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                }
            }
            if (!ComSab || (ComSab && !StartComSabUnk))
            {
                if (Scrambler.Role != null && Scrambler.Camo)
                {
                    Morphling.Role.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToScrambler, "", "", "", "");
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
                else
                {
                    Morphling.Role.setDefaultLook();
                    Morphling.Role.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                }
            }
        }
        //SCRAMBLER
        public static void camoOn()
        {
            Scrambler.Camo = true;
            SoundManager.Instance.PlaySound(ScramblerOn, false, 100f);

            GLMod.GLMod.currentGame.addAction(Scrambler.Role.Data.PlayerName, "", "camo_used");

            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                    players.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToScrambler, "", "", "", "");
                }
            }
        }
        public static void camoOff()
        {
            Scrambler.Camo = false;
            SoundManager.Instance.PlaySound(ScramblerOff, false, 100f);
            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
            {
                if (ComSab && CommsSabotageAnonymous.getSelection() == 1)
                {
                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                    players.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToCom, "", "", "", "");
                }
                else
                {
                    if (Morphling.Role != null && Morphling.Morph != null && players.PlayerId == Morphling.Role.PlayerId && Morphling.Morphed)
                    {
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                        players.setLook(Morphling.Morph.Data.PlayerName, Morphling.Morph.Data.DefaultOutfit.ColorId, Morphling.Morph.Data.DefaultOutfit.HatId, Morphling.Morph.Data.DefaultOutfit.VisorId, Morphling.Morph.Data.DefaultOutfit.SkinId, Morphling.Morph.Data.DefaultOutfit.PetId);
                    }
                    else
                    {
                        players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                        players.setDefaultLook();
                    }
                }
            }
        }
        //BARGHEST

        
        public static void shadowOn()
        {
            GLMod.GLMod.currentGame.addAction(Barghest.Role.Data.PlayerName, "", "shadow_start");
            if (!Timelord.TimeStopped)
            {
                HudManager.Instance.FullScreen.gameObject.SetActive(true);
                HudManager.Instance.FullScreen.enabled = true;
                HudManager.Instance.FullScreen.color = new Color(0.2f, 0.2f, 0.4f, 0.3f);
            }
            
            PlayerControl.LocalPlayer.MyPhysics.Speed = 1.85f;
            SoundManager.Instance.PlaySound(Used, false, 100f);
            SoundManager.Instance.PlaySound(Shadow, true, 100f);
            Barghest.Shadow = true;

            if (Barghest.Role != null && PlayerControl.LocalPlayer == Barghest.Role)
            {

            }
            else
            {
                if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    if (BarghestAffectImpostor.getBool() == true || ImpostorsKnowEachother.getBool() == true)
                    {
                        Challenger.LobbyLightOff = true;
                    }
                    else
                    {
                        Challenger.LobbyLightOff = false;
                    }
                }
                else
                {
                    Challenger.LobbyLightOff = true;
                }
            }

           

        }
        public static void shadowOff()
        {
            if (Timelord.TimeStopped)
            {
                HudManager.Instance.FullScreen.gameObject.SetActive(true);
                HudManager.Instance.FullScreen.enabled = true;
                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0.8f, 0.3f);
            }
            else
            {
                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0f);
            }

            SoundManager.Instance.PlaySound(Used, false, 100f);
            PlayerControl.LocalPlayer.MyPhysics.Speed = 2.5f;
            Challenger.LobbyLightOff = false;
            SoundManager.Instance.StopSound(Shadow);
            Barghest.Shadow = false;

        }
        //GHOST
        public static void ghostOn()
        {
            Ghost.Hide = true;
            Ghost.Role.Visible = false;
            GLMod.GLMod.currentGame.addAction(Ghost.Role.Data.PlayerName, "", "invisibility_used");
        }
        public static void ghostOff()
        {
            Ghost.Hide = false;
            Ghost.Role.Visible = true;
        }
        //SORCERER
        public static void war1()
        {
            Sorcerer.TotalRuneLoot = 1;
            GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "rune1");
        }
        public static void war2()
        {
            Sorcerer.TotalRuneLoot = 2f;
            GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "rune2");
        }
        public static void war3()
        {
            Sorcerer.TotalRuneLoot = 3f;
            GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "rune3");
        }
        public static void war4()
        {
            Sorcerer.TotalRuneLoot = 4f;
            GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "rune4");
        }
        

        public static void setPetrifyPlayer(byte petrifyId)
        {
            Basilisk.Used = true;
            Basilisk.PetrifyCount -= Basilisk.CostParalize;
            Basilisk.PetrifyAndShield = false;

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == petrifyId)
                {
                    Basilisk.Petrified = player;
                    GLMod.GLMod.currentGame.addAction(Basilisk.Role.Data.PlayerName, player.Data.PlayerName, "Petrify");
                    
                    if (!Petrifiedplayers.Contains(player))
                    {
                        Petrifiedplayers.Add(player);
                    }

                }
            }
        }
        public static void setPetrifyAndShieldPlayer(byte petrifyId)
        {
            Basilisk.Used = true;
            Basilisk.PetrifyCount -= Basilisk.CostPetrify;
            Basilisk.PetrifyAndShield = true;

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.PlayerId == petrifyId)
                {
                    Basilisk.Petrified = player;
                    GLMod.GLMod.currentGame.addAction(Basilisk.Role.Data.PlayerName, player.Data.PlayerName, "Super_Petrify");

                    if (!Petrifiedplayers.Contains(player))
                    {
                        Petrifiedplayers.Add(player);
                    }

                }
                
            }
        }


        //IMPOSTORS NORMAL KILL

        public static void vectorKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Vector.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Vector.Role.Data.PlayerName, "", "suicide_byshield");
                    Vector.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Vector.Role.MurderPlayer(player);
                    Vector.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Vector.Role.Data.PlayerName, player.Data.PlayerName, "kill");
                    return;
                }
            }
        }
        public static void impostor1Kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Impostor1.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Impostor1.Role.Data.PlayerName, "", "suicide_byshield");
                    Impostor1.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Impostor1.Role.MurderPlayer(player);
                    Impostor1.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Impostor1.Role.Data.PlayerName, player.Data.PlayerName, "kill");
                    return;
                }
            }
        }
        public static void impostor2Kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Impostor2.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Impostor2.Role.Data.PlayerName, "", "suicide_byshield");
                    Impostor2.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Impostor2.Role.MurderPlayer(player);
                    Impostor2.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Impostor2.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void impostor3Kill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Impostor3.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Impostor3.Role.Data.PlayerName, "", "suicide_byshield");
                    Impostor3.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Impostor3.Role.MurderPlayer(player);
                    Impostor3.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Impostor3.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void morphlingKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Morphling.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Morphling.Role.Data.PlayerName, "", "suicide_byshield");
                    Morphling.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Morphling.Role.MurderPlayer(player);
                    Morphling.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Morphling.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void scramblerKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Scrambler.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Scrambler.Role.Data.PlayerName, "", "suicide_byshield");
                    Scrambler.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Scrambler.Role.MurderPlayer(player);
                    Scrambler.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Scrambler.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void barghestKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Barghest.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Barghest.Role.Data.PlayerName, "", "suicide_byshield");
                    Barghest.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Barghest.Role.MurderPlayer(player);
                    Barghest.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Barghest.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void ghostKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Ghost.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Ghost.Role.Data.PlayerName, "", "suicide_byshield");
                    Ghost.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Ghost.Role.MurderPlayer(player);
                    Ghost.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Ghost.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void sorcererKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Sorcerer.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, "", "suicide_byshield");
                    Sorcerer.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Sorcerer.Role.MurderPlayer(player);
                    Sorcerer.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Sorcerer.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void guesserKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Guesser.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Guesser.Role.Data.PlayerName, "", "suicide_byshield");
                    Guesser.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Guesser.Role.MurderPlayer(player);
                    Guesser.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Guesser.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void basiliskKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Basilisk.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Basilisk.Role.Data.PlayerName, "", "suicide_byshield");
                    Basilisk.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Basilisk.Role.MurderPlayer(player);
                    Basilisk.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Basilisk.Role.Data.PlayerName, player.Data.PlayerName, "kill");
                    Basilisk.PetrifyCount += Basilisk.DoseKill;

                    return;
                }
            }
        }
        public static void reaperKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Reaper.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Reaper.Role.Data.PlayerName, "", "suicide_byshield");
                    Reaper.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Reaper.Role.MurderPlayer(player);
                    Reaper.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Reaper.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void saboteurKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Saboteur.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Saboteur.Role.Data.PlayerName, "", "suicide_byshield");
                    Saboteur.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Saboteur.Role.MurderPlayer(player);
                    Saboteur.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Saboteur.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void assassinKill(byte targetId)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (targetId == Assassin.Role.PlayerId)
                {
                    GLMod.GLMod.currentGame.addAction(Assassin.Role.Data.PlayerName, "", "suicide_byshield");
                    Assassin.SuicideShield = true;
                }
                if (player.PlayerId == targetId)
                {
                    Assassin.Role.MurderPlayer(player);
                    Assassin.Role.transform.position = player.transform.position;
                    GLMod.GLMod.currentGame.addAction(Assassin.Role.Data.PlayerName, player.Data.PlayerName, "kill");

                    return;
                }
            }
        }
        public static void assassinShield()
        {
            Assassin.Shielded = true;
            Assassin.StealShield = false;
            GLMod.GLMod.currentGame.addAction(Assassin.Role.Data.PlayerName, "", "assassin_shielded");

            return;
        }
        public static void baitbalise(byte[] buff)
        {
            Vector3 position = Vector3.zero;
            position.x = BitConverter.ToSingle(buff, 0 * sizeof(float));
            position.y = BitConverter.ToSingle(buff, 1 * sizeof(float));
            new Balise(position);
            if (Bait.Role != null && !Bait.Role.Data.IsDead)
            {
                GLMod.GLMod.currentGame.addAction(Bait.Role.Data.PlayerName, "", "create_bait_area");
            }
            else
            {
                if (CopyCat.Role != null)
                {
                    GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, "", "create_bait_area");
                }
            }
            Bait.BaliseData = true;


        }
        public static void baitBaliseEnable(float posX, float posY)
        {
            Bait.BaliseEnable = true;
            GLMod.GLMod.currentGame.addAction("", "", "bait_area");
            ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 0f / 255f, 0f / 255f), 2f);
            SoundManager.Instance.PlaySound(BaitAlerte, false, 100f);
            Bait.BaliseData = true;
           
            int arrowIndex = 0;

            arrowIndex = Challenger.localArrows.Count;
            Challenger.localArrows.Add(new Arrow(Color.red));
            Vector3 pos = new Vector3(posX, posY, 1f);

            if (Challenger.localArrows[arrowIndex] != null)
            {
                Challenger.localArrows[arrowIndex].arrow.SetActive(true);
                Challenger.localArrows[arrowIndex].Update(pos, Color.red);
            }

        }
        public static void shareDronePosition(float posX, float posY, byte DroneControllerID)
        {

            if (Challenger.DroneController == null)
            {
                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    if (player.PlayerId == DroneControllerID)
                    {
                        Challenger.DroneController = player;
                    }

                }
            }

            Vector3 pos = new Vector3(posX, posY, -15f);

            if (Challenger.DroneController != null && PlayerControl.LocalPlayer != Challenger.DroneController)
            {
                if (GameObject.Find("Drone_SurvCamera"))
                {
                    GameObject SurvDrone = GameObject.Find("Drone_SurvCamera");
                    if (SurvDrone.transform.position != pos)
                    { SurvDrone.transform.position = pos; }
                }
            }

            

        }
        public static void stopDrone()
        {

            if (Challenger.DroneController != null)
            {
                Challenger.DroneController = null;
            }
        }

    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.HandleRpc))]
    class HandleRpcPatch
    {
        static void Postfix([HarmonyArgument(0)] byte callId, [HarmonyArgument(1)] MessageReader reader)
        {
            byte packetId = callId;
            switch (packetId)
            {

                // Main Controls
                
        
                
                case (byte)CustomRPC.SetVisorColor:
                    {
                        byte PlayerID = reader.ReadByte();
                        int ColorID = reader.ReadPackedInt32();
                        RPCProcedure.setVisorColor(PlayerID, ColorID);
                        break;
                    }
                case (byte)CustomRPC.ShareAllRoles:
                    {
                        RPCProcedure.shareAllRoles();
                        break;
                    }
                case (byte)CustomRPC.ShareNewPLayerSlot:
                    {
                        int Value = reader.ReadPackedInt32();
                        RPCProcedure.shareNewPLayerSlot(Value);
                        break;
                    }
                case (byte)CustomRPC.ShareNewMapID:
                    {
                        byte ID = reader.ReadByte();
                        RPCProcedure.shareNewMapID(ID);
                        break;
                    }
                //NUCLEAR
                case (byte)CustomRPC.SyncTimer:
                    {
                        float TimerSyncro = reader.ReadSingle();
                        RPCProcedure.syncTimer(TimerSyncro);
                        break;
                    }
                case (byte)CustomRPC.SyncMap:
                    {
                        RPCProcedure.syncMap();
                        break;
                    }
                case (byte)CustomRPC.SyncDie:
                    {
                        byte Player = reader.ReadByte();
                        RPCProcedure.syncDie(Player);
                        break;
                    }
                case (byte)CustomRPC.SyncEmergency:
                    {
                        int Emergency = reader.ReadPackedInt32();
                        RPCProcedure.syncEmergency(Emergency);
                        break;
                    }
                case (byte)CustomRPC.RemoveAllBodies:
                    var buggedBodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
                    foreach (var body in buggedBodies)
                        body.gameObject.Destroy();
                    break;
                
                
                
                case (byte)CustomRPC.SetLocalPlayers:
                    localPlayers.Clear();
                    localPlayer = PlayerControl.LocalPlayer;
                    var localPlayerBytes = reader.ReadBytesAndSize();

                    foreach (byte id in localPlayerBytes)
                    {
                        foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                        {
                            if (player.PlayerId == id) { localPlayers.Add(player); }
                        }
                    }
                    break;

                case (byte)CustomRPC.SetRole:
                    byte roleId = reader.ReadByte();
                    byte playerId = reader.ReadByte();
                    RPCProcedure.setRole(roleId, playerId);
                    break;

                   
                //WINNER
                case (byte)CustomRPC.SetWinLove:
                    {
                        RPCProcedure.setWinLove();
                        break;
                    }
                case (byte)CustomRPC.SetLooseLove:
                    {
                        RPCProcedure.setlooseLove();
                        break;
                    }
                case (byte)CustomRPC.SetWinCrewmatesByTask:
                    {
                        RPCProcedure.setWinCrewmatesByTask();
                        break;
                    }
                case (byte)CustomRPC.SetWinCrewmatesByKill:
                    {
                        RPCProcedure.setWinCrewmatesByKill();
                        break;
                    }
                case (byte)CustomRPC.SetWinImpostorsByKill:
                    {
                        RPCProcedure.setWinImpostorByKill();
                        break;
                    }
                case (byte)CustomRPC.SetWinImpostorsBySab:
                    {
                        RPCProcedure.setWinImpostorBySab();
                        break;
                    }
                case (byte)CustomRPC.SetWinJester:
                    {
                        RPCProcedure.setWinJester();
                        break;
                    }
                case (byte)CustomRPC.SetWinEater:
                    {
                        RPCProcedure.setWinEater();
                        break;
                    }
                case (byte)CustomRPC.SetWinOutlaw:
                    {
                        RPCProcedure.setWinOutlaw();
                        break;
                    }
                case (byte)CustomRPC.SetWinArsonist:
                    {
                        RPCProcedure.setWinArsonist();
                        break;
                    }
                case (byte)CustomRPC.SetWinCulte:
                    {
                        RPCProcedure.setWinCulte();
                        break;
                    }
                case (byte)CustomRPC.SetWinCursed:
                    {
                        RPCProcedure.setWinCursed();
                        break;
                    }

                //ITEMS
                case (byte)CustomRPC.SpawnItem:
                    var itemId = reader.ReadInt32();
                    var itemPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle());
                    var velocity = new Vector3(reader.ReadSingle(), reader.ReadSingle());
                    ChallengerMod.HarmonyMain.Instance.SpawnItem(itemId, itemPosition, velocity);
                    break;
                case (byte)CustomRPC.DestroyItem:
                    if (!AmongUsClient.Instance.AmHost)
                    {
                        var targetItemId = reader.ReadInt32();
                        List<_MapItems> allMatches = ChallengerMod.HarmonyMain.Instance.AllItems.FindAll(x => x.Id == targetItemId);
                        foreach (_MapItems item in allMatches)
                            item.Delete();
                        ChallengerMod.HarmonyMain.Instance.AllItems.RemoveAll(x => x.IsPickedUp);

                    }
                    break;


                //SHERIFF
                case (byte)CustomRPC.Sheriff1Kill:
                    {
                        RPCProcedure.sheriff1kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Sheriff2Kill:
                    {
                        RPCProcedure.sheriff2kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Sheriff3Kill:
                    {
                        RPCProcedure.sheriff3kill(reader.ReadByte());
                        break;
                    }

                //GUARDIAN
                
                case (byte)CustomRPC.SetProtectedPlayer:
                    {
                        RPCProcedure.setProtectedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetProtectedMystic:
                    {
                        RPCProcedure.setProtectedMystic(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetProtectedCopyMystic:
                    {
                        RPCProcedure.setProtectedCopyMystic();
                        break;
                    }
                //ENGINEER
                case (byte)CustomRPC.EngineerRepair:
                    {
                        RPCProcedure.engineerRepair();
                        break;
                    }
                case (byte)CustomRPC.EngineerFixLight:
                    {
                        RPCProcedure.engineerFixLight();
                        break;
                    }
                case (byte)CustomRPC.TimeStop_Start:
                    {
                        RPCProcedure.timeStop_Start(reader.ReadInt32());
                        break;
                    }
                case (byte)CustomRPC.TimeStop_End:
                    {
                        RPCProcedure.timeStop_End();
                        break;
                    }
                //HUNTER
                case (byte)CustomRPC.SetTrackedPlayer:
                    {
                        RPCProcedure.setTrackedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.HunterTrackedDie:
                    {
                        RPCProcedure.hunterTrackedDie();
                        break;
                    }

                case (byte)CustomRPC.HunterTrackedKill:
                    {
                        RPCProcedure.hunterTrackedKill();
                        break;
                    }
                case (byte)CustomRPC.SetCopyTrackedPlayer:
                    {
                        RPCProcedure.setCopyTrackedPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.HunterCopyTrackedDie:
                    {
                        RPCProcedure.hunterCopyTrackedDie();
                        break;
                    }

                case (byte)CustomRPC.HunterCopyTrackedKill:
                    {
                        RPCProcedure.hunterCopyTrackedKill();
                        break;
                    }
                //MYSTIC
                case (byte)CustomRPC.MysticShieldOn:
                    {
                        RPCProcedure.mysticShieldOn();
                        break;
                    }
                case (byte)CustomRPC.MysticShieldOff:
                    {
                        RPCProcedure.mysticShieldOff();
                        break;
                    }

                //SPIRIT
                case (byte)CustomRPC.SpiritRevive:
                    {
                        RPCProcedure.spiritRevive();
                        break;
                    }
                case (byte)CustomRPC.CopyCatRevive:
                    {
                        RPCProcedure.copyCatRevive();
                        break;
                    }
                //MAYOR
                case (byte)CustomRPC.MayorBuzz:
                    {
                        RPCProcedure.mayorBuzz();
                        break;
                    }
                //DETECTIVE
                case (byte)CustomRPC.DetectiveFindFPOn:
                    {
                        RPCProcedure.detectiveFindFPOn();
                        break;
                    }
                case (byte)CustomRPC.DetectiveFindFPOff:
                    {
                        RPCProcedure.detectiveFindFPOff();
                        break;
                    }
                //NIGHTWATCH
                case (byte)CustomRPC.NightwatchLightOn:
                    {
                        RPCProcedure.nightwatchLightOn();
                        break;
                    }
                case (byte)CustomRPC.NightwatchLightOff:
                    {
                        RPCProcedure.nightwatchLightOff();
                        break;
                    }
                //SPY
                case (byte)CustomRPC.SpyOn:
                    {
                        RPCProcedure.spyOn();
                        break;
                    }
                case (byte)CustomRPC.SpyOff:
                    {
                        RPCProcedure.spyOff();
                        break;
                    }
                //INFORMANT
                case (byte)CustomRPC.SetInfoPlayer:
                    {
                        RPCProcedure.setInfoPlayer(reader.ReadByte());
                        break;
                    }
                //MENTALIST
                case (byte)CustomRPC.MentalistColorOn:
                    {
                        RPCProcedure.mentalistColorOn();
                        break;
                    }
                case (byte)CustomRPC.MentalistColorOff:
                    {
                        RPCProcedure.mentalistColorOff();
                        break;
                    }
               

                //BUILDER
                case (byte)CustomRPC.SealVent:
                    RPCProcedure.sealVent(reader.ReadPackedInt32());
                    break;

                //DICTATOR
                case (byte)CustomRPC.DictatorNoSkipVote:
                    {
                        RPCProcedure.dictatorNoSkipVote();
                        break;
                    }


                //SENTINEL
                case (byte)CustomRPC.SentinelScanOn:
                    {
                        RPCProcedure.sentinelScanOn();
                        break;
                    }
                case (byte)CustomRPC.SentinelScanOff:
                    {
                        RPCProcedure.sentinelScanOff();
                        break;
                    }
                //LEADER
                case (byte)CustomRPC.AssignTarget1:
                    {
                        RPCProcedure.assignTarget1(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.AssignTarget2:
                    {
                        RPCProcedure.assignTarget2(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.AssignCopyTarget1:
                    {
                        RPCProcedure.assignCopyTarget1(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.AssignCopyTarget2:
                    {
                        RPCProcedure.assignCopyTarget2(reader.ReadByte());
                        break;
                    }

                //JESTER
                case (byte)CustomRPC.JesterFakeKill:
                    {
                        RPCProcedure.jesterFakeKill();
                        break;
                    }
                case (byte)CustomRPC.JesterWin:
                    {
                        RPCProcedure.jesterWin();
                        break;
                    }
                
                //EATER
                case (byte)CustomRPC.CleanBody:
                    {
                        RPCProcedure.cleanBody(reader.ReadByte());
                        break;
                    }
                //CUPID
               
                case (byte)CustomRPC.LoversExiled:
                    {
                        RPCProcedure.loversExiled();
                        break;
                    }
                case (byte)CustomRPC.KillLover1:
                    {
                        RPCProcedure.killLover1();
                        break;
                    }
                case (byte)CustomRPC.KillLover2:
                    {
                        RPCProcedure.killLover2();
                        break;
                    }
                //CULTIST
                case (byte)CustomRPC.SetCulte1Player:
                    {
                        RPCProcedure.setCulte1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetCulte2Player:
                    {
                        RPCProcedure.setCulte2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetCulte3Player:
                    {
                        RPCProcedure.setCulte3Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.CultistDie:
                    {
                        RPCProcedure.cultistDie();
                        break;
                    }
                //Eater
                case (byte)CustomRPC.DraggBody:
                    {
                        RPCProcedure.draggBody(reader.ReadPackedInt32());

                        break;
                    } 
                case (byte)CustomRPC.DropBody:
                    {
                        RPCProcedure.dropBody(reader.ReadPackedInt32());
                        break;
                    }


                //OUTLAW
                case (byte)CustomRPC.OutlawKill:
                    {
                        RPCProcedure.outlawKill(reader.ReadByte());
                        break;
                    }
                //ARSONIST
                case (byte)CustomRPC.ArsonistWin:
                    {
                        RPCProcedure.arsonistWin();
                        break;
                    }
                case (byte)CustomRPC.ArsonistAddOil:
                    {
                        RPCProcedure.arsonistAddOil(reader.ReadByte());
                        break;
                    }
                //CURSED
                case (byte)CustomRPC.CursedWin:
                    {
                        RPCProcedure.cursedWin();
                        break;
                    }
                case (byte)CustomRPC.CurseSync:
                    RPCProcedure.curseSync(reader.ReadPackedInt32());
                    break;

                //MERCENARY
                case (byte)CustomRPC.MercenaryKill:
                    {
                        RPCProcedure.mercenaryKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MercenaryTryKill:
                    {
                        RPCProcedure.mercenaryTryKill();
                        break;
                    }
                //COPYCAT
                case (byte)CustomRPC.SetCopyPlayer:
                    {
                        byte copyPlayer = reader.ReadByte();
                        int copyID = reader.ReadInt32();
                        RPCProcedure.setCopyPlayer(copyPlayer, copyID);
                        break;
                    }
                case (byte)CustomRPC.CopyCatDie:
                    {
                        RPCProcedure.copyCatDie();
                        break;
                    }
                case (byte)CustomRPC.CopyCatKill:
                    {
                        RPCProcedure.copyCatKill(reader.ReadByte());
                        break;
                    }

                //REVENGER
                case (byte)CustomRPC.SetEMP1Player:
                    {
                        RPCProcedure.setEMP1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetEMP2Player:
                    {
                        RPCProcedure.setEMP2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetEMP3Player:
                    {
                        RPCProcedure.setEMP3Player(reader.ReadByte());
                        break;
                    }
                //SORCERER
                case (byte)CustomRPC.SetScan1Player:
                    {
                        RPCProcedure.setScan1Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetScan2Player:
                    {
                        RPCProcedure.setScan2Player(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetExtPlayer:
                    {
                        RPCProcedure.setExtPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SabAdmin:
                    {
                        RPCProcedure.sabAdmin();
                        break;
                    }

                //VECTOR
                case (byte)CustomRPC.SetInfectePlayer:
                    {
                        RPCProcedure.setInfectePlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.KillInfected:
                    {
                        RPCProcedure.killInfected();
                        break;
                    }
                    
                //MORPHLING
                case (byte)CustomRPC.SetMorphPlayer:
                    {
                        RPCProcedure.setMorphPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MorphOn:
                    {
                        RPCProcedure.morphOn();
                        break;
                    }
                case (byte)CustomRPC.MorphOff:
                    {
                        RPCProcedure.morphOff();
                        break;
                    }
                //SCRAMBLER
                case (byte)CustomRPC.CamoOn:
                    {
                        RPCProcedure.camoOn();
                        break;
                    }
                case (byte)CustomRPC.CamoOff:
                    {
                        RPCProcedure.camoOff();
                        break;
                    }
                //BARGHEST
                
                case (byte)CustomRPC.ShadowOn:
                    {
                        RPCProcedure.shadowOn();
                        break;
                    }
                case (byte)CustomRPC.ShadowOff:
                    {
                        RPCProcedure.shadowOff();
                        break;
                    }
                //GHOST
                case (byte)CustomRPC.GhostOn:
                    {
                        RPCProcedure.ghostOn();
                        break;
                    }
                case (byte)CustomRPC.GhostOff:
                    {
                        RPCProcedure.ghostOff();
                        break;
                    }
                //SORCERER
                case (byte)CustomRPC.War1:
                    {
                        RPCProcedure.war1();
                        break;
                    }
                case (byte)CustomRPC.War2:
                    {
                        RPCProcedure.war2();
                        break;
                    }
                case (byte)CustomRPC.War3:
                    {
                        RPCProcedure.war3();
                        break;
                    }
                case (byte)CustomRPC.War4:
                    {
                        RPCProcedure.war4();
                        break;
                    }
                case (byte)CustomRPC.CreateVent:
                    {
                        RPCProcedure.createVent(reader.ReadBytesAndSize());
                        break;
                    }
                case (byte)CustomRPC.SetPetrifyPlayer:
                    {
                        RPCProcedure.setPetrifyPlayer(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SetPetrifyAndShieldPlayer:
                    {
                        RPCProcedure.setPetrifyAndShieldPlayer(reader.ReadByte());
                        break;
                    }
                //IMPOSTORS KILL NORMAL
                case (byte)CustomRPC.VectorKill:
                    {
                        RPCProcedure.vectorKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor1Kill:
                    {
                        RPCProcedure.impostor1Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor2Kill:
                    {
                        RPCProcedure.impostor2Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.Impostor3Kill:
                    {
                        RPCProcedure.impostor3Kill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.MorphlingKill:
                    {
                        RPCProcedure.morphlingKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.ScramblerKill:
                    {
                        RPCProcedure.scramblerKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.BarghestKill:
                    {
                        RPCProcedure.barghestKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.GhostKill:
                    {
                        RPCProcedure.ghostKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SorcererKill:
                    {
                        RPCProcedure.sorcererKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.GuesserKill:
                    {
                        RPCProcedure.guesserKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.BasiliskKill:
                    {
                        RPCProcedure.basiliskKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.ReaperKill:
                    {
                        RPCProcedure.reaperKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.SaboteurKill:
                    {
                        RPCProcedure.saboteurKill(reader.ReadByte());
                        break;
                    }
                   
                    //ASSASSIN
                case (byte)CustomRPC.AssassinKill:
                    {
                        RPCProcedure.assassinKill(reader.ReadByte());
                        break;
                    }
                case (byte)CustomRPC.AssassinShield:
                    {
                        RPCProcedure.assassinShield();
                        break;
                    }
                case (byte)CustomRPC.MindControlOn:
                    
                    
                    HarmonyMain.Instance.ControlPlayer();


                    break;
                case (byte)CustomRPC.MindControl:

                    Vector3 newVel = new Vector3(reader.ReadSingle(), reader.ReadSingle());
                    Vector3 newPos = new Vector3(reader.ReadSingle(), reader.ReadSingle());
                    
                    if (PlayerControl.LocalPlayer == Mesmer.ControlledPlayer)
                    {
                        Mesmer.ControlledPlayer.transform.position = newPos;
                        Mesmer.ControlledPlayer.MyPhysics.body.position = newPos;
                        Mesmer.ControlledPlayer.MyPhysics.body.velocity = newVel;
                    }
                    break;
                case (byte)CustomRPC.BaitBalise:
                    RPCProcedure.baitbalise(reader.ReadBytesAndSize());
                    break;
                case (byte)CustomRPC.BaitBaliseEnable:
                    {
                        float posX = reader.ReadSingle();
                        float posY = reader.ReadSingle();
                        RPCProcedure.baitBaliseEnable(posX, posY);
                        break;
                    }
                case (byte)CustomRPC.ShareDronePosition:
                    {
                        float posX = reader.ReadSingle();
                        float posY = reader.ReadSingle();
                        byte ControllerID = reader.ReadByte();
                        RPCProcedure.shareDronePosition(posX, posY, ControllerID);
                        break;
                    }
                case (byte)CustomRPC.StopDrone:
                    {
                        RPCProcedure.stopDrone();
                        break;
                    }
            }
        }
    }
}

