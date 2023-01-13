using HarmonyLib;
using UnityEngine;
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
        public static Sprite _Hat_CC01;
        public static Sprite _Hat_CC02;
        public static Sprite _Hat_CC03;
        public static Sprite _Hat_CC04;

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

        public static Sprite _Hat_CCamera;
        public static Sprite _Hat_CLight;
        public static Sprite _Hat_CSound;
        public static Sprite _Hat_CPopCorn;
        public static Sprite _Hat_COscar;

        




        public static Sprite _Hat_Brain;
        public static Sprite _Hat_Horror;
        public static Sprite _Hat_Reaper;
        public static Sprite _Hat_WhiteMask;
        public static Sprite _Hat_WhiteMask_L;

        public static Sprite _Hat_Cupid;
        public static Sprite _Hat_Heart;
        public static Sprite _Hat_Ourfit;
        public static Sprite _Hat_Meringue;



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

        public static Sprite _Visor_C3D;

        public static Sprite _Visor_Bloody;
        public static Sprite _Visor_Scythe;

        public static Sprite _Visor_Love;
        public static Sprite _Visor_Baloon;
        public static Sprite _Visor_LV1;
        public static Sprite _Visor_LV2;


        public static Sprite _Plate_Eater;
        public static Sprite _Plate_Cupid;
        public static Sprite _Plate_Arsonist;

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

        public static Sprite StartGameR;
        public static Sprite StartGameR0;

        public static Sprite StartGameR_FR;
        public static Sprite StartGameR0_FR;

        public static Sprite CreateGame;
        public static Sprite CreateGameR;
        public static Sprite BackServer;
        public static Sprite GameCodeBtt;
        public static Sprite FindBtt;
        public static Sprite FindBtt0;
        public static Sprite ValidServer;

        public static Sprite CreateGame_FR;
        public static Sprite CreateGameR_FR;
        public static Sprite BackServer_FR;
        public static Sprite GameCodeBtt_FR;
        public static Sprite ValidServer_FR;
        public static Sprite FindBtt_FR;
        public static Sprite FindBtt0_FR;


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
        public static Sprite BloodIco;
        public static Sprite DragIco;
        public static Sprite MindIco;
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

        public static Sprite B0;
        public static Sprite B1;
        public static Sprite B2;
        public static Sprite B3;
        public static Sprite B4;
        public static Sprite B5;
        public static Sprite B6;
        public static Sprite B7;
        public static Sprite B8;
        public static Sprite B9;
        public static Sprite Bmax;
        public static Sprite T0;
        public static Sprite T1;
        public static Sprite T2;
        public static Sprite T3;

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




        public static Sprite C0A0V0;
        public static Sprite C1A0V0;
        public static Sprite C0A1V0;
        public static Sprite C0A0V1;
        public static Sprite C1A1V0;
        public static Sprite C0A1V1;
        public static Sprite C1A1V1;
        public static Sprite C1A0V1;
        public static Sprite pl3;
        public static Sprite pl4;
        public static Sprite pl5;
        public static Sprite pl6;
        public static Sprite pl7;
        public static Sprite pl8;
        public static Sprite pl9;
        public static Sprite pl10;
        public static Sprite pl11;
        public static Sprite pl12;
        public static Sprite pl13;
        public static Sprite pl14;
        public static Sprite pl15;
        public static Sprite cre0;
        public static Sprite cre1;
        public static Sprite cre2;
        public static Sprite cre3;
        public static Sprite cre4;
        public static Sprite cre5;
        public static Sprite cre6;
        public static Sprite cre7;
        public static Sprite cre8;
        public static Sprite cre9;
        public static Sprite cre10;
        public static Sprite cre11;
        public static Sprite cre12;
        public static Sprite cre13;
        public static Sprite cre14;
        public static Sprite imp0;
        public static Sprite imp1;
        public static Sprite imp2;
        public static Sprite imp3;
        public static Sprite imp4;
        public static Sprite spe0;
        public static Sprite spe1;
        public static Sprite spe2;
        public static Sprite spe3;
        public static Sprite spe4;
        public static Sprite spe5;
        public static Sprite spe6;
        public static Sprite trinity;
        public static Sprite GLLog0;
        public static Sprite GLLog1;
        public static Sprite GLLog0_FR;
        public static Sprite GLLog1_FR;
        public static Sprite R_Button_FR;
        public static Sprite R_Button_EN;

        public static Sprite REPLACE_ME1;
        public static Sprite REPLACE_ME2;
        public static Sprite DiscordJoin;
        public static Sprite StartGame;
        public static Sprite StartGame_FR;
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
        public static Sprite TargetSheriff;
        public static Sprite TargetGuardian;
        public static Sprite TargetHunter;
        public static Sprite TargetInfor;
        public static Sprite TargetCupid;
        public static Sprite TargetCultiste;
        public static Sprite TargetOutlaw;
        public static Sprite TargetArsonist;
        public static Sprite TargetCopyCat;
        public static Sprite TargetMercenary;
        public static Sprite TargetAssassin;
        public static Sprite TargetSlayer;
        public static Sprite TargetImpostor;
        public static Sprite TargetVenger;

        private static Sprite animatedVentSealedSpritebar;

       

       



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