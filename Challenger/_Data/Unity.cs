using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.Video;


namespace ChallengerMod
{

    

    [HarmonyPatch]
    public static class Unity
    {
        
        public static GameObject LobbyLevel;

        public static readonly Sprite MiraLab = Level_TexHQLab;
        public static readonly Vector3 OutScale = new Vector3(0f, 0f, 0f);
        public static readonly Vector3 InScale = new Vector3(1f, 1f, 1f);
        public static readonly Sprite MapPB1 = LobbyLevel_PolusMapV1;
        public static readonly Sprite MapPB2 = LobbyLevel_PolusMapV2;
        public static readonly Sprite MapHQ1 = LobbyLevel_MiraMapV1;
        public static readonly Sprite MapHQ2 = LobbyLevel_MiraMapV2;

       

        public static VideoClip video;
        public static Sprite _Hat_CC00;
        public static Sprite _Hat_CC002;
        public static Sprite _Hat_CC;

        public static Sprite _Visor_CC00;
        public static Sprite _Hat_CC01;
        public static Sprite _Hat_CC02;
        public static Sprite _Hat_CC03;
        public static Sprite _Hat_CC04;

        public static Sprite _Hat_FRA;
        public static Sprite _Hat_SUB1;
        public static Sprite _Hat_TOI1;
        public static Sprite _Hat_TOI2;
        public static Sprite _Hat_TOI3;
        public static Sprite _Hat_TOI4;
        public static Sprite _Hat_TOI5;
        public static Sprite _Hat_TOI6;
        public static Sprite _Hat_TOI7;
        public static Sprite _Hat_TOI8;

        public static Sprite _Hat_TOI9;
        public static Sprite _Hat_TOI10;

        public static Sprite _Hat_TOI11;
        public static Sprite _Hat_TOI12;
        public static Sprite _Hat_TOI13;
        public static Sprite _Hat_TOI14;
        public static Sprite _Hat_TOI15;



        public static Sprite _Hat_Alien;
        public static Sprite _Hat_Demon;
        public static Sprite _Hat_Angel;
        public static Sprite _Hat_Kawaii;
        public static Sprite _Hat_Angry;
        public static Sprite _Hat_Vampire;
        public static Sprite _Hat_Strange;
        public static Sprite _Hat_Pom;
        public static Sprite _Hat_Pom2;
        public static Sprite _Hat_Clown;
        public static Sprite _Hat_Mask;
        public static Sprite _Hat_Ears;
        public static Sprite _Hat_Licorne;
        public static Sprite _Hat_Bomber;
        public static Sprite _Hat_Dragon;
        public static Sprite _Hat_Tv;

        public static Sprite _Hat_Bee;
        public static Sprite _Hat_Cat;
        public static Sprite _Hat_Fluffy;
        public static Sprite _Hat_CatEars;
        public static Sprite _Hat_LilyPin;
        public static Sprite _Hat_ShootingStar;
        public static Sprite _Hat_WitchHat;
        public static Sprite _Hat_Toast;
        public static Sprite _Hat_Cake;




        public static Sprite _Hat_HChar1;
        public static Sprite _Hat_HChar2;
        public static Sprite _Hat_HChar3;
        public static Sprite _Hat_HChar4;
        public static Sprite _Hat_HChar5;
        public static Sprite _Hat_HChar6;
        public static Sprite _Hat_HChar7;
        public static Sprite _Hat_HChar8;

        public static Sprite _Hat_HH1;
        public static Sprite _Hat_HS1;
        public static Sprite _Hat_HS2;
        public static Sprite _Hat_HS3;
        public static Sprite _Hat_HS4;

        public static Sprite _Hat_WHBruce;
        public static Sprite _Hat_WHCaptain;
        public static Sprite _Hat_WHBlacky;
        public static Sprite _Hat_WHTiger;
        public static Sprite _Hat_WHCutter;
        public static Sprite _Hat_WHDevour;
        public static Sprite _Hat_WHIronMask;
        public static Sprite _Hat_WHJoker;
        public static Sprite _Hat_WHQuenny;
        public static Sprite _Hat_WHMyster;
        public static Sprite _Hat_WHSkipperman;
        public static Sprite _Hat_WHSlash;
        public static Sprite _Hat_WHStranger;
        public static Sprite _Hat_WHThor;

