using System.Linq;
using Vector2 = UnityEngine.Vector2;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using Reactor.Extensions;

namespace ChallengerMod.Item
{
    public class War2Item : _MapItems
    {
        public static System.Random ItemRandom { get; set; } = new System.Random();
        public static float ItemSpawnChance { get; set; } = 100000;
        public static bool HasSpawned { get; set; }

        public War2Item(Vector2 position)
        {
            this.Position = position;
            this.Id = 2;
            if (PlayerControl.LocalPlayer == Sorcerer.Role)
            {
                this.Icon = Rune8;
            }
            else
            {
                this.Icon = empty;
            }
            
            this.Name = "Cristal 2";
        }

        public static void WorldSpawn()
        {
            if (!CanSpawn())
                return;

            if (!ShipStatus.Instance)
                return;

            Vector2 pos = ChallengerMod.HarmonyMain.Instance.GetAllApplicableItemPositions2().Random();
            ChallengerMod.HarmonyMain.Instance.RpcSpawnItem(2, pos);
            HasSpawned = true;
        }

        public static bool CanSpawn()
        {
            if (ChallengerMod.HarmonyMain.Instance.AllItems.Where(x => x.Id == 2).ToList().Count > 0) return false;
            if (MeetingHud.Instance) return false;
            if (!AmongUsClient.Instance.IsGameStarted) return false;
            if (HasSpawned) return false;

            return true;
        }
    }
}