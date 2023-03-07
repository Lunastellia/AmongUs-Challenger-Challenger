using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Roles;
using ChallengerMod.RPC;
using Hazel;
using Reactor.Extensions;
using Cpp2IL.Core.Analysis.Actions.x86.Important;

namespace ChallengerMod.SetEndGame
{
    enum CustomGameOverReason
    {
        _Win = 10,
    }

    enum WinCondition
    {
        Default,
        ChallengerWin,
    }

    static class AdditionalTempData
    {
        public static WinCondition winCondition = WinCondition.Default;
        public static List<WinCondition> additionalWinConditions = new List<WinCondition>();

        public static void clear()
        {
            additionalWinConditions.Clear();
            winCondition = WinCondition.Default;
        }

        
    }


    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class AmongUsClientOnGameEndPatch
    {
        private static GameOverReason gameOverReason;

        public static void Prefix(AmongUsClient __instance, [HarmonyArgument(0)] ref EndGameResult endResult)
        {
            gameOverReason = endResult.GameOverReason;
            if ((int)endResult.GameOverReason >= 10) endResult.GameOverReason = GameOverReason.ImpostorByKill;

        }

        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ref EndGameResult endResult)
        {
            AdditionalTempData.clear();

            List<PlayerControl> clearWinnerList = new List<PlayerControl>();
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                clearWinnerList.Add(player);
            }

            

            List<WinningPlayerData> removeWinnerList = new List<WinningPlayerData>();
            foreach (WinningPlayerData winner in TempData.winners)
            {
                if (clearWinnerList.Any(x => x.Data.PlayerName == winner.PlayerName)) removeWinnerList.Add(winner);
            }
            foreach (var winner in removeWinnerList) TempData.winners.Remove(winner);

            bool CustomWin = gameOverReason == (GameOverReason)CustomGameOverReason._Win;


            // Mini lose
            if (CustomWin)
            {
                AdditionalTempData.winCondition = WinCondition.ChallengerWin;
            }


