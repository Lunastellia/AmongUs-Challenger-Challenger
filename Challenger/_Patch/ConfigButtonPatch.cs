using HarmonyLib;
using static ChallengerMod.Roles;
using Hazel;
using UnityEngine;
using ChallengerMod.RPC;


namespace ChallengerMod.Physics
{

    public class MindControl
    {
        
    }


    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.FixedUpdate))]
    class PlayerPhysics_FixedUpdate
    {
        static bool Prefix(PlayerPhysics __instance)
        {
           

            if (PlayerControl.LocalPlayer == Mesmer.Role && Mesmer.MindControl == true && Mesmer.ControlledPlayer != null && Mesmer.Role != null && !Mesmer.Role.Data.IsDead && !Mesmer.ControlledPlayer.Data.IsDead)
            {

                

                Vector2 _velocity = HudManager.Instance.joystick.Delta * (__instance.TrueSpeed);
                Mesmer.ControlledPlayer.MyPhysics.body.velocity = _velocity;
                MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MindControl, SendOption.Reliable);
                writer.Write(_velocity.x);
                writer.Write(_velocity.y);
                writer.Write(Mesmer.ControlledPlayer.transform.position.x);
                writer.Write(Mesmer.ControlledPlayer.transform.position.y);
                writer.EndMessage();

                
                Vector3 newVel = new Vector3(_velocity.x, _velocity.y);
                Vector3 newPos = new Vector3(Mesmer.ControlledPlayer.transform.position.x, Mesmer.ControlledPlayer.transform.position.y);
                Mesmer.ControlledPlayer.transform.position = newPos;
                Mesmer.ControlledPlayer.MyPhysics.body.position = newPos;
                Mesmer.ControlledPlayer.MyPhysics.body.velocity = newVel;
                


                return false;
            }
            else { return true; }
        }

        static void Postfix(PlayerPhysics __instance)
        {
            if (__instance.AmOwner && PlayerControl.LocalPlayer != null)
            {
                __instance.body.velocity *= 1f;
                __instance.body.velocity *= 1f;

            }
        }
    }
}