        public static Sprite _Hat_SWDark;
        public static Sprite _Hat_SWMool;
        public static Sprite _Hat_SWLela;
        public static Sprite _Hat_SWBaby;
        public static Sprite _Hat_SWShewi;
        public static Sprite _Hat_SWAaya;
        public static Sprite _Hat_SWAhsoka;
        public static Sprite _Hat_SWAnak;



        public static Sprite _Hat_CCamera;
        public static Sprite _Hat_CLight;
        public static Sprite _Hat_CSound;
        public static Sprite _Hat_CPopCorn;
        public static Sprite _Hat_COscar;

        



        //EATER
        public static Sprite _Hat_Brain;
        public static Sprite _Hat_Horror;
        public static Sprite _Hat_Reaper;
        public static Sprite _Hat_WhiteMask;
        public static Sprite _Hat_WhiteMask_L;

        //CUPID
        public static Sprite _Hat_Cupid;
        public static Sprite _Hat_Heart;
        public static Sprite _Hat_Timid;
        public static Sprite _Hat_Meringue;

        //CULTE
        public static Sprite _Hat_Outfit;
        public static Sprite _Hat_Crown;
        public static Sprite _Hat_Ghost;
        public static Sprite _Hat_SpeHorn;
        public static Sprite _Hat_Candle;


        public static Sprite _Visor_Gun;
        public static Sprite _Visor_Knife;
        public static Sprite _Visor_Katana;
        public static Sprite _Visor_VampireTooth;
        public static Sprite _Visor_Fish;
        public static Sprite _Visor_Spiral_1;
        public static Sprite _Visor_Spiral_2;
        
        public static Sprite _Visor_Coffee;
        public static Sprite _Visor_Cred;
        public static Sprite _Visor_Cpink;
        public static Sprite _Visor_Cpurple;
        public static Sprite _Visor_Cgreen;
        public static Sprite _Visor_Cblue;
        public static Sprite _Visor_Cleef;
        public static Sprite _Visor_Cyellow;

        public static Sprite _Visor_H1;
        public static Sprite _Visor_H2;
        public static Sprite _Visor_HB1;
        public static Sprite _Visor_HB2;
        public static Sprite _Visor_HB3;

        public static Sprite _Visor_SWSaber1;
        public static Sprite _Visor_SWSaber2;
        public static Sprite _Visor_SWSaber3;
        public static Sprite _Visor_SWSaber4;
        public static Sprite _Visor_SWSaber5;


        public static Sprite _Visor_C3D;

        public static Sprite _Visor_Bloody;
        public static Sprite _Visor_Scythe;

        public static Sprite _Visor_Love;
        public static Sprite _Visor_Baloon;
        public static Sprite _Visor_LV1;
        public static Sprite _Visor_LV2;

        public static Sprite _Visor_DBook;

        public static Sprite _Plate_SUB1;
        public static Sprite _Plate_SUB2;
        public static Sprite _Plate_SUB3;

        public static Sprite _Plate_Eater;
        public static Sprite _Plate_Cupid;
        public static Sprite _Plate_Arsonist;
        
        public static Sprite _Plate_SW1;
        public static Sprite _Plate_SW2;


        

        public static Sprite _Plate_CBand;
        public static Sprite _Plate_CBG;
        public static Sprite _Plate_CClap;

        public static Sprite _Plate_1;
        public static Sprite _Plate_2;
        public static Sprite _Plate_3;
        public static Sprite _Plate_4;
        public static Sprite _Plate_5;
        public static Sprite _Plate_6;
        public static Sprite _Plate_7;
        public static Sprite _Plate_8;
        public static Sprite _Plate_9;
        public static Sprite _Plate_10;
        public static Sprite _Plate_11;
        public static Sprite _Plate_12;
        public static Sprite _Plate_13;
        public static Sprite _Plate_14;