            // Reset Settings
        }
    }
    /*[HarmonyPatch(typeof(EndGameNavigation))]
    public class EndGameManagerPatch2
    {
        public static void Postfix(EndGameNavigation __instance)
        {
            GameObject Button = __instance.ContinueButton;

            PassiveButton Bttn = Button.GetComponent<PassiveButton>();
            Bttn.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);

            void onClick()
            {
                var OnDestroy = GameObject.Find("WinText_TMP(Clone)");
                OnDestroy.Destroy();
            }
        }
    }*/


            [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
    public class EndGameManagerSetUpPatch
    {
        public static void Postfix(EndGameManager __instance)
        {
            
            
            // Additional code
            __instance.BackgroundBar.material.color = ChallengerMod.ColorTable.blackColor;
            __instance.WinText.text = "";
            GameObject bonusText = UnityEngine.Object.Instantiate(__instance.WinText.gameObject);
            bonusText.transform.position = new Vector3(__instance.WinText.transform.position.x, __instance.WinText.transform.position.y - 0f, __instance.WinText.transform.position.z);
            bonusText.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            TMPro.TMP_Text textRenderer = bonusText.GetComponent<TMPro.TMP_Text>();
            textRenderer.text = "";
            

            if (AdditionalTempData.winCondition == WinCondition.ChallengerWin)
            {

                /* */

                List<string> WinList = new List<string>();

                if (CulteWinthegame == true)
                {
                    WinList.Add("Culte");
                    textRenderer.text += "<size=3><color=#8300FF>φ " + Str_CulteWin + " φ\n</color></size>";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Role.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_Cultist + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                    if (Culte1_Count == true)
                    {
                        GLMod.GLMod.AddWinnerPlayer(Cultist.Culte1.Data.PlayerName);
                        textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Culte1.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_CulteMember + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                    }
                    else { }
                    if (Culte2_Count == true)
                    {

                        GLMod.GLMod.AddWinnerPlayer(Cultist.Culte2.Data.PlayerName);
                        textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Culte2.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_CulteMember + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                    }
                    else { }
                    if (Culte3_Count == true)
                    {

                        GLMod.GLMod.AddWinnerPlayer(Cultist.Culte3.Data.PlayerName);
                        textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Culte3.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_CulteMember + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                    }
                    else { }
                    textRenderer.text += "\n\n";
                }
                else { }

                if (JesterWinthegame == true)
                {

                    textRenderer.text += "<size=3><color=#FF0A88>★ " + Str_JesterWin + " ★\n</color></size>\n";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0A88>[" + Jester.Role.Data.PlayerName + "]</color> <color=#FF0A88>(" + Role_Jester + ")</color> - <color=#00ff00>" + Str_Win + "</color>\n";
                    WinList.Add("Jester");
                }

                else { }
                if (CursedWinthegame == true)
                {

                    textRenderer.text += "<size=3><color=#3F683B>★ " + Str_CursedWin + " ★\n</color></size>\n";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#3F683B>[" + Cursed.Role.Data.PlayerName + "]</color> <color=#3F683B>(" + Role_Cursed + ")</color> - <color=#FF0000>[" + Cursed.CursePercent + "%]</color> - <color=#00ff00>" + Str_Win + "</color>\n";
                    WinList.Add("Cursed");
                }

                else { }
                if (OutlawWinthegame == true)
                {

                    textRenderer.text += "<size=3><color=#0033FF>★ " + Str_OutlawWin + " ★\n</color></size>\n";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#0033FF>[" + Outlaw.Role.Data.PlayerName + "]</color> <color=#0033FF>(" + Role_Outlaw + ")</color> - <color=#00ff00>" + Str_Win + "</color>\n";
                    WinList.Add("Outlaw");
                }

                else { }

                if (ArsonistWinthegame == true)
                {

                    textRenderer.text += "<size=3><color=#ffc800>★ " + Str_ArsonistWin + " ★\n</color></size>\n";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ffc800>[" + Arsonist.Role.Data.PlayerName + "]</color> <color=#ffc800>(" + Role_Arsonist + ")</color> - <color=#00ff00>" + Str_Win + "</color>\n";
                    WinList.Add("Arsonist");
                }

                else { }

                if (EaterWinthegame == true)
                {
                    textRenderer.text += "<size=3><color=#FF6E00>★ " + Str_EaterWin + " ★\n</color></size>\n";
                    textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF6E00>[" + Eater.Role.Data.PlayerName + "]</color> <color=#FF6E00>(" + Role_Eater + ")</color> - <color=#FF0000>[" + EaterTask + "/" + Eatervaluewin + "]</color> - <color=#00ff00>" + Str_Win + "</color>\n";
                    WinList.Add("Eater");
                }
                else { }
                if (ImpostorWinthegameBySab == true)
                {
                    textRenderer.text += "<size=3><color=#FF0000>★ " + Str_ImpostorWin + " ★\n</color></size>\n";
                    textRenderer.text += "<size=1.6><color=#FF0000>" + Str_BySabWin + "\n</color></size>\n";
                    WinList.Add("Impostor");

                }
                else { }
                if (ImpostorWinthegame == true)
                {
                    textRenderer.text += "<size=3><color=#FF0000>★ " + Str_ImpostorWin + " ★\n</color></size>\n";
                    textRenderer.text += "<size=1.6><color=#FF0000>" + Str_ByKillWin + "\n</color></size>\n";
                    WinList.Add("Impostor");
                }
                else { }
                if (CrewmateWinthegamebyTask == true)
                {
                    textRenderer.text += "<size=3><color=#B4FAFA>★ " + Str_CrewmateWin + " ★\n</color></size>\n";
                    textRenderer.text += "<size=1.6><color=#B4FAFA>" + Str_ByTaskWin + "\n</color></size>\n";
                    WinList.Add("Crewmate");

                }
                else { }
                if (CrewmateWinthegame == true)
                {
                    textRenderer.text += "<size=3><color=#B4FAFA>★ " + Str_CrewmateWin + " ★\n</color></size>\n";
                    textRenderer.text += "<size=1.6><color=#B4FAFA>" + Str_ByVoteWin + "\n</color></size>\n";
                    WinList.Add("Crewmate");

                }
                else { }
                if (LoveWinthegame == true)
                {
                    WinList.Add("Lover");


                    GLMod.GLMod.AddWinnerPlayer(Cupid.Lover1.Data.PlayerName);
                    GLMod.GLMod.AddWinnerPlayer(Cupid.Lover2.Data.PlayerName);

                    textRenderer.text += "<size=1.6><color=#FFAFFF>" + Str_CupidWin + " = [" + Cupid.Lover1.Data.PlayerName + " ♥]" + " + [" + Cupid.Lover2.Data.PlayerName + " ♥]" + "</color></size>\n";

                }
                else { }

                textRenderer.text += "\n";

                if (Sheriff1Count == true)
                {
                    if (Sheriff1Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Sheriff1.Role.Data.PlayerName + "]")) { }

                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff1.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Sheriff1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff1.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff1.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }


                if (Sheriff2Count == true)
                {
                    if (Sheriff2Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Sheriff2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff2.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Sheriff2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff2.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff2.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Sheriff3Count == true)
                {
                    if (Sheriff3Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Sheriff3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff3.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff3Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Sheriff3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff3.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff3.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff3Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (GuardianCount == true)
                {
                    if (GuardianWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Guardian.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Guardian.Role.Data.PlayerName + "]</color> <color=#00FFFF>(" + Role_Guardian + ")</color> - <color=#00FFFF>[" + GuardianTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (GuardianWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Guardian.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Guardian.Role.Data.PlayerName + "]</color> <color=#00FFFF>(" + Role_Guardian + ")</color> - <color=#00FFFF>[" + GuardianTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (EngineerCount == true)
                {
                    if (EngineerWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Engineer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Engineer.Role.Data.PlayerName + "]</color> <color=#FFA100>(" + Role_Engineer + ")</color> - <color=#00FFFF>[" + EngineerTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (EngineerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Engineer.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Engineer.Role.Data.PlayerName + "]</color> <color=#FFA100>(" + Role_Engineer + ")</color> - <color=#00FFFF>[" + EngineerTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (TimelordCount == true)
                {
                    if (TimelordWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Timelord.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Timelord.Role.Data.PlayerName + "]</color> <color=#007FFF>(" + Role_Timelord + ")</color> - <color=#00FFFF>[" + TimelordTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (TimelordWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Timelord.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Timelord.Role.Data.PlayerName + "]</color> <color=#007FFF>(" + Role_Timelord + ")</color> - <color=#00FFFF>[" + TimelordTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (HunterCount == true)
                {
                    if (HunterWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Hunter.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Hunter.Role.Data.PlayerName + "]</color> <color=#00FF00>(" + Role_Hunter + ")</color> - <color=#00FFFF>[" + HunterTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (HunterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Hunter.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Hunter.Role.Data.PlayerName + "]</color> <color=#00FF00>(" + Role_Hunter + ")</color> - <color=#00FFFF>[" + HunterTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }

                if (MysticCount == true)
                {
                    if (MysticWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Mystic.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mystic.Role.Data.PlayerName + "]</color> <color=#F9FFB2>(" + Role_Mystic + ")</color> - <color=#00FFFF>[" + MysticTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MysticWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mystic.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mystic.Role.Data.PlayerName + "]</color> <color=#F9FFB2>(" + Role_Mystic + ")</color> - <color=#00FFFF>[" + MysticTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (SpiritCount == true)
                {
                    if (SpiritWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Spirit.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spirit.Role.Data.PlayerName + "]</color> <color=#A1FF00>(" + Role_Spirit + ")</color> - <color=#00FFFF>[" + SpiritTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (SpiritWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Spirit.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spirit.Role.Data.PlayerName + "]</color> <color=#A1FF00>(" + Role_Spirit + ")</color> - <color=#00FFFF>[" + SpiritTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }

                if (MayorCount == true)
                {
                    if (MayorWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Mayor.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mayor.Role.Data.PlayerName + "]</color> <color=#AF8269>(" + Role_Mayor + ")</color> - <color=#00FFFF>[" + MayorTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MayorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mayor.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mayor.Role.Data.PlayerName + "]</color> <color=#AF8269>(" + Role_Mayor + ")</color> - <color=#00FFFF>[" + MayorTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (DetectiveCount == true)
                {
                    if (DetectiveWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Detective.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Detective.Role.Data.PlayerName + "]</color> <color=#BCFFBA>(" + Role_Detective + ")</color> - <color=#00FFFF>[" + DetectiveTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (DetectiveWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Detective.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Detective.Role.Data.PlayerName + "]</color> <color=#BCFFBA>(" + Role_Detective + ")</color> - <color=#00FFFF>[" + DetectiveTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (NightwatchCount == true)
                {
                    if (NightwatchWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Nightwatch.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Nightwatch.Role.Data.PlayerName + "]</color> <color=#9EB3FF>(" + Role_Nightwatch + ")</color> - <color=#00FFFF>[" + NightwatchTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (NightwatchWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Nightwatch.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Nightwatch.Role.Data.PlayerName + "]</color> <color=#9EB3FF>(" + Role_Nightwatch + ")</color> - <color=#00FFFF>[" + NightwatchTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (SpyCount == true)
                {
                    if (SpyWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Spy.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spy.Role.Data.PlayerName + "]</color> <color=#9EE1FF>(" + Role_Spy + ")</color> - <color=#00FFFF>[" + SpyTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (SpyWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Spy.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spy.Role.Data.PlayerName + "]</color> <color=#9EE1FF>(" + Role_Spy + ")</color> - <color=#00FFFF>[" + SpyTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (InformantCount == true)
                {
                    if (InformantWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Informant.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Informant.Role.Data.PlayerName + "]</color> <color=#ADFFEA>(" + Role_Informant + ")</color> - <color=#00FFFF>[" + InformantTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (InformantWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Informant.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Informant.Role.Data.PlayerName + "]</color> <color=#ADFFEA>(" + Role_Informant + ")</color> - <color=#00FFFF>[" + InformantTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (BaitCount == true)
                {
                    if (BaitWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Bait.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Bait.Role.Data.PlayerName + "]</color> <color=#808080>(" + Role_Bait + ")</color> - <color=#00FFFF>[" + BaitTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (BaitWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Bait.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Bait.Role.Data.PlayerName + "]</color> <color=#808080>(" + Role_Bait + ")</color> - <color=#00FFFF>[" + BaitTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (MentalistCount == true)
                {
                    if (MentalistWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Mentalist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mentalist.Role.Data.PlayerName + "]</color> <color=#A991FF>(" + Role_Mentalist + ")</color> - <color=#00FFFF>[" + MentalistTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MentalistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mentalist.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mentalist.Role.Data.PlayerName + "]</color> <color=#A991FF>(" + Role_Mentalist + ")</color> - <color=#00FFFF>[" + MentalistTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (BuilderCount == true)
                {
                    if (BuilderWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Builder.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Builder.Role.Data.PlayerName + "]</color> <color=#FFC291>(" + Role_Builder + ")</color> - <color=#00FFFF>[" + BuilderTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (BuilderWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Builder.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Builder.Role.Data.PlayerName + "]</color> <color=#FFC291>(" + Role_Builder + ")</color> - <color=#00FFFF>[" + BuilderTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (DictatorCount == true)
                {
                    if (DictatorWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Dictator.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Dictator.Role.Data.PlayerName + "]</color> <color=#C06A6A>(" + Role_Dictator + ")</color> - <color=#00FFFF>[" + DictatorTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (DictatorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Dictator.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Dictator.Role.Data.PlayerName + "]</color> <color=#C06A6A>(" + Role_Dictator + ")</color> - <color=#00FFFF>[" + DictatorTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (SentinelCount == true)
                {
                    if (SentinelWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Sentinel.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sentinel.Role.Data.PlayerName + "]</color> <color=#06AD17>(" + Role_Sentinel + ")</color> - <color=#00FFFF>[" + SentinelTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (SentinelWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Sentinel.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sentinel.Role.Data.PlayerName + "]</color> <color=#06AD17>(" + Role_Sentinel + ")</color> - <color=#00FFFF>[" + SentinelTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }

                if (Teammate1Count == true)
                {
                    if (Teammate1Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Teammate1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Teammate1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Teammate1.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Teammate2Count == true)
                {
                    if (Teammate2Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Teammate2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Teammate2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Teammate2.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (LawkeeperCount == true)
                {
                    if (LawkeeperWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Lawkeeper.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Lawkeeper.Role.Data.PlayerName + "]</color> <color=#FF9b9b>(" + Role_Lawkeeper + ")</color> - <color=#00FFFF>[" + LawkeeperTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (LawkeeperWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Lawkeeper.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Lawkeeper.Role.Data.PlayerName + "]</color> <color=#FF9b9b>(" + Role_Lawkeeper + ")</color> - <color=#00FFFF>[" + LawkeeperTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (FakeCount == true)
                {
                    if (FakeWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Fake.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Fake.Role.Data.PlayerName + "]</color> <color=#FF7A7A>(" + Role_Fake + ")</color> - <color=#00FFFF>[" + FakeTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (FakeWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Fake.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Fake.Role.Data.PlayerName + "]</color> <color=#FF7A7A>(" + Role_Fake + ")</color> - <color=#00FFFF>[" + FakeTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (LeaderCount == true)
                {
                    if (LeaderWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Leader.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Leader.Role.Data.PlayerName + "]</color> <color=#5A7DA5>(" + Role_Leader + ")</color> - <color=#00FFFF>[" + LeaderTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (LeaderWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Leader.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Leader.Role.Data.PlayerName + "]</color> <color=#5A7DA5>(" + Role_Leader + ")</color> - <color=#00FFFF>[" + LeaderTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }

                //
                if (Crewmate1Count == true)
                {
                    if (Crewmate1Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate1.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate1Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate2Count == true)
                {
                    if (Crewmate2Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Crewmate2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate2.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate2Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate3Count == true)
                {
                    if (Crewmate3Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate3.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate3Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate3.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate3.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate3Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate4Count == true)
                {
                    if (Crewmate4Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate4.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate4.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate4Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate4Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate4.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate4.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate4Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate5Count == true)
                {
                    if (Crewmate5Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate5.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate5.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate5Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate5Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate5.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate5.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate5Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate6Count == true)
                {
                    if (Crewmate6Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Crewmate6.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate6.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate6Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate6Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate6.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate6.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate6Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate7Count == true)
                {
                    if (Crewmate7Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate7.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate7.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate7Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate7Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate7.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate7.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate7Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate8Count == true)
                {
                    if (Crewmate8Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate8.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate8.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate8Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate8Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate8.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate8.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate8Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate9Count == true)
                {
                    if (Crewmate9Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate9.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate9.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate9Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate9Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate9.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate9.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate9Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate10Count == true)
                {
                    if (Crewmate10Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate10.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate10.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate10Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate10Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate10.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate10.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate10Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate11Count == true)
                {
                    if (Crewmate11Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate11.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate11.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate11Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate11Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate11.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate11.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate11Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate12Count == true)
                {
                    if (Crewmate12Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate12.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate12.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate12Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate12Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate12.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate12.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate12Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate13Count == true)
                {
                    if (Crewmate13Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate13.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate13.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate13Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate13Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate13.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate13.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate13Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Crewmate14Count == true)
                {
                    if (Crewmate14Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Crewmate14.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate14.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate14Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Crewmate14Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate14.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate14.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate14Task + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (JesterCount == true)
                {
                    if (JesterWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Jester.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0A88>[" + Jester.Role.Data.PlayerName + "]</color> <color=#FF0A88>(" + Role_Jester + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (JesterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Jester.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0A88>[" + Jester.Role.Data.PlayerName + "]</color> <color=#FF0A88>(" + Role_Jester + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (CursedCount == true)
                {
                    if (CursedWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Cursed.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#3F683B>[" + Cursed.Role.Data.PlayerName + "]</color> <color=#3F683B>(" + Role_Cursed + ")</color> - <color=#FF0000>[" + Cursed.CursePercent + "%]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (CursedWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Cursed.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#3F683B>[" + Cursed.Role.Data.PlayerName + "]</color> <color=#3F683B>(" + Role_Cursed + ")</color> - <color=#FF0000>[" + Cursed.CursePercent + "%]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (OutlawCount == true)
                {
                    if (OutlawWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Outlaw.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#0033FF>[" + Outlaw.Role.Data.PlayerName + "]</color> <color=#0033FF>(" + Role_Outlaw + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (OutlawWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Outlaw.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#0033FF>[" + Outlaw.Role.Data.PlayerName + "]</color> <color=#0033FF>(" + Role_Outlaw + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (ArsonistCount == true)
                {
                    if (ArsonistWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Arsonist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ffc800>[" + Arsonist.Role.Data.PlayerName + "]</color> <color=#ffc800>(" + Role_Arsonist + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (ArsonistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Arsonist.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ffc800>[" + Arsonist.Role.Data.PlayerName + "]</color> <color=#ffc800>(" + Role_Arsonist + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (CupidCount == true)
                {
                    if (LoveWinthegame == true)
                    {




                        textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FFAFFF>[" + Cupid.Role.Data.PlayerName + "]</color> <color=#FFAFFF>(" + Role_Cupid + ")</color> - <color=#00ff00>" + Str_Win + "</color>";

                    }
                }
                if (MercenaryCount == true)
                {
                    if (MercenaryCWin == true) // win crew
                    {


                        GLMod.GLMod.AddWinnerPlayer(Mercenary.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#00FFFF>[" + MercenaryTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MercenaryWin == true) // win impo
                    {



                        GLMod.GLMod.AddWinnerPlayer(Mercenary.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    else if (MercenaryCWin == false) // loose crew mais love
                    {
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#00FFFF>[" + MercenaryTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                    else if (MercenaryWin == false) // loose Impo mais love
                    {
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }

                }
                if (RevengerCount == true)
                {
                    if (RevengerCWin == true) // win crew
                    {

                        GLMod.GLMod.AddWinnerPlayer(Revenger.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#00FFFF>[" + RevengerTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (RevengerWin == true) // win impo
                    {


                        GLMod.GLMod.AddWinnerPlayer(Revenger.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    else if (RevengerCWin == false) // loose crew mais love
                    {
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#00FFFF>[" + RevengerTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                    else if (RevengerWin == false) // loose Impo mais love
                    {
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }

                }

                if (CopyCatCount == true)
                {
                    if (CopyCatCWin == true) // win crew
                    {


                        GLMod.GLMod.AddWinnerPlayer(CopyCat.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#00FFFF>[" + CopyCatTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (CopyCatWin == true) // win impo
                    {


                        GLMod.GLMod.AddWinnerPlayer(CopyCat.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    else if (CopyCatCWin == false) // loose crew mais love
                    {
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#00FFFF>[" + CopyCatTask + "/" + TotalTask + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                    else if (CopyCatWin == false) // loose Impo mais love
                    {
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }

                }




                if (SurvivorCount == true)
                {
                    if (SurvivorWin == true)
                    {


                        GLMod.GLMod.AddWinnerPlayer(Survivor.Role.Data.PlayerName);
                        if (textRenderer.text.Contains("[" + Survivor.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#7F5E4C>[" + Survivor.Role.Data.PlayerName + "]</color> <color=#7F5E4C>(" + Role_Survivor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (SurvivorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Survivor.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4B4B4>[" + Survivor.Role.Data.PlayerName + "]</color> <color=#7F5E4C>(" + Role_Survivor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (EaterCount == true)
                {
                    if (EaterWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Eater.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF6E00>[" + Eater.Role.Data.PlayerName + "]</color> <color=#FF6E00>(" + Role_Eater + ")</color> - <color=#FF0000>[" + EaterTask + "/" + Eatervaluewin + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (EaterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Eater.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF6E00>[" + Eater.Role.Data.PlayerName + "]</color> <color=#FF6E00>(" + Role_Eater + ")</color> - <color=#FF0000>[" + EaterTask + "/" + Eatervaluewin + "]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (CultistCount == true)
                {
                    if (CultistWin == true)
                    {




                        if (textRenderer.text.Contains("[" + Cultist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Role.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_Cultist + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (CultistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Cultist.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Role.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_Cultist + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (AssassinCount == true)
                {
                    if (AssassinWin == true)
                    {




                        if (textRenderer.text.Contains("[" + Assassin.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Assassin.Role.Data.PlayerName + "]</color> <color=#005106>(" + Role_Assassin + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (AssassinWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Assassin.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Assassin.Role.Data.PlayerName + "]</color> <color=#005106>(" + Role_Assassin + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (VectorCount == true)
                {
                    if (VectorWin == true)
                    {




                        if (textRenderer.text.Contains("[" + Vector.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Vector.Role.Data.PlayerName + "]</color> <color=#8c1919>(" + Role_Vector + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (VectorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Vector.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Vector.Role.Data.PlayerName + "]</color> <color=#8c1919>(" + Role_Vector + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (MorphlingCount == true)
                {
                    if (MorphlingWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Morphling.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Morphling.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Morphling + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MorphlingWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Morphling.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Morphling.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Morphling + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (ScramblerCount == true)
                {
                    if (ScramblerWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Scrambler.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Scrambler.Role.Data.PlayerName + "]</color> <color=#544700>(" + Role_Scrambler + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (ScramblerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Scrambler.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Scrambler.Role.Data.PlayerName + "]</color> <color=#544700>(" + Role_Scrambler + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (BarghestCount == true)
                {
                    if (BarghestWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Barghest.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Barghest.Role.Data.PlayerName + "]</color> <color=#000569>(" + Role_Barghest + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (BarghestWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Barghest.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Barghest.Role.Data.PlayerName + "]</color> <color=#000569>(" + Role_Barghest + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (GhostCount == true)
                {
                    if (GhostWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Ghost.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Ghost.Role.Data.PlayerName + "]</color> <color=#404040>(Ghost)</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (GhostWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Ghost.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Ghost.Role.Data.PlayerName + "]</color> <color=#404040>(Ghost)</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (SorcererCount == true)
                {
                    if (SorcererWin == true)
                    {


                        if (textRenderer.text.Contains("[" + Sorcerer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Sorcerer.Role.Data.PlayerName + "]</color> <color=#542B00>(" + Role_Sorcerer + ")</color> - <color=#FF0000>[" + Sorcerer.TotalRuneLoot + "/4]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (SorcererWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Sorcerer.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Sorcerer.Role.Data.PlayerName + "]</color> <color=#542B00>(" + Role_Sorcerer + ")</color> - <color=#FF0000>[" + Sorcerer.TotalRuneLoot + "/4]</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (GuesserCount == true)
                {
                    if (GuesserWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Guesser.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Guesser.Role.Data.PlayerName + "]</color> <color=#003954>(" + Role_Guesser + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (GuesserWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Guesser.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Guesser.Role.Data.PlayerName + "]</color> <color=#003954>(" + Role_Guesser + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (MesmerCount == true)
                {
                    if (MesmerWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Mesmer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Mesmer.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Mesmer + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (MesmerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mesmer.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Mesmer.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Mesmer + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (BasiliskCount == true)
                {
                    if (BasiliskWin == true)
                    {



                        if (textRenderer.text.Contains("[" + Basilisk.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Basilisk.Role.Data.PlayerName + "]</color> <color=#5B466B>(" + Role_Basilisk + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (BasiliskWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Basilisk.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Basilisk.Role.Data.PlayerName + "]</color> <color=#5B466B>(" + Role_Basilisk + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Impostor1Count == true)
                {
                    if (Impostor1Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Impostor1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor1.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Impostor1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor1.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor1.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Impostor2Count == true)
                {
                    if (Impostor2Win == true)
                    {


                        if (textRenderer.text.Contains("[" + Impostor2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor2.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Impostor2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor2.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor2.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }
                if (Impostor3Count == true)
                {
                    if (Impostor3Win == true)
                    {



                        if (textRenderer.text.Contains("[" + Impostor3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor3.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                    }
                    if (Impostor3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor3.Role.Data.PlayerName + " ♥]"))
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor3.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#00ff00>" + Str_Win + "</color>";
                        }
                        else
                        {

                        }
                    }
                }

                textRenderer.text += "\n\n";


                if (Sheriff1Count == true)
                {
                    if (Sheriff1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff1.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff1Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }


                if (Sheriff2Count == true)
                {
                    if (Sheriff2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff2.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff2Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Sheriff3Count == true)
                {
                    if (Sheriff3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Sheriff3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sheriff3.Role.Data.PlayerName + "]</color> <color=#FFFF00>(" + Role_Sheriff + ")</color> - <color=#00FFFF>[" + Sheriff3Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (GuardianCount == true)
                {
                    if (GuardianWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Guardian.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Guardian.Role.Data.PlayerName + "]</color> <color=#00FFFF>(" + Role_Guardian + ")</color> - <color=#00FFFF>[" + GuardianTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (EngineerCount == true)
                {
                    if (EngineerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Engineer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Engineer.Role.Data.PlayerName + "]</color> <color=#FFA100>(" + Role_Engineer + ")</color> - <color=#00FFFF>[" + EngineerTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (TimelordCount == true)
                {
                    if (TimelordWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Timelord.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Timelord.Role.Data.PlayerName + "]</color> <color=#007FFF>(" + Role_Timelord + ")</color> - <color=#00FFFF>[" + TimelordTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (HunterCount == true)
                {
                    if (HunterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Hunter.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Hunter.Role.Data.PlayerName + "]</color> <color=#00FF00>(" + Role_Hunter + ")</color> - <color=#00FFFF>[" + HunterTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                
                if (MysticCount == true)
                {
                    if (MysticWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mystic.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mystic.Role.Data.PlayerName + "]</color> <color=#F9FFB2>(" + Role_Mystic + ")</color> - <color=#00FFFF>[" + MysticTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (SpiritCount == true)
                {
                    if (SpiritWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Spirit.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spirit.Role.Data.PlayerName + "]</color> <color=#A1FF00>(" + Role_Spirit + ")</color> - <color=#00FFFF>[" + SpiritTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
               
                if (MayorCount == true)
                {
                    if (MayorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mayor.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mayor.Role.Data.PlayerName + "]</color> <color=#AF8269>(" + Role_Mayor + ")</color> - <color=#00FFFF>[" + MayorTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (DetectiveCount == true)
                {
                    if (DetectiveWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Detective.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Detective.Role.Data.PlayerName + "]</color> <color=#BCFFBA>(" + Role_Detective + ")</color> - <color=#00FFFF>[" + DetectiveTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (NightwatchCount == true)
                {
                    if (NightwatchWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Nightwatch.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Nightwatch.Role.Data.PlayerName + "]</color> <color=#9EB3FF>(" + Role_Nightwatch + ")</color> - <color=#00FFFF>[" + NightwatchTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (SpyCount == true)
                {
                    if (SpyWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Spy.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Spy.Role.Data.PlayerName + "]</color> <color=#9EE1FF>(" + Role_Spy + ")</color> - <color=#00FFFF>[" + SpyTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (InformantCount == true)
                {
                    if (InformantWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Informant.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Informant.Role.Data.PlayerName + "]</color> <color=#ADFFEA>(" + Role_Informant + ")</color> - <color=#00FFFF>[" + InformantTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (BaitCount == true)
                {
                    if (BaitWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Bait.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Bait.Role.Data.PlayerName + "]</color> <color=#808080>(" + Role_Bait + ")</color> - <color=#00FFFF>[" + BaitTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (MentalistCount == true)
                {
                    if (MentalistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mentalist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mentalist.Role.Data.PlayerName + "]</color> <color=#A991FF>(" + Role_Mentalist + ")</color> - <color=#00FFFF>[" + MentalistTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (BuilderCount == true)
                {
                    if (BuilderWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Builder.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Builder.Role.Data.PlayerName + "]</color> <color=#FFC291>(" + Role_Builder + ")</color> - <color=#00FFFF>[" + BuilderTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (DictatorCount == true)
                {
                    if (DictatorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Dictator.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Dictator.Role.Data.PlayerName + "]</color> <color=#C06A6A>(" + Role_Dictator + ")</color> - <color=#00FFFF>[" + DictatorTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (SentinelCount == true)
                {
                    if (SentinelWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Sentinel.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Sentinel.Role.Data.PlayerName + "]</color> <color=#06AD17>(" + Role_Sentinel + ")</color> - <color=#00FFFF>[" + SentinelTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                
                if (Teammate1Count == true)
                {
                    if (Teammate1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Teammate1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate1Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Teammate2Count == true)
                {
                    if (Teammate2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Teammate2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Teammate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Teammate + ")</color> - <color=#00FFFF>[" + Teammate2Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (LawkeeperCount == true)
                {
                    if (LawkeeperWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Lawkeeper.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Lawkeeper.Role.Data.PlayerName + "]</color> <color=#FF9b9b>(" + Role_Lawkeeper + ")</color> - <color=#00FFFF>[" + LawkeeperTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (FakeCount == true) 
                {
                    if (FakeWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Fake.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Fake.Role.Data.PlayerName + "]</color> <color=#FF7A7A>(" + Role_Fake + ")</color> - <color=#00FFFF>[" + FakeTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (LeaderCount == true) 
                {
                    if (LeaderWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Leader.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Leader.Role.Data.PlayerName + "]</color> <color=#5A7DA5>(" + Role_Leader + ")</color> - <color=#00FFFF>[" + LeaderTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate1Count == true)
                {
                    if (Crewmate1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate1.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate1Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate2Count == true)
                {
                    if (Crewmate2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate2.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate2Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate3Count == true)
                {
                    if (Crewmate3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate3.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate3Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate4Count == true)
                {
                    if (Crewmate4Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate4.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate4.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate4Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate5Count == true)
                {
                    if (Crewmate5Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate5.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate5.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate5Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate6Count == true)
                {
                    if (Crewmate6Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate6.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate6.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate6Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate7Count == true)
                {
                    if (Crewmate7Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate7.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate7.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate7Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate8Count == true)
                {
                    if (Crewmate8Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate8.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate8.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate8Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate9Count == true)
                {
                    if (Crewmate9Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate9.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate9.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate9Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate10Count == true)
                {
                    if (Crewmate10Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate10.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate10.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate10Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate11Count == true)
                {
                    if (Crewmate11Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate11.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate11.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate11Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate12Count == true)
                {
                    if (Crewmate12Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate12.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate12.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate12Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate13Count == true)
                {
                    if (Crewmate13Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate13.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate13.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate13Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Crewmate14Count == true)
                {
                    if (Crewmate14Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Crewmate14.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Crewmate14.Role.Data.PlayerName + "]</color> <color=#B4FAFA>(" + Role_Crewmate + ")</color> - <color=#00FFFF>[" + Crewmate14Task + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (JesterCount == true)
                {
                    if (JesterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Jester.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0A88>[" + Jester.Role.Data.PlayerName + "]</color> <color=#FF0A88>(" + Role_Jester + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (CursedCount == true)
                {
                    if (CursedWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Cursed.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#3F683B>[" + Cursed.Role.Data.PlayerName + "]</color> <color=#3F683B>(" + Role_Cursed + ")</color> - <color=#FF0000>[" + Cursed.CursePercent + "%]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (OutlawCount == true)
                {
                    if (OutlawWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Outlaw.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#0033FF>[" + Outlaw.Role.Data.PlayerName + "]</color> <color=#0033FF>(" + Role_Outlaw + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (ArsonistCount == true)
                {
                    if (ArsonistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Arsonist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ffc800>[" + Arsonist.Role.Data.PlayerName + "]</color> <color=#ffc800>(" + Role_Arsonist + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (CupidCount == true)
                {
                    if (CupidWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Cupid.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FFAFFF>[" + Cupid.Role.Data.PlayerName + "]</color> <color=#FFAFFF>(" + Role_Cupid + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (MercenaryCount == true && Mercenary.isImpostor)
                {
                    if (MercenaryWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (MercenaryCount == true)
                {
                    if (MercenaryCWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mercenary.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Mercenary.Role.Data.PlayerName + "]</color> <color=#FF49E6>(" + Role_Mercenary + ")</color> - <color=#00FFFF>[" + MercenaryTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (RevengerCount == true && Revenger.isImpostor)
                {
                    if (RevengerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (RevengerCount == true)
                {
                    if (RevengerCWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Revenger.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + Revenger.Role.Data.PlayerName + "]</color> <color=#D9C27E>(" + Role_Revenger + ")</color> - <color=#00FFFF>[" + RevengerTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (CopyCatCount == true && CopyCat.isImpostor)
                {
                    if (CopyCatWin == false)
                    {
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#ff0000>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (CopyCatCount == true)
                {
                    if (CopyCatCWin == false)
                    {
                        if (textRenderer.text.Contains("[" + CopyCat.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4FAFA>[" + CopyCat.Role.Data.PlayerName + "]</color> <color=#64E6B4>(©)</color> - " + STR_COPY + " - <color=#00FFFF>[" + CopyCatTask + "/" + TotalTask + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (SurvivorCount == true)
                {
                    if (SurvivorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Survivor.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#B4B4B4>[" + Survivor.Role.Data.PlayerName + "]</color> <color=#7F5E4C>(" + Role_Survivor + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (EaterCount == true)
                {
                    if (EaterWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Eater.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF6E00>[" + Eater.Role.Data.PlayerName + "]</color> <color=#FF6E00>(" + Role_Eater + ")</color> - <color=#FF0000>[" + EaterTask + "/" + Eatervaluewin + "]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (CultistCount == true)
                {
                    if (CultistWin == false)
                    {
                        if (textRenderer.text.Contains("[" + "[" + Cultist.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#8300FF>[" + Cultist.Role.Data.PlayerName + "]</color> <color=#8300FF>(" + Role_Cultist + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (AssassinCount == true)
                {
                    if (AssassinWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Assassin.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Assassin.Role.Data.PlayerName + "]</color> <color=#005106>(" + Role_Assassin + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (VectorCount == true)
                {
                    if (VectorWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Vector.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Vector.Role.Data.PlayerName + "]</color> <color=#8c1919>(" + Role_Vector + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (MorphlingCount == true)
                {
                    if (MorphlingWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Morphling.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Morphling.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Morphling + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (ScramblerCount == true)
                {
                    if (ScramblerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Scrambler.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Scrambler.Role.Data.PlayerName + "]</color> <color=#544700>(" + Role_Scrambler + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (BarghestCount == true)
                {
                    if (BarghestWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Barghest.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Barghest.Role.Data.PlayerName + "]</color> <color=#000569>(" + Role_Barghest + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (GhostCount == true)
                {
                    if (GhostWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Ghost.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Ghost.Role.Data.PlayerName + "]</color> <color=#404040>(Ghost)</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (SorcererCount == true)
                {
                    if (SorcererWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Sorcerer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Sorcerer.Role.Data.PlayerName + "]</color> <color=#542B00>(" + Role_Sorcerer + ")</color> - <color=#FF0000>[" + Sorcerer.TotalRuneLoot + "/4]</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (GuesserCount == true)
                {
                    if (GuesserWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Guesser.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Guesser.Role.Data.PlayerName + "]</color> <color=#003954>(" + Role_Guesser + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (MesmerCount == true)
                {
                    if (MesmerWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Mesmer.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Mesmer.Role.Data.PlayerName + "]</color> <color=#430054>(" + Role_Mesmer + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (BasiliskCount == true)
                {
                    if (BasiliskWin == false)
                    {
                        if (textRenderer.text.Contains("[" + Basilisk.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Basilisk.Role.Data.PlayerName + "]</color> <color=#5B466B>(" + Role_Basilisk + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Impostor1Count == true)
                {
                    if (Impostor1Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor1.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor1.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Impostor2Count == true)
                {
                    if (Impostor2Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor2.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor2.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }
                if (Impostor3Count == true)
                {
                    if (Impostor3Win == false)
                    {
                        if (textRenderer.text.Contains("[" + Impostor3.Role.Data.PlayerName + "]")) { }
                        else
                        {
                            textRenderer.text += "\n<color=#FFFFFF>- </color><color=#FF0000>[" + Impostor2.Role.Data.PlayerName + "]</color> <color=#ff0000>(" + Role_Impostor + ")</color> - <color=#ff0000>" + Str_Loose + "</color>";
                        }
                    }
                }

                textRenderer.text += "\n";



                if (Challenger.IsrankedGame)
                {
                    Challenger.ReadyPlayers = new List<string>();
                }
                
                var EndgameManager = GameObject.Find("EndGameManager");
                if (EndgameManager != null)
                {
                    EndgameManager.transform.localPosition = new Vector3(99, 99, 0);
                }


                textRenderer.color = ChallengerMod.ColorTable.WhiteColor;

                GLMod.GLMod.SetWinnerTeams(WinList);
                GLMod.GLMod.EndGame();
                __instance.BackgroundBar.material.color = ChallengerMod.ColorTable.blackColor;
                ChallengerMod.Utility.Discord.DiscordData.UpdateDetails("Lobby");
                ChallengerMod.Utility.Discord.DiscordData.UpdateState(" ");

            }

            

            
            AdditionalTempData.clear();
        }
    }

    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CheckEndCriteria))]
    class CheckEndCriteriaPatch
    {
        public static bool Prefix(ShipStatus __instance)
        {
            if (!GameData.Instance) return false;
            if (DestroyableSingleton<TutorialManager>.InstanceExists) // 
                return true;
            var _value = new PlayerStatistics(__instance);
            if (_OutlawWin(__instance, _value)) return false;
            if (_ArsonistWin(__instance, _value)) return false;
            if (_CulteWin(__instance, _value)) return false;
            if (_JesterWin(__instance, _value)) return false;
            if (_EaterWin(__instance, _value)) return false;
            if (_CursedWin(__instance, _value)) return false;
            if (_ImpostorsSabotageWin(__instance, _value)) return false;
            if (_EndGameForSabotage(__instance, _value)) return false;
            if (_CrewmatesTaskWin(__instance, _value)) return false;
            if (_ImpostorWin(__instance, _value)) return false;
            if (_CrewmateWin(__instance, _value)) return false;
            if (_PlayerAlive(__instance, _value)) return false;
            return false;
        }
        private static bool _PlayerAlive(ShipStatus __instance, PlayerStatistics values)
        {

            if (Outlaw_Alive == 0)
            {
                ChallengerMod.Challenger.OutlawAlive = false;
            }
            return false;


        }
        private static bool _OutlawWin(ShipStatus __instance, PlayerStatistics values)
        {
            if ((values.TeamOutlawAlive == 1 && values.TeamImpostorsAlive == 0) && values.TotalAlive < 3 && !Jester.Exiled)
            {

                if (TotalLoverAlive == 2)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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


                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinOutlaw, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinOutlaw();



                CheckEnd(__instance, values);
            }
            return false;


        }
        private static bool _CulteWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (Cultist.Win == true && !Jester.Exiled)

            {
                if (TotalLoverAlive == 2)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinCulte, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinCulte();


                CheckEnd(__instance, values);
            }
            return false;
        }


        private static bool _JesterWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (Jester.Win == true)
            {
                if (values.JesterLoved == true && Jester.Win == true)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinJester, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinJester();


                CheckEnd(__instance, values);
                return true;


            }
            return false;


        }
        private static bool _EaterWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (Eater.Win == true && !Jester.Exiled)
            {
                if (TotalLoverAlive == 2 && values.EaterLoved == true)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinEater, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinEater();


                CheckEnd(__instance, values);
                return true;

            }
            return false;
        }
        private static bool _CursedWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (Cursed.Win == true)
            {
                if (values.CursedLoved == true && Cursed.Win == true)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinCursed, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinCursed();


                CheckEnd(__instance, values);
                return true;


            }
            return false;


        }
        private static bool _ArsonistWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (Arsonist.Win == true && !Jester.Exiled)
            {
                if (TotalLoverAlive == 2 && values.ArsonistLoved == true)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinArsonist, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinArsonist();


                CheckEnd(__instance, values);
                return true;

            }
            return false;
        }








    

        private static bool _ImpostorsSabotageWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (__instance.Systems == null) return false;
            var systemType = __instance.Systems.ContainsKey(SystemTypes.LifeSupp) ? __instance.Systems[SystemTypes.LifeSupp] : null;
            if (systemType != null)
            {
                LifeSuppSystemType lifeSuppSystemType = systemType.TryCast<LifeSuppSystemType>();
                if (lifeSuppSystemType != null && lifeSuppSystemType.Countdown < 0f)
                {
                    Challenger.EndGameSab = true;
                    lifeSuppSystemType.Countdown = 10000f;
                    return true;
                }
            }
            var systemType2 = __instance.Systems.ContainsKey(SystemTypes.Reactor) ? __instance.Systems[SystemTypes.Reactor] : null;
            if (systemType2 == null)
            {
                systemType2 = __instance.Systems.ContainsKey(SystemTypes.Laboratory) ? __instance.Systems[SystemTypes.Laboratory] : null;
            }
            if (systemType2 != null)
            {
                ICriticalSabotage criticalSystem = systemType2.TryCast<ICriticalSabotage>();
                if (criticalSystem != null && criticalSystem.Countdown < 0f)
                {
                    Challenger.EndGameSab = true;
                    criticalSystem.ClearSabotage();
                    return true;
                }
            }
            return false;
        }



        private static bool _CrewmatesTaskWin(ShipStatus __instance, PlayerStatistics values)
        {
            if (GameData.Instance.TotalTasks <= GameData.Instance.CompletedTasks)
            {
                if (TotalLoverAlive >= 2)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinCrewmatesByTask, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinCrewmatesByTask();

                CheckEnd(__instance, values);
                return true;


            }
            return false;
        }





        private static bool _ImpostorWin(ShipStatus __instance, PlayerStatistics values)
        {


            if (values.TeamImpostorsAlive >= (values.TotalAlive - values.TeamImpostorsAlive) && values.TeamOutlawAlive == 0 && !Mercenary.Temp && !CopyCat.Temp && !Jester.Exiled)
            {
                if (Mercenary.Temp || CopyCat.Temp)
                {

                }
                else
                {


                    if (TotalLoverAlive >= 2)
                    {
                        LoveWinthegame = true;
                        CheckLove(__instance, values);
                    }
                    else
                    {
                        LoveWinthegame = false;
                        CheckLove(__instance, values);
                    }

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

                    MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinImpostorsByKill, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(write);
                    RPCProcedure.setWinImpostorByKill();




                    CheckEnd(__instance, values);
                    return true;
                }


            }
            return false;



        }
        private static void CheckLove(ShipStatus __instance, PlayerStatistics values)
        {

            if (TotalLoverAlive == 2 || Cupid.SpecialWin)
            {
                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinLove, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinLove();

            }
            else
            { 
                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetLooseLove, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setlooseLove();
            }




        }
        private static void CheckEnd(ShipStatus __instance, PlayerStatistics values)
        {



            ChallengerMod.Challenger.EndDelay -= Time.fixedDeltaTime;


            if ((ChallengerMod.Challenger.EndDelay <= 0f))
            {
                ShipStatus.RpcEndGame((GameOverReason)CustomGameOverReason._Win, false);
                __instance.enabled = false;
            }
            else { return; }






        }

        private static bool _CrewmateWin(ShipStatus __instance, PlayerStatistics values)
        {

            if (values.TeamImpostorsAlive == 0 && values.TeamOutlawAlive == 0 && !Jester.Exiled)
            {
                if (TotalLoverAlive >= 2)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);
                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinCrewmatesByKill, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(write);
                RPCProcedure.setWinCrewmatesByKill();

                CheckEnd(__instance, values);
                return true;



            }
            return false;
            //}
        }

        private static bool _EndGameForSabotage(ShipStatus __instance, PlayerStatistics values)
        {

            if (Challenger.EndGameSab)
            {

                if (TotalLoverAlive == 2)
                {
                    LoveWinthegame = true;
                    CheckLove(__instance, values);


                }
                else
                {
                    LoveWinthegame = false;
                    CheckLove(__instance, values);
                }

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

                MessageWriter Writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetWinImpostorsBySab, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(Writer);
                RPCProcedure.setWinImpostorBySab();

                CheckEnd(__instance, values);
                return true;
            }
            return false;
        }
    }


    internal class PlayerStatistics
    {
        public int TeamImpostorsAlive { get; set; }
        public int MercenaryImpostor { get; set; }
        public int CopyCatImpostor { get; set; }
        public int RevengerImpostor { get; set; }
        public int TeamOutlawAlive { get; set; }
        public int TeamLoveAlive { get; set; }
        public int TotalAlive { get; set; }
        public int TeamCulteAlive { get; set; }
        public bool JesterLoved { get; set; }
        public bool CursedLoved { get; set; }

        public bool OutlawLoved { get; set; }
        public bool EaterLoved { get; set; }
        public bool ArsonistLoved { get; set; }
        public bool CulteLoved { get; set; }


        public PlayerStatistics(ShipStatus __instance)
        {
            GetPlayerCounts();
        }


        

        private bool IsLover(GameData.PlayerInfo p)
        {
            return (Cupid.Lover1 != null && Cupid.Lover1.PlayerId == p.PlayerId) || (Cupid.Lover2 != null && Cupid.Lover2.PlayerId == p.PlayerId);
        }
        private bool IsCulte(GameData.PlayerInfo p)
        {
            return (Cultist.Role != null && Cultist.Role.PlayerId == p.PlayerId);
        }
        private bool IsCulte1(GameData.PlayerInfo p)
        {
            return (Cultist.Culte1 != null && Cultist.Culte1.PlayerId == p.PlayerId);
        }
        private bool IsCulte2(GameData.PlayerInfo p)
        {
            return (Cultist.Culte2 != null && Cultist.Culte2.PlayerId == p.PlayerId);
        }
        private bool IsCulte3(GameData.PlayerInfo p)
        {
            return (Cultist.Culte3 != null && Cultist.Culte3.PlayerId == p.PlayerId);
        }
        private bool IsOutlaw(GameData.PlayerInfo p)
        {
            return (Outlaw.Role != null && Outlaw.Role.PlayerId == p.PlayerId);
        }


        private void GetPlayerCounts()
        {
            int numCulteAlive = 0;
            int numCulte1Alive = 0;
            int numCulte2Alive = 0;
            int numCulte3Alive = 0;
            int numLoveAlive = 0;
            int numImpostorsAlive = 0;
            int numOutlawAlive = 0;
            int numTotalAlive = 0;
            bool Jesterlove = false;
            bool Cursedlove = false;
            bool Eaterlove = false;
            bool Arsonistlove = false;
            bool CulteLove = false;
            bool Outlawlove = false;


            for (int i = 0; i < GameData.Instance.PlayerCount; i++)
            {
                GameData.PlayerInfo playerInfo = GameData.Instance.AllPlayers[i];
                if (!playerInfo.Disconnected)
                {
                    if (!playerInfo.IsDead)
                    {

                        numTotalAlive++;
                        bool lover = IsLover(playerInfo);
                        if (lover) numLoveAlive++;
                        bool outlaw = IsOutlaw(playerInfo);
                        if (outlaw) numOutlawAlive++;
                        bool culte = IsCulte(playerInfo);
                        if (culte) numCulteAlive++;
                        bool culte1 = IsCulte1(playerInfo);
                        if (culte1) numCulte1Alive++;
                        bool culte2 = IsCulte2(playerInfo);
                        if (culte2) numCulte2Alive++;
                        bool culte3 = IsCulte3(playerInfo);
                        if (culte3) numCulte3Alive++;

                       

                        if (playerInfo.Role.IsImpostor)
                        {
                            numImpostorsAlive++;
                        }

                        if (Jester.Role != null && Jester.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Jesterlove = true;

                        }
                        if (Cursed.Role != null && Cursed.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Cursedlove = true;

                        }
                        if (Outlaw.Role != null && Outlaw.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Outlawlove = true;

                        }
                        if (Eater.Role != null && Eater.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Eaterlove = true;

                        }
                        if (Arsonist.Role != null && Arsonist.Role.PlayerId == playerInfo.PlayerId)
                        {
                            if (lover) Arsonistlove = true;

                        }
                        if ((Cultist.Role != null && Cultist.Role.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte1 != null && Cultist.Culte1.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte2 != null && Cultist.Culte2.PlayerId == playerInfo.PlayerId)
                            || (Cultist.Culte3 != null && Cultist.Culte3.PlayerId == playerInfo.PlayerId)
                            )
                        {
                            if (lover) CulteLove = true;

                        }

                    }
                }

                TeamCulteAlive = numCulte1Alive + numCulte2Alive + numCulte3Alive;
                TeamLoveAlive = numLoveAlive;
                TeamImpostorsAlive = numImpostorsAlive;
                TeamOutlawAlive = numOutlawAlive;
                TotalAlive = numTotalAlive;
                JesterLoved = Jesterlove;
                CursedLoved = Cursedlove;
                OutlawLoved = Outlawlove;
                EaterLoved = Eaterlove;
                ArsonistLoved = Arsonistlove;
                CulteLoved = CulteLove;
                ChallengerMod.Set.Data.LoadImpostor = numImpostorsAlive;
            }
        }
    }
}