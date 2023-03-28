using HarmonyLib;
using UnityEngine;



namespace ChallengerMod.Cosmetics
{
    class CustomNamePlates
    {

        private static bool CreateNamePlates = false;
        

        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetNamePlateById))]
        public static class AddCustomNamePlates
        {



            public static void Postfix(HatManager __instance)
            {


                var allPlates = __instance.allNamePlates;


                //RANKED
                if (!CreateNamePlates)
                {
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_1, "Season 1 - Bronze 3", "Lunastellia", "R-S1R1", 1001, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_2, "Season 1 - Bronze 2", "Lunastellia", "R-S1R2", 1002, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_3, "Season 1 - Bronze 1", "Lunastellia", "R-S1R3", 1003, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_4, "Season 1 - Silver 3", "Lunastellia", "R-S1R4", 1004, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_5, "Season 1 - Silver 2", "Lunastellia", "R-S1R5", 1005, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_6, "Season 1 - Silver 1", "Lunastellia", "R-S1R6", 1006, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_7, "Season 1 - Gold 3", "Lunastellia", "R-S1R7", 1007, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_8, "Season 1 - Gold 2", "Lunastellia", "R-S1R8", 1008, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_9, "Season 1 - Gold 1", "Lunastellia", "R-S1R9", 1009, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_10, "Season 1 - Crystal 3", "Lunastellia", "R-S1R10", 1010, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_11, "Season 1 - Crystal 2", "Lunastellia", "R-S1R11", 1011, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_12, "Season 1 - Crystal 1", "Lunastellia", "R-S1R12", 1012, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_13, "Season 1 - Epic", "Lunastellia", "R-S1R13", 1013, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_14, "Season 1 - Master", "Lunastellia", "R-S1R14", 1014, false));

                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB1, "Submerged 1", "Submerged Team", "SUBMERGED", 2001, true));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB2, "Submerged 2", "Submerged Team", "SUBMERGED", 2002, true));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SUB3, "Submerged 3", "Submerged Team", "SUBMERGED", 2003, true));

                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Eater, "[DLC] The Eater", "Lunastellia", "SH-EAT", 3101, false));
                   
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Cupid, "[DLC] Love & Cupid", "Asman", "SH-CUP", 3201, false));

                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_Arsonist, "[DLC] Burn them all", "Lunastellia", "SH-ARS", 3401, false));

                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SW1, "[PRIME] SpaceWar 1", "Lunastellia", "PRIME", 4301, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_SW2, "[PRIME] SpaceWar 2", "Lunastellia", "PRIME", 4302, false));

                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CBand, "[PRIME] CineBand", "Lunastellia", "PRIME", 4401, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CClap, "[PRIME] CineClap", "Lunastellia", "PRIME", 4402, false));
                    allPlates.Add(CreateNamePlate(ChallengerMod.Unity._Plate_CBG, "[PRIME] CineGreen", "Lunastellia", "PRIME", 4403, false));


                    CreateNamePlates = true;
                }
            }
                
         
            private static NamePlateData CreateNamePlate(Sprite sprite, string spritename, string author, string PID,int NamePlateID, bool isFree)
            {

                NamePlateData newPlate = ScriptableObject.CreateInstance<NamePlateData>();
                newPlate.viewData.viewData = ScriptableObject.CreateInstance<NamePlateViewData>();
                newPlate.name = $"{spritename} \n(by {author})";
                newPlate.viewData.viewData.Image = sprite;
                newPlate.ProductId = "nameplate_" + sprite.name.Replace(' ', '_');
                newPlate.BundleId = PID;
                newPlate.displayOrder = NamePlateID;
                newPlate.Free = isFree;
                newPlate.ChipOffset = new Vector2(0f, 0.2f);
                newPlate.freeRedeemableCosmetic = false;

                return newPlate;
            }
        }
    }
}



        
       
           
           
           