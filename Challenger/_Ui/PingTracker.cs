
using HarmonyLib;
using static ChallengerMod.HarmonyMain;
using static ChallengerOS.Utils.Option.CustomOptionHolder;
using static ChallengerMod.Set.Data;


//using ChallengerMod.Arrow;

namespace ChallengerMod
{

    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingPatch
    {
        public static void Postfix(PingTracker __instance)
        {

            //__instance.text.text += "\nPS-" + Cursed.CursePlayer + "\nRS-" + Cursed.CurseSpeed + "\nV-" + Cursed.CurseValue;

            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                if (Challenger.IsrankedGame == true)
                {
                        __instance.text.text += "\n\n<color=#DE6C13><size=3.6>Challenger</size></color><color=#0089EE> <size=1.8>(" + PrefixString + VersionString + SufixString + ")</size></color>\n<size=2.4>Par <color=#FF2DE9>Lunastellia</size></color><size=1>\n\n</size><size=2><color=#FF00FF>★ Partie Classé</color><color=#252525> </color>" + RT_ACTIF + "\n\n</size>";
                    
                }
                else
                {
                    __instance.text.text += "\n\n<color=#DE6C13><size=3.6>Challenger</size></color><color=#0089EE> <size=1.8>(" + PrefixString + VersionString + SufixString + ")</size></color>\n<size=2.4>Par <color=#FF2DE9>Lunastellia</size></color><size=1>\n\n</size><size=2><color=#FFFF00>★ Partie Normal</color><color=#252525> </color>" + RT_ACTIF + "\n\n</size>";
                    
                }

                



                __instance.text.text += "<size=1>\n\n\n</size>";
                if (((QTCrew.getFloat() != 0) &&
                    ((SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (GuardianSpawnChance.getFloat() > 0 && GuardianAdd.getBool() == true)
                    || (engineerSpawnChance.getFloat() > 0 && engineerAdd.getBool() == true)
                    || (HunterSpawnChance.getFloat() > 0 && HunterAdd.getBool() == true)
                    || (TimeLordSpawnChance.getFloat() > 0 && TimeLordAdd.getBool() == true)
                    || (MysticSpawnChance.getFloat() > 0 && MysticAdd.getBool() == true)
                    || (SpiritSpawnChance.getFloat() > 0 && SpiritAdd.getBool() == true)
                    || (MayorSpawnChance.getFloat() > 0 && MayorAdd.getBool() == true)
                    || (DetectiveSpawnChance.getFloat() > 0 && DetectiveAdd.getBool() == true)
                    || (NightwatcherSpawnChance.getFloat() > 0 && NightwatcherAdd.getBool() == true)
                    || (SpySpawnChance.getFloat() > 0 && SpyAdd.getBool() == true)
                    || (InforSpawnChance.getFloat() > 0 && InforAdd.getBool() == true)
                    || (BaitSpawnChance.getFloat() > 0 && BaitAdd.getBool() == true)
                    || (MentalistSpawnChance.getFloat() > 0 && MentalistAdd.getBool() == true)
                    || (BuilderSpawnChance.getFloat() > 0 && BuilderAdd.getBool() == true)
                    || (DictatorSpawnChance.getFloat() > 0 && DictatorAdd.getBool() == true)
                    || (SentinelSpawnChance.getFloat() > 0 && SentinelAdd.getBool() == true)
                    || (LawkeeperSpawnChance.getFloat() > 0 && LawkeeperAdd.getBool() == true)
                    || (MateSpawnChance.getFloat() > 0 && MateAdd.getBool() == true)
                    || (FakeSpawnChance.getFloat() > 0 && FakeAdd.getBool() == true)
                    || (LeaderSpawnChance.getFloat() > 0 && LeaderAdd.getBool() == true)
                    )))
                {
                    __instance.text.text += "<size=1><color=#189FEC>\n\n                                                                                                                                                                                                       </size><size=1.5>[" + (0 + QTCrew.getFloat()) + "] Crewmate</color></size>";
                    if (SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Shérif " + SherifSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Shérif " + Sherif2SpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Shérif " + Sherif3SpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GuardianSpawnChance.getFloat() > 0 && GuardianAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#00FFFF>(Gardien " + GuardianSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (engineerSpawnChance.getFloat() > 0 && engineerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFA100>(Ingénieur " + engineerSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (TimeLordSpawnChance.getFloat() > 0 && TimeLordAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#007FFF>(Temporel " + TimeLordSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (HunterSpawnChance.getFloat() > 0 && HunterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#00FF00>(Chasseur " + HunterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MysticSpawnChance.getFloat() > 0 && MysticAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#F9FFB2>(Mystique " + MysticSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SpiritSpawnChance.getFloat() > 0 && SpiritAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#A1FF00>(Esprit " + SpiritSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MayorSpawnChance.getFloat() > 0 && MayorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#AF8269>(Maire " + MayorSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (DetectiveSpawnChance.getFloat() > 0 && DetectiveAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#BCFFBA>(Detective " + DetectiveSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (NightwatcherSpawnChance.getFloat() > 0 && NightwatcherAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#9EB3FF>(Veilleur " + NightwatcherSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SpySpawnChance.getFloat() > 0 && SpyAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#9EE1FF>(Espion " + SpySpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (InforSpawnChance.getFloat() > 0 && InforAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#ADFFEA>(Voyante " + InforSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BaitSpawnChance.getFloat() > 0 && BaitAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#808080>(Appat " + BaitSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MentalistSpawnChance.getFloat() > 0 && MentalistAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#A991FF>(Mentaliste " + MentalistSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BuilderSpawnChance.getFloat() > 0 && BuilderAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFC291>(Constructeur " + BuilderSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (DictatorSpawnChance.getFloat() > 0 && DictatorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF7A7A>(Dictateur " + DictatorSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SentinelSpawnChance.getFloat() > 0 && SentinelAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#06AD17>(Sentinelle " + SentinelSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MateSpawnChance.getFloat() > 0 && MateAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#B4FAFA>(Partenaires " + MateSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (LawkeeperSpawnChance.getFloat() > 0 && LawkeeperAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF9b9b>(Justicier " + LawkeeperSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (FakeSpawnChance.getFloat() > 0 && FakeAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF4D35>(Intru " + FakeSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (LeaderSpawnChance.getFloat() > 0 && LeaderAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#5A7DA5>(Chef " + LeaderSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTSpe.getFloat() != 0) &&
                ((JesterSpawnChance.getFloat() > 0 && JesterAdd.getBool() == true)
                || (EaterSpawnChance.getFloat() > 0 && EaterAdd.getBool() == true)
                || (CursedSpawnChance.getFloat() > 0 && CursedAdd.getBool() == true)
                || (CupidSpawnChance.getFloat() > 0 && CupidAdd.getBool() == true)
                || (CultisteSpawnChance.getFloat() > 0 && CultisteAdd.getBool() == true)
                || (ArsonistSpawnChance.getFloat() > 0 && ArsonistAdd.getBool() == true)
                || (OutlawSpawnChance.getFloat() > 0 && OutlawAdd.getBool() == true)

                )))
                {
                    __instance.text.text += "<size=1><color=#B218EC>\n\n                                                                                                                                                                                                      </size><size=1.5> [" + (0 + QTSpe.getFloat()) + "] Special</color></size>";
                    if (JesterSpawnChance.getFloat() > 0 && JesterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                               "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF0A88>(Bouffon " + JesterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CupidSpawnChance.getFloat() > 0 && CupidAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFAFFF>(Cupidon " + CupidSpawnChance.getFloat() + "%)</color></size>";
                    }


                    if (EaterSpawnChance.getFloat() > 0 && EaterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                               "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF6E00>(Devoreur " + EaterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CultisteSpawnChance.getFloat() > 0 && CultisteAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#8300FF>(Cultiste " + CultisteSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (OutlawSpawnChance.getFloat() > 0 && OutlawAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#0033FF>(Criminel " + OutlawSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (ArsonistSpawnChance.getFloat() > 0 && ArsonistAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFC800>(Pyroman " + ArsonistSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CursedSpawnChance.getFloat() > 0 && CursedAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#3F683B>(Maudit " + CursedSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTDuo.getFloat() != 0) &&
               ((MercenarySpawnChance.getFloat() > 0 && MercenaryAdd.getBool() == true)
                || (CopyCatSpawnChance.getFloat() > 0 && CopyCatAdd.getBool() == true)
                || (SorcererSpawnChance.getFloat() > 0 && SorcererAdd.getBool() == true)
                || (RevengerSpawnChance.getFloat() > 0 && RevengerAdd.getBool() == true)
                )))
                {
                    __instance.text.text += "<size=1><color=#B270E8>\n\n                                                                                                                                                                                                      </size><size=1.5> [" + (0 + QTDuo.getFloat()) + "] Hybrid</color></size>";
                    if (MercenarySpawnChance.getFloat() > 0 && MercenaryAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF49E6>(Mercenaire " + MercenarySpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CopyCatSpawnChance.getFloat() > 0 && CopyCatAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#64E6B4>(Immitateur " + CopyCatSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SorcererSpawnChance.getFloat() > 0 && SorcererAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#7F5E4C>(Survivant " + SorcererSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (RevengerSpawnChance.getFloat() > 0 && RevengerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#D9C27E>(Vengeur " + RevengerSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTImp.getFloat() != 0) &&
                ((AssassinSpawnChance.getFloat() > 0 && AssassinAdd.getBool() == true)
                || (VectorSpawnChance.getFloat() > 0 && VectorAdd.getBool() == true)
                || (MorphlingSpawnChance.getFloat() > 0 && MorphlingAdd.getBool() == true)
                || (CamoSpawnChance.getFloat() > 0 && CamoAdd.getBool() == true)
                || (BarghestSpawnChance.getFloat() > 0 && BarghestAdd.getBool() == true)
                || (WarSpawnChance.getFloat() > 0 && WarAdd.getBool() == true)
                || (GuesserSpawnChance.getFloat() > 0 && GuesserAdd.getBool() == true)
                || (GhostSpawnChance.getFloat() > 0 && GhostAdd.getBool() == true)
                || (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)
                //|| (MesmerSpawnChance.getFloat() > 0 && MesmerAdd.getBool() == true)
                )))
                {
                    __instance.text.text += "<size=1><color=#FF0000>\n\n                                                                                                                                                                                                       </size><size=1.5>[" + (0 + QTImp.getFloat()) + "] Impostor</color></size>";
                    if (AssassinSpawnChance.getFloat() > 0 && AssassinAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#005106>(Assassin " + AssassinSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (VectorSpawnChance.getFloat() > 0 && VectorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#8C1919>(Vecteur " + VectorSpawnChance.getFloat() + "%)</color></size>";
                    }

                    if (MorphlingSpawnChance.getFloat() > 0 && MorphlingAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#430054>(Metamorphe " + MorphlingSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CamoSpawnChance.getFloat() > 0 && CamoAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#544700>(Brouilleur " + CamoSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BarghestSpawnChance.getFloat() > 0 && BarghestAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#000569>(Barghest " + BarghestSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GhostSpawnChance.getFloat() > 0 && GhostAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#404040>(Fantom " + GhostSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (WarSpawnChance.getFloat() > 0 && WarAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#542B00>(Sorcier " + WarSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GuesserSpawnChance.getFloat() > 0 && GuesserAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#003954>(Devin " + GuesserSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#5B466B>(Basilik " + BasiliskSpawnChance.getFloat() + "%)</color></size>";
                    }
                    /*if (MesmerSpawnChance.getFloat() > 0 && MesmerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#680037>(Envouteur " + MesmerSpawnChance.getFloat() + "%)</color></size>";
                    }*/
                }

            }
            else
            {
                if (Challenger.IsrankedGame == true)
                {
                    __instance.text.text += "\n\n<color=#DE6C13><size=3.6>Challenger</size></color><color=#0089EE> <size=1.8>(" + PrefixString + VersionString + SufixString + ")</size></color>\n<size=2.4>By <color=#FF2DE9>Lunastellia</size></color><size=1>\n\n</size><size=2><color=#FF00FF>★ Game Ranked</color><color=#252525> </color>" + RT_ACTIF + "\n\n</size>";
                    
                }
                else
                {
                    __instance.text.text += "\n\n<color=#DE6C13><size=3.6>Challenger</size></color><color=#0089EE> <size=1.8>(" + PrefixString + VersionString + SufixString + ")</size></color>\n<size=2.4>By <color=#FF2DE9>Lunastellia</size></color><size=1>\n\n</size><size=2><color=#FFFF00>★ Normal Game</color><color=#252525> </color>" + RT_ACTIF + "\n\n</size>";
                   
                }
                

                __instance.text.text += "<size=1>\n\n\n</size>";
                if (((QTCrew.getFloat() != 0) &&
                    ((SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    || (GuardianSpawnChance.getFloat() > 0 && GuardianAdd.getBool() == true)
                    || (engineerSpawnChance.getFloat() > 0 && engineerAdd.getBool() == true)
                    || (HunterSpawnChance.getFloat() > 0 && HunterAdd.getBool() == true)
                    || (TimeLordSpawnChance.getFloat() > 0 && TimeLordAdd.getBool() == true)
                    || (MysticSpawnChance.getFloat() > 0 && MysticAdd.getBool() == true)
                    || (SpiritSpawnChance.getFloat() > 0 && SpiritAdd.getBool() == true)
                    || (MayorSpawnChance.getFloat() > 0 && MayorAdd.getBool() == true)
                    || (DetectiveSpawnChance.getFloat() > 0 && DetectiveAdd.getBool() == true)
                    || (NightwatcherSpawnChance.getFloat() > 0 && NightwatcherAdd.getBool() == true)
                    || (SpySpawnChance.getFloat() > 0 && SpyAdd.getBool() == true)
                    || (InforSpawnChance.getFloat() > 0 && InforAdd.getBool() == true)
                    || (BaitSpawnChance.getFloat() > 0 && BaitAdd.getBool() == true)
                    || (MentalistSpawnChance.getFloat() > 0 && MentalistAdd.getBool() == true)
                    || (BuilderSpawnChance.getFloat() > 0 && BuilderAdd.getBool() == true)
                    || (DictatorSpawnChance.getFloat() > 0 && DictatorAdd.getBool() == true)
                    || (SentinelSpawnChance.getFloat() > 0 && SentinelAdd.getBool() == true)
                    || (LawkeeperSpawnChance.getFloat() > 0 && LawkeeperAdd.getBool() == true)
                    || (MateSpawnChance.getFloat() > 0 && MateAdd.getBool() == true)
                    || (FakeSpawnChance.getFloat() > 0 && FakeAdd.getBool() == true)
                    || (LeaderSpawnChance.getFloat() > 0 && LeaderAdd.getBool() == true)
                    )))
                {
                    __instance.text.text += "<size=1><color=#189FEC>\n\n                                                                                                                                                                                                       </size><size=1.5>[" + (0 + QTCrew.getFloat()) + "] Crewmate</color></size>";
                    if (SherifSpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Sheriff " + SherifSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (Sherif2SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Sheriff " + Sherif2SpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (Sherif3SpawnChance.getFloat() > 0 && SherifAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFFF00>(Sheriff " + Sherif3SpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GuardianSpawnChance.getFloat() > 0 && GuardianAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#00FFFF>(Guardian " + GuardianSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (engineerSpawnChance.getFloat() > 0 && engineerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFA100>(Engineer " + engineerSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (TimeLordSpawnChance.getFloat() > 0 && TimeLordAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#007FFF>(Timelord " + TimeLordSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (HunterSpawnChance.getFloat() > 0 && HunterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#00FF00>(Hunter " + HunterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MysticSpawnChance.getFloat() > 0 && MysticAdd.getBool() == true)
                    {
                        __instance.text.text +=
                            "<size=1>\n                                                                                                                                                                                                       " + "<color=#F9FFB2>(Mystic " + MysticSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SpiritSpawnChance.getFloat() > 0 && SpiritAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#A1FF00>(Spirit " + SpiritSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MayorSpawnChance.getFloat() > 0 && MayorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#AF8269>(Mayor " + MayorSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (DetectiveSpawnChance.getFloat() > 0 && DetectiveAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#BCFFBA>(Detective " + DetectiveSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (NightwatcherSpawnChance.getFloat() > 0 && NightwatcherAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#9EB3FF>(Nightwatch " + NightwatcherSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SpySpawnChance.getFloat() > 0 && SpyAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#9EE1FF>(Spy " + SpySpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (InforSpawnChance.getFloat() > 0 && InforAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#ADFFEA>(Informant " + InforSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BaitSpawnChance.getFloat() > 0 && BaitAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#808080>(Bait " + BaitSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MentalistSpawnChance.getFloat() > 0 && MentalistAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#A991FF>(Mentalist " + MentalistSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BuilderSpawnChance.getFloat() > 0 && BuilderAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFC291>(Builder " + BuilderSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (DictatorSpawnChance.getFloat() > 0 && DictatorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF7A7A>(Dictator " + DictatorSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SentinelSpawnChance.getFloat() > 0 && SentinelAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#06AD17>(Sentinel " + SentinelSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (MateSpawnChance.getFloat() > 0 && MateAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#B4FAFA>(Teammate " + MateSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (LawkeeperSpawnChance.getFloat() > 0 && LawkeeperAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF9b9b>(Lawkeeper " + LawkeeperSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (FakeSpawnChance.getFloat() > 0 && FakeAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF4D35>(Fake " + FakeSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (LeaderSpawnChance.getFloat() > 0 && LeaderAdd.getBool() == true)
                    {
                        __instance.text.text +=
                             "<size=1>\n                                                                                                                                                                                                       " + "<color=#5A7DA5>(Leader " + LeaderSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTSpe.getFloat() != 0) &&
                ((JesterSpawnChance.getFloat() > 0 && JesterAdd.getBool() == true)
                || (EaterSpawnChance.getFloat() > 0 && EaterAdd.getBool() == true)
                || (CursedSpawnChance.getFloat() > 0 && CursedAdd.getBool() == true)
                || (CupidSpawnChance.getFloat() > 0 && CupidAdd.getBool() == true)
                || (CultisteSpawnChance.getFloat() > 0 && CultisteAdd.getBool() == true)
                || (ArsonistSpawnChance.getFloat() > 0 && ArsonistAdd.getBool() == true)
                || (OutlawSpawnChance.getFloat() > 0 && OutlawAdd.getBool() == true)

                )))
                {
                    __instance.text.text += "<size=1><color=#B218EC>\n\n                                                                                                                                                                                                      </size><size=1.5> [" + (0 + QTSpe.getFloat()) + "] Special</color></size>";
                    if (JesterSpawnChance.getFloat() > 0 && JesterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                               "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF0A88>(Jester " + JesterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CupidSpawnChance.getFloat() > 0 && CupidAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFAFFF>(Cupid " + CupidSpawnChance.getFloat() + "%)</color></size>";
                    }


                    if (EaterSpawnChance.getFloat() > 0 && EaterAdd.getBool() == true)
                    {
                        __instance.text.text +=
                               "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF6E00>(Eater " + EaterSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CultisteSpawnChance.getFloat() > 0 && CultisteAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#8300FF>(Cultist " + CultisteSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (OutlawSpawnChance.getFloat() > 0 && OutlawAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#0033FF>(Outlaw " + OutlawSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (ArsonistSpawnChance.getFloat() > 0 && ArsonistAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FFC800>(Arsonist " + ArsonistSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CursedSpawnChance.getFloat() > 0 && CursedAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#3F683B>(Cursed " + CursedSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTDuo.getFloat() != 0) &&
               ((MercenarySpawnChance.getFloat() > 0 && MercenaryAdd.getBool() == true)
                || (CopyCatSpawnChance.getFloat() > 0 && CopyCatAdd.getBool() == true)
                || (SorcererSpawnChance.getFloat() > 0 && SorcererAdd.getBool() == true)
                || (RevengerSpawnChance.getFloat() > 0 && RevengerAdd.getBool() == true)
                )))
                {
                    __instance.text.text += "<size=1><color=#B270E8>\n\n                                                                                                                                                                                                      </size><size=1.5> [" + (0 + QTDuo.getFloat()) + "] Hybrid</color></size>";
                    if (MercenarySpawnChance.getFloat() > 0 && MercenaryAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#FF49E6>(Mercenary " + MercenarySpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CopyCatSpawnChance.getFloat() > 0 && CopyCatAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#64E6B4>(CopyCat " + CopyCatSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (SorcererSpawnChance.getFloat() > 0 && SorcererAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#7F5E4C>(Survivor " + SorcererSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (RevengerSpawnChance.getFloat() > 0 && RevengerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#D9C27E>(Revenger " + RevengerSpawnChance.getFloat() + "%)</color></size>";
                    }
                }
                if (((QTImp.getFloat() != 0) &&
                ((AssassinSpawnChance.getFloat() > 0 && AssassinAdd.getBool() == true)
                || (VectorSpawnChance.getFloat() > 0 && VectorAdd.getBool() == true)
                || (MorphlingSpawnChance.getFloat() > 0 && MorphlingAdd.getBool() == true)
                || (CamoSpawnChance.getFloat() > 0 && CamoAdd.getBool() == true)
                || (BarghestSpawnChance.getFloat() > 0 && BarghestAdd.getBool() == true)
                || (WarSpawnChance.getFloat() > 0 && WarAdd.getBool() == true)
                || (GuesserSpawnChance.getFloat() > 0 && GuesserAdd.getBool() == true)
                || (GhostSpawnChance.getFloat() > 0 && GhostAdd.getBool() == true)
                || (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)
                //|| (MesmerSpawnChance.getFloat() > 0 && MesmerAdd.getBool() == true)

                )))
                {
                    __instance.text.text += "<size=1><color=#FF0000>\n\n                                                                                                                                                                                                       </size><size=1.5>[" + (0 + QTImp.getFloat()) + "] Impostor</color></size>";
                    if (AssassinSpawnChance.getFloat() > 0 && AssassinAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#005106>(Assassin " + AssassinSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (VectorSpawnChance.getFloat() > 0 && VectorAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#8C1919>(Vector " + VectorSpawnChance.getFloat() + "%)</color></size>";
                    }

                    if (MorphlingSpawnChance.getFloat() > 0 && MorphlingAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#430054>(Morphling " + MorphlingSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (CamoSpawnChance.getFloat() > 0 && CamoAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#544700>(Scrambler " + CamoSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BarghestSpawnChance.getFloat() > 0 && BarghestAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#000569>(Barghest " + BarghestSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GhostSpawnChance.getFloat() > 0 && GhostAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#404040>(Ghost " + GhostSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (WarSpawnChance.getFloat() > 0 && WarAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#542B00>(Sorcerer " + WarSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (GuesserSpawnChance.getFloat() > 0 && GuesserAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#003954>(Guesser " + GuesserSpawnChance.getFloat() + "%)</color></size>";
                    }
                    if (BasiliskSpawnChance.getFloat() > 0 && BasiliskAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#5B466B>(Basilisk " + BasiliskSpawnChance.getFloat() + "%)</color></size>";
                    }
                    /*if (MesmerSpawnChance.getFloat() > 0 && MesmerAdd.getBool() == true)
                    {
                        __instance.text.text +=
                              "<size=1>\n                                                                                                                                                                                                       " + "<color=#680037>(Mesmer " + MesmerSpawnChance.getFloat() + "%)</color></size>";
                    }*/
                }
            }




            



            




           

            

        }
    }
}