        public static Sprite LobbyLevel_PolusMapV1;
        public static Sprite LobbyLevel_PolusMapV2;
        public static Sprite LobbyLevel_PolusMapV3;
        public static Sprite LobbyLevel_MiraMapV1;
        public static Sprite LobbyLevel_MiraMapV2;
        public static Sprite LobbyLevel_room_tunnel1;
        public static Sprite TexBGMira;
        public static Sprite Level_TexHQLab;
        public static Sprite Level_TexHQCam;
        public static Sprite Level_TexHQCam2;
        public static Sprite Level_TexHQDS;
        public static Sprite Colliderdebugg;
        public static Sprite Colliderblack;
        public static Sprite Colliderbox;

        public static Sprite ColorLock;
        public static Sprite ColorUnlock;

        public static AnimationClip CircleAnim;
        public static AnimationClip LoginAnim;
        public static AnimationClip Logo;
        public static AnimationClip LoginAnimation;
        public static AnimationClip PetrifyAnim;
        public static AnimationClip Drone0Anim;
        public static AnimationClip Drone1Anim;
        public static Sprite Drone0;
        public static Sprite Drone1;

        public static Sprite Level_Tex1;
        public static Sprite Level_Tex2;
        public static Sprite Level_Tex3;
        public static Sprite Level_Tex4;
        public static Sprite Level_collider1;
        public static Sprite Level_collider2;
        public static Sprite Level_collider3;
        public static Sprite Level_collider4;
        public static Sprite Level_collider5;
        public static Sprite Level_collider6;
        public static Sprite Level_collider7;
        public static Sprite Elec;
        public static Sprite Elec2;
        public static Sprite Level_TexP1;
        public static Sprite Level_TexP2;
        public static Sprite Level_TexP3;

        public static Sprite SA1;
        public static Sprite SA2;
        public static Sprite SA3;
        public static Sprite SA4;

        public static Sprite EA1;
        public static Sprite EA2;
        public static Sprite EA3;
        public static Sprite EA4;
        public static Sprite EA5;
        public static Sprite EA6;

        public static Sprite ReadyIco;
        public static Sprite SteamAvatar;

        public static Sprite FFR0;
        public static Sprite FFR1;
        public static Sprite FEN0;
        public static Sprite FEN1;
        public static Sprite FAU0;
        public static Sprite FAU1;


        public static Sprite PS1EN0;
        public static Sprite PS1EN1;
        public static Sprite PS1FR0;
        public static Sprite PS1FR1;

        public static Sprite PS2EN0;
        public static Sprite PS2EN1;
        public static Sprite PS2FR0;
        public static Sprite PS2FR1;

        public static Sprite PS3EN0;
        public static Sprite PS3EN1;
        public static Sprite PS3FR0;
        public static Sprite PS3FR1;


        public static AssetBundle bundle_char;
        public static AssetBundle bundle;
        public static AssetBundle bundle_Anim;
        public static AssetBundle bundle_Sound;
        public static AssetBundle bundle_Ranked;
        public static AssetBundle bundle_Level;
        public static AssetBundle bundle_Sprite;
        public static AssetBundle bundle_Assets;
        public static AssetBundle bundle_Map0;


        //UI
        public static AudioClip introOST;
        public static AudioClip ALN;
        public static AudioClip Explode; //

        //SHIELD

        //TIMELORD
        public static AudioClip Tic;
        public static AudioClip breakClip; //
        public static AudioClip timeoff; //


        //JESTER
        public static AudioClip jesterkill;

        //CULTE + SHIELD
        public static AudioClip shieldClip;//


        public static AudioClip ventClip;

        //GHOST VECTOR
        public static AudioClip PoisonDelay;

        public static AudioClip PoisonClip;
        public static AudioClip agony;
        public static AudioClip JesterWinSound;
        public static AudioClip Used;
        public static AudioClip ScramblerOn;
        public static AudioClip ScramblerOff;
        public static AudioClip AlerteLoop;
        public static AudioClip UseUI;
        public static AudioClip CulteWin;


