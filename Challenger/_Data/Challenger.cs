using ChallengerOS;
using HarmonyLib;
using Hazel;
using System;
using System.Collections.Generic;
using UnityEngine;
using static ChallengerOS.Arrow;


namespace ChallengerMod
{

    

   


    [HarmonyPatch]
    public static class Challenger
    {
        //NEVER CLEAR THIS !! 
        public static bool RankedSettings = false;
        

        public static string debugg = "";
        public static string debugg02 = "";
        public static string debugg03 = "";
        public static KeyCode KeycodeKill { get; set; }
        public static KeyCode KeycodeAbility { get; set; }
        public static KeyCode KeycodeDroneRight { get; set; }
        public static KeyCode KeycodeDroneLeft { get; set; }
        public static KeyCode KeycodeDroneUp { get; set; }
        public static KeyCode KeycodeDroneDown { get; set; }
        public static bool IsrankedGame { get; set; }
        public static string SteamID = "ID";

        public static List<string> ReadyPlayers = new List<string>();

        public static bool RoleAssigned = false;
        public static bool IntroScreen = false;
        public static float CameraZoom = 3f;
        public static bool UICustom = true;

        public static float LangGameSet = 0f;
        public static DateTime? EndgameTimer { get; set; }
        public static float EndDelay = 0.3f;
        public static bool EndGameSab = false;
        public static float GameStarted = 5f;
        public static bool NuclearMap = false;
        public static float NuclearTimeMin = 90f;
        public static float NuclearTimeAdd = 0f;

        public static string EventActive = "Normal";
        public static bool LoverEvent = true;
        public static bool EventStarted = false;
        public static int ColorIDSave_ToCom = 6;
        public static int ColorIDSave_ToScrambler = 7;



        public static float NuclearTimer = 300f;
        public static float NuclearLastTimer = 10f;
        public static bool StartNuclear = false;
        public static bool StartSabNuclear = false;
        public static bool EmergencyDestroy = false;
        public static float ReSyncIntroTimer = 10f;
        public static bool ReSyncIntro = false;
        public static bool PlayerSafe = false;
        public static bool StartTimer = false;
        public static bool ResetIntroCD = false;
        public static bool IntroCD = false;
        public static bool IsMapPolusV2 = false;

        public static int QTEmergency = 0;

        public static bool UnknowImpostors { get; set; }
        public static bool ImpostorCanKillOther { get; set; }
        
        public static bool FirstTurn = true;
        public static bool SecondTurn = false;
        public static bool SyncButton = false;

        public static bool ResetScreenColor = false;

        //Goodloss Data
        public static string playerToken = "";
        public static string STRMap = "Map";
        public static string STRRole = "Role";
        public static string STRTeam = "Team";
        public static string STRGamecode = "XXXXXX";
        public static bool isRankedGame = false;
        public static bool LinkedAccount { get; set; }

        //RankedS2

        public static int _Players { get; set; }
        public static int _MapID { get; set; }
        public static int _IMP { get; set; }
        public static int _DUO { get; set; }
        public static int _SPE { get; set; }
        public static int _CRW { get; set; }
        public static List<string> _Roles = new List<string>();


        //PlayerData

        public static bool NewTeam = false;
        public static string STR_MyRole = "";
        public static string STR_MyName = "";
        public static string STR_MyTeam = "";
        public static string STR_MyRoleColor = "";
        public static string STR_MyTeamColor = "";
        public static string STR_MyTaskColor = "";
        public static string STR_Mytask = "";
        public static string STR_MyTotaltask = "";
        public static string STR_Mylove = "";
        public static string STR_MyCulte = "";
        public static string STR_MyShield = "";
        public static string STR_Ts1 = "[";
        public static string STR_Ts2 = "/";
        public static string STR_Ts3 = "]";
        public static string STR_P1 = "(";
        public static string STR_P2 = ")";


        public static System.Random rng = new System.Random();
        public static System.Random rnd = new System.Random((int)DateTime.Now.Ticks);

        public static List<PlayerControl> Vectorkill = new List<PlayerControl>();
        public static List<byte> bodys = new List<byte>();
        public static List<byte> bodys2 = new List<byte>();
        public static List<byte> EatedID = new List<byte>();
        public static List<PlayerControl> OiledPlayers = new List<PlayerControl>();
        public static List<PlayerControl> Petrifiedplayers = new List<PlayerControl>();
        public static List<PlayerControl> CultePlayers = new List<PlayerControl>();

