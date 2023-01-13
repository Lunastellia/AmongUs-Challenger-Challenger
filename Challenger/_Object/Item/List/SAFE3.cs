using System.Linq;
using Vector2 = UnityEngine.Vector2;
using Reactor.Extensions;
using static ChallengerMod.Unity;

namespace ChallengerMod.Item
{
    public class War10Item : _MapItems
    {
        public static System.Random ItemRandom { get; set; } = new System.Random();
        public static float ItemSpawnChance { get; set; } = 100000;
        public static bool HasSpawned { get; set; }

        public War10Item(Vector2 position)
        {
            this.Position = position;
            this.Id = 10;
            
                this.Icon = SA3;
            
            
            this.Name = "SafeArea3";
        }

        public static void WorldSpawn()
        {
            if (!CanSpawn())
                return;

            if (!ShipStatus.Instance)
                return;

            Vector2 pos = ChallengerMod.HarmonyMain.Instance.GetAllApplicableItemPositions10().Random();
            ChallengerMod.HarmonyMain.Instance.RpcSpawnItem(10, pos);
            HasSpawned = true;
        }

        public static bool CanSpawn()
        {
            if (ChallengerMod.HarmonyMain.Instance.AllItems.Where(x => x.Id == 10).ToList().Count > 0) return false;
            if (MeetingHud.Instance) return false;
            if (!AmongUsClient.Instance.IsGameStarted) return false;
            if (HasSpawned) return false;

            return true;
        }
    }
}