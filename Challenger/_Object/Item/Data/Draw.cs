using System;
using System.Linq;
using UnityEngine;
using Reactor.Extensions;
using static ChallengerMod.Unity;

namespace ChallengerMod.Item
{
    public class TestItemDraw : _MapItems
    {
        public static System.Random ItemRandom { get; set; } = new System.Random();
        public static float ItemSpawnChance { get; set; } = 100000;
        public static bool HasSpawned { get; set; }
        public Vector3 Velocity { get; set; }

        public TestItemDraw(Vector3 position, Vector3 velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.Id = 99;
            this.Icon = slayerIco;
            this.Name = "Main";
        }

        private double _time;
        public override void DrawWorldIcon()
        {
            if (ItemWorldObject == null)
            {
                System.Console.WriteLine("Creating new Item: " + Name);
                ItemWorldObject = new GameObject();
                ItemWorldObject.AddComponent<SpriteRenderer>();
                ItemWorldObject.SetActive(true);

                SpriteRenderer itemRender = ItemWorldObject.GetComponent<SpriteRenderer>();
                itemRender.enabled = true;
                itemRender.sprite = Icon;
                itemRender.transform.localScale = new Vector3(0.5f, 0.5f, 2);
                ItemWorldObject.transform.position = Position;

                Rigidbody2D itemRigid = ItemWorldObject.AddComponent<Rigidbody2D>();
                BoxCollider2D itemCollider = ItemWorldObject.AddComponent<BoxCollider2D>();

                itemCollider.autoTiling = false;
                itemCollider.edgeRadius = 0;
                itemCollider.size = Icon.bounds.size * 0.5f;
                ItemWorldObject.layer = 8;

                itemRigid.velocity = Velocity;
            }

            Rigidbody2D itemRigid2 = ItemWorldObject.GetComponent<Rigidbody2D>();
            itemRigid2.fixedAngle = true;
            itemRigid2.drag = 0;
            itemRigid2.angularDrag = 0;
            itemRigid2.inertia = 0;
            itemRigid2.gravityScale = 0;

            _time += Time.deltaTime;

            var angle = (float)(25 + (25 * Math.Sin(_time)));
            itemRigid2.rotation = angle - 32.5f;
        }

        public static void WorldSpawn()
        {
            if (!CanSpawn())
                return;

            if (!ShipStatus.Instance)
                return;

            Vector3 pos = ChallengerMod.HarmonyMain.Instance.GetAllApplicableItemPositions1().Random();
            ChallengerMod.HarmonyMain.Instance.RpcSpawnItem(9, pos);
            HasSpawned = true;
        }

        public static bool CanSpawn()
        {
            if (ChallengerMod.HarmonyMain.Instance.AllItems.Where(x => x.Id == 3).ToList().Count > 0) return false;
            if (MeetingHud.Instance) return false;
            if (!AmongUsClient.Instance.IsGameStarted) return false;
            if (ItemRandom.Next(0, 100000) > ItemSpawnChance) return false;
            if (HasSpawned) return false;

            return true;
        }
    }
}