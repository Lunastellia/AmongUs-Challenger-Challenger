using HarmonyLib;
using ChallengerMod.Item;

namespace ChallengerMod.item
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class PlayerControl_FixedUpdate
    {
        static void Postfix(PlayerControl __instance)
        {
            
                foreach (_MapItems wItem in ChallengerMod.HarmonyMain.Instance.AllItems)
                {
                    wItem.DrawWorldIcon();
                    wItem.Update();
                }

                ChallengerMod.HarmonyMain.Instance.AllItems.RemoveAll(x => x.IsPickedUp);
            
        }
    }
}