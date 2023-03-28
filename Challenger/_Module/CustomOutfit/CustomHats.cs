using HarmonyLib;
using UnityEngine;



namespace ChallengerMod.Cosmetics
{
    class CustomHats
    {
        public static Material MagicShader;


        
        private static bool CreateHats = false;


       

       



        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetHatById))]
        public static class AddCustomHats
        {



            public static void Postfix(HatManager __instance) {


                var allHats = __instance.allHats;

                //CREATOR
                if (!CreateHats)
                {
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC, "test", "test", "CC-00", 1000 , null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC00, "Lunastellia - [For Stellia]", "Lunastellia", "CC-00", 1001 , null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Pom2, "Pom Biboune - [For Emy]", "LilyPichou / Lunastellia", "CC-02", 1003, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC02, "Mini - [For Emy]", "Asman", "CC-02", 1004, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC03, "Noeud - [For Asman]", "Asman", "CC-03", 1005, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC04, "Avion - [For Val]", "Val", "CC-04", 1006, null, null, null, false, false, false, false));
                   
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_FRA, "[FRA] - Baguette !", "Lunastellia", "FRA", 1100, null, null, null, false, false, false, true));
                   
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SUB1, "Submerged Hat 1", "Submerged Team", "SUBMERGED", 1200, null, null, null, false, false, true, false));
                  
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI1, "ColorCloud", "Con_No_1", "FREE", 1300, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI2, "Big Egg", "Con_No_1", "FREE", 1301, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI3, "Sly", "Con_No_1", "FREE", 1302, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI4, "K K Shi", "Con_No_1", "FREE", 1303, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI5, "Pirate", "Con_No_1", "FREE", 1304, null, null, null, false, false, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI6, "Dinooo", "Con_No_1", "FREE", 1305, null, null, null, false, true, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI7, "Strong!", "Con_No_1", "FREE", 1306, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI8, "Flying Carpet", "Con_No_1 & Lunastellia", "FREE", 1307, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI9, "Painting", "Electricbeez & Lunastellia", "FREE", 1308, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI10, "MiniCrew", "Electricbeez", "FREE", 1309, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI14, "Poor Cat", "/", "FREE", 1313, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI11, "My Friend", "/", "FREE", 1310, null, null, null, false, true, true, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI12, "LN", "/", "FREE", 1311, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI13, "Murloc", "/", "FREE", 1312, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_TOI15, "Fox", "/", "FREE", 1315, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Licorne, "Unicorn", "Lunastellia", "FREE", 1316, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Ears, "Ears", "Lunastellia", "FREE", 1317, null, null, null, false, false, true, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SpeHorn, "S.Horn", "Lunastellia", "FREE", 3304, null, null, null, false, false, true, false));


                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bee, "[EGG] Bee", "LyliPichou", "SH-LILY", 1401, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Cat, "[EGG] Cat", "LyliPichou", "SH-LILY", 1402, null, null, null, false, false, false, false));                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Fluffy, "[EGG] Fluffy", "LyliPichou", "SH-LILY", 1403, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CatEars, "[EGG] Cat Ears", "LyliPichou", "SH-LILY", 1404, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_LilyPin, "[EGG] Lily Pin", "LyliPichou", "SH-LILY", 1405, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_ShootingStar, "[EGG] Shooting Star", "LyliPichou", "SH-LILY", 1406, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WitchHat, "[EGG] Witch Hat", "LyliPichou", "SH-LILY", 1407, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Toast, "[EGG] Toast", "LyliPichou", "SH-LILY", 1408, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Cake, "[EGG] Cake", "LyliPichou", "SH-LILY", 1409, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Meringue, "[EGG] Meringue", "Lunastellia", "SH-LILY", 1410, null, null, null, false, false, false, false));
                   
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Demon, "[Reward] Demon", "Lunastellia", "AC-IMPOSTORS", 2001, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Angel, "[Reward] Angel", "Asman", "AC-CREWMATES", 2002, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Joker, "[Reward] Jester", "Lunastellia", "AC-JESTER", 2003, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Crown, "[Reward] Crown", "Lunastellia", "SH-LEADER", 2004, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SpyGlass, "[Reward] SpyGlass", "Lunastellia", "AC-SPY", 2005, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Pom, "[Reward] Pom", "LyliPichou", "AC-SPIRIT", 2006, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Candle, "[Reward] Candle", "Lunastellia", "SH-NIGHTWATCH", 2007, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Snake, "[Reward] Snake", "Lunastellia", "AC-BASILISK", 2008, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Knight, "[Reward] Knight", "Lunastellia", "AC-GUARDIAN", 2009, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Mecha, "[Reward] Mecha", "Lunastellia", "AC-ENGINEER", 2010, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Dalek, "[Reward] Dalek", "Lunastellia", "AC-TIMELORD", 2011, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Hunt, "[Reward] Hunter", "Lunastellia", "AC-HUNTER", 2012, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Eater, "[Reward] Eater", "Lunastellia", "AC-EATER", 2013, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Ninja, "[Reward] Ninja", "Lunastellia", "AC-ASSASSIN", 2014, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Morph, "[Reward] Morph", "Lunastellia", "AC-MORPHLING", 2015, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Angry, "[Reward] Angry", "Lunastellia", "AC-DICTATOR", 2016, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Strange, "[Reward] Stranger", "Lunastellia", "AC-FAKE", 2017, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Alien, "[Reward] Alien", "Asman/Lunastellia", "AC-COPYCAT", 2018, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Outfit, "[Reward] Outfit", "Lunastellia", "SH-CULTIST", 2019, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Ghost, "[Reward] Ghost", "Lunastellia", "SH-GHOST", 2020, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CC002, "[Reward] Hollow", "Lunastellia", "CC-BARGHEST", 2022, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Curse, "[Reward] Cursed", "Asman/Lunastellia", "AC-CURSED", 2023, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Scarab, "[Reward] Scarab", "Lunastellia", "AC-REVENGER", 2024, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bowling, "[Reward] Bowling", "Lunastellia", "AC-BUILDER", 2025, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Selfi, "[Reward] Selfi", "Lunastellia", "AC-MAYOR", 2026, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Read, "[Reward] Read", "Lunastellia", "AC-LAWKEEPER", 2027, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Card, "[Reward] Tarot", "Lunastellia", "AC-INFORMANT", 2028, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Drone, "[Reward] Drone", "Lunastellia", "AC-SENTINEL", 2029, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Loupe, "[Reward] Lawkeeper", "Lunastellia", "AC-DETECTIVE", 2030, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Kawaii, "[Reward] Kawaii", "Asman", "AC-CUPID", 2031, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Rabbit, "[Reward] RabbitKawaii", "Asman", "AC-MYSTIC", 2032, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bear, "[Reward] BearKawaii", "Asman", "AC-TEAMMATE", 2033, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Dragon, "[Reward] Dragon", "Asman", "AC-ARSONIST", 2034, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Vampire, "[Reward] Vampire", "Lunastellia", "AC-VECTOR", 2035, null, null, null, false, false, false, false));


                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Brain, "[DLC] Brain", "Lunastellia", "SH-EAT", 3101, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Horror, "[DLC] Horror", "Lunastellia", "SH-EAT", 3102, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Reaper, "[DLC] Reaper", "Lunastellia", "SH-EAT", 3103, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WhiteMask, "[DLC] Hollow", "Lunastellia", "SH-EAT", 3104, null, null, ChallengerMod.Unity._Hat_WhiteMask_L, false, false, false, false));

                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Cupid, "[DLC] Cupid", "Lunastellia", "SH-CUP", 3201, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Timid, "[DLC] Timid", "Lunastellia", "SH-CUP", 3202, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Heart, "[DLC] I Love You", "Lunastellia", "SH-CUP", 3203, null, null, null, false, true, false, true));


                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar1, "[PRIME] - H.P", "Asman", "PRIME", 4101, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar2, "[PRIME] - R.W", "Asman", "PRIME", 4102, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar3, "[PRIME] - H.G", "Asman", "PRIME", 4103, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar4, "[PRIME] - D.M", "Asman", "PRIME", 4104, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar5, "[PRIME] - L.L", "Asman", "PRIME", 4105, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar6, "[PRIME] - S.T", "Asman", "PRIME", 4106, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar7, "[PRIME] - Q.Q", "Asman", "PRIME", 4107, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HChar8, "[PRIME] - A.D", "Asman", "PRIME", 4108, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HH1, "[PRIME] - Magic Hat", "Asman", "PRIME", 4109, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS1, "[PRIME] - Scarf1", "Asman", "PRIME", 4110, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS2, "[PRIME] - Scarf2", "Asman", "PRIME", 4111, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS3, "[PRIME] - Scarf3", "Asman", "PRIME", 4112, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_HS4, "[PRIME] - Scarf4", "Asman", "PRIME", 4113, null, null, null, false, false, false, false));

                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHIronMask, "[PRIME] - IronMask", "Lunastellia", "PRIME", 4201, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHSkipperman, "[PRIME] - Skipper-Man", "Lunastellia", "PRIME", 4202, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHCaptain, "[PRIME] - Captain", "Lunastellia", "PRIME", 4203, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHBruce, "[PRIME] - Bruce", "Lunastellia", "PRIME", 4204, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHBlacky, "[PRIME] - Blacky", "Lunastellia", "PRIME", 4206, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHThor, "[PRIME] - Thor", "Lunastellia", "PRIME", 4207, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHStranger, "[PRIME] - Strange", "Lunastellia", "PRIME", 4208, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHTiger, "[PRIME] - Panther", "Lunastellia", "PRIME", 4209, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHSlash, "[PRIME] - Slash", "Lunastellia", "PRIME", 4210, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHDevour, "[PRIME] - Symbiote", "Lunastellia", "PRIME", 4211, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHMyster, "[PRIME] - Mysterious", "Lunastellia", "PRIME", 4212, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHJoker, "[PRIME] - Joker", "Lunastellia", "PRIME", 4213, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHQuenny, "[PRIME] - Queeny", "Lunastellia", "PRIME", 4214, null, null, null, false, false, false, true));

                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWDark, "[PRIME] - DarkVad", "Lunastellia", "PRIME", 4301, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWMool, "[PRIME] - DarkMool", "Lunastellia", "PRIME", 4302, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWLela, "[PRIME] - MissLela", "Lunastellia", "PRIME", 4303, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWShewi, "[PRIME] - Chewie", "Lunastellia", "PRIME", 4304, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWBaby, "[PRIME] - Dayooo", "Lunastellia", "PRIME", 4305, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWAhsoka, "[PRIME] - Ahsoki", "Lunastellia", "PRIME", 4306, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWAaya, "[PRIME] - Aaila", "Lunastellia", "PRIME", 4307, null, null, null, false, true, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_SWAnak, "[PRIME] - Anakill", "Lunastellia", "PRIME", 4308, null, null, null, false, false, false, false));

                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_WHCutter, "[PRIME] - Screamer", "Lunastellia", "PRIME", 4401, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Clown, "[PRIME] Clown", "Asman", "PRIME", 4402, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Mask, "[PRIME] JigMask", "Asman", "PRIME", 4403, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_Bomber, "[PRIME] Bomber", "Lunastellia", "PRIME", 4404, null, null, null, false, false, false, false));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CPopCorn, "[PRIME] - Cine PopCorn", "Lunastellia", "PRIME", 4405, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_COscar, "[PRIME] - Cine Oscar", "Lunastellia", "PRIME", 4406, null, null, null, false, false, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CSound, "[PRIME] - Cine Sound", "Lunastellia", "PRIME", 4407, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CLight, "[PRIME] - Cine Light", "Lunastellia", "PRIME", 4408, null, null, null, false, true, false, true));
                    allHats.Add(CreateHat(ChallengerMod.Unity._Hat_CCamera, "[PRIME] - Cine Camera", "Lunastellia", "PRIME", 4409, null, null, null, false, true, false, true));

                    CreateHats = true;
                }
            }

            private static HatData CreateHat(Sprite sprite, string spritename, string author, string PID, int HatID, Sprite climb = null, Sprite floor = null, Sprite leftimage = null, bool bounce = false, bool altshader = false, bool isFree = false, bool blocksVisors = false) {
                
                if (MagicShader == null) {
                    Material hatShader = new Material("PlayerMaterial");
                    hatShader.shader = Shader.Find("Unlit/PlayerShader");
                    MagicShader = hatShader;
                }

                HatData newHat = ScriptableObject.CreateInstance<HatData>();
                newHat.hatViewData.viewData = ScriptableObject.CreateInstance<HatViewData>();
                newHat.name = $"{spritename} \n(by {author})";
                newHat.hatViewData.viewData.MainImage = sprite;
                newHat.ProductId = "hat_" + sprite.name.Replace(' ', '_');
                newHat.BundleId = PID;
                newHat.displayOrder = HatID;
                newHat.InFront = true;
                newHat.NoBounce = bounce;
                newHat.redeemPopUpColor = 5;
                newHat.hatViewData.viewData.FloorImage = floor;
                newHat.hatViewData.viewData.ClimbImage = climb;
                newHat.hatViewData.viewData.LeftMainImage = leftimage;
                newHat.ChipOffset = new Vector2(-0.1f, 0.4f);
                newHat.freeRedeemableCosmetic = false;
                newHat.Free = isFree;
                newHat.BlocksVisors = blocksVisors;

                if (altshader == true) 
                { 
                    newHat.hatViewData.viewData.AltShader = MagicShader;
                }

                return newHat;
            }
        }
    }
    
}
