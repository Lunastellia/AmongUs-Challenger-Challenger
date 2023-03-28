
using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using Hazel;
using System.Reflection;
using System.IO;
using ChallengerOS.Utils.Option;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using System.Drawing;
using InnerNet;
using static Il2CppSystem.Linq.Expressions.Interpreter.CastInstruction.CastInstructionNoT;
using UnityEngine.UIElements;
using static ChallengerMod.Roles;

namespace ChallengerMod.Set
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class Data
    {

        public static string debugg1 = "1";
        public static string debugg2 = "1";
        public static string debugg3 = "1";
        public static string debugg4 = "1";
        public static string debugg5 = "1";




        public static string g_role_All = "";

        public static string g_role_Sheriff = "";


        public static string g_role_Guardian = "";


        public static string g_role_Engineer = "";


        public static string g_role_Timelord = "";


        public static string g_role_Hunter = "";


        public static string g_role_Mystic = "";


        public static string g_role_Spirit = "";


        public static string g_role_Mayor = "";


        public static string g_role_Detective = "";


        public static string g_role_Nightwatch = "";


        public static string g_role_Spy = "";


        public static string g_role_Informant = "";


        public static string g_role_Bait = "";


        public static string g_role_Mentalist = "";


        public static string g_role_Builder = "";


        public static string g_role_Dictator = "";


        public static string g_role_Sentinel = "";


        public static string g_role_Teammate = "";


        public static string g_role_Lawkeeper = "";


        public static string g_role_Fake = "";


        public static string g_role_Traveler = "";


        public static string g_role_Leader = "";


        public static string g_role_Doctor = "";


        public static string g_role_Slave = "";


        public static string g_role_Cupid = "";


        public static string g_role_Cultist = "";


        public static string g_role_Outlaw = "";


        public static string g_role_Jester = "";


        public static string g_role_Eater = "";


        public static string g_role_Arsonist = "";
        public static string g_role_Cursed = "";


        public static string g_role_Mercenary = "";


        public static string g_role_CopyCat = "";


        public static string g_role_Survivor = "";


        public static string g_role_Revenger = "";


        public static string g_role_Assassin = "";


        public static string g_role_Vector = "";


        public static string g_role_Morphling = "";


        public static string g_role_Scrambler = "";


        public static string g_role_Barghest = "";


        public static string g_role_Ghost = "";


        public static string g_role_Sorcerer = "";


        public static string g_role_Guesser = "";


        public static string g_role_Mesmer = "";


        public static string g_role_Basilisk = "";


        public static string g_role_Reaper = "";


        public static string g_role_Saboteur = "";


        public static int SetCost = 1;
        public static int SetCost0 = 0;
        public static int SetInformantTaskRemaining = 0;

        public static int TotalPlayerCount = 15;
        public static int TotalPlayerDie = 0;
        public static int TotalPlayerAlive = 15;

        public static int TotalCulteAlive = 0;
        public static int TotalImpoAlive = 2;

        public static int TotalCrewAlive = 15;

        public static int TotalLoverAlive = 0;

        public static int Culte1_Alive = 0;
        public static int Culte2_Alive = 0;
        public static int Culte3_Alive = 0;

        public static int Lover1_Alive = 0;
        public static int Lover2_Alive = 0;

        public static bool Culte1_Count = false;
        public static bool Culte2_Count = false;
        public static bool Culte3_Count = false;

        public static bool Love1_Count = false;
        public static bool love2_Count = false;

        public static int TotalPlayerOil = 0;



        public static bool SheriffMate { get; set; }
        public static bool EngineerMate { get; set; }
        public static bool GuardianMate { get; set; }
        public static bool GOEND { get; set; }
        public static float GuessValue { get; set; }


        public static float CopyCatMin { get; set; }

        public static int BuzzForAllValue { get; set; }





        public static float RealImpostor { get; set; }
        public static float LoadImpostor = 0;




        //Settings lobby
        public static float Sheriff1Max { get; set; }
        public static float Sheriff2Max { get; set; }
        public static float Sheriff3Max { get; set; }
        public static float Team1Min { get; set; }
        public static float Team2Min { get; set; }

        public static float LawkeeperMin { get; set; }
        public static float GuardianMin { get; set; }
        public static float SherifMin { get; set; }
        public static float Sherif2Min { get; set; }
        public static float Sherif3Min { get; set; }
        public static float EngineerMin { get; set; }
        public static float TimelordMin { get; set; }
        public static float HunterMin { get; set; }
        public static float MysticMin { get; set; }
        public static float SpiritMin { get; set; }
        public static float BuilderMin { get; set; }
        public static float FakeMin { get; set; }
        public static float MayorMin { get; set; }
        public static float DetectiveMin { get; set; }
        public static float NightwatcherMin { get; set; }
        public static float SpyMin { get; set; }
        public static float InforMin { get; set; }
        public static float BaitMin { get; set; }
        public static float MentalistMin { get; set; }
        public static float DictatorMin { get; set; }
        public static float SentinelMin { get; set; }
        public static float LeaderMin { get; set; }

        public static float JesterMin { get; set; }

        public static float OutlawMin { get; set; }
        public static float ArsonistMin { get; set; }

        public static float CursedMin { get; set; }
        public static float MercenaryMin { get; set; }
        public static float RevengerMin { get; set; }
        public static float SorcererMin { get; set; }
        public static float CupidMin { get; set; }
        public static float CultisteMin { get; set; }
        public static float EaterMin { get; set; }
        public static float Eatervaluewin { get; set; }



        public static float TotalTask { get; set; }





        public static float AssassinMin { get; set; }
        public static float VectorMin { get; set; }
        public static float MorphMin { get; set; }

        public static float MesmerMin { get; set; }
        public static float BasiliskMin { get; set; }
        public static float CamoMin { get; set; }
        public static float BarghestMin { get; set; }
        public static float GhostMin { get; set; }
        public static float Impo4Min { get; set; }
        public static float GuesserMin { get; set; }

       

        //UPDATE_ELEMENT
        public static string CC = "</color>";
        public static string CZ = "</size>";
        public static string Size0 = "<size=1>";
        public static string Size1 = "<size=1.1>";
        public static string Size2 = "<size=1.2>";
        public static string Size3 = "<size=1.3>";
        public static string Size4 = "<size=1.4>";
        public static string Size5 = "<size=1.5>";
        public static string SizeTT = "<size=8>";
        public static string C_WhiteColor = "<color=#FFFFFF>";
        public static string C_BlackColor = "<color=#FFFFFF>";
        public static string C_RedColor = "<color=#FF0000>";
        public static string C_GreenColor = "<color=#00FF00>";
        public static string C_BlueColor = "<color=#0000FF>";
        public static string C_CyanColor = "<color=#00FFFF>";
        public static string C_PinkColor = "<color=#FF00FF>";
        public static string C_YellowColor = "<color=#FFFF00>";

        //TASK_COLOR
        public static string Q_Crew = "<color=#0ADBEF>";
        public static string Q_Imp = "<color=#E70000>";
        public static string Q_Eater = "<color=#FFCD74>";
        public static string Q_Culte = "<color=#BC0AEF>";
        public static string Q_Arsonist = "<color=#EFD90A>";

        //ROLE_COLOR
        public static string R_CrewmateColor = "<color=#B4FAFA>";
        public static string R_GuardianColor = "<color=#00FFFF>";
        public static string R_EngineerColor = "<color=#FFA100>";
        public static string R_SheriffColor = "<color=#FFFF00>";
        public static string R_HunterColor = "<color=#00FF00>";
        public static string R_TimelordColor = "<color=#007FFF>";
        public static string R_MysticColor = "<color=#F9FFB2>";
        public static string R_SpiritColor = "<color=#A1FF00>";
        public static string R_MayorColor = "<color=#AF8269>";
        public static string R_SpyColor = "<color=#9EE1FF>";
        public static string R_NightwatchColor = "<color=#9EB3FF>";
        public static string R_DetectiveColor = "<color=#BCFFBA>";
        public static string R_InformantColor = "<color=#ADFFEA>";
        public static string R_BaitColor = "<color=#808080>";
        public static string R_MentalistColor = "<color=#A991FF>";
        public static string R_BuilderColor = "<color=#FFC291>";
        public static string R_DictatorColor = "<color=#C06A6A>";
        public static string R_SentinelColor = "<color=#06AD17>";
        public static string R_LawkeeperColor = "<color=#FF9B9B>";
        public static string R_FakeColor = "<color=#FF7A7A>";
        public static string R_TravelerColor = "<color=#6D8AFF>";
        public static string R_LeaderColor = "<color=#5A7DA5>";
        public static string R_DoctorColor = "<color=#19FFBA>";
        public static string R_SlaveColor = "<color=#DE1DFF>";

        public static string R_CupidColor = "<color=#FFAFFF>";
        public static string R_CulteColor = "<color=#8300FF>";
        public static string R_OutlawColor = "<color=#0033FF>";
        public static string R_JesterColor = "<color=#FF0A88>";
        public static string R_CursedColor = "<color=#3F683B>";
        public static string R_EaterColor = "<color=#FF6E00>";
        public static string R_ArsonistColor = "<color=#FFC800>";

        public static string R_MercenaryColor = "<color=#FF49E6>";
        public static string R_CopyCatColor = "<color=#64E6B4>";
        public static string R_RevengerColor = "<color=#D9C27E>";
        public static string R_SurvivorColor = "<color=#7F5E4C>";

        public static string R_ImpostorColor = "<color=#FF0000>";
        public static string R_AssassinColor = "<color=#005106>";
        public static string R_VectorColor = "<color=#8C1919>";
        public static string R_MorphlingColor = "<color=#430054>";
        public static string R_ScramblerColor = "<color=#544700>";
        public static string R_BarghestColor = "<color=#000569>";
        public static string R_GhostColor = "<color=#542B00>";
        public static string R_SorcererColor = "<color=#7F5E4C>";
        public static string R_GuesserColor = "<color=#003954>";
        public static string R_MesmerColor = "<color=#680037>";
        public static string R_BasiliskColor = "<color=#5B466B>";
        public static string R_ReaperColor = "<color=#004941>";
        public static string R_SaboteurColor = "<color=#683229>";

        //TEAM
        public static string T_Crewmates = "<color=#B4FAFA>";
        public static string T_Impostors = "<color=#FF0000>";
        public static string T_Cultes = "<color=#8300FF>";
        public static string T_Loves = "<color=#DC78C8>";
        public static string T_Jester = "<color=#FF0A88>";
        public static string T_Eater = "<color=#FF6E00>";
        public static string T_Outlaw = "<color=#0033ff>";
        public static string T_Arsonist = "<color=#ffc800>";
        public static string T_Cursed = "<color=#3F683B>";
        public static string T_Oileds = "<color=#FFED89>";
        public static string T_Survivor = "<color=#7F5E4C>";
        public static string T_Fail = "<color=#B4B4B4>";

        //BUFF
        public static string B_Lover_Alive = "<size=1.4><color=#DC78C8> ♥</color></size>";
        public static string B_Lover_Die = "<size=1.4><color=#9B9B9B> ♥</color></size>";
        public static string B_Culte_Alive = "<size=1.4><color=#8300FF> φ</color></size>";
        public static string B_Culte_Die = "<size=1.4><color=#9B9B9B> φ</color></size>";
        public static string B_Shield = "<size=1.4><color=#00FFFF> ⦿</color></size>";
        public static string B_DoubleShield = "<size=1.4><color=#00FF00> ⦿</color></size>";
        public static string B_SelfShield = "<size=1.4><color=#FFFF00> ⦿</color></size>";
        public static string B_NoSelfShield = "<size=1.4><color=#9B9B9B> ⦿</color></size>";
        public static string B_Tracker = "<size=1.4><color=#00FF00> ∇</color></size>";
        public static string B_Infect = "<size=1.4><color=#A20000> ∴</color></size>";
        public static string B_EMP_On = "<size=1.4><color=#FF0000> ◊</color></size>";
        public static string B_EMP_Off = "<size=1.4><color=#9B9B9B> ◊</color></size>";
        public static string B_Copy = "<size=1.4><color=#64E6B4> ©</color></size>";
        public static string B_Infored = " ❖";
        public static string B_Infored_Bad = "<size=1.4><color=#ff0000> ❖</color></size>";
        public static string B_Infored_Nice = "<size=1.4><color=#00ffff> ❖</color></size>";
        public static string B_Infored_Jester = "<size=1.4><color=#FF0A88> ❖</color></size>";
        public static string B_Infored_Outlaw = "<size=1.4><color=#0033ff> ❖</color></size>";
        public static string B_Infored_Eater = "<size=1.4><color=#FF6E00> ❖</color></size>";
        public static string B_Infored_Arsonist = "<size=1.4><color=#ffc800> ❖</color></size>";
        public static string B_Infored_Cursed = "<size=1.4><color=#3F683B> ❖</color></size>";
        public static string B_Infored_Culte = "<size=1.4><color=#8300FF> ❖</color></size>";
        public static string B_Master_Alive = "★";
        public static string B_Master_Die = "★";
        public static string B_Slave_Free = "★";
        public static string B_Slave_Die = "★";
        public static string B_Slave_On = "★";
        public static string B_Petrified = "<size=1.4><color=#ff00ff> ○</color></size>";
        public static string B_Petrified2 = "<size=1.4><color=#ff0000> ○</color></size>";
        public static string B_Morphed = "<color=#FF0000>\n[" + "" + "]</color>";
        public static string B_LeaderMark = "<size=1.4><color=#ffff00> ✿</color></size>";
        public static string B_LocalLeaderMark = "<size=1.4><color=#ACACAC> ✿</color></size>";
        public static string B_LeaderMarkCopy = "<size=1.4><color=#ffff00> ✿</color></size>";
        public static string B_LeaderMarkCopyIfExist = "<size=1.4><color=#64E6B4> ✿</color></size>";





        //LOBBY
        //WIN_DATA
        public static bool CrewmateWinthegamebyTask { get; set; }
        public static bool CulteWinthegame { get; set; }
        public static bool JesterWinthegame { get; set; }
        public static bool OutlawWinthegame { get; set; }
        public static bool ArsonistWinthegame { get; set; }
        public static bool EaterWinthegame { get; set; }
        public static bool CursedWinthegame { get; set; }
        public static bool CrewmateWinthegame { get; set; }
        public static bool ImpostorWinthegame { get; set; }
        public static bool ImpostorWinthegameBySab { get; set; }
        public static bool LoveWinthegame { get; set; }
        public static bool Sheriff1Win { get; set; }
        public static bool Sheriff2Win { get; set; }
        public static bool Sheriff3Win { get; set; }
        public static bool GuardianWin { get; set; }
        public static bool EngineerWin { get; set; }
        public static bool HunterWin { get; set; }
        public static bool TimelordWin { get; set; }
        public static bool MysticWin { get; set; }
        public static bool SpiritWin { get; set; }
        public static bool MayorWin { get; set; }
        public static bool DetectiveWin { get; set; }
        public static bool NightwatchWin { get; set; }
        public static bool SpyWin { get; set; }
        public static bool InformantWin { get; set; }
        public static bool BaitWin { get; set; }
        public static bool MentalistWin { get; set; }
        public static bool BuilderWin { get; set; }
        public static bool DictatorWin { get; set; }
        public static bool SentinelWin { get; set; }
        public static bool Teammate1Win { get; set; }
        public static bool Teammate2Win { get; set; }
        public static bool LawkeeperWin { get; set; }
        public static bool FakeWin { get; set; }
        public static bool TravelerWin { get; set; }
        public static bool LeaderWin { get; set; }
        public static bool DoctorWin { get; set; }
        public static bool SlaveWin { get; set; }
        public static bool Crewmate1Win { get; set; }
        public static bool Crewmate2Win { get; set; }
        public static bool Crewmate3Win { get; set; }
        public static bool Crewmate4Win { get; set; }
        public static bool Crewmate5Win { get; set; }
        public static bool Crewmate6Win { get; set; }
        public static bool Crewmate7Win { get; set; }
        public static bool Crewmate8Win { get; set; }
        public static bool Crewmate9Win { get; set; }
        public static bool Crewmate10Win { get; set; }
        public static bool Crewmate11Win { get; set; }
        public static bool Crewmate12Win { get; set; }
        public static bool Crewmate13Win { get; set; }
        public static bool Crewmate14Win { get; set; }



        public static bool CupidWin { get; set; }
        public static bool CultistWin { get; set; }
        public static bool OutlawWin { get; set; }
        public static bool JesterWin { get; set; }
        public static bool EaterWin { get; set; }
        public static bool ArsonistWin { get; set; }
        public static bool CursedWin { get; set; }

        public static bool MercenaryWin { get; set; }
        public static bool MercenaryCWin { get; set; }
        public static bool CopyCatWin { get; set; }
        public static bool CopyCatCWin { get; set; }
        public static bool RevengerWin { get; set; }
        public static bool RevengerCWin { get; set; }
        public static bool SurvivorWin { get; set; }



        public static bool Impostor1Win { get; set; }
        public static bool Impostor2Win { get; set; }
        public static bool Impostor3Win { get; set; }
        public static bool AssassinWin { get; set; }
        public static bool VectorWin { get; set; }
        public static bool MorphlingWin { get; set; }
        public static bool ScramblerWin { get; set; }
        public static bool BarghestWin { get; set; }
        public static bool GhostWin { get; set; }
        public static bool SorcererWin { get; set; }
        public static bool GuesserWin { get; set; }
        public static bool MesmerWin { get; set; }
        public static bool BasiliskWin { get; set; }
        public static bool ReaperWin { get; set; }
        public static bool SaboteurWin { get; set; }

        //TASKDATA


        public static float Sheriff1Task { get; set; }
        public static float Sheriff2Task { get; set; }
        public static float Sheriff3Task { get; set; }
        public static float GuardianTask { get; set; }
        public static float EngineerTask { get; set; }
        public static float HunterTask { get; set; }
        public static float TimelordTask { get; set; }
        public static float MysticTask { get; set; }
        public static float SpiritTask { get; set; }
        public static float MayorTask { get; set; }
        public static float DetectiveTask { get; set; }
        public static float NightwatchTask { get; set; }
        public static float SpyTask { get; set; }
        public static float InformantTask { get; set; }
        public static float BaitTask { get; set; }
        public static float MentalistTask { get; set; }
        public static float BuilderTask { get; set; }
        public static float DictatorTask { get; set; }
        public static float SentinelTask { get; set; }
        public static float Teammate1Task { get; set; }
        public static float Teammate2Task { get; set; }
        public static float LawkeeperTask { get; set; }
        public static float FakeTask { get; set; }
        public static float TravelerTask { get; set; }
        public static float LeaderTask { get; set; }
        public static float DoctorTask { get; set; }
        public static float SlaveTask { get; set; }
        public static float Crewmate1Task { get; set; }
        public static float Crewmate2Task { get; set; }
        public static float Crewmate3Task { get; set; }
        public static float Crewmate4Task { get; set; }
        public static float Crewmate5Task { get; set; }
        public static float Crewmate6Task { get; set; }
        public static float Crewmate7Task { get; set; }
        public static float Crewmate8Task { get; set; }
        public static float Crewmate9Task { get; set; }
        public static float Crewmate10Task { get; set; }
        public static float Crewmate11Task { get; set; }
        public static float Crewmate12Task { get; set; }
        public static float Crewmate13Task { get; set; }
        public static float Crewmate14Task { get; set; }
        public static float MercenaryTask { get; set; }
        public static float MercenaryCTask { get; set; }
        public static float CopyCatTask { get; set; }
        public static float CopyCatCTask { get; set; }
        public static float RevengerTask { get; set; }
        public static float RevengerCTask { get; set; }
        public static float EaterTask = 0f;

        //ROLE_COUNT

        public static bool Sheriff1Count { get; set; }
        public static bool Sheriff2Count { get; set; }
        public static bool Sheriff3Count { get; set; }
        public static bool GuardianCount { get; set; }
        public static bool EngineerCount { get; set; }
        public static bool HunterCount { get; set; }
        public static bool TimelordCount { get; set; }
        public static bool MysticCount { get; set; }
        public static bool SpiritCount { get; set; }
        public static bool MayorCount { get; set; }
        public static bool DetectiveCount { get; set; }
        public static bool NightwatchCount { get; set; }
        public static bool SpyCount { get; set; }
        public static bool InformantCount { get; set; }
        public static bool BaitCount { get; set; }
        public static bool MentalistCount { get; set; }
        public static bool BuilderCount { get; set; }
        public static bool DictatorCount { get; set; }
        public static bool SentinelCount { get; set; }
        public static bool Teammate1Count { get; set; }
        public static bool Teammate2Count { get; set; }
        public static bool LawkeeperCount { get; set; }
        public static bool FakeCount { get; set; }
        public static bool TravelerCount { get; set; }
        public static bool LeaderCount { get; set; }
        public static bool DoctorCount { get; set; }
        public static bool SlaveCount { get; set; }
        public static bool Crewmate1Count { get; set; }
        public static bool Crewmate2Count { get; set; }
        public static bool Crewmate3Count { get; set; }
        public static bool Crewmate4Count { get; set; }
        public static bool Crewmate5Count { get; set; }
        public static bool Crewmate6Count { get; set; }
        public static bool Crewmate7Count { get; set; }
        public static bool Crewmate8Count { get; set; }
        public static bool Crewmate9Count { get; set; }
        public static bool Crewmate10Count { get; set; }
        public static bool Crewmate11Count { get; set; }
        public static bool Crewmate12Count { get; set; }
        public static bool Crewmate13Count { get; set; }
        public static bool Crewmate14Count { get; set; }



        public static bool CupidCount { get; set; }
        public static bool CultistCount { get; set; }
        public static bool OutlawCount { get; set; }
        public static bool JesterCount { get; set; }
        public static bool EaterCount { get; set; }
        public static bool ArsonistCount { get; set; }
        public static bool CursedCount { get; set; }

        public static bool MercenaryCount { get; set; }
        public static bool MercenaryICount { get; set; }
        public static bool CopyCatCount { get; set; }
        public static bool CopyCatICount { get; set; }
        public static bool RevengerCount { get; set; }
        public static bool RevengerICount { get; set; }
        public static bool SurvivorCount { get; set; }



        public static bool Impostor1Count { get; set; }
        public static bool Impostor2Count { get; set; }
        public static bool Impostor3Count { get; set; }
        public static bool AssassinCount { get; set; }
        public static bool VectorCount { get; set; }
        public static bool MorphlingCount { get; set; }
        public static bool ScramblerCount { get; set; }
        public static bool BarghestCount { get; set; }
        public static bool GhostCount { get; set; }
        public static bool SorcererCount { get; set; }
        public static bool GuesserCount { get; set; }
        public static bool MesmerCount { get; set; }
        public static bool BasiliskCount { get; set; }
        public static bool ReaperCount { get; set; }
        public static bool SaboteurCount { get; set; }

        public static string Playerlang { get; set; }
        public static string UpdatedRank = "";

        public static int Sheriff1_Alive = 0;
        public static int Sheriff2_Alive = 0;
        public static int Sheriff3_Alive = 0;
        public static int Guardian_Alive = 0;
        public static int Engineer_Alive = 0;
        public static int Hunter_Alive = 0;
        public static int Timelord_Alive = 0;
        public static int Mystic_Alive = 0;
        public static int Spirit_Alive = 0;
        public static int Mayor_Alive = 0;
        public static int Detective_Alive = 0;
        public static int Nightwatch_Alive = 0;
        public static int Spy_Alive = 0;
        public static int Informant_Alive = 0;
        public static int Bait_Alive = 0;
        public static int Mentalist_Alive = 0;
        public static int Builder_Alive = 0;
        public static int Dictator_Alive = 0;
        public static int Sentinel_Alive = 0;
        public static int Teammate1_Alive = 0;
        public static int Teammate2_Alive = 0;
        public static int Lawkeeper_Alive = 0;
        public static int Fake_Alive = 0;
        public static int Traveler_Alive = 0;
        public static int Leader_Alive = 0;
        public static int Doctor_Alive = 0;
        public static int Slave_Alive = 0;
        public static int Crewmate1_Alive = 0;
        public static int Crewmate2_Alive = 0;
        public static int Crewmate3_Alive = 0;
        public static int Crewmate4_Alive = 0;
        public static int Crewmate5_Alive = 0;
        public static int Crewmate6_Alive = 0;
        public static int Crewmate7_Alive = 0;
        public static int Crewmate8_Alive = 0;
        public static int Crewmate9_Alive = 0;
        public static int Crewmate10_Alive = 0;
        public static int Crewmate11_Alive = 0;
        public static int Crewmate12_Alive = 0;
        public static int Crewmate13_Alive = 0;
        public static int Crewmate14_Alive = 0;

        public static int Cupid_Alive = 0;
        public static int Cultist_Alive = 0;
        public static int Outlaw_Alive = 0;
        public static int Jester_Alive = 0;
        public static int Eater_Alive = 0;
        public static int Arsonist_Alive = 0;
        public static int Cursed_Alive = 0;

        public static int Mercenary_Alive = 0;
        public static int CopyCat_Alive = 0;
        public static int IMercenary_Alive = 0;
        public static int ICopyCat_Alive = 0;
        public static int Revenger_Alive = 0;
        public static int Survivor_Alive = 0;

        public static int Impostor1_Alive = 0;
        public static int Impostor2_Alive = 0;
        public static int Impostor3_Alive = 0;
        public static int Assassin_Alive = 0;
        public static int Vector_Alive = 0;
        public static int Morphling_Alive = 0;
        public static int Scrambler_Alive = 0;
        public static int Barghest_Alive = 0;
        public static int Ghost_Alive = 0;
        public static int Sorcerer_Alive = 0;
        public static int Guesser_Alive = 0;
        public static int Mesmer_Alive = 0;
        public static int Basilisk_Alive = 0;
        public static int Reaper_Alive = 0;
        public static int Saboteur_Alive = 0;

        public static int Master_Alive = 0;
        //BUTTON


        public static float AdminButtonMaxTimer = 0f;
        public static float CamButtonMaxTimer = 0f;
        public static float VitalButtonMaxTimer = 0f;
        public static float BuzzButtonMaxTimer = 0f;


        //CREWMATES
        public static float ImpostorsKillButtonMaxTimer = 5f;

        public static float SheriffKillButtonMaxTimer = 5f;


        public static float GuardianAbilityButtonMaxTimer = 5f;

        public static float EngineerAbilityButtonMaxTimer = 5f;

        public static float TimelordAbilityButtonMaxTimer = 5f;
        public static float TimelordAbilityButtonEffectDuration = 5f;

        public static float HunterAbilityButtonMaxTimer = 5f;

        public static float MysticAbilityButtonMaxTimer = 5f;
        public static float MysticAbilityButtonEffectDuration = 5f;

        public static float SpiritAbilityButtonMaxTimer = 0f;

        public static float MayorAbilityButtonMaxTimer = 5f;

        public static float DetectiveAbilityButtonMaxTimer = 5f;
        public static float DetectiveAbilityButtonEffectDuration = 5f;

        public static float NightwatchAbilityButtonMaxTimer = 5f;
        public static float NightwatchAbilityButtonEffectDuration = 5f;

        public static float SpyAbilityButtonMaxTimer = 5f;
        public static float SpyAbilityButtonEffectDuration = 5f;

        public static float InformantAbilityButtonMaxTimer = 5f;

        public static float MentalistAbilityButtonMaxTimer = 5f;
        public static float MentalistAbilityButtonEffectDuration = 5f;

        public static float BuilderAbilityButtonMaxTimer = 5f;

        public static float DictatorAbilityButtonMaxTimer = 5f;

        public static float SentinelAbilityButtonMaxTimer = 5f;
        public static float SentinelAbilityButtonEffectDuration = 5f;

        public static float BaitButtonMaxTimer = 5f;

        //HYBRID
        public static float MercenaryKillButtonMaxTimer = 5f;

        public static float CopyCatScanAbilityButtonMaxTimer = 5f;

        public static float RevengerAbilityButtonMaxTimer = 5f;

        //SPECIALS
        public static float CupidAbilityButtonMaxTimer = 1f;

        public static float CultistAbilityButtonMaxTimer = 5f;

        public static float OutlawKillButtonMaxTimer = 5f;

        public static float JesterAbilityButtonMaxTimer = 5f;
        public static float CursedAbilityButtonMaxTimer = 5f;
        public static float CursedAbilityButtonEffectDuration = 5f;
        public static float CursedTime = 5f;


        public static float EaterDraggAbilityButtonMaxTimer = 0f;
        public static float EaterBarAbilityButtonMaxTimer = 0f;
        public static float EaterEatAbilityButtonMaxTimer = 5f;
        public static float EaterEatAbilityButtonEffectDuration = 5f;

        public static float ArsonistOilAbilityButtonMaxTimer = 5f;
        public static float ArsonistOilAbilityButtonEffectDuration = 5f;
        public static float ArsonistBurnAbilityButtonMaxTimer = 5f;

        //IMPOSTOR

        public static float AssassinKillButtonMaxTimer = 5f;
        public static float AssassinBonusCD = 5f;
        public static float AssassinMalusCD = 5f;

        

        public static float VectorInfectAbilityButtonMaxTimer = 5f;
        public static float VectorKillButtonMaxTimer = 5f;

        public static float MorphlingScanAbilityButtonMaxTimer = 5f;
        public static float MorphlingMorphAbilityButtonMaxTimer = 5f;
        public static float MorphlingMorphAbilityButtonEffectDuration = 5f;

        public static float ScramblerAbilityButtonMaxTimer = 5f;
        public static float ScramblerAbilityButtonEffectDuration = 5f;

        public static float BarghestShadowAbilityButtonMaxTimer = 5f;
        public static float BarghestShadowAbilityButtonEffectDuration = 5f;
        public static float BarghestCreateVentAbilityButtonMaxTimer = 5f;

        public static float GhostAbilityButtonMaxTimer = 5f;
        public static float GhostAbilityButtonEffectDuration = 5f;

        public static float SorcererFindAbilityButtonMaxTimer = 5f;
        public static float SorcererStuffAbilityButtonMaxTimer = 0f;




        // <TRANSLATOR>
        //Unrank AFD87C
        //Bronze D3B094
        //Sylver 99C5D7
        //gold ECDD79
        //cristal CF92EB
        //master E57B7B
        //Challenger FF9700
        public static string R_UnrankedFR = "<color=#AFD87C>Non-Classé</color>";
        public static string R_UnrankedZHCN = "<color=#AFD87C>未排名</color>";
        public static string R_UnrankedEN = "<color=#AFD87C>Unranked</color>";
        public static string R_Unranked = "<color=#AFD87C>Unranked</color>";

        public static string R_B3FR = "<color=#D3B094>Bronze III</color>";
        public static string R_B3ZHCN = "<color=#D3B094>青铜 III</color>";
        public static string R_B3EN = "<color=#D3B094>Bronze III</color>";
        public static string R_B3 = "<color=#D3B094>Bronze III</color>";

        public static string R_B2FR = "<color=#D3B094>Bronze II</color>";
        public static string R_B2ZHCN = "<color=#D3B094>青铜 II</color>";
        public static string R_B2EN = "<color=#D3B094>Bronze II</color>";
        public static string R_B2 = "<color=#D3B094>Bronze II</color>";

        public static string R_B1FR = "<color=#D3B094>Bronze I</color>";
        public static string R_B1ZHCN = "<color=#D3B094>青铜 I</color>";
        public static string R_B1EN = "<color=#D3B094>Bronze I</color>";
        public static string R_B1 = "<color=#D3B094>Bronze I</color>";

        public static string R_S3FR = "<color=#99C5D7>Argent III</color>";
        public static string R_S3ZHCN = "<color=#99C5D7>白银 III</color>";
        public static string R_S3EN = "<color=#99C5D7>Silver III</color>";
        public static string R_S3 = "<color=#99C5D7>Silver III</color>";

        public static string R_S2FR = "<color=#99C5D7>Argent II</color>";
        public static string R_S2ZHCN = "<color=#99C5D7>白银 II</color>";
        public static string R_S2EN = "<color=#99C5D7>Silver II</color>";
        public static string R_S2 = "<color=#99C5D7>Silver II</color>";

        public static string R_S1FR = "<color=#99C5D7>Argent I</color>";
        public static string R_S1ZHCN = "<color=#99C5D7>白银 I</color>";
        public static string R_S1EN = "<color=#99C5D7>Silver I</color>";
        public static string R_S1 = "<color=#99C5D7>Silver I</color>";

        public static string R_G3FR = "<color=#ECDD79>Or III</color>";
        public static string R_G3ZHCN = "<color=#ECDD79>黄金 III</color>";
        public static string R_G3EN = "<color=#ECDD79>Gold III</color>";
        public static string R_G3 = "<color=#ECDD79>Gold III</color>";

        public static string R_G2FR = "<color=#ECDD79>Or II</color>";
        public static string R_G2ZHCN = "<color=#ECDD79>黄金 II</color>";
        public static string R_G2EN = "<color=#ECDD79>Gold II</color>";
        public static string R_G2 = "<color=#ECDD79>Gold II</color>";

        public static string R_G1FR = "<color=#ECDD79>Or I</color>";
        public static string R_G1ZHCN = "<color=#ECDD79>黄金 I</color>";
        public static string R_G1EN = "<color=#ECDD79>Gold I</color>";
        public static string R_G1 = "<color=#ECDD79>Gold I</color>";

        public static string R_C3FR = "<color=#CF92EB>Cristal III</color>";
        public static string R_C3ZHCN = "<color=#CF92EB>水晶 III</color>";
        public static string R_C3EN = "<color=#CF92EB>Crystal III</color>";
        public static string R_C3 = "<color=#CF92EB>Crystal III</color>";

        public static string R_C2FR = "<color=#CF92EB>Cristal II</color>";
        public static string R_C2ZHCN = "<color=#CF92EB>水晶 II</color>";
        public static string R_C2EN = "<color=#CF92EB>Crystal II</color>";
        public static string R_C2 = "<color=#CF92EB>Crystal II</color>";

        public static string R_C1FR = "<color=#CF92EB>Cristal I</color>";
        public static string R_C1ZHCN = "<color=#CF92EB>水晶 I</color>";
        public static string R_C1EN = "<color=#CF92EB>Crystal I</color>";
        public static string R_C1 = "<color=#CF92EB>Crystal I</color>";

        public static string R_EFR = "<color=#E57B7B>Epique</color>";
        public static string R_EZNCN = "<color=#E57B7B>英雄</color>";
        public static string R_EEN = "<color=#E57B7B>Epic</color>";
        public static string R_E = "<color=#E57B7B>Epic</color>";

        public static string R_MFR = "<color=#FF9700>Mythique</color>";
        public static string R_MZHCN = "<color=#FF9700>神学家</color>";
        public static string R_MEN = "<color=#FF9700>Mythic</color>";
        public static string R_M = "<color=#FF9700>Mythic</color>";

        public static string DR_UnrankedFR = "Non-Classé";
        public static string DR_UnrankedZHCN = "未排名";
        public static string DR_UnrankedEN = "Unranked";
        public static string DR_Unranked = "Unranked";

        public static string DR_B3FR = "Bronze III";
        public static string DR_B3ZHCN = "青铜 III";
        public static string DR_B3EN = "Bronze III";
        public static string DR_B3 = "Bronze III";

        public static string DR_B2FR = "Bronze II";
        public static string DR_B2ZHCN = "青铜 II";
        public static string DR_B2EN = "Bronze II";
        public static string DR_B2 = "Bronze II";

        public static string DR_B1FR = "Bronze I";
        public static string DR_B1ZHCN = "青铜 I";
        public static string DR_B1EN = "Bronze I";
        public static string DR_B1 = "Bronze I";

        public static string DR_S3FR = "Argent III";
        public static string DR_S3ZHCN = "白银 III";
        public static string DR_S3EN = "Silver III";
        public static string DR_S3 = "Silver III";

        public static string DR_S2FR = "Argent II";
        public static string DR_S2ZHCN = "白银 II";
        public static string DR_S2EN = "Silver II";
        public static string DR_S2 = "Silver II";

        public static string DR_S1FR = "Argent I";
        public static string DR_S1ZHCN = "白银 I";
        public static string DR_S1EN = "Silver I";
        public static string DR_S1 = "Silver I";

        public static string DR_G3FR = "Or III";
        public static string DR_G3ZHCN = "黄金 III";
        public static string DR_G3EN = "Gold III";
        public static string DR_G3 = "Gold III";

        public static string DR_G2FR = "Or II";
        public static string DR_G2ZHCN = "黄金 II";
        public static string DR_G2EN = "Gold II";
        public static string DR_G2 = "Gold II";

        public static string DR_G1FR = "Or I";
        public static string DR_G1ZHCN = "黄金 I";
        public static string DR_G1EN = "Gold I";
        public static string DR_G1 = "Gold I";

        public static string DR_C3FR = "Cristal III";
        public static string DR_C3ZHCN = "水晶 III";
        public static string DR_C3EN = "Crystal III";
        public static string DR_C3 = "Crystal III";

        public static string DR_C2FR = "Cristal II";
        public static string DR_C2ZHCN = "水晶 II";
        public static string DR_C2EN = "Crystal II";
        public static string DR_C2 = "Crystal II";

        public static string DR_C1FR = "Cristal I";
        public static string DR_C1ZHCN = "水晶 I";
        public static string DR_C1EN = "Crystal I";
        public static string DR_C1 = "Crystal I";

        public static string DR_EFR = "Epique";
        public static string DR_EZHCN = "英雄";
        public static string DR_EEN = "Epic";
        public static string DR_E = "Epic";

        public static string DR_MFR = "Mythique";
        public static string DR_MZHCN = "神学家";
        public static string DR_MEN = "Mythic";
        public static string DR_M = "Mythic";




        public static string RT_ACTIF = "";

        public static string RTXT_1FR = "Joue en partie normal";
        public static string RTXT_1ZHCN = "游玩正常模式";
        public static string RTXT_1EN = "Play normal game";
        public static string RTXT_1 = "Play normal game";

        public static string RTXT_2FR = "Joue en partie Classé";
        public static string RTXT_2ZHCN = "游玩排位赛";
        public static string RTXT_2EN = "Play ranked game";
        public static string RTXT_2 = "Play ranked game";

        public static string RTXT_0 = "Play game";

        public static string CrewmateFR = "Coéquipier";
        public static string CrewmateZHCN = "船员";
        public static string CrewmateEN = "Crewmate";
        public static string Role_Crewmate = "Crewmate";

        public static string SheriffFR = "Shérif";
        public static string SheriffZHCN = "警长";
        public static string SheriffEN = "Sheriff";
        public static string Role_Sheriff = "Sheriff";

        public static string GuardianFR = "Gardien";
        public static string GuardianZHCN = "守护者";
        public static string GuardianEN = "Guardian";
        public static string Role_Guardian = "Guardian";

        public static string EngineerFR = "Ingénieur";
        public static string EngineerZHCN = "工程师";
        public static string EngineerEN = "Engineer";
        public static string Role_Engineer = "Engineer";

        public static string TimelordFR = "Temporel";
        public static string TimelordZHCN = "时间领主";
        public static string TimelordEN = "TimeLord";
        public static string Role_Timelord = "TimeLord";

        public static string HunterFR = "Chasseur";
        public static string HunterZHCN = "猎人";
        public static string HunterEN = "Hunter";
        public static string Role_Hunter = "Hunter";

        public static string MysticFR = "Mystique";
        public static string MysticZHCN = "神秘人";
        public static string MysticEN = "Mystic";
        public static string Role_Mystic = "Mystic";

        public static string SpiritFR = "Esprit";
        public static string SpiritZHCN = "精灵";
        public static string SpiritEN = "Spirit";
        public static string Role_Spirit = "Spirit";

        public static string MayorFR = "Maire";
        public static string MayorZHCN = "市长";
        public static string MayorEN = "Mayor";
        public static string Role_Mayor = "Mayor";

        public static string DetectiveFR = "Detective";
        public static string DetectiveZHCN = "侦探";
        public static string DetectiveEN = "Detective";
        public static string Role_Detective = "Detective";

        public static string NightwatchFR = "Veilleur";
        public static string NightwatchZHCN = "执灯人";
        public static string NightwatchEN = "Nightwatch";
        public static string Role_Nightwatch = "Nightwatch";

        public static string SpyFR = "Espion";
        public static string SpyZHCN = "特工";
        public static string SpyEN = "Spy";
        public static string Role_Spy = "Spy";

        public static string InformantFR = "Voyante";
        public static string InformantZHCN = "线人";
        public static string InformantEN = "Informant";
        public static string Role_Informant = "Informant";

        public static string BaitFR = "Appat";
        public static string BaitZHCN = "诱饵";
        public static string BaitEN = "Bait";
        public static string Role_Bait = "Bait";

        public static string MentalistFR = "Mentaliste";
        public static string MentalistZHCN = "心理医生";
        public static string MentalistEN = "Mentalist";
        public static string Role_Mentalist = "Mentalist";

        public static string BuilderFR = "Constructeur";
        public static string BuilderZHCN = "保安";
        public static string BuilderEN = "Builder";
        public static string Role_Builder = "Builder";

        public static string DictatorFR = "Dictateur";
        public static string DictatorZHCN = "独裁者";
        public static string DictatorEN = "Dictator";
        public static string Role_Dictator = "Dictator";

        public static string SentinelFR = "Sentinelle";
        public static string SentinelZHCN = "哨兵";
        public static string SentinelEN = "Sentinel";
        public static string Role_Sentinel = "Sentinel";

        public static string TeammateFR = "Partenaire";
        public static string TeammateZHCN = "队友";
        public static string TeammateEN = "Teammate";
        public static string Role_Teammate = "Teammate";

        public static string LawkeeperFR = "Justicier";
        public static string LawkeeperZHCN = "验尸官";
        public static string LawkeeperEN = "Lawkeeper";
        public static string Role_Lawkeeper = "Lawkeeper";

        public static string FakeFR = "Intrue";
        public static string FakeZHCN = "卧底";
        public static string FakeEN = "Fake";
        public static string Role_Fake = "Fake";

        public static string TravelerFR = "Voyageur";
        public static string TravelerZHCN = "旅行者";
        public static string TravelerEN = "Traveler";
        public static string Role_Traveler = "Traveler";

        public static string LeaderFR = "Chef";
        public static string LeaderZHCN = "领袖";
        public static string LeaderEN = "Leader";
        public static string Role_Leader = "Leader";

        public static string DoctorFR = "Docteur";
        public static string DoctorZHCN = "医生";
        public static string DoctorEN = "Doctor";
        public static string Role_Doctor = "Doctor";

        public static string SlaveFR = "Esclave";
        public static string SlaveZHCN = "奴隶";
        public static string SlaveEN = "Slave";
        public static string Role_Slave = "Slave";

        public static string MasterFR = "Maître";
        public static string MasterZHCN = "奴隶主";
        public static string MasterEN = "Master";
        public static string Role_Master = "Master";

        public static string AngelFR = "Ange";
        public static string AngelZHCN = "Angel";
        public static string AngelEN = "Angel";
        public static string Role_Angel = "Angel";



        public static string CupidFR = "Cupidon";
        public static string CupidZHCN = "丘比特";
        public static string CupidEN = "Cupid";
        public static string Role_Cupid = "Cupid";

        public static string CultistFR = "Cultiste";
        public static string CultistZHCN = "教主";
        public static string CultistEN = "Cultist";
        public static string Role_Cultist = "Cultist";

        public static string OutlawFR = "Criminel";
        public static string OutlawZHCN = "亡命徒";
        public static string OutlawEN = "Outlaw";
        public static string Role_Outlaw = "Outlaw";

        public static string JesterFR = "Bouffon";
        public static string JesterZHCN = "小丑";
        public static string JesterEN = "Jester";
        public static string Role_Jester = "Jester";

        public static string EaterFR = "Dévoreur";
        public static string EaterZHCN = "秃鹫";
        public static string EaterEN = "Eater";
        public static string Role_Eater = "Eater";

        public static string ArsonistFR = "Pyromane";
        public static string ArsonistZHCN = "纵火犯";
        public static string ArsonistEN = "Arsonist";
        public static string Role_Arsonist = "Arsonist";

        public static string CursedFR = "Maudit";
        public static string CursedZHCN = "被诅咒者";
        public static string CursedEN = "Cursed";
        public static string Role_Cursed = "Cursed";

        public static string MercenaryFR = "Mercenaire";
        public static string MercenaryZHCN = "雇佣兵";
        public static string MercenaryEN = "Mercenary";
        public static string Role_Mercenary = "Mercenary";

        public static string CopyCatFR = "Immitateur";
        public static string CopyCatZHCN = "失忆者";
        public static string CopyCatEN = "CopyCat";
        public static string Role_CopyCat = "CopyCat";

        public static string SurvivorFR = "Survivant";
        public static string SurvivorZHCN = "幸存者";
        public static string SurvivorEN = "Survivor";
        public static string Role_Survivor = "Survivor";

        public static string RevengerFR = "Vengeur";
        public static string RevengerZHCN = "复仇者";
        public static string RevengerEN = "Revenger";
        public static string Role_Revenger = "Revenger";

        public static string ImpostorFR = "Imposteur";
        public static string ImpostorZHCN = "内鬼";
        public static string ImpostorEN = "Impostor";
        public static string Role_Impostor = "Impostor";

        public static string AssassinFR = "Assassin";
        public static string AssassinZHCN = "刺客";
        public static string AssassinEN = "Assassin";
        public static string Role_Assassin = "Assassin";

        public static string VectorFR = "Vecteur";
        public static string VectorZHCN = "染控者";
        public static string VectorEN = "Vector";
        public static string Role_Vector = "Vector";

        public static string MorphlingFR = "Métamorphe";
        public static string MorphlingZHCN = "化形者";
        public static string MorphlingEN = "Morphling";
        public static string Role_Morphling = "Morphling";

        public static string ScramblerFR = "Brouilleur";
        public static string ScramblerZHCN = "隐蔽者";
        public static string ScramblerEN = "Scrambler";
        public static string Role_Scrambler = "Scrambler";

        public static string BarghestFR = "Barghest";
        public static string BarghestZHCN = "犬魔";
        public static string BarghestEN = "Barghest";
        public static string Role_Barghest = "Barghest";

        public static string GhostFR = "Fantome";
        public static string GhostZHCN = "隐身人";
        public static string GhostEN = "Ghost";
        public static string Role_Ghost = "Ghost";

        public static string SorcererFR = "Sorcier";
        public static string SorcererZHCN = "法师";
        public static string SorcererEN = "Sorcerer";
        public static string Role_Sorcerer = "Sorcerer";

        public static string GuesserFR = "Devin";
        public static string GuesserZHCN = "赌怪";
        public static string GuesserEN = "Guesser";
        public static string Role_Guesser = "Guesser";

        public static string MesmerFR = "Envoûteur";
        public static string MesmerZHCN = "术士";
        public static string MesmerEN = "Mesmer";
        public static string Role_Mesmer = "Mesmer";

        public static string BasiliskFR = "Basilik";
        public static string BasiliskZHCN = "蛇怪";
        public static string BasiliskEN = "Basilisk";
        public static string Role_Basilisk = "Basilisk";

        public static string ReaperFR = "Faucheur";
        public static string ReaperZHCN = "灵魂收割者";
        public static string ReaperEN = "Reaper";
        public static string Role_Reaper = "Reaper";

        public static string SaboteurFR = "Saboteur";
        public static string SaboteurZHCN = "破坏者";
        public static string SaboteurEN = "Saboteur";
        public static string Role_Saboteur = "Saboteur";


        public static string STR_LOVERS = "";
        public static string STR_MORPH = "";
        public static string STR_COPY = "STR";
        public static string STR_NAME = "STR";
        public static string STR_WARV = "STR";
        public static string STR_List1 = "-";
        public static string STR_List2 = "-";

        public static string CulteMemberFR = "Membre du Culte";
        public static string CulteMemberZHCN = "邪教成员";
        public static string CulteMemberEN = "Culte Member";
        public static string Role_CulteMember = "Culte Member";

        public static string LoverFR = "Amoureux/se";
        public static string LoverZHCN = "恋人";
        public static string LoverEN = "Lover";
        public static string Role_Lover = "Lover";

        public static string WinFR = "Victoire";
        public static string WinZHCN = "胜利";
        public static string WinEN = "Victory";
        public static string Str_Win = "Victory";

        public static string LooseFR = "Défaite";
        public static string LooseZHCN = "Defeat";
        public static string LooseEN = "Defeat";
        public static string Str_Loose = "Defeat";

        public static string JesterWinFR = "Victoire du Bouffon";
        public static string JesterWinZHCN = "♪所有技巧，没有招待，我给这个游戏，相当轰动...♪";
        public static string JesterWinEN = "Jester Win";
        public static string Str_JesterWin = "Jester Win";

        public static string CursedWinFR = "Victoire du Maudit";
        public static string CursedWinZHCN = "被诅咒者胜利";
        public static string CursedWinEN = "Cursed Win";
        public static string Str_CursedWin = "Cursed Win";

        public static string EaterWinFR = "Victoire du Dévoreur";
        public static string EaterWinZHCN = "感谢招待";
        public static string EaterWinEN = "Eater Win";
        public static string Str_EaterWin = "Eater Win";

        public static string OutlawWinFR = "Victoire du Criminel";
        public static string OutlawWinZHCN = "亡命徒胜利";
        public static string OutlawWinEN = "Outlaw Win";
        public static string Str_OutlawWin = "Outlaw Win";

        public static string ArsonistWinFR = "Victoire du Pyromane";
        public static string ArsonistWinZHCN = "♪我放火，放火，放火，给我的朋友们...♪";
        public static string ArsonistWinEN = "Arsonist Win";
        public static string Str_ArsonistWin = "Arsonist Win";

        public static string CulteWinFR = "Victoire du Culte";
        public static string CulteWinZHCN = "邪教胜利";
        public static string CulteWinEN = "The Culte Win";
        public static string Str_CulteWin = "The Culte Win";

        public static string CupidWinFR = "Victoire de Cupidon & des amoureux";
        public static string CupidWinZHCN = "丘比特 & 恋人 胜利";
        public static string CupidWinEN = "Cupid & Lovers Win";
        public static string Str_CupidWin = "Cupid & Lovers Win";

        public static string CrewmateWinFR = "Victoire des Coéquipiers";
        public static string CrewmateWinZHCN = "船员胜利";
        public static string CrewmateWinEN = "Crewmates Win";
        public static string Str_CrewmateWin = "Crewmates Win";

        public static string ImpostorWinFR = "Victoire des Imposteurs";
        public static string ImpostorWinZHCN = "内鬼胜利";
        public static string ImpostorWinEN = "Impostors Win";
        public static string Str_ImpostorWin = "Impostors Win";

        public static string BySabWinFR = "Les Imposteurs gagnent avec les sabotages !";
        public static string BySabWinZHCN = "内鬼通过破坏获胜 !";
        public static string BySabWinEN = "Impostors win the game with sabotages !";
        public static string Str_BySabWin = "Impostors win the game with sabotages !";

        public static string ByVoteWinFR = "Les imposteurs ont tous étaient éliminés";
        public static string ByVoteWinZHCN = "内鬼全部死亡 !";
        public static string ByVoteWinEN = "The Impostors are all dead !";
        public static string Str_ByVoteWin = "The Impostors are all dead !";

        public static string ByTaskWinFR = "Toute les tâches sont terminées";
        public static string ByTaskWinZHCN = "船员所有任务均已完成 !";
        public static string ByTaskWinEN = "All the tasks were completed !";
        public static string Str_ByTaskWin = "All the tasks were completed !";

        public static string ByKillWinFR = "tout les Coéquipiers ont étaient tués";
        public static string ByKillWinZHCN = "所有船员均被淘汰 !";
        public static string ByKillWinEN = "All Crewmates have been eliminated !";
        public static string Str_ByKillWin = "All Crewmates have been eliminated !";



        public static string Task_CrewmateFR = "<color=#87f7f7>Termine tes tâches et trouve les </color><color=#FF0000>Imposteurs</color>.";
        public static string Task_CrewmateZHCN = "<color=#87f7f7>完成任务并且找出</color><color=#FF0000>内鬼</color>.";
        public static string Task_CrewmateEN = "<color=#87f7f7>Finish your tasks and find the </color><color=#FF0000>Impostors</color>.";
        public static string Task_Role_Crewmate = "<color=#87f7f7>Finish your tasks and find the </color><color=#FF0000>Impostors</color>.";

        public static string Task_SheriffFR = "<color=#87f7f7>Tue les </color> <color=#FF0000>Imposteurs</color> <color=#87f7f7>et les autres Méchants.</color>";
        public static string Task_SheriffZHCN = "<color=#87f7f7>杀死 </color> <color=#FF0000>内鬼</color> <color=#87f7f7>和其他阵营的人.</color>";
        public static string Task_SheriffEN = "<color=#87f7f7>Kill the </color> <color=#FF0000>Impostors</color> <color=#87f7f7>and other wicked.</color>";
        public static string Task_Role_Sheriff = "<color=#87f7f7>Kill the </color> <color=#FF0000>Impostors</color> <color=#87f7f7>and other wicked.</color>";

        public static string Task_GuardianFR = "<color=#87f7f7>Créé un bouclier pour protéger 1 autre joueur.</color>";
        public static string Task_GuardianZHCN = "<color=#87f7f7>创建一个护盾来保护另一个玩家</color>";
        public static string Task_GuardianEN = "<color=#87f7f7>Create a shield to protect another player.</color>";
        public static string Task_Role_Guardian = "<color=#87f7f7>Create a shield to protect another player.</color>";

        public static string Task_EngineerFR = "<color=#87f7f7>Utilise ta capacité pour réparer les sabotages.</color>";
        public static string Task_EngineerZHCN = "<color=#87f7f7>用你的技能来修复破坏</color>";
        public static string Task_EngineerEN = "<color=#87f7f7>Use your ability to repair the sabotages.</color>";
        public static string Task_Role_Engineer = "<color=#87f7f7>Use your ability to repair the sabotages.</color>";

        public static string Task_TimelordFR = "<color=#87f7f7>Utilise ta capacité pour arrêter le temps.</color>";
        public static string Task_TimelordZHCN = "<color=#87f7f7>用你的技能来暂停时间.</color>";
        public static string Task_TimelordEN = "<color=#87f7f7>Use your ability to stop time.</color>";
        public static string Task_Role_Timelord = "<color=#87f7f7>Use your ability to stop time.</color>";

        public static string Task_HunterFR = "<color=#87f7f7>Traque un autre joueur, si tu meurs, il meurt avec toi !</color>";
        public static string Task_HunterZHCN = "<color=#87f7f7>选择另一个玩家，如果你死了，他们会和你一起死 !</color>";
        public static string Task_HunterEN = "<color=#87f7f7>Track another player, if you die they die with you !</color>";
        public static string Task_Role_Hunter = "<color=#87f7f7>Track another player, if you die they die with you !</color>";

        public static string Task_MysticFR = "<color=#87f7f7>Utilise ton bouclier personnel pour te protéger.</color>";
        public static string Task_MysticZHCN = "<color=#87f7f7>使用你的护盾来保护你自己.</color>";
        public static string Task_MysticEN = "<color=#87f7f7>Use your personal shield to protect yourself.</color>";
        public static string Task_Role_Mystic = "<color=#87f7f7>Use your personal shield to protect yourself.</color>";

        public static string Task_SpiritFR = "<color=#87f7f7>Tu ne peux pas être éliminé aux votes !</color>";
        public static string Task_SpiritZHCN = "<color=#87f7f7>你不能被投出 !</color>";
        public static string Task_SpiritEN = "<color=#87f7f7>You can't be voted out !</color>";
        public static string Task_Role_Spirit = "<color=#87f7f7>You can't be voted out !</color>";

        public static string Task_MayorFR = "<color=#87f7f7>Le vote du maire compte double pendant les réunions.</color>";
        public static string Task_MayorZHCN = "<color=#87f7f7>你的票数算作两票.</color>";
        public static string Task_MayorEN = "<color=#87f7f7>Mayor's vote counts x2 during meetings.</color>";
        public static string Task_Role_Mayor = "<color=#87f7f7>Mayor's vote counts x2 during meetings.</color>";

        public static string Task_DetectiveFR = "<color=#87f7f7>Utilise ta capacité pour voir par où les autres sont allés.</color>";
        public static string Task_DetectiveZHCN = "<color=#87f7f7>使用你的技能知道别人去了哪里.</color>";
        public static string Task_DetectiveEN = "<color=#87f7f7>Use your ability to see where the others have gone.</color>";
        public static string Task_Role_Detective = "<color=#87f7f7>Use your ability to see where the others have gone.</color>";

        public static string Task_NightwatchFR = "<color=#87f7f7>Augmente temporairement ta vision.</color>";
        public static string Task_NightwatchZHCN = "<color=#87f7f7>暂时增加你的视野.</color>";
        public static string Task_NightwatchEN = "<color=#87f7f7>Temporarily increases your vision.</color>";
        public static string Task_Role_Nightwatch = "<color=#87f7f7>Temporarily increases your vision.</color>";

        public static string Task_SpyFR = "<color=#87f7f7>Espionne les autres joueurs.</color>";
        public static string Task_SpyZHCN = "<color=#87f7f7>监视其他玩家.</color>";
        public static string Task_SpyEN = "<color=#87f7f7>Spy on other players.</color>";
        public static string Task_Role_Spy = "<color=#87f7f7>Spy on other players.</color>";

        public static string Task_InformantFR = "<color=#87f7f7>Termine tes tâches pour en savoir plus sur les autres.</color>";
        public static string Task_InformantZHCN = "<color=#87f7f7>完成你的任务来了解更多关于其他人的事情.</color>";
        public static string Task_InformantEN = "<color=#87f7f7>Complete your tasks to learn more about others.</color>";
        public static string Task_Role_Informant = "<color=#87f7f7>Complete your tasks to learn more about others.</color>";

        public static string Task_BaitFR = "<color=#87f7f7>Crée des zones d'alerte et puni les tueurs !</color>";
        public static string Task_BaitZHCN = "<color=#87f7f7>Create warning area and punish killers!</color>";
        public static string Task_BaitEN = "<color=#87f7f7>Create warning area and punish killers!</color>";
        public static string Task_Role_Bait = "<color=#87f7f7>Create warning area and punish killers!</color>";

        public static string Task_MentalistFR = "<color=#87f7f7>Tu peux temporairement voir les couleurs des autres.</color>";
        public static string Task_MentalistZHCN = "<color=#87f7f7>你可以暂时看到其他人的颜色.</color>";
        public static string Task_MentalistEN = "<color=#87f7f7>You can temporarily see other people's colors.</color>";
        public static string Task_Role_Mentalist = "<color=#87f7f7>You can temporarily see other people's colors.</color>";

        public static string Task_BuilderFR = "<color=#87f7f7>Tu peux sceller des vents !</color>";
        public static string Task_BuilderZHCN = "<color=#87f7f7>你可以封锁管道 !</color>";
        public static string Task_BuilderEN = "<color=#87f7f7>You can seal the vents !</color>";
        public static string Task_Role_Builder = "<color=#87f7f7>You can seal the vents !</color>";

        public static string Task_DictatorFR = "<color=#87f7f7>Ordonne aux autres joueurs de voter !</color>";
        public static string Task_DictatorZHCN = "<color=#87f7f7>迫使其他玩家投票 !</color>";
        public static string Task_DictatorEN = "<color=#87f7f7>Obligate the other players to vote !</color>";
        public static string Task_Role_Dictator = "<color=#87f7f7>Obligate the other players to vote !</color>";

        public static string Task_SentinelFR = "<color=#87f7f7>Scanne la zone pour trouver des informations.</color>";
        public static string Task_SentinelZHCN = "<color=#87f7f7>通过扫描来查找信息.</color>";
        public static string Task_SentinelEN = "<color=#87f7f7>Scan to find information.</color>";
        public static string Task_Role_Sentinel = "<color=#87f7f7>Scan to find information.</color>";

        public static string Task_TeammateFR = "<color=#87f7f7>Termine tes tâches et trouve les </color><color=#FF0000>Imposteurs</color>.";
        public static string Task_TeammateZHCN = "<color=#87f7f7>完成你的任务并且找到 </color><color=#FF0000>内鬼</color>.";
        public static string Task_TeammateEN = "<color=#87f7f7>Finish your tasks and find the </color><color=#FF0000>Impostors</color>.";
        public static string Task_Role_Teammate = "<color=#87f7f7>Finish your tasks and find the </color><color=#FF0000>Impostors</color>.";

        public static string Task_LawkeeperFR = "<color=#87f7f7>Signale les cadavres pour obtenir des infos sur le tueur.</color>";
        public static string Task_LawkeeperZHCN = "<color=#87f7f7>报告尸体以获取凶手的信息.</color>";
        public static string Task_LawkeeperEN = "<color=#87f7f7>Report a deadbody to get info on the killer.</color>";
        public static string Task_Role_Lawkeeper = "<color=#87f7f7>Report a deadbody to get info on the killer.</color>";

        public static string Task_FakeFR = "<color=#87f7f7>Les imposteurs pensent que tu es l'un des leurs.</color>";
        public static string Task_FakeZHCN = "<color=#87f7f7>混在内鬼当中.</color>";
        public static string Task_FakeEN = "<color=#87f7f7>The Impostors think you're one of them.</color>";
        public static string Task_Role_Fake = "<color=#87f7f7>The Impostors think you're one of them.</color>";

        public static string Task_TravelerFR = "<color=#87f7f7>Utilise ta capacité pour te téléporter.</color>";
        public static string Task_TravelerZHCN = "<color=#87f7f7>使用你的技能穿越空间.</color>";
        public static string Task_TravelerEN = "<color=#87f7f7>Use your ability to jump into space.</color>";
        public static string Task_Role_Traveler = "<color=#87f7f7>Use your ability to jump into space.</color>";

        public static string Task_LeaderFR = "<color=#87f7f7>Aide ton équipe à débusquer les méchants.</color>";
        public static string Task_LeaderZHCN = "<color=#87f7f7>Help your team to find out the bad guys.</color>";
        public static string Task_LeaderEN = "<color=#87f7f7>Help your team to find out the bad guys.</color>";
        public static string Task_Role_Leader = "<color=#87f7f7>Help your team to find out the bad guys.</color>";

        public static string Task_AngelFR = "<color=#87f7f7>Fais abbatre ton jugement sur le joueur qui ta tuer.</color>";
        public static string Task_AngelZHCN = "<color=#87f7f7>Cast your judgment on the player who killed you.</color>";
        public static string Task_AngelEN = "<color=#87f7f7>Cast your judgment on the player who killed you.</color>";
        public static string Task_Role_Angel = "<color=#87f7f7>Cast your judgment on the player who killed you.</color>";

        public static string Task_DoctorFR = "<color=#87f7f7>Controle l'état de santé de tes patients.</color>";
        public static string Task_DoctorZHCN = "<color=#87f7f7>检查患者的健康状况.</color>";
        public static string Task_DoctorEN = "<color=#87f7f7>Check the health status of your patients.</color>";
        public static string Task_Role_Doctor = "<color=#87f7f7>Check the health status of your patients.</color>";

        public static string Task_SlaveFR = "<color=#87f7f7>Découvre qui est le Maître, et affranchis toi !</color>";
        public static string Task_SlaveZHCN = "<color=#87f7f7>找出谁是奴隶主，然后释放你自己, and free yourself !</color>";
        public static string Task_SlaveEN = "<color=#87f7f7>Find out who is the Master, and free yourself !</color>";
        public static string Task_Role_Slave = "<color=#87f7f7>Find out who is the Master, and free yourself !</color>";

        public static string Task_MasterFR = "<color=#87f7f7>Si L'esclave meure, votre identité sera révélée.</color>";
        public static string Task_MasterZHCN = "<color=#87f7f7>如果奴隶死了，你的身份就会暴露.</color>";
        public static string Task_MasterEN = "<color=#87f7f7>If The Slave dies, your identity will be revealed.</color>";
        public static string Task_Role_Master = "<color=#87f7f7>If The Slave dies, your identity will be revealed.</color>";

        public static string Task_CupidFR = "<color=#FFAFFF>Rends amoureux 2 autres joueurs !</color>";
        public static string Task_CupidZHCN = "<color=#FFAFFF>让两个玩家坠入爱河 !</color>";
        public static string Task_CupidEN = "<color=#FFAFFF>Make 2 other players fall in love !</color>";
        public static string Task_Role_Cupid = "<color=#FFAFFF>Make 2 other players fall in love !</color>";

        public static string Task_CultistFR = "<color=#8300FF>Convertis d'autres joueurs dans ton culte !</color>";
        public static string Task_CultistZHCN = "<color=#8300FF>让玩家加入为你的邪教 !</color>";
        public static string Task_CultistEN = "<color=#8300FF>Convert players to your culte !</color>";
        public static string Task_Role_Cultist = "<color=#8300FF>Convert players to your culte !</color>";

        public static string Task_CulteFR = "<color=#8300FF>Soyez en supériorité numérique pour gagner.</color>";
        public static string Task_CulteZHCN = "<color=#8300FF>在人数优势中获胜 !</color>";
        public static string Task_CulteEN = "<color=#8300FF>Be the most numerous for win !</color>";
        public static string Task_Role_Culte = "<color=#8300FF>Be the most numerous for win !</color>";

        public static string Task_OutlawFR = "<color=#0033FF>Tue tout le monde !</color>";
        public static string Task_OutlawZHCN = "<color=#0033FF>击杀所有人!</color>";
        public static string Task_OutlawEN = "<color=#0033FF>Kill everyone!</color>";
        public static string Task_Role_Outlaw = "<color=#0033FF>Kill everyone!</color>";

        public static string Task_JesterFR = "<color=#FF0A88>Fais toi éliminer aux votes pour gagner la partie !</color>";
        public static string Task_JesterZHCN = "<color=#FF0A88>想办法被投出去以获胜 !</color>";
        public static string Task_JesterEN = "<color=#FF0A88>Get voted out to win the game !</color>";
        public static string Task_Role_Jester = "<color=#FF0A88>Get voted out to win the game !</color>";

        public static string Task_EaterFR = "<color=#FF6E00>Trouve et Dévore des cadavres pour gagner !</color>";
        public static string Task_EaterZHCN = "<color=#FF6E00>吞噬尸体来获胜 !</color>";
        public static string Task_EaterEN = "<color=#FF6E00>Find and eat deadbodies to win !</color>";
        public static string Task_Role_Eater = "<color=#FF6E00>Find and eat deadbodies to win !</color>";

        public static string Task_ArsonistFR = "<color=#FFC800>Enduis d'huile les autres joueurs vivants et brûle les pour gagner !</color>";
        public static string Task_ArsonistZHCN = "<color=#FFC800>给其他玩家浇油并且点燃它们 !</color>";
        public static string Task_ArsonistEN = "<color=#FFC800>Oil other living players and burn them all !</color>";
        public static string Task_Role_Arsonist = "<color=#FFC800>Oil other living players and burn them all !</color>";

        public static string Task_CursedFR = "<color=#3F683B>Reste seule pour gagner la partie !</color>";
        public static string Task_CursedZHCN = "<color=#3F683B>孤独的获得游戏胜利 !</color>";
        public static string Task_CursedEN = "<color=#3F683B>Stay Alone to win the game !</color>";
        public static string Task_Role_Cursed = "<color=#3F683B>Stay Alone to win the game !</color>";


        public static string Task_MercenaryFR = "<color=#87f7f7>Choisis ton Camp, Si tu tentes de tuer, tu deviendras un </color><color=#FF0000>Imposteur</color>.";
        public static string Task_MercenaryZHCN = "<color=#87f7f7>选择你的阵营，如果你尝试击杀，你就会变成 </color><color=#FF0000>内鬼</color>.";
        public static string Task_MercenaryEN = "<color=#87f7f7>Choose your side, if you try to kill, you will become an </color><color=#FF0000>Impostor</color>.";
        public static string Task_Role_Mercenary = "<color=#87f7f7>Choose your side, if you try to kill, you will become an </color><color=#FF0000>Impostor</color>.";

        public static string Task_CopyCatFR = "<color=#87f7f7>Copie le rôle d'un autre joueur lorsqu'il meurt</color>.";
        public static string Task_CopyCatZHCN = "<color=#87f7f7>当其他玩家死亡时复制它们的职业</color>.";
        public static string Task_CopyCatEN = "<color=#87f7f7>Copy another player's role when they die</color>.";
        public static string Task_Role_CopyCat = "<color=#87f7f7>Copy another player's role when they die</color>.";

        public static string Task_SurvivorFR = "<color=#7F5E4C>Reste en vie pour gagner !</color>";
        public static string Task_SurvivorZHCN = "<color=#7F5E4C>幸存下来以获胜!</color>";
        public static string Task_SurvivorEN = "<color=#7F5E4C>Stay alive to win!</color>";
        public static string Task_Role_Survivor = "<color=#7F5E4C>Stay alive to win!</color>";

        public static string Task_RevengerFR = "<color=#87f7f7>Désactive les pouvoirs d'autres joueurs lorsque tu meurs</color>.";
        public static string Task_RevengerZHCN = "<color=#87f7f7>当你死后禁用其他玩家的技能</color>.";
        public static string Task_RevengerEN = "<color=#87f7f7>Disable other players' abilities when you die</color>.";
        public static string Task_Role_Revenger = "<color=#87f7f7>Disable other players' abilities when you die</color>.";

        public static string Task_ImpostorFR = "<color=#FFBABA>Elimine tous les </color><color=#87f7f7>coéquipiers</color>.";
        public static string Task_ImpostorZHCN = "<color=#FFBABA>杀死所有 </color><color=#87f7f7>船员</color>.";
        public static string Task_ImpostorEN = "<color=#FFBABA>Kill all </color><color=#87f7f7>Crewmates</color>.";
        public static string Task_Role_Impostor = "<color=#FFBABA>Kill all </color><color=#87f7f7>Crewmates</color>.";

        public static string Task_AssassinFR = "<color=#FFBABA>Gagne des bonus en tuant d'autres joueurs</color>.";
        public static string Task_AssassinZHCN = "<color=#FFBABA>通过杀死玩家获得力量</color>.";
        public static string Task_AssassinEN = "<color=#FFBABA>Earn power by killing players</color>.";
        public static string Task_Role_Assassin = "<color=#FFBABA>Earn power by killing players</color>.";

        public static string Task_VectorFR = "<color=#FFBABA>Infecte d'autre joueur pour les faire exploser à distance</color>.";
        public static string Task_VectorZHCN = "<color=#FFBABA>感染其他玩家并且远程杀死他们</color>.";
        public static string Task_VectorEN = "<color=#FFBABA>Infect other players to blast them all remotely</color>.";
        public static string Task_Role_Vector = "<color=#FFBABA>Infect other players to blast them all remotely</color>.";

        public static string Task_MorphlingFR = "<color=#FFBABA>Vole l'ADN d'un autre joueur pour prendre son apparence</color>.";
        public static string Task_MorphlingZHCN = "<color=#FFBABA>窃取另一名玩家的基因以获得他们的外观</color>.";
        public static string Task_MorphlingEN = "<color=#FFBABA>Steal another player's DNA to take on their appearance</color>.";
        public static string Task_Role_Morphling = "<color=#FFBABA>Steal another player's DNA to take on their appearance</color>.";

        public static string Task_ScramblerFR = "<color=#FFBABA>Perturbe les autres en rendant tout le monde anonyme</color>.";
        public static string Task_ScramblerZHCN = "<color=#FFBABA>通过让所有人匿名以迷惑他人</color>.";
        public static string Task_ScramblerEN = "<color=#FFBABA>Confuse others by making everyone anonymous</color>.";
        public static string Task_Role_Scrambler = "<color=#FFBABA>Confuse others by making everyone anonymous</color>.";

        public static string Task_BarghestFR = "<color=#FFBABA>Crée des Vents & Réduit la vision des autres joueurs.</color>";
        public static string Task_BarghestZHCN = "<color=#FFBABA>创建管道 & 降低其它玩家的视野.</color>";
        public static string Task_BarghestEN = "<color=#FFBABA>Create Vents & redure other players' vision.</color>";
        public static string Task_Role_Barghest = "<color=#FFBABA>Create Vents & redure other players' vision.</color>";

        public static string Task_GhostFR = "<color=#FFBABA>Deviens temporairement invisible</color>.";
        public static string Task_GhostZHCN = "<color=#FFBABA>暂时隐身.</color>";
        public static string Task_GhostEN = "<color=#FFBABA>Become temporarily invisible.</color>";
        public static string Task_Role_Ghost = "<color=#FFBABA>Become temporarily invisible.</color>";

        public static string Task_SorcererFR = "<color=#FFBABA>Trouve les 4 runes pour utiliser tes Pouvoirs.</color>";
        public static string Task_SorcererZHCN = "<color=#FFBABA>找到四个符文来使用你的法术.</color>";
        public static string Task_SorcererEN = "<color=#FFBABA>Find the 4 runes to use your spells.</color>";
        public static string Task_Role_Sorcerer = "<color=#FFBABA>Find the 4 runes to use your spells.</color>";

        public static string Task_GuesserFR = "<color=#FFBABA>Devine le rôle des autres pour les tuer.</color>";
        public static string Task_GuesserZHCN = "<color=#FFBABA>通过猜测职业来杀死它们.</color>";
        public static string Task_GuesserEN = "<color=#FFBABA>Discover the role of others to kill them.</color>";
        public static string Task_Role_Guesser = "<color=#FFBABA>Discover the role of others to kill them.</color>";

        public static string Task_MesmerFR = "<color=#FFBABA>Prends le contrôle de ta cible.</color>";
        public static string Task_MesmerZHCN = "<color=#FFBABA>控制你的目标.</color>";
        public static string Task_MesmerEN = "<color=#FFBABA>Take control of your target.</color>";
        public static string Task_Role_Mesmer = "<color=#FFBABA>Take control of your target.</color>";

        public static string Task_BasiliskFR = "<color=#FFBABA>Pétrifie un autre joueur pour l'empêcher de parler.</color>";
        public static string Task_BasiliskZHCN = "<color=#FFBABA>石化另一个玩家以阻止他们说话.</color>";
        public static string Task_BasiliskEN = "<color=#FFBABA>Petrify another player to prevent them from talking.</color>";
        public static string Task_Role_Basilisk = "<color=#FFBABA>Petrify another player to prevent them from talking.</color>";

        public static string Task_ReaperFR = "<color=#FFBABA>Vole l'âme d'un autre joueur et cache la !</color>";
        public static string Task_ReaperZHCN = "<color=#FFBABA>偷取另一个玩家的灵魂并将其隐藏起来 !</color>";
        public static string Task_ReaperEN = "<color=#FFBABA>Steal another player's soul and hide it !</color>";
        public static string Task_Role_Reaper = "<color=#FFBABA>Steal another player's soul and hide it !</color>";

        public static string Task_SaboteurFR = "<color=#FFBABA>Empêche les</color> <color=#87f7f7>coéquipiers</color><color=#FFBABA> de progresser.</color>";
        public static string Task_SaboteurZHCN = "<color=#FFBABA>阻止 <color=#87f7f7>船员们</color><color=#FFBABA> 做任务.</color>";
        public static string Task_SaboteurEN = "<color=#FFBABA>Prevents <color=#87f7f7>Crewmates</color><color=#FFBABA> from progressing.</color>";
        public static string Task_Role_Saboteur = "<color=#FFBABA>Prevents <color=#87f7f7>Crewmates</color><color=#FFBABA> from progressing.</color>";

        //CLIENT
        public static string Client_VerNoStartFR = "Impossible de lancer le jeu";
        public static string Client_VerNoStartZHCN = "无法开始游戏";
        public static string Client_VerNoStartEN = "Unable to start the game";
        public static string Client_VerNoStart = "Unable to start the game";

        public static string Client_VerUpdateFR = "Vous devez mettre à jour votre version du Jeu";
        public static string Client_VerUpdateZHCN = "你需要更新你的游戏版本";
        public static string Client_VerUpdateEN = "You need to update your version of the game";
        public static string Client_VerUpdate = "You need to update your version of the game";

        public static string Client_VerMissFR = "n'est pas executer (ou cette version n'est pas supportée)";
        public static string Client_VerMissZHCN = "未被执行 (或不支持此版本)";
        public static string Client_VerMissEN = "is not executed (or this version is no supported)";
        public static string Client_VerMiss = "is not executed (or this version is no supported)";

        public static string Client_VerDiffFR = "Utilise une version différente";
        public static string Client_VerDiffZHCN = "安装了一个不同的版本";
        public static string Client_VerDiffEN = "has a different version";
        public static string Client_VerDiff = "has a different version";

        //BUTTON
        public static string BTT_EMPTY = "";

        public static string BTT_KillFR = "TUER";
        public static string BTT_KillZHCN = "击杀";
        public static string BTT_KillEN = "KILL";
        public static string BTT_Role_Kill = "KILL";

        public static string BTT_GuardianFR = "BOUCLIER";
        public static string BTT_GuardianZHCN = "护盾";
        public static string BTT_GuardianEN = "SHIELD";
        public static string BTT_Role_Guardian = "SHIELD";

        public static string BTT_EngineerFR = "REPARER";
        public static string BTT_EngineerZHCN = "修复";
        public static string BTT_EngineerEN = "REPAIR";
        public static string BTT_Role_Engineer = "REPAIR";

        public static string BTT_TimelordFR = "STOP";
        public static string BTT_TimelordZHCN = "暂停";
        public static string BTT_TimelordEN = "BREAK";
        public static string BTT_Role_Timelord = "BREAK";

        public static string BTT_HunterFR = "CIBLER";
        public static string BTT_HunterZHCN = "追踪";
        public static string BTT_HunterEN = "TRACK";
        public static string BTT_Role_Hunter = "TRACK";

        public static string BTT_MysticFR = "PROTECTION";
        public static string BTT_MysticZHCN = "护盾";
        public static string BTT_MysticEN = "SELFSHIELD";
        public static string BTT_Role_Mystic = "SELFSHIELD";

        public static string BTT_SpiritFR = "SAB-PORTES";
        public static string BTT_SpiritZHCN = "破坏门";
        public static string BTT_SpiritEN = "SAB-DOOR";
        public static string BTT_Role_Spirit = "SAB-DOOR";

        public static string BTT_MayorFR = "REUNION";
        public static string BTT_MayorZHCN = "会议";
        public static string BTT_MayorEN = "MEETING";
        public static string BTT_Role_Mayor = "MEETING";

        public static string BTT_DetectiveFR = "RECHERCHE";
        public static string BTT_DetectiveZHCN = "搜索";
        public static string BTT_DetectiveEN = "SEARCH";
        public static string BTT_Role_Detective = "SEARCH";

        public static string BTT_NightwatchFR = "LUMIERE";
        public static string BTT_NightwatchZHCN = "执灯";
        public static string BTT_NightwatchEN = "LIGHT";
        public static string BTT_Role_Nightwatch = "LIGHT";

        public static string BTT_SpyFR = "VISION";
        public static string BTT_SpyZHCN = "监视";
        public static string BTT_SpyEN = "SPY";
        public static string BTT_Role_Spy = "SPY";

        public static string BTT_BaitFR = "ZONE ALERT";
        public static string BTT_BaitZHCN = "WARN AREA";
        public static string BTT_BaitEN = "WARN AREA";
        public static string BTT_Role_Bait = "WARN AREA";

        public static string BTT_InformantFR = "VOIR";
        public static string BTT_InformantZHCN = "检查";
        public static string BTT_InformantEN = "CHECK";
        public static string BTT_Role_Informant = "CHECK";

        public static string BTT_MentalistFR = "COULEUR";
        public static string BTT_MentalistZHCN = "变色";
        public static string BTT_MentalistEN = "COLOR";
        public static string BTT_Role_Mentalist = "COLOR";

        public static string BTT_BuilderFR = "SCELLER";
        public static string BTT_BuilderZHCN = "封锁";
        public static string BTT_BuilderEN = "SEAL";
        public static string BTT_Role_Builder = "SEAL";

        public static string BTT_DictatorFR = "VOTEZ!";
        public static string BTT_DictatorZHCN = "无跳过";
        public static string BTT_DictatorEN = "NOSKIP";
        public static string BTT_Role_Dictator = "NOISKIP";

        public static string BTT_SentinelFR = "SCANNER";
        public static string BTT_SentinelZHCN = "扫描";
        public static string BTT_SentinelEN = "SCAN";
        public static string BTT_Role_Sentinel = "SCAN";

        public static string BTT_LeaderFR = "MARQUER";
        public static string BTT_LeaderZHCN = "MARK";
        public static string BTT_LeaderEN = "MARK";
        public static string BTT_Role_Leader = "MARK";

        public static string BTT_TravelerFR = "TELEPORTE";
        public static string BTT_TravelerZHCN = "传送";
        public static string BTT_TravelerEN = "TELEPORT";
        public static string BTT_Role_Traveler = "TELEPORT";

        public static string BTT_Doctor1FR = "SURVEILLER";
        public static string BTT_Doctor1ZHCN = "监视";
        public static string BTT_Doctor1EN = "MONITOR";
        public static string BTT_Role_Doctor1 = "MONITOR";

        public static string BTT_CupidFR = "AMOUR";
        public static string BTT_CupidZHCN = "选择";
        public static string BTT_CupidEN = "LOVE";
        public static string BTT_Role_Cupid = "LOVE";

        public static string BTT_CultistFR = "CONVERSION";
        public static string BTT_CultistZHCN = "转换";
        public static string BTT_CultistEN = "CONVERT";
        public static string BTT_Role_Cultist = "CONVERT";


        public static string BTT_JesterFR = "EFFRAYER";
        public static string BTT_JesterZHCN = "假杀";
        public static string BTT_JesterEN = "FAKEKILL";
        public static string BTT_Role_Jester = "FAKEKILL";

        public static string BTT_EaterEatFR = "DEVORER";
        public static string BTT_EaterEatZHCN = "吞噬";
        public static string BTT_EaterEatEN = "EAT";
        public static string BTT_Role_EaterEat = "EAT";

        public static string BTT_EaterDraggFR = "DEPLACER";
        public static string BTT_EaterDraggZHCN = "拖动";
        public static string BTT_EaterDraggEN = "DRAGG";
        public static string BTT_Role_EaterDragg = "DRAGG";

        public static string BTT_EaterDropFR = "LACHER";
        public static string BTT_EaterDropZHCN = "放下";
        public static string BTT_EaterDropEN = "DROP";
        public static string BTT_Role_EaterDrop = "DROP";

        public static string BTT_ArsonistOilFR = "HUILER";
        public static string BTT_ArsonistOilZHCN = "浇油";
        public static string BTT_ArsonistOilEN = "OIL";
        public static string BTT_Role_ArsonistOil = "OIL";

        public static string BTT_ArsonistBurnFR = "BRULER";
        public static string BTT_ArsonistBurnZHCN = "点燃";
        public static string BTT_ArsonistBurnEN = "Burn";
        public static string BTT_Role_ArsonistBurn = "BURN";

        public static string BTT_CursedFR = "ABRI";
        public static string BTT_CursedZHCN = "庇护";
        public static string BTT_CursedEN = "SHELTER";
        public static string BTT_Role_Cursed = "SHELTER";


        public static string BTT_CopyCatFR = "COPIER";
        public static string BTT_CopyCatZHCN = "回忆";
        public static string BTT_CopyCatEN = "COPY";
        public static string BTT_Role_CopyCat = "COPY";


        public static string BTT_RevengerFR = "IEM";
        public static string BTT_RevengerZHCN = "电磁";
        public static string BTT_RevengerEN = "EMP";
        public static string BTT_Role_Revenger = "EMP";

        public static string BTT_VectorFR = "INFECTER";
        public static string BTT_VectorZHCN = "感染";
        public static string BTT_VectorEN = "INFECT";
        public static string BTT_Role_Vector = "INFECT";

        public static string BTT_MorphlingStealFR = "VOLER ADN";
        public static string BTT_MorphlingStealZHCN = "取样";
        public static string BTT_MorphlingStealEN = "STEAL DNA";
        public static string BTT_Role_MorphlingSteal = "STEAL DNA";

        public static string BTT_MorphlingMorphFR = "METAMORPHOSE";
        public static string BTT_MorphlingMorphZHCN = "化形";
        public static string BTT_MorphlingMorphEN = "MORPH";
        public static string BTT_Role_MorphlingMorph = "MORPH";


        public static string BTT_ScramblerFR = "BROUILLAGE";
        public static string BTT_ScramblerZHCN = "隐蔽";
        public static string BTT_ScramblerEN = "CAMO";
        public static string BTT_Role_Scrambler = "CAMO";

        public static string BTT_BarghestShadowFR = "TENEBRE";
        public static string BTT_BarghestShadowZHCN = "降低视野";
        public static string BTT_BarghestShadowEN = "SHADOW";
        public static string BTT_Role_BarghestShadow = "SHADOW";

        public static string BTT_BarghestVentFR = "CREE VENT";
        public static string BTT_BarghestVentZHCN = "创建管道";
        public static string BTT_BarghestVentEN = "CREATE VENT";
        public static string BTT_Role_BarghestVent = "CREATE VENT";

        public static string BTT_GhostFR = "INVISIBLE";
        public static string BTT_GhostZHCN = "隐藏";
        public static string BTT_GhostEN = "HIDE";
        public static string BTT_Role_Ghost = "HIDE";

        public static string BTT_SorcererFR = "DETRUIRE";
        public static string BTT_SorcererZHCN = "摧毁";
        public static string BTT_SorcererEN = "DESTROY";
        public static string BTT_Role_Sorcerer = "DESTROY";

        public static string BTT_SorcererFindFR = "RECHERCHER";
        public static string BTT_SorcererFindZHCN = "查找";
        public static string BTT_SorcererFindEN = "FIND";
        public static string BTT_Role_SorcererFind = "FIND";

        public static string BTT_Sorcerer1FR = "FOCALISATION";
        public static string BTT_Sorcerer1ZHCN = "聚焦";
        public static string BTT_Sorcerer1EN = "FOCUS";
        public static string BTT_Role_Sorcerer1 = "FOCUS";

        public static string BTT_Sorcerer2FR = "VISION";
        public static string BTT_Sorcerer2ZHCN = "幻象";
        public static string BTT_Sorcerer2EN = "VISION";
        public static string BTT_Role_Sorcerer2 = "VISION";

        public static string BTT_Sorcerer3FR = "CONFUSION";
        public static string BTT_Sorcerer3ZHCN = "迷惑";
        public static string BTT_Sorcerer3EN = "CONFUSE";
        public static string BTT_Role_Sorcerer3 = "CONFUSE";

        public static string BTT_MesmerTargetFR = "CIBLER";
        public static string BTT_MesmerTargetZHCN = "选择目标";
        public static string BTT_MesmerTargetEN = "TARGET";
        public static string BTT_Role_MesmerTarget = "TARGET";

        public static string BTT_MesmerMcFR = "CONTROLER";
        public static string BTT_MesmerMcZHCN = "头脑操控";
        public static string BTT_MesmerMcEN = "MIND CONTROL";
        public static string BTT_Role_MesmerMc = "MIND CONTROL";

        public static string BTT_BasiliskFR = "PARALYSER";
        public static string BTT_BasiliskZHCN = "麻痹";
        public static string BTT_BasiliskEN = "PARALYZE";
        public static string BTT_Role_Basilisk = "PARALYZE";

        public static string BTT_Basilisk2FR = "PETRIFIER";
        public static string BTT_Basilisk2ZHCN = "石化";
        public static string BTT_Basilisk2EN = "PETRIFY";
        public static string BTT_Role_Basilisk2 = "PETRIFY";

        public static string BTT_ReaperTakeFR = "VOLER";
        public static string BTT_ReaperTakeZHCN = "偷窃";
        public static string BTT_ReaperTakeEN = "STEAL";
        public static string BTT_Role_ReaperTake = "STEAL";

        public static string BTT_ReaperDropFR = "POSER";
        public static string BTT_ReaperDropZHCN = "移动灵魂";
        public static string BTT_ReaperDropEN = "DROP SOUL";
        public static string BTT_Role_ReaperDrop = "DROP SOUL";

        public static string BTT_SaboteurFR = "PERTURBER";
        public static string BTT_SaboteurZHCN = "缓速";
        public static string BTT_SaboteurEN = "SLOW";
        public static string BTT_Role_Saboteur = "SLOW";

        public static string BTT_ScanBodyFR = "CADAVRE";
        public static string BTT_ScanBodyZHCN = "尸体";
        public static string BTT_ScanBodyEN = "DEADBODY";
        public static string BTT_ScanBody = "DEADBODY";

        public static string BTT_ADMINFR = "ADMIN";
        public static string BTT_ADMINZHCN = "ADMIN";
        public static string BTT_ADMINEN = "ADMIN";
        public static string BTT_ADMIN = "ADMIN";

        public static string BTT_CAMFR = "CAMERA";
        public static string BTT_CAMZHCN = "CAMERA";
        public static string BTT_CAMEN = "CAMERA";
        public static string BTT_CAM = "CAMERA";

        public static string BTT_VITALFR = "VITALE";
        public static string BTT_VITALZHCN = "VITAL";
        public static string BTT_VITALEN = "VITAL";
        public static string BTT_VITAL = "VITAL";

        public static string BTT_BUZZFR = "BUZZ";
        public static string BTT_BUZZZHCN = "BUZZ";
        public static string BTT_BUZZEN = "BUZZ";
        public static string BTT_BUZZ = "BUZZ";

        public static string BTT_VENTFR = "CONDUIT";
        public static string BTT_VENTZHCN = "VENT";
        public static string BTT_VENTEN = "VENT";
        public static string BTT_VENT = "VENT";

        public static string BTT_ReadyFR = "Je suis prêt !";
        public static string BTT_ReadyZHCN = "我准备好了 !";
        public static string BTT_ReadyEN = "I'm ready !";
        public static string BTT_Ready = "I'm ready !";

        public static string TXT_BuzzFR = "Les radiations bloque l'utilisation du Bouton...";
        public static string TXT_BuzzZHCN = "辐射使你无法按下按钮...";
        public static string TXT_BuzzEN = "Radiation keeps you from pressing the button...";
        public static string TXT_Buzz = "Radiation keeps you from pressing the button...";

        public static string TXT_LawSuspectFR = " Liste des joueurs suspects = ";
        public static string TXT_LawSuspectZHCN = " 可疑人员名单 = ";
        public static string TXT_LawSuspectEN = " List of suspected players = ";
        public static string TXT_LawSuspect = " List of suspected players = ";

        public static string TXT_LawKillerdieFR = " Le tueur est mort";
        public static string TXT_LawKillerdieZHCN = " 凶手已死亡";
        public static string TXT_LawKillerdieEN = " The killer is dead";
        public static string TXT_LawKillerdie = " The killer is dead";

        public static string TXT_LawKillerFR = " Nom du tueur = ";
        public static string TXT_LawKillerZHCN = " 凶手姓名 = ";
        public static string TXT_LawKillerEN = " Killer Name = ";
        public static string TXT_LawKiller = " Killer Name = ";

        //Kill
        public static string TXT_Deathreason0FR = "Rien à Signaler";
        public static string TXT_Deathreason0ZHCN = "没有尸体可用于报告";
        public static string TXT_Deathreason0EN = "Nothing to report";
        public static string TXT_Deathreason0 = "Nothing to report";

        //Suicide
        public static string TXT_Deathreason1FR = "Cela ressemble a un suicide";
        public static string TXT_Deathreason1ZHCN = "看起来像自杀";
        public static string TXT_Deathreason1EN = "It looks like a suicide";
        public static string TXT_Deathreason1 = "It looks like a suicide";

        //Lover
        public static string TXT_Deathreason2FR = "Son coeur semble brisé.";
        public static string TXT_Deathreason2ZHCN = "它的心碎了一地.";
        public static string TXT_Deathreason2EN = "Her heart seems broken.";
        public static string TXT_Deathreason2 = "Her heart seems broken.";

        //Track
        public static string TXT_Deathreason3FR = "Un mouchard sur lui semble l'avoir tué.";
        public static string TXT_Deathreason3ZHCN = "一个线人似乎要了他的命.";
        public static string TXT_Deathreason3EN = "A snitch on him seems to have killed him.";
        public static string TXT_Deathreason3 = "A snitch on him seems to have killed him.";

        //Vector
        public static string TXT_Deathreason4FR = "Il semble avoir été infecté par un virus.";
        public static string TXT_Deathreason4ZHCN = "它看起来因病而亡.";
        public static string TXT_Deathreason4EN = "It seems to have been infected with a virus.";
        public static string TXT_Deathreason4 = "It seems to have been infected with a virus.";

        //Other
        public static string TXT_Deathreason5FR = "C'est une mort étrange";
        public static string TXT_Deathreason5ZHCN = "它死得很奇怪.";
        public static string TXT_Deathreason5EN = "It's a strange death.";
        public static string TXT_Deathreason5 = "It's a strange death.";

        public static string SG_ReadyFR = "\n<color=#00FF00><size=1.4>(Prêt)</size></color>";
        public static string SG_ReadyZHCN = "\n<color=#00FF00><size=1.4>(准备好)</size></color>";
        public static string SG_ReadyEN = "\n<color=#00FF00><size=1.4>(Ready)</size></color>";
        public static string SG_Ready = "\n<color=#00FF00><size=1.4>(Ready)</size></color>";

        public static string SCROLLFR = "Faites défiler le texte avec la molette de la sourie si besoin";
        public static string SCROLLZHCN = "Scroll the text with the mouse wheel if necessary";
        public static string SCROLLEN = "Scroll the text with the mouse wheel if necessary";
        public static string SCROLL = "Scroll the text with the mouse wheel if necessary";

        

        public static Dictionary<GameObject, float> dots = new Dictionary<GameObject, float>();

        public static void Postfix(HudManager __instance)
        {
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {
                if (__instance.GameSettings != null) { __instance.GameSettings.text = " "; }
            }
            else {

                if (__instance.GameSettings != null && !__instance.GameSettings.text.Contains("CHALLENGER"))
                {

                    __instance.GameSettings.text = "<size=3.2><color=#EC7C18>CHALLENGER</color></size><size=0.85>\n\n<color=#FF6666>(" + SCROLL +")</color></size> ";


                    {

                        //LIST MAIN
                        string MainSet = "<color=#EC7C18>\n\n<size=1>[Game Settings]</size></color><color=#FF6666><size=0.85> - (Press F1 to Hide)</size>\n</color><size=0.75>";
                        string MainSetFR = "<color=#EC7C18>\n\n<size=1>[Options General]</size></color><color=#FF6666><size=0.85> - (Appuyez sur F1 pour Masquer)</size>\n</color><size=0.75>";
                        string MainSetZHCN = "<color=#EC7C18>\n\n<size=1>[游戏设置]</size></color><color=#FF6666><size=0.85> - (Press F1 to Hide)</size>\n</color><size=0.75>";

                        string TABMainSet = "<color=#EC7C18>\n\n<size=1>[Game Settings]</size></color><color=#FF6666><size=0.85> - (Press F1 for Show)</size>\n</color><size=0.75>";
                        string TABMainSetFR = "<color=#EC7C18>\n\n<size=1>[Options General]</size></color><color=#FF6666><size=0.85> - (Appuyez sur F1 pour Afficher)</size>\n</color><size=0.75>";
                        string TABMainSetZHCN = "<color=#EC7C18>\n\n<size=1>[游戏设置]</size></color><color=#FF6666><size=0.85> - (Press F1 for Show)</size>\n</color><size=0.75>";



                        ChallengerMod.Challenger.STRGamecode = "" + GameStartManager.Instance.GameRoomNameCode.text.Substring(6);


                        if (PlayerControl.GameOptions.MapId == 0)
                        {


                            if (BetterMapSK.getSelection() == 1)
                            {
                                MainSet += "\nMap = <color=#FF00FF>The Skeld (Challenger Skeld - By Lunastellia)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>The Skeld (Challenger Skeld - Par Lunastellia)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>The Skeld (挑战者 Skeld - 作者 Lunastellia)</color>";

                                ChallengerMod.Challenger.STRMap = "The Skeld Better";
                            }
                            if (BetterMapSK.getSelection() == 0)
                            {
                                MainSet += "\nMap = <color=#FF00FF>The Skeld (Normal)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>The Skeld (Normal)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>The Skeld (正常)</color>";

                                ChallengerMod.Challenger.STRMap = "The Skeld Normal";
                            }
                        }
                        else if (PlayerControl.GameOptions.MapId == 1)
                        {
                            if (BetterMapHQ.getSelection() == 1)
                            {
                                MainSet += "\nMap = <color=#FF00FF>MiraHQ (Challenger Mira - By Lunastellia)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>MiraHQ (Challenger Mira - Par Lunastellia)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Mira HQ (挑战者Mira - 作者 Lunastellia)</color>";

                                MainSet += ", Camera-Drone Speed = <color=#FFFF00>x" + DroneSpeed.getFloat() + "</color>.";
                                MainSetFR += ", Vitesse du drone camera = <color=#FFFF00>x" + DroneSpeed.getFloat() + "</color>.";
                                MainSetZHCN += ", Camera-Drone Speed = <color=#FFFF00>x" + DroneSpeed.getFloat() + "</color>.";



                                ChallengerMod.Challenger.STRMap = "Mira Challenger";
                            }
                            if (BetterMapHQ.getSelection() == 0)
                            {
                                MainSet += "\nMap = <color=#FF00FF>MiraHQ (Normal)</color>";
                                MainSetFR += "\nCarteap = <color=#FF00FF>MiraHQ (Normal)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Mira HQ (正常)</color>";

                                ChallengerMod.Challenger.STRMap = "Mira Normal";
                            }
                        }
                        else if (PlayerControl.GameOptions.MapId == 2)
                        {
                            if (BetterMapPL.getSelection() == 2 && NuclearTimerMod.getBool() == true)
                            {
                                MainSet += "\nMap = <color=#FF00FF>Polus (Challenger Polus +Nuclear  - By Lunastellia)</color>, Nuclear Spawn chance: <color=#FF00FF>" + NuclearRND.getFloat() + "%</color>.";
                                MainSetFR += "\nCarte = <color=#FF00FF>Polus (Challenger Polus +Nucléaire  - Par Lunastellia)</color> Chance d'apparition (Nuclear) : <color=#FF00FF>" + NuclearRND.getFloat() + "%</color>.";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Polus (挑战者Polus + 核弹 - 作者 Lunastellia)</color>, 核弹生成几率: <color=#FF00FF>" + NuclearRND.getFloat() + "%</color>.";


                                if (NuclearTimeRND.getFloat() == 0f)
                                {
                                    MainSet += "\nChallenge Polus Nuclear timer = <color=#FFFF00>" + NuclearTime1.getFloat() + "s</color>, Alerte Duration = <color=#FF0000>" + NuclearTime2.getFloat() + "s</color>,";
                                    MainSetFR += "\nChallenge Polus Nucléaire Compte à rebour = <color=#FFFF00>" + NuclearTime1.getFloat() + "s</color>, Durée de l'alerte = <color=#FF0000>" + NuclearTime2.getFloat() + "s</color>,";
                                    MainSetZHCN += "\n挑战者 Polus 核弹倒计时 = <color=#FFFF00>" + NuclearTime1.getFloat() + "秒</color>, 警报持续时间 = <color=#FF0000>" + NuclearTime2.getFloat() + "秒</color>,";

                                }
                                else
                                {
                                    MainSet += "\nChallenge Polus Nuclear timer = <color=#FFFF00>" + NuclearTime1.getFloat() + " ~ " + (NuclearTime1.getFloat() + NuclearTimeRND.getFloat()) + "</color>, Alerte Duration = <color=#FF0000>" + NuclearTime2.getFloat() + "s</color>,";
                                    MainSetFR += "\nChallenge Polus Nucléaire Compte à rebour = <color=#FFFF00>" + NuclearTime1.getFloat() + " ~ " + (NuclearTime1.getFloat() + NuclearTimeRND.getFloat()) + "</color>, Durée de l'alerte = <color=#FF0000>" + NuclearTime2.getFloat() + "s</color>,";
                                    MainSetZHCN += "\n挑战者 Polus 核弹倒计时 = <color=#FFFF00>" + NuclearTime1.getFloat() + " ~ " + (NuclearTime1.getFloat() + NuclearTimeRND.getFloat()) + "</color>, 警报持续时间 = <color=#FF0000>" + NuclearTime2.getFloat() + "秒</color>,";

                                }

                                if (NuclearHide.getSelection() == 0)
                                {
                                    MainSet += " Timer visibility : <color=#ff0000>No</color>.";
                                    MainSetFR += "Compteur visible : <color=#ff0000>Non</color>.";
                                    MainSetZHCN += " Timer visibility : <color=#ff0000>No</color>.";
                                }
                                if (NuclearHide.getSelection() == 1)
                                {
                                    MainSet += " Timer visibility : <color=#00ff00>Yes</color>.";
                                    MainSetFR += "Compteur visible : <color=#00ff00>Yes</color>.";
                                    MainSetZHCN += " Timer visibility : <color=#00ff00>Yes</color>.";

                                }
                                if (NuclearHide.getSelection() == 2)
                                {
                                    MainSet += " Timer visibility : <color=#ff00ff>Only impostors</color>.";
                                    MainSetFR += "Compteur visible : <color=#ff00ff>Uniquement les imposteurs</color>.";
                                    MainSetZHCN += " Timer visibility : <color=#ff00ff>Only impostors</color>.";

                                }

                                ChallengerMod.Challenger.STRMap = "Polus Challenger Nuclear";
                            }
                            if (BetterMapPL.getSelection() == 2 && NuclearTimerMod.getBool() == false)
                            {
                                MainSet += "\nMap = <color=#FF00FF>Polus (Challenger Polus  - By Lunastellia)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>Polus (Challenger Polus  - Par Lunastellia)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Polus (挑战者Polus  - 作者 Lunastellia)</color>";

                                ChallengerMod.Challenger.STRMap = "Polus Challenger";
                            }
                            if (BetterMapPL.getSelection() == 1)
                            {
                                MainSet += "\nMap = <color=#FF00FF>Polus (BetterPolus - By BryBry)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>Polus (BetterPolus - Par BryBry)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Polus (更好的Polus - 作者 BryBry)</color>";

                                ChallengerMod.Challenger.STRMap = "Polus Better";
                            }
                            if (BetterMapPL.getSelection() == 0)
                            {
                                MainSet += "\nMap = <color=#FF00FF>Polus (Normal)</color>";
                                MainSetFR += "\nCarte = <color=#FF00FF>Polus (Normal)</color>";
                                MainSetZHCN += "\n地图 = <color=#FF00FF>Polus (正常)</color>";

                                ChallengerMod.Challenger.STRMap = "Polus Normal";
                            }
                        }
                        else if (PlayerControl.GameOptions.MapId == 3)
                        {
                            MainSet += "\nMap = <color=#FF00FF>Skeld 1 Avril</color>";
                            MainSetFR += "\nCarte = <color=#FF00FF>Skeld 1 Avril</color>";
                            MainSetZHCN += "\n地图 = <color=#FF00FF>愚人节Skeld</color>";

                            ChallengerMod.Challenger.STRMap = "dlekS ehT";
                        }

                        else if (PlayerControl.GameOptions.MapId == 4)

                        {
                            MainSet += "\nMap = <color=#FF00FF>Airship</color>";
                            MainSetFR += "\nCarte = <color=#FF00FF>Airship</color>";
                            MainSetZHCN += "\n地图 = <color=#FF00FF>Airship</color>";

                            ChallengerMod.Challenger.STRMap = "Airship Normal";
                        }
                        else
                        {

                            MainSet += "\nMap = <color=#FF00FF>Submerged (Team PolusGG - By 5up)</color>";
                            MainSetFR += "\nCarte = <color=#FF00FF>Submerged (Equipe PolusGG - Par 5up)</color>";
                            MainSetZHCN += "\n地图 = <color=#FF00FF>潜艇 (PolusGG 团队 - 作者 5up)</color>";

                            ChallengerMod.Challenger.STRMap = "Submerged";
                        }



                        if (PlayerControl.GameOptions.NumImpostors == 1)

                        {
                            if (AmongUsClient.Instance.allClients.Count <= 3)
                            {
                                MainSet += "\nPlayers = (No enough players)";
                                MainSetFR += "\nJoueurs = (Pas assés de joueurs)";
                                MainSetZHCN += "\n玩家设置 = (没有足够的玩家)";

                                RealImpostor = 0f;
                            }
                            else
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color>, Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color>, Coéquipier ou rôle Special/hybride : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color>, 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                        }

                        if (PlayerControl.GameOptions.NumImpostors == 2)

                        {
                            if (AmongUsClient.Instance.allClients.Count <= 3)
                            {
                                MainSet += "\nPlayers = (No enough players)";
                                MainSetFR += "\nJoueurs = (Pas assés de joueurs)";
                                MainSetZHCN += "\n玩家设置 = (没有足够的玩家)";

                                RealImpostor = 0f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 4)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 7 or more players to put 2 Impostors), Crewmates or Special/Hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 7 joueurs minimum pour jouer avec 2 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有7个或更多玩家才能使内鬼数为2), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 5)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 7 or more players to put 2 Impostors), Crewmates or Special/Hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 7 joueurs minimum pour jouer avec 2 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有7个或更多玩家才能使内鬼数为2), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 6)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 7 or more players to put 2 Impostors), Crewmates or Special role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 7 joueurs minimum pour jouer avec 2 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有7个或更多玩家才能使内鬼数为2), 船员 或 特殊职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count >= 7)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color>, Crewmates or Special/Hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color>, Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color>, 船员 或 特殊职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }


                        }
                        if (PlayerControl.GameOptions.NumImpostors == 3)

                        {

                            if (AmongUsClient.Instance.allClients.Count <= 3)
                            {
                                MainSet += "\nPlayers = (No enough players)";
                                MainSetFR += "\nJoueurs = (Pas assés de joueurs)";
                                MainSetZHCN += "\n玩家设置 = (没有足够的玩家)";

                                RealImpostor = 0f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 4)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000></color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 5)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";


                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 6)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";


                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 7)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 8)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 9)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 10 or more players to put 3 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 10 joueurs minimum pour jouer avec 3 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有10个或更多玩家才能使内鬼数为3), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count >= 10)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>3</color>, Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>3</color> , Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSet += "\n玩家设置 = 内鬼数 : <color=#FF0000>3</color>, 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";

                                RealImpostor = 3f;
                            }

                        }
                        if (PlayerControl.GameOptions.NumImpostors == 4)

                        {

                            if (AmongUsClient.Instance.allClients.Count <= 3)
                            {
                                MainSet += "\nPlayers = (No enough players)";
                                MainSetFR += "\nJoueurs = (Pas assés de joueurs)";
                                MainSetZHCN += "\n玩家设置 = (没有足够的玩家)";
                                RealImpostor = 0f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 4)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数 : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";

                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 5)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>1</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>1</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 1) + "</color>";

                                RealImpostor = 1f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 6)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>1</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 7)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 8)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 9)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 2) + "</color>";

                                RealImpostor = 2f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 10)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";

                                RealImpostor = 3f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 11)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";

                                RealImpostor = 3f;
                            }
                            if (AmongUsClient.Instance.allClients.Count == 12)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>2</color> (You must be 13 or more players to put 4 Impostors), Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>2</color> (Vous devez être 13 joueurs minimum pour jouer avec 4 imposteurs), Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>2</color> (必须有13个或更多玩家才能使内鬼数为4), 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 3) + "</color>";

                                RealImpostor = 3f;
                            }
                            if (AmongUsClient.Instance.allClients.Count >= 13)
                            {
                                MainSet += "\nPlayers = Impostors : <color=#FF0000>4</color>, Crewmates or Special/hybrid role : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 4) + "</color>";
                                MainSetFR += "\nJoueurs = Imposteurs : <color=#FF0000>4</color> , Coéquipier ou rôle Special/Hybrid : <color=#00FFFF>" + (AmongUsClient.Instance.allClients.Count - 4) + "</color>";
                                MainSetZHCN += "\n玩家设置 = 内鬼数 : <color=#FF0000>4</color>, 船员 或 特殊/混合职业数" + (AmongUsClient.Instance.allClients.Count - 4) + "</color>";

                                RealImpostor = 4f;
                            }

                        }


                        MainSet += "\nPlayers Settings = Speed : <color=#FF00FF>" + (PlayerControl.GameOptions.PlayerSpeedMod * 100) + "%</color>, Crewmates vision : <color=#00FFFF>" + (PlayerControl.GameOptions.CrewLightMod * 100) + "%</color>, Impostors vision : <color=#FF0000>" + (PlayerControl.GameOptions.ImpostorLightMod * 100) + "%</color>.";
                        MainSetFR += "\nParamètres des Joueurs = Vitesse : <color=#FF00FF>" + (PlayerControl.GameOptions.PlayerSpeedMod * 100) + "%</color>, Vision des Coéquipiers : <color=#00FFFF>" + (PlayerControl.GameOptions.CrewLightMod * 100) + "%</color>, Vision des Imposteurs : <color=#FF0000>" + (PlayerControl.GameOptions.ImpostorLightMod * 100) + "%</color>.";
                        MainSetZHCN += "\n玩家设置 = 速度 : <color=#FF00FF>" + (PlayerControl.GameOptions.PlayerSpeedMod * 100) + "%</color>, 船员视野 : <color=#00FFFF>" + (PlayerControl.GameOptions.CrewLightMod * 100) + "%</color>, 内鬼视野 : <color=#FF0000>" + (PlayerControl.GameOptions.ImpostorLightMod * 100) + "%</color>.";

                        if (PlayerControl.GameOptions.AnonymousVotes == true)
                        {
                            if (PlayerControl.GameOptions.ConfirmImpostor == true)
                            {
                                if (BuzzCommon.getSelection() == 1)
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#00FF00>Yes</color>, Confirm Eject : <color=#00FF00>Yes</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (To Share)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#00FF00>Oui</color>, Rôles indiqués en cas d'exil : <color=#00FF00>Oui</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Partager)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>是</color>, 确认驱逐身份 : <color=#00FF00>是</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (共享)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote  : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }
                                else
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#00FF00>Yes</color>, Confirm Eject : <color=#00FF00>Yes</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Per Player)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#00FF00>Oui</color>, Rôles indiqués en cas d'exil : <color=#00FF00>Oui</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Par Joueur Player)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>是</color>, 确认驱逐身份 : <color=#00FF00>是</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (每名玩家)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote  : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }


                            }
                            else
                            {
                                if (BuzzCommon.getSelection() == 1)
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#00FF00>Yes</color>, Confirm Eject : <color=#FF0000>No</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (To Share)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#00FF00>Oui</color>, Rôles indiqués en cas d'exil : <color=#FF0000>Non</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Partager)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>是</color>, 确认驱逐身份 : <color=#00FF00>否</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (共享)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }
                                else
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#00FF00>Yes</color>, Confirm Eject : <color=#FF0000>No</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Per Player)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#00FF00>Oui</color>, Rôles indiqués en cas d'exil : <color=#FF0000>Non</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Par Joueur)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>是</color>, 确认驱逐身份 : <color=#00FF00>否</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (每名玩家)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }



                            }

                        }
                        else
                        {
                            if (PlayerControl.GameOptions.ConfirmImpostor == true)
                            {
                                if (BuzzCommon.getSelection() == 1)
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#FF0000>No</color>, Confirm Eject : <color=#00FF00>Yes</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (To Share)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#FF0000>Non</color>, Rôles indiqués en cas d'exil : <color=#00FF00>Oui</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Partager)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>否</color>, 确认驱逐身份 : <color=#00FF00>是</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (共享)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote  : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }
                                else
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#FF0000>No</color>, Confirm Eject : <color=#00FF00>Yes</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Per Player)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#FF0000>Non</color>, Rôles indiqués en cas d'exil : <color=#00FF00>Oui</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Par Joueur)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>否</color>, 确认驱逐身份 : <color=#00FF00>是</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (每名玩家)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote  : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }


                            }
                            else
                            {
                                if (BuzzCommon.getSelection() == 1)
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#FF0000>No</color>, Confirm Eject : <color=#FF0000>No</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (To Share)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#FF0000>Non</color>, Rôles indiqués en cas d'exil : <color=#FF0000>Non</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Partager)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>否</color>, 确认驱逐身份 : <color=#00FF00>否</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (共享)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }
                                else
                                {
                                    MainSet += "\nMeeting = Anonymous votes : <color=#FF0000>No</color>, Confirm Eject : <color=#FF0000>No</color> Emergency meeting : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Per Player)</color>.";
                                    MainSetFR += "\nRéunion = Votes Anonymes : <color=#FF0000>Non</color>, Rôles indiqués en cas d'exil : <color=#FF0000>Non</color> Réunion d'urgence : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (Par Joueur)</color>.";
                                    MainSetZHCN += "\n会议设置 = 匿名投票 : <color=#00FF00>否</color>, 确认驱逐身份 : <color=#00FF00>否</color> 紧急会议数 : <color=#FF00FF>x" + PlayerControl.GameOptions.NumEmergencyMeetings + "</color><color=#ff00ff> (每名玩家)</color>.";

                                    MainSet += "\nMeeting Timer = Emergency coolcown : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Discution Time : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Voting Time : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetFR += "\nTemps de réunion = Délai de Réunion d'urgence : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "s</color>, Durée de Discution  : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "s</color>, Durée de Vote : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "s</color>.";
                                    MainSetZHCN += "\n会议时间 = 紧急会议冷却 : <color=#FF00FF>" + PlayerControl.GameOptions.EmergencyCooldown + "秒</color>, 讨论时间 : <color=#FF00FF>" + PlayerControl.GameOptions.DiscussionTime + "秒</color>, 投票时间 : <color=#FF00FF>" + PlayerControl.GameOptions.VotingTime + "秒</color>.";

                                }

                            }
                        }



                        if (PlayerControl.GameOptions.VisualTasks == true)
                        {
                            MainSet += "\nPlayers Task = Visual task : <color=#00FF00>Enable</color>, TaskBar Update : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";
                            MainSetFR += "\nTâches = Tâches Visuelles : <color=#00FF00>Activé</color>, Mise à jour de la barre des Tâches : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";
                            MainSetZHCN += "\n玩家任务设置 = 可视任务 : <color=#00FF00>开</color>, 任务条更新频率 : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";

                        }
                        else
                        {
                            MainSet += "\nPlayers Task = Visual task : <color=#FF0000>Disabled</color>, TaskBar Update : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";
                            MainSetFR += "\nTâches = Tâches Visuelles : <color=#FF0000>Désactivé</color>, Mise à jour de la barre des Tâches : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";
                            MainSetZHCN += "\n玩家任务设置 = 可视任务 : <color=#00FF00>关</color>, 任务条更新频率 : <color=#FF00FF>" + PlayerControl.GameOptions.TaskBarMode + "</color>.";

                        }

                        MainSet += "\nNumber Task = Common task : <color=#FF00FF>" + PlayerControl.GameOptions.NumCommonTasks + "</color>, Long task : <color=#FF00FF>" + PlayerControl.GameOptions.NumLongTasks + "</color>, short task : <color=#FF00FF>" + PlayerControl.GameOptions.NumShortTasks + "</color>. Better Task :";
                        MainSetFR += "\nNombres de Tâches = Tâches Communes : <color=#FF00FF>" + PlayerControl.GameOptions.NumCommonTasks + "</color>, Tâches Longues : <color=#FF00FF>" + PlayerControl.GameOptions.NumLongTasks + "</color>, Tâches Courtes : <color=#FF00FF>" + PlayerControl.GameOptions.NumShortTasks + "</color>. Tâches améliorées :";
                        MainSetZHCN += "\n任务数设置 = 共同任务 : <color=#FF00FF>" + PlayerControl.GameOptions.NumCommonTasks + "</color>, 长任务数 : <color=#FF00FF>" + PlayerControl.GameOptions.NumLongTasks + "</color>, 短任务数 : <color=#FF00FF>" + PlayerControl.GameOptions.NumShortTasks + "</color>. 更好的任务 :";


                        if (BetterTaskWeapon.getBool() == false && BetterTaskWire.getBool() == false)
                        {
                            MainSet += " <color=#ff0000>No</color>";
                            MainSetFR += " <color=#ff0000>Non</color>";
                            MainSetZHCN += " <color=#ff0000>否</color>";

                        }
                        if (BetterTaskWire.getBool() == true)
                        {
                            MainSet += " - Wire";
                            MainSetFR += " - Fils Electrique";
                            MainSetZHCN += " - 连电线";

                        }
                        if (BetterTaskWeapon.getBool() == true)
                        {
                            MainSet += " - Weapon";
                            MainSetFR += " - Astéroïdes";
                            MainSetZHCN += " - 打陨石";

                        }
                        MainSet += ".";
                        MainSetFR += ".";
                        MainSetZHCN += ".";




                        if (Challenger.Setting_TabGen == "0")
                        {


                            if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += TABMainSetFR;
                            }
                            else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += TABMainSetZHCN;
                            }
                            else
                            {
                                __instance.GameSettings.text += TABMainSet;
                            }
                        }
                        else
                        {


                            if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += MainSetFR;
                            }
                            else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += MainSetZHCN;
                            }
                            else
                            {
                                __instance.GameSettings.text += MainSet;
                            }
                        }


                        //UNKNOWIMPOSTORS
                        string UIP = "\n<size=0.75>Impostors = ";
                        string UIPFR = "\n<size=0.75>Imposteurs = ";
                        string UIPZHCN = "\n<size=0.75>内鬼设置 = ";


                        if (ImpostorsKnowEachother.getBool() == true)
                        {
                            UIP += "Unknow : <color=#00FF00>Enable</color>, Can kill Each Other : <color=#00FF00>Enable</color>. Kill Cooldown : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, to <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> Yard.";
                            UIPFR += "Ne se connaissent pas : <color=#00FF00>Activé</color>, Peuvent s'entretuer : <color=#00FF00>Oui</color>. Délai Pour Tuer : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, à une distance de <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> mètres.";
                            UIPZHCN += "互相不知道 : <color=#00FF00>开</color>, 可以互相击杀 : <color=#00FF00>开</color>. 击杀冷却 : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "秒</color>, 击杀距离： <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color>.";

                        }
                        if (ImpostorsKnowEachother.getBool() == false)
                        {
                            if (ImpostorCanKillFake.getBool() == true && (FakeAdd.getBool() == true) && (FakeSpawnChance.getFloat() > 0))
                            {
                                UIP += "  Unknow : <color=#FF0000>Disable</color>, Can kill Each Other : <color=#00FF00>Yes (If The Fake Spawn)</color>. Kill Cooldown : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, to <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> Yard.";
                                UIPFR += "  Ne se connaissent pas : <color=#FF0000>Désactivé</color>, Peuvent s'entretuer : <color=#00FF00>Oui (Si l'intru est présent)</color>. Délai Pour Tuer : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, à une distance de <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> mètres.";
                                UIPZHCN += "互相不知道 : <color=#00FF00>关</color>, 可以互相击杀 : <color=#00FF00>开（如果存在卧底）</color>. 击杀冷却 : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "秒</color>, 击杀距离： <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color>.";

                            }
                            else
                            {
                                UIP += "  Unknow : <color=#FF0000>Disable</color>, Can kill Each Other : <color=#FF0000>No</color>. Kill Cooldown : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, to <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> Yard.";
                                UIPFR += "  Ne se connaissent pas : <color=#FF0000>Désactivé</color>, Peuvent s'entretuer : <color=#FF0000>Non</color>. Délai Pour Tuer : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "s</color>, à une distance de <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color> mètres.";
                                UIPZHCN += "互相不知道 : <color=#00FF00>关</color>, 可以互相击杀 : <color=#00FF00>关</color>. 击杀冷却 : <color=#00FFFF>" + PlayerControl.GameOptions.KillCooldown + "秒</color>, 击杀距离： <color=#FF00FF>" + (PlayerControl.GameOptions.KillDistance + 1) + "</color>.";

                            }
                        }
                        if (Challenger.Setting_TabGen == "1")
                        {
                            if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += UIPFR;
                            }
                            else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                            {
                                __instance.GameSettings.text += UIPZHCN;
                            }
                            else
                            {
                                __instance.GameSettings.text += UIP;
                            }
                        }

                        //LIST LOBBY
                        string LobbySets = "<color=#EC7C18>\n\n<size=1>[Lobby Settings]</size></color><color=#FF6666><size=0.85> - (Press F2 to Hide)</size>\n</color>";
                        string LobbySetsFR = "<color=#EC7C18>\n\n<size=1>[Option de Jeu]</size></color><color=#FF6666><size=0.85> - (Appuyez sur F2 pour Masquer)</size>\n</color>";
                        string LobbySetsZHCN = "<color=#EC7C18>\n\n<size=1>[大厅设置]</size></color><color=#FF6666><size=0.85> - (Press F2 to Hide)</size>\n</color>";

                        string TABLobbySets = "<color=#EC7C18>\n\n<size=1>[Lobby Settings]</size></color><color=#FF6666><size=0.85> - (Press F2 for Show)</size>\n</color>";
                        string TABLobbySetsFR = "<color=#EC7C18>\n\n<size=1>[Option de Jeu]</size></color><color=#FF6666><size=0.85> - (Appuyez sur F2 pour Afficher)</size>\n</color>";
                        string TABLobbySetsZHCN = "<color=#EC7C18>\n\n<size=1>[大厅设置]</size></color><color=#FF6666><size=0.85> - (Press F2 for Show)</size>\n</color>";



                        if ((DisabledVitales.getSelection() != 0
                        || DisabledCamera.getSelection() != 0
                        || DisabledAdmin.getSelection() != 0
                        || NoOxySabotage.getSelection() != 0
                        || ReactorSabotageShaking.getSelection() != 0
                        || CommsSabotageAnonymous.getSelection() != 0
                        || AdminTimeOn.getSelection() != 0
                        || CamTimeOn.getSelection() != 0
                        || VitalTimeOn.getSelection() != 0
                        ))
                        {
                            if (Challenger.Setting_TabGame == "0")
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TABLobbySetsFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TABLobbySetsZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += TABLobbySets;
                                }
                            }
                            else
                            {

                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LobbySetsFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LobbySetsZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += LobbySets;
                                }
                            }

                        }


                        if (Challenger.Setting_TabGame == "1")
                        {


                            //SABOTAGES - COM
                            string SabModcom = "<size=0.75><color=#EC7C18>\nSabotages - Coms Unknow Players :</color>";
                            string SabModcomFR = "<size=0.75><color=#EC7C18>\nSabotages - Com : Joueurs anonyme :</color>";
                            string SabModcomZHCN = "<size=0.75><color=#EC7C18>\n破坏设置 - 破坏通讯可全员匿名 :</color>";




                            if (CommsSabotageAnonymous.getSelection() == 0)
                            {

                                SabModcom += " <color=#FF0000>Disable</color>";
                                SabModcomFR += " <color=#FF0000>Désactivé</color>";
                                SabModcomZHCN += " <color=#FF0000>关</color>";

                            }
                            if (CommsSabotageAnonymous.getSelection() == 1)
                            {

                                SabModcom += " <color=#00FF00>Enable</color>";
                                SabModcomFR += " <color=#00FF00>Activé</color>";
                                SabModcomZHCN += " <color=#00FF00>开</color>";

                            }

                            if ((NoOxySabotage.getSelection() != 0 || ReactorSabotageShaking.getSelection() != 0 || CommsSabotageAnonymous.getSelection() != 0))
                            {

                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SabModcomFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SabModcomZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += SabModcom;
                                }
                            }

                            /*
                            //SABOTAGES - Reactor
                            string SabModrea = "<color=#EC7C18>\nSabotages - Reactor Shacking Mode :</color>";
                            string SabModreaFR = "<color=#EC7C18>\nSabotages - Reacteur : Fait trembler d'écran :</color>";


                            if (ReactorSabotageShaking.getSelection() == 0)
                            {

                                SabModrea += " <color=#FF0000>Disable</color>";
                                SabModreaFR += " <color=#FF0000>Désactivé</color>";

                            }
                            if (ReactorSabotageShaking.getSelection() == 1)
                            {

                                SabModrea += " <color=#00FF00>Enable</color> to <color=#FF00FF>Rising Mod</color>";
                                SabModreaFR += " <color=#00FF00>Activé</color> en <color=#FF00FF>Mode Progressif</color>";

                            }
                            if (ReactorSabotageShaking.getSelection() == 2)
                            {

                                SabModrea += " <color=#00FF00>Enable</color> to <color=#FF00FF>Fix Mod</color>";
                                SabModreaFR += " <color=#00FF00>Activé</color> en <color=#FF00FF>Mode Stable</color>";

                            }

                            if ((NoOxySabotage.getSelection() != 0 || ReactorSabotageShaking.getSelection() != 0 || CommsSabotageAnonymous.getSelection() != 0))
                            {

                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SabModreaFR;
                                }
                                else
                                {
                                    __instance.GameSettings.text += SabModrea;
                                }
                            }

                            //SABOTAGES - OXY
                            string SabModoxy = "<size=0.75><color=#EC7C18>\nSabotages - Oxygen fainting Effect :</color>";
                            string SabModoxyFR = "<size=0.75><color=#EC7C18>\nSabotages - Oxygen : Perte de connaissance :</color>";


                            if (NoOxySabotage.getSelection() == 0)
                            {

                                SabModoxy += " <color=#FF0000>Disable</color>";
                                SabModoxyFR += " <color=#FF0000>Désactivé</color>";
                            }
                            if (NoOxySabotage.getSelection() == 1)
                            {

                                SabModoxy += " <color=#00FF00>Enable</color>";
                                SabModoxyFR += " <color=#00FF00>Activé</color>";

                            }

                            if ((NoOxySabotage.getSelection() != 0 || ReactorSabotageShaking.getSelection() != 0 || CommsSabotageAnonymous.getSelection() != 0))
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SabModoxyFR;
                                }
                                else
                                {
                                    __instance.GameSettings.text += SabModoxy;
                                }
                            }
                            */


                            //TRYHARD - Admin
                            string TryHardAdmin = "<size=0.75><color=#EC7C18>\nUtility - Admin : </color>";
                            string TryHardAdminFR = "<size=0.75><color=#EC7C18>\nSurveillance - Admin : </color>";
                            string TryHardAdminZHCN = "<size=0.75><color=#EC7C18>\n功能 - 管理地图 : </color>";



                            if (DisabledAdmin.getSelection() == 0)
                            {
                                TryHardAdmin += "  <color=#00FF00>Enable</color> for <color=#FF00FF>Everyone</color>";
                                TryHardAdminFR += "  <color=#00FF00>Activé</color> pour <color=#FF00FF>tout le monde</color>";
                                TryHardAdminZHCN += "  对<color=#FF00FF>所有人</color> <color=#00FF00>开启</color>";



                            }
                            if (DisabledAdmin.getSelection() == 1)
                            {
                                TryHardAdmin += " <color=#FF0000>Disable</color> for <color=#FF00FF>Everyone</color>";
                                TryHardAdminFR += " <color=#FF0000>Désactivé</color> pour <color=#FF00FF>tout le monde</color>";
                                TryHardAdminZHCN += "对 <color=#FF00FF>所有人</color><color=#FF0000>禁用</color>";



                            }
                            if (DisabledAdmin.getSelection() == 2)
                            {
                                TryHardAdmin += "  <color=#FF0000>Disable</color> for <color=#FF0000>Impostors</color>";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> pour <color=#FF0000>les Imposteurs</color>";
                                TryHardAdminZHCN += "  对<color=#FF0000>内鬼</color> <color=#FF0000>禁用</color>";



                            }
                            if (DisabledAdmin.getSelection() == 3)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x1</color> player";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x1</color> joueur";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x1</color>位玩家前<color=#FF0000>禁用</color> ";



                            }
                            if (DisabledAdmin.getSelection() == 4)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x2</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x2</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x2</color>位玩家前<color=#FF0000>禁用</color> ";


                            }
                            if (DisabledAdmin.getSelection() == 5)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x3</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x3</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x3</color>位玩家前<color=#FF0000>禁用</color> ";


                            }
                            if (DisabledAdmin.getSelection() == 6)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x4</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x4</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x4</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledAdmin.getSelection() == 7)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x5</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x5</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x5</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledAdmin.getSelection() == 8)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x6</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x6</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x6</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledAdmin.getSelection() == 9)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x7</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x7</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x7</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledAdmin.getSelection() == 10)
                            {

                                TryHardAdmin += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x8</color> players";
                                TryHardAdminFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x8</color> joueurs";
                                TryHardAdminZHCN += " 在死<color=#ff00ff>x8</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (AdminTimeOn.getSelection() == 1)
                            {
                                TryHardAdmin += " - Limited time to use : <color=#00FFFF>" + AdminTime.getFloat() + "s</color>, Reset : <color=#ff0000>Never</color>.";
                                TryHardAdminFR += " - Temps d'utilisation : <color=#00FFFF>" + AdminTime.getFloat() + "s</color>, Se réinitialise : <color=#ff0000>Jamais</color>.";
                                TryHardAdminZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>从不</color>.";

                            }
                            if (AdminTimeOn.getSelection() == 2)
                            {
                                TryHardAdmin += " - Limited time to use : <color=#00FFFF>" + AdminTime.getFloat() + "s</color>, Reset : <color=#ff00ff>Each Round</color>.";
                                TryHardAdminFR += " - Temps d'utilisation : <color=#00FFFF>" + AdminTime.getFloat() + "s</color>, Se réinitialise : <color=#ff00ff>Après chaque réunion</color>.";
                                TryHardAdminZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>每局</color>.";

                            }

                            if ((DisabledAdmin.getSelection() != 0
                                || DisabledCamera.getSelection() != 0
                                || DisabledVitales.getSelection() != 0
                                || AdminTimeOn.getSelection() != 0
                                || CamTimeOn.getSelection() != 0
                                || VitalTimeOn.getSelection() != 0
                                ))
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardAdminFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardAdminZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += TryHardAdmin;
                                }
                            }

                            //TRYHARD - VITALES
                            string TryHardVitales = "<size=0.75><color=#EC7C18>\nUtility - Vitale : </color>";
                            string TryHardVitalesFR = "<size=0.75><color=#EC7C18>\nSurveillance - Vitales : </color>";
                            string TryHardVitalesZHCN = "<size=0.75><color=#EC7C18>\n功能 - 生命监测仪 : </color>";

                            if (DisabledVitales.getSelection() == 0)
                            {
                                TryHardVitales += "  <color=#00FF00>Enable</color> for <color=#FF00FF>Everyone</color>";

                                TryHardVitalesFR += "  <color=#00FF00>Activé</color> pour <color=#FF00FF>tout le monde</color>";

                                TryHardVitalesZHCN += "对<color=#FF00FF>所有人</color><color=#00FF00>启用</color>";
                            }
                            if (DisabledVitales.getSelection() == 1)
                            {
                                TryHardVitales += " <color=#FF0000>Disable</color> for <color=#FF00FF>Everyone</color>";

                                TryHardVitalesFR += " <color=#FF0000>Désactivé</color> pour <color=#FF00FF>tout le monde</color>";

                                TryHardVitalesZHCN += "对<color=#FF00FF>所有人</color><color=#00FF00>禁用</color>";
                            }
                            if (DisabledVitales.getSelection() == 2)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> for <color=#FF0000>Impostors</color>";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> pour <color=#FF0000>Les Imposteurs</color>";

                                TryHardVitalesZHCN += "对<color=#FF0000>内鬼</color><color=#00FF00>禁用</color>";
                            }
                            if (DisabledVitales.getSelection() == 3)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x1</color> player";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x1</color> joueur";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x1</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 4)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x2</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x2</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x2</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 5)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x3</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x3</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x3</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 6)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x4</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x4</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x4</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 7)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x5</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x5</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x5</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 8)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x6</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x6</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x6</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 9)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x7</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x7</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x7</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledVitales.getSelection() == 10)
                            {
                                TryHardVitales += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x8</color> players";

                                TryHardVitalesFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x8</color> joueurs";

                                TryHardVitalesZHCN += " 在死<color=#ff00ff>x8</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (VitalTimeOn.getSelection() == 1)
                            {
                                TryHardVitales += " - Limited time to use : <color=#00FFFF>" + VitalTime.getFloat() + "s</color>, Reset : <color=#ff0000>Never</color>.";

                                TryHardVitalesFR += " - Temps d'utilisation : <color=#00FFFF>" + VitalTime.getFloat() + "s</color>, Se réinitialise : <color=#ff0000>Jamais</color>.";

                                TryHardVitalesZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>从不</color>.";
                            }
                            if (VitalTimeOn.getSelection() == 2)
                            {
                                TryHardVitales += " - Limited time to use : <color=#00FFFF>" + VitalTime.getFloat() + "s</color>, Reset : <color=#ff00ff>Each Round</color>.";

                                TryHardVitalesFR += " - Temps d'utilisation : <color=#00FFFF>" + VitalTime.getFloat() + "s</color>, Se réinitialise : <color=#ff00ff>Après chaque réunion</color>.";

                                TryHardVitalesZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>每局</color>.";
                            }


                            if ((DisabledAdmin.getSelection() != 0
                                                    || DisabledCamera.getSelection() != 0
                                                    || DisabledVitales.getSelection() != 0
                                                    || AdminTimeOn.getSelection() != 0
                                                    || CamTimeOn.getSelection() != 0
                                                    || VitalTimeOn.getSelection() != 0
                                                    ))
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardVitalesFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardVitalesZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += TryHardVitales;
                                }
                            }


                            //TRYHARD - Camera
                            string TryHardCamera = "<size=0.75><color=#EC7C18>\nUtility - Camera : </color>";
                            string TryHardCameraFR = "<size=0.75><color=#EC7C18>\nSurveillance - Camera : </color>";
                            string TryHardCameraZHCN = "<size=0.75><color=#EC7C18>\n功能 - 摄像头 : </color>";


                            if (DisabledCamera.getSelection() == 0)
                            {
                                TryHardCamera += "  <color=#00FF00>Enable</color> for <color=#FF00FF>Everyone</color>";

                                TryHardCameraFR += "  <color=#00FF00>Activé</color> pour <color=#FF00FF>tout le monde</color>";

                                TryHardVitalesZHCN += "对<color=#FF00FF>所有人</color><color=#00FF00>启用</color>";
                            }
                            if (DisabledCamera.getSelection() == 1)
                            {
                                TryHardCamera += " <color=#FF0000>Disable</color> for <color=#FF00FF>Everyone</color>";
                                TryHardCameraFR += " <color=#FF0000>Désactivé</color> pour <color=#FF00FF>tout le monde</color>";
                                TryHardCameraZHCN += "对<color=#FF00FF>所有人</color><color=#00FF00>禁用</color>";
                            }
                            if (DisabledCamera.getSelection() == 2)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> for <color=#FF0000>Impostors</color>";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> pour <color=#FF0000>Les Imposteurs</color>";

                                TryHardCameraZHCN += "对<color=#FF0000>内鬼</color><color=#00FF00>禁用</color>";
                            }
                            if (DisabledCamera.getSelection() == 3)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x1</color> player";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x1</color> joueur";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x1</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 4)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x2</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x2</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x2</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 5)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x3</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x3</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x3</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 6)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x4</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x4</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x4</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 7)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x5</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x5</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x5</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 8)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x6</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x6</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x6</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 9)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x7</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x7</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x7</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (DisabledCamera.getSelection() == 10)
                            {
                                TryHardCamera += "  <color=#FF0000>Disable</color> before the death of <color=#ff00ff>x8</color> players";

                                TryHardCameraFR += "  <color=#FF0000>Désactivé</color> avant la mort de <color=#ff00ff>x8</color> joueurs";

                                TryHardCameraZHCN += " 在死<color=#ff00ff>x8</color>位玩家前<color=#FF0000>禁用</color> ";

                            }
                            if (CamTimeOn.getSelection() == 1)
                            {
                                TryHardCamera += " - Limited time to use : <color=#00FFFF>" + CamTime.getFloat() + "s</color>, Reset : <color=#ff0000>Never</color>.";

                                TryHardCameraFR += " - Temps d'utilisation : <color=#00FFFF>" + CamTime.getFloat() + "s</color>, Se réinitialise : <color=#ff0000>Jamais</color>.";

                                TryHardCameraZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>从不</color>.";
                            }
                            if (CamTimeOn.getSelection() == 2)
                            {
                                TryHardCamera += " - Limited time to use : <color=#00FFFF>" + CamTime.getFloat() + "s</color>, Reset : <color=#ff00ff>Each Round</color>.";

                                TryHardCameraFR += " - Temps d'utilisation : <color=#00FFFF>" + CamTime.getFloat() + "s</color>, Se réinitialise : <color=#ff00ff>Après chaque réunion</color>.";

                                TryHardCameraZHCN += " - 限制使用时间时长 : <color=#00FFFF>" + AdminTime.getFloat() + "秒</color>, 重置使用时间 : <color=#ff0000>每局</color>.";
                            }


                            if ((DisabledAdmin.getSelection() != 0
                                                    || DisabledCamera.getSelection() != 0
                                                    || DisabledVitales.getSelection() != 0
                                                    || AdminTimeOn.getSelection() != 0
                                                    || CamTimeOn.getSelection() != 0
                                                    || VitalTimeOn.getSelection() != 0
                                                    ))
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardCameraFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TryHardCameraZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += TryHardCamera;
                                }
                            }


                        }


                        //SPACER---
                        string Spacercrew = "\n";
                        __instance.GameSettings.text += Spacercrew;

                        //ROLESSETTINGS
                        string Crewmates = "<color=#0080ff><size=1>\n[Crewmates Role]</size></color>";
                        string CrewmatesFR = "<color=#0080ff><size=1>\n[Rôles Cooquipiers]</size></color>";
                        string CrewmatesZHCN = "<color=#0080ff><size=1>\n[Crewmates Role]</size></color>";

                        if (Challenger.Setting_TabSetCrew == "1")
                        {
                            Crewmates += "<color=#FF6666><size=0.85> - (Press F3 to Hide)\n</size></color>";
                            CrewmatesFR += "<color=#FF6666><size=0.85> - (Appuyez sur F3 pour Masquer)\n</size></color>";
                            CrewmatesZHCN += "<color=#FF6666><size=0.85> - (Press F3 to Hide)\n</size></color>";
                        }
                        else
                        {
                            Crewmates += "<color=#FF6666><size=0.85> - (Press F3 for Show)\n</size></color>";
                            CrewmatesFR += "<color=#FF6666><size=0.85> - (Appuyez sur F3 pour Afficher)\n</size></color>";
                            CrewmatesZHCN += "<color=#FF6666><size=0.85> - (Press F3 for Show)\n</size></color>";
                        }


                        if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += CrewmatesFR;
                        }
                        else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += CrewmatesZHCN;
                        }
                        else
                        {
                            __instance.GameSettings.text += Crewmates;
                        }

                        if (Challenger.Setting_TabSetCrew == "1")
                        {
                            //SHERIF
                            string Sherifs = "<size=0.75><color=#FFFF00>\n> Sheriff : </color>";
                            string SherifsFR = "<size=0.75><color=#FFFF00>\n> Shérif : </color>";
                            string SherifsZHCN = "<size=0.75><color=#FFFF00>\n> 警长 : </color>";


                            if (SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || HIDE_Sheriff.getBool() == true)

                            {
                                if (SherifKillRange.getSelection() == 0)
                                {

                                    Sherifs += "Sheriff count : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, Kill Cooldown : <color=#00ffff>" + SherifKillCooldown.getFloat() + "s</color>, Kill distance : <color=#ff00ff>Normal (100%)</color>";
                                    SherifsFR += "Nombre de Shérif : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, Délai pour Tuer : <color=#00ffff>" + SherifKillCooldown.getFloat() + "s</color>, distance : <color=#ff00ff>Normal (100%)</color>";
                                    SherifsZHCN += "警长数 : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, 击杀冷却 : <color=#00ffff>" + SherifKillCooldown.getFloat() + "秒</color>, 击杀范围 : <color=#ff00ff>正常 (100%)</color>";
                                }
                                if (SherifKillRange.getSelection() == 1)
                                {
                                    Sherifs += "Sheriff count : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, Kill Cooldown : <color=#00ffff>" + SherifKillCooldown.getFloat() + "s</color>, Kill distance : <color=#ff00ff>Upgraded (120%)</color>";
                                    SherifsFR += "Nombre de Shérif : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, Délai pour Tuer : <color=#00ffff>" + SherifKillCooldown.getFloat() + "s</color>, distance : <color=#ff00ff>Amélioré (120%)</color>";
                                    SherifsZHCN += "警长数 : <color=#ff00ff>" + (0 + Sheriff1Max + Sheriff2Max + Sheriff3Max) + "~" + (0 + SherifMin + Sherif2Min + Sherif3Min) + "</color>, 击杀冷却 : <color=#00ffff>" + SherifKillCooldown.getFloat() + "秒</color>, 击杀范围 : <color=#ff00ff>提升 (120%)</color>";

                                }
                                if (SherifKillCulteMember.getBool() == true)
                                {
                                    Sherifs += ",\nCan Kill Culte Member : <color=#00ff00>Yes</color>,";
                                    SherifsFR += ",\nPeut tuer les membres du Culte : <color=#00ff00>Oui</color>,";
                                    SherifsZHCN += ",\n可以击杀邪教成员 : <color=#00ff00>是</color>,";

                                }
                                if (SherifKillCulteMember.getBool() == false)
                                {
                                    Sherifs += ",\nCan Kill Culte Member : <color=#ff0000>No</color>,";
                                    SherifsFR += ",\nPeut tuer les membres du Culte : <color=#ff0000>Non</color>,";
                                    SherifsZHCN += ",\n可以击杀邪教成员 : <color=#00ff00>否</color>,";

                                }
                                if (SherifKillSettings.getSelection() == 0)
                                {
                                    Sherifs += " Ability Setting : <color=#00ff00>Enable</color>.";
                                    SherifsFR += " Paramètres de la capacité : <color=#00ff00>Activé</color>.";
                                    SherifsZHCN += " 技能设置 : <color=#00ff00>直接可用</color>.";
                                }
                                if (SherifKillSettings.getSelection() == 1)
                                {
                                    Sherifs += " Ability Setting : <color=#ff00ff>Disabled at first turn</color>.";
                                    SherifsFR += " Paramètres de la capacité : <color=#ff00ff>Désactivé au premier tour</color>.";
                                    SherifsZHCN += " 技能设置 : <color=#00ff00>在第一局禁用</color>.";
                                }
                                if (SherifKillSettings.getSelection() == 2)
                                {
                                    Sherifs += " Ability Setting : <color=#ff00ff>He will have to find his weapon before kill</color>.";
                                    SherifsFR += " Paramètres de la capacité : <color=#00ff00>Il devras trouver sont arme pour tuer</color>.";
                                    SherifsZHCN += " 技能设置 : <color=#00ff00>在寻找到自己的武器前禁用</color>.";
                                }


                            }
                            if (SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true || HIDE_Sheriff.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SherifsFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SherifsZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Sherifs;
                                }
                            }


                            //GUARDIAN
                            string Guardian = "<size=0.75><color=#00FFFF>\n> Guardian : </color>";
                            string GuardianFR = "<size=0.75><color=#00FFFF>\n> Guardien : </color>";
                            string GuardianZHCN = "<size=0.75><color=#00FFFF>\n> 守护者 : </color>";

                            if (GuardianSpawnChance.getFloat() > 0)

                            {

                                if (ShieldSettings.getSelection() == 1)
                                {
                                    if (GuardianShieldVisibility.getBool() == true)
                                    {
                                        Guardian += "Shield Settings Mode : <color=#ff00ff>Reflect</color>, player protected see the shield : <color=#00ff00>Yes</color>";
                                        GuardianFR += "Paramètre du Bouclier : <color=#ff00ff>Renvoie</color>, le joueur protégé voit le Bouclier : <color=#00ff00>Oui</color>";
                                        GuardianZHCN += "护盾模式设置 : <color=#ff00ff>反弹</color>, 被保护的玩家可见护盾 : <color=#00ff00>是</color>";

                                    }
                                    else
                                    {
                                        Guardian += "Shield Settings Mode : <color=#ff00ff>Reflect</color>, player protected see the shield : <color=#ff0000>No</color>";
                                        GuardianFR += "Paramètre du Bouclier : <color=#ff00ff>Renvoie</color>, le joueur protégé voit le Bouclier : <color=#ff0000>Non</color>";
                                        GuardianZHCN += "护盾模式设置 : <color=#ff00ff>反弹</color>, 被保护的玩家可见护盾 : <color=#00ff00>否</color>";

                                    }

                                }
                                if (ShieldSettings.getSelection() == 0)
                                {
                                    if (GuardianShieldVisibility.getBool() == true)
                                    {
                                        Guardian += "Shield Settings Mode : <color=#ff00ff>Protected</color>, player protected see the shield : <color=#00ff00>Yes</color>";
                                        GuardianFR += "Paramètre du Bouclier : <color=#ff00ff>Protection</color>, le joueur protégé voit le Bouclier : <color=#00ff00>Oui</color>";
                                        GuardianZHCN += "护盾模式设置 : <color=#ff00ff>保护</color>, 被保护的玩家可见护盾 : <color=#00ff00>是</color>";
                                    }
                                    else
                                    {
                                        Guardian += "Shield Settings Mode : <color=#ff00ff>Protected</color>, player protected see the shield : <color=#ff0000>No</color>";
                                        GuardianFR += "Paramètre du Bouclier : <color=#ff00ff>Protection</color>, le joueur protégé voit le Bouclier : <color=#ff0000>Non</color>";
                                        GuardianZHCN += "护盾模式设置 : <color=#ff00ff>保护</color>, 被保护的玩家可见护盾 : <color=#00ff00>否</color>";

                                    }

                                }
                                if (GuardianShieldVisibilitytry.getSelection() == 0)
                                {
                                    if (GuardianShieldSound.getBool() == true)
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Everyone</color> can see shield and hear the noise shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>tout le monde</color> peut voir le Shield et entendras le son.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>所有人</color>都可以看见护盾并听到护盾被破坏的声音";

                                    }
                                    else
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Everyone</color> can see shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>tout le monde</color> peut voir le Bouclier.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>所有人</color>都可以看见护盾";

                                    }

                                }
                                if (GuardianShieldVisibilitytry.getSelection() == 1 && GuardianShieldVisibility.getBool() == false)
                                {
                                    if (GuardianShieldSound.getBool() == true)
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Shielded Player</color> can see shield and <color=#ff00ff>Everyone</color> hear the noise shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>le joueur protégé</color> peut voir le Bouclier, et <color=#ff00ff>tout le monde</color> entends le son.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>被保护的玩家</color> 会看见护盾 并且 <color=#ff00ff>所有人</color> 都会听到护盾被破坏的声音.";

                                    }
                                    else
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Shielded Player</color> can see shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>le joueur protégé</color> peut voir le Bouclier.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>被保护的玩家</color> 会看见护盾 .";

                                    }
                                }
                                if (GuardianShieldVisibilitytry.getSelection() == 1 && GuardianShieldVisibility.getBool() == true)
                                {
                                    if (GuardianShieldSound.getBool() == true)
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Everyone</color> hear the noise shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>tout le monde</color> entendras le son.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>所有人</color> 都会听到护盾被破坏的声音.";

                                    }
                                    else
                                    {
                                        Guardian += ".";
                                        GuardianFR += ".";
                                        GuardianZHCN += ".";

                                    }
                                }

                                if (GuardianShieldVisibilitytry.getSelection() == 2)
                                {
                                    if (GuardianShieldSound.getBool() == true)
                                    {
                                        Guardian += ", if Player attempt to kill Shielded player, <color=#ff00ff>Everyone</color> hear the noise shield.";
                                        GuardianFR += ", Si un joueur tente de tuer le joueur protégé, <color=#ff00ff>tout le monde</color> entendras le son.";
                                        GuardianZHCN += ", 如果有玩家尝试击杀被保护的玩家, <color=#ff00ff>所有人</color> 都会听到护盾被破坏的声音.";

                                    }
                                    else
                                    {
                                        Guardian += ".";
                                        GuardianFR += ".";
                                        GuardianZHCN += ".";

                                    }
                                }



                            }
                            if (GuardianSpawnChance.getFloat() > 0 && GuardianAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GuardianFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GuardianZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Guardian;
                                }
                            }



                            //ENGINEER
                            string Engineer = "<size=0.75><color=#FFA100>\n> Engineer : </color>";
                            string EngineerFR = "<size=0.75><color=#FFA100>\n> Ingénieur : </color>";
                            string EngineerZHCN = "<size=0.75><color=#FFA100>\n> 工程师 : </color>";

                            if (engineerSpawnChance.getFloat() > 0)

                            {

                                if (RepairSettings.getSelection() == 0)
                                {
                                    if (EngineerCanVent.getBool() == true)
                                    {
                                        Engineer += "Repair Mode : <color=#ff00ff>Single</color>, Cooldown : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Can Use Vent : <color=#00ff00>Yes</color>.";
                                        EngineerFR += "Mode de réparation : <color=#ff00ff>Unique</color>, Délai : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Peut utiliser les Vents : <color=#00ff00>Oui</color>.";
                                        EngineerZHCN += "修复频率 : <color=#ff00ff>单次</color>, 钻管冷却 : <color=#00ffff>" + EngineerRepairCD.getFloat() + "秒</color>, 可以使用管道 : <color=#00ff00>是</color>.";

                                    }
                                    if (EngineerCanVent.getBool() == false)
                                    {
                                        Engineer += "Repair Mode : <color=#ff00ff>Single</color>, Cooldown : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Can Use Vent : <color=#FF0000>No</color>.";
                                        EngineerFR += "Mode de réparation : <color=#ff00ff>Unique</color>, Délai : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>.";
                                        EngineerZHCN += "修复频率 : <color=#ff00ff>单次</color>, 钻管冷却 : <color=#00ffff>" + EngineerRepairCD.getFloat() + "秒</color>, 可以使用管道 : <color=#00ff00>否</color>.";

                                    }

                                }
                                if (RepairSettings.getSelection() == 1)
                                {
                                    if (EngineerCanVent.getBool() == true)
                                    {
                                        Engineer += "Repair Mode : <color=#ff00ff>Round</color>, Cooldown : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Can Use Vent : <color=#00ff00>Yes</color>.";
                                        EngineerFR += "Mode de réparation : <color=#ff00ff>1x Par Tour</color>, Délai : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Peut utiliser les Vents : <color=#00ff00>Oui</color>.";
                                        EngineerZHCN += "修复频率 : <color=#ff00ff>每局</color>, 钻管冷却 : <color=#00ffff>" + EngineerRepairCD.getFloat() + "秒</color>, 可以使用管道 : <color=#00ff00>是</color>.";


                                    }
                                    if (EngineerCanVent.getBool() == false)
                                    {
                                        Engineer += "Repair Mode : <color=#ff00ff>Round</color>, Cooldown : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Can Use Vent : <color=#FF0000>No</color>.";
                                        EngineerFR += "Mode de réparation : <color=#ff00ff>1x Par Tour</color>, Délai : <color=#00ffff>" + EngineerRepairCD.getFloat() + "s</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>.";
                                        EngineerZHCN += "修复频率 : <color=#ff00ff>每局</color>, 钻管冷却 : <color=#00ffff>" + EngineerRepairCD.getFloat() + "秒</color>, 可以使用管道 : <color=#00ff00>否</color>.";


                                    }

                                }


                            }
                            if (engineerSpawnChance.getFloat() > 0 && engineerAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += EngineerFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += EngineerZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Engineer;
                                }
                            }



                            //TIMELORD
                            string Timelord = "<size=0.75><color=#007FFF>\n> Timelord : </color>";
                            string TimelordFR = "<size=0.75><color=#007FFF>\n> Temporel : </color>";
                            string TimelordZHCN = "<size=0.75><color=#007FFF>\n> 时间领主 : </color>";


                            if (TimeLordSpawnChance.getFloat() > 0)

                            {
                                Timelord += "Break Time : <color=#00ffff>" + TimeLordStopCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + TimeLordStopDuration.getFloat() + "s</color> duration.</color>";
                                TimelordFR += "Délai pour Arrêter le temps : <color=#00ffff>" + TimeLordStopCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + TimeLordStopDuration.getFloat() + "s</color>.</color>";
                                TimelordZHCN += "暂停时间冷却 : <color=#00ffff>" + TimeLordStopCooldown.getFloat() + "秒</color> 暂停时间持续时间： <color=#00ffff>" + TimeLordStopDuration.getFloat() + "秒</color>.</color>";

                            }
                            if (TimeLordSpawnChance.getFloat() > 0 && TimeLordAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TimelordFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += TimelordZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Timelord;
                                }
                            }

                            //HUNTER
                            string Hunter = "<size=0.75><color=#00ff00>\n> Hunter : </color>";
                            string HunterFR = "<size=0.75><color=#00ff00>\n> Chasseur : </color>";
                            string HunterZHCN = "<size=0.75><color=#00ff00>\n> 猎人 : </color>";



                            if (HunterSpawnChance.getFloat() > 0)

                            {
                                if (ResetTrack.getBool() == false)
                                {
                                    if (Followtrack.getBool() == false)
                                    {
                                        Hunter += "Can reuse Track if Tracked player die : <color=#ff0000>No</color>, Hunter can Follow Tracked player : <color=#ff0000>No</color>.";
                                        HunterFR += "Peut réutiliser son pisteur si la cible est tuée : <color=#ff0000>Non</color>, Le Pisteur affiche un marqueur en jeu : <color=#ff0000>Non</color>.";
                                        HunterZHCN += "如果被追踪玩家死亡可以再次追踪 : <color=#ff0000>否</color>, 猎人可以跟踪被追踪的玩家 : <color=#ff0000>否</color>.";

                                    }
                                    if (Followtrack.getBool() == true)
                                    {
                                        Hunter += "Can reuse Track if Tracked player die : <color=#ff0000>No</color>, Hunter can Follow Tracked player : <color=#00FF00>Yes</color>.";
                                        HunterFR += "Peut réutiliser son pisteur si la cible est tuée : <color=#ff0000>Non</color>, Le Pisteur affiche un marqueur en jeu : <color=#00FF00>Oui</color>.";
                                        HunterZHCN += "如果被追踪玩家死亡可以再次追踪 : <color=#ff0000>否</color>, 猎人可以跟踪被追踪的玩家 : <color=#ff0000>是</color>.";

                                    }
                                }
                                if (ResetTrack.getBool() == true)
                                {
                                    if (Followtrack.getBool() == false)
                                    {
                                        Hunter += "Can reuse Track if Tracked player die : <color=#00FF00>Yes</color>, Hunter can Follow Tracked player : <color=#ff0000>No</color>.";
                                        HunterFR += "Peut réutiliser son pisteur si la cible est tuée : <color=#00FF00>Oui</color>, Le Pisteur affiche un marqueur en jeu : <color=#ff0000>Non</color>.";
                                        HunterZHCN += "如果被追踪玩家死亡可以再次追踪 : <color=#00FF00>是</color>, 猎人可以跟踪被追踪的玩家 : <color=#ff0000>否</color>.";

                                    }
                                    if (Followtrack.getBool() == true)
                                    {
                                        Hunter += "Can reuse Track if Tracked player die : <color=#00FF00>Yes</color>, Hunter can Follow Tracked player : <color=#00FF00>Yes</color>.";
                                        HunterFR += "Peut réutiliser son pisteur si la cible est tuée : <color=#00FF00>Oui</color>, Le Pisteur affiche un marqueur en jeu : <color=#00FF00>Oui</color>.";
                                        HunterZHCN += "如果被追踪玩家死亡可以再次追踪 : <color=#00FF00>是</color>, 猎人可以跟踪被追踪的玩家 : <color=#00FF00>是</color>.";

                                    }
                                }
                            }
                            if (HunterSpawnChance.getFloat() > 0 && HunterAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += HunterFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += HunterZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Hunter;
                                }
                            }


                            //MYSTIC
                            string Mystic = "<size=0.75><color=#F9FFB2>\n> Mystic : </color>";
                            string MysticFR = "<size=0.75><color=#F9FFB2>\n> Mystic : </color>";
                            string MysticZHCN = "<size=0.75><color=#F9FFB2>\n> 神秘人 : </color>";



                            if (MysticSpawnChance.getFloat() > 0)

                            {
                                Mystic += "Personal-Shield : <color=#00ffff>" + MysticSetCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + MysticSetDuration.getFloat() + "s</color> duration.</color>";
                                MysticFR += "Délai du Bouclier personnel : <color=#00ffff>" + MysticSetCooldown.getFloat() + "s</color> pour une durée de <color=#00ffff>" + MysticSetDuration.getFloat() + "s</color>.";
                                MysticZHCN += "私人护盾冷却 : <color=#00ffff>" + MysticSetCooldown.getFloat() + "秒</color> 护盾保护时间： <color=#00ffff>" + MysticSetDuration.getFloat() + "秒</color>.</color>";

                            }
                            if (MysticSpawnChance.getFloat() > 0 && MysticAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MysticFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MysticZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Mystic;
                                }
                            }

                            //SPIRIT
                            string Spirit = "<size=0.75><color=#A1FF00>\n> Spirit : </color>";
                            string SpiritFR = "<size=0.75><color=#A1FF00>\n> Esprit : </color>";
                            string SpiritZHCN = "<size=0.75><color=#A1FF00>\n> 精灵 : </color>";



                            if (SpiritSpawnChance.getFloat() > 0)
                            {

                                if (SpiritSab.getBool() == false)
                                {
                                    Spirit += "Spirit can use Sabotage when he die (Door only) : <color=#ff0000>Disabled.</color>.";
                                    SpiritFR += "L'esprit peut utiliser les sabotages si il est mort (Porte uniquement) : <color=#ff0000>Désactivé.</color>.";
                                    SpiritZHCN += "当精灵死亡后仅可以破坏门  : <color=#ff0000>关.</color>.";


                                }
                                if (SpiritSab.getBool() == true)
                                {
                                    Spirit += "Spirit can use Sabotage when he die (Door only) : <color=#00FF00>Enable</color>.";
                                    SpiritFR += "L'esprit peut utiliser les sabotages si il est mort (Porte uniquement) : <color=#00FF00>Activé</color>.";
                                    SpiritZHCN += "当精灵死亡后仅可以破坏门  : <color=#ff0000>开.</color>.";


                                }

                            }
                            if (SpiritSpawnChance.getFloat() > 0 && SpiritAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SpiritFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SpiritZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Spirit;
                                }
                            }



                            //MAYOR
                            string Mayor = "<size=0.75><color=#AF8269>\n> Mayor : </color>";
                            string MayorFR = "<size=0.75><color=#AF8269>\n> Maire : </color>";
                            string MayorZHCN = "<size=0.75><color=#AF8269>\n> 市长 : </color>";



                            if (MayorSpawnChance.getFloat() > 0)

                            {
                                if (BonusBuzz.getSelection() == 0)
                                {
                                    Mayor += "Bonus Buzz Mode : <color=#ff0000>Disabled.</color>";
                                    MayorFR += "Réunion d'urgence bonus : <color=#ff0000>Désactivé.</color>";
                                    MayorZHCN += "减少紧急会议冷却 : <color=#ff0000>关.</color>";

                                }
                                if (BonusBuzz.getSelection() == 1)
                                {
                                    Mayor += "Bonus Buzz Mode : <color=#ff00ff>After First Meeting</color>, Cooldown : <color=#00ffff>" + BuzzCooldown.getFloat() + "s</color>";
                                    MayorFR += "Réunion d'urgence bonus : <color=#ff00ff>Activé - Après la première réunion</color>, Délai : <color=#00ffff>" + BuzzCooldown.getFloat() + "s</color>";
                                    MayorZHCN += "减少紧急会议冷却 : <color=#ff00ff>在第一局后</color>, 冷却时间 : <color=#00ffff>" + BuzzCooldown.getFloat() + "秒</color>";

                                }
                                if (BonusBuzz.getSelection() == 2)
                                {
                                    Mayor += "Bonus Buzz Mode : <color=#ff00ff>only if finished tasks</color>, Cooldown : <color=#00ffff>" + BuzzCooldown.getFloat() + "s</color>";
                                    MayorFR += "Réunion d'urgence bonus : <color=#ff00ff>Acitvé - Lorsque le Maire termine ces Tâches</color>, Délai : <color=#00ffff>" + BuzzCooldown.getFloat() + "s</color>";
                                    MayorZHCN += "减少紧急会议冷却 : <color=#ff00ff>仅当完成任务时</color>, 冷却时间 : <color=#00ffff>" + BuzzCooldown.getFloat() + "秒</color>";


                                }
                            }
                            if (MayorSpawnChance.getFloat() > 0 && MayorAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MayorFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MayorZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Mayor;
                                }
                            }



                            //DETECTIVE
                            string Detective = "<size=0.75><color=#BCFFBA>\n> Detective : </color>";
                            string DetectiveFR = "<size=0.75><color=#BCFFBA>\n> Detective : </color>";
                            string DetectiveZHCN = "<size=0.75><color=#BCFFBA>\n> 侦探 : </color>";



                            if (DetectiveSpawnChance.getFloat() > 0)

                            {
                                if (detectiveFootprintanonymous.getBool() == true)
                                {
                                    Detective += "<color=#ff00ff>Anonym</color> Footprint : <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "s</color> duration and <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "s</color> visible.</color>";

                                    DetectiveFR += "Traces <color=#ff00ff>Anonyme</color> Délai d'activation: <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "s</color> l'effet persiste pendant <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "s</color> Les traces restent visibles <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "s</color>.</color>";

                                    DetectiveZHCN += "<color=#ff00ff>匿名</color> 跟踪激活冷却 : <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "秒</color> 匿名跟踪激活时间： <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "秒</color> 匿名脚印可见时间： <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "秒</color>.</color>";
                                }
                                if (detectiveFootprintanonymous.getBool() == false)
                                {
                                    Detective += "<color=#ff00ff>Colored</color> Foorprint : <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "s</color> duration and <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "s</color> visible.</color>";

                                    DetectiveFR += "Traces <color=#ff00ff>De la couleur des joueurs</color> Délai d'activation: <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "s</color> l'effet persiste pendant <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "s</color> Les traces restent visibles <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "s</color>.</color>";

                                    DetectiveZHCN += "脚印<color=#ff00ff>颜色</color>显示冷却  : <color=#00ffff>" + detectiveFootprintcooldown.getFloat() + "秒</color> 脚印颜色显示时间： <color=#00ffff>" + detectiveFootprintDuration2.getFloat() + "秒</color> 脚印颜色显示持续范围 <color=#00ffff>" + detectiveFootprintDuration.getFloat() + "秒</color> 可见.</color>";
                                }


                            }
                            if (DetectiveSpawnChance.getFloat() > 0 && DetectiveAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += DetectiveFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += DetectiveZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Detective;
                                }
                            }



                            //NIGHTWATCH
                            string Nightwatch = "<size=0.75><color=#9EB3FF>\n> Nightwatch : </color>";
                            string NightwatchFR = "<size=0.75><color=#9EB3FF>\n> Veilleur : </color>";
                            string NightwatchZHCN = "<size=0.75><color=#9EB3FF>\n> 执灯人 : </color>";


                            if (NightwatcherSpawnChance.getFloat() > 0)

                            {
                                Nightwatch += "Light Vision : <color=#00ffff>" + NightwatcherSetCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + NightwatcherSetDuration.getFloat() + "s</color> duration.";

                                NightwatchFR += "Délai de la Vision Améliorée : <color=#00ffff>" + NightwatcherSetCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + NightwatcherSetDuration.getFloat() + "s</color>.";
                                NightwatchZHCN += "执灯冷却 : <color=#00ffff>" + NightwatcherSetCooldown.getFloat() + "秒</color> 执灯持续时间： <color=#00ffff>" + NightwatcherSetDuration.getFloat() + "秒</color>.";

                            }
                            if (NightwatcherSpawnChance.getFloat() > 0 && NightwatcherAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += NightwatchFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += NightwatchZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Nightwatch;
                                }
                            }


                            //SPY
                            string Spy = "<size=0.75><color=#9EE1FF>\n> Spy : </color>";
                            string SpyFR = "<size=0.75><color=#9EE1FF>\n> Espion : </color>";
                            string SpyZHCN = "<size=0.75><color=#9EE1FF>\n> 特工 : </color>";



                            if (SpySpawnChance.getFloat() > 0)

                            {
                                Spy += "Spy Ability Duration : <color=#00ffff>" + SpyDuration.getFloat() + "s</color>,";
                                SpyFR += "La Capacité de l'espion dure : <color=#00ffff>" + SpyDuration.getFloat() + "s</color>,";
                                SpyZHCN += "监视技能持续时间 : <color=#00ffff>" + SpyDuration.getFloat() + "秒</color>,";
                                if (SpyRange.getSelection() == 0)
                                {
                                    Spy += " ability view Range : <color=#FF00FF>100%</color>.";
                                    SpyFR += " porté de la vision : <color=#00FF00>100%</color>.";
                                    SpyZHCN += " 监视能力可见范围 : <color=#FF00FF>100%</color>.";
                                }
                                if (SpyRange.getSelection() == 1)
                                {
                                    Spy += " ability view Range : <color=#FF00FF>125%</color>.";
                                    SpyFR += " porté de la vision : <color=#00FF00>125%</color>.";
                                    SpyZHCN += " 监视能力可见范围 : <color=#FF00FF>125%</color>.";
                                }
                                if (SpyRange.getSelection() == 2)
                                {
                                    Spy += " ability view Range : <color=#FF00FF>150%</color>.";
                                    SpyFR += " porté de la vision : <color=#00FF00>150%</color>.";
                                    SpyZHCN += " 监视能力可见范围 : <color=#FF00FF>150%</color>.";
                                }
                            }
                            if (SpySpawnChance.getFloat() > 0 && SpyAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SpyFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SpyZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Spy;
                                }
                            }



                            //INFORMANT
                            string Informant = "<size=0.75><color=#ADFFEA>\n> Informant : </color>";
                            string InformantFR = "<size=0.75><color=#ADFFEA>\n> Voyante : </color>";
                            string InformantZHCN = "<size=0.75><color=#ADFFEA>\n> 线人 : </color>";



                            if (InforSpawnChance.getFloat() > 0)

                            {
                                if (InforAnalyseMod.getSelection() == 0)
                                {
                                    Informant += "Analyse Ability Mode : <color=#ff00ff>Single</color>, Cooldown Before Use : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantFR += "Peut analyser : <color=#ff00ff>1 Joueur</color>, Délai d'utilisation : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantZHCN += "分析能力模式 : <color=#ff00ff>单次</color>, 使用前冷却 : <color=#00ffff>" + InforCooldown.getFloat() + "秒</color>,";

                                }
                                if (InforAnalyseMod.getSelection() == 1)
                                {
                                    Informant += "Analyse Ability Mode : <color=#ff00ff>Round</color>, Cooldown Before Use : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantFR += "Peut analyser : <color=#ff00ff>1x Par Tour</color>, Délai d'utilisation : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantZHCN += "分析能力模式 : <color=#ff00ff>每局</color>, 使用前冷却 : <color=#00ffff>" + InforCooldown.getFloat() + "秒</color>,";

                                }
                                if (InforAnalyseMod.getSelection() == 2)
                                {
                                    Informant += "Analyse Ability Mode : <color=#ff00ff>Cooldown</color>, Cooldown for Use : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantFR += "Peut analyser : <color=#ff00ff>Plusieurs fois</color>, Délai d'utilisation : <color=#00ffff>" + InforCooldown.getFloat() + "s</color>,";
                                    InformantZHCN += "分析能力模式 : <color=#ff00ff>冷却</color>, 使用前冷却 : <color=#00ffff>" + InforCooldown.getFloat() + "秒</color>,";

                                }

                                if (InforRemainingTask.getFloat() == TotalTask)
                                {

                                    Informant += "\nEnable : <color=#ff00ff>From the game start</color>,";
                                    InformantFR += "\nDisponible : <color=#ff00ff>Dés le début de la partie</color>,";
                                    InformantZHCN += "\n开启 : <color=#ff00ff>在游戏开始时</color>,";

                                }
                                else
                                {
                                    if (InforRemainingTask.getFloat() == 0)
                                    {
                                        Informant += "\nEnable : <color=#ff00ff>When all task are complete</color>,";
                                        InformantFR += "\nDisponible : <color=#00ff00>quand Toute les tâches sont terminées</color>,";
                                        InformantZHCN += "\n开启 : <color=#ff00ff>当完成所有任务时</color>,";

                                    }
                                    else
                                    {
                                        Informant += "\nEnable :If <color=#ff00ff>" + (TotalTask - InforRemainingTask.getFloat()) + "/" + TotalTask + " task are completed</color>,";
                                        InformantFR += "\nDisponible :Si <color=#ff00ff>" + (TotalTask - InforRemainingTask.getFloat()) + "/" + TotalTask + " Tâches sont terminées.</color>,";
                                        InformantZHCN += "\n开启 :如果 <color=#ff00ff>" + (TotalTask - InforRemainingTask.getFloat()) + "/" + TotalTask + " 被完成</color>,";

                                    }
                                }


                                if (InforAnalyseTeam.getBool() == true)
                                {
                                    Informant += " can see Special role Team : <color=#00ff00>Yes</color>.";
                                    InformantFR += " Peut voir l'équipe des Rôles spéciaux : <color=#00ff00>Oui</color>.";
                                    InformantZHCN += " 可以看见特殊职业阵营 : <color=#00ff00>是</color>.";

                                }
                                if (InforAnalyseTeam.getBool() == false)
                                {
                                    Informant += " can see Special role Team : <color=#ff0000>No</color>.";
                                    InformantFR += " Peut voir l'équipe des Rôles spéciaux : <color=#ff0000>Non</color>.";
                                    InformantZHCN += " 可以看见特殊职业阵营 : <color=#ff0000>否</color>.";

                                }


                            }
                            if (InforSpawnChance.getFloat() > 0 && InforAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += InformantFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += InformantZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Informant;
                                }
                            }

                            //BAIT
                            string Bait = "<size=0.75><color=#808080>\n> Bait : </color>";
                            string BaitFR = "<size=0.75><color=#808080>\n> Appat : </color>";
                            string BaitZHCN = "<size=0.75><color=#808080>\n> 诱饵 : </color>";



                            if (BaitSpawnChance.getFloat() > 0)

                            {


                                if (BaitReport.getSelection() != 0)
                                {
                                    if (BaitReporttimeRnd.getFloat() != 0)
                                    {
                                        Bait += "Bait Reporting time : <color=#00ffff>" + BaitReporttime.getFloat() + "s ~ " + (BaitReporttime.getFloat() + BaitReporttimeRnd.getFloat()) + "s</color>,";
                                        BaitFR += "Délai avant que le Signalement s'active : <color=#00ffff>" + BaitReporttime.getFloat() + "s ~ " + (BaitReporttime.getFloat() + BaitReporttimeRnd.getFloat()) + "s</color>,";
                                        BaitZHCN += "诱饵强制报告时间 : <color=#00ffff>" + BaitReporttime.getFloat() + "秒 ~ " + (BaitReporttime.getFloat() + BaitReporttimeRnd.getFloat()) + "秒</color>,";

                                    }
                                    else
                                    {
                                        Bait += "Bait Reporting time : <color=#00ffff>" + BaitReporttime.getFloat() + "s</color>,";
                                        BaitFR += "Délai avant que le Signalement s'active : <color=#00ffff>" + BaitReporttime.getFloat() + "s</color>,";
                                        BaitZHCN += "诱饵强制报告时间 : <color=#00ffff>" + BaitReporttime.getFloat() + "秒</color>,";

                                    }
                                }
                                else
                                {
                                    Bait += "Bait Reporting time : <color=#ff0000>Disabled</color>,";
                                    BaitFR += "Délai avant que le Signalement s'active : <color=#ff0000>Désactivé</color>,";
                                    BaitZHCN += "Bait Reporting time : <color=#ff0000>Disabled</color>,";

                                }

                                if (BaitReport.getSelection() != 1)
                                {
                                    Bait += " Bait Killer Stuns : <color=#00ff00>Yes</color>, Duration : <color=#00ffff>" + BaitStuns.getFloat() + "</color>s,";
                                    BaitFR += " Le tueur est étourdit : <color=#00ff00>Oui</color>, Pendant : <color=#00ffff>" + BaitStuns.getFloat() + "</color>s,";
                                    BaitZHCN += " Bait Killer Stuns : <color=#00ff00>Yes</color>, Duration : <color=#00ffff>" + BaitStuns.getFloat() + "</color>s,";
                                }
                                else
                                {
                                    Bait += " Bait Killer Stuns : <color=#ff0000>No</color>,";
                                    BaitFR += " Le tueur est étourdit : <color=#ff0000>Non</color>,";
                                    BaitZHCN += " Bait Killer Stuns : <color=#ff0000>No</color>,";
                                }



                                if (BaitBalise.getFloat() != 0)
                                {
                                    Bait += " Warn Area : <color=#ff00ff>x" + BaitBalise.getFloat() + "</color>, Cooldown : <color=#00ffff>" + BaitBaliseTime.getFloat() + "s</color>,";
                                    BaitFR += " Zone d'alerte : <color=#ff00ff>x" + BaitBalise.getFloat() + "</color>, Cooldown : <color=#00ffff>" + BaitBaliseTime.getFloat() + "s</color>,";
                                    BaitZHCN += " Warn Area : <color=#ff00ff>x" + BaitBalise.getFloat() + "</color>, Cooldown : <color=#00ffff>" + BaitBaliseTime.getFloat() + "s</color>,";
                                }
                                else
                                {
                                    Bait += " Warn Area : <color=#ff0000>No</color>,";
                                    BaitFR += " Zone d'alerte : <color=#ff0000>Non</color>,";
                                    BaitZHCN += " Warn Area : <color=#ff0000>No</color>,";
                                }


                                if (BaitCanVent.getBool() == true)
                                {
                                    Bait += " Can Use Vent : <color=#00FF00>yes</color>.";
                                    BaitFR += " peut utiliser les Vents : <color=#00FF00>Oui</color>.";
                                    BaitZHCN += " 可以使用管道 : <color=#00FF00>是</color>.";

                                }
                                if (BaitCanVent.getBool() == false)
                                {
                                    Bait += " Can Use Vent : <color=#FF0000>No</color>.";
                                    BaitFR += " peut utiliser les Vents : <color=#FF0000>Non</color>.";
                                    BaitZHCN += " 可以使用管道 : <color=#FF0000>否</color>.";

                                }


                            }
                            if (BaitSpawnChance.getFloat() > 0 && BaitAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BaitFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BaitZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Bait;
                                }
                            }


                            //Mentalist
                            string Mentalist = "<size=0.75><color=#A991FF>\n> Mentalist : </color>";
                            string MentalistFR = "<size=0.75><color=#A991FF>\n> Mentaliste : </color>";
                            string MentalistZHCN = "<size=0.75><color=#A991FF>\n> 心理医生 : </color>";



                            if (MentalistSpawnChance.getFloat() > 0)

                            {
                                if (MentalistAbility.getSelection() != 1)
                                {
                                    if (AdminSetting.getSelection() == 0)
                                    {
                                        Mentalist += "Mentalist can See players color with admin (<color=#ff00ff>once use per Game</color>) : <color=#00FF00>Yes</color>, for :<color=#00ffff>" + AdminDuration.getFloat() + "s</color>,";

                                        MentalistFR += "Peut voir les couleurs sur la table d'admin (<color=#ff00ff>1 seule fois par partie</color>) : <color=#00FF00>Oui</color>, Pendant :<color=#00ffff>" + AdminDuration.getFloat() + "s</color>,";

                                        MentalistZHCN += "心理医生用管理桌子时可看到玩家的颜色 (<color=#ff00ff>每局游戏一次</color>) : <color=#00FF00>是</color>, 持续时间 :<color=#00ffff>" + AdminDuration.getFloat() + "秒</color>,";
                                    }
                                    else
                                    {
                                        Mentalist += "Mentalist can See players color with admin (<color=#ff00ff>once use per Round</color>) : <color=#00FF00>Yes</color>, for :<color=#00ffff>" + AdminDuration.getFloat() + "s</color>,";

                                        MentalistFR += "Peut voir les couleurs sur la table d'admin (<color=#ff00ff>1x Par Tour</color>) : <color=#00FF00>Yes</color>, Pendant :<color=#00ffff>" + AdminDuration.getFloat() + "s</color>,";

                                        MentalistZHCN += "心理医生用管理桌子时可看到玩家的颜色 (<color=#ff00ff>每局一次</color>) : <color=#00FF00>是</color>, 持续时间 :<color=#00ffff>" + AdminDuration.getFloat() + "秒</color>,";
                                    }

                                }
                                else
                                {
                                    Mentalist += "Mentalist can See players color with admin : <color=#FF0000>No</color>,";

                                    MentalistFR += "Peut voir les couleurs sur la table d'admin : <color=#FF0000>Non</color>,";

                                    MentalistZHCN += "心理医生用管理桌子时可看到玩家的颜色 : <color=#FF0000>否</color>,";
                                }


                                if (MentalistAbility.getSelection() != 0)
                                {
                                    Mentalist += " Can See color votes : <color=#00FF00>Yes</color>.";

                                    MentalistFR += " Peut voir les couleurs des votes : <color=#00FF00>Oui</color>.";

                                    MentalistZHCN += " 可以看到投票颜色 : <color=#00FF00>是</color>.";

                                }
                                else
                                {
                                    Mentalist += " Can See color votes : <color=#FF0000>No</color>.";

                                    MentalistFR += " Peut voir les couleurs des votes : <color=#FF0000>Non</color>.";

                                    MentalistZHCN += " 可以看到投票颜色 : <color=#FF0000>否</color>.";

                                }


                            }
                            if (MentalistSpawnChance.getFloat() > 0 && MentalistAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MentalistFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MentalistZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Mentalist;
                                }
                            }

                            //Mentalist
                            string Builder = "<size=0.75><color=#FFC291>\n> Builder : </color>";
                            string BuilderFR = "<size=0.75><color=#FFC291>\n> Constructeur : </color>";
                            string BuilderZHCN = "<size=0.75><color=#FFC291>\n> 建筑工 : </color>";



                            if (BuilderSpawnChance.getFloat() > 0)

                            {
                                if (MaxBuild.getSelection() == 0)
                                {
                                    if (BuildRound.getBool() == true)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>1</color>, Only one use per round : <color=#00ff00>Yes</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>1</color>, Une seul utilisation par tour : <color=#00ff00>Oui</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>1</color>, 一局只可用一次 : <color=#00ff00>是</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";

                                    }
                                    if (BuildRound.getBool() == false)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>1</color>, Only one use per round : <color=#ff0000>No</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>1</color>, Une seul utilisation par tour : <color=#ff0000>Non</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>1</color>, 一局只可用一次 : <color=#ff0000>否</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";
                                    }
                                }
                                if (MaxBuild.getSelection() == 1)
                                {
                                    if (BuildRound.getBool() == true)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>2</color>, Only one use per round : <color=#00ff00>Yes</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>2</color>, Une seul utilisation par tour : <color=#00ff00>Oui</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>2</color>, 一局只可用一次 : <color=#00ff00>是</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";

                                    }
                                    if (BuildRound.getBool() == false)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>2</color>, Only one use per round : <color=#ff0000>No</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>2</color>, Une seul utilisation par tour : <color=#ff0000>Non</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>2</color>, 一局只可用一次 : <color=#ff0000>否</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";
                                    }
                                }
                                if (MaxBuild.getSelection() == 2)
                                {
                                    if (BuildRound.getBool() == true)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>3</color>, Only one use per round : <color=#00ff00>Yes</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>3</color>, Une seul utilisation par tour : <color=#00ff00>Oui</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";
                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>3</color>, 一局只可用一次 : <color=#00ff00>是</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";

                                    }
                                    if (BuildRound.getBool() == false)
                                    {
                                        Builder += "Max Vent Block :<color=#ff00ff>3</color>, Only one use per round : <color=#ff0000>No</color>. Cooldown :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderFR += "Maximum de Vents blocables : <color=#ff00ff>3</color>, Une seul utilisation par tour : <color=#ff0000>Non</color>. Délai :<color=#00ffff>" + BuildCooldown.getFloat() + "s</color>.";

                                        BuilderZHCN += "最大封锁管道数 :<color=#ff00ff>3</color>, 一局只可用一次 : <color=#ff0000>否</color>. 使用冷却 :<color=#00ffff>" + BuildCooldown.getFloat() + "秒</color>.";
                                    }
                                }


                            }
                            if (BuilderSpawnChance.getFloat() > 0 && BuilderAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BuilderFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BuilderZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Builder;
                                }
                            }
                            //Dictator
                            string Dictator = "<size=0.75><color=#C06A6A>\n> Dictator : </color>";
                            string DictatorFR = "<size=0.75><color=#C06A6A>\n> Dictateur : </color>";
                            string DictatorZHCN = "<size=0.75><color=#FF7A7A>\n> 独裁者 : </color>";



                            if (DictatorSpawnChance.getFloat() > 0)

                            {

                                if (DictatorAbility.getSelection() == 1)
                                {
                                    Dictator += "Can Use NoskipVote : <color=#ff0000>No</color>,";
                                    DictatorFR += "Capacité Votez! disponible : <color=#ff0000>Non</color>,";
                                    DictatorZHCN += "Can Use NoskipVote : <color=#ff0000>No</color>,";

                                }
                                else
                                {
                                    Dictator += "Can Use NoskipVote : <color=#00ff00>Yes</color>,";
                                    DictatorFR += "Capacité Votez! disponible : <color=#00ff00>Oui</color>,";
                                    DictatorZHCN += "Can Use NoskipVote : <color=#00ff00>Yes</color>,";

                                    if (DictatorFirstTurn.getBool() == false)
                                    {
                                        Dictator += " From the first round : <color=#00ff00>Yes</color>,";
                                        DictatorFR += " Dés le premier tour : <color=#00ff00>Oui</color>,";
                                        DictatorZHCN += " From the first round : <color=#00ff00>Yes</color>,";

                                    }
                                    else
                                    {
                                        Dictator += " From the first round : <color=#ff0000>No</color>,";
                                        DictatorFR += " Dés le premier tour : <color=#ff0000>Non</color>,";
                                        DictatorZHCN += " From the first round : <color=#ff0000>No</color>,";

                                    }

                                    if (DictatorMeeting.getSelection() == 0)
                                    {
                                        Dictator += "Mode : <color=#FF00FF>Passive</color> (As long as the dictator is alive).";
                                        DictatorFR += "Mode : <color=#FF00FF>Passif</color> (Tant que le dictateur est en vie).";
                                        DictatorZHCN += "Mode : <color=#FF00FF>Passive</color> (As long as the dictator is alive).";


                                    }
                                    if (DictatorMeeting.getSelection() == 1)
                                    {
                                        Dictator += "Mode : <color=#FF00FF>Round</color> (The dictator chooses when he wants to use his Ability).";
                                        DictatorFR += "Mode : <color=#FF00FF>Selection</color> (Le dictateur choisie quand il active la capacité).";
                                        DictatorZHCN += "Mode : <color=#FF00FF>Round</color> (The dictator chooses when he wants to use his Ability).";


                                    }
                                    if (DictatorMeeting.getSelection() == 2)
                                    {
                                        Dictator += "Mode : <color=#FF00FF>Single</color> (Only one use per Game).";
                                        DictatorFR += "Mode : <color=#FF00FF>Usage Unique</color> (Utilisation 1x par partie).";
                                        DictatorZHCN += "Mode : <color=#FF00FF>Single</color> (Only one use per Game).";


                                    }
                                }

                                if (DictatorAbility.getSelection() == 0)
                                {
                                    Dictator += "\nCan Use ForcedVote : <color=#ff0000>No</color>,";
                                    DictatorFR += "\nCapacité Force-Vote disponible : <color=#ff0000>Non</color>,";
                                    DictatorZHCN += "\nCan Use ForcedVote : <color=#ff0000>No</color>,";

                                }
                                else
                                {
                                    Dictator += "\nCan Use ForcedVote : <color=#00ff00>Yes</color>,";
                                    DictatorFR += "\nCapacité Force-Vote disponible : <color=#00ff00>Oui</color>,";
                                    DictatorZHCN += "\nCan Use ForcedVote : <color=#00ff00>Yes</color>,";


                                    if (DictatorForcedVote.getBool() == true)
                                    {
                                        Dictator += "Dictator targets himself if an innocent is selected : <color=#00ff00>Yes</color>.";
                                        DictatorFR += "Le Dictateur se cible lui même si un innocent est selectionner  : <color=#00ff00>Oui</color>.";
                                        DictatorZHCN += "Dictator targets himself if an innocent is selected : <color=#00ff00>Yes</color>.";

                                    }
                                    else
                                    {
                                        Dictator += "Dictator targets himself if an innocent is selected : <color=#ff0000>No</color>.";
                                        DictatorFR += "Le Dictateur se cible lui même si un innocent est selectionner  : <color=#ff0000>Non</color>.";
                                        DictatorZHCN += "Dictator targets himself if an innocent is selected : <color=#ff0000>No</color>.";

                                    }

                                }


                            }
                            if (DictatorSpawnChance.getFloat() > 0 && DictatorAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += DictatorFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += DictatorZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Dictator;
                                }
                            }


                            //SENTINEL
                            string Sentinel = "<size=0.75><color=#06AD17>\n> Sentinel : </color>";
                            string SentinelFR = "<size=0.75><color=#06AD17>\n> Sentinelle : </color>";
                            string SentinelZHCN = "<size=0.75><color=#06AD17>\n> 哨兵 : </color>";



                            if (SentinelSpawnChance.getFloat() > 0)

                            {

                                Sentinel += "Scan : <color=#00ffff>" + ScanCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + ScanDuration.getFloat() + "s</color> duration,";
                                SentinelFR += "Délai du Scan : <color=#00ffff>" + ScanCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + ScanDuration.getFloat() + "s</color>,";
                                SentinelZHCN += "扫描冷却 : <color=#00ffff>" + ScanCooldown.getFloat() + "秒</color> 持续时间 <color=#00ffff>" + ScanDuration.getFloat() + "秒</color> ,";

                                if (ScanAbility.getSelection() == 0)
                                {
                                    Sentinel += " Enable dead Players : <color=#FF0000>No</color>, In Vent Player : <color=#00ff00>Yes</color>.";
                                    SentinelFR += " Détecte les joueurs - Mort : <color=#FF0000>Non</color>, - Dans une Vent : <color=#00ff00>Oui</color>.";
                                    SentinelZHCN += " 可扫描死亡玩家 : <color=#FF0000>否</color>, 可扫描在管道内的玩家 : <color=#00ff00>是</color>.";
                                }
                                if (ScanAbility.getSelection() == 1)
                                {
                                    Sentinel += " Enable dead Players : <color=#00FF00>Yes</color>, In Vent Player : <color=#ff0000>No</color>.";
                                    SentinelFR += " Détecte les joueurs - Mort : <color=#00FF00>Oui</color>, - Dans une Vent : <color=#ff0000>Non</color>.";
                                    SentinelZHCN += " 可扫描死亡玩家 : <color=#00FF00>是</color>, 可扫描在管道内的玩家 : <color=#ff0000>否</color>.";
                                }
                                if (ScanAbility.getSelection() == 2)
                                {
                                    Sentinel += " Enable dead Players : <color=#00FF00>Yes</color>, In Vent Player : <color=#00ff00>Yes</color>.";
                                    SentinelFR += " Détecte les joueurs - Mort : <color=#00FF00>Oui</color>, - Dans une Vent : <color=#00ff00>Oui</color>.";
                                    SentinelZHCN += " 可扫描死亡玩家 : <color=#00FF00>是</color>, 可扫描在管道内的玩家 : <color=#00ff00>否</color>.";
                                }
                            }
                            if (SentinelSpawnChance.getFloat() > 0 && SentinelAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SentinelFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SentinelZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Sentinel;
                                }
                            }

                            //LAWKEEPR
                            string Lawkeeper = "<size=0.75><color=#FF9b9b>\n> Lawkeeper : </color>";
                            string LawkeeperFR = "<size=0.75><color=#FF9b9b>\n> Justicier : </color>";
                            string LawkeeperZHCN = "<size=0.75><color=#FF9b9b>\n> 验尸官 : </color>";


                            if (LawkeeperSpawnChance.getFloat() > 0)

                            {

                                Lawkeeper += "if Lawkeeper Report deadbody :";
                                LawkeeperFR += "Si il Signale un Corps :";
                                LawkeeperZHCN += "如果验尸官报告尸体 :";

                                if (LKTimer.getBool() == true)
                                {
                                    Lawkeeper += " The kill delay is revealed : <color=#00ff00>Yes</color>.";
                                    LawkeeperFR += " Il Obtient le délai de la Mort : <color=#00ff00>Oui</color>.";
                                    LawkeeperZHCN += " 显示距击杀时间 : <color=#00ff00>时</color>.";
                                }
                                else
                                {
                                    Lawkeeper += " The kill delay is revealed : <color=#FF0000>No</color>.";
                                    LawkeeperFR += " Il Obtient le délai de la Mort : <color=#FF0000>Non</color>.";
                                    LawkeeperZHCN += " 显示距击杀时间 : <color=#FF0000>否</color>.";
                                }

                                if (LKInfo.getBool() == true)
                                {
                                    Lawkeeper += " Information about Kill revealed : <color=#00ff00>Yes</color>.";
                                    LawkeeperFR += " Des informations sur la Mort : <color=#00ff00>Oui</color>.";
                                    LawkeeperZHCN += " 显示击杀的信息 : <color=#00ff00>是</color>.";
                                }
                                else
                                {
                                    Lawkeeper += " Information about Kill revealed : <color=#FF0000>No</color>.";
                                    LawkeeperFR += " Des informations sur la Mort : <color=#FF0000>Non</color>.";
                                    LawkeeperZHCN += " 显示击杀的信息 : <color=#FF0000>否</color>.";
                                }




                                if (TimeRName.getFloat() == 0)
                                {
                                    if (TimeRList.getFloat() == 0)
                                    {
                                        Lawkeeper += "";
                                        LawkeeperFR += "";
                                        LawkeeperZHCN += "";


                                    }
                                    else
                                    {
                                        Lawkeeper += "\nIf the kill has less than<color=#00ffff> " + TimeRList.getFloat() + "s</color> Suspect List reveal.";
                                        LawkeeperFR += "\nSi le meurtre à eu lieux avant <color=#00ffff> " + TimeRList.getFloat() + "s</color> Il obtient une liste de suspect.";
                                        LawkeeperZHCN += "\n如果距离击杀时间少于<color=#00ffff> " + TimeRList.getFloat() + "秒</color> 显示嫌疑人名单.";

                                    }
                                }
                                else
                                {
                                    if (TimeRList.getFloat() == 0)
                                    {
                                        Lawkeeper += "\nIf the kill has less than<color=#00ffff> " + TimeRName.getFloat() + "s</color> Killer Name reveal.";
                                        LawkeeperFR += "\nSi le meurtre à eu lieux avant <color=#00ffff> " + TimeRName.getFloat() + "s</color> Il obtient le nom du tueur.";
                                        LawkeeperZHCN += "\n如果距离击杀时间少于<color=#00ffff> " + TimeRName.getFloat() + "秒</color>  显示凶手名字.";

                                    }
                                    else
                                    {
                                        Lawkeeper += "\nIf the kill has less than<color=#00ffff> " + TimeRName.getFloat() + "s</color> Killer Name reveal, \nIf the kill has less than<color=#00ffff> " + TimeRList.getFloat() + "s</color> Suspect List reveal.";
                                        LawkeeperFR += "\nSi le meurtre à eu lieux avant <color=#00ffff> " + TimeRName.getFloat() + "s</color> Il obtient le nom du tueur, \nSi le meurtre à eu lieux avant<color=#00ffff> " + TimeRList.getFloat() + "s</color> Il obtient une liste de suspect.";
                                        LawkeeperZHCN += "\n如果距离击杀时间少于<color=#00ffff> " + TimeRName.getFloat() + "秒</color> 显示凶手名字, \n如果距离击杀时间少于<color=#00ffff> " + TimeRList.getFloat() + "秒</color> 显示嫌疑人名单.";

                                    }
                                }
                            }
                            if (LawkeeperSpawnChance.getFloat() > 0 && LawkeeperAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LawkeeperFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LawkeeperZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Lawkeeper;
                                }
                            }

                            //FAKE
                            string Fake = "<size=0.75><color=#FF7A7A>\n> Fake : </color>";
                            string FakeFR = "<size=0.75><color=#FF7A7A>\n> Intru : </color>";
                            string FakeZHCN = "<size=0.75><color=#FF7A7A>\n> 卧底 : </color>";



                            if (FakeSpawnChance.getFloat() > 0)

                            {
                                if (ImpostorCanKillFake.getBool() == true)
                                {
                                    Fake += "All Impostors can kill the Fake and Other Impostors : <color=#00FF00>Yes</color>,";
                                    FakeFR += "Les Imposteurs peuvent tuer l'intru et les autres imposteurs : <color=#00FF00>Oui</color>,";
                                    FakeZHCN += "所有内鬼都可以击杀卧底和其他内鬼 : <color=#00FF00>是</color>,";

                                }
                                if (ImpostorCanKillFake.getBool() == false)
                                {
                                    Fake += "All Impostors can kill the Fake and Other Impostors : <color=#FF0000>No</color>,";
                                    FakeFR += "Les Imposteurs peuvent tuer l'intru et les autres imposteurs : <color=#FF0000>Non</color>,";
                                    FakeZHCN += "所有内鬼都可以击杀卧底和其他内鬼 : <color=#FF0000>否</color>,";

                                }

                                if (FakeCanVent.getBool() == true)
                                {
                                    Fake += " Can Use Vent : <color=#00FF00>Yes</color>.";
                                    FakeFR += " Peut utiliser les vents : <color=#00FF00>Oui</color>,";
                                    FakeZHCN += " 可以使用管道 : <color=#00FF00>是</color>.";

                                }
                                if (FakeCanVent.getBool() == false)
                                {
                                    Fake += " Can Use Vent : <color=#FF0000>No</color>.";
                                    FakeFR += " Peut utiliser les vents : <color=#FF0000>Non</color>.";
                                    FakeZHCN += " 可以使用管道 : <color=#FF0000>否</color>.";

                                }



                            }
                            if (FakeSpawnChance.getFloat() > 0 && FakeAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += FakeFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += FakeZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Fake;
                                }
                            }

                            //LEADER
                            string Leader = "<size=0.75><color=#5A7DA5>\n> Leader : </color>";
                            string LeaderFR = "<size=0.75><color=#5A7DA5>\n> Chef : </color>";
                            string LeaderZHCN = "<size=0.75><color=#5A7DA5>\n> 领袖 : </color>";


                            if (LeaderSpawnChance.getFloat() > 0)

                            {

                                if (LeaderTaskEnd.getBool() == true)
                                {
                                    Leader += "Mark Second player when : <color=#ff00ff>Player die or All task Completed</color>";
                                    LeaderFR += "Marque le 2eme Joueur Si : <color=#ff00ff>Le Chef Meure ou si il termine toute ces tâches</color>";
                                    LeaderZHCN += "Mark Second player when : <color=#ff00ff>Player die or All task Completed</color>";

                                }
                                else
                                {
                                    Leader += "Mark Second player when : <color=#ff00ff>Player die</color>";
                                    LeaderFR += "Marque le 2eme Joueur Si : <color=#ff00ff>Le Chef Meure</color>";
                                    LeaderZHCN += "Mark Second player when : <color=#ff00ff>Player die</color>";

                                }

                                if (CupidAdd.getBool() == true && CupidSpawnChance.getFloat() > 0)
                                {
                                    if (LeaderAffectCupid.getBool() == false)
                                    {
                                        Leader += ", if the cupid is marked : <color=#ff00ff>Crewmates cannot be designer</color> by the second mark.";
                                        LeaderFR += ", Si le Cupidon est marquer : <color=#ff00ff>Les coéquipiers ne pourront pas être désignés</color> par la 2eme marque.";
                                        LeaderZHCN += ", if the cupid is marked : <color=#ff00ff>Crewmates cannot be designer</color> by the second mark.";

                                    }
                                    else
                                    {
                                        Leader += ", if the cupid is marked : <color=#ff00ff>Crewmates can be designer</color> by the second mark.";
                                        LeaderFR += ", si le Cupidon est marquer : <color=#ff00ff>Les coéquipiers pourront être désignés</color> par la 2eme marque.";
                                        LeaderZHCN += ", if the cupid is marked : <color=#ff00ff>Crewmates can be designer</color> by the second mark.";

                                    }
                                }

                                else
                                {
                                    Leader += ".";
                                    LeaderFR += ".";
                                    LeaderZHCN += ".";

                                }


                            }
                            if (LeaderSpawnChance.getFloat() > 0 && LeaderAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LeaderFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += LeaderZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Leader;
                                }
                            }
                        }

                        //SPACER ---
                        string SpacerSpe = "\n";
                        __instance.GameSettings.text += SpacerSpe;

                        //ROLESSETTINGS
                        string Speciaux = "<color=#DE24DE><size=1>\n[Specials Role]</size></color>";
                        string SpeciauxFR = "<color=#DE24DE><size=1>\n[Rôles Spéciaux]</size></color>";
                        string SpeciauxZHCN = "<color=#DE24DE><size=1>\n[Specials Role]</size></color>";

                        if (Challenger.Setting_TabSetSpe == "1")
                        {
                            Speciaux += "<color=#FF6666><size=0.85> - (Press F4 to Hide)\n</size></color>";
                            SpeciauxFR += "<color=#FF6666><size=0.85> - (Appuyez sur F4 pour Masquer)\n</size></color>";
                            SpeciauxZHCN += "<color=#FF6666><size=0.85> - (Press F4 to Hide)\n</size></color>";
                        }
                        else
                        {
                            Speciaux += "<color=#FF6666><size=0.85> - (Press F4 for Show)\n</size></color>";
                            SpeciauxFR += "<color=#FF6666><size=0.85> - (Appuyez sur F4 pour Afficher)\n</size></color>";
                            SpeciauxZHCN += "<color=#FF6666><size=0.85> - (Press F4 for Show)\n</size></color>";
                        }


                        if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += SpeciauxFR;
                        }
                        else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += SpeciauxZHCN;
                        }
                        else
                        {
                            __instance.GameSettings.text += Speciaux;
                        }
                        if (Challenger.Setting_TabSetSpe == "1")
                        {
                            //JESTER
                            string Jester = "<size=0.75><color=#FF0A88>\n> Jester : </color>";
                            string JesterFR = "<size=0.75><color=#FF0A88>\n> Bouffon : </color>";
                            string JesterZHCN = "<size=0.75><color=#FF0A88>\n> 小丑 : </color>";


                            if (JesterSpawnChance.getFloat() > 0)

                            {


                                if (JesterSingle.getSelection() == 0)
                                {
                                    Jester += "Fake Kill Cooldown : <color=#00ffff>" + JesterCooldown.getFloat() + "s</color>, Only use one time";
                                    JesterFR += "Délai du Faux Meurtre : <color=#00ffff>" + JesterCooldown.getFloat() + "s</color>, Usage unique";
                                    JesterZHCN += "假杀冷却 : <color=#00ffff>" + JesterCooldown.getFloat() + "秒</color>, 仅可使用一次";

                                }
                                if (JesterSingle.getSelection() == 1)
                                {
                                    Jester += "Fake Kill Cooldown : <color=#00ffff>" + JesterCooldown.getFloat() + "s</color>";
                                    JesterFR += "Délai du Faux Meurtre : <color=#00ffff>" + JesterCooldown.getFloat() + "s</color>";
                                    JesterZHCN += "假杀冷却 : <color=#00ffff>" + JesterCooldown.getFloat() + "秒</color>";


                                }
                                if (JesterSingle.getSelection() == 2)
                                {
                                    Jester += "Fake Kill :<color=#ff0000> Disable</color>";
                                    JesterFR += "Faux Meurtre :<color=#ff0000> Désactivé</color>";
                                    JesterZHCN += "假杀 :<color=#ff0000>禁用</color>";
                                }
                                if (JesterCanVent.getBool() == true)
                                {
                                    Jester += ", Can Use Vent : <color=#00ff00>Yes</color>";
                                    JesterFR += ", Peut utiliser les vents : <color=#00ff00>Oui</color>";
                                    JesterZHCN += ", 可以钻管 : <color=#00ff00>是</color>";
                                }
                                if (JesterCanVent.getBool() == false)
                                {
                                    Jester += ", Can Use Vent : <color=#FF0000>No</color>";
                                    JesterFR += ", Peut utiliser les vents : <color=#FF0000>Non</color>";
                                    JesterZHCN += ", 可以钻管 : <color=#FF0000>否</color>";
                                }
                                
                                if (JesterIMPV.getBool() == true)
                                {
                                    Jester += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    JesterFR += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    JesterZHCN += "\n视野 : <color=#ff00ff>仅限内鬼</color>,";

                                    if (JesterIMPVS.getBool() == true)
                                    {
                                        Jester += ", Affected by Light sabotage : <color=#00ff00>Yes</color>.";
                                        JesterFR += ", Affecter par les sabotages des Lumières : <color=#00ff00>Oui</color>.";
                                        JesterZHCN += ", 受灯光破坏影响 : <color=#00ff00>是</color>.";
                                    }
                                    if (JesterIMPVS.getBool() == false)
                                    {
                                        Jester += ", Affected by Light sabotage : <color=#ff0000>no</color>.";
                                        JesterFR += ", Affecter par les sabotages des Lumières : <color=#ff0000>Non</color>.";
                                        JesterZHCN += ", 受灯光破坏影响 : <color=#ff0000>否</color>.";
                                    }

                                }
                                if (JesterIMPV.getBool() == false)
                                {
                                    Jester += "\nVision : <color=#ff00ff>Normal</color>.";
                                    JesterFR += "\nVision : <color=#ff00ff>Normal</color>.";
                                    JesterZHCN += "\n视野 : <color=#ff00ff>正常</color>.";
                                }



                            }
                            if (JesterSpawnChance.getFloat() > 0 && JesterAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += JesterFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += JesterZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Jester;
                                }
                            }



                            //CUPID
                            string Cupid = "<size=0.75><color=#FFAFFF>\n> Cupid : </color>";
                            string CupidFR = "<size=0.75><color=#FFAFFF>\n> Cupidon : </color>";
                            string CupidZHCN = "<size=0.75><color=#FFAFFF>\n> 丘比特 : </color>";


                            if (CupidSpawnChance.getFloat() > 0)

                            {
                                if (Loverdie.getBool() == true)
                                {
                                    Cupid += "Both Lovers die : <color=#00FF00>Yes</color>.";
                                    CupidFR += "Les Amoureux meurent ensemble : <color=#00FF00>Oui</color>.";
                                    CupidZHCN += "恋人共死 : <color=#00FF00>是</color>.";

                                }
                                if (Loverdie.getBool() == false)
                                {
                                    Cupid += "Both Lovers die : <color=#FF0000>No</color>.";
                                    CupidFR += "Les Amoureux meurent ensemble : <color=#FF0000>Non</color>.";
                                    CupidZHCN += "恋人共死 : <color=#FF0000>否</color>.";

                                }


                            }
                            if (CupidSpawnChance.getFloat() > 0 && CupidAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CupidFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CupidZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Cupid;
                                }
                            }






                            //EATER
                            string Eater = "<size=0.75><color=#FF6E00>\n> Eater : </color>";
                            string EaterFR = "<size=0.75><color=#FF6E00>\n> Dévoreur : </color>";


                            if (EaterSpawnChance.getFloat() > 0)

                            {
                                if (EaterCanVent.getBool() == true)
                                {

                                    if (EaterCanDrag.getBool() == true)
                                    {

                                        if (BodyRemove.getBool() == true)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#00FF00>Yes</color>, Can Vent : <color=#00FF00>Yes</color>, Blood removed after meeting : <color=#00FF00>Yes</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>, Traces de sang effacées après une réunion : <color=#00FF00>Oui</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#00FF00>是</color>, 可以钻管 : <color=#00FF00>是</color>, 在会议后移除血迹 : <color=#00FF00>是</color>.";

                                        }
                                        if (BodyRemove.getBool() == false)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#00FF00>Yes</color>, Can Vent : <color=#00FF00>Yes</color>, Blood removed after meeting : <color=#FF0000>No</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>, Traces de sang effacées après une réunion : <color=#FF0000>Non</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#00FF00>是</color>, 可以钻管 : <color=#00FF00>是</color>, 在会议后移除血迹 : <color=#FF0000>否</color>.";

                                        }

                                    }
                                    if (EaterCanDrag.getBool() == false)
                                    {
                                        if (BodyRemove.getBool() == true)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#FF0000>No</color>, Can Vent : <color=#00FF00>Yes</color>, Blood removed after meeting : <color=#00FF00>Yes</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>, Traces de sang effacées après une réunion : <color=#00FF00>Oui</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#FF0000>否</color>, 可以钻管 : <color=#00FF00>是</color>, 在会议后移除血迹 : <color=#00FF00>是</color>.";

                                        }
                                        if (BodyRemove.getBool() == false)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#FF0000>No</color>, Can Vent : <color=#00FF00>Yes</color>, Blood removed after meeting : <color=#FF0000>No</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>, Traces de sang effacées après une réunion : <color=#FF0000>Non</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#FF0000>否</color>, 可以钻管 : <color=#00FF00>是</color>, 在会议后移除血迹 : <color=#FF0000>否</color>.";

                                        }



                                    }
                                }
                                if (EaterCanVent.getBool() == false)
                                {
                                    if (EaterCanDrag.getBool() == true)
                                    {

                                        if (BodyRemove.getBool() == true)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#00FF00>Yes</color>, Can Vent : <color=#FF0000>No</color>, Blood removed after meeting : <color=#00FF00>Yes</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>, Traces de sang effacées après une réunion : <color=#00FF00>Oui</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#00FF00>是</color>, 可以钻管 : <color=#FF0000>否</color>, 在会议后移除血迹 : <color=#00FF00>是</color>.";

                                        }
                                        if (BodyRemove.getBool() == false)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#00FF00>Yes</color>, Can Vent : <color=#FF0000>No</color>, Blood removed after meeting : <color=#FF0000>No</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>, Traces de sang effacées après une réunion : <color=#FF0000>Non</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#00FF00>是</color>, 可以钻管 : <color=#FF0000>否</color>, 在会议后移除血迹 : <color=#FF0000>否</color>.";

                                        }

                                    }
                                    if (EaterCanDrag.getBool() == false)
                                    {

                                        if (BodyRemove.getBool() == true)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#FF0000>No</color>, Can Vent : <color=#FF0000>No</color>, Blood removed after meeting : <color=#00FF00>Yes</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>, Traces de sang effacées après une réunion : <color=#00FF00>Oui</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#FF0000>否</color>, 可以钻管 : <color=#FF0000>否</color>, 在会议后移除血迹 : <color=#00FF00>是</color>.";

                                        }
                                        if (BodyRemove.getBool() == false)
                                        {
                                            Eater += "Digest cooldown : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Time for Eat : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Body Eated for win : <color=#00ffff>x" + Eatervaluewin + "</color>, Eater Can Drag a Body : <color=#FF0000>No</color>, Can Vent : <color=#FF0000>No</color>, Blood removed after meeting : <color=#FF0000>No</color>.";
                                            EaterFR += "Délai de Digestion : <color=#00ffff>" + EaterCooldown.getFloat() + "s</color>, Durée pour Dévorer : <color=#00ffff>" + Eaterduration.getFloat() + "s</color>, Nombre de Corps à dévorer pour Gagner : <color=#00ffff>x" + Eatervaluewin + "</color>, \nPeut Déplacer les corps : <color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>, Traces de sang effacées après une réunion : <color=#FF0000>Non</color>.";
                                            EaterZHCN += "消化冷却 : <color=#00ffff>" + EaterCooldown.getFloat() + "秒</color>, 吞噬所需时间 : <color=#00ffff>" + Eaterduration.getFloat() + "秒</color>, 胜利所需吃尸体数 : <color=#00ffff>x" + Eatervaluewin + "</color>, 秃鹫可以拖拽尸体 : <color=#FF0000>否</color>, 可以钻管 : <color=#FF0000>否</color>, 在会议后移除血迹 : <color=#FF0000>否</color>.";

                                        }

                                    }
                                }
                                if (EaterIMPV.getBool() == true)
                                {
                                    Eater += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    EaterFR += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    EaterZHCN += "\n视野 : <color=#ff00ff>仅限内鬼</color>,";

                                    if (EaterIMPVS.getBool() == true)
                                    {
                                        Eater += ", Affected by Light sabotage : <color=#00ff00>Yes</color>.";
                                        EaterFR += ", Affecter par les sabotages des Lumières : <color=#00ff00>Oui</color>.";
                                        EaterZHCN += ", 受灯光破坏影响 : <color=#00ff00>是</color>.";
                                    }
                                    if (EaterIMPVS.getBool() == false)
                                    {
                                        Eater += ", Affected by Light sabotage : <color=#ff0000>no</color>.";
                                        EaterFR += ", Affecter par les sabotages des Lumières : <color=#ff0000>Non</color>.";
                                        EaterZHCN += ", 受灯光破坏影响 : <color=#ff0000>否</color>.";
                                    }

                                }
                                if (EaterIMPV.getBool() == false)
                                {
                                    Eater += "\nVision : <color=#ff00ff>Normal</color>.";
                                    EaterFR += "\nVision : <color=#ff00ff>Normal</color>.";
                                    EaterZHCN += "\n视野 : <color=#ff00ff>正常</color>.";
                                }
                            }
                            if (EaterSpawnChance.getFloat() > 0 && EaterAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += EaterFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += EaterZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Eater;
                                }
                            }

                            //CULTE
                            string Culte = "<size=0.75><color=#8300FF>\n> Cultist : </color>";
                            string CulteFR = "<size=0.75><color=#8300FF>\n> Cultiste : </color>";
                            string CulteZHCN = "<size=0.75><color=#8300FF>\n> 教主 : </color>";


                            if (CultisteSpawnChance.getFloat() > 0)

                            {
                                if (Cultistdie.getSelection() == 0)
                                {
                                    Culte += "Max Member of Culte : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Cooldowns : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Don't die if he fails his conversion</color>.";

                                    CulteFR += "Nombre de Conversion Possible : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Délai : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Ne meurt pas en cas d'echec de conversion</color>.";

                                    CulteZHCN += "最大邪教成员数 : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, 转换冷却 : <color=#00ffff>" + CultisteCooldown.getFloat() + "秒</color>, <color=#FF00FF>如果转换失败不会死亡</color>.";
                                }
                                if (Cultistdie.getSelection() == 1)
                                {
                                    Culte += "Max Member of Culte : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Cooldowns : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Dies immediately if conversion fails</color>.";

                                    CulteFR += "Nombre de Conversion Possible : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Délai : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Meurt immédiatement en cas d'echec de conversion</color>.";

                                    CulteZHCN += "最大邪教成员数 : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, 转换冷却 : <color=#00ffff>" + CultisteCooldown.getFloat() + "秒</color>, <color=#FF00FF>如果转换失败将会死亡</color>.";
                                }
                                if (Cultistdie.getSelection() == 2)
                                {
                                    Culte += "Max Member of Culte : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Cooldowns : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Dies at the start of the next meeting if the conversion fails</color>.";

                                    CulteFR += "Nombre de Conversion Possible : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, Délai : <color=#00ffff>" + CultisteCooldown.getFloat() + "s</color>, <color=#FF00FF>Meurt au début du prochain meeting en cas d'echec de conversion</color>.";

                                    CulteZHCN += "最大邪教成员数 : <color=#00ffff>x" + CulteMember.getFloat() + "</color>, 转换冷却 : <color=#00ffff>" + CultisteCooldown.getFloat() + "秒</color>, <color=#FF00FF>如果转换失败将会在下次会议开始时死亡</color>.";
                                }



                            }
                            if (CultisteSpawnChance.getFloat() > 0 && CultisteAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CulteFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CulteZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Culte;
                                }
                            }


                            //OUTLAW
                            string Outlaw = "<size=0.75><color=#0033ff>\n> Outlaw : </color>";
                            string OutlawFR = "<size=0.75><color=#0033ff>\n> Criminel : </color>";
                            string OutlawZHCN = "<size=0.75><color=#0033ff>\n> 亡命徒 : </color>";


                            if (OutlawSpawnChance.getFloat() > 0)

                            {
                                if (OutlawKillRange.getSelection() == 0)
                                {
                                    Outlaw += "Kill Cooldown : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "s</color>, Kill distance : <color=#ff00ff>Normal (100%)</color>";
                                    OutlawFR += "Délai pour Tuer : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "s</color>, distance : <color=#ff00ff>Normal (100%)</color>";
                                    OutlawZHCN += "击杀冷却 : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "秒</color>, 击杀范围 : <color=#ff00ff>正常 (100%)</color>";

                                }
                                if (OutlawKillRange.getSelection() == 1)
                                {
                                    Outlaw += "Kill Cooldown : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "s</color>, Kill distance : <color=#ff00ff>Upgraded (120%)</color>";
                                    OutlawFR += "Délai pour Tuer : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "s</color>, distance : <color=#ff00ff>Amélioré (120%)</color>";
                                    OutlawZHCN += "击杀冷却 : <color=#00ffff>" + OutlawKillCooldown.getFloat() + "秒</color>, 击杀范围 : <color=#ff00ff>提升 (120%)</color>";

                                }
                                if (OutlawCanVent.getBool() == true)
                                {
                                    Outlaw += ", Can Use Vent : <color=#00ff00>Yes</color>.";
                                    OutlawFR += ", Peut utiliser les Vents : <color=#00ff00>Oui</color>.";
                                    OutlawZHCN += ", 可以使用管道 : <color=#00ff00>是</color>.";

                                }
                                if (OutlawCanVent.getBool() == false)
                                {
                                    Outlaw += ", Can Use Vent : <color=#FF0000>No</color>.";
                                    OutlawFR += ", Peut utiliser les Vents : <color=#FF0000>Non</color>.";
                                    OutlawZHCN += ", 可以使用管道 : <color=#00ff00>否</color>.";

                                }
                                if (OutlawIMPV.getBool() == true)
                                {
                                    Outlaw += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    OutlawFR += "\nVision : <color=#ff00ff>Impostor</color>,";
                                    OutlawZHCN += "\n视野 : <color=#ff00ff>仅限内鬼</color>,";

                                    if (OutlawIMPVS.getBool() == true)
                                    {
                                        Outlaw += ", Affected by Light sabotage : <color=#00ff00>Yes</color>.";
                                        OutlawFR += ", Affecter par les sabotages des Lumières : <color=#00ff00>Oui</color>.";
                                        OutlawZHCN += ", 受灯光破坏影响 : <color=#00ff00>是</color>.";
                                    }
                                    if (OutlawIMPVS.getBool() == false)
                                    {
                                        Outlaw += ", Affected by Light sabotage : <color=#ff0000>no</color>.";
                                        OutlawFR += ", Affecter par les sabotages des Lumières : <color=#ff0000>Non</color>.";
                                        OutlawZHCN += ", 受灯光破坏影响 : <color=#ff0000>否</color>.";
                                    }

                                }
                                if (OutlawIMPV.getBool() == false)
                                {
                                    Outlaw += "\nVision : <color=#ff00ff>Normal</color>.";
                                    OutlawFR += "\nVision : <color=#ff00ff>Normal</color>.";
                                    OutlawZHCN += "\n视野 : <color=#ff00ff>正常</color>.";
                                }



                            }
                            if (OutlawSpawnChance.getFloat() > 0 && OutlawAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += OutlawFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += OutlawZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Outlaw;
                                }
                            }

                            //ARSONIST
                            string Arsonist = "<size=0.75><color=#ffc800>\n> Arsonist : </color>";
                            string ArsonistFR = "<size=0.75><color=#ffc800>\n> Pyromane : </color>";
                            string ArsonistZHCN = "<size=0.75><color=#ffc800>\n> 纵火犯 : </color>";


                            if (ArsonistSpawnChance.getFloat() > 0)

                            {
                                Arsonist += "Oil Cooldown : <color=#00ffff>" + ArsonistCooldown.getFloat() + "s</color>,";
                                ArsonistFR += "Délai pour Huiler : <color=#00ffff>" + ArsonistCooldown.getFloat() + "s</color>,";
                                ArsonistZHCN += "浇油冷却 : <color=#00ffff>" + ArsonistCooldown.getFloat() + "秒</color>,";


                                if (ArsonistDuration.getFloat() == 0)
                                {
                                    Arsonist += " Cast Time : <color=#ff0000>No</color>, ";
                                    ArsonistFR += " Temps d'action : <color=#ff0000>Non</color>, ";
                                    ArsonistZHCN += " 拥有行动时间 : <color=#ff0000>否</color>, ";
                                }
                                else
                                {
                                    Arsonist += " Cast Time : <color=#00ffff>" + ArsonistDuration.getFloat() + "s</color>, if ability failed : <color=#00ffff>+" + ArsonistFailDuration.getFloat() + "s</color>,\n";
                                    ArsonistFR += " Temps d'action : <color=#00ffff>" + ArsonistDuration.getFloat() + "s</color>, Délai en cas d'échec : <color=#00ffff>+" + ArsonistFailDuration.getFloat() + "s</color>,\n";
                                    ArsonistZHCN += " 行动时间 : <color=#00ffff>" + ArsonistDuration.getFloat() + "秒</color>, 如果技能使用失败 : <color=#00ffff>+" + ArsonistFailDuration.getFloat() + "秒冷却</color>,\n";
                                }

                                if (ArsonistFuelQT.getFloat() == 0)
                                {
                                    Arsonist += "Oil Quantity for Use : <color=#ff0000>Disabled</color>";
                                    ArsonistFR += "Quantité d'huile requis : <color=#ff0000>Désactivé</color>";
                                    ArsonistZHCN += "浇油会使用油量 : <color=#ff0000>禁用</color>";
                                }
                                else
                                {
                                    Arsonist += " Oil Quantity for Use : <color=#00ffff>" + ArsonistFuelQT.getFloat() + "%</color>";
                                    ArsonistFR += " Quantité d'huile requis : <color=#00ffff>" + ArsonistFuelQT.getFloat() + "%</color>";
                                    ArsonistZHCN += " 浇油使用的油量 : <color=#00ffff>" + ArsonistFuelQT.getFloat() + "%</color>";
                                }


                                if (AutoRefuel.getBool() == true && ArsonistFuelQT.getFloat() != 0)
                                {
                                    Arsonist += ", Meeting Auto Refuel : <color=#00ffff>+" + ArsonistFuelQT.getFloat() + "%</color>.";
                                    ArsonistFR += ", Rechage d'huile en meeting : <color=#00ffff>+" + ArsonistFuelQT.getFloat() + "%</color>.";
                                    ArsonistZHCN += ", 会议自动加油量 : <color=#00ffff>+" + ArsonistFuelQT.getFloat() + "%</color>.";

                                }
                                if (AutoRefuel.getBool() == true && ArsonistFuelQT.getFloat() == 0)
                                {
                                    Arsonist += ".";
                                    ArsonistFR += ".";
                                    ArsonistZHCN += ".";

                                }
                                if (AutoRefuel.getBool() == false)
                                {
                                    Arsonist += ", Meeting Auto Refuel : <color=#ff0000>Disable</color>.";
                                    ArsonistFR += ", Rechage d'huile en meeting : <color=#ff0000>Désactivé</color>.";
                                    ArsonistZHCN += ", 会议自动加油 : <color=#ff0000>禁用</color>.";
                                }

                            }
                            if (ArsonistSpawnChance.getFloat() > 0 && ArsonistAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += ArsonistFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += ArsonistZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Arsonist;
                                }
                            }


                            //CURSED
                            string Cursed = "<size=0.75><color=#3F683B>\n> Cursed : </color>";
                            string CursedFR = "<size=0.75><color=#3F683B>\n> Maudit : </color>";
                            string CursedZHCN = "<size=0.75><color=#3F683B>\n> 被诅咒者 : </color>";


                            if (CursedSpawnChance.getFloat() > 0)

                            {

                                if (CursedSpeedModifieur.getSelection() == 0)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>100%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>100%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 1)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>110%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>110%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>110%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 2)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>120%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>120%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 3)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>130%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间: <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>130%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 4)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>140%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>140%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 5)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>150%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>150%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 6)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>80%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>80%</color>";
                                }
                                if (CursedSpeedModifieur.getSelection() == 7)
                                {
                                    Cursed += "Curse disable for : <color=#00ffff>" + CursedTimer.getFloat() + "s</color>, charging speed <color=#00ffff>90%</color>";
                                    CursedFR += "Malédiction inactif pendant : <color=#00ffff>" + CursedTimer.getFloat() + "</color>s, Vitesse de charge <color=#00ffff>100%</color>";
                                    CursedZHCN += "诅咒禁用时间 : <color=#00ffff>" + CursedTimer.getFloat() + "秒</color>, 恢复速度 <color=#00ffff>90%</color>";
                                }


                                if (CursedAbility.getBool() == false)
                                {

                                    Cursed += ", Shelter Ability available : <color =#ff0000>No</color>.";
                                    CursedFR += ", Capacité Abri disponible : <color =#ff0000>Non</color>.";
                                    CursedZHCN += ", 庇护技能可用 : <color =#ff0000>否</color>.";

                                }
                                else
                                {
                                    Cursed += "\n Shelter Ability cooldown : <color=#00ffff>" + CursedCooldown.getFloat() + "</color>s, duration : <color=#00ffff>" + CursedDuration.getFloat() + "s</color>.";
                                    CursedFR += "\n Temps de recharge de la capacité Abri : <color=#00ffff>" + CursedCooldown.getFloat() + "</color>s, Durée de l'effet : <color=#00ffff>" + CursedDuration.getFloat() + "s</color>.";
                                    CursedZHCN += "\n 庇护技能冷却 : <color=#00ffff>" + CursedCooldown.getFloat() + "</color>秒, 持续时间 : <color=#00ffff>" + CursedDuration.getFloat() + "秒</color>.";
                                }
                            }
                            if (CursedSpawnChance.getFloat() > 0 && CursedAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CursedFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CursedZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Cursed;
                                }
                            }

                        }



                        //SPACER ---
                        string SpacerDuo = "\n";
                        __instance.GameSettings.text += SpacerDuo;

                        //ROLESSETTINGS
                        string Duo = "<color=#A232EC><size=1>\n[Hybrid Role]</size></color>";
                        string DuoFR = "<color=#A232EC><size=1>\n[Rôles Hybride]</size></color>";
                        string DuoZHCN = "<color=#A232EC><size=1>\n[Hybrid Role]</size></color>";

                        if (Challenger.Setting_TabSetHyb == "1")
                        {
                            Duo += "<color=#FF6666><size=0.85> - (Press F5 to Hide)\n</size></color>";
                            DuoFR += "<color=#FF6666><size=0.85> - (Appuyez sur F5 pour Masquer)\n</size></color>";
                            DuoZHCN += "<color=#FF6666><size=0.85> - (Press F5 to Hide)\n</size></color>";
                        }
                        else
                        {
                            Duo += "<color=#FF6666><size=0.85> - (Press F5 for Show)\n</size></color>";
                            DuoFR += "<color=#FF6666><size=0.85> - (Appuyez sur F5 pour Afficher)\n</size></color>";
                            DuoZHCN += "<color=#FF6666><size=0.85> - (Press F5 for Show)\n</size></color>";
                        }


                        if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += DuoFR;
                        }
                        else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += DuoZHCN;
                        }
                        else
                        {
                            __instance.GameSettings.text += Duo;
                        }


                        if (Challenger.Setting_TabSetHyb == "1")
                        {
                            //MERCENARY
                            string Mercenary = "<size=0.75><color=#FF49E6>\n> Mercenary : </color>";
                            string MercenaryFR = "<size=0.75><color=#FF49E6>\n> Mercenaire : </color>";
                            string MercenaryZHCN = "<size=0.75><color=#FF49E6>\n> 雇佣兵 : </color>";



                            if (MercenarySpawnChance.getFloat() > 0)

                            {
                                if (MercenaryCanVent.getBool() == true)
                                {
                                    Mercenary += "Kill Cooldown : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "s</color>, Can Use Vent : <color=#00FF00>Yes</color>.";
                                    MercenaryFR += "Délai pour Tuer : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "s</color>, Peut utiliser les vents : <color=#00FF00>Oui</color>.";
                                    MercenaryZHCN += "击杀冷却 : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "秒</color>, 可以钻管 : <color=#00FF00>是</color>.";

                                }
                                else
                                {
                                    Mercenary += "Kill Cooldown : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "s</color>, Can Use Vent : <color=#FF0000>No</color>.";
                                    MercenaryFR += "Délai pour Tuer : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "s</color>, Peut utiliser les vents : <color=#FF0000>Non</color>.";
                                    MercenaryZHCN += "击杀冷却 : <color=#00ffff>" + MercenaryKillCooldown.getFloat() + "秒</color>, 可以钻管 : <color=#FF0000>否</color>.";

                                }
                            }
                            if (MercenarySpawnChance.getFloat() > 0 && MercenaryAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MercenaryFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MercenaryZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Mercenary;
                                }
                            }



                            //COPYCAT
                            string CopyCat = "<size=0.75><color=#64E6B4>\n> CopyCat : </color>";
                            string CopyCatFR = "<size=0.75><color=#64E6B4>\n> CopyCat : </color>";
                            string CopyCatZHCN = "<size=0.75><color=#64E6B4>\n> 失忆者 : </color>";



                            if (CopyCatSpawnChance.getFloat() > 0)

                            {
                                if (CopyImp.getSelection() == 0)
                                {
                                    CopyCat += "If CopyCat try to Copy Impostors Rôle :<color=#ff00ff> CopyCat die</color>,";
                                    CopyCatFR += "Si il tente de copier un Imposteur :<color=#ff00ff> L'imitateur Meurt</color>,";
                                    CopyCatZHCN += "如果失忆者尝试回忆内鬼职业 :<color=#ff00ff> 失忆者死亡</color>,";

                                }
                                if (CopyImp.getSelection() == 1)
                                {
                                    CopyCat += "If CopyCat try to Copy Impostors Rôle : Changed to <color=#FF0000>Impostor</color>,";
                                    CopyCatFR += "Si il tente de copier un Imposteur : Il devient un <color=#FF0000>Impostor</color>,";
                                    CopyCatZHCN += "如果失忆者尝试回忆内鬼职业 : 更改职业为 <color=#FF0000>内鬼</color>,";

                                }
                                if (CopyImp.getSelection() == 2)
                                {
                                    CopyCat += "If CopyCat try to Copy Impostors Rôle : Changed to <color=#FFFF00>Sheriff</color>,";
                                    CopyCatFR += "Si il tente de copier un Imposteur : Il devient un <color=#FFFF00>Shérif</color>,";
                                    CopyCatZHCN += "如果失忆者尝试回忆内鬼职业 : 更改职业为 <color=#FFFF00>警长</color>,";

                                }
                                if (CopyImp.getSelection() == 3)
                                {
                                    CopyCat += "If CopyCat try to Copy Impostors Rôle : Changed to <color=#B4FAFA>Crewmate</color>,";
                                    CopyCatFR += "Si il tente de copier un Imposteur : Il devient un <color=#B4FAFA>Coéquipier</color>,";
                                    CopyCatZHCN += "如果失忆者尝试回忆内鬼职业 : 更改职业为 <color=#B4FAFA>船员</color>,";

                                }
                                if (CopySpe.getSelection() == 0)
                                {
                                    CopyCat += " If CopyCat try to Copy Special Rôle :<color=#ff00ff> CopyCat die</color>.";
                                    CopyCatFR += " Si il tente de copier un Rôle Spécial :<color=#ff00ff> L'imitateur Meurt</color>.";
                                    CopyCatZHCN += " 如果失忆者尝试回忆特殊职业 :<color=#ff00ff> 失忆者死亡</color>.";

                                }

                                if (CopySpe.getSelection() == 1)
                                {
                                    CopyCat += " If CopyCat try to Copy Special Rôle : Changed to <color=#FFFF00>Sheriff</color>.";
                                    CopyCatFR += " Si il tente de copier un Rôle Spécial : Il devient un <color=#FFFF00>Shérif</color>.";
                                    CopyCatZHCN += " 如果失忆者尝试回忆特殊职业 : 更改职业为 <color=#FFFF00>警长</color>.";

                                }
                                if (CopySpe.getSelection() == 2)
                                {
                                    CopyCat += " If CopyCat try to Copy Special Rôle : Changed to <color=#B4FAFA>Crewmate</color>.";
                                    CopyCatFR += " Si il tente de copier un Rôle Spécial : Il devient un <color=#B4FAFA>Coéquipier</color>.";
                                    CopyCatZHCN += " 如果失忆者尝试回忆特殊职业 : 更改职业为 <color=#B4FAFA>船员</color>.";

                                }
                            }



                            if (CopyCatSpawnChance.getFloat() > 0 && CopyCatAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CopyCatFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += CopyCatZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += CopyCat;
                                }
                            }

                            //REVENGER
                            string Revenger = "<size=0.75><color=#D9C27E>\n> Revenger : </color>";
                            string RevengerFR = "<size=0.75><color=#D9C27E>\n> Vengeur : </color>";
                            string RevengerZHCN = "<size=0.75><color=#D9C27E>\n> 复仇者 : </color>";


                            if (RevengerSpawnChance.getFloat() > 0)

                            {
                                if ((VengerKill.getBool() == true) && (VengerExil.getBool() == true))
                                {
                                    Revenger += "If the revenge is killed in game, <color=#ff00ff>All</color> imposters lose their powers ! If the revenge is voted Out, <color=#ff00ff>All</color> Crewmates lose their powers ";

                                    RevengerFR += "Si il est tué en jeu, <color=#ff00ff>Tous</color> les imposteurs perdent leurs capacités octroyées par les rôles ! Si il est exilé lors d'une réunion, <color=#ff00ff>Tous</color> les Rôles Coéquipiers Perdent leurs capacités octroyées par les rôles ";

                                    RevengerZHCN += "如果复仇者在游戏中被杀死, <color=#ff00ff>所有</color> 内鬼失去他们的能力 ! 如果复仇者被投出, <color=#ff00ff>所有</color> 船员失去他们的能力 ";

                                }
                                if ((VengerKill.getBool() == false) && (VengerExil.getBool() == false))
                                {
                                    Revenger += "If the revenge is : - killed in game, <color=#ff00ff>Selected</color> imposters lose their powers - Voted Out : <color=#ff00ff>Selected</color> Crewmates lose their powers ";
                                    RevengerFR += "Si il est tué en jeu, Les imposteurs <color=#ff00ff>Selectionner</color> perdent leurs capacités octroyées par les rôles ! Si il est exilé lors d'une réunion, les Rôles de Coéquipiers <color=#ff00ff>Sélectionner</color> Perdent leurs capacités octroyées par les rôles ";
                                    RevengerZHCN += "如果复仇者 : - 在游戏中被杀死, <color=#ff00ff>被选中的</color> 内鬼失去他的能力 - 在游戏中被投出 : <color=#ff00ff>被选中的</color> 船员失去他的能力 ";

                                    Revenger += "\nEMP Cooldown : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Max Player Target by EMP : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerFR += "\nDélai de la capacité EMP : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Nombre de joueurs Sélectionnables : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerZHCN += "\n电磁冷却 : <color=#00ffff>" + VengerCooldown.getFloat() + "秒</color>, 电磁最大玩家目标 : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";

                                }
                                if ((VengerKill.getBool() == true) && (VengerExil.getBool() == false))
                                {
                                    Revenger += "如果复仇者 : - 在游戏中被杀死, <color=#ff00ff>所有</color> 内鬼失去他们的能力 - 在游戏中被投出 : <color=#ff00ff>被选中的</color> 船员失去他的能力 ";
                                    RevengerFR += "Si il est tué en jeu, <color=#ff00ff>Tous</color> Les imposteurs perdent leurs capacités octroyées par les rôles ! Si il est exilé lors d'une réunion, les Rôles Coéquipier <color=#ff00ff>Sélectionner</color> Perdent leurs capacités octroyées par les rôles ";
                                    RevengerZHCN += "If the revenge is : - killed in game, <color=#ff00ff>All</color> imposters lose their powers - Voted Out : <color=#ff00ff>Selected</color> Crewmates lose their powers ";

                                    Revenger += "\nEMP Cooldown : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Max Player Target by EMP : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerFR += "\nDélai de la capacité EMP : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Nombre de joueurs Sélectionnables : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerZHCN += "\n电磁冷却 : <color=#00ffff>" + VengerCooldown.getFloat() + "秒</color>, 电磁最大玩家目标 : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";

                                }
                                if ((VengerKill.getBool() == false) && (VengerExil.getBool() == true))
                                {
                                    Revenger += "If the revenge is : - killed in game, <color=#ff00ff>Selected</color> imposters lose their powers - Voted Out : <color=#ff00ff>All</color> Crewmates lose their powers ";
                                    RevengerFR += "Si il est tué en jeu, Les imposteurs <color=#ff00ff>Selectionner</color> perdent leurs capacités octroyées par les rôles ! Si il est exilé lors d'une réunion, <color=#ff00ff>Tous</color> les Rôles Coéquipier Perdent leurs capacités octroyées par les rôles ";
                                    RevengerZHCN += "如果复仇者 : - 在游戏中被杀死, <color=#ff00ff>被选中的</color> 内鬼失去他的能力 - 在游戏中被投出 : <color=#ff00ff>所有</color> 船员失去他们的能力 ";
                                    Revenger += "\nEMP Cooldown : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Max Player Target by EMP : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerFR += "\nDélai de la capacité EMP : <color=#00ffff>" + VengerCooldown.getFloat() + "s</color>, Nombre de joueurs Sélectionnables : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";
                                    RevengerZHCN += "\n电磁冷却 : <color=#00ffff>" + VengerCooldown.getFloat() + "秒</color>, 电磁最大玩家目标 : <color=#ff00ff>x" + QtVenger.getFloat() + "</color>.";

                                }


                            }
                            if (RevengerSpawnChance.getFloat() > 0 && RevengerAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += RevengerFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += RevengerZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Revenger;
                                }
                            }


                        }



                        //SPACER ---
                        string SpacerImp = "\n";
                        __instance.GameSettings.text += SpacerImp;

                        //ROLESSETTINGS
                        string Impostors = "<color=#CC0000><size=1>\n[Impostors Role]</size></color>";
                        string ImpostorsFR = "<color=#CC0000><size=1>\n[Rôles Imposteurs]</size></color>";
                        string ImpostorsZHCN = "<color=#CC0000><size=1>\n[Impostors Role]</size></color>";

                        if (Challenger.Setting_TabSetImp == "1")
                        {
                            Impostors += "<color=#FF6666><size=0.85> - (Press F6 to Hide)\n</size></color>";
                            ImpostorsFR += "<color=#FF6666><size=0.85> - (Appuyez sur F6 pour Masquer)\n</size></color>";
                            ImpostorsZHCN += "<color=#FF6666><size=0.85> - (Press F6 to Hide)\n</size></color>";
                        }
                        else
                        {
                            Impostors += "<color=#FF6666><size=0.85> - (Press F6 for Show)\n</size></color>";
                            ImpostorsFR += "<color=#FF6666><size=0.85> - (Appuyez sur F6 pour Afficher)\n</size></color>";
                            ImpostorsZHCN += "<color=#FF6666><size=0.85> - (Press F6 for Show)\n</size></color>";
                        }


                        if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += ImpostorsFR;
                        }
                        else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                        {
                            __instance.GameSettings.text += ImpostorsZHCN;
                        }
                        else
                        {
                            __instance.GameSettings.text += Impostors;
                        }
                        if (Challenger.Setting_TabSetImp == "1")
                        {

                            //ASSASSIN
                            string Assassin = "<size=0.75><color=#005106>\n> Assassin : </color>";
                            string AssassinFR = "<size=0.75><color=#005106>\n> Assassin : </color>";
                            string AssassinZHCN = "<size=0.75><color=#005106>\n> 刺客 : </color>";


                            if (AssassinSpawnChance.getFloat() > 0)

                            {
                                if (AssassinCanKillShield.getBool() == true)
                                {
                                    Assassin += "Kill Cooldown : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "s</color>, Assassin can Kill Shielded Player : <color=#00FF00>yes</color>. \n<color=#ff0000>List of activated roles and their bonuses when the assassin kills them :</color>";

                                    AssassinFR += "Délai pour Tuer : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "s</color>, Peut tuer les joueurs Protégés par un Bouclier : <color=#00FF00>Oui</color>. \n<color=#ff0000>Liste des bonus actif lorsque l'assassin tue un joueur :</color>";

                                    AssassinZHCN += "击杀冷却 : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "秒</color>, 刺客可以击杀被保护的玩家 : <color=#00FF00>是</color>. \n<color=#ff0000>开启的职业列表以及当刺客杀死时获得的能力 :</color>";
                                }
                                if (AssassinCanKillShield.getBool() == false)
                                {
                                    Assassin += "Kill Cooldown : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "s</color>, Assassin can Kill Shielded Player : <color=#FF0000>No</color>. \n<color=#ff0000>List of activated roles and their bonuses when the assassin kills them :</color>";

                                    AssassinFR += "Délai pour Tuer : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "s</color>, Peut tuer les joueurs Protégés par un Bouclier : <color=#FF0000>Non</color>. \n<color=#ff0000>Liste des bonus actif lorsque l'assassin tue un joueur :</color>";

                                    AssassinZHCN += "击杀冷却 : <color=#00ffff>" + AssassinKillCooldown.getFloat() + "秒</color>, 刺客可以击杀被保护的玩家 : <color=#FF0000>否</color>. \n<color=#ff0000>开启的职业列表以及当刺客杀死时获得的能力 :</color>";
                                }
                                if (BSheriff.getBool() == true &&
                                    (SherifAdd.getBool() == true && ((SherifSpawnChance.getFloat() > 0) || (Sherif2SpawnChance.getFloat() > 0) || (Sherif3SpawnChance.getFloat() > 0)))
                                    || (CopyCatAdd.getBool() == true && CopyCatSpawnChance.getFloat() > 0 && ((CopyImp.getSelection() == 2) || (CopySpe.getSelection() == 1 && QTSpe.getFloat() > 0)))
                                    )
                                {
                                    Assassin += "<color=#FFFF00>\n--- Sheriff</color> (Instantly reset kill cooldown)";

                                    AssassinFR += "<color=#FFFF00>\n--- Shérif</color> (Délai pour tuer réinitialisé)";

                                    AssassinZHCN += "<color=#FFFF00>\n--- 警长</color> (技能 : 立即重置击杀冷却)";
                                }
                                if (BGuardian.getBool() == true && (GuardianSpawnChance.getFloat() > 0) && GuardianAdd.getBool() == true)
                                {
                                    Assassin += "<color=#00FFFF>\n--- Guardian</color> (Ability : Self Shield)";
                                    AssassinFR += "<color=#00FFFF>\n--- Guardien</color> (Pouvoir : Bouclier personnel permanent)";
                                    AssassinZHCN += "<color=#00FFFF>\n--- 守护者</color> (技能 : 护盾)";
                                }
                                if (BEngineer.getBool() == true && (engineerSpawnChance.getFloat() > 0) && engineerAdd.getBool() == true)
                                {
                                    Assassin += "<color=#FFA100>\n--- Engineer</color> (Passif : Assassin Can use Vent)";

                                    AssassinFR += "<color=#FFA100>\n--- Ingénieur</color> (Passif : Peut Utiliser les Vents)";

                                    AssassinZHCN += "<color=#FFA100>\n--- 工程师</color> (技能 : 刺客可以使用管道)";
                                }
                                if (BTimelord.getBool() == true && (TimeLordSpawnChance.getFloat() > 0) && TimeLordAdd.getBool() == true)
                                {
                                    Assassin += "<color=#007FFF>\n--- TimeLord</color> (Ability : BreakTime Enabled)";

                                    AssassinFR += "<color=#007FFF>\n--- Temporel</color> (Pouvoir : Peut arrêter le temps)";

                                    AssassinZHCN += "<color=#007FFF>\n--- 时间领主</color> (技能 : 开启暂停时间)";
                                }
                                if (BMystic.getBool() == true && (MysticSpawnChance.getFloat() > 0) && MysticAdd.getBool() == true)
                                {
                                    Assassin += "<color=#F9FFB2>\n--- Mystic</color> (Ability : Self Shield)";

                                    AssassinFR += "<color=#F9FFB2>\n--- Mystique</color> (Pouvoir : Bouclier personnel permanent)";

                                    AssassinZHCN += "<color=#F9FFB2>\n--- 神秘人</color> (技能 : 护盾)";
                                }
                                if (BMayor.getBool() == true && (MayorSpawnChance.getFloat() > 0) && MayorAdd.getBool() == true)
                                {
                                    Assassin += "<color=#AF8269>\n--- Mayor</color> (Passif : Can see the colors of the votes)";

                                    AssassinFR += "<color=#AF8269>\n--- Maire</color> (Passif : peut voir les couleurs des votes)";

                                    AssassinZHCN += "<color=#AF8269>\n--- 市长</color> (技能 : 可以看见投票者的颜色)";
                                }
                                if (BDetective.getBool() == true && (DetectiveSpawnChance.getFloat() > 0) && DetectiveAdd.getBool() == true)
                                {
                                    Assassin += "<color=#BCFFBA>\n--- Detective</color> (Passif : Can see Player Footprint)";

                                    AssassinFR += "<color=#BCFFBA>\n--- Detective</color> (Passif : Peut voir les traces des joueurs)";

                                    AssassinZHCN += "<color=#BCFFBA>\n--- 侦探</color> (技能 : 可以看见玩家脚印)";
                                }
                                if (BNightwatcher.getBool() == true && (NightwatcherSpawnChance.getFloat() > 0) && NightwatcherAdd.getBool() == true)
                                {
                                    Assassin += "<color=#9EB3FF>\n--- Nightwatch</color> (Passif : Improved vision range)";

                                    AssassinFR += "<color=#9EB3FF>\n--- Veilleur</color> (Passif : Augmente la vision)";

                                    AssassinZHCN += "<color=#9EB3FF>\n--- 执灯人</color> (技能 : 改善视野范围)";
                                }
                                if (BSpy.getBool() == true && (SpySpawnChance.getFloat() > 0) && SpyAdd.getBool() == true)
                                {
                                    Assassin += "<color=#9EE1FF>\n--- Spy</color> (Passif : Improved vision range)";

                                    AssassinFR += "<color=#9EE1FF>\n--- Espion</color> (Passif : Augmente la vision)";

                                    AssassinZHCN += "<color=#9EE1FF>\n--- 特工</color> (技能 : 改善视野范围)";
                                }
                                if (BInfor.getBool() == true && (InforSpawnChance.getFloat() > 0) && InforAdd.getBool() == true)
                                {
                                    Assassin += "<color=#ADFFEA>\n--- Informant</color> (Passif : Can See Player Roles, Infos and Task)";

                                    AssassinFR += "<color=#ADFFEA>\n--- Voyante</color> (Passif : peut voir les rôles et infos joueurs comme les morts)";

                                    AssassinZHCN += "<color=#ADFFEA>\n--- 线人</color> (技能 : 可以看到玩家的职业、信息和任务)";
                                }
                                if (BMentalist.getBool() == true && (MentalistSpawnChance.getFloat() > 0) && MentalistAdd.getBool() == true)
                                {
                                    Assassin += "<color=#A991FF>\n--- Mentalist</color> (Passif : Can See Player color with Admin Table)";

                                    AssassinFR += "<color=#A991FF>\n--- Mentaliste</color> (Passif : peut voir les couleurs des joueurs sur la table d'admin)";

                                    AssassinZHCN += "<color=#A991FF>\n--- 心理医生</color> (技能 : 可以通过管理地图看见玩家颜色)";
                                }
                                if (BBuilder.getBool() == true && (BuilderSpawnChance.getFloat() > 0) && BuilderAdd.getBool() == true)
                                {
                                    Assassin += "<color=#FFC291>\n--- Builder</color> (Passif : Assassin Can use Vent)";

                                    AssassinFR += "<color=#FFC291>\n--- Constructeur</color> (Passif : Peut Utiliser les Vents)";

                                    AssassinZHCN += "<color=#FFC291>\n--- 保安</color> (技能 : 刺客可以使用管道)";
                                }
                                if (BDictator.getBool() == true && (DictatorSpawnChance.getFloat() > 0) && DictatorAdd.getBool() == true)
                                {
                                    Assassin += "<color=#FF7A7A>\n--- Dictator</color> (Passif : Can see the colors of the votes)";

                                    AssassinFR += "<color=#FF7A7A>\n--- Dictateur</color> (Passif : peut voir les couleurs des votes)";

                                    AssassinZHCN += "<color=#FF7A7A>\n--- 独裁者</color> (技能 : 可以看见投票者的颜色)";
                                }
                                if (BSentinel.getBool() == true && (SentinelSpawnChance.getFloat() > 0) && SentinelAdd.getBool() == true)
                                {
                                    Assassin += "<color=#06AD17>\n--- Sentinel</color> (Passif : Improved vision range)";

                                    AssassinFR += "<color=#06AD17>\n--- Sentinelle</color> (Passif : Augmente la vision)";

                                    AssassinZHCN += "<color=#06AD17>\n--- 哨兵</color> (技能 : 改善视野范围)";
                                }
                                if (BLawkeeper.getBool() == true && (SentinelSpawnChance.getFloat() > 0) && LawkeeperAdd.getBool() == true)
                                {
                                    Assassin += "<color=#FF9b9b>\n--- Lawkeeper</color> (Passif : Can see Player Footprint)";

                                    AssassinFR += "<color=#FF9b9b>\n--- Justicier</color> (Passif : Peut voir les traces des joueurs)";

                                    AssassinZHCN += "<color=#FF9b9b>\n--- 验尸官</color> (技能 : 可以看见玩家脚印)";
                                }
                                if (BFake.getFloat() > 0 && (FakeSpawnChance.getFloat() > 0) && FakeAdd.getBool() == true)
                                {
                                    Assassin += "<color=#990000>\n--- Fake</color> (Passif : Modifies the kill cooldown and increase it by <color=#00ffff>" + BFake.getFloat() + "s</color>)";

                                    AssassinFR += "<color=#990000>\n--- Intru</color> (Passif : Modifie le délai pour tuer et l'augmente de <color=#00ffff>" + BFake.getFloat() + "s</color>)";

                                    AssassinZHCN += "<color=#990000>\n--- Fake</color> (Passif : Modifies the kill cooldown and increase it by <color=#00ffff>" + BFake.getFloat() + "s</color>)";
                                }
                                if (BImpo.getFloat() > 0)
                                {
                                    Assassin += "<color=#FF0000>\n--- Impostors</color> (Passif : Modifies the kill cooldown and reduces it by <color=#00ffff>" + BImpo.getFloat() + "s</color>)";

                                    AssassinFR += "<color=#FF0000>\n--- Imposteurs</color> (Passif : Modifie le délai pour tuer et le réduit de <color=#00ffff>" + BImpo.getFloat() + "s</color>)";

                                    AssassinZHCN += "<color=#FF0000>\n--- Impostors</color> (Passif : Modifies the kill cooldown and reduces it by <color=#00ffff>" + BImpo.getFloat() + "s</color>)";
                                }
                            }
                            if (AssassinSpawnChance.getFloat() > 0 && AssassinAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += AssassinFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += AssassinZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Assassin;
                                }
                            }

                            //Vector
                            string Vector = "<size=0.75><color=#8C1919>\n> Vector : </color>";
                            string VectorFR = "<size=0.75><color=#8C1919>\n> Vecteur : </color>";
                            string VectorZHCN = "<size=0.75><color=#8C1919>\n> 染控者 : </color>";


                            if (VectorSpawnChance.getFloat() > 0)

                            {
                                if (VectorBuffVisibility.getBool() == true)
                                {
                                    if (VectorCanVent.getBool() == true)
                                    {
                                        Vector += "Infect Cooldown : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Kill Cooldown : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, Infected player can see Buff : <color=#00FF00>Yes</color>, Can Use Vent : <color=#00FF00>Yes</color>,";

                                        VectorFR += "Délai pour Infecter : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Délai pour Tuer le joueur infecté : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, le joueur infecté sait qu'il est infecté : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>,";

                                        VectorZHCN += "感染冷却 : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "秒</color>, 击杀冷却 : <color=#00ffff>" + VectorKillCooldown.getFloat() + "秒</color>, 被感染的玩家可以看到Buff : <color=#00FF00>是</color>, 可以钻管 : <color=#00FF00>是</color>,";
                                    }
                                    if (VectorCanVent.getBool() == false)
                                    {
                                        Vector += "Infect Cooldown : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Kill Cooldown : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, Infected player can see Buff : <color=#00FF00>Yes</color>, Can Use Vent : <color=#FF0000>No</color>,";

                                        VectorFR += "Délai pour Infecter : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Délai pour Tuer le joueur infecté : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, le joueur infecté sait qu'il est infecté : <color=#00FF00>Oui</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>,";

                                        VectorZHCN += "感染冷却 : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "秒</color>, 击杀冷却 : <color=#00ffff>" + VectorKillCooldown.getFloat() + "秒</color>, 被感染的玩家可以看到Buff : <color=#00FF00>是</color>, 可以钻管 : <color=#FF0000>否</color>,";
                                    }

                                }
                                if (VectorBuffVisibility.getBool() == false)
                                {
                                    if (VectorCanVent.getBool() == true)
                                    {
                                        Vector += "Infect Cooldown : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Kill Cooldown : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, Infected player can see Buff :<color=#FF0000>No</color>, Can Use Vent : <color=#00FF00>Yes</color>,";

                                        VectorFR += "Délai pour Infecter : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Délai pour Tuer le joueur infecté : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, le joueur infecté sait qu'il est infecté :<color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#00FF00>Oui</color>,";

                                        VectorZHCN += "感染冷却 : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "秒</color>, 击杀冷却 : <color=#00ffff>" + VectorKillCooldown.getFloat() + "秒</color>, 被感染的玩家可以看到Buff :<color=#FF0000>否</color>, 可以钻管 : <color=#00FF00>是</color>,";
                                    }
                                    if (VectorCanVent.getBool() == false)
                                    {
                                        Vector += "Infect Cooldown : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Kill Cooldown : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, Infected player can see Buff :<color=#FF0000>No</color>, Can Use Vent : <color=#FF0000>No</color>,";

                                        VectorFR += "Délai pour Infecter : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "s</color>, Délai pour Tuer le joueur infecté : <color=#00ffff>" + VectorKillCooldown.getFloat() + "s</color>, le joueur infecté sait qu'il est infecté :<color=#FF0000>Non</color>, Peut utiliser les Vents : <color=#FF0000>Non</color>,";

                                        Vector += "感染冷却 : <color=#00ffff>" + VectorBuffCooldown.getFloat() + "秒</color>, 击杀冷却 : <color=#00ffff>" + VectorKillCooldown.getFloat() + "秒</color>, 被感染的玩家可以看到Buff :<color=#FF0000>否</color>, 可以钻管 : <color=#FF0000>否</color>,";
                                    }

                                }
                                /*if (VectorSolo.getBool() == true)
                                {
                                    Vector += " Normal Kill if he is the last living impostor : <color=#00ff00>Yes</color>.";
                                }
                                if (VectorSolo.getBool() == false)
                                {
                                    Vector += " Normal Kill if he is the last living impostor <color=#ff0000>No</color>.";
                                }*/
                            }
                            if (VectorSpawnChance.getFloat() > 0 && VectorAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += VectorFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += VectorZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Vector;
                                }
                            }




                            //Morphling
                            string Morphling = "<size=0.75><color=#430054>\n> Morphling : </color>";
                            string MorphlingFR = "<size=0.75><color=#430054>\n> Metamorph : </color>";
                            string MorphlingZHCN = "<size=0.75><color=#430054>\n> 化形者 : </color>";


                            if (MorphlingSpawnChance.getFloat() > 0)

                            {


                                if (MorphlingCanVent.getBool() == true)
                                {
                                    Morphling += "Morph : <color=#00ffff>" + MorphSetCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + MorphSetDuration.getFloat() + "s</color> duration, Drop a Mark : <color=#FF0000>No</color>, Can Use Vent : <color=#00FF00>yes</color>.";

                                    MorphlingFR += "Délai pour se Métamorphoser : <color=#00ffff>" + MorphSetCooldown.getFloat() + "s</color> pendant <color=#00ffff>" + MorphSetDuration.getFloat() + "s</color>, Laisse une trace : <color=#FF0000>Non</color>, Peut utiliser les vents : <color=#00FF00>Oui</color>.";

                                    MorphlingZHCN += "化形冷却 : <color=#00ffff>" + MorphSetCooldown.getFloat() + "秒</color> 化形持续时间： <color=#00ffff>" + MorphSetDuration.getFloat() + "秒</color> , 留下痕迹 : <color=#FF0000>否</color>, 可以钻管 : <color=#00FF00>是</color>.";
                                }
                                if (MorphlingCanVent.getBool() == false)
                                {
                                    Morphling += "Morph : <color=#00ffff>" + MorphSetCooldown.getFloat() + "s</color> Cooldown For <color=#00ffff>" + MorphSetDuration.getFloat() + "s</color> duration, Drop a Mark : <color=#FF0000>No</color>, Can Use Vent : <color=#FF0000>No</color>.";

                                    MorphlingFR += "Délai pour se Métamorphoser : <color=#00ffff>" + MorphSetCooldown.getFloat() + "s</color> pendant <color=#00ffff>" + MorphSetDuration.getFloat() + "s</color>, Laisse une trace : <color=#FF0000>Non</color>, Peut utiliser les vents : <color=#FF0000>Non</color>.";

                                    MorphlingZHCN += "化形冷却 : <color=#00ffff>" + MorphSetCooldown.getFloat() + "秒</color> 化形持续时间：<color=#00ffff>" + MorphSetDuration.getFloat() + "秒</color> duration, 留下痕迹 : <color=#FF0000>否</color>, 可以钻管 : <color=#FF0000>否</color>.";

                                }

                            }
                            if (MorphlingSpawnChance.getFloat() > 0 && MorphlingAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MorphlingFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += MorphlingZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Morphling;
                                }
                            }



                            //SCRAMBLER
                            string Scrambler = "<size=0.75><color=#544700>\n> Scrambler : </color>";
                            string ScramblerFR = "<size=0.75><color=#544700>\n> Brouilleur : </color>";
                            string ScramblerZHCN = "<size=0.75><color=#544700>\n> 隐蔽者 : </color>";


                            if (CamoSpawnChance.getFloat() > 0)

                            {
                                if (CamoCanVent.getBool() == true)
                                {
                                    Scrambler += "Camo : <color=#00ffff>" + CamoSetCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + CamoSetDuration.getFloat() + "s</color> duration, Can Use Vent : <color=#00FF00>Yes</color>.";

                                    ScramblerFR += "Délai d'utilisation du Brouillage : <color=#00ffff>" + CamoSetCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + CamoSetDuration.getFloat() + "s</color>, Peut utiliser les vents : <color=#00FF00>Oui</color>.";

                                    ScramblerZHCN += "隐蔽冷却 : <color=#00ffff>" + CamoSetCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + CamoSetDuration.getFloat() + "秒</color> , 可以钻管 : <color=#00FF00>是</color>.";
                                }
                                if (CamoCanVent.getBool() == false)
                                {
                                    Scrambler += "Camo : <color=#00ffff>" + CamoSetCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + CamoSetDuration.getFloat() + "s</color> duration, Can Use Vent : <color=#FF0000>No</color>.";

                                    ScramblerFR += "Délai d'utilisation du Brouillage : <color=#00ffff>" + CamoSetCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + CamoSetDuration.getFloat() + "s</color>, Peut utiliser les vents : <color=#FF0000>Non</color>.";

                                    ScramblerZHCN += "隐蔽冷却 : <color=#00ffff>" + CamoSetCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + CamoSetDuration.getFloat() + "秒</color> , 可以钻管 : <color=#FF0000>否</color>.";
                                }

                            }
                            if (CamoSpawnChance.getFloat() > 0 && CamoAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += ScramblerFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += ScramblerZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Scrambler;
                                }
                            }

                            //BARGHEST
                            string Barghest = "<size=0.75><color=#000569>\n> Barghest : </color>";
                            string BarghestFR = "<size=0.75><color=#000569>\n> Barghest : </color>";
                            string BarghestZHCN = "<size=0.75><color=#000569>\n> 犬魔 : </color>";


                            if (BarghestSpawnChance.getFloat() > 0)

                            {


                                if (BarghestAffectImpostor.getBool() == true) // true
                                {
                                    if (BarghestCamlight.getBool() == true)
                                    {
                                        Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#00FF00>Yes</color>, affect other impostors : <color=#00FF00>Yes</color>,";

                                        BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#00FF00>Oui</color>, affectent les autres imposteurs : <color=#00FF00>Oui</color>,";

                                        BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#00FF00>是</color>, 降低视野也会附着在其他内鬼上 : <color=#00FF00>是</color>,";
                                    }
                                    if (BarghestCamlight.getBool() == false)
                                    {
                                        Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#FF0000>No</color>, affect other impostors : <color=#00FF00>Yes</color>,";

                                        BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#FF0000>Non</color>, affectent les autres imposteurs : <color=#00FF00>Oui</color>,";

                                        BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#FF0000>否</color>, 降低视野也会附着在其他内鬼上 : <color=#00FF00>是</color>,";
                                    }
                                }
                                if (BarghestAffectImpostor.getBool() == false)
                                {
                                    if (ImpostorsKnowEachother.getBool() == true) //false but force true
                                    {
                                        if (BarghestCamlight.getBool() == true)
                                        {
                                            Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#00FF00>Yes</color>, affect other impostors : <color=#00FF00>Yes</color>,";

                                            BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#00FF00>Oui</color>, affectent les autres imposteurs : <color=#00FF00>Oui</color>,";

                                            BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#00FF00>是</color>, 降低视野也会附着在其他内鬼上 : <color=#00FF00>是</color>,";
                                        }
                                        if (BarghestCamlight.getBool() == false)
                                        {
                                            Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#FF0000>No</color>, affect other impostors : <color=#00FF00>Yes</color>,";

                                            BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#FF0000>Non</color>, affectent les autres imposteurs : <color=#00FF00>Oui</color>,";

                                            BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#FF0000>否</color>, 降低视野也会附着在其他内鬼上 : <color=#00FF00>是</color>,";
                                        }
                                    }
                                    if (ImpostorsKnowEachother.getBool() == false) //false
                                    {
                                        if (BarghestCamlight.getBool() == true)
                                        {
                                            Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#00FF00>Yes</color>, affect other impostors : <color=#FF0000>No</color>,";

                                            BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#00FF00>Oui</color>, affectent les autres imposteurs : <color=#FF0000>Non</color>,";

                                            BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#00FF00>是</color>, 降低视野也会附着在其他内鬼上 : <color=#FF0000>否</color>,";
                                        }
                                        if (BarghestCamlight.getBool() == false)
                                        {
                                            Barghest += "Call Shadow : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> duration, Shadow Disabled Camera : <color=#FF0000>No</color>, affect other impostors : <color=#FF0000>No</color>,";

                                            BarghestFR += "Délai d'appel des Ténèbres : <color=#00ffff>" + BargestLightCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + BargestLightDuration.getFloat() + "s</color> Les Ténèbres désactivent les Caméras : <color=#FF0000>Non</color>, affectent les autres imposteurs : <color=#FF0000>Non</color>,";

                                            BarghestZHCN += "降低视野冷却 : <color=#00ffff>" + BargestLightCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + BargestLightDuration.getFloat() + "秒</color> , 降低视野时禁用监控摄像头 : <color=#FF0000>否</color>, 降低视野也会附着在其他内鬼上 : <color=#FF0000>否</color>,";
                                        }
                                    }
                                }

                                if (BarghestCanCreateVent.getBool() == true)
                                {

                                    if (CanUseBarghestVent.getSelection() == 0)
                                    {
                                        Barghest += "\n Can Create Barghest Vent : <color=#00FF00>Yes</color>, Cooldown for Create Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Only Barghest</color> can Use Barghest Vent,";
                                        BarghestFR += "\n Peut créer des Vents de Barghest : <color=#00FF00>Oui</color>, Délai pour la création de Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Le Barghest Uniquement</color> Peut les Utiliser,";
                                        BarghestZHCN += "\n 可以创建犬魔管道 : <color=#00FF00>是</color>, 创建管道冷却 : <color=#00ffff>" + BarghestVentCD.getFloat() + "秒</color>, <color=#FF00FF>仅有犬魔</color> 可使用犬魔管道,";
                                    }
                                    if (CanUseBarghestVent.getSelection() == 1)
                                    {
                                        Barghest += "\n Can Create Barghest Vent : <color=#00FF00>Yes</color>, Cooldown for Create Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Barghest and Other Impostors</color> can Use Barghest Vent,";
                                        BarghestFR += "\n Peut créer des Vents de Barghest : <color=#00FF00>Oui</color>, Délai pour la création de Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>tous les imposteurs</color> Peuvent les Utiliser,";
                                        BarghestZHCN += "\n 可以创建犬魔管道 : <color=#00FF00>是</color>, 创建管道冷却 : <color=#00ffff>" + BarghestVentCD.getFloat() + "秒</color>, <color=#FF00FF>所有内鬼</color> 都可使用犬魔管道,";
                                    }
                                    if (CanUseBarghestVent.getSelection() == 2)
                                    {
                                        Barghest += "\n Can Create Barghest Vent : <color=#00FF00>Yes</color>, Cooldown for Create Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Only Impostor if he can use Normal vent</color> can Use Barghest Vent,";
                                        BarghestFR += "\n Peut créer des Vents de Barghest : <color=#00FF00>Oui</color>, Délai pour la création de Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>tous les Imposteurs qui peuvent utiliser les Vents</color> peuvent les Utiliser,";
                                        BarghestZHCN += "\n 可以创建犬魔管道 : <color=#00FF00>是</color>, 创建管道冷却 : <color=#00ffff>" + BarghestVentCD.getFloat() + "秒</color>, <color=#FF00FF>仅有可以使用正常管道的内鬼</color> 可使用犬魔管道,";

                                    }
                                    if (CanUseBarghestVent.getSelection() == 3)
                                    {
                                        Barghest += "\n Can Create Barghest Vent : <color=#00FF00>Yes</color>, Cooldown for Create Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Anyone who can use Normal vent</color> can Use Barghest Vent,";
                                        BarghestFR += "\n Peut créer des Vents de Barghest : <color=#00FF00>Oui</color>, Délai pour la création de Vent : <color=#00ffff>" + BarghestVentCD.getFloat() + "s</color>, <color=#FF00FF>Tous ceux qui peuvent utiliser les Vents</color> Peuvent les Utiliser,";
                                        BarghestZHCN += "\n 可以创建犬魔管道 : <color=#00FF00>是</color>, 创建管道冷却 : <color=#00ffff>" + BarghestVentCD.getFloat() + "秒</color>, <color=#FF00FF>可以使用正常管道的所有人</color> 都可使用犬魔管道,";

                                    }



                                }
                                if (BarghestCanCreateVent.getBool() == false)
                                {
                                    Barghest += "\n Can Create Barghest Vent : <color=#FF0000>No</color>,";
                                    BarghestFR += "\n Peut créer des Vents de Barghest : <color=#FF0000>Non</color>,";
                                    BarghestZHCN += "\n 可以创建犬魔管道 : <color=#FF0000>否</color>,";

                                }

                                if (BarghestCanVent.getBool() == false)
                                {
                                    Barghest += " Can Use Normal Vent : <color=#FF0000>No</color>.";
                                    BarghestFR += " Peut utiliser les Vents normal : <color=#FF0000>Non</color>.";
                                    BarghestZHCN += " 可以使用正常管道 : <color=#FF0000>否</color>.";

                                }
                                if (BarghestCanVent.getBool() == true)
                                {
                                    Barghest += " Can Use Normal Vent : <color=#00FF00>Yes</color>.";
                                    BarghestFR += " Peut utiliser les Vents normal : <color=#00FF00>Oui</color>.";
                                    BarghestZHCN += " 可以使用正常管道 : <color=#00FF00>是</color>.";

                                }


                            }
                            if (BarghestSpawnChance.getFloat() > 0 && BarghestAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BarghestFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BarghestZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Barghest;
                                }
                            }

                            //GHOST
                            string Ghost = "<size=0.75><color=#404040>\n> Ghost : </color>";
                            string GhostFR = "<size=0.75><color=#404040>\n> Fantome : </color>";
                            string GhostZHCN = "<size=0.75><color=#404040>\n> 隐身人 : </color>";


                            if (GhostSpawnChance.getFloat() > 0)

                            {
                                if (GhostCanVent.getBool() == true)
                                {
                                    Ghost += "Invisibility : <color=#00ffff>" + HideSetCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + HideSetDuration.getFloat() + "s</color> duration, Can Use Vent : <color=#00FF00>yes</color>.";

                                    GhostFR += "Délai de l'Invisibilité : <color=#00ffff>" + HideSetCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + HideSetDuration.getFloat() + "s</color>, Peut utiliser les vents : <color=#00FF00>Oui</color>.";

                                    GhostZHCN += "隐藏冷却 : <color=#00ffff>" + HideSetCooldown.getFloat() + "秒</color>持续时间： <color=#00ffff>" + HideSetDuration.getFloat() + "秒</color> , 可以钻管 : <color=#00FF00>是</color>.";
                                }
                                if (GhostCanVent.getBool() == false)
                                {
                                    Ghost += "Invisibility : <color=#00ffff>" + HideSetCooldown.getFloat() + "s</color> Cooldown for <color=#00ffff>" + HideSetDuration.getFloat() + "s</color> duration, Can Use Vent : <color=#FF0000>No</color>.";

                                    GhostFR += "Délai de l'Invisibilité : <color=#00ffff>" + HideSetCooldown.getFloat() + "s</color> Pendant <color=#00ffff>" + HideSetDuration.getFloat() + "s</color> Peut utiliser les vents : <color=#FF0000>No,</color>.";

                                    GhostZHCN += "隐藏冷却 : <color=#00ffff>" + HideSetCooldown.getFloat() + "秒</color> 持续时间： <color=#00ffff>" + HideSetDuration.getFloat() + "秒</color> , 可以钻管 : <color=#FF0000>否</color>.";
                                }


                            }
                            if (GhostSpawnChance.getFloat() > 0 && GhostAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GhostFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GhostZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Ghost;
                                }
                            }

                            //SORCERER
                            string Sorcerer = "<size=0.75><color=#542B00>\n> Sorcerer : </color>";
                            string SorcererFR = "<size=0.75><color=#542B00>\n> Sorcier : </color>";
                            string SorcererZHCN = "<size=0.75><color=#542B00>\n> 法师 : </color>";


                            if (WarSpawnChance.getFloat() > 0)

                            {
                                Sorcerer += "Find cooldown : <color=#00ffff>" + WarCooldown.getFloat() + "s</color>,";
                                SorcererFR += "Délai de la capacité de recherche : <color=#00ffff>" + WarCooldown.getFloat() + "s</color>,";
                                SorcererZHCN += "查找冷却 : <color=#00ffff>" + WarCooldown.getFloat() + "秒</color>,";

                                if (War1.getBool() == false)
                                {
                                    Sorcerer += " Can Use Focus (x1 rune) : <color=#FF0000>No</color>,";
                                    SorcererFR += " Peut utiliser Focalisation (x1 rune) : <color=#FF0000>Non</color>,";
                                    SorcererZHCN += " 可以使用聚焦 (x1 符文) : <color=#FF0000>否</color>,";

                                }
                                if (War1.getBool() == true)
                                {
                                    Sorcerer += " Can Use Focus (x1 rune) : <color=#00FF00>Yes</color>,";
                                    SorcererFR += " Peut utiliser Focalisation (x1 rune) : <color=#00FF00>Oui</color>,";
                                    SorcererZHCN += " 可以使用聚焦 (x1 符文) : <color=#00FF00>是</color>,";

                                }
                                if (War2.getBool() == false)
                                {
                                    Sorcerer += " Can Use Vision (x2 runes) : <color=#FF0000>No</color>,";
                                    SorcererFR += " Peut utiliser Vision (x2 runes) : <color=#FF0000>Non</color>,";
                                    SorcererZHCN += " 可以使用幻象 (x2 符文) : <color=#FF0000>否</color>,";

                                }
                                if (War2.getBool() == true)
                                {
                                    Sorcerer += " Can Use Vision (x2 runes) : <color=#00FF00>Yes</color>,";
                                    SorcererFR += " Peut utiliser Vision (x2 runes) : <color=#00FF00>Oui</color>,";
                                    SorcererZHCN += " 可以使用幻象 (x2 符文) : <color=#00FF00>是</color>,";

                                }
                                if (War3.getBool() == false)
                                {
                                    Sorcerer += "\nCan Use Confuse (x3 runes) : <color=#FF0000>No</color>,";
                                    SorcererFR += "\nPeut utiliser Confusion (x3 runes) : <color=#FF0000>Non</color>,";
                                    SorcererZHCN += "\n可以使用迷惑 (x3 符文) : <color=#FF0000>否</color>,";

                                }
                                if (War3.getBool() == true)
                                {
                                    Sorcerer += "\nCan Use Confuse (x3 runes) : <color=#00FF00>Yes</color>,";
                                    SorcererFR += "\nPeut utiliser Confision (x3 runes) : <color=#00FF00>Oui</color>,";
                                    SorcererZHCN += "\n可以使用迷惑 (x3 符文) : <color=#00FF00>是</color>,";

                                }
                                if (War4.getBool() == false)
                                {
                                    Sorcerer += " Can Use Destroy (x4 runes) : <color=#FF0000>No</color>,";
                                    SorcererFR += " Peut utiliser Detruire (x4 runes) : <color=#FF0000>Non</color>,";
                                    SorcererZHCN += " 可以使用摧毁 (x4 符文) : <color=#FF0000>否</color>,";

                                }
                                if (War4.getBool() == true)
                                {
                                    Sorcerer += " Can Use Destroy (x4 runes) : <color=#00FF00>Yes</color>,";
                                    SorcererFR += " Peut utiliser Detruire (x4 runes) : <color=#00FF00>Oui</color>,";
                                    SorcererZHCN += " 可以使用摧毁 (x4 符文) : <color=#00FF00>是</color>,";

                                }


                                if (WarCanVent.getBool() == false)
                                {
                                    Sorcerer += " Can Use Vent : <color=#FF0000>No</color>.";
                                    SorcererFR += " Peut utiliser les vents : <color=#FF0000>Non</color>.";
                                    SorcererZHCN += " 可以钻管 : <color=#FF0000>否</color>.";

                                }
                                if (WarCanVent.getBool() == true)
                                {
                                    Sorcerer += " Can Use Vent : <color=#00FF00>Yes</color>.";
                                    SorcererFR += " Peut utiliser les vents  : <color=#00FF00>Oui</color>.";
                                    SorcererZHCN += " 可以钻管 : <color=#00FF00>是</color>.";

                                }

                            }
                            if (WarSpawnChance.getFloat() > 0 && WarAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SorcererFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += SorcererZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Sorcerer;
                                }
                            }

                            //GUESSER
                            string Guess = "<size=0.75><color=#003954>\n> Guesser : </color>";
                            string GuessFR = "<size=0.75><color=#003954>\n> Devin : </color>";
                            string GuessZHCN = "<size=0.75><color=#003954>\n> 赌怪 : </color>";



                            if (GuesserSpawnChance.getFloat() > 0)

                            {


                                if (GuessTryOne.getBool() == true)
                                {
                                    Guess += "Try to Kill during meeting : <color=#00ffff>x" + Gestry.getFloat() + "</color>, Only use 1 try per round  : <color=#00FF00>Yes</color>";
                                    GuessFR += "Tentative de tuer pendant une Réunion : <color=#00ffff>x" + Gestry.getFloat() + "</color>, utilisable 1x par tour : <color=#00FF00>Oui</color>";
                                    GuessZHCN += "在会议中可尝试击杀数 : <color=#00ffff>x" + Gestry.getFloat() + "</color>, 每局只能使用1次  : <color=#00FF00>是</color>";

                                }
                                if (GuessTryOne.getBool() == false)
                                {
                                    Guess += "Try to Kill during meeting : <color=#00ffff>x" + Gestry.getFloat() + "</color> Only use 1 try per round : <color=#FF0000>No</color>";
                                    GuessFR += "Tentative de tuer pendant une Réunion : <color=#00ffff>x" + Gestry.getFloat() + "</color> utilisable 1x par tour : <color=#FF0000>Non</color>";
                                    GuessZHCN += "在会议中可尝试击杀数 : <color=#00ffff>x" + Gestry.getFloat() + "</color> 每局只能使用1次 : <color=#FF0000>否</color>";


                                }


                                if (GuessDie.getBool() == true)
                                {
                                    Guess += ", die on a failure : <color=#00FF00>yes</color>";
                                    GuessFR += ", Meurt en cas d'échec : <color=#00FF00>Oui</color>";
                                    GuessZHCN += ", 如果猜测错误自杀 : <color=#00FF00>是</color>";

                                }
                                if (GuessDie.getBool() == false)
                                {
                                    Guess += ", die on a failure : <color=#FF0000>No</color>";
                                    GuessFR += ", Meurt en cas d'échec : <color=#FF0000>Non</color>";
                                    GuessZHCN += ", 如果猜测错误自杀 : <color=#FF0000>否</color>";

                                }

                                if (GuessCanVent.getBool() == true)
                                {
                                    Guess += ", Can Use Vent : <color=#00FF00>yes</color>";
                                    GuessFR += ", Peut utiliser les vents : <color=#00FF00>Oui</color>";
                                    GuessZHCN += ", 可以钻管 : <color=#00FF00>是</color>";

                                }
                                if (GuessCanVent.getBool() == false)
                                {
                                    Guess += ", Can Use Vent : <color=#FF0000>No</color>";
                                    GuessFR += ", Peut utiliser les vents : <color=#FF0000>Non</color>";
                                    GuessZHCN += ", 可以钻管 : <color=#FF0000>否</color>";
                                }
                                if (GuessMystic.getBool() == false && GuessSpirit.getBool() == false && GuessFake.getBool() == false) // 0
                                {
                                    Guess += ".";
                                    GuessFR += ".";
                                    GuessZHCN += ".";

                                }
                                if (GuessMystic.getBool() == true && GuessSpirit.getBool() == false && GuessFake.getBool() == false) // Mystic only
                                {
                                    Guess += ", Can't Guess : <color=#F9FFB2>Mystic</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#F9FFB2>Mystique</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#F9FFB2>神秘人</color>.";

                                }
                                if (GuessMystic.getBool() == false && GuessSpirit.getBool() == true && GuessFake.getBool() == false) // Spirit only
                                {
                                    Guess += ", Can't Guess : <color=#A1FF00>Spirit</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#A1FF00>Spirite</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#A1FF00>精灵</color>.";
                                }
                                if (GuessMystic.getBool() == false && GuessSpirit.getBool() == false && GuessFake.getBool() == true) // Fake only
                                {
                                    Guess += ", Can't Guess : <color=#FF7A7A>Fake</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#FF7A7A>Intru</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#FF7A7A>卧底</color>.";
                                }
                                if (GuessMystic.getBool() == true && GuessSpirit.getBool() == true && GuessFake.getBool() == false) // Mystic+spirit
                                {
                                    Guess += ", Can't Guess : <color=#F9FFB2>Mystic</color> / <color=#A1FF00>Spirit</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#F9FFB2>Mystique</color> / <color=#A1FF00>Spirite</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#F9FFB2>神秘人</color> / <color=#A1FF00>精灵</color>.";
                                }
                                if (GuessMystic.getBool() == true && GuessSpirit.getBool() == false && GuessFake.getBool() == true) // Mystic+Fake
                                {
                                    Guess += ", Can't Guess : <color=#F9FFB2>Mystic</color> / <color=#FF7A7A>Fake</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#F9FFB2>Mystique</color> / <color=#FF7A7A>Intru</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#F9FFB2>神秘人</color> / <color=#FF7A7A>卧底</color>.";
                                }
                                if (GuessMystic.getBool() == false && GuessSpirit.getBool() == true && GuessFake.getBool() == true) // Spirit+Fake
                                {
                                    Guess += ", Can't Guess : <color=#A1FF00>Spirit</color> / <color=#FF7A7A>Fake</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#A1FF00>Spirite</color> / <color=#FF7A7A>Intru</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#A1FF00>精灵</color> / <color=#FF7A7A>卧底</color>.";
                                }
                                if (GuessMystic.getBool() == true && GuessSpirit.getBool() == true && GuessFake.getBool() == false) // Mystic+spirit+Fake
                                {
                                    Guess += ", Can't Guess : <color=#F9FFB2>Mystic</color> / <color=#A1FF00>Spirit</color> / <color=#FF7A7A>Fake</color>.";
                                    GuessFR += ", Rôles impossible à deviner : <color=#F9FFB2>Mystique</color> / <color=#A1FF00>Spirite</color> / <color=#FF7A7A>Intru</color>.";
                                    GuessZHCN += ", 无法猜测 : <color=#F9FFB2>神秘人</color> / <color=#A1FF00>精灵</color> / <color=#FF7A7A>卧底</color>.";
                                }
                            }
                            if (GuesserSpawnChance.getFloat() > 0 && GuesserAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GuessFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += GuessZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Guess;
                                }
                            }


                            //BASILISK
                            string Basilisk = "<color=#5B466B>\n> Basilisk : </color>";
                            string BasiliskFR = "<color=#5B466B>\n> Basilik : </color>";
                            string BasiliskZHCN = "<color=#5B466B>\n> 蛇怪 : </color>";


                            if (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)

                            {



                                Basilisk += "Maximum amount of storable dose(s): <color=#ff00ff>x" + BasiliskCooldown.getFloat() + "</color>, Start game with : <color=#ff00ff>x" + BasiliskStart.getFloat() + "</color> dose(s), killing a player grants : <color=#ff00ff>x" + BasiliskKill.getFloat() + "</color> dose(s), Each new round grants : <color=#ff00ff>x" + BasiliskMeet.getFloat() + "</color> dose(s).\n";
                                BasiliskFR += "Quantité maximum de dose(s) stockable : <color=#ff00ff>x" + BasiliskCooldown.getFloat() + "</color>, Commence la partie avec : <color=#ff00ff>x" + BasiliskStart.getFloat() + "</color> dose(s), Tuer un joueur raporte : <color=#ff00ff>x" + BasiliskKill.getFloat() + "</color> dose(s), Chaque nouveau tour de jeu donne : <color=#ff00ff>x" + BasiliskMeet.getFloat() + "</color> dose(s).\n";
                                BasiliskZHCN += "最大可储存剂量: <color=#ff00ff>x" + BasiliskCooldown.getFloat() + "</color>, 开始游戏时拥有的剂量 : <color=#ff00ff>x" + BasiliskStart.getFloat() + "</color> , 击杀玩家奖励剂量数 : <color=#ff00ff>x" + BasiliskKill.getFloat() + "</color>, 每新一局奖励剂量数 : <color=#ff00ff>x" + BasiliskMeet.getFloat() + "</color>.\n";

                                Basilisk += "Paralyze Cost : <color=#ff00ff>x" + BasiliskParalizeCost.getFloat() + "</color> dose(s), Petrify Cost : <color=#ff00ff>x" + BasiliskPetrifyCost.getFloat() + "</color> dose(s).\n";
                                BasiliskFR += "Paralyzer coûte : <color=#ff00ff>x" + BasiliskParalizeCost.getFloat() + "</color> dose(s), Petrifier coûte : <color=#ff00ff>x" + BasiliskPetrifyCost.getFloat() + "</color> dose(s).\n";
                                BasiliskZHCN += "麻痹花费剂量数 : <color=#ff00ff>x" + BasiliskParalizeCost.getFloat() + "</color> , 石化花费剂量数 : <color=#ff00ff>x" + BasiliskPetrifyCost.getFloat() + "</color> .\n";


                                if (BasiliskVote.getSelection() == 0)
                                {
                                    Basilisk += "Can Use Paralyze (Paralized player can to be voted) : <color=#00ff00>Yes</color>.\n";
                                    BasiliskFR += "Peut utiliser Paralyser, (Le joueur Paralyser peut être voter) : <color=#00ff00>Oui</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家可以投票) : <color=#00ff00>是</color>.\n";
                                    Basilisk += "Can Use Petrify, (Petrified player cant to be voted) : <color=#00ff00>Yes</color>.\n";
                                    BasiliskFR += "Peut utiliser Pétrifier, (Le joueur Petrifier ne peut pas être voter) : <color=#00ff00>Oui</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家不可以投票) : <color=#00ff00>是</color>.\n";
                                }

                                if (BasiliskVote.getSelection() == 1)
                                {
                                    Basilisk += "Can Use Paralyze (Paralized player can to be voted) : <color=#00ff00>Yes</color>.\n";
                                    BasiliskFR += "Peut utiliser Paralyser, (Le joueur Paralyser peut être voter) : <color=#00ff00>Oui</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家可以投票) : <color=#00ff00>是</color>.\n";
                                    Basilisk += "Can Use Petrify, (Petrified player cant to be voted) : <color=#ff0000>No</color>.\n";
                                    BasiliskFR += "Peut utiliser Pétrifier, (Le joueur Petrifier ne peut pas être voter) : <color=#ff0000>Non</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家不可以投票) : <color=#ff0000>否</color>.\n";
                                }

                                if (BasiliskVote.getSelection() == 2)
                                {
                                    Basilisk += "Can Use Paralyze (Paralized player can to be voted) : <color=#ff0000>No</color>.\n";
                                    BasiliskFR += "Peut utiliser Paralyser, (Le joueur Paralyser peut être voter) : <color=#ff0000>Non</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家可以投票) : <color=#ff0000>否</color>.\n";
                                    Basilisk += "Can Use Petrify, (Petrified player cant to be voted) : <color=#00ff00>Yes</color>.\n";
                                    BasiliskFR += "Peut utiliser Pétrifier, (Le joueur Petrifier ne peut pas être voter) : <color=#00ff00>Oui</color>.\n";
                                    BasiliskZHCN += "可以使用麻痹 (被麻痹玩家不可以投票) : <color=#00ff00>是</color>.\n";
                                }


                                if (BasiliskSinglePetrify.getBool() == true)
                                {
                                    Basilisk += "Paralyze/Petrify players can only be affected once : <color=#00ff00>Yes</color>";
                                    BasiliskFR += "Les joueurs Paralyser/Pétrifier ne peuvent être affectés qu'une seule fois : <color=#00ff00>Yes</color>";
                                    BasiliskZHCN += "被石化/麻痹的玩家只能受到一次影响 : <color=#00ff00>是</color>";
                                }
                                if (BasiliskSinglePetrify.getBool() == false)
                                {
                                    Basilisk += "Paralyze/Petrify players can only be affected once : <color=#ff0000>No</color>";
                                    BasiliskFR += "Les joueurs Paralyser/Pétrifier ne peuvent être affectés qu'une seule fois : <color=#ff0000>Non</color>";
                                    BasiliskZHCN += "被石化/麻痹的玩家只能受到一次影响 : <color=#ff0000>否</color>";
                                }

                                if (BasiliskCanVent.getBool() == true)
                                {
                                    Basilisk += ", Can Use Vent : <color=#00ff00>Yes</color>";
                                    BasiliskFR += ", Peut utiliser les vents : <color=#00ff00>Oui</color>";
                                    BasiliskZHCN += ", 可以钻管 : <color=#00ff00>是</color>";
                                }
                                if (BasiliskCanVent.getBool() == false)
                                {
                                    Basilisk += ", Can Use Vent : <color=#FF0000>No</color>";
                                    BasiliskFR += ", Peut utiliser les vents : <color=#FF0000>Non</color>";
                                    BasiliskZHCN += ", 可以钻管 : <color=#FF0000>否</color>";
                                }
                            }
                            if (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)
                            {
                                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BasiliskFR;
                                }
                                else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
                                {
                                    __instance.GameSettings.text += BasiliskZHCN;
                                }
                                else
                                {
                                    __instance.GameSettings.text += Basilisk;
                                }
                            }

                        }

                        //SPACER ---
                        string SpacerEnd = "\n\n\n ...\n\n";
                        __instance.GameSettings.text += SpacerEnd;


                        AdminButtonMaxTimer = 0f;
                        CamButtonMaxTimer = 0f;
                        VitalButtonMaxTimer = 0f;
                        BuzzButtonMaxTimer = 0f;



                        //COOLDOWN BUTTON AUTO-SET


                        //CREWMATES
                        SheriffKillButtonMaxTimer = SherifKillCooldown.getFloat();
                        GuardianAbilityButtonMaxTimer = 5f;
                        EngineerAbilityButtonMaxTimer = EngineerRepairCD.getFloat();
                        TimelordAbilityButtonMaxTimer = TimeLordStopCooldown.getFloat();
                        TimelordAbilityButtonEffectDuration = TimeLordStopDuration.getFloat();
                        HunterAbilityButtonMaxTimer = 5f;
                        MysticAbilityButtonMaxTimer = MysticSetCooldown.getFloat();
                        MysticAbilityButtonEffectDuration = MysticSetDuration.getFloat();
                        SpiritAbilityButtonMaxTimer = 0f;
                        MayorAbilityButtonMaxTimer = BuzzCooldown.getFloat();
                        DetectiveAbilityButtonMaxTimer = detectiveFootprintcooldown.getFloat();
                        DetectiveAbilityButtonEffectDuration = detectiveFootprintDuration2.getFloat();
                        NightwatchAbilityButtonMaxTimer = NightwatcherSetCooldown.getFloat();
                        NightwatchAbilityButtonEffectDuration = NightwatcherSetDuration.getFloat();
                        SpyAbilityButtonMaxTimer = 5f;
                        SpyAbilityButtonEffectDuration = SpyDuration.getFloat();
                        InformantAbilityButtonMaxTimer = InforCooldown.getFloat();
                        MentalistAbilityButtonMaxTimer = 5f;
                        MentalistAbilityButtonEffectDuration = AdminDuration.getFloat();
                        BuilderAbilityButtonMaxTimer = BuildCooldown.getFloat();
                        DictatorAbilityButtonMaxTimer = 5f;
                        SentinelAbilityButtonMaxTimer = ScanCooldown.getFloat();
                        SentinelAbilityButtonEffectDuration = ScanDuration.getFloat();
                        BaitButtonMaxTimer = BaitBaliseTime.getFloat();
                        MercenaryKillButtonMaxTimer = MercenaryKillCooldown.getFloat();
                        CopyCatScanAbilityButtonMaxTimer = 5f;
                        RevengerAbilityButtonMaxTimer = VengerCooldown.getFloat();
                        CupidAbilityButtonMaxTimer = 1f;
                        CultistAbilityButtonMaxTimer = CultisteCooldown.getFloat();
                        OutlawKillButtonMaxTimer = OutlawKillCooldown.getFloat();
                        JesterAbilityButtonMaxTimer = JesterCooldown.getFloat();
                        CursedTime = CursedTimer.getFloat();
                        CursedAbilityButtonMaxTimer = CursedCooldown.getFloat();
                        CursedAbilityButtonEffectDuration = CursedDuration.getFloat();
                        EaterDraggAbilityButtonMaxTimer = 0f;
                        EaterBarAbilityButtonMaxTimer = 0f;
                        EaterEatAbilityButtonMaxTimer = EaterCooldown.getFloat();
                        EaterEatAbilityButtonEffectDuration = Eaterduration.getFloat();
                        ArsonistOilAbilityButtonMaxTimer = ArsonistCooldown.getFloat();
                        ArsonistOilAbilityButtonEffectDuration = ArsonistDuration.getFloat();
                        ArsonistBurnAbilityButtonMaxTimer = 0f;
                        ImpostorsKillButtonMaxTimer = PlayerControl.GameOptions.KillCooldown + 0f;
                        AssassinKillButtonMaxTimer = AssassinKillCooldown.getFloat();
                        AssassinBonusCD = BImpo.getFloat();
                        AssassinMalusCD = BFake.getFloat();
                        VectorInfectAbilityButtonMaxTimer = VectorBuffCooldown.getFloat();
                        VectorKillButtonMaxTimer = VectorKillCooldown.getFloat();
                        MorphlingScanAbilityButtonMaxTimer = 5f;
                        MorphlingMorphAbilityButtonMaxTimer = MorphSetCooldown.getFloat();
                        MorphlingMorphAbilityButtonEffectDuration = MorphSetDuration.getFloat();
                        ScramblerAbilityButtonMaxTimer = CamoSetCooldown.getFloat();
                        ScramblerAbilityButtonEffectDuration = CamoSetDuration.getFloat();
                        BarghestShadowAbilityButtonMaxTimer = BargestLightCooldown.getFloat();
                        BarghestShadowAbilityButtonEffectDuration = BargestLightDuration.getFloat();
                        BarghestCreateVentAbilityButtonMaxTimer = BarghestVentCD.getFloat();
                        GhostAbilityButtonMaxTimer = HideSetCooldown.getFloat();
                        GhostAbilityButtonEffectDuration = HideSetDuration.getFloat();
                        SorcererFindAbilityButtonMaxTimer = WarCooldown.getFloat();
                        SorcererStuffAbilityButtonMaxTimer = 0f;

                        TotalTask = PlayerControl.GameOptions.NumCommonTasks + PlayerControl.GameOptions.NumLongTasks + PlayerControl.GameOptions.NumShortTasks;
                        if (TotalTask == 0)
                        {
                            PlayerControl.GameOptions.NumShortTasks = 1;
                        }

                        ChallengerMod.Challenger.SetAdminTime = AdminTime.getFloat() + 0f;
                        ChallengerMod.Challenger.SetVitalTime = VitalTime.getFloat() + 0f;
                        ChallengerMod.Challenger.SetCamTime = CamTime.getFloat() + 0f;
                        ChallengerMod.Challenger.timerV = (int)Math.Round(ChallengerMod.Challenger.SetVitalTime);
                        ChallengerMod.Challenger.timerC = (int)Math.Round(ChallengerMod.Challenger.SetCamTime);
                        ChallengerMod.Challenger.timerA = (int)Math.Round(ChallengerMod.Challenger.SetAdminTime);
                        ChallengerMod.Challenger.timerN = (int)Math.Round(ChallengerMod.Challenger.NuclearTimer);
                        ChallengerMod.Challenger.timerLN = (int)Math.Round(ChallengerMod.Challenger.NuclearLastTimer);

                        ChallengerMod.Roles.Bait.BaliseCount = BaitBalise.getFloat();
                        ChallengerMod.Roles.Bait.stunsDelay = BaitStuns.getFloat();
                        ChallengerMod.Roles.Bait.reportDelayMin = BaitReporttime.getFloat();
                        ChallengerMod.Roles.Bait.reportDelayMax = (BaitReporttime.getFloat() + BaitReporttimeRnd.getFloat());

                        Challenger.NuclearTimeMin = NuclearTime1.getFloat();
                        Challenger.NuclearTimeAdd = (NuclearTime1.getFloat() + NuclearTimeRND.getFloat());

                        ChallengerMod.Roles.Guesser.remainingShots = ChallengerOS.Utils.Option.CustomOptionHolder.Gestry.getFloat();
                        ChallengerMod.Roles.Basilisk.CostParalize = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskParalizeCost.getFloat();
                        ChallengerMod.Roles.Basilisk.CostPetrify = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskPetrifyCost.getFloat();

                        ChallengerMod.Roles.Basilisk.PetrifyMax = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat();
                        ChallengerMod.Roles.Basilisk.PetrifyCount = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskStart.getFloat();

                        ChallengerMod.Roles.Basilisk.DoseMeet = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskMeet.getFloat();
                        ChallengerMod.Roles.Basilisk.DoseKill = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskKill.getFloat();
                        ChallengerMod.Roles.Basilisk.DoseStart = ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskStart.getFloat();

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 0) { ChallengerMod.Roles.Cursed.SpeedModifieur = 0; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 1) { ChallengerMod.Roles.Cursed.SpeedModifieur = 1; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 2) { ChallengerMod.Roles.Cursed.SpeedModifieur = 2; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 3) { ChallengerMod.Roles.Cursed.SpeedModifieur = 3; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 4) { ChallengerMod.Roles.Cursed.SpeedModifieur = 4; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 5) { ChallengerMod.Roles.Cursed.SpeedModifieur = 5; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 6) { ChallengerMod.Roles.Cursed.SpeedModifieur = -2; }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.CursedSpeedModifieur.getSelection() == 7) { ChallengerMod.Roles.Cursed.SpeedModifieur = -1; }


                        SetInformantTaskRemaining = (int)Math.Round(TotalTask);
                        SetCost = (int)Math.Round(ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat() - 1);
                        SetCost0 = (int)Math.Round(ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat());

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.EaterCanDrag.getBool() == true) { ChallengerMod.Roles.Eater.CanDragg = true; }
                        else { ChallengerMod.Roles.Eater.CanDragg = false; }

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskVote.getSelection() == 0)
                        {
                            ChallengerMod.Roles.Basilisk.CanPetrifyAndShield = true;
                            ChallengerMod.Roles.Basilisk.CanPetrify = true;
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskVote.getSelection() == 1)
                        {
                            ChallengerMod.Roles.Basilisk.CanPetrifyAndShield = false;
                            ChallengerMod.Roles.Basilisk.CanPetrify = true;
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskVote.getSelection() == 2)
                        {
                            ChallengerMod.Roles.Basilisk.CanPetrifyAndShield = true;
                            ChallengerMod.Roles.Basilisk.CanPetrify = false;
                        }

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.InforRemainingTask.getFloat() > TotalTask)
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.InforRemainingTask.updateSelection(SetInformantTaskRemaining);
                        }


                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskParalizeCost.getFloat() > ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat())
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskParalizeCost.updateSelection(SetCost);
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskPetrifyCost.getFloat() > ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat())
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskPetrifyCost.updateSelection(SetCost);
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskKill.getFloat() > ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat())
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskKill.updateSelection(SetCost0);
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskMeet.getFloat() > ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat())
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskMeet.updateSelection(SetCost0);
                        }
                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskStart.getFloat() > ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskCooldown.getFloat())
                        {
                            ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskStart.updateSelection(SetCost0);
                        }


                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BasiliskSinglePetrify.getBool() == true) { ChallengerMod.Roles.Basilisk.SinglePetrify = true; }
                        else { ChallengerMod.Roles.Basilisk.SinglePetrify = false; }

                        if (ImpostorsKnowEachother.getSelection() == 0) { ChallengerMod.Challenger.UnknowImpostors = false; }
                        else { ChallengerMod.Challenger.UnknowImpostors = true; }

                        if (ImpostorCanKillFake.getBool() == false) { ChallengerMod.Challenger.ImpostorCanKillOther = false; }
                        else { ChallengerMod.Challenger.ImpostorCanKillOther = true; }

                        if (AssassinCanKillShield.getBool() == false) { ChallengerMod.Roles.Assassin.CanKillShield = false; }
                        else { ChallengerMod.Roles.Assassin.CanKillShield = true; }

                        if (BSheriff.getBool() == true) { ChallengerMod.Roles.Assassin.BSheriff = true; }
                        else { ChallengerMod.Roles.Assassin.BSheriff = false; }

                        if (BGuardian.getBool() == true) { ChallengerMod.Roles.Assassin.BGuardian = true; }
                        else { ChallengerMod.Roles.Assassin.BGuardian = false; }

                        if (BEngineer.getBool() == true) { ChallengerMod.Roles.Assassin.BEngineer = true; }
                        else { ChallengerMod.Roles.Assassin.BEngineer = false; }

                        if (BTimelord.getBool() == true) { ChallengerMod.Roles.Assassin.BTimelord = true; }
                        else { ChallengerMod.Roles.Assassin.BTimelord = false; }

                        if (BMystic.getBool() == true) { ChallengerMod.Roles.Assassin.BMystic = true; }
                        else { ChallengerMod.Roles.Assassin.BSheriff = false; }

                        if (BMayor.getBool() == true) { ChallengerMod.Roles.Assassin.BMayor = true; }
                        else { ChallengerMod.Roles.Assassin.BMayor = false; }

                        if (BDetective.getBool() == true) { ChallengerMod.Roles.Assassin.BDetective = true; }
                        else { ChallengerMod.Roles.Assassin.BDetective = false; }

                        if (BNightwatcher.getBool() == true) { ChallengerMod.Roles.Assassin.BNightwatcher = true; }
                        else { ChallengerMod.Roles.Assassin.BNightwatcher = false; }

                        if (BSpy.getBool() == true) { ChallengerMod.Roles.Assassin.BSpy = true; }
                        else { ChallengerMod.Roles.Assassin.BSpy = false; }

                        if (BInfor.getBool() == true) { ChallengerMod.Roles.Assassin.BInfor = true; }
                        else { ChallengerMod.Roles.Assassin.BInfor = false; }

                        if (BMentalist.getBool() == true) { ChallengerMod.Roles.Assassin.BMentalist = true; }
                        else { ChallengerMod.Roles.Assassin.BMentalist = false; }

                        if (BBuilder.getBool() == true) { ChallengerMod.Roles.Assassin.BBuilder = true; }
                        else { ChallengerMod.Roles.Assassin.BBuilder = false; }

                        if (BDictator.getBool() == true) { ChallengerMod.Roles.Assassin.BDictator = true; }
                        else { ChallengerMod.Roles.Assassin.BDictator = false; }

                        if (BSentinel.getBool() == true) { ChallengerMod.Roles.Assassin.BSentinel = true; }
                        else { ChallengerMod.Roles.Assassin.BSentinel = false; }

                        if (BDictator.getBool() == true) { ChallengerMod.Roles.Assassin.BDictator = true; }
                        else { ChallengerMod.Roles.Assassin.BDictator = false; }

                        if (BLawkeeper.getBool() == true) { ChallengerMod.Roles.Assassin.BLawkeeper = true; }
                        else { ChallengerMod.Roles.Assassin.BDictator = false; }

                        ChallengerMod.Roles.Assassin.BImpo = BImpo.getFloat();
                        ChallengerMod.Roles.Assassin.BFake = BFake.getFloat();







                        if (EngineerCanVent.getBool() == true) { ChallengerMod.Roles.Engineer.CanVent = true; }
                        else { ChallengerMod.Roles.Engineer.CanVent = false; }

                        if (BaitCanVent.getBool() == true) { ChallengerMod.Roles.Bait.CanVent = true; }
                        else { ChallengerMod.Roles.Bait.CanVent = false; }

                        if (FakeCanVent.getBool() == true) { ChallengerMod.Roles.Fake.CanVent = true; }
                        else { ChallengerMod.Roles.Fake.CanVent = false; }

                        if (EaterCanVent.getBool() == true) { ChallengerMod.Roles.Eater.CanVent = true; }
                        else { ChallengerMod.Roles.Eater.CanVent = false; }

                        if (OutlawCanVent.getBool() == true) { ChallengerMod.Roles.Outlaw.CanVent = true; }
                        else { ChallengerMod.Roles.Outlaw.CanVent = false; }

                        if (JesterCanVent.getBool() == true) { ChallengerMod.Roles.Jester.CanVent = true; }
                        else { ChallengerMod.Roles.Jester.CanVent = false; }

                        if (MercenaryCanVent.getBool() == true) { ChallengerMod.Roles.Mercenary.CanVent = true; }
                        else { ChallengerMod.Roles.Mercenary.CanVent = false; }

                        if (VectorCanVent.getBool() == true) { ChallengerMod.Roles.Vector.CanVent = true; }
                        else { ChallengerMod.Roles.Vector.CanVent = false; }

                        if (MorphlingCanVent.getBool() == true) { ChallengerMod.Roles.Morphling.CanVent = true; }
                        else { ChallengerMod.Roles.Morphling.CanVent = false; }

                        if (CamoCanVent.getBool() == true) { ChallengerMod.Roles.Scrambler.CanVent = true; }
                        else { ChallengerMod.Roles.Scrambler.CanVent = false; }

                        if (BarghestCanVent.getBool() == true) { ChallengerMod.Roles.Barghest.CanVent = true; }
                        else { ChallengerMod.Roles.Barghest.CanVent = false; }

                        if (GhostCanVent.getBool() == true) { ChallengerMod.Roles.Ghost.CanVent = true; }
                        else { ChallengerMod.Roles.Ghost.CanVent = false; }

                        if (WarCanVent.getBool() == true) { ChallengerMod.Roles.Sorcerer.CanVent = true; }
                        else { ChallengerMod.Roles.Sorcerer.CanVent = false; }

                        if (GuessCanVent.getBool() == true) { ChallengerMod.Roles.Guesser.CanVent = true; }
                        else { ChallengerMod.Roles.Guesser.CanVent = false; }

                        if (BasiliskCanVent.getBool() == true) { ChallengerMod.Roles.Basilisk.CanVent = true; }
                        else { ChallengerMod.Roles.Basilisk.CanVent = false; }

                        Challenger.SurvDroneSpeed = DroneSpeed.getFloat() / 100;




                        PlayerControl.GameOptions.RoleOptions.SetRoleRate(RoleTypes.Shapeshifter, 0, 0);
                        PlayerControl.GameOptions.RoleOptions.SetRoleRate(RoleTypes.GuardianAngel, 0, 0);
                        PlayerControl.GameOptions.RoleOptions.SetRoleRate(RoleTypes.Engineer, 0, 0);
                        PlayerControl.GameOptions.RoleOptions.SetRoleRate(RoleTypes.Scientist, 0, 0);






                        if (Challenger.IsrankedGame)
                        {
                            if (Challenger._DIF == 1)
                            {
                                PlayerControl.GameOptions.KillCooldown = 27.5f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 7;
                                PlayerControl.GameOptions.NumLongTasks = 1;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 3;
                                PlayerControl.GameOptions.ImpostorLightMod = 1f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }
                            if (Challenger._DIF == 2)
                            {
                                PlayerControl.GameOptions.KillCooldown = 25f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 6;
                                PlayerControl.GameOptions.NumLongTasks = 2;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 3;
                                PlayerControl.GameOptions.ImpostorLightMod = 1f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }
                            if (Challenger._DIF == 3)
                            {
                                PlayerControl.GameOptions.KillCooldown = 22.5f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 6;
                                PlayerControl.GameOptions.NumLongTasks = 2;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                                PlayerControl.GameOptions.ImpostorLightMod = 1f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }
                            if (Challenger._DIF == 4)
                            {
                                PlayerControl.GameOptions.KillCooldown = 22.5f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 5;
                                PlayerControl.GameOptions.NumLongTasks = 3;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                                PlayerControl.GameOptions.ImpostorLightMod = 1f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }
                            if (Challenger._DIF == 5)
                            {
                                PlayerControl.GameOptions.KillCooldown = 20f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 6;
                                PlayerControl.GameOptions.NumLongTasks = 3;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                                PlayerControl.GameOptions.ImpostorLightMod = 1.25f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }
                            if (Challenger._DIF == 6)
                            {
                                PlayerControl.GameOptions.KillCooldown = 22.5f;
                                PlayerControl.GameOptions.NumCommonTasks = 2;
                                PlayerControl.GameOptions.NumShortTasks = 5;
                                PlayerControl.GameOptions.NumLongTasks = 3;
                                PlayerControl.GameOptions.NumEmergencyMeetings = 1;
                                PlayerControl.GameOptions.ImpostorLightMod = 1.25f;
                                PlayerControl.GameOptions.ConfirmImpostor = false;
                                PlayerControl.GameOptions.AnonymousVotes = true;
                                PlayerControl.GameOptions.VisualTasks = false;
                                PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                                PlayerControl.GameOptions.DiscussionTime = 15;
                                PlayerControl.GameOptions.VotingTime = 165;
                                PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                                PlayerControl.GameOptions.CrewLightMod = 0.5f;
                                PlayerControl.GameOptions.EmergencyCooldown = 15;
                                PlayerControl.GameOptions.KillDistance = 0;
                            }

                            

                            
                            
                            

                            if (QTImp.getFloat() == 1) { PlayerControl.GameOptions.NumImpostors = 1; }
                            else if (QTImp.getFloat() == 2) { PlayerControl.GameOptions.NumImpostors = 2; }
                            else if (QTImp.getFloat() == 3) { PlayerControl.GameOptions.NumImpostors = 3; }


                            if (AmongUsClient.Instance.AmHost)
                            {
                                Challenger._Players = PlayerControl.GameOptions.MaxPlayers;

                                if (QTImp.getFloat() == 0) { QTImp.updateSelection(1); }


                                Challenger._CRW = 0 + Challenger._Players - Challenger._IMP - Challenger._DUO - Challenger._SPE;
                               
                                if (QTCrew.getFloat() != Challenger._CRW)
                                {
                                    QTCrew.updateSelection(Challenger._CRW);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                

                                if ((PlayerControl.GameOptions.NumImpostors == 2 && Challenger._Players < 12 && MercenaryAdd.getBool() == true)
                                    || (PlayerControl.GameOptions.NumImpostors == 3 && Challenger._Players < 15 && MercenaryAdd.getBool() == true)
                                    )
                                {
                                    MercenaryAdd.updateSelection(0);
                                }
                                if (Challenger._Players == 10)
                                {
                                    if (QTImp.getFloat() > 2) 
                                    { 
                                        QTImp.updateSelection(2);
                                        Challenger._IMP = 2;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTDuo.getFloat() > 1) 
                                    { 
                                        QTDuo.updateSelection(1);
                                        Challenger._DUO = 1;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTSpe.getFloat() > 1) 
                                    { 
                                        QTSpe.updateSelection(1);
                                        Challenger._SPE = 1;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                if (Challenger._Players == 11)
                                {
                                    if (QTImp.getFloat() > 2) 
                                    { 
                                        QTImp.updateSelection(2);
                                        Challenger._IMP = 2;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTDuo.getFloat() > 2) 

                                    { 
                                        QTDuo.updateSelection(2);
                                        Challenger._DUO = 2;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTSpe.getFloat() > 2)
                                    { 
                                        QTSpe.updateSelection(2);
                                        Challenger._SPE = 2;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                if (Challenger._Players == 12)
                                {
                                    if (QTImp.getFloat() > 2) 
                                    { 
                                        QTImp.updateSelection(2);
                                        Challenger._IMP = 2;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTDuo.getFloat() > 3) 
                                    {
                                        QTDuo.updateSelection(3);
                                        Challenger._DUO = 3;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    if (QTSpe.getFloat() > 3)
                                    {
                                        QTSpe.updateSelection(3);
                                        Challenger._SPE = 3;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                if (Challenger._Players == 13)
                                {
                                    if (QTSpe.getFloat() > 4) 
                                    { 
                                        QTSpe.updateSelection(4);
                                        Challenger._SPE = 4;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                if (Challenger._Players == 14)
                                {
                                    if (QTSpe.getFloat() > 5)
                                    {
                                        QTSpe.updateSelection(5);
                                        Challenger._SPE = 5;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }

                                }


                                

                                

                                



                                if (Challenger._DIF == 1) 
                                {
                                    DroneSpeed.updateSelection(2);
                                    BuzzCommon.updateSelection(1);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    CommsSabotageAnonymous.updateSelection(0);
                                    BetterTaskWeapon.updateSelection(0);
                                    AdminTime.updateSelection(29);
                                    VitalTime.updateSelection(24);
                                    CamTime.updateSelection(39);

                                    SherifKillSettings.updateSelection(0);
                                    SherifKillCooldown.updateSelection(5);
                                    GuardianShieldSound.updateSelection(1);
                                    MysticSetCooldown.updateSelection(6);
                                    MysticSetDuration.updateSelection(9);
                                    SpyRange.updateSelection(2);
                                    InforRemainingTask.updateSelection(5);
                                    BaitReport.updateSelection(2);
                                    BaitReporttime.updateSelection(3);
                                    BaitReporttimeRnd.updateSelection(2);
                                    BaitStuns.updateSelection(4);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(5);
                                    BaitBaliseTime.updateSelection(6);
                                    AdminDuration.updateSelection(14);
                                    MaxBuild.updateSelection(2);
                                    DictatorMeeting.updateSelection(2);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(2);
                                    DictatorForcedVote.updateSelection(0);
                                    TimeRName.updateSelection(5);
                                    TimeRList.updateSelection(20);
                                    FakeCanVent.updateSelection(1);
                                    LeaderTaskEnd.updateSelection(1);
                                    MercenaryKillCooldown.updateSelection(7);
                                    MercenaryCanVent.updateSelection(0);
                                    AssassinKillCooldown.updateSelection(7);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(15);
                                    BImpo.updateSelection(5);
                                    VectorBuffCooldown.updateSelection(10);
                                    VectorCanVent.updateSelection(0);
                                    CamoSetCooldown.updateSelection(10);
                                    CamoSetDuration.updateSelection(6);
                                    BargestLightCooldown.updateSelection(10);
                                    BargestLightDuration.updateSelection(6);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(0);
                                    HideSetCooldown.updateSelection(10);
                                    HideSetDuration.updateSelection(9);
                                    WarCooldown.updateSelection(6);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(0);
                                    War4.updateSelection(0);
                                    BasiliskCooldown.updateSelection(0);
                                    BasiliskStart.updateSelection(1);
                                    BasiliskMeet.updateSelection(0);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(1);
                                    BasiliskParalizeCost.updateSelection(0);
                                    BasiliskPetrifyCost.updateSelection(0);
                                    BasiliskSinglePetrify.updateSelection(1);

                                    SherifKillRange.updateSelection(1);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(1);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(8);
                                    detectiveFootprintDuration.updateSelection(7);
                                    detectiveFootprintDuration2.updateSelection(10);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(8);
                                    NightwatcherSetDuration.updateSelection(11);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(4);
                                    InforAnalyseMod.updateSelection(0);
                                    InforAnalyseMod.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(4);
                                    ScanCooldown.updateSelection(7);
                                    ScanDuration.updateSelection(8);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);


                                    if (((Challenger._Players == 10 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 11 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 12 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 13 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 13 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 14 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 14 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 15))
                                        ) { CopyImp.updateSelection(1); }
                                    else { CopyImp.updateSelection(2); }

                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(0);
                                    SurvivorWinArsonist.updateSelection(0);
                                    SurvivorWinCursed.updateSelection(0);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(0);
                                    VengerExil.updateSelection(0);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(12);
                                    Cultistdie.updateSelection(0);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(0);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(6);
                                    OutlawKillRange.updateSelection(1);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    if (Challenger._MapID >= 8 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistFuelQT.updateSelection(0); }
                                    else { ArsonistFuelQT.updateSelection(3); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }


                                    AutoRefuel.updateSelection(0);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(8);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(6);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(0);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    if ((Challenger._Players == 10) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 10) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);
                                }
                                if (Challenger._DIF == 2)
                                {
                                    DroneSpeed.updateSelection(2);
                                    BuzzCommon.updateSelection(1);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    CommsSabotageAnonymous.updateSelection(0);
                                    BetterTaskWeapon.updateSelection(0);
                                    AdminTime.updateSelection(24);
                                    VitalTime.updateSelection(19);
                                    CamTime.updateSelection(34);

                                    SherifKillSettings.updateSelection(0);
                                    SherifKillCooldown.updateSelection(6);
                                    GuardianShieldSound.updateSelection(0);
                                    MysticSetCooldown.updateSelection(8);
                                    MysticSetDuration.updateSelection(9);
                                    SpyRange.updateSelection(1);
                                    InforRemainingTask.updateSelection(4);
                                    BaitReport.updateSelection(0);
                                    BaitReporttime.updateSelection(0);
                                    BaitReporttimeRnd.updateSelection(0);
                                    BaitStuns.updateSelection(4);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(4);
                                    BaitBaliseTime.updateSelection(6);
                                    AdminDuration.updateSelection(11);
                                    MaxBuild.updateSelection(2);
                                    DictatorMeeting.updateSelection(1);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(2);
                                    DictatorForcedVote.updateSelection(0);
                                    TimeRName.updateSelection(3);
                                    TimeRList.updateSelection(15);
                                    FakeCanVent.updateSelection(0);
                                    LeaderTaskEnd.updateSelection(1);
                                    MercenaryKillCooldown.updateSelection(6);
                                    MercenaryCanVent.updateSelection(0);
                                    AssassinKillCooldown.updateSelection(6);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(12);
                                    BImpo.updateSelection(5);
                                    VectorBuffCooldown.updateSelection(8);
                                    VectorCanVent.updateSelection(0);
                                    CamoSetCooldown.updateSelection(10);
                                    CamoSetDuration.updateSelection(7);
                                    BargestLightCooldown.updateSelection(10);
                                    BargestLightDuration.updateSelection(7);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(0);
                                    HideSetCooldown.updateSelection(10);
                                    HideSetDuration.updateSelection(11);
                                    WarCooldown.updateSelection(6);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(1);
                                    War4.updateSelection(0);
                                    BasiliskCooldown.updateSelection(1);
                                    BasiliskStart.updateSelection(2);
                                    BasiliskMeet.updateSelection(0);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(2);
                                    BasiliskParalizeCost.updateSelection(0);
                                    BasiliskPetrifyCost.updateSelection(0);
                                    BasiliskSinglePetrify.updateSelection(1);

                                    SherifKillRange.updateSelection(1);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(1);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(8);
                                    detectiveFootprintDuration.updateSelection(7);
                                    detectiveFootprintDuration2.updateSelection(10);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(8);
                                    NightwatcherSetDuration.updateSelection(11);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(4);
                                    InforAnalyseMod.updateSelection(0);
                                    InforAnalyseMod.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(4);
                                    ScanCooldown.updateSelection(7);
                                    ScanDuration.updateSelection(8);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);


                                    if (((Challenger._Players == 10 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 11 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 12 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 13 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 13 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 14 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 14 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 15))
                                        ) { CopyImp.updateSelection(1); }
                                    else { CopyImp.updateSelection(2); }

                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(0);
                                    SurvivorWinArsonist.updateSelection(0);
                                    SurvivorWinCursed.updateSelection(0);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(0);
                                    VengerExil.updateSelection(0);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(12);
                                    Cultistdie.updateSelection(0);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(0);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(6);
                                    OutlawKillRange.updateSelection(1);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    if (Challenger._MapID >= 8 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistFuelQT.updateSelection(0); }
                                    else { ArsonistFuelQT.updateSelection(3); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }


                                    AutoRefuel.updateSelection(0);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(8);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(6);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(0);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    if ((Challenger._Players == 10) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 10) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);
                                }
                                if (Challenger._DIF == 3) 
                                {
                                    DroneSpeed.updateSelection(2);
                                    BuzzCommon.updateSelection(1);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    if (Challenger._MapID >= 6)
                                    {
                                        CommsSabotageAnonymous.updateSelection(0);
                                        BetterTaskWeapon.updateSelection(0);
                                        AdminTime.updateSelection(24);
                                        VitalTime.updateSelection(19);
                                        CamTime.updateSelection(34);
                                    }
                                    else
                                    {
                                        CommsSabotageAnonymous.updateSelection(1);
                                        BetterTaskWeapon.updateSelection(0);
                                        AdminTime.updateSelection(24);
                                        VitalTime.updateSelection(19);
                                        CamTime.updateSelection(34);
                                    }

                                    SherifKillSettings.updateSelection(1);
                                    SherifKillCooldown.updateSelection(6);
                                    GuardianShieldSound.updateSelection(0);
                                    MysticSetCooldown.updateSelection(8);
                                    MysticSetDuration.updateSelection(9);
                                    SpyRange.updateSelection(1);
                                    InforRemainingTask.updateSelection(3);
                                    BaitReport.updateSelection(0);
                                    BaitReporttime.updateSelection(0);
                                    BaitReporttimeRnd.updateSelection(0);
                                    BaitStuns.updateSelection(2);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(3);
                                    BaitBaliseTime.updateSelection(6);
                                    AdminDuration.updateSelection(9);
                                    MaxBuild.updateSelection(2);
                                    DictatorMeeting.updateSelection(1);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(2);
                                    DictatorForcedVote.updateSelection(1);
                                    TimeRName.updateSelection(2);
                                    TimeRList.updateSelection(12);
                                    FakeCanVent.updateSelection(0);
                                    LeaderTaskEnd.updateSelection(1);
                                    MercenaryKillCooldown.updateSelection(6);
                                    MercenaryCanVent.updateSelection(1);
                                    AssassinKillCooldown.updateSelection(6);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(10);
                                    BImpo.updateSelection(5);
                                    VectorBuffCooldown.updateSelection(6);
                                    VectorCanVent.updateSelection(0);
                                    CamoSetCooldown.updateSelection(10);
                                    CamoSetDuration.updateSelection(7);
                                    BargestLightCooldown.updateSelection(10);
                                    BargestLightDuration.updateSelection(7);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(1);
                                    HideSetCooldown.updateSelection(10);
                                    HideSetDuration.updateSelection(11);
                                    WarCooldown.updateSelection(5);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(1);
                                    War4.updateSelection(1);
                                    BasiliskCooldown.updateSelection(1);
                                    BasiliskStart.updateSelection(2);
                                    BasiliskMeet.updateSelection(0);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(2);
                                    BasiliskParalizeCost.updateSelection(0);
                                    BasiliskPetrifyCost.updateSelection(0);
                                    BasiliskSinglePetrify.updateSelection(1);

                                    SherifKillRange.updateSelection(1);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(1);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(8);
                                    detectiveFootprintDuration.updateSelection(7);
                                    detectiveFootprintDuration2.updateSelection(10);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(8);
                                    NightwatcherSetDuration.updateSelection(11);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(4);
                                    InforAnalyseMod.updateSelection(0);
                                    InforAnalyseMod.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(4);
                                    ScanCooldown.updateSelection(7);
                                    ScanDuration.updateSelection(8);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);


                                    if (((Challenger._Players == 10 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 11 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 12 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 13 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 13 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 14 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 14 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 15))
                                        ) { CopyImp.updateSelection(1); }
                                    else { CopyImp.updateSelection(2); }

                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(0);
                                    SurvivorWinArsonist.updateSelection(0);
                                    SurvivorWinCursed.updateSelection(0);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(0);
                                    VengerExil.updateSelection(0);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(12);
                                    Cultistdie.updateSelection(0);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(0);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(6);
                                    OutlawKillRange.updateSelection(1);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    if (Challenger._MapID >= 8 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistFuelQT.updateSelection(0); }
                                    else { ArsonistFuelQT.updateSelection(3); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }


                                    AutoRefuel.updateSelection(0);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(8);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(6);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(0);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    if ((Challenger._Players == 10) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 10) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);
                                }
                                if (Challenger._DIF == 4)
                                {
                                    DroneSpeed.updateSelection(2);
                                    BuzzCommon.updateSelection(1);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    if (Challenger._MapID >= 6)
                                    {
                                        CommsSabotageAnonymous.updateSelection(0);
                                        BetterTaskWeapon.updateSelection(0);
                                        AdminTime.updateSelection(24);
                                        VitalTime.updateSelection(19);
                                        CamTime.updateSelection(34);
                                    }
                                    else
                                    {
                                        CommsSabotageAnonymous.updateSelection(1);
                                        BetterTaskWeapon.updateSelection(0);
                                        AdminTime.updateSelection(24);
                                        VitalTime.updateSelection(19);
                                        CamTime.updateSelection(34);
                                    }

                                    SherifKillSettings.updateSelection(2);
                                    SherifKillCooldown.updateSelection(5);
                                    GuardianShieldSound.updateSelection(0);
                                    MysticSetCooldown.updateSelection(8);
                                    MysticSetDuration.updateSelection(7);
                                    SpyRange.updateSelection(1);
                                    InforRemainingTask.updateSelection(2);
                                    BaitReport.updateSelection(0);
                                    BaitReporttime.updateSelection(0);
                                    BaitReporttimeRnd.updateSelection(0);
                                    BaitStuns.updateSelection(2);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(2);
                                    BaitBaliseTime.updateSelection(6);
                                    AdminDuration.updateSelection(7);
                                    MaxBuild.updateSelection(1);
                                    DictatorMeeting.updateSelection(1);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(2);
                                    DictatorForcedVote.updateSelection(1);
                                    TimeRName.updateSelection(1);
                                    TimeRList.updateSelection(10);
                                    FakeCanVent.updateSelection(0);
                                    LeaderTaskEnd.updateSelection(1);
                                    MercenaryKillCooldown.updateSelection(2);
                                    MercenaryCanVent.updateSelection(1);
                                    AssassinKillCooldown.updateSelection(5);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(8);
                                    BImpo.updateSelection(5);
                                    VectorBuffCooldown.updateSelection(6);
                                    VectorCanVent.updateSelection(0);
                                    CamoSetCooldown.updateSelection(10);
                                    CamoSetDuration.updateSelection(9);
                                    BargestLightCooldown.updateSelection(10);
                                    BargestLightDuration.updateSelection(9);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(1);
                                    HideSetCooldown.updateSelection(8);
                                    HideSetDuration.updateSelection(11);
                                    WarCooldown.updateSelection(4);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(1);
                                    War4.updateSelection(1);
                                    BasiliskCooldown.updateSelection(1);
                                    BasiliskStart.updateSelection(2);
                                    BasiliskMeet.updateSelection(0);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(0);
                                    BasiliskParalizeCost.updateSelection(0);
                                    BasiliskPetrifyCost.updateSelection(0);
                                    BasiliskSinglePetrify.updateSelection(1);

                                    SherifKillRange.updateSelection(1);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(1);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(8);
                                    detectiveFootprintDuration.updateSelection(7);
                                    detectiveFootprintDuration2.updateSelection(10);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(8);
                                    NightwatcherSetDuration.updateSelection(11);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(4);
                                    InforAnalyseMod.updateSelection(0);
                                    InforAnalyseMod.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(4);
                                    ScanCooldown.updateSelection(7);
                                    ScanDuration.updateSelection(8);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);


                                    if (((Challenger._Players == 10 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 11 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 12 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 13 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 13 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 14 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 14 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 15))
                                        ) { CopyImp.updateSelection(1); }
                                    else { CopyImp.updateSelection(2); }

                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(0);
                                    SurvivorWinArsonist.updateSelection(0);
                                    SurvivorWinCursed.updateSelection(0);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(0);
                                    VengerExil.updateSelection(0);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(12);
                                    Cultistdie.updateSelection(0);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(0);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(6);
                                    OutlawKillRange.updateSelection(1);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    if (Challenger._MapID >= 8 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistFuelQT.updateSelection(0); }
                                    else { ArsonistFuelQT.updateSelection(3); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }


                                    AutoRefuel.updateSelection(0);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(8);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(6);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(0);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    if ((Challenger._Players == 10) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 10) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);
                                }
                                if (Challenger._DIF == 5)
                                {
                                    DroneSpeed.updateSelection(2);
                                    BuzzCommon.updateSelection(1);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    CommsSabotageAnonymous.updateSelection(1);
                                    BetterTaskWeapon.updateSelection(1);
                                    AdminTime.updateSelection(19);
                                    VitalTime.updateSelection(14);
                                    CamTime.updateSelection(29);

                                    SherifKillSettings.updateSelection(2);
                                    SherifKillCooldown.updateSelection(4);
                                    GuardianShieldSound.updateSelection(0);
                                    MysticSetCooldown.updateSelection(8);
                                    MysticSetDuration.updateSelection(7);
                                    SpyRange.updateSelection(1);
                                    InforRemainingTask.updateSelection(0);
                                    BaitReport.updateSelection(0);
                                    BaitReporttime.updateSelection(0);
                                    BaitReporttimeRnd.updateSelection(0);
                                    BaitStuns.updateSelection(1);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(2);
                                    BaitBaliseTime.updateSelection(8);
                                    AdminDuration.updateSelection(4);
                                    MaxBuild.updateSelection(1);
                                    DictatorMeeting.updateSelection(1);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(2);
                                    DictatorForcedVote.updateSelection(1);
                                    TimeRName.updateSelection(0);
                                    TimeRList.updateSelection(10);
                                    FakeCanVent.updateSelection(0);
                                    LeaderTaskEnd.updateSelection(0);
                                    MercenaryKillCooldown.updateSelection(4);
                                    MercenaryCanVent.updateSelection(1);
                                    AssassinKillCooldown.updateSelection(4);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(5);
                                    BImpo.updateSelection(5);
                                    VectorBuffCooldown.updateSelection(6);
                                    VectorCanVent.updateSelection(1);
                                    CamoSetCooldown.updateSelection(8);
                                    CamoSetDuration.updateSelection(9);
                                    BargestLightCooldown.updateSelection(8);
                                    BargestLightDuration.updateSelection(9);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(1);
                                    HideSetCooldown.updateSelection(6);
                                    HideSetDuration.updateSelection(11);
                                    WarCooldown.updateSelection(2);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(1);
                                    War4.updateSelection(1);
                                    BasiliskCooldown.updateSelection(1);
                                    BasiliskStart.updateSelection(2);
                                    BasiliskMeet.updateSelection(0);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(0);
                                    BasiliskParalizeCost.updateSelection(0);
                                    BasiliskPetrifyCost.updateSelection(0);
                                    BasiliskSinglePetrify.updateSelection(0);

                                    SherifKillRange.updateSelection(1);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(1);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(8);
                                    detectiveFootprintDuration.updateSelection(7);
                                    detectiveFootprintDuration2.updateSelection(10);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(8);
                                    NightwatcherSetDuration.updateSelection(11);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(4);
                                    InforAnalyseMod.updateSelection(0);
                                    InforAnalyseMod.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(4);
                                    ScanCooldown.updateSelection(7);
                                    ScanDuration.updateSelection(8);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);


                                    if (((Challenger._Players == 10 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 11 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 12 && Challenger._IMP == 1) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 13 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 13 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 14 && Challenger._IMP == 1))
                                        || ((Challenger._Players == 14 && Challenger._IMP == 2) && ChallengerMod.Set.Data.MercenaryMin == 0f)
                                        || ((Challenger._Players == 15))
                                        ) { CopyImp.updateSelection(1); }
                                    else { CopyImp.updateSelection(2); }

                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(0);
                                    SurvivorWinArsonist.updateSelection(0);
                                    SurvivorWinCursed.updateSelection(0);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(0);
                                    VengerExil.updateSelection(0);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(12);
                                    Cultistdie.updateSelection(0);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(0);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(4); Eaterduration.updateSelection(2); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(2); Eaterduration.updateSelection(1); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(6);
                                    OutlawKillRange.updateSelection(1);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    if (Challenger._MapID >= 8 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistFuelQT.updateSelection(0); }
                                    else { ArsonistFuelQT.updateSelection(3); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(2); ArsonistDuration.updateSelection(1); ArsonistFailDuration.updateSelection(4); }


                                    AutoRefuel.updateSelection(0);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(6); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(8);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(6);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(0);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    if ((Challenger._Players == 10) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 10) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 11) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(1); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 12) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 13) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 14) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(2); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 1)) { GuessDie.updateSelection(0); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 2)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }
                                    if ((Challenger._Players == 15) && (Challenger._IMP == 3)) { GuessDie.updateSelection(1); Gestry.updateSelection(3); }

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);
                                }

                                if (Challenger._DIF == 6)
                                {
                                    DroneSpeed.updateSelection(3);
                                    BuzzCommon.updateSelection(0);

                                    ImpostorsKnowEachother.updateSelection(0);

                                    DisabledAdmin.updateSelection(0);
                                    DisabledVitales.updateSelection(0);
                                    DisabledCamera.updateSelection(0);

                                    AdminTimeOn.updateSelection(1);
                                    VitalTimeOn.updateSelection(1);
                                    CamTimeOn.updateSelection(1);

                                    CommsSabotageAnonymous.updateSelection(1);
                                    BetterTaskWeapon.updateSelection(0);
                                    AdminTime.updateSelection(19);
                                    VitalTime.updateSelection(9);
                                    CamTime.updateSelection(34);

                                    SherifKillSettings.updateSelection(2);
                                    SherifKillCooldown.updateSelection(5);
                                    GuardianShieldSound.updateSelection(0);
                                    MysticSetCooldown.updateSelection(4);
                                    MysticSetDuration.updateSelection(9);
                                    SpyRange.updateSelection(1);
                                    InforRemainingTask.updateSelection(0);
                                    BaitReport.updateSelection(0);
                                    BaitReporttime.updateSelection(0);
                                    BaitReporttimeRnd.updateSelection(0);
                                    BaitStuns.updateSelection(2);
                                    BaitCanVent.updateSelection(0);
                                    BaitBalise.updateSelection(2);
                                    BaitBaliseTime.updateSelection(0);
                                    AdminDuration.updateSelection(4);
                                    MaxBuild.updateSelection(1);
                                    DictatorMeeting.updateSelection(1);
                                    DictatorFirstTurn.updateSelection(1);
                                    DictatorAbility.updateSelection(1);
                                    DictatorForcedVote.updateSelection(1);
                                    TimeRName.updateSelection(2);
                                    TimeRList.updateSelection(15);
                                    FakeCanVent.updateSelection(0);
                                    LeaderTaskEnd.updateSelection(1);
                                    MercenaryKillCooldown.updateSelection(5);
                                    MercenaryCanVent.updateSelection(1);
                                    AssassinKillCooldown.updateSelection(5);
                                    AssassinCanKillShield.updateSelection(0);
                                    BFake.updateSelection(3);
                                    BImpo.updateSelection(8);
                                    VectorBuffCooldown.updateSelection(8);
                                    VectorCanVent.updateSelection(1);
                                    CamoSetCooldown.updateSelection(10);
                                    CamoSetDuration.updateSelection(7);
                                    BargestLightCooldown.updateSelection(10);
                                    BargestLightDuration.updateSelection(7);
                                    BarghestAffectImpostor.updateSelection(0);
                                    BarghestCamlight.updateSelection(1);
                                    HideSetCooldown.updateSelection(10);
                                    HideSetDuration.updateSelection(7);
                                    WarCooldown.updateSelection(2);
                                    War1.updateSelection(1);
                                    War2.updateSelection(1);
                                    War3.updateSelection(1);
                                    War4.updateSelection(1);
                                    BasiliskCooldown.updateSelection(1);
                                    BasiliskStart.updateSelection(2);
                                    BasiliskMeet.updateSelection(1);
                                    BasiliskKill.updateSelection(0);
                                    BasiliskVote.updateSelection(2);
                                    BasiliskParalizeCost.updateSelection(1);
                                    BasiliskPetrifyCost.updateSelection(1);
                                    BasiliskSinglePetrify.updateSelection(0);

                                    SherifKillRange.updateSelection(0);
                                    SherifKillCulteMember.updateSelection(1);
                                    ShieldSettings.updateSelection(0);
                                    GuardianShieldVisibility.updateSelection(0);
                                    GuardianShieldVisibilitytry.updateSelection(2);
                                    EngineerCanVent.updateSelection(1);
                                    EngineerRepairCD.updateSelection(2);
                                    RepairSettings.updateSelection(0);
                                    TimeLordStopCooldown.updateSelection(12);
                                    TimeLordStopDuration.updateSelection(7);
                                    ResetTrack.updateSelection(1);
                                    Followtrack.updateSelection(1);
                                    SpiritSab.updateSelection(0);
                                    BonusBuzz.updateSelection(2);
                                    BuzzCooldown.updateSelection(4);
                                    detectiveFootprintcooldown.updateSelection(0);
                                    detectiveFootprintDuration.updateSelection(19);
                                    detectiveFootprintDuration2.updateSelection(14);
                                    detectiveFootprintanonymous.updateSelection(0);
                                    NightwatcherSetCooldown.updateSelection(6);
                                    NightwatcherSetDuration.updateSelection(7);
                                    SpyDuration.updateSelection(4);
                                    InforCooldown.updateSelection(2);
                                    InforAnalyseMod.updateSelection(1);
                                    InforAnalyseTeam.updateSelection(1);
                                    MentalistAbility.updateSelection(0);
                                    AdminSetting.updateSelection(1);
                                    BuildRound.updateSelection(1);
                                    BuildCooldown.updateSelection(0);
                                    ScanCooldown.updateSelection(8);
                                    ScanDuration.updateSelection(9);
                                    ScanAbility.updateSelection(2);
                                    LKTimer.updateSelection(1);
                                    LKInfo.updateSelection(1);
                                    SuperInfo.updateSelection(0);
                                    ImpostorCanKillFake.updateSelection(1);
                                    LeaderAffectCupid.updateSelection(0);

                                    CopyImp.updateSelection(2);
                                    CopySpe.updateSelection(1);

                                    SurvivorWinJester.updateSelection(1);
                                    SurvivorWinEater.updateSelection(1);
                                    SurvivorWinOutlaw.updateSelection(1);
                                    SurvivorWinCulte.updateSelection(1);
                                    SurvivorWinArsonist.updateSelection(1);
                                    SurvivorWinCursed.updateSelection(1);

                                    QtVenger.updateSelection(2);
                                    VengerCooldown.updateSelection(8);
                                    VengerKill.updateSelection(1);
                                    VengerExil.updateSelection(1);

                                    //SPE
                                    Loverdie.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(0); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CultisteMin == 1f) { CulteMember.updateSelection(2); }


                                    CultisteCooldown.updateSelection(8);
                                    Cultistdie.updateSelection(2);

                                    JesterSingle.updateSelection(2);
                                    JesterCooldown.updateSelection(12);
                                    JesterCanVent.updateSelection(0);
                                    JesterIMPV.updateSelection(1);
                                    JesterIMPVS.updateSelection(1);



                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(1); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.EaterMin == 1f) { Eatvalueforwin.updateSelection(2); EaterCooldown.updateSelection(6); Eaterduration.updateSelection(4); }

                                    EaterCanVent.updateSelection(0);
                                    EaterCanDrag.updateSelection(1);
                                    BodyRemove.updateSelection(0);
                                    EaterIMPV.updateSelection(0);
                                    EaterIMPVS.updateSelection(0);

                                    OutlawKillCooldown.updateSelection(5);
                                    OutlawKillRange.updateSelection(0);
                                    OutlawCanVent.updateSelection(1);
                                    OutlawIMPV.updateSelection(1);
                                    OutlawIMPVS.updateSelection(0);

                                    ArsonistFuelQT.updateSelection(5); 

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.ArsonistMin == 1f) { ArsonistCooldown.updateSelection(4); ArsonistDuration.updateSelection(2); ArsonistFailDuration.updateSelection(9); }


                                    AutoRefuel.updateSelection(1);

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(0); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID >= 8) { CursedSpeedModifieur.updateSelection(7); }

                                    if (Challenger._Players == 10 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(4); }
                                    if (Challenger._Players == 11 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(3); }
                                    if (Challenger._Players == 12 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(2); }
                                    if (Challenger._Players == 13 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(1); }
                                    if (Challenger._Players == 14 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(7); }
                                    if (Challenger._Players == 15 && ChallengerMod.Set.Data.CursedMin == 1f && Challenger._MapID < 8) { CursedSpeedModifieur.updateSelection(6); }

                                    CursedTimer.updateSelection(4);
                                    CursedAbility.updateSelection(1);
                                    CursedCooldown.updateSelection(4);
                                    CursedDuration.updateSelection(9);

                                    //IMP

                                    BSheriff.updateSelection(1);
                                    BGuardian.updateSelection(1);
                                    BEngineer.updateSelection(1);
                                    BTimelord.updateSelection(1);
                                    BMystic.updateSelection(1);
                                    BMayor.updateSelection(1);
                                    BDetective.updateSelection(1);
                                    BNightwatcher.updateSelection(1);
                                    BSpy.updateSelection(1);
                                    BInfor.updateSelection(1);
                                    BMentalist.updateSelection(1);
                                    BBuilder.updateSelection(1);
                                    BDictator.updateSelection(1);
                                    BSentinel.updateSelection(1);
                                    BLawkeeper.updateSelection(1);
                                    VectorKillCooldown.updateSelection(4);
                                    VectorBuffVisibility.updateSelection(1);
                                    MorphSetCooldown.updateSelection(4);
                                    MorphSetDuration.updateSelection(14);
                                    MorphlingCanVent.updateSelection(1);
                                    CamoCanVent.updateSelection(1);

                                    if (Challenger._MapID >= 6 || Challenger._MapID == 3) { BarghestCanCreateVent.updateSelection(0); }
                                    else { BarghestCanCreateVent.updateSelection(1); }

                                    BarghestVentCD.updateSelection(0);
                                    BarghestCanVent.updateSelection(1);
                                    CanUseBarghestVent.updateSelection(4);
                                    GhostCanVent.updateSelection(1);
                                    WarCanVent.updateSelection(1);


                                    GuessDie.updateSelection(1);
                                    Gestry.updateSelection(1); 
                                    

                                    GuessTryOne.updateSelection(1);
                                    GuessMystic.updateSelection(1);
                                    GuessSpirit.updateSelection(1);
                                    GuessFake.updateSelection(1);
                                    GuessCanVent.updateSelection(1);
                                    BasiliskCanVent.updateSelection(1);

                                }
                                

                            }
                        }









                        if ((PlayerControl.GameOptions.NumImpostors == 1 && FakeAdd.getBool() == true) || ImpostorsKnowEachother.getSelection() == 1 && FakeAdd.getBool() == true)
                        {
                            FakeAdd.updateSelection(0);
                        }


                        if (PlayerControl.GameOptions.NumImpostors == 1 && ImpostorsKnowEachother.getSelection() == 1)
                        {
                            ImpostorsKnowEachother.updateSelection(0);
                        }


                        if (SherifAdd.getBool() == true)
                        {
                            HIDE_Sheriff.updateSelection(1);
                        }
                        else
                        {
                            if (CopyCatAdd.getBool() == true)
                            {
                                if ((CopyImp.getSelection() == 2 || CopySpe.getSelection() == 1))
                                {
                                    HIDE_Sheriff.updateSelection(1);
                                }
                                else
                                {
                                    HIDE_Sheriff.updateSelection(0);
                                }
                            }
                            else
                            {
                                HIDE_Sheriff.updateSelection(0);
                            }
                        }



                        if (BetterMapPL.getSelection() == 2) { HIDE_Map.updateSelection(1); }
                        else { HIDE_Map.updateSelection(0); }



                        if (engineerSpawnChance.getFloat() > 1 && engineerAdd.getBool() == true)
                        {
                            EngineerMin = 1f;
                            g_role_Engineer = "engineer,";
                        }
                        else
                        {
                            EngineerMin = 0f;
                            g_role_Engineer = "";
                        }





                        if (GuardianSpawnChance.getFloat() > 1 && GuardianAdd.getBool() == true)
                        {
                            GuardianMin = 1f;
                            g_role_Guardian = "guardian,";
                        }
                        else
                        {
                            GuardianMin = 0f;
                            g_role_Guardian = "";
                        }



                        if (MateSpawnChance.getFloat() > 1 && MateAdd.getBool() == true)
                        {
                            Team1Min = 1f;
                            Team2Min = 1f;
                            g_role_Teammate = "teammate,";
                        }
                        else
                        {
                            Team1Min = 0f;
                            Team2Min = 0f;
                            g_role_Teammate = "";
                        }





                        if (SherifAdd.getBool() == true && QTCrew.getFloat() != 0 && (SherifSpawnChance.getFloat() > 1 || Sherif2SpawnChance.getFloat() > 1 || Sherif3SpawnChance.getFloat() > 1))
                        {
                            g_role_Sheriff = "sheriff,";
                        }
                        else
                        {
                            g_role_Sheriff = "";
                        }



                        if (SherifSpawnChance.getFloat() > 1 && SherifAdd.getBool() == true)
                        {
                            SherifMin = 1f;

                        }
                        else
                        {
                            SherifMin = 0f;
                        }

                        if (SherifSpawnChance.getFloat() == 100 && SherifAdd.getBool() == true)
                        {
                            Sheriff1Max = 1f;
                        }
                        else
                        {
                            Sheriff1Max = 0f;
                        }



                        if (Sherif2SpawnChance.getFloat() > 1 && SherifAdd.getBool() == true)
                        {
                            Sherif2Min = 1f;
                        }
                        else
                        {
                            Sherif2Min = 0f;
                        }

                        if (Sherif2SpawnChance.getFloat() == 100 && SherifAdd.getBool() == true)
                        {
                            Sheriff2Max = 1f;
                        }
                        else
                        {
                            Sheriff2Max = 0f;
                        }



                        if (Sherif3SpawnChance.getFloat() > 1 && SherifAdd.getBool() == true)
                        {
                            Sherif3Min = 1f;
                        }
                        else
                        {
                            Sherif3Min = 0f;
                        }

                        if (Sherif3SpawnChance.getFloat() == 100 && SherifAdd.getBool() == true)
                        {
                            Sheriff3Max = 1f;
                        }
                        else
                        {
                            Sheriff3Max = 0f;
                        }



                        if (TimeLordSpawnChance.getFloat() > 1 && TimeLordAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            TimelordMin = 1f;
                            g_role_Timelord = "timelord,";
                        }
                        else
                        {
                            TimelordMin = 0f;
                            g_role_Timelord = "";
                        }





                        if (HunterSpawnChance.getFloat() > 1 && HunterAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            HunterMin = 1f;
                            g_role_Hunter = "hunter,";
                        }
                        else
                        {
                            HunterMin = 0f;
                            g_role_Hunter = "";
                        }



                        if (MysticSpawnChance.getFloat() > 1 && MysticAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            MysticMin = 1f;
                            g_role_Mystic = "mystic,";
                        }
                        else
                        {
                            MysticMin = 0f;
                            g_role_Mystic = "";
                        }



                        if (SpiritSpawnChance.getFloat() > 1 && SpiritAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            SpiritMin = 1f;
                            g_role_Spirit = "spirit,";
                        }
                        else
                        {
                            SpiritMin = 0f;
                            g_role_Spirit = "";
                        }


                        if (MentalistSpawnChance.getFloat() > 1 && MentalistAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            MentalistMin = 1f;
                            g_role_Mentalist = "mentalist,";
                        }
                        else
                        {
                            MentalistMin = 0f;
                            g_role_Mentalist = "";

                        }


                        if (MayorSpawnChance.getFloat() > 1 && MayorAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            MayorMin = 1f;
                            g_role_Mayor = "mayor,";
                        }
                        else
                        {
                            MayorMin = 0f;
                            g_role_Mayor = "";
                        }



                        if (DetectiveSpawnChance.getFloat() > 1 && DetectiveAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            DetectiveMin = 1f;
                            g_role_Detective = "detective,";
                        }
                        else
                        {
                            DetectiveMin = 0f;
                            g_role_Detective = "";
                        }



                        if (BuilderSpawnChance.getFloat() > 1 && BuilderAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            BuilderMin = 1f;
                            g_role_Builder = "builder,";
                        }
                        else
                        {
                            BuilderMin = 0f;
                            g_role_Builder = "";
                        }


                        if (FakeSpawnChance.getFloat() > 1 && FakeAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            FakeMin = 1f;
                            g_role_Fake = "fake,";
                        }
                        else
                        {
                            FakeMin = 0f;
                            g_role_Fake = "";
                        }

                        if (LeaderSpawnChance.getFloat() > 1 && LeaderAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            LeaderMin = 1f;
                            g_role_Leader = "leader,";
                        }
                        else
                        {
                            LeaderMin = 0f;
                            g_role_Leader = "";
                        }


                        if (NightwatcherSpawnChance.getFloat() > 1 && NightwatcherAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            NightwatcherMin = 1f;
                            g_role_Nightwatch = "nightwatch,";
                        }
                        else
                        {
                            NightwatcherMin = 0f;
                            g_role_Nightwatch = "";
                        }





                        if (SpySpawnChance.getFloat() > 1 && SpyAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            SpyMin = 1f;
                            g_role_Spy = "spy,";
                        }
                        else
                        {
                            SpyMin = 0f;
                            g_role_Spy = "";
                        }





                        if (InforSpawnChance.getFloat() > 1 && InforAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            InforMin = 1f;
                            g_role_Informant = "informant,";
                        }
                        else
                        {
                            InforMin = 0f;
                            g_role_Informant = "";
                        }





                        if (BaitSpawnChance.getFloat() > 1 && BaitAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            BaitMin = 1f;
                            g_role_Bait = "bait,";
                        }
                        else
                        {
                            BaitMin = 0f;
                            g_role_Bait = "";
                        }





                        if (JesterSpawnChance.getFloat() > 1 && JesterAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            JesterMin = 1f;
                            g_role_Jester = "jester,";
                        }
                        else
                        {
                            JesterMin = 0f;
                            g_role_Jester = "";
                        }


                        if (CursedSpawnChance.getFloat() > 1 && CursedAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            CursedMin = 1f;
                            g_role_Cursed = "cursed,";
                        }
                        else
                        {
                            CursedMin = 0f;
                            g_role_Cursed = "";
                        }





                        if (MercenarySpawnChance.getFloat() > 1 && MercenaryAdd.getBool() == true && QTDuo.getFloat() != 0)
                        {
                            MercenaryMin = 1f;
                            g_role_Mercenary = "mercenary,";
                        }
                        else
                        {
                            MercenaryMin = 0f;
                            g_role_Mercenary = "";
                        }



                        if (RevengerSpawnChance.getFloat() > 1 && RevengerAdd.getBool() == true && QTDuo.getFloat() != 0)
                        {
                            RevengerMin = 1f;
                            g_role_Revenger = "revenger,";
                        }
                        else
                        {
                            RevengerMin = 0f;
                            g_role_Revenger = "";
                        }




                        if (CopyCatSpawnChance.getFloat() > 1 && CopyCatAdd.getBool() == true && QTDuo.getFloat() != 0)
                        {
                            CopyCatMin = 1f;
                            g_role_CopyCat = "copycat,";
                        }
                        else
                        {
                            CopyCatMin = 0f;
                            g_role_CopyCat = "";
                        }



                        if (DictatorSpawnChance.getFloat() > 1 && DictatorAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            DictatorMin = 1f;
                            g_role_Dictator = "dictator,";
                        }
                        else
                        {
                            DictatorMin = 0f;
                            g_role_Dictator = "";
                        }



                        if (SentinelSpawnChance.getFloat() > 1 && SentinelAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            SentinelMin = 1f;
                            g_role_Sentinel = "sentinel,";
                        }
                        else
                        {
                            SentinelMin = 0f;
                            g_role_Sentinel = "";
                        }


                        if (LawkeeperSpawnChance.getFloat() > 1 && LawkeeperAdd.getBool() == true && QTCrew.getFloat() != 0)
                        {
                            LawkeeperMin = 1f;
                            g_role_Lawkeeper = "lawkeeper,";
                        }
                        else
                        {
                            LawkeeperMin = 0f;
                            g_role_Lawkeeper = "";
                        }




                        if (SorcererSpawnChance.getFloat() > 1 && SorcererAdd.getBool() == true && QTDuo.getFloat() != 0)
                        {
                            SorcererMin = 1f;
                            g_role_Sorcerer = "survivor,";
                        }
                        else
                        {
                            SorcererMin = 0f;
                            g_role_Sorcerer = "";
                        }



                        if (EaterSpawnChance.getFloat() > 1 && EaterAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            EaterMin = 1f;
                            g_role_Eater = "eater,";
                        }
                        else
                        {
                            EaterMin = 0f;
                            g_role_Eater = "";
                        }



                        if (CupidSpawnChance.getFloat() > 1 && CupidAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            CupidMin = 1f;
                            g_role_Cupid = "cupid,";
                        }
                        else
                        {
                            CupidMin = 0f;
                            g_role_Cupid = "";
                        }



                        if (CultisteSpawnChance.getFloat() > 1 && CultisteAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            CultisteMin = 1f;
                            g_role_Cultist = "cultist,";
                        }
                        else
                        {
                            CultisteMin = 0f;
                            g_role_Cultist = "";
                        }


                        if (OutlawSpawnChance.getFloat() > 1 && OutlawAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            OutlawMin = 1f;
                            g_role_Outlaw = "outlaw,";
                        }
                        else
                        {
                            OutlawMin = 0f;
                            g_role_Outlaw = "";
                        }

                        if (ArsonistSpawnChance.getFloat() > 1 && ArsonistAdd.getBool() == true && QTSpe.getFloat() != 0)
                        {
                            ArsonistMin = 1f;
                            g_role_Arsonist = "arsonist,";
                        }
                        else
                        {
                            ArsonistMin = 0f;
                            g_role_Arsonist = "";
                        }





                        if (AssassinSpawnChance.getFloat() > 1 && AssassinAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            AssassinMin = 1f;
                            g_role_Assassin = "assassin,";
                        }
                        else
                        {
                            AssassinMin = 0f;
                            g_role_Assassin = "";
                        }



                        if (VectorSpawnChance.getFloat() > 1 && VectorAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            VectorMin = 1f;
                            g_role_Vector = "vector,";
                        }
                        else
                        {
                            VectorMin = 0f;
                            g_role_Vector = "";
                        }




                        if (MorphlingSpawnChance.getFloat() > 1 && MorphlingAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            MorphMin = 1f;
                            g_role_Morphling = "morphling,";
                        }
                        else
                        {
                            MorphMin = 0f;
                            g_role_Morphling = "";
                        }




                        if (CamoSpawnChance.getFloat() > 1 && CamoAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            CamoMin = 1f;
                            g_role_Scrambler = "scrambler,";
                        }
                        else
                        {
                            CamoMin = 0f;
                            g_role_Scrambler = "";
                        }




                        if (BarghestSpawnChance.getFloat() > 1 && BarghestAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            BarghestMin = 1f;
                            g_role_Barghest = "barghest,";
                        }
                        else
                        {
                            BarghestMin = 0f;
                            g_role_Barghest = "";
                        }



                        if (GhostSpawnChance.getFloat() > 1 && GhostAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            GhostMin = 1f;
                            g_role_Ghost = "ghost,";
                        }
                        else
                        {
                            GhostMin = 0f;
                            g_role_Ghost = "";
                        }



                        if (WarSpawnChance.getFloat() > 1 && WarAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            Impo4Min = 1f;
                            g_role_Survivor = "sorcerer,";
                        }
                        else
                        {
                            Impo4Min = 0f;
                            g_role_Survivor = "";
                        }

                        if (GuesserSpawnChance.getFloat() > 1 && GuesserAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            GuesserMin = 1f;
                            g_role_Guesser = "guesser,";
                        }
                        else
                        {
                            GuesserMin = 0f;
                            g_role_Guesser = "";
                        }



                        if (BasiliskSpawnChance.getFloat() > 1 && BasiliskAdd.getBool() == true && QTImp.getFloat() != 0)
                        {
                            BasiliskMin = 1f;
                            g_role_Basilisk = "basilisk,";
                        }
                        else
                        {
                            BasiliskMin = 0f;
                            g_role_Basilisk = "";
                        }


                        g_role_All = g_role_Sheriff + g_role_Guardian + g_role_Engineer + g_role_Timelord + g_role_Hunter + g_role_Mystic + g_role_Spirit + g_role_Mayor + g_role_Detective + g_role_Nightwatch + g_role_Spy + g_role_Informant
                             + g_role_Bait + g_role_Mentalist + g_role_Builder + g_role_Dictator + g_role_Sentinel + g_role_Teammate + g_role_Lawkeeper + g_role_Fake + g_role_Doctor + g_role_Leader + g_role_Slave + g_role_Traveler
                             + g_role_Assassin + g_role_Vector + g_role_Morphling + g_role_Scrambler + g_role_Barghest + g_role_Ghost + g_role_Sorcerer + g_role_Guesser + g_role_Basilisk + g_role_Mesmer + g_role_Saboteur + g_role_Reaper
                             + g_role_Survivor + g_role_Mercenary + g_role_CopyCat + g_role_Revenger + g_role_Jester + g_role_Outlaw + g_role_Eater + g_role_Arsonist + g_role_Cultist + g_role_Cupid + g_role_Cursed;





                        if (Eatvalueforwin.getSelection() == 0)
                        {
                            Eatervaluewin = 1f;
                        }
                        if (Eatvalueforwin.getSelection() == 1)
                        {
                            Eatervaluewin = 2f;
                        }
                        if (Eatvalueforwin.getSelection() == 2)
                        {
                            Eatervaluewin = 3f;
                        }
                        if (Eatvalueforwin.getSelection() == 3)
                        {
                            Eatervaluewin = 4f;
                        }
                        if (Eatvalueforwin.getSelection() == 4)
                        {
                            Eatervaluewin = 5f;
                        }

                        if (ChallengerMod.Challenger.IsrankedGame)
                        {
                            string Player = GameStartManager.Instance.LastPlayerCount + "";
                            string MaxPlayer = PlayerControl.GameOptions.MaxPlayers + "";
                            if (GameStartManager.Instance.LastPlayerCount != PlayerControl.GameOptions.MaxPlayers)
                            {
                                GameStartManager.Instance.PlayerCounter.SetText("<color=#ff0000>" + Player + "/" + MaxPlayer + "</color>");
                            }
                            else
                            {
                                GameStartManager.Instance.PlayerCounter.SetText("<color=#00ff00>" + Player + "/" + MaxPlayer + "</color>");
                            }

                        }

                        //KICK SERVICE
                        if (ChallengerMod.Challenger.IsrankedGame == false && Ranked.getBool() == false)
                        {

                        }
                        else if (ChallengerMod.Challenger.IsrankedGame == true && Ranked.getBool() == true)
                        {

                        }
                        else if (ChallengerMod.Challenger.IsrankedGame == true && Ranked.getBool() == false)
                        {
                            SceneChanger.ChangeScene("MainMenu");
                            AmongUsClient.Instance.DisconnectInternal(DisconnectReasons.ServerRequest);
                        }
                        else if (ChallengerMod.Challenger.IsrankedGame == false && Ranked.getBool() == true)
                        {
                            SceneChanger.ChangeScene("MainMenu");
                            AmongUsClient.Instance.DisconnectInternal(DisconnectReasons.ServerRequest);
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}
