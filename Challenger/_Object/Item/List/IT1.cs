using System.Linq;
using Vector3 = UnityEngine.Vector3;
using Reactor.Extensions;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;

namespace ChallengerMod.Item
{
    public class War1Item : _MapItems
    {
        public static System.Random ItemRandom { get; set; } = new System.Random();
        public static float ItemSpawnChance { get; set; } = 100000;
        public static bool HasSpawned { get; set; }

        public War1Item(Vector3 position)
        {
            this.Position = position;
            this.Id = 1;
            if (PlayerControl.LocalPlayer == Sorcerer.Role)
            {
                this.Icon = Rune1;
            }
            else
            {
                this.Icon = empty;
            }
            
            this.Name = "Cristal 1";
            
            //this.ItemWorldObject.gameObject.name = "1";
        }

        public static void WorldSpawn()
        {
            if (!CanSpawn())
                return;

            if (!ShipStatus.Instance)
                return;

            Vector3 pos = ChallengerMod.HarmonyMain.Instance.GetAllApplicableItemPositions1().Random();
            ChallengerMod.HarmonyMain.Instance.RpcSpawnItem(1, pos);
            HasSpawned = true;
        }

        public static bool CanSpawn()
        {
            if (ChallengerMod.HarmonyMain.Instance.AllItems.Where(x => x.Id == 1).ToList().Count > 0) return false;
            if (MeetingHud.Instance) return false;
            if (!AmongUsClient.Instance.IsGameStarted) return false;
            if (HasSpawned) return false;

            return true;
        }
    }
}