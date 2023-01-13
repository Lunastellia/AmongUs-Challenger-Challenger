using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ChallengerMod.Challenger;
using static ChallengerMod.Unity;
using UnityEngine.UI;
using Il2CppSystem.Collections;
using static ChallengerMod.HarmonyMain;
using ChallengerMod.Utility.Utils;
using Steamworks;
using UnityEngine.Video;

namespace ChallengerMod
{

    public static class SpritePatches
    {
        private static Dictionary<string, Sprite> SpriteUI;
        private static Dictionary<string, Vector4> PositionUI;
        public static bool AccountTAB = false;
        public static bool RankB3 = false;
        public static bool RankB2 = false;
        public static bool RankB1 = false;

        public static bool RankS3 = false;
        public static bool RankS2 = false;
        public static bool RankS1 = false;

        public static bool RankG3 = false;
        public static bool RankG2 = false;
        public static bool RankG1 = false;

        public static bool RankP3 = false;
        public static bool RankP2 = false;
        public static bool RankP1 = false;

        public static bool RankD = false;
        public static bool RankM = false;

        public static bool Rank0 = false;
        public static float RankValue { get; set; }




        public static void Patch()
        {
            SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)ChallengerUI);
        }


        private static void ChallengerUI(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (GameObject.Find("PlayOnlineButton") || (GameObject.Find("AmongUsLogo")))

            {
                SpriteUI = new Dictionary<string, Sprite>()
                {
                { "AmongUsLogo", LoginBannerMini },
                };
                PositionUI = new Dictionary<string, Vector4>()
                {
                    //EDIT
                    { "AmongUsLogo", new Vector4(0, -2, 0, 0) },
                };
            }
            if (GameObject.Find("HostGameButton"))
            {
                SpriteUI = new Dictionary<string, Sprite>()
                {
                    { "NormalMenu", E1 },
                    { "arrowEnter", MapIco },
                };


            }


            

            foreach (var (StringName, SpriteChange) in SpriteUI)
            {
                var original = GameObject.Find(StringName);

                var Star = GameObject.Find("Ambience"); //delete
                Star.transform.localScale = new Vector3(0f, 0f, 0f);


                //if (GameObject.Find("AnnounceButton"))
                // {

                if (GameObject.Find("AccountManager/Loading/TitleText_TMP/AmongUsLogo"))
                {
                    var AmongUsLogo = GameObject.Find("AccountManager/Loading/TitleText_TMP/AmongUsLogo");
                    AmongUsLogo.GetComponent<SpriteRenderer>().sprite = LoginBannerMini;
                    AmongUsLogo.transform.localPosition = new Vector3(0.2f, 2.5f, 1f);
                }
                else
                {

                }

                var menuHostBanner1 = GameObject.Find("bannerLogo_AmongUs");
                    menuHostBanner1.GetComponent<SpriteRenderer>().sprite = empty;
                    menuHostBanner1.transform.localPosition = new Vector3(0f, -1.2f, 1f);

                   // SpriteAnimUtils.StartAnimationLogin(LoginAnimation, GameObject.Find("bannerLogo_AmongUs").transform.position, 1f, 1f);
                    SpriteAnimUtils.StartAnimation3(Logo, GameObject.Find("bannerLogo_AmongUs").transform.position, 1.1f, 1f);
                    GameObject.Find("LogoChallenger").transform.localPosition = new Vector3(0.1f, 1.3f, -5f);
                   // GameObject.Find("Login_Anim").transform.localPosition = new Vector3(0f, 0f, 0.5f);
                    //BOTTON MENU
                    var BottomButtons = GameObject.Find("BottomButtons");//PARENT
                    BottomButtons.transform.localPosition = new Vector3(0.24f, -2.64f, -5f);
                    BottomButtons.transform.localScale = new Vector3(0.75f, 0.75f, 1f);

                /* var AnnounceButton = GameObject.Find("AnnounceButton");
                 AnnounceButton.GetComponent<SpriteRenderer>().sprite = news;
                 var OptionsButton = GameObject.Find("OptionsButton");
                 OptionsButton.GetComponent<SpriteRenderer>().sprite = settings;
                 var CreditsButton = GameObject.Find("CreditsButton");
                 CreditsButton.GetComponent<SpriteRenderer>().sprite = inner;
                 //var SubCreditsButton = GameObject.Find("SubCreditsButton");
                 var StatsButton = GameObject.Find("StatsButton");
                 StatsButton.GetComponent<SpriteRenderer>().sprite = stats;
                 StatsButton.transform.localScale = new Vector3(0f, 0f, 0f);
                 var StoreButton = GameObject.Find("StoreButton");
                 StoreButton.GetComponent<SpriteRenderer>().sprite = shop;
                 var InventoryButton = GameObject.Find("InventoryButton");
                 InventoryButton.GetComponent<SpriteRenderer>().sprite = Inventory;
                 InventoryButton.transform.localScale = new Vector3(0.67f, 0.67f, 1f);
                 InventoryButton.transform.position = new Vector3(4f,0f, 1f);*/

                /*
                  SpriteAnimUtils.StartAnimationLogin(LoginAnimation, GameObject.Find("bannerLogo_AmongUs").transform.position, 0f, 1f);
                GameObject LoginAnimationV2 = new GameObject("VideoPlayerModule");
                 LoginAnimationV2.transform.localPosition = new Vector3(0f, 0f, 3f);*/
                
                





                
                




                

                //MID MENU
                var HowToPlayButton = GameObject.Find("HowToPlayButton");
                    HowToPlayButton.transform.localScale = new Vector3(0f, 0f, 0f);
                    var PlayLocalButton = GameObject.Find("PlayLocalButton");
                    PlayLocalButton.transform.localScale = new Vector3(0f, 0f, 0f);
                    var FreePlayButton = GameObject.Find("FreePlayButton");
                    FreePlayButton.transform.localScale = new Vector3(0f, 0f, 0f);
                    var PlayOnlineButton = GameObject.Find("PlayOnlineButton");
                    PlayOnlineButton.transform.localScale = new Vector3(0f, 0f, 0f);

                    var FriendsListManager = GameObject.Find("FriendsListManager");
                    FriendsListManager.transform.localScale = new Vector3(0f, 0f, 0f);
                    var AccountManager = GameObject.Find("AccountManager").transform.FindChild("AccountTab").transform.FindChild("AccountWindow").transform.FindChild("Tab");
                    AccountManager.transform.localScale = new Vector3(0.84f, 0.84f, 1f);
                    AccountManager.transform.localPosition = new Vector3(0.53f, -1.82f, 0f);


                    var CustomButton = GameObject.Find("OptionsButton");
                    if (CustomButton == null) return;


                    var Lang_Auto = UnityEngine.Object.Instantiate(CustomButton, null);
                    Lang_Auto.transform.name = "ChallengerUI_FlagAUTO";
                    Lang_Auto.transform.localPosition = new Vector3(-0.6f, -2f, 0f);
                    Lang_Auto.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    PassiveButton BLang_Auto = Lang_Auto.GetComponent<PassiveButton>();
                    BLang_Auto.OnClick = new Button.ButtonClickedEvent();
                    BLang_Auto.OnClick.AddListener((UnityEngine.Events.UnityAction)Set_Lang_Auto);
                    BoxCollider2D BLang_Auto_Collider = BLang_Auto.GetComponent<BoxCollider2D>();

                    if (ChallengerMod.Challenger.LangGameSet == 0f)
                    {
                        BLang_Auto.GetComponent<SpriteRenderer>().sprite = FAU1; // 
                        BLang_Auto_Collider.size = new Vector2(1f, 1f);
                    }
                    else
                    {
                        BLang_Auto.GetComponent<SpriteRenderer>().sprite = FAU0; // 
                        BLang_Auto_Collider.size = new Vector2(1f, 1f);
                    }



                    var Lang_FR = UnityEngine.Object.Instantiate(CustomButton, null);
                    Lang_FR.transform.name = "ChallengerUI_FlagFR";
                    Lang_FR.transform.localPosition = new Vector3(0.6f, -2f, 0f);
                    Lang_FR.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    PassiveButton BLang_FR = Lang_FR.GetComponent<PassiveButton>();
                    BLang_FR.OnClick = new Button.ButtonClickedEvent();
                    BLang_FR.OnClick.AddListener((UnityEngine.Events.UnityAction)Set_Lang_FR);
                    BoxCollider2D BLang_FR_Collider = BLang_FR.GetComponent<BoxCollider2D>();

                    if (ChallengerMod.Challenger.LangGameSet == 2f)
                    {
                        BLang_FR.GetComponent<SpriteRenderer>().sprite = FFR1; // 
                        BLang_FR_Collider.size = new Vector2(1f, 1f);
                    }
                    else
                    {
                        BLang_FR.GetComponent<SpriteRenderer>().sprite = FFR0; // 
                        BLang_FR_Collider.size = new Vector2(1f, 1f);
                    }


                    var Lang_EN = UnityEngine.Object.Instantiate(CustomButton, null);
                    Lang_FR.transform.name = "ChallengerUI_FlagEN";
                    Lang_EN.transform.localPosition = new Vector3(-0f, -2f, 0f);
                    Lang_EN.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    PassiveButton BLang_EN = Lang_EN.GetComponent<PassiveButton>();
                    BLang_EN.OnClick = new Button.ButtonClickedEvent();
                    BLang_EN.OnClick.AddListener((UnityEngine.Events.UnityAction)Set_Lang_EN);
                    BoxCollider2D BLang_EN_Collider = BLang_EN.GetComponent<BoxCollider2D>();

                    if (ChallengerMod.Challenger.LangGameSet == 1f)
                    {
                        BLang_EN.GetComponent<SpriteRenderer>().sprite = FEN1; // 
                        BLang_EN_Collider.size = new Vector2(1f, 1f);
                    }
                    else
                    {
                        BLang_EN.GetComponent<SpriteRenderer>().sprite = FEN0; // 
                        BLang_EN_Collider.size = new Vector2(1f, 1f);
                    }

                    void Set_Lang_Auto()
                    {
                        Challenger.LangGameSet = 0f;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        ChallengerMod.Set.Data.Playerlang = TranslationController.Instance.currentLanguage.languageID.ToString();
                    }
                    void Set_Lang_FR()
                    {
                        Challenger.LangGameSet = 2f;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        ChallengerMod.Set.Data.Playerlang = TranslationController.Instance.currentLanguage.languageID.ToString();
                    }
                    void Set_Lang_EN()
                    {
                        Challenger.LangGameSet = 1f;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        ChallengerMod.Set.Data.Playerlang = TranslationController.Instance.currentLanguage.languageID.ToString();
                    }



                    var button = UnityEngine.Object.Instantiate(CustomButton, null);
                    var newbuttonR = UnityEngine.Object.Instantiate(CustomButton, null);
                    var newbuttonL = UnityEngine.Object.Instantiate(CustomButton, null);
                    var newbutton = UnityEngine.Object.Instantiate(CustomButton, null);

                    button.transform.name = "ChallengerUI_DiscordButton";
                    newbutton.transform.name = "ChallengerUI_PlayNormalButton";
                    newbuttonR.transform.name = "ChallengerUI_PlayRankedButton";
                    newbuttonL.transform.name = "ChallengerUI_GoodlossLoginButton";

                    button.transform.localPosition = new Vector3(-2f, -1.15f, 0f);
                    button.transform.localScale = new Vector3(0.6f, 0.45f, 1f);//icon
                    newbutton.transform.localPosition = new Vector3(0f, -0.95f, 0f);
                    newbutton.transform.localScale = new Vector3(0.8f, 0.52f, 1f);//play
                    newbuttonR.transform.localPosition = new Vector3(0f, -1.45f, 0f);
                    newbuttonR.transform.localScale = new Vector3(0.8f, 0.52f, 1f);//ranked
                    
                    newbuttonL.transform.localPosition = new Vector3(2f, -1.15f, 0f);
                    newbuttonL.transform.localScale = new Vector3(0.6f, 0.45f, 1f);//Loggin

                    PassiveButton passiveButton = button.GetComponent<PassiveButton>();
                    passiveButton.OnClick = new Button.ButtonClickedEvent();
                    passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);

                    PassiveButton bttn = newbutton.GetComponent<PassiveButton>();
                    bttn.OnClick = new Button.ButtonClickedEvent();
                    bttn.OnClick.AddListener((UnityEngine.Events.UnityAction)toClick);

                    PassiveButton bttn2 = newbuttonR.GetComponent<PassiveButton>();
                    bttn2.OnClick = new Button.ButtonClickedEvent();
                    bttn2.OnClick.AddListener((UnityEngine.Events.UnityAction)goClick);

                    PassiveButton bttn3 = newbuttonL.GetComponent<PassiveButton>();
                    // bttn3.OnClick = new Button.ButtonClickedEvent();
                    bttn3.OnClick.AddListener((UnityEngine.Events.UnityAction)logClick);

                    var sprite = button.GetComponent<SpriteRenderer>().sprite;
                    //CustomButton.GetComponent<SpriteRenderer>().sprite = settings;
                    
                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                {
                    bttn.GetComponent<SpriteRenderer>().sprite = StartGame_FR;
                }
                else
                {
                    bttn.GetComponent<SpriteRenderer>().sprite = StartGame;
                }
                    BoxCollider2D boxNsize = bttn.GetComponent<BoxCollider2D>();
                    boxNsize.size = new Vector2(2.45f, 0.8f);
                    BoxCollider2D boxLsize = bttn3.GetComponent<BoxCollider2D>();
                    boxLsize.size = new Vector2(2.2f, 2.1f);
                    BoxCollider2D boxNRsize = bttn2.GetComponent<BoxCollider2D>();


                //var OptionGL = GameObject.Find("OptionsMenu").transform.FindChild("MatuxAccountPopUp");


                //OptionGL.transform.localPosition = new Vector3(0.70f, 0.55f, 1f);//Loggin



                //if (MatuxMod.MatuxMod.isLoggedIn() == true)
                // {
                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                {
                    bttn2.GetComponent<SpriteRenderer>().sprite = StartGameR_FR;
                }
                else
                {
                    bttn2.GetComponent<SpriteRenderer>().sprite = StartGameR;
                }
                
                    boxNRsize.size = new Vector2(2.45f, 0.8f);
                if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                {
                    bttn3.GetComponent<SpriteRenderer>().sprite = GLLog1_FR;
                }
                else
                {
                    bttn3.GetComponent<SpriteRenderer>().sprite = GLLog1;
                }
                
                    //  }
                    // else
                    // {
                    //      bttn2.GetComponent<SpriteRenderer>().sprite = StartGameR0;
                    //       boxNRsize.size = new Vector2(0f, 0f);
                    //      bttn3.GetComponent<SpriteRenderer>().sprite = GLLog0;
                    //  }





                    passiveButton.GetComponent<SpriteRenderer>().sprite = DiscordJoin; // discord
                    BoxCollider2D boxNDsize = passiveButton.GetComponent<BoxCollider2D>();
                    boxNDsize.size = new Vector2(2.2f, 2.1f);




                    var rend = newbutton.GetComponent<SpriteRenderer>().sprite;
                    rend = settings;

                
                if (GameObject.Find("RK_Text"))
                {
                    var ClearText = GameObject.Find("RK_Text");
                    ClearText.transform.localPosition = new Vector3(99f, 99f, -1f);
                }

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

                void toClick()
                {
                    // ChallengerMod.HarmonyMain.Ranked.SetValue(false);
                    SceneChanger.ChangeScene("MMOnline");

                    GLMod.GLMod.disableService("StartGame");
                    GLMod.GLMod.disableService("EndGame");
                    GLMod.GLMod.disableService("Kills");
                   

                    GLMod.GLMod.setModName("Challenger");
                    newbutton.SetActive(false);
                    Challenger.IsrankedGame = false;
                    Challenger.isRankedGame = false;

                    IsrankedGameSet = 100f;
                    ChallengerMod.Set.Data.Playerlang = TranslationController.Instance.currentLanguage.languageID.ToString();

                    // ChallengerMod.SteamAPPDLC.appDLC.ISteamUser();
                    ChallengerMod.Utility.Discord.DiscordData.Initialize();
                    if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C") {  ChallengerMod.Challenger.KeycodeKill = KeyCode.A; }
                    else  { ChallengerMod.Challenger.KeycodeKill = KeyCode.Q;}

                    if (GLMod.GLMod.isLoggedIn() == true)
                    {
                        GLMod.GLMod.getRank();
                        GLMod.GLMod.reloadItems();

                    }
                    
                    if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                    {
                        ChallengerMod.Set.Data.R_Unranked = ChallengerMod.Set.Data.R_UnrankedFR;
                        ChallengerMod.Set.Data.R_B1 = ChallengerMod.Set.Data.R_B1FR;
                        ChallengerMod.Set.Data.R_B2 = ChallengerMod.Set.Data.R_B2FR;
                        ChallengerMod.Set.Data.R_B3 = ChallengerMod.Set.Data.R_B3FR;
                        ChallengerMod.Set.Data.R_S1 = ChallengerMod.Set.Data.R_S1FR;
                        ChallengerMod.Set.Data.R_S2 = ChallengerMod.Set.Data.R_S2FR;
                        ChallengerMod.Set.Data.R_S3 = ChallengerMod.Set.Data.R_S3FR;
                        ChallengerMod.Set.Data.R_G1 = ChallengerMod.Set.Data.R_G1FR;
                        ChallengerMod.Set.Data.R_G2 = ChallengerMod.Set.Data.R_G2FR;
                        ChallengerMod.Set.Data.R_G3 = ChallengerMod.Set.Data.R_G3FR;
                        ChallengerMod.Set.Data.R_C1 = ChallengerMod.Set.Data.R_C1FR;
                        ChallengerMod.Set.Data.R_C2 = ChallengerMod.Set.Data.R_C2FR;
                        ChallengerMod.Set.Data.R_C3 = ChallengerMod.Set.Data.R_C3FR;
                        ChallengerMod.Set.Data.R_E = ChallengerMod.Set.Data.R_EFR;
                        ChallengerMod.Set.Data.R_M = ChallengerMod.Set.Data.R_MFR;

                        ChallengerMod.Set.Data.DR_Unranked = ChallengerMod.Set.Data.DR_UnrankedFR;
                        ChallengerMod.Set.Data.DR_B1 = ChallengerMod.Set.Data.DR_B1FR;
                        ChallengerMod.Set.Data.DR_B2 = ChallengerMod.Set.Data.DR_B2FR;
                        ChallengerMod.Set.Data.DR_B3 = ChallengerMod.Set.Data.DR_B3FR;
                        ChallengerMod.Set.Data.DR_S1 = ChallengerMod.Set.Data.DR_S1FR;
                        ChallengerMod.Set.Data.DR_S2 = ChallengerMod.Set.Data.DR_S2FR;
                        ChallengerMod.Set.Data.DR_S3 = ChallengerMod.Set.Data.DR_S3FR;
                        ChallengerMod.Set.Data.DR_G1 = ChallengerMod.Set.Data.DR_G1FR;
                        ChallengerMod.Set.Data.DR_G2 = ChallengerMod.Set.Data.DR_G2FR;
                        ChallengerMod.Set.Data.DR_G3 = ChallengerMod.Set.Data.DR_G3FR;
                        ChallengerMod.Set.Data.DR_C1 = ChallengerMod.Set.Data.DR_C1FR;
                        ChallengerMod.Set.Data.DR_C2 = ChallengerMod.Set.Data.DR_C2FR;
                        ChallengerMod.Set.Data.DR_C3 = ChallengerMod.Set.Data.DR_C3FR;
                        ChallengerMod.Set.Data.DR_E = ChallengerMod.Set.Data.DR_EFR;
                        ChallengerMod.Set.Data.DR_M = ChallengerMod.Set.Data.DR_MFR;

                    }
                    else
                    {
                        ChallengerMod.Set.Data.R_Unranked = ChallengerMod.Set.Data.R_UnrankedEN;
                        ChallengerMod.Set.Data.R_B1 = ChallengerMod.Set.Data.R_B1EN;
                        ChallengerMod.Set.Data.R_B2 = ChallengerMod.Set.Data.R_B2EN;
                        ChallengerMod.Set.Data.R_B3 = ChallengerMod.Set.Data.R_B3EN;
                        ChallengerMod.Set.Data.R_S1 = ChallengerMod.Set.Data.R_S1EN;
                        ChallengerMod.Set.Data.R_S2 = ChallengerMod.Set.Data.R_S2EN;
                        ChallengerMod.Set.Data.R_S3 = ChallengerMod.Set.Data.R_S3EN;
                        ChallengerMod.Set.Data.R_G1 = ChallengerMod.Set.Data.R_G1EN;
                        ChallengerMod.Set.Data.R_G2 = ChallengerMod.Set.Data.R_G2EN;
                        ChallengerMod.Set.Data.R_G3 = ChallengerMod.Set.Data.R_G3EN;
                        ChallengerMod.Set.Data.R_C1 = ChallengerMod.Set.Data.R_C1EN;
                        ChallengerMod.Set.Data.R_C2 = ChallengerMod.Set.Data.R_C2EN;
                        ChallengerMod.Set.Data.R_C3 = ChallengerMod.Set.Data.R_C3EN;
                        ChallengerMod.Set.Data.R_E = ChallengerMod.Set.Data.R_EEN;
                        ChallengerMod.Set.Data.R_M = ChallengerMod.Set.Data.R_MEN;

                        ChallengerMod.Set.Data.DR_Unranked = ChallengerMod.Set.Data.DR_UnrankedEN;
                        ChallengerMod.Set.Data.DR_B1 = ChallengerMod.Set.Data.DR_B1EN;
                        ChallengerMod.Set.Data.DR_B2 = ChallengerMod.Set.Data.DR_B2EN;
                        ChallengerMod.Set.Data.DR_B3 = ChallengerMod.Set.Data.DR_B3EN;
                        ChallengerMod.Set.Data.DR_S1 = ChallengerMod.Set.Data.DR_S1EN;
                        ChallengerMod.Set.Data.DR_S2 = ChallengerMod.Set.Data.DR_S2EN;
                        ChallengerMod.Set.Data.DR_S3 = ChallengerMod.Set.Data.DR_S3EN;
                        ChallengerMod.Set.Data.DR_G1 = ChallengerMod.Set.Data.DR_G1EN;
                        ChallengerMod.Set.Data.DR_G2 = ChallengerMod.Set.Data.DR_G2EN;
                        ChallengerMod.Set.Data.DR_G3 = ChallengerMod.Set.Data.DR_G3EN;
                        ChallengerMod.Set.Data.DR_C1 = ChallengerMod.Set.Data.DR_C1EN;
                        ChallengerMod.Set.Data.DR_C2 = ChallengerMod.Set.Data.DR_C2EN;
                        ChallengerMod.Set.Data.DR_C3 = ChallengerMod.Set.Data.DR_C3EN;
                        ChallengerMod.Set.Data.DR_E = ChallengerMod.Set.Data.DR_EEN;
                        ChallengerMod.Set.Data.DR_M = ChallengerMod.Set.Data.DR_MEN;
                    }

                    

                }
                    void logClick()
                {
                    if (GLMod.GLMod.isLoggedIn() == true)
                    {
                        SceneChanger.ChangeScene("MainMenu");
                        Application.OpenURL("https://goodloss.fr/player/" + GLMod.GLMod.getAccountName());
                    }
                    else
                    {
                        SceneChanger.ChangeScene("MainMenu");
                        Application.OpenURL("https://goodloss.fr/register");
                    }
                    

                }
                    void onClick()
                {
                    SceneChanger.ChangeScene("MainMenu");
                    Application.OpenURL("https://discord.gg/ZYsjg5dvB7");
                }
                    void goClick()
                {
                    //if (MatuxMod.MatuxMod.isLoggedIn() == true)
                    // {
                    //ChallengerMod.HarmonyMain.Ranked.SetValue(true);
                    if (SteamUser.GetSteamID() != null && GLMod.GLMod.isLoggedIn() == true && RankedSeason == true)
                    {
                        SteamID = SteamUser.GetSteamID().ToString();
                        GLMod.GLMod.disableService("StartGame");
                        GLMod.GLMod.disableService("EndGame");
                        GLMod.GLMod.setModName("Challenger");


                        Challenger.IsrankedGame = true;
                        Challenger.isRankedGame = true;
                        GLMod.GLMod.getRank();
                        GLMod.GLMod.reloadItems();
                        GoodlossRank = GLMod.GLMod.rank.id;
                        GoodlossRankValue = GLMod.GLMod.rank.percent;
                        IsrankedGameSet = 0f;

                        ChallengerMod.Utility.Discord.DiscordData.Initialize();

                        if (Challenger.LangGameSet == 2f || (ChallengerMod.Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
                        {
                            ChallengerMod.Set.Data.R_Unranked = ChallengerMod.Set.Data.R_UnrankedFR;
                            ChallengerMod.Set.Data.R_B1 = ChallengerMod.Set.Data.R_B1FR;
                            ChallengerMod.Set.Data.R_B2 = ChallengerMod.Set.Data.R_B2FR;
                            ChallengerMod.Set.Data.R_B3 = ChallengerMod.Set.Data.R_B3FR;
                            ChallengerMod.Set.Data.R_S1 = ChallengerMod.Set.Data.R_S1FR;
                            ChallengerMod.Set.Data.R_S2 = ChallengerMod.Set.Data.R_S2FR;
                            ChallengerMod.Set.Data.R_S3 = ChallengerMod.Set.Data.R_S3FR;
                            ChallengerMod.Set.Data.R_G1 = ChallengerMod.Set.Data.R_G1FR;
                            ChallengerMod.Set.Data.R_G2 = ChallengerMod.Set.Data.R_G2FR;
                            ChallengerMod.Set.Data.R_G3 = ChallengerMod.Set.Data.R_G3FR;
                            ChallengerMod.Set.Data.R_C1 = ChallengerMod.Set.Data.R_C1FR;
                            ChallengerMod.Set.Data.R_C2 = ChallengerMod.Set.Data.R_C2FR;
                            ChallengerMod.Set.Data.R_C3 = ChallengerMod.Set.Data.R_C3FR;
                            ChallengerMod.Set.Data.R_E = ChallengerMod.Set.Data.R_EFR;
                            ChallengerMod.Set.Data.R_M = ChallengerMod.Set.Data.R_MFR;

                            ChallengerMod.Set.Data.DR_Unranked = ChallengerMod.Set.Data.DR_UnrankedFR;
                            ChallengerMod.Set.Data.DR_B1 = ChallengerMod.Set.Data.DR_B1FR;
                            ChallengerMod.Set.Data.DR_B2 = ChallengerMod.Set.Data.DR_B2FR;
                            ChallengerMod.Set.Data.DR_B3 = ChallengerMod.Set.Data.DR_B3FR;
                            ChallengerMod.Set.Data.DR_S1 = ChallengerMod.Set.Data.DR_S1FR;
                            ChallengerMod.Set.Data.DR_S2 = ChallengerMod.Set.Data.DR_S2FR;
                            ChallengerMod.Set.Data.DR_S3 = ChallengerMod.Set.Data.DR_S3FR;
                            ChallengerMod.Set.Data.DR_G1 = ChallengerMod.Set.Data.DR_G1FR;
                            ChallengerMod.Set.Data.DR_G2 = ChallengerMod.Set.Data.DR_G2FR;
                            ChallengerMod.Set.Data.DR_G3 = ChallengerMod.Set.Data.DR_G3FR;
                            ChallengerMod.Set.Data.DR_C1 = ChallengerMod.Set.Data.DR_C1FR;
                            ChallengerMod.Set.Data.DR_C2 = ChallengerMod.Set.Data.DR_C2FR;
                            ChallengerMod.Set.Data.DR_C3 = ChallengerMod.Set.Data.DR_C3FR;
                            ChallengerMod.Set.Data.DR_E = ChallengerMod.Set.Data.DR_EFR;
                            ChallengerMod.Set.Data.DR_M = ChallengerMod.Set.Data.DR_MFR;

                        }
                        else
                        {
                            ChallengerMod.Set.Data.R_Unranked = ChallengerMod.Set.Data.R_UnrankedEN;
                            ChallengerMod.Set.Data.R_B1 = ChallengerMod.Set.Data.R_B1EN;
                            ChallengerMod.Set.Data.R_B2 = ChallengerMod.Set.Data.R_B2EN;
                            ChallengerMod.Set.Data.R_B3 = ChallengerMod.Set.Data.R_B3EN;
                            ChallengerMod.Set.Data.R_S1 = ChallengerMod.Set.Data.R_S1EN;
                            ChallengerMod.Set.Data.R_S2 = ChallengerMod.Set.Data.R_S2EN;
                            ChallengerMod.Set.Data.R_S3 = ChallengerMod.Set.Data.R_S3EN;
                            ChallengerMod.Set.Data.R_G1 = ChallengerMod.Set.Data.R_G1EN;
                            ChallengerMod.Set.Data.R_G2 = ChallengerMod.Set.Data.R_G2EN;
                            ChallengerMod.Set.Data.R_G3 = ChallengerMod.Set.Data.R_G3EN;
                            ChallengerMod.Set.Data.R_C1 = ChallengerMod.Set.Data.R_C1EN;
                            ChallengerMod.Set.Data.R_C2 = ChallengerMod.Set.Data.R_C2EN;
                            ChallengerMod.Set.Data.R_C3 = ChallengerMod.Set.Data.R_C3EN;
                            ChallengerMod.Set.Data.R_E = ChallengerMod.Set.Data.R_EEN;
                            ChallengerMod.Set.Data.R_M = ChallengerMod.Set.Data.R_MEN;

                            ChallengerMod.Set.Data.DR_Unranked = ChallengerMod.Set.Data.DR_UnrankedEN;
                            ChallengerMod.Set.Data.DR_B1 = ChallengerMod.Set.Data.DR_B1EN;
                            ChallengerMod.Set.Data.DR_B2 = ChallengerMod.Set.Data.DR_B2EN;
                            ChallengerMod.Set.Data.DR_B3 = ChallengerMod.Set.Data.DR_B3EN;
                            ChallengerMod.Set.Data.DR_S1 = ChallengerMod.Set.Data.DR_S1EN;
                            ChallengerMod.Set.Data.DR_S2 = ChallengerMod.Set.Data.DR_S2EN;
                            ChallengerMod.Set.Data.DR_S3 = ChallengerMod.Set.Data.DR_S3EN;
                            ChallengerMod.Set.Data.DR_G1 = ChallengerMod.Set.Data.DR_G1EN;
                            ChallengerMod.Set.Data.DR_G2 = ChallengerMod.Set.Data.DR_G2EN;
                            ChallengerMod.Set.Data.DR_G3 = ChallengerMod.Set.Data.DR_G3EN;
                            ChallengerMod.Set.Data.DR_C1 = ChallengerMod.Set.Data.DR_C1EN;
                            ChallengerMod.Set.Data.DR_C2 = ChallengerMod.Set.Data.DR_C2EN;
                            ChallengerMod.Set.Data.DR_C3 = ChallengerMod.Set.Data.DR_C3EN;
                            ChallengerMod.Set.Data.DR_E = ChallengerMod.Set.Data.DR_EEN;
                            ChallengerMod.Set.Data.DR_M = ChallengerMod.Set.Data.DR_MEN;
                        }
                        //TEST
                        if (ChallengerMod.HarmonyMain.KeyboardData == "0000040C") { ChallengerMod.Challenger.KeycodeKill = KeyCode.A; }
                        else { ChallengerMod.Challenger.KeycodeKill = KeyCode.Q; }

                        GoodlossRankValue = 0;
                        GoodlossRank = 0;

                        ChallengerMod.Set.Data.Playerlang = TranslationController.Instance.currentLanguage.languageID.ToString();
                        SceneChanger.ChangeScene("MMOnline");
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                    // }

                    //  else
                    //   {

                    //   }



                }
                if (PositionUI.TryGetValue(StringName, out var translation))
                {
                    original.transform.Translate(translation);
                }
                continue;
            }
               /* if (GameObject.Find("HostGameButton"))
                {


                    SpriteAnimUtils.StartAnimationLogin(Challenger.LoginAnimation, GameObject.Find("bannerLogo_AmongUs").transform.position, 1f, 1f);
                    SpriteAnimUtils.StartAnimation3(Challenger.Logo, GameObject.Find("bannerLogo_AmongUs").transform.position, 1.1f, 1f);
                    GameObject.Find("LogoChallenger").transform.localPosition = new Vector3(0.1f, 1.3f, -5f);
                    GameObject.Find("Login_Anim").transform.localPosition = new Vector3(0f, 0f, 0.5f);




                    //CREATE GAME
                    var CustomButtonCn = GameObject.Find("OptionsMenu").transform.FindChild("Content");
                    var CustomButtonCnOPT = GameObject.Find("OptionsMenu");
                    CustomButtonCn.transform.gameObject.SetActive(true);
                    CustomButtonCnOPT.transform.gameObject.SetActive(true);
                    CustomButtonCn.transform.localPosition = new Vector3(-99f, 0f, 0f);

                    var CustomButtonC = GameObject.Find("OptionsMenu").transform.FindChild("Content").transform.FindChild("Confirm");
                    CustomButtonC.transform.localPosition = new Vector3(100.07f, -1.08f, -1f);
                    CustomButtonC.transform.localScale = new Vector3(1.7f, 4.4f, -1f);
                    BoxCollider2D boxNsize = CustomButtonC.GetComponent<BoxCollider2D>();
                    boxNsize.size = new Vector2(1.3f, 0.15f);
                    if (IsrankedGame == false)
                    {
                        CustomButtonC.GetComponent<SpriteRenderer>().sprite = CreateGame;
                    }
                    else
                    {
                        CustomButtonC.GetComponent<SpriteRenderer>().sprite = CreateGameR;
                    }

                    var CustomButtonCt = GameObject.Find("OptionsMenu").transform.FindChild("Content").transform.FindChild("Confirm").transform.FindChild("Text_TMP");
                    CustomButtonCt.transform.gameObject.SetActive(false);
                }*/
           // }
        }

        private static void StartCoroutine(IEnumerator enumerator)
        {
            throw new NotImplementedException();
        }
    }
}