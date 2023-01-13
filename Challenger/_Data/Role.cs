using HarmonyLib;
using System.Collections.Generic;


namespace ChallengerMod
{

    [HarmonyPatch]
    public static class Roles
    {


        //GENERAL

        public static class AllPlayers
        {


        }
      

        //ROLES_CREWMATES_VANILLA
        public static class Crewmate1
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate2
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate3
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate4
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate5
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate6
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate7
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate8
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate9
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate10
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate11
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate12
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate13
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Crewmate14
        {
            public static PlayerControl Role { get; set; }

        }
        //ROLES_IMPOSTOR_VANILLA
        public static class Impostor1
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;

        }
        public static class Impostor2
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;


        }
        public static class Impostor3
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;


        }
        //ROLES_CREWMATES
        public static class Sheriff1
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool CanKill = false;
            public static bool Suicide = false;

        }
        public static class Sheriff2
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool CanKill = false;
            public static bool Suicide = false;

        }
        public static class Sheriff3
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool CanKill = false;
            public static bool Suicide = false;

        }
        public static class Guardian
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Protected { get; set; }
            public static PlayerControl ProtectedMystic { get; set; }
            public static PlayerControl currentTarget;
            public static bool TryKill = false;
            public static bool shieldattempt = false;
            public static bool ShieldUsed = false;

        }
        public static class Engineer
        {
            public static PlayerControl Role { get; set; }
            public static bool CanVent = false;
            public static bool RepairUsed = false;

        }
        public static class Timelord
        {
            public static PlayerControl Role { get; set; }
            public static bool TimeStopped = false;
            public static bool TimeLordStopTime = false;
            public static bool CopyCatStopTime = false;
            public static bool AssassinStopTime = false;
            

        }
        public static class Hunter
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Tracked { get; set; }
            public static PlayerControl CopyTracked { get; set; }
            public static PlayerControl currentTarget;
            public static bool TrackUsed = false;
            public static bool CopyTrackUsed = false;
            public static bool KilledByHunter = false;
            public static bool KilledByCopyHunter = false;
            public static float timer = 2f;
            public static float footprintIntervall = 0.2f;
            public static float footprintDuration = 0.25f;



        }
        public static class Mystic
        {
            public static PlayerControl Role { get; set; }
            public static bool selfShield = true;
            public static bool ShieldButton = false;
            public static bool DoubleShield = false;
            public static bool ClearDoubleShield = false;


        }
        public static class Spirit
        {
            public static PlayerControl Role { get; set; }
            public static bool CanCloseDoor = false;

        }
        public static class Mayor
        {
            public static PlayerControl Role { get; set; }
            public static bool TaskEND = false;
            public static bool Buzz = false;
            public static bool BuzzUsed = false;

        }
        public static class Detective
        {
            public static PlayerControl Role { get; set; }
            public static bool FindFP = false;
            public static float footprintIntervall = 0.35f;
            public static float footprintDuration = 1f;
            public static bool anonymousFootprints = false;
            public static float timer = 6f;

        }
        public static class Nightwatch
        {
            public static PlayerControl Role { get; set; }
            public static bool LightBuff = false;


        }
        public static class Spy
        {
            public static PlayerControl Role { get; set; }
            public static bool Use = false;
            public static bool SpyUsed = false;
            public static float Range = 3f;

        }
        public static class Informant
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Informed { get; set; }
            public static int InformedTeam = 0;
            public static PlayerControl currentTarget;
            public static bool TaskEND = false;
            public static bool Used = false;
        }
        public static class Bait
        {
            
            public static PlayerControl Role { get; set; }
            public static List<PlayerControl> bait = new List<PlayerControl>();
            public static bool CanVent = false;
            public static Dictionary<ChallengerOS.Utils.Helpers.DeadPlayer, float> active = new Dictionary<ChallengerOS.Utils.Helpers.DeadPlayer, float>();
            public static float reportDelayMin = 1f;
            public static float reportDelayMax = 1f;

        }
        public static class Mentalist
        {
            public static PlayerControl Role { get; set; }
            public static bool AdminVisibility = false;
            public static bool AdminUsed = false;


        }
        public static class Builder
        {
            public static PlayerControl Role { get; set; }
            public static Vent ventTarget = null;
            public static bool Use1 = false;
            public static bool Use2 = false;
            public static bool Use3 = false;
            public static bool round = false;

        }
        public static class Dictator
        {
            public static PlayerControl Role { get; set; }
            public static bool HMActive = false;
            public static bool NoSkipUsed = false;
            public static bool NoSkipButton = false;
            


        }
        public static class Sentinel
        {
            public static PlayerControl Role { get; set; }
            public static bool Scan = false;
            public static int ScanPlayerDie = 0;
            public static bool ScanPLayerInVent = false;

        }
        public static class Teammate1
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Teammate2
        {
            public static PlayerControl Role { get; set; }

        }
        public static class Lawkeeper
        {
            public static PlayerControl Role { get; set; }
            public static bool AbilityEnable = false;
            public static bool TaskEND = false;

        }
        public static class Fake
        {
            public static PlayerControl Role { get; set; }
            public static bool CanVent = false;

        }
        public static class Traveler
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Target { get; set; }
            public static PlayerControl currentTarget;

        }
        public static class Leader
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Target { get; set; }
            public static PlayerControl Target2 { get; set; }
            public static PlayerControl currentTarget;

        }
        public static class Doctor
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Patient1 { get; set; }
            public static PlayerControl Patient2 { get; set; }
            public static PlayerControl Patient3 { get; set; }
            public static PlayerControl currentTarget;

        }
        public static class Slave
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Master { get; set; }

        }
        //ROLE_HYBRID
        public static class Mercenary
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static bool isImpostor = false;
            public static bool Temp = false;
            public static float Timer = 1.5f;


        }
        public static class CopyCat
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl CopiedPlayer { get; set; }
            public static PlayerControl currentTarget;
            public static Vent ventTarget = null;

            public static bool CanVent = false;
            public static bool isImpostor = false;

            public static bool Suicide = false;
            public static bool SuicideShield = false;
            public static bool CopyUsed = false;
            public static bool CopyCatDie = false;
            public static bool TaskEND = false;
            public static bool AbilityEnable = false;
          
            public static int copyRole = 0;

            public static bool CopyStart = false;
            public static bool AdminVisibility = false;
            public static bool Temp = false;
            public static float Timer = 1.5f;
            public static bool HMActive = false;
            public static int ScanPlayerDie = 0;


        }
        public static class Survivor
        {
            public static PlayerControl Role { get; set; }
            public static bool isDie = false;

        }
        public static class Revenger
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl EMP1 { get; set; }
            public static PlayerControl EMP2 { get; set; }
            public static PlayerControl EMP3 { get; set; }
            public static PlayerControl currentTarget;
            
            public static bool Exiled = false;
            public static bool isCrewmate = false;
            public static bool isImpostor = false;
            public static bool EMP1_On = false;
            public static bool EMP2_On = false;
            public static bool EMP3_On = false;
            public static bool EMP1_Used = false;
            public static bool EMP2_Used = false;
            public static bool EMP3_Used = false;
            public static bool AllEMP_Kill = false;
            public static bool AllEMP_Exil = false;

            



        }
        //ROLE_SPECIAL
        public static class Cupid
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Lover1 { get; set; }
            public static PlayerControl Lover2 { get; set; }
            public static PlayerControl currentTarget;
            public static bool loverDie = false;
            public static bool Love1Used = false;
            public static bool Love2Used = false;
            public static bool LoveUsed = false;
            public static bool SpecialWin = false;
            public static bool Fail = false;
            public static bool lover1Suicide = false;
            public static bool lover2Suicide = false;
            public static bool FirstMeeting = false;

        }
        public static class Cultist
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Culte1 { get; set; }
            public static PlayerControl Culte2 { get; set; }
            public static PlayerControl Culte3 { get; set; }
            public static bool Suicide = false;
            public static PlayerControl currentTarget;
            public static float totalcultemember = 0f;
            public static bool Culte1Used = false;
            public static bool Culte2Used = false;
            public static bool Culte3Used = false;
            public static bool CulteUsed = false;
            public static bool CulteTargetFail = false;
            public static bool Die = false;


            public static bool Win = false;
           

        }
        public static class Outlaw
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool canKill = false;
            public static bool Win = false;

        }
        public static class Jester
        {
            public static PlayerControl Role { get; set; }
            public static bool Exiled = false;
            public static bool Win = false;
            public static bool FakeUsed = false;
            public static bool CanFake = false;
            public static bool SingleFake = false;


        }
        public static class Eater
        {
            public static PlayerControl Role { get; set; }
            public static DeadBody deadbodyTarget { get; set; }
            public static bool CanVent = false;
            public static bool Win = false;
            public static bool CanDragg = false;
            public static bool TargetBody = false;
            public static bool CanEat = false;
            public static int DistBody = 0;
            public static int EVD1 = 0;
            public static int EVD2 = 0;
            public static int EVD3 = 0;
            public static int EVD4 = 0;
            public static int EVD5 = 0;
            public static int EVD6 = 0;
            public static int EVD7 = 0;
            public static int EVD8 = 0;
            public static int EVD9 = 0;
            public static int EVD10 = 0;
        }
        public static class Arsonist
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Oiled { get; set; }
            public static PlayerControl currentTarget;
            public static PlayerControl castTarget;
            public static bool Win = false;
            public static bool CanBurn = false;
            public static bool Fail = false;
            public static bool NullTarget = false;
            public static int FuelPercent = 0;
            public static float FuelSpeed = 0f;
            public static float Fuel = 0f;
            public static float FailTimer = 10f;


        }
        public static class Cursed
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;

            public static bool Win = false;
            
            public static bool CurseStart = false;
            public static bool NoCurse = false;
            
            public static bool NightEffect = false;
            public static float SpeedModifieur = 0f;

            public static int CursePercent = 0;
            
            public static float CurseValue = 0f;
            public static float CurseSpeed = 0f;
            public static float CursePlayer = 0f;


        }
        //ROLE_IMPOSTOR
        public static class Assassin
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanKillShield = false;
            public static bool Shielded = false;
            public static bool StealTime = false;
            public static bool StealShield = false;
            public static bool StealVent = false;
            public static bool StealVision = false;
            public static bool StealPlayerInfo = false;
            public static bool StealVoteColor = false;
            public static bool StealAdminColor = false;
            public static bool StealFootPrint = false;

            public static bool BSheriff = false;
            public static bool BGuardian = false;
            public static bool BEngineer = false;
            public static bool BTimelord = false;
            public static bool BMystic = false;
            public static bool BMayor = false;
            public static bool BDetective = false;
            public static bool BNightwatcher = false;
            public static bool BSpy = false;
            public static bool BInfor = false;
            public static bool BMentalist = false;
            public static bool BBuilder = false;
            public static bool BDictator = false;
            public static bool BSentinel = false;
            public static bool BLawkeeper = false;
            public static bool BImpo = false;
             
            


        }
        public static class Vector
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Infected { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool infect = false;
            public static bool CanVent = false;
            public static bool Reset = false;
            public static bool KillBait = false;



        }
        public static class Morphling
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Morph { get; set; }
            public static bool SuicideShield = false;
            public static byte MorphID = 0;
            public static PlayerControl currentTarget;
            public static bool Morphed = false;
            public static bool StartMorphed = false;
            public static bool StopMorphed = true;

            public static bool CanVent = false;


        }
        public static class Scrambler
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool Camo = false;
            public static bool CanVent = false;

        }
        public static class Barghest
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static bool Shadow = false;
            public static bool VentUpdate = false;
            public static bool VentUse = false;

        }
        public static class Ghost
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool Hide = false;
            public static bool CanVent = false;

        }
        public static class Sorcerer
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Exterminated { get; set; }
            public static PlayerControl Scan1 { get; set; }
            public static int SetScan1 = 0;
            public static PlayerControl Scan2 { get; set; }
            public static int SetScan2 = 0;
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static int TotalRune = 0;
            public static float TotalRuneLoot = 0;
            public static bool VitalSab = false;
            public static bool CamSab = false;
            public static bool AdminSab = false;
            public static bool Start = false;
           
            public static bool LootValue1 = false;
            public static bool LootValue2 = false;
            public static bool LootValue3 = false;
            public static bool LootValue4 = false;
            public static bool LootAttrValue1 = false;
            public static bool LootAttrValue2 = false;
            public static bool LootAttrValue3 = false;
            public static bool LootAttrValue4 = false;

            public static bool ButtonCircle = false;
            public static bool CircleEnabled = false;

            public static bool CanUse1 = false;
            public static bool CanUse2 = false;
            public static bool CanUse3 = false;
            public static bool CanUse4 = false;

            


        }
        public static class Guesser
        {
            public static PlayerControl Role { get; set; }
            public static float remainingShots = 0f;
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static bool hasMultipleShotsPerMeeting { get; set; }
        }
        public static class Mesmer
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl ControlledPlayer { get; set; }

            
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool MindControl = false;
            public static bool CanVent = false;

        }
        public static class Basilisk
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Petrified { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static bool Used = false;
            public static float PetrifyCount = 0f;
            public static float PetrifyMax = 0f;
            public static float CostPetrify = 0f;
            public static float CostParalize = 0f;
            public static float DoseKill = 0f;
            public static float DoseMeet = 0f;
            public static float DoseStart = 0f;
            public static bool PetrifyAndShield = false;
            public static bool CanPetrify = false;
            public static bool CanPetrifyAndShield = false; 
            public static bool NullTarget = false;
            public static bool SinglePetrify = false;



        }
        public static class Reaper
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl Stealed { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;

        }
        public static class Saboteur
        {
            public static PlayerControl Role { get; set; }
            public static PlayerControl currentTarget;
            public static bool SuicideShield = false;
            public static bool CanVent = false;
            public static bool Roll = false;
            public static float RollInt = 0f;

        }

      

 
    }
}





