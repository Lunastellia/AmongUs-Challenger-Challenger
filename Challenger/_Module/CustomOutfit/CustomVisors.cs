using HarmonyLib;
using TMPro;
using UnityEngine;



namespace ChallengerMod.Cosmetics
{
    class CustomVisors
    {
        public static Material MagicShader;


        private static bool CreateVisors = false;
        



        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetVisorById))]
        public static class AddCustomVisors
        {

            public static void Postfix(HatManager __instance)
            {
                var allVisors = __instance.allVisors;


                if (!CreateVisors)
                {
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_CC00, "Lunastellia - [For Stellia]", "Lunastellia", "CC-00", 1000, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cred, "Visor Red", "Lunastellia", "AC-FREE", 1300, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cpink, "Visor Pink", "Lunastellia", "AC-FREE", 1301, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cblue, "Visor Blue", "Lunastellia", "AC-FREE", 1302, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cgreen, "Visor Green", "Lunastellia", "AC-FREE", 1303, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cleef, "Visor Leef", "Lunastellia", "AC-FREE", 1304, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Cyellow, "Visor Yellow", "Lunastellia", "AC-FREE", 1305, null, false, true));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Fish, "Fish", "Asman", "AC-FREE", 1306, null, false, true));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Spiral_1, "[Reward] VisorColored", "Lunastellia", "AC-MENTALIST", 2001, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Gun, "[Reward] Gun", "Lunastellia", "AC-SHERIFF", 2002, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Knife, "[Reward] Knife", "Lunastellia", "AC-OUTLAW", 2003, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Katana, "[Reward] Katana", "Lunastellia", "AC-MERCENARY", 2004, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_GSword, "[Reward] GreatSword", "Lunastellia", "AC-SURVIVOR", 2005, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Axe, "[Reward] Axe", "Lunastellia", "AC-BAIT", 2006, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Mace, "[Reward] Mace", "Lunastellia", "AC-SCRAMBLER", 2007, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Staff, "[Reward] Staff", "Lunastellia", "AC-SORCERER", 2008, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_VampireTooth, "[Reward] VampireTooth", "Lunastellia", "AC-VECTOR", 2009, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Coffee, "[Reward] Coffee", "Lunastellia", "AC-GUESSER", 2010, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Bloody, "[DLC] Blood", "Lunastellia", "SH-EAT", 3101, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Scythe, "[DLC] Scythe", "Lunastellia", "SH-EAT", 3102, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Baloon, "[DLC] Baloon", "Lunastellia", "SH-CUP", 3201, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_Love, "[DLC] In Love", "Lunastellia", "SH-CUP", 3202, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_LV2, "[DLC] You and Me", "Lunastellia", "SH-CUP", 3203, ChallengerMod.Unity._Visor_LV1, false ,false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_DBook, "[DLC] Dark Book", "Lunastellia", "SH-CLT", 3301, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H1, "[PRIME] L.L", "Asman", "PRIME", 4101, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_H2, "[PRIME] S.T", "Asman", "PRIME", 4102, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB1, "[PRIME] Magic Wand 1", "Lunastellia", "PRIME", 4103, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB2, "[PRIME] Magic Wand 2", "Lunastellia", "PRIME", 4104, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_HB3, "[PRIME] Magic Wand 3", "Lunastellia", "PRIME", 4105, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber1, "[PRIME] Blue LightSaber", "Lunastellia", "PRIME", 4301, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber2, "[PRIME] Green LightSaber", "Lunastellia", "PRIME", 4302, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber3, "[PRIME] Purple LightSaber", "Lunastellia", "PRIME", 4303, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber4, "[PRIME] Gold LightSaber", "Lunastellia", "PRIME", 4304, null, false, false));
                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_SWSaber5, "[PRIME] Red LightSaber", "Lunastellia", "PRIME", 4305, null, false, false));

                    allVisors.Add(CreateVisor(ChallengerMod.Unity._Visor_C3D, "[PRIME] 3D", "Lunastellia", "PRIME", 4401, null, false, false));

                    CreateVisors = true;
                }
            }
            

            
            private static VisorData CreateVisor(Sprite sprite, string spritename, string author, string PID,int VisorID, Sprite leftIdleFrame = null, bool altshader = false, bool isFree = false )
            {
                if (MagicShader == null)
                {
                    Material hatShader = new Material("PlayerMaterial");
                    hatShader.shader = Shader.Find("Unlit/PlayerShader");
                    MagicShader = hatShader;
                }

                VisorData newVisor = ScriptableObject.CreateInstance<VisorData>();
                newVisor.viewData.viewData = ScriptableObject.CreateInstance<VisorViewData>();
                newVisor.name = $"{spritename} \n(by {author})";
                newVisor.viewData.viewData.IdleFrame = sprite;
                newVisor.ProductId = "visor_" + sprite.name.Replace(' ', '_');
                newVisor.BundleId = PID;
                newVisor.viewData.viewData.LeftIdleFrame = leftIdleFrame;
                newVisor.displayOrder = VisorID;
                newVisor.ChipOffset = new Vector2(0f, 0.2f);
                newVisor.freeRedeemableCosmetic = false;
                newVisor.Free = isFree;

                if (altshader == true)
                {
                    //newVisor.viewData.viewData.AltShader = MagicShader;
                }

                    return newVisor;
            }
           

        }
    }
}