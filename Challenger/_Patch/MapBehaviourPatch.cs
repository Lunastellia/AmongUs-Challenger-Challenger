using HarmonyLib;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;


namespace ChallengerMod
{

    [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.ShowSabotageMap))]
    class MapOverlay
    {
        static void Postfix(MapBehaviour __instance)
        {
            if ((Spirit.Role != null) || ((CopyCat.Role != null) && (CopyCat.copyRole == 7)))
            {
                if (((Spirit.Role.PlayerId == PlayerControl.LocalPlayer.PlayerId) && Spirit.CanCloseDoor)
                    || (CopyCat.Role.PlayerId == PlayerControl.LocalPlayer.PlayerId && CopyCat.copyRole == 7 && CopyCat.CopyStart && Spirit.CanCloseDoor)
                    )
                {
                    if (__instance.IsOpen)
                    {
                        __instance.ColorControl.baseColor = SpiritColor;
                        foreach (MapRoom room in __instance.infectedOverlay.rooms)
                        {
                            if (room.special != null)
                            {

                                room.special.material.SetFloat("_Desat", 0f);
                                room.special.enabled = false;
                                room.special.gameObject.SetActive(false);
                                room.special.gameObject.active = false;
                                room.special.gameObject.transform.localPosition = new UnityEngine.Vector3(0f, 5f, 5f);

                                if (room.door != null)
                                {

                                    room.door.color = CrewmateColor;
                                }
                            }
                        }
                    }
                }
            }
            if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && Challenger.EmergencyDestroy)
            {
                if (__instance.IsOpen)
                {
                    foreach (MapRoom room in __instance.infectedOverlay.rooms)
                    {
                        if (room.special != null)
                        {
                            
                            room.special.material.SetFloat("_Desat", 0f);
                            room.special.enabled = false;
                            room.special.gameObject.SetActive(false);
                            room.special.gameObject.active = false;
                        }
                    }
                }
            }
            if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && !Challenger.EmergencyDestroy)
            {
                if (__instance.IsOpen)
                {
                    foreach (MapRoom room in __instance.infectedOverlay.rooms)
                    {
                        if (room.special != null)
                        {

                            room.special.material.SetFloat("_Desat", 1f);
                            room.special.enabled = true;
                            room.special.gameObject.SetActive(true);
                            room.special.gameObject.active = true;
                        }
                    }
                }
            }
        }
    }



    [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.FixedUpdate))]
    class SpiritMapUpdate
    {
        static void Postfix(MapBehaviour __instance)
        {
            if ((Spirit.Role != null) || ((CopyCat.Role != null) && (CopyCat.copyRole == 7)))
            {
                if (((Spirit.Role.PlayerId == PlayerControl.LocalPlayer.PlayerId) && Spirit.CanCloseDoor)
                    || (CopyCat.Role.PlayerId == PlayerControl.LocalPlayer.PlayerId && CopyCat.copyRole == 7 && CopyCat.CopyStart && Spirit.CanCloseDoor)
                                        )
                {
                    if (__instance.IsOpen && __instance.infectedOverlay.gameObject.active)
                    {

                        __instance.ColorControl.baseColor = SpiritColor;
                        foreach (MapRoom room in __instance.infectedOverlay.rooms)
                        {
                            if (room.special != null)
                            {

                                room.special.material.SetFloat("_Desat", 0f);
                                room.special.enabled = false;
                                room.special.gameObject.SetActive(false);
                                room.special.gameObject.active = false;
                                room.special.gameObject.transform.localPosition = new UnityEngine.Vector3(0f, 5f, 5f);

                                if (room.door != null)
                                {

                                    room.door.color = CrewmateColor;
                                }
                            }
                        }
                    }
                }
            }
            if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && Challenger.EmergencyDestroy)
            {
                if (__instance.IsOpen && __instance.infectedOverlay.gameObject.active)
                {
                    foreach (MapRoom room in __instance.infectedOverlay.rooms)
                    {
                        if (room.special != null)
                        {

                            room.special.material.SetFloat("_Desat", 0f);
                            room.special.enabled = false;
                            room.special.gameObject.SetActive(false);
                            room.special.gameObject.active = false;
                        }
                    }
                }
            }
            if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && !Challenger.EmergencyDestroy)
            {
                if (__instance.IsOpen && __instance.infectedOverlay.gameObject.active)
                {
                    foreach (MapRoom room in __instance.infectedOverlay.rooms)
                    {
                        if (room.special != null)
                        {

                            room.special.material.SetFloat("_Desat", 1f);
                            room.special.enabled = true;
                            room.special.gameObject.SetActive(true);
                            room.special.gameObject.active = true;
                        }
                    }
                }
            }
        }
    }


}