        public static AudioClip Buff;
        public static AudioClip ShieldBuff;
        public static AudioClip Shadow;
        
        public static AudioClip loot;
        public static AudioClip surcharge;

        public static AudioClip Burned;
        public static AudioClip Eated;
        
        public static AudioClip SoulTake;
        public static AudioClip BaitAlerte;


        public static Sprite BarghestKillIco;
        public static Sprite BarghestKillIco2;
        public static Sprite OutlawKill;
        public static Sprite OutlawKill2;
        public static Sprite Outlaw0;
        public static Sprite Outlaw1;

        public static Sprite Pop0;
        public static Sprite Pop1;

        public static Sprite admin0;
        public static Sprite admin1;

        public static Sprite Vitale0;
        public static Sprite Vitale1;

        public static Sprite cam0;
        public static Sprite cam1;

        public static Sprite buzz0;
        public static Sprite buzz1;

        public static Sprite SheriffGun;

        public static Sprite RoleINF;

        public static Sprite Affich;
        public static Sprite Affich2;
        public static Sprite ShadowIco;
        public static Sprite repairIco;
        public static Sprite ventmapIco;
        public static Sprite NewVent;
        public static Sprite BlockVent1;
        public static Sprite BlockVent2;
        public static Sprite BlockVent3;
        public static Sprite BlockVentuse;
        public static Sprite BlockVentall;

        public static Sprite UI2_PlayRanked;
        public static Sprite UI2_GLLogin;

        public static Sprite UI2_PlayRankedFR;
        public static Sprite StartGameR0_FR;

        public static Sprite UI2_CreateGame;
        public static Sprite UI2_CreateCancel;
        public static Sprite UI2_MainMenu;
        public static Sprite UI2_EnterCode;
        public static Sprite UI2_FindGameOn;
        public static Sprite UI2_FindGameOff;
        public static Sprite UI2_CreateConfirm;

        public static Sprite UI2_CreateGameFR;
        public static Sprite UI2_CreateCancelFR;
        public static Sprite UI2_MainMenuFR;
        public static Sprite UI2_EnterCodeFR;
        public static Sprite UI2_CreateConfirmFR;
        public static Sprite UI2_FindGameOnFR;
        public static Sprite UI2_FindGameOffFR;


        public static Sprite LocRune;
        public static Sprite createventIco;
        public static Sprite BlockVentIco;
        
        public static Sprite love1Ico;
        public static Sprite love2Ico;
        public static Sprite noloveIco;
        public static Sprite loveIco;
        public static Sprite miniloveIco;
        public static Sprite shieldIco;
        public static Sprite trackIco;
        public static Sprite fakeIco;
        public static Sprite Hideico;
        public static Sprite stopIco;
        public static Sprite KillSherifIco;
        public static Sprite KillSherifIco2;
        public static Sprite KillMercenaryIco;
        public static Sprite KillMercenaryIco2;
        public static Sprite KillAssassinIco;
        public static Sprite KillAssassinIco2;
        public static Sprite KillSlayerIco;
        public static Sprite KillSlayerIco2;
        public static Sprite slayerIco;
        public static Sprite slayerIco2;
        public static Sprite KillWarlockIco;
        public static Sprite LoginBanner;
        public static Sprite LoginBannerMini;
        public static Sprite reviveIco;
        public static Sprite mysticIco;
        public static Sprite KillSorcererIco;
        public static Sprite SorcererIco1;
        public static Sprite SorcererIco2;
        public static Sprite SorcererIco3;
        public static Sprite sorcererprezIco;
        //public static Animator FakeKillA;
        public static Sprite NightwatchIco;
        public static Sprite MapIco;
        public static Sprite SpyIco;
        public static Sprite CamoIco;
        public static Sprite IkillIco;
        public static Sprite IkillIco2;
        public static Sprite ScanIco;
        public static Sprite MorphIco;
        public static Sprite FPrint;
        public static Sprite HPrint;
        public static Sprite DetectiveIco;
        public static Sprite InforIco;
        public static Sprite MayorIco;
        public static Sprite EaterIco;
        public static Sprite EaterIco2;
        public static Sprite ArrowWarn;
        public static Sprite BloodIco;
        public static Sprite DragIco;
        public static Sprite MindIco;
        public static Sprite MakeVoterIco;
        public static Sprite E0;
        public static Sprite E1;
        public static Sprite E2;
        public static Sprite E3;
        public static Sprite E4;
        public static Sprite E5;
        public static Sprite E6;
        public static Sprite E7;
        public static Sprite E8;
        public static Sprite E9;
        public static Sprite E10;
        public static Sprite LoginBannerSc2;
        public static Sprite LoginBannerSc2R;

