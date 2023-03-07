using HarmonyLib;
using Hazel;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.Challenger;
using ChallengerMod.RPC;
using ChallengerOS.Utils;
using ChallengerOS.Objects;

namespace ChallengerMod
{




    [HarmonyPatch]





    public static class GameEvent
    {
        //SetTask

            public static void SurvDrone(bool flag)
        {
            if (flag)
            {
                
                if (PlayerControl.GameOptions.MapId == 1 && ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() == 1) //Mirah
                {
                    ChallengerMod.Utility.Utils.SpriteAnimUtils.StartDrone0(Unity.Drone0Anim, new Vector3(0f,0f,0f), 5f, 3f);
                    ChallengerMod.Utility.Utils.SpriteAnimUtils.StartDrone1(Unity.Drone1Anim, new Vector3(0f, 0f, 0f), 5f, 3f);
                    DroneAnimGen = true;
                }
                else { DroneAnimGen = true; }
                
            }
        }
        public static void SetSurvDrone(bool flag)
        {
            if (flag)
            {
                
                if (GameObject.Find("Drone_SurvCamera")) //Mirah
                {
                    GameObject SurvDrone = GameObject.Find("Drone_SurvCamera");

                    if (GameObject.Find("_SurvDronAnimOff") && !DroneAnimP1) 
                    {
                        GameObject Anim0 = GameObject.Find("_SurvDronAnimOff");
                        Anim0.transform.parent = SurvDrone.transform;
                        DroneAnimP1 = true;
                    }
                    if (GameObject.Find("_SurvDronAnimOn") && !DroneAnimP2) 
                    {
                        GameObject Anim1 = GameObject.Find("_SurvDronAnimOn");
                        Anim1.transform.parent = SurvDrone.transform;
                        DroneAnimP1 = true;
                    }
                }
                if (DroneAnimP1 && DroneAnimP2) { DroneAnimGen2 = true; }
                


            }
        }
        public static void ResetDroneController(bool flag)
        {
            if (flag)
            {
                Challenger.DroneController = null;
            }
        }
        public static void ChangeVentSprite(bool flag)
        {
            if (flag)
            {
                if (PlayerControl.GameOptions.MapId == 0) //Skeld
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
                if (PlayerControl.GameOptions.MapId == 1) //Mirah
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
                if (PlayerControl.GameOptions.MapId == 4) //Airship
                {

                    foreach (Vent vent in ShipStatus.Instance.AllVents)
                    {
                        PowerTools.SpriteAnim animator = vent.GetComponent<PowerTools.SpriteAnim>();
                        animator?.Stop();
                        vent.EnterVentAnim = vent.ExitVentAnim = null;
                        vent.myRend.sprite = NewVent;
                        vent.myRend.color = Color.white;
                    }
                    VentSpriteEdited = true;
                }
            }
        }


        public static void BaitBaliseEnable(bool flag)
        {
            if (flag)
            {
                if (Balise.balise.Count() != 0 && Bait.Role != null)
                {
                    foreach (Balise balise in Balise.balise)
                    {
                        SpriteRenderer Bs = balise.background.GetComponent<SpriteRenderer>();

                        if (Bait.BaliseEnable)
                        {
                            Bs.sprite = BaitBaliseArea;
                            Bait.BaliseData = false;
                        }
                        else
                        {
                            if ((Bait.Role != null && PlayerControl.LocalPlayer == Bait.Role)
                                || (CopyCat.Role != null && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 13 && CopyCat.CopyStart == true)
                                || (PlayerControl.LocalPlayer.Data.IsDead)
                                )
                            {
                                Bs.sprite = BaitBaliseArea0;
                                Bait.BaliseData = false;
                            }
                            else { Bait.BaliseData = false; }

                        }
                    }
                }
                
            }
        }

