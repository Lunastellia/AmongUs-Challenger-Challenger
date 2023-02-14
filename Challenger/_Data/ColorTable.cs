using HarmonyLib;
using UnityEngine;


namespace ChallengerMod
{


    [HarmonyPatch]
    public static class ColorTable
    {
        public static readonly int VisorColor = Shader.PropertyToID("_VisorColor");

        public static Color nocolor = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0);//no color
            public static Color testcolor = new Color(255f / 255f, 0f / 255f, 0f / 255f, 150f);//testcolor


            public static Color CrewColor = new Color(180f / 255f, 250f / 255f, 250f / 255f, 1);//B4FAFA
            public static Color DuoColor = new Color(178f / 255f, 112f / 255f, 232f / 255f, 1);//B270E8
            public static Color RedColor = new Color(255f / 255f, 0f / 255f, 0f / 255f, 1);//FF0000
            public static Color OrangeColor = new Color(255f / 255f, 150f / 255f, 0f / 255f, 1);//FF9600
            public static Color YellowColor = new Color(255f / 255f, 220f / 255f, 0f / 255f, 1);//FFDC00
            public static Color GreenColor = new Color(0f / 255f, 255f / 255f, 0f / 255f, 1);//00FF00
            public static Color PurpleColor = new Color(220f / 255f, 0f / 255f, 255f / 255f, 1);//DC00FF
            public static Color WhiteColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1);//FFFFFF
            public static Color GreyColor = new Color(142f / 255f, 142f / 255f, 142f / 255f, 1);//8E8E8E
            public static Color blackColor = new Color(0f / 255f, 0f / 255f, 0f / 255f, 1);//000000
            public static Color StelliaColor = new Color(255f / 255f, 45f / 255f, 233f / 255f, 1);//FF2DE9

            public static Color CrewmatesColor = new Color(181f / 255f, 250f / 255f, 250f / 255f, 1);//B4FAFA
            public static Color CrewmateColor = new Color(180f / 255f, 250f / 255f, 250f / 255f, 1);//B4FAFA
            public static Color SheriffColor = new Color(255f / 255f, 255f / 255f, 0f / 255f, 1);//FFFF00
            public static Color SheriffsColor = new Color(254f / 255f, 255f / 255f, 0f / 255f, 1);//FFFF00

            public static Color GuardianColor = new Color(0f / 255f, 255f / 255f, 255f / 255f, 1);//00FFFF
            public static Color EngineerColor = new Color(255f / 255f, 161f / 255f, 0f / 255f, 1);//FFA100
            public static Color HunterColor = new Color(0f / 255f, 255f / 255f, 0f / 255f, 1);//00FF00
            public static Color TimeLordColor = new Color(0f / 255f, 127f / 255f, 255f / 255f, 1);//007FFF
            public static Color MysticColor = new Color(249f / 255f, 255f / 255f, 178f / 255f, 1);//F9FFB2
            public static Color SpiritColor = new Color(161f / 255f, 255f / 255f, 0f / 255f, 1);//A1FF00
            public static Color MayorColor = new Color(175f / 255f, 130f / 255f, 105f / 255f, 1);//AF8269
            public static Color DetectiveColor = new Color(188f / 255f, 255f / 255f, 186f / 255f, 1);//BCFFBA
            public static Color NightwatchColor = new Color(158f / 255f, 179f / 255f, 255f / 255f, 1);//9EB3FF
            public static Color SpyColor = new Color(158f / 255f, 225f / 255f, 255f / 255f, 1);//9EE1FF
            public static Color InformantColor = new Color(173f / 255f, 255 / 255f, 234f / 255f, 1);//ADFFEA
            public static Color BaitColor = new Color(128f / 255f, 128f / 255f, 128f / 255f, 1);//808080
            public static Color MentalistColor = new Color(169f / 255f, 145f / 255f, 255f / 255f, 1);//A991FF
            public static Color BuilderColor = new Color(255 / 255f, 194f / 255f, 145f / 255f, 1);//FFC291
            public static Color DictatorColor = new Color(255f / 255f, 77f / 255f, 53f / 255f, 1);//FF4D35
            public static Color SentinelColor = new Color(6f / 255f, 173f / 255f, 23f / 255f, 1);//06AD17
            public static Color TeammateColor = new Color(180f / 255f, 251f / 255f, 251f / 255f, 1);//B4FAFA
            public static Color LawkeeperColor = new Color(255 / 255f, 155f / 255f, 155f / 255f, 1);//FF9B9B
            public static Color FakeColor = new Color(255f / 255f, 150f / 255f, 150f / 255f, 1);//FF7A7A
            
            
            public static Color LeaderColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1);//5A7DA5
            public static Color AngelColor = new Color(25f / 255f, 255f / 255f, 186f / 255f, 1);//19FFBA
            public static Color DoctorColor = new Color(25f / 255f, 255f / 255f, 186f / 255f, 1);//19FFBA
            public static Color TravelerColor = new Color(175f / 255f, 100f / 255f, 175f / 255f, 1);//AF64AF


            public static Color CupidColor = new Color(255f / 255f, 175f / 255f, 255f / 255f, 1);//FFAFFF
            public static Color CulteColor = new Color(131f / 255f, 0f / 255f, 255f / 255f, 1);//8300FF
            public static Color OutlawColor = new Color(0f / 255f, 51f / 255f, 255f / 255f, 1);//0033FF
            public static Color ArsonistColor = new Color(255f / 255f, 200f / 255f, 0f / 255f, 1);//FFC800
            public static Color ArsonistTColor = new Color(165f / 255f, 165f / 255f, 165f / 255f, 1);//A5A5A5
            public static Color JesterColor = new Color(255f / 255f, 10f / 255f, 110f / 255f, 1);//FF0A88
            public static Color EaterColor = new Color(255f / 255f, 110f / 255f, 0f / 255f, 1);//FF6E00
            public static Color CursedColor = new Color(63f / 255f, 104f / 255f, 59f / 255f, 1);//3F683B

            public static Color MercenaryColor = new Color(255f / 255f, 73f / 255f, 230f / 255f, 1);//FF49E6
            public static Color CopyCatColor = new Color(100f / 255f, 230f / 255f, 180f / 255f, 1);//64E6B4
            public static Color RevengerColor = new Color(217f / 255f, 194f / 255f, 126f / 255f, 1);//D9C27E
            public static Color SurvivorColor = new Color(127f / 255f, 94f / 255f, 76f / 255f, 1);//7F5E4C
            public static Color SlaveColor = new Color(121f / 255f, 151f / 255f, 151f / 255f, 1);//799797

            public static Color ImpostorColor = new Color(255f / 255f, 0f / 255f, 0f / 255f, 1);//FF0000

            public static Color AssassinColor = new Color(0f / 255f, 81f / 255f, 6f / 255f, 1);//005106
            public static Color MorphlingColor = new Color(67f / 255f, 0f / 255f, 84f / 255f, 1);//430054
            public static Color MorphColor = new Color(67f / 255f, 0f / 255f, 84f / 255f, 1);//430054
            public static Color ScramblerColor = new Color(84f / 255f, 71f / 255f, 0f / 255f, 1);//544700
            public static Color BarghestColor = new Color(5f / 255f, 4f / 255f, 105f / 255f, 1);//000569
            public static Color GhostColor = new Color(64f / 255f, 64f / 255f, 64f / 255f, 1);//404040
            public static Color SorcererColor = new Color(84f / 255f, 43f / 255f, 0f / 255f, 1);//542B00
            public static Color VectorColor = new Color(140f / 255f, 25f / 255f, 25f / 255f, 1);//8C1919
            public static Color VectorInfColor = new Color(141f / 255f, 25f / 255f, 25f / 255f, 1);//8D1919
            public static Color MesmerColor = new Color(104f / 255f, 0f / 255f, 55f / 255f, 1);//680037
            public static Color BasiliskColor = new Color(91f / 255f, 70f / 255f, 107f / 255f, 1);//5B466B
            public static Color ReaperColor = new Color(0f / 255f, 73f / 255f, 65f / 255f, 1);//004941
            public static Color SaboteurColor = new Color(104f / 255f, 50f / 255f, 41f / 255f, 1);//683229
            public static Color GuesserColor = new Color(0f / 255f, 57f / 255f, 84f / 255f, 1);//003954

            public static Color _KillerColor = new Color(218f / 255f, 129f / 255f, 107f / 255f, 1);//DA816B
            public static Color _SupportColor = new Color(154f / 255f, 107f / 255f, 218f / 255f, 1);//9A6BDA
            public static Color _InvestigatorColor = new Color(107f / 255f, 218f / 255f, 114f / 255f, 1);//6BDA72
            public static Color _DefensiveColor = new Color(107f / 255f, 218f / 255f, 208f / 255f, 1);//6BDAD0

            public static Color PetrifyColor = new Color(255f / 255f, 0f / 255f, 255f / 255f, 50f / 255f);
            public static Color Petrify2Color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 160f / 255f);

            public static Color protectedColor = new Color(0, 1, 1, 1);
            public static Color ScannedColor = new Color(1, 0, 1, 1);
            public static Color TrackedColor = new Color(0, 1, 0, 1);
            public static Color UpdateShieldColor = new Color(0, 1, 1, 1);
            public static Color LovedColor = new Color(1, 0, 1, 1);
            public static Color BuffedColor = new Color(1, 0, 0, 1);
            public static Color MysticProtectedColor = new Color(1, 1, 0, 1);
            public static Color MysticNoProtectedColor = new Color(1, 1, 1, 0);
            public static Color InfCColor = new Color(0, 0, 1, 1);
            public static Color InfIColor = new Color(1, 0, 0, 1);

    }

}