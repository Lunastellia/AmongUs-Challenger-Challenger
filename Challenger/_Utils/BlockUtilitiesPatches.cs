using AssemblyUnhollower.Extensions;
using ChallengerMod.RPC;
using HarmonyLib;
using Hazel;
using UnityEngine;

namespace ChallengerMod.Fix
{
    public static class BlockUtilitiesPatches
    {
        public static bool adminBool = true;
        public static bool vitalsBool = true;
        public static bool camsBool = true;

        [HarmonyPatch(typeof(VitalsMinigame), nameof(VitalsMinigame.Update))]
        public static class VitalsMinigameUpdate
        {
            public static bool Prefix(VitalsMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {


                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetVitalTimeOn = true;

                        if ((ChallengerMod.Challenger.SetVitalTime <= 0f) || Challenger.ComSab)
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
                        }
                        
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetVitalTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = false;
                }




                if (!__instance.SabText.isActiveAndEnabled &&
                    vitalsBool)
                {
                    __instance.SabText.gameObject.SetActive(true);
                    for (int j = 0; j < __instance.vitals.Length; j++)
                    {
                        __instance.vitals[j].gameObject.SetActive(false);
                    }
                }


                return !vitalsBool;
            }
        }


        [HarmonyPatch(typeof(PlanetSurveillanceMinigame), nameof(PlanetSurveillanceMinigame.Update))]
        public static class PlanetSurveillanceMinigameUpdate
        {
            public static bool Prefix(PlanetSurveillanceMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetCamTimeOn = true;

                        if ((ChallengerMod.Challenger.SetCamTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetCamTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false;
                }


                if (!__instance.isStatic && camsBool)
                {
                    __instance.isStatic = true;
                    __instance.ViewPort.sharedMaterial = __instance.StaticMaterial;
                    __instance.SabText.gameObject.SetActive(true);
                }

                return !camsBool;
            }
        }

        [HarmonyPatch(typeof(PlanetSurveillanceMinigame), nameof(PlanetSurveillanceMinigame.NextCamera))]
        public static class PlanetSurveillanceMinigameNextCamera
        {
            public static bool Prefix(PlanetSurveillanceMinigame __instance)
            {





                if (camsBool)
                {


                    __instance.Dots[__instance.currentCamera].sprite = __instance.DotDisabled;

                    __instance.currentCamera = Extensions.Wrap(__instance.currentCamera,
                        __instance.survCameras.Length);
                    __instance.Dots[__instance.currentCamera].sprite = __instance.DotEnabled;
                    SurvCamera survCamera = __instance.survCameras[__instance.currentCamera];
                    __instance.Camera.transform.position = survCamera.transform.position +
                                                           __instance.survCameras[__instance.currentCamera].Offset;
                    __instance.LocationName.text = survCamera.CamName;
                    return false;
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(SurveillanceMinigame), nameof(SurveillanceMinigame.Update))]
        public static class SurveillanceMinigameUpdate
        {
            public static bool Prefix(SurveillanceMinigame __instance)
            {
                if (!PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (__instance.enabled)
                    {



                        ChallengerMod.Challenger.SetCamTimeOn = true;

                        if ((ChallengerMod.Challenger.SetCamTime <= 0f))
                        {
                            ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                        }
                    }
                    else
                    {
                        ChallengerMod.Challenger.SetCamTimeOn = false;
                    }
                }
                else
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false;
                }

