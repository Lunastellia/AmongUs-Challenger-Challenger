using System.Linq;
using Vector2 = UnityEngine.Vector2;
using Reactor.Extensions;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;

namespace ChallengerMod.Item
{
    public class War13Item : _MapItems
    {
        public static System.Random ItemRandom { get; set; } = new System.Random();
        public static float ItemSpawnChance { get; set; } = 100000;
        public static bool HasSpawned { get; set; }

        public War13Item(Vector2 position)
        {
            this.Position = position;
            this.Id = 13;

            if (PlayerControl.LocalPlayer == Sheriff2.Role)
            {
                this.Icon = SheriffGun;
            }
            else
            {
                this.Icon = empty;
            }


            this.Name = "GUN2";
        }

        public static void WorldSpawn()
        {
            if (!CanSpawn())
                return;

            if (!ShipStatus.Instance)
                return;

            Vector2 pos = ChallengerMod.HarmonyMain.Instance.GetAllApplicableItemPositions13().Random();
            ChallengerMod.HarmonyMain.Instance.RpcSpawnItem(13, pos);
            HasSpawned = true;
        }

        public static bool CanSpawn()
        {
            if (ChallengerMod.HarmonyMain.Instance.AllItems.Where(x => x.Id == 13).ToList().Count > 0) return false;
            if (MeetingHud.Instance) return false;
            if (!AmongUsClient.Instance.IsGameStarted) return false;
            if (HasSpawned) return false;

            return true;
        }
    }
}