        public static void ResetSpritesIfPlayerDie(bool flag)
        {
            if (flag)
            {
                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {

                    player.setDefaultLook();

                    if (!player.Data.IsDead)
                    {
                        player.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                    }


                    Challenger.ResetAllPlayersSkin = true;


                }
            }
        }
        public static void AssignSheriff1Task(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Sheriff1.Role != null && PlayerControl.LocalPlayer == Sheriff1.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SheriffColor + "(" + Role_Sheriff + ")" + " : " + CC + Task_Role_Sheriff + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;

                    }

                }
            }
        }
        public static void AssignSheriff2Task(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Sheriff2.Role != null && PlayerControl.LocalPlayer == Sheriff2.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SheriffColor + "(" + Role_Sheriff + ")" + " : " + CC + Task_Role_Sheriff + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }

                }
            }
        }
        public static void AssignSheriff3Task(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Sheriff3.Role != null && PlayerControl.LocalPlayer == Sheriff3.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SheriffColor + "(" + Role_Sheriff + ")" + " : " + CC + Task_Role_Sheriff + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }

                }
            }
        }
        public static void AssignGuardianTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Guardian.Role != null && PlayerControl.LocalPlayer == Guardian.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_GuardianColor + "(" + Role_Guardian + ")" + " : " + CC + Task_Role_Guardian + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }

                }
            }
        }
        public static void AssignEngineerTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Engineer.Role != null && PlayerControl.LocalPlayer == Engineer.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_EngineerColor + "(" + Role_Engineer + ")" + " : " + CC + Task_Role_Engineer + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignTimelordTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Timelord.Role != null && PlayerControl.LocalPlayer == Timelord.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_TimelordColor + "(" + Role_Timelord + ")" + " : " + CC + Task_Role_Timelord + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignHunterTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Hunter.Role != null && PlayerControl.LocalPlayer == Hunter.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_HunterColor + "(" + Role_Hunter + ")" + " : " + CC + Task_Role_Hunter + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMysticTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Mystic.Role != null && PlayerControl.LocalPlayer == Mystic.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MysticColor + "(" + Role_Mystic + ")" + " : " + CC + Task_Role_Mystic + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSpiritTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Spirit.Role != null && PlayerControl.LocalPlayer == Spirit.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SpiritColor + "(" + Role_Spirit + ")" + " : " + CC + Task_Role_Spirit + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMayorTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Mayor.Role != null && PlayerControl.LocalPlayer == Mayor.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MayorColor + "(" + Role_Mayor + ")" + " : " + CC + Task_Role_Mayor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignDetectiveTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Detective.Role != null && PlayerControl.LocalPlayer == Detective.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DetectiveColor + "(" + Role_Detective + ")" + " : " + CC + Task_Role_Detective + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignNightwatchTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Nightwatch.Role != null && PlayerControl.LocalPlayer == Nightwatch.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_NightwatchColor + "(" + Role_Nightwatch + ")" + " : " + CC + Task_Role_Nightwatch + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSpyTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Spy.Role != null && PlayerControl.LocalPlayer == Spy.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SpyColor + "(" + Role_Spy + ")" + " : " + CC + Task_Role_Spy + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignInformantTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Informant.Role != null && PlayerControl.LocalPlayer == Informant.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_InformantColor + "(" + Role_Informant + ")" + " : " + CC + Task_Role_Informant + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignBaitTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Bait.Role != null && PlayerControl.LocalPlayer == Bait.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BaitColor + "(" + Role_Bait + ")" + " : " + CC + Task_Role_Bait + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMentalistTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Mentalist.Role != null && PlayerControl.LocalPlayer == Mentalist.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MentalistColor + "(" + Role_Mentalist + ")" + " : " + CC + Task_Role_Mentalist + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignBuilderTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Builder.Role != null && PlayerControl.LocalPlayer == Builder.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BuilderColor + "(" + Role_Builder + ")" + " : " + CC + Task_Role_Builder + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignDictatorTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Dictator.Role != null && PlayerControl.LocalPlayer == Dictator.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DictatorColor + "(" + Role_Dictator + ")" + " : " + CC + Task_Role_Dictator + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSentinelTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Sentinel.Role != null && PlayerControl.LocalPlayer == Sentinel.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SentinelColor + "(" + Role_Sentinel + ")" + " : " + CC + Task_Role_Sentinel + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignTeammate1Task(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Teammate1.Role != null && Teammate2.Role != null && PlayerControl.LocalPlayer == Teammate1.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CrewmateColor + "(" + Role_Teammate + ")" + " : " + CC + R_CrewmateColor + Teammate1.Role.Data.PlayerName + " & " + Teammate2.Role.Data.PlayerName + " !" + CC + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignTeammate2Task(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Teammate1.Role != null && Teammate2.Role != null && PlayerControl.LocalPlayer == Teammate2.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CrewmateColor + "(" + Role_Teammate + ")" + " : " + CC + R_CrewmateColor + Teammate2.Role.Data.PlayerName + " & " + Teammate1.Role.Data.PlayerName + " !" + CC + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignLawkeeperTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Lawkeeper.Role != null && PlayerControl.LocalPlayer == Lawkeeper.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_LawkeeperColor + "(" + Role_Lawkeeper + ")" + " : " + CC + Task_Role_Lawkeeper + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignFakeTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Fake.Role != null && PlayerControl.LocalPlayer == Fake.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_FakeColor + "(" + Role_Fake + ")" + " : " + CC + Task_Role_Fake + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignTravelerTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Traveler.Role != null && PlayerControl.LocalPlayer == Traveler.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_TravelerColor + "(" + Role_Traveler + ")" + " : " + CC + Task_Role_Traveler + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignLeaderTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Leader.Role != null && PlayerControl.LocalPlayer == Leader.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_LeaderColor + "(" + Role_Leader + ")" + " : " + CC + Task_Role_Leader + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignDoctorTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Doctor.Role != null && PlayerControl.LocalPlayer == Doctor.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DoctorColor + "(" + Role_Doctor + ")" + " : " + CC + Task_Role_Doctor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }

                }
            }
        }
        public static void AssignSlaveTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Slave.Role != null && Slave.Master != null && PlayerControl.LocalPlayer == Slave.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SlaveColor + "(" + Role_Slave + ")" + " : " + CC + Task_Role_Slave + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignJesterTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Jester.Role != null && PlayerControl.LocalPlayer == Jester.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_JesterColor + "(" + Role_Jester + ")" + " : " + CC + Task_Role_Jester + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignEaterTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Eater.Role != null && PlayerControl.LocalPlayer == Eater.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_EaterColor + "(" + Role_Eater + ")" + " : " + CC + Task_Role_Eater + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignOutlawTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Outlaw.Role != null && PlayerControl.LocalPlayer == Outlaw.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_OutlawColor + "(" + Role_Outlaw + ")" + " : " + CC + Task_Role_Outlaw + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignArsonistTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Arsonist.Role != null && PlayerControl.LocalPlayer == Arsonist.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_ArsonistColor + "(" + Role_Arsonist + ")" + " : " + CC + Task_Role_Arsonist + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignCursedTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Cursed.Role != null && PlayerControl.LocalPlayer == Cursed.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CursedColor + "(" + Role_Cursed + ")" + " : " + CC + Task_Role_Cursed + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignCultistTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Cultist.Role != null && PlayerControl.LocalPlayer == Cultist.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CulteColor + "(" + Role_Cultist + ")" + " : " + CC + Task_Role_Cultist + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignCupidTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Cupid.Role != null && PlayerControl.LocalPlayer == Cupid.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CupidColor + "(" + Role_Cupid + ")" + " : " + CC + Task_Role_Cupid + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMercenaryTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Mercenary.Role != null && PlayerControl.LocalPlayer == Mercenary.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MercenaryColor + "(" + Role_Mercenary + ")" + " : " + CC + Task_Role_Mercenary + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignCopyCatTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (CopyCat.Role != null && PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CopyCatColor + "(" + Role_CopyCat + ")" + " : " + CC + Task_Role_CopyCat + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignRevengerTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Revenger.Role != null && PlayerControl.LocalPlayer == Revenger.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_RevengerColor + "(" + Role_Revenger + ")" + " : " + CC + Task_Role_Revenger + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSurvivorTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Survivor.Role != null && PlayerControl.LocalPlayer == Survivor.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SurvivorColor + "(" + Role_Survivor + ")" + " : " + CC + Task_Role_Survivor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignAssassinTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Assassin.Role != null && PlayerControl.LocalPlayer == Assassin.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_AssassinColor + "(" + Role_Assassin + ")" + " : " + CC + Task_Role_Assassin + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignVectorTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Vector.Role != null && PlayerControl.LocalPlayer == Vector.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_VectorColor + "(" + Role_Vector + ")" + " : " + CC + Task_Role_Vector + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMorphlingTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Morphling.Role != null && PlayerControl.LocalPlayer == Morphling.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MorphlingColor + "(" + Role_Morphling + ")" + " : " + CC + Task_Role_Morphling + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignScramblerTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Scrambler.Role != null && PlayerControl.LocalPlayer == Scrambler.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_ScramblerColor + "(" + Role_Scrambler + ")" + " : " + CC + Task_Role_Scrambler + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignBarghestTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Barghest.Role != null && PlayerControl.LocalPlayer == Barghest.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BarghestColor + "(" + Role_Barghest + ")" + " : " + CC + Task_Role_Barghest + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignGhostTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Ghost.Role != null && PlayerControl.LocalPlayer == Ghost.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_GhostColor + "(" + Role_Ghost + ")" + " : " + CC + Task_Role_Ghost + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSorcererTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Sorcerer.Role != null && PlayerControl.LocalPlayer == Sorcerer.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SorcererColor + "(" + Role_Sorcerer + ")" + " : " + CC + Task_Role_Sorcerer + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                        ChallengerMod.Utility.Utils.SpriteAnimUtils.StartCircle(Unity.CircleAnim, Challenger.CirclePosition, 5f, 3f);
                    }
                }
            }
        }
        public static void AssignGuesserTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Guesser.Role != null && PlayerControl.LocalPlayer == Guesser.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_GuesserColor + "(" + Role_Guesser + ")" + " : " + CC + Task_Role_Guesser + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignMesmerTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Mesmer.Role != null && PlayerControl.LocalPlayer == Mesmer.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MesmerColor + "(" + Role_Mesmer + ")" + " : " + CC + Task_Role_Mesmer + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignBasiliskTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Basilisk.Role != null && PlayerControl.LocalPlayer == Basilisk.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BasiliskColor + "(" + Role_Basilisk + ")" + " : " + CC + Task_Role_Basilisk + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignReaperTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Reaper.Role != null && PlayerControl.LocalPlayer == Reaper.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_ReaperColor + "(" + Role_Reaper + ")" + " : " + CC + Task_Role_Reaper + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignSaboteurTask(bool flag)
        {
            if (flag)
            {

                if (!RoleTaskAssigned)
                {
                    if (Saboteur.Role != null && PlayerControl.LocalPlayer == Saboteur.Role)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SaboteurColor + "(" + Role_Saboteur + ")" + " : " + CC + Task_Role_Saboteur + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        RoleTaskAssigned = true;
                    }
                }
            }
        }





        public static void AssignCulte1Task(bool flag)
        {
            if (flag)
            {
                if (!CulteTaskAssigned)
                {
                    if (Cultist.Role != null && Cultist.Culte1 != null && PlayerControl.LocalPlayer == Cultist.Culte1)
                    {

                        ImportantTextTask CulteTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        CulteTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        CulteTask.Text = R_CulteColor + "(" + Role_CulteMember + B_Culte_Alive + ")" + " : " + CC + Task_Role_Culte + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, CulteTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(200f / 255f, 50f / 255f, 215f / 255f));
                        CulteTaskAssigned = true;
                        SoundManager.Instance.PlaySound(shieldClip, false, 100f);
                    }
                }
            }
        }
        public static void AssignCulte2Task(bool flag)
        {
            if (flag)
            {
                if (!CulteTaskAssigned)
                {
                    if (Cultist.Role != null && Cultist.Culte2 != null && PlayerControl.LocalPlayer == Cultist.Culte2)
                    {

                        ImportantTextTask CulteTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        CulteTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        CulteTask.Text = R_CulteColor + "(" + Role_CulteMember + B_Culte_Alive + ")" + " : " + CC + Task_Role_Culte + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, CulteTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(200f / 255f, 50f / 255f, 215f / 255f));
                        CulteTaskAssigned = true;
                        SoundManager.Instance.PlaySound(shieldClip, false, 100f);
                    }
                }
            }
        }
        public static void AssignCulte3Task(bool flag)
        {
            if (flag)
            {
                if (!CulteTaskAssigned)
                {
                    if (Cultist.Role != null && Cultist.Culte3 != null && PlayerControl.LocalPlayer == Cultist.Culte3)
                    {

                        ImportantTextTask CulteTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        CulteTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        CulteTask.Text = R_CulteColor + "(" + Role_CulteMember + B_Culte_Alive + ")" + " : " + CC + Task_Role_Culte + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, CulteTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(200f / 255f, 50f / 255f, 215f / 255f));
                        CulteTaskAssigned = true;
                        SoundManager.Instance.PlaySound(shieldClip, false, 100f);
                    }
                }
            }
        }


        public static void AssignLove0Task(bool flag)
        {
            if (flag)
            {
                if (!loveTaskAssigned)
                {
                    if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && PlayerControl.LocalPlayer == Cupid.Role)
                    {
                        ImportantTextTask LoveTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        LoveTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        LoveTask.Text = R_CupidColor + "(" + Role_Lover + B_Lover_Alive + ")" + " : " + CC + Cupid.Lover1.Data.PlayerName + " & " + Cupid.Lover2.Data.PlayerName + " !" + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, LoveTask);
                        loveTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignLove1Task(bool flag)
        {
            if (flag)
            {
                if (!loveTaskAssigned)
                {
                    if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && PlayerControl.LocalPlayer == Cupid.Lover1)
                    {
                        ImportantTextTask LoveTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        LoveTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        LoveTask.Text = R_CupidColor + "(" + Role_Lover + B_Lover_Alive + ")" + " : " + CC + Cupid.Lover1.Data.PlayerName + " & " + Cupid.Lover2.Data.PlayerName + " !" + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, LoveTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 200f / 255f, 255f / 255f));
                        SoundManager.Instance.PlaySound(PoisonClip, false, 100f);
                        loveTaskAssigned = true;
                    }
                }
            }
        }
        public static void AssignLove2Task(bool flag)
        {
            if (flag)
            {
                if (!loveTaskAssigned)
                {
                    if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && PlayerControl.LocalPlayer == Cupid.Lover2)
                    {
                        ImportantTextTask LoveTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        LoveTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        LoveTask.Text = R_CupidColor + "(" + Role_Lover + B_Lover_Alive + ")" + " : " + CC + Cupid.Lover1.Data.PlayerName + " & " + Cupid.Lover2.Data.PlayerName + " !" + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, LoveTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 200f / 255f, 255f / 255f));
                        SoundManager.Instance.PlaySound(PoisonClip, false, 100f);
                        loveTaskAssigned = true;
                    }
                }
            }
        }

        public static void AssignMasterTask(bool flag)
        {
            if (flag)
            {
                if (!MasterTaskAssigned)
                {
                    if (Slave.Role != null && Slave.Master != null && PlayerControl.LocalPlayer == Slave.Master)
                    {
                        ImportantTextTask MasterTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        MasterTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        MasterTask.Text = R_SlaveColor + "(" + Role_Master + B_Master_Alive + ")" + " : " + CC + Task_Role_Master + "\n" + R_SlaveColor + "(" + Role_Slave + B_Slave_On + ")" + " : " + CC + Slave.Role.Data.PlayerName + " !" + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, MasterTask);
                        MasterTaskAssigned = true;
                    }
                }
            }
        }
        public static void TheOutlawCanKill(bool flag)
        {
            if (flag)
            {
                if (!OutlawCanKill)
                {
                    if (Outlaw.Role != null && PlayerControl.LocalPlayer == Outlaw.Role)
                    {
                        ChallengerOS.Utils.Helpers.showFlash(new Color(0f / 255f, 0f / 255f, 255f / 255f, 2f));
                        SoundManager.Instance.PlaySound(PoisonClip, false, 100f);
                        OutlawCanKill = true;
                    }
                }
            }
        }
        public static void AssignCopyTask(bool flag)
        {
            if (flag)
            {
                if (!CopyTaskAssigned)
                {
                    //Crewmate
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 24)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_CrewmateColor + "(" + Role_Crewmate + ")" + " : " + CC + Task_Role_Crewmate + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(180f / 255f, 250f / 255f, 250f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Impostor
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 25)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_ImpostorColor + "(" + Role_Impostor + ")" + " : " + CC + Task_Role_Impostor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 5f / 255f, 5f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Sheriff
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 1)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SheriffColor + "(" + Role_Sheriff + ")" + " : " + CC + Task_Role_Sheriff + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 0f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Guardian
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 2)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_GuardianColor + "(" + Role_Guardian + ")" + " : " + CC + Task_Role_Guardian + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Engineer
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 3)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_EngineerColor + "(" + Role_Engineer + ")" + " : " + CC + Task_Role_Engineer + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 161f / 255f, 0f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Timelord
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 4)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_TimelordColor + "(" + Role_Timelord + ")" + " : " + CC + Task_Role_Timelord + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(0f / 255f, 127f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Hunter
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 5)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_HunterColor + "(" + Role_Hunter + ")" + " : " + CC + Task_Role_Hunter + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(0f / 255f, 255f / 255f, 0f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Mystic
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 6)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MysticColor + "(" + Role_Mystic + ")" + " : " + CC + Task_Role_Mystic + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(249f / 255f, 255f / 255f, 178f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Spirit
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 7)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SpiritColor + "(" + Role_Spirit + ")" + " : " + CC + Task_Role_Spirit + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(161f / 255f, 255f / 255f, 0f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Mayor
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 8)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MayorColor + "(" + Role_Mayor + ")" + " : " + CC + Task_Role_Mayor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(175f / 255f, 130f / 255f, 105f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Detective
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 9)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DetectiveColor + "(" + Role_Detective + ")" + " : " + CC + Task_Role_Detective + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(188f / 255f, 255f / 255f, 186f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Nightwatch
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 10)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_NightwatchColor + "(" + Role_Nightwatch + ")" + " : " + CC + Task_Role_Nightwatch + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(158f / 255f, 179f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Spy
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 11)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SpyColor + "(" + Role_Spy + ")" + " : " + CC + Task_Role_Spy + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(158f / 255f, 225f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Informant
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 12)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_InformantColor + "(" + Role_Informant + ")" + " : " + CC + Task_Role_Informant + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(173f / 255f, 255 / 255f, 234f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Bait
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 13)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BaitColor + "(" + Role_Bait + ")" + " : " + CC + Task_Role_Bait + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(128f / 255f, 128f / 255f, 128f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Mentalist
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 14)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_MentalistColor + "(" + Role_Mentalist + ")" + " : " + CC + Task_Role_Mentalist + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(169f / 255f, 145f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Builder
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 15)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_BuilderColor + "(" + Role_Builder + ")" + " : " + CC + Task_Role_Builder + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 194f / 255f, 145f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Dictator
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 16)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DictatorColor + "(" + Role_Dictator + ")" + " : " + CC + Task_Role_Dictator + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 77f / 255f, 53f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Sentinel
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 17)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_SentinelColor + "(" + Role_Sentinel + ")" + " : " + CC + Task_Role_Sentinel + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(6f / 255f, 173f / 255f, 23f / 255f));
                        CopyTaskAssigned = true;
                    }

                    //Lawkeeper
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 18)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_LawkeeperColor + "(" + Role_Lawkeeper + ")" + " : " + CC + Task_Role_Lawkeeper + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(255 / 255f, 155f / 255f, 155f / 255f));
                        CopyTaskAssigned = true;
                    }

                    //Traveler
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 19)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_TravelerColor + "(" + Role_Traveler + ")" + " : " + CC + Task_Role_Traveler + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(109f / 255f, 138f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Leader
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 20)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_LeaderColor + "(" + Role_Leader + ")" + " : " + CC + Task_Role_Leader + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(209f / 255f, 237f / 255f, 255f / 255f));
                        CopyTaskAssigned = true;
                    }
                    //Doctor
                    if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.copyRole == 21)
                    {
                        ImportantTextTask RoleTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                        RoleTask.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                        RoleTask.Text = R_DoctorColor + "(" + Role_Doctor + ")" + " : " + CC + Task_Role_Doctor + "\n";
                        PlayerControl.LocalPlayer.myTasks.Insert(0, RoleTask);
                        ChallengerOS.Utils.Helpers.showFlash(new Color(25f / 255f, 255f / 255f, 186f / 255f));
                        CopyTaskAssigned = true;
                    }
                }
            }
        }



        public static void SendToGoodlossServices(bool flag)
        {
            if (flag)
            {

                if (!SendtoGoodloss)
                {

                    GLMod.GLMod.step = 0;
                    GLMod.GLMod.StartGame("******", STRMap, isRankedGame);


                    if (Crewmate1.Role != null) { GLMod.GLMod.AddPlayer(Crewmate1.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate2.Role != null) { GLMod.GLMod.AddPlayer(Crewmate2.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate3.Role != null) { GLMod.GLMod.AddPlayer(Crewmate3.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate4.Role != null) { GLMod.GLMod.AddPlayer(Crewmate4.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate5.Role != null) { GLMod.GLMod.AddPlayer(Crewmate5.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate6.Role != null) { GLMod.GLMod.AddPlayer(Crewmate6.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate7.Role != null) { GLMod.GLMod.AddPlayer(Crewmate7.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate8.Role != null) { GLMod.GLMod.AddPlayer(Crewmate8.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate9.Role != null) { GLMod.GLMod.AddPlayer(Crewmate9.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate10.Role != null) { GLMod.GLMod.AddPlayer(Crewmate10.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate11.Role != null) { GLMod.GLMod.AddPlayer(Crewmate11.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate12.Role != null) { GLMod.GLMod.AddPlayer(Crewmate12.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate13.Role != null) { GLMod.GLMod.AddPlayer(Crewmate13.Role.Data.PlayerName, "Crewmate", "Crewmate"); }
                    if (Crewmate14.Role != null) { GLMod.GLMod.AddPlayer(Crewmate14.Role.Data.PlayerName, "Crewmate", "Crewmate"); }

                    if (Sheriff1.Role != null) { GLMod.GLMod.AddPlayer(Sheriff1.Role.Data.PlayerName, "Sheriff", "Crewmate"); }
                    if (Sheriff2.Role != null) { GLMod.GLMod.AddPlayer(Sheriff2.Role.Data.PlayerName, "Sheriff", "Crewmate"); }
                    if (Sheriff3.Role != null) { GLMod.GLMod.AddPlayer(Sheriff3.Role.Data.PlayerName, "Sheriff", "Crewmate"); }
                    if (Guardian.Role != null) { GLMod.GLMod.AddPlayer(Guardian.Role.Data.PlayerName, "Guardian", "Crewmate"); }
                    if (Engineer.Role != null) { GLMod.GLMod.AddPlayer(Engineer.Role.Data.PlayerName, "Engineer", "Crewmate"); }
                    if (Timelord.Role != null) { GLMod.GLMod.AddPlayer(Timelord.Role.Data.PlayerName, "Timelord", "Crewmate"); }
                    if (Hunter.Role != null) { GLMod.GLMod.AddPlayer(Hunter.Role.Data.PlayerName, "Hunter", "Crewmate"); }
                    if (Mystic.Role != null) { GLMod.GLMod.AddPlayer(Mystic.Role.Data.PlayerName, "Mystic", "Crewmate"); }
                    if (Spirit.Role != null) { GLMod.GLMod.AddPlayer(Spirit.Role.Data.PlayerName, "Spirit", "Crewmate"); }
                    if (Mayor.Role != null) { GLMod.GLMod.AddPlayer(Mayor.Role.Data.PlayerName, "Mayor", "Crewmate"); }
                    if (Detective.Role != null) { GLMod.GLMod.AddPlayer(Detective.Role.Data.PlayerName, "Detective", "Crewmate"); }
                    if (Nightwatch.Role != null) { GLMod.GLMod.AddPlayer(Nightwatch.Role.Data.PlayerName, "Nightwatch", "Crewmate"); }
                    if (Spy.Role != null) { GLMod.GLMod.AddPlayer(Spy.Role.Data.PlayerName, "Spy", "Crewmate"); }
                    if (Informant.Role != null) { GLMod.GLMod.AddPlayer(Informant.Role.Data.PlayerName, "Informant", "Crewmate"); }
                    if (Bait.Role != null) { GLMod.GLMod.AddPlayer(Bait.Role.Data.PlayerName, "Bait", "Crewmate"); }
                    if (Mentalist.Role != null) { GLMod.GLMod.AddPlayer(Mentalist.Role.Data.PlayerName, "Mentalist", "Crewmate"); }
                    if (Builder.Role != null) { GLMod.GLMod.AddPlayer(Builder.Role.Data.PlayerName, "Builder", "Crewmate"); }
                    if (Dictator.Role != null) { GLMod.GLMod.AddPlayer(Dictator.Role.Data.PlayerName, "Dictator", "Crewmate"); }
                    if (Sentinel.Role != null) { GLMod.GLMod.AddPlayer(Sentinel.Role.Data.PlayerName, "Sentinel", "Crewmate"); }
                    if (Teammate1.Role != null) { GLMod.GLMod.AddPlayer(Teammate1.Role.Data.PlayerName, "Teammate", "Crewmate"); }
                    if (Teammate2.Role != null) { GLMod.GLMod.AddPlayer(Teammate2.Role.Data.PlayerName, "Teammate", "Crewmate"); }
                    if (Lawkeeper.Role != null) { GLMod.GLMod.AddPlayer(Lawkeeper.Role.Data.PlayerName, "Lawkeeper", "Crewmate"); }
                    if (Fake.Role != null) { GLMod.GLMod.AddPlayer(Fake.Role.Data.PlayerName, "Fake", "Crewmate"); }
                    if (Traveler.Role != null) { GLMod.GLMod.AddPlayer(Traveler.Role.Data.PlayerName, "Traveler", "Crewmate"); }
                    if (Leader.Role != null) { GLMod.GLMod.AddPlayer(Leader.Role.Data.PlayerName, "Leader", "Crewmate"); }
                    if (Doctor.Role != null) { GLMod.GLMod.AddPlayer(Doctor.Role.Data.PlayerName, "Doctor", "Crewmate"); }
                    if (Slave.Role != null) { GLMod.GLMod.AddPlayer(Slave.Role.Data.PlayerName, "Slave", "Crewmate"); }

                    if (Mercenary.Role != null) { GLMod.GLMod.AddPlayer(Mercenary.Role.Data.PlayerName, "Mercenary", "Neutral"); }
                    if (CopyCat.Role != null) { GLMod.GLMod.AddPlayer(CopyCat.Role.Data.PlayerName, "CopyCat", "Neutral"); }
                    if (Survivor.Role != null) { GLMod.GLMod.AddPlayer(Survivor.Role.Data.PlayerName, "Survivor", "Neutral"); }
                    if (Revenger.Role != null) { GLMod.GLMod.AddPlayer(Revenger.Role.Data.PlayerName, "Revenger", "Neutral"); }

                    if (Cupid.Role != null) { GLMod.GLMod.AddPlayer(Cupid.Role.Data.PlayerName, "Cupid", "Lover"); }
                    if (Cultist.Role != null) { GLMod.GLMod.AddPlayer(Cultist.Role.Data.PlayerName, "Cultist", "Culte"); }
                    if (Outlaw.Role != null) { GLMod.GLMod.AddPlayer(Outlaw.Role.Data.PlayerName, "Outlaw", "Outlaw"); }
                    if (Jester.Role != null) { GLMod.GLMod.AddPlayer(Jester.Role.Data.PlayerName, "Jester", "Jester"); }
                    if (Eater.Role != null) { GLMod.GLMod.AddPlayer(Eater.Role.Data.PlayerName, "Eater", "Eater"); }
                    if (Arsonist.Role != null) { GLMod.GLMod.AddPlayer(Arsonist.Role.Data.PlayerName, "Arsonist", "Arsonist"); }
                    if (Cursed.Role != null) { GLMod.GLMod.AddPlayer(Cursed.Role.Data.PlayerName, "Cursed", "Cursed"); }

                    if (Assassin.Role != null) { GLMod.GLMod.AddPlayer(Assassin.Role.Data.PlayerName, "Assassin", "Impostor"); }
                    if (Vector.Role != null) { GLMod.GLMod.AddPlayer(Vector.Role.Data.PlayerName, "Vector", "Impostor"); }
                    if (Morphling.Role != null) { GLMod.GLMod.AddPlayer(Morphling.Role.Data.PlayerName, "Morphling", "Impostor"); }
                    if (Scrambler.Role != null) { GLMod.GLMod.AddPlayer(Scrambler.Role.Data.PlayerName, "Scrambler", "Impostor"); }
                    if (Barghest.Role != null) { GLMod.GLMod.AddPlayer(Barghest.Role.Data.PlayerName, "Barghest", "Impostor"); }
                    if (Ghost.Role != null) { GLMod.GLMod.AddPlayer(Ghost.Role.Data.PlayerName, "Ghost", "Impostor"); }
                    if (Sorcerer.Role != null) { GLMod.GLMod.AddPlayer(Sorcerer.Role.Data.PlayerName, "Sorcerer", "Impostor"); }
                    if (Guesser.Role != null) { GLMod.GLMod.AddPlayer(Guesser.Role.Data.PlayerName, "Guesser", "Impostor"); }
                    if (Mesmer.Role != null) { GLMod.GLMod.AddPlayer(Mesmer.Role.Data.PlayerName, "Mesmer", "Impostor"); }
                    if (Basilisk.Role != null) { GLMod.GLMod.AddPlayer(Basilisk.Role.Data.PlayerName, "Basilisk", "Impostor"); }
                    if (Reaper.Role != null) { GLMod.GLMod.AddPlayer(Reaper.Role.Data.PlayerName, "Reaper", "Impostor"); }
                    if (Saboteur.Role != null) { GLMod.GLMod.AddPlayer(Saboteur.Role.Data.PlayerName, "Saboteur", "Impostor"); }

                    if (Impostor1.Role != null) { GLMod.GLMod.AddPlayer(Impostor1.Role.Data.PlayerName, "Impostor", "Impostor"); }
                    if (Impostor2.Role != null) { GLMod.GLMod.AddPlayer(Impostor2.Role.Data.PlayerName, "Impostor", "Impostor"); }
                    if (Impostor3.Role != null) { GLMod.GLMod.AddPlayer(Impostor3.Role.Data.PlayerName, "Impostor", "Impostor"); }

                    GLMod.GLMod.SendGame();
                    //SEND STARTED
                    GLMod.GLMod.AddMyPlayer();

                    //debugg02 = "\n" + GLMod.GLMod.currentGame.id + "\n" + GLMod.GLMod.currentGame.players.First().playerName + "";


                    SendtoGoodloss = true;
                }
            }
        }




        //SURVEY
        public static void GoVitaleSab(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
            }
        }
        public static void GoCamSab(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
            }
        }
        public static void GoAdminSab(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true;
            }
        }
        public static void TimerAdminOn(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.SetAdminTime -= Time.deltaTime;
            }
        }
        public static void TimerVitalOn(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.SetVitalTime -= Time.deltaTime;
            }
        }
        public static void TimerCamOn(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.SetCamTime -= Time.deltaTime;
            }
        }
        public static void TimerNuclearOn(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.NuclearTimer -= Time.deltaTime;
            }
        }
        public static void TimerNuclearSabOn(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.NuclearLastTimer -= Time.deltaTime;
            }
        }
        public static void ResetIntroCooldown(bool flag)
        {
            ChallengerMod.CustomButton.HudManagerStartPatch.setCustomButtonCooldowns();
            ResetIntroCD = true;
        }

        public static void setIntroCooldown(bool flag)
        {
            if (flag)
            {
                ChallengerMod.CustomButton.CustomButton.MeetingEndedUpdate();
                ChallengerMod.ResetData.PlayerListClear();
                IntroCD = true;
            }
        }
        public static void GoSafeTimer(bool flag)
        {
            if (flag)
            {
                ChallengerMod.Challenger.SafeTimer -= Time.deltaTime;
            }
        }

        public static void goWinJester(bool flag)
        {
            if (flag)
            {
                Jester.Win = true;
            }
        }
        public static void goWinCursed(bool flag)
        {
            if (flag)
            {
                Cursed.Win = true;
            }
        }


        //GUARDIAN
        public static void breakShield(bool flag)
        {
            if (flag)
            {
                Guardian.Protected = null;
            }
        }
        public static void setDoubleShield(bool flag)
        {
            if (flag)
            {
                Mystic.DoubleShield = true;
                Mystic.selfShield = true;
            }
        }
        public static void clearDoubleShield(bool flag)
        {
            if (flag)
            {
                Mystic.DoubleShield = false;
                Mystic.selfShield = false;
                Guardian.ProtectedMystic = null;
                Mystic.ClearDoubleShield = true;
            }
        }
        public static void ConvertDoubleShield(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetProtectedCopyMystic, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.setProtectedCopyMystic();
                Mystic.DoubleShield = true;
                Mystic.selfShield = true;
            }
        }

        //HUNTER
        public static void killTrack(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.HunterTrackedKill, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.hunterTrackedKill();
                GLMod.GLMod.currentGame.addAction(Hunter.Role.Data.PlayerName, Hunter.Tracked.Data.PlayerName, "player_tracked_kill");

            }
        }
        public static void updateTrack(bool flag)
        {
            if (flag)
            {
                if (Hunter.Role != null)
                {

                    if (Hunter.Tracked != null)
                    {

                        Hunter.Tracked = null;
                        Hunter.TrackUsed = false;
                    }
                    else
                    {

                    }
                }
                else { }
            }
        }
        public static void killCopyTrack(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.HunterCopyTrackedKill, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.hunterCopyTrackedKill();
                GLMod.GLMod.currentGame.addAction(CopyCat.Role.Data.PlayerName, CopyCat.CopiedPlayer.Data.PlayerName, "player_tracked_kill");

            }
        }
        public static void resetTrack(bool flag)
        {
            if (flag)
            {
                if (Hunter.Tracked == null)
                    Hunter.TrackUsed = false;
            }
        }

        public static void updateCopyTrack(bool flag)
        {
            if (flag)
            {
                if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart)
                {

                    if (Hunter.CopyTracked != null)
                    {

                        Hunter.CopyTracked = null;
                        Hunter.CopyTrackUsed = false;
                    }
                    else
                    {

                    }
                }
                else { }
            }
        }

        public static void resetCopyTrack(bool flag)
        {
            if (flag)
            {
                if (Hunter.CopyTracked == null)
                    Hunter.CopyTrackUsed = false;
            }
        }

        //BAIT
        public static void stunned(bool flag)
        {
            if (flag)
            {
                Bait.stunsDelay -= Time.deltaTime;

                if (Bait.stunsDelay < 0) 
                {
                    if (Barghest.Shadow == true)
                    {
                        PlayerControl.LocalPlayer.MyPhysics.Speed = 1.85f;
                        Bait.ResetStunsPlayer = true;
                    }
                    else
                    {
                        PlayerControl.LocalPlayer.MyPhysics.Speed = 2.5f;
                        Bait.ResetStunsPlayer = true;
                    }
                }
                else
                {
                    PlayerControl.LocalPlayer.MyPhysics.Speed = 0.85f;
                }
                
            }
        }
        public static void resetstunned(bool flag)
        {
            if (flag)
            {
                Bait.stunsDelay = ChallengerOS.Utils.Option.CustomOptionHolder.BaitStuns.getFloat() + 0;
                Bait.StunsPlayer = false;
                Bait.ResetStunsPlayer = false;
            }
        }

        //CUPID
        public static void killLover1(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.KillLover1, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.killLover1();
                GLMod.GLMod.currentGame.addAction(Cupid.Lover1.Data.PlayerName, "", "lover_suicide");
            }
        }
        public static void killLover2(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.KillLover2, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.killLover2();
                GLMod.GLMod.currentGame.addAction(Cupid.Lover2.Data.PlayerName, "", "lover_suicide");
            }
        }
        public static void cupidLoose(bool flag)
        {
            if (flag)
            {
                Cupid.Fail = true;
            }
        }

        //CULTIST
        public static void CultistDieNow(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CultistDie, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.cultistDie();
                GLMod.GLMod.currentGame.addAction(Cultist.Role.Data.PlayerName, "", "cultist_die");

            }
        }

        //ARSONIST 
        public static void OiledUI(bool flag)
        {
            if (flag)
            {
                PlayerOiled = true;
            }
        }
        //COPYCAT
        public static void CopyStart(bool flag)
        {
            if (flag)
            {

                if (PlayerControl.LocalPlayer == CopyCat.Role)
                {
                    if (Guardian.Protected != null) { Guardian.ShieldUsed = true; }
                    if (Informant.Informed != null) { Informant.Informed = null; }

                    Hunter.CopyTrackUsed = false;
                    Engineer.RepairUsed = false;
                    Mystic.selfShield = false;
                    Mayor.BuzzUsed = false;
                    Detective.FindFP = false;
                    Nightwatch.LightBuff = false;
                    Spy.SpyUsed = false;
                    Spy.Use = false;
                    Informant.Used = false;
                    Mentalist.AdminUsed = false;
                    Dictator.NoSkipUsed = false;
                    CopyCat.Temp = true;
                    CopyCat.CopyStart = true;
                    Sentinel.Scan = false;
                }
                else
                {
                    CopyCat.Temp = true;
                    CopyCat.CopyStart = true;
                }

            }
        }
        public static void CopyDie(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CopyCatDie, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.copyCatDie();
            }
        }
        public static void CopyImpostor(bool flag)
        {
            if (flag)
            {
                CopyCat.Role.Data.Role.TeamType = RoleTeamTypes.Impostor;
                CopyCat.isImpostor = true;
            }
        }


        //REVENGER
        public static void RevengerKill(bool flag)
        {
            if (flag)
            {
                Revenger.isCrewmate = true;
                Revenger.isImpostor = false;
            }
        }
        public static void RevengerExil(bool flag)
        {
            if (flag)
            {
                Revenger.isCrewmate = false;
                Revenger.isImpostor = true;
            }
        }

        public static void DisabledAllImpostors(bool flag)
        {
            if (flag)
            {
                if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisabledAllCrewmates(bool flag)
        {
            if (flag)
            {
                if (!PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableCrew1(bool flag)
        {
            if (flag)
            {
                Revenger.EMP1_On = true;
                if (Revenger.EMP1 != null && PlayerControl.LocalPlayer == Revenger.EMP1 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableCrew2(bool flag)
        {
            if (flag)
            {
                Revenger.EMP2_On = true;
                if (Revenger.EMP2 != null && PlayerControl.LocalPlayer == Revenger.EMP2 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableCrew3(bool flag)
        {
            if (flag)
            {
                Revenger.EMP3_On = true;
                if (Revenger.EMP3 != null && PlayerControl.LocalPlayer == Revenger.EMP3 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableImpo1(bool flag)
        {
            if (flag)
            {
                Revenger.EMP1_On = true;
                if (Revenger.EMP1 != null && PlayerControl.LocalPlayer == Revenger.EMP1 && PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableImpo2(bool flag)
        {
            if (flag)
            {
                Revenger.EMP2_On = true;
                if (Revenger.EMP2 != null && PlayerControl.LocalPlayer == Revenger.EMP2 && PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }
        public static void DisableImpo3(bool flag)
        {
            if (flag)
            {
                Revenger.EMP3_On = true;
                if (Revenger.EMP3 != null && PlayerControl.LocalPlayer == Revenger.EMP3 && PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {
                    AbilityDisabled = true;
                }
            }
        }

        public static void IncRune1(bool flag)
        {
            if (flag)
            {
                Sorcerer.TotalRune += 1;
                Sorcerer.LootAttrValue1 = true;
            }
        }
        public static void IncRune2(bool flag)
        {
            if (flag)
            {
                Sorcerer.TotalRune += 1;
                Sorcerer.LootAttrValue2 = true;
            }
        }
        public static void IncRune3(bool flag)
        {
            if (flag)
            {
                Sorcerer.TotalRune += 1;
                Sorcerer.LootAttrValue3 = true;
            }
        }
        public static void IncRune4(bool flag)
        {
            if (flag)
            {
                Sorcerer.TotalRune += 1;
                Sorcerer.LootAttrValue4 = true;
            }
        }

        public static void Exterminated(bool flag)
        {
            if (flag)
            {
                foreach (PlayerControl P in PlayerControl.AllPlayerControls)
                {
                    if (P == Sorcerer.Exterminated)
                    {
                        P.Die(DeathReason.Exile);
                        new ChallengerOS.SorcererMark(15f, P);
                    }
                }
                if (PlayerControl.LocalPlayer == Sorcerer.Exterminated)
                {
                    PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                    Sorcerer.Role.MurderPlayer(Sorcerer.Exterminated);
                    Sorcerer.Exterminated.Data.IsDead = true;

                }
                else
                {
                    Sorcerer.Exterminated.Data.IsDead = true;
                }

            }
        }


        public static void ClearInfected(bool flag)
        {
            if (flag)
            {
                Vector.Reset = true;
                if (PlayerControl.LocalPlayer == Vector.Infected)
                {
                    SoundManager.Instance.StopSound(PoisonDelay);
                    HudManager.Instance.FullScreen.gameObject.SetActive(true);
                    HudManager.Instance.FullScreen.enabled = true;
                    HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0f);
                }
            }
        }
        public static void VectorReset(bool flag)
        {
            if (flag)
            {
                Vector.Infected = null;
                Vector.Reset = false;
            }
        }
        public static void IsInfected(bool flag)
        {
            if (flag)
            {
                if (PlayerControl.LocalPlayer == Vector.Infected)
                {

                    SoundManager.Instance.PlaySound(PoisonDelay, true, 100f);
                    HudManager.Instance.FullScreen.gameObject.SetActive(true);
                    HudManager.Instance.FullScreen.enabled = true;
                    HudManager.Instance.FullScreen.color = new Color(0.85f, 0.1f, 0f, 0.5f);
                }
            }
        }

        public static void ResetMorph(bool flag)
        {
            if (flag)
            {
                Morphling.Morph = null;
            }
        }


        //ASSASSIN STEAL

        public static void AssassinStealShield(bool flag)
        {
            if (flag)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AssassinShield, Hazel.SendOption.None, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.assassinShield();

            }
        }
    }
}