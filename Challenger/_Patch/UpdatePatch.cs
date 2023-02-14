using HarmonyLib;
using UnityEngine;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using InnerNet;
using System.Collections.Generic;
using Hazel;
using System;
using System.IO;
using System.Net.Http;
using System.Linq;
using ChallengerMod.Utility.Utils;
using Object = UnityEngine.Object;
using static ChallengerMod.HarmonyMain;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using Il2CppSystem.Collections;
using Twitch;
using System.Threading.Tasks;
using GLMod;
using TMPro;
using System.Threading;
using static ChallengerMod.Set.Data;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerOS.Utils.Helpers;
using static ChallengerMod.GameEvent;
using ChallengerMod.RPC;
using Steamworks;
using ChallengerMod.Rnd;
using ChallengerMod.CustomButton;
using ChallengerMod.Item;
using Discord;
using Rewired;
using UnityEngine.Video;
using ChallengerOS.Utils.Option;
using ChallengerOS.Objects;
using ChallengerMod.Cosmetics;
using ChallengerMod.Cosmetiques;

namespace ChallengerMod
{
    [HarmonyPatch(typeof(FindAGameManager), "Start")]
    public static class MFindAGameManagerStart
    {
        public static void Prefix(FindAGameManager __instance)
        {
            GameObject AnimationLogin = new GameObject();
            AnimationLogin.transform.name = "ChallengerUI_VP";
            AnimationLogin.transform.localPosition = new Vector3(0f, 0f, 3f);
            AnimationLogin.transform.localScale = new Vector3(12.5f, 11f, 2f);
            BoxCollider2D AnimationLoginBttnBox = AnimationLogin.AddComponent<BoxCollider2D>();
            SpriteRenderer AnimationLoginBttnSprite = AnimationLogin.AddComponent<SpriteRenderer>();
            AnimationLoginBttnSprite.sprite = empty;
            AnimationLoginBttnBox.size = new Vector2(0f, 0f);
            VideoPlayer LoginAnimationV2V = AnimationLogin.AddComponent<VideoPlayer>();
            LoginAnimationV2V.clip = video;
            LoginAnimationV2V.Play();
            LoginAnimationV2V.isLooping = true;

            GameObject GameArea = GameObject.Find("GameArea");
            GameArea.transform.localPosition = new Vector3(1.03f, -0.67f, -10f);
            GameObject FilterSettings = GameObject.Find("FilterSettings");
            FilterSettings.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            FilterSettings.transform.localPosition = new Vector3(1.1f,0.43f, -20f);


        }
    }


        [HarmonyPatch(typeof(MMOnlineManager), "Start")]
    public static class MMOnlineManagerStart
    {
        public static void Prefix(MMOnlineManager __instance)
        {
            Challenger.RankedSettings = false;
            GameObject AnimationLogin = new GameObject();
            AnimationLogin.transform.name = "ChallengerUI_VP";
            AnimationLogin.transform.localPosition = new Vector3(0f, 0f, 3f);
            AnimationLogin.transform.localScale = new Vector3(12.5f, 11f, 2f);
            BoxCollider2D AnimationLoginBttnBox = AnimationLogin.AddComponent<BoxCollider2D>();
            SpriteRenderer AnimationLoginBttnSprite = AnimationLogin.AddComponent<SpriteRenderer>();
            AnimationLoginBttnSprite.sprite = empty;
            AnimationLoginBttnBox.size = new Vector2(0f, 0f);
            VideoPlayer LoginAnimationV2V = AnimationLogin.AddComponent<VideoPlayer>();
            LoginAnimationV2V.clip = video;
            LoginAnimationV2V.Play();
            LoginAnimationV2V.isLooping = true;

            GameObject BlocGL = new GameObject();
            GameObject BlocPL = new GameObject();
            GameObject BlocPLM = new GameObject();

            BlocGL.name = "Bloc_GLMod";
            BlocPL.name = "Bloc_Player";
            BlocPLM.name = "Bloc_PlayerMax";

            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                SpriteRenderer BlocGLSprite = BlocGL.AddComponent<SpriteRenderer>();
                SpriteRenderer BlocPLSprite = BlocPL.AddComponent<SpriteRenderer>();
                SpriteRenderer BlocPLMSprite = BlocPLM.AddComponent<SpriteRenderer>();

                if (GLMod.GLMod.isLoggedIn() == true)
                {
                    BlocGLSprite.sprite = TB_GL1_FR;

                }
                else
                {
                    BlocGLSprite.sprite = TB_GL0_FR;

                }

                BlocPLSprite.sprite = TB_PLAYER_FR;
                BlocPLMSprite.sprite = TB_MAXPLAYER_FR;
            }
            else
            {

                SpriteRenderer BlocGLSprite = BlocGL.AddComponent<SpriteRenderer>();
                SpriteRenderer BlocPLSprite = BlocPL.AddComponent<SpriteRenderer>();
                SpriteRenderer BlocPLMSprite = BlocPLM.AddComponent<SpriteRenderer>();


                if (GLMod.GLMod.isLoggedIn() == true)
                {
                    BlocGLSprite.sprite = TB_GL1;

                }
                else
                {
                    BlocGLSprite.sprite = TB_GL0;

                }
                BlocPLSprite.sprite = TB_PLAYER;
                BlocPLMSprite.sprite = TB_MAXPLAYER;

            }

            var CustomIcone = GameObject.Find("NormalMenu/HelpButton");
            var RK_Ico = UnityEngine.Object.Instantiate(CustomIcone, null);
            var GL_Create = UnityEngine.Object.Instantiate(CustomIcone, null);
            var GL_Login = UnityEngine.Object.Instantiate(CustomIcone, null);
            var GL_Profil = UnityEngine.Object.Instantiate(CustomIcone, null);


            RK_Ico.name = "RK_Ico";
            GL_Create.name = "GL_Create";
            GL_Login.name = "GL_Login";
            GL_Profil.name = "GL_Profil";

            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                GL_Create.GetComponent<SpriteRenderer>().sprite = UI2_GLLoginFR;
                GL_Login.GetComponent<SpriteRenderer>().sprite = StartGameR0_FR;
                GL_Profil.GetComponent<SpriteRenderer>().sprite = UI2_GLProfil;
            }
            else
            {
                GL_Create.GetComponent<SpriteRenderer>().sprite = UI2_GLCreate;
                GL_Login.GetComponent<SpriteRenderer>().sprite = UI2_GLLogin;
                GL_Profil.GetComponent<SpriteRenderer>().sprite = UI2_GLProfil;
            }

            BoxCollider2D GL_CreateButtonCollider = GL_Create.GetComponent<BoxCollider2D>();
            GL_CreateButtonCollider.size = new Vector2(2.4f, 0.65f);
            PassiveButton GL_CreateButton = GL_Create.GetComponent<PassiveButton>();
            GL_CreateButton.OnClick = new Button.ButtonClickedEvent();
            GL_CreateButton.OnClick.AddListener((UnityEngine.Events.UnityAction)GL_CreateButton_onClick);
            void GL_CreateButton_onClick()
            {
                Application.OpenURL("https://goodloss.fr/register");
            }

            BoxCollider2D GL_LoginButtonCollider = GL_Login.GetComponent<BoxCollider2D>();
            GL_LoginButtonCollider.size = new Vector2(2.4f, 0.65f);
            PassiveButton GL_LoginButton = GL_Login.GetComponent<PassiveButton>();
            GL_LoginButton.OnClick = new Button.ButtonClickedEvent();
            GL_LoginButton.OnClick.AddListener((UnityEngine.Events.UnityAction)GL_LoginButton_onClick);
            void GL_LoginButton_onClick()
            {
                if (GLMod.GLMod.isLoggedIn() == false)
                {
                   // ChallengerMod.GLLogin.GLMod_Login.tryLogin();
                }
            }

            BoxCollider2D GL_ProfilButtonCollider = GL_Profil.GetComponent<BoxCollider2D>();
            GL_ProfilButtonCollider.size = new Vector2(2.4f, 0.65f);
            PassiveButton GL_ProfilButton = GL_Profil.GetComponent<PassiveButton>();
            GL_ProfilButton.OnClick = new Button.ButtonClickedEvent();
            GL_ProfilButton.OnClick.AddListener((UnityEngine.Events.UnityAction)GL_ProfilButton_onClick);
            void GL_ProfilButton_onClick()
            {
                if (GLMod.GLMod.isLoggedIn() == true)
                {
                    Application.OpenURL("https://goodloss.fr/player/" + GLMod.GLMod.getAccountName());
                }
            }


            var CustomText = GameObject.Find("AccountManager").transform.FindChild("AccountTab").transform.FindChild("AccountWindow").transform.FindChild("Card").transform.FindChild("CardContents").transform.FindChild("IDCard").transform.FindChild("UserNameTitle_TMP");
            var RankText = UnityEngine.Object.Instantiate(CustomText, null);
            //var ModText = UnityEngine.Object.Instantiate(CustomText, null);
            RankText.name = "RK_Text";

            var PoolablePlayer = GameObject.Find("AccountManager/AccountTab/AccountWindow/Card/CardContents/IDCard/PoolablePlayer");
            var CustomPlayer = UnityEngine.Object.Instantiate(PoolablePlayer, null);
            CustomPlayer.name = "CustomPlayer";

            var IDBgMask = GameObject.Find("AccountManager/AccountTab/AccountWindow/Card/CardContents/IDCard/IDBgMask");
            var CustomPlayerMask = UnityEngine.Object.Instantiate(IDBgMask, null);
            CustomPlayerMask.name = "CustomPlayerMask";

            //ModText.name = "TAB_Text";
            
               


        }
    }
    [HarmonyPatch(typeof(MMOnlineManager), "Update")]
    public static class MMOnlineManagerUpdate
    {
        public static void Postfix(MMOnlineManager __instance)
        {
          if (Challenger.IsrankedGame)
            {
               Challenger.ReadyPlayers = new List<string>();
            }
          
            //Set FreeName 

            var FreeName = GameObject.Find("NameText(Clone)");
            
            if (GameObject.Find("OptionsMenu/Content/Confirm")) // SCENE 2
            {
                FreeName.transform.localScale = new Vector3(0f, 0f, 0f);

                if (GameObject.Find("Bloc_Player"))
                {
                    GameObject Tab_Player = GameObject.Find("Bloc_Player");
                    Tab_Player.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("Bloc_PlayerMax"))
                {
                    GameObject Tab_PlayerMax = GameObject.Find("Bloc_PlayerMax");
                    Tab_PlayerMax.transform.localScale = new Vector3(0.6f, 0.55f, 1f);
                    Tab_PlayerMax.transform.localPosition = new Vector3(0f, 0.3f, 0.7f);

                }
                if (GameObject.Find("Bloc_GLMod"))
                {
                    GameObject Tab_Account = GameObject.Find("Bloc_GLMod");
                    Tab_Account.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("GL_Create"))
                {
                    GameObject GL_Create = GameObject.Find("GL_Create");
                    GL_Create.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("GL_Login"))
                {
                    GameObject GL_Login = GameObject.Find("GL_Login");
                    GL_Login.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("GL_Profil"))
                {
                    GameObject GL_Profil = GameObject.Find("GL_Profil");
                    GL_Profil.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("NormalMenu/BackButton"))
                {
                    GameObject BackButton = GameObject.Find("NormalMenu/BackButton");
                    BackButton.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("CustomPlayer"))
                {
                    GameObject CustomPlayer = GameObject.Find("CustomPlayer");
                    CustomPlayer.transform.localScale = new Vector3(0f, 0f, 0f);

                }
                if (GameObject.Find("CustomPlayerMask"))
                {
                    GameObject CustomPlayerMask = GameObject.Find("CustomPlayerMask");
                    CustomPlayerMask.transform.localScale = new Vector3(0f, 0f, 0f);

                }
                if (GameObject.Find("OptionsMenu/Content/LanguageMenu"))
                {
                    GameObject LanguageMenu = GameObject.Find("OptionsMenu/Content/LanguageMenu");
                    LanguageMenu.transform.localPosition = new Vector3(100f, 0f, -10f);
                }
                if (GameObject.Find("OptionsMenu/Content/Languages/PickerButton"))
                {
                    GameObject PickerButton = GameObject.Find("OptionsMenu/Content/Languages/PickerButton");
                    PickerButton.transform.localPosition = new Vector3(103.325f, 0.6f, 0f);
                }

            }
            else // SCENE 1
            {
                
                FreeName.transform.localPosition = new Vector3(1.29f, -0.2f, -0.5f);
                FreeName.transform.localScale = new Vector3(0.45f, 0.5f, 0f);
                
                if (GameObject.Find("Bloc_PlayerMax"))
                {
                    GameObject Tab_PlayerMax = GameObject.Find("Bloc_PlayerMax");
                    Tab_PlayerMax.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("Bloc_Player"))
                {
                    GameObject Tab_Player = GameObject.Find("Bloc_Player");
                    Tab_Player.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                    Tab_Player.transform.localPosition = new Vector3(1.3f, 0.7f, 1f);
                }

                if (GameObject.Find("Bloc_GLMod"))
                {
                    GameObject Tab_Account = GameObject.Find("Bloc_GLMod");
                   Tab_Account.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                   Tab_Account.transform.localPosition = new Vector3(-1.3f, 0.7f, 1f);
                }

                if (GameObject.Find("GL_Create"))
                {
                    if (GLMod.GLMod.isLoggedIn() == true)
                    {
                        GameObject GL_Create = GameObject.Find("GL_Create");
                        GL_Create.transform.localScale = new Vector3(0f, 0f, 0f);

                    }
                    else
                    {
                        GameObject GL_Create = GameObject.Find("GL_Create");
                        GL_Create.transform.localScale = new Vector3(0.65f, 0.45f, 1f);
                        GL_Create.transform.localPosition = new Vector3(-1.3f, 0.45f, 0f);
                    }
                       
                }

                if (GameObject.Find("GL_Login"))
                {
                    if (GLMod.GLMod.isLoggedIn() == true)
                    {
                        GameObject GL_Login = GameObject.Find("GL_Login");
                        GL_Login.transform.localScale = new Vector3(0f, 0f, 0f);

                    }
                    else
                    {
                       
                        GameObject GL_Login = GameObject.Find("GL_Login");
                        GL_Login.transform.localScale = new Vector3(0.65f, 0.45f, 1f);
                        GL_Login.transform.localPosition = new Vector3(-1.3f, -0.05f, 0f);
                    }
                       
                }

                if (GameObject.Find("GL_Profil"))
                {

                    if (GLMod.GLMod.isLoggedIn() == true)
                    {
                        GameObject GL_Profil = GameObject.Find("GL_Profil");
                        GL_Profil.transform.localScale = new Vector3(0.65f, 0.45f, 1f);
                        GL_Profil.transform.localPosition = new Vector3(-1.3f, 1.25f, 0f);
                    }
                    else
                    {
                        GameObject GL_Profil = GameObject.Find("GL_Profil");
                        GL_Profil.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    
                }



                if (GameObject.Find("OptionsMenu/Content/LanguageMenu"))
                {
                    GameObject LanguageMenu = GameObject.Find("OptionsMenu/Content/LanguageMenu");
                    LanguageMenu.transform.localPosition = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("OptionsMenu/Content/Languages/PickerButton"))
                {
                    GameObject PickerButton = GameObject.Find("OptionsMenu/Content/Languages/PickerButton");
                    PickerButton.transform.localPosition = new Vector3(0f, 0f, 0f);
                }

               

                if (GameObject.Find("NormalMenu/BackButton"))
                {
                    GameObject BackButton = GameObject.Find("NormalMenu/BackButton");
                   BackButton.transform.localScale = new Vector3(1.95f, 1.8f, 1f);
                   BackButton.transform.localPosition = new Vector3(0f, -2.5f, -3f);
                    BoxCollider2D BackButtonbox = BackButton.GetComponent<BoxCollider2D>();
                    BackButtonbox.size = new Vector2(1f, 0.35f);

                    if (GameObject.Find("NormalMenu/BackButton/Text_TMP"))
                    {
                        GameObject BackButtonSTR = GameObject.Find("NormalMenu/BackButton/Text_TMP");
                        BackButtonSTR.transform.localScale = new Vector3(0f, 0f, 0f);
                    }

                    if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                    {
                        SpriteRenderer BackButtonSprite = BackButton.GetComponent<SpriteRenderer>();
                        BackButtonSprite.sprite = UI2_MainMenuFR;
                    }
                    else
                    {
                        SpriteRenderer BackButtonSprite = BackButton.GetComponent<SpriteRenderer>();
                        BackButtonSprite.sprite = UI2_MainMenu;
                    }
                }
                if (GameObject.Find("CustomPlayer"))
                {
                    GameObject CustomPlayer = GameObject.Find("CustomPlayer");
                    CustomPlayer.transform.localScale = new Vector3(0.42f, 0.42f, 1f);
                    CustomPlayer.transform.localPosition = new Vector3(1.3f, 0.45f, -0.2f);

                }
                if (GameObject.Find("CustomPlayerMask"))
                {
                    GameObject CustomPlayerMask = GameObject.Find("CustomPlayerMask");
                   CustomPlayerMask.transform.localScale = new Vector3(2.39f, 1.9f, 1f);
                   CustomPlayerMask.transform.localPosition = new Vector3(1.29f, 0.64f, 0.1f);

                }

                



            }



            if (GameObject.Find("NormalMenu/RegionButton"))
            {
                var RegionButton = GameObject.Find("NormalMenu/RegionButton");
                RegionButton.transform.localScale = new Vector3(0f, 0f, 0f);

                RegionButton.transform.localPosition = new Vector3(-1.2059f, -1.92f, 0f);
                RegionButton.GetComponent<SpriteRenderer>().sprite = serverbtt;
                var RegionText_TMP = GameObject.Find("NormalMenu/RegionButton/RegionText_TMP");
                RegionText_TMP.transform.localPosition = new Vector3(0f, -0.3451f, 0f);
                RegionText_TMP.GetComponent<TMPro.TextMeshPro>().horizontalAlignment = HorizontalAlignmentOptions.Center;
                RegionText_TMP.GetComponent<TMPro.TextMeshPro>().color = Color.blue;
            }


            //FindGameButton
            var FindGameButton = GameObject.Find("NormalMenu/FindGameButton/FindGameButton");
           FindGameButton.transform.localScale = new Vector3(1f, 1.8f, -1f);

            if (GameObject.Find("OptionsMenu/Content/Confirm"))
            {
                FindGameButton.transform.localPosition = new Vector3(0f, -1.92f, -3f);

            }
            else
            {
                 FindGameButton.transform.localPosition = new Vector3(100f, -2f, -3f);

            }



            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
               
                if (ChallengerMod.Challenger.IsrankedGame)
                {
                    FindGameButton.GetComponent<SpriteRenderer>().sprite = UI2_FindGameOffFR;
                    BoxCollider2D FindGameButtonbox = FindGameButton.GetComponent<BoxCollider2D>();
                    FindGameButtonbox.size = new Vector2(0f, 0f);

                }
                else
                {
                    FindGameButton.GetComponent<SpriteRenderer>().sprite = UI2_FindGameOnFR;
                    BoxCollider2D FindGameButtonbox = FindGameButton.GetComponent<BoxCollider2D>();
                    FindGameButtonbox.size = new Vector2(1.9f, 0.2f);
                }
                
            }
            else
            {


                if (ChallengerMod.Challenger.IsrankedGame)
                {
                    FindGameButton.GetComponent<SpriteRenderer>().sprite = UI2_FindGameOff;
                    BoxCollider2D FindGameButtonbox = FindGameButton.GetComponent<BoxCollider2D>();
                    FindGameButtonbox.size = new Vector2(0f, 0f);

                }
                else
                {
                    FindGameButton.GetComponent<SpriteRenderer>().sprite = UI2_FindGameOn;
                    BoxCollider2D FindGameButtonbox = FindGameButton.GetComponent<BoxCollider2D>();
                    FindGameButtonbox.size = new Vector2(1.9f, 0.2f);
                }
            }


            var FixFindGameButtonText_TMP = GameObject.Find("NormalMenu/FindGameButton/FindGameButton/Text_TMP"); ;
            FixFindGameButtonText_TMP.transform.localScale = new Vector3(0f, 0f, 0f);

            //CreateGameButton
            var HostGameButton = GameObject.Find("NormalMenu/HostGameButton/CreateGameButton");
           HostGameButton.transform.localScale = new Vector3(1f, 1.8f, -1f);

          
           


            if (GameObject.Find("OptionsMenu/Content/Confirm"))
            {
                HostGameButton.transform.localPosition = new Vector3(0f, -1.25f, -3f);

            }
            else
            {
               HostGameButton.transform.localPosition = new Vector3(100f, -1f, -3f);


            }



            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                HostGameButton.GetComponent<SpriteRenderer>().sprite = UI2_CreateGameFR;
            }
            else
            {
                HostGameButton.GetComponent<SpriteRenderer>().sprite = UI2_CreateGame;
            }
            BoxCollider2D HostGameButtonbox = HostGameButton.GetComponent<BoxCollider2D>();
                HostGameButtonbox.size = new Vector2(1.9f, 0.2f);
            
            
            var FixCreateGameButtonText_TMP = GameObject.Find("NormalMenu/HostGameButton/CreateGameButton/Text_TMP"); ;
            FixCreateGameButtonText_TMP.transform.localScale = new Vector3(0f, 0f, 0f);
           
            
            //JoinGameButton
            var JoinGameButton = GameObject.Find("NormalMenu/JoinGameButton/JoinGameButton");
            BoxCollider2D boxNsize4 = JoinGameButton.GetComponent<BoxCollider2D>();
            boxNsize4.size = new Vector2(1.9f, 0.2f);
            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                JoinGameButton.GetComponent<SpriteRenderer>().sprite = UI2_EnterCodeFR;
            }
            else
            {
                JoinGameButton.GetComponent<SpriteRenderer>().sprite = UI2_EnterCode;
            }
            
            JoinGameButton.transform.localScale = new Vector3(1f, 1.8f, 1f);//**
            var FixText_TMP3 = GameObject.Find("NormalMenu/JoinGameButton/JoinGameButton/Text_TMP");
            FixText_TMP3.transform.localScale = new Vector3(0f, 0f, 0f);

            if (GameObject.Find("OptionsMenu/Content/Confirm"))
            {
                JoinGameButton.transform.localPosition = new Vector3(0f, -1.65f, -3f);

            }
            else
            {
               JoinGameButton.transform.localPosition = new Vector3(100f, -1.5f, -3f);

            }




            //Fix Panel for Join Game
            if (GameObject.Find("NormalMenu/JoinGameButton/JoinGameMenu"))
            {
                var JoinGameMenu = GameObject.Find("NormalMenu/JoinGameButton/JoinGameMenu");
                JoinGameMenu.transform.localPosition = new Vector3(100f, 0f, -31f);
            }

            if (GameObject.Find("OptionsMenu/Content/Confirm"))
            {
                var Content = GameObject.Find("OptionsMenu/Content");
                Content.transform.localPosition = new Vector3(-100f, 0f, -1f);

                //CreateGame
                var CustomButtonCreate = GameObject.Find("OptionsMenu/Content/Confirm");
                CustomButtonCreate.transform.localPosition = new Vector3(100f, -1.4f, -3f); //**
                CustomButtonCreate.transform.localScale = new Vector3(1.5f, 2.5f, -1f);//**
                BoxCollider2D boxNsize = CustomButtonCreate.GetComponent<BoxCollider2D>();
                boxNsize.size = new Vector2(1.9f, 0.2f);

                    if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                    {
                        CustomButtonCreate.GetComponent<SpriteRenderer>().sprite = UI2_CreateConfirmFR;
                    }
                    else
                    {
                        CustomButtonCreate.GetComponent<SpriteRenderer>().sprite = UI2_CreateConfirm;
                    }

                var FixText_TMP = GameObject.Find("OptionsMenu/Content/Confirm/Text_TMP");
                FixText_TMP.transform.localScale = new Vector3(0f, 0f, 0f);

                //CANCEL
                var CustomButtonCancel = GameObject.Find("OptionsMenu/Content/Cancel");
                CustomButtonCancel.transform.localPosition = new Vector3(100f, -2f, -3f);
                CustomButtonCancel.transform.localScale = new Vector3(1.5f, 2.5f, -1f);
                BoxCollider2D boxNsize2 = CustomButtonCancel.GetComponent<BoxCollider2D>();
                boxNsize2.size = new Vector2(1.3f, 0.15f);

                if (ChallengerMod.Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                {
                    CustomButtonCancel.GetComponent<SpriteRenderer>().sprite = UI2_CreateCancelFR;
                }
                else
                {
                    CustomButtonCancel.GetComponent<SpriteRenderer>().sprite = UI2_CreateCancel;
                }
                var FixText_TMP2 = GameObject.Find("OptionsMenu/Content/Cancel/Text_TMP");
                FixText_TMP2.transform.localScale = new Vector3(0f, 0f, 0f);

                //PMAX
                var Num10 = GameObject.Find("OptionsMenu/Content/Max Players/10");
                var Num11 = GameObject.Find("OptionsMenu/Content/Max Players/11");
                var Num12 = GameObject.Find("OptionsMenu/Content/Max Players/12");
                var Num13 = GameObject.Find("OptionsMenu/Content/Max Players/13");
                var Num14 = GameObject.Find("OptionsMenu/Content/Max Players/14");
                var Num15 = GameObject.Find("OptionsMenu/Content/Max Players/15");
                Num10.transform.localPosition = new Vector3(100.768f, 2.1f, 21f);
                Num11.transform.localPosition = new Vector3(101.218f, 2.1f, 21f);
                Num12.transform.localPosition = new Vector3(101.668f, 2.1f, 21f);
                Num13.transform.localPosition = new Vector3(102.118f, 2.1f, 21f);
                Num14.transform.localPosition = new Vector3(102.568f, 2.1f, 21f);
                Num15.transform.localPosition = new Vector3(103.018f, 2.1f, 21f);


                
                //BoxCollider2D boxNsize2 = CustomButtonCancel.GetComponent<BoxCollider2D>();
                //boxNsize2.size = new Vector2(1.3f, 0.15f);

                if (ChallengerMod.Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                {
                    CustomButtonCancel.GetComponent<SpriteRenderer>().sprite = UI2_CreateCancelFR;
                }
                else
                {
                    CustomButtonCancel.GetComponent<SpriteRenderer>().sprite = UI2_CreateCancel;
                }
               

            }

            var RK_Ico = GameObject.Find("RK_Ico");
            var RankTextFind = GameObject.Find("RK_Text");

            if (GameObject.Find("OptionsMenu/Content/Confirm"))
            {
               
                RK_Ico.transform.localScale = new Vector3(0f, 0f, 0f);
                RankTextFind.transform.localScale = new Vector3(0f, 0f, 0f);
            }
            else
            {
                if (GLMod.GLMod.isLoggedIn() == true)
                {
                    RK_Ico.transform.localPosition = new Vector3(-1.3f, 0.5f, 0f);
                    RK_Ico.transform.localScale = new Vector3(0.5f, 0.5f, -40f);
                    RankTextFind.transform.localPosition = new Vector3(-1.3f, -0.1f, -1f);
                    RankTextFind.transform.localScale = new Vector3(0.72f, 0.72f, 1f);
                }
                else
                {
                    RK_Ico.transform.localScale = new Vector3(0f, 0f, 0f);
                    RankTextFind.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                
            }

            BoxCollider2D RK_IcoBC = RK_Ico.GetComponent<BoxCollider2D>();
            RK_IcoBC.size = new Vector2(0f, 0f);
            TMP_Text RankSTRT = RankTextFind.GetComponent<TMP_Text>();
            RankSTRT.horizontalAlignment = HorizontalAlignmentOptions.Center;

            if (GLMod.GLMod.isLoggedIn() == true)
            {
                GoodlossRank = GLMod.GLMod.rank.id;
                GoodlossRankValue = GLMod.GLMod.rank.percent;
                STR_myRank = "r" + GoodlossRank;
                if (GoodlossRank == 0)
                {
                    STR_myRankname = DR_Unranked;
                }
                else if (GoodlossRank == 1)
                {
                    STR_myRankname = DR_B3;
                }
                else if (GoodlossRank == 2)
                {
                    STR_myRankname = DR_B2;
                }
                else if (GoodlossRank == 3)
                {
                    STR_myRankname = DR_B1;
                }
                else if (GoodlossRank == 4)
                {
                    STR_myRankname = DR_S3;
                }
                else if (GoodlossRank == 5)
                {
                    STR_myRankname = DR_S2;
                }
                else if (GoodlossRank == 6)
                {
                    STR_myRankname = DR_S1;
                }
                else if (GoodlossRank == 7)
                {
                    STR_myRankname = DR_G3;
                }
                else if (GoodlossRank == 8)
                {
                    STR_myRankname = DR_G2;
                }
                else if (GoodlossRank == 9)
                {
                    STR_myRankname = DR_G1;
                }
                else if (GoodlossRank == 10)
                {
                    STR_myRankname = DR_C3;
                }
                else if (GoodlossRank == 11)
                {
                    STR_myRankname = DR_C2;
                }
                else if (GoodlossRank == 12)
                {
                    STR_myRankname = DR_C1;
                }
                else if (GoodlossRank == 13)
                {
                    STR_myRankname = DR_E;
                }
                else if (GoodlossRank == 14)
                {
                    STR_myRankname = DR_M;
                }
            }
            else
            {

                STR_myRankname = DR_Unranked;
            }


            if (GLMod.GLMod.isLoggedIn() == true)
            {

                if (GoodlossRank == 0)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_0;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_Unranked;
                    var RKSTR = "<color=#D4D4D4>" + STR_GoodlossRank + "</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 1)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_B3;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_B3;
                    var RKSTR = "<color=#E0AC8D>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 2)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_B2;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_B2;
                    var RKSTR = "<color=#E0AC8D>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 3)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_B1;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_B1;
                    var RKSTR = "<color=#E0AC8D>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 4)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_S3;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_S3;
                    var RKSTR = "<color=#ABD9EC>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 5)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_S2;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_S2;
                    var RKSTR = "<color=#ABD9EC>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 6)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_S1;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_S1;
                    var RKSTR = "<color=#ABD9EC>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 7)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_G3;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_G3;
                    var RKSTR = "<color=#F5ED65>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 8)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_G2;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_G2;
                    var RKSTR = "<color=#F5ED65>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 9)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_G1;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_G1;
                    var RKSTR = "<color=#F5ED65>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 10)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_P3;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_C3;
                    var RKSTR = "<color=#DDB4FE>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 11)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_P2;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_C2;
                    var RKSTR = "<color=#DDB4FE>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 12)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_P1;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_C1;
                    var RKSTR = "<color=#DDB4FE>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 13)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_D;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_E;
                    var RKSTR = "<color=#FF9D9D>" + STR_GoodlossRank + "</color>\n<color=#6BB3FF>(" + GoodlossRankValue + " %)</color>";
                    RankSTRT.SetText(RKSTR);
                }
                else if (GoodlossRank == 14)
                {
                    RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_M;
                    STR_GoodlossRank = ChallengerMod.Set.Data.R_M;
                    var RKSTR = "<color=#FF9D9D>" + STR_GoodlossRank + "</color>\n<color=#FF4EE1>[" + GoodlossRankValue + "]</color>";
                    RankSTRT.SetText(RKSTR);
                }
            }
            else
            {
                RK_Ico.GetComponent<SpriteRenderer>().sprite = Rank_0;
                STR_GoodlossRank = ChallengerMod.Set.Data.R_Unranked;
                var RKSTR = "<color=#D4D4D4>" + STR_GoodlossRank + "</color>";
                RankSTRT.SetText(RKSTR);
            }

            if (ChallengerMod.Challenger.IsrankedGame == true) //CLASSE
            {

                if (presetSelection.getSelection() != 3)
                {
                    ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.updateSelection(3);
                    ChallengerOS.Utils.Option.CustomOption.switchPreset(3);
                    Ranked.updateSelection(1);
                }
                else
                {
                    Ranked.updateSelection(1);
                }
            }
            else //NORMAL
            {
                
                if (presetSelection.getSelection() != 0)
                {
                    ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.updateSelection(0);
                    ChallengerOS.Utils.Option.CustomOption.switchPreset(0);
                    Ranked.updateSelection(0);
                }
                else
                {
                    Ranked.updateSelection(0);
                }

            }

           


           
                
            

            



           


           


        }
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    class HudUpdateManager
    {
        static void UpdateName()
        {
            Dictionary<byte, PlayerControl> playersById = ChallengerOS.Utils.Helpers.allPlayersById();

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                String playerName = player.Data.PlayerName;

                player.cosmetics.nameText.text = ChallengerOS.Utils.Helpers.hidePlayerName(PlayerControl.LocalPlayer, player) ? ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x") : playerName;

                if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                {

                    if (Fake.Role != null)
                    {
                        if (player.Data.Role.IsImpostor || player == Fake.Role)
                        {
                            player.cosmetics.nameText.color = ImpostorColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else
                        {
                            player.cosmetics.nameText.color = WhiteColor;
                        }
                    }
                    else
                    {
                        if (player.Data.Role.IsImpostor)
                        {
                            player.cosmetics.nameText.color = ImpostorColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (player == Cultist.Role))
                        {
                            player.cosmetics.nameText.color = CulteColor;
                        }
                        else
                        {
                            player.cosmetics.nameText.color = WhiteColor;
                        }
                    }

                }
                else
                {
                    if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (player == Cultist.Role))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (player == Cultist.Role))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (player == Cultist.Culte3))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (player == Cultist.Culte1))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (player == Cultist.Culte2))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (player == Cultist.Role))
                    {
                        player.cosmetics.nameText.color = CulteColor;
                    }
                    else
                    {
                        player.cosmetics.nameText.color = WhiteColor;
                    }

                }
            }
            foreach (PlayerControl oiledplayers in OiledPlayers)
            {
                if (Arsonist.Role != null && Arsonist.Role == PlayerControl.LocalPlayer)
                {
                    oiledplayers.cosmetics.nameText.color = ArsonistColor;
                }
            }


            if (MeetingHud.Instance != null)
            {
                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                {
                    PlayerControl playerControl = playersById.ContainsKey((byte)player.TargetPlayerId) ? playersById[(byte)player.TargetPlayerId] : null;
                    if (playerControl != null)
                    {
                        player.NameText.text = playerControl.Data.PlayerName;

                        if (PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                        {
                            if (Fake.Role != null)
                            {
                                if (playerControl.Data.Role.IsImpostor || playerControl == Fake.Role)
                                {
                                    player.NameText.color = ImpostorColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else
                                {
                                    player.NameText.color = WhiteColor;
                                }
                            }
                            else
                            {
                                if (playerControl.Data.Role.IsImpostor)
                                {
                                    player.NameText.color = ImpostorColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                                {
                                    player.NameText.color = CulteColor;
                                }
                                else
                                {
                                    player.NameText.color = WhiteColor;
                                }
                            }

                        }
                        else
                        {
                            if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Role && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte1 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte2 && (Cultist.Culte3 != null) && (playerControl == Cultist.Culte3))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte1 != null) && (playerControl == Cultist.Culte1))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Culte2 != null) && (playerControl == Cultist.Culte2))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if ((Cultist.Role != null) && PlayerControl.LocalPlayer == Cultist.Culte3 && (Cultist.Role != null) && (playerControl == Cultist.Role))
                            {
                                player.NameText.color = CulteColor;
                            }
                            else if (Arsonist.Role != null && PlayerControl.LocalPlayer == Arsonist.Role)
                            {
                                foreach (PlayerControl oiledplayers in OiledPlayers)
                                {
                                    if (playerControl == oiledplayers)
                                    {
                                        player.NameText.color = ArsonistColor;
                                    }
                                }
                            }
                            else
                            {
                                player.NameText.color = WhiteColor;
                            }

                        }
                    }
                }
            }
        }
        
        static void updateImpostorKillButton(HudManager __instance)
        {
             __instance.KillButton.Hide();

        }
        static void updateUseButton(HudManager __instance)
        {
            if (MeetingHud.Instance) __instance.UseButton.Hide();
        }
        static void updateSabotageButton(HudManager __instance)
        {
            if (MeetingHud.Instance || (HudManager.Instance && Challenger.EmergencyDestroy)) __instance.SabotageButton.enabled = false;
            if (HudManager.Instance && !MeetingHud.Instance && !Challenger.EmergencyDestroy && PlayerControl.LocalPlayer.Data.Role.IsImpostor) __instance.SabotageButton.enabled = true;
        }
        static void updateAbilityButton(HudManager __instance)
        {
            __instance.AbilityButton.Hide();
           
        }
       


        static void Postfix(HudManager __instance)
        {




            if (AmongUsClient.Instance.GameState != InnerNetClient.GameStates.Started)
            {
                

                

                ChallengerMod.Challenger.RoleAssigned = false; //reset SetRoles

                if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("GameStartManager").transform.FindChild("PlayerCounter_TMP"))
                {
                    
                    
                    
                    ChallengerMod.ResetData.ResetSurvey();
                    ChallengerMod.ResetData.ResetPlayerTask();
                    ChallengerMod.ResetData.ResetWinData();
                    ChallengerMod.ResetData.ResetLobbySettings();
                    ChallengerMod.ResetData.ResetRolePick();
                    ChallengerMod.ResetData.ResetRoleData();
                    ChallengerMod.ResetData.ResetRolesCount();


                }
                
                ChallengerMod.Challenger.SetAdminTime = AdminTime.getFloat() + 0f;
                ChallengerMod.Challenger.SetVitalTime = VitalTime.getFloat() + 0f;
                ChallengerMod.Challenger.SetCamTime = CamTime.getFloat() + 0f;
                timerV = (int)Math.Round(ChallengerMod.Challenger.SetVitalTime);
                timerC = (int)Math.Round(ChallengerMod.Challenger.SetCamTime);
                timerA = (int)Math.Round(ChallengerMod.Challenger.SetAdminTime);
                timerN = (int)Math.Round(ChallengerMod.Challenger.NuclearTimer);
                timerLN = (int)Math.Round(ChallengerMod.Challenger.NuclearLastTimer);

                


                //CREATE_OBJECT
                if (GameObject.Find("Main Camera/Hud/GameStartManager/StartButton"))
                {
                    if (AmongUsClient.Instance.AmHost)
                    {
                        //PRESSET_1
                        if (GameObject.Find("PressetButton_1"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_1");
                            button.transform.localPosition = new Vector3(-0.6f, 2.15f, 1f);
                            button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            if (ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.getSelection() == 0)
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS1FR1;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS1EN1;
                                }
                            }
                            else
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS1FR0;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS1EN0;
                                }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.updateSelection(0);
                                ChallengerOS.Utils.Option.CustomOption.switchPreset(0);
                                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                            }
                        }
                        else
                        {
                            var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");
                            var ButtonParent = GameObject.Find("Main Camera/Hud/");
                            var button1 = UnityEngine.Object.Instantiate(CustomButton, null);
                            button1.transform.parent = ButtonParent.transform;
                            button1.transform.name = "PressetButton_1";
                        }

                        //PRESSET_2
                        if (GameObject.Find("PressetButton_2"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_2");
                            button.transform.localPosition = new Vector3(0f, 2.15f, 1f);
                            button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            if (ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.getSelection() == 1)
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS2FR1;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS2EN1;
                                }
                            }
                            else
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS2FR0;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS2EN0;
                                }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.updateSelection(1);
                                ChallengerOS.Utils.Option.CustomOption.switchPreset(1);
                                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                            }
                        }
                        else
                        {
                            var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");
                            var ButtonParent = GameObject.Find("Main Camera/Hud/");
                            var button1 = UnityEngine.Object.Instantiate(CustomButton, null);
                            button1.transform.parent = ButtonParent.transform;
                            button1.transform.name = "PressetButton_2";
                        }

                        //PRESSET_3
                        if (GameObject.Find("PressetButton_3"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_3");
                            button.transform.localPosition = new Vector3(0.6f, 2.15f, 1f);
                            button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            if (ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.getSelection() == 2)
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS3FR1;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS3EN1;
                                }
                            }
                            else
                            {
                                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS3FR0;
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = PS3EN0;
                                }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                ChallengerOS.Utils.Option.CustomOptionHolder.presetSelection.updateSelection(2);
                                ChallengerOS.Utils.Option.CustomOption.switchPreset(2);
                                ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                            }

                        }
                        else
                        {
                            var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");
                            var ButtonParent = GameObject.Find("Main Camera/Hud/");
                            var button1 = UnityEngine.Object.Instantiate(CustomButton, null);
                            button1.transform.parent = ButtonParent.transform;
                            button1.transform.name = "PressetButton_3";
                        }

                        //UI_RANKED_BUTTON
                        if (GameObject.Find("RankedButton"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/RankedButton");
                            

                            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                            {
                                if (RankedSettings == false)
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = UI2_BTTNFR;
                                    button.transform.localPosition = new Vector3(0f, 2.65f, 1f);
                                    button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = UI2_CreateConfirmFR;
                                }
                            }
                            else
                            {
                                if (RankedSettings == false)
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = UI2_BTTN;
                                    button.transform.localPosition = new Vector3(0f, 2.65f, 1f);
                                    button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                                }
                                else
                                {
                                    button.GetComponent<SpriteRenderer>().sprite = UI2_CreateConfirm;
                                }
                            }

                            

                        }
                        else
                        {
                            if (Challenger.IsrankedGame)
                            {
                                var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");
                                var ButtonParent = GameObject.Find("Main Camera/Hud/");
                                var button1 = UnityEngine.Object.Instantiate(CustomButton, null);
                                button1.transform.parent = ButtonParent.transform;
                                PassiveButton passiveButton = button1.GetComponent<PassiveButton>();
                                passiveButton.OnClick = new Button.ButtonClickedEvent();
                                passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                                void onClick()
                                {
                                    //OPENUI
                                    if (RankedSettings == false)
                                    {
                                        RankedSettings = true;
                                        PlayerControl.LocalPlayer.moveable = false;
                                        PlayerControl.LocalPlayer.MyPhysics.body.velocity = Vector2.zero;
                                    }
                                    else
                                    {
                                        RankedSettings = false;
                                        PlayerControl.LocalPlayer.moveable = true;
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                button1.transform.name = "RankedButton";
                            }
                            
                        }


                        //UI_RANKED
                        if (GameObject.Find("RankedUI"))
                        {
                            var UITAB = GameObject.Find("Main Camera/Hud/RankedUI");
                            UITAB.transform.localPosition = new Vector3(0f, 0f, -100f);
                            if (RankedSettings == false) { UITAB.transform.localScale = new Vector3(0f, 0f, 0f); }
                            else { UITAB.transform.localScale = new Vector3(0.4f, 0.4f, 1f); }
                        }
                        else
                        {
                            if (Challenger.IsrankedGame)
                            {
                                GameObject CustomUI = new GameObject();
                                var HUD = GameObject.Find("Main Camera/Hud/");
                                CustomUI.layer = 5;
                                CustomUI.transform.parent = HUD.transform;
                                CustomUI.transform.localScale = new Vector3(0f, 0f, 0f);


                                CustomUI.AddComponent<SpriteRenderer>().sprite = UI2_TAB;
                                CustomUI.transform.name = "RankedUI";

                                var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");


                                var IMP1 = UnityEngine.Object.Instantiate(CustomButton, null);
                                IMP1.transform.parent = CustomUI.transform;
                                IMP1.name = "IMP1";

                                var IMP2 = UnityEngine.Object.Instantiate(CustomButton, null);
                                IMP2.transform.parent = CustomUI.transform;
                                IMP2.name = "IMP2";

                                var IMP3 = UnityEngine.Object.Instantiate(CustomButton, null);
                                IMP3.transform.parent = CustomUI.transform;
                                IMP3.name = "IMP3";

                                var DUO0 = UnityEngine.Object.Instantiate(CustomButton, null);
                                DUO0.transform.parent = CustomUI.transform;
                                DUO0.name = "DUO0";

                                var DUO1 = UnityEngine.Object.Instantiate(CustomButton, null);
                                DUO1.transform.parent = CustomUI.transform;
                                DUO1.name = "DUO1";

                                var DUO2 = UnityEngine.Object.Instantiate(CustomButton, null);
                                DUO2.transform.parent = CustomUI.transform;
                                DUO2.name = "DUO2";

                                var DUO3 = UnityEngine.Object.Instantiate(CustomButton, null);
                                DUO3.transform.parent = CustomUI.transform;
                                DUO3.name = "DUO3";

                                var SPE0 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE0.transform.parent = CustomUI.transform;
                                SPE0.name = "SPE0";

                                var SPE1 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE1.transform.parent = CustomUI.transform;
                                SPE1.name = "SPE1";

                                var SPE2 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE2.transform.parent = CustomUI.transform;
                                SPE2.name = "SPE2";

                                var SPE3 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE3.transform.parent = CustomUI.transform;
                                SPE3.name = "SPE3";

                                var SPE4 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE4.transform.parent = CustomUI.transform;
                                SPE4.name = "SPE4";

                                var SPE5 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE5.transform.parent = CustomUI.transform;
                                SPE5.name = "SPE5";

                                var SPE6 = UnityEngine.Object.Instantiate(CustomButton, null);
                                SPE6.transform.parent = CustomUI.transform;
                                SPE6.name = "SPE6";

                                var MAP_POLUS = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_POLUS.transform.parent = CustomUI.transform;
                                MAP_POLUS.name = "MAP_POLUS";

                                var MAP_BPOLUS = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_BPOLUS.transform.parent = CustomUI.transform;
                                MAP_BPOLUS.name = "MAP_BPOLUS";

                                var MAP_CPOLUS = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_CPOLUS.transform.parent = CustomUI.transform;
                                MAP_CPOLUS.name = "MAP_CPOLUS";

                                var MAP_NPOLUS = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_NPOLUS.transform.parent = CustomUI.transform;
                                MAP_NPOLUS.name = "MAP_NPOLUS";

                                var MAP_SKELD = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_SKELD.transform.parent = CustomUI.transform;
                                MAP_SKELD.name = "MAP_SKELD";

                                var MAP_CSKELD = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_CSKELD.transform.parent = CustomUI.transform;
                                MAP_CSKELD.name = "MAP_CSKELD";

                                var MAP_MIRA = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_MIRA.transform.parent = CustomUI.transform;
                                MAP_MIRA.name = "MAP_MIRA";

                                var MAP_CMIRA = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_CMIRA.transform.parent = CustomUI.transform;
                                MAP_CMIRA.name = "MAP_CMIRA";

                                var MAP_AIRSHIP = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_AIRSHIP.transform.parent = CustomUI.transform;
                                MAP_AIRSHIP.name = "MAP_AIRSHIP";

                                var MAP_SUBMERGED = UnityEngine.Object.Instantiate(CustomButton, null);
                                MAP_SUBMERGED.transform.parent = CustomUI.transform;
                                MAP_SUBMERGED.name = "MAP_SUBMERGED";

                                var PMAX_ADD = UnityEngine.Object.Instantiate(CustomButton, null);
                                PMAX_ADD.transform.parent = CustomUI.transform;
                                PMAX_ADD.name = "PMAX_ADD";

                                var PMAX_REMOVE = UnityEngine.Object.Instantiate(CustomButton, null);
                                PMAX_REMOVE.transform.parent = CustomUI.transform;
                                PMAX_REMOVE.name = "PMAX_REMOVE";

                                var PMAX_NUM = UnityEngine.Object.Instantiate(CustomButton, null);
                                PMAX_NUM.transform.parent = CustomUI.transform;
                                PMAX_NUM.name = "PMAX_NUM";


                                var ROLE_CRW_SHERIFF = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SHERIFF.transform.parent = CustomUI.transform;
                                ROLE_CRW_SHERIFF.name = "ROLE_CRW_Sheriff1";

                                var ROLE_CRW_SHERIFF2 = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SHERIFF2.transform.parent = CustomUI.transform;
                                ROLE_CRW_SHERIFF2.name = "ROLE_CRW_Sheriff2";

                                var ROLE_CRW_SHERIFF3 = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SHERIFF3.transform.parent = CustomUI.transform;
                                ROLE_CRW_SHERIFF3.name = "ROLE_CRW_Sheriff3";

                                var ROLE_CRW_GUARDIAN = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_GUARDIAN.transform.parent = CustomUI.transform;
                                ROLE_CRW_GUARDIAN.name = "ROLE_CRW_Guardian";

                                var ROLE_CRW_ENGINEER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_ENGINEER.transform.parent = CustomUI.transform;
                                ROLE_CRW_ENGINEER.name = "ROLE_CRW_Engineer";

                                var ROLE_CRW_TMELORD = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_TMELORD.transform.parent = CustomUI.transform;
                                ROLE_CRW_TMELORD.name = "ROLE_CRW_Timelord";

                                var ROLE_CRW_HUNTER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_HUNTER.transform.parent = CustomUI.transform;
                                ROLE_CRW_HUNTER.name = "ROLE_CRW_Hunter";

                                var ROLE_CRW_MYSTIC = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_MYSTIC.transform.parent = CustomUI.transform;
                                ROLE_CRW_MYSTIC.name = "ROLE_CRW_Mystic";

                                var ROLE_CRW_SPIRIT = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SPIRIT.transform.parent = CustomUI.transform;
                                ROLE_CRW_SPIRIT.name = "ROLE_CRW_Spirit";

                                var ROLE_CRW_MAYOR = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_MAYOR.transform.parent = CustomUI.transform;
                                ROLE_CRW_MAYOR.name = "ROLE_CRW_Mayor";

                                var ROLE_CRW_DETECTIVE = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_DETECTIVE.transform.parent = CustomUI.transform;
                                ROLE_CRW_DETECTIVE.name = "ROLE_CRW_Detective";

                                var ROLE_CRW_NIGHTWATCH = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_NIGHTWATCH.transform.parent = CustomUI.transform;
                                ROLE_CRW_NIGHTWATCH.name = "ROLE_CRW_Nightwatch";

                                var ROLE_CRW_SPY = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SPY.transform.parent = CustomUI.transform;
                                ROLE_CRW_SPY.name = "ROLE_CRW_Spy";

                                var ROLE_CRW_INFORMANT = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_INFORMANT.transform.parent = CustomUI.transform;
                                ROLE_CRW_INFORMANT.name = "ROLE_CRW_Informant";

                                var ROLE_CRW_BAIT = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_BAIT.transform.parent = CustomUI.transform;
                                ROLE_CRW_BAIT.name = "ROLE_CRW_Bait";

                                var ROLE_CRW_MENTALIST = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_MENTALIST.transform.parent = CustomUI.transform;
                                ROLE_CRW_MENTALIST.name = "ROLE_CRW_Mentalist";

                                var ROLE_CRW_BUILDER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_BUILDER.transform.parent = CustomUI.transform;
                                ROLE_CRW_BUILDER.name = "ROLE_CRW_Builder";

                                var ROLE_CRW_DICTATOR = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_DICTATOR.transform.parent = CustomUI.transform;
                                ROLE_CRW_DICTATOR.name = "ROLE_CRW_Dictator";

                                var ROLE_CRW_SENTINEL = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_SENTINEL.transform.parent = CustomUI.transform;
                                ROLE_CRW_SENTINEL.name = "ROLE_CRW_Sentinel";

                                var ROLE_CRW_TEAMMATE = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_TEAMMATE.transform.parent = CustomUI.transform;
                                ROLE_CRW_TEAMMATE.name = "ROLE_CRW_Teammate";

                                var ROLE_CRW_LAWKEEPER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_LAWKEEPER.transform.parent = CustomUI.transform;
                                ROLE_CRW_LAWKEEPER.name = "ROLE_CRW_Lawkeeper";

                                var ROLE_CRW_FAKE = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_FAKE.transform.parent = CustomUI.transform;
                                ROLE_CRW_FAKE.name = "ROLE_CRW_Fake";

                                var ROLE_CRW_LEADER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_LEADER.transform.parent = CustomUI.transform;
                                ROLE_CRW_LEADER.name = "ROLE_CRW_Leader";

                                var ROLE_CRW_DOCTOR = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_DOCTOR.transform.parent = CustomUI.transform;
                                ROLE_CRW_DOCTOR.name = "ROLE_CRW_Doctor";

                                var ROLE_CRW_TRAVELER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_CRW_TRAVELER.transform.parent = CustomUI.transform;
                                ROLE_CRW_TRAVELER.name = "ROLE_CRW_Traveler";



                                var ROLE_DUO_MERCENARY = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_DUO_MERCENARY.transform.parent = CustomUI.transform;
                                ROLE_DUO_MERCENARY.name = "ROLE_DUO_Mercenary";

                                var ROLE_DUO_COPYCAT = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_DUO_COPYCAT.transform.parent = CustomUI.transform;
                                ROLE_DUO_COPYCAT.name = "ROLE_DUO_Copycat";

                                var ROLE_DUO_REVENGER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_DUO_REVENGER.transform.parent = CustomUI.transform;
                                ROLE_DUO_REVENGER.name = "ROLE_DUO_Revenger";

                                var ROLE_DUO_SURVIVOR = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_DUO_SURVIVOR.transform.parent = CustomUI.transform;
                                ROLE_DUO_SURVIVOR.name = "ROLE_DUO_Survivor";

                                var ROLE_DUO_SLAVE = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_DUO_SLAVE.transform.parent = CustomUI.transform;
                                ROLE_DUO_SLAVE.name = "ROLE_DUO_Slave";


                                var ROLE_SPE_CUPID = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_CUPID.transform.parent = CustomUI.transform;
                                ROLE_SPE_CUPID.name = "ROLE_SPE_Cupid";

                                var ROLE_SPE_CULTIST = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_CULTIST.transform.parent = CustomUI.transform;
                                ROLE_SPE_CULTIST.name = "ROLE_SPE_Cultist";

                                var ROLE_SPE_JESTER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_JESTER.transform.parent = CustomUI.transform;
                                ROLE_SPE_JESTER.name = "ROLE_SPE_Jester";

                                var ROLE_SPE_EATER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_EATER.transform.parent = CustomUI.transform;
                                ROLE_SPE_EATER.name = "ROLE_SPE_Eater";

                                var ROLE_SPE_OUTLAW = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_OUTLAW.transform.parent = CustomUI.transform;
                                ROLE_SPE_OUTLAW.name = "ROLE_SPE_Outlaw";

                                var ROLE_SPE_ARSONIST = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_ARSONIST.transform.parent = CustomUI.transform;
                                ROLE_SPE_ARSONIST.name = "ROLE_SPE_Arsonist";

                                var ROLE_SPE_CURSED = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_SPE_CURSED.transform.parent = CustomUI.transform;
                                ROLE_SPE_CURSED.name = "ROLE_SPE_Cursed";


                                var ROLE_IMP_ASSASSIN = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_ASSASSIN.transform.parent = CustomUI.transform;
                                ROLE_IMP_ASSASSIN.name = "ROLE_IMP_Assassin";

                                var ROLE_IMP_VECTOR = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_VECTOR.transform.parent = CustomUI.transform;
                                ROLE_IMP_VECTOR.name = "ROLE_IMP_Vector";

                                var ROLE_IMP_MORPHLING = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_MORPHLING.transform.parent = CustomUI.transform;
                                ROLE_IMP_MORPHLING.name = "ROLE_IMP_Morphling";

                                var ROLE_IMP_SCRAMBLER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_SCRAMBLER.transform.parent = CustomUI.transform;
                                ROLE_IMP_SCRAMBLER.name = "ROLE_IMP_Scrambler";

                                var ROLE_IMP_BARGHEST = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_BARGHEST.transform.parent = CustomUI.transform;
                                ROLE_IMP_BARGHEST.name = "ROLE_IMP_Barghest";

                                var ROLE_IMP_GHOST = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_GHOST.transform.parent = CustomUI.transform;
                                ROLE_IMP_GHOST.name = "ROLE_IMP_Ghost";

                                var ROLE_IMP_SORCERER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_SORCERER.transform.parent = CustomUI.transform;
                                ROLE_IMP_SORCERER.name = "ROLE_IMP_Sorcerer";

                                var ROLE_IMP_GUESSER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_GUESSER.transform.parent = CustomUI.transform;
                                ROLE_IMP_GUESSER.name = "ROLE_IMP_Guesser";

                                var ROLE_IMP_BASILISK = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_BASILISK.transform.parent = CustomUI.transform;
                                ROLE_IMP_BASILISK.name = "ROLE_IMP_Basilisk";

                                var ROLE_IMP_REAPER = UnityEngine.Object.Instantiate(CustomButton, null);
                                ROLE_IMP_REAPER.transform.parent = CustomUI.transform;
                                ROLE_IMP_REAPER.name = "ROLE_IMP_Reaper";


                            }

                        }

                        if (GameObject.Find("MAP_POLUS"))
                        {
                            var button = GameObject.Find("MAP_POLUS");
                            button.transform.localPosition = new Vector3(4.175f, 4.7f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 0) { button.GetComponent<SpriteRenderer>().sprite = UI2_Polus1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Polus0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 0)
                                {
                                    Challenger._MapID = 0;
                                    PlayerControl.GameOptions.MapId = 2;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(2);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(2);
                                    BetterMapPL.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_BPOLUS"))
                        {
                            var button = GameObject.Find("MAP_BPOLUS");
                            button.transform.localPosition = new Vector3(5.8f, 4.7f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 1) { button.GetComponent<SpriteRenderer>().sprite = UI2_Bpolus1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Bpolus0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 1)
                                {
                                    Challenger._MapID = 1;
                                    PlayerControl.GameOptions.MapId = 2;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(2);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(2);
                                    BetterMapPL.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_CPOLUS"))
                        {
                            var button = GameObject.Find("MAP_CPOLUS");
                            button.transform.localPosition = new Vector3(4.175f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 2) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cpolus1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Cpolus0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 2)
                                {
                                    Challenger._MapID = 2;
                                    PlayerControl.GameOptions.MapId = 2;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(2);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(2);
                                    BetterMapPL.updateSelection(2);
                                    NuclearTimerMod.updateSelection(0);
                                    NuclearRND.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();

                                }
                            }
                        }
                        if (GameObject.Find("MAP_NPOLUS"))
                        {
                            var button = GameObject.Find("MAP_NPOLUS");
                            button.transform.localPosition = new Vector3(5.8f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 3) { button.GetComponent<SpriteRenderer>().sprite = UI2_Npolus1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Npolus0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 3)
                                {
                                    Challenger._MapID = 3;
                                    PlayerControl.GameOptions.MapId = 2;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(2);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(2);
                                    BetterMapPL.updateSelection(2);
                                    NuclearRND.updateSelection(20);
                                    NuclearTimerMod.updateSelection(1);
                                    NuclearHide.updateSelection(2);
                                    NuclearTime1.updateSelection(0);
                                    NuclearTimeRND.updateSelection(24);
                                    NuclearTime2.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    
                                }
                            }
                        }
                        if (GameObject.Find("MAP_SKELD"))
                        {
                            var button = GameObject.Find("MAP_SKELD");
                            button.transform.localPosition = new Vector3(4.175f, 1.4f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 4) { button.GetComponent<SpriteRenderer>().sprite = UI2_Skeld1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Skeld0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 4)
                                {
                                    Challenger._MapID = 4;
                                    PlayerControl.GameOptions.MapId = 0;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(0);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(0);
                                    BetterMapSK.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_CSKELD"))
                        {
                            var button = GameObject.Find("MAP_CSKELD");
                            button.transform.localPosition = new Vector3(5.8f, 1.4f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 5) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cskeld1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Csleld0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 5)
                                {
                                    Challenger._MapID = 5;
                                    PlayerControl.GameOptions.MapId = 0;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(0);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(0);
                                    BetterMapSK.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_MIRA"))
                        {
                            var button = GameObject.Find("MAP_MIRA");
                            button.transform.localPosition = new Vector3(4.175f, -0.3f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 6) { button.GetComponent<SpriteRenderer>().sprite = UI2_Mira1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Mira0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 6)
                                {
                                    Challenger._MapID = 6;
                                    PlayerControl.GameOptions.MapId = 1;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(1);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(1);
                                    BetterMapHQ.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_CMIRA"))
                        {
                            var button = GameObject.Find("MAP_CMIRA");
                            button.transform.localPosition = new Vector3(5.8f, -0.3f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 7) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cmira1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Cmira0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 7)
                                {
                                    Challenger._MapID = 7;
                                    PlayerControl.GameOptions.MapId = 1;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(1);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(1);
                                    BetterMapHQ.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_AIRSHIP"))
                        {
                            var button = GameObject.Find("MAP_AIRSHIP");
                            button.transform.localPosition = new Vector3(4.175f, -2f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 8) { button.GetComponent<SpriteRenderer>().sprite = UI2_Airship1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Airship0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 8)
                                {
                                    Challenger._MapID = 8;
                                    PlayerControl.GameOptions.MapId = 4;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(4);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(4);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("MAP_SUBMERGED"))
                        {
                            var button = GameObject.Find("MAP_SUBMERGED");
                            button.transform.localPosition = new Vector3(5.8f, -2f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._MapID == 9) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sub1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sub0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._MapID != 9)
                                {
                                    Challenger._MapID = 9;
                                    PlayerControl.GameOptions.MapId = 5;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewMapID, Hazel.SendOption.Reliable);
                                    writer.Write(5);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewMapID(5);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("PMAX_REMOVE"))
                        {
                            var button = GameObject.Find("PMAX_REMOVE");
                            button.transform.localPosition = new Vector3(3.9f, -5f, -1f);
                            button.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                            if (PlayerControl.GameOptions.MaxPlayers > 10 && GameStartManager.Instance.LastPlayerCount < PlayerControl.GameOptions.MaxPlayers)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PMREM1;
                            }
                            else
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PMREM0;
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (GameStartManager.Instance.LastPlayerCount < PlayerControl.GameOptions.MaxPlayers)
                                {

                                    if (PlayerControl.GameOptions.MaxPlayers == 11)
                                    {
                                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                        writer.Write(10);
                                        writer.EndMessage();
                                        RPCProcedure.shareNewPLayerSlot(10);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else if (PlayerControl.GameOptions.MaxPlayers == 12)
                                    {
                                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                        writer.Write(11);
                                        writer.EndMessage();
                                        RPCProcedure.shareNewPLayerSlot(11);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else if (PlayerControl.GameOptions.MaxPlayers == 13)
                                    {
                                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                        writer.Write(12);
                                        writer.EndMessage();
                                        RPCProcedure.shareNewPLayerSlot(12);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else if (PlayerControl.GameOptions.MaxPlayers == 14)
                                    {
                                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                        writer.Write(13);
                                        writer.EndMessage();
                                        RPCProcedure.shareNewPLayerSlot(13);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else if (PlayerControl.GameOptions.MaxPlayers >= 15)
                                    {
                                        MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                        writer.Write(14);
                                        writer.EndMessage();
                                        RPCProcedure.shareNewPLayerSlot(14);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else { }
                                }

                            }
                        }
                        if (GameObject.Find("PMAX_ADD"))
                        {
                            var button = GameObject.Find("PMAX_ADD");
                            button.transform.localPosition = new Vector3(5.9f, -5f, -1f);
                            button.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                            if (PlayerControl.GameOptions.MaxPlayers < 15)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PMADD1;
                            }
                            else
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PMADD0;
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (PlayerControl.GameOptions.MaxPlayers == 14)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                    writer.Write(15);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewPLayerSlot(15);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else if (PlayerControl.GameOptions.MaxPlayers == 13)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                    writer.Write(14);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewPLayerSlot(14);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else if (PlayerControl.GameOptions.MaxPlayers == 12)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                    writer.Write(13);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewPLayerSlot(13);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else if (PlayerControl.GameOptions.MaxPlayers == 11)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                    writer.Write(12);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewPLayerSlot(12);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else if (PlayerControl.GameOptions.MaxPlayers <= 10)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareNewPLayerSlot, Hazel.SendOption.Reliable);
                                    writer.Write(11);
                                    writer.EndMessage();
                                    RPCProcedure.shareNewPLayerSlot(11);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else { }
                            }
                        }
                        if (GameObject.Find("PMAX_NUM"))
                        {
                            var button = GameObject.Find("PMAX_NUM");
                            button.transform.localPosition = new Vector3(4.9f, -5f, -1f);
                            button.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
                            
                            if (PlayerControl.GameOptions.MaxPlayers == 10) 
                            { 
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM10; 
                            }
                            else if (PlayerControl.GameOptions.MaxPlayers == 11)
                            { 
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM11;
                            }
                            else if (PlayerControl.GameOptions.MaxPlayers == 12)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM12;
                            }
                            else if (PlayerControl.GameOptions.MaxPlayers == 13)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM13;
                            }
                            else if (PlayerControl.GameOptions.MaxPlayers == 14)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM14;
                            }
                            else if (PlayerControl.GameOptions.MaxPlayers == 15)
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_PM15;
                            }
                        }
                        


                        if (GameObject.Find("IMP1"))
                        {
                            var button = GameObject.Find("IMP1");
                            button.transform.localPosition = new Vector3(-4.5f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._IMP == 1) { button.GetComponent<SpriteRenderer>().sprite = UI2_1N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_1N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._IMP != 1)
                                {
                                    Challenger._IMP = 1;
                                    PlayerControl.GameOptions.NumImpostors = 1;
                                    QTImp.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("IMP2"))
                        {
                            var button = GameObject.Find("IMP2");
                            button.transform.localPosition = new Vector3(-3.7f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._IMP == 2) { button.GetComponent<SpriteRenderer>().sprite = UI2_2N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_2N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._IMP != 2)
                                {
                                    Challenger._IMP = 2;
                                    PlayerControl.GameOptions.NumImpostors = 2;
                                    QTImp.updateSelection(2);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("IMP3"))
                        {
                            var button = GameObject.Find("IMP3");
                            button.transform.localPosition = new Vector3(-2.9f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 13) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._IMP == 3) { button.GetComponent<SpriteRenderer>().sprite = UI2_3N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_3N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._IMP != 3 && Challenger._Players >= 13)
                                {
                                    Challenger._IMP = 3;
                                    PlayerControl.GameOptions.NumImpostors = 3;
                                    QTImp.updateSelection(3);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }

                        if (GameObject.Find("DUO0"))
                        {
                            var button = GameObject.Find("DUO0");
                            button.transform.localPosition = new Vector3(-0.25f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._DUO == 0) { button.GetComponent<SpriteRenderer>().sprite = UI2_0N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_0N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._DUO != 0)
                                {
                                    Challenger._DUO = 0;
                                    QTDuo.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }

                        if (GameObject.Find("DUO1"))
                        {
                            var button = GameObject.Find("DUO1");
                            button.transform.localPosition = new Vector3(0.65f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._DUO == 1) { button.GetComponent<SpriteRenderer>().sprite = UI2_1N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_1N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._DUO != 1)
                                {
                                    Challenger._DUO = 1;
                                    QTDuo.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("DUO2"))
                        {
                            var button = GameObject.Find("DUO2");
                            button.transform.localPosition = new Vector3(1.45f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 11) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._DUO == 2) { button.GetComponent<SpriteRenderer>().sprite = UI2_2N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_2N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 11)
                                {

                                }
                                else
                                {
                                    if (Challenger._DUO != 2)
                                    {
                                        Challenger._DUO = 2;
                                        QTDuo.updateSelection(2);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }
                        if (GameObject.Find("DUO3"))
                        {
                            var button = GameObject.Find("DUO3");
                            button.transform.localPosition = new Vector3(2.25f, 5.365f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);

                            if (Challenger._Players < 12) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._DUO == 3) { button.GetComponent<SpriteRenderer>().sprite = UI2_3N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_3N0; }
                            }

                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 12)
                                {

                                }
                                else
                                {
                                    if (Challenger._DUO != 3)
                                    {
                                        Challenger._DUO = 3;
                                        QTDuo.updateSelection(3);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }

                        if (GameObject.Find("SPE0"))
                        {
                            var button = GameObject.Find("SPE0");
                            button.transform.localPosition = new Vector3(-4.5f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._SPE == 0) { button.GetComponent<SpriteRenderer>().sprite = UI2_0N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_0N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._SPE != 0)
                                {
                                    Challenger._SPE = 0;
                                    QTSpe.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }

                        if (GameObject.Find("SPE1"))
                        {
                            var button = GameObject.Find("SPE1");
                            button.transform.localPosition = new Vector3(-3.7f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._SPE == 1) { button.GetComponent<SpriteRenderer>().sprite = UI2_1N1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_1N0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._SPE != 1)
                                {
                                    Challenger._SPE = 1;
                                    QTSpe.updateSelection(1);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("SPE2"))
                        {
                            var button = GameObject.Find("SPE2");
                            button.transform.localPosition = new Vector3(-2.9f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 11) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._SPE == 2) { button.GetComponent<SpriteRenderer>().sprite = UI2_2N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_2N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 11)
                                {

                                }
                                else
                                {
                                    if (Challenger._SPE != 2)
                                    {
                                        Challenger._SPE = 2;
                                        QTSpe.updateSelection(2);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }
                        if (GameObject.Find("SPE3"))
                        {
                            var button = GameObject.Find("SPE3");
                            button.transform.localPosition = new Vector3(-2.1f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 12) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._SPE == 3) { button.GetComponent<SpriteRenderer>().sprite = UI2_3N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_3N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 12)
                                {

                                }
                                else
                                {
                                    if (Challenger._SPE != 3)
                                    {
                                        Challenger._SPE = 3;
                                        QTSpe.updateSelection(3);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }
                        if (GameObject.Find("SPE4"))
                        {
                            var button = GameObject.Find("SPE4");
                            button.transform.localPosition = new Vector3(-1.3f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 13) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._SPE == 4) { button.GetComponent<SpriteRenderer>().sprite = UI2_4N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_4N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 13)
                                {

                                }
                                else
                                {
                                    if (Challenger._SPE != 4)
                                    {
                                        Challenger._SPE = 4;
                                        QTSpe.updateSelection(4);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }
                        if (GameObject.Find("SPE5"))
                        {
                            var button = GameObject.Find("SPE5");
                            button.transform.localPosition = new Vector3(-0.5f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 14) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._SPE == 5) { button.GetComponent<SpriteRenderer>().sprite = UI2_5N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_5N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 14)
                                {

                                }
                                else
                                {
                                    if (Challenger._SPE != 5)
                                    {
                                        Challenger._SPE = 5;
                                        QTSpe.updateSelection(5);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }
                        if (GameObject.Find("SPE6"))
                        {
                            var button = GameObject.Find("SPE6");
                            button.transform.localPosition = new Vector3(0.3f, 4.52f, -1f);
                            button.transform.localScale = new Vector3(1f, 1f, 1f);
                            if (Challenger._Players < 15) { button.GetComponent<SpriteRenderer>().sprite = UI2_NUMBER_LOCK; }
                            else
                            {
                                if (Challenger._SPE == 6) { button.GetComponent<SpriteRenderer>().sprite = UI2_6N1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_6N0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (Challenger._Players < 15)
                                {

                                }
                                else
                                {
                                    if (Challenger._SPE != 6)
                                    {
                                        Challenger._SPE = 6;
                                        QTSpe.updateSelection(6);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                            }
                        }

                        if (GameObject.Find("ROLE_CRW_Sheriff1"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Sheriff1");
                            button.transform.localPosition = new Vector3(-5.5f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.SherifMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.SherifMin != 1f)
                                {
                                    SherifAdd.updateSelection(1);
                                    SherifSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SherifSpawnChance.updateSelection(0);
                                    if (ChallengerMod.Set.Data.Sherif2Min == 0f && ChallengerMod.Set.Data.Sherif3Min == 0f) { SherifAdd.updateSelection(0); }
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Sheriff2"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Sheriff2");
                            button.transform.localPosition = new Vector3(-4.1f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.Sherif2Min == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.Sherif2Min != 1f)
                                {
                                    SherifAdd.updateSelection(1);
                                    Sherif2SpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    Sherif2SpawnChance.updateSelection(0);
                                    if (ChallengerMod.Set.Data.SherifMin == 0f && ChallengerMod.Set.Data.Sherif3Min == 0f) { SherifAdd.updateSelection(0); }
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Sheriff3"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Sheriff3");
                            button.transform.localPosition = new Vector3(-2.7f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.Sherif3Min == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sheriff0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.Sherif3Min != 1f)
                                {
                                    SherifAdd.updateSelection(1);
                                    Sherif3SpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    Sherif3SpawnChance.updateSelection(0);
                                    if (ChallengerMod.Set.Data.SherifMin == 0f && ChallengerMod.Set.Data.Sherif2Min == 0f) { SherifAdd.updateSelection(0); }
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();


                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Guardian"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Guardian");
                            button.transform.localPosition = new Vector3(-1.3f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.GuardianMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Guardian1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Guardian0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.GuardianMin != 1f)
                                {
                                    GuardianAdd.updateSelection(1);
                                    GuardianSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    GuardianSpawnChance.updateSelection(0);
                                    GuardianAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Engineer"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Engineer");
                            button.transform.localPosition = new Vector3(0.1f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.EngineerMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Engineer1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Engineer0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.EngineerMin != 1f)
                                {
                                    engineerAdd.updateSelection(1);
                                    engineerSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    engineerSpawnChance.updateSelection(0);
                                    engineerAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Timelord"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Timelord");
                            button.transform.localPosition = new Vector3(1.5f, 3.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.TimelordMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Timelord1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Timelord0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.TimelordMin != 1f)
                                {
                                    TimeLordAdd.updateSelection(1);
                                    TimeLordSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    TimeLordSpawnChance.updateSelection(0);
                                    TimeLordAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Hunter"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Hunter");
                            button.transform.localPosition = new Vector3(-5.5f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.HunterMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Hunter1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Hunter0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.HunterMin != 1f)
                                {
                                    HunterAdd.updateSelection(1);
                                    HunterSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    HunterSpawnChance.updateSelection(0);
                                    HunterAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Mystic"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Mystic");
                            button.transform.localPosition = new Vector3(-4.1f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.MysticMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Mystic1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Mystic0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.MysticMin != 1f)
                                {
                                    MysticAdd.updateSelection(1);
                                    MysticSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    MysticSpawnChance.updateSelection(0);
                                    MysticAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Spirit"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Spirit");
                            button.transform.localPosition = new Vector3(-2.7f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.SpiritMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Spirit1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Spirit0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.SpiritMin != 1f)
                                {
                                    SpiritAdd.updateSelection(1);
                                    SpiritSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SpiritSpawnChance.updateSelection(0);
                                    SpiritAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Mayor"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Mayor");
                            button.transform.localPosition = new Vector3(-1.3f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.MayorMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Mayor1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Mayor0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.MayorMin != 1f)
                                {
                                    MayorAdd.updateSelection(1);
                                    MayorSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    MayorSpawnChance.updateSelection(0);
                                    MayorAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Detective"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Detective");
                            button.transform.localPosition = new Vector3(0.1f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.DetectiveMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Detective1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Detective0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.DetectiveMin != 1f)
                                {
                                    DetectiveAdd.updateSelection(1);
                                    DetectiveSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    DetectiveSpawnChance.updateSelection(0);
                                    DetectiveAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Nightwatch"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Nightwatch");
                            button.transform.localPosition = new Vector3(1.5f, 2.3f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.NightwatcherMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Nightwatch1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Nightwatch0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.NightwatcherMin != 1f)
                                {
                                    NightwatcherAdd.updateSelection(1);
                                    NightwatcherSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    NightwatcherSpawnChance.updateSelection(0);
                                    NightwatcherAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Spy"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Spy");
                            button.transform.localPosition = new Vector3(-5.5f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.SpyMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Spy1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Spy0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.SpyMin != 1f)
                                {
                                    SpyAdd.updateSelection(1);
                                    SpySpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SpySpawnChance.updateSelection(0);
                                    SpyAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Informant"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Informant");
                            button.transform.localPosition = new Vector3(-4.1f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.InforMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Informant1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Informant0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.InforMin != 1f)
                                {
                                    InforAdd.updateSelection(1);
                                    InforSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    InforSpawnChance.updateSelection(0);
                                    InforAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Bait"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Bait");
                            button.transform.localPosition = new Vector3(-2.7f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.BaitMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Bait1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Bait0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.BaitMin != 1f)
                                {
                                    BaitAdd.updateSelection(1);
                                    BaitSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    BaitSpawnChance.updateSelection(0);
                                    BaitAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Mentalist"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Mentalist");
                            button.transform.localPosition = new Vector3(-1.3f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.MentalistMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Mentalist1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Mentalist0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.MentalistMin != 1f)
                                {
                                    MentalistAdd.updateSelection(1);
                                    MentalistSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    MentalistSpawnChance.updateSelection(0);
                                    MentalistAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Builder"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Builder");
                            button.transform.localPosition = new Vector3(0.1f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.BuilderMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Builder1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Builder0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.BuilderMin != 1f)
                                {
                                    BuilderAdd.updateSelection(1);
                                    BuilderSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    BuilderSpawnChance.updateSelection(0);
                                    BuilderAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Dictator"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Dictator");
                            button.transform.localPosition = new Vector3(1.5f, 1.5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.DictatorMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Dictator1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Dictator0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.DictatorMin != 1f)
                                {
                                    DictatorAdd.updateSelection(1);
                                    DictatorSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    DictatorSpawnChance.updateSelection(0);
                                    DictatorAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Sentinel"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Sentinel");
                            button.transform.localPosition = new Vector3(-5.5f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.SentinelMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sentinel1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sentinel0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.SentinelMin != 1f)
                                {
                                    SentinelAdd.updateSelection(1);
                                    SentinelSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SentinelSpawnChance.updateSelection(0);
                                    SentinelAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Teammate"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Teammate");
                            button.transform.localPosition = new Vector3(-4.1f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.Team1Min == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Teammate1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Teammate0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.Team1Min != 1f)
                                {
                                    MateAdd.updateSelection(1);
                                    MateSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    MateSpawnChance.updateSelection(0);
                                    MateAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Lawkeeper"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Lawkeeper");
                            button.transform.localPosition = new Vector3(-2.7f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.LawkeeperMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Lawkeeper1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Lawkeeper0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.LawkeeperMin != 1f)
                                {
                                    LawkeeperAdd.updateSelection(1);
                                    LawkeeperSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    LawkeeperSpawnChance.updateSelection(0);
                                    LawkeeperAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Fake"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Fake");
                            button.transform.localPosition = new Vector3(-1.3f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (Challenger._IMP == 1) { button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK; }
                            else
                            {
                                if (ChallengerMod.Set.Data.FakeMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Fake1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_Fake0; }
                            }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.FakeMin != 1f)
                                {
                                    FakeAdd.updateSelection(1);
                                    FakeSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    FakeSpawnChance.updateSelection(0);
                                    FakeAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Leader"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Leader");
                            button.transform.localPosition = new Vector3(0.1f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.LeaderMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Leader1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Leader0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.LeaderMin != 1f)
                                {
                                    LeaderAdd.updateSelection(1);
                                    LeaderSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    LeaderSpawnChance.updateSelection(0);
                                    LeaderAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Doctor"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Doctor");
                            button.transform.localPosition = new Vector3(1.5f, 0.7f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK;
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                
                                
                            }
                        }
                        if (GameObject.Find("ROLE_CRW_Traveler"))
                        {
                            var button = GameObject.Find("ROLE_CRW_Traveler");
                            button.transform.localPosition = new Vector3(-5.5f, -0.1f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK; 
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                
                            }
                        }

                        if (GameObject.Find("ROLE_IMP_Assassin"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Assassin");
                            button.transform.localPosition = new Vector3(-5.5f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.AssassinMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Assassin1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Assassin0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.AssassinMin != 1f)
                                {
                                    AssassinAdd.updateSelection(1);
                                    AssassinSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    AssassinSpawnChance.updateSelection(0);
                                    AssassinAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Vector"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Vector");
                            button.transform.localPosition = new Vector3(-4.1f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.VectorMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Vector1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Vector0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.VectorMin != 1f)
                                {
                                    VectorAdd.updateSelection(1);
                                    VectorSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    VectorSpawnChance.updateSelection(0);
                                    VectorAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Morphling"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Morphling");
                            button.transform.localPosition = new Vector3(-2.7f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.MorphMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Morphling1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Morphling0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.MorphMin != 1f)
                                {
                                    MorphlingAdd.updateSelection(1);
                                    MorphlingSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    MorphlingSpawnChance.updateSelection(0);
                                    MorphlingAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Scrambler"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Scrambler");
                            button.transform.localPosition = new Vector3(-1.3f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.CamoMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Scrambler1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Scrambler0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.CamoMin != 1f)
                                {
                                    CamoAdd.updateSelection(1);
                                    CamoSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    CamoSpawnChance.updateSelection(0);
                                    CamoAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Barghest"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Barghest");
                            button.transform.localPosition = new Vector3(0.1f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.BarghestMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Barghest1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Barghest0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.BarghestMin != 1f)
                                {
                                    BarghestAdd.updateSelection(1);
                                    BarghestSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    BarghestSpawnChance.updateSelection(0);
                                    BarghestAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Ghost"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Ghost");
                            button.transform.localPosition = new Vector3(1.5f, -1.55f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.GhostMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Ghost1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Ghost0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.GhostMin != 1f)
                                {
                                    GhostAdd.updateSelection(1);
                                    GhostSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    GhostSpawnChance.updateSelection(0);
                                    GhostAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Sorcerer"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Sorcerer");
                            button.transform.localPosition = new Vector3(-5.5f, -2.35f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.Impo4Min == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Sorcerer1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Sorcerer0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.Impo4Min != 1f)
                                {
                                    SorcererAdd.updateSelection(1);
                                    SorcererSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SorcererSpawnChance.updateSelection(0);
                                    SorcererAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Guesser"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Guesser");
                            button.transform.localPosition = new Vector3(-4.1f, -2.35f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.GuesserMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Guesser1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Guesser0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.GuesserMin != 1f)
                                {
                                    GuesserAdd.updateSelection(1);
                                    GuesserSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    GuesserSpawnChance.updateSelection(0);
                                    GuesserAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Basilisk"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Basilisk");
                            button.transform.localPosition = new Vector3(-2.7f, -2.35f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.BasiliskMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Basilisk1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Basilisk0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.BasiliskMin != 1f)
                                {
                                    BasiliskAdd.updateSelection(1);
                                    BasiliskSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    BasiliskSpawnChance.updateSelection(0);
                                    BasiliskAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_IMP_Reaper"))
                        {
                            var button = GameObject.Find("ROLE_IMP_Reaper");
                            button.transform.localPosition = new Vector3(-1.3f, -2.35f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK;
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                
                            }
                        }
                        if (GameObject.Find("ROLE_DUO_Mercenary"))
                        {
                            var button = GameObject.Find("ROLE_DUO_Mercenary");
                            button.transform.localPosition = new Vector3(-5.5f, -3.6f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if ((Challenger._IMP == 3 && Challenger._Players < 15) 
                                || (Challenger._IMP == 2 && Challenger._Players < 12)
                                ) 
                            {
                                button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK;
                            }
                            else
                            {
                                if (ChallengerMod.Set.Data.MercenaryMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Mercenary1; }
                                else { button.GetComponent<SpriteRenderer>().sprite = UI2_Mercenary0; }
                            }
                           
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if ((Challenger._IMP == 3 && Challenger._Players < 15)
                                || (Challenger._IMP == 2 && Challenger._Players < 12)
                                )
                                {

                                }
                                else
                                {
                                    if (ChallengerMod.Set.Data.MercenaryMin != 1f)
                                    {
                                        MercenaryAdd.updateSelection(1);
                                        MercenarySpawnChance.updateSelection(20);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                    else
                                    {
                                        MercenarySpawnChance.updateSelection(0);
                                        MercenaryAdd.updateSelection(0);
                                        ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                    }
                                }
                                    
                            }
                        }
                        if (GameObject.Find("ROLE_DUO_Copycat"))
                        {
                            var button = GameObject.Find("ROLE_DUO_Copycat");
                            button.transform.localPosition = new Vector3(-4.1f, -3.6f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.CopyCatMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_CopyCat1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_CopyCat0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.CopyCatMin != 1f)
                                {
                                    CopyCatAdd.updateSelection(1);
                                    CopyCatSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    CopyCatSpawnChance.updateSelection(0);
                                    CopyCatAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_DUO_Revenger"))
                        {
                            var button = GameObject.Find("ROLE_DUO_Revenger");
                            button.transform.localPosition = new Vector3(-2.7f, -3.6f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.RevengerMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Revenger1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Revenger0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.RevengerMin != 1f)
                                {
                                    RevengerAdd.updateSelection(1);
                                    RevengerSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    RevengerSpawnChance.updateSelection(0);
                                    RevengerAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_DUO_Survivor"))
                        {
                            var button = GameObject.Find("ROLE_DUO_Survivor");
                            button.transform.localPosition = new Vector3(-1.3f, -3.6f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            if (ChallengerMod.Set.Data.SorcererMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Survivor1; }
                            else { button.GetComponent<SpriteRenderer>().sprite = UI2_Survivor0; }
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {
                                if (ChallengerMod.Set.Data.SorcererMin != 1f)
                                {
                                    SorcererAdd.updateSelection(1);
                                    SorcererSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    SorcererSpawnChance.updateSelection(0);
                                    SorcererAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                            }
                        }
                        if (GameObject.Find("ROLE_DUO_Slave"))
                        {
                            var button = GameObject.Find("ROLE_DUO_Slave");
                            button.transform.localPosition = new Vector3(0.1f, -3.6f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                            button.GetComponent<SpriteRenderer>().sprite = UI2_ROLE_LOCK;
                            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                            passiveButton.OnClick = new Button.ButtonClickedEvent();
                            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                            void onClick()
                            {

                            }

                        }
                    if (GameObject.Find("ROLE_SPE_Cupid"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Cupid");
                            button.transform.localPosition = new Vector3(-5.5f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.CupidMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cupid1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Cupid0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.CupidMin != 1f)
                                {
                                    CupidAdd.updateSelection(1);
                                    CupidSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    CupidSpawnChance.updateSelection(0);
                                    CupidAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Cultist"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Cultist");
                            button.transform.localPosition = new Vector3(-4.1f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.CultisteMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cultist1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Cultist0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.CultisteMin != 1f)
                                {
                                    CultisteAdd.updateSelection(1);
                                    CultisteSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    CultisteSpawnChance.updateSelection(0);
                                    CultisteAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Jester"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Jester");
                            button.transform.localPosition = new Vector3(-2.7f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.JesterMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Jester1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Jester0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.JesterMin != 1f)
                                {
                                    JesterAdd.updateSelection(1);
                                    JesterSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    JesterSpawnChance.updateSelection(0);
                                    JesterAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Eater"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Eater");
                            button.transform.localPosition = new Vector3(-1.3f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.EaterMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Eater1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Eater0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.EaterMin != 1f)
                                {
                                    EaterAdd.updateSelection(1);
                                    EaterSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    EaterSpawnChance.updateSelection(0);
                                    EaterAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Outlaw"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Outlaw");
                            button.transform.localPosition = new Vector3(0.1f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.OutlawMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Outlaw1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Outlaw0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.OutlawMin != 1f)
                                {
                                    OutlawAdd.updateSelection(1);
                                    OutlawSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    OutlawSpawnChance.updateSelection(0);
                                    OutlawAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Arsonist"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Arsonist");
                            button.transform.localPosition = new Vector3(1.5f, -5f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.ArsonistMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Arsonist1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Arsonist0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.ArsonistMin != 1f)
                                {
                                    ArsonistAdd.updateSelection(1);
                                    ArsonistSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    ArsonistSpawnChance.updateSelection(0);
                                    ArsonistAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }
                    if (GameObject.Find("ROLE_SPE_Cursed"))
                    {
                        var button = GameObject.Find("ROLE_SPE_Cursed");
                            button.transform.localPosition = new Vector3(-5.5f, -5.8f, -1f);
                            button.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                        if (ChallengerMod.Set.Data.CursedMin == 1f) { button.GetComponent<SpriteRenderer>().sprite = UI2_Cursed1; }
                        else { button.GetComponent<SpriteRenderer>().sprite = UI2_Cursed0; }
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                        void onClick()
                        {
                                if (ChallengerMod.Set.Data.CursedMin != 1f)
                                {
                                    CursedAdd.updateSelection(1);
                                    CursedSpawnChance.updateSelection(20);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                                else
                                {
                                    CursedSpawnChance.updateSelection(0);
                                    CursedAdd.updateSelection(0);
                                    ChallengerOS.Utils.Option.CustomOption.ShareOptionSelections();
                                }
                        }
                    }





                    if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("GameStartManager").transform.FindChild("StartButton"))
                        {
                            var StartButton = GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("GameStartManager").transform.FindChild("StartButton");


                            if (RankedSettings)
                            {
                                BoxCollider2D StartButton_Collider = StartButton.GetComponent<BoxCollider2D>();
                                StartButton_Collider.size = new Vector2(0f, 0f);
                            }
                            else
                            {
                                if (ChallengerMod.HarmonyMain.CanStartTheGame)
                                {
                                    BoxCollider2D StartButton_Collider = StartButton.GetComponent<BoxCollider2D>();
                                    StartButton_Collider.size = new Vector2(1f, 1f);
                                }
                                else
                                {
                                    BoxCollider2D StartButton_Collider = StartButton.GetComponent<BoxCollider2D>();
                                    StartButton_Collider.size = new Vector2(0f, 0f);
                                }
                            }
                        }




                        if ((GameData.Instance.PlayerCount <= 3) && !ChallengerMod.Challenger.IsrankedGame) // normal
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }
                        else if ((GameData.Instance.PlayerCount <= 9) && ChallengerMod.Challenger.IsrankedGame) //ranked
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }
                        else if (ChallengerMod.Challenger.ReadyPlayers.Count() != GameData.Instance.PlayerCount - 0 && ChallengerMod.Challenger.IsrankedGame)
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }

                        //All Role Exed
                        else if ((ChallengerOS.Utils.Option.CustomOptionHolder.QTImp.getFloat() + ChallengerOS.Utils.Option.CustomOptionHolder.QTSpe.getFloat() + ChallengerOS.Utils.Option.CustomOptionHolder.QTDuo.getFloat() + ChallengerOS.Utils.Option.CustomOptionHolder.QTCrew.getFloat()) > GameData.Instance.PlayerCount)
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }
                        //Impo Exced
                        else if (ChallengerOS.Utils.Option.CustomOptionHolder.QTImp.getFloat() > ChallengerMod.Set.Data.RealImpostor)
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }
                        // CRE+SPE+DUO exed (Players - Impo)
                        else if ((ChallengerOS.Utils.Option.CustomOptionHolder.QTCrew.getFloat() + ChallengerOS.Utils.Option.CustomOptionHolder.QTDuo.getFloat() + ChallengerOS.Utils.Option.CustomOptionHolder.QTSpe.getFloat()) > (GameData.Instance.PlayerCount - ChallengerMod.Set.Data.RealImpostor))
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = false;
                        }
                        else
                        {
                            ChallengerMod.HarmonyMain.CanStartTheGame = true;
                        }



                    }

                    //GL
                    if (GameObject.Find("GLLinkButton_1"))
                    {
                       
                        var button = GameObject.Find("Main Camera/Hud/GLLinkButton_1");
                        var SetButton = GameObject.Find("Main Camera/Hud/Buttons/TopRight/MenuButton");
                       
                        if (SetButton != null)
                        {
                            if (button.transform.localPosition != (SetButton.transform.localPosition + Vector3.down * 1.25f))
                            {
                                button.transform.localPosition = (SetButton.transform.localPosition + Vector3.down * 1.25f);
                            }
                            
                            
                            
                        }
                             
                       
                        

                        button.transform.localScale = new Vector3(0.52f, 0.46f, 1f);
                        button.GetComponent<SpriteRenderer>().sprite = RoleINF;


                       
                        
                        
                        PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                        passiveButton.OnClick = new Button.ButtonClickedEvent();
                        passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
                       
                        void onClick()
                        {

                            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                            {
                                Application.OpenURL("https://orianagames.com/challenger/roles?lg=fr&roles=" + g_role_All + "");
                            }
                            else
                            {
                                Application.OpenURL("https://orianagames.com/challenger/roles?lg=en&roles=" + g_role_All + "");

                            }

                        }

                    }
                    else
                    {
                        var CustomButton = GameObject.Find("Main Camera/Hud/ChatUi/ChatButton");
                        var ButtonParent = GameObject.Find("Main Camera/Hud/");

                        var button1 = UnityEngine.Object.Instantiate(CustomButton, null);

                        button1.transform.parent = ButtonParent.transform;

                        button1.transform.name = "GLLinkButton_1";
                    }





                    if (ChallengerMod.Challenger.IsrankedGame == true)
                    {
                        if (GameObject.Find("Lobby(Clone)").transform.FindChild("SmallBox").transform.FindChild("Panel"))
                        {
                            var Panel = GameObject.Find("Lobby(Clone)").transform.FindChild("SmallBox").transform.FindChild("Panel");
                            Panel.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("Main Camera/Hud/GameStartManager/MakePublicButton"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/GameStartManager/MakePublicButton");
                            if (button != null)
                            {
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                        }
                        if (GameObject.Find("Main Camera/Hud/PressetButton_1"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_1");
                            button.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("Main Camera/Hud/PressetButton_2"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_2");
                            button.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("Main Camera/Hud/PressetButton_3"))
                        {
                            var button = GameObject.Find("Main Camera/Hud/PressetButton_3");
                            button.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        
                        if (AmongUsClient.Instance.AmHost)
                        {
                            if (GameObject.Find("Main Camera/Hud/RankedButton"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedButton");
                                button.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                            }
                            
                            
                        }
                        else
                        {
                            if (GameObject.Find("Main Camera/Hud/RankedButton"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedButton");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/RankedUI"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedUI");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            
                        }
                    }
                    else
                    {
                        if (GameObject.Find("Lobby(Clone)").transform.FindChild("SmallBox").transform.FindChild("Panel"))
                        {
                            var Panel = GameObject.Find("Lobby(Clone)").transform.FindChild("SmallBox").transform.FindChild("Panel");
                            Panel.transform.localScale = new Vector3(1.3f, 1.3f, 1.2f);

                        }
                        //ENABLE PRESSET BUTTON
                        if (AmongUsClient.Instance.AmHost)
                        {
                            if (GameObject.Find("Main Camera/Hud/PressetButton_1"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_1");
                                button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            }
                            if (GameObject.Find("Main Camera/Hud/PressetButton_2"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_2");
                                button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            }
                            if (GameObject.Find("Main Camera/Hud/PressetButton_3"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_3");
                                button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            }
                            if (GameObject.Find("Main Camera/Hud/RankedButton"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedButton");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/RankedUI"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedUI");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                        }
                        else
                        {
                            if (GameObject.Find("Main Camera/Hud/PressetButton_1"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_1");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/PressetButton_2"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_2");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/PressetButton_3"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/PressetButton_3");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/RankedButton"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedButton");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("Main Camera/Hud/RankedUI"))
                            {
                                var button = GameObject.Find("Main Camera/Hud/RankedUI");
                                button.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            
                        }
                    }








                    //MAP_DATA
                    if (GameObject.Find("LobbyLevel_Data"))
                    {

                    }
                    else
                    {

                        GameObject ChallengerPolusShip = new GameObject("ChallengerPolusShip");
                        GameObject ChallengerPolusShipV2 = new GameObject("ChallengerPolusShipV2");



                        GameObject ChallengerMiraShip = new GameObject("ChallengerMiraShip");


                        GameObject newOiledPlayer = new GameObject("UI_Oiled");
                        SpriteRenderer newOiledPlayerSprite = newOiledPlayer.AddComponent<SpriteRenderer>();
                        newOiledPlayerSprite.sprite = CanBurn; // Load sprite with asset bundle
                        newOiledPlayer.transform.localPosition = new Vector3(99f, 99f, 1f);
                        newOiledPlayer.layer = 5;


                        GameObject newTargetPlayer = new GameObject("UI_Target");
                        SpriteRenderer newTargetPlayerSprite = newTargetPlayer.AddComponent<SpriteRenderer>();
                        newTargetPlayerSprite.sprite = war0; // Load sprite with asset bundle
                        newTargetPlayer.transform.localPosition = new Vector3(99f, 99f, 1f);
                        newTargetPlayer.layer = 5;



                       /* GameObject x = new GameObject("zzz");
                        SystemConsole y = x.AddComponent<SystemConsole>();
                        VitalsPanel z = x.AddComponent<VitalsPanel>();
                        y.usableDistance = 5f;

                        x.transform.localPosition = new Vector3(0f, 0f, 1f);
                        x.transform.localScale = new Vector3(1f, 1f, 1f);
                        SpriteRenderer XX = x.AddComponent<SpriteRenderer>();
                        XX.sprite = repairIco; */

                        //MIRA

                        GameObject HBlock1 = new GameObject("HQ_ColliderDSL");
                        HBlock1.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock1 = HBlock1.AddComponent<SpriteRenderer>();
                        rendHBlock1.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock1.transform.localPosition = new Vector3(-6.9227f, 2.44f, 1f);
                        HBlock1.transform.localScale = new Vector3(0.16f, 4.5212f, 1f);
                        HBlock1.SetActive(true);
                        HBlock1.layer = 9;
                        BoxCollider2D collider2DHBlock1 = HBlock1.AddComponent<BoxCollider2D>();
                        collider2DHBlock1.enabled = true;
                        collider2DHBlock1.isTrigger = false;

                        GameObject HBlock2 = new GameObject("HQ_ColliderDship");
                        HBlock2.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock2 = HBlock2.AddComponent<SpriteRenderer>();
                        rendHBlock2.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock2.transform.localPosition = new Vector3(-3.4588f, 6.58f, 1f);
                        HBlock2.transform.localScale = new Vector3(8.3533f, 4.36f, 1f);
                        HBlock2.SetActive(true);
                        HBlock2.layer = 9;
                        BoxCollider2D collider2DHBlock2 = HBlock2.AddComponent<BoxCollider2D>();
                        collider2DHBlock2.enabled = true;
                        collider2DHBlock2.isTrigger = false;

                        GameObject HBlock3 = new GameObject("HQ_ColliderDSB");
                        HBlock3.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock3 = HBlock3.AddComponent<SpriteRenderer>();
                        rendHBlock3.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock3.transform.localPosition = new Vector3(-1.6253f, -0.12f, 1f);
                        HBlock3.transform.localScale = new Vector3(9.48f, 0.18f, 1f);
                        HBlock3.SetActive(true);
                        HBlock3.layer = 9;
                        BoxCollider2D collider2DHBlock3 = HBlock3.AddComponent<BoxCollider2D>();
                        collider2DHBlock3.enabled = true;
                        collider2DHBlock3.isTrigger = false;

                        GameObject HBlock4 = new GameObject("HQ_ColliderDSR");
                        HBlock4.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock4 = HBlock4.AddComponent<SpriteRenderer>();
                        rendHBlock4.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock4.transform.localPosition = new Vector3(3.72f, -0.22f, 1f);
                        HBlock4.transform.localScale = new Vector3(0.1f, 5.9f, 1f);
                        HBlock4.SetActive(true);
                        HBlock4.layer = 9;
                        BoxCollider2D collider2DHBlock4 = HBlock4.AddComponent<BoxCollider2D>();
                        collider2DHBlock4.enabled = true;
                        collider2DHBlock4.isTrigger = false;

                        GameObject HBlock5 = new GameObject("HQ_ColliderlockerL1");
                        HBlock5.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock5 = HBlock5.AddComponent<SpriteRenderer>();
                        rendHBlock5.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock5.transform.localPosition = new Vector3(4.3f, 2.72f, 1f);
                        HBlock5.transform.localScale = new Vector3(1.1f, 0.56f, 1f);
                        HBlock5.SetActive(true);
                        HBlock5.layer = 9;
                        BoxCollider2D collider2DHBlock5 = HBlock5.AddComponent<BoxCollider2D>();
                        collider2DHBlock5.enabled = true;
                        collider2DHBlock5.isTrigger = false;

                        GameObject HBlock6 = new GameObject("HQ_ColliderLockerL2");
                        HBlock6.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock6 = HBlock6.AddComponent<SpriteRenderer>();
                        rendHBlock6.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock6.transform.localPosition = new Vector3(7.832f, 2.74f, 1f);
                        HBlock6.transform.localScale = new Vector3(1.0107f, 0.58f, 1f);
                        HBlock6.SetActive(true);
                        HBlock6.layer = 9;
                        BoxCollider2D collider2DHBlock6 = HBlock6.AddComponent<BoxCollider2D>();
                        collider2DHBlock6.enabled = true;
                        collider2DHBlock6.isTrigger = false;

                        GameObject HBlock7 = new GameObject("HQ_ColliderLockerTL");
                        HBlock7.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock7 = HBlock7.AddComponent<SpriteRenderer>();
                        rendHBlock7.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock7.transform.localPosition = new Vector3(8.24f, 4.4933f, 1f);
                        HBlock7.transform.localScale = new Vector3(0.14f, 3.32f, 1f);
                        HBlock7.SetActive(true);
                        HBlock7.layer = 9;
                        BoxCollider2D collider2DHBlock7 = HBlock7.AddComponent<BoxCollider2D>();
                        collider2DHBlock7.enabled = true;
                        collider2DHBlock7.isTrigger = false;

                        GameObject HBlock8 = new GameObject("HQ_ColliderLockerTR");
                        HBlock8.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock8 = HBlock8.AddComponent<SpriteRenderer>();
                        rendHBlock8.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock8.transform.localPosition = new Vector3(9.72f, 5.868f, 1f);
                        HBlock8.transform.localScale = new Vector3(2.6973f, 1.08f, 1f);
                        HBlock8.SetActive(true);
                        HBlock8.layer = 9;
                        BoxCollider2D collider2DHBlock8 = HBlock8.AddComponent<BoxCollider2D>();
                        collider2DHBlock8.enabled = true;
                        collider2DHBlock8.isTrigger = false;

                        GameObject HBlock9 = new GameObject("HQ_ColliderOfficecafe");
                        HBlock9.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock9 = HBlock9.AddComponent<SpriteRenderer>();
                        rendHBlock9.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock9.transform.localPosition = new Vector3(17.82f, 5.988f, 1f);
                        HBlock9.transform.localScale = new Vector3(7.44f, 1f, 1f);
                        HBlock9.SetActive(true);
                        HBlock9.layer = 9;
                        BoxCollider2D collider2DHBlock9 = HBlock9.AddComponent<BoxCollider2D>();
                        collider2DHBlock9.enabled = true;
                        collider2DHBlock9.isTrigger = false;

                        GameObject HBlock10 = new GameObject("HQ_ColliderBorderRight");
                        HBlock10.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock10 = HBlock10.AddComponent<SpriteRenderer>();
                        rendHBlock10.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock10.transform.localPosition = new Vector3(24.896f, 11.056f, 1f);
                        HBlock10.transform.localScale = new Vector3(-0.8667f, 10.02f, 1f);
                        HBlock10.SetActive(true);
                        HBlock10.layer = 9;
                        BoxCollider2D collider2DHBlock10 = HBlock10.AddComponent<BoxCollider2D>();
                        collider2DHBlock10.enabled = true;
                        collider2DHBlock10.isTrigger = false;

                        GameObject HBlock11 = new GameObject("HQ_ColliderBorderTop1");
                        HBlock11.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock11 = HBlock11.AddComponent<SpriteRenderer>();
                        rendHBlock11.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock11.transform.localPosition = new Vector3(22.3f, 16.24f, 1f);
                        HBlock11.transform.localScale = new Vector3(5.868f, 0.96f, 1f);
                        HBlock11.SetActive(true);
                        HBlock11.layer = 9;
                        BoxCollider2D collider2DHBlock11 = HBlock11.AddComponent<BoxCollider2D>();
                        collider2DHBlock11.enabled = true;
                        collider2DHBlock11.isTrigger = false;

                        GameObject HBlock12 = new GameObject("HQ_ColliderBorderTop2");
                        HBlock12.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock12 = HBlock12.AddComponent<SpriteRenderer>();
                        rendHBlock12.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock12.transform.localPosition = new Vector3(14.34f, 16.2507f, 1f);
                        HBlock12.transform.localScale = new Vector3(4.16f, 1f, 1f);
                        HBlock12.SetActive(true);
                        HBlock12.layer = 9;
                        BoxCollider2D collider2DHBlock12 = HBlock12.AddComponent<BoxCollider2D>();
                        collider2DHBlock12.enabled = true;
                        collider2DHBlock12.isTrigger = false;

                        GameObject HBlock13 = new GameObject("HQ_ColliderLabR");
                        HBlock13.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock13 = HBlock13.AddComponent<SpriteRenderer>();
                        rendHBlock13.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock13.transform.localPosition = new Vector3(12.22f, 12.32f, 1f);
                        HBlock13.transform.localScale = new Vector3(0.18f, 6.48f, 1f);
                        HBlock13.SetActive(true);
                        HBlock13.layer = 9;
                        BoxCollider2D collider2DHBlock13 = HBlock13.AddComponent<BoxCollider2D>();
                        collider2DHBlock13.enabled = true;
                        collider2DHBlock13.isTrigger = false;

                        GameObject HBlock14 = new GameObject("HQ_ColliderTexShadowReactorBot");
                        HBlock14.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock14 = HBlock14.AddComponent<SpriteRenderer>();
                        rendHBlock14.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock14.transform.localPosition = new Vector3(2.468f, 9.24f, 1f);
                        HBlock14.transform.localScale = new Vector3(4.3f, 0.66f, 1f);
                        HBlock14.SetActive(true);
                        HBlock14.layer = 11;
                        BoxCollider2D collider2DHBlock14 = HBlock14.AddComponent<BoxCollider2D>();
                        collider2DHBlock14.enabled = true;
                        collider2DHBlock14.isTrigger = false;

                        GameObject HBlock15 = new GameObject("HQ_ColliderTexShadowRightreactor");
                        HBlock15.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock15 = HBlock15.AddComponent<SpriteRenderer>();
                        rendHBlock15.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock15.transform.localPosition = new Vector3(0.0176f, 13.26f, 1f);
                        HBlock15.transform.localScale = new Vector3(0.06f, 6.52f, 1f);
                        HBlock15.SetActive(true);
                        HBlock15.layer = 11;
                        BoxCollider2D collider2DHBlock15 = HBlock15.AddComponent<BoxCollider2D>();
                        collider2DHBlock15.enabled = true;
                        collider2DHBlock15.isTrigger = false;

                        GameObject HBlock16 = new GameObject("HQ_ColliderLockright");
                        HBlock16.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock16 = HBlock16.AddComponent<SpriteRenderer>();
                        rendHBlock16.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock16.transform.localPosition = new Vector3(11.18f, 4.664f, 1f);
                        HBlock16.transform.localScale = new Vector3(0.14f, 2.58f, 1f);
                        HBlock16.SetActive(true);
                        HBlock16.layer = 9;
                        BoxCollider2D collider2DHBlock16 = HBlock16.AddComponent<BoxCollider2D>();
                        collider2DHBlock16.enabled = true;
                        collider2DHBlock16.isTrigger = false;

                        GameObject HBlock17 = new GameObject("HQ_ColliderLockershadow");
                        HBlock17.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock17 = HBlock17.AddComponent<SpriteRenderer>();
                        rendHBlock17.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock17.transform.localPosition = new Vector3(11.1853f, 3.2146f, 1f);
                        HBlock17.transform.localScale = new Vector3(0.1f, 5.5728f, 1f);
                        HBlock17.SetActive(true);
                        HBlock17.layer = 11;
                        BoxCollider2D collider2DHBlock17 = HBlock17.AddComponent<BoxCollider2D>();
                        collider2DHBlock17.enabled = true;
                        collider2DHBlock17.isTrigger = false;

                        GameObject HBlock18 = new GameObject("HQ_ColliderLabShadow");
                        HBlock18.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock18 = HBlock18.AddComponent<SpriteRenderer>();
                        rendHBlock18.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock18.transform.localPosition = new Vector3(7.254f, 11.18f, 1f);
                        HBlock18.transform.localScale = new Vector3(0.04f, 3.846f, 1f);
                        HBlock18.SetActive(true);
                        HBlock18.layer = 11;
                        BoxCollider2D collider2DHBlock18 = HBlock18.AddComponent<BoxCollider2D>();
                        collider2DHBlock18.enabled = true;
                        collider2DHBlock18.isTrigger = false;

                        GameObject HBlock19 = new GameObject("HQ_Colliderreactorshadow");
                        HBlock19.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock19 = HBlock19.AddComponent<SpriteRenderer>();
                        rendHBlock19.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock19.transform.localPosition = new Vector3(4.94f, 14.0859f, 1f);
                        HBlock19.transform.localScale = new Vector3(0.04f, 4.54f, 1f);
                        HBlock19.SetActive(true);
                        HBlock19.layer = 11;
                        BoxCollider2D collider2DHBlock19 = HBlock19.AddComponent<BoxCollider2D>();
                        collider2DHBlock19.enabled = true;
                        collider2DHBlock19.isTrigger = false;

                        GameObject HBlock20 = new GameObject("HQ_ColliderTexShadowLocker");
                        HBlock20.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock20 = HBlock20.AddComponent<SpriteRenderer>();
                        rendHBlock20.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock20.transform.localPosition = new Vector3(9.7759f, 6.492f, -10f);
                        HBlock20.transform.localScale = new Vector3(2.5339f, 0.62f, 1f);
                        HBlock20.SetActive(true);
                        HBlock20.layer = 11;
                        BoxCollider2D collider2DHBlock20 = HBlock20.AddComponent<BoxCollider2D>();
                        collider2DHBlock20.enabled = true;
                        collider2DHBlock20.isTrigger = false;



                        GameObject HBlock21 = new GameObject("HQ_ColliderTexShadowOfficeCafe");
                        HBlock21.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock21 = HBlock21.AddComponent<SpriteRenderer>();
                        rendHBlock21.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock21.transform.localPosition = new Vector3(17.84f, 6.492f, -10f);
                        HBlock21.transform.localScale = new Vector3(7.38f, 0.62f, 1f);
                        HBlock21.SetActive(true);
                        HBlock21.layer = 11;
                        BoxCollider2D collider2DHBlock21 = HBlock21.AddComponent<BoxCollider2D>();
                        collider2DHBlock21.enabled = true;
                        collider2DHBlock21.isTrigger = false;

                        GameObject HBlock22 = new GameObject("HQ_ColliderTexShadowlockerVertLeft");
                        HBlock22.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock22 = HBlock22.AddComponent<SpriteRenderer>();
                        rendHBlock22.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock22.transform.localPosition = new Vector3(7.75f, 4.904f, -10f);
                        HBlock22.transform.localScale = new Vector3(1f, 3.446f, 1f);
                        HBlock22.SetActive(true);
                        HBlock22.layer = 11;
                        BoxCollider2D collider2DHBlock22 = HBlock22.AddComponent<BoxCollider2D>();
                        collider2DHBlock22.enabled = true;
                        collider2DHBlock22.isTrigger = false;

                        GameObject HBlock23 = new GameObject("HQ_ColliderTexShadowLockerLeft");
                        HBlock23.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock23 = HBlock23.AddComponent<SpriteRenderer>();
                        rendHBlock23.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock23.transform.localPosition = new Vector3(4.326f, 3.26f, -10f);
                        HBlock23.transform.localScale = new Vector3(1.1f, 0.6f, 1f);
                        HBlock23.SetActive(true);
                        HBlock23.layer = 11;
                        BoxCollider2D collider2DHBlock23 = HBlock23.AddComponent<BoxCollider2D>();
                        collider2DHBlock23.enabled = true;
                        collider2DHBlock23.isTrigger = false;

                        GameObject HBlock24 = new GameObject("HQ_ColliderTexShadowShadowElecBot");
                        HBlock24.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock24 = HBlock24.AddComponent<SpriteRenderer>();
                        rendHBlock24.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock24.transform.localPosition = new Vector3(22.4679f, 9.63f, 1f);
                        HBlock24.transform.localScale = new Vector3(3.528f, 0.1f, 1f);
                        HBlock24.SetActive(true);
                        HBlock24.layer = 11;
                        BoxCollider2D collider2DHBlock24 = HBlock24.AddComponent<BoxCollider2D>();
                        collider2DHBlock24.enabled = true;
                        collider2DHBlock24.isTrigger = false;

                        GameObject HBlock25 = new GameObject("HQ_ColliderElecBot");
                        HBlock25.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock25 = HBlock25.AddComponent<SpriteRenderer>();
                        rendHBlock25.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock25.transform.localPosition = new Vector3(22.436f, 9.2779f, 1f);
                        HBlock25.transform.localScale = new Vector3(3.464f, 0.66f, 1f);
                        HBlock25.SetActive(true);
                        HBlock25.layer = 9;
                        BoxCollider2D collider2DHBlock25 = HBlock25.AddComponent<BoxCollider2D>();
                        collider2DHBlock25.enabled = true;
                        collider2DHBlock25.isTrigger = false;

                        GameObject HBlock26 = new GameObject("HQ_ColliderTexShadowShadowElecLeft");
                        HBlock26.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock26 = HBlock26.AddComponent<SpriteRenderer>();
                        rendHBlock26.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock26.transform.localPosition = new Vector3(20.4978f, 13.118f, -10f);
                        HBlock26.transform.localScale = new Vector3(0.08f, 2.7019f, 1f);
                        HBlock26.SetActive(true);
                        HBlock26.layer = 11;
                        BoxCollider2D collider2DHBlock26 = HBlock26.AddComponent<BoxCollider2D>();
                        collider2DHBlock26.enabled = true;
                        collider2DHBlock26.isTrigger = false;

                        GameObject HBlock27 = new GameObject("HQ_ColliderShadowTexLabo");
                        HBlock27.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock27 = HBlock27.AddComponent<SpriteRenderer>();
                        rendHBlock27.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock27.transform.localPosition = new Vector3(9.74f, 9.2238f, 1f);
                        HBlock27.transform.localScale = new Vector3(4.35f, 0.6984f, 1f);
                        HBlock27.SetActive(true);
                        HBlock27.layer = 11;
                        BoxCollider2D collider2DHBlock27 = HBlock27.AddComponent<BoxCollider2D>();
                        collider2DHBlock27.enabled = true;
                        collider2DHBlock27.isTrigger = false;

                        GameObject HBlock28 = new GameObject("HQ_ColliderMidCenter");
                        HBlock28.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock28 = HBlock28.AddComponent<SpriteRenderer>();
                        rendHBlock28.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock28.transform.localPosition = new Vector3(17.2588f, 9.3414f, 1f);
                        HBlock28.transform.localScale = new Vector3(1.46f, 1.4575f, 1f);
                        HBlock28.SetActive(true);
                        HBlock28.layer = 9;
                        BoxCollider2D collider2DHBlock28 = HBlock28.AddComponent<BoxCollider2D>();
                        collider2DHBlock28.enabled = true;
                        collider2DHBlock28.isTrigger = false;

                        GameObject HBlock29 = new GameObject("HQ_ColliderMidBot");
                        HBlock29.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock29 = HBlock29.AddComponent<SpriteRenderer>();
                        rendHBlock29.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock29.transform.localPosition = new Vector3(16.8438f, 8.1414f, 1f);
                        HBlock29.transform.localScale = new Vector3(2.18f, 1.0175f, 1f);
                        HBlock29.SetActive(true);
                        BoxCollider2D collider2DHBlock29 = HBlock29.AddComponent<BoxCollider2D>();
                        collider2DHBlock29.enabled = true;
                        collider2DHBlock29.isTrigger = false;

                        GameObject HBlock30 = new GameObject("HQ_ColliderMidRTop");
                        HBlock30.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock30 = HBlock30.AddComponent<SpriteRenderer>();
                        rendHBlock30.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock30.transform.localPosition = new Vector3(15.71f, 9.8863f, 1f);
                        HBlock30.transform.localScale = new Vector3(1.26f, 0.235f, 1f);
                        HBlock30.SetActive(true);
                        BoxCollider2D collider2DHBlock30 = HBlock30.AddComponent<BoxCollider2D>();
                        collider2DHBlock30.enabled = true;
                        collider2DHBlock30.isTrigger = false;

                        GameObject HBlock31 = new GameObject("HQ_ColliderMidRBot");
                        HBlock31.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock31 = HBlock31.AddComponent<SpriteRenderer>();
                        rendHBlock31.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock31.transform.localPosition = new Vector3(15.71f, 8.74f, 1f);
                        HBlock31.transform.localScale = new Vector3(1.26f, 0.235f, 1f);
                        HBlock31.SetActive(true);
                        BoxCollider2D collider2DHBlock31 = HBlock31.AddComponent<BoxCollider2D>();
                        collider2DHBlock31.enabled = true;
                        collider2DHBlock31.isTrigger = false;

                        GameObject HBlock32 = new GameObject("HQ_ColliderSH1");
                        HBlock32.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock32 = HBlock32.AddComponent<SpriteRenderer>();
                        rendHBlock32.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock32.transform.localPosition = new Vector3(16.4838f, 13.9063f, 1f);
                        HBlock32.transform.localScale = new Vector3(0.46f, 0.36f, 1f);
                        HBlock32.SetActive(true);
                        HBlock32.layer = 9;
                        BoxCollider2D collider2DHBlock32 = HBlock32.AddComponent<BoxCollider2D>();
                        collider2DHBlock32.enabled = true;
                        collider2DHBlock32.isTrigger = false;

                        GameObject HBlock33 = new GameObject("HQ_ColliderSH2");
                        HBlock33.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock33 = HBlock33.AddComponent<SpriteRenderer>();
                        rendHBlock33.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock33.transform.localPosition = new Vector3(14.2463f, 14.04f, 1f);
                        HBlock33.transform.localScale = new Vector3(3.3239f, 0.6f, 1f);
                        HBlock33.SetActive(true);
                        BoxCollider2D collider2DHBlock33 = HBlock33.AddComponent<BoxCollider2D>();
                        collider2DHBlock33.enabled = true;
                        collider2DHBlock33.isTrigger = false;

                        GameObject HBlock34 = new GameObject("HQ_ColliderElecGen");
                        HBlock34.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock34 = HBlock34.AddComponent<SpriteRenderer>();
                        rendHBlock34.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock34.transform.localPosition = new Vector3(23.12f, 12.74f, 1f);
                        HBlock34.transform.localScale = new Vector3(2.2f, 1.78f, 1f);
                        HBlock34.SetActive(true);
                        HBlock34.layer = 9;
                        BoxCollider2D collider2DHBlock34 = HBlock34.AddComponent<BoxCollider2D>();
                        collider2DHBlock34.enabled = true;
                        collider2DHBlock34.isTrigger = false;

                        GameObject HBlock35 = new GameObject("HQ_ColliderElecTab");
                        HBlock35.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock35 = HBlock35.AddComponent<SpriteRenderer>();
                        rendHBlock35.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock35.transform.localPosition = new Vector3(23.8163f, 15.3488f, 1f);
                        HBlock35.transform.localScale = new Vector3(1.32f, 0.74f, 1f);
                        HBlock35.SetActive(true);
                        HBlock35.layer = 9;
                        BoxCollider2D collider2DHBlock35 = HBlock35.AddComponent<BoxCollider2D>();
                        collider2DHBlock35.enabled = true;
                        collider2DHBlock35.isTrigger = false;

                        GameObject HBlock36 = new GameObject("HQ_ColliderTexShadowShadowElecLeftDoor");
                        HBlock36.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock36 = HBlock36.AddComponent<SpriteRenderer>();
                        rendHBlock36.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock36.transform.localPosition = new Vector3(20.4978f, 12.798f, 1f);
                        HBlock36.transform.localScale = new Vector3(0.08f, 3.2319f, 1f);
                        HBlock36.SetActive(true);
                        HBlock36.layer = 9;
                        BoxCollider2D collider2DHBlock36 = HBlock36.AddComponent<BoxCollider2D>();
                        collider2DHBlock36.enabled = true;
                        collider2DHBlock36.isTrigger = false;

                        GameObject HBlock37 = new GameObject("HQ_ColliderMidTop");
                        HBlock37.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock37 = HBlock37.AddComponent<SpriteRenderer>();
                        rendHBlock37.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock37.transform.localPosition = new Vector3(16.8438f, 10.3074f, 1f);
                        HBlock37.transform.localScale = new Vector3(2.18f, 1.0175f, 1f);
                        HBlock37.SetActive(true);
                        BoxCollider2D collider2DHBlock37 = HBlock37.AddComponent<BoxCollider2D>();
                        collider2DHBlock37.enabled = true;
                        collider2DHBlock37.isTrigger = false;

                        GameObject HBlock38 = new GameObject("HQ_ColliderTexShadowlowReactor");
                        HBlock38.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock38 = HBlock38.AddComponent<SpriteRenderer>();
                        rendHBlock38.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock38.transform.localPosition = new Vector3(2.4737f, 8.9859f, 0.98f);
                        HBlock38.transform.localScale = new Vector3(4.34f, 1.02f, 1f);
                        HBlock38.SetActive(true);
                        HBlock38.layer = 12;
                        BoxCollider2D collider2DHBlock38 = HBlock38.AddComponent<BoxCollider2D>();
                        collider2DHBlock38.enabled = true;
                        collider2DHBlock38.isTrigger = false;

                        GameObject HBlock39 = new GameObject("HQ_ColliderTexShadowlowLab");
                        HBlock39.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock39 = HBlock39.AddComponent<SpriteRenderer>();
                        rendHBlock39.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock39.transform.localPosition = new Vector3(9.7371f, 8.9859f, 0.98f);
                        HBlock39.transform.localScale = new Vector3(4.34f, 1.02f, 1f);
                        HBlock39.SetActive(true);
                        HBlock39.layer = 12;
                        BoxCollider2D collider2DHBlock39 = HBlock39.AddComponent<BoxCollider2D>();
                        collider2DHBlock39.enabled = true;
                        collider2DHBlock39.isTrigger = false;

                        GameObject HBlock40 = new GameObject("HQ_ColliderTexShadowupOfficeCafe");
                        HBlock40.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock40 = HBlock40.AddComponent<SpriteRenderer>();
                        rendHBlock40.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock40.transform.localPosition = new Vector3(16.8677f, 7.1369f, -10f);
                        HBlock40.transform.localScale = new Vector3(2.7715f, 0.58f, 1f);
                        HBlock40.SetActive(true);
                        HBlock40.layer = 11;
                        BoxCollider2D collider2DHBlock40 = HBlock40.AddComponent<BoxCollider2D>();
                        collider2DHBlock40.enabled = true;
                        collider2DHBlock40.isTrigger = false;

                        GameObject HBlock41 = new GameObject("HQ_ColliderTexShadowupbotO2panel");
                        HBlock41.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock41 = HBlock41.AddComponent<SpriteRenderer>();
                        rendHBlock41.sprite = Colliderblack; // Load sprite with asset bundle
                        HBlock41.transform.localPosition = new Vector3(3.75f, 0.1187f, -9.52f);
                        HBlock41.transform.localScale = new Vector3(0.1f, 5.6439f, 1f);
                        HBlock41.SetActive(true);
                        HBlock41.layer = 11;
                        BoxCollider2D collider2DHBlock41 = HBlock41.AddComponent<BoxCollider2D>();
                        collider2DHBlock41.enabled = true;
                        collider2DHBlock41.isTrigger = false;

                        GameObject HBlock42 = new GameObject("HQ_ColliderDSClotL");
                        HBlock42.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock42 = HBlock42.AddComponent<SpriteRenderer>();
                        rendHBlock42.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock42.transform.localPosition = new Vector3(2.06f, 5.3926f, 1f);
                        HBlock42.transform.localScale = new Vector3(1.4f, 0.52f, 1f);
                        HBlock42.SetActive(true);
                        HBlock42.layer = 12;
                        BoxCollider2D collider2DHBlock42 = HBlock42.AddComponent<BoxCollider2D>();
                        collider2DHBlock42.enabled = true;
                        collider2DHBlock42.isTrigger = false;

                        GameObject HBlock43 = new GameObject("HQ_ColliderDSClotR");
                        HBlock43.transform.parent = ChallengerMiraShip.transform;
                        SpriteRenderer rendHBlock43 = HBlock43.AddComponent<SpriteRenderer>();
                        rendHBlock43.sprite = Colliderbox; // Load sprite with asset bundle
                        HBlock43.transform.localPosition = new Vector3(6.08f, 5.3926f, 1f);
                        HBlock43.transform.localScale = new Vector3(2.54f, 0.52f, 1f);
                        HBlock43.SetActive(true);
                        HBlock43.layer = 12;
                        BoxCollider2D collider2DHBlock43 = HBlock43.AddComponent<BoxCollider2D>();
                        collider2DHBlock43.enabled = true;
                        collider2DHBlock43.isTrigger = false;


                        //POLUS


                        /*GameObject LightAff = new GameObject("LobbyLevel_L");
                        LightAff.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendli = LightAff.AddComponent<SpriteRenderer>();
                        rendli.sprite = EA1; // Load sprite with asset bundle
                        BoxCollider2D collider2DLight = LightAff.AddComponent<BoxCollider2D>();
                        collider2DLight.enabled = true;
                        collider2DLight.isTrigger = true;
                        LightAffector rendlight = LightAff.AddComponent<LightAffector>();
                        rendlight.Multiplier = 0.2f;
                        rendlight.Hitbox = collider2DLight;
                        LightAff.transform.localPosition = new Vector3(1f, -20f, 0f);
                        LightAff.transform.localScale = new Vector3(5f, 5f, 1f);
                        LightAff.SetActive(true);
                        LightAff.layer = 9;*/

                        //V2.2 AREA
                        GameObject block8 = new GameObject("LobbyLevel_Collider8"); // + leftadmin
                        block8.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer rendblock8 = block8.AddComponent<SpriteRenderer>();
                        rendblock8.sprite = Colliderbox; // Load sprite with asset bundle
                        block8.transform.localPosition = new Vector3(14.5f, -17.571f, 5f);
                        block8.transform.localScale = new Vector3(2f, 1f, 1f);
                        block8.SetActive(true);
                        block8.layer = 9;
                        BoxCollider2D collider2Dblock8 = block8.AddComponent<BoxCollider2D>();
                        collider2Dblock8.enabled = true;
                        collider2Dblock8.isTrigger = false;

                        GameObject block9 = new GameObject("LobbyLevel_Collider9"); // + leftreactor
                        block9.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer rendblock9 = block9.AddComponent<SpriteRenderer>();
                        rendblock9.sprite = Colliderbox; // Load sprite with asset bundle
                        block9.transform.localPosition = new Vector3(8.058f, -7.467f, 5f);
                        block9.transform.localScale = new Vector3(2.26f, 1f, 1f);
                        block9.SetActive(true);
                        block9.layer = 9;
                        BoxCollider2D collider2Dblock9 = block9.AddComponent<BoxCollider2D>();
                        collider2Dblock9.enabled = true;
                        collider2Dblock9.isTrigger = false;

                        GameObject block10 = new GameObject("LobbyLevel_Collider10"); // + leftlab
                        block10.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer rendblock10 = block10.AddComponent<SpriteRenderer>();
                        rendblock10.sprite = Colliderbox; // Load sprite with asset bundle
                        block10.transform.localPosition = new Vector3(23.5617f, -8.152f, 5f);
                        block10.transform.localScale = new Vector3(2f, 0.6f, 1f);
                        block10.SetActive(true);
                        block10.layer = 9;
                        BoxCollider2D collider2Dblock10 = block10.AddComponent<BoxCollider2D>();
                        collider2Dblock10.enabled = true;
                        collider2Dblock10.isTrigger = false;

                        GameObject block11 = new GameObject("LobbyLevel_Collider11"); // + leftlab
                        block11.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer rendblock11 = block11.AddComponent<SpriteRenderer>();
                        rendblock11.sprite = Colliderbox; // Load sprite with asset bundle
                        block11.transform.localPosition = new Vector3(22.354f, -9.1597f, 5f);
                        block11.transform.localScale = new Vector3(0.8f, 2.4f, 1f);
                        block11.SetActive(true);
                        block11.layer = 9;
                        BoxCollider2D collider2Dblock11 = block11.AddComponent<BoxCollider2D>();
                        collider2Dblock11.enabled = true;
                        collider2Dblock11.isTrigger = false;

                        GameObject block12 = new GameObject("LobbyLevel_Collider12"); // + leftlab
                        block12.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer rendblock12 = block12.AddComponent<SpriteRenderer>();
                        rendblock12.sprite = Colliderbox; // Load sprite with asset bundle
                        block12.transform.localPosition = new Vector3(22.7037f, -8.5674f, 5f);
                        block12.transform.localScale = new Vector3(1.8f, 0.7f, 1f);
                        block12.SetActive(true);
                        block12.layer = 9;
                        BoxCollider2D collider2Dblock12 = block12.AddComponent<BoxCollider2D>();
                        collider2Dblock12.enabled = true;
                        collider2Dblock12.isTrigger = false;

                        GameObject FxCamLab = new GameObject("LobbyLevel_ColliderFixCamLab");
                        FxCamLab.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer FxCamLabSprite = FxCamLab.AddComponent<SpriteRenderer>();
                        FxCamLabSprite.sprite = Colliderbox; // Load sprite with asset bundle
                        FxCamLab.transform.localPosition = new Vector3(24.311f, -8.5857f, 0f);
                        FxCamLab.transform.localScale = new Vector3(0.5f, 0.5f, 2f);
                        FxCamLab.SetActive(true);
                        FxCamLab.layer = 9;
                        BoxCollider2D collider2DFxCamLab = FxCamLab.AddComponent<BoxCollider2D>();
                        collider2DFxCamLab.enabled = true;
                        collider2DFxCamLab.isTrigger = false;




                        GameObject block26 = new GameObject("LobbyLevel_TempWall"); //Temp Wall
                        block26.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock26 = block26.AddComponent<SpriteRenderer>();
                        rendblock26.sprite = Colliderbox; // Load sprite with asset bundle
                        block26.transform.localPosition = new Vector3(4.9617f, -8.5299f, 5f);
                        block26.transform.localScale = new Vector3(2.8f, 1.6f, 1f);
                        block26.SetActive(true);
                        block26.layer = 9;
                        BoxCollider2D collider2Dblock26 = block26.AddComponent<BoxCollider2D>();
                        collider2Dblock26.enabled = true;
                        collider2Dblock26.isTrigger = false;

                        GameObject TexP1 = new GameObject("ChallengerPolusShipSpriteP1");
                        TexP1.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer TexP1Sprite = TexP1.AddComponent<SpriteRenderer>();
                        TexP1Sprite.sprite = Level_TexP1; // Load sprite with asset bundle
                        TexP1.transform.localScale = new Vector3(1f, 1f, 1f);
                        TexP1.transform.localPosition = new Vector3(8.08f, -7.56f, 1.04f);
                        TexP1.layer = 11;

                        GameObject TexP2 = new GameObject("ChallengerPolusShipSpriteP2");
                        TexP2.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer TexP2Sprite = TexP2.AddComponent<SpriteRenderer>();
                        TexP2Sprite.sprite = Level_TexP2; // Load sprite with asset bundle
                        TexP2.transform.localScale = new Vector3(0.56f, 0.56f, 1f);
                        TexP2.transform.localPosition = new Vector3(14.5141f, -17.58f, 1.04f);
                        TexP2.layer = 11;

                        GameObject TexP3 = new GameObject("ChallengerPolusShipSpriteP3");
                        TexP3.transform.parent = ChallengerPolusShipV2.transform;
                        SpriteRenderer TexP3Sprite = TexP3.AddComponent<SpriteRenderer>();
                        TexP3Sprite.sprite = Level_TexP3; // Load sprite with asset bundle
                        TexP3.transform.localScale = new Vector3(0.61f, 0.59f, 1f);
                        TexP3.transform.localPosition = new Vector3(23.3856f, -8.9544f, 1.04f);
                        TexP3.layer = 11;




                        GameObject ChallengerPolusShipElec = new GameObject("ChallengerPolusShipSprite");
                        SpriteRenderer ChallengerPolusShipElecSprite = ChallengerPolusShipElec.AddComponent<SpriteRenderer>();
                        ChallengerPolusShipElecSprite.sprite = Elec; // Load sprite with asset bundle
                        ChallengerPolusShipElec.transform.localScale = new Vector3(0f, 0f, 0f);
                        ChallengerPolusShipElec.transform.localPosition = new Vector3(6.34f, -13.41f, 2f);
                        ChallengerPolusShipElec.layer = 11;



                        GameObject ChallengerPolusShipElec2 = new GameObject("ChallengerPolusShipSprite2");
                        SpriteRenderer ChallengerPolusShipElecSprite2 = ChallengerPolusShipElec2.AddComponent<SpriteRenderer>();
                        ChallengerPolusShipElecSprite2.sprite = Elec2; // Load sprite with asset bundle
                        ChallengerPolusShipElec2.transform.localScale = new Vector3(0f, 0f, 0f);
                        ChallengerPolusShipElec2.transform.localPosition = new Vector3(6.34f, -13.41f, 2f);
                        ChallengerPolusShipElec2.layer = 11;


                        GameObject block13 = new GameObject("LobbyLevel_Collider13");
                        block13.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock13 = block13.AddComponent<SpriteRenderer>(); //Wall top right
                        rendblock13.sprite = Colliderbox; // Load sprite with asset bundle
                        block13.transform.localPosition = new Vector3(8.74f, -8.5266f, 5f);
                        block13.transform.localScale = new Vector3(4.5534f, 1.08f, 1f);
                        block13.SetActive(true);
                        block13.layer = 9;
                        BoxCollider2D collider2Dblock13 = block13.AddComponent<BoxCollider2D>();
                        collider2Dblock13.enabled = true;
                        collider2Dblock13.isTrigger = false;

                        GameObject block14 = new GameObject("LobbyLevel_Collider14"); //wall top Left
                        block14.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock14 = block14.AddComponent<SpriteRenderer>();
                        rendblock14.sprite = Colliderbox; // Load sprite with asset bundle
                        block14.transform.localPosition = new Vector3(2.4085f, -8.5266f, 5f);
                        block14.transform.localScale = new Vector3(2.32f, 1.08f, 1f);
                        block14.SetActive(true);
                        block14.layer = 9;
                        BoxCollider2D collider2Dblock14 = block14.AddComponent<BoxCollider2D>();
                        collider2Dblock14.enabled = true;
                        collider2Dblock14.isTrigger = false;

                        GameObject block15 = new GameObject("LobbyLevel_Collider15"); // left elec/cam
                        block15.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock15 = block15.AddComponent<SpriteRenderer>();
                        rendblock15.sprite = Colliderbox; // Load sprite with asset bundle
                        block15.transform.localPosition = new Vector3(1.0217f, -11.3f, 5f);
                        block15.transform.localScale = new Vector3(1f, 4f, 1f);
                        block15.SetActive(true);
                        block15.layer = 9;
                        BoxCollider2D collider2Dblock15 = block15.AddComponent<BoxCollider2D>();
                        collider2Dblock15.enabled = true;
                        collider2Dblock15.isTrigger = false;

                        GameObject block16 = new GameObject("LobbyLevel_Collider16"); //cam top
                        block16.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock16 = block16.AddComponent<SpriteRenderer>();
                        rendblock16.sprite = Colliderbox; // Load sprite with asset bundle
                        block16.transform.localPosition = new Vector3(3.785f, -10.8917f, 5f);
                        block16.transform.localScale = new Vector3(1.16f, 0.86f, 1f);
                        block16.SetActive(true);
                        block16.layer = 9;
                        BoxCollider2D collider2Dblock16 = block16.AddComponent<BoxCollider2D>();
                        collider2Dblock16.enabled = true;
                        collider2Dblock16.isTrigger = false;

                        GameObject block17 = new GameObject("LobbyLevel_Collider17"); //wall cam right
                        block17.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock17 = block17.AddComponent<SpriteRenderer>();
                        rendblock17.sprite = Colliderbox; // Load sprite with asset bundle
                        block17.transform.localPosition = new Vector3(4.4136f, -11.86f, 5f);
                        block17.transform.localScale = new Vector3(0.1f, 2.48f, 1f);
                        block17.SetActive(true);
                        block17.layer = 9;
                        BoxCollider2D collider2Dblock17 = block17.AddComponent<BoxCollider2D>();
                        collider2Dblock17.enabled = true;
                        collider2Dblock17.isTrigger = false;

                        GameObject block18 = new GameObject("LobbyLevel_Collider18"); //cam bot
                        block18.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock18 = block18.AddComponent<SpriteRenderer>();
                        rendblock18.sprite = Colliderbox; // Load sprite with asset bundle
                        block18.transform.localPosition = new Vector3(3.2217f, -13.515f, 5f);
                        block18.transform.localScale = new Vector3(2.88f, 0.88f, 1f);
                        block18.SetActive(true);
                        block18.layer = 9;
                        BoxCollider2D collider2Dblock18 = block18.AddComponent<BoxCollider2D>();
                        collider2Dblock18.enabled = true;
                        collider2Dblock18.isTrigger = false;

                        GameObject block19 = new GameObject("LobbyLevel_Collider19"); // elet out left
                        block19.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock19 = block19.AddComponent<SpriteRenderer>();
                        rendblock19.sprite = Colliderbox; // Load sprite with asset bundle
                        block19.transform.localPosition = new Vector3(6.5151f, -12.2144f, 5f);
                        block19.transform.localScale = new Vector3(0.3f, 3.2f, 1f);
                        block19.SetActive(true);
                        block19.layer = 9;
                        BoxCollider2D collider2Dblock19 = block19.AddComponent<BoxCollider2D>();
                        collider2Dblock19.enabled = true;
                        collider2Dblock19.isTrigger = false;

                        GameObject block20 = new GameObject("LobbyLevel_Collider20"); // door bot right
                        block20.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock20 = block20.AddComponent<SpriteRenderer>();
                        rendblock20.sprite = Colliderbox; // Load sprite with asset bundle
                        block20.transform.localPosition = new Vector3(6.265f, -13.4932f, 5f);
                        block20.transform.localScale = new Vector3(0.58f, 0.88f, 1f);
                        block20.SetActive(true);
                        block20.layer = 9;
                        BoxCollider2D collider2Dblock20 = block20.AddComponent<BoxCollider2D>();
                        collider2Dblock20.enabled = true;
                        collider2Dblock20.isTrigger = false;

                        GameObject block21 = new GameObject("LobbyLevel_Collider21"); //wall ouf top left
                        block21.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock21 = block21.AddComponent<SpriteRenderer>();
                        rendblock21.sprite = Colliderbox; // Load sprite with asset bundle
                        block21.transform.localPosition = new Vector3(6.6188f, -10.9f, 5f);
                        block21.transform.localScale = new Vector3(0.46f, 0.86f, 1f);
                        block21.SetActive(true);
                        block21.layer = 9;
                        BoxCollider2D collider2Dblock21 = block21.AddComponent<BoxCollider2D>();
                        collider2Dblock21.enabled = true;
                        collider2Dblock21.isTrigger = false;

                        GameObject block22 = new GameObject("LobbyLevel_Collider22"); //wall out top
                        block22.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock22 = block22.AddComponent<SpriteRenderer>();
                        rendblock22.sprite = Colliderbox; // Load sprite with asset bundle
                        block22.transform.localPosition = new Vector3(9.6768f, -10.9f, 5f);
                        block22.transform.localScale = new Vector3(2.84f, 0.86f, 1f);
                        block22.SetActive(true);
                        block22.layer = 9;
                        BoxCollider2D collider2Dblock22 = block22.AddComponent<BoxCollider2D>();
                        collider2Dblock22.enabled = true;
                        collider2Dblock22.isTrigger = false;

                        GameObject block23 = new GameObject("LobbyLevel_Collider23"); //grill right
                        block23.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock23 = block23.AddComponent<SpriteRenderer>();
                        rendblock23.sprite = Colliderbox; // Load sprite with asset bundle
                        block23.transform.localPosition = new Vector3(11.3334f, -12.2417f, 5f);
                        block23.transform.localScale = new Vector3(0.1f, 3.22f, 1f);
                        block23.SetActive(true);
                        block23.layer = 9;
                        BoxCollider2D collider2Dblock23 = block23.AddComponent<BoxCollider2D>();
                        collider2Dblock23.enabled = true;
                        collider2Dblock23.isTrigger = false;
                        GameObject block24 = new GameObject("LobbyLevel_Collider24"); //grill bot
                        block24.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock24 = block24.AddComponent<SpriteRenderer>();
                        rendblock24.sprite = Colliderbox; // Load sprite with asset bundle
                        block24.transform.localPosition = new Vector3(8.84f, -14.0115f, 5f);
                        block24.transform.localScale = new Vector3(4.2868f, 0.2134f, 1f);
                        block24.SetActive(true);
                        block24.layer = 9;
                        BoxCollider2D collider2Dblock24 = block24.AddComponent<BoxCollider2D>();
                        collider2Dblock24.enabled = true;
                        collider2Dblock24.isTrigger = false;

                        GameObject block25 = new GameObject("LobbyLevel_Collider25"); //cam miniwall
                        block25.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock25 = block25.AddComponent<SpriteRenderer>();
                        rendblock25.sprite = Colliderbox; // Load sprite with asset bundle
                        block25.transform.localPosition = new Vector3(1.7285f, -10.84f, 5f);
                        block25.transform.localScale = new Vector3(0.28f, 0.86f, 1f);
                        block25.SetActive(true);
                        block25.layer = 9;
                        BoxCollider2D collider2Dblock25 = block25.AddComponent<BoxCollider2D>();
                        collider2Dblock25.enabled = true;
                        collider2Dblock25.isTrigger = false;

                        GameObject block27 = new GameObject("LobbyLevel_Collider27"); //Door Mini
                        block27.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock27 = block27.AddComponent<SpriteRenderer>();
                        rendblock27.sprite = Colliderbox; // Load sprite with asset bundle
                        block27.transform.localPosition = new Vector3(11.2285f, -10.64f, 5f);
                        block27.transform.localScale = new Vector3(0.28f, 0.86f, 1f);
                        block27.SetActive(true);
                        block27.layer = 9;
                        BoxCollider2D collider2Dblock27 = block27.AddComponent<BoxCollider2D>();
                        collider2Dblock27.enabled = true;
                        collider2Dblock27.isTrigger = false;

                        //V2.0


                        //EasterEgg

                        GameObject EE1 = new GameObject("LobbyLevel_EE1");
                        EE1.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE1 = EE1.AddComponent<SpriteRenderer>();
                        rendEE1.sprite = EA1; // Load sprite with asset bundle
                        EE1.transform.localPosition = new Vector3(0.6219f, -23.2167f, 0f);
                        EE1.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                        EE1.SetActive(true);
                        EE1.layer = 12;

                        GameObject EE2 = new GameObject("LobbyLevel_EE2");
                        EE2.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE2 = EE2.AddComponent<SpriteRenderer>();
                        rendEE2.sprite = EA2; // Load sprite with asset bundle
                        EE2.transform.localPosition = new Vector3(34.9896f, -8.8956f, 0f);
                        EE2.transform.localScale = new Vector3(0.4f, 0.35f, 1f);
                        EE2.SetActive(true);
                        EE2.layer = 12;

                        GameObject EE3 = new GameObject("LobbyLevel_EE3");
                        EE3.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE3 = EE3.AddComponent<SpriteRenderer>();
                        rendEE3.sprite = EA3; // Load sprite with asset bundle
                        EE3.transform.localPosition = new Vector3(22.5967f, -16.1365f, 0f);
                        EE3.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                        EE3.SetActive(true);
                        EE3.layer = 12;

                        GameObject EE4 = new GameObject("LobbyLevel_EE4");
                        EE4.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE4 = EE4.AddComponent<SpriteRenderer>();
                        rendEE4.sprite = EA4; // Load sprite with asset bundle
                        EE4.transform.localPosition = new Vector3(7.9169f, -16.4194f, 0f);
                        EE4.SetActive(true);
                        EE4.layer = 0;

                        GameObject EE5 = new GameObject("LobbyLevel_EE5");
                        EE5.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE5 = EE5.AddComponent<SpriteRenderer>();
                        rendEE5.sprite = EA5; // Load sprite with asset bundle
                        EE5.transform.localPosition = new Vector3(22.4549f, -20.2269f, 0f);
                        EE5.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                        EE5.SetActive(true);
                        EE5.layer = 12;

                        GameObject EE6 = new GameObject("LobbyLevel_EE6");
                        EE6.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendEE6 = EE6.AddComponent<SpriteRenderer>();
                        rendEE6.sprite = EA6; // Load sprite with asset bundle
                        EE6.transform.localPosition = new Vector3(33.5496f, -14.4765f, 0f);
                        EE6.SetActive(true);
                        EE6.layer = 0;


                        //Newtextures & Colliders


                        GameObject NewTexture = new GameObject("LobbyLevel_NewTexture");
                        NewTexture.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendNewTexture = NewTexture.AddComponent<SpriteRenderer>();
                        rendNewTexture.sprite = LobbyLevel_room_tunnel1; // Load sprite with asset bundle
                        NewTexture.transform.localPosition = new Vector3(29.5245f, -22.9338f, 2.4468f);
                        NewTexture.SetActive(true);
                        NewTexture.layer = 12;


                        GameObject Texture1 = new GameObject("LobbyLevel_Texture1");
                        Texture1.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendTexture1 = Texture1.AddComponent<SpriteRenderer>();
                        rendTexture1.sprite = Level_Tex1; // Load sprite with asset bundle
                        rendTexture1.renderingLayerMask = 1;
                        Texture1.transform.localPosition = new Vector3(31.595f, -28.5f, 1f);
                        Texture1.layer = 12;
                        BoxCollider2D collider2DTexture1 = Texture1.AddComponent<BoxCollider2D>();
                        collider2DTexture1.enabled = true;
                        collider2DTexture1.isTrigger = false;


                        GameObject Texture2 = new GameObject("LobbyLevel_Texture2");
                        Texture2.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendTexture2 = Texture2.AddComponent<SpriteRenderer>();
                        rendTexture2.sprite = Level_Tex2; // Load sprite with asset bundle
                        Texture2.transform.localPosition = new Vector3(35.0425f, -24.6738f, 2.4468f);
                        Texture2.SetActive(true);
                        Texture2.layer = 12;
                        BoxCollider2D collider2DTexture2 = Texture2.AddComponent<BoxCollider2D>();
                        collider2DTexture2.enabled = true;
                        collider2DTexture2.isTrigger = false;

                        GameObject Texture3 = new GameObject("LobbyLevel_Texture3");
                        Texture3.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendTexture3 = Texture3.AddComponent<SpriteRenderer>();
                        rendTexture3.sprite = Level_Tex3; // Load sprite with asset bundle
                        Texture3.transform.localPosition = new Vector3(34.3625f, -22.7338f, 2.4468f);
                        Texture3.transform.localScale = new Vector3(1f, 1f, 1f);
                        Texture3.SetActive(true);
                        Texture3.layer = 12;
                        BoxCollider2D collider2DTexture3 = Texture3.AddComponent<BoxCollider2D>();
                        collider2DTexture3.enabled = true;
                        collider2DTexture3.isTrigger = false;

                        GameObject Texture4 = new GameObject("LobbyLevel_Texture4");
                        Texture4.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendTexture4 = Texture4.AddComponent<SpriteRenderer>();
                        rendTexture4.sprite = Level_Tex4; // Load sprite with asset bundle
                        Texture4.transform.localPosition = new Vector3(31.2171f, -23.3938f, 2.4468f);
                        Texture4.transform.localScale = new Vector3(0.62f, 0.5f, 1f);
                        Texture4.SetActive(true);
                        Texture4.layer = 12;
                        BoxCollider2D collider2DTexture4 = Texture4.AddComponent<BoxCollider2D>();
                        collider2DTexture4.enabled = true;
                        collider2DTexture4.isTrigger = false;

                        GameObject block1 = new GameObject("LobbyLevel_Collider1");
                        block1.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock1 = block1.AddComponent<SpriteRenderer>();
                        rendblock1.sprite = Level_collider1; // Load sprite with asset bundle
                        block1.transform.localPosition = new Vector3(29.7785f, -19.8898f, 2.4468f);
                        block1.SetActive(true);
                        block1.layer = 9;
                        BoxCollider2D collider2Dblock1 = block1.AddComponent<BoxCollider2D>();
                        collider2Dblock1.enabled = true;
                        collider2Dblock1.isTrigger = false;

                        GameObject block2 = new GameObject("LobbyLevel_Collider2");
                        block2.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock2 = block2.AddComponent<SpriteRenderer>();
                        rendblock2.sprite = Level_collider2; // Load sprite with asset bundle
                        block2.transform.localPosition = new Vector3(29.1612f, -21.6778f, 2.4468f);
                        block2.transform.localScale = new Vector3(1f, 0.7894f, 1f);
                        block2.SetActive(true);
                        block2.layer = 9;
                        BoxCollider2D collider2Dblock2 = block2.AddComponent<BoxCollider2D>();
                        collider2Dblock2.enabled = true;
                        collider2Dblock2.isTrigger = false;

                        GameObject block3 = new GameObject("LobbyLevel_Collider3");
                        block3.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock3 = block3.AddComponent<SpriteRenderer>();
                        rendblock3.sprite = Level_collider3; // Load sprite with asset bundle
                        block3.transform.localPosition = new Vector3(28.6479f, -24.2124f, 2.4468f);
                        block3.transform.localScale = new Vector3(0.52f, 1f, 1f);
                        block3.SetActive(true);
                        block3.layer = 9;
                        BoxCollider2D collider2Dblock3 = block3.AddComponent<BoxCollider2D>();
                        collider2Dblock3.enabled = true;
                        collider2Dblock3.isTrigger = false;

                        GameObject block4 = new GameObject("LobbyLevel_Collider4");
                        block4.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock4 = block4.AddComponent<SpriteRenderer>();
                        rendblock4.sprite = Level_collider4; // Load sprite with asset bundle
                        block4.transform.localPosition = new Vector3(32.2973f, -21.7111f, 2.4468f);
                        block4.SetActive(true);
                        block4.layer = 9;
                        BoxCollider2D collider2Dblock4 = block4.AddComponent<BoxCollider2D>();
                        collider2Dblock4.enabled = true;
                        collider2Dblock4.isTrigger = false;

                        GameObject block5 = new GameObject("LobbyLevel_Collider5");
                        block5.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock5 = block5.AddComponent<SpriteRenderer>();
                        rendblock5.sprite = Level_collider5; // Load sprite with asset bundle
                        block5.transform.localPosition = new Vector3(27.0625f, -25.7338f, 2.4468f);
                        block5.transform.localScale = new Vector3(0.4f, 1f, 1f);
                        block5.SetActive(true);
                        block5.layer = 9;
                        BoxCollider2D collider2Dblock5 = block5.AddComponent<BoxCollider2D>();
                        collider2Dblock5.enabled = true;
                        collider2Dblock5.isTrigger = false;

                        GameObject block6 = new GameObject("LobbyLevel_Collider6");
                        block6.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock6 = block6.AddComponent<SpriteRenderer>();
                        rendblock6.sprite = Level_collider6; // Load sprite with asset bundle
                        block6.transform.localPosition = new Vector3(26.2025f, -21.9738f, 2.4468f);
                        block6.SetActive(true);
                        block6.layer = 9;
                        BoxCollider2D collider2Dblock6 = block6.AddComponent<BoxCollider2D>();
                        collider2Dblock6.enabled = true;
                        collider2Dblock6.isTrigger = false;

                        GameObject block7 = new GameObject("LobbyLevel_Collider7");
                        block7.transform.parent = ChallengerPolusShip.transform;
                        SpriteRenderer rendblock7 = block7.AddComponent<SpriteRenderer>();
                        rendblock7.sprite = Level_collider7; // Load sprite with asset bundle
                        block7.transform.localPosition = new Vector3(33.9225f, -22.0365f, 2.4468f);
                        block7.transform.localScale = new Vector3(-0.47f, -0.1613f, 1f);
                        block7.SetActive(true);
                        block7.layer = 9;
                        BoxCollider2D collider2Dblock7 = block7.AddComponent<BoxCollider2D>();
                        collider2Dblock7.enabled = true;
                        collider2Dblock7.isTrigger = false;


                        GameObject gameObject2 = new GameObject("LobbyLevel_GameObject2");
                        SpriteRenderer rend2 = gameObject2.AddComponent<SpriteRenderer>();
                        rend2.sprite = Affich2; // Load sprite with asset bundle
                        gameObject2.transform.localPosition = new Vector3(99f, 4.27f, 1f);

                        GameObject gameObject = new GameObject("LobbyLevel_GameObject");
                        SpriteRenderer rend = gameObject.AddComponent<SpriteRenderer>();
                        rend.sprite = Affich; // Load sprite with asset bundle
                        gameObject.transform.localPosition = new Vector3(0f, 4.27f, 1f);

                        if (gameObject != null && gameObject2 != null && ChallengerPolusShip != null && ChallengerMiraShip != null && newOiledPlayer != null &&
                            newTargetPlayer != null && HBlock1 != null && HBlock2 != null && HBlock3 != null && HBlock4 != null &&
                            HBlock5 != null && HBlock6 != null && HBlock7 != null && HBlock8 != null && HBlock9 != null &&
                            HBlock10 != null && HBlock11 != null && HBlock12 != null && HBlock13 != null && HBlock14 != null &&
                            HBlock15 != null && HBlock16 != null && HBlock17 != null && HBlock18 != null && HBlock19 != null &&
                            HBlock20 != null && HBlock21 != null && HBlock22 != null && HBlock23 != null && HBlock24 != null &&
                            HBlock25 != null && HBlock26 != null && HBlock27 != null && HBlock28 != null && HBlock29 != null &&
                            HBlock30 != null && HBlock31 != null && HBlock32 != null && HBlock33 != null && HBlock34 != null &&
                            HBlock35 != null && HBlock36 != null && HBlock37 != null && HBlock38 != null && HBlock39 != null &&
                            HBlock40 != null && HBlock41 != null && HBlock42 != null && HBlock43 != null && EE1 != null &&
                            EE2 != null && EE3 != null && EE4 != null && EE5 != null && EE6 != null &&
                            NewTexture != null && Texture1 != null && Texture2 != null && Texture3 != null && Texture4 != null &&
                            block1 != null && block2 != null && block3 != null && block4 != null && block5 != null &&
                            block6 != null && block7)
                        {
                            GameObject StopCreate = new GameObject("LobbyLevel_Data");
                        }

                    }

                }


               


                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    if (player != null)
                    {
                        if (Challenger.IsrankedGame)
                        {
                            if (Challenger.ReadyPlayers.Contains(player.name))
                            {
                                player.cosmetics.nameText.color = GreenColor;
                            }
                            else
                            {
                                player.cosmetics.nameText.color = RedColor;
                            }
                        }
                        else
                        {
                            player.cosmetics.nameText.color = OrangeColor;
                        }
                    }
                }

                

                   // Playercontrol.Renderer.material.SetColor(ChallengerMod.ColorTable.VisorColor, Palette.ImpostorRed);
                


                GetSteamID = SteamUser.GetSteamID().ToString();

                
                ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank = GoodlossRank;

                        /*byte Player = 0;
                        int color = 0;
                        Player = PlayerControl.LocalPlayer.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetVisorColor, Hazel.SendOption.Reliable, -1);
                        writer.Write(Player);
                        writer.Write(color);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setVisorColor(Player, color);*/



                if (debugMod >= 6)
                {

                    ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Lily = true;

                }

                if (debugMod < 6)
                {
                    if (Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        debugMod = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad1))
                    {
                        debugMod = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad2))
                    {
                        if (debugMod == 2) { debugMod += 1; }
                        else { debugMod = 0; }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad3))
                    {
                        if (debugMod == 3) { debugMod += 1; }
                        else { debugMod = 0; }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad4))
                    {
                        debugMod = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad5))
                    {
                        debugMod = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad6))
                    {
                        if (debugMod == 4) { debugMod += 1; }
                        else { debugMod = 0; }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad7))
                    {
                        debugMod = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad8))
                    {
                        if (debugMod < 2) { debugMod += 1; }
                        else { debugMod = 0; }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad9))
                    {
                        if (debugMod == 5)
                        {
                            debugMod += 1;
                            SoundManager.Instance.PlaySound(ShieldBuff, false, 100f);
                            
                        }
                        else { debugMod = 0; }
                    }
                }





                

                if (Challenger.IsrankedGame == true)
                {
                    RTXT_0 = RTXT_2;
                    RT_ACTIF = "";
                }
                if (Challenger.IsrankedGame == false)
                {
                    RTXT_0 = RTXT_1;
                    RT_ACTIF = "";
                }

                


                if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
                {

                   
                    RTXT_1 = RTXT_1FR;
                    RTXT_2 = RTXT_2FR;
                    RT_100 = RT_100FR;
                    RT_0 = RT_0FR;
                    RT_1 = RT_1FR;
                    RT_2 = RT_2FR;
                    RT_3 = RT_3FR;
                    RT_4 = RT_4FR;
                    RT_5 = RT_5FR;
                    RT_6 = RT_6FR;
                    RT_7 = RT_7FR;
                    RT_8 = RT_8FR;
                    Role_Crewmate = CrewmateFR;
                    Role_Sheriff = SheriffFR;
                    Role_Engineer = EngineerFR;
                    Role_Guardian = GuardianFR;
                    Role_Timelord = TimelordFR;
                    Role_Hunter = HunterFR;
                    Role_Mystic = MysticFR;
                    Role_Spirit = SpiritFR;
                    Role_Mayor = MayorFR;
                    Role_Detective = DetectiveFR;
                    Role_Nightwatch = NightwatchFR;
                    Role_Spy = SpyFR;
                    Role_Informant = InformantFR;
                    Role_Bait = BaitFR;
                    Role_Mentalist = MentalistFR;
                    Role_Builder = BuilderFR;
                    Role_Dictator = DictatorFR;
                    Role_Sentinel = SentinelFR;
                    Role_Teammate = TeammateFR;
                    Role_Lawkeeper = LawkeeperFR;
                    Role_Fake = FakeFR;
                    Role_Traveler = TravelerFR;
                    Role_Leader = LeaderFR;
                    Role_Doctor = DoctorFR;
                    Role_Slave = SlaveFR;
                    Role_Master = MasterFR;
                    Role_Cupid = CupidFR;
                    Role_Cultist = CultistFR;
                    Role_Outlaw = OutlawFR;
                    Role_Jester = JesterFR;
                    Role_Eater = EaterFR;
                    Role_Arsonist = ArsonistFR;
                    Role_Cursed = CursedFR;
                    Role_Mercenary = MercenaryFR;
                    Role_CopyCat = CopyCatFR;
                    Role_Survivor = SurvivorFR;
                    Role_Revenger = RevengerFR;
                    Role_Impostor = ImpostorFR;
                    Role_Assassin = AssassinFR;
                    Role_Vector = VectorFR;
                    Role_Morphling = MorphlingFR;
                    Role_Scrambler = ScramblerFR;
                    Role_Barghest = BarghestFR;
                    Role_Ghost = GhostFR;
                    Role_Sorcerer = SorcererFR;
                    Role_Guesser = GuesserFR;
                    Role_Mesmer = MesmerFR;
                    Role_Basilisk = BasiliskFR;
                    Role_Reaper = ReaperFR;
                    Role_Saboteur = SaboteurFR;
                    Str_Win = WinFR;
                    Str_Loose = LooseFR;
                    Str_JesterWin = JesterWinFR;
                    Str_EaterWin = EaterWinFR;
                    Str_OutlawWin = OutlawWinFR;
                    Str_ArsonistWin = ArsonistWinFR;
                    Str_CursedWin = CursedWinFR;
                    Str_CulteWin = CulteWinFR;
                    Str_CupidWin = CupidWinFR;
                    Str_CrewmateWin = CrewmateWinFR;
                    Str_ImpostorWin = ImpostorWinFR;
                    Str_BySabWin = BySabWinFR;
                    Str_ByVoteWin = ByVoteWinFR;
                    Str_ByTaskWin = ByTaskWinFR;
                    Str_ByKillWin = ByKillWinFR;
                    Task_Role_Crewmate = Task_CrewmateFR;
                    Task_Role_Sheriff = Task_SheriffFR;
                    Task_Role_Engineer = Task_EngineerFR;
                    Task_Role_Guardian = Task_GuardianFR;
                    Task_Role_Timelord = Task_TimelordFR;
                    Task_Role_Hunter = Task_HunterFR;
                    Task_Role_Mystic = Task_MysticFR;
                    Task_Role_Spirit = Task_SpiritFR;
                    Task_Role_Mayor = Task_MayorFR;
                    Task_Role_Detective = Task_DetectiveFR;
                    Task_Role_Nightwatch = Task_NightwatchFR;
                    Task_Role_Spy = Task_SpyFR;
                    Task_Role_Informant = Task_InformantFR;
                    Task_Role_Bait = Task_BaitFR;
                    Task_Role_Mentalist = Task_MentalistFR;
                    Task_Role_Builder = Task_BuilderFR;
                    Task_Role_Dictator = Task_DictatorFR;
                    Task_Role_Sentinel = Task_SentinelFR;
                    Task_Role_Teammate = Task_TeammateFR;
                    Task_Role_Lawkeeper = Task_LawkeeperFR;
                    Task_Role_Fake = Task_FakeFR;
                    Task_Role_Traveler = Task_TravelerFR;
                    Task_Role_Leader = Task_LeaderFR;
                    Task_Role_Doctor = Task_DoctorFR;
                    Task_Role_Slave = Task_SlaveFR;
                    Task_Role_Master = Task_MasterFR;
                    Task_Role_Cupid = Task_CupidFR;
                    Task_Role_Cultist = Task_CultistFR;
                    Task_Role_Culte = Task_CulteFR;
                    Task_Role_Outlaw = Task_OutlawFR;
                    Task_Role_Jester = Task_JesterFR;
                    Task_Role_Eater = Task_EaterFR;
                    Task_Role_Arsonist = Task_ArsonistFR;
                    Task_Role_Cursed = Task_CursedFR;
                    Task_Role_Mercenary = Task_MercenaryFR;
                    Task_Role_CopyCat = Task_CopyCatFR;
                    Task_Role_Survivor = Task_SurvivorFR;
                    Task_Role_Revenger = Task_RevengerFR;
                    Task_Role_Impostor = Task_ImpostorFR;
                    Task_Role_Assassin = Task_AssassinFR;
                    Task_Role_Vector = Task_VectorFR;
                    Task_Role_Morphling = Task_MorphlingFR;
                    Task_Role_Scrambler = Task_ScramblerFR;
                    Task_Role_Barghest = Task_BarghestFR;
                    Task_Role_Ghost = Task_GhostFR;
                    Task_Role_Sorcerer = Task_SorcererFR;
                    Task_Role_Guesser = Task_GuesserFR;
                    Task_Role_Mesmer = Task_MesmerFR;
                    Task_Role_Basilisk = Task_BasiliskFR;
                    Task_Role_Reaper = Task_ReaperFR;
                    Task_Role_Saboteur = Task_SaboteurFR;
                    Client_VerNoStart = Client_VerNoStartFR;
                    Client_VerUpdate = Client_VerUpdateFR;
                    Client_VerMiss = Client_VerMissFR;
                    Client_VerDiff = Client_VerDiffFR;
                    BTT_Role_Kill = BTT_KillFR;
                    BTT_Role_Guardian = BTT_GuardianFR;
                    BTT_Role_Engineer = BTT_EngineerFR;
                    BTT_Role_Timelord = BTT_TimelordFR;
                    BTT_Role_Hunter = BTT_HunterFR;
                    BTT_Role_Mystic = BTT_MysticFR;
                    BTT_Role_Spirit = BTT_SpiritFR;
                    BTT_Role_Mayor = BTT_MayorFR;
                    BTT_Role_Detective = BTT_DetectiveFR;
                    BTT_Role_Nightwatch = BTT_NightwatchFR;
                    BTT_Role_Spy = BTT_SpyFR;
                    BTT_Role_Bait = BTT_BaitFR;
                    BTT_Role_Informant = BTT_InformantFR;
                    BTT_Role_Mentalist = BTT_MentalistFR;
                    BTT_Role_Builder = BTT_BuilderFR;
                    BTT_Role_Dictator = BTT_DictatorFR;
                    BTT_Role_Sentinel = BTT_SentinelFR;
                    BTT_Role_Leader = BTT_LeaderFR;
                    BTT_Role_Traveler = BTT_TravelerFR;
                    BTT_Role_Doctor1 = BTT_Doctor1FR;
                    BTT_Role_Cupid = BTT_CupidFR;
                    BTT_Role_Cultist = BTT_CultistFR;
                    BTT_Role_Jester = BTT_JesterFR;
                    BTT_Role_EaterEat = BTT_EaterEatFR;
                    BTT_Role_EaterDragg = BTT_EaterDraggFR;
                    BTT_Role_EaterDrop = BTT_EaterDropFR;
                    BTT_Role_ArsonistOil = BTT_ArsonistOilFR;
                    BTT_Role_ArsonistBurn = BTT_ArsonistBurnFR;
                    BTT_Role_Cursed = BTT_CursedFR;
                    BTT_Role_CopyCat = BTT_CopyCatFR;
                    BTT_Role_Revenger = BTT_RevengerFR;
                    BTT_Role_Vector = BTT_VectorFR;
                    BTT_Role_MorphlingSteal = BTT_MorphlingStealFR;
                    BTT_Role_MorphlingMorph = BTT_MorphlingMorphFR;
                    BTT_Role_Scrambler = BTT_ScramblerFR;
                    BTT_Role_BarghestShadow = BTT_BarghestShadowFR;
                    BTT_Role_BarghestVent = BTT_BarghestVentFR;
                    BTT_Role_Ghost = BTT_GhostFR;
                    BTT_Role_Sorcerer = BTT_SorcererFR;
                    BTT_Role_Sorcerer1 = BTT_Sorcerer1FR;
                    BTT_Role_Sorcerer2 = BTT_Sorcerer2FR;
                    BTT_Role_Sorcerer3 = BTT_Sorcerer3FR;
                    BTT_Role_SorcererFind = BTT_SorcererFindFR;
                    BTT_Role_MesmerTarget = BTT_MesmerTargetFR;
                    BTT_Role_MesmerMc = BTT_MesmerMcFR;
                    BTT_Role_Basilisk = BTT_BasiliskFR;
                    BTT_Role_Basilisk2 = BTT_Basilisk2FR;

                    BTT_Role_ReaperTake = BTT_ReaperTakeFR;
                    BTT_Role_ReaperDrop = BTT_ReaperDropFR;
                    BTT_Role_Saboteur = BTT_SaboteurFR;
                    BTT_ScanBody = BTT_ScanBodyFR;
                    SG_Ready = SG_ReadyFR;
                    TXT_Buzz = TXT_BuzzFR;
                    TXT_LawSuspect = TXT_LawSuspectFR;
                    TXT_LawKillerdie = TXT_LawKillerdieFR;
                    TXT_LawKiller = TXT_LawKillerFR;
                    TXT_Deathreason0 = TXT_Deathreason0FR;
                    TXT_Deathreason1 = TXT_Deathreason1FR;
                    TXT_Deathreason2 = TXT_Deathreason2FR;
                    TXT_Deathreason3 = TXT_Deathreason3FR;
                    TXT_Deathreason4 = TXT_Deathreason4FR;
                    TXT_Deathreason5 = TXT_Deathreason5FR;

                    BTT_Ready = BTT_ReadyFR;
                    ChallengerMod.Utility.Discord.DiscordData.UpdateIco(STR_myRank, STR_myRankname);
                }

                else
                {


                    RTXT_1 = RTXT_1EN;
                    RTXT_2 = RTXT_2EN;
                    RT_100 = RT_100EN;
                    RT_0 = RT_0EN;
                    RT_1 = RT_1EN;
                    RT_2 = RT_2EN;
                    RT_3 = RT_3EN;
                    RT_4 = RT_4EN;
                    RT_5 = RT_5EN;
                    RT_6 = RT_6EN;
                    RT_7 = RT_7EN;
                    RT_8 = RT_8EN;
                    Role_Crewmate = CrewmateEN;
                    Role_Sheriff = SheriffEN;
                    Role_Engineer = EngineerEN;
                    Role_Guardian = GuardianEN;
                    Role_Timelord = TimelordEN;
                    Role_Hunter = HunterEN;
                    Role_Mystic = MysticEN;
                    Role_Spirit = SpiritEN;
                    Role_Mayor = MayorEN;
                    Role_Detective = DetectiveEN;
                    Role_Nightwatch = NightwatchEN;
                    Role_Spy = SpyEN;
                    Role_Informant = InformantEN;
                    Role_Bait = BaitEN;
                    Role_Mentalist = MentalistEN;
                    Role_Builder = BuilderEN;
                    Role_Dictator = DictatorEN;
                    Role_Sentinel = SentinelEN;
                    Role_Teammate = TeammateEN;
                    Role_Lawkeeper = LawkeeperEN;
                    Role_Fake = FakeEN;
                    Role_Traveler = TravelerEN;
                    Role_Leader = LeaderEN;
                    Role_Doctor = DoctorEN;
                    Role_Slave = SlaveEN;
                    Role_Master = MasterEN;
                    Role_Cupid = CupidEN;
                    Role_Cultist = CultistEN;
                    Role_Outlaw = OutlawEN;
                    Role_Jester = JesterEN;
                    Role_Eater = EaterEN;
                    Role_Arsonist = ArsonistEN;
                    Role_Cursed = CursedEN;
                    Role_Mercenary = MercenaryEN;
                    Role_CopyCat = CopyCatEN;
                    Role_Survivor = SurvivorEN;
                    Role_Revenger = RevengerEN;
                    Role_Impostor = ImpostorEN;
                    Role_Assassin = AssassinEN;
                    Role_Vector = VectorEN;
                    Role_Morphling = MorphlingEN;
                    Role_Scrambler = ScramblerEN;
                    Role_Barghest = BarghestEN;
                    Role_Ghost = GhostEN;
                    Role_Sorcerer = SorcererEN;
                    Role_Guesser = GuesserEN;
                    Role_Mesmer = MesmerEN;
                    Role_Basilisk = BasiliskEN;
                    Role_Reaper = ReaperEN;
                    Role_Saboteur = SaboteurEN;
                    Role_Lover = LoverEN;
                    Role_CulteMember = CulteMemberEN;
                    Str_Win = WinEN;
                    Str_Loose = LooseEN;
                    Str_JesterWin = JesterWinEN;
                    Str_EaterWin = EaterWinEN;
                    Str_OutlawWin = OutlawWinEN;
                    Str_ArsonistWin = ArsonistWinEN;
                    Str_CursedWin = CursedWinEN;
                    Str_CulteWin = CulteWinEN;
                    Str_CupidWin = CupidWinEN;
                    Str_CrewmateWin = CrewmateWinEN;
                    Str_ImpostorWin = ImpostorWinEN;
                    Str_BySabWin = BySabWinEN;
                    Str_ByVoteWin = ByVoteWinEN;
                    Str_ByTaskWin = ByTaskWinEN;
                    Str_ByKillWin = ByKillWinEN;
                    Task_Role_Crewmate = Task_CrewmateEN;
                    Task_Role_Sheriff = Task_SheriffEN;
                    Task_Role_Engineer = Task_EngineerEN;
                    Task_Role_Guardian = Task_GuardianEN;
                    Task_Role_Timelord = Task_TimelordEN;
                    Task_Role_Hunter = Task_HunterEN;
                    Task_Role_Mystic = Task_MysticEN;
                    Task_Role_Spirit = Task_SpiritEN;
                    Task_Role_Mayor = Task_MayorEN;
                    Task_Role_Detective = Task_DetectiveEN;
                    Task_Role_Nightwatch = Task_NightwatchEN;
                    Task_Role_Spy = Task_SpyEN;
                    Task_Role_Informant = Task_InformantEN;
                    Task_Role_Bait = Task_BaitEN;
                    Task_Role_Mentalist = Task_MentalistEN;
                    Task_Role_Builder = Task_BuilderEN;
                    Task_Role_Dictator = Task_DictatorEN;
                    Task_Role_Sentinel = Task_SentinelEN;
                    Task_Role_Teammate = Task_TeammateEN;
                    Task_Role_Lawkeeper = Task_LawkeeperEN;
                    Task_Role_Fake = Task_FakeEN;
                    Task_Role_Traveler = Task_TravelerEN;
                    Task_Role_Leader = Task_LeaderEN;
                    Task_Role_Doctor = Task_DoctorEN;
                    Task_Role_Master = Task_MasterEN;
                    Task_Role_Slave = Task_SlaveEN;
                    Task_Role_Cupid = Task_CupidEN;
                    Task_Role_Cultist = Task_CultistEN;
                    Task_Role_Culte = Task_CulteEN;
                    Task_Role_Outlaw = Task_OutlawEN;
                    Task_Role_Jester = Task_JesterEN;
                    Task_Role_Eater = Task_EaterEN;
                    Task_Role_Arsonist = Task_ArsonistEN;
                    Task_Role_Cursed = Task_CursedEN;
                    Task_Role_Mercenary = Task_MercenaryEN;
                    Task_Role_CopyCat = Task_CopyCatEN;
                    Task_Role_Survivor = Task_SurvivorEN;
                    Task_Role_Revenger = Task_RevengerEN;
                    Task_Role_Impostor = Task_ImpostorEN;
                    Task_Role_Assassin = Task_AssassinEN;
                    Task_Role_Vector = Task_VectorEN;
                    Task_Role_Morphling = Task_MorphlingEN;
                    Task_Role_Scrambler = Task_ScramblerEN;
                    Task_Role_Barghest = Task_BarghestEN;
                    Task_Role_Ghost = Task_GhostEN;
                    Task_Role_Sorcerer = Task_SorcererEN;
                    Task_Role_Guesser = Task_GuesserEN;
                    Task_Role_Mesmer = Task_MesmerEN;
                    Task_Role_Basilisk = Task_BasiliskEN;
                    Task_Role_Reaper = Task_ReaperEN;
                    Task_Role_Saboteur = Task_SaboteurEN;
                    Client_VerNoStart = Client_VerNoStartEN;
                    Client_VerUpdate = Client_VerUpdateEN;
                    Client_VerMiss = Client_VerMissEN;
                    Client_VerDiff = Client_VerDiffEN;
                    BTT_Role_Kill = BTT_KillEN;
                    BTT_Role_Guardian = BTT_GuardianEN;
                    BTT_Role_Engineer = BTT_EngineerEN;
                    BTT_Role_Timelord = BTT_TimelordEN;
                    BTT_Role_Hunter = BTT_HunterEN;
                    BTT_Role_Mystic = BTT_MysticEN;
                    BTT_Role_Spirit = BTT_SpiritEN;
                    BTT_Role_Mayor = BTT_MayorEN;
                    BTT_Role_Detective = BTT_DetectiveEN;
                    BTT_Role_Nightwatch = BTT_NightwatchEN;
                    BTT_Role_Spy = BTT_SpyEN;
                    BTT_Role_Bait = BTT_BaitEN;
                    BTT_Role_Informant = BTT_InformantEN;
                    BTT_Role_Mentalist = BTT_MentalistEN;
                    BTT_Role_Builder = BTT_BuilderEN;
                    BTT_Role_Dictator = BTT_DictatorEN;
                    BTT_Role_Sentinel = BTT_SentinelEN;
                    BTT_Role_Leader = BTT_LeaderFR;
                    BTT_Role_Traveler = BTT_TravelerEN;
                    BTT_Role_Doctor1 = BTT_Doctor1EN;
                    BTT_Role_Cupid = BTT_CupidEN;
                    BTT_Role_Cultist = BTT_CultistEN;
                    BTT_Role_Jester = BTT_JesterEN;
                    BTT_Role_EaterEat = BTT_EaterEatEN;
                    BTT_Role_EaterDragg = BTT_EaterDraggEN;
                    BTT_Role_EaterDrop = BTT_EaterDropEN;
                    BTT_Role_ArsonistOil = BTT_ArsonistOilEN;
                    BTT_Role_ArsonistBurn = BTT_ArsonistBurnEN;
                    BTT_Role_Cursed = BTT_CursedEN;
                    BTT_Role_CopyCat = BTT_CopyCatEN;
                    BTT_Role_Revenger = BTT_RevengerEN;
                    BTT_Role_Vector = BTT_VectorEN;
                    BTT_Role_MorphlingSteal = BTT_MorphlingStealEN;
                    BTT_Role_MorphlingMorph = BTT_MorphlingMorphEN;
                    BTT_Role_Scrambler = BTT_ScramblerEN;
                    BTT_Role_BarghestShadow = BTT_BarghestShadowEN;
                    BTT_Role_BarghestVent = BTT_BarghestVentEN;
                    BTT_Role_Ghost = BTT_GhostEN;
                    BTT_Role_Sorcerer = BTT_SorcererEN;
                    BTT_Role_Sorcerer1 = BTT_Sorcerer1EN;
                    BTT_Role_Sorcerer2 = BTT_Sorcerer2EN;
                    BTT_Role_Sorcerer3 = BTT_Sorcerer3EN;
                    BTT_Role_SorcererFind = BTT_SorcererFindEN;
                    BTT_Role_MesmerTarget = BTT_MesmerTargetEN;
                    BTT_Role_MesmerMc = BTT_MesmerMcEN;
                    BTT_Role_Basilisk = BTT_BasiliskEN;
                    BTT_Role_Basilisk2 = BTT_Basilisk2EN;
                    BTT_Role_ReaperTake = BTT_ReaperTakeEN;
                    BTT_Role_ReaperDrop = BTT_ReaperDropEN;
                    BTT_Role_Saboteur = BTT_SaboteurEN;
                    BTT_ScanBody = BTT_ScanBodyEN;
                    SG_Ready = SG_ReadyEN;
                    TXT_Buzz = TXT_BuzzEN;
                    TXT_LawSuspect = TXT_LawSuspectEN;
                    TXT_LawKiller = TXT_LawKillerEN;
                    TXT_LawKillerdie = TXT_LawKillerdieEN;
                    TXT_Deathreason0 = TXT_Deathreason0EN;
                    TXT_Deathreason1 = TXT_Deathreason1EN;
                    TXT_Deathreason2 = TXT_Deathreason2EN;
                    TXT_Deathreason3 = TXT_Deathreason3EN;
                    TXT_Deathreason4 = TXT_Deathreason4EN;
                    TXT_Deathreason5 = TXT_Deathreason5EN;

                    BTT_Ready = BTT_ReadyEN;
                    ChallengerMod.Utility.Discord.DiscordData.UpdateIco(STR_myRank, STR_myRankname);

                }

                
            

        }
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {

                if (AmongUsClient.Instance.AmHost && RoleAssigned == false && (LoadImpostor == RealImpostor))
                {

                    //RESET DATA / ROLE
                    ChallengerMod.Utility.Discord.DiscordData.UpdateDetails(RTXT_0);
                    ChallengerMod.Utility.Discord.DiscordData.UpdateState("- " + STRMap);

                    List<string> CrewmatesList = new List<string>();
                    List<string> SpecialsList = new List<string>();
                    List<string> HybridList = new List<string>();
                    List<string> ImpostorsList = new List<string>();




                   



                    

                    if ((NuclearTimerMod.getBool() == true) && (rng.Next(1, 101) <= NuclearRND.getFloat()))
                    { 
                        ChallengerMod.Challenger.NuclearMap = true;
                        MessageWriter Nuclear = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncMap, Hazel.SendOption.Reliable, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(Nuclear);
                        RPCProcedure.syncMap();


                    }

                    //CrewmatesList
                    if ((SherifAdd.getBool() == true) && (rng.Next(1, 101) <= SherifSpawnChance.getFloat()))
                    { CrewmatesList.Add("Sheriff1"); }
                    if ((SherifAdd.getBool() == true) && (rng.Next(1, 101) <= Sherif2SpawnChance.getFloat()))
                    { CrewmatesList.Add("Sheriff2"); }
                    if ((SherifAdd.getBool() == true) && (rng.Next(1, 101) <= Sherif3SpawnChance.getFloat()))
                    { CrewmatesList.Add("Sheriff3"); }
                    if ((engineerAdd.getBool() == true) && (rng.Next(1, 101) <= engineerSpawnChance.getFloat()))
                    { CrewmatesList.Add("Engineer"); }
                    if ((GuardianAdd.getBool() == true) && (rng.Next(1, 101) <= GuardianSpawnChance.getFloat()))
                    { CrewmatesList.Add("Guardian"); }
                    if ((HunterAdd.getBool() == true) && (rng.Next(1, 101) <= HunterSpawnChance.getFloat()))
                    { CrewmatesList.Add("Hunter"); }
                    if ((TimeLordAdd.getBool() == true) && (rng.Next(1, 101) <= TimeLordSpawnChance.getFloat()))
                    { CrewmatesList.Add("Timelord"); }
                    if ((MysticAdd.getBool() == true) && (rng.Next(1, 101) <= MysticSpawnChance.getFloat()))
                    { CrewmatesList.Add("Mystic"); }
                    if ((SpiritAdd.getBool() == true) && (rng.Next(1, 101) <= SpiritSpawnChance.getFloat()))
                    { CrewmatesList.Add("Spirit"); }
                    if ((MayorAdd.getBool() == true) && (rng.Next(1, 101) <= MayorSpawnChance.getFloat()))
                    { CrewmatesList.Add("Mayor"); }
                    if ((DetectiveAdd.getBool() == true) && (rng.Next(1, 101) <= DetectiveSpawnChance.getFloat()))
                    { CrewmatesList.Add("Detective"); }
                    if ((NightwatcherAdd.getBool() == true) && (rng.Next(1, 101) <= NightwatcherSpawnChance.getFloat()))
                    { CrewmatesList.Add("Nightwatch"); }
                    if ((SpyAdd.getBool() == true) && (rng.Next(1, 101) <= SpySpawnChance.getFloat()))
                    { CrewmatesList.Add("Spy"); }
                    if ((InforAdd.getBool() == true) && (rng.Next(1, 101) <= InforSpawnChance.getFloat()))
                    { CrewmatesList.Add("Informant"); }
                    if ((BaitAdd.getBool() == true) && (rng.Next(1, 101) <= BaitSpawnChance.getFloat()))
                    { CrewmatesList.Add("Bait"); }
                    if ((MentalistAdd.getBool() == true) && (rng.Next(1, 101) <= MentalistSpawnChance.getFloat()))
                    { CrewmatesList.Add("Mentalist"); }
                    if ((BuilderAdd.getBool() == true) && (rng.Next(1, 101) <= BuilderSpawnChance.getFloat()))
                    { CrewmatesList.Add("Builder"); }
                    if ((DictatorAdd.getBool() == true) && (rng.Next(1, 101) <= DictatorSpawnChance.getFloat()))
                    { CrewmatesList.Add("Dictator"); }
                    if ((SentinelAdd.getBool() == true) && (rng.Next(1, 101) <= SentinelSpawnChance.getFloat()))
                    { CrewmatesList.Add("Sentinel"); }
                    if ((MateAdd.getBool() == true) && (rng.Next(1, 101) <= MateSpawnChance.getFloat()))
                    { CrewmatesList.Add("Teammate1"); }
                    if ((LawkeeperAdd.getBool() == true) && (rng.Next(1, 101) <= LawkeeperSpawnChance.getFloat()))
                    { CrewmatesList.Add("Lawkeeper"); }
                    if ((FakeAdd.getBool() == true) && (rng.Next(1, 101) <= FakeSpawnChance.getFloat()))
                    { CrewmatesList.Add("Fake"); }
                    if ((LeaderAdd.getBool() == true) && (rng.Next(1, 101) <= LeaderSpawnChance.getFloat()))
                    { CrewmatesList.Add("Leader"); }


                    //SpecialsList
                    if ((JesterAdd.getBool() == true) && (rng.Next(1, 101) <= JesterSpawnChance.getFloat()))
                    { SpecialsList.Add("Jester"); }
                    if ((EaterAdd.getBool() == true) && (rng.Next(1, 101) <= EaterSpawnChance.getFloat()))
                    { SpecialsList.Add("Eater"); }
                    if ((CupidAdd.getBool() == true) && (rng.Next(1, 101) <= CupidSpawnChance.getFloat()))
                    { SpecialsList.Add("Cupid"); }
                    if ((CultisteAdd.getBool() == true) && (rng.Next(1, 101) <= CultisteSpawnChance.getFloat()))
                    { SpecialsList.Add("Cultist"); }
                    if ((OutlawAdd.getBool() == true) && (rng.Next(1, 101) <= OutlawSpawnChance.getFloat()))
                    { SpecialsList.Add("Outlaw"); }
                    if ((ArsonistAdd.getBool() == true) && (rng.Next(1, 101) <= ArsonistSpawnChance.getFloat()))
                    { SpecialsList.Add("Arsonist"); }
                    if ((CursedAdd.getBool() == true) && (rng.Next(1, 101) <= CursedSpawnChance.getFloat()))
                    { SpecialsList.Add("Cursed"); }

                    // HybridList
                    if ((MercenaryAdd.getBool() == true) && (rng.Next(1, 101) <= MercenarySpawnChance.getFloat()))
                    { HybridList.Add("Mercenary"); }
                    if ((CopyCatAdd.getBool() == true) && (rng.Next(1, 101) <= CopyCatSpawnChance.getFloat()))
                    { HybridList.Add("CopyCat"); }
                    if ((SorcererAdd.getBool() == true) && (rng.Next(1, 101) <= SorcererSpawnChance.getFloat()))
                    { HybridList.Add("Survivor"); }
                    if ((RevengerAdd.getBool() == true) && (rng.Next(1, 101) <= RevengerSpawnChance.getFloat()))
                    { HybridList.Add("Revenger"); }

                    //ImpostorsList
                    if ((AssassinAdd.getBool() == true) && (rng.Next(1, 101) <= AssassinSpawnChance.getFloat()))
                    { ImpostorsList.Add("Assassin"); }
                    if ((VectorAdd.getBool() == true) && (rng.Next(1, 101) <= VectorSpawnChance.getFloat()))
                    { ImpostorsList.Add("Vector"); }
                    if ((CamoAdd.getBool() == true) && (rng.Next(1, 101) <= CamoSpawnChance.getFloat()))
                    { ImpostorsList.Add("Scrambler"); }
                    if ((MorphlingAdd.getBool() == true) && (rng.Next(1, 101) <= MorphlingSpawnChance.getFloat()))
                    { ImpostorsList.Add("Morphling"); }
                    if ((GhostAdd.getBool() == true) && (rng.Next(1, 101) <= GhostSpawnChance.getFloat()))
                    { ImpostorsList.Add("Ghost"); }
                    if ((BarghestAdd.getBool() == true) && (rng.Next(1, 101) <= BarghestSpawnChance.getFloat()))
                    { ImpostorsList.Add("Barghest"); }
                    if ((GuesserAdd.getBool() == true) && (rng.Next(1, 101) <= GuesserSpawnChance.getFloat()))
                    { ImpostorsList.Add("Guesser"); }
                    if ((WarAdd.getBool() == true) && (rng.Next(1, 101) <= WarSpawnChance.getFloat()))
                    { ImpostorsList.Add("Sorcerer"); }
                    if ((BasiliskAdd.getBool() == true) && (rng.Next(1, 101) <= BasiliskSpawnChance.getFloat()))
                     { ImpostorsList.Add("Basilisk"); }

                    //RND > Shuffle
                    ImpostorsList.Shuffle();
                    SpecialsList.Shuffle();
                    CrewmatesList.Shuffle();
                    HybridList.Shuffle();
                    var rnd = new System.Random();

                    var randomizedImpo = ImpostorsList.OrderBy(item => rnd.Next());
                    var randomizedSpe = SpecialsList.OrderBy(item => rnd.Next());
                    var randomizedDuo = HybridList.OrderBy(item => rnd.Next());
                    var randomizedCrew = CrewmatesList.OrderBy(item => rnd.Next());

                    //Check and remove 
                    ImpostorsList.RemoveRange(0, ImpostorsList.Count - (((byte)QTImp.getFloat() >= ImpostorsList.Count) ? ImpostorsList.Count : (byte)QTImp.getFloat()));
                    SpecialsList.RemoveRange(0, SpecialsList.Count - (((byte)QTSpe.getFloat() >= SpecialsList.Count) ? SpecialsList.Count : (byte)QTSpe.getFloat()));
                    CrewmatesList.RemoveRange(0, CrewmatesList.Count - (((byte)QTCrew.getFloat() >= CrewmatesList.Count) ? CrewmatesList.Count : (byte)QTCrew.getFloat()));
                    HybridList.RemoveRange(0, HybridList.Count - (((byte)QTDuo.getFloat() >= HybridList.Count) ? HybridList.Count : (byte)QTDuo.getFloat()));


                    //Add 2nd Teammate
                    if (CrewmatesList.Contains("Teammate1"))
                    {
                        CrewmatesList.Add("Teammate2");
                    }


                    //GEN LIST FOR SETROLES
                    List<PlayerControl> crewmates = PlayerControl.AllPlayerControls.ToArray().ToList().OrderBy(x => Guid.NewGuid()).ToList();
                    crewmates.RemoveAll(x => x.Data.Role.IsImpostor);
                    List<PlayerControl> impostors = PlayerControl.AllPlayerControls.ToArray().ToList().OrderBy(x => Guid.NewGuid()).ToList();
                    impostors.RemoveAll(x => !x.Data.Role.IsImpostor);

                    

                    //List Impostors players

                    if (ImpostorsList.Contains("Assassin") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetAssassin;
                        var AssassinRandom = rng.Next(0, impostors.Count);
                        Assassin.Role = impostors[AssassinRandom];
                        impostors.RemoveAt(AssassinRandom);
                        byte playerId = Assassin.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Assassin");
                    }
                    if (ImpostorsList.Contains("Vector") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetVector;
                        var VectorRandom = rng.Next(0, impostors.Count);
                        Vector.Role = impostors[VectorRandom];
                        impostors.RemoveAt(VectorRandom);
                        byte playerId = Vector.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Vector");
                    }
                    if (ImpostorsList.Contains("Morphling") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetMorphling;
                        var MorphlingRandom = rng.Next(0, impostors.Count);
                        Morphling.Role = impostors[MorphlingRandom];
                        impostors.RemoveAt(MorphlingRandom);
                        byte playerId = Morphling.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Morphling");
                    }
                    if (ImpostorsList.Contains("Scrambler") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetScrambler;
                        var ScramblerRandom = rng.Next(0, impostors.Count);
                        Scrambler.Role = impostors[ScramblerRandom];
                        impostors.RemoveAt(ScramblerRandom);
                        byte playerId = Scrambler.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Scrambler");
                    }
                    if (ImpostorsList.Contains("Barghest") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetBarghest;
                        var BarghestRandom = rng.Next(0, impostors.Count);
                        Barghest.Role = impostors[BarghestRandom];
                        impostors.RemoveAt(BarghestRandom);
                        byte playerId = Barghest.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Barghest");
                    }
                    if (ImpostorsList.Contains("Ghost") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetGhost;
                        var GhostRandom = rng.Next(0, impostors.Count);
                        Ghost.Role = impostors[GhostRandom];
                        impostors.RemoveAt(GhostRandom);
                        byte playerId = Ghost.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Ghost");
                    }
                    if (ImpostorsList.Contains("Sorcerer") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSorcerer;
                        var SorcererRandom = rng.Next(0, impostors.Count);
                        Sorcerer.Role = impostors[SorcererRandom];
                        impostors.RemoveAt(SorcererRandom);
                        byte playerId = Sorcerer.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Sorcerer");
                    }
                    if (ImpostorsList.Contains("Guesser") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetGuesser;
                        var GuesserRandom = rng.Next(0, impostors.Count);
                        Guesser.Role = impostors[GuesserRandom];
                        impostors.RemoveAt(GuesserRandom);
                        byte playerId = Guesser.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Guesser");
                    }
                    
                    if (ImpostorsList.Contains("Basilisk") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetBasilisk;
                        var BasiliskRandom = rng.Next(0, impostors.Count);
                        Basilisk.Role = impostors[BasiliskRandom];
                        impostors.RemoveAt(BasiliskRandom);
                        byte playerId = Basilisk.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Basilisk");
                    }
                    if (ImpostorsList.Contains("Reaper") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetReaper;
                        var ReaperRandom = rng.Next(0, impostors.Count);
                        Reaper.Role = impostors[ReaperRandom];
                        impostors.RemoveAt(ReaperRandom);
                        byte playerId = Reaper.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Reaper");
                    }
                    if (ImpostorsList.Contains("Saboteur") && impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSaboteur;
                        var SaboteurRandom = rng.Next(0, impostors.Count);
                        Saboteur.Role = impostors[SaboteurRandom];
                        impostors.RemoveAt(SaboteurRandom);
                        byte playerId = Saboteur.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Saboteur");
                    }
                    if (impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetImpostor1;
                        var Impostor1Random = rng.Next(0, impostors.Count);
                        Impostor1.Role = impostors[Impostor1Random];
                        impostors.RemoveAt(Impostor1Random);
                        byte playerId = Impostor1.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Impostor1");
                    }
                    if (impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetImpostor2;
                        var Impostor2Random = rng.Next(0, impostors.Count);
                        Impostor2.Role = impostors[Impostor2Random];
                        impostors.RemoveAt(Impostor2Random);
                        byte playerId = Impostor2.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Impostor2");
                    }
                    if (impostors.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetImpostor3;
                        var Impostor3Random = rng.Next(0, impostors.Count);
                        Impostor3.Role = impostors[Impostor3Random];
                        impostors.RemoveAt(Impostor3Random);
                        byte playerId = Impostor3.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        ImpostorsList.Remove("Impostor3");
                    }

                    //
                    // ---> Crewmates/Specials Roles 
                    //specials

                    if (SpecialsList.Contains("Cupid") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCupid;
                        var CupidRandom = rng.Next(0, crewmates.Count);
                        Cupid.Role = crewmates[CupidRandom];
                        crewmates.RemoveAt(CupidRandom);
                        byte playerId = Cupid.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Cupid");
                    }
                    if (SpecialsList.Contains("Cultist") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCultist;
                        var CultistRandom = rng.Next(0, crewmates.Count);
                        Cultist.Role = crewmates[CultistRandom];
                        crewmates.RemoveAt(CultistRandom);
                        byte playerId = Cultist.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Cultist");
                    }
                    if (SpecialsList.Contains("Outlaw") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetOutlaw;
                        var OutlawRandom = rng.Next(0, crewmates.Count);
                        Outlaw.Role = crewmates[OutlawRandom];
                        crewmates.RemoveAt(OutlawRandom);
                        byte playerId = Outlaw.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Outlaw");
                    }
                    if (SpecialsList.Contains("Jester") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetJester;
                        var JesterRandom = rng.Next(0, crewmates.Count);
                        Jester.Role = crewmates[JesterRandom];
                        crewmates.RemoveAt(JesterRandom);
                        byte playerId = Jester.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Jester");
                    }
                    if (SpecialsList.Contains("Eater") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetEater;
                        var EaterRandom = rng.Next(0, crewmates.Count);
                        Eater.Role = crewmates[EaterRandom];
                        crewmates.RemoveAt(EaterRandom);
                        byte playerId = Eater.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Eater");
                    }
                    if (SpecialsList.Contains("Arsonist") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetArsonist;
                        var ArsonistRandom = rng.Next(0, crewmates.Count);
                        Arsonist.Role = crewmates[ArsonistRandom];
                        crewmates.RemoveAt(ArsonistRandom);
                        byte playerId = Arsonist.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Arsonist");
                    }
                    if (SpecialsList.Contains("Cursed") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCursed;
                        var CursedRandom = rng.Next(0, crewmates.Count);
                        Cursed.Role = crewmates[CursedRandom];
                        crewmates.RemoveAt(CursedRandom);
                        byte playerId = Cursed.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        SpecialsList.Remove("Cursed");
                    }



                    //Hybrid

                    if (HybridList.Contains("Mercenary") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetMercenary;
                        var MercenaryRandom = rng.Next(0, crewmates.Count);
                        Mercenary.Role = crewmates[MercenaryRandom];
                        crewmates.RemoveAt(MercenaryRandom);
                        byte playerId = Mercenary.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        HybridList.Remove("Mercenary");
                    }
                    if (HybridList.Contains("CopyCat") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCopyCat;
                        var CopyCatRandom = rng.Next(0, crewmates.Count);
                        CopyCat.Role = crewmates[CopyCatRandom];
                        crewmates.RemoveAt(CopyCatRandom);
                        byte playerId = CopyCat.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        HybridList.Remove("CopyCat");
                    }
                    if (HybridList.Contains("Revenger") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetRevenger;
                        var RevengerRandom = rng.Next(0, crewmates.Count);
                        Revenger.Role = crewmates[RevengerRandom];
                        crewmates.RemoveAt(RevengerRandom);
                        byte playerId = Revenger.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        HybridList.Remove("Revenger");
                    }
                    if (HybridList.Contains("Survivor") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSurvivor;
                        var SurvivorRandom = rng.Next(0, crewmates.Count);
                        Survivor.Role = crewmates[SurvivorRandom];
                        crewmates.RemoveAt(SurvivorRandom);
                        byte playerId = Survivor.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        HybridList.Remove("Survivor");
                    }





                    // Crewmates
                    if (CrewmatesList.Contains("Teammate1") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetTeammate1;
                        var Teammate1Random = rng.Next(0, crewmates.Count);
                        Teammate1.Role = crewmates[Teammate1Random];
                        crewmates.RemoveAt(Teammate1Random);
                        byte playerId = Teammate1.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Teammate1");
                    }
                    if (CrewmatesList.Contains("Teammate2") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetTeammate2;
                        var Teammate2Random = rng.Next(0, crewmates.Count);
                        Teammate2.Role = crewmates[Teammate2Random];
                        crewmates.RemoveAt(Teammate2Random);
                        byte playerId = Teammate2.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Teammate2");
                    }

                    if (CrewmatesList.Contains("Sheriff1") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSheriff1;
                        var Sheriff1Random = rng.Next(0, crewmates.Count);
                        Sheriff1.Role = crewmates[Sheriff1Random];
                        crewmates.RemoveAt(Sheriff1Random);
                        byte playerId = Sheriff1.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Sheriff1");
                    }
                    if (CrewmatesList.Contains("Sheriff2") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSheriff2;
                        var Sheriff2Random = rng.Next(0, crewmates.Count);
                        Sheriff2.Role = crewmates[Sheriff2Random];
                        crewmates.RemoveAt(Sheriff2Random);
                        byte playerId = Sheriff2.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Sheriff2");
                    }
                    if (CrewmatesList.Contains("Sheriff3") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSheriff3;
                        var Sheriff3Random = rng.Next(0, crewmates.Count);
                        Sheriff3.Role = crewmates[Sheriff3Random];
                        crewmates.RemoveAt(Sheriff3Random);
                        byte playerId = Sheriff3.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Sheriff3");
                    }
                    if (CrewmatesList.Contains("Guardian") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetGuardian;
                        var GuardianRandom = rng.Next(0, crewmates.Count);
                        Guardian.Role = crewmates[GuardianRandom];
                        crewmates.RemoveAt(GuardianRandom);
                        byte playerId = Guardian.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Guardian");
                    }
                    if (CrewmatesList.Contains("Engineer") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetEngineer;
                        var EngineerRandom = rng.Next(0, crewmates.Count);
                        Engineer.Role = crewmates[EngineerRandom];
                        crewmates.RemoveAt(EngineerRandom);
                        byte playerId = Engineer.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Engineer");
                    }
                    if (CrewmatesList.Contains("Timelord") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetTimelord;
                        var TimelordRandom = rng.Next(0, crewmates.Count);
                        Timelord.Role = crewmates[TimelordRandom];
                        crewmates.RemoveAt(TimelordRandom);
                        byte playerId = Timelord.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Timelord");
                    }
                    if (CrewmatesList.Contains("Hunter") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetHunter;
                        var HunterRandom = rng.Next(0, crewmates.Count);
                        Hunter.Role = crewmates[HunterRandom];
                        crewmates.RemoveAt(HunterRandom);
                        byte playerId = Hunter.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Hunter");
                    }
                    if (CrewmatesList.Contains("Mystic") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetMystic;
                        var MysticRandom = rng.Next(0, crewmates.Count);
                        Mystic.Role = crewmates[MysticRandom];
                        crewmates.RemoveAt(MysticRandom);
                        byte playerId = Mystic.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Mystic");
                    }
                    if (CrewmatesList.Contains("Spirit") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSpirit;
                        var SpiritRandom = rng.Next(0, crewmates.Count);
                        Spirit.Role = crewmates[SpiritRandom];
                        crewmates.RemoveAt(SpiritRandom);
                        byte playerId = Spirit.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Spirit");
                    }
                    if (CrewmatesList.Contains("Mayor") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetMayor;
                        var MayorRandom = rng.Next(0, crewmates.Count);
                        Mayor.Role = crewmates[MayorRandom];
                        crewmates.RemoveAt(MayorRandom);
                        byte playerId = Mayor.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Mayor");
                    }
                    if (CrewmatesList.Contains("Detective") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetDetective;
                        var DetectiveRandom = rng.Next(0, crewmates.Count);
                        Detective.Role = crewmates[DetectiveRandom];
                        crewmates.RemoveAt(DetectiveRandom);
                        byte playerId = Detective.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Detective");
                    }
                    if (CrewmatesList.Contains("Nightwatch") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetNightwatch;
                        var NightwatchRandom = rng.Next(0, crewmates.Count);
                        Nightwatch.Role = crewmates[NightwatchRandom];
                        crewmates.RemoveAt(NightwatchRandom);
                        byte playerId = Nightwatch.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Nightwatch");
                    }
                    if (CrewmatesList.Contains("Spy") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSpy;
                        var SpyRandom = rng.Next(0, crewmates.Count);
                        Spy.Role = crewmates[SpyRandom];
                        crewmates.RemoveAt(SpyRandom);
                        byte playerId = Spy.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Spy");
                    }
                    if (CrewmatesList.Contains("Informant") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetInformant;
                        var InformantRandom = rng.Next(0, crewmates.Count);
                        Informant.Role = crewmates[InformantRandom];
                        crewmates.RemoveAt(InformantRandom);
                        byte playerId = Informant.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Informant");
                    }
                    if (CrewmatesList.Contains("Bait") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetBait;
                        var BaitRandom = rng.Next(0, crewmates.Count);
                        Bait.Role = crewmates[BaitRandom];
                        crewmates.RemoveAt(BaitRandom);
                        byte playerId = Bait.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Bait");
                    }
                    if (CrewmatesList.Contains("Mentalist") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetMentalist;
                        var MentalistRandom = rng.Next(0, crewmates.Count);
                        Mentalist.Role = crewmates[MentalistRandom];
                        crewmates.RemoveAt(MentalistRandom);
                        byte playerId = Mentalist.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Mentalist");
                    }
                    if (CrewmatesList.Contains("Builder") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetBuilder;
                        var BuilderRandom = rng.Next(0, crewmates.Count);
                        Builder.Role = crewmates[BuilderRandom];
                        crewmates.RemoveAt(BuilderRandom);
                        byte playerId = Builder.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Builder");
                    }
                    if (CrewmatesList.Contains("Dictator") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetDictator;
                        var DictatorRandom = rng.Next(0, crewmates.Count);
                        Dictator.Role = crewmates[DictatorRandom];
                        crewmates.RemoveAt(DictatorRandom);
                        byte playerId = Dictator.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Dictator");
                    }
                    if (CrewmatesList.Contains("Sentinel") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSentinel;
                        var SentinelRandom = rng.Next(0, crewmates.Count);
                        Sentinel.Role = crewmates[SentinelRandom];
                        crewmates.RemoveAt(SentinelRandom);
                        byte playerId = Sentinel.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Sentinel");
                    }
                    if (CrewmatesList.Contains("Lawkeeper") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetLawkeeper;
                        var LawkeeperRandom = rng.Next(0, crewmates.Count);
                        Lawkeeper.Role = crewmates[LawkeeperRandom];
                        crewmates.RemoveAt(LawkeeperRandom);
                        byte playerId = Lawkeeper.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Lawkeeper");
                    }
                    if (CrewmatesList.Contains("Fake") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetFake;
                        var FakeRandom = rng.Next(0, crewmates.Count);
                        Fake.Role = crewmates[FakeRandom];
                        crewmates.RemoveAt(FakeRandom);
                        byte playerId = Fake.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Fake");
                    }
                    if (CrewmatesList.Contains("Traveler") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetTraveler;
                        var TravelerRandom = rng.Next(0, crewmates.Count);
                        Traveler.Role = crewmates[TravelerRandom];
                        crewmates.RemoveAt(TravelerRandom);
                        byte playerId = Traveler.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Traveler");
                    }
                    if (CrewmatesList.Contains("Leader") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetLeader;
                        var LeaderRandom = rng.Next(0, crewmates.Count);
                        Leader.Role = crewmates[LeaderRandom];
                        crewmates.RemoveAt(LeaderRandom);
                        byte playerId = Leader.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Leader");
                    }
                    if (CrewmatesList.Contains("Doctor") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetDoctor;
                        var DoctorRandom = rng.Next(0, crewmates.Count);
                        Doctor.Role = crewmates[DoctorRandom];
                        crewmates.RemoveAt(DoctorRandom);
                        byte playerId = Doctor.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Doctor");
                    }
                    if (CrewmatesList.Contains("Slave") && crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetSlave;
                        var SlaveRandom = rng.Next(0, crewmates.Count);
                        Slave.Role = crewmates[SlaveRandom];
                        crewmates.RemoveAt(SlaveRandom);
                        byte playerId = Slave.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                        CrewmatesList.Remove("Slave");
                    }

                    //Additional Crew
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate1;
                        var Crewmate1Random = rng.Next(0, crewmates.Count);
                        Crewmate1.Role = crewmates[Crewmate1Random];
                        crewmates.RemoveAt(Crewmate1Random);
                        byte playerId = Crewmate1.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate2;
                        var Crewmate2Random = rng.Next(0, crewmates.Count);
                        Crewmate2.Role = crewmates[Crewmate2Random];
                        crewmates.RemoveAt(Crewmate2Random);
                        byte playerId = Crewmate2.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate3;
                        var Crewmate3Random = rng.Next(0, crewmates.Count);
                        Crewmate3.Role = crewmates[Crewmate3Random];
                        crewmates.RemoveAt(Crewmate3Random);
                        byte playerId = Crewmate3.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate4;
                        var Crewmate4Random = rng.Next(0, crewmates.Count);
                        Crewmate4.Role = crewmates[Crewmate4Random];
                        crewmates.RemoveAt(Crewmate4Random);
                        byte playerId = Crewmate4.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate5;
                        var Crewmate5Random = rng.Next(0, crewmates.Count);
                        Crewmate5.Role = crewmates[Crewmate5Random];
                        crewmates.RemoveAt(Crewmate5Random);
                        byte playerId = Crewmate5.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate6;
                        var Crewmate6Random = rng.Next(0, crewmates.Count);
                        Crewmate6.Role = crewmates[Crewmate6Random];
                        crewmates.RemoveAt(Crewmate6Random);
                        byte playerId = Crewmate6.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate7;
                        var Crewmate7Random = rng.Next(0, crewmates.Count);
                        Crewmate7.Role = crewmates[Crewmate7Random];
                        crewmates.RemoveAt(Crewmate7Random);
                        byte playerId = Crewmate7.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate8;
                        var Crewmate8Random = rng.Next(0, crewmates.Count);
                        Crewmate8.Role = crewmates[Crewmate8Random];
                        crewmates.RemoveAt(Crewmate8Random);
                        byte playerId = Crewmate8.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate9;
                        var Crewmate9Random = rng.Next(0, crewmates.Count);
                        Crewmate9.Role = crewmates[Crewmate9Random];
                        crewmates.RemoveAt(Crewmate9Random);
                        byte playerId = Crewmate9.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate10;
                        var Crewmate10Random = rng.Next(0, crewmates.Count);
                        Crewmate10.Role = crewmates[Crewmate10Random];
                        crewmates.RemoveAt(Crewmate10Random);
                        byte playerId = Crewmate10.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate11;
                        var Crewmate11Random = rng.Next(0, crewmates.Count);
                        Crewmate11.Role = crewmates[Crewmate11Random];
                        crewmates.RemoveAt(Crewmate11Random);
                        byte playerId = Crewmate11.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate12;
                        var Crewmate12Random = rng.Next(0, crewmates.Count);
                        Crewmate12.Role = crewmates[Crewmate12Random];
                        crewmates.RemoveAt(Crewmate12Random);
                        byte playerId = Crewmate12.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate13;
                        var Crewmate13Random = rng.Next(0, crewmates.Count);
                        Crewmate13.Role = crewmates[Crewmate13Random];
                        crewmates.RemoveAt(Crewmate13Random);
                        byte playerId = Crewmate13.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }
                    if (crewmates.Count > 0)
                    {
                        var roleID = (byte)SetRoleID.SetCrewmate14;
                        var Crewmate14Random = rng.Next(0, crewmates.Count);
                        Crewmate14.Role = crewmates[Crewmate14Random];
                        crewmates.RemoveAt(Crewmate14Random);
                        byte playerId = Crewmate14.Role.PlayerId;
                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetRole, Hazel.SendOption.Reliable, -1);
                        writer.Write(roleID);
                        writer.Write(playerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.setRole(roleID, playerId);
                    }

                    Challenger.RoleAssigned = true;
                    MessageWriter RolesAssigned = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ShareAllRoles, Hazel.SendOption.Reliable, -1);
                    AmongUsClient.Instance.FinishRpcImmediately(RolesAssigned);
                    RPCProcedure.shareAllRoles();
                }



                if (PlayerControl.LocalPlayer.Data.IsDead)
                {
                    if (!Challenger.IsMeeting)
                    {
                        DestroyableSingleton<HudManager>.Instance.ShadowQuad.gameObject.SetActive(false);

                        if (CameraZoom < 3f) { CameraZoom = 3f; }
                        if (CameraZoom > 15f) { CameraZoom = 15f; }



                        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
                        {
                            if (CameraZoom <= 3)
                            {
                                Camera.main.orthographicSize = 3f;
                            }
                            else
                            {
                                CameraZoom -= 0.5f;
                                Camera.main.orthographicSize = CameraZoom;
                            }
                        }
                        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
                        {
                            if (CameraZoom >= 15f)
                            {
                                Camera.main.orthographicSize = 15f;
                            }
                            else
                            {
                                CameraZoom += 0.5f;
                                Camera.main.orthographicSize = CameraZoom;
                            }
                        }
                    }
                    else
                    {
                        CameraZoom = 3f;
                        Camera.main.orthographicSize = 3f;
                    }
                }

                //UPDATE
                SG_Ready = "";
                UpdateName();
                updateImpostorKillButton(__instance);
                updateSabotageButton(__instance);
                updateAbilityButton(__instance);
                updateUseButton(__instance);
                // updateVentButton(__instance);
                ChallengerMod.CustomButton.HudManagerStartPatch.UpdateCustomButtonCooldowns();
                ChallengerMod.CustomButton.CustomButton.HudUpdate();

              
               
                timerV = (int)Math.Round(ChallengerMod.Challenger.SetVitalTime);
                timerC = (int)Math.Round(ChallengerMod.Challenger.SetCamTime);
                timerA = (int)Math.Round(ChallengerMod.Challenger.SetAdminTime);
                timerN = (int)Math.Round(ChallengerMod.Challenger.NuclearTimer);
                timerLN = (int)Math.Round(ChallengerMod.Challenger.NuclearLastTimer);

                War8Item.WorldSpawn();
                War9Item.WorldSpawn();
                War10Item.WorldSpawn();
                War11Item.WorldSpawn();

                if (Sheriff1.Role != null && PlayerControl.LocalPlayer == Sheriff1.Role && SherifKillSettings.getSelection() == 2)
                {
                    War12Item.WorldSpawn();
                }
                if (Sheriff2.Role != null && PlayerControl.LocalPlayer == Sheriff2.Role && SherifKillSettings.getSelection() == 2)
                {
                    War13Item.WorldSpawn();
                }
                if (Sheriff3.Role != null && PlayerControl.LocalPlayer == Sheriff3.Role && SherifKillSettings.getSelection() == 2)
                {
                    War14Item.WorldSpawn();
                }

                if (Sorcerer.Role != null && PlayerControl.LocalPlayer == Sorcerer.Role)
                {
                    if (!Sorcerer.Start && Sorcerer.TotalRuneLoot == 0f)
                    {
                      War1Item.WorldSpawn();
                      Sorcerer.Start = true;
                    }
                    if (!Sorcerer.Start && Sorcerer.TotalRuneLoot == 1f)
                    {
                        War2Item.WorldSpawn();
                        Sorcerer.Start = true;
                    }
                    if (!Sorcerer.Start && Sorcerer.TotalRuneLoot == 2f)
                    {
                        War3Item.WorldSpawn();
                        Sorcerer.Start = true;
                    }
                    if (!Sorcerer.Start && Sorcerer.TotalRuneLoot == 3f)
                    {
                        War4Item.WorldSpawn();
                        Sorcerer.Start = true;
                    }

                }
                if (Arsonist.Role != null && PlayerControl.LocalPlayer == Arsonist.Role)
                {
                    War5Item.WorldSpawn();
                    War6Item.WorldSpawn();
                    War7Item.WorldSpawn();
                }
                if (GameObject.Find("RefuelArea"))
                {
                    var Refuel = GameObject.Find("RefuelArea");
                    if (PlayerControl.LocalPlayer == Arsonist.Role)
                    {
                        Refuel.SetActive(true);
                        Refuel.GetComponent<SpriteRenderer>().sprite = RefuelStation;
                    }
                    else
                    {
                        Refuel.SetActive(false);
                        Refuel.GetComponent<SpriteRenderer>().sprite = empty;
                    }

                }
                /* if (GameObject.Find("SafeArea1"))
                 {
                     var SA1 = GameObject.Find("SafeArea1");
                     SA1.transform.localScale = new Vector3(1.7328f, 2.64f, 2);
                 }
                 if (GameObject.Find("SafeArea2"))
                 {
                     var SA2 = GameObject.Find("SafeArea2");
                     SA2.transform.localScale = new Vector3(8.1138f, 3.1102f, 2);
                 }
                 if (GameObject.Find("SafeArea3"))
                 {
                     var SA3 = GameObject.Find("SafeArea3");
                     SA3.transform.localScale = new Vector3(2.6723f, 1.44f, 2);
                 }
                 if (GameObject.Find("SafeArea4"))
                 {
                     var SA4 = GameObject.Find("SafeArea4");
                     SA4.transform.localScale = new Vector3(4.72f, 5.6164f, 2);
                 }*/
                

               

                if (GameObject.Find("Cristal 1"))
                {
                    var C1SaveLocation = GameObject.Find("Cristal 1");
                    ChallengerMod.Challenger.CirclePositionC1 = C1SaveLocation.transform.localPosition;
                    if (Sorcerer.TotalRuneLoot > 0f)
                    {
                        C1SaveLocation.transform.localScale = new Vector3(0f, 0f, 0f);
                    }

                }
                if (GameObject.Find("Cristal 2"))
                {
                    var C2SaveLocation = GameObject.Find("Cristal 2");
                    ChallengerMod.Challenger.CirclePositionC2 = C2SaveLocation.transform.localPosition;
                    if (Sorcerer.TotalRuneLoot > 1f)
                    {
                        C2SaveLocation.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                }
                if (GameObject.Find("Cristal 3"))
                {
                    var C3SaveLocation = GameObject.Find("Cristal 3");
                    ChallengerMod.Challenger.CirclePositionC3 = C3SaveLocation.transform.localPosition;
                    if (Sorcerer.TotalRuneLoot > 2f)
                    {
                        C3SaveLocation.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                }
                if (GameObject.Find("Cristal 4"))
                {
                    var C4SaveLocation = GameObject.Find("Cristal 4");
                    ChallengerMod.Challenger.CirclePositionC4 = C4SaveLocation.transform.localPosition;
                    if (Sorcerer.TotalRuneLoot > 3f)
                    {
                        C4SaveLocation.transform.localScale = new Vector3(0f, 0f, 0f);
                    }

                }


                if (GameObject.Find("Circle"))
                {

                    var CircleLoadLocation = GameObject.Find("Circle");
                    if (Sorcerer.CircleEnabled == true)
                    {
                        CircleLoadLocation.transform.localPosition = ChallengerMod.Challenger.CirclePosition;
                    }
                    else
                    {
                        CircleLoadLocation.transform.localPosition = ChallengerMod.Challenger.CirclePositionC0;
                    }
                }
                
                //DISABLED PRESSET BUTTON
                if (AmongUsClient.Instance.AmHost)
                {
                    if (GameObject.Find("Main Camera/Hud/PressetButton_1"))
                    {
                        var button = GameObject.Find("Main Camera/Hud/PressetButton_1");
                        button.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else { }
                    if (GameObject.Find("Main Camera/Hud/PressetButton_2"))
                    {
                        var button = GameObject.Find("Main Camera/Hud/PressetButton_2");
                        button.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else { }
                    if (GameObject.Find("Main Camera/Hud/PressetButton_3"))
                    {
                        var button = GameObject.Find("Main Camera/Hud/PressetButton_3");
                        button.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else { }
                    if (GameObject.Find("Main Camera/Hud/RankedButton"))
                    {
                        var button = GameObject.Find("Main Camera/Hud/RankedButton");
                        button.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else { }
                }






                //SET SURVEY TRYHARD
                //SET PLAYERDIE
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 3) { Challenger.TryHardPlayerDieCam = 1; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 3) { Challenger.TryHardPlayerDieAdmin = 1; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 3) { Challenger.TryHardPlayerDieVital = 1; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 4) { Challenger.TryHardPlayerDieCam = 2; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 4) { Challenger.TryHardPlayerDieAdmin = 2; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 4) { Challenger.TryHardPlayerDieVital = 2; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 5) { Challenger.TryHardPlayerDieCam = 3; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 5) { Challenger.TryHardPlayerDieAdmin = 3; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 5) { Challenger.TryHardPlayerDieVital = 3; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 6) { Challenger.TryHardPlayerDieCam = 4; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 6) { Challenger.TryHardPlayerDieAdmin = 4; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 6) { Challenger.TryHardPlayerDieVital = 4; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 7) { Challenger.TryHardPlayerDieCam = 5; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 7) { Challenger.TryHardPlayerDieAdmin = 5; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 7) { Challenger.TryHardPlayerDieVital = 5; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 8) { Challenger.TryHardPlayerDieCam = 6; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 8) { Challenger.TryHardPlayerDieAdmin = 6; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 8) { Challenger.TryHardPlayerDieVital = 6; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 9) { Challenger.TryHardPlayerDieCam = 7; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 9) { Challenger.TryHardPlayerDieAdmin = 7; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 9) { Challenger.TryHardPlayerDieVital = 7; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 10) { Challenger.TryHardPlayerDieCam = 8; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 10) { Challenger.TryHardPlayerDieAdmin = 8; }
                if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 10) { Challenger.TryHardPlayerDieVital = 8; }



                //TRYHARD 3.0
                //ADMIN
                if (Sorcerer.Role != null && Sorcerer.AdminSab == true || (AdminTimeOn.getSelection() != 0 && ChallengerMod.Challenger.SetAdminTime <= 0f))
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true;
                }
                else
                {
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 0) // Enable
                    {
                        if (Challenger.LobbyAdminOff) { ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 1) // disable
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 2 && PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() == 2 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        if (Challenger.LobbyAdminOff) { ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledAdmin.getSelection() >= 3)
                    {
                        if (ChallengerMod.Set.Data.TotalPlayerDie >= Challenger.TryHardPlayerDieAdmin) { } // Enable 1 player die
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.adminBool = true; }
                    }
                }



                //VITAL
                if (Sorcerer.Role != null && Sorcerer.VitalSab == true || (VitalTimeOn.getSelection() != 0 && ChallengerMod.Challenger.SetVitalTime <= 0f))
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
                }
                else
                {
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 0) // Enable
                    {
                        if (Challenger.LobbyVitalOff) { ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 1) // disable
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 2 && PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() == 2 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        if (Challenger.LobbyVitalOff) { ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledVitales.getSelection() >= 3)
                    {
                        if (ChallengerMod.Set.Data.TotalPlayerDie >= Challenger.TryHardPlayerDieVital) { } // Enable 1 player die
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.vitalsBool = true; }
                    }
                }



                //CAMERA
                if (Sorcerer.Role != null && Sorcerer.CamSab == true || (CamTimeOn.getSelection() != 0 && ChallengerMod.Challenger.SetCamTime <= 0f))
                {
                    ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                }
                else
                {
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 0) // Enable
                    {
                        if (Challenger.LobbyCamOff) { ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 1) // disable
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 2 && PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true;
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() == 2 && !PlayerControl.LocalPlayer.Data.Role.IsImpostor) // Enable crew only
                    {
                        if (Challenger.LobbyCamOff) { ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true; }
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = false; }
                    }
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.DisabledCamera.getSelection() >= 3)
                    {
                        if (ChallengerMod.Set.Data.TotalPlayerDie >= Challenger.TryHardPlayerDieCam) { } // Enable 1 player die
                        else { ChallengerMod.Fix.BlockUtilitiesPatches.camsBool = true; }
                    }
                }

                if (PlayerControl.LocalPlayer.Data.PlayerName != null)
                {
                    STR_MyName = "" + PlayerControl.LocalPlayer.Data.PlayerName;
                }

                

                if (Cultist.Culte1 != null)
                {
                    if (Cultist.Culte1.Data.IsDead || Cultist.Culte1.Data.Disconnected) { Culte1_Alive = 0; }
                    else { Culte1_Alive = 1; }
                    Culte1_Count = true;
                    if (PlayerControl.LocalPlayer == Cultist.Culte1)
                    {
                        NewTeam = true;
                        STR_MyTeam = "" + T_Cultes;
                        STR_MyCulte = B_Culte_Alive;
                    }
                }
                if (Cultist.Culte2 != null)
                {
                    if (Cultist.Culte2.Data.IsDead || Cultist.Culte2.Data.Disconnected) { Culte2_Alive = 0; }
                    else { Culte2_Alive = 1; }
                    Culte2_Count = true;
                    if (PlayerControl.LocalPlayer == Cultist.Culte2)
                    {
                        NewTeam = true;
                        STR_MyTeam = "" + T_Cultes;
                        STR_MyCulte = B_Culte_Alive;
                    }
                }
                if (Cultist.Culte3 != null)
                {
                    if (Cultist.Culte3.Data.IsDead || Cultist.Culte3.Data.Disconnected) { Culte3_Alive = 0; }
                    else { Culte3_Alive = 1; }
                    Culte3_Count = true;
                    if (PlayerControl.LocalPlayer == Cultist.Culte3)
                    {
                        NewTeam = true;
                        STR_MyTeam = "" + T_Cultes;
                        STR_MyCulte = B_Culte_Alive;
                    }
                }
                if (Guardian.Protected != null)
                {
                    if (PlayerControl.LocalPlayer == Guardian.Protected && Guardian.shieldattempt && GuardianShieldVisibilitytry.getSelection() != 2 )
                    {
                        STR_MyShield = B_Shield;
                    }
                }
                
                if (Cupid.Lover1 != null && Cupid.Lover2 != null)
                {
                    Love1_Count = true;
                    love2_Count = true;
                    
                    if (Cupid.Lover1.Data.IsDead || Cupid.Lover1.Data.Disconnected) { Lover1_Alive = 0; }
                    else { Lover1_Alive = 1; }
                    if (Cupid.Lover2.Data.IsDead || Cupid.Lover2.Data.Disconnected) { Lover2_Alive = 0; }
                    else { Lover2_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Cupid.Lover1)
                    {
                        STR_Mylove = B_Lover_Alive;
                    }
                    if (PlayerControl.LocalPlayer == Cupid.Lover2)
                    {
                        STR_Mylove = B_Lover_Alive;
                    }
                }

                //CREWMATES
                //Sheriff1

             

                if (Sheriff1.Role != null)
                {
                    if (Sheriff1.Role.Data.IsDead || Sheriff1.Role.Data.Disconnected) { Sheriff1_Alive = 0; }
                    else { Sheriff1_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Sheriff1.Role)
                    {
                        STRRole = "Sheriff";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Sheriff;
                        STR_MyRoleColor = "" + R_SheriffColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Sheriff1Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (SherifKillSettings.getSelection() == 0)
                        {
                            Sheriff1.CanKill = true;
                        }
                    }
                    Sheriff1Count = true;
                }
                else { Sheriff1_Alive = 0; }
                //Sheriff2
                if (Sheriff2.Role != null)
                {
                    if (Sheriff2.Role.Data.IsDead || Sheriff2.Role.Data.Disconnected) { Sheriff2_Alive = 0; }
                    else { Sheriff2_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Sheriff2.Role)
                    {
                        STRRole = "Sheriff";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Sheriff;
                        STR_MyRoleColor = "" + R_SheriffColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Sheriff2Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (SherifKillSettings.getSelection() == 0)
                        {
                            Sheriff2.CanKill = true;
                        }
                    }
                    Sheriff2Count = true;
                }
                else { Sheriff2_Alive = 0; }
                //Sheriff3
                if (Sheriff3.Role != null)
                {
                    if (Sheriff3.Role.Data.IsDead || Sheriff3.Role.Data.Disconnected) { Sheriff3_Alive = 0; }
                    else { Sheriff3_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Sheriff3.Role)
                    {
                        STRRole = "Sheriff";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Sheriff;
                        STR_MyRoleColor = "" + R_SheriffColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Sheriff3Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (SherifKillSettings.getSelection() == 0)
                        {
                            Sheriff3.CanKill = true;
                        }
                    }
                    Sheriff3Count = true;
                }
                else { Sheriff3_Alive = 0; }
                //Guardian
                if (Guardian.Role != null)
                {
                    if (Guardian.Role.Data.IsDead || Guardian.Role.Data.Disconnected) { Guardian_Alive = 0; }
                    else { Guardian_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Guardian.Role)
                    {
                        STRRole = "Guardian";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Guardian;
                        STR_MyRoleColor = "" + R_GuardianColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.GuardianTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                      
                    }
                    GuardianCount = true;
                }
                else { Guardian_Alive = 0; }
                //Engineer
                if (Engineer.Role != null)
                {
                    if (Engineer.Role.Data.IsDead || Engineer.Role.Data.Disconnected) { Engineer_Alive = 0; }
                    else { Engineer_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Engineer.Role)
                    {
                        STRRole = "Engineer";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Engineer;
                        STR_MyRoleColor = "" + R_EngineerColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.EngineerTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        
                       
                    }
                    EngineerCount = true;
                }
                else { Engineer_Alive = 0; }
                //Timelord
                if (Timelord.Role != null)
                {
                    if (Timelord.Role.Data.IsDead || Timelord.Role.Data.Disconnected) { Timelord_Alive = 0; }
                    else { Timelord_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Timelord.Role)
                    {
                        STRRole = "Timelord";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Timelord;
                        STR_MyRoleColor = "" + R_TimelordColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.TimelordTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    TimelordCount = true;
                }
                else { Timelord_Alive = 0; }
                //Hunter
                if (Hunter.Role != null)
                {
                    if (Hunter.Role.Data.IsDead || Hunter.Role.Data.Disconnected) { Hunter_Alive = 0; }
                    else { Hunter_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Hunter.Role)
                    {
                        STRRole = "Hunter";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Hunter;
                        STR_MyRoleColor = "" + R_HunterColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.HunterTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        
                    }
                    HunterCount = true;
                }
                else { Hunter_Alive = 0; }
                //Mystic
                if (Mystic.Role != null)
                {
                    if (Mystic.Role.Data.IsDead || Mystic.Role.Data.Disconnected) { Mystic_Alive = 0; }
                    else 
                    { 
                        Mystic_Alive = 1;
                        if (Challenger.FirstTurn == true)
                        {
                            Mystic.selfShield = true;
                        }
                    }
                    

                    if (PlayerControl.LocalPlayer == Mystic.Role)
                    {
                        STRRole = "Mystic";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Mystic;
                        STR_MyRoleColor = "" + R_MysticColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.MysticTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                       
                        if (Mystic.DoubleShield) 
                        { 
                            STR_MyShield = B_DoubleShield;
                            Mystic.ShieldButton = false;
                        }
                        else
                        {
                            if (Mystic.selfShield) 
                            { 
                                STR_MyShield = B_SelfShield;
                            }
                            else 
                            { 
                                STR_MyShield = B_NoSelfShield;
                            }
                        }
                    }
                    MysticCount = true;
                }
                else { Mystic_Alive = 0; }
                //Spirit
                if (Spirit.Role != null)
                {
                    if (Spirit.Role.Data.IsDead || Spirit.Role.Data.Disconnected)
                    {
                        Spirit_Alive = 0;
                        if (SpiritSab.getBool() == true) { Spirit.CanCloseDoor = true; }
                        else { Spirit.CanCloseDoor = false; }

                    }
                    else
                    {
                        Spirit_Alive = 1;
                        Spirit.CanCloseDoor = false;
                    }

                    if (PlayerControl.LocalPlayer == Spirit.Role)
                    {
                        STRRole = "Spirit";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Spirit;
                        STR_MyRoleColor = "" + R_SpiritColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.SpiritTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }

                    SpiritCount = true;
                }
                else { Spirit_Alive = 0; }
                //Mayor
                if (Mayor.Role != null)
                {
                    if (Mayor.Role.Data.IsDead || Mayor.Role.Data.Disconnected) { Mayor_Alive = 0; }
                    else { Mayor_Alive = 1; }

                    


                    if (PlayerControl.LocalPlayer == Mayor.Role)
                    {
                        STRRole = "Mayor";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Mayor;
                        STR_MyRoleColor = "" + R_MayorColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.MayorTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        if (BonusBuzz.getSelection() == 0) { Mayor.Buzz = false; }
                        else if (BonusBuzz.getSelection() == 1) { Mayor.Buzz = true; }
                        else if (Mayor.TaskEND == true && BonusBuzz.getSelection() == 2) { Mayor.Buzz = true; }
                        else if (Mayor.TaskEND == false && BonusBuzz.getSelection() == 2) { Mayor.Buzz = false; }

                    }
                    MayorCount = true;
                }
                else { Mayor_Alive = 0; }
                //Detective
                if (Detective.Role != null)
                {
                    if (Detective.Role.Data.IsDead || Detective.Role.Data.Disconnected) { Detective_Alive = 0; }
                    else { Detective_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Detective.Role)
                    {
                        STRRole = "Detective";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Detective;
                        STR_MyRoleColor = "" + R_DetectiveColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.DetectiveTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        Detective.footprintDuration = detectiveFootprintDuration.getFloat();
                        if (detectiveFootprintanonymous.getBool() == true) { Detective.anonymousFootprints = true; }
                        else { Detective.anonymousFootprints = false; }

                    }
                    DetectiveCount = true;
                }
                else { Detective_Alive = 0; }
                //Nightwatch
                if (Nightwatch.Role != null)
                {
                    if (Nightwatch.Role.Data.IsDead || Nightwatch.Role.Data.Disconnected) { Nightwatch_Alive = 0; }
                    else { Nightwatch_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Nightwatch.Role)
                    {
                        STRRole = "Nightwatch";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Nightwatch;
                        STR_MyRoleColor = "" + R_NightwatchColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.NightwatchTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    NightwatchCount = true;
                }
                else { Nightwatch_Alive = 0; }
                //Spy
                if (Spy.Role != null)
                {
                    if (Spy.Role.Data.IsDead || Spy.Role.Data.Disconnected) { Spy_Alive = 0; }
                    else { Spy_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Spy.Role)
                    {
                        STRRole = "Spy";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Spy;
                        STR_MyRoleColor = "" + R_SpyColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.SpyTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        


                    }

                    if (SpyRange.getSelection() == 0) { Spy.Range = 3f; }
                    if (SpyRange.getSelection() == 1) { Spy.Range = 3.75f; }
                    if (SpyRange.getSelection() == 2) { Spy.Range = 4.5f; }

                    SpyCount = true;
                }
                else { Spy_Alive = 0; }
                //Informant
                if (Informant.Role != null)
                {
                    if (Informant.Role.Data.IsDead || Informant.Role.Data.Disconnected) { Informant_Alive = 0; }
                    else { Informant_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Informant.Role)
                    {
                        STRRole = "Informant";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Informant;
                        STR_MyRoleColor = "" + R_InformantColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.InformantTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    InformantCount = true;
                }
                else { Informant_Alive = 0; }
                //Bait
                if (Bait.Role != null)
                {
                    if (Bait.Role.Data.IsDead || Bait.Role.Data.Disconnected) { Bait_Alive = 0; }
                    else { Bait_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Bait.Role)
                    {
                        STRRole = "Bait";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Bait;
                        STR_MyRoleColor = "" + R_BaitColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.BaitTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                    }
                    BaitCount = true;


                    if (!Bait.bait.Contains(Bait.Role))
                    { Bait.bait.Add(Bait.Role); }
                    if (CopyCat.Role != null && CopyCat.copyRole == 13 && CopyCat.CopyStart && Bait.Role.Data.IsDead && !Bait.bait.Contains(CopyCat.Role)) 
                    { Bait.bait.Add(CopyCat.Role); }


                }
                else { Bait_Alive = 0; }
                //Mentalist
                if (Mentalist.Role != null)
                {
                    if (Mentalist.Role.Data.IsDead || Mentalist.Role.Data.Disconnected) { Mentalist_Alive = 0; }
                    else { Mentalist_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Mentalist.Role)
                    {
                        STRRole = "Mentalist";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Mentalist;
                        STR_MyRoleColor = "" + R_MentalistColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.MentalistTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    MentalistCount = true;
                }
                else { Mentalist_Alive = 0; }
                //Builder
                if (Builder.Role != null)
                {
                    if (Builder.Role.Data.IsDead || Builder.Role.Data.Disconnected) { Builder_Alive = 0; }
                    else { Builder_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Builder.Role)
                    {
                        STRRole = "Builder";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Builder;
                        STR_MyRoleColor = "" + R_BuilderColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.BuilderTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (MaxBuild.getSelection() == 0)
                        {
                            Builder.Use1 = true;
                            Builder.Use2 = true; //stay 1
                        }
                        if (MaxBuild.getSelection() == 1)
                        {
                            Builder.Use1 = true; // stay 2
                        }
                        if (BuildRound.getBool() == false)
                        {
                            Builder.round = false; // force false
                        }

                    }
                    BuilderCount = true;
                }
                else { Builder_Alive = 0; }
                //Dictator
                if (Dictator.Role != null)
                {
                    


                    if (Dictator.Role.Data.IsDead || Dictator.Role.Data.Disconnected) { Dictator_Alive = 0; Dictator.HMActive = false; }
                    else
                    { 
                        Dictator_Alive = 1;
                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == true && FirstTurn == true) { Dictator.HMActive = false; }
                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == false) { Dictator.HMActive = true; }
                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == true && FirstTurn == false) { Dictator.HMActive = true; }
                    }

                    if (PlayerControl.LocalPlayer == Dictator.Role)
                    {
                        STRRole = "Dictator";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Dictator;
                        STR_MyRoleColor = "" + R_DictatorColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.DictatorTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";


                        if (DictatorMeeting.getSelection() != 0) 
                        { 
                            if (DictatorFirstTurn.getBool() == true && FirstTurn == true) { Dictator.NoSkipButton = false; }
                            else { Dictator.NoSkipButton = true; }

                        }
                        else 
                        {
                            Dictator.NoSkipButton = false;
                        }
                    }
                    DictatorCount = true;
                }
                else { Dictator_Alive = 0; }
                //Sentinel
                if (Sentinel.Role != null)
                {
                    if (Sentinel.Role.Data.IsDead || Sentinel.Role.Data.Disconnected) { Sentinel_Alive = 0; }
                    else { Sentinel_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Sentinel.Role)
                    {
                        STRRole = "Sentinel";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Sentinel;
                        STR_MyRoleColor = "" + R_SentinelColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.SentinelTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        

                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance * 25f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                DeadBody body = (DeadBody)((Component)collider2D).GetComponent<DeadBody>();
                                if (!bodys.Contains(body.ParentId) && !EatedID.Contains(body.ParentId))
                                { 
                                    bodys.Add(body.ParentId);
                                }
                                if (bodys.Contains(body.ParentId) && EatedID.Contains(body.ParentId))
                                {
                                    bodys.Remove(body.ParentId);
                                }
                            }
                        }
                        if (bodys.Count == 0)
                        {
                            Sentinel.ScanPlayerDie = 0;
                        }
                        else
                        {
                            Sentinel.ScanPlayerDie = bodys.Count();
                        }


                        if (((Barghest.Role != null) && (Barghest.Role.inVent))
                        || ((Assassin.Role != null) && (Assassin.Role.inVent))
                        || ((Vector.Role != null) && (Vector.Role.inVent))
                        || ((Morphling.Role != null) && (Morphling.Role.inVent))
                        || ((Scrambler.Role != null) && (Scrambler.Role.inVent))
                        || ((Ghost.Role != null) && (Ghost.Role.inVent))
                        || ((Guesser.Role != null) && (Guesser.Role.inVent))
                        || ((Sorcerer.Role != null) && (Sorcerer.Role.inVent))
                        || ((Mesmer.Role != null) && (Mesmer.Role.inVent))
                        || ((Basilisk.Role != null) && (Basilisk.Role.inVent))
                        || ((Reaper.Role != null) && (Reaper.Role.inVent))
                        || ((Saboteur.Role != null) && (Saboteur.Role.inVent))
                        || ((Impostor1.Role != null) && (Impostor1.Role.inVent))
                        || ((Impostor2.Role != null) && (Impostor2.Role.inVent))
                        || ((Impostor3.Role != null) && (Impostor3.Role.inVent))
                        || ((Mercenary.Role != null) && (Mercenary.Role.inVent))
                        || ((Eater.Role != null) && (Eater.Role.inVent))
                        || ((Fake.Role != null) && (Fake.Role.inVent))
                        || ((Bait.Role != null) && (Bait.Role.inVent))
                        || ((Engineer.Role != null) && (Engineer.Role.inVent))
                        || ((CopyCat.Role != null) && (CopyCat.Role.inVent))
                        )
                        {
                            Sentinel.ScanPLayerInVent = true;
                        }
                        else
                        {
                            Sentinel.ScanPLayerInVent = false;
                        }
                        
                        
                            
                        
                        











                }
                    SentinelCount = true;
                }
                else { Sentinel_Alive = 0; }
                //Teammate1
                if (Teammate1.Role != null)
                {
                    if (Teammate1.Role.Data.IsDead || Teammate1.Role.Data.Disconnected) { Teammate1_Alive = 0; }
                    else { Teammate1_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Teammate1.Role)
                    {
                        STRRole = "Teammate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Teammate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Teammate1Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Teammate1Count = true;
                }
                else { Teammate1_Alive = 0; }
                //Teammate2
                if (Teammate2.Role != null)
                {
                    if (Teammate2.Role.Data.IsDead || Teammate2.Role.Data.Disconnected) { Teammate2_Alive = 0; }
                    else { Teammate2_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Teammate2.Role)
                    {
                        STRRole = "Teammate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Teammate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Teammate2Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Teammate2Count = true;
                }
                else { Teammate2_Alive = 0; }
                //Lawkeeper
                if (Lawkeeper.Role != null)
                {
                    if (Lawkeeper.Role.Data.IsDead || Lawkeeper.Role.Data.Disconnected) { Lawkeeper_Alive = 0; }
                    else { Lawkeeper_Alive = 1; }

                    if (Lawkeeper.TaskEND = true && SuperInfo.getBool() == true && !Lawkeeper.Role.Data.IsDead)
                    {
                        Lawkeeper.AbilityEnable = true;
                    }
                    else
                    {
                        Lawkeeper.AbilityEnable = false;
                    }
                    

                    if (PlayerControl.LocalPlayer == Lawkeeper.Role)
                    {
                        STRRole = "Lawkeeper";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Lawkeeper;
                        STR_MyRoleColor = "" + R_LawkeeperColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.LawkeeperTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    LawkeeperCount = true;
                }
                else { Lawkeeper_Alive = 0; }
                //Fake
                if (Fake.Role != null)
                {
                    if (Fake.Role.Data.IsDead || Fake.Role.Data.Disconnected) { Fake_Alive = 0; }
                    else { Fake_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Fake.Role)
                    {
                        STRRole = "Fake";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Fake;
                        STR_MyRoleColor = "" + R_FakeColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.FakeTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    FakeCount = true;
                }
                else { Fake_Alive = 0; }
                //Traveler
                if (Traveler.Role != null)
                {
                    if (Traveler.Role.Data.IsDead || Traveler.Role.Data.Disconnected) { Traveler_Alive = 0; }
                    else { Traveler_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Traveler.Role)
                    {
                        STRRole = "Traveler";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Traveler;
                        STR_MyRoleColor = "" + R_TravelerColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.TravelerTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    TravelerCount = true;
                }
                else { Traveler_Alive = 0; }
                //Leader
                if (Leader.Role != null)
                {
                    if (Leader.Role.Data.IsDead || Leader.Role.Data.Disconnected) { Leader_Alive = 0; }
                    else { Leader_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Leader.Role)
                    {
                        STRRole = "Leader";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Leader;
                        STR_MyRoleColor = "" + R_LeaderColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.LeaderTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    LeaderCount = true;
                }
                else { Leader_Alive = 0; }
                //Doctor
                if (Doctor.Role != null)
                {
                    if (Doctor.Role.Data.IsDead || Doctor.Role.Data.Disconnected) { Doctor_Alive = 0; }
                    else { Doctor_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Doctor.Role)
                    {
                        STRRole = "Doctor";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Doctor;
                        STR_MyRoleColor = "" + R_DoctorColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.DoctorTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    DoctorCount = true;
                }
                else { Doctor_Alive = 0; }
                //Slave
                if (Slave.Role != null)
                {
                    if (Slave.Role.Data.IsDead || Slave.Role.Data.Disconnected) { Slave_Alive = 0; }
                    else { Slave_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Slave.Role)
                    {
                        STRRole = "Slave";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Slave;
                        STR_MyRoleColor = "" + R_SlaveColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.SlaveTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    SlaveCount = true;
                }
                else { Slave_Alive = 0; }
                //Crewmates
                if (Crewmate1.Role != null)
                {
                    if (Crewmate1.Role.Data.IsDead || Crewmate1.Role.Data.Disconnected) { Crewmate1_Alive = 0; }
                    else { Crewmate1_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate1.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate1Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate1Count = true;
                }
                else { Crewmate1_Alive = 0; }
                if (Crewmate2.Role != null)
                {
                    if (Crewmate2.Role.Data.IsDead || Crewmate2.Role.Data.Disconnected) { Crewmate2_Alive = 0; }
                    else { Crewmate2_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate2.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate2Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate2Count = true;
                }
                else { Crewmate2_Alive = 0; }
                if (Crewmate3.Role != null)
                {
                    if (Crewmate3.Role.Data.IsDead || Crewmate3.Role.Data.Disconnected) { Crewmate3_Alive = 0; }
                    else { Crewmate3_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate3.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate3Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate3Count = true;
                }
                else { Crewmate3_Alive = 0; }
                if (Crewmate4.Role != null)
                {
                    if (Crewmate4.Role.Data.IsDead || Crewmate4.Role.Data.Disconnected) { Crewmate4_Alive = 0; }
                    else { Crewmate4_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate4.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate4Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate4Count = true;
                }
                else { Crewmate4_Alive = 0; }
                if (Crewmate5.Role != null)
                {
                    if (Crewmate5.Role.Data.IsDead || Crewmate5.Role.Data.Disconnected) { Crewmate5_Alive = 0; }
                    else { Crewmate5_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate5.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate5Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate5Count = true;
                }
                else { Crewmate5_Alive = 0; }
                if (Crewmate6.Role != null)
                {
                    if (Crewmate6.Role.Data.IsDead || Crewmate6.Role.Data.Disconnected) { Crewmate6_Alive = 0; }
                    else { Crewmate6_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate6.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate6Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate6Count = true;
                }
                else { Crewmate6_Alive = 0; }
                if (Crewmate7.Role != null)
                {
                    if (Crewmate7.Role.Data.IsDead || Crewmate7.Role.Data.Disconnected) { Crewmate7_Alive = 0; }
                    else { Crewmate7_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate7.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate7Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate7Count = true;
                }
                else { Crewmate7_Alive = 0; }
                if (Crewmate8.Role != null)
                {
                    if (Crewmate8.Role.Data.IsDead || Crewmate8.Role.Data.Disconnected) { Crewmate8_Alive = 0; }
                    else { Crewmate8_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate8.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate8Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate8Count = true;
                }
                if (Crewmate9.Role != null)
                {
                    if (Crewmate9.Role.Data.IsDead || Crewmate9.Role.Data.Disconnected) { Crewmate9_Alive = 0; }
                    else { Crewmate9_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate9.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate9Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate9Count = true;
                }
                else { Crewmate9_Alive = 0; }
                if (Crewmate10.Role != null)
                {
                    if (Crewmate10.Role.Data.IsDead || Crewmate10.Role.Data.Disconnected) { Crewmate10_Alive = 0; }
                    else { Crewmate10_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate10.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate10Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate10Count = true;
                }
                else { Crewmate10_Alive = 0; }
                if (Crewmate11.Role != null)
                {
                    if (Crewmate11.Role.Data.IsDead || Crewmate11.Role.Data.Disconnected) { Crewmate11_Alive = 0; }
                    else { Crewmate11_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate11.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate11Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate11Count = true;
                }
                else { Crewmate11_Alive = 0; }
                if (Crewmate12.Role != null)
                {
                    if (Crewmate12.Role.Data.IsDead || Crewmate12.Role.Data.Disconnected) { Crewmate12_Alive = 0; }
                    else { Crewmate12_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate12.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate12Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate12Count = true;
                }
                else { Crewmate12_Alive = 0; }
                if (Crewmate13.Role != null)
                {
                    if (Crewmate13.Role.Data.IsDead || Crewmate13.Role.Data.Disconnected) { Crewmate13_Alive = 0; }
                    else { Crewmate13_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate13.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate13Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate13Count = true;
                }
                else { Crewmate13_Alive = 0; }
                if (Crewmate14.Role != null)
                {
                    if (Crewmate14.Role.Data.IsDead || Crewmate14.Role.Data.Disconnected) { Crewmate14_Alive = 0; }
                    else { Crewmate14_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Crewmate14.Role)
                    {
                        STRRole = "Crewmate";
                        STRTeam = "Crewmate";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                        STR_MyRole = "" + Role_Crewmate;
                        STR_MyRoleColor = "" + R_CrewmateColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.Crewmate14Task;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Crewmates; }
                        STR_MyTaskColor = "" + Q_Crew;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    Crewmate14Count = true;
                }
                else { Crewmate14_Alive = 0; }


                //SPECIAL
                //Jester
                if (Jester.Role != null)
                {
                    if (Jester.Role.Data.IsDead || Jester.Role.Data.Disconnected) { Jester_Alive = 0; }
                    else { Jester_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Jester.Role)
                    {
                        STRRole = "Jester";
                        STRTeam = "Jester";
                        STR_MyTotaltask = "";
                        STR_MyRole = "" + Role_Jester;
                        STR_MyRoleColor = "" + R_JesterColor;
                        STR_Mytask = "";
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Jester; }
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (JesterSingle.getSelection() == 0) //single
                        { 
                            Jester.CanFake = true;
                            Jester.SingleFake = true;
                        }
                        if (JesterSingle.getSelection() == 1) //multi
                        {
                            Jester.CanFake = true;
                            Jester.SingleFake = false;

                        }
                        if (JesterSingle.getSelection() == 2) //off
                        {
                            Jester.CanFake = false;
                        }
                    }
                    JesterCount = true;
                }
                else { Jester_Alive = 0; }
                //Eater
                if (Eater.Role != null)
                {
                    if (Eater.Role.Data.IsDead || Eater.Role.Data.Disconnected) { Eater_Alive = 0; }
                    else { Eater_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Eater.Role)
                    {
                        STRRole = "Eater";
                        STRTeam = "Eater";
                        STR_MyTotaltask = "" + ChallengerMod.Set.Data.Eatervaluewin;
                        STR_MyRole = "" + Role_Eater;
                        STR_MyRoleColor = "" + R_EaterColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.EaterTask;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Eater; }
                        STR_MyTaskColor = "" + Q_Eater;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance / 6f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                Eater.TargetBody = true;
                            }
                            else
                            {
                                Eater.TargetBody = false;
                            }
                        }
                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance / 6f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                Eater.CanEat = true;
                            }
                            else
                            {
                                Eater.CanEat = false;
                            }
                        }

                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance * 25f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                DeadBody component = collider2D.GetComponent<DeadBody>();
                                if (component && !component.Reported)
                                {
                                    Vector2 truePosition = PlayerControl.LocalPlayer.GetTruePosition();
                                    Vector2 truePosition2 = component.TruePosition;

                                    if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 10;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 1.25 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 9;

                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 1.75 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 8;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 2.5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 7;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 3 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 6;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 3.5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 5;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 4 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 4;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 4.5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 3;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 2;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) <= PlayerControl.LocalPlayer.MaxReportDistance * 5.5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 1;
                                    }
                                    else if (Vector2.Distance(truePosition2, truePosition) > PlayerControl.LocalPlayer.MaxReportDistance * 5.5 && PlayerControl.LocalPlayer.CanMove)
                                    {
                                        Eater.DistBody = 0;
                                    }
                                }
                            }
                        }


                    }
                    
                    
                    EaterCount = true;
                }
                else { Eater_Alive = 0; }
                //Outlaw
                if (Outlaw.Role != null)
                {
                    if (Outlaw.Role.Data.IsDead || Outlaw.Role.Data.Disconnected) { Outlaw_Alive = 0; }
                    else { Outlaw_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Outlaw.Role)
                    {
                        STRRole = "Outlaw";
                        STRTeam = "Outlaw";
                        STR_MyTotaltask = "";
                        STR_MyRole = "" + Role_Outlaw;
                        STR_MyRoleColor = "" + R_OutlawColor;
                        STR_Mytask = "";
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Outlaw; }
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    OutlawCount = true;
                }
                else { Outlaw_Alive = 0; }
                //Arsonist
                if (Arsonist.Role != null)
                {
                    if (Arsonist.Role.Data.IsDead || Arsonist.Role.Data.Disconnected) { Arsonist_Alive = 0; }
                    else { Arsonist_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Arsonist.Role)
                    {
                        STRRole = "Arsonist";
                        STRTeam = "Arsonist";
                        STR_MyTotaltask = "" + (ChallengerMod.Set.Data.TotalPlayerAlive -1);
                        STR_MyRole = "" + Role_Arsonist;
                        STR_MyRoleColor = "" + R_ArsonistColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.TotalPlayerOil;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Arsonist; }
                        STR_MyTaskColor = "" + Q_Arsonist;
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        
                        foreach (PlayerControl PO in OiledPlayers)
                        {
                            if (Arsonist.currentTarget == PO)
                            {
                                Arsonist.NullTarget = true;
                            }
                            else
                            {
                                Arsonist.NullTarget = false;
                            }
                        }

                    }

                    Arsonist.FailTimer = ArsonistFailDuration.getFloat() + 0;
                    Arsonist.FuelSpeed = ArsonistFuelQT.getFloat() + 0;

                    if (Arsonist.Fuel < 0f) { Arsonist.FuelPercent = 0; ; Arsonist.Fuel = 0f; }
                    else if (Arsonist.Fuel > 1000f) { Arsonist.FuelPercent = 100; Arsonist.Fuel = 1000f; }
                    else { Arsonist.FuelPercent = (int)Math.Round(Arsonist.Fuel / 10); }



                    ArsonistCount = true;

                }
                else { Arsonist_Alive = 0; }


                //Cursed
                if (Cursed.Role != null)
                {
                    if (Cursed.Role.Data.IsDead || Cursed.Role.Data.Disconnected) { Cursed_Alive = 0; }
                    else { Cursed_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Cursed.Role)
                    {
                        STRRole = "Cursed";
                        STRTeam = "Cursed";
                        STR_MyTotaltask = "";
                        STR_MyRole = "" + Role_Cursed;
                        STR_MyRoleColor = "" + R_CursedColor;
                        STR_Mytask = "" + Cursed.CursePercent;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Cursed; }
                        STR_MyTaskColor = "" + Q_Imp;
                        STR_Ts1 = "[";
                        STR_Ts2 = "%";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        



                        if (Cursed.CurseStart == false || Cursed.NoCurse == true || Challenger.LobbyTimeStop == true)
                        {

                        }
                        else
                        {

                            Cursed.CursePlayer = TotalPlayerAlive + (Cursed.SpeedModifieur);

                            if (ChallengerMod.Challenger.FirstTurn == true) { Cursed.CurseSpeed = 0.008f; } //T1
                            else
                            {
                                if (ChallengerMod.Challenger.SecondTurn == false) { Cursed.CurseSpeed = 0.012f; } //T2
                                else { Cursed.CurseSpeed = 0.020f; } //T3
                            }
                            
                            
                            if (Cursed.currentTarget != null)
                            {
                                Cursed.CurseValue -= (Cursed.CurseSpeed * Cursed.CursePlayer); 
                            }
                            else
                            {
                                Cursed.CurseValue += (Cursed.CurseSpeed * Cursed.CursePlayer);
                            }
                        }

                        if (Cursed.CurseValue < 0)
                        {
                            Cursed.CurseValue = 0f;
                            Cursed.CursePercent = 0;

                        }
                        else
                        {
                            if (Cursed.CurseValue >= 1000)
                            {
                                Cursed.CursePercent = 100;
                                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CursedWin, Hazel.SendOption.Reliable, -1);
                                AmongUsClient.Instance.FinishRpcImmediately(writer);
                                RPCProcedure.cursedWin();
                            }
                            else
                            {
                                int SavePercent = 0;
                                int SharePercent = 0;

                                SavePercent = Cursed.CursePercent;
                                Cursed.CursePercent = (int)Math.Round(Cursed.CurseValue / 10);
                                SharePercent = Cursed.CursePercent;

                                if (SavePercent != SharePercent)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CurseSync, Hazel.SendOption.None, -1);
                                    writer.WritePacked(SharePercent);
                                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                                    SavePercent = SharePercent;
                                }
                            }
                        }

                        





                    }

                    CursedCount = true;

                }
                else { Cursed_Alive = 0; }




                //Cultist
                if (Cultist.Role != null)
                {
                    if (Cultist.Role.Data.IsDead || Cultist.Role.Data.Disconnected) { Cultist_Alive = 0; }
                    else { Cultist_Alive = 1; }

                    if ((ChallengerMod.Set.Data.TotalCulteAlive) > (ChallengerMod.Set.Data.TotalPlayerAlive - ChallengerMod.Set.Data.TotalCulteAlive))
                    {
                        Cultist.Win = true;
                    }
                    else { Cultist.Win = false; }
                    

                    if (PlayerControl.LocalPlayer == Cultist.Role)
                    {
                        STRRole = "Cultist";
                        STRTeam = "Culte";
                        STR_MyTotaltask = "" + (ChallengerMod.Set.Data.TotalPlayerAlive - ChallengerMod.Set.Data.TotalCulteAlive);
                        STR_MyRole = "" + Role_Cultist;
                        STR_MyRoleColor = "" + R_CulteColor;
                        STR_Mytask = "" + ChallengerMod.Set.Data.TotalCulteAlive;
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Cultes; }
                        STR_MyTaskColor = "" + Q_Culte;
                        STR_Ts1 = "[";
                        STR_Ts2 = "<color=#FFFFFF> vs </color><color=#FF0000>";
                        STR_Ts3 = "</color><color=#BC0AEF>]</color><color=#FFFFFF>";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        
                    }
                    CultistCount = true;

                }
                else { Cultist_Alive = 0; }
                //Cupid
                if (Cupid.Role != null)
                {
                    if (Cupid.Role.Data.IsDead || Cupid.Role.Data.Disconnected) { Cupid_Alive = 0; }
                    else { Cupid_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Cupid.Role)
                    {
                        STRRole = "Cupid";
                        STRTeam = "Cupid";
                        STR_MyTotaltask = "";
                        STR_MyRole = "" + Role_Cupid;
                        STR_MyRoleColor = "" + R_CupidColor;
                        STR_Mytask = "";
                        if (!NewTeam)
                        { 
                            if (!Cupid.loverDie && !Cupid.Fail)
                            {
                                STR_MyTeam = "" + T_Loves;
                            }
                            else
                            {
                                STR_MyTeam = "" + T_Fail;
                            }
                        }
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    CupidCount = true;
                }
                else { Cupid_Alive = 0; }

                //HYBRID
                //Mercenary
                if (Mercenary.Role != null)
                {
                    if (Mercenary.Role.Data.IsDead || Mercenary.Role.Data.Disconnected)
                    {
                        Mercenary_Alive = 0;
                        IMercenary_Alive = 0;
                    }
                    else
                    {
                        if (Mercenary.isImpostor) { IMercenary_Alive = 1; Mercenary_Alive = 0; }
                        else { IMercenary_Alive = 0; Mercenary_Alive = 1; }
                            
                        

                    }

                    if (Mercenary.Temp)
                    {
                        Mercenary.Timer -= Time.fixedDeltaTime;

                        if (Mercenary.Timer <= 0)
                        {
                            Mercenary.Temp = false;
                        }
                    }
                    

                    if (PlayerControl.LocalPlayer == Mercenary.Role)
                    {
                        STRRole = "Mercenary";
                        STRTeam = "Hybrid";
                        
                        STR_MyRole = "" + Role_Mercenary;
                        STR_MyRoleColor = "" + R_MercenaryColor;
                        if (!Mercenary.isImpostor)
                        {
                            STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                            STR_Mytask = "" + ChallengerMod.Set.Data.MercenaryTask;
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Crewmates; }
                            STR_MyTaskColor = "" + Q_Crew;
                            STR_Ts1 = "[";
                            STR_Ts2 = "/";
                            STR_Ts3 = "]";
                            STR_P1 = "(";
                            STR_P2 = ")";
                        }
                        else
                        {
                            STR_MyTotaltask = "";
                            STR_Mytask = "";
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Impostors; }
                            STR_MyTaskColor = "";
                            STR_Ts1 = "";
                            STR_Ts2 = "";
                            STR_Ts3 = "";
                            STR_P1 = "(";
                            STR_P2 = ")";
                        }
                        
                    }
                    if (Mercenary.isImpostor)
                    {
                        MercenaryCount = true;
                        MercenaryICount = true;
                        
                        if (MercenaryCanVent.getBool() == true)
                        {
                            Mercenary.CanVent = true;
                        }
                        else { Mercenary.CanVent = false; }
                        
                        if (Mercenary.Role.Data.IsDead && Outlaw.Role != null)
                        {
                            Outlaw.canKill = true;
                        }
                    }
                    else
                    {
                        MercenaryCount = true;
                        MercenaryICount = false;
                        Mercenary.CanVent = false;
                    }

                }
                else { Mercenary_Alive = 0; }
                //CopyCat
                if (CopyCat.Role != null)
                {
                    if (CopyCat.Role.Data.IsDead || CopyCat.Role.Data.Disconnected)
                    { 
                        CopyCat_Alive = 0;
                        ICopyCat_Alive = 0;
                        CopyCat.HMActive = false;
                    }
                    else 
                    {
                        if (CopyCat.isImpostor) { ICopyCat_Alive = 1; CopyCat_Alive = 0; }
                        else { ICopyCat_Alive = 0; CopyCat_Alive = 1; }

                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == true && FirstTurn == true) { CopyCat.HMActive = false; }
                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == false) { CopyCat.HMActive = true; }
                        if (DictatorMeeting.getSelection() == 0 && DictatorFirstTurn.getBool() == true && FirstTurn == false) { CopyCat.HMActive = true; }
                    }

                    if (CopyCat.TaskEND = true && SuperInfo.getBool() == true && !CopyCat.Role.Data.IsDead && CopyCat.copyRole == 18 && CopyCat.CopyStart)
                    {
                        CopyCat.AbilityEnable = true;
                    }
                    else
                    {
                        CopyCat.AbilityEnable = false;
                    }



                    if (CopyCat.Temp)
                    {
                        CopyCat.Timer -= Time.fixedDeltaTime;

                        if (CopyCat.Timer <= 0)
                        {
                            CopyCat.Temp = false;
                        }
                    }

                    if (PlayerControl.LocalPlayer == CopyCat.Role)
                    {
                        STRRole = "CopyCat";
                        STRTeam = "Hybrid";
                        STR_MyRole = "" + STR_COPY;
                        STR_MyRoleColor = "";
                        
                        if (!CopyCat.isImpostor)
                        {
                            STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                            STR_Mytask = "" + ChallengerMod.Set.Data.CopyCatTask;
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Crewmates; }
                            STR_MyTaskColor = "" + Q_Crew;
                            STR_Ts1 = "[";
                            STR_Ts2 = "/";
                            STR_Ts3 = "]";
                            STR_P1 = "";
                            STR_P2 = "";
                        }
                        else
                        {
                            STR_MyTotaltask = "";
                            STR_Mytask = "";
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Impostors; }
                            STR_MyTaskColor = "";
                            STR_Ts1 = "";
                            STR_Ts2 = "";
                            STR_Ts3 = "";
                            STR_P1 = "";
                            STR_P2 = "";
                        }

                        if (CopyCat.copyRole == 6 && CopyCat.CopyStart)
                        {
                            if (Mystic.DoubleShield)
                            {
                                STR_MyShield = B_DoubleShield;
                                Mystic.ShieldButton = false;
                            }
                            else
                            {
                                if (Mystic.selfShield)
                                {
                                    STR_MyShield = B_SelfShield;
                                    Mystic.ShieldButton = true;
                                }
                                else
                                {
                                    STR_MyShield = B_NoSelfShield;
                                    Mystic.ShieldButton = true;
                                }
                            }
                        }
                        

                        if (Mayor.Role != null)
                        {
                            if (BonusBuzz.getSelection() == 0) { Mayor.Buzz = false; }
                            else if (BonusBuzz.getSelection() == 1) { Mayor.Buzz = true; }
                            else if (CopyCat.TaskEND == true && BonusBuzz.getSelection() == 2) { Mayor.Buzz = true; }
                            else if (CopyCat.TaskEND == false && BonusBuzz.getSelection() == 2) { Mayor.Buzz = false; }

                        }

                        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(PlayerControl.LocalPlayer.GetTruePosition(), PlayerControl.LocalPlayer.MaxReportDistance * 25f, Constants.PlayersOnlyMask))
                        {
                            if (collider2D.tag == "DeadBody")
                            {
                                DeadBody body = (DeadBody)((Component)collider2D).GetComponent<DeadBody>();
                                if (!bodys2.Contains(body.ParentId) && !EatedID.Contains(body.ParentId))
                                {
                                    bodys2.Add(body.ParentId);
                                }
                                if (bodys2.Contains(body.ParentId) && EatedID.Contains(body.ParentId))
                                {
                                    bodys2.Remove(body.ParentId);
                                }
                            }
                        }
                        if (bodys2.Count == 0)
                        {
                            CopyCat.ScanPlayerDie = 0;
                        }
                        else
                        {
                            CopyCat.ScanPlayerDie = bodys2.Count();
                        }


                        if (((Barghest.Role != null) && (Barghest.Role.inVent))
                        || ((Assassin.Role != null) && (Assassin.Role.inVent))
                        || ((Vector.Role != null) && (Vector.Role.inVent))
                        || ((Morphling.Role != null) && (Morphling.Role.inVent))
                        || ((Scrambler.Role != null) && (Scrambler.Role.inVent))
                        || ((Ghost.Role != null) && (Ghost.Role.inVent))
                        || ((Guesser.Role != null) && (Guesser.Role.inVent))
                        || ((Sorcerer.Role != null) && (Sorcerer.Role.inVent))
                        || ((Mesmer.Role != null) && (Mesmer.Role.inVent))
                        || ((Basilisk.Role != null) && (Basilisk.Role.inVent))
                        || ((Reaper.Role != null) && (Reaper.Role.inVent))
                        || ((Saboteur.Role != null) && (Saboteur.Role.inVent))
                        || ((Impostor1.Role != null) && (Impostor1.Role.inVent))
                        || ((Impostor2.Role != null) && (Impostor2.Role.inVent))
                        || ((Impostor3.Role != null) && (Impostor3.Role.inVent))
                        || ((Mercenary.Role != null) && (Mercenary.Role.inVent))
                        || ((Eater.Role != null) && (Eater.Role.inVent))
                        || ((Fake.Role != null) && (Fake.Role.inVent))
                        || ((Bait.Role != null) && (Bait.Role.inVent))
                        || ((Engineer.Role != null) && (Engineer.Role.inVent))
                        || ((CopyCat.Role != null) && (CopyCat.Role.inVent))
                        )
                        {
                            Sentinel.ScanPLayerInVent = true;
                        }
                        else
                        {
                            Sentinel.ScanPLayerInVent = false;
                        }

                    }

                    if (CopyCat.isImpostor)
                    {
                        CopyCatCount = true;
                        CopyCatICount = true;
                        CopyCat.CanVent = true;
                        if (CopyCat.Role.Data.IsDead && Outlaw.Role != null)
                        {
                            Outlaw.canKill = true;
                        }
                    }
                    else
                    {
                        CopyCatCount = true;
                        CopyCatICount = false;
                       
                        if (CopyCat.copyRole == 3 && CopyCat.CopyStart && EngineerCanVent.getBool() == true)
                        {
                            CopyCat.CanVent = true;
                        }
                        else if (CopyCat.copyRole == 13 && CopyCat.CopyStart && BaitCanVent.getBool() == true)
                        {
                            CopyCat.CanVent = true;
                        }
                        else
                        {
                            CopyCat.CanVent = false;
                        }
                       if (CopyCat.copyRole == 15 && CopyCat.CopyStart)
                        {
                            if (MaxBuild.getSelection() == 0)
                            {
                                Builder.Use1 = true;
                                Builder.Use2 = true; //stay 1
                            }
                            if (MaxBuild.getSelection() == 1)
                            {
                                Builder.Use1 = true; // stay 2
                            }
                            if (BuildRound.getBool() == false)
                            {
                                Builder.round = false; // force false
                            }
                        }

                    }
                }
                else { CopyCat_Alive = 0; }
                //Revenger
                if (Revenger.Role != null)
                {
                    if (Revenger.Role.Data.IsDead || Revenger.Role.Data.Disconnected) { Revenger_Alive = 0; }
                    else { Revenger_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Revenger.Role)
                    {
                        STRRole = "Revenger";
                        STRTeam = "Hybrid";
                        STR_MyRole = "" + Role_Revenger;
                        STR_MyRoleColor = "" + R_RevengerColor;
                        if (!Revenger.isImpostor)
                        {
                            STR_MyTotaltask = "" + ChallengerMod.Set.Data.TotalTask;
                            STR_Mytask = "" + ChallengerMod.Set.Data.RevengerTask;
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Crewmates; }
                            STR_MyTaskColor = "" + Q_Crew;
                            STR_Ts1 = "[";
                            STR_Ts2 = "/";
                            STR_Ts3 = "]";
                            STR_P1 = "(";
                            STR_P2 = ")";
                        }
                        else
                        {
                            STR_MyTotaltask = "";
                            STR_Mytask = "";
                            if (!NewTeam)
                            { STR_MyTeam = "" + T_Impostors; }
                            STR_MyTaskColor = "";
                            STR_Ts1 = "";
                            STR_Ts2 = "";
                            STR_Ts3 = "";
                            STR_P1 = "(";
                            STR_P2 = ")";
                        }
                        if (QtVenger.getFloat() == 2)
                        {
                            Revenger.EMP1_Used = true;
                        }
                        if (QtVenger.getFloat() == 1)
                        {
                            Revenger.EMP1_Used = true;
                            Revenger.EMP2_Used = true;
                        }
                        if (VengerKill.getBool() == true)
                        {
                            Revenger.AllEMP_Kill = true;
                        }
                        if (VengerExil.getBool() == true)
                        {
                            Revenger.AllEMP_Exil = true;

                        }
                        if (VengerKill.getBool() == true && VengerExil.getBool() == true)
                        {
                            Revenger.EMP1_Used = true;
                            Revenger.EMP2_Used = true;
                            Revenger.EMP3_Used = true;
                        }
                    }
                    if (Revenger.isImpostor)
                    {
                        RevengerCount = true;
                        RevengerICount = true;
                    }
                    else
                    {
                        RevengerCount = true;
                        RevengerICount = false;
                    }
                }
                else { Revenger_Alive = 0; }
                //Survivor
                if (Survivor.Role != null)
                {
                    if (Survivor.Role.Data.IsDead || Survivor.Role.Data.Disconnected) { Survivor_Alive = 0; }
                    else { Survivor_Alive = 1; }

                    if (PlayerControl.LocalPlayer == Survivor.Role)
                    {
                        STRRole = "Survivor";
                        STRTeam = "Hybrid";
                        STR_MyRole = "" + Role_Survivor;
                        STR_MyRoleColor = "" + R_SurvivorColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        if (!NewTeam)
                        { STR_MyTeam = "" + T_Survivor; }
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";

                    }
                    SurvivorCount = true;
                }
                else { Survivor_Alive = 0; }

                //IMPOSTOR
                //Assassin
                if (Assassin.Role != null)
                {
                    if (Assassin.Role.Data.IsDead || Assassin.Role.Data.Disconnected) { Assassin_Alive = 0; }
                    else { Assassin_Alive = 1; }


                    AssassinCount = true;

                    if (PlayerControl.LocalPlayer == Assassin.Role)
                    {
                        STRRole = "Assassin";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Assassin;
                        STR_MyRoleColor = "" + R_AssassinColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        if (Assassin.Shielded) { STR_MyShield = B_Shield; }
                        else { STR_MyShield = ""; }
                    }
                    if (Assassin.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Assassin_Alive = 0; }
                //Vector
                if (Vector.Role != null)
                {
                    if (Vector.Role.Data.IsDead || Vector.Role.Data.Disconnected) { Vector_Alive = 0; }
                    else { Vector_Alive = 1; }

                    VectorCount = true;
                    if (PlayerControl.LocalPlayer == Vector.Role)
                    {
                        STRRole = "Vector";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Vector;
                        STR_MyRoleColor = "" + R_VectorColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Vector.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Vector_Alive = 0; }
                //Morphling
                if (Morphling.Role != null)
                {
                    if (Morphling.Role.Data.IsDead || Morphling.Role.Data.Disconnected) { Morphling_Alive = 0; }
                    else { Morphling_Alive = 1; }

                    MorphlingCount = true;
                    if (PlayerControl.LocalPlayer == Morphling.Role)
                    {
                        STRRole = "Morphling";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Morphling;
                        STR_MyRoleColor = "" + R_MorphlingColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Morphling.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Morphling_Alive = 0; }
                //Scrambler
                if (Scrambler.Role != null)
                {
                    if (Scrambler.Role.Data.IsDead || Scrambler.Role.Data.Disconnected) { Scrambler_Alive = 0; }
                    else { Scrambler_Alive = 1; }

                    ScramblerCount = true;
                    if (PlayerControl.LocalPlayer == Scrambler.Role)
                    {
                        STRRole = "Scrambler";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Scrambler;
                        STR_MyRoleColor = "" + R_ScramblerColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Scrambler.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Scrambler_Alive = 0; }
                //Barghest
                if (Barghest.Role != null)
                {
                    if (Barghest.Role.Data.IsDead || Barghest.Role.Data.Disconnected) { Barghest_Alive = 0; }
                    else { Barghest_Alive = 1; }

                    BarghestCount = true;
                    if (PlayerControl.LocalPlayer == Barghest.Role)
                    {
                        STRRole = "Barghest";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Barghest;
                        STR_MyRoleColor = "" + R_BarghestColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Barghest.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Barghest_Alive = 0; }
                //Ghost
                if (Ghost.Role != null)
                {
                    if (Ghost.Role.Data.IsDead || Ghost.Role.Data.Disconnected) { Ghost_Alive = 0; }
                    else { Ghost_Alive = 1; }

                    GhostCount = true;
                    if (PlayerControl.LocalPlayer == Ghost.Role)
                    {
                        STRRole = "Ghost";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Ghost;
                        STR_MyRoleColor = "" + R_GhostColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Ghost.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Ghost_Alive = 0; }
                //Sorcerer
                if (Sorcerer.Role != null)
                {
                    if (Sorcerer.Role.Data.IsDead || Sorcerer.Role.Data.Disconnected) { Sorcerer_Alive = 0; }
                    else { Sorcerer_Alive = 1; }

                    SorcererCount = true;
                    if (PlayerControl.LocalPlayer == Sorcerer.Role)
                    {
                        STRRole = "Sorcerer";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Sorcerer;
                        STR_MyRoleColor = "" + R_SorcererColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "x" + Sorcerer.TotalRune;
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "" + Q_Imp;
                        STR_Ts1 = "[";
                        STR_Ts2 = "";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        if (War1.getBool() == true) { Sorcerer.CanUse1 = true; }
                        else { Sorcerer.CanUse1 = false; }
                        if (War2.getBool() == true) { Sorcerer.CanUse2 = true; }
                        else { Sorcerer.CanUse2 = false; }
                        if (War3.getBool() == true) { Sorcerer.CanUse3 = true; }
                        else { Sorcerer.CanUse3 = false; }
                        if (War4.getBool() == true) { Sorcerer.CanUse4 = true; }
                        else { Sorcerer.CanUse4 = false; }

                    }
                    if (Sorcerer.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Sorcerer_Alive = 0; }
                //Guesser
                if (Guesser.Role != null)
                {
                    if (Guesser.Role.Data.IsDead || Guesser.Role.Data.Disconnected) { Guesser_Alive = 0; }
                    else { Guesser_Alive = 1; }

                    GuesserCount = true;
                    if (PlayerControl.LocalPlayer == Guesser.Role)
                    {
                        STRRole = "Guesser";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Guesser;
                        STR_MyRoleColor = "" + R_GuesserColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "" + Guesser.remainingShots;
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "" + Q_Imp;
                        STR_Ts1 = "[";
                        STR_Ts2 = "";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";
                        
                        if (GuessTryOne.getBool() == true)
                        {
                            Guesser.hasMultipleShotsPerMeeting = true;
                        }
                        else
                        {
                            Guesser.hasMultipleShotsPerMeeting = false;
                        }
                        
                    }
                    if (Guesser.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Guesser_Alive = 0; }
                //Mesmer
                if (Mesmer.Role != null)
                {
                    if (Mesmer.Role.Data.IsDead || Mesmer.Role.Data.Disconnected) { Mesmer_Alive = 0; }
                    else { Mesmer_Alive = 1; }

                    MesmerCount = true;
                    if (PlayerControl.LocalPlayer == Mesmer.Role)
                    {
                        STRRole = "Mesmer";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Mesmer;
                        STR_MyRoleColor = "" + R_MesmerColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Mesmer.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Mesmer_Alive = 0; }
                
                //Basilisk
                if (Basilisk.Role != null)
                {
                    if (Basilisk.Role.Data.IsDead || Basilisk.Role.Data.Disconnected) { Basilisk_Alive = 0; }
                    else { Basilisk_Alive = 1; }

                    if (Basilisk.PetrifyCount > Basilisk.PetrifyMax)
                    { Basilisk.PetrifyCount = Basilisk.PetrifyMax; }

                    BasiliskCount = true;
                    if (PlayerControl.LocalPlayer == Basilisk.Role)
                    {
                        STRRole = "Basilisk";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Basilisk;
                        STR_MyRoleColor = "" + R_BasiliskColor;
                        STR_MyTotaltask = "" + Basilisk.PetrifyMax;
                        STR_Mytask = "" + Basilisk.PetrifyCount;
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "[";
                        STR_Ts2 = "/";
                        STR_Ts3 = "]";
                        STR_P1 = "(";
                        STR_P2 = ")";

                        if (Basilisk.SinglePetrify == true)
                        {
                            foreach (PlayerControl PR in Petrifiedplayers)
                            {
                                if (Basilisk.currentTarget == PR)
                                {
                                    Basilisk.NullTarget = true;
                                }
                                else
                                {
                                    Basilisk.NullTarget = false;
                                }
                            }
                        }
                        else { Basilisk.NullTarget = false; }
                        




                    }
                    if (Basilisk.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Basilisk_Alive = 0; }
                //Reaper
                if (Reaper.Role != null)
                {
                    if (Reaper.Role.Data.IsDead || Reaper.Role.Data.Disconnected) { Reaper_Alive = 0; }
                    else { Reaper_Alive = 1; }

                    ReaperCount = true;
                    if (PlayerControl.LocalPlayer == Reaper.Role)
                    {
                        STRRole = "Reaper";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Reaper;
                        STR_MyRoleColor = "" + R_ReaperColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Reaper.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Reaper_Alive = 0; }
                //Saboteur
                if (Saboteur.Role != null)
                {
                    if (Saboteur.Role.Data.IsDead || Saboteur.Role.Data.Disconnected) { Saboteur_Alive = 0; }
                    else { Saboteur_Alive = 1; }

                    SaboteurCount = true;
                    if (PlayerControl.LocalPlayer == Saboteur.Role)
                    {
                        STRRole = "Saboteur";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Saboteur;
                        STR_MyRoleColor = "" + R_SaboteurColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Saboteur.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Saboteur_Alive = 0; }
                //Impostors
                if (Impostor1.Role != null)
                {
                    if (Impostor1.Role.Data.IsDead || Impostor1.Role.Data.Disconnected) { Impostor1_Alive = 0; }
                    else { Impostor1_Alive = 1; }

                    Impostor1Count = true;
                    if (PlayerControl.LocalPlayer == Impostor1.Role)
                    {
                        STRRole = "Impostor";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Impostor;
                        STR_MyRoleColor = "" + R_ImpostorColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Impostor1.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Impostor1_Alive = 0; }
                if (Impostor2.Role != null)
                {
                    if (Impostor2.Role.Data.IsDead || Impostor2.Role.Data.Disconnected) { Impostor2_Alive = 0; }
                    else { Impostor2_Alive = 1; }

                    Impostor2Count = true;
                    if (PlayerControl.LocalPlayer == Impostor2.Role)
                    {
                        STRRole = "Impostor";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Impostor;
                        STR_MyRoleColor = "" + R_ImpostorColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Impostor2.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Impostor2_Alive = 0; }
                if (Impostor3.Role != null)
                {
                    if (Impostor3.Role.Data.IsDead || Impostor3.Role.Data.Disconnected) { Impostor3_Alive = 0; }
                    else { Impostor3_Alive = 1; }

                    Impostor3Count = true;
                    if (PlayerControl.LocalPlayer == Impostor3.Role)
                    {
                        STRRole = "Impostor";
                        STRTeam = "Impostor";
                        STR_MyRole = "" + Role_Impostor;
                        STR_MyRoleColor = "" + R_ImpostorColor;
                        STR_MyTotaltask = "";
                        STR_Mytask = "";
                        STR_MyTeam = "" + T_Impostors;
                        STR_MyTaskColor = "";
                        STR_Ts1 = "";
                        STR_Ts2 = "";
                        STR_Ts3 = "";
                        STR_P1 = "(";
                        STR_P2 = ")";
                    }
                    if (Impostor3.Role.Data.IsDead && Outlaw.Role != null)
                    {
                        Outlaw.canKill = true;
                    }
                }
                else { Impostor3_Alive = 0; }

                ChallengerMod.Challenger.GameStarted -= Time.fixedDeltaTime;

                TotalCulteAlive = 0 + Cultist_Alive + Culte1_Alive + Culte2_Alive + Culte3_Alive;

                TotalLoverAlive = 0 + Lover1_Alive + Lover2_Alive;


                TotalPlayerCount = GameData.Instance.PlayerCount;

                TotalPlayerAlive = Sheriff1_Alive + Sheriff2_Alive + Sheriff3_Alive + Guardian_Alive + Engineer_Alive + Timelord_Alive + Hunter_Alive
                 + Mystic_Alive + Spirit_Alive + Mayor_Alive + Detective_Alive + Nightwatch_Alive + Spy_Alive + Informant_Alive
                 + Bait_Alive + Mentalist_Alive + Builder_Alive + Dictator_Alive + Sentinel_Alive + Teammate1_Alive + Teammate2_Alive
                 + Lawkeeper_Alive + Fake_Alive + Traveler_Alive + Leader_Alive + Doctor_Alive + Slave_Alive
                 + Crewmate1_Alive + Crewmate2_Alive + Crewmate3_Alive + Crewmate4_Alive + Crewmate5_Alive + Crewmate6_Alive + Crewmate7_Alive
                 + Crewmate8_Alive + Crewmate9_Alive + Crewmate10_Alive + Crewmate11_Alive + Crewmate12_Alive + Crewmate13_Alive + Crewmate14_Alive
                 + Jester_Alive + Eater_Alive + Outlaw_Alive + Cultist_Alive + Cupid_Alive + Arsonist_Alive + Cursed_Alive + Mercenary_Alive + CopyCat_Alive
                 + Revenger_Alive + Survivor_Alive + Assassin_Alive + Vector_Alive + Morphling_Alive + Scrambler_Alive + Barghest_Alive
                 + Ghost_Alive + Sorcerer_Alive + Guesser_Alive + Mesmer_Alive + Basilisk_Alive + Reaper_Alive + Saboteur_Alive
                 + Impostor1_Alive + Impostor2_Alive + Impostor3_Alive + IMercenary_Alive + ICopyCat_Alive + 0;

                TotalImpoAlive = Assassin_Alive + Vector_Alive + Morphling_Alive + Scrambler_Alive + Barghest_Alive
                 + Ghost_Alive + Sorcerer_Alive + Guesser_Alive + Mesmer_Alive + Basilisk_Alive + Reaper_Alive + Saboteur_Alive
                 + Impostor1_Alive + Impostor2_Alive + Impostor3_Alive + IMercenary_Alive + ICopyCat_Alive + 0;

                TotalCrewAlive = Sheriff1_Alive + Sheriff2_Alive + Sheriff3_Alive + Guardian_Alive + Engineer_Alive + Timelord_Alive + Hunter_Alive
                 + Mystic_Alive + Spirit_Alive + Mayor_Alive + Detective_Alive + Nightwatch_Alive + Spy_Alive + Informant_Alive
                 + Bait_Alive + Mentalist_Alive + Builder_Alive + Dictator_Alive + Sentinel_Alive + Teammate1_Alive + Teammate2_Alive
                 + Lawkeeper_Alive + Fake_Alive + Traveler_Alive + Leader_Alive + Doctor_Alive + Slave_Alive
                 + Crewmate1_Alive + Crewmate2_Alive + Crewmate3_Alive + Crewmate4_Alive + Crewmate5_Alive + Crewmate6_Alive + Crewmate7_Alive
                 + Crewmate8_Alive + Crewmate9_Alive + Crewmate10_Alive + Crewmate11_Alive + Crewmate12_Alive + Crewmate13_Alive + Crewmate14_Alive
                 + Jester_Alive + Eater_Alive + Outlaw_Alive + Cultist_Alive + Cupid_Alive + Arsonist_Alive + Cursed_Alive + Mercenary_Alive + CopyCat_Alive
                 + Revenger_Alive + Survivor_Alive + 0;



                TotalPlayerDie = GameData.Instance.PlayerCount - TotalPlayerAlive;


                if (Outlaw.Role != null && !Outlaw.Role.Data.IsDead && (
                    (TotalPlayerAlive <= 2 && TotalImpoAlive == 1)
                    || (TotalPlayerAlive <= 4 && TotalImpoAlive == 2)
                    || (TotalPlayerAlive <= 6 && TotalImpoAlive == 3)
                   )
                   )
                {
                    Outlaw.canKill = true;
                }

                

                if (Eater.Role != null && ChallengerMod.Set.Data.EaterTask == Eatervaluewin)
                {
                    Eater.Win = true;
                }
                else
                {
                    Eater.Win = false;
                }

                if (Outlaw_Alive == 1 && TotalImpoAlive == 0 && TotalPlayerAlive < 3)
                {
                    Outlaw.Win = true;
                }
                else
                {
                    Outlaw.Win = false;
                }


                if (Arsonist.Role != null)
                {
                    foreach (PlayerControl PlayerDoozed in OiledPlayers)
                    {
                        if (!PlayerDoozed.Data.IsDead && !PlayerDoozed.Data.Disconnected)
                        {
                            var Data = OiledPlayers.ToArray();
                            var Count = Data.Count(x => !x.Data.Disconnected && !x.Data.IsDead);

                            if (Count >= TotalPlayerAlive - 1)
                            {
                                Arsonist.CanBurn = true;
                            }
                        }
                    }
                    foreach (PlayerControl PlayerOiled in OiledPlayers)
                    {
                        if (!PlayerOiled.Data.IsDead && !PlayerOiled.Data.Disconnected)
                        {
                            var Data = OiledPlayers.ToArray();
                            var Count = Data.Count(x => !x.Data.Disconnected && !x.Data.IsDead);

                            TotalPlayerOil = Count;
                        }
                    }
                }
               

                

                //SET_EVENT

                //LOBBY SURVEY
                if (ChallengerMod.Challenger.SetAdminTimeOn == true && AdminTimeOn.getSelection() != 0)
                    TimerAdminOn(true);
                if (Minigame.Instance && ChallengerMod.Challenger.SetVitalTimeOn == true && VitalTimeOn.getSelection() != 0)
                    TimerVitalOn(true);
                if (Minigame.Instance && ChallengerMod.Challenger.SetCamTimeOn == true && CamTimeOn.getSelection() != 0)
                    TimerCamOn(true);
                if (ChallengerMod.Challenger.SetNuclearTimeOn == true && NuclearMap == true && !StartSabNuclear && BetterMapPL.getSelection() == 2)
                    TimerNuclearOn(true);
                if (ChallengerMod.Challenger.SetNuclearSabTimeOn == true && NuclearMap == true && !StartNuclear && BetterMapPL.getSelection() == 2)
                    TimerNuclearSabOn(true);



                if (!Minigame.Instance && ChallengerMod.Challenger.SetVitalTimeOn == true) // Fix Timer
                {
                    ChallengerMod.Challenger.SetVitalTimeOn = false;
                }
                if (!Minigame.Instance && ChallengerMod.Challenger.SetCamTimeOn == true)
                {
                    ChallengerMod.Challenger.SetCamTimeOn = false;
                }



                //CULTE
                if (Cultist.Role != null && Cultist.Culte1 != null && CulteTaskAssigned == false && PlayerControl.LocalPlayer == Cultist.Culte1)
                    AssignCulte1Task(true);
                if (Cultist.Role != null && Cultist.Culte2 != null && CulteTaskAssigned == false && PlayerControl.LocalPlayer == Cultist.Culte2)
                    AssignCulte2Task(true);
                if (Cultist.Role != null && Cultist.Culte3 != null && CulteTaskAssigned == false && PlayerControl.LocalPlayer == Cultist.Culte3)
                    AssignCulte3Task(true);
                
                //CUPID
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && loveTaskAssigned == false && PlayerControl.LocalPlayer == Cupid.Role)
                    AssignLove0Task(true);
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && loveTaskAssigned == false && PlayerControl.LocalPlayer == Cupid.Lover1)
                    AssignLove1Task(true);
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && loveTaskAssigned == false && PlayerControl.LocalPlayer == Cupid.Lover2)
                    AssignLove2Task(true);


                //MASTER
                if (Slave.Role != null && Slave.Master != null && MasterTaskAssigned == false && PlayerControl.LocalPlayer == Slave.Master)
                    AssignMasterTask(true);

                //COPYCAT_COPY
                if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyTaskAssigned == false  && CopyCat.CopiedPlayer.Data.IsDead && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role)
                    AssignCopyTask(true);
                
                //OUTLAW
                if (Outlaw.Role != null && Outlaw.canKill && OutlawCanKill == false && PlayerControl.LocalPlayer == Outlaw.Role)
                    TheOutlawCanKill(true);

                if ((ChallengerMod.Challenger.GameStarted <= 0f) && Challenger.RoleAssigned)
                {


                    //SHERIFF
                    if (Sheriff1.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Sheriff1.Role)
                        AssignSheriff1Task(true);
                    //SHERIFF
                    if (Sheriff2.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Sheriff2.Role)
                        AssignSheriff2Task(true);
                    //SHERIFF
                    if (Sheriff3.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Sheriff3.Role)
                        AssignSheriff3Task(true);
                    //Guardian
                    if (Guardian.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Guardian.Role)
                        AssignGuardianTask(true);
                    //Engineer
                    if (Engineer.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Engineer.Role)
                        AssignEngineerTask(true);
                    //Timelord
                    if (Timelord.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Timelord.Role)
                        AssignTimelordTask(true);
                    //Hunter
                    if (Hunter.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Hunter.Role)
                        AssignHunterTask(true);
                    //Mystic
                    if (Mystic.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Mystic.Role)
                        AssignMysticTask(true);
                    //Spirit
                    if (Spirit.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Spirit.Role)
                        AssignSpiritTask(true);
                    //Mayor
                    if (Mayor.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Mayor.Role)
                        AssignMayorTask(true);
                    //Detective
                    if (Detective.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Detective.Role)
                        AssignDetectiveTask(true);
                    //Nightwatch
                    if (Nightwatch.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Nightwatch.Role)
                        AssignNightwatchTask(true);
                    //Spy
                    if (Spy.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Spy.Role)
                        AssignSpyTask(true);
                    //Informant
                    if (Informant.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Informant.Role)
                        AssignInformantTask(true);
                    //Bait
                    if (Bait.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Bait.Role)
                        AssignBaitTask(true);
                    //Mentalist
                    if (Mentalist.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Mentalist.Role)
                        AssignMentalistTask(true);
                    //Builder
                    if (Builder.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Builder.Role)
                        AssignBuilderTask(true);
                    //Dictator
                    if (Dictator.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Dictator.Role)
                        AssignDictatorTask(true);
                    //Sentinel
                    if (Sentinel.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Sentinel.Role)
                        AssignSentinelTask(true);
                    //Teammate1
                    if (Teammate1.Role != null && Teammate2.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Teammate1.Role)
                        AssignTeammate1Task(true);
                    //Teammate2
                    if (Teammate2.Role != null && Teammate1.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Teammate2.Role)
                        AssignTeammate2Task(true);
                    //Lawkeeper
                    if (Lawkeeper.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Lawkeeper.Role)
                        AssignLawkeeperTask(true);
                    //Fake
                    if (Fake.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Fake.Role)
                        AssignFakeTask(true);
                    //Traveler
                    if (Traveler.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Traveler.Role)
                        AssignTravelerTask(true);
                    //Leader
                    if (Leader.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Leader.Role)
                        AssignLeaderTask(true);
                    //Doctor
                    if (Doctor.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Doctor.Role)
                        AssignDoctorTask(true);
                    //Slave
                    if (Slave.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Slave.Role)
                        AssignSlaveTask(true);

                    //Mercenary
                    if (Mercenary.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Mercenary.Role)
                        AssignMercenaryTask(true);
                    //CopyCat
                    if (CopyCat.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == CopyCat.Role)
                        AssignCopyCatTask(true);
                    //Survivor
                    if (Survivor.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Survivor.Role)
                        AssignSurvivorTask(true);
                    //Revenger
                    if (Revenger.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Revenger.Role)
                        AssignRevengerTask(true);


                    //Cupid
                    if (Cupid.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Cupid.Role)
                        AssignCupidTask(true);
                    //Cultist
                    if (Cultist.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Cultist.Role)
                        AssignCultistTask(true);
                    //Outlaw
                    if (Outlaw.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Outlaw.Role)
                        AssignOutlawTask(true);
                    //Jester
                    if (Jester.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Jester.Role)
                        AssignJesterTask(true);
                    //Eater
                    if (Eater.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Eater.Role)
                        AssignEaterTask(true);
                    //Arsonist
                    if (Arsonist.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Arsonist.Role)
                        AssignArsonistTask(true);
                    //Jester
                    if (Cursed.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Cursed.Role)
                        AssignCursedTask(true);


                    //Assassin
                    if (Assassin.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Assassin.Role)
                        AssignAssassinTask(true);
                    //Vector
                    if (Vector.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Vector.Role)
                        AssignVectorTask(true);
                    //Morphling
                    if (Morphling.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Morphling.Role)
                        AssignMorphlingTask(true);
                    //Scrambler
                    if (Scrambler.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Scrambler.Role)
                        AssignScramblerTask(true);
                    //Barghest
                    if (Barghest.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Barghest.Role)
                        AssignBarghestTask(true);
                    //Ghost
                    if (Ghost.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Ghost.Role)
                        AssignGhostTask(true);
                    //Sorcerer
                    if (Sorcerer.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Sorcerer.Role)
                        AssignSorcererTask(true);
                    //Guesser
                    if (Guesser.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Guesser.Role)
                        AssignGuesserTask(true);
                    //Mesmer
                    if (Mesmer.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Mesmer.Role)
                        AssignMesmerTask(true);
                    //Basilisk
                    if (Basilisk.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Basilisk.Role)
                        AssignBasiliskTask(true);
                    //Reaper
                    if (Reaper.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Reaper.Role)
                        AssignReaperTask(true);
                    //Saboteur
                    if (Saboteur.Role != null && RoleTaskAssigned == false && PlayerControl.LocalPlayer == Saboteur.Role)
                        AssignSaboteurTask(true);


                    //SHERIFF
                    if (VentSpriteEdited == false)
                        ChangeVentSprite(true);


                    if (ResetIntroCD == false)
                        ResetIntroCooldown(true);

                    if (ResetIntroCD == true && IntroCD == false)
                        setIntroCooldown(true);

                    if (SendtoGoodloss == false)
                        SendToGoodlossServices(true);

                    


                    if (AmongUsClient.Instance.AmHost) //Syncro Timers (nuclear + CustomButton)
                    {
                        if (!ReSyncIntro)
                        {
                            ChallengerMod.Challenger.ReSyncIntroTimer -= Time.deltaTime;


                            if (ReSyncIntroTimer <= 0)
                            {
                                float Nuclear_Delay = (float)Challenger.rnd.Next((int)Challenger.NuclearTimeMin, (int)Challenger.NuclearTimeAdd);
                                NuclearTimer = Nuclear_Delay;


                                MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncTimer, Hazel.SendOption.Reliable);
                                writer.Write(ChallengerMod.Challenger.NuclearTimer);
                                writer.EndMessage();
                                RPCProcedure.syncTimer(ChallengerMod.Challenger.NuclearTimer);
                            }
                        }
                    }

                    if (PlayerControl.GameOptions.MapId == 2 && LoverEvent && !EventStarted) 
                    {
                        var SnowParticles = GameObject.Find("PolusShip(Clone)").transform.FindChild("SnowParticles");
                        if (SnowParticles != null)
                        {
                            UnityEngine.ParticleSystem SnowParticlesRend = SnowParticles.GetComponent<UnityEngine.ParticleSystem>();
                            SnowParticlesRend.startColor = CupidColor;
                            EventStarted = true;
                        }
                        ColorIDSave_ToCom = 3;
                        ColorIDSave_ToScrambler = 13;
                        EventStarted = true;

                        
                    }
                    else if (!EventStarted)
                    {
                        ColorIDSave_ToCom = 6;
                        ColorIDSave_ToScrambler = 7;
                        EventStarted = true;
                    }


                }
                if (PlayerControl.GameOptions.MapId == 2 && NuclearMap == true)
                {


                    if ((NuclearTimer <= 0f))
                    {
                        
                        HudManager.Instance.FullScreen.gameObject.SetActive(true);
                        HudManager.Instance.FullScreen.enabled = true;
                        
                        if (!StartNuclear && !Timelord.TimeStopped && NuclearLastTimer > 0.5f)
                        {
                            HudManager.Instance.FullScreen.color = new Color(0.5f, 0.5f, 0f, 0.15f);
                        }
                        

                        if (!Timelord.TimeStopped && !StartNuclear && MeetingHud.Instance == null)
                        {
                            SetNuclearTimeOn = false;
                            SetNuclearSabTimeOn = true;
                        }
                        else
                        {
                            SetNuclearTimeOn = false;
                            SetNuclearSabTimeOn = false;

                        }
                        

                        if (!StartSabNuclear)
                        {
                             
                            //RPC
                            foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                            {
                                if (task.TaskType == TaskTypes.FixLights)
                                {
                                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.EngineerFixLight, Hazel.SendOption.Reliable, -1);
                                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                                    RPCProcedure.engineerFixLight();
                                }
                                else if (task.TaskType == TaskTypes.RestoreOxy)
                                {
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 0 | 64);
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 1 | 64);
                                }
                                else if (task.TaskType == TaskTypes.ResetReactor)
                                {
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16);
                                }
                                else if (task.TaskType == TaskTypes.ResetSeismic)
                                {
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 16);
                                }
                                else if (task.TaskType == TaskTypes.FixComms)
                                {
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 0);
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 1);
                                }
                                else if (task.TaskType == TaskTypes.StopCharles)
                                {
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 0 | 16);
                                    ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 1 | 16);
                                }
                            }
                                SoundManager.Instance.PlaySound(ALN, false, 100f);
                            
                            EmergencyDestroy = true;
                            StartSabNuclear = true;
                        }
                        if (NuclearLastTimer > 0f && NuclearLastTimer < 1.15f)
                        {
                            ShipStatus.Instance.RpcCloseDoorsOfType(SystemTypes.Office);
                            ShipStatus.Instance.RpcCloseDoorsOfType(SystemTypes.Admin);
                            ShipStatus.Instance.RpcCloseDoorsOfType(SystemTypes.Decontamination);
                            ShipStatus.Instance.RpcCloseDoorsOfType(SystemTypes.Decontamination2);
                            ShipStatus.Instance.RpcCloseDoorsOfType(SystemTypes.Decontamination3);
                            SetNuclearSabTimeOn = true;
                        }
                        if ((NuclearLastTimer <= 0f))
                        {
                            if (!StartNuclear)
                            {
                                //genmap
                                //RPC
                                if (ChallengerMod.Challenger.SafeTimer <= 0) 
                                {
                                    byte Player = 0;

                                    Player = PlayerControl.LocalPlayer.PlayerId;
                                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncDie, Hazel.SendOption.Reliable, -1);
                                    writer.Write(Player);
                                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                                    RPCProcedure.syncDie(Player);
                                }

                                ChallengerOS.Utils.Helpers.showFlash(new Color(255f / 255f, 255f / 255f, 255f / 255f), 4f);
                                HudManager.Instance.FullScreen.color = new Color(0, 0f, 0f, 0f);
                                SoundManager.Instance.StopSound(ALN);
                                SoundManager.Instance.PlaySound(Burned, false, 100f); 

                                //GEN Winter Nuclear particle
                                var SnowParticles = GameObject.Find("PolusShip(Clone)").transform.FindChild("SnowParticles");
                                if (SnowParticles != null)
                                {
                                    UnityEngine.ParticleSystem SnowParticlesRend = SnowParticles.GetComponent<UnityEngine.ParticleSystem>();
                                    SnowParticlesRend.startColor = blackColor;
                                    //SnowParticlesRend.startColor = PurpleColor;

                                }
                                IsMapPolusV2 = true;
                                EmergencyDestroy = false;
                                SetNuclearSabTimeOn = false;
                                SetNuclearTimeOn = false;
                                StartNuclear = true;
                                
                            }
                        }
                    }
                    else
                    {
                        if (!Timelord.TimeStopped && MeetingHud.Instance == null)
                        {
                            SetNuclearTimeOn = true;
                        }
                        else
                        {
                            SetNuclearTimeOn = false;
                        }
                    }
                }

               
               /* var SnowParticles = GameObject.Find("PolusShip(Clone)").transform.FindChild("SnowParticles");
                if (SnowParticles != null)
                {
                    UnityEngine.ParticleSystemRenderer SnowParticlesRend = SnowParticles.GetComponent<UnityEngine.ParticleSystemRenderer>();
                    SnowParticlesRend.sharedMaterial = Material.;
                    //SnowParticlesRend.startColor = PurpleColor;

                }*/

                //SAVE NO SAB with nuclear timer
                if (EmergencyDestroy)
                {
                    foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                    {
                        if (task.TaskType == TaskTypes.FixLights)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.EngineerFixLight, Hazel.SendOption.Reliable, -1);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            RPCProcedure.engineerFixLight();
                        }
                        else if (task.TaskType == TaskTypes.RestoreOxy)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 0 | 64);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 1 | 64);
                        }
                        else if (task.TaskType == TaskTypes.ResetReactor)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16);
                        }
                        else if (task.TaskType == TaskTypes.ResetSeismic)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 16);
                        }
                        else if (task.TaskType == TaskTypes.FixComms)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 0);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 1);
                        }
                        else if (task.TaskType == TaskTypes.StopCharles)
                        {
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 0 | 16);
                            ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 1 | 16);
                        }
                    }
                }
                if (Basilisk.Role != null)
                {
                    if (!GameObject.Find("PetrifySprite"))
                    {
                        ChallengerMod.Utility.Utils.SpriteAnimUtils.StartPetrify(Unity.PetrifyAnim, Challenger.PetrifyPosition, 0.17f, 0.58f);
                    }
                    else
                    {
                        if (!MeetingHud.Instance)
                        {
                            var PetrifyNewposition = GameObject.Find("PetrifySprite");
                            PetrifyNewposition.transform.position = Challenger.PetrifyPositionIni;
                        }
                    }
                }

                if (PlayerControl.LocalPlayer.Data.IsDead && Challenger.ResetAllPlayersSkin == false)
                    ResetSpritesIfPlayerDie(true);

                //RESET RPC If KILLED DURING EFFECT
                if (Spy.Role != null && Spy.Use && Spy.Role.Data.IsDead && PlayerControl.LocalPlayer == Spy.Role)
                {
                    RPCProcedure.spyOff();
                }
                if (CopyCat.Role != null && CopyCat.copyRole == 11 && CopyCat.CopyStart && Spy.Use && CopyCat.Role.Data.IsDead && PlayerControl.LocalPlayer == CopyCat.Role)
                {
                    RPCProcedure.spyOff();
                }
                if (Timelord.Role != null && Timelord.Role.Data.IsDead && Timelord.TimeLordStopTime)
                {
                   RPCProcedure.timeStop_End();
                }
                if (Assassin.Role != null && Assassin.Role.Data.IsDead && Timelord.AssassinStopTime)
                {
                    RPCProcedure.timeStop_End();
                }
                if (CopyCat.Role != null && CopyCat.Role.Data.IsDead && Timelord.CopyCatStopTime)
                {
                    RPCProcedure.timeStop_End();
                }

                if (Barghest.Role != null && Barghest.Shadow && Barghest.Role.Data.IsDead)
                {
                    RPCProcedure.shadowOff();
                }
                if (Scrambler.Role != null && Scrambler.Camo && Scrambler.Role.Data.IsDead)
                {
                    RPCProcedure.camoOff();
                }
                if (Morphling.Role != null && Morphling.Morph != null && Morphling.Morphed && Morphling.Morph.Data.IsDead)
                {
                    RPCProcedure.morphOff();
                    ResetMorph(true);
                }
                  if (SafeTimer <= 0) { debugg1 = "DIE"; }
                  else { debugg1 = "SAFE"; }

                if (/*EmergencyDestroy &&*/ !PlayerControl.LocalPlayer.Data.IsDead)
                    GoSafeTimer(true);




                





                //GUARDIAN
                if (Guardian.Protected != null && Guardian.Role == null && CopyCat.Role == null)
                    breakShield(true);

                if (Jester.Role != null && Jester.Exiled && !Jester.Win)
                    goWinJester(true);

                

                if (Guardian.Protected != null && Guardian.Protected.Data.IsDead)
                    breakShield(true);


                if (Guardian.Protected != null && Guardian.Role != null && Guardian.Role.Data.IsDead && CopyCat.Role == null)
                    breakShield(true);
                if (Guardian.Protected != null && Guardian.Role != null && Guardian.Role.Data.IsDead && CopyCat.Role != null && CopyCat.copyRole == 2 && CopyCat.Role.Data.IsDead && CopyCat.CopyStart)
                    breakShield(true);
                if (Guardian.Protected != null && Guardian.Role != null && Guardian.Role.Data.IsDead && CopyCat.Role != null && CopyCat.copyRole != 2)
                    breakShield(true);


                if (Guardian.Role == null && Guardian.Protected != null && CopyCat.Role != null && CopyCat.copyRole == 2 && CopyCat.Role.Data.IsDead && CopyCat.CopyStart)
                    breakShield(true);
                if (Guardian.Role == null && Guardian.Protected != null && CopyCat.Role != null && CopyCat.copyRole != 2)
                    breakShield(true);


                if (Mystic.Role != null && Guardian.ProtectedMystic != null && !Mystic.Role.Data.IsDead)
                    setDoubleShield(true);

                if (Mystic.Role != null && Guardian.ProtectedMystic != null && Mystic.Role.Data.IsDead && !Mystic.ClearDoubleShield)
                    clearDoubleShield(true);

                if (CopyCat.Role != null && Mystic.Role != null && Mystic.Role.Data.IsDead && Guardian.Protected != null && Guardian.ProtectedMystic == null && CopyCat.copyRole == 6 && CopyCat.CopyStart && Guardian.Protected.PlayerId == CopyCat.Role.PlayerId)
                    ConvertDoubleShield(true);
                
                if (CopyCat.Role != null && Guardian.ProtectedMystic != null && CopyCat.copyRole == 6 && CopyCat.CopyStart && !CopyCat.Role.Data.IsDead)
                    setDoubleShield(true);



                //HUNTER
                if (Hunter.Role != null && Hunter.Tracked != null && Hunter.Role.Data.IsDead && !Hunter.Tracked.Data.IsDead && PlayerControl.LocalPlayer == Hunter.Tracked)
                    killTrack(true);
                if (Hunter.Role != null && Hunter.Tracked != null && !Hunter.Role.Data.IsDead && Hunter.Tracked.Data.IsDead)
                    updateTrack(true);
                if (Hunter.Tracked == null && ChallengerOS.Utils.Option.CustomOptionHolder.ResetTrack.getBool() == true)
                    resetTrack(true);

                if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && Hunter.CopyTracked != null && CopyCat.Role.Data.IsDead && !Hunter.CopyTracked.Data.IsDead && PlayerControl.LocalPlayer == Hunter.CopyTracked)
                    killCopyTrack(true);
                if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && Hunter.CopyTracked != null && !CopyCat.Role.Data.IsDead && Hunter.CopyTracked.Data.IsDead)
                    updateCopyTrack(true);
                if (Hunter.CopyTracked == null && ChallengerOS.Utils.Option.CustomOptionHolder.ResetTrack.getBool() == true)
                    resetCopyTrack(true);


                //BAIT
                if (Bait.Role != null && Bait.BaliseData == true)
                    BaitBaliseEnable(true);
                
                if (Bait.StunsPlayer)
                    stunned(true);

                if (Bait.StunsPlayer && Bait.ResetStunsPlayer)
                    resetstunned(true);

                //CUPID
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && !Cupid.Lover1.Data.IsDead && Cupid.Lover2.Data.IsDead && PlayerControl.LocalPlayer == Cupid.Lover1 && Loverdie.getBool() == true)
                    killLover1(true);
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && !Cupid.Lover2.Data.IsDead && Cupid.Lover1.Data.IsDead && PlayerControl.LocalPlayer == Cupid.Lover2 && Loverdie.getBool() == true)
                    killLover2(true);
                
                if (Cupid.Role != null && Cupid.Lover1 != null && Cupid.Lover2 != null && (Cupid.Lover1.Data.IsDead || Cupid.Lover2.Data.IsDead) && !Cupid.SpecialWin && Loverdie.getBool() == false)
                    cupidLoose(true);

                //ARSONIST
                if (Arsonist.Role != null && Arsonist.Oiled != null && PlayerControl.LocalPlayer == Arsonist.Oiled)
                    OiledUI(true);

                //CULTIST
                if (Cultist.Role != null && Cultist.CulteTargetFail && Cultistdie.getSelection() == 1 && (PlayerControl.LocalPlayer == Cultist.Role) && !Cultist.Role.Data.IsDead)
                    CultistDieNow(true);

                //COPYCAT
                if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && !CopyCat.Role.Data.IsDead && !CopyCat.CopyCatDie && !CopyCat.CopyStart)
                    CopyStart(true);
                
                if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && !CopyCat.Role.Data.IsDead && CopyCat.CopyCatDie && PlayerControl.LocalPlayer == CopyCat.Role)
                    CopyDie(true);
                
                if (CopyCat.Role != null && CopyCat.CopiedPlayer != null && CopyCat.CopiedPlayer.Data.IsDead && !CopyCat.Role.Data.IsDead && !CopyCat.CopyCatDie && CopyCat.copyRole == 25)
                    CopyImpostor(true);


                //REVENGER
                if (Revenger.Role != null && Revenger.Role.Data.IsDead && !Revenger.Exiled)
                    RevengerKill(true);

                if (Revenger.Role != null && Revenger.Role.Data.IsDead && Revenger.Exiled)
                    RevengerExil(true);

                if (Revenger.Role != null && Revenger.Role.Data.IsDead && Revenger.AllEMP_Exil && Revenger.isImpostor && !PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                    DisabledAllCrewmates(true);

                if (Revenger.Role != null && Revenger.Role.Data.IsDead && Revenger.AllEMP_Kill && Revenger.isCrewmate && PlayerControl.LocalPlayer.Data.Role.IsImpostor)
                    DisabledAllImpostors(true);

                if (Revenger.Role != null && Revenger.EMP1 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Kill && Revenger.isCrewmate && Revenger.EMP1.Data.Role.IsImpostor)
                    DisableImpo1(true);

                if (Revenger.Role != null && Revenger.EMP2 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Kill && Revenger.isCrewmate && Revenger.EMP2.Data.Role.IsImpostor)
                    DisableImpo2(true);

                if (Revenger.Role != null && Revenger.EMP3 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Kill && Revenger.isCrewmate && Revenger.EMP3.Data.Role.IsImpostor)
                    DisableImpo3(true);

                if (Revenger.Role != null && Revenger.EMP1 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Exil && Revenger.isImpostor && !Revenger.EMP1.Data.Role.IsImpostor)
                    DisableCrew1(true);

                if (Revenger.Role != null && Revenger.EMP2 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Exil && Revenger.isImpostor && !Revenger.EMP2.Data.Role.IsImpostor)
                    DisableCrew2(true);

                if (Revenger.Role != null && Revenger.EMP3 != null && Revenger.Role.Data.IsDead && !Revenger.AllEMP_Exil && Revenger.isImpostor && !Revenger.EMP3.Data.Role.IsImpostor)
                    DisableCrew3(true);


                //SORCERER

                if (Sorcerer.Role != null && Sorcerer.LootValue1 && !Sorcerer.LootAttrValue1 && PlayerControl.LocalPlayer == Sorcerer.Role)
                    IncRune1(true);

                if (Sorcerer.Role != null && Sorcerer.LootValue2 && !Sorcerer.LootAttrValue2 && PlayerControl.LocalPlayer == Sorcerer.Role)
                    IncRune2(true);

                if (Sorcerer.Role != null && Sorcerer.LootValue3 && !Sorcerer.LootAttrValue3 && PlayerControl.LocalPlayer == Sorcerer.Role)
                    IncRune3(true);

                if (Sorcerer.Role != null && Sorcerer.LootValue4 && !Sorcerer.LootAttrValue4 && PlayerControl.LocalPlayer == Sorcerer.Role)
                    IncRune4(true);

                if (Sorcerer.Role != null && Sorcerer.Exterminated != null && !Sorcerer.Exterminated.Data.IsDead) 
                    Exterminated(true);


                //VECTOR
                if (Vector.Role != null && Vector.Infected != null && Vector.Role.Data.IsDead)
                    ClearInfected(true);
                if (Vector.Role != null && Vector.Infected != null && Vector.Infected.Data.IsDead)
                    ClearInfected(true);
                
                if (Vector.Reset)
                    VectorReset(true);

                if (Vector.Role != null && Vector.Infected != null && PlayerControl.LocalPlayer == Vector.Infected)
                    IsInfected(true);

                //ASSASSIN
                if (Assassin.Role != null && Assassin.StealShield == true)
                    AssassinStealShield(true);

                //LIST LAWKEEPER

                string List1 = " ";
                string List2 = " ";

                if (List1 == " ")
                {
                    if (playerById(0) != null)
                    {
                        List1 += " " + (playerById(0).Data.PlayerName);
                    }
                    if (playerById(2) != null)
                    {
                        List1 += " " + (playerById(2).Data.PlayerName);
                    }
                    if (playerById(4) != null)
                    {
                        List1 += " " + (playerById(4).Data.PlayerName);
                    }
                    if (playerById(6) != null)
                    {
                        List1 += " " + (playerById(6).Data.PlayerName);
                    }
                    if (playerById(8) != null)
                    {
                        List1 += " " + (playerById(8).Data.PlayerName);
                    }
                    if (playerById(10) != null)
                    {
                        List1 += " " + (playerById(10).Data.PlayerName);
                    }
                    if (playerById(12) != null)
                    {
                        List1 += " " + (playerById(12).Data.PlayerName);
                    }
                    if (playerById(14) != null)
                    {
                        List1 += " " + (playerById(14).Data.PlayerName);
                    }
                    STR_List1 = List1;

                }
                if (List2 == " ")
                {
                    if (playerById(1) != null)
                    {
                        List2 += " " + (playerById(1).Data.PlayerName);
                    }

                    if (playerById(3) != null)
                    {
                        List2 += " " + (playerById(3).Data.PlayerName);
                    }

                    if (playerById(5) != null)
                    {
                        List2 += " " + (playerById(5).Data.PlayerName);
                    }

                    if (playerById(7) != null)
                    {
                        List2 += " " + (playerById(7).Data.PlayerName);
                    }

                    if (playerById(9) != null)
                    {
                        List2 += " " + (playerById(9).Data.PlayerName);
                    }

                    if (playerById(11) != null)
                    {
                        List2 += " " + (playerById(11).Data.PlayerName);
                    }

                    if (playerById(13) != null)
                    {
                        List2 += " " + (playerById(13).Data.PlayerName);
                    }
                    STR_List2 = List2;

                }



                //STR_VAR_ROLE

                //CUPID
                string STR_Lover1_Name = "";
                string STR_Lover2_Name = "";
                string STR_Lovers_Name = "";


                if (Cupid.Role != null)
                {
                    if (Cupid.Lover1 != null)
                    {
                        STR_Lover1_Name = Cupid.Lover1.Data.PlayerName;
                    }
                    if (Cupid.Lover2 != null)
                    {
                        STR_Lover2_Name = Cupid.Lover2.Data.PlayerName;
                    }
                    if (Cupid.Lover1 != null && Cupid.Lover2 != null && Cupid.LoveUsed)
                    {
                        STR_Lovers_Name = "" + STR_Lover1_Name + "\n" + STR_Lover2_Name + "";
                    }
                }
                if (STR_LOVERS != STR_Lovers_Name)
                {
                    STR_LOVERS = STR_Lovers_Name;
                }

                string STR_Morphed_Name = "";

                if (Morphling.Role != null)
                {
                    if (Morphling.Morph != null)
                    {
                        STR_Morphed_Name = Morphling.Morph.Data.PlayerName;
                    }
                    else
                    {
                        STR_Morphed_Name = Morphling.Role.Data.PlayerName;
                    }
                }
                if (STR_MORPH != STR_Morphed_Name)
                {
                    STR_MORPH = STR_Morphed_Name;
                }

                //SORCERER
                string STR_Sorcerer_Scan1 = "-";
                string STR_Sorcerer_Scan2 = "-";

                if (STR_Sorcerer_Scan1 == "-")
                {
                    if (Sorcerer.Scan1 != null)
                    {
                        if (Sorcerer.SetScan1 == 1)
                        {
                            STR_Sorcerer_Scan1 =  R_SheriffColor + "\n(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 2)
                        {
                            STR_Sorcerer_Scan1 =  R_GuardianColor + "\n(" + ChallengerMod.Set.Data.Role_Guardian + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 3)
                        {
                            STR_Sorcerer_Scan1 =  R_EngineerColor + "\n(" + ChallengerMod.Set.Data.Role_Engineer + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 4)
                        {
                            STR_Sorcerer_Scan1 =  R_TimelordColor + "\n(" + ChallengerMod.Set.Data.Role_Timelord + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 5)
                        {
                            STR_Sorcerer_Scan1 =  R_HunterColor + "\n(" + ChallengerMod.Set.Data.Role_Hunter + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 6)
                        {
                            STR_Sorcerer_Scan1 =  R_MysticColor + "\n(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 7)
                        {
                            STR_Sorcerer_Scan1 =  R_SpiritColor + "\n(" + ChallengerMod.Set.Data.Role_Spirit + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 8)
                        {
                            STR_Sorcerer_Scan1 =  R_MayorColor + "\n(" + ChallengerMod.Set.Data.Role_Mayor + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 9)
                        {
                            STR_Sorcerer_Scan1 =  R_DetectiveColor + "\n(" + ChallengerMod.Set.Data.Role_Detective + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 10)
                        {
                            STR_Sorcerer_Scan1 =  R_NightwatchColor + "\n(" + ChallengerMod.Set.Data.Role_Nightwatch + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 11)
                        {
                            STR_Sorcerer_Scan1 =  R_SpyColor + "\n(" + ChallengerMod.Set.Data.Role_Spy + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 12)
                        {
                            STR_Sorcerer_Scan1 =  R_InformantColor + "\n(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 13)
                        {
                            STR_Sorcerer_Scan1 =  R_BaitColor + "\n(" + ChallengerMod.Set.Data.Role_Bait + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 14)
                        {
                            STR_Sorcerer_Scan1 =  R_MentalistColor + "\n(" + ChallengerMod.Set.Data.Role_Mentalist + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 15)
                        {
                            STR_Sorcerer_Scan1 =  R_BuilderColor + "\n(" + ChallengerMod.Set.Data.Role_Builder + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 16)
                        {
                            STR_Sorcerer_Scan1 =  R_DictatorColor + "\n(" + ChallengerMod.Set.Data.Role_Dictator + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 17)
                        {
                            STR_Sorcerer_Scan1 =  R_SentinelColor + "\n(" + ChallengerMod.Set.Data.Role_Sentinel + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 18)
                        {
                            STR_Sorcerer_Scan1 =  R_CrewmateColor + "\n(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 19)
                        {
                            STR_Sorcerer_Scan1 =  R_LawkeeperColor + "\n(" + ChallengerMod.Set.Data.Role_Lawkeeper + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 20)
                        {
                            STR_Sorcerer_Scan1 =  R_FakeColor + "\n(" + ChallengerMod.Set.Data.Role_Fake + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 21)
                        {
                            STR_Sorcerer_Scan1 =  R_TravelerColor + "\n(" + ChallengerMod.Set.Data.Role_Traveler + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 22)
                        {
                            STR_Sorcerer_Scan1 =  R_LeaderColor + "\n(" + ChallengerMod.Set.Data.Role_Leader + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 23)
                        {
                            STR_Sorcerer_Scan1 =  R_DoctorColor + "\n(" + ChallengerMod.Set.Data.Role_Doctor + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 24)
                        {
                            STR_Sorcerer_Scan1 =  R_SlaveColor + "\n(" + ChallengerMod.Set.Data.Role_Slave + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 25)
                        {
                            STR_Sorcerer_Scan1 =  R_CupidColor+ "\n(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 26)
                        {
                            STR_Sorcerer_Scan1 = R_CulteColor + "\n(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 27)
                        {
                            STR_Sorcerer_Scan1 = R_OutlawColor + "\n(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 28)
                        {
                            STR_Sorcerer_Scan1 = R_JesterColor + "\n(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 29)
                        {
                            STR_Sorcerer_Scan1 = R_EaterColor + "\n(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 30)
                        {
                            STR_Sorcerer_Scan1 = R_ArsonistColor + "\n(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 31)
                        {
                            STR_Sorcerer_Scan1 = R_MercenaryColor + "\n(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 32)
                        {
                            STR_Sorcerer_Scan1 = R_CopyCatColor + "\n(" + ChallengerMod.Set.Data.Role_CopyCat + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 33)
                        {
                            STR_Sorcerer_Scan1 = R_SurvivorColor + "\n(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 34)
                        {
                            STR_Sorcerer_Scan1 = R_RevengerColor + "\n(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 35)
                        {
                            STR_Sorcerer_Scan1 = R_AssassinColor + "\n(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 36)
                        {
                            STR_Sorcerer_Scan1 = R_VectorColor + "\n(" + ChallengerMod.Set.Data.Role_Vector + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 37)
                        {
                            STR_Sorcerer_Scan1 = R_MorphlingColor + "\n(" + ChallengerMod.Set.Data.Role_Morphling + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 38)
                        {
                            STR_Sorcerer_Scan1 = R_ScramblerColor + "\n(" + ChallengerMod.Set.Data.Role_Scrambler + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 39)
                        {
                            STR_Sorcerer_Scan1 = R_BarghestColor + "\n(" + ChallengerMod.Set.Data.Role_Barghest + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 40)
                        {
                            STR_Sorcerer_Scan1 = R_GhostColor + "\n(" + ChallengerMod.Set.Data.Role_Ghost + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 41)
                        {
                            STR_Sorcerer_Scan1 = R_GuesserColor + "\n(" + ChallengerMod.Set.Data.Role_Guesser + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 42)
                        {
                            STR_Sorcerer_Scan1 = R_MesmerColor + "\n(" + ChallengerMod.Set.Data.Role_Mesmer + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 43)
                        {
                            STR_Sorcerer_Scan1 = R_BasiliskColor + "\n(" + ChallengerMod.Set.Data.Role_Basilisk + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 44)
                        {
                            STR_Sorcerer_Scan1 = R_ReaperColor + "\n(" + ChallengerMod.Set.Data.Role_Reaper + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 45)
                        {
                            STR_Sorcerer_Scan1 = R_SaboteurColor + "\n(" + ChallengerMod.Set.Data.Role_Saboteur + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 46)
                        {
                            STR_Sorcerer_Scan1 = R_CrewmateColor + "\n(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 47)
                        {
                            STR_Sorcerer_Scan1 = R_ImpostorColor + "\n(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC;
                        }
                        if (Sorcerer.SetScan1 == 48)
                        {
                            STR_Sorcerer_Scan1 = R_CursedColor + "\n(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC;
                        }
                    }
                }
                if (STR_Sorcerer_Scan2 == "-")
                {
                    if (Sorcerer.Scan2 != null)
                    {
                        if (Sorcerer.SetScan2 == 1)
                        {
                            STR_Sorcerer_Scan2 = R_SheriffColor + "\n(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 2)
                        {
                            STR_Sorcerer_Scan2 = R_GuardianColor + "\n(" + ChallengerMod.Set.Data.Role_Guardian + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 3)
                        {
                            STR_Sorcerer_Scan2 = R_EngineerColor + "\n(" + ChallengerMod.Set.Data.Role_Engineer + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 4)
                        {
                            STR_Sorcerer_Scan2 = R_TimelordColor + "\n(" + ChallengerMod.Set.Data.Role_Timelord + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 5)
                        {
                            STR_Sorcerer_Scan2 = R_HunterColor + "\n(" + ChallengerMod.Set.Data.Role_Hunter + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 6)
                        {
                            STR_Sorcerer_Scan2 = R_MysticColor + "\n(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 7)
                        {
                            STR_Sorcerer_Scan2 = R_SpiritColor + "\n(" + ChallengerMod.Set.Data.Role_Spirit + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 8)
                        {
                            STR_Sorcerer_Scan2 = R_MayorColor + "\n(" + ChallengerMod.Set.Data.Role_Mayor + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 9)
                        {
                            STR_Sorcerer_Scan2 = R_DetectiveColor + "\n(" + ChallengerMod.Set.Data.Role_Detective + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 10)
                        {
                            STR_Sorcerer_Scan2 = R_NightwatchColor + "\n(" + ChallengerMod.Set.Data.Role_Nightwatch + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 11)
                        {
                            STR_Sorcerer_Scan2 = R_SpyColor + "\n(" + ChallengerMod.Set.Data.Role_Spy + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 12)
                        {
                            STR_Sorcerer_Scan2 = R_InformantColor + "\n(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 13)
                        {
                            STR_Sorcerer_Scan2 = R_BaitColor + "\n(" + ChallengerMod.Set.Data.Role_Bait + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 14)
                        {
                            STR_Sorcerer_Scan2 = R_MentalistColor + "\n(" + ChallengerMod.Set.Data.Role_Mentalist + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 15)
                        {
                            STR_Sorcerer_Scan2 = R_BuilderColor + "\n(" + ChallengerMod.Set.Data.Role_Builder + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 16)
                        {
                            STR_Sorcerer_Scan2 = R_DictatorColor + "\n(" + ChallengerMod.Set.Data.Role_Dictator + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 17)
                        {
                            STR_Sorcerer_Scan2 = R_SentinelColor + "\n(" + ChallengerMod.Set.Data.Role_Sentinel + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 18)
                        {
                            STR_Sorcerer_Scan2 = R_CrewmateColor + "\n(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 19)
                        {
                            STR_Sorcerer_Scan2 = R_LawkeeperColor + "\n(" + ChallengerMod.Set.Data.Role_Lawkeeper + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 20)
                        {
                            STR_Sorcerer_Scan2 = R_FakeColor + "\n(" + ChallengerMod.Set.Data.Role_Fake + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 21)
                        {
                            STR_Sorcerer_Scan2 = R_TravelerColor + "\n(" + ChallengerMod.Set.Data.Role_Traveler + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 22)
                        {
                            STR_Sorcerer_Scan2 = R_LeaderColor + "\n(" + ChallengerMod.Set.Data.Role_Leader + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 23)
                        {
                            STR_Sorcerer_Scan2 = R_DoctorColor + "\n(" + ChallengerMod.Set.Data.Role_Doctor + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 24)
                        {
                            STR_Sorcerer_Scan2 = R_SlaveColor + "\n(" + ChallengerMod.Set.Data.Role_Slave + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 25)
                        {
                            STR_Sorcerer_Scan2 = R_CupidColor + "\n(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 26)
                        {
                            STR_Sorcerer_Scan2 = R_CulteColor + "\n(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 27)
                        {
                            STR_Sorcerer_Scan2 = R_OutlawColor + "\n(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 28)
                        {
                            STR_Sorcerer_Scan2 = R_JesterColor + "\n(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 29)
                        {
                            STR_Sorcerer_Scan2 = R_EaterColor + "\n(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 30)
                        {
                            STR_Sorcerer_Scan2 = R_ArsonistColor + "\n(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 31)
                        {
                            STR_Sorcerer_Scan2 = R_MercenaryColor + "\n(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 32)
                        {
                            STR_Sorcerer_Scan2 = R_CopyCatColor + "\n(" + ChallengerMod.Set.Data.Role_CopyCat + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 33)
                        {
                            STR_Sorcerer_Scan2 = R_SurvivorColor + "\n(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 34)
                        {
                            STR_Sorcerer_Scan2 = R_RevengerColor + "\n(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 35)
                        {
                            STR_Sorcerer_Scan2 = R_AssassinColor + "\n(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 36)
                        {
                            STR_Sorcerer_Scan2 = R_VectorColor + "\n(" + ChallengerMod.Set.Data.Role_Vector + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 37)
                        {
                            STR_Sorcerer_Scan2 = R_MorphlingColor + "\n(" + ChallengerMod.Set.Data.Role_Morphling + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 38)
                        {
                            STR_Sorcerer_Scan2 = R_ScramblerColor + "\n(" + ChallengerMod.Set.Data.Role_Scrambler + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 39)
                        {
                            STR_Sorcerer_Scan2 = R_BarghestColor + "\n(" + ChallengerMod.Set.Data.Role_Barghest + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 40)
                        {
                            STR_Sorcerer_Scan2 = R_GhostColor + "\n(" + ChallengerMod.Set.Data.Role_Ghost + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 41)
                        {
                            STR_Sorcerer_Scan2 = R_GuesserColor + "\n(" + ChallengerMod.Set.Data.Role_Guesser + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 42)
                        {
                            STR_Sorcerer_Scan2 = R_MesmerColor + "\n(" + ChallengerMod.Set.Data.Role_Mesmer + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 43)
                        {
                            STR_Sorcerer_Scan2 = R_BasiliskColor + "\n(" + ChallengerMod.Set.Data.Role_Basilisk + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 44)
                        {
                            STR_Sorcerer_Scan2 = R_ReaperColor + "\n(" + ChallengerMod.Set.Data.Role_Reaper + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 45)
                        {
                            STR_Sorcerer_Scan2 = R_SaboteurColor + "\n(" + ChallengerMod.Set.Data.Role_Saboteur + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 46)
                        {
                            STR_Sorcerer_Scan2 = R_CrewmateColor + "\n(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 47)
                        {
                            STR_Sorcerer_Scan2 = R_ImpostorColor + "\n(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC;
                        }
                        if (Sorcerer.SetScan2 == 48)
                        {
                            STR_Sorcerer_Scan2 = R_CursedColor + "\n(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC;
                        }
                    }
                }

                //COPYCAT
                string STR_CopyCat_NewRoleName = R_CopyCatColor + "(" + ChallengerMod.Set.Data.Role_CopyCat + ")" + CC;


                if (STR_CopyCat_NewRoleName == R_CopyCatColor + "(" + ChallengerMod.Set.Data.Role_CopyCat + ")" + CC)
                {
                    if (CopyCat.Role != null)
                    {
                        if (CopyCat.copyRole == 1 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC;
                        }
                        if (CopyCat.copyRole == 2 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_GuardianColor + "(" + ChallengerMod.Set.Data.Role_Guardian + ")" + CC;
                        }
                        if (CopyCat.copyRole == 3 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_EngineerColor + "(" + ChallengerMod.Set.Data.Role_Engineer + ")" + CC;
                        }
                        if (CopyCat.copyRole == 4 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_TimelordColor + "(" + ChallengerMod.Set.Data.Role_Timelord + ")" + CC;
                        }
                        if (CopyCat.copyRole == 5 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_HunterColor + "(" + ChallengerMod.Set.Data.Role_Hunter + ")" + CC;
                        }
                        if (CopyCat.copyRole == 6 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_MysticColor + "(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC;
                        }
                        if (CopyCat.copyRole == 7 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_SpiritColor + "(" + ChallengerMod.Set.Data.Role_Spirit + ")" + CC;
                        }
                        if (CopyCat.copyRole == 8 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_MayorColor + "(" + ChallengerMod.Set.Data.Role_Mayor + ")" + CC;
                        }
                        if (CopyCat.copyRole == 9 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_DetectiveColor + "(" + ChallengerMod.Set.Data.Role_Detective + ")" + CC;
                        }
                        if (CopyCat.copyRole == 10 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_NightwatchColor + "(" + ChallengerMod.Set.Data.Role_Nightwatch + ")" + CC;
                        }
                        if (CopyCat.copyRole == 11 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_SpyColor + "(" + ChallengerMod.Set.Data.Role_Spy + ")" + CC;
                        }
                        if (CopyCat.copyRole == 12 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC;
                        }
                        if (CopyCat.copyRole == 13 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_BaitColor + "(" + ChallengerMod.Set.Data.Role_Bait + ")" + CC;
                        }
                        if (CopyCat.copyRole == 14 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_MentalistColor + "(" + ChallengerMod.Set.Data.Role_Mentalist + ")" + CC;
                        }
                        if (CopyCat.copyRole == 15 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_BuilderColor + "(" + ChallengerMod.Set.Data.Role_Builder + ")" + CC;
                        }
                        if (CopyCat.copyRole == 16 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_DictatorColor + "(" + ChallengerMod.Set.Data.Role_Dictator + ")" + CC;
                        }
                        if (CopyCat.copyRole == 17 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_SentinelColor + "(" + ChallengerMod.Set.Data.Role_Sentinel + ")" + CC;
                        }
                        if (CopyCat.copyRole == 18 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_LawkeeperColor + "(" + ChallengerMod.Set.Data.Role_Lawkeeper + ")" + CC;
                        }
                        if (CopyCat.copyRole == 19 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_FakeColor + "(" + ChallengerMod.Set.Data.Role_Fake + ")" + CC;
                        }
                        if (CopyCat.copyRole == 20 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_TravelerColor + "(" + ChallengerMod.Set.Data.Role_Traveler + ")" + CC;
                        }
                        if (CopyCat.copyRole == 21 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_LeaderColor + "(" + ChallengerMod.Set.Data.Role_Leader + ")" + CC;
                        }
                        if (CopyCat.copyRole == 22 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_DoctorColor + "(" + ChallengerMod.Set.Data.Role_Doctor + ")" + CC;
                        }
                        if (CopyCat.copyRole == 23 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_SlaveColor + "(" + ChallengerMod.Set.Data.Role_Slave + ")" + CC;
                        }
                        if (CopyCat.copyRole == 24 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC;
                        }
                        if (CopyCat.copyRole == 25 && CopyCat.CopiedPlayer.Data.IsDead)
                        {
                            STR_CopyCat_NewRoleName = B_Copy + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC;
                        }
                    }
                }
                if (STR_COPY != STR_CopyCat_NewRoleName)
                {
                    STR_COPY = STR_CopyCat_NewRoleName;
                }
                
                
                    if (Sorcerer.Role != null)
                    {
                        if (Sorcerer.TotalRuneLoot == 0)
                        {
                            Challenger.CirclePosition = CirclePositionC1;
                        }
                        if (Sorcerer.TotalRuneLoot == 1)
                        {
                            Challenger.CirclePosition = CirclePositionC2;
                        }
                        if (Sorcerer.TotalRuneLoot == 2)
                        {
                            Challenger.CirclePosition = CirclePositionC3;
                        }
                        if (Sorcerer.TotalRuneLoot == 3)
                        {
                            Challenger.CirclePosition = CirclePositionC4;
                        }
                        if (Sorcerer.TotalRuneLoot == 4)
                        {
                            Challenger.CirclePosition = CirclePositionC0;
                        }
                    }



                foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                {
                    if (task.TaskType == TaskTypes.FixComms) { Challenger.ComSab = true; }
                    else { Challenger.ComSab = false; }

                    if (task.TaskType == TaskTypes.ResetReactor) 
                    { 
                        Challenger.ReactorSab = true;
                        Challenger.ResetScreenColor = true;
                    }
                    else { Challenger.ReactorSab = false; }

                }

                if (IsMapPolusV2 && !ReactorSab && !LobbyTimeStop && !Barghest.Shadow && !Spy.Use && !(PlayerControl.LocalPlayer == Vector.Infected) && ResetScreenColor)
                {
                    HudManager.Instance.FullScreen.color = new Color(0, 0f, 0f, 0f);
                    Challenger.ResetScreenColor = false;
                }

                if (CommsSabotageAnonymous.getSelection() == 1)
                {
                    StartComSabUnk = true;
                }
                else 
                { 
                    StartComSabUnk = false;
                }


                if (ComSab)
                {
                    if (StartComSabUnk && !ComIsSab)
                    {
                        foreach (PlayerControl players in PlayerControl.AllPlayerControls)
                        {
                            if (!PlayerControl.LocalPlayer.Data.IsDead)
                            {
                                
                                if (Scrambler.Role != null && Scrambler.Camo)
                                {
                                    players.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), 7, "", "", "", "");
                                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                                }
                                else
                                {
                                    players.setLook(ChallengerOS.Utils.Helpers.cs(ChallengerMod.ColorTable.nocolor, "x"), ColorIDSave_ToCom, "", "", "", "");
                                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                                }
                            }
                            Challenger.ComIsSab = true;
                        }
                    }
                    else { Challenger.ComIsSab = true; }
                    
                }
                else
                {
                    if (Scrambler.Role != null && Scrambler.Camo)
                    {
                        foreach (PlayerControl players in PlayerControl.AllPlayerControls)
                        {
                            if (Ghost.Role != null && PlayerControl.LocalPlayer == Ghost.Role && Ghost.Hide )
                            {
                                if (players == PlayerControl.LocalPlayer)
                                {
                                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.DisabledClear;
                                }
                                else
                                {
                                    players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                                }
                            }
                            else
                            {
                                players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                            }
                        }
                    }
                    else
                    {
                        if (StartComSabUnk && ComIsSab)
                        {
                            foreach (PlayerControl players in PlayerControl.AllPlayerControls)
                            {
                                players.cosmetics.currentBodySprite.BodySprite.color = Palette.EnabledColor;
                                
                                if (Morphling.Role != null && Morphling.Morph != null && players.PlayerId == Morphling.Role.PlayerId && Morphling.Morphed)
                                {
                                    Morphling.Role.setLook(Morphling.Morph.Data.PlayerName, Morphling.Morph.Data.DefaultOutfit.ColorId, Morphling.Morph.Data.DefaultOutfit.HatId, Morphling.Morph.Data.DefaultOutfit.VisorId, Morphling.Morph.Data.DefaultOutfit.SkinId, Morphling.Morph.Data.DefaultOutfit.PetId);
                                }
                                else
                                {
                                    players.setDefaultLook();
                                }

                                
                                Challenger.ComIsSab = false;
                            }
                        }
                        else { Challenger.ComIsSab = false; }
                    }
                }


                //ROLE_UPDATE
                if (PlayerControl.LocalPlayer.Data.IsDead == false) //PlayerLocalData
                {

                    // BUFFS

                    if ((ComSab && CommsSabotageAnonymous.getSelection() == 1) || (Scrambler.Role != null && Scrambler.Camo == true))
                    {

                        //HUNTER TRACK 
                        if (Hunter.Role != null && Hunter.Tracked != null)
                        {
                            if (PlayerControl.LocalPlayer == Hunter.Role)
                            {
                                if (Hunter.Tracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                                else { Hunter.Tracked.cosmetics.nameText.text += C_WhiteColor + Hunter.Tracked.Data.PlayerName + CC + B_Tracker + "<color=#00000000>-</color>"; }

                            }
                            
                        }
                        if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && Hunter.CopyTracked != null)
                        {
                            if (PlayerControl.LocalPlayer == CopyCat.Role)
                            {
                                if (Hunter.CopyTracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                                else { Hunter.CopyTracked.cosmetics.nameText.text += C_WhiteColor + Hunter.CopyTracked.Data.PlayerName + CC + B_Tracker + "<color=#00000000>-</color>"; }

                            }
                            

                        }
                        //VECTOR INFECTED
                        if (Vector.Role != null && Vector.Infected != null)
                        {
                            if (PlayerControl.LocalPlayer == Vector.Role)
                            {
                                if (Vector.Infected.cosmetics.nameText.text.Contains(B_Infect)) { }
                                else
                                {
                                    if ((Vector.Infected.Data.Role.IsImpostor && ImpostorsKnowEachother.getBool() == false) || (Fake.Role != null && Vector.Infected.Data.PlayerId == Fake.Role.Data.PlayerId && ImpostorsKnowEachother.getBool() == false))
                                    {
                                        Vector.Infected.cosmetics.nameText.text += C_RedColor + Vector.Infected.Data.PlayerName + CC + B_Infect + "<color=#00000000>-</color>"; ;
                                    }
                                    else
                                    {
                                        Vector.Infected.cosmetics.nameText.text += C_WhiteColor + Vector.Infected.Data.PlayerName + CC + B_Infect;
                                    }

                                }

                            }

                        }
                    }
                    else
                    {
                        //GUARDIUAN SHIELD
                        if (Guardian.Role != null && Guardian.Protected != null)
                        {

                            if (PlayerControl.LocalPlayer == Guardian.Role)
                            {
                                if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibility.getBool() == true) && (PlayerControl.LocalPlayer == Guardian.Protected))
                            {
                                if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibilitytry.getSelection() == 1) && (Guardian.shieldattempt == true) && (PlayerControl.LocalPlayer == Guardian.Protected))
                            {
                                if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibilitytry.getSelection() == 0) && (Guardian.shieldattempt == true))
                            {
                                if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((CopyCat.Role != null) && (CopyCat.copyRole == 2) && (CopyCat.CopiedPlayer != null) && (CopyCat.CopiedPlayer.Data.IsDead) && (Guardian.Protected != null) && (PlayerControl.LocalPlayer == CopyCat.Role))
                            {
                                if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                        }
                        //GUARDIUAN SHIELD-MYSTIC
                        if (Guardian.Role != null && Guardian.ProtectedMystic != null)
                        {

                            if (PlayerControl.LocalPlayer == Guardian.Role)
                            {
                                if (Guardian.ProtectedMystic.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.ProtectedMystic.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.ProtectedMystic.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibility.getBool() == true) && (PlayerControl.LocalPlayer == Guardian.ProtectedMystic))
                            {
                                if (Guardian.ProtectedMystic.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.ProtectedMystic.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.ProtectedMystic.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibilitytry.getSelection() == 1) && (Guardian.shieldattempt == true) && (PlayerControl.LocalPlayer == Guardian.ProtectedMystic))
                            {
                                if (Guardian.ProtectedMystic.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.ProtectedMystic.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.ProtectedMystic.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((GuardianShieldVisibilitytry.getSelection() == 0) && (Guardian.shieldattempt == true))
                            {
                                if (Guardian.ProtectedMystic.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.ProtectedMystic.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.ProtectedMystic.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                            if ((CopyCat.Role != null) && (CopyCat.copyRole == 2) && (CopyCat.CopiedPlayer != null) && (CopyCat.CopiedPlayer.Data.IsDead) && (Guardian.ProtectedMystic != null) && (PlayerControl.LocalPlayer == CopyCat.Role))
                            {
                                if (Guardian.ProtectedMystic.cosmetics.nameText.text.Contains(B_Shield)) { }
                                else { Guardian.ProtectedMystic.cosmetics.nameText.text += B_Shield; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Guardian.ProtectedMystic.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Shield)) { }
                                            else { player.NameText.text += B_Shield; }
                                        }
                            }
                        }


                        //HUNTER TRACK 
                        if (Hunter.Role != null && Hunter.Tracked != null)
                        {
                            if (PlayerControl.LocalPlayer == Hunter.Role)
                            {
                                if (Hunter.Tracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                                else { Hunter.Tracked.cosmetics.nameText.text += B_Tracker; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Hunter.Tracked.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Tracker)) { }
                                            else { player.NameText.text += B_Tracker; }
                                        }
                            }
                        }
                        if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && (Hunter.CopyTracked != null))
                        {
                            if (PlayerControl.LocalPlayer == CopyCat.Role)

                            {
                                if (Hunter.CopyTracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                                else { Hunter.CopyTracked.cosmetics.nameText.text += B_Tracker; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Hunter.CopyTracked.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Tracker)) { }
                                            else { player.NameText.text += B_Tracker; }
                                        }
                            }

                        }

                        //LEADERMARK 
                        if (Leader.Target != null && Leader.Target2 != null)
                        {
                            if (Leader.Target.cosmetics.nameText.text.Contains(B_LeaderMark)) { }
                            else { Leader.Target.cosmetics.nameText.text += B_LeaderMark; }

                            if (Leader.Target2.cosmetics.nameText.text.Contains(B_LeaderMark)) { }
                            else { Leader.Target2.cosmetics.nameText.text += B_LeaderMark; }

                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Leader.Target.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMark)) { }
                                        else { player.NameText.text += B_LeaderMark; }
                                    }
                                    if (player.NameText.text != null && Leader.Target2.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMark)) { }
                                        else { player.NameText.text += B_LeaderMark; }
                                    }
                                }
                        }
                        if (Leader.Role != null && Leader.Target != null && Leader.Target2 == null)
                        {
                            if (PlayerControl.LocalPlayer == Leader.Role)
                            {
                                if (Leader.Target.cosmetics.nameText.text.Contains(B_LocalLeaderMark)) { }
                                else { Leader.Target.cosmetics.nameText.text += B_LocalLeaderMark; }

                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Leader.Target.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_LocalLeaderMark)) { }
                                            else { player.NameText.text += B_LocalLeaderMark; }
                                        }
                                    }
                            }
                        }
                        //LEADERMARK COPY

                        if (CopyCat.Target != null && CopyCat.Target2 != null && Leader.Target2 == null)
                        {
                            if (CopyCat.Target.cosmetics.nameText.text.Contains(B_LeaderMarkCopy)) { }
                            else { CopyCat.Target.cosmetics.nameText.text += B_LeaderMarkCopy; }

                            if (CopyCat.Target2.cosmetics.nameText.text.Contains(B_LeaderMarkCopy)) { }
                            else { CopyCat.Target2.cosmetics.nameText.text += B_LeaderMarkCopy; }

                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && CopyCat.Target.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopy)) { }
                                        else { player.NameText.text += B_LeaderMarkCopy; }
                                    }
                                    if (player.NameText.text != null && CopyCat.Target2.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopy)) { }
                                        else { player.NameText.text += B_LeaderMarkCopy; }
                                    }
                                }
                        }
                        if (CopyCat.Target != null && CopyCat.Target2 != null && Leader.Target2 != null)
                        {
                            if (CopyCat.Target.cosmetics.nameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                            else { CopyCat.Target.cosmetics.nameText.text += B_LeaderMarkCopyIfExist; }

                            if (CopyCat.Target2.cosmetics.nameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                            else { CopyCat.Target2.cosmetics.nameText.text += B_LeaderMarkCopyIfExist; }

                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && CopyCat.Target.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                                        else { player.NameText.text += B_LeaderMarkCopyIfExist; }
                                    }
                                    if (player.NameText.text != null && CopyCat.Target2.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                                        else { player.NameText.text += B_LeaderMarkCopyIfExist; }
                                    }
                                }
                        }
                        if (CopyCat.Role != null && CopyCat.Target != null && CopyCat.Target2 == null)
                        {
                            if (PlayerControl.LocalPlayer == CopyCat.Role && CopyCat.CopyStart && CopyCat.copyRole == 21)
                            {
                                if (CopyCat.Target.cosmetics.nameText.text.Contains(B_LocalLeaderMark)) { }
                                else { CopyCat.Target.cosmetics.nameText.text += B_LocalLeaderMark; }

                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && CopyCat.Target.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_LocalLeaderMark)) { }
                                            else { player.NameText.text += B_LocalLeaderMark; }
                                        }
                                    }
                            }
                        }
                        //VECTOR INFECTED
                        if (Vector.Role != null && Vector.Infected != null)
                        {
                            if (PlayerControl.LocalPlayer == Vector.Role)
                            {
                                if (Vector.Infected.cosmetics.nameText.text.Contains(B_Infect)) { }
                                else { Vector.Infected.cosmetics.nameText.text += B_Infect; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Vector.Infected.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Infect)) { }
                                            else { player.NameText.text += B_Infect; }
                                        }
                            }

                        }
                        //BASILISK PETRIFIED
                        if (Basilisk.Role != null && Basilisk.Petrified != null && !Basilisk.PetrifyAndShield)
                        {
                            if (PlayerControl.LocalPlayer == Basilisk.Role)
                            {
                                if (Basilisk.Petrified.cosmetics.nameText.text.Contains(B_Petrified)) { }
                                else { Basilisk.Petrified.cosmetics.nameText.text += B_Petrified; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Basilisk.Petrified.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Petrified)) { }
                                            else { player.NameText.text += B_Petrified; }
                                        }
                            }

                        }
                        if (Basilisk.Role != null && Basilisk.Petrified != null && Basilisk.PetrifyAndShield)
                        {
                            if (PlayerControl.LocalPlayer == Basilisk.Role)
                            {
                                if (Basilisk.Petrified.cosmetics.nameText.text.Contains(B_Petrified2)) { }
                                else { Basilisk.Petrified.cosmetics.nameText.text += B_Petrified2; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Basilisk.Petrified.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Petrified2)) { }
                                            else { player.NameText.text += B_Petrified2; }
                                        }
                            }

                        }


                        //COPYCAT COPY
                        if (CopyCat.Role != null && CopyCat.CopiedPlayer != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {

                                if (PlayerControl.LocalPlayer == CopyCat.Role)
                                {
                                    if (CopyCat.CopiedPlayer.cosmetics.nameText.text.Contains(B_Copy)) { }
                                    else { CopyCat.CopiedPlayer.cosmetics.nameText.text += B_Copy; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && CopyCat.CopiedPlayer.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Copy)) { }
                                                else { player.NameText.text += B_Copy; }
                                            }
                                }
                            }

                        }
                        //REVENGER
                        //EMP1
                        if (Revenger.Role != null && Revenger.EMP1 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Revenger.Role)
                                {
                                    {
                                        if (Revenger.EMP1.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                        else { Revenger.EMP1.cosmetics.nameText.text += B_EMP_Off; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Revenger.EMP1.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_EMP_Off)) { }
                                                    else { player.NameText.text += B_EMP_Off; }
                                                }

                                    }

                                }
                            }
                        }

                        //EMP2
                        if (Revenger.Role != null && Revenger.EMP2 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Revenger.Role)
                                {
                                    {
                                        if (Revenger.EMP2.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                        else { Revenger.EMP2.cosmetics.nameText.text += B_EMP_Off; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Revenger.EMP2.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_EMP_Off)) { }
                                                    else { player.NameText.text += B_EMP_Off; }
                                                }
                                    }

                                }
                            }
                        }

                        //EMP3
                        if (Revenger.Role != null && Revenger.EMP3 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Revenger.Role)
                                {
                                    {
                                        if (Revenger.EMP3.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                        else { Revenger.EMP3.cosmetics.nameText.text += B_EMP_Off; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Revenger.EMP3.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_EMP_Off)) { }
                                                    else { player.NameText.text += B_EMP_Off; }
                                                }
                                    }

                                }
                            }
                        }

                        // SORCERER INFORMED
                        if (Sorcerer.Role != null && Sorcerer.Scan1 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Sorcerer.Role)
                                {
                                    if (Sorcerer.Scan1.cosmetics.nameText.text.Contains(STR_Sorcerer_Scan1)) { }
                                    else { Sorcerer.Scan1.cosmetics.nameText.text += STR_Sorcerer_Scan1; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Sorcerer.Scan1.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(STR_Sorcerer_Scan1)) { }
                                                else { player.NameText.text += STR_Sorcerer_Scan1; }
                                            }
                                }
                            }
                        }
                        // SORCERER INFORMED
                        if (Sorcerer.Role != null && Sorcerer.Scan2 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Sorcerer.Role)
                                {
                                    if (Sorcerer.Scan2.cosmetics.nameText.text.Contains(STR_Sorcerer_Scan2)) { }
                                    else { Sorcerer.Scan2.cosmetics.nameText.text += STR_Sorcerer_Scan2; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Sorcerer.Scan2.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(STR_Sorcerer_Scan2)) { }
                                                else { player.NameText.text += STR_Sorcerer_Scan2; }
                                            }
                                }
                            }
                        }

                        // INFORMANT  INFORMED
                        if (Informant.Role != null && Informant.Informed != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 1)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Nice)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Nice; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Nice)) { }
                                                else { player.NameText.text += B_Infored_Nice; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 2)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Bad)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Bad; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Bad)) { }
                                                else { player.NameText.text += B_Infored_Bad; }
                                            }
                                }
                                if (Informant.InformedTeam > 2 && InforAnalyseTeam.getBool() == false)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Bad)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Bad; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Bad)) { }
                                                else { player.NameText.text += B_Infored_Bad; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 3 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Jester)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Jester; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Jester)) { }
                                                else { player.NameText.text += B_Infored_Jester; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 4 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Eater)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Eater; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Eater)) { }
                                                else { player.NameText.text += B_Infored_Eater; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 5 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Outlaw)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Outlaw; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Outlaw)) { }
                                                else { player.NameText.text += B_Infored_Outlaw; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 6 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Arsonist)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Arsonist; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Arsonist)) { }
                                                else { player.NameText.text += B_Infored_Arsonist; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 7 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Culte)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Culte; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Culte)) { }
                                                else { player.NameText.text += B_Infored_Culte; }
                                            }
                                }
                                if (PlayerControl.LocalPlayer == Informant.Role && Informant.InformedTeam == 8 && InforAnalyseTeam.getBool() == true)
                                {
                                    if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Cursed)) { }
                                    else { Informant.Informed.cosmetics.nameText.text += B_Infored_Cursed; }
                                    if (MeetingHud.Instance != null)
                                        foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                            if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                            {
                                                if (player.NameText.text.Contains(B_Infored_Cursed)) { }
                                                else { player.NameText.text += B_Infored_Cursed; }
                                            }
                                }



                                if ((CopyCat.Role != null) && (CopyCat.copyRole == 12) && (CopyCat.CopiedPlayer != null) && (CopyCat.CopiedPlayer.Data.IsDead) && (Informant.Informed != null) && (PlayerControl.LocalPlayer == CopyCat.Role))
                                {
                                    if (Informant.InformedTeam == 1)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Nice)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Nice; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Nice)) { }
                                                    else { player.NameText.text += B_Infored_Nice; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 2)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Bad)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Bad; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Bad)) { }
                                                    else { player.NameText.text += B_Infored_Bad; }
                                                }
                                    }
                                    if (Informant.InformedTeam > 2 && InforAnalyseTeam.getBool() == false)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Bad)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Bad; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Bad)) { }
                                                    else { player.NameText.text += B_Infored_Bad; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 3 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Jester)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Jester; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Jester)) { }
                                                    else { player.NameText.text += B_Infored_Jester; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 4 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Eater)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Eater; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Eater)) { }
                                                    else { player.NameText.text += B_Infored_Eater; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 5 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Outlaw)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Outlaw; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Outlaw)) { }
                                                    else { player.NameText.text += B_Infored_Outlaw; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 6 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Arsonist)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Arsonist; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Arsonist)) { }
                                                    else { player.NameText.text += B_Infored_Arsonist; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 7 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Culte)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Culte; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Culte)) { }
                                                    else { player.NameText.text += B_Infored_Culte; }
                                                }
                                    }
                                    if (Informant.InformedTeam == 8 && InforAnalyseTeam.getBool() == true)
                                    {
                                        if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored_Cursed)) { }
                                        else { Informant.Informed.cosmetics.nameText.text += B_Infored_Cursed; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Infored_Cursed)) { }
                                                    else { player.NameText.text += B_Infored_Cursed; }
                                                }
                                    }
                                }
                            }

                        }
                       
                        // CUPID AND LOVER
                        // CUPID LOVER 1
                        if (Cupid.Role != null && Cupid.Lover1 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Cupid.Role)
                                {
                                    if (Cupid.loverDie == false)
                                    {
                                        if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                        else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Alive; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                                    else { player.NameText.text += B_Lover_Alive; }
                                                }
                                    }
                                    else
                                    {
                                        if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                        else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Die; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Die)) { }
                                                    else { player.NameText.text += B_Lover_Die; }
                                                }
                                    }
                                }

                                if (Cupid.Lover2 != null && PlayerControl.LocalPlayer == Cupid.Lover2)
                                {
                                    if (Cupid.loverDie == false)
                                    {
                                        if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                        else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Alive; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                                    else { player.NameText.text += B_Lover_Alive; }
                                                }
                                    }
                                    else
                                    {
                                        if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                        else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Die; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Die)) { }
                                                    else { player.NameText.text += B_Lover_Die; }
                                                }
                                    }
                                }
                            }
                        }



                        // CUPID LOVER 2
                        if (Cupid.Role != null && Cupid.Lover2 != null)
                        {
                            if (!ComSab && CommsSabotageAnonymous.getSelection() == 1 || CommsSabotageAnonymous.getSelection() == 0)
                            {
                                if (PlayerControl.LocalPlayer == Cupid.Role)
                                {
                                    if (Cupid.loverDie == false)

                                    {
                                        if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                        else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Alive; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                                    else { player.NameText.text += B_Lover_Alive; }
                                                }
                                    }
                                    else
                                    {
                                        if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                        else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Die; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Die)) { }
                                                    else { player.NameText.text += B_Lover_Die; }
                                                }
                                    }
                                }
                                if (Cupid.Lover1 != null && PlayerControl.LocalPlayer == Cupid.Lover1)
                                {
                                    if (Cupid.loverDie == false)

                                    {
                                        if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                        else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Alive; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                                    else { player.NameText.text += B_Lover_Alive; }
                                                }
                                    }
                                    else
                                    {
                                        if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                        else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Die; }
                                        if (MeetingHud.Instance != null)
                                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                                if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                                {
                                                    if (player.NameText.text.Contains(B_Lover_Die)) { }
                                                    else { player.NameText.text += B_Lover_Die; }
                                                }
                                    }
                                }
                            }
                        }
                        if (Morphling.Role != null && Morphling.Morph != null)
                        {
                            if (PlayerControl.LocalPlayer != Morphling.Role && Morphling.Morphed == true)
                            {
                                Morphling.Role.cosmetics.nameText.text = Morphling.Morph.Data.PlayerName;
                            }
                        }
                        if (Teammate1.Role != null && Teammate2.Role != null)
                        {

                            if (PlayerControl.LocalPlayer == Teammate2.Role)
                            {
                                Teammate1.Role.cosmetics.nameText.text =
                                    T_Crewmates + Teammate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Teammate1.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Crewmates + Teammate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                        }
                                    }
                                }
                            }
                            if (PlayerControl.LocalPlayer == Teammate1.Role)
                            {
                                Teammate2.Role.cosmetics.nameText.text =
                                    T_Crewmates + Teammate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Teammate2.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Crewmates + Teammate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Informant.Role != null)
                    {

                        if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && Informant.TaskEND == true)
                        {
                            Informant.Role.cosmetics.nameText.text =
                                T_Crewmates + Informant.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                            + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.InformantTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Informant.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Informant.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.InformantTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }
                        }
                    }
                    if (CopyCat.Role != null && CopyCat.copyRole == 12 && CopyCat.CopyStart)
                    {

                        if (PlayerControl.LocalPlayer.Data.Role.IsImpostor && CopyCat.TaskEND == true)
                        {
                            CopyCat.Role.cosmetics.nameText.text =
                                T_Crewmates + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                            + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.CopyCatTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && CopyCat.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.CopyCatTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }
                        }
                    }


                    if (IntroScreen)
                    {

                        if (Morphling.Role != null && Morphling.Morph != null && PlayerControl.LocalPlayer == Morphling.Role && Morphling.Morphed == true)
                        {
                            PlayerControl.LocalPlayer.cosmetics.nameText.text =
                                            STR_MyTeam + STR_MORPH + CC + STR_MyCulte + STR_Mylove + STR_MyShield
                                        + "\n" + Size4 + STR_MyRoleColor + STR_P1 + STR_MyRole + STR_P2 + CC
                                        + " " + STR_MyTaskColor + STR_Ts1 + STR_Mytask + STR_Ts2 + STR_MyTotaltask + STR_Ts3 + CC + CZ;
                        }
                        else
                        {
                            PlayerControl.LocalPlayer.cosmetics.nameText.text =
                                            STR_MyTeam + STR_MyName + CC + STR_MyCulte + STR_Mylove + STR_MyShield
                                        + "\n" + Size4 + STR_MyRoleColor + STR_P1 + STR_MyRole + STR_P2 + CC
                                        + " " + STR_MyTaskColor + STR_Ts1 + STR_Mytask + STR_Ts2 + STR_MyTotaltask + STR_Ts3 + CC + CZ;
                        }
                    }



                        if (MeetingHud.Instance != null)
                        {
                            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                            {
                                if (player.NameText.text != null && PlayerControl.LocalPlayer.PlayerId == player.TargetPlayerId)
                                {
                                    player.NameText.text =
                                        STR_MyTeam + STR_MyName + CC + STR_MyCulte + STR_Mylove + STR_MyShield 
                                    + "\n" + Size4 + STR_MyRoleColor + STR_P1 + STR_MyRole + STR_P2 + CC
                                    + " " + STR_MyTaskColor + STR_Ts1 + STR_Mytask + STR_Ts2 + STR_MyTotaltask + STR_Ts3 + CC + CZ;

                                }
                                
                             }

                        }
                    

                    return;
                }
                else // PLAYER DEAD !
                {

                    

                    foreach (PlayerControl PC in PlayerControl.AllPlayerControls)
                    {


                       
                        






                        //ROLE_SHERIFF1
                        if (Sheriff1.Role != null)
                        {
                            Sheriff1.Role.cosmetics.nameText.text =
                                    T_Crewmates + Sheriff1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Sheriff1.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Sheriff1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Sheriff2
                        if (Sheriff2.Role != null)
                        {
                            Sheriff2.Role.cosmetics.nameText.text =
                                    T_Crewmates + Sheriff2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Sheriff2.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Sheriff2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Sheriff3
                        if (Sheriff3.Role != null)
                        {
                            Sheriff3.Role.cosmetics.nameText.text =
                                    T_Crewmates + Sheriff3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff3Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Sheriff3.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Sheriff3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SheriffColor + "(" + ChallengerMod.Set.Data.Role_Sheriff + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Sheriff3Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Guardian
                        if (Guardian.Role != null)
                        {
                            Guardian.Role.cosmetics.nameText.text =
                                    T_Crewmates + Guardian.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_GuardianColor + "(" + ChallengerMod.Set.Data.Role_Guardian + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.GuardianTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Guardian.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Guardian.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_GuardianColor + "(" + ChallengerMod.Set.Data.Role_Guardian + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.GuardianTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Engineer
                        if (Engineer.Role != null)
                        {
                            Engineer.Role.cosmetics.nameText.text =
                                    T_Crewmates + Engineer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_EngineerColor + "(" + ChallengerMod.Set.Data.Role_Engineer + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.EngineerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Engineer.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Engineer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_EngineerColor + "(" + ChallengerMod.Set.Data.Role_Engineer + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.EngineerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Timelord
                        if (Timelord.Role != null)
                        {
                            Timelord.Role.cosmetics.nameText.text =
                                    T_Crewmates + Timelord.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_TimelordColor + "(" + ChallengerMod.Set.Data.Role_Timelord + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.TimelordTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Timelord.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Timelord.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_TimelordColor + "(" + ChallengerMod.Set.Data.Role_Timelord + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.TimelordTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Hunter
                        if (Hunter.Role != null)
                        {
                            Hunter.Role.cosmetics.nameText.text =
                                    T_Crewmates + Hunter.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_HunterColor + "(" + ChallengerMod.Set.Data.Role_Hunter + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.HunterTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Hunter.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Hunter.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_HunterColor + "(" + ChallengerMod.Set.Data.Role_Hunter + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.HunterTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }
                        }
                        //ROLE_Mystic
                        if (Mystic.Role != null)
                        {
                            if (Mystic.selfShield == true)
                            {
                                Mystic.Role.cosmetics.nameText.text =
                                   T_Crewmates + Mystic.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                               + "\n" + Size4 + R_MysticColor + "(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC
                               + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MysticTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + B_SelfShield + CZ;
                            }
                            else
                            {
                                Mystic.Role.cosmetics.nameText.text =
                                   T_Crewmates + Mystic.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                               + "\n" + Size4 + R_MysticColor + "(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC
                               + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MysticTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + B_NoSelfShield + CZ;
                            }
                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Mystic.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Mystic.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_MysticColor + "(" + ChallengerMod.Set.Data.Role_Mystic + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MysticTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Spirit
                        if (Spirit.Role != null)
                        {
                            Spirit.Role.cosmetics.nameText.text =
                                    T_Crewmates + Spirit.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SpiritColor + "(" + ChallengerMod.Set.Data.Role_Spirit + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SpiritTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Spirit.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Spirit.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SpiritColor + "(" + ChallengerMod.Set.Data.Role_Spirit + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SpiritTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Mayor
                        if (Mayor.Role != null)
                        {
                            Mayor.Role.cosmetics.nameText.text =
                                    T_Crewmates + Mayor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MayorColor + "(" + ChallengerMod.Set.Data.Role_Mayor + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MayorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Mayor.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Mayor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_MayorColor + "(" + ChallengerMod.Set.Data.Role_Mayor + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MayorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Detective
                        if (Detective.Role != null)
                        {
                            Detective.Role.cosmetics.nameText.text =
                                    T_Crewmates + Detective.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_DetectiveColor + "(" + ChallengerMod.Set.Data.Role_Detective + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DetectiveTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Detective.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Detective.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_DetectiveColor + "(" + ChallengerMod.Set.Data.Role_Detective + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DetectiveTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Nightwatch
                        if (Nightwatch.Role != null)
                        {
                            Nightwatch.Role.cosmetics.nameText.text =
                                    T_Crewmates + Nightwatch.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_NightwatchColor + "(" + ChallengerMod.Set.Data.Role_Nightwatch + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.NightwatchTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Nightwatch.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Nightwatch.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_NightwatchColor + "(" + ChallengerMod.Set.Data.Role_Nightwatch + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.NightwatchTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Spy
                        if (Spy.Role != null)
                        {
                            Spy.Role.cosmetics.nameText.text =
                                    T_Crewmates + Spy.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SpyColor + "(" + ChallengerMod.Set.Data.Role_Spy + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SpyTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Spy.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Spy.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SpyColor + "(" + ChallengerMod.Set.Data.Role_Spy + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SpyTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Informant
                        if (Informant.Role != null)
                        {
                            Informant.Role.cosmetics.nameText.text =
                                    T_Crewmates + Informant.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.InformantTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Informant.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Informant.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_InformantColor + "(" + ChallengerMod.Set.Data.Role_Informant + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.InformantTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Bait
                        if (Bait.Role != null)
                        {
                            Bait.Role.cosmetics.nameText.text =
                                    T_Crewmates + Bait.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_BaitColor + "(" + ChallengerMod.Set.Data.Role_Bait + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.BaitTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Bait.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Bait.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_BaitColor + "(" + ChallengerMod.Set.Data.Role_Bait + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.BaitTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Mentalist
                        if (Mentalist.Role != null)
                        {
                            Mentalist.Role.cosmetics.nameText.text =
                                    T_Crewmates + Mentalist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MentalistColor + "(" + ChallengerMod.Set.Data.Role_Mentalist + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MentalistTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Mentalist.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Mentalist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_MentalistColor + "(" + ChallengerMod.Set.Data.Role_Mentalist + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MentalistTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Builder
                        if (Builder.Role != null)
                        {
                            Builder.Role.cosmetics.nameText.text =
                                    T_Crewmates + Builder.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_BuilderColor + "(" + ChallengerMod.Set.Data.Role_Builder + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.BuilderTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Builder.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Builder.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_BuilderColor + "(" + ChallengerMod.Set.Data.Role_Builder + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.BuilderTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Dictator
                        if (Dictator.Role != null)
                        {
                            Dictator.Role.cosmetics.nameText.text =
                                    T_Crewmates + Dictator.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_DictatorColor + "(" + ChallengerMod.Set.Data.Role_Dictator + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DictatorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Dictator.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Dictator.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_DictatorColor + "(" + ChallengerMod.Set.Data.Role_Dictator + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DictatorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Sentinel
                        if (Sentinel.Role != null)
                        {
                            Sentinel.Role.cosmetics.nameText.text =
                                    T_Crewmates + Sentinel.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SentinelColor + "(" + ChallengerMod.Set.Data.Role_Sentinel + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SentinelTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Sentinel.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Sentinel.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SentinelColor + "(" + ChallengerMod.Set.Data.Role_Sentinel + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SentinelTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Teammate1
                        if (Teammate1.Role != null)
                        {
                            Teammate1.Role.cosmetics.nameText.text =
                                    T_Crewmates + Teammate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Teammate1.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Teammate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Teammate2
                        if (Teammate2.Role != null)
                        {
                            Teammate2.Role.cosmetics.nameText.text =
                                    T_Crewmates + Teammate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Teammate2.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Teammate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Teammate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Teammate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Lawkeeper
                        if (Lawkeeper.Role != null)
                        {
                            Lawkeeper.Role.cosmetics.nameText.text =
                                    T_Crewmates + Lawkeeper.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_LawkeeperColor + "(" + ChallengerMod.Set.Data.Role_Lawkeeper + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.LawkeeperTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Lawkeeper.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Lawkeeper.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_LawkeeperColor + "(" + ChallengerMod.Set.Data.Role_Lawkeeper + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.LawkeeperTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Fake
                        if (Fake.Role != null)
                        {
                            Fake.Role.cosmetics.nameText.text =
                                    T_Crewmates + Fake.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_FakeColor + "(" + ChallengerMod.Set.Data.Role_Fake + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.FakeTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Fake.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Fake.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_FakeColor + "(" + ChallengerMod.Set.Data.Role_Fake + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.FakeTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Traveler
                        if (Traveler.Role != null)
                        {
                            Traveler.Role.cosmetics.nameText.text =
                                    T_Crewmates + Traveler.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_TravelerColor + "(" + ChallengerMod.Set.Data.Role_Traveler + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.TravelerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Traveler.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Traveler.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_TravelerColor + "(" + ChallengerMod.Set.Data.Role_Traveler + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.TravelerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Leader
                        if (Leader.Role != null)
                        {
                            Leader.Role.cosmetics.nameText.text =
                                    T_Crewmates + Leader.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_LeaderColor + "(" + ChallengerMod.Set.Data.Role_Leader + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.LeaderTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Leader.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Leader.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_LeaderColor + "(" + ChallengerMod.Set.Data.Role_Leader + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.LeaderTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Doctor
                        if (Doctor.Role != null)
                        {
                            Doctor.Role.cosmetics.nameText.text =
                                    T_Crewmates + Doctor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_DoctorColor + "(" + ChallengerMod.Set.Data.Role_Doctor + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DoctorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Doctor.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Doctor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_DoctorColor + "(" + ChallengerMod.Set.Data.Role_Doctor + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.DoctorTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Slave
                        if (Slave.Role != null)
                        {
                            Slave.Role.cosmetics.nameText.text =
                                    T_Crewmates + Slave.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SlaveColor + "(" + ChallengerMod.Set.Data.Role_Slave + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SlaveTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Slave.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Slave.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SlaveColor + "(" + ChallengerMod.Set.Data.Role_Slave + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.SlaveTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //CREWMATE_VANILLA
                        //ROLE_Crewmate1
                        if (Crewmate1.Role != null)
                        {
                            Crewmate1.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate1.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate1Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate2
                        if (Crewmate2.Role != null)
                        {
                            Crewmate2.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate2.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate2Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate3
                        if (Crewmate3.Role != null)
                        {
                            Crewmate3.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate3Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate3.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate3Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate4
                        if (Crewmate4.Role != null)
                        {
                            Crewmate4.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate4.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate4Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate4.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate4.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate4Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate5
                        if (Crewmate5.Role != null)
                        {
                            Crewmate5.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate5.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate5Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate5.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate5.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate5Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate6
                        if (Crewmate6.Role != null)
                        {
                            Crewmate6.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate6.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate6Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate6.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate6.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate6Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate7
                        if (Crewmate7.Role != null)
                        {
                            Crewmate7.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate7.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate7Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate7.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate7.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate7Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate8
                        if (Crewmate8.Role != null)
                        {
                            Crewmate8.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate8.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate8Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate8.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate8.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate8Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate9
                        if (Crewmate9.Role != null)
                        {
                            Crewmate9.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate9.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate9Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate9.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate9.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate9Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate10
                        if (Crewmate10.Role != null)
                        {
                            Crewmate10.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate10.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate10Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate10.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate10.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate10Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate11
                        if (Crewmate11.Role != null)
                        {
                            Crewmate11.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate11.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate11Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate11.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate11.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate11Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate12
                        if (Crewmate12.Role != null)
                        {
                            Crewmate12.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate12.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate12Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate12.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate12.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate12Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate13
                        if (Crewmate13.Role != null)
                        {
                            Crewmate13.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate13.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate13Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate13.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate13.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate13Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Crewmate14
                        if (Crewmate14.Role != null)
                        {
                            Crewmate14.Role.cosmetics.nameText.text =
                                    T_Crewmates + Crewmate14.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate14Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Crewmate14.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Crewmates + Crewmate14.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_CrewmateColor + "(" + ChallengerMod.Set.Data.Role_Crewmate + ")" + CC
                                        + " " + Q_Crew + "[" + ChallengerMod.Set.Data.Crewmate14Task + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //HYBRID_ROLE
                        //ROLE_Mercenary
                        if (Mercenary.Role != null)
                        {
                            if (Mercenary.isImpostor == true)
                            {
                                Mercenary.Role.cosmetics.nameText.text =
                                    T_Impostors + Mercenary.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MercenaryColor + "(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC + CZ;

                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Mercenary.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Impostors + Mercenary.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_MercenaryColor + "(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Mercenary.Role.cosmetics.nameText.text =
                                    T_Crewmates + Mercenary.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MercenaryColor + "(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MercenaryTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Mercenary.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Crewmates + Mercenary.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_MercenaryColor + "(" + ChallengerMod.Set.Data.Role_Mercenary + ")" + CC
                                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.MercenaryTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_CopyCat
                        if (CopyCat.Role != null)
                        {
                            if (CopyCat.isImpostor == true)
                            {
                                CopyCat.Role.cosmetics.nameText.text =
                                    T_Impostors + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + STR_CopyCat_NewRoleName;

                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && CopyCat.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Impostors + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + STR_CopyCat_NewRoleName;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                CopyCat.Role.cosmetics.nameText.text =
                                    T_Crewmates + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                               + "\n" + Size4 + STR_CopyCat_NewRoleName
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.CopyCatTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && CopyCat.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Crewmates + CopyCat.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + STR_CopyCat_NewRoleName
                                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.CopyCatTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Revenger
                        if (Revenger.Role != null)
                        {
                            if (Revenger.isImpostor == true)
                            {
                                Revenger.Role.cosmetics.nameText.text =
                                    T_Impostors + Revenger.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_RevengerColor + "(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC + CZ;

                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Revenger.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Impostors + Revenger.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_RevengerColor + "(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Revenger.Role.cosmetics.nameText.text =
                                    T_Crewmates + Revenger.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_RevengerColor + "(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC
                                + " " + Q_Crew + "[" + ChallengerMod.Set.Data.RevengerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Revenger.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Crewmates + Revenger.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_RevengerColor + "(" + ChallengerMod.Set.Data.Role_Revenger + ")" + CC
                                            + " " + Q_Crew + "[" + ChallengerMod.Set.Data.RevengerTask + "/" + ChallengerMod.Set.Data.TotalTask + "]" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Survivor
                        if (Survivor.Role != null)
                        {
                            if (Survivor.Role.Data.IsDead)
                            {
                                Survivor.Role.cosmetics.nameText.text =
                                        T_Fail + Survivor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_SurvivorColor + "(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Survivor.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Survivor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_SurvivorColor + "(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Survivor.Role.cosmetics.nameText.text =
                                        T_Survivor + Survivor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_SurvivorColor + "(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Survivor.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Survivor + Survivor.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_SurvivorColor + "(" + ChallengerMod.Set.Data.Role_Survivor + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }

                        //SPECIAL_ROLE
                        //ROLE_Cupid
                        if (Cupid.Role != null)
                        {
                            if (Cupid.loverDie == true)
                            {
                                Cupid.Role.cosmetics.nameText.text =
                                        T_Fail + Cupid.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CupidColor + "(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cupid.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Cupid.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CupidColor + "(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Cupid.Role.cosmetics.nameText.text =
                                        T_Loves + Cupid.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CupidColor + "(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cupid.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Loves + Cupid.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CupidColor + "(" + ChallengerMod.Set.Data.Role_Cupid + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }

                        STR_Ts1 = "[";
                        STR_Ts2 = " vs <color=#FF0000>";
                        STR_Ts3 = "";


                        //ROLE_Cultist
                        if (Cultist.Role != null)
                        {
                            if (Cultist.totalcultemember <= 1f)
                            {
                                Cultist.Role.cosmetics.nameText.text =
                                        T_Fail + Cultist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CulteColor + "(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC
                                    + " " + Q_Culte + "[" + TotalCulteAlive + "</color><color=#FFFFFF> vs </color><color=#FF0000>" + (TotalPlayerAlive - TotalCulteAlive)  + "</color><color=#BC0AEF>]</color><color=#FFFFFF>" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cultist.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Cultist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CulteColor + "(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC
                                            + " " + Q_Culte + "[" + TotalCulteAlive + "</color><color=#FFFFFF> vs </color><color=#FF0000>" + (TotalPlayerAlive - TotalCulteAlive) + "</color><color=#BC0AEF>]</color><color=#FFFFFF>" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Cultist.Role.cosmetics.nameText.text =
                                        T_Cultes + Cultist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CulteColor + "(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC
                                            + " " + Q_Culte + "[" + TotalCulteAlive + "</color><color=#FFFFFF> vs </color><color=#FF0000>" + (TotalPlayerAlive - TotalCulteAlive) + "</color><color=#BC0AEF>]</color><color=#FFFFFF>" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cultist.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Cultes + Cultist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CulteColor + "(" + ChallengerMod.Set.Data.Role_Cultist + ")" + CC
                                            + " " + Q_Culte + "[" + TotalCulteAlive + "</color><color=#FFFFFF> vs </color><color=#FF0000>" + (TotalPlayerAlive - TotalCulteAlive) + "</color><color=#BC0AEF>]</color><color=#FFFFFF>" + CC + CZ;


                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Outlaw
                        if (Outlaw.Role != null)
                        {
                            if (Outlaw.Role.Data.IsDead || Outlaw.canKill == false)
                            {
                                Outlaw.Role.cosmetics.nameText.text =
                                        T_Fail + Outlaw.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_OutlawColor + "(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Outlaw.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Outlaw.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_OutlawColor + "(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Outlaw.Role.cosmetics.nameText.text =
                                        T_Outlaw + Outlaw.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_OutlawColor + "(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Outlaw.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Outlaw + Outlaw.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_OutlawColor + "(" + ChallengerMod.Set.Data.Role_Outlaw + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Jester
                        if (Jester.Role != null)
                        {
                            if (Jester.Role.Data.IsDead && Jester.Exiled == false)
                            {
                                Jester.Role.cosmetics.nameText.text =
                                        T_Fail + Jester.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_JesterColor + "(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Jester.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Jester.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_JesterColor + "(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Jester.Role.cosmetics.nameText.text =
                                        T_Jester + Jester.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_JesterColor + "(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Jester.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Jester + Jester.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_JesterColor + "(" + ChallengerMod.Set.Data.Role_Jester + ")" + CC + CZ;

                                        }
                                    }
                                }

                            }
                        }

                        //ROLE_Eater
                        if (Eater.Role != null)
                        {
                            if (Eater.Role.Data.IsDead)
                            {
                                Eater.Role.cosmetics.nameText.text =
                                        T_Fail + Eater.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_EaterColor + "(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC
                                    + " " + Q_Eater + "[" + ChallengerMod.Set.Data.EaterTask + "/" + Eatervaluewin + "]" + CC + CZ;


                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Eater.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Eater.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_EaterColor + "(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC
                                    + " " + Q_Eater + "[" + ChallengerMod.Set.Data.EaterTask + "/" + Eatervaluewin + "]" + CC + CZ;

                                        }
                                    }
                                }

                            }
                            else
                            {
                                Eater.Role.cosmetics.nameText.text =
                                        T_Eater + Eater.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_EaterColor + "(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC
                                + " " + Q_Eater + "[" + ChallengerMod.Set.Data.EaterTask + "/" + Eatervaluewin + "]" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Eater.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Eater + Eater.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_EaterColor + "(" + ChallengerMod.Set.Data.Role_Eater + ")" + CC
                                            + " " + Q_Eater + "[" + ChallengerMod.Set.Data.EaterTask + "/" + Eatervaluewin + "]" + CC + CZ;


                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Arsonist
                        if (Arsonist.Role != null)
                        {
                            if (Arsonist.Role.Data.IsDead)
                            {
                                Arsonist.Role.cosmetics.nameText.text =
                                        T_Fail + Arsonist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_ArsonistColor + "(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Arsonist.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Arsonist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_ArsonistColor + "(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC + CZ;


                                        }
                                    }
                                }

                            }
                            else
                            {
                                Arsonist.Role.cosmetics.nameText.text =
                                        T_Arsonist + Arsonist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_ArsonistColor + "(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC
                                    + " " + Q_Arsonist + "[" + ChallengerMod.Set.Data.TotalPlayerOil + "/" + (TotalPlayerAlive - 1) + "]" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Arsonist.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Arsonist + Arsonist.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_ArsonistColor + "(" + ChallengerMod.Set.Data.Role_Arsonist + ")" + CC
                                            + " " + Q_Arsonist + "[" + ChallengerMod.Set.Data.TotalPlayerOil + "/" + (TotalPlayerAlive - 1) + "]" + CC + CZ;


                                        }
                                    }
                                }

                            }
                        }
                        //ROLE_Cursed
                        if (Cursed.Role != null)
                        {
                            if (Cursed.Role.Data.IsDead)
                            {
                                Cursed.Role.cosmetics.nameText.text =
                                        T_Fail + Cursed.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CursedColor + "(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cursed.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Fail + Cursed.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CursedColor + "(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC + CZ;


                                        }
                                    }
                                }

                            }
                            else
                            {
                                Cursed.Role.cosmetics.nameText.text =
                                        T_Cursed + Cursed.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                    + "\n" + Size4 + R_CursedColor + "(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC
                                    + " " + Q_Imp + "[" + Cursed.CursePercent + "%"  + "]" + CC + CZ;



                                if (MeetingHud.Instance != null)
                                {
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    {
                                        if (player.NameText.text != null && Cursed.Role.PlayerId == player.TargetPlayerId)
                                        {
                                            player.NameText.text =
                                                T_Cursed + Cursed.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_CursedColor + "(" + ChallengerMod.Set.Data.Role_Cursed + ")" + CC
                                            + " " + Q_Imp + "[" + Cursed.CursePercent + "%" + "]" + CC + CZ;


                                        }
                                    }
                                }

                            }
                        }
                        //IMPOSTOR_ROLE
                        //ROLE_Assassin
                        if (Assassin.Role != null)
                        {
                            if (Assassin.Shielded)
                            {
                                Assassin.Role.cosmetics.nameText.text =
                                    T_Impostors + Assassin.Role.Data.PlayerName + CC + B_Shield  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_AssassinColor + "(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC + CZ;
                            }
                            else
                            {
                                Assassin.Role.cosmetics.nameText.text =
                                    T_Impostors + Assassin.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_AssassinColor + "(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC + CZ;
                            }
                            

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Assassin.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        if (Assassin.Shielded)
                                        {
                                            player.NameText.text =
                                            T_Impostors + Assassin.Role.Data.PlayerName + CC + B_Shield //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_AssassinColor + "(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC + CZ;
                                        }
                                        else
                                        {
                                            player.NameText.text =
                                            T_Impostors + Assassin.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                            + "\n" + Size4 + R_AssassinColor + "(" + ChallengerMod.Set.Data.Role_Assassin + ")" + CC + CZ;
                                        }

                                    }
                                }
                            }

                        }
                        //ROLE_Vector
                        if (Vector.Role != null)
                        {
                            Vector.Role.cosmetics.nameText.text =
                                    T_Impostors + Vector.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_VectorColor + "(" + ChallengerMod.Set.Data.Role_Vector + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Vector.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Vector.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_VectorColor + "(" + ChallengerMod.Set.Data.Role_Vector + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Morphling
                        if (Morphling.Role != null)
                        {
                            Morphling.Role.cosmetics.nameText.text =
                                    T_Impostors + Morphling.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MorphlingColor + "(" + ChallengerMod.Set.Data.Role_Morphling + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Morphling.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Morphling.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_MorphlingColor + "(" + ChallengerMod.Set.Data.Role_Morphling + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Scrambler
                        if (Scrambler.Role != null)
                        {
                            Scrambler.Role.cosmetics.nameText.text =
                                    T_Impostors + Scrambler.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_ScramblerColor + "(" + ChallengerMod.Set.Data.Role_Scrambler + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Scrambler.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Scrambler.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_ScramblerColor + "(" + ChallengerMod.Set.Data.Role_Scrambler + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Barghest
                        if (Barghest.Role != null)
                        {
                            Barghest.Role.cosmetics.nameText.text =
                                    T_Impostors + Barghest.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_BarghestColor + "(" + ChallengerMod.Set.Data.Role_Barghest + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Barghest.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Barghest.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_BarghestColor + "(" + ChallengerMod.Set.Data.Role_Barghest + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Ghost
                        if (Ghost.Role != null)
                        {
                            Ghost.Role.cosmetics.nameText.text =
                                    T_Impostors + Ghost.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_GhostColor + "(" + ChallengerMod.Set.Data.Role_Ghost + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Ghost.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Ghost.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_GhostColor + "(" + ChallengerMod.Set.Data.Role_Ghost + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Sorcerer
                        if (Sorcerer.Role != null)
                        {
                            Sorcerer.Role.cosmetics.nameText.text =
                                    T_Impostors + Sorcerer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SorcererColor + "(" + ChallengerMod.Set.Data.Role_Sorcerer + ")" + CC
                                + " " + Q_Imp + "[" + Sorcerer.TotalRuneLoot + "/" + "4" + "]" + CC + CZ;


                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Sorcerer.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Sorcerer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SorcererColor + "(" + ChallengerMod.Set.Data.Role_Sorcerer + ")" + CC
                                        + " " + Q_Imp + "[" + Sorcerer.TotalRuneLoot + "/" + "4" + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Guesser
                        if (Guesser.Role != null)
                        {
                            Guesser.Role.cosmetics.nameText.text =
                                    T_Impostors + Guesser.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_GuesserColor + "(" + ChallengerMod.Set.Data.Role_Guesser + ")" + CC
                                + " " + Q_Imp + "[" + Guesser.remainingShots + "/" + ChallengerOS.Utils.Option.CustomOptionHolder.Gestry.getFloat() + "]" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Guesser.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Guesser.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_GuesserColor + "(" + ChallengerMod.Set.Data.Role_Guesser + ")" + CC
                                        + " " + Q_Imp + "[" + Guesser.remainingShots + "/" + ChallengerOS.Utils.Option.CustomOptionHolder.Gestry.getFloat() + "]" + CC + CZ;


                                    }
                                }
                            }

                        }
                        //ROLE_Mesmer
                        if (Mesmer.Role != null)
                        {
                            Mesmer.Role.cosmetics.nameText.text =
                                    T_Impostors + Mesmer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_MesmerColor + "(" + ChallengerMod.Set.Data.Role_Mesmer + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Mesmer.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Mesmer.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_MesmerColor + "(" + ChallengerMod.Set.Data.Role_Mesmer + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Basilisk
                        if (Basilisk.Role != null)
                        {
                            Basilisk.Role.cosmetics.nameText.text =
                                    T_Impostors + Basilisk.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_BasiliskColor + "(" + ChallengerMod.Set.Data.Role_Basilisk + ")" + CC
                                + " " + Q_Imp + "[" + Basilisk.PetrifyCount + "/" + Basilisk.PetrifyMax + "]" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Basilisk.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Basilisk.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_BasiliskColor + "(" + ChallengerMod.Set.Data.Role_Basilisk + ")" + CC
                                        + " " + Q_Imp + "[" + Basilisk.PetrifyCount + "/" + Basilisk.PetrifyMax + "]" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Reaper
                        if (Reaper.Role != null)
                        {
                            Reaper.Role.cosmetics.nameText.text =
                                    T_Impostors + Reaper.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_ReaperColor + "(" + ChallengerMod.Set.Data.Role_Reaper + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Reaper.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Reaper.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_ReaperColor + "(" + ChallengerMod.Set.Data.Role_Reaper + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Saboteur
                        if (Saboteur.Role != null)
                        {
                            Saboteur.Role.cosmetics.nameText.text =
                                    T_Impostors + Saboteur.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_SaboteurColor + "(" + ChallengerMod.Set.Data.Role_Saboteur + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Saboteur.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Saboteur.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_SaboteurColor + "(" + ChallengerMod.Set.Data.Role_Saboteur + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //IMPOSTOR VANILLA
                        //ROLE_Impostor1
                        if (Impostor1.Role != null)
                        {
                            Impostor1.Role.cosmetics.nameText.text =
                                    T_Impostors + Impostor1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Impostor1.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Impostor1.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Impostor2
                        if (Impostor2.Role != null)
                        {
                            Impostor2.Role.cosmetics.nameText.text =
                                    T_Impostors + Impostor2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Impostor2.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Impostor2.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        //ROLE_Impostor3
                        if (Impostor3.Role != null)
                        {
                            Impostor3.Role.cosmetics.nameText.text =
                                    T_Impostors + Impostor3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                            if (MeetingHud.Instance != null)
                            {
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Impostor3.Role.PlayerId == player.TargetPlayerId)
                                    {
                                        player.NameText.text =
                                            T_Impostors + Impostor3.Role.Data.PlayerName + CC  //PlayerName + PlayerTeam
                                        + "\n" + Size4 + R_ImpostorColor + "(" + ChallengerMod.Set.Data.Role_Impostor + ")" + CC + CZ;

                                    }
                                }
                            }

                        }
                        // BUFFS
                        //GUARDIUAN SHIELD
                        if (Guardian.Role != null && Guardian.Protected != null)
                        {
                            if (Guardian.Protected.cosmetics.nameText.text.Contains(B_Shield)) { }
                            else { Guardian.Protected.cosmetics.nameText.text += B_Shield; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && Guardian.Protected.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Shield)) { }
                                        else { player.NameText.text += B_Shield; }
                                    }
                        }
                        //HUNTER TRACK 
                        if (Hunter.Role != null && Hunter.Tracked != null)
                        {

                            if (Hunter.Tracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                            else { Hunter.Tracked.cosmetics.nameText.text += B_Tracker; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && Hunter.Tracked.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Tracker)) { }
                                        else { player.NameText.text += B_Tracker; }
                                    }

                        }
                        if (CopyCat.Role != null && CopyCat.copyRole == 5 && CopyCat.CopyStart && Hunter.CopyTracked != null)
                        {

                            if (Hunter.CopyTracked.cosmetics.nameText.text.Contains(B_Tracker)) { }
                            else { Hunter.CopyTracked.cosmetics.nameText.text += B_Tracker; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && Hunter.CopyTracked.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Tracker)) { }
                                        else { player.NameText.text += B_Tracker; }
                                    }

                        }
                        //LEADERMARK (ONLY MEETING)
                        if (Leader.Target != null)
                        {
                            if (Leader.Target.cosmetics.nameText.text.Contains(B_LeaderMark)) { }
                            else { Leader.Target.cosmetics.nameText.text += B_LeaderMark; }

                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Leader.Target.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMark)) { }
                                        else { player.NameText.text += B_LeaderMark; }
                                    }
                                }
                        }
                        if (Leader.Target2 != null)
                        {
                            if (Leader.Target2.cosmetics.nameText.text.Contains(B_LeaderMark)) { }
                            else { Leader.Target2.cosmetics.nameText.text += B_LeaderMark; }

                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && Leader.Target2.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMark)) { }
                                        else { player.NameText.text += B_LeaderMark; }
                                    }
                                }
                        }
                        //LEADERMARK COPY
                        if (CopyCat.Target != null)
                        {
                            if (CopyCat.Target.cosmetics.nameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                            else { CopyCat.Target.cosmetics.nameText.text += B_LeaderMarkCopyIfExist; }

                            
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && CopyCat.Target.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                                        else { player.NameText.text += B_LeaderMarkCopyIfExist; }
                                    }
                                }
                        }
                        if (CopyCat.Target2 != null)
                        {
                            if (CopyCat.Target2.cosmetics.nameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                            else { CopyCat.Target2.cosmetics.nameText.text += B_LeaderMarkCopyIfExist; }


                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                {
                                    if (player.NameText.text != null && CopyCat.Target2.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_LeaderMarkCopyIfExist)) { }
                                        else { player.NameText.text += B_LeaderMarkCopyIfExist; }
                                    }
                                }
                        }
                        //VECTOR INFECTED
                        if (Vector.Role != null && Vector.Infected != null)
                        {

                            if (Vector.Infected.cosmetics.nameText.text.Contains(B_Infect)) { }
                            else { Vector.Infected.cosmetics.nameText.text += B_Infect; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && Vector.Infected.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Infect)) { }
                                        else { player.NameText.text += B_Infect; }
                                    }

                        }

                        //BASILISK PETRIFIED
                        if (Basilisk.Role != null && Basilisk.Petrified != null && !Basilisk.PetrifyAndShield)
                        {
                            
                                if (Basilisk.Petrified.cosmetics.nameText.text.Contains(B_Petrified)) { }
                                else { Basilisk.Petrified.cosmetics.nameText.text += B_Petrified; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Basilisk.Petrified.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Petrified)) { }
                                            else { player.NameText.text += B_Petrified; }
                                        }
                            

                        }
                        if (Basilisk.Role != null && Basilisk.Petrified != null && Basilisk.PetrifyAndShield)
                        {

                                if (Basilisk.Petrified.cosmetics.nameText.text.Contains(B_Petrified2)) { }
                                else { Basilisk.Petrified.cosmetics.nameText.text += B_Petrified2; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Basilisk.Petrified.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Petrified2)) { }
                                            else { player.NameText.text += B_Petrified2; }
                                        }
                            

                        }
                        //COPYCAT COPY
                        if (CopyCat.Role != null && CopyCat.CopiedPlayer != null)
                        {


                            if (CopyCat.CopiedPlayer.cosmetics.nameText.text.Contains(B_Copy)) { }
                            else { CopyCat.CopiedPlayer.cosmetics.nameText.text += B_Copy; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && CopyCat.CopiedPlayer.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Copy)) { }
                                        else { player.NameText.text += B_Copy; }
                                    }


                        }
                        //REVENGER
                        //EMP1
                        if (Revenger.Role != null && Revenger.EMP1 != null)
                        {

                            if (Revenger.EMP1_On == true) //ENABLE
                            {
                                if (Revenger.EMP1.cosmetics.nameText.text.Contains(B_EMP_On)) { }
                                else { Revenger.EMP1.cosmetics.nameText.text += B_EMP_On; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_On)) { }
                                            else { player.NameText.text += B_EMP_On; }
                                        }
                            }
                            else
                            {
                                if (Revenger.EMP1.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                else { Revenger.EMP1.cosmetics.nameText.text += B_EMP_Off; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_Off)) { }
                                            else { player.NameText.text += B_EMP_Off; }
                                        }

                            }

                        }

                        //EMP2
                        if (Revenger.Role != null && Revenger.EMP2 != null)
                        {

                            if (Revenger.EMP2_On == true) //ENABLE
                            {
                                if (Revenger.EMP2.cosmetics.nameText.text.Contains(B_EMP_On)) { }
                                else { Revenger.EMP2.cosmetics.nameText.text += B_EMP_On; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_On)) { }
                                            else { player.NameText.text += B_EMP_On; }
                                        }
                            }
                            else
                            {
                                if (Revenger.EMP2.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                else { Revenger.EMP2.cosmetics.nameText.text += B_EMP_Off; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_Off)) { }
                                            else { player.NameText.text += B_EMP_Off; }
                                        }
                            }

                        }

                        //EMP3
                        if (Revenger.Role != null && Revenger.EMP3 != null)
                        {

                            if (Revenger.EMP3_On == true) //ENABLE
                            {
                                if (Revenger.EMP3.cosmetics.nameText.text.Contains(B_EMP_On)) { }
                                else { Revenger.EMP3.cosmetics.nameText.text += B_EMP_On; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP3.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_On)) { }
                                            else { player.NameText.text += B_EMP_On; }
                                        }
                            }
                            else
                            {
                                if (Revenger.EMP3.cosmetics.nameText.text.Contains(B_EMP_Off)) { }
                                else { Revenger.EMP3.cosmetics.nameText.text += B_EMP_Off; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Revenger.EMP3.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_EMP_Off)) { }
                                            else { player.NameText.text += B_EMP_Off; }
                                        }
                            }

                        }

                        // INFORMANT NICE INFORMED
                        if (Informant.Role != null && Informant.Informed != null)
                        {


                            if (Informant.Informed.cosmetics.nameText.text.Contains(B_Infored)) { }
                            else { Informant.Informed.cosmetics.nameText.text += B_Infored; }
                            if (MeetingHud.Instance != null)
                                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                    if (player.NameText.text != null && Informant.Informed.PlayerId == player.TargetPlayerId)
                                    {
                                        if (player.NameText.text.Contains(B_Infored)) { }
                                        else { player.NameText.text += B_Infored; }
                                    }


                        }
                        
                        // CUPID AND LOVER
                        // CUPID LOVER 1
                        if (Cupid.Role != null && Cupid.Lover1 != null)
                        {

                            if (Cupid.loverDie == false)
                            {
                                if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Alive; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                            else { player.NameText.text += B_Lover_Alive; }
                                        }
                            }
                            else
                            {
                                if (Cupid.Lover1.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                else { Cupid.Lover1.cosmetics.nameText.text += B_Lover_Die; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cupid.Lover1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Lover_Die)) { }
                                            else { player.NameText.text += B_Lover_Die; }
                                        }
                            }

                        }
                        // CUPID LOVER 2
                        if (Cupid.Role != null && Cupid.Lover2 != null)
                        {

                            if (Cupid.loverDie == false)

                            {
                                if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Alive)) { }
                                else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Alive; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Lover_Alive)) { }
                                            else { player.NameText.text += B_Lover_Alive; }
                                        }
                            }
                            else
                            {
                                if (Cupid.Lover2.cosmetics.nameText.text.Contains(B_Lover_Die)) { }
                                else { Cupid.Lover2.cosmetics.nameText.text += B_Lover_Die; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cupid.Lover2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Lover_Die)) { }
                                            else { player.NameText.text += B_Lover_Die; }
                                        }
                            }

                        }

                        // CULTE MEMBER VISION
                        // CULTE MEMBER 1
                        if (Cultist.Role != null && Cultist.Culte1 != null)
                        {

                            if (!Cultist.Culte1.Data.IsDead)
                            {
                                if (Cultist.Culte1.cosmetics.nameText.text.Contains(B_Culte_Alive)) { }
                                else { Cultist.Culte1.cosmetics.nameText.text += B_Culte_Alive; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Alive)) { }
                                            else { player.NameText.text += B_Culte_Alive; }
                                        }
                            }
                            else
                            {
                                if (Cultist.Culte1.cosmetics.nameText.text.Contains(B_Culte_Die)) { }
                                else { Cultist.Culte1.cosmetics.nameText.text += B_Culte_Die; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte1.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Die)) { }
                                            else { player.NameText.text += B_Culte_Die; }
                                        }
                            }

                        }

                        // CULTE MEMBER 2
                        if (Cultist.Role != null && Cultist.Culte2 != null)
                        {

                            if (!Cultist.Culte2.Data.IsDead)
                            {
                                if (Cultist.Culte2.cosmetics.nameText.text.Contains(B_Culte_Alive)) { }
                                else { Cultist.Culte2.cosmetics.nameText.text += B_Culte_Alive; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Alive)) { }
                                            else { player.NameText.text += B_Culte_Alive; }
                                        }
                            }
                            else
                            {
                                if (Cultist.Culte2.cosmetics.nameText.text.Contains(B_Culte_Die)) { }
                                else { Cultist.Culte2.cosmetics.nameText.text += B_Culte_Die; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte2.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Die)) { }
                                            else { player.NameText.text += B_Culte_Die; }
                                        }
                            }

                        }

                        // CULTE MEMBER 3
                        if (Cultist.Role != null && Cultist.Culte3 != null)
                        {

                            if (!Cultist.Culte3.Data.IsDead)
                            {
                                if (Cultist.Culte3.cosmetics.nameText.text.Contains(B_Culte_Alive)) { }
                                else { Cultist.Culte3.cosmetics.nameText.text += B_Culte_Alive; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte3.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Alive)) { }
                                            else { player.NameText.text += B_Culte_Alive; }
                                        }
                            }
                            else
                            {
                                if (Cultist.Culte3.cosmetics.nameText.text.Contains(B_Culte_Die)) { }
                                else { Cultist.Culte3.cosmetics.nameText.text += B_Culte_Die; }
                                if (MeetingHud.Instance != null)
                                    foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                                        if (player.NameText.text != null && Cultist.Culte3.PlayerId == player.TargetPlayerId)
                                        {
                                            if (player.NameText.text.Contains(B_Culte_Die)) { }
                                            else { player.NameText.text += B_Culte_Die; }
                                        }
                            }

                        }


                    }
                    return;

                }
                
            }

            








        }
    }
}
        
    
