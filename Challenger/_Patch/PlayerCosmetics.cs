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

            if (GLMod.GLMod.isUnlocked("AC-H1")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Demon = true; }
            if (GLMod.GLMod.isUnlocked("AC-H2")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Angel = true; }
            if (GLMod.GLMod.isUnlocked("AC-H3")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Vampire = true; }
            if (GLMod.GLMod.isUnlocked("AC-H4")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Kawaii = true; }
            if (GLMod.GLMod.isUnlocked("AC-H5")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Angry = true; }
            if (GLMod.GLMod.isUnlocked("AC-H6")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Cat = true; }
            if (GLMod.GLMod.isUnlocked("AC-H7")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Knight = true; }
            if (GLMod.GLMod.isUnlocked("AC-H8")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Crazy = true; }
            if (GLMod.GLMod.isUnlocked("AC-H9")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_FireFighter = true; }
            if (GLMod.GLMod.isUnlocked("AC-H10")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Ninja = true; }
            if (GLMod.GLMod.isUnlocked("AC-H11")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Alien = true; }
            if (GLMod.GLMod.isUnlocked("AC-H12")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Barghest = true; }
            if (GLMod.GLMod.isUnlocked("AC-H13")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Bomber = true; }
            if (GLMod.GLMod.isUnlocked("AC-H14")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Dragon = true; }

            if (GLMod.GLMod.isUnlocked("AC-V1")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Gun = true; }
            if (GLMod.GLMod.isUnlocked("AC-V2")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Knifte = true; }
            if (GLMod.GLMod.isUnlocked("AC-V3")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Katana = true; }
            if (GLMod.GLMod.isUnlocked("AC-V4")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Orbe = true; }
            if (GLMod.GLMod.isUnlocked("AC-V5")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Cube = true; }
            if (GLMod.GLMod.isUnlocked("AC-V6")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_VampireTooth = true; }
            if (GLMod.GLMod.isUnlocked("AC-V7")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Axe = true; }
            if (GLMod.GLMod.isUnlocked("AC-V8")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_DNA = true; }
            if (GLMod.GLMod.isUnlocked("AC-V9")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Chain = true; }
            if (GLMod.GLMod.isUnlocked("AC-V10")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_MagicWand = true; }
            if (GLMod.GLMod.isUnlocked("AC-V11")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_FireBall = true; }

            if (GLMod.GLMod.isUnlocked("AC-C1")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Bloody = true; }
            if (GLMod.GLMod.isUnlocked("AC-C2")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Earth = true; }
            if (GLMod.GLMod.isUnlocked("AC-C3")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Chedard = true; }
            if (GLMod.GLMod.isUnlocked("AC-C4")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Sun = true; }
            if (GLMod.GLMod.isUnlocked("AC-C5")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Leef = true; }
            if (GLMod.GLMod.isUnlocked("AC-C6")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Radian = true; }
            if (GLMod.GLMod.isUnlocked("AC-C7")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Swamp = true; }
            if (GLMod.GLMod.isUnlocked("AC-C8")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ice = true; }
            if (GLMod.GLMod.isUnlocked("AC-C9")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Lagoon = true; }
            if (GLMod.GLMod.isUnlocked("AC-C10")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Ocean = true; }
            if (GLMod.GLMod.isUnlocked("AC-C11")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Night = true; }
            if (GLMod.GLMod.isUnlocked("AC-C12")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dawn = true; }
            if (GLMod.GLMod.isUnlocked("AC-C13")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Candy = true; }
            if (GLMod.GLMod.isUnlocked("AC-C14")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Galaxy = true; }
            if (GLMod.GLMod.isUnlocked("AC-C15")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Snow = true; }
            if (GLMod.GLMod.isUnlocked("AC-C16")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Cender = true; }
            if (GLMod.GLMod.isUnlocked("AC-C17")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Dark = true; }
            if (GLMod.GLMod.isUnlocked("AC-C18")) { ChallengerMod.Cosmetiques.Cosmetics_Achievement.Color_Rainbow = true; }

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
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Demon)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H1") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Angel)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H2") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Vampire)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H3") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Kawaii)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H4") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Angry)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H5") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Cat)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H6") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Knight)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H7") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Crazy)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H8") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_FireFighter)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H9") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Ninja)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H10") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Alien)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H11") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Barghest)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H12") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Bomber)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H13") { H.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Hat_Dragon)
            {
                foreach (HatData H in HatManager.Instance.allHats) { if (H.BundleId == "AC-H14") { H.Free = true; } }
            }

            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Gun)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V1") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Knifte)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V2") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Katana)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V3") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Orbe)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V4") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Cube)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V5") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_VampireTooth)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V6") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Axe)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V7") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_DNA)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V8") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_Chain)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V9") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_MagicWand)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V10") { V.Free = true; } }
            }
            if (ChallengerMod.Cosmetiques.Cosmetics_Achievement.Visor_FireBall)
            {
                foreach (VisorData V in HatManager.Instance.allVisors) { if (V.BundleId == "AC-V11") { V.Free = true; } }
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