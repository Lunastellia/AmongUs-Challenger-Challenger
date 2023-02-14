using HarmonyLib;
using UnityEngine;



namespace ChallengerMod.Cosmetics
{
    class CustomNamePlates
    {

        private static bool _R1 = false;
        private static bool _R2 = false;
        private static bool _R3 = false;
        private static bool _R4 = false;
        private static bool _R5 = false;
        private static bool _R6 = false;
        private static bool _R7 = false;
        private static bool _R8 = false;
        private static bool _R9 = false;
        private static bool _R10 = false;
        private static bool _R11 = false;
        private static bool _R12 = false;
        private static bool _R13 = false;
        private static bool _R14 = false;

        private static bool _Sub1 = false;
        private static bool _Sub2 = false;
        private static bool _Sub3 = false;

        private static bool _Eater = false;
        private static bool _Cupid = false;
        private static bool _Arsonist = false;
        
        private static bool _SW1 = false;
        private static bool _SW2 = false;

        private static bool _NC1 = false;
        private static bool _NC2 = false;
        private static bool _NC3 = false;

        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetNamePlateById))]
        public static class AddCustomNamePlates
        {



            public static void Postfix(HatManager __instance)
            {


                var allPlates = __instance.allNamePlates;


                //RANKED
                if (!_R1)
                {
                    NamePlateID = 1;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_1, "Season 1 - Bronze 3", "Lunastellia", "R-S1R1", false));
                    _R1 = true;
                }
                if (!_R2)
                {
                    NamePlateID = 2;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_2, "Season 1 - Bronze 2", "Lunastellia", "R-S1R2", false));
                    _R2 = true;
                }
                if (!_R3)
                {
                    NamePlateID = 3;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_3, "Season 1 - Bronze 1", "Lunastellia", "R-S1R3", false));
                    _R3 = true;
                }
                if (!_R4)
                {
                    NamePlateID = 4;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_4, "Season 1 - Silver 3", "Lunastellia", "R-S1R4", false));
                    _R4 = true;
                }
                if (!_R5)
                {
                    NamePlateID = 5;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_5, "Season 1 - Silver 2", "Lunastellia", "R-S1R5", false));
                    _R5 = true;
                }
                if (!_R6)
                {
                    NamePlateID = 6;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_6, "Season 1 - Silver 1", "Lunastellia", "R-S1R6", false));
                    _R6 = true;
                }
                if (!_R7)
                {
                    NamePlateID = 7;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_7, "Season 1 - Gold 3", "Lunastellia", "R-S1R7", false));
                    _R7 = true;
                }
                if (!_R8)
                {
                    NamePlateID = 8;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_8, "Season 1 - Gold 2", "Lunastellia", "R-S1R8", false));
                    _R8 = true;
                }
                if (!_R9)
                {
                    NamePlateID = 9;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_9, "Season 1 - Gold 1", "Lunastellia", "R-S1R9", false));
                    _R9 = true;
                }
                if (!_R10)
                {
                    NamePlateID = 10;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_10, "Season 1 - Crystal 3", "Lunastellia", "R-S1R10", false));
                    _R10 = true;
                }
                if (!_R11)
                {
                    NamePlateID = 11;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_11, "Season 1 - Crystal 2", "Lunastellia", "R-S1R11", false));
                    _R11 = true;
                }
                if (!_R12)
                {
                    NamePlateID = 12;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_12, "Season 1 - Crystal 1", "Lunastellia", "R-S1R12", false));
                    _R12 = true;
                }
                if (!_R13)
                {
                    NamePlateID = 13;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_13, "Season 1 - Epic", "Lunastellia", "R-S1R13", false));
                    _R13 = true;
                }
                if (!_R14)
                {
                    NamePlateID = 14;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_14, "Season 1 - Master", "Lunastellia", "R-S1R14", false));
                    _R14 = true;
                }

                //FREE
                if (!_Sub1)
                {
                    NamePlateID = 201;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB1, "Submerged 1", "Submerged Team", "SUBMERGED", true));
                    _Sub1 = true;
                }
                if (!_Sub2)
                {
                    NamePlateID = 202;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB2, "Submerged 2", "Submerged Team", "SUBMERGED", true));
                    _Sub2 = true;
                }
                if (!_Sub3)
                {
                    NamePlateID = 203;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB3, "Submerged 3", "Submerged Team", "SUBMERGED", true));
                    _Sub3 = true;
                }


                //SHOP
                if (!_Eater)
                {
                    NamePlateID = 501;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Eater, "[DLC] The Eater", "Lunastellia", "SH-EAT", false));
                    _Eater = true;
                }
                if (!_Cupid)
                {
                    NamePlateID = 502;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Cupid, "[DLC] Love & Cupid", "Asman", "SH-CUP", false));
                    _Cupid = true;
                }
                if (!_Arsonist)
                {
                    NamePlateID = 503;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Arsonist, "[DLC] Burn them all", "Lunastellia", "SH-ARS", false));
                    _Arsonist = true;
                }


                if (!_SW1)
                {
                    NamePlateID = 508;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SW1, "[PRIME] SpaceWar 1", "Lunastellia", "PRIME", false));
                    _SW1 = true;
                }
                if (!_SW2)
                {
                    NamePlateID = 509;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SW2, "[PRIME] SpaceWar 2", "Lunastellia", "PRIME", false));
                    _SW2 = true;
                }


                if (!_NC1)
                {
                    NamePlateID = 510;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CBand, "[PRIME] CineBand", "Lunastellia", "PRIME", false));
                    _NC1 = true;
                }

                if (!_NC2)
                {
                    NamePlateID = 511;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CClap, "[PRIME] CineClap", "Lunastellia", "PRIME", false));
                    _NC2 = true;
                }

                if (!_NC3)
                {
                    NamePlateID = 512;
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CBG, "[PRIME] CineGreen", "Lunastellia", "PRIME", false));
                    _NC3 = true;
                }
            }



            public static int NamePlateID = 0;
           
            
            private static NamePlateData CreateNamePlate(Sprite sprite, string spritename, string author, string PID, bool isFree)
            {

                NamePlateData newPlate = ScriptableObject.CreateInstance<NamePlateData>();
                newPlate.viewData.viewData = ScriptableObject.CreateInstance<NamePlateViewData>();
                newPlate.name = $"{spritename} \n(by {author})";
                newPlate.viewData.viewData.Image = sprite;
                newPlate.ProductId = "nameplate_" + sprite.name.Replace(' ', '_');
                newPlate.BundleId = PID;
                newPlate.displayOrder = 1000 + NamePlateID;
                newPlate.Free = isFree;
                newPlate.ChipOffset = new Vector2(0f, 0.2f);
                newPlate.freeRedeemableCosmetic = false;

                return newPlate;
            }
        }
    }
}



        
       
           
           
           