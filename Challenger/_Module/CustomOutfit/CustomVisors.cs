using HarmonyLib;
using TMPro;
using UnityEngine;



namespace ChallengerMod.Cosmetics
{
    class CustomVisors
    {
        private static bool _VStellia = false;


        private static bool _Gun = false;
        private static bool _Knife = false;
        private static bool _Katana = false;
        private static bool _Vampire_Tooth = false;
        private static bool _Spiral = false;
        private static bool _Chain = false;
        private static bool _Coffee = false;

        private static bool _Cred = false;
        private static bool _Cpurple = false;
        private static bool _Cpink = false;
        private static bool _Cblue = false;
        private static bool _Cgreen = false;
        private static bool _Cleef = false;
        private static bool _Cyellow = false;

        //DLC EATER
        private static bool _Bloody = false;
        private static bool _Scythe = false;

        //DLC CUPID
        private static bool _Inlove = false;
        private static bool _Baloon = false;
        private static bool _Dual = false;

        //DLC CULTE
        private static bool _Book = false;

        private static bool _H1 = false;
        private static bool _H2 = false;
        private static bool _H3 = false;
        private static bool _H4 = false;
        private static bool _H5 = false;

        private static bool _SW1 = false;
        private static bool _SW2 = false;
        private static bool _SW3 = false;
        private static bool _SW4 = false;
        private static bool _SW5 = false;

