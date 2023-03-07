using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Linq;
using Reactor;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.Utility.Server.Server;
using UnityEngine;
using System.IO;
using Reactor.Extensions;
using System.Collections;
using ChallengerMod.RPC;
using Hazel.Udp;
using Hazel;
using InnerNet;
using System.Collections.Generic;
using ChallengerMod.UI;
using ChallengerMod.Item;
using UnityEngine.Video;

namespace ChallengerMod
{
    [BepInPlugin(Id, "Challenger_Core", VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInProcess("Among Us.exe")]

    public class HarmonyMain : BasePlugin
    {
        public const int MaxPlayers = 15;
        public const int MaxImpostors = 3;
        public const string VersionString = "5.2.1";
        public static bool CanStartTheGame = false;
        public const string UpdateNameString = "Mira Challenger";
        public const string UpdateNameStringFR = "Mira Challenger";

        public const string PrefixString = "";
        public const string SufixString = "";
        public static int GoodlossRank = 0;
        public static int GoodlossRankValue = 0;
        public static string STR_GoodlossRank = "";
        public static string STR_myRank = "orianachallenger";
        public static string STR_myRankname = "x";
        public static string STR_DiscordText = "Lobby";
        public static bool RankedSeason = true;
        public static string ServerID = "Wait";
        public static int debugMod = 0;

        public static bool MDP0 = false;
        public static bool MDP1 = false;
        public static bool MDP2 = false;
        public static bool MDP3 = false;
        public static bool MDP4 = false;
        public static bool MDP5 = false;
        public static string GetPersonaName = "";
        public static string GetSteamID = "";

        public static bool CanGMMod = false;
        public static bool CanGMYes = false;

        public static string KeyboardData = "null";
        public static string KeyKillBind = "Q";

        public static System.Version Version = System.Version.Parse(VersionString);
        
        public const string Id = "Config.OrianaGames";
        public static HarmonyMain Instance { get { return PluginSingleton<HarmonyMain>.Instance; } }
        public List<_MapItems> AllItems { get; set; }
        public Harmony Harmony { get; } = new Harmony(Id);
        public static ConfigEntry<string> EventConfig { get; set; }



        public void ControlPlayer()
        {

            Mesmer.ControlledPlayer.MyPhysics.body.velocity = Vector2.zero;
            Mesmer.Role.MyPhysics.body.velocity = Vector2.zero;
            KillAnimation.SetMovement(Mesmer.Role, false);
            KillAnimation.SetMovement(Mesmer.Role, true);
            KillAnimation.SetMovement(Mesmer.ControlledPlayer, false);
            KillAnimation.SetMovement(Mesmer.ControlledPlayer, true);
            Coroutines.Start(CoControlPlayer());

        }

        public void RpcControlPlayer()
        {


            ControlPlayer();
            MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.MindControlOn, SendOption.Reliable);
            writer.EndMessage();

        }
        

        public IEnumerator CoControlPlayer()
        {
            DateTime now = DateTime.UtcNow;

            PlayerControl controller = Mesmer.Role;
            PlayerControl target = Mesmer.ControlledPlayer;


            if (controller.AmOwner)
            {
                target.MyPhysics.body.interpolation = RigidbodyInterpolation2D.Interpolate;
                Camera.main.GetComponent<FollowerCamera>().Target = target;
                Camera.main.GetComponent<FollowerCamera>().shakeAmount = 0;
            }


            target.moveable = true;
           controller.moveable = true;

            if (target.AmOwner || controller.AmOwner)
                PlayerControl.LocalPlayer.MyPhysics.body.velocity = new Vector2(0, 0);

            while (true)
            {
                if (target.Data.IsDead ||
                    MeetingHud.Instance ||
                    target.Data.IsDead ||
                    AmongUsClient.Instance.GameState != InnerNetClient.GameStates.Started ||
                    now.AddSeconds(ChallengerOS.Utils.Option.CustomOptionHolder.MesmerMindDuration.getFloat() + 0f) < DateTime.UtcNow)
                {
                    if (target.AmOwner)
                    {
                        target.moveable = true;
                    }
                    else if (controller.AmOwner)
                    {
                        target.MyPhysics.body.interpolation = RigidbodyInterpolation2D.None;
                        controller.moveable = true;
                        Camera.main.GetComponent<FollowerCamera>().Target = controller;
                        controller.myLight.transform.position = controller.transform.position;
                    }

                    target = null;
                    controller = null;
                    //call RPC RESET
                    yield break;
                }

                if (controller.AmOwner || target.AmOwner)
                {
                    if (Minigame.Instance)
                        Minigame.Instance.Close();
                    PlayerControl.LocalPlayer.moveable = false;
                    if (controller.AmOwner)
                    {
                        controller.myLight.transform.position = target.transform.position;

                    }
                }

                yield return null;
            }
        }





        public List<Tuple<byte, Vector3>> PossibleItemPositions1 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleItemPositions2 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleItemPositions3 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleItemPositions4 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleRefuelPositions1 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleRefuelPositions2 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleRefuelPositions3 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleSafeAreaPosition1 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleSafeAreaPosition2 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleSafeAreaPosition3 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleSafeAreaPosition4 { get; set; }

        public List<Tuple<byte, Vector3>> PossibleGunPosition1 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleGunPosition2 { get; set; }
        public List<Tuple<byte, Vector3>> PossibleGunPosition3 { get; set; }

        public List<Tuple<byte, Vector3>> DefaultItemPositons1 { get; } = new List<Tuple<byte, Vector3>>
        {

            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(7.1917f, -7.4608f, 0f)), // reactor gauche
            new Tuple<byte, Vector3>(2, new Vector3(0.7336f, -15.8723f, 0f)),//O2 arbre
            new Tuple<byte, Vector3>(2, new Vector3(0.7272f, -23.7329f, 0f)),//boiler
            new Tuple<byte, Vector3>(2, new Vector3(12.5163f, -15.805f, 0f)),//com
            new Tuple<byte, Vector3>(2, new Vector3(14.0535f, -25.5563f, 0f)),//letf weapon
            new Tuple<byte, Vector3>(2, new Vector3(22.2359f, -25.1529f, 0f)),//admin
            new Tuple<byte, Vector3>(2, new Vector3(40.4668f, -7.9357f, 0f)),//labscan
            new Tuple<byte, Vector3>(2, new Vector3(31.7124f, -12.6003f, 0f)),//lab sous
            new Tuple<byte, Vector3>(2, new Vector3(10.6926f, -23.1685f, 0f)),//weapon
            new Tuple<byte, Vector3>(2, new Vector3(19.2048f, -14.2662f, 0f)),//sous storage
             new Tuple<byte, Vector3>(2, new Vector3(8.5258f, -25.3094f, 0f)),//weapongauche
            new Tuple<byte, Vector3>(2, new Vector3(6.9869f, -17.2416f, 0f)),//o2droite

            
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(10.2647f, 2.5933f, 0f)),//weapon
            new Tuple<byte, Vector3>(0, new Vector3(9.4932f, -12.3475f, 0f)),//shield
            new Tuple<byte, Vector3>(0, new Vector3(2.5737f, -16.1931f, 0f)),//com
            new Tuple<byte, Vector3>(0, new Vector3(-17.7589f, -13.075f, 0f)),//lower
            new Tuple<byte, Vector3>(0, new Vector3(-13.5324f, -6.6402f, 0f)),//cam
           
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(9.0096f, 13.3139f, 0f)),//lab
             new Tuple<byte, Vector3>(1, new Vector3(14.2094f, 20.3396f, 0f)),//office
             new Tuple<byte, Vector3>(1, new Vector3(19.6934f, 24.2592f, 0f)),//o2
             new Tuple<byte, Vector3>(1, new Vector3(19.6554f, -1.7158f, 0f)),//balcony
           
            //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-8.9262f, 12.411f, 0f)),//vault
            new Tuple<byte, Vector3>(4, new Vector3(-13.947f, -16.2671f, 0f)),//wifi
            new Tuple<byte, Vector3>(4, new Vector3(6.3916f, 2.8207f, 0f)),//room
            new Tuple<byte, Vector3>(4, new Vector3(16.8694f, 15.1931f, 0f)),//meeting
            new Tuple<byte, Vector3>(4, new Vector3(39.0316f, 0.1374f, 0f)),//cargobay

        };
        public List<Tuple<byte, Vector3>> DefaultItemPositons2 { get; } = new List<Tuple<byte, Vector3>>
        {
            
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(33.2881f, -5.9731f, 0f)),//lab
            new Tuple<byte, Vector3>(2, new Vector3(15.3485f, -1.5507f, 0f)),//dropship
            new Tuple<byte, Vector3>(2, new Vector3(9.7674f, -13.0522f, 0f)),//elec
            new Tuple<byte, Vector3>(2, new Vector3(3.8551f, -11.3176f, 0f)),//cam
            new Tuple<byte, Vector3>(2, new Vector3(22.1464f, -7.3579f, 0f)),//gauche lab
            new Tuple<byte, Vector3>(2, new Vector3(25.4283f, -7.2494f, 0f)),//drill
            new Tuple<byte, Vector3>(2, new Vector3(30.5908f, -16.9539f, 0f)),//lave
            new Tuple<byte, Vector3>(2, new Vector3(23.1093f, -16.7963f, 0f)),//office
            new Tuple<byte, Vector3>(2, new Vector3(35.3437f, -21.7277f, 0f)),//specimen
            new Tuple<byte, Vector3>(2, new Vector3(23.5183f, -25.095f, 0f)),//sasadmin
            new Tuple<byte, Vector3>(2, new Vector3(40.447f, -9.74f, 0f)),//saslabo
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(6.7502f, -4.7172f, 0f)),//o2
            new Tuple<byte, Vector3>(0, new Vector3(-2.6562f, -9.8193f, 0f)),//storage
             new Tuple<byte, Vector3>(0, new Vector3(-21.4545f, -1.8767f, 0f)),//react
             new Tuple<byte, Vector3>(0, new Vector3(4.2615f, -1.3479f, 0f)),//cafe
             new Tuple<byte, Vector3>(0, new Vector3(-8.9569f, -8.2333f, 0f)),//elec
             
             //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(-3.702f, 3.8094f, 1f)),//dropship
             new Tuple<byte, Vector3>(1, new Vector3(15.5234f, -1.1143f, 0f)),//medbay
             new Tuple<byte, Vector3>(1, new Vector3(10.2239f, 0.9181f, 0f)),//locker
             new Tuple<byte, Vector3>(1, new Vector3(21.6816f, 17.3318f, 0f)),//admin
              //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-17.8355f, -3.1899f, 0f)),//admin
            new Tuple<byte, Vector3>(4, new Vector3(-3.6655f, -9.2027f, 0f)),//kitchen
            new Tuple<byte, Vector3>(4, new Vector3(11.7524f, 2.4413f, 0f)),//mainhallphoto
            new Tuple<byte, Vector3>(4, new Vector3(29.2975f, -6.4715f, 0f)),//medbay
            new Tuple<byte, Vector3>(4, new Vector3(20.2132f, 11.8975f, 0f)),//record
            
        };
        public List<Tuple<byte, Vector3>> DefaultItemPositons3 { get; } = new List<Tuple<byte, Vector3>>
        {
           //POLUS
           
             new Tuple<byte, Vector3>(2, new Vector3(27.8525f, -20.8146f, 0f)),//couloirspeci
             new Tuple<byte, Vector3>(2, new Vector3(10.615f, -15.8735f, 0f)),//com
            new Tuple<byte, Vector3>(2, new Vector3(7.9362f, -14.7973f, 0f)),//elecdroite
            new Tuple<byte, Vector3>(2, new Vector3(3.4457f, -17.3265f, 0f)),//o2
            new Tuple<byte, Vector3>(2, new Vector3(5.5484f, -24.912f, 0f)),//droite boiler
            new Tuple<byte, Vector3>(2, new Vector3(12.7708f, -24.4433f, 0f)),//weapon
            new Tuple<byte, Vector3>(2, new Vector3(20.1273f, -25.0795f, 0f)),//admin
            new Tuple<byte, Vector3>(2, new Vector3(33.199f, -10.2464f, 0f)),//toilette
            new Tuple<byte, Vector3>(2, new Vector3(20.0469f, -12.3139f, 0f)),//storage
            new Tuple<byte, Vector3>(2, new Vector3(21.9653f, -14.5883f, 0f)),//sousstorage
            new Tuple<byte, Vector3>(2, new Vector3(4.675f, -4.3846f, 0f)),//reagauche
            new Tuple<byte, Vector3>(2, new Vector3(1.3791f, -18.7537f, 0f)),//o2
            new Tuple<byte, Vector3>(2, new Vector3(2.4404f, -24.6233f, 0f)),//boiler
            
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(16.9056f, -4.6246f, 0f)),//nav
            new Tuple<byte, Vector3>(0, new Vector3(-18.2318f, 2.5851f, 0f)),//upper
            new Tuple<byte, Vector3>(0, new Vector3(-9.7375f, -4.8044f, 0f)),//med
            new Tuple<byte, Vector3>(0, new Vector3(7.9712f, -14.1755f, 0f)),//shield
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(27.9054f, -1.7185f, 0f)),//balconydroite
             new Tuple<byte, Vector3>(1, new Vector3(13.3060f, 22.5659f, 0f)),//o2 gauche
             new Tuple<byte, Vector3>(1, new Vector3(16.0411f, 3.3872f, 0f)),//com
             new Tuple<byte, Vector3>(1, new Vector3(1.0289f, 13.1097f, 0f)),//reactor
             //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-14.0511f, -7.9543f, 0f)),//armory
            new Tuple<byte, Vector3>(4, new Vector3(-5.9335f, 1.3978f, 0f)),//engine
            new Tuple<byte, Vector3>(4, new Vector3(10.3444f, -15.261f, 0f)),//cam
            new Tuple<byte, Vector3>(4, new Vector3(21.3439f, -1.8354f, 0f)),//shower
            new Tuple<byte, Vector3>(4, new Vector3(32.248f, 7.2861f, 1f)),//toilette
           
        };
        public List<Tuple<byte, Vector3>> DefaultItemPositons4 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(11.5194f, -7.1433f, 0f)),//reagauche
            new Tuple<byte, Vector3>(2, new Vector3(24.2608f, -3.376f, 0f)),//readroite
            new Tuple<byte, Vector3>(2, new Vector3(10.7201f, -12.2281f, 0f)),//elec
            new Tuple<byte, Vector3>(2, new Vector3(6.2224f, -20.1319f, 0f)),//o2
            new Tuple<byte, Vector3>(2, new Vector3(17.8117f, -24.349f, 0f)),//valveadmin
            new Tuple<byte, Vector3>(2, new Vector3(18.9582f, -22.2884f, 0f)),//admin
            new Tuple<byte, Vector3>(2, new Vector3(38.0018f, -21.3751f, 0f)),//specimen
            new Tuple<byte, Vector3>(2, new Vector3(29.6931f, -7.4688f, 0f)),//lab
            new Tuple<byte, Vector3>(2, new Vector3(17.9595f, -1.3522f, 0f)),//dropship
              new Tuple<byte, Vector3>(2, new Vector3(27.3188f, -12.5149f, 0f)),//rocher
              new Tuple<byte, Vector3>(2, new Vector3(24.3683f, -16.7891f, 0f)),//office
              new Tuple<byte, Vector3>(2, new Vector3(1.9682f, -11.5193f, 0f)),//cam
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(-3.0672f, 5.2626f, 0f)),//cafe
            new Tuple<byte, Vector3>(0, new Vector3(6.4539f, -7.3551f, 0f)),//admin
            new Tuple<byte, Vector3>(0, new Vector3(-21.9484f, -7.6734f, 0f)),//react
            
            new Tuple<byte, Vector3>(0, new Vector3(-19.0121f, -0.9024f, 0f)),//upper
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(-3.702f, 3.8094f, 0f)),//dropship
             new Tuple<byte, Vector3>(1, new Vector3(15.5234f, -1.1143f, 0f)),//medbay
             new Tuple<byte, Vector3>(1, new Vector3(10.2239f, 0.9181f, 0f)),//locker
             new Tuple<byte, Vector3>(1, new Vector3(21.6816f, 17.3318f, 0f)),//admin
              //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-17.8355f, -3.1899f, 0f)),//admin
            new Tuple<byte, Vector3>(4, new Vector3(-3.6655f, -9.2027f, 0f)),//kitchen
            new Tuple<byte, Vector3>(4, new Vector3(11.7524f, 2.4413f, 0f)),//mainhallphoto
            new Tuple<byte, Vector3>(4, new Vector3(29.2975f, -6.4715f, 0f)),//medbay
            new Tuple<byte, Vector3>(4, new Vector3(20.2132f, 11.8975f, 0f)),//record

        };
        public List<Tuple<byte, Vector3>> RefuelPosition1 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(19.834f, -10.8615f, 0f)),//Storage
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(-0.841f, -14.2433f, 0f)),//Storage
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(-3.3535f, 4.1112f, 0f)),//Dropship
              //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-1.8523f, 1.3073f, 0f)),//Engine

        };
        public List<Tuple<byte, Vector3>> RefuelPosition2 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(16.2174f, -20.8618f, 0f)),//AdminL
            new Tuple<byte, Vector3>(2, new Vector3(35.5909f, -18.7693f, 0f)),//Specimen
            new Tuple<byte, Vector3>(2, new Vector3(26.7149f, -6.5041f, 0f)),//labdrill
            
            
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(8.9857f, 3.7336f, 0f)),//weapon
            new Tuple<byte, Vector3>(0, new Vector3(16.8764f, -2.8335f, 0f)),//Nav
            new Tuple<byte, Vector3>(0, new Vector3(2.0932f, -14.7262f, 0f)),//radio
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(10.9212f, 12.5117f, 0f)),//Lab
             new Tuple<byte, Vector3>(1, new Vector3(16.699f, 0.7137f, 0f)),//Medbay
             new Tuple<byte, Vector3>(1, new Vector3(19.8736f, 2.6009f, 0f)),//Storage
              //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-14.2941f, -11.423f, 0f)),//deckl
            new Tuple<byte, Vector3>(4, new Vector3(5.6775f, -14.2652f, 0f)),//Deckr
            new Tuple<byte, Vector3>(4, new Vector3(27.2288f, -5.1918f, 0f)),//Medbay
            new Tuple<byte, Vector3>(4, new Vector3(37.2848f,  1.5967f, 0f)),//Cargo

        };
        public List<Tuple<byte, Vector3>> RefuelPosition3 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            
            new Tuple<byte, Vector3>(2, new Vector3(22.0209f, -24.829f, 0f)),//adminbiblio
            new Tuple<byte, Vector3>(2, new Vector3(34.2076f, -9.7121f, 0f)),//labToilette
            new Tuple<byte, Vector3>(2, new Vector3(0.688f, -15.6178f, 0f)),//O2
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(-9.1102f, -7.7026f, 0f)),//elec
            new Tuple<byte, Vector3>(0, new Vector3(-18.9893f, -9.5304f, 0f)),//lower
            new Tuple<byte, Vector3>(0, new Vector3(-18.0426f, 2.8485f, 0f)),//Upper
            new Tuple<byte, Vector3>(0, new Vector3(-1.5776f, 6.0349f, 0f)),//cafe
            //MIRAHQ
             new Tuple<byte, Vector3>(1, new Vector3(19.7134f, 20.7979f, 0f)),//admin
             new Tuple<byte, Vector3>(1, new Vector3(26.4194f, 5.4666f, 0f)),//Cafe
             new Tuple<byte, Vector3>(1, new Vector3(16.5678f, 25.4457f, 0f)),//Green
              //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(19.9468f, 12.2438f, 0f)),//biblio
            new Tuple<byte, Vector3>(4, new Vector3(21.6867f,  .7521f, 0f)),//shower
            new Tuple<byte, Vector3>(4, new Vector3(-9.1563f, 13.2349f, 0f)),//vault

        };
        public List<Tuple<byte, Vector3>> SafeAreaPosition1 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(18.6328f, -21.2657f, 0f)),//adminleft  1,7328 3,04 0
        };
        public List<Tuple<byte, Vector3>> SafeAreaPosition2 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(20.6328f, -18.0257f, 0f)),//Top 8,1138 3,1102 0
        };
        public List<Tuple<byte, Vector3>> SafeAreaPosition3 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(26.963f, -17.1929f, 0f)),//right 2,82 1,44 0
        };
        public List<Tuple<byte, Vector3>> SafeAreaPosition4 { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS
            new Tuple<byte, Vector3>(2, new Vector3(22.5774f, -22.7129f, 0f)),//admin  4,72 5,7964 0
        };

        public List<Tuple<byte, Vector3>> GunPosition { get; } = new List<Tuple<byte, Vector3>>
        {
            //POLUS 23,0126 -16,5761 -0,0166
            new Tuple<byte, Vector3>(2, new Vector3(23.0126f, -16.5761f, -1f)),//Office 
            new Tuple<byte, Vector3>(2, new Vector3(40.4136f, -8.0252f, -1f)),//Labo 
            new Tuple<byte, Vector3>(2, new Vector3(36.4681f, -21.3815f, -1f)),//Speci
            new Tuple<byte, Vector3>(2, new Vector3(2.2549f, -24.4211f, -1f)),//Boiler
            new Tuple<byte, Vector3>(2, new Vector3(3.781f, -11.6533f, -1f)),//cam 
            //SKELD
            new Tuple<byte, Vector3>(0, new Vector3(16.7047f, -5.2933f, -1f)),//nav 
            new Tuple<byte, Vector3>(0, new Vector3(2.7376f, -16.3465f, -1f)),//com 
            new Tuple<byte, Vector3>(0, new Vector3(-9.3134f, -8.4273f, -1f)),//elec 
            new Tuple<byte, Vector3>(0, new Vector3(-13.7024f, -6.6731f, -1f)),//cam 
            new Tuple<byte, Vector3>(0, new Vector3(-4.6291f, 4.9291f, 0f)),//cafe

            //MIRA
            new Tuple<byte, Vector3>(1, new Vector3(11.163f, 10.5611f, -1f)),//lab 
            new Tuple<byte, Vector3>(1, new Vector3(9.3077f, 5.0939f, -1f)),//locker 
            new Tuple<byte, Vector3>(1, new Vector3(19.6368f, 4.4803f, -1f)),//storage 
            new Tuple<byte, Vector3>(1, new Vector3(28.0706f, -1.9534f, -1f)),//bacony 
            new Tuple<byte, Vector3>(1, new Vector3(16.3116f, 24.3578f, -1f)),//oxy

            //AIRSHIP
            new Tuple<byte, Vector3>(4, new Vector3(-14.1008f, -4.7481f, -1f)),//admin 
           




        };
        

        public List<Tuple<byte, Vector3>> DefaultItemPositons { get; } = new List<Tuple<byte, Vector3>>
        {
            //l
           //POLUS
            
            
            new Tuple<byte, Vector3>(2, new Vector3( 20.8265f, -22.372f, 0f)),//
            //SKELD
            
            new Tuple<byte, Vector3>(0, new Vector3(-0.6779f, -3.5032f, 0f)),//
            //MIRAHQ
            
            new Tuple<byte, Vector3>(1, new Vector3(17.7894f, 11.4857f, 0f)),//
            //AIRSHIP
            
            new Tuple<byte, Vector3>(4, new Vector3(-19.0934f, -1.3812f, 0f)),//

            //r
           
        };

        public List<Vector3> GetAllApplicableItemPositions1()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleItemPositions1)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions2()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleItemPositions2)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions3()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleItemPositions3)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions4()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleItemPositions4)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions5()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleRefuelPositions1)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions6()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleRefuelPositions2)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions7()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in PossibleRefuelPositions3)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions8()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in SafeAreaPosition1)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions9()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in SafeAreaPosition2)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions10()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in SafeAreaPosition3)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions11()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in SafeAreaPosition4)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions12()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in GunPosition)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions13()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in GunPosition)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }
        public List<Vector3> GetAllApplicableItemPositions14()
        {
            List<Vector3> positions = new List<Vector3>();
            foreach (Tuple<byte, Vector3> position in GunPosition)
                if (ShipStatus.Instance != null && position.Item1 == PlayerControl.GameOptions.MapId)
                    positions.Add(position.Item2);
            return positions;
        }


        public void RpcSpawnItem(int id, Vector3 pos)
        {
            float x = UnityEngine.Random.Range(-1.2f, 1.2f);
            float y = UnityEngine.Random.Range(-1.2f, 1.2f);
            float z = UnityEngine.Random.Range(-1.2f, 1.2f);
            Vector3 velocity = new Vector3(x, y);
            SpawnItem(id, pos, velocity);

            MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SpawnItem, SendOption.Reliable);
            writer.Write(id);
            writer.Write(pos.x);
            writer.Write(pos.y);
            writer.Write(pos.z);
            writer.Write(velocity.x);
            writer.Write(velocity.y);
            writer.Write(velocity.z);


            writer.EndMessage();
        }
        public void SpawnItem(int id, Vector3 pos, Vector3 vel)
        {
            switch (id)
            {

                case 1:
                    War1Item War1 = new War1Item(pos);
                    AllItems.Add(War1);
                    break;
                case 2:
                    War2Item War2 = new War2Item(pos);
                    AllItems.Add(War2);
                    break;
                case 3:
                    War3Item War3 = new War3Item(pos);
                    AllItems.Add(War3);
                    break;
                case 4:
                    War4Item War4 = new War4Item(pos);
                    AllItems.Add(War4);
                    break;
                case 5:
                    War5Item War5 = new War5Item(pos);
                    AllItems.Add(War5);
                    break;
                case 6:
                    War6Item War6 = new War6Item(pos);
                    AllItems.Add(War6);
                    break;
                case 7:
                    War7Item War7 = new War7Item(pos);
                    AllItems.Add(War7);
                    break;
                case 8:
                    War8Item War8 = new War8Item(pos);
                    AllItems.Add(War8);
                    break;
                case 9:
                    War9Item War9 = new War9Item(pos);
                    AllItems.Add(War9);
                    break;
                case 10:
                    War10Item War10 = new War10Item(pos);
                    AllItems.Add(War10);
                    break;
                case 11:
                    War11Item War11 = new War11Item(pos);
                    AllItems.Add(War11);
                    break;
                case 12:
                    War12Item War12 = new War12Item(pos);
                    AllItems.Add(War12);
                    break;
                case 13:
                    War13Item War13 = new War13Item(pos);
                    AllItems.Add(War13);
                    break;
                case 14:
                    War14Item War14 = new War14Item(pos);
                    AllItems.Add(War14);
                    break;
            }
        }


        public override void Load()
        {

            ChallengerMod.Keydata.Keyboard.Main();
            AllItems = new List<_MapItems>();
            EventConfig = Config.Bind("Local-Options", "Event", "Normal");
            //GLMod.GLMod.withUnityExplorer = true;

            bundle_char = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\char");
            bundle = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\bundle");
            bundle_Anim = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\mesh");
            bundle_Sound = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\sound");
            bundle_Ranked = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\assets_ranked");
            bundle_Level = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\level");
            bundle_Map0 = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\Level_sprite");
            bundle_Sprite = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\sprite");

            _Hat_CC = bundle_char.LoadAsset<Sprite>("lapin.png").DontUnload();

            _Hat_CC00 = bundle_char.LoadAsset<Sprite>("CS_H_Stellia.png").DontUnload();
            _Hat_CC002 = bundle_char.LoadAsset<Sprite>("CS_H_HK.png").DontUnload();
            _Visor_CC00 = bundle_char.LoadAsset<Sprite>("CS_V_Stellia.png").DontUnload();
            _Hat_CC01 = bundle_char.LoadAsset<Sprite>("CS_H_Noeud.png").DontUnload();
            _Hat_CC02 = bundle_char.LoadAsset<Sprite>("CS_H_Mini.png").DontUnload();
            _Hat_CC03 = bundle_char.LoadAsset<Sprite>("CS_H_Noeud.png").DontUnload();
            _Hat_CC04 = bundle_char.LoadAsset<Sprite>("CS_H_Val.png").DontUnload();

            _Hat_FRA = bundle_char.LoadAsset<Sprite>("CS_H_FRA.png").DontUnload();
            _Hat_SUB1 = bundle_char.LoadAsset<Sprite>("CS_H_SUB1.png").DontUnload();

            _Hat_TOI1 = bundle_char.LoadAsset<Sprite>("CS_H_Colour.png").DontUnload();
            _Hat_TOI2 = bundle_char.LoadAsset<Sprite>("CS_H_Egghead.png").DontUnload();
            _Hat_TOI3 = bundle_char.LoadAsset<Sprite>("CS_H_Sly.png").DontUnload();
            _Hat_TOI4 = bundle_char.LoadAsset<Sprite>("CS_H_KKshi.png").DontUnload();
            _Hat_TOI5 = bundle_char.LoadAsset<Sprite>("CS_H_Pirate.png").DontUnload();
            _Hat_TOI6 = bundle_char.LoadAsset<Sprite>("CS_H_DinoHead.png").DontUnload();
            _Hat_TOI7 = bundle_char.LoadAsset<Sprite>("CS_H_Strong.png").DontUnload();
            _Hat_TOI8 = bundle_char.LoadAsset<Sprite>("CS_H_Carpet.png").DontUnload();
            
            _Hat_TOI9 = bundle_char.LoadAsset<Sprite>("CS_H_Tag.png").DontUnload();
            _Hat_TOI10 = bundle_char.LoadAsset<Sprite>("CS_H_Minicrew.png").DontUnload();

            _Hat_TOI11 = bundle_char.LoadAsset<Sprite>("CS_H_Dos.png").DontUnload();
            _Hat_TOI12 = bundle_char.LoadAsset<Sprite>("CS_H_LN.png").DontUnload();
            _Hat_TOI13 = bundle_char.LoadAsset<Sprite>("CS_H_Murloc.png").DontUnload();
            _Hat_TOI14 = bundle_char.LoadAsset<Sprite>("CS_H_Poorcat.png").DontUnload();
            _Hat_TOI15 = bundle_char.LoadAsset<Sprite>("CS_H_Fox.png").DontUnload();

            _Hat_Alien = bundle_char.LoadAsset<Sprite>("CS_H_Alien.png").DontUnload();
            _Hat_Demon = bundle_char.LoadAsset<Sprite>("CS_H_Demon.png").DontUnload();
            _Hat_Angel = bundle_char.LoadAsset<Sprite>("CS_H_Angel.png").DontUnload();
            _Hat_Kawaii = bundle_char.LoadAsset<Sprite>("CS_H_Kawaii.png").DontUnload();
            _Hat_Licorne = bundle_char.LoadAsset<Sprite>("CS_H_Licorne.png").DontUnload();
            _Hat_Ears = bundle_char.LoadAsset<Sprite>("CS_H_Ears.png").DontUnload();
            _Hat_Angry = bundle_char.LoadAsset<Sprite>("CS_H_Angry.png").DontUnload();
            _Hat_Vampire = bundle_char.LoadAsset<Sprite>("CS_H_Vampire.png").DontUnload();
            _Hat_Strange = bundle_char.LoadAsset<Sprite>("CS_H_Strange.png").DontUnload();
            _Hat_Clown = bundle_char.LoadAsset<Sprite>("CS_H_Clown.png").DontUnload();
            _Hat_Mask = bundle_char.LoadAsset<Sprite>("CS_H_Mask.png").DontUnload();
            _Hat_Horror = bundle_char.LoadAsset<Sprite>("CS_H_Horror.png").DontUnload();
            _Hat_Brain = bundle_char.LoadAsset<Sprite>("CS_H_Brain.png").DontUnload();
            _Hat_Reaper = bundle_char.LoadAsset<Sprite>("CS_H_Reaper.png").DontUnload();
            _Hat_WhiteMask = bundle_char.LoadAsset<Sprite>("CS_H_WhiteMask_R.png").DontUnload();
            _Hat_WhiteMask_L = bundle_char.LoadAsset<Sprite>("CS_H_WhiteMask_L.png").DontUnload();
            _Hat_Pom = bundle_char.LoadAsset<Sprite>("CS_H_Pom.png").DontUnload();
            _Hat_Pom2 = bundle_char.LoadAsset<Sprite>("CS_H_Pombiboune").DontUnload();
            _Hat_Bomber = bundle_char.LoadAsset<Sprite>("CS_H_Bomber").DontUnload();
            _Hat_Dragon = bundle_char.LoadAsset<Sprite>("CS_H_Dragon").DontUnload();
            _Hat_Tv = bundle_char.LoadAsset<Sprite>("CS_H_Tv").DontUnload();

            _Hat_Bee = bundle_char.LoadAsset<Sprite>("CS_H_Bee.png").DontUnload();
            _Hat_Cat = bundle_char.LoadAsset<Sprite>("CS_H_Cat.png").DontUnload();
            _Hat_Fluffy = bundle_char.LoadAsset<Sprite>("CS_H_Fluffy.png").DontUnload();
            _Hat_CatEars = bundle_char.LoadAsset<Sprite>("CS_H_CatEars.png").DontUnload();
            _Hat_LilyPin = bundle_char.LoadAsset<Sprite>("CS_H_LilyPin.png").DontUnload();
            _Hat_ShootingStar = bundle_char.LoadAsset<Sprite>("CS_H_ShootingStar.png").DontUnload();
            _Hat_WitchHat = bundle_char.LoadAsset<Sprite>("CS_H_WitchHat.png").DontUnload();
            _Hat_Toast = bundle_char.LoadAsset<Sprite>("CS_H_Toast.png").DontUnload();
            _Hat_Cake = bundle_char.LoadAsset<Sprite>("CS_H_Cake.png").DontUnload();

            _Hat_Meringue = bundle_char.LoadAsset<Sprite>("CS_H_Meringue.png").DontUnload();

            _Hat_HChar1 = bundle_char.LoadAsset<Sprite>("CS_H_HChar1.png").DontUnload();
            _Hat_HChar2 = bundle_char.LoadAsset<Sprite>("CS_H_HChar2.png").DontUnload();
            _Hat_HChar3 = bundle_char.LoadAsset<Sprite>("CS_H_HChar3.png").DontUnload();
            _Hat_HChar4 = bundle_char.LoadAsset<Sprite>("CS_H_HChar4.png").DontUnload();
            _Hat_HChar5 = bundle_char.LoadAsset<Sprite>("CS_H_HChar5.png").DontUnload();
            _Hat_HChar6 = bundle_char.LoadAsset<Sprite>("CS_H_HChar6.png").DontUnload();
            _Hat_HChar7 = bundle_char.LoadAsset<Sprite>("CS_H_HChar7.png").DontUnload();
            _Hat_HChar8 = bundle_char.LoadAsset<Sprite>("CS_H_HChar8.png").DontUnload();

            _Hat_HH1 = bundle_char.LoadAsset<Sprite>("CS_H_HMagicalHat.png").DontUnload();
            _Hat_HS1 = bundle_char.LoadAsset<Sprite>("CS_H_HMScarf1.png").DontUnload();
            _Hat_HS2 = bundle_char.LoadAsset<Sprite>("CS_H_HMScarf2.png").DontUnload();
            _Hat_HS3 = bundle_char.LoadAsset<Sprite>("CS_H_HMScarf3.png").DontUnload();
            _Hat_HS4 = bundle_char.LoadAsset<Sprite>("CS_H_HMScarf4.png").DontUnload();

            _Hat_WHBruce = bundle_char.LoadAsset<Sprite>("CS_H_WHBruce.png").DontUnload();
            _Hat_WHCaptain = bundle_char.LoadAsset<Sprite>("CS_H_WHCaptain.png").DontUnload();
            _Hat_WHBlacky = bundle_char.LoadAsset<Sprite>("CS_H_WHBlacky.png").DontUnload();
            _Hat_WHTiger = bundle_char.LoadAsset<Sprite>("CS_H_WHBlackTiger.png").DontUnload();
            _Hat_WHCutter = bundle_char.LoadAsset<Sprite>("CS_H_WHCutter.png").DontUnload();
            _Hat_WHDevour = bundle_char.LoadAsset<Sprite>("CS_H_WHDevourer.png").DontUnload();
            _Hat_WHIronMask = bundle_char.LoadAsset<Sprite>("CS_H_WHIronMask.png").DontUnload();
            _Hat_WHJoker = bundle_char.LoadAsset<Sprite>("CS_H_WHJoker.png").DontUnload();
            _Hat_WHQuenny = bundle_char.LoadAsset<Sprite>("CS_H_WHQueeny.png").DontUnload();
            _Hat_WHMyster = bundle_char.LoadAsset<Sprite>("CS_H_WHMyster.png").DontUnload();
            _Hat_WHSkipperman = bundle_char.LoadAsset<Sprite>("CS_H_WHSkipperman.png").DontUnload();
            _Hat_WHSlash = bundle_char.LoadAsset<Sprite>("CS_H_WHSlash.png").DontUnload();
            _Hat_WHStranger = bundle_char.LoadAsset<Sprite>("CS_H_WHStranger.png").DontUnload();
            _Hat_WHThor = bundle_char.LoadAsset<Sprite>("CS_H_WHThor.png").DontUnload();

            _Hat_SWDark = bundle_char.LoadAsset<Sprite>("CS_H_SWDark.png").DontUnload();
            _Hat_SWMool = bundle_char.LoadAsset<Sprite>("CS_H_SWMool.png").DontUnload();
            _Hat_SWLela = bundle_char.LoadAsset<Sprite>("CS_H_SWLela.png").DontUnload();
            _Hat_SWBaby = bundle_char.LoadAsset<Sprite>("CS_H_SWBaby.png").DontUnload();
            _Hat_SWShewi = bundle_char.LoadAsset<Sprite>("CS_H_SWShewi.png").DontUnload();
            _Hat_SWAaya = bundle_char.LoadAsset<Sprite>("CS_H_SWAayla.png").DontUnload();
            _Hat_SWAhsoka = bundle_char.LoadAsset<Sprite>("CS_H_SWAhsoka.png").DontUnload();
            _Hat_SWAnak = bundle_char.LoadAsset<Sprite>("CS_H_SWAnak.png").DontUnload();

            _Hat_CCamera = bundle_char.LoadAsset<Sprite>("CS_H_CCamera.png").DontUnload();
            _Hat_CPopCorn = bundle_char.LoadAsset<Sprite>("CS_H_CPopCorn.png").DontUnload();
            _Hat_CLight = bundle_char.LoadAsset<Sprite>("CS_H_CLight.png").DontUnload();
            _Hat_CSound = bundle_char.LoadAsset<Sprite>("CS_H_CSound.png").DontUnload();
            _Hat_COscar = bundle_char.LoadAsset<Sprite>("CS_H_COscar.png").DontUnload();

            _Hat_Cupid = bundle_char.LoadAsset<Sprite>("CS_H_Cupid.png").DontUnload();
            _Hat_Heart = bundle_char.LoadAsset<Sprite>("CS_H_Heart.png").DontUnload();
            _Hat_Timid = bundle_char.LoadAsset<Sprite>("CS_H_Timid.png").DontUnload();
            

            _Hat_Outfit = bundle_char.LoadAsset<Sprite>("CS_H_Outfit.png").DontUnload();
            _Hat_Crown = bundle_char.LoadAsset<Sprite>("CS_H_Crown.png").DontUnload();
            _Hat_Ghost = bundle_char.LoadAsset<Sprite>("CS_H_Ghost.png").DontUnload();
            _Hat_SpeHorn = bundle_char.LoadAsset<Sprite>("CS_H_SpeHorn.png").DontUnload();
            _Hat_Candle = bundle_char.LoadAsset<Sprite>("CS_H_Candle.png").DontUnload();


            _Visor_Cred = bundle_char.LoadAsset<Sprite>("CS_V_Cred.png").DontUnload();
            _Visor_Cpurple = bundle_char.LoadAsset<Sprite>("CS_V_Cpurple.png").DontUnload();
            _Visor_Cpink = bundle_char.LoadAsset<Sprite>("CS_V_Cpink.png").DontUnload();
            _Visor_Cblue = bundle_char.LoadAsset<Sprite>("CS_V_Cblue.png").DontUnload();
            _Visor_Cgreen = bundle_char.LoadAsset<Sprite>("CS_V_Cgreen.png").DontUnload();
            _Visor_Cleef = bundle_char.LoadAsset<Sprite>("CS_V_Cleef.png").DontUnload();
            _Visor_Cyellow = bundle_char.LoadAsset<Sprite>("CS_V_Cyellow.png").DontUnload();

            _Visor_Gun = bundle_char.LoadAsset<Sprite>("CS_V_Gun.png").DontUnload();
            _Visor_Knife = bundle_char.LoadAsset<Sprite>("CS_V_Knife.png").DontUnload();
            _Visor_Katana = bundle_char.LoadAsset<Sprite>("CS_V_Katana.png").DontUnload();
            _Visor_VampireTooth = bundle_char.LoadAsset<Sprite>("CS_V_Vampire Tooth.png").DontUnload();
            _Visor_Bloody = bundle_char.LoadAsset<Sprite>("CS_V_Bloody.png").DontUnload();
            _Visor_Fish = bundle_char.LoadAsset<Sprite>("CS_V_Fish.png").DontUnload();
            _Visor_Spiral_1 = bundle_char.LoadAsset<Sprite>("CS_V_Spiral_1.png").DontUnload();
            _Visor_Spiral_2 = bundle_char.LoadAsset<Sprite>("CS_V_Spiral_2.png").DontUnload();
            _Visor_Scythe = bundle_char.LoadAsset<Sprite>("CS_V_Scythe.png").DontUnload();
            _Visor_Coffee = bundle_char.LoadAsset<Sprite>("CS_V_Coffee.png").DontUnload();

            _Visor_H1 = bundle_char.LoadAsset<Sprite>("CS_V_H1.png").DontUnload();
            _Visor_H2 = bundle_char.LoadAsset<Sprite>("CS_V_H2.png").DontUnload();
            _Visor_HB1 = bundle_char.LoadAsset<Sprite>("CS_V_H3.png").DontUnload();
            _Visor_HB2 = bundle_char.LoadAsset<Sprite>("CS_V_H4.png").DontUnload();
            _Visor_HB3 = bundle_char.LoadAsset<Sprite>("CS_V_H5.png").DontUnload();

            _Visor_SWSaber1 = bundle_char.LoadAsset<Sprite>("CS_V_SWSaber1.png").DontUnload();
            _Visor_SWSaber2 = bundle_char.LoadAsset<Sprite>("CS_V_SWSaber2.png").DontUnload();
            _Visor_SWSaber3 = bundle_char.LoadAsset<Sprite>("CS_V_SWSaber3.png").DontUnload();
            _Visor_SWSaber4 = bundle_char.LoadAsset<Sprite>("CS_V_SWSaber4.png").DontUnload();
            _Visor_SWSaber5 = bundle_char.LoadAsset<Sprite>("CS_V_SWSaber5.png").DontUnload();

            _Visor_C3D = bundle_char.LoadAsset<Sprite>("CS_V_C3D.png").DontUnload();

            _Visor_Love = bundle_char.LoadAsset<Sprite>("CS_V_Loveyou.png").DontUnload();
            _Visor_Baloon = bundle_char.LoadAsset<Sprite>("CS_V_Love.png").DontUnload();
            _Visor_LV1 = bundle_char.LoadAsset<Sprite>("CS_V_LOVE1.png").DontUnload();
            _Visor_LV2 = bundle_char.LoadAsset<Sprite>("CS_V_LOVE2.png").DontUnload();

            _Visor_DBook = bundle_char.LoadAsset<Sprite>("CS_V_DBook.png").DontUnload();

            

            _Plate_SUB1 = bundle_char.LoadAsset<Sprite>("CS_NP_SUB1.png").DontUnload();
            _Plate_SUB2 = bundle_char.LoadAsset<Sprite>("CS_NP_SUB2.png").DontUnload();
            _Plate_SUB3 = bundle_char.LoadAsset<Sprite>("CS_NP_SUB3.png").DontUnload();

            _Plate_Eater = bundle_char.LoadAsset<Sprite>("CS_P_Eater.png").DontUnload();
            _Plate_Cupid = bundle_char.LoadAsset<Sprite>("CS_P_Cupid.png").DontUnload();

            _Plate_Arsonist = bundle_char.LoadAsset<Sprite>("CS_P_Arsonist.png").DontUnload();

            _Plate_SW1 = bundle_char.LoadAsset<Sprite>("CS_NP_SW1.png").DontUnload();
            _Plate_SW2 = bundle_char.LoadAsset<Sprite>("CS_NP_SW2.png").DontUnload();



            _Plate_CClap = bundle_char.LoadAsset<Sprite>("CS_NP_CClap.png").DontUnload();
            _Plate_CBG = bundle_char.LoadAsset<Sprite>("CS_NP_CBG.png").DontUnload();
            _Plate_CBand = bundle_char.LoadAsset<Sprite>("CS_NP_CBand.png").DontUnload();

            _Plate_1 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Bronze-3.png").DontUnload();
            _Plate_2 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Bronze-2.png").DontUnload();
            _Plate_3 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Bronze-1.png").DontUnload();
            _Plate_4 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Silver-3.png").DontUnload();
            _Plate_5 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Silver-2.png").DontUnload();
            _Plate_6 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Silver-1.png").DontUnload();
            _Plate_7 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Gold-3.png").DontUnload();
            _Plate_8 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Gold-2.png").DontUnload();
            _Plate_9 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Gold-1.png").DontUnload();
            _Plate_10 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Crystal-3.png").DontUnload();
            _Plate_11 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Crystal-2.png").DontUnload();
            _Plate_12 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Crystal-1.png").DontUnload();
            _Plate_13 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Epic.png").DontUnload();
            _Plate_14 = bundle_char.LoadAsset<Sprite>("CS_P_S1-Master.png").DontUnload();

            LobbyLevel = bundle_Map0.LoadAsset<GameObject>("Level_Lobby.prefab").DontUnload();
            LobbyLevel_PolusMapV1 = bundle_Map0.LoadAsset<Sprite>("mapPB1.png").DontUnload();
            LobbyLevel_PolusMapV2 = bundle_Map0.LoadAsset<Sprite>("mapPB2.png").DontUnload();
            LobbyLevel_PolusMapV3 = bundle_Map0.LoadAsset<Sprite>("mapPB3.png").DontUnload();
            LobbyLevel_MiraMapV1 = bundle_Map0.LoadAsset<Sprite>("mapHQ1.png").DontUnload();
            LobbyLevel_MiraMapV2 = bundle_Map0.LoadAsset<Sprite>("mapHQ2.png").DontUnload();
            LobbyLevel_room_tunnel1 = bundle_Map0.LoadAsset<Sprite>("room_tunnel1.png").DontUnload();
            Colliderdebugg = bundle_Map0.LoadAsset<Sprite>("ALP_Debugg.png").DontUnload();
            Colliderblack = bundle_Map0.LoadAsset<Sprite>("ALP_Black.png").DontUnload();
            Colliderbox = bundle_Map0.LoadAsset<Sprite>("ALP_Collider.png").DontUnload();

            Level_collider1 = bundle_Map0.LoadAsset<Sprite>("ALP_b.png").DontUnload();
            Level_collider2 = bundle_Map0.LoadAsset<Sprite>("ALP_m.png").DontUnload();
            Level_collider3 = bundle_Map0.LoadAsset<Sprite>("ALP_ml.png").DontUnload();
            Level_collider4 = bundle_Map0.LoadAsset<Sprite>("ALP_mr.png").DontUnload();
            Level_collider5 = bundle_Map0.LoadAsset<Sprite>("ALP_t.png").DontUnload();
            Level_collider6 = bundle_Map0.LoadAsset<Sprite>("ALP_tl.png").DontUnload();
            Level_collider7 = bundle_Map0.LoadAsset<Sprite>("ALP_di.png").DontUnload();

            Elec = bundle_Map0.LoadAsset<Sprite>("Elec.png").DontUnload();
            Elec2 = bundle_Map0.LoadAsset<Sprite>("Elec2.png").DontUnload();
            Level_TexP1 = bundle_Map0.LoadAsset<Sprite>("TexP1.png").DontUnload();
            Level_TexP2 = bundle_Map0.LoadAsset<Sprite>("TexP2.png").DontUnload();
            Level_TexP3 = bundle_Map0.LoadAsset<Sprite>("TexP3.png").DontUnload();

            SA1 = bundle_Map0.LoadAsset<Sprite>("SA1.png").DontUnload();
            SA2 = bundle_Map0.LoadAsset<Sprite>("SA2.png").DontUnload();
            SA3 = bundle_Map0.LoadAsset<Sprite>("SA3.png").DontUnload();
            SA4 = bundle_Map0.LoadAsset<Sprite>("SA4.png").DontUnload();

            Level_Tex3 = bundle_Map0.LoadAsset<Sprite>("room_tunnel4.png").DontUnload();
            Level_Tex4 = bundle_Map0.LoadAsset<Sprite>("room_tunnel5.png").DontUnload();
            Level_Tex1 = bundle_Map0.LoadAsset<Sprite>("ALP_sprite1.png").DontUnload();
            Level_Tex2 = bundle_Map0.LoadAsset<Sprite>("ALP_sprite2.png").DontUnload();
            TexBGMira = bundle_Map0.LoadAsset<Sprite>("ALM_Bg.png").DontUnload();
            Level_TexHQLab = bundle_Map0.LoadAsset<Sprite>("ALM_Lab.png").DontUnload();
            Level_TexHQCam = bundle_Map0.LoadAsset<Sprite>("ALM_SCam.png").DontUnload();
            Level_TexHQCam2 = bundle_Map0.LoadAsset<Sprite>("ALM_SCam2.png").DontUnload();

            Level_TexHQDS = bundle_Map0.LoadAsset<Sprite>("ALM_Dropship.png").DontUnload();

            EA1 = bundle_Map0.LoadAsset<Sprite>("EA0.png").DontUnload();
            EA2 = bundle_Map0.LoadAsset<Sprite>("EA1.png").DontUnload();
            EA3 = bundle_Map0.LoadAsset<Sprite>("EA2.png").DontUnload();
            EA4 = bundle_Map0.LoadAsset<Sprite>("EA3.png").DontUnload();
            EA5 = bundle_Map0.LoadAsset<Sprite>("EA4.png").DontUnload();
            EA6 = bundle_Map0.LoadAsset<Sprite>("EA5.png").DontUnload();


            // --------------- Bundle


            

            // --------------- Anim
            LoginAnim = bundle_Anim.LoadAsset<AnimationClip>("TestA.anim").DontDestroy();
            Logo = bundle_Anim.LoadAsset<AnimationClip>("Challenger.anim").DontDestroy();
            CircleAnim = bundle_Anim.LoadAsset<AnimationClip>("CircleAnim.anim").DontDestroy();
            LoginAnimation = bundle_Anim.LoadAsset<AnimationClip>("LoginAnim.anim").DontDestroy();
            PetrifyAnim = bundle_Anim.LoadAsset<AnimationClip>("PetrifySprite.anim").DontDestroy();
            video = bundle_Anim.LoadAsset<VideoClip>("Login.mp4").DontDestroy();
            Drone0Anim = bundle_Anim.LoadAsset<AnimationClip>("DroneSurvoff.anim").DontDestroy();
            Drone1Anim = bundle_Anim.LoadAsset<AnimationClip>("DroneSurvon.anim").DontDestroy();

            // --------------- Sound
            shieldClip = bundle_Sound.LoadAsset<AudioClip>("ShieldSound.wav").DontUnload();
            PoisonDelay = bundle_Sound.LoadAsset<AudioClip>("PoisonDelay.wav").DontUnload();
            timeoff = bundle_Sound.LoadAsset<AudioClip>("reactiv.wav").DontUnload();
            jesterkill = bundle_Sound.LoadAsset<AudioClip>("Jesterkill.wav").DontUnload();
            breakClip = bundle_Sound.LoadAsset<AudioClip>("TimeEffect.wav").DontUnload();

            ALN = bundle_Sound.LoadAsset<AudioClip>("ALN.mp3").DontUnload();



            introOST = bundle_Sound.LoadAsset<AudioClip>("Challenger_BGM.mp3").DontUnload(); //MàJ 4.2.2 +

            ventClip = bundle_Sound.LoadAsset<AudioClip>("splat.wav").DontUnload();
            PoisonClip = bundle_Sound.LoadAsset<AudioClip>("chut.wav").DontUnload();
            AlerteLoop = bundle_Sound.LoadAsset<AudioClip>("AlertLoop.wav").DontUnload();
            UseUI = bundle_Sound.LoadAsset<AudioClip>("UseUI.wav").DontUnload();

            CulteWin = bundle_Sound.LoadAsset<AudioClip>("CulteWin.wav").DontUnload();
            agony = bundle_Sound.LoadAsset<AudioClip>("Agony.wav").DontUnload();
            JesterWinSound = bundle_Sound.LoadAsset<AudioClip>("JesterWin.wav").DontUnload();
            Used = bundle_Sound.LoadAsset<AudioClip>("using.wav").DontUnload();
            ScramblerOn = bundle_Sound.LoadAsset<AudioClip>("ScramblerOn.wav").DontUnload();
            ScramblerOff = bundle_Sound.LoadAsset<AudioClip>("ScramblerOff.wav").DontUnload();
            ShieldBuff = bundle_Sound.LoadAsset<AudioClip>("Shielduse.wav").DontUnload();
            Tic = bundle_Sound.LoadAsset<AudioClip>("Tic.wav").DontUnload();
            Shadow = bundle_Sound.LoadAsset<AudioClip>("Shadow.wav").DontUnload();
            loot = bundle_Sound.LoadAsset<AudioClip>("loot.wav").DontUnload();
            surcharge = bundle_Sound.LoadAsset<AudioClip>("surcharge.wav").DontUnload();


            Burned = bundle_Sound.LoadAsset<AudioClip>("Fire.wav").DontUnload();
            Eated = bundle_Sound.LoadAsset<AudioClip>("Eated.wav").DontUnload();
            Explode = bundle_Sound.LoadAsset<AudioClip>("Explode.wav").DontUnload();
            SoulTake = bundle_Sound.LoadAsset<AudioClip>("Soundout.wav").DontUnload();
            BaitAlerte = bundle_Sound.LoadAsset<AudioClip>("Bait.mp3").DontUnload();

            // --------------- Level
            Affich = bundle_Level.LoadAsset<Sprite>("oneY2.png").DontUnload(); //Event 4.0.2
            Affich2 = bundle_Level.LoadAsset<Sprite>("oneY3.png").DontUnload(); //Event 4.0.2

            Pop1 = bundle_Level.LoadAsset<Sprite>("PopUp2.png").DontUnload();
            Pop0 = bundle_Level.LoadAsset<Sprite>("PopUp.png").DontUnload();

            ReadyIco = bundle_Level.LoadAsset<Sprite>("FFR0.png").DontUnload();
            ReadyIco = bundle_Level.LoadAsset<Sprite>("FFR0.png").DontUnload();

            FFR0 = bundle_Level.LoadAsset<Sprite>("FFR0.png").DontUnload();
            FFR1 = bundle_Level.LoadAsset<Sprite>("FFR1.png").DontUnload();
            FEN0 = bundle_Level.LoadAsset<Sprite>("FEN0.png").DontUnload();
            FEN1 = bundle_Level.LoadAsset<Sprite>("FEN1.png").DontUnload();
            FAU0 = bundle_Level.LoadAsset<Sprite>("FAU0.png").DontUnload();
            FAU1 = bundle_Level.LoadAsset<Sprite>("FAU1.png").DontUnload();

            PS1EN0 = bundle_Level.LoadAsset<Sprite>("PS1EN0.png").DontUnload();
            PS1EN1 = bundle_Level.LoadAsset<Sprite>("PS1EN1.png").DontUnload();
            PS1FR0 = bundle_Level.LoadAsset<Sprite>("PS1FR0.png").DontUnload();
            PS1FR1 = bundle_Level.LoadAsset<Sprite>("PS1FR1.png").DontUnload();

            PS2EN0 = bundle_Level.LoadAsset<Sprite>("PS2EN0.png").DontUnload();
            PS2EN1 = bundle_Level.LoadAsset<Sprite>("PS2EN1.png").DontUnload();
            PS2FR0 = bundle_Level.LoadAsset<Sprite>("PS2FR0.png").DontUnload();
            PS2FR1 = bundle_Level.LoadAsset<Sprite>("PS2FR1.png").DontUnload();

            PS3EN0 = bundle_Level.LoadAsset<Sprite>("PS3EN0.png").DontUnload();
            PS3EN1 = bundle_Level.LoadAsset<Sprite>("PS3EN1.png").DontUnload();
            PS3FR0 = bundle_Level.LoadAsset<Sprite>("PS3FR0.png").DontUnload();
            PS3FR1 = bundle_Level.LoadAsset<Sprite>("PS3FR1.png").DontUnload();


            Set_P1 = bundle_Level.LoadAsset<Sprite>("Set_P1.png").DontUnload();
            Set_P2 = bundle_Level.LoadAsset<Sprite>("Set_P2.png").DontUnload();
            Set_P3 = bundle_Level.LoadAsset<Sprite>("Set_P3.png").DontUnload();
            Set_P4 = bundle_Level.LoadAsset<Sprite>("Set_P4.png").DontUnload();
            Set_P5 = bundle_Level.LoadAsset<Sprite>("Set_P5.png").DontUnload();


            shop = bundle_Level.LoadAsset<Sprite>("shop.png").DontUnload();
            news = bundle_Level.LoadAsset<Sprite>("new.png").DontUnload();
            inner = bundle_Level.LoadAsset<Sprite>("inner.png").DontUnload();
            Inventory = bundle_Level.LoadAsset<Sprite>("Login_Inventory.png").DontUnload();
            settings = bundle_Level.LoadAsset<Sprite>("settings.png").DontUnload();
            stats = bundle_Level.LoadAsset<Sprite>("stats.png").DontUnload();

            LA1 = bundle_Level.LoadAsset<Sprite>("LA1.png").DontUnload();
            LA2 = bundle_Level.LoadAsset<Sprite>("LA2.png").DontUnload();
            LA3 = bundle_Level.LoadAsset<Sprite>("LA3.png").DontUnload();
            LA4 = bundle_Level.LoadAsset<Sprite>("LA4.png").DontUnload();
            LA5 = bundle_Level.LoadAsset<Sprite>("LA5.png").DontUnload();
            LA6 = bundle_Level.LoadAsset<Sprite>("LA6.png").DontUnload();
            LA7 = bundle_Level.LoadAsset<Sprite>("LA7.png").DontUnload();

            //UI2
            TB_PLAYER = bundle_Level.LoadAsset<Sprite>("LGLP.png").DontUnload();
            TB_PLAYER_FR = bundle_Level.LoadAsset<Sprite>("LGLPFR.png").DontUnload();
            TB_GL0 = bundle_Level.LoadAsset<Sprite>("LGL0.png").DontUnload();
            TB_GL0_FR = bundle_Level.LoadAsset<Sprite>("LGL0FR.png").DontUnload();
            TB_GL1 = bundle_Level.LoadAsset<Sprite>("LGL1.png").DontUnload();
            TB_GL1_FR = bundle_Level.LoadAsset<Sprite>("LGL1FR.png").DontUnload();
            CLUF = bundle_Level.LoadAsset<Sprite>("CLUF.png").DontUnload();
            CLUFFR = bundle_Level.LoadAsset<Sprite>("CLUFFR.png").DontUnload();
            UI2_GLProfil = bundle_Level.LoadAsset<Sprite>("RPMPR.png").DontUnload();
            TB_MAXPLAYER = bundle_Level.LoadAsset<Sprite>("LGLPLM.png").DontUnload();
            TB_MAXPLAYER_FR = bundle_Level.LoadAsset<Sprite>("LGLPLMFR.png").DontUnload();

            //MAPTAB
            EV_0_0 = bundle_Level.LoadAsset<Sprite>("EVENT0.png").DontUnload();
            EV_0_1 = bundle_Level.LoadAsset<Sprite>("EVENT0.png").DontUnload();
            EV_1_0 = bundle_Level.LoadAsset<Sprite>("EVENT1.png").DontUnload();
            EV_1_1 = bundle_Level.LoadAsset<Sprite>("EVENT1.png").DontUnload();
            EV_TAB = bundle_Level.LoadAsset<Sprite>("EVENTTAB.png").DontUnload();

            //UI2RTAB
            UI2_BTTN = bundle_Level.LoadAsset<Sprite>("PS4EN.png").DontUnload();
            UI2_BTTNFR = bundle_Level.LoadAsset<Sprite>("PS4FR.png").DontUnload();
            UI2_TAB = bundle_Level.LoadAsset<Sprite>("UIS2_RankedTab.png").DontUnload();

            UI2_PM10 = bundle_Level.LoadAsset<Sprite>("QTP10.png").DontUnload();
            UI2_PM11 = bundle_Level.LoadAsset<Sprite>("QTP11.png").DontUnload();
            UI2_PM12 = bundle_Level.LoadAsset<Sprite>("QTP12.png").DontUnload();
            UI2_PM13 = bundle_Level.LoadAsset<Sprite>("QTP13.png").DontUnload();
            UI2_PM14 = bundle_Level.LoadAsset<Sprite>("QTP14.png").DontUnload();
            UI2_PM15 = bundle_Level.LoadAsset<Sprite>("QTP15.png").DontUnload();

            UI2_PMADD0 = bundle_Level.LoadAsset<Sprite>("QTADD0.png").DontUnload();
            UI2_PMADD1 = bundle_Level.LoadAsset<Sprite>("QTADD1.png").DontUnload();
            UI2_PMREM0 = bundle_Level.LoadAsset<Sprite>("QTREM0.png").DontUnload();
            UI2_PMREM1 = bundle_Level.LoadAsset<Sprite>("QTREM1.png").DontUnload();

    

            UI2_10P0 = bundle_Level.LoadAsset<Sprite>("P100.png").DontUnload();
            UI2_10P1 = bundle_Level.LoadAsset<Sprite>("P101.png").DontUnload();
            UI2_11P0 = bundle_Level.LoadAsset<Sprite>("P110.png").DontUnload();
            UI2_11P1 = bundle_Level.LoadAsset<Sprite>("P111.png").DontUnload();
            UI2_12P0 = bundle_Level.LoadAsset<Sprite>("P120.png").DontUnload();
            UI2_12P1 = bundle_Level.LoadAsset<Sprite>("P121.png").DontUnload();
            UI2_13P0 = bundle_Level.LoadAsset<Sprite>("P130.png").DontUnload();
            UI2_13P1 = bundle_Level.LoadAsset<Sprite>("P131.png").DontUnload();
            UI2_14P0 = bundle_Level.LoadAsset<Sprite>("P140.png").DontUnload();
            UI2_14P1 = bundle_Level.LoadAsset<Sprite>("P141.png").DontUnload();
            UI2_15P0 = bundle_Level.LoadAsset<Sprite>("P150.png").DontUnload();
            UI2_15P1 = bundle_Level.LoadAsset<Sprite>("P151.png").DontUnload();

            UI2_SPE = bundle_Level.LoadAsset<Sprite>("SPE.png").DontUnload();
            UI2_IMP = bundle_Level.LoadAsset<Sprite>("IMP.png").DontUnload();
            UI2_DUO = bundle_Level.LoadAsset<Sprite>("DUO.png").DontUnload();

            UI2_0N0 = bundle_Level.LoadAsset<Sprite>("QT00.png").DontUnload();
            UI2_0N1 = bundle_Level.LoadAsset<Sprite>("QT01.png").DontUnload();
            UI2_1N0 = bundle_Level.LoadAsset<Sprite>("QT10.png").DontUnload();
            UI2_1N1 = bundle_Level.LoadAsset<Sprite>("QT11.png").DontUnload();
            UI2_2N0 = bundle_Level.LoadAsset<Sprite>("QT20.png").DontUnload();
            UI2_2N1 = bundle_Level.LoadAsset<Sprite>("QT21.png").DontUnload();
            UI2_3N0 = bundle_Level.LoadAsset<Sprite>("QT30.png").DontUnload();
            UI2_3N1 = bundle_Level.LoadAsset<Sprite>("QT31.png").DontUnload();
            UI2_4N0 = bundle_Level.LoadAsset<Sprite>("QT40.png").DontUnload();
            UI2_4N1 = bundle_Level.LoadAsset<Sprite>("QT41.png").DontUnload();
            UI2_5N0 = bundle_Level.LoadAsset<Sprite>("QT50.png").DontUnload();
            UI2_5N1 = bundle_Level.LoadAsset<Sprite>("QT51.png").DontUnload();
            UI2_6N0 = bundle_Level.LoadAsset<Sprite>("QT60.png").DontUnload();
            UI2_6N1 = bundle_Level.LoadAsset<Sprite>("QT61.png").DontUnload();
            UI2_NUMBER_LOCK = bundle_Level.LoadAsset<Sprite>("QTL.png").DontUnload();



            UI2_Polus0 = bundle_Level.LoadAsset<Sprite>("POLUS0.png").DontUnload();
            UI2_Polus1 = bundle_Level.LoadAsset<Sprite>("POLUS1.png").DontUnload();
            UI2_Bpolus0 = bundle_Level.LoadAsset<Sprite>("BPOLUS0.png").DontUnload();
            UI2_Bpolus1 = bundle_Level.LoadAsset<Sprite>("BPOLUS1.png").DontUnload();
            UI2_Cpolus0 = bundle_Level.LoadAsset<Sprite>("CPOLUS0.png").DontUnload();
            UI2_Cpolus1 = bundle_Level.LoadAsset<Sprite>("CPOLUS1.png").DontUnload();
            UI2_Npolus0 = bundle_Level.LoadAsset<Sprite>("NPOLUS0.png").DontUnload();
            UI2_Npolus1 = bundle_Level.LoadAsset<Sprite>("NPOLUS1.png").DontUnload();
            UI2_Skeld0 = bundle_Level.LoadAsset<Sprite>("SKELD0.png").DontUnload();
            UI2_Skeld1 = bundle_Level.LoadAsset<Sprite>("SKELD1.png").DontUnload();
            UI2_Csleld0 = bundle_Level.LoadAsset<Sprite>("CSKELD0.png").DontUnload();
            UI2_Cskeld1 = bundle_Level.LoadAsset<Sprite>("CSKELD1.png").DontUnload();
            UI2_Mira0 = bundle_Level.LoadAsset<Sprite>("MIRA0.png").DontUnload();
            UI2_Mira1 = bundle_Level.LoadAsset<Sprite>("MIRA1.png").DontUnload();
            UI2_Cmira0 = bundle_Level.LoadAsset<Sprite>("CMIRA0.png").DontUnload();
            UI2_Cmira1 = bundle_Level.LoadAsset<Sprite>("CMIRA1.png").DontUnload();
            UI2_Airship0 = bundle_Level.LoadAsset<Sprite>("Airship0.png").DontUnload();
            UI2_Airship1 = bundle_Level.LoadAsset<Sprite>("Airship1.png").DontUnload();
            UI2_Sub0 = bundle_Level.LoadAsset<Sprite>("SUBMERGED0.png").DontUnload();
            UI2_Sub1 = bundle_Level.LoadAsset<Sprite>("SUBMERGED1.png").DontUnload();


            UI2_ROLE_LOCK = bundle_Level.LoadAsset<Sprite>("RL.png").DontUnload();

            UI2_Sheriff0 = bundle_Level.LoadAsset<Sprite>("Sheriff0.png").DontUnload();
            UI2_Sheriff1 = bundle_Level.LoadAsset<Sprite>("Sheriff1.png").DontUnload();
            UI2_Guardian0 = bundle_Level.LoadAsset<Sprite>("Guardian0.png").DontUnload();
            UI2_Guardian1 = bundle_Level.LoadAsset<Sprite>("Guardian1.png").DontUnload();
            UI2_Engineer0 = bundle_Level.LoadAsset<Sprite>("Engineer0.png").DontUnload();
            UI2_Engineer1 = bundle_Level.LoadAsset<Sprite>("Engineer1.png").DontUnload();
            UI2_Timelord0 = bundle_Level.LoadAsset<Sprite>("Timelord0.png").DontUnload();
            UI2_Timelord1 = bundle_Level.LoadAsset<Sprite>("Timelord1.png").DontUnload();
            UI2_Hunter0 = bundle_Level.LoadAsset<Sprite>("Hunter0.png").DontUnload();
            UI2_Hunter1 = bundle_Level.LoadAsset<Sprite>("Hunter1.png").DontUnload();
            UI2_Mystic0 = bundle_Level.LoadAsset<Sprite>("Mystic0.png").DontUnload();
            UI2_Mystic1 = bundle_Level.LoadAsset<Sprite>("Mystic1.png").DontUnload();
            UI2_Spirit0 = bundle_Level.LoadAsset<Sprite>("Spirit0.png").DontUnload();
            UI2_Spirit1 = bundle_Level.LoadAsset<Sprite>("Spirit1.png").DontUnload();
            UI2_Mayor0 = bundle_Level.LoadAsset<Sprite>("Mayor0.png").DontUnload();
            UI2_Mayor1 = bundle_Level.LoadAsset<Sprite>("Mayor1.png").DontUnload();
            UI2_Detective0 = bundle_Level.LoadAsset<Sprite>("Detective0.png").DontUnload();
            UI2_Detective1 = bundle_Level.LoadAsset<Sprite>("Detective1.png").DontUnload();
            UI2_Nightwatch0 = bundle_Level.LoadAsset<Sprite>("Nightwatch0.png").DontUnload();
            UI2_Nightwatch1 = bundle_Level.LoadAsset<Sprite>("Nightwatch1.png").DontUnload();
            UI2_Spy0 = bundle_Level.LoadAsset<Sprite>("Spy0.png").DontUnload();
            UI2_Spy1 = bundle_Level.LoadAsset<Sprite>("Spy1.png").DontUnload();
            UI2_Informant0 = bundle_Level.LoadAsset<Sprite>("Informant0.png").DontUnload();
            UI2_Informant1 = bundle_Level.LoadAsset<Sprite>("Informant1.png").DontUnload();
            UI2_Bait0 = bundle_Level.LoadAsset<Sprite>("Bait0.png").DontUnload();
            UI2_Bait1 = bundle_Level.LoadAsset<Sprite>("Bait1.png").DontUnload();
            UI2_Mentalist0 = bundle_Level.LoadAsset<Sprite>("Mentalist0.png").DontUnload();
            UI2_Mentalist1 = bundle_Level.LoadAsset<Sprite>("Mentalist1.png").DontUnload();
            UI2_Builder0 = bundle_Level.LoadAsset<Sprite>("Builder0.png").DontUnload();
            UI2_Builder1 = bundle_Level.LoadAsset<Sprite>("Builder1.png").DontUnload();
            UI2_Dictator0 = bundle_Level.LoadAsset<Sprite>("Dictator0.png").DontUnload();
            UI2_Dictator1 = bundle_Level.LoadAsset<Sprite>("Dictator1.png").DontUnload();
            UI2_Sentinel0 = bundle_Level.LoadAsset<Sprite>("Sentinel0.png").DontUnload();
            UI2_Sentinel1 = bundle_Level.LoadAsset<Sprite>("Sentinel1.png").DontUnload();
            UI2_Teammate0 = bundle_Level.LoadAsset<Sprite>("Teammate0.png").DontUnload();
            UI2_Teammate1 = bundle_Level.LoadAsset<Sprite>("Teammate1.png").DontUnload();
            UI2_Lawkeeper0 = bundle_Level.LoadAsset<Sprite>("Lawkeeper0.png").DontUnload();
            UI2_Lawkeeper1 = bundle_Level.LoadAsset<Sprite>("Lawkeeper1.png").DontUnload();
            UI2_Fake0 = bundle_Level.LoadAsset<Sprite>("Fake0.png").DontUnload();
            UI2_Fake1 = bundle_Level.LoadAsset<Sprite>("Fake1.png").DontUnload();
            UI2_Leader0 = bundle_Level.LoadAsset<Sprite>("Leader0.png").DontUnload();
            UI2_Leader1 = bundle_Level.LoadAsset<Sprite>("Leader1.png").DontUnload();

            UI2_Mercenary0 = bundle_Level.LoadAsset<Sprite>("Mercenary0.png").DontUnload();
            UI2_Mercenary1 = bundle_Level.LoadAsset<Sprite>("Mercenary1.png").DontUnload();
            UI2_CopyCat0 = bundle_Level.LoadAsset<Sprite>("Copycat0.png").DontUnload();
            UI2_CopyCat1 = bundle_Level.LoadAsset<Sprite>("Copycat1.png").DontUnload();
            UI2_Revenger0 = bundle_Level.LoadAsset<Sprite>("Revenger0.png").DontUnload();
            UI2_Revenger1 = bundle_Level.LoadAsset<Sprite>("Revenger1.png").DontUnload();
            UI2_Survivor0 = bundle_Level.LoadAsset<Sprite>("Survivor0.png").DontUnload();
            UI2_Survivor1 = bundle_Level.LoadAsset<Sprite>("Survivor1.png").DontUnload();

            UI2_Cupid0 = bundle_Level.LoadAsset<Sprite>("Cupid0.png").DontUnload();
            UI2_Cupid1 = bundle_Level.LoadAsset<Sprite>("Cupid1.png").DontUnload();
            UI2_Cultist0 = bundle_Level.LoadAsset<Sprite>("Cultist0.png").DontUnload();
            UI2_Cultist1 = bundle_Level.LoadAsset<Sprite>("Cultist1.png").DontUnload();
            UI2_Jester0 = bundle_Level.LoadAsset<Sprite>("Jester0.png").DontUnload();
            UI2_Jester1 = bundle_Level.LoadAsset<Sprite>("Jester1.png").DontUnload();
            UI2_Eater0 = bundle_Level.LoadAsset<Sprite>("Eater0.png").DontUnload();
            UI2_Eater1 = bundle_Level.LoadAsset<Sprite>("Eater1.png").DontUnload();
            UI2_Outlaw0 = bundle_Level.LoadAsset<Sprite>("Outlaw0.png").DontUnload();
            UI2_Outlaw1 = bundle_Level.LoadAsset<Sprite>("Outlaw1.png").DontUnload();
            UI2_Arsonist0 = bundle_Level.LoadAsset<Sprite>("Arsonist0.png").DontUnload();
            UI2_Arsonist1 = bundle_Level.LoadAsset<Sprite>("Arsonist1.png").DontUnload();
            UI2_Cursed0 = bundle_Level.LoadAsset<Sprite>("Cursed0.png").DontUnload();
            UI2_Cursed1 = bundle_Level.LoadAsset<Sprite>("Cursed1.png").DontUnload();

            UI2_Assassin0 = bundle_Level.LoadAsset<Sprite>("Assassin0.png").DontUnload();
            UI2_Assassin1 = bundle_Level.LoadAsset<Sprite>("Assassin1.png").DontUnload();
            UI2_Vector0 = bundle_Level.LoadAsset<Sprite>("Vector0.png").DontUnload();
            UI2_Vector1 = bundle_Level.LoadAsset<Sprite>("Vector1.png").DontUnload();
            UI2_Morphling0 = bundle_Level.LoadAsset<Sprite>("Morphling0.png").DontUnload();
            UI2_Morphling1 = bundle_Level.LoadAsset<Sprite>("Morphling1.png").DontUnload();
            UI2_Scrambler0 = bundle_Level.LoadAsset<Sprite>("Scrambler0.png").DontUnload();
            UI2_Scrambler1 = bundle_Level.LoadAsset<Sprite>("Scrambler1.png").DontUnload();
            UI2_Barghest0 = bundle_Level.LoadAsset<Sprite>("Barghest0.png").DontUnload();
            UI2_Barghest1 = bundle_Level.LoadAsset<Sprite>("Barghest1.png").DontUnload();
            UI2_Ghost0 = bundle_Level.LoadAsset<Sprite>("Ghost0.png").DontUnload();
            UI2_Ghost1 = bundle_Level.LoadAsset<Sprite>("Ghost1.png").DontUnload();
            UI2_Sorcerer0 = bundle_Level.LoadAsset<Sprite>("Sorcerer0.png").DontUnload();
            UI2_Sorcerer1 = bundle_Level.LoadAsset<Sprite>("Sorcerer1.png").DontUnload();
            UI2_Guesser0 = bundle_Level.LoadAsset<Sprite>("Guesser0.png").DontUnload();
            UI2_Guesser1 = bundle_Level.LoadAsset<Sprite>("Guesser1.png").DontUnload();
            UI2_Basilisk0 = bundle_Level.LoadAsset<Sprite>("Basilisk0.png").DontUnload();
            UI2_Basilisk1 = bundle_Level.LoadAsset<Sprite>("Basilisk0.png").DontUnload();






            REPLACE_ME1 = bundle_Level.LoadAsset<Sprite>("Replace36095.png").DontUnload();
            REPLACE_ME2 = bundle_Level.LoadAsset<Sprite>("RPM.png").DontUnload();
            UI2_PlayNormal = bundle_Level.LoadAsset<Sprite>("RPM.png").DontUnload();
            UI2_CreateGame = bundle_Level.LoadAsset<Sprite>("RPM3.png").DontUnload();
            UI2_CreateCancel = bundle_Level.LoadAsset<Sprite>("RPM4.png").DontUnload();
            UI2_MainMenu = bundle_Level.LoadAsset<Sprite>("RPM6.png").DontUnload();
            UI2_CreateConfirm = bundle_Level.LoadAsset<Sprite>("RPM5.png").DontUnload();
            UI2_EnterCode = bundle_Level.LoadAsset<Sprite>("RPM7.png").DontUnload();
            UI2_FindGameOn = bundle_Level.LoadAsset<Sprite>("RPM8.png").DontUnload();
            UI2_FindGameOff = bundle_Level.LoadAsset<Sprite>("RPM80.png").DontUnload();
            UI2_PlayRanked = bundle_Level.LoadAsset<Sprite>("RPM2.png").DontUnload();
            UI2_GLLogin = bundle_Level.LoadAsset<Sprite>("RPM1.png").DontUnload();
            DiscordJoin = bundle_Level.LoadAsset<Sprite>("RMP0.png").DontUnload();
            UI2_GLCreate = bundle_Level.LoadAsset<Sprite>("RPMA0.png").DontUnload();
            GLLog1 = bundle_Level.LoadAsset<Sprite>("RPMA1.png").DontUnload();
            UI2_PlayNormalFR = bundle_Level.LoadAsset<Sprite>("RPM_FR.png").DontUnload();
            UI2_CreateGameFR = bundle_Level.LoadAsset<Sprite>("RPM3_FR.png").DontUnload();
            UI2_CreateCancelFR = bundle_Level.LoadAsset<Sprite>("RPM4_FR.png").DontUnload();
            UI2_MainMenuFR = bundle_Level.LoadAsset<Sprite>("RPM6_FR.png").DontUnload();
            UI2_CreateConfirmFR = bundle_Level.LoadAsset<Sprite>("RPM5_FR.png").DontUnload();
            UI2_EnterCodeFR = bundle_Level.LoadAsset<Sprite>("RPM7_FR.png").DontUnload();
            UI2_FindGameOnFR = bundle_Level.LoadAsset<Sprite>("RPM8FR.png").DontUnload();
            UI2_FindGameOffFR = bundle_Level.LoadAsset<Sprite>("RPM80FR.png").DontUnload();
            UI2_PlayRankedFR = bundle_Level.LoadAsset<Sprite>("RPM2_FR.png").DontUnload();
            StartGameR0_FR = bundle_Level.LoadAsset<Sprite>("RPM1_FR.png").DontUnload();
            UI2_GLLoginFR = bundle_Level.LoadAsset<Sprite>("RPMA0_FR.png").DontUnload();
            GLLog1_FR = bundle_Level.LoadAsset<Sprite>("RPMA1_FR.png").DontUnload();
            R_Button_FR = bundle_Level.LoadAsset<Sprite>("BTTRFR.png").DontUnload();
            R_Button_EN = bundle_Level.LoadAsset<Sprite>("BTTR.png").DontUnload();

            IRKnone = bundle_Level.LoadAsset<Sprite>("RKnone.png").DontUnload();
            IRKFree = bundle_Level.LoadAsset<Sprite>("RKFree.png").DontUnload();
            IRKarsonist = bundle_Level.LoadAsset<Sprite>("RKarsonist.png").DontUnload();
            IRKarsonist0 = bundle_Level.LoadAsset<Sprite>("RKarsonist0.png").DontUnload();
            IRKoutlaw = bundle_Level.LoadAsset<Sprite>("RKoutlaw.png").DontUnload();
            IRKoutlaw0 = bundle_Level.LoadAsset<Sprite>("RKoutlaw0.png").DontUnload();
            IRKjester = bundle_Level.LoadAsset<Sprite>("RKjester.png").DontUnload();
            IRKjester0 = bundle_Level.LoadAsset<Sprite>("RKjester0.png").DontUnload();
            IRKeat = bundle_Level.LoadAsset<Sprite>("RKeat.png").DontUnload();
            IRKeat0 = bundle_Level.LoadAsset<Sprite>("RKeat0.png").DontUnload();
            IRKcupid = bundle_Level.LoadAsset<Sprite>("RKcupid.png").DontUnload();
            IRKcupid0 = bundle_Level.LoadAsset<Sprite>("RKcupid0.png").DontUnload();
            IRKculte = bundle_Level.LoadAsset<Sprite>("RKculte.png").DontUnload();
            IRKculte0 = bundle_Level.LoadAsset<Sprite>("RKculte0.png").DontUnload();
            IRKLite = bundle_Level.LoadAsset<Sprite>("RKLite.png").DontUnload();
            IRKLite0 = bundle_Level.LoadAsset<Sprite>("RKLite0.png").DontUnload();
            IRKvanilla = bundle_Level.LoadAsset<Sprite>("RKvanilla.png").DontUnload();
            IRKvanilla0 = bundle_Level.LoadAsset<Sprite>("RKvanilla0.png").DontUnload();
            IRKuknow = bundle_Level.LoadAsset<Sprite>("RKuknow.png").DontUnload();
            IRKuknow0 = bundle_Level.LoadAsset<Sprite>("RKuknow0.png").DontUnload();
            RBvanilla = bundle_Level.LoadAsset<Sprite>("RKBanner_Vanilla.png").DontUnload();
            RBlite = bundle_Level.LoadAsset<Sprite>("RKBanner_Lite.png").DontUnload();
            RBuknow = bundle_Level.LoadAsset<Sprite>("RKBanner_Tryhard.png").DontUnload();
            RBjester = bundle_Level.LoadAsset<Sprite>("RKBanner_Jester.png").DontUnload();
            RBeater = bundle_Level.LoadAsset<Sprite>("RKBanner_Eater.png").DontUnload();
            RBcupid = bundle_Level.LoadAsset<Sprite>("RKBanner_Cupid.png").DontUnload();
            RBcultist = bundle_Level.LoadAsset<Sprite>("RKBanner_Culte.png").DontUnload();
            RBoutlaw = bundle_Level.LoadAsset<Sprite>("RKBanner_Outlaw.png").DontUnload();
            RBarsonist = bundle_Level.LoadAsset<Sprite>("RKBanner_Arsonist.png").DontUnload();
            RBFree = bundle_Level.LoadAsset<Sprite>("RKBanner_Free.png").DontUnload();
            RBvanillaFR = bundle_Level.LoadAsset<Sprite>("RKBanner_VanillaFR.png").DontUnload();
            RBliteFR = bundle_Level.LoadAsset<Sprite>("RKBanner_LiteFR.png").DontUnload();
            RBuknowFR = bundle_Level.LoadAsset<Sprite>("RKBanner_TryhardFR.png").DontUnload();
            RBjesterFR = bundle_Level.LoadAsset<Sprite>("RKBanner_JesterFR.png").DontUnload();
            RBeaterFR = bundle_Level.LoadAsset<Sprite>("RKBanner_EaterFR.png").DontUnload();
            RBcupidFR = bundle_Level.LoadAsset<Sprite>("RKBanner_CupidFR.png").DontUnload();
            RBcultistFR = bundle_Level.LoadAsset<Sprite>("RKBanner_CulteFR.png").DontUnload();
            RBoutlawFR = bundle_Level.LoadAsset<Sprite>("RKBanner_OutlawFR.png").DontUnload();
            RBarsonistFR = bundle_Level.LoadAsset<Sprite>("RKBanner_ArsonistFR.png").DontUnload();
            RBFreeFR = bundle_Level.LoadAsset<Sprite>("RKBanner_FreeFR.png").DontUnload();

            ColorLock = bundle_Level.LoadAsset<Sprite>("ColorLock.png").DontUnload();
            ColorUnlock = bundle_Level.LoadAsset<Sprite>("ColorLock2.png").DontUnload();

            playbtt = bundle_Level.LoadAsset<Sprite>("play.png").DontUnload();
            serverbtt = bundle_Level.LoadAsset<Sprite>("server.png").DontUnload();
            btt1 = bundle_Level.LoadAsset<Sprite>("button.png").DontUnload();
            btt2 = bundle_Level.LoadAsset<Sprite>("ButtonL.png").DontUnload();

            LoginBanner = bundle_Level.LoadAsset<Sprite>("CH_Main.png").DontUnload();
            LoginBannerSc2 = bundle_Level.LoadAsset<Sprite>("CH_MMOnline.png").DontUnload();
            LoginBannerSc2R = bundle_Level.LoadAsset<Sprite>("CH_MMOnlineR.png").DontUnload();
            LoginBannerMini = bundle_Level.LoadAsset<Sprite>("bannermini.png").DontUnload();


            // --------------- Char


            // --------------- Ranked

            Rank_B3 = bundle_Ranked.LoadAsset<Sprite>("Rank_B3.png").DontUnload();
            Rank_B2 = bundle_Ranked.LoadAsset<Sprite>("Rank_B2.png").DontUnload();
            Rank_B1 = bundle_Ranked.LoadAsset<Sprite>("Rank_B1.png").DontUnload();
            Rank_S3 = bundle_Ranked.LoadAsset<Sprite>("Rank_S3.png").DontUnload();
            Rank_S2 = bundle_Ranked.LoadAsset<Sprite>("Rank_S2.png").DontUnload();
            Rank_S1 = bundle_Ranked.LoadAsset<Sprite>("Rank_S1.png").DontUnload();
            Rank_G3 = bundle_Ranked.LoadAsset<Sprite>("Rank_G3.png").DontUnload();
            Rank_G2 = bundle_Ranked.LoadAsset<Sprite>("Rank_G2.png").DontUnload();
            Rank_G1 = bundle_Ranked.LoadAsset<Sprite>("Rank_G1.png").DontUnload();
            Rank_P3 = bundle_Ranked.LoadAsset<Sprite>("Rank_P3.png").DontUnload();
            Rank_P2 = bundle_Ranked.LoadAsset<Sprite>("Rank_P2.png").DontUnload();
            Rank_P1 = bundle_Ranked.LoadAsset<Sprite>("Rank_P1.png").DontUnload();
            Rank_D = bundle_Ranked.LoadAsset<Sprite>("Rank_D.png").DontUnload();
            Rank_M = bundle_Ranked.LoadAsset<Sprite>("Rank_M.png").DontUnload();
            Rank_0 = bundle_Ranked.LoadAsset<Sprite>("Rank_0.png").DontUnload();

            // --------------- Sprite

            cam0 = bundle_Sprite.LoadAsset<Sprite>("cam0.png").DontUnload();
            cam1 = bundle_Sprite.LoadAsset<Sprite>("cam1.png").DontUnload();
            Vitale0 = bundle_Sprite.LoadAsset<Sprite>("Vitale0.png").DontUnload();
            Vitale1 = bundle_Sprite.LoadAsset<Sprite>("Vitale1.png").DontUnload();
            admin0 = bundle_Sprite.LoadAsset<Sprite>("admin0.png").DontUnload();
            admin1 = bundle_Sprite.LoadAsset<Sprite>("admin1.png").DontUnload();
            buzz0 = bundle_Sprite.LoadAsset<Sprite>("buzz0.png").DontUnload();
            buzz1 = bundle_Sprite.LoadAsset<Sprite>("buzz1.png").DontUnload();

            RU1 = bundle_Sprite.LoadAsset<Sprite>("Ru1.png").DontUnload();
            RU2 = bundle_Sprite.LoadAsset<Sprite>("Ru2.png").DontUnload();
            RU3 = bundle_Sprite.LoadAsset<Sprite>("Ru3.png").DontUnload();
            RU4 = bundle_Sprite.LoadAsset<Sprite>("Ru4.png").DontUnload();
            RU5 = bundle_Sprite.LoadAsset<Sprite>("Ru5.png").DontUnload();
            RU6 = bundle_Sprite.LoadAsset<Sprite>("Ru6.png").DontUnload();
            RU7 = bundle_Sprite.LoadAsset<Sprite>("Ru7.png").DontUnload();
            RU8 = bundle_Sprite.LoadAsset<Sprite>("Ru8.png").DontUnload();
            RU9 = bundle_Sprite.LoadAsset<Sprite>("Ru9.png").DontUnload();
            RU10 = bundle_Sprite.LoadAsset<Sprite>("Ru10.png").DontUnload();
            RU11 = bundle_Sprite.LoadAsset<Sprite>("Ru11.png").DontUnload();
            RU12 = bundle_Sprite.LoadAsset<Sprite>("Ru12.png").DontUnload();
            RU0 = bundle_Sprite.LoadAsset<Sprite>("Ru0.png").DontUnload();
            RUX = bundle_Sprite.LoadAsset<Sprite>("Ru13.png").DontUnload();

            Rune1 = bundle_Sprite.LoadAsset<Sprite>("rune1.png").DontUnload();
            Rune2 = bundle_Sprite.LoadAsset<Sprite>("rune2.png").DontUnload();
            Rune3 = bundle_Sprite.LoadAsset<Sprite>("rune3.png").DontUnload();
            Rune4 = bundle_Sprite.LoadAsset<Sprite>("rune4.png").DontUnload();
            Rune5 = bundle_Sprite.LoadAsset<Sprite>("rune5.png").DontUnload();
            Rune6 = bundle_Sprite.LoadAsset<Sprite>("rune6.png").DontUnload();
            Rune7 = bundle_Sprite.LoadAsset<Sprite>("rune7.png").DontUnload();
            Rune8 = bundle_Sprite.LoadAsset<Sprite>("rune8.png").DontUnload();
            Rune9 = bundle_Sprite.LoadAsset<Sprite>("rune9.png").DontUnload();
            Rune10 = bundle_Sprite.LoadAsset<Sprite>("rune10.png").DontUnload();
            Rune11 = bundle_Sprite.LoadAsset<Sprite>("rune11.png").DontUnload();
            Rune12 = bundle_Sprite.LoadAsset<Sprite>("rune12.png").DontUnload();

            RoleINF = bundle_Sprite.LoadAsset<Sprite>("roleinfos.png").DontUnload();

            SheriffGun = bundle_Sprite.LoadAsset<Sprite>("SheriffGun.png").DontUnload();
            repairIco = bundle_Sprite.LoadAsset<Sprite>("Engineerrepair.png").DontUnload();
            ventmapIco = bundle_Sprite.LoadAsset<Sprite>("ventTP3.png").DontUnload();
            NewVent = bundle_Sprite.LoadAsset<Sprite>("NewVent.png").DontUnload();

            createventIco = bundle_Sprite.LoadAsset<Sprite>("createvent.png").DontUnload();
            shieldIco = bundle_Sprite.LoadAsset<Sprite>("Guardianshield.png").DontUnload();
            stopIco = bundle_Sprite.LoadAsset<Sprite>("TimeLordBreak.png").DontUnload();
            trackIco = bundle_Sprite.LoadAsset<Sprite>("Huntertrack.png").DontUnload();
            KillSherifIco = bundle_Sprite.LoadAsset<Sprite>("Sherifkill.png").DontUnload();
            KillSherifIco2 = bundle_Sprite.LoadAsset<Sprite>("Sherifkill2.png").DontUnload();
            reviveIco = bundle_Sprite.LoadAsset<Sprite>("revive.png").DontUnload();
            KillMercenaryIco = bundle_Sprite.LoadAsset<Sprite>("Mercenarykill.png").DontUnload();
            KillMercenaryIco2 = bundle_Sprite.LoadAsset<Sprite>("Mercenarykill2.png").DontUnload();
            KillAssassinIco = bundle_Sprite.LoadAsset<Sprite>("Assassinkill.png").DontUnload();
            KillAssassinIco2 = bundle_Sprite.LoadAsset<Sprite>("Assassinkill2.png").DontUnload();
            KillSlayerIco = bundle_Sprite.LoadAsset<Sprite>("SlayerKill.png").DontUnload();
            KillSlayerIco2 = bundle_Sprite.LoadAsset<Sprite>("SlayerKill2.png").DontUnload();
            slayerIco = bundle_Sprite.LoadAsset<Sprite>("SlayerBuff.png").DontUnload();
            slayerIco2 = bundle_Sprite.LoadAsset<Sprite>("SlayerBuff2.png").DontUnload();

            love1Ico = bundle_Sprite.LoadAsset<Sprite>("love1.png").DontUnload();
            love2Ico = bundle_Sprite.LoadAsset<Sprite>("love2.png").DontUnload();
            loveIco = bundle_Sprite.LoadAsset<Sprite>("love0.png").DontUnload();
            noloveIco = bundle_Sprite.LoadAsset<Sprite>("nolove.png").DontUnload();
            miniloveIco = bundle_Sprite.LoadAsset<Sprite>("MakeLover.png").DontUnload();
            MakeVoterIco = bundle_Sprite.LoadAsset<Sprite>("MakeVoter.png").DontUnload();
            fakeIco = bundle_Sprite.LoadAsset<Sprite>("Fakekill.png").DontUnload();
            KillWarlockIco = bundle_Sprite.LoadAsset<Sprite>("war0.png").DontUnload();

            BarghestKillIco = bundle_Sprite.LoadAsset<Sprite>("BarghestKill.png").DontUnload();
            BarghestKillIco2 = bundle_Sprite.LoadAsset<Sprite>("BarghestKill2.png").DontUnload();

            OutlawKill = bundle_Sprite.LoadAsset<Sprite>("outlawkill.png").DontUnload();
            OutlawKill2 = bundle_Sprite.LoadAsset<Sprite>("outlawkill2.png").DontUnload();

            Outlaw0 = bundle_Sprite.LoadAsset<Sprite>("outoff.png").DontUnload();
            Outlaw1 = bundle_Sprite.LoadAsset<Sprite>("outon.png").DontUnload();
            Hideico = bundle_Sprite.LoadAsset<Sprite>("MesmerHide.png").DontUnload();
            mysticIco = bundle_Sprite.LoadAsset<Sprite>("Mystic.png").DontUnload();
            sorcererprezIco = bundle_Sprite.LoadAsset<Sprite>("sorcererprez.png").DontUnload();
            KillSorcererIco = bundle_Sprite.LoadAsset<Sprite>("SorcererKill.png").DontUnload();
            SorcererIco1 = bundle_Sprite.LoadAsset<Sprite>("SSorcerer1.png").DontUnload();
            SorcererIco2 = bundle_Sprite.LoadAsset<Sprite>("SSorcerer2.png").DontUnload();
            SorcererIco3 = bundle_Sprite.LoadAsset<Sprite>("SSorcerer3.png").DontUnload();
            NightwatchIco = bundle_Sprite.LoadAsset<Sprite>("light.png").DontUnload();
            MapIco = bundle_Sprite.LoadAsset<Sprite>("MapIco.png").DontUnload();
            SpyIco = bundle_Sprite.LoadAsset<Sprite>("SpyIco.png").DontUnload();
            ShadowIco = bundle_Sprite.LoadAsset<Sprite>("shadow.png").DontUnload();
            CamoIco = bundle_Sprite.LoadAsset<Sprite>("CamoHide.png").DontUnload();
            IkillIco = bundle_Sprite.LoadAsset<Sprite>("Kill.png").DontUnload();
            IkillIco2 = bundle_Sprite.LoadAsset<Sprite>("Kill2.png").DontUnload();
            MorphIco = bundle_Sprite.LoadAsset<Sprite>("Morph.png").DontUnload();
            ScanIco = bundle_Sprite.LoadAsset<Sprite>("Scan.png").DontUnload();
            FPrint = bundle_Sprite.LoadAsset<Sprite>("Mark.png").DontUnload();
            HPrint = bundle_Sprite.LoadAsset<Sprite>("HMark.png").DontUnload();
            DetectiveIco = bundle_Sprite.LoadAsset<Sprite>("DetectiveIco.png").DontUnload();
            VengerIco = bundle_Sprite.LoadAsset<Sprite>("VengerIco.png").DontUnload();
            InforIco = bundle_Sprite.LoadAsset<Sprite>("Infor.png").DontUnload();
            MayorIco = bundle_Sprite.LoadAsset<Sprite>("buzzer.png").DontUnload();
            EaterIco = bundle_Sprite.LoadAsset<Sprite>("EaterIco.png").DontUnload();
            EaterIco2 = bundle_Sprite.LoadAsset<Sprite>("EaterIco2.png").DontUnload();
            ArrowWarn = bundle_Sprite.LoadAsset<Sprite>("ArrowWarn.png").DontUnload();

            MindIco = bundle_Sprite.LoadAsset<Sprite>("mindIco.png").DontUnload();
            E0 = bundle_Sprite.LoadAsset<Sprite>("E0.png").DontUnload();
            E1 = bundle_Sprite.LoadAsset<Sprite>("E1.png").DontUnload();
            E2 = bundle_Sprite.LoadAsset<Sprite>("E2.png").DontUnload();
            E3 = bundle_Sprite.LoadAsset<Sprite>("E3.png").DontUnload();
            E4 = bundle_Sprite.LoadAsset<Sprite>("E4.png").DontUnload();
            E5 = bundle_Sprite.LoadAsset<Sprite>("E5.png").DontUnload();
            E6 = bundle_Sprite.LoadAsset<Sprite>("E6.png").DontUnload();
            E7 = bundle_Sprite.LoadAsset<Sprite>("E7.png").DontUnload();
            E8 = bundle_Sprite.LoadAsset<Sprite>("E8.png").DontUnload();
            E9 = bundle_Sprite.LoadAsset<Sprite>("E9.png").DontUnload();
            E10 = bundle_Sprite.LoadAsset<Sprite>("E10.png").DontUnload();
            BloodIco = bundle_Sprite.LoadAsset<Sprite>("blood.png").DontUnload();
            DragIco = bundle_Sprite.LoadAsset<Sprite>("dragIco.png").DontUnload();

            CB0 = bundle_Sprite.LoadAsset<Sprite>("CB0.png").DontUnload();
            CB1 = bundle_Sprite.LoadAsset<Sprite>("CB1.png").DontUnload();
            CB2 = bundle_Sprite.LoadAsset<Sprite>("CB2.png").DontUnload();
            CB3 = bundle_Sprite.LoadAsset<Sprite>("CB3.png").DontUnload();
            CB4 = bundle_Sprite.LoadAsset<Sprite>("CB4.png").DontUnload();
            CB5 = bundle_Sprite.LoadAsset<Sprite>("CB5.png").DontUnload();
            CB6 = bundle_Sprite.LoadAsset<Sprite>("CB6.png").DontUnload();
            CB7 = bundle_Sprite.LoadAsset<Sprite>("CB7.png").DontUnload();
            CB8 = bundle_Sprite.LoadAsset<Sprite>("CB8.png").DontUnload();
            CB9 = bundle_Sprite.LoadAsset<Sprite>("CB9.png").DontUnload();
            CB10 = bundle_Sprite.LoadAsset<Sprite>("CB10.png").DontUnload();
            CB11 = bundle_Sprite.LoadAsset<Sprite>("CB11.png").DontUnload();
            CB12 = bundle_Sprite.LoadAsset<Sprite>("CB12.png").DontUnload();
            CB13 = bundle_Sprite.LoadAsset<Sprite>("CB13.png").DontUnload();
            CB14 = bundle_Sprite.LoadAsset<Sprite>("CB14.png").DontUnload();
            CB15 = bundle_Sprite.LoadAsset<Sprite>("CB15.png").DontUnload();
            CB16 = bundle_Sprite.LoadAsset<Sprite>("CB16.png").DontUnload();
            CB17 = bundle_Sprite.LoadAsset<Sprite>("CB17.png").DontUnload();
            CB18 = bundle_Sprite.LoadAsset<Sprite>("CB18.png").DontUnload();
            CB19 = bundle_Sprite.LoadAsset<Sprite>("CB19.png").DontUnload();
            CB20 = bundle_Sprite.LoadAsset<Sprite>("CB20.png").DontUnload();

            AR_0 = bundle_Sprite.LoadAsset<Sprite>("BA_0.png").DontUnload();
            AR_UP = bundle_Sprite.LoadAsset<Sprite>("BA_UP.png").DontUnload();
            AR_DOWN = bundle_Sprite.LoadAsset<Sprite>("BA_DOWN.png").DontUnload();

            CeciteIco = bundle_Sprite.LoadAsset<Sprite>("CeciteIco.png").DontUnload();

            MentalistIco = bundle_Sprite.LoadAsset<Sprite>("MentalistIco.png").DontUnload();
            slayersolo = bundle_Sprite.LoadAsset<Sprite>("slayersolo.png").DontUnload();
            cr1 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr2 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr3 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr4 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr5 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr6 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr7 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr8 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr9 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr10 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr11 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            cr12 = bundle_Sprite.LoadAsset<Sprite>("cristal.png").DontUnload();
            empty = bundle_Sprite.LoadAsset<Sprite>("empty.png").DontUnload();
            NuclearButtonSprite = bundle_Sprite.LoadAsset<Sprite>("NBS.png").DontUnload();
            NuclearButtonSprite0 = bundle_Sprite.LoadAsset<Sprite>("NBS0.png").DontUnload();
            NuclearButtonSprite1 = bundle_Sprite.LoadAsset<Sprite>("NBS1.png").DontUnload();
            war1 = bundle_Sprite.LoadAsset<Sprite>("war1.png").DontUnload();
            war2 = bundle_Sprite.LoadAsset<Sprite>("war2.png").DontUnload();
            war3 = bundle_Sprite.LoadAsset<Sprite>("war3.png").DontUnload();
            war0 = bundle_Sprite.LoadAsset<Sprite>("war0.png").DontUnload();

            CulteIco = bundle_Sprite.LoadAsset<Sprite>("CulteIco.png").DontUnload();

            GuessIco = bundle_Sprite.LoadAsset<Sprite>("Guess.png").DontUnload();
            GuessUIIco = bundle_Sprite.LoadAsset<Sprite>("guessui.png").DontUnload();

            BlockVentIco = bundle_Sprite.LoadAsset<Sprite>("ventTP5.png").DontUnload();
            BlockVentuse = bundle_Sprite.LoadAsset<Sprite>("ventTP5.png").DontUnload();
            BlockVentall = bundle_Sprite.LoadAsset<Sprite>("ventTP4.png").DontUnload();
            BlockVent1 = bundle_Sprite.LoadAsset<Sprite>("locker1.png").DontUnload();
            BlockVent2 = bundle_Sprite.LoadAsset<Sprite>("locker2.png").DontUnload();
            BlockVent3 = bundle_Sprite.LoadAsset<Sprite>("locker3.png").DontUnload();

            DictatorIco = bundle_Sprite.LoadAsset<Sprite>("dictator.png").DontUnload();
            SabdoorIco = bundle_Sprite.LoadAsset<Sprite>("sabdoor.png").DontUnload();
            OilIco = bundle_Sprite.LoadAsset<Sprite>("oil.png").DontUnload();
            OilIcoFail = bundle_Sprite.LoadAsset<Sprite>("oil0.png").DontUnload();
            OilIcoCast = bundle_Sprite.LoadAsset<Sprite>("oil1.png").DontUnload();
            RefuelStation = bundle_Sprite.LoadAsset<Sprite>("Refuel.png").DontUnload();
            CanBurn = bundle_Sprite.LoadAsset<Sprite>("CanBurn.png").DontUnload();

            BurnIco = bundle_Sprite.LoadAsset<Sprite>("burn.png").DontUnload();
            CopyIco = bundle_Sprite.LoadAsset<Sprite>("copycat.png").DontUnload();
            PetrifyIco = bundle_Sprite.LoadAsset<Sprite>("Petrify.png").DontUnload();
            Petrify2Ico = bundle_Sprite.LoadAsset<Sprite>("Petrify2.png").DontUnload();
            LocRune = bundle_Sprite.LoadAsset<Sprite>("Find.png").DontUnload();

            SenVnull = bundle_Sprite.LoadAsset<Sprite>("SenVnull.png").DontUnload();
            SenV = bundle_Sprite.LoadAsset<Sprite>("SenV.png").DontUnload();
            SenVon = bundle_Sprite.LoadAsset<Sprite>("SenVon.png").DontUnload();
            SenVoff = bundle_Sprite.LoadAsset<Sprite>("SenVoff.png").DontUnload();
            SenDBnull = bundle_Sprite.LoadAsset<Sprite>("SenDBnull.png").DontUnload();
            SenDB = bundle_Sprite.LoadAsset<Sprite>("SenDB.png").DontUnload();
            SenDBon = bundle_Sprite.LoadAsset<Sprite>("SenDBon.png").DontUnload();
            SenDBoff = bundle_Sprite.LoadAsset<Sprite>("SenDBoff.png").DontUnload();
            SenIco = bundle_Sprite.LoadAsset<Sprite>("SenIco.png").DontUnload();

            BaitBaliseArea = bundle_Sprite.LoadAsset<Sprite>("BaitArea.png").DontUnload();
            BaitBaliseArea0 = bundle_Sprite.LoadAsset<Sprite>("BaitArea0.png").DontUnload();
            BaitIco = bundle_Sprite.LoadAsset<Sprite>("BaitIco.png").DontUnload();
            LeadIco = bundle_Sprite.LoadAsset<Sprite>("LeadIco.png").DontUnload();

            Drone0 = bundle_Sprite.LoadAsset<Sprite>("DroneOff.png").DontUnload();
            Drone1 = bundle_Sprite.LoadAsset<Sprite>("DroneOn.png").DontUnload();

            ChallengerMod.Challenger.LoadEvent();
            Harmony.Unpatch(typeof(UdpConnection).GetMethod("HandleSend"), HarmonyPatchType.Prefix,
            ReactorPlugin.Id);
            SpritePatches.Patch();
            ChallengerUI_MMO.Initialize();
            CheckServer();
            Harmony.PatchAll();
        }



        [HarmonyPatch(typeof(Constants), nameof(Constants.ShouldFlipSkeld))]
        class ConstantsShouldFlipSkeldPatch
        {
            public static bool Prefix(ref bool __result)
            {
                if (PlayerControl.GameOptions == null) return true;
                __result = PlayerControl.GameOptions.MapId == 3;
                return false;
            }
        }
        
        
        [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
        [HarmonyPriority(Priority.First)]
        public static class GameOptionsMenuPatch
        {
            public static void Postfix(GameOptionsMenu __instance)
            {
                __instance.Children
                    .Single(o => o.Title == StringNames.GameCommonTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 2);

                __instance.Children
                   .Single(o => o.Title == StringNames.GameLongTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 5);
                
                __instance.Children
                   .Single(o => o.Title == StringNames.GameShortTasks).Cast<NumberOption>().ValidRange = new FloatRange(0, 8);
               
                //WIP 15+ Player
               /* __instance.Children
                   .Single(o => o.Title == StringNames.GameNumImpostors).Cast<NumberOption>().ValidRange = new FloatRange(1, 4);
               */
               
                __instance.Children
                   .Single(o => o.Title == StringNames.GameRecommendedSettings).Destroy();


            }
        }
        
    }
   
    [HarmonyPatch(typeof(StatsManager), nameof(StatsManager.AmBanned), MethodType.Getter)]
    public static class AmBannedPatch
    {
        public static void Postfix(out bool __result)
        {
            __result = false;
        }
    }
   
}