        public static Sprite CB0;
        public static Sprite CB1;
        public static Sprite CB2;
        public static Sprite CB3;
        public static Sprite CB4;
        public static Sprite CB5;
        public static Sprite CB6;
        public static Sprite CB7;
        public static Sprite CB8;
        public static Sprite CB9;
        public static Sprite CB10;
        public static Sprite CB11;
        public static Sprite CB12;
        public static Sprite CB13;
        public static Sprite CB14;
        public static Sprite CB15;
        public static Sprite CB16;
        public static Sprite CB17;
        public static Sprite CB18;
        public static Sprite CB19;
        public static Sprite CB20;

        public static Sprite AR_0;
        public static Sprite AR_UP;
        public static Sprite AR_DOWN;

        public static Sprite CeciteIco;
       

        public static Sprite Set_P1;
        public static Sprite Set_P2;
        public static Sprite Set_P3;
        public static Sprite Set_P4;
        public static Sprite Set_P5;

        public static Sprite IRKnone;

        public static Sprite IRKFree;

        public static Sprite IRKarsonist;
        public static Sprite IRKarsonist0;

        public static Sprite IRKoutlaw;
        public static Sprite IRKoutlaw0;

        public static Sprite IRKjester;
        public static Sprite IRKjester0;

        public static Sprite IRKeat;
        public static Sprite IRKeat0;

        public static Sprite IRKcupid;
        public static Sprite IRKcupid0;

        public static Sprite IRKculte;
        public static Sprite IRKculte0;

        public static Sprite IRKLite;
        public static Sprite IRKLite0;

        public static Sprite IRKvanilla;
        public static Sprite IRKvanilla0;

        public static Sprite IRKuknow;
        public static Sprite IRKuknow0;

        public static Sprite RBvanilla;
        public static Sprite RBlite;
        public static Sprite RBuknow;
        public static Sprite RBjester;
        public static Sprite RBeater;
        public static Sprite RBcupid;
        public static Sprite RBcultist;
        public static Sprite RBoutlaw;
        public static Sprite RBarsonist;
        public static Sprite RBFree;

        public static Sprite RBvanillaFR;
        public static Sprite RBliteFR;
        public static Sprite RBuknowFR;
        public static Sprite RBjesterFR;
        public static Sprite RBeaterFR;
        public static Sprite RBcupidFR;
        public static Sprite RBcultistFR;
        public static Sprite RBoutlawFR;
        public static Sprite RBarsonistFR;
        public static Sprite RBFreeFR;





        public static Sprite playbtt;
        public static Sprite serverbtt;
        public static Sprite btt1;
        public static Sprite btt2;
        public static Sprite MentalistIco;
        public static Sprite slayersolo;
        public static Sprite empty;
        public static Sprite NuclearButtonSprite;
        public static Sprite NuclearButtonSprite0;
        public static Sprite NuclearButtonSprite1;

        public static Sprite cr1;
        public static Sprite cr2;
        public static Sprite cr3;
        public static Sprite cr4;
        public static Sprite cr5;
        public static Sprite cr6;
        public static Sprite cr7;
        public static Sprite cr8;
        public static Sprite cr9;
        public static Sprite cr10;
        public static Sprite cr11;
        public static Sprite cr12;
        public static Sprite war0;
        public static Sprite war1;
        public static Sprite war2;
        public static Sprite war3;
        public static Sprite news;
        public static Sprite settings;
        public static Sprite inner;
        public static Sprite Inventory;
        public static Sprite stats;
        public static Sprite shop;
        public static Sprite CulteIco;
        public static Sprite GuessIco;
        public static Sprite GuessUIIco; 

        
        public static Sprite RU1;
        public static Sprite RU2;
        public static Sprite RU3;
        public static Sprite RU4;
        public static Sprite RU5;
        public static Sprite RU6;
        public static Sprite RU7;
        public static Sprite RU8;
        public static Sprite RU9;
        public static Sprite RU10;
        public static Sprite RU11;
        public static Sprite RU12;
        public static Sprite RU0;
        public static Sprite RUX;


