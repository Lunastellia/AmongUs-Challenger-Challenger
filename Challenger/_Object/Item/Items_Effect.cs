using Hazel;
using Reactor.Extensions;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using ChallengerMod.RPC;
using static ChallengerMod.Set.Data;

namespace ChallengerMod.Item
{
    public class _MapItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sprite Icon { get; set; }
        public Vector3 Position { get; set; }
        public GameObject ItemWorldObject { get; set; }
        public bool IsPickedUp { get; set; }

        public void Update()
        {

            if (ItemWorldObject == null) return;
            
            if (ItemWorldObject.GetComponent<SpriteRenderer>().bounds.Intersects(PlayerControl.LocalPlayer.cosmetics.currentBodySprite.BodySprite.bounds) && !PlayerControl.LocalPlayer.Data.IsDead)
            {

                if (Arsonist.Role != null && PlayerControl.LocalPlayer.PlayerId == Arsonist.Role.PlayerId)
                {
                    if (ItemWorldObject.name == "RefuelArea")
                    {
                        LoadFuel();
                    }
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }
                }
                else if (Sorcerer.Role != null && PlayerControl.LocalPlayer.PlayerId == Sorcerer.Role.PlayerId)
                {
                    if (ItemWorldObject.name == "Cristal 1")
                    {
                        PickUp1();
                    }
                    if (ItemWorldObject.name == "Cristal 2")
                    {
                        PickUp2();
                        Delete1();
                    }
                    if (ItemWorldObject.name == "Cristal 3")
                    {
                        PickUp3();
                        Delete1();
                        Delete2();
                    }
                    if (ItemWorldObject.name == "Cristal 4")
                    {
                        PickUp4();
                        Delete1();
                        Delete2();
                        Delete3();
                    }
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }
                }
                else if (Sheriff1.Role != null && PlayerControl.LocalPlayer.PlayerId == Sheriff1.Role.PlayerId)
                {
                    
                    if (ItemWorldObject.name == "GUN1")
                    {
                        PickGun1();
                    }
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }
                }
                else if (Sheriff2.Role != null && PlayerControl.LocalPlayer.PlayerId == Sheriff2.Role.PlayerId)
                {

                    if (ItemWorldObject.name == "GUN2")
                    {
                        PickGun2();
                    }
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }
                }
                else if (Sheriff3.Role != null && PlayerControl.LocalPlayer.PlayerId == Sheriff3.Role.PlayerId)
                {

                    if (ItemWorldObject.name == "GUN3")
                    {
                        PickGun3();
                    }
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }
                }
                else
                {
                    if (ItemWorldObject.name == "SafeArea1")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea2")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea3")
                    {
                        Safe();
                    }
                    if (ItemWorldObject.name == "SafeArea4")
                    {
                        Safe();
                    }

                }
            }
            
        }

        public virtual void DrawWorldIcon()
        {
            if (ItemWorldObject == null)
            {
                ItemWorldObject = new GameObject();
                ItemWorldObject.AddComponent<SpriteRenderer>();
                ItemWorldObject.AddComponent<BoxCollider2D>();
                
                ItemWorldObject.name = Name;
                ItemWorldObject.SetActive(true);
                
            }

            SpriteRenderer itemRender = ItemWorldObject.GetComponent<SpriteRenderer>();
            itemRender.enabled = true;
            itemRender.sprite = Icon;
            itemRender.transform.localScale = new Vector2(0.5f, 0.5f);
            ItemWorldObject.transform.position = Position;
        }
        public void PickUp1()
        {
            
                Delete1();
                this.Delete();
                SoundManager.Instance.PlaySound(loot, false, 100f);
                Sorcerer.LootValue1 = true;
                Sorcerer.ButtonCircle = true;
                Sorcerer.CircleEnabled = false;
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.War1, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.war1();
                Sorcerer.Start = false;
            
                

        }
        public void PickUp2()
        {
            

                Delete2();
                this.Delete();
                SoundManager.Instance.PlaySound(loot, false, 100f);
                Sorcerer.LootValue2 = true;
                Sorcerer.ButtonCircle = true;
                Sorcerer.CircleEnabled = false;
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.War2, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.war2();
                Sorcerer.Start = false;
            


        }
        public void PickUp3()
        {
            
                Delete3();
                this.Delete();
                SoundManager.Instance.PlaySound(loot, false, 100f);
                Sorcerer.LootValue3 = true;
                Sorcerer.ButtonCircle = true;
                Sorcerer.CircleEnabled = false;
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.War3, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.war3();
                Sorcerer.Start = false;
            
        }
        public void PickUp4()
        {

            
                Delete4();
                this.Delete();
                SoundManager.Instance.PlaySound(loot, false, 100f);
                Sorcerer.LootValue4 = true;
                Sorcerer.ButtonCircle = true;
                Sorcerer.CircleEnabled = false;
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.War4, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.war4();
                Sorcerer.Start = false;
            
        }
        public void LoadFuel()
        {
            Arsonist.Fuel += 1;
            debugg4 = "fuel2";
        }
        public void Safe()
        {
            SafeTimer = 0.5f;
        }
       
        public void PickGun1()
        {
            Sheriff1.CanKill = true;
            DeleteGun1();
            this.Delete();
        }
        public void PickGun2()
        {
            Sheriff2.CanKill = true;
            DeleteGun2();
            this.Delete();
        }
        public void PickGun3()
        {
            Sheriff3.CanKill = true;
            DeleteGun3();
            this.Delete();
        }



        public void Delete()
        {
            IsPickedUp = true;

            if (ItemWorldObject != null) ItemWorldObject.Destroy();

            if (AmongUsClient.Instance.AmHost)
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DestroyItem, SendOption.Reliable);
                writer.Write(this.Id);
                writer.EndMessage();
            }
            
        }
        
        public void Delete1()
        {
            
            if (ItemWorldObject.name == "Cristal 1")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void Delete2()
        {
            
            if (ItemWorldObject.name == "Cristal 2")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void Delete3()
        {
            
            if (ItemWorldObject.name == "Cristal 3")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void Delete4()
        {
            
            if (ItemWorldObject.name == "Cristal 4")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void DeleteGun1()
        {

            if (ItemWorldObject.name == "GUN1")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void DeleteGun2()
        {

            if (ItemWorldObject.name == "GUN2")
            {
                ItemWorldObject.Destroy();
            }
        }
        public void DeleteGun3()
        {

            if (ItemWorldObject.name == "GUN3")
            {
                ItemWorldObject.Destroy();
            }
        }

    }
}