                if (ShipStatus.Instance.Type == ShipStatus.MapType.Hq)
                {
                    //Disabled Close Outside
                    if (!Challenger.resetMiraCam)
                    {
                        if (Challenger.DroneController != null && PlayerControl.LocalPlayer == Challenger.DroneController && !PlayerControl.LocalPlayer.Data.IsDead)
                        {

                            if (GameObject.Find("Main Camera/SurvMinigame(Clone)/BackgroundCloseButton/OutsideCloseButton"))
                            {
                                GameObject OutsideCloseButton = GameObject.Find("Main Camera/SurvMinigame(Clone)/BackgroundCloseButton/OutsideCloseButton");
                                OutsideCloseButton.SetActive(false);
                            }
                            //Disable CAM UI
                            if (GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/Background"))
                            {
                                GameObject Background = GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/Background");
                                Background.SetActive(false);
                            }
                            if (GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_right"))
                            {
                                GameObject security_right = GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_right");
                                security_right.SetActive(false);
                            }
                            if (GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_left"))
                            {
                                GameObject security_left = GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_left");
                                security_left.SetActive(false);
                            }
                            if (GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_desk"))
                            {
                                GameObject security_desk = GameObject.Find("Main Camera/SurvMinigame(Clone)/Viewables/security_desk");
                                security_desk.SetActive(false);
                            }
                            if (GameObject.Find("Drone_SurvCamera"))
                            {
                                GameObject SurvDrone = GameObject.Find("Drone_SurvCamera");
                                Camera.main.GetComponent<FollowerCamera>().transform.position = SurvDrone.transform.position;
                                PlayerControl.LocalPlayer.myLight.transform.position = SurvDrone.transform.position;
                                float PosX = SurvDrone.transform.position.x;
                                float PosY = SurvDrone.transform.position.y;
                                byte MyPlayer = PlayerControl.LocalPlayer.PlayerId;

                                if (Input.GetKey(Challenger.KeycodeDroneRight) || Input.GetKey(KeyCode.RightArrow))
                                {
                                    PosX += Challenger.SurvDroneSpeed;
                                    SurvDrone.transform.position = new Vector3(PosX, PosY, 1f);
                                    MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareDronePosition, Hazel.SendOption.Reliable, -1);
                                    messageWriter.Write(PosX);
                                    messageWriter.Write(PosY);
                                    messageWriter.Write(MyPlayer);
                                    AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                                    RPCProcedure.shareDronePosition(PosX, PosY, MyPlayer);
                                }
                                if (Input.GetKey(Challenger.KeycodeDroneLeft) || Input.GetKey(KeyCode.LeftArrow))
                                {
                                    PosX -= Challenger.SurvDroneSpeed;
                                    SurvDrone.transform.position = new Vector3(PosX, PosY, 1f);
                                    MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareDronePosition, Hazel.SendOption.Reliable, -1);
                                    messageWriter.Write(PosX);
                                    messageWriter.Write(PosY);
                                    messageWriter.Write(MyPlayer);
                                    AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                                    RPCProcedure.shareDronePosition(PosX, PosY, MyPlayer);
                                }
                                if (Input.GetKey(Challenger.KeycodeDroneUp) || Input.GetKey(KeyCode.UpArrow))
                                {
                                    PosY += Challenger.SurvDroneSpeed;
                                    SurvDrone.transform.position = new Vector3(PosX, PosY, 1f);
                                    MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareDronePosition, Hazel.SendOption.Reliable, -1);
                                    messageWriter.Write(PosX);
                                    messageWriter.Write(PosY);
                                    messageWriter.Write(MyPlayer);
                                    AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                                    RPCProcedure.shareDronePosition(PosX, PosY, MyPlayer);
                                }
                                if (Input.GetKey(Challenger.KeycodeDroneDown) || Input.GetKey(KeyCode.DownArrow))
                                {
                                    PosY -= Challenger.SurvDroneSpeed;
                                    SurvDrone.transform.position = new Vector3(PosX, PosY, 1f);
                                    MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareDronePosition, Hazel.SendOption.Reliable, -1);
                                    messageWriter.Write(PosX);
                                    messageWriter.Write(PosY);
                                    messageWriter.Write(MyPlayer);
                                    AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                                    RPCProcedure.shareDronePosition(PosX, PosY, MyPlayer);
                                }
                            }
                            if (!__instance.isStatic && camsBool)
                            {
                                __instance.isStatic = true;
                                __instance.Close();
                            }
                            if (Challenger.ComSab) 
                            {
                                __instance.Close(); 
                            }

                        }
                    }
                }

                if (!__instance.isStatic && camsBool)
                {
                    __instance.isStatic = true;
                    for (int j = 0; j < __instance.ViewPorts.Length; j++)
                    {
                        __instance.ViewPorts[j].sharedMaterial = __instance.StaticMaterial;
                        __instance.SabText[j].gameObject.SetActive(true);
                    }
                }

                return !camsBool;
            }
        }
        [HarmonyPatch(typeof(SurveillanceMinigame), nameof(SurveillanceMinigame.Begin))]
        class SurveillanceMinigameBeginPatch
        {
            public static void Postfix(SurveillanceMinigame __instance)
            {
                if (ShipStatus.Instance.Type == ShipStatus.MapType.Hq)
                {
                    if (Challenger.DroneController != null || Challenger.ComSab || PlayerControl.LocalPlayer.Data.IsDead) { __instance.Close(); }
                    else
                    {
                        if (GameObject.Find("Drone_SurvCamera"))
                        {
                            GameObject SurvDrone = GameObject.Find("Drone_SurvCamera");
                            float PosX = SurvDrone.transform.position.x;
                            float PosY = SurvDrone.transform.position.y;
                            byte MyPlayer = PlayerControl.LocalPlayer.PlayerId;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareDronePosition, Hazel.SendOption.Reliable, -1);
                            messageWriter.Write(PosX);
                            messageWriter.Write(PosY);
                            messageWriter.Write(MyPlayer);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.shareDronePosition(PosX, PosY, MyPlayer);
                            Challenger.resetMiraCam = false;
                        }

                    }
                }
            }
            [HarmonyPatch(typeof(SurveillanceMinigame), nameof(SurveillanceMinigame.Close))]
            class SurveillanceMinigameClosePatch
            {
                public static void Postfix(SurveillanceMinigame __instance)
                {
                    if (ShipStatus.Instance.Type == ShipStatus.MapType.Hq)
                    {
                        if (Challenger.DroneController != null && PlayerControl.LocalPlayer == Challenger.DroneController)
                        {
                            Challenger.resetMiraCam = true;
                            Camera.main.GetComponent<FollowerCamera>().transform.position = PlayerControl.LocalPlayer.transform.position;
                            Camera.main.GetComponent<FollowerCamera>().Target = PlayerControl.LocalPlayer;
                            PlayerControl.LocalPlayer.myLight.transform.position = PlayerControl.LocalPlayer.transform.position;
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.StopDrone, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                            RPCProcedure.stopDrone();
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