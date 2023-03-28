using HarmonyLib;


namespace ChallengerMod.Cosmetiques
{


    [HarmonyPatch]
    public static class Cosmetics_Achievement
    {
        // ----- ACHIEVEMENT

        //COLOR
        public static bool Color_Bloody = false; 
        public static bool Color_Earth = false; 
        public static bool Color_Chedard = false; 
        public static bool Color_Sun = false; 
        public static bool Color_Leef = false; 
        public static bool Color_Radian = false; 
        public static bool Color_Swamp = false; 
        public static bool Color_Ice = false; 
        public static bool Color_Lagoon = false; 
        public static bool Color_Ocean = false; 
        public static bool Color_Night = false; 
        public static bool Color_Dawn = false; 
        public static bool Color_Candy = false; 
        public static bool Color_Galaxy = false; 
        public static bool Color_Snow = false; 
        public static bool Color_Cender = false; 
        public static bool Color_Dark = false; 
        public static bool Color_Rainbow = false; 

        public static bool Color_Ruby = false; 
        public static bool Color_Amber = false; 
        public static bool Color_Emerald = false; 
        public static bool Color_Larimar = false; 
        public static bool Color_Sapphir = false; 
        public static bool Color_Quartz = false;


        

       
        public static bool __Impostors = false; //Impostors
        public static bool __Assassin = false; //Assassin
        public static bool __Vector = false; //Vector
        public static bool __Morphling = false; //Morphling
        public static bool __Scrambler = false; //Scrambler
        public static bool __Barghest = false; //Barghest
        public static bool __Ghost = false; //Ghost
        public static bool __Sorcerer = false; //Sorcerer
        public static bool __Guesser = false; //Guesser
        public static bool __Basilisk = false; //Basilisk
        public static bool __Reaper = false; //Reaper
        public static bool __Mesmer = false; //Mesmer


        public static bool __Cupid = false; //Cupid*
        public static bool __Cultist = false; //Cultist*
        public static bool __Jester = false; //Jester
        public static bool __Eater = false; //Eater
        public static bool __Outlaw = false; //Outlaw
        public static bool __Arsonist = false; //Arsonist
        public static bool __Cursed = false; //Cursed

        public static bool __Mercenary = false; //Mercenary
        public static bool __Copycat = false; //CopyCat
        public static bool __Survivor = false; //Survivor
        public static bool __Revenger = false; //Revenger-
        public static bool __Slave = false; //Slave


        public static bool __Crewmates = false; //Crewmates
        public static bool __Sheriff = false; //Sheriff*
        public static bool __Guardian = false; //Guardian*
        public static bool __Engineer = false; //Engineer
        public static bool __Timelord = false; //Timelord
        public static bool __Hunter = false; //Hunter
        public static bool __Mystic = false; //Mystic*
        public static bool __Spirit = false; //Spirit
        public static bool __Mayor = false; //Mayor
        public static bool __Detective = false; //Detective*
        public static bool __Nightwatch = false; //Nightwatch
        public static bool __Spy = false; //Spy*
        public static bool __Informant = false; //Informant
        public static bool __Bait = false; //Bait
        public static bool __Mentalist = false; //Mentalist
        public static bool __Builder = false; //Builder
        public static bool __Dictator = false; //Dictator
        public static bool __Sentinel = false; //Sentinel*
        public static bool __Teammate = false; //Teammate
        public static bool __Lawkeeper = false; //Lawkeeper
        public static bool __Fake = false; //Fake
        public static bool __Leader = false; //Leader
        public static bool __Angel = false; //Angel
        public static bool __Traveler = false; //Traveler
        public static bool __Doctor = false; //Doctor






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