        private static bool _CV1 = false;




        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetVisorById))]
        public static class AddCustomVisors
        {

            public static void Postfix(HatManager __instance)
            {
                var allVisors = __instance.allVisors;


                if (!_VStellia)
                {
                    VisorID = 100;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_CC00, "Lunastellia - [For Stellia]", "Lunastellia", "CC-00", null, false));
                    _VStellia = true;
                }

                //ACHIEVEMENT



                if (!_Cred)
                {
                    VisorID = 193;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cred, "[Reward] Visor Red", "Lunastellia", "AC-V4", null, false));
                    _Cred = true;
                }
                if (!_Cpink)
                {
                    VisorID = 194;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cpink, "[Reward] Visor Pink", "Lunastellia", "AC-V5", null, false));
                    _Cpink = true;
                }
                if (!_Cpurple)
                {
                    VisorID = 195;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cpurple, "[Reward] Visor Purple", "Lunastellia", "AC-V7", null, false));
                    _Cpurple = true;
                }
                if (!_Cblue)
                {
                    VisorID = 196;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cblue, "[Reward] Visor Blue", "Lunastellia", "AC-V4", null, false));
                    _Cblue = true;
                }
                if (!_Cgreen)
                {
                    VisorID = 197;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cgreen, "[Reward] Visor Green", "Lunastellia", "AC-V5", null, false));
                    _Cgreen = true;
                }
                if (!_Cleef)
                {
                    VisorID = 198;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cleef, "[Reward] Visor Leef", "Lunastellia", "AC-V7", null, false));
                    _Cleef = true;
                }
                if (!_Cyellow)
                {
                    VisorID = 199;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cyellow, "[Reward] Visor Yellow", "Lunastellia", "AC-V10", null, false));
                    _Cyellow = true;
                }


                if (!_Gun)
                {
                    VisorID = 201;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Gun, "[Reward] Gun", "Lunastellia", "AC-V1", null, false));
                    _Gun = true;
                }
                if (!_Knife)
                {
                    VisorID = 202;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Knife, "[Reward] Knife", "Lunastellia", "AC-V2", null, false));
                    _Knife = true;
                }
                if (!_Katana)
                {
                    VisorID = 203;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Katana, "[Reward] Katana", "Lunastellia", "AC-V3", null, false));
                    _Katana = true;
                }
                if (!_Vampire_Tooth)
                {
                    VisorID = 206;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_VampireTooth, "[Reward] VampireTooth", "Lunastellia", "AC-V6", null, false));
                    _Vampire_Tooth = true;
                }
                if (!_Spiral)
                {
                    VisorID = 208;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Spiral_1, "[Reward] Strange", "Lunastellia", "AC-V8", null, false));
                    _Spiral = true;
                }
                if (!_Chain)
                {
                    VisorID = 209;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Fish, "[Reward] Fish", "Asman", "AC-V9", null, false));
                    _Chain = true;
                }
                
                if (!_Coffee)
                {
                    VisorID = 210;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Coffee, "[Reward] Coffee", "Lunastellia", "AC-V11", null, false));
                    _Coffee = true;
                }

                //DLS Eater
                if (!_Bloody)
                {
                    VisorID = 501;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Bloody, "[DLC] Blood", "Lunastellia", "SH-EAT", null, false));
                    _Bloody = true;
                }
                if (!_Scythe)
                {
                    VisorID = 502;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Scythe, "[DLC] Scythe", "Lunastellia", "SH-EAT", null, false));
                    _Scythe = true;
                }

                //DLC CUPID
                if (!_Baloon)
                {
                    VisorID = 503;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Baloon, "[DLC] Baloon", "Lunastellia", "SH-CUP", null, false));
                    _Baloon = true;
                }
                if (!_Inlove)
                {
                    VisorID = 504;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Love, "[DLC] In Love", "Lunastellia", "SH-CUP", null, false));
                    _Inlove = true;
                }
                if (!_Dual)
                {
                    VisorID = 505;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_LV2, "[DLC] You and Me", "Lunastellia", "SH-CUP", ChallengerMod.Unity._Visor_LV1, false));
                    _Dual = true;
                }

                //DLC CULTE
                if (!_Book)
                {
                    VisorID = 506;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_DBook, "[DLC] Dark Book", "Lunastellia", "SH-CLT", null, false));
                    _Book = true;
                }


                //PRIME
                if (!_H1)
                {
                    VisorID = 701;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H1, "[PRIME] L.L", "Asman", "PRIME", null, false));
                    _H1 = true;
                }
                if (!_H2)
                {
                    VisorID = 702;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H2, "[PRIME] S.T", "Asman", "PRIME", null, false));
                    _H2 = true;
                }
                if (!_H3)
                {
                    VisorID = 703;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB1, "[PRIME] Magic Wand 1", "Lunastellia", "PRIME", null, false));
                    _H3 = true;
                }
                if (!_H4)
                {
                    VisorID = 704;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB2, "[PRIME] Magic Wand 2", "Lunastellia", "PRIME", null, false));
                    _H4 = true;
                }
                if (!_H5)
                {
                    VisorID = 705;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB3, "[PRIME] Magic Wand 3", "Lunastellia", "PRIME", null, false));
                    _H5 = true;
                }

                if (!_SW1)
                {
                    VisorID = 706;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber1, "[PRIME] Blue LightSaber", "Lunastellia", "PRIME", null, false));
                    _SW1 = true;
                }
                if (!_SW2)
                {
                    VisorID = 707;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber2, "[PRIME] Green LightSaber", "Lunastellia", "PRIME", null, false));
                    _SW2 = true;
                }
                if (!_SW3)
                {
                    VisorID = 708;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber3, "[PRIME] Purple LightSaber", "Lunastellia", "PRIME", null, false));
                    _SW3 = true;
                }
                if (!_SW4)
                {
                    VisorID = 709;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber4, "[PRIME] Gold LightSaber", "Lunastellia", "PRIME", null, false));
                    _SW4 = true;
                }
                if (!_SW5)
                {
                    VisorID = 710;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber5, "[PRIME] Red LightSaber", "Lunastellia", "PRIME", null, false));
                    _SW5 = true;
                }

                if (!_CV1)
                {
                    VisorID = 711;
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_C3D, "[PRIME] 3D", "Lunastellia", "PRIME", null , false));
                    _CV1 = true;
                }

            }
            


            public static int VisorID = 0;
            
            private static VisorData CreateVisor(Sprite sprite, string spritename, string author, string PID, Sprite leftIdleFrame = null, bool isFree = false)
            {

                VisorData newVisor = ScriptableObject.CreateInstance<VisorData>();
                newVisor.viewData.viewData = ScriptableObject.CreateInstance<VisorViewData>();
                newVisor.name = $"{spritename} \n(by {author})";
                newVisor.viewData.viewData.IdleFrame = sprite;
                newVisor.ProductId = "visor_" + sprite.name.Replace(' ', '_');
                newVisor.BundleId = PID;
                newVisor.viewData.viewData.LeftIdleFrame = leftIdleFrame;
                newVisor.displayOrder = 1000 + VisorID;
                newVisor.ChipOffset = new Vector2(0f, 0.2f);
                newVisor.freeRedeemableCosmetic = false;
                newVisor.Free = isFree;

                return newVisor;
            }
           

        }
    }
}