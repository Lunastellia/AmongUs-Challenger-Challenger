using HarmonyLib;
using System.Collections.Generic;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Roles;
using static ChallengerMod.Challenger;



namespace ChallengerMod
{



    [HarmonyPatch]
    public static class ResetData
    {

        public static void ResetSurvey()
        {
            
            SetAdminTimeOn = false;
            SetVitalTimeOn = false;
            SetCamTimeOn = false;
            SetNuclearTimeOn = false;
            SetNuclearSabTimeOn = false;
            NuclearMap = false;
            ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false;
            ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = false;
            ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = false;
        }

        public static void ResetLobbySettings()
        {
            ResetAllPlayersSkin = false;
            EventStarted = false;
            ChallengerMod.Set.Data.LoadImpostor = 0;
            NuclearTimer = NuclearTime1.getFloat();
            NuclearLastTimer = NuclearTime2.getFloat();
            QTEmergency = PlayerControl.GameOptions.NumEmergencyMeetings;
            StartTimer = false;
            IntroCD = false;
            ResetIntroCD = false;
            StartNuclear = false;
            StartSabNuclear = false;
            EmergencyDestroy = false;
            ReSyncIntroTimer = 10f;
            ReSyncIntro = false;
            SyncButton = false;
            PlayerSafe = false;
            IsMapPolusV2 = false;
            GameStarted = 5f;
            ComSab = false;
            OxySab = false;
            ReactorSab = false;
            StartComSabUnk = false;
            HMActive = false;
            LobbyTimeStop = false;
            InVent = false;
            LobbyLightOff = false;
            LobbyCamOff = false;
            LobbyAdminOff = false;
            LobbyVitalOff = false;
            AdminIsOpen = false;
            IsMeeting = false;
            PlayerOiled = false;
            AbilityDisabled = false;
            GuesserNotDie = false;
            OutlawAlive = false;
            PlayerControlled = false;
            IntroScreen = false;
            RoleTaskAssigned = false;
            VentSpriteEdited = false;
            CulteTaskAssigned = false;
            loveTaskAssigned = false;
            MasterTaskAssigned = false;
            CopyTaskAssigned = false;
            SendtoGoodloss = false;
            OutlawCanKill = false;
            NewTeam = false;
            STR_Mylove = "";
            STR_MyCulte = "";
            STR_MyShield = "";
            FirstTurn = true;
            SecondTurn = false;
            ChallengerMod.Set.Data.TotalPlayerOil = 0;
            EndDelay = 1.2f;

        }
        public static void PlayerListClear()
        {
            Challenger.OiledPlayers = new List<PlayerControl>();
            Challenger.Petrifiedplayers = new List<PlayerControl>();
            Challenger.Vectorkill = new List<PlayerControl>();
            ChallengerOS.Utils.Helpers.GameHistory.deadPlayers = new List<ChallengerOS.Utils.Helpers.DeadPlayer>();
            Challenger.bodys = new List<byte>();
            Challenger.bodys2 = new List<byte>();
            Challenger.EatedID = new List<byte>();
            Challenger.draggers = new List<byte>();
            Challenger.corpse = new List<int>();
            Challenger.ventsToSeal = new List<Vent>();
            Challenger._Alls = new List<PlayerControl>();
            Challenger.LeaderList = new List<PlayerControl>();
            Challenger.LeaderCopyList = new List<PlayerControl>();

            ChallengerOS.Objects.Balise.clear();
        }
        public static void ResetRolePick()
        {
           
            //CREWMATE ROLE
            Sheriff1.Role = null;
            Sheriff2.Role = null;
            Sheriff3.Role = null;
            Guardian.Role = null;
            Engineer.Role = null;
            Hunter.Role = null;
            Timelord.Role = null;
            Mystic.Role = null;
            Spirit.Role = null;
            Mayor.Role = null;
            Detective.Role = null;
            Nightwatch.Role = null;
            Spy.Role = null;
            Informant.Role = null;
            Bait.Role = null;
            Mentalist.Role = null;
            Builder.Role = null;
            Dictator.Role = null;
            Sentinel.Role = null;
            Teammate1.Role = null;
            Teammate2.Role = null;
            Lawkeeper.Role = null;
            Fake.Role = null;
            Traveler.Role = null;
            Leader.Role = null;
            Doctor.Role = null;
            Slave.Role = null;
          
            //CREWMATE VANILLA
            Crewmate1.Role = null;
            Crewmate2.Role = null;
            Crewmate3.Role = null;
            Crewmate4.Role = null;
            Crewmate5.Role = null;
            Crewmate6.Role = null;
            Crewmate7.Role = null;
            Crewmate8.Role = null;
            Crewmate9.Role = null;
            Crewmate10.Role = null;
            Crewmate11.Role = null;
            Crewmate12.Role = null;
            Crewmate13.Role = null;
            Crewmate14.Role = null;
           
            //SPECIAL ROLE
            Cupid.Role = null;
            Cultist.Role = null;
            Outlaw.Role = null;
            Jester.Role = null;
            Eater.Role = null;
            Sorcerer.Role = null;
            Cursed.Role = null;
           
            //HYBRID ROLE
            Mercenary.Role = null;
            CopyCat.Role = null;
            Revenger.Role = null;
            Survivor.Role = null;
           
            //IMPOSTOR ROLE
            Assassin.Role = null;
            Vector.Role = null;
            Morphling.Role = null;
            Scrambler.Role = null;
            Barghest.Role = null;
            Ghost.Role = null;
            Sorcerer.Role = null;
            Guesser.Role = null;
            Mesmer.Role = null;
           
            //IMPOSTOR VANILLA
            Impostor1.Role = null;
            Impostor2.Role = null;
            Impostor3.Role = null;
        }
        public static void ResetRoleData()
        {
            //RESET_ROLEDATA

            //SHERIFF1
            Sheriff1.CanKill = false;
            Sheriff1.Suicide = false;
            //SHERIFF2
            Sheriff2.CanKill = false;
            Sheriff2.Suicide = false;
            //SHERIFF3
            Sheriff3.CanKill = false;
            Sheriff3.Suicide = false;

            //GUARDIAN
            Guardian.Protected = null;
            Guardian.ProtectedMystic = null;
            Guardian.shieldattempt = false;
            Guardian.currentTarget = null;
            Guardian.ShieldUsed = false;
            Guardian.TryKill = false;

            //ENGINEER
            Engineer.RepairUsed = false;

            //HUNTER
            Hunter.Tracked = null;
            Hunter.CopyTracked = null;
            Hunter.currentTarget = null;
            Hunter.TrackUsed = false;
            Hunter.CopyTrackUsed = false;
            Hunter.KilledByHunter = false;
            Hunter.KilledByCopyHunter = false;


            //TIMELORD

            Timelord.TimeStopped = false;
            Timelord.TimeLordStopTime = false;
            Timelord.CopyCatStopTime = false;
            Timelord.AssassinStopTime = false;

            //MYSTIC
            Mystic.selfShield = true;
            Mystic.ShieldButton = false;
            Mystic.DoubleShield = false;
            Mystic.ClearDoubleShield = false;

            //MAYOR
            Mayor.TaskEND = false;
            Mayor.Buzz = false;
            Mayor.BuzzUsed = false;

            //DETECTIVE
            Detective.FindFP = false;
            Detective.anonymousFootprints = false;

            //NIGHTWATCH
            Nightwatch.LightBuff = false;


            //SPY
            Spy.Use = false;
            Spy.SpyUsed = false;
            Spy.Range = 3f;

            //INFORMANT
            Informant.Informed = null;
            Informant.TaskEND = false;
            Informant.Used = false;
            Informant.InformedTeam = 0;

            //BAIT
            Bait.active = new Dictionary<ChallengerOS.Utils.Helpers.DeadPlayer, float>();
            Bait.bait = new List<PlayerControl>();
            Bait.BaliseEnable = false;
            Bait.BaliseData = false;
            Bait.StunsPlayer = false;
            Bait.ResetStunsPlayer = false;


            //MENTALIST
            Mentalist.AdminVisibility = false;
            Mentalist.AdminUsed = false;

            //BUILDER
            Builder.ventTarget = null;
            Builder.Use1 = false;
            Builder.Use2 = false;
            Builder.Use3 = false;
            Builder.round = false;

            //DICTATOR
            Dictator.HMActive = false;
            Dictator.NoSkipUsed = false;
            Dictator.NoSkipButton = false;

            //SENTINEL
            Sentinel.Scan = false;
            Sentinel.ScanPlayerDie = 0;
            Sentinel.ScanPLayerInVent = false;

            //LAWKEEPER
            Lawkeeper.AbilityEnable = false;
            Lawkeeper.TaskEND = false;

            //LEADER
            Leader.Target = null;
            Leader.Target2 = null;
            Leader.Used = false;
            Leader.Used2 = false;
            Leader.TaskEND = false;

            //DOCTOR
            Doctor.Patient1 = null;
            Doctor.Patient2 = null;
            Doctor.Patient3 = null;

            //SLAVE
            Slave.Master = null;

            //MERCENARY
            Mercenary.isImpostor = false;
            Mercenary.Temp = false;
            Mercenary.Timer = 1.5f;
            Mercenary.SuicideShield = false;

            //COPYCAT
            CopyCat.CopiedPlayer = null;
            CopyCat.isImpostor = false;
            CopyCat.copyRole = 0;
            CopyCat.CopyUsed = false;
            CopyCat.CopyCatDie = false;
            CopyCat.CopyStart = false;
            CopyCat.AdminVisibility = false;
            CopyCat.TaskEND = false;
            CopyCat.Temp = false;
            CopyCat.Timer = 1.5f;
            CopyCat.HMActive = false;
            CopyCat.ScanPlayerDie = 0;
            CopyCat.Suicide = false;
            CopyCat.SuicideShield = false;
            CopyCat.AbilityEnable = false;
            CopyCat.Target = null;
            CopyCat.Target2 = null;
            CopyCat.Used = false;
            CopyCat.Used2 = false;

            //REVENGER
            Revenger.EMP1 = null;
            Revenger.EMP2 = null;
            Revenger.EMP3 = null;
            Revenger.isImpostor = false;
            Revenger.isCrewmate = false;
            Revenger.Exiled = false;
            Revenger.EMP1_On = false;
            Revenger.EMP2_On = false;
            Revenger.EMP3_On = false;
            Revenger.EMP1_Used = false;
            Revenger.EMP2_Used = false;
            Revenger.EMP3_Used = false;
            Revenger.AllEMP_Kill = false;
            Revenger.AllEMP_Exil = false;

            //SURVIVOR
            Survivor.isDie = false;

            //CULTE
            Cultist.Culte1 = null;
            Cultist.Culte2 = null;
            Cultist.Culte3 = null;
            Cultist.totalcultemember = 0f;
            Cultist.Win = false;
            Cultist.Culte1Used = false;
            Cultist.Culte2Used = false;
            Cultist.Culte3Used = false;
            Cultist.CulteUsed = false;
            Cultist.CulteTargetFail = false;
            Cultist.Die = false;
            Cultist.Suicide = false;

            //CUPID
            Cupid.Lover1 = null;
            Cupid.Lover2 = null;
            Cupid.loverDie = false;
            Cupid.Love1Used = false;
            Cupid.Love2Used = false;
            Cupid.LoveUsed = false;
            Cupid.Fail = false;
            Cupid.SpecialWin = false;
            Cupid.lover1Suicide = false;
            Cupid.lover2Suicide = false;
            Cupid.FirstMeeting = false;

            //OUTLAW
            Outlaw.canKill = false;
            Outlaw.Win = false;
            Outlaw.SuicideShield = false;

            //JESTER
            Jester.Exiled = false;
            Jester.Win = false;
            Jester.FakeUsed = false;
            Jester.CanFake = false;
            Jester.SingleFake = false;



            //EATER
            Eater.Win = false;
            Eater.TargetBody = false;
            EaterTask = 0f;
            Eater.CanEat = false;

            //ARSONIST
            Arsonist.Oiled = null;
            Arsonist.castTarget = null;
            Arsonist.Win = false;
            Arsonist.CanBurn = false;
            Arsonist.Fuel = 0f;
            Arsonist.Fail = false;
            Arsonist.NullTarget = false;
            Arsonist.FuelPercent = 0;
            Arsonist.FuelSpeed = 0f;
            Arsonist.FailTimer = 10f;

            //CURSED
            Cursed.Win = false;
            Cursed.CurseStart = false;
            Cursed.NoCurse = false;
            Cursed.NightEffect = false;
            Cursed.CursePercent = 0;
            Cursed.CurseValue = 0f;
            Cursed.CurseSpeed = 0f;
            Cursed.CursePlayer = 0f;

            //ASSASSIN
            Assassin.Shielded = false;
            Assassin.CanKillShield = false;
            Assassin.StealTime = false;
            Assassin.StealShield = false;
            Assassin.StealVent = false;
            Assassin.StealVision = false;
            Assassin.StealPlayerInfo = false;
            Assassin.StealVoteColor = false;
            Assassin.StealAdminColor = false;
            Assassin.StealFootPrint = false;
            Assassin.SuicideShield = false;

            //VECTOR
            Vector.Infected = null;
            Vector.Reset = false;
            Vector.KillBait = false;
            Vector.infect = false;
            Vector.SuicideShield = false;
            

            //MORPHLING
            Morphling.Morph = null;
            Morphling.Morphed = false;
            Morphling.StartMorphed = false;
            Morphling.StopMorphed = true;
            Morphling.SuicideShield = false;

            //SCRAMBLER
            Scrambler.Camo = false;
            Scrambler.SuicideShield = false;

            //BARGHEST
            Barghest.Shadow = false;
            Barghest.VentUse = false;
            Barghest.SuicideShield = false;

            //GHOST
            Ghost.Hide = false;
            Ghost.SuicideShield = false;

            //BASILISK
            Basilisk.Petrified = null;
            Basilisk.SuicideShield = false;
            Basilisk.Used = false;
            Basilisk.PetrifyAndShield = false;
            Basilisk.NullTarget = false;


            //REAPER
            Reaper.Stealed = null;
            Reaper.SuicideShield = false;

            //GUESSER
            Guesser.SuicideShield = false;

            //SORCERER
            Sorcerer.SuicideShield = false;
            Sorcerer.Exterminated = null;
            Sorcerer.Scan1 = null;
            Sorcerer.Scan2 = null;
            Sorcerer.SetScan1 = 0;
            Sorcerer.SetScan2 = 0;
            Sorcerer.TotalRune = 0;
            Sorcerer.TotalRuneLoot = 0f;
            Sorcerer.VitalSab = false;
            Sorcerer.CamSab = false;
            Sorcerer.AdminSab = false;
            Sorcerer.Start = false;
            Sorcerer.LootValue1 = false;
            Sorcerer.LootValue2 = false;
            Sorcerer.LootValue3 = false;
            Sorcerer.LootValue4 = false;

            Sorcerer.LootAttrValue1 = false;
            Sorcerer.LootAttrValue2 = false;
            Sorcerer.LootAttrValue3 = false;
            Sorcerer.LootAttrValue4 = false;

            Sorcerer.ButtonCircle = false;
            Sorcerer.CircleEnabled = false;

            //MESMER
            Mesmer.ControlledPlayer = null;
            Mesmer.MindControl = false;
            Mesmer.SuicideShield = false;

            //IMP
            Impostor1.SuicideShield = false;
            Impostor2.SuicideShield = false;
            Impostor3.SuicideShield = false;
        }
        public static void ResetRolesCount()
        {
        
            //PLAYERS_COUNT
        
            TotalPlayerCount = 15;
            TotalPlayerDie = 0;
            TotalPlayerAlive = 15;
            TotalCrewAlive = 13;
            TotalImpoAlive = 2;
            TotalCulteAlive = 0;
            TotalLoverAlive = 0;
            Cultist_Alive = 0;
            Culte1_Alive = 0;
            Culte2_Alive = 0;
            Culte3_Alive = 0;
            Lover1_Alive = 0;
            Lover2_Alive = 0;

            Culte1_Count = false;
            Culte2_Count = false;
            Culte3_Count = false;

            Love1_Count = false;
            love2_Count = false;
       
            //CREWMATES ROLE
            Sheriff1Count = false;
            Sheriff2Count = false;
            Sheriff3Count = false;
            GuardianCount = false;
            EngineerCount = false;
            HunterCount = false;
            TimelordCount = false;
            MysticCount = false;
            SpiritCount = false;
            MayorCount = false;
            DetectiveCount = false;
            NightwatchCount = false;
            SpyCount = false;
            InformantCount = false;
            BaitCount = false;
            MentalistCount = false;
            BuilderCount = false;
            DictatorCount = false;
            SentinelCount = false;
            Teammate1Count = false;
            Teammate2Count = false;
            LawkeeperCount = false;
            FakeCount = false;
            TravelerCount = false;
            LeaderCount = false;
            DoctorCount = false;
            SlaveCount = false;
           
            //CREWMATE VANILLA
            Crewmate1Count = false;
            Crewmate2Count = false;
            Crewmate3Count = false;
            Crewmate4Count = false;
            Crewmate5Count = false;
            Crewmate6Count = false;
            Crewmate7Count = false;
            Crewmate8Count = false;
            Crewmate9Count = false;
            Crewmate10Count = false;
            Crewmate11Count = false;
            Crewmate12Count = false;
            Crewmate13Count = false;
            Crewmate14Count = false;
           
            //SPECIAL ROLE
            CupidCount = false;
            CultistCount = false;
            OutlawCount = false;
            JesterCount = false;
            EaterCount = false;
            ArsonistCount = false;
            CursedCount = false;
            SorcererCount = false;
           
            //HYBRID ROLE
            MercenaryCount = false;
            MercenaryICount = false;
            CopyCatCount = false;
            CopyCatICount = false;
            RevengerCount = false;
            RevengerICount = false;
            SurvivorCount = false;
           
            //IMPOSTOR ROLE
            AssassinCount = false;
            VectorCount = false;
            MorphlingCount = false;
            ScramblerCount = false;
            BarghestCount = false;
            GhostCount = false;
            SorcererCount = false;
            GuesserCount = false;
            MesmerCount = false;
            BasiliskCount = false;
            ReaperCount = false;
            SaboteurCount = false;
           
            //IMPOSTOR VANILLA
            Impostor1Count = false;
            Impostor2Count = false;
            Impostor3Count = false;
        }
        public static void ResetWinData()
        {
            //WINTHEGAME
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            LoveWinthegame = false;
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
           
            //SPECIAL ROLE
            CupidWin = false;
            CultistWin = false;
            OutlawWin = false;
            JesterWin = false;
            EaterWin = false;
            ArsonistWin = false;
            CursedWin = false;
           
            //HYBRID ROLE
            MercenaryWin = false;
            MercenaryCWin = false;
            CopyCatWin = false;
            CopyCatCWin = false;
            RevengerWin = false;
            RevengerCWin = false;
            SurvivorWin = false;
           
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

        }
        public static void ResetPlayerTask()
        {
            
            //CREWMATES ROLE
            Sheriff1Task = 0f;
            Sheriff2Task = 0f;
            Sheriff3Task = 0f;
            GuardianTask = 0f;
            EngineerTask = 0f;
            HunterTask = 0f;
            TimelordTask = 0f;
            MysticTask = 0f;
            SpiritTask = 0f;
            MayorTask = 0f;
            DetectiveTask = 0f;
            NightwatchTask = 0f;
            SpyTask = 0f;
            InformantTask = 0f;
            BaitTask = 0f;
            MentalistTask = 0f;
            BuilderTask = 0f;
            DictatorTask = 0f;
            SentinelTask = 0f;
            Teammate1Task = 0f;
            Teammate2Task = 0f;
            LawkeeperTask = 0f;
            FakeTask = 0f;
            TravelerTask = 0f;
            LeaderTask = 0f;
            DoctorTask = 0f;
            SlaveTask = 0f;
           
            //CREWMATE VANILLA
            Crewmate1Task = 0f;
            Crewmate2Task = 0f;
            Crewmate3Task = 0f;
            Crewmate4Task = 0f;
            Crewmate5Task = 0f;
            Crewmate6Task = 0f;
            Crewmate7Task = 0f;
            Crewmate8Task = 0f;
            Crewmate9Task = 0f;
            Crewmate10Task = 0f;
            Crewmate11Task = 0f;
            Crewmate12Task = 0f;
            Crewmate13Task = 0f;
            Crewmate14Task = 0f;
            
            //HYBRID ROLE
            MercenaryTask = 0f;
            MercenaryCTask = 0f;
            CopyCatTask = 0f;
            CopyCatCTask = 0f;
            RevengerTask = 0f;
            RevengerCTask = 0f;
        }
        
    }
}