        public static List<PlayerControl> LeaderList = new List<PlayerControl>();
        public static List<PlayerControl> LeaderCopyList = new List<PlayerControl>();
        public static List<PlayerControl> LoversList = new List<PlayerControl>();
        public static List<PlayerControl> _Alls = new List<PlayerControl>();



        public static List<Vent> ventsToSeal = new List<Vent>();
        public static List<Vent> Barghestvent = new List<Vent>();
        public static List<byte> draggers = new List<byte>();
        public static List<int> corpse = new List<int>();
        public static List<Arrow> localArrows = new List<Arrow>();
        public static List<SurvCamera> MiraCam = new List<SurvCamera>();
        public static bool resetMiraCam = false;
        public static PlayerControl DroneController = null;

        public static bool CanUseVent = false;
        public static bool DroneAnimGen = false;
        public static bool DroneAnimGen2 = false;
        public static bool DroneAnimP1 = false;
        public static bool DroneAnimP2 = false;
        public static bool VentSpriteEdited = false;
        public static bool RoleTaskAssigned = false;
        public static bool CulteTaskAssigned = false;
        public static bool loveTaskAssigned = false;
        public static bool MasterTaskAssigned = false;
        public static bool CopyTaskAssigned = false;
        public static bool OutlawCanKill = false;

        public static bool SendtoGoodloss = false;


        public static List<ChallengerOS.Utils.Helpers.DeadPlayer> killedPlayers = new List<ChallengerOS.Utils.Helpers.DeadPlayer>();
        public static PlayerControl CurrentTarget = null;
        public static PlayerControl localPlayer = null;
        public static List<PlayerControl> localPlayers = new List<PlayerControl>();
        public static PlayerControl PlayerphysiqueControler = PlayerControl.LocalPlayer;
        public static int TryHardPlayerDieCam { get; set; }
        public static int TryHardPlayerDieAdmin { get; set; }
        public static int TryHardPlayerDieVital { get; set; }
        public static float SetVitalTime { get; set; }
        public static float SetCamTime { get; set; }
        public static float SetAdminTime { get; set; }

        public static int timerV = 0;
        public static int timerC = 0;
        public static int timerA = 0;
        public static int timerN = 0;
        public static int timerLN = 0;
        public static float SafeTimer = 1;


        public static Dictionary<byte, PoolablePlayer> playerIcons = new Dictionary<byte, PoolablePlayer>();

        //LobbyData General event
        public static bool ComSab = false;
        public static bool OxySab = false;
        public static bool ReactorSab = false;
        public static bool StartComSabUnk = false;
        public static bool ResetAllPlayersSkin = false;
        public static bool ComIsSab = false;
        public static bool HMActive = false;
        public static bool LobbyTimeStop = false;
        public static bool InVent = false;
        public static bool LobbyLightOff = false;
        public static bool LobbyCamOff = false;
        public static bool LobbyAdminOff = false;
        public static bool LobbyVitalOff = false;
        public static bool AdminIsOpen = false;
        
        public static bool IsMeeting = false;
        public static bool PlayerOiled = false;
        public static bool AbilityDisabled = false;
        public static bool GuesserNotDie = false;
        public static bool OutlawAlive = false;
        public static bool PlayerControlled = false;

        public static bool SetAdminTimeOn = false;
        public static bool SetVitalTimeOn = false;
        public static bool SetCamTimeOn = false;
        public static bool SetNuclearTimeOn = false;
        public static bool SetNuclearSabTimeOn = false;

        public static Vector3 PetrifyPosition = new Vector3(99f, 99f, 1f);
        public static Vector3 PetrifyPositionIni = new Vector3(99f, 99f, 1f);

        public static Vector3 CirclePosition = new Vector3(99f, 99f, 1f);
        public static Vector3 CirclePositionC1 = new Vector3(99f, 99f, 1f);
        public static Vector3 CirclePositionC2 = new Vector3(99f, 99f, 1f);
        public static Vector3 CirclePositionC3 = new Vector3(99f, 99f, 1f);
        public static Vector3 CirclePositionC4 = new Vector3(99f, 99f, 1f);
        public static Vector3 CirclePositionC0 = new Vector3(99f, 99f, 1f);

        public static float CircleScale = 1f;

        public static void UpdateEvent()
        {
            ChallengerMod.HarmonyMain.EventConfig.Value = ChallengerMod.Challenger.EventActive;
        }
        public static void LoadEvent()
        {
            ChallengerMod.Challenger.EventActive = ChallengerMod.HarmonyMain.EventConfig.Value;
        }

        

    }
     
}