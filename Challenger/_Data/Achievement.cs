using HarmonyLib;


namespace ChallengerMod.Cosmetiques
{


    [HarmonyPatch]
    public static class Cosmetics_Achievement
    {
        // ----- ACHIEVEMENT

        //COLOR
        public static bool Color_Bloody = false; //AC_C1
        public static bool Color_Earth = false; //AC_C2
        public static bool Color_Chedard = false; //AC_C3
        public static bool Color_Sun = false; //AC_C4
        public static bool Color_Leef = false; //AC_C5
        public static bool Color_Radian = false; //AC_C6
        public static bool Color_Swamp = false; //AC_C7
        public static bool Color_Ice = false; //AC_C8
        public static bool Color_Lagoon = false; //AC_C9
        public static bool Color_Ocean = false; //AC_C10
        public static bool Color_Night = false; //AC_C11
        public static bool Color_Dawn = false; //AC_C12
        public static bool Color_Candy = false; //AC_C13
        public static bool Color_Galaxy = false; //AC_C14
        public static bool Color_Snow = false; //AC_C15
        public static bool Color_Cender = false; //AC_C16
        public static bool Color_Dark = false; //AC_C17
        public static bool Color_Rainbow = false; //AC_C18


        //HAT
        public static bool Hat_Demon = false; //AC_H1
        public static bool Hat_Angel = false; //AC_H2
        public static bool Hat_Vampire = false; //AC_H3
        public static bool Hat_Kawaii = false; //AC_H4
        public static bool Hat_Angry = false; //AC_H5
        public static bool Hat_Cat = false; //AC_H6
        public static bool Hat_Knight = false; //AC_H7
        public static bool Hat_Crazy = false; //AC_H8
        public static bool Hat_FireFighter = false; //AC_H9
        public static bool Hat_Ninja = false; //AC_H10
        public static bool Hat_Alien = false; //AC_H11
        public static bool Hat_Barghest = false; //AC_H12
        public static bool Hat_Bomber = false; //AC_H13
        public static bool Hat_Dragon = false; //AC_H14


        //VISOR
        public static bool Visor_Gun = false; //AC_V1
        public static bool Visor_Knifte = false; //AC_V2
        public static bool Visor_Katana = false; //AC_V3
        public static bool Visor_Orbe = false; //AC_V4
        public static bool Visor_Cube = false; //AC_V5
        public static bool Visor_VampireTooth = false; //AC_V6
        public static bool Visor_Axe = false; //AC_V7
        public static bool Visor_DNA = false; //AC_V8
        public static bool Visor_Chain = false; //AC_V9
        public static bool Visor_MagicWand = false; //AC_V10
        public static bool Visor_FireBall = false; //AC_V11


        
    }
    public static class Cosmetics_Ranked
    {
        // ----- RANKED

        //PLATENAME

        //STATIC RANK
        public static int IntRank = 0;

        //UNLOCK AFTER SX
        public static bool Plate_S1R1 = false;
        public static bool Plate_S1R2 = false;
        public static bool Plate_S1R3 = false;
        public static bool Plate_S1R4 = false;
        public static bool Plate_S1R5 = false;
        public static bool Plate_S1R6 = false;
        public static bool Plate_S1R7 = false;
        public static bool Plate_S1R8 = false;
        public static bool Plate_S1R9 = false;
        public static bool Plate_S1R10 = false;
        public static bool Plate_S1R11 = false;
        public static bool Plate_S1R12 = false;
        public static bool Plate_S1R13 = false;
        public static bool Plate_S1R14 = false;
    }
    public static class Cosmetics_Shops
    {
        // ----- SHOP

        //PRIME
        public static bool Bundle_Prime = false; // Prime

        //EATER BUNDLE
        public static bool Bundle_Eater = false; // Octobre-Novembre 2022


        public static bool Bundle_Cultist = false; // Decembre-Janvier 2023
        public static bool Bundle_Cupid = false; // Fevrier-Mars 2023

        public static bool Bundle_Lily = false; // EasterEgg

    }
    public static class Cosmetics_ContentCreator
    {
        
        public static bool Bundle_Stellia = false;
        public static bool Bundle_Matux = false;
        public static bool Bundle_Emy = false; 
        public static bool Bundle_Asman = false;
        public static bool Bundle_Val = false;
        
    }
}