        public static Sprite Rune1;
        public static Sprite Rune2;
        public static Sprite Rune3;
        public static Sprite Rune4;
        public static Sprite Rune5;
        public static Sprite Rune6;
        public static Sprite Rune7;
        public static Sprite Rune8;
        public static Sprite Rune9;
        public static Sprite Rune10;
        public static Sprite Rune11;
        public static Sprite Rune12;



        public static Sprite UI2_GLCreate;
        public static Sprite GLLog1;
        public static Sprite UI2_GLLoginFR;
        public static Sprite GLLog1_FR;
        public static Sprite R_Button_FR;
        public static Sprite R_Button_EN;
       
        public static Sprite TB_PLAYER;
        public static Sprite TB_PLAYER_FR;
        public static Sprite TB_GL0;
        public static Sprite TB_GL0_FR;
        public static Sprite TB_GL1;
        public static Sprite TB_GL1_FR;
        public static Sprite CLUF;
        public static Sprite CLUFFR;
        public static Sprite UI2_GLProfil;
        public static Sprite TB_MAXPLAYER;
        public static Sprite TB_MAXPLAYER_FR;

        public static Sprite REPLACE_ME1;
        public static Sprite REPLACE_ME2;
        public static Sprite DiscordJoin;
        public static Sprite UI2_PlayNormal;
        public static Sprite UI2_PlayNormalFR;
        public static Sprite DictatorIco;
        public static Sprite SabdoorIco;
        public static Sprite OilIco;
        public static Sprite OilIcoFail;
        public static Sprite OilIcoCast;
        public static Sprite RefuelStation;
        public static Sprite CanBurn;
        public static Sprite BurnIco;
        public static Sprite VengerIco;
        public static Sprite CopyIco;
        public static Sprite PetrifyIco;
        public static Sprite Petrify2Ico;
        public static Sprite LA1;
        public static Sprite LA2;
        public static Sprite LA3;
        public static Sprite LA4;
        public static Sprite LA5;
        public static Sprite LA6;
        public static Sprite LA7;

        public static Sprite SenVnull;
        public static Sprite SenV;
        public static Sprite SenVon;
        public static Sprite SenVoff;
        public static Sprite SenDBnull;
        public static Sprite SenDB;
        public static Sprite SenDBon;
        public static Sprite SenDBoff;
        public static Sprite SenIco;

        public static Sprite Rank_B3;
        public static Sprite Rank_B2;
        public static Sprite Rank_B1;
        public static Sprite Rank_S3;
        public static Sprite Rank_S2;
        public static Sprite Rank_S1;
        public static Sprite Rank_G3;
        public static Sprite Rank_G2;
        public static Sprite Rank_G1;
        public static Sprite Rank_P3;
        public static Sprite Rank_P2;
        public static Sprite Rank_P1;
        public static Sprite Rank_D;
        public static Sprite Rank_M;
        public static Sprite Rank_0;
        

        private static Sprite animatedVentSealedSpritebar;
        public static Sprite BaitBaliseArea;
        public static Sprite BaitBaliseArea0;
        public static Sprite BaitIco;

        public static Sprite LeadIco;

        public static Sprite EV_0_0;
        public static Sprite EV_0_1;
        public static Sprite EV_1_0;
        public static Sprite EV_1_1;
        public static Sprite EV_TAB;


        public static Sprite UI2_BTTN;
        public static Sprite UI2_BTTNFR;
        public static Sprite UI2_TAB;

