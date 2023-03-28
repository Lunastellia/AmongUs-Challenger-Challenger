using HarmonyLib;


namespace ChallengerMod.Cosmetiques
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(PlayerCustomizationMenu), nameof(PlayerCustomizationMenu.OpenTab))]
    public static class OpenTab
    {
        public static void Prefix(PlayerCustomizationMenu __instance)
        {
            PlayerCosmetics.CheckForUnlock();
        }
    }


    public static class PlayerCosmetics
    {

        public static void CheckForUnlock()
        {

            if (GLMod.GLMod.isUnlocked("CC-00")) { ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Stellia = true; }
            if (GLMod.GLMod.isUnlocked("CC-01")) { ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Matux = true; }
            if (GLMod.GLMod.isUnlocked("CC-02")) { ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Emy = true; }
            if (GLMod.GLMod.isUnlocked("CC-03")) { ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Asman = true; }
            if (GLMod.GLMod.isUnlocked("CC-04")) { ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Val = true; }

            //UPDATE UNLOCK

            if (GLMod.GLMod.isUnlocked("AC-IMPOSTORS")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Impostors = true; }
            if (GLMod.GLMod.isUnlocked("AC-CREWMATES")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Crewmates = true; }

            if (GLMod.GLMod.isUnlocked("AC-ASSASSIN")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Assassin = true; }
            if (GLMod.GLMod.isUnlocked("AC-VECTOR")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Vector = true; }
            if (GLMod.GLMod.isUnlocked("AC-MORPHLING")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Morphling = true; }
            if (GLMod.GLMod.isUnlocked("AC-SCRAMBLER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Scrambler = true; }
            if (GLMod.GLMod.isUnlocked("AC-BARGHEST")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Barghest = true; }
            if (GLMod.GLMod.isUnlocked("AC-GHOST")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Ghost = true; }
            if (GLMod.GLMod.isUnlocked("AC-SORCERER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sorcerer = true; }
            if (GLMod.GLMod.isUnlocked("AC-GUESSER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Guesser = true; }
            if (GLMod.GLMod.isUnlocked("AC-BASILISK")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Basilisk = true; }
            if (GLMod.GLMod.isUnlocked("AC-REAPER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Reaper = true; }
            if (GLMod.GLMod.isUnlocked("AC-MESMER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mesmer = true; }

            if (GLMod.GLMod.isUnlocked("AC-CUPID")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cupid = true; }
            if (GLMod.GLMod.isUnlocked("AC-CULTIST")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cultist = true; }
            if (GLMod.GLMod.isUnlocked("AC-JESTER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Jester = true; }
            if (GLMod.GLMod.isUnlocked("AC-EATER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Eater = true; }
            if (GLMod.GLMod.isUnlocked("AC-OUTLAW")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Outlaw = true; }
            if (GLMod.GLMod.isUnlocked("AC-ARSONIST")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Arsonist = true; }
            if (GLMod.GLMod.isUnlocked("AC-CURSED")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cursed = true; }

            if (GLMod.GLMod.isUnlocked("AC-MERCENARY")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mercenary = true; }
            if (GLMod.GLMod.isUnlocked("AC-COPYCAT")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Copycat = true; }
            if (GLMod.GLMod.isUnlocked("AC-SURVIVOR")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Survivor = true; }
            if (GLMod.GLMod.isUnlocked("AC-REVENGER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Revenger = true; }
            if (GLMod.GLMod.isUnlocked("AC-SLAVE")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Slave = true; }


            if (GLMod.GLMod.isUnlocked("AC-DICTATOR")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Bloody = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Dictator = true; }
            if (GLMod.GLMod.isUnlocked("AC-MAYOR")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Earth = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mayor = true; }
            if (GLMod.GLMod.isUnlocked("AC-ENGINEER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Chedard = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Engineer = true; }
            if (GLMod.GLMod.isUnlocked("AC-MYSTIC")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Sun = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mystic = true; }
            if (GLMod.GLMod.isUnlocked("AC-HUNTER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Leef = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Hunter = true; }
            if (GLMod.GLMod.isUnlocked("AC-SENTINEL")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Radian = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sentinel = true; }
            if (GLMod.GLMod.isUnlocked("AC-DETECTIVE")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Swamp = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Detective = true; }
            if (GLMod.GLMod.isUnlocked("AC-GUARDIAN")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ice = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Guardian = true; }
            if (GLMod.GLMod.isUnlocked("AC-SPY")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Lagoon = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Spy = true; }
            if (GLMod.GLMod.isUnlocked("AC-TIMELORD")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ocean = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Timelord = true; }
            if (GLMod.GLMod.isUnlocked("AC-NIGHTWATCH")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Night = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Nightwatch = true; }
            if (GLMod.GLMod.isUnlocked("AC-SPIRIT")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dawn = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Spirit = true; }
            if (GLMod.GLMod.isUnlocked("AC-TEAMMATE")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Candy = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Teammate = true; }
            if (GLMod.GLMod.isUnlocked("AC-MENTALIST")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Galaxy = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mentalist = true; }
            if (GLMod.GLMod.isUnlocked("AC-LAWKEEPER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Snow = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Lawkeeper = true; }
            if (GLMod.GLMod.isUnlocked("AC-BAIT")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Cender = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Bait = true; }
            if (GLMod.GLMod.isUnlocked("AC-FAKE")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dark = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Fake = true; }
            if (GLMod.GLMod.isUnlocked("AC-ANGEL")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Rainbow = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Angel = true; }

            if (GLMod.GLMod.isUnlocked("AC-BUILDER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ruby = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Builder = true; }
            if (GLMod.GLMod.isUnlocked("AC-SHERIFF")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Amber = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sheriff = true; }
            if (GLMod.GLMod.isUnlocked("AC-DOCTOR")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Emerald = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Doctor = true; }
            if (GLMod.GLMod.isUnlocked("AC-INFORMANT")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Larimar = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Informant = true; }
            if (GLMod.GLMod.isUnlocked("AC-LEADER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Sapphir = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Leader = true; }
            if (GLMod.GLMod.isUnlocked("AC-TRAVELER")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Quartz = true; ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Traveler = true; }



            if (GLMod.GLMod.hasDlc(2171400)) { ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Eater = true; }
            if (GLMod.GLMod.hasDlc(2240160)) { ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Prime = true; }
            if (GLMod.GLMod.hasDlc(2294680)) { ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Cupid = true; }
            if (GLMod.GLMod.hasDlc(2294683)) { ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Cultist = true; }




            

            ChallengerMod.Cosmetiques.PlayerCosmetics.CheckForUpdate();

        }
        public static void CheckForUpdate()
        {




            //UNLOCK CHECK
            if (ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Stellia)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-00") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-00") { V.Free = true; } }

            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-00") { H.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-00") { V.Free = false; } }
            }



            if (ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Matux)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-01") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-01") { V.Free = true; } }
            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-01") { H.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-01") { V.Free = false; } }
            }



            if (ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Emy)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-02") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-02") { V.Free = true; } }
            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-02") { H.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-02") { V.Free = false; } }
            }



            if (ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Asman)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-03") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-03") { V.Free = true; } }
            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-03") { H.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-03") { V.Free = false; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_ContentCreator.Bundle_Val)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-04") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-04") { V.Free = true; } }
            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "CC-04") { H.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "CC-04") { V.Free = false; } }
            }



            //ACHIEVEMENT & Shop
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Impostors)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-IMPOSTORS") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Crewmates)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-CREWMATES") { H.Free = true; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Assassin)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-ASSASSIN") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-ASSASSIN") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Vector)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-VECTOR") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-VECTOR") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Morphling)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MORPHLING") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MORPHLING") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Scrambler)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SCRAMBLER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SCRAMBLER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Barghest)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-BARGHEST") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-BARGHEST") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Ghost)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-GHOST") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-GHOST") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sorcerer)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SORCERER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SORCERER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Guesser)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-GUESSER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-GUESSER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Basilisk)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-BASILISK") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-BASILISK") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Reaper)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-REAPER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-REAPER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mesmer)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MESMER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MESMER") { V.Free = true; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cupid)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-CUPID") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-CUPID") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cultist)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-CULTIST") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-CULTIST") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Jester)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-JESTER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-JESTER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Eater)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-EATER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-EATER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Outlaw)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-OUTLAW") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-OUTLAW") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Arsonist)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-ARSONIST") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-ARSONIST") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Cursed)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-CURSED") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-CURSED") { V.Free = true; } }
            }


            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mercenary)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MERCENARY") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MERCENARY") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Copycat)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-COPYCAT") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-COPYCAT") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Survivor)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SURVIVOR") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SURVIVOR") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Revenger)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-REVENGER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-REVENGER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Slave)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SLAVE") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SLAVE") { V.Free = true; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sheriff)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SHERIFF") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SHERIFF") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Guardian)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-GUARDIAN") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-GUARDIAN") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Engineer)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-ENGINEER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-ENGINEER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Timelord)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-TIMELORD") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-TIMELORD") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Hunter)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-HUNTER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-HUNTER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mystic)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MYSTIC") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MYSTIC") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Spirit)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SPIRIT") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SPIRIT") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mayor)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MAYOR") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MAYOR") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Detective)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-DETECTIVE") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-DETECTIVE") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Nightwatch)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-NIGHTWATCH") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-NIGHTWATCH") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Spy)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SPY") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SPY") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Informant)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-INFORMANT") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-INFORMANT") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Bait)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-BAIT") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-BAIT") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Mentalist)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-MENTALIST") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-MENTALIST") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Builder)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-BUILDER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-BUILDER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Dictator)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-DICTATOR") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-DICTATOR") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Sentinel)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-SENTINEL") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-SENTINEL") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Teammate)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-TEAMMATE") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-TEAMMATE") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Lawkeeper)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-LAWKEEPER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-LAWKEEPER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Fake)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-FAKE") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-FAKE") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Leader)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-LEADER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-LEADER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Angel)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-ANGEL") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-ANGEL") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Traveler)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-TRAVELER") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-TRAVELER") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.__Doctor)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-DOCTOR") { H.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-DOCTOR") { V.Free = true; } }
            }







            if (ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Eater)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-EAT") { P.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-EAT") { V.Free = true; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-EAT") { H.Free = true; } }
            }
            else
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-EAT") { P.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-EAT") { V.Free = false; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-EAT") { H.Free = false; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Cupid)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-CUP") { P.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-CUP") { V.Free = true; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-CUP") { H.Free = true; } }
            }
            else
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-CUP") { P.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-CUP") { V.Free = false; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-CUP") { H.Free = false; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Cultist)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-CLT") { P.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-CLT") { V.Free = true; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-CLT") { H.Free = true; } }
            }
            else
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "SH-CLT") { P.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "SH-CLT") { V.Free = false; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-CLT") { H.Free = false; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Prime)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "PRIME") { P.Free = true; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "PRIME") { V.Free = true; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "PRIME") { H.Free = true; } }
            }
            else
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates) { if (P.BundleId == "PRIME") { P.Free = false; } }
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "PRIME") { V.Free = false; } }
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "PRIME") { H.Free = false; } }

            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Shops.Bundle_Lily)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "SH-LILY") { H.Free = true; } }
            }

            if (Challenger.LangGameSet == 2f || (Set.Data.Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "FRA") { H.Free = true; } }
            }
            else
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "FRA") { H.Free = false; } }
            }



            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 0)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }




            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 1)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = true; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 2)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = true; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 3)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = true; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 4)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = true; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 5)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = true; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 6)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = true; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 7)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = true; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 8)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = true; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 9)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = true; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 10)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = true; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 11)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = true; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 12)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = true; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 13)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = true; }
                    if (P.BundleId == "R-S1R14") { P.Free = false; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 14)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = false; }
                    if (P.BundleId == "R-S1R2") { P.Free = false; }
                    if (P.BundleId == "R-S1R3") { P.Free = false; }
                    if (P.BundleId == "R-S1R4") { P.Free = false; }
                    if (P.BundleId == "R-S1R5") { P.Free = false; }
                    if (P.BundleId == "R-S1R6") { P.Free = false; }
                    if (P.BundleId == "R-S1R7") { P.Free = false; }
                    if (P.BundleId == "R-S1R8") { P.Free = false; }
                    if (P.BundleId == "R-S1R9") { P.Free = false; }
                    if (P.BundleId == "R-S1R10") { P.Free = false; }
                    if (P.BundleId == "R-S1R11") { P.Free = false; }
                    if (P.BundleId == "R-S1R12") { P.Free = false; }
                    if (P.BundleId == "R-S1R13") { P.Free = false; }
                    if (P.BundleId == "R-S1R14") { P.Free = true; }
                }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Ranked.IntRank == 15)
            {
                foreach (NamePlateData P in HatManager.Instance.allNamePlates)
                {
                    if (P.BundleId == "R-S1R1") { P.Free = true; }
                    if (P.BundleId == "R-S1R2") { P.Free = true; }
                    if (P.BundleId == "R-S1R3") { P.Free = true; }
                    if (P.BundleId == "R-S1R4") { P.Free = true; }
                    if (P.BundleId == "R-S1R5") { P.Free = true; }
                    if (P.BundleId == "R-S1R6") { P.Free = true; }
                    if (P.BundleId == "R-S1R7") { P.Free = true; }
                    if (P.BundleId == "R-S1R8") { P.Free = true; }
                    if (P.BundleId == "R-S1R9") { P.Free = true; }
                    if (P.BundleId == "R-S1R10") { P.Free = true; }
                    if (P.BundleId == "R-S1R11") { P.Free = true; }
                    if (P.BundleId == "R-S1R12") { P.Free = true; }
                    if (P.BundleId == "R-S1R13") { P.Free = true; }
                    if (P.BundleId == "R-S1R14") { P.Free = true; }
                }
            }
        }
    }
}