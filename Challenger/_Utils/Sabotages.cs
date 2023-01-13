using System;
using HarmonyLib;
using InnerNet;
using Object = UnityEngine.Object;
using UnityEngine;
using static ChallengerMod.Roles;
using static ChallengerOS.Utils.Option.CustomOptionHolder;



namespace ChallengerMod.Sabotages
{
    [HarmonyPatch(typeof(HudManager))]
    public class HubManagerPatch
    {
        [HarmonyPatch(nameof(HudManager.Update))]
        static void Postfix(HudManager __instance)
        {
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {
                ReactorTask reactorTask = Object.FindObjectOfType<ReactorTask>();

                if (reactorTask != null)
                {

                    if (reactorTask.reactor.Countdown <= 60)
                    {
                        Challenger.ReactorSab = true;
                    }
                    else
                    {
                        Challenger.ReactorSab = false;
                    }

                    if (reactorTask && ReactorSabotageShaking.getSelection() == 2)
                    {
                        float reactorCountdown = reactorTask.reactor.Countdown;
                        __instance.PlayerCam.shakeAmount = 0.03f * (float)(Math.Pow(1, 3));
                        __instance.PlayerCam.shakePeriod = 400;
                    }
                    if (reactorTask && ReactorSabotageShaking.getSelection() == 1)
                    {
                        float reactorCountdown = reactorTask.reactor.Countdown;
                        __instance.PlayerCam.shakeAmount = 4f / reactorTask.reactor.Countdown;
                        __instance.PlayerCam.shakePeriod = 400;
                        if (reactorTask.reactor.Countdown <= 30)
                        {
                            HudManager.Instance.FullScreen.color = new Color(1f, 0f, 0f, 0.5f);
                            HudManager.Instance.FullScreen.enabled = true;
                        }
                        else if (reactorTask.reactor.Countdown <= 20)
                        {
                            HudManager.Instance.FullScreen.color = new Color(1f, 0f, 0f, 0.65f);
                            HudManager.Instance.FullScreen.enabled = true;
                        }
                        else if (reactorTask.reactor.Countdown <= 10)
                        {
                            HudManager.Instance.FullScreen.color = new Color(1f, 0f, 0f, 0.8f);
                            HudManager.Instance.FullScreen.enabled = true;
                        }
                    }
                    else
                    {
                        __instance.PlayerCam.shakeAmount = 0;
                        __instance.PlayerCam.shakePeriod = 0;
                    }
                }
            }
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {
                NoOxyTask noOxyTask = Object.FindObjectOfType<NoOxyTask>();
                if (noOxyTask != null)
                {



                    if (noOxyTask.reactor.Countdown <= 60)
                    {
                        Challenger.OxySab = true;
                    }
                    else
                    {
                        Challenger.OxySab = false;
                    }


                    if (noOxyTask && NoOxySabotage.getSelection() != 0)
                    {
                        foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                        {
                            player.MyPhysics.Speed = Math.Max(0.35f,
                            Math.Min(2.5f,
                            7.5f * noOxyTask.reactor.Countdown / noOxyTask.reactor.LifeSuppDuration));
                            if (player.MyPhysics.Speed <= 2.4f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.05f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2.35f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.075f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2.3f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.10f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2.25f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.13f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2.2f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.16f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2.1f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.19f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 2f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.23f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.9f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.28f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.8f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.33f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.7f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.37f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.6f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.45f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.5f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.52f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.4f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.60f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.2f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.65f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1.1f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.70f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 1f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.76f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 0.9f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.82f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 0.8f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.88f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 0.7f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.92f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }
                            if (player.MyPhysics.Speed <= 0.6f)
                            {
                                HudManager.Instance.FullScreen.color = new Color(0f, 0f, 0f, 0.95f);
                                HudManager.Instance.FullScreen.enabled = true;
                            }


                        }
                    }
                }
                else
                {
                    foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                    {
                        if (Barghest.Role != null)
                        {
                            if (Barghest.Shadow == true)
                            {

                            }
                            else
                            {
                                player.MyPhysics.Speed = 2.5f;
                            }
                        }
                        else
                        {
                            player.MyPhysics.Speed = 2.5f;
                        }
                    }
                }
            }



        }
    }
}