        public static Sprite UI2_PM10;
        public static Sprite UI2_PM11;
        public static Sprite UI2_PM12;
        public static Sprite UI2_PM13;
        public static Sprite UI2_PM14;
        public static Sprite UI2_PM15;

        public static Sprite UI2_PMADD0;
        public static Sprite UI2_PMADD1;
        public static Sprite UI2_PMREM0;
        public static Sprite UI2_PMREM1;

        public static Sprite UI2_10P0;
        public static Sprite UI2_10P1;
        public static Sprite UI2_11P0;
        public static Sprite UI2_11P1;
        public static Sprite UI2_12P0;
        public static Sprite UI2_12P1;
        public static Sprite UI2_13P0;
        public static Sprite UI2_13P1;
        public static Sprite UI2_14P0;
        public static Sprite UI2_14P1;
        public static Sprite UI2_15P0;
        public static Sprite UI2_15P1;

        public static Sprite UI2_SPE;
        public static Sprite UI2_IMP;
        public static Sprite UI2_DUO;
        public static Sprite UI2_0N0;
        public static Sprite UI2_0N1;
        public static Sprite UI2_1N0;
        public static Sprite UI2_1N1;
        public static Sprite UI2_2N0;
        public static Sprite UI2_2N1;
        public static Sprite UI2_3N0;
        public static Sprite UI2_3N1;
        public static Sprite UI2_4N0;
        public static Sprite UI2_4N1;
        public static Sprite UI2_5N0;
        public static Sprite UI2_5N1;
        public static Sprite UI2_6N0;
        public static Sprite UI2_6N1;
        public static Sprite UI2_NUMBER_LOCK;



        public static Sprite UI2_Polus0;
        public static Sprite UI2_Polus1;
        public static Sprite UI2_Bpolus0;
        public static Sprite UI2_Bpolus1;
        public static Sprite UI2_Cpolus0;
        public static Sprite UI2_Cpolus1;
        public static Sprite UI2_Npolus0;
        public static Sprite UI2_Npolus1;
        public static Sprite UI2_Skeld0;
        public static Sprite UI2_Skeld1;
        public static Sprite UI2_Csleld0;
        public static Sprite UI2_Cskeld1;
        public static Sprite UI2_Mira0;
        public static Sprite UI2_Mira1;
        public static Sprite UI2_Cmira0;
        public static Sprite UI2_Cmira1;
        public static Sprite UI2_Airship0;
        public static Sprite UI2_Airship1;
        public static Sprite UI2_Sub0;
        public static Sprite UI2_Sub1;


        public static Sprite UI2_ROLE_LOCK;

        public static Sprite UI2_Sheriff0;
        public static Sprite UI2_Sheriff1;
        public static Sprite UI2_Guardian0;
        public static Sprite UI2_Guardian1;
        public static Sprite UI2_Engineer0;
        public static Sprite UI2_Engineer1;
        public static Sprite UI2_Timelord0;
        public static Sprite UI2_Timelord1;
        public static Sprite UI2_Hunter0;
        public static Sprite UI2_Hunter1;
        public static Sprite UI2_Mystic0;
        public static Sprite UI2_Mystic1;
        public static Sprite UI2_Spirit0;
        public static Sprite UI2_Spirit1;
        public static Sprite UI2_Mayor0;
        public static Sprite UI2_Mayor1;
        public static Sprite UI2_Detective0;
        public static Sprite UI2_Detective1;
        public static Sprite UI2_Nightwatch0;
        public static Sprite UI2_Nightwatch1;
        public static Sprite UI2_Spy0;
        public static Sprite UI2_Spy1;
        public static Sprite UI2_Informant0;
        public static Sprite UI2_Informant1;
        public static Sprite UI2_Bait0;
        public static Sprite UI2_Bait1;
        public static Sprite UI2_Mentalist0;
        public static Sprite UI2_Mentalist1;
        public static Sprite UI2_Builder0;
        public static Sprite UI2_Builder1;
        public static Sprite UI2_Dictator0;
        public static Sprite UI2_Dictator1;
        public static Sprite UI2_Sentinel0;
        public static Sprite UI2_Sentinel1;
        public static Sprite UI2_Teammate0;
        public static Sprite UI2_Teammate1;
        public static Sprite UI2_Lawkeeper0;
        public static Sprite UI2_Lawkeeper1;
        public static Sprite UI2_Fake0;
        public static Sprite UI2_Fake1;
        public static Sprite UI2_Leader0;
        public static Sprite UI2_Leader1;

        public static Sprite UI2_Mercenary0;
        public static Sprite UI2_Mercenary1;
        public static Sprite UI2_CopyCat0;
        public static Sprite UI2_CopyCat1;
        public static Sprite UI2_Revenger0;
        public static Sprite UI2_Revenger1;
        public static Sprite UI2_Survivor0;
        public static Sprite UI2_Survivor1;

        public static Sprite UI2_Cupid0;
        public static Sprite UI2_Cupid1;
        public static Sprite UI2_Cultist0;
        public static Sprite UI2_Cultist1;
        public static Sprite UI2_Jester0;
        public static Sprite UI2_Jester1;
        public static Sprite UI2_Eater0;
        public static Sprite UI2_Eater1;
        public static Sprite UI2_Outlaw0;
        public static Sprite UI2_Outlaw1;
        public static Sprite UI2_Arsonist0;
        public static Sprite UI2_Arsonist1;
        public static Sprite UI2_Cursed0;
        public static Sprite UI2_Cursed1;

        public static Sprite UI2_Assassin0;
        public static Sprite UI2_Assassin1;
        public static Sprite UI2_Vector0;
        public static Sprite UI2_Vector1;
        public static Sprite UI2_Morphling0;
        public static Sprite UI2_Morphling1;
        public static Sprite UI2_Scrambler0;
        public static Sprite UI2_Scrambler1;
        public static Sprite UI2_Barghest0;
        public static Sprite UI2_Barghest1;
        public static Sprite UI2_Ghost0;
        public static Sprite UI2_Ghost1;
        public static Sprite UI2_Sorcerer0;
        public static Sprite UI2_Sorcerer1;
        public static Sprite UI2_Guesser0;
        public static Sprite UI2_Guesser1;
        public static Sprite UI2_Basilisk0;
        public static Sprite UI2_Basilisk1;




        public static Sprite getAnimatedVentSealedSpritebar()
        {
            if (animatedVentSealedSpritebar) return animatedVentSealedSpritebar;
            animatedVentSealedSpritebar = ventmapIco;
            return animatedVentSealedSpritebar;
        }

        private static Sprite staticVentSealedSpritebar;
        public static Sprite getStaticVentSealedSpritebar()
        {
            if (staticVentSealedSpritebar) return staticVentSealedSpritebar;
            staticVentSealedSpritebar = ventmapIco;
            return staticVentSealedSpritebar;
        }

        //all
        private static Sprite animatedVentSealedSprite;
        public static Sprite getAnimatedVentSealedSprite()
        {
            if (animatedVentSealedSprite) return animatedVentSealedSprite;
            animatedVentSealedSprite = BlockVentall;
            return animatedVentSealedSprite;
        }

        private static Sprite staticVentSealedSprite;
        public static Sprite getStaticVentSealedSprite()
        {
            if (staticVentSealedSprite) return staticVentSealedSprite;
            staticVentSealedSprite = BlockVentall;
            return staticVentSealedSprite;
        }

        //user
        private static Sprite animatedVentSealedSpriteuse;
        public static Sprite getAnimatedVentSealedSpriteuse()
        {
            if (animatedVentSealedSpriteuse) return animatedVentSealedSpriteuse;
            animatedVentSealedSpriteuse = BlockVentuse;
            return animatedVentSealedSpriteuse;
        }

        private static Sprite staticVentSealedSpriteuse;
        public static Sprite getStaticVentSealedSpriteuse()
        {
            if (staticVentSealedSpriteuse) return staticVentSealedSpriteuse;
            staticVentSealedSpriteuse = BlockVentuse;
            return staticVentSealedSpriteuse;
        }

    } 

}