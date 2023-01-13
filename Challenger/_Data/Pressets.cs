using HarmonyLib;
using static ChallengerOS.Utils.Option.CustomOptionHolder;

namespace ChallengerMod.Pressets
{
    internal class Start
    {
        [HarmonyPatch(typeof(GameStartManager))]
        public static class GameStartManagerPatch
        {
            [HarmonyPatch(nameof(GameStartManager.Start))]
            [HarmonyPrefix]
            public static void StartPatch(ref GameStartManager __instance)
            {


               

                if (AmongUsClient.Instance.AmHost)
                {
                    if (Challenger.IsrankedGame == true) 
                    {
                        Ranked.updateSelection(1);
                        Challenger.isRankedGame = true;
                    }
                    if (Challenger.IsrankedGame == false) 
                    {
                        Ranked.updateSelection(0);
                        Challenger.isRankedGame = false;
                    }


                        if (Challenger.IsrankedGameSet == 0)
                        {
                            RankedInt.updateSelection(0);
                        }
                        if (Challenger.IsrankedGameSet == 1)
                        {
                            RankedInt.updateSelection(1);
                        }
                        if (Challenger.IsrankedGameSet == 2)
                        {
                            RankedInt.updateSelection(2);
                        }
                        if (Challenger.IsrankedGameSet == 3)
                        {
                            RankedInt.updateSelection(3);
                        }
                        if (Challenger.IsrankedGameSet == 4)
                        {
                            RankedInt.updateSelection(4);
                        }
                        if (Challenger.IsrankedGameSet == 5)
                        {
                            RankedInt.updateSelection(5);
                        }
                        if (Challenger.IsrankedGameSet == 6)
                        {
                            RankedInt.updateSelection(6);
                        }
                        if (Challenger.IsrankedGameSet == 7)
                        {
                            RankedInt.updateSelection(7);
                        }
                        if (Challenger.IsrankedGameSet == 8)
                        {
                            RankedInt.updateSelection(8);
                        }
                    if (Challenger.IsrankedGameSet == 100)
                    {
                        RankedInt.updateSelection(100);
                        PlayerControl.GameOptions.MaxPlayers = 15;
                    }
                    

                    if (Challenger.IsrankedGameSet == 0) // Vanilla
                    {
                        RankedInt.updateSelection(0);
                        PlayerControl.GameOptions.MaxPlayers = 10;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 1;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(8);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(0);
                        QTDuo.updateSelection(0);

                        SherifAdd.updateSelection(0);
                        GuardianAdd.updateSelection(0);
                        engineerAdd.updateSelection(0);
                        TimeLordAdd.updateSelection(0);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(0);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(0);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(0);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(0);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(0);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(0);
                        VitalTimeOn.updateSelection(0);
                        CamTimeOn.updateSelection(0);

                        AdminTime.updateSelection(0);
                        VitalTime.updateSelection(0);
                        CamTime.updateSelection(0);

                    }
                    if (Challenger.IsrankedGameSet == 1) // Lite
                    {
                        RankedInt.updateSelection(1);
                        PlayerControl.GameOptions.MaxPlayers = 10;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 1;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(5);
                        QTImp.updateSelection(1);
                        QTSpe.updateSelection(0);
                        QTDuo.updateSelection(0);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(1);
                        engineerAdd.updateSelection(1);
                        TimeLordAdd.updateSelection(0);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(0);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(1);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(1);
                        SpyAdd.updateSelection(0);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(1);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(0);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(0);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(2);
                        VitalTimeOn.updateSelection(2);
                        CamTimeOn.updateSelection(2);

                        AdminTime.updateSelection(21);
                        VitalTime.updateSelection(11);
                        CamTime.updateSelection(21);


                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(0);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(0);

                        GuardianSpawnChance.updateSelection(20);
                        ShieldSettings.updateSelection(0);
                        GuardianShieldVisibility.updateSelection(0);
                        GuardianShieldVisibilitytry.updateSelection(2);
                        GuardianShieldSound.updateSelection(1);


                        engineerSpawnChance.updateSelection(20);
                        EngineerCanVent.updateSelection(1);
                        EngineerRepairCD.updateSelection(2);
                        RepairSettings.updateSelection(0);

                        MayorSpawnChance.updateSelection(20);
                        BonusBuzz.updateSelection(0);
                        BuzzCooldown.updateSelection(0);

                        NightwatcherSpawnChance.updateSelection(20);
                        NightwatcherSetCooldown.updateSelection(8);
                        NightwatcherSetDuration.updateSelection(11);

                        CamoSpawnChance.updateSelection(20);
                        CamoSetCooldown.updateSelection(10);
                        CamoSetDuration.updateSelection(9);
                        CamoCanVent.updateSelection(1);

                    }
                    if (Challenger.IsrankedGameSet == 2) // Tryhard
                    {
                        RankedInt.updateSelection(2);
                        PlayerControl.GameOptions.MaxPlayers = 15;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 3;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 22.5f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(10);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(2);
                        QTDuo.updateSelection(1);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(1);
                        engineerAdd.updateSelection(1);
                        TimeLordAdd.updateSelection(1);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(1);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(1);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(1);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(1);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(1);

                        AssassinAdd.updateSelection(1);
                        VectorAdd.updateSelection(1);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(1);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(1);
                        JesterAdd.updateSelection(1);
                        EaterAdd.updateSelection(1);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(1);
                        SorcererAdd.updateSelection(1);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(21);
                        VitalTime.updateSelection(11);
                        CamTime.updateSelection(31);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(20);
                        Sherif3SpawnChance.updateSelection(5);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        GuardianSpawnChance.updateSelection(20);
                        ShieldSettings.updateSelection(0);
                        GuardianShieldVisibility.updateSelection(0);
                        GuardianShieldVisibilitytry.updateSelection(2);
                        GuardianShieldSound.updateSelection(1);

                        engineerSpawnChance.updateSelection(20);
                        EngineerCanVent.updateSelection(1);
                        EngineerRepairCD.updateSelection(2);
                        RepairSettings.updateSelection(0);

                        TimeLordSpawnChance.updateSelection(20);
                        TimeLordStopCooldown.updateSelection(12);
                        TimeLordStopDuration.updateSelection(7);

                        MysticSpawnChance.updateSelection(20);
                        MysticSetCooldown.updateSelection(8);
                        MysticSetDuration.updateSelection(9);

                        MayorSpawnChance.updateSelection(20);
                        BonusBuzz.updateSelection(2);
                        BuzzCooldown.updateSelection(4);

                        SpySpawnChance.updateSelection(20);
                        SpyDuration.updateSelection(4);
                        SpyRange.updateSelection(2);

                        MentalistSpawnChance.updateSelection(20);
                        MentalistAbility.updateSelection(0);
                        AdminSetting.updateSelection(1);
                        AdminDuration.updateSelection(9);

                        FakeSpawnChance.updateSelection(20);
                        ImpostorCanKillFake.updateSelection(1);
                        FakeCanVent.updateSelection(0);

                        CopyCatSpawnChance.updateSelection(20);
                        CopyImp.updateSelection(1);
                        CopySpe.updateSelection(1);

                        SorcererSpawnChance.updateSelection(20);
                        SurvivorWinJester.updateSelection(0);
                        SurvivorWinEater.updateSelection(0);
                        SurvivorWinOutlaw.updateSelection(0);
                        SurvivorWinCulte.updateSelection(0);
                        SurvivorWinArsonist.updateSelection(0);

                        OutlawSpawnChance.updateSelection(20);
                        OutlawKillCooldown.updateSelection(6);
                        OutlawKillRange.updateSelection(1);

                        JesterSpawnChance.updateSelection(20);
                        JesterSingle.updateSelection(2);
                        JesterCooldown.updateSelection(12);

                        EaterSpawnChance.updateSelection(20);
                        EaterCooldown.updateSelection(2);
                        Eaterduration.updateSelection(2);
                        Eatvalueforwin.updateSelection(2);
                        EaterCanVent.updateSelection(1);
                        EaterCanDrag.updateSelection(1);
                        BodyRemove.updateSelection(0);

                        AssassinSpawnChance.updateSelection(20);
                        AssassinKillCooldown.updateSelection(6);
                        AssassinCanKillShield.updateSelection(1);
                        BSheriff.updateSelection(1);
                        BGuardian.updateSelection(1);
                        BEngineer.updateSelection(1);
                        BTimelord.updateSelection(1);
                        BMystic.updateSelection(1);
                        BMayor.updateSelection(1);
                        BDetective.updateSelection(0);
                        BNightwatcher.updateSelection(0);
                        BSpy.updateSelection(1);
                        BInfor.updateSelection(0);
                        BMentalist.updateSelection(1);
                        BBuilder.updateSelection(0);
                        BDictator.updateSelection(0);
                        BSentinel.updateSelection(0);
                        BLawkeeper.updateSelection(0);
                        BImpo.updateSelection(1);

                        VectorSpawnChance.updateSelection(20);
                        VectorBuffCooldown.updateSelection(6);
                        VectorKillCooldown.updateSelection(4);
                        VectorBuffVisibility.updateSelection(1);
                        VectorCanVent.updateSelection(1);

                        GuesserSpawnChance.updateSelection(20);
                        Gestry.updateSelection(2);
                        GuessTryOne.updateSelection(1);
                        GuessDie.updateSelection(0);
                        GuessMystic.updateSelection(1);
                        GuessSpirit.updateSelection(0);
                        GuessFake.updateSelection(1);
                        GuessCanVent.updateSelection(1);
                    }
                    if (Challenger.IsrankedGameSet == 3) // Jester
                    {
                        RankedInt.updateSelection(3);
                        PlayerControl.GameOptions.MaxPlayers = 11;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(8);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(1);
                        QTDuo.updateSelection(0);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(1);
                        engineerAdd.updateSelection(1);
                        TimeLordAdd.updateSelection(1);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(0);
                        SpiritAdd.updateSelection(1);
                        MayorAdd.updateSelection(1);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(1);
                        InforAdd.updateSelection(1);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(1);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(1);
                        BasiliskAdd.updateSelection(1);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(1);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        GuardianSpawnChance.updateSelection(20);
                        ShieldSettings.updateSelection(0);
                        GuardianShieldVisibility.updateSelection(0);
                        GuardianShieldVisibilitytry.updateSelection(2);
                        GuardianShieldSound.updateSelection(1);

                        engineerSpawnChance.updateSelection(20);
                        EngineerCanVent.updateSelection(1);
                        EngineerRepairCD.updateSelection(2);
                        RepairSettings.updateSelection(0);

                        TimeLordSpawnChance.updateSelection(20);
                        TimeLordStopCooldown.updateSelection(12);
                        TimeLordStopDuration.updateSelection(7);

                        SpiritSpawnChance.updateSelection(20);
                        SpiritSab.updateSelection(1);

                        MayorSpawnChance.updateSelection(20);
                        BonusBuzz.updateSelection(2);
                        BuzzCooldown.updateSelection(4);

                        InforSpawnChance.updateSelection(20);
                        InforCooldown.updateSelection(4);
                        InforAnalyseMod.updateSelection(0);
                        InforAnalyseMod.updateSelection(1);

                        JesterSpawnChance.updateSelection(20);
                        JesterSingle.updateSelection(0);
                        JesterCooldown.updateSelection(12);

                        MorphlingSpawnChance.updateSelection(20);
                        MorphSetCooldown.updateSelection(8);
                        MorphSetDuration.updateSelection(14);
                        MorphlingCanVent.updateSelection(1);

                        GuesserSpawnChance.updateSelection(20);
                        Gestry.updateSelection(2);
                        GuessTryOne.updateSelection(1);
                        GuessDie.updateSelection(0);
                        GuessMystic.updateSelection(0);
                        GuessSpirit.updateSelection(1);
                        GuessFake.updateSelection(0);
                        GuessCanVent.updateSelection(1);

                        BasiliskSpawnChance.updateSelection(20);
                        BasiliskCooldown.updateSelection(4);
                        BasiliskStart.updateSelection(5);
                        BasiliskMeet.updateSelection(0);
                        BasiliskKill.updateSelection(1);
                        BasiliskVote.updateSelection(0);
                        BasiliskParalizeCost.updateSelection(1);
                        BasiliskPetrifyCost.updateSelection(2);
                        BasiliskSinglePetrify.updateSelection(1);
                        BasiliskCanVent.updateSelection(1);

                       




                    }
                    if (Challenger.IsrankedGameSet == 4) // Eater
                    {

                        RankedInt.updateSelection(4);
                        PlayerControl.GameOptions.MaxPlayers = 11;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(8);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(0);
                        QTDuo.updateSelection(0);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(0);
                        engineerAdd.updateSelection(0);
                        TimeLordAdd.updateSelection(0);
                        HunterAdd.updateSelection(1);
                        MysticAdd.updateSelection(1);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(0);
                        DetectiveAdd.updateSelection(1);
                        NightwatcherAdd.updateSelection(1);
                        SpyAdd.updateSelection(0);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(1);
                        BuilderAdd.updateSelection(1);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(1);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(1);
                        VectorAdd.updateSelection(1);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(1);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(1);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        HunterSpawnChance.updateSelection(20);
                        ResetTrack.updateSelection(1);
                        Followtrack.updateSelection(1);

                        MysticSpawnChance.updateSelection(20);
                        MysticSetCooldown.updateSelection(8);
                        MysticSetDuration.updateSelection(9);

                        DetectiveSpawnChance.updateSelection(20);
                        detectiveFootprintcooldown.updateSelection(8);
                        detectiveFootprintDuration.updateSelection(7);
                        detectiveFootprintDuration2.updateSelection(10);
                        detectiveFootprintanonymous.updateSelection(0);

                        NightwatcherSpawnChance.updateSelection(20);
                        NightwatcherSetCooldown.updateSelection(8);
                        NightwatcherSetDuration.updateSelection(11);

                        MentalistSpawnChance.updateSelection(20);
                        MentalistAbility.updateSelection(0);
                        AdminSetting.updateSelection(1);
                        AdminDuration.updateSelection(9);

                        BuilderSpawnChance.updateSelection(20);
                        BuildRound.updateSelection(1);
                        MaxBuild.updateSelection(2);
                        BuildCooldown.updateSelection(4);

                        LawkeeperSpawnChance.updateSelection(20);
                        LKTimer.updateSelection(1);
                        LKInfo.updateSelection(1);
                        TimeRName.updateSelection(2);
                        TimeRList.updateSelection(12);
                        SuperInfo.updateSelection(1);

                        EaterSpawnChance.updateSelection(20);
                        EaterCooldown.updateSelection(6);
                        Eaterduration.updateSelection(2);
                        Eatvalueforwin.updateSelection(1);
                        EaterCanVent.updateSelection(0);
                        EaterCanDrag.updateSelection(1);
                        BodyRemove.updateSelection(0);

                        AssassinSpawnChance.updateSelection(20);
                        AssassinKillCooldown.updateSelection(6);
                        AssassinCanKillShield.updateSelection(0);
                        BSheriff.updateSelection(1);
                        BGuardian.updateSelection(0);
                        BEngineer.updateSelection(0);
                        BTimelord.updateSelection(0);
                        BMystic.updateSelection(1);
                        BMayor.updateSelection(0);
                        BDetective.updateSelection(1);
                        BNightwatcher.updateSelection(1);
                        BSpy.updateSelection(0);
                        BInfor.updateSelection(0);
                        BMentalist.updateSelection(1);
                        BBuilder.updateSelection(1);
                        BDictator.updateSelection(0);
                        BSentinel.updateSelection(0);
                        BLawkeeper.updateSelection(1);
                        BImpo.updateSelection(0);

                        VectorSpawnChance.updateSelection(20);
                        VectorBuffCooldown.updateSelection(6);
                        VectorKillCooldown.updateSelection(4);
                        VectorBuffVisibility.updateSelection(1);
                        VectorCanVent.updateSelection(0);

                        BasiliskSpawnChance.updateSelection(20);
                        BasiliskCooldown.updateSelection(4);
                        BasiliskStart.updateSelection(5);
                        BasiliskMeet.updateSelection(0);
                        BasiliskKill.updateSelection(1);
                        BasiliskVote.updateSelection(0);
                        BasiliskParalizeCost.updateSelection(1);
                        BasiliskPetrifyCost.updateSelection(2);
                        BasiliskSinglePetrify.updateSelection(1);
                        BasiliskCanVent.updateSelection(1);

                    }
                    if (Challenger.IsrankedGameSet == 5) // Outlaw
                    {

                        RankedInt.updateSelection(5);
                        PlayerControl.GameOptions.MaxPlayers = 12;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(9);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(0);
                        QTDuo.updateSelection(0);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(0);
                        engineerAdd.updateSelection(1);
                        TimeLordAdd.updateSelection(0);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(1);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(1);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(0);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(1);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(1);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(1);
                        MateAdd.updateSelection(1);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(1);
                        BarghestAdd.updateSelection(1);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(1);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        engineerSpawnChance.updateSelection(20);
                        EngineerCanVent.updateSelection(1);
                        EngineerRepairCD.updateSelection(2);
                        RepairSettings.updateSelection(0);

                        MysticSpawnChance.updateSelection(20);
                        MysticSetCooldown.updateSelection(8);
                        MysticSetDuration.updateSelection(9);

                        MayorSpawnChance.updateSelection(20);
                        BonusBuzz.updateSelection(2);
                        BuzzCooldown.updateSelection(4);

                        BaitSpawnChance.updateSelection(20);
                        BaitReporttime.updateSelection(0);
                        BaitReporttimeRnd.updateSelection(2);
                        BaitCanVent.updateSelection(0);

                        DictatorSpawnChance.updateSelection(20);
                        DictatorMeeting.updateSelection(1);
                        DictatorFirstTurn.updateSelection(1);

                        SentinelSpawnChance.updateSelection(20);
                        ScanCooldown.updateSelection(7);
                        ScanDuration.updateSelection(8);
                        ScanAbility.updateSelection(2);

                        MateSpawnChance.updateSelection(20);

                        OutlawSpawnChance.updateSelection(20);
                        OutlawKillCooldown.updateSelection(5);
                        OutlawKillRange.updateSelection(1);

                        CamoSpawnChance.updateSelection(16);
                        CamoSetCooldown.updateSelection(10);
                        CamoSetDuration.updateSelection(9);
                        CamoCanVent.updateSelection(1);

                        BarghestSpawnChance.updateSelection(16);
                        BargestLightCooldown.updateSelection(10);
                        BargestLightDuration.updateSelection(7);
                        BarghestAffectImpostor.updateSelection(0);
                        BarghestCamlight.updateSelection(1);
                        BarghestCanCreateVent.updateSelection(1);
                        BarghestVentCD.updateSelection(6);
                        BarghestCanVent.updateSelection(1);
                        CanUseBarghestVent.updateSelection(0);



                    }
                    if (Challenger.IsrankedGameSet == 6) // Cupid
                    {
                      
                        RankedInt.updateSelection(6);
                        PlayerControl.GameOptions.MaxPlayers = 13;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(8);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(1);
                        QTDuo.updateSelection(2);

                        SherifAdd.updateSelection(0);
                        GuardianAdd.updateSelection(0);
                        engineerAdd.updateSelection(0);
                        TimeLordAdd.updateSelection(1);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(0);
                        SpiritAdd.updateSelection(1);
                        MayorAdd.updateSelection(0);
                        DetectiveAdd.updateSelection(1);
                        NightwatcherAdd.updateSelection(1);
                        SpyAdd.updateSelection(0);
                        InforAdd.updateSelection(1);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(1);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(0);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(1);
                        FakeAdd.updateSelection(1);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(1);
                        CamoAdd.updateSelection(1);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(1);
                        WarAdd.updateSelection(0);
                        GuesserAdd.updateSelection(1);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(1);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(1);
                        SorcererAdd.updateSelection(1);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(0);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(0);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(0);
                        SherifKillCulteMember.updateSelection(0);


                        TimeLordSpawnChance.updateSelection(20);
                        TimeLordStopCooldown.updateSelection(12);
                        TimeLordStopDuration.updateSelection(7);

                        SpiritSpawnChance.updateSelection(20);
                        SpiritSab.updateSelection(1);

                        DetectiveSpawnChance.updateSelection(20);
                        detectiveFootprintcooldown.updateSelection(8);
                        detectiveFootprintDuration.updateSelection(7);
                        detectiveFootprintDuration2.updateSelection(10);
                        detectiveFootprintanonymous.updateSelection(0);

                        NightwatcherSpawnChance.updateSelection(20);
                        NightwatcherSetCooldown.updateSelection(8);
                        NightwatcherSetDuration.updateSelection(11);

                        InforSpawnChance.updateSelection(20);
                        InforCooldown.updateSelection(4);
                        InforAnalyseMod.updateSelection(0);
                        InforAnalyseMod.updateSelection(0);

                        BuilderSpawnChance.updateSelection(20);
                        BuildRound.updateSelection(1);
                        MaxBuild.updateSelection(2);
                        BuildCooldown.updateSelection(4);

                        LawkeeperSpawnChance.updateSelection(20);
                        LKTimer.updateSelection(1);
                        LKInfo.updateSelection(1);
                        TimeRName.updateSelection(2);
                        TimeRList.updateSelection(12);
                        SuperInfo.updateSelection(1);

                        FakeSpawnChance.updateSelection(20);
                        ImpostorCanKillFake.updateSelection(1);
                        FakeCanVent.updateSelection(0);

                        CopyCatSpawnChance.updateSelection(20);
                        CopyImp.updateSelection(2);
                        CopySpe.updateSelection(1);

                        SorcererSpawnChance.updateSelection(20);
                        SurvivorWinJester.updateSelection(0);
                        SurvivorWinEater.updateSelection(0);
                        SurvivorWinOutlaw.updateSelection(0);
                        SurvivorWinCulte.updateSelection(0);
                        SurvivorWinArsonist.updateSelection(0);

                        CupidSpawnChance.updateSelection(20);
                        Loverdie.updateSelection(1);

                        CamoSpawnChance.updateSelection(20);
                        CamoSetCooldown.updateSelection(10);
                        CamoSetDuration.updateSelection(9);
                        CamoCanVent.updateSelection(1);

                        MorphlingSpawnChance.updateSelection(10);
                        MorphSetCooldown.updateSelection(8);
                        MorphSetDuration.updateSelection(14);
                        MorphlingCanVent.updateSelection(1);

                        GhostSpawnChance.updateSelection(20);
                        HideSetCooldown.updateSelection(10);
                        HideSetDuration.updateSelection(14);
                        GhostCanVent.updateSelection(1);

                        GuesserSpawnChance.updateSelection(15);
                        Gestry.updateSelection(2);
                        GuessTryOne.updateSelection(1);
                        GuessDie.updateSelection(0);
                        GuessMystic.updateSelection(0);
                        GuessSpirit.updateSelection(1);
                        GuessFake.updateSelection(0);
                        GuessCanVent.updateSelection(1);




                    }
                    if (Challenger.IsrankedGameSet == 7) // Culte
                    {

                        RankedInt.updateSelection(7);
                        PlayerControl.GameOptions.MaxPlayers = 13;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(9);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(1);
                        QTDuo.updateSelection(1);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(0);
                        engineerAdd.updateSelection(1);
                        TimeLordAdd.updateSelection(1);
                        HunterAdd.updateSelection(1);
                        MysticAdd.updateSelection(0);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(0);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(1);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(1);
                        MentalistAdd.updateSelection(0);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(1);
                        MateAdd.updateSelection(0);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(1);

                        AssassinAdd.updateSelection(1);
                        VectorAdd.updateSelection(1);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(1);
                        GhostAdd.updateSelection(0);
                        WarAdd.updateSelection(1);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(1);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(0);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(0);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(1);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(20);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        engineerSpawnChance.updateSelection(20);
                        EngineerCanVent.updateSelection(1);
                        EngineerRepairCD.updateSelection(2);
                        RepairSettings.updateSelection(0);

                        TimeLordSpawnChance.updateSelection(20);
                        TimeLordStopCooldown.updateSelection(12);
                        TimeLordStopDuration.updateSelection(7);

                        HunterSpawnChance.updateSelection(20);
                        ResetTrack.updateSelection(1);
                        Followtrack.updateSelection(1);

                        SpySpawnChance.updateSelection(20);
                        SpyDuration.updateSelection(4);
                        SpyRange.updateSelection(1);

                        BaitSpawnChance.updateSelection(20);
                        BaitReporttime.updateSelection(1);
                        BaitReporttimeRnd.updateSelection(2);
                        BaitCanVent.updateSelection(0);

                        SentinelSpawnChance.updateSelection(20);
                        ScanCooldown.updateSelection(7);
                        ScanDuration.updateSelection(8);
                        ScanAbility.updateSelection(2);

                        FakeSpawnChance.updateSelection(20);
                        ImpostorCanKillFake.updateSelection(1);
                        FakeCanVent.updateSelection(0);

                        RevengerSpawnChance.updateSelection(20);
                        QtVenger.updateSelection(2);
                        VengerCooldown.updateSelection(8);
                        VengerKill.updateSelection(0);
                        VengerExil.updateSelection(0);

                        CultisteSpawnChance.updateSelection(0);
                        CulteMember.updateSelection(1);
                        CultisteCooldown.updateSelection(12);
                        Cultistdie.updateSelection(0);

                        AssassinSpawnChance.updateSelection(10);
                        AssassinKillCooldown.updateSelection(6);
                        AssassinCanKillShield.updateSelection(0);
                        BSheriff.updateSelection(1);
                        BGuardian.updateSelection(0);
                        BEngineer.updateSelection(1);
                        BTimelord.updateSelection(1);
                        BMystic.updateSelection(0);
                        BMayor.updateSelection(0);
                        BDetective.updateSelection(0);
                        BNightwatcher.updateSelection(0);
                        BSpy.updateSelection(1);
                        BInfor.updateSelection(0);
                        BMentalist.updateSelection(0);
                        BBuilder.updateSelection(0);
                        BDictator.updateSelection(0);
                        BSentinel.updateSelection(1);
                        BLawkeeper.updateSelection(0);
                        BImpo.updateSelection(1);

                        VectorSpawnChance.updateSelection(20);
                        VectorBuffCooldown.updateSelection(6);
                        VectorKillCooldown.updateSelection(4);
                        VectorBuffVisibility.updateSelection(1);
                        VectorCanVent.updateSelection(0);

                        BarghestSpawnChance.updateSelection(15);
                        BargestLightCooldown.updateSelection(10);
                        BargestLightDuration.updateSelection(7);
                        BarghestAffectImpostor.updateSelection(0);
                        BarghestCamlight.updateSelection(1);
                        BarghestCanCreateVent.updateSelection(1);
                        BarghestVentCD.updateSelection(6);
                        BarghestCanVent.updateSelection(1);
                        CanUseBarghestVent.updateSelection(0);

                        WarSpawnChance.updateSelection(20);
                        WarCooldown.updateSelection(6);
                        War1.updateSelection(1);
                        War2.updateSelection(1);
                        War3.updateSelection(1);
                        War4.updateSelection(1);
                        WarCanVent.updateSelection(1);
                    }
                    if (Challenger.IsrankedGameSet == 8) // Arsonist
                    {

                        RankedInt.updateSelection(8);
                        PlayerControl.GameOptions.MaxPlayers = 12;
                        PlayerControl.GameOptions.MapId = 2;
                        PlayerControl.GameOptions.NumImpostors = 2;
                        PlayerControl.GameOptions.ConfirmImpostor = false;
                        PlayerControl.GameOptions.NumEmergencyMeetings = 2;
                        PlayerControl.GameOptions.EmergencyCooldown = 15;
                        PlayerControl.GameOptions.DiscussionTime = 15;
                        PlayerControl.GameOptions.VotingTime = 150;
                        PlayerControl.GameOptions.AnonymousVotes = true;
                        PlayerControl.GameOptions.PlayerSpeedMod = 1f;
                        PlayerControl.GameOptions.CrewLightMod = 0.5f;
                        PlayerControl.GameOptions.ImpostorLightMod = 1f;
                        PlayerControl.GameOptions.KillCooldown = 25f;
                        PlayerControl.GameOptions.KillDistance = 0;
                        PlayerControl.GameOptions.VisualTasks = false;
                        PlayerControl.GameOptions.TaskBarMode = (TaskBarMode)1;
                        PlayerControl.GameOptions.NumCommonTasks = 2;
                        PlayerControl.GameOptions.NumShortTasks = 5;
                        PlayerControl.GameOptions.NumLongTasks = 3;

                        QTCrew.updateSelection(8);
                        QTImp.updateSelection(2);
                        QTSpe.updateSelection(1);
                        QTDuo.updateSelection(1);

                        SherifAdd.updateSelection(1);
                        GuardianAdd.updateSelection(1);
                        engineerAdd.updateSelection(0);
                        TimeLordAdd.updateSelection(0);
                        HunterAdd.updateSelection(0);
                        MysticAdd.updateSelection(1);
                        SpiritAdd.updateSelection(0);
                        MayorAdd.updateSelection(0);
                        DetectiveAdd.updateSelection(0);
                        NightwatcherAdd.updateSelection(0);
                        SpyAdd.updateSelection(1);
                        InforAdd.updateSelection(0);
                        BaitAdd.updateSelection(0);
                        MentalistAdd.updateSelection(1);
                        BuilderAdd.updateSelection(0);
                        DictatorAdd.updateSelection(0);
                        SentinelAdd.updateSelection(1);
                        MateAdd.updateSelection(1);
                        LawkeeperAdd.updateSelection(0);
                        FakeAdd.updateSelection(0);

                        AssassinAdd.updateSelection(0);
                        VectorAdd.updateSelection(0);
                        MorphlingAdd.updateSelection(0);
                        CamoAdd.updateSelection(0);
                        BarghestAdd.updateSelection(0);
                        GhostAdd.updateSelection(1);
                        WarAdd.updateSelection(1);
                        GuesserAdd.updateSelection(0);
                        BasiliskAdd.updateSelection(0);

                        CupidAdd.updateSelection(0);
                        CultisteAdd.updateSelection(0);
                        OutlawAdd.updateSelection(0);
                        JesterAdd.updateSelection(0);
                        EaterAdd.updateSelection(0);
                        ArsonistAdd.updateSelection(1);
                        CursedAdd.updateSelection(0);

                        MercenaryAdd.updateSelection(0);
                        CopyCatAdd.updateSelection(1);
                        SorcererAdd.updateSelection(0);
                        RevengerAdd.updateSelection(0);

                        ImpostorsKnowEachother.updateSelection(0);
                        BuzzCommon.updateSelection(1);

                        BetterMapPL.updateSelection(2);
                        BetterMapSK.updateSelection(0);
                        BetterMapHQ.updateSelection(0);

                        NuclearTimerMod.updateSelection(1);
                        NuclearTime1.updateSelection(6);
                        NuclearTime2.updateSelection(20);

                        BetterTaskWeapon.updateSelection(0);
                        BetterTaskWire.updateSelection(0);

                        ReactorSabotageShaking.updateSelection(0);
                        NoOxySabotage.updateSelection(0);
                        CommsSabotageAnonymous.updateSelection(1);

                        DisabledAdmin.updateSelection(0);
                        DisabledVitales.updateSelection(0);
                        DisabledCamera.updateSelection(0);

                        AdminTimeOn.updateSelection(1);
                        VitalTimeOn.updateSelection(1);
                        CamTimeOn.updateSelection(1);

                        AdminTime.updateSelection(26);
                        VitalTime.updateSelection(19);
                        CamTime.updateSelection(36);

                        SherifSpawnChance.updateSelection(20);
                        Sherif2SpawnChance.updateSelection(0);
                        Sherif3SpawnChance.updateSelection(0);
                        SherifKillSettings.updateSelection(2);
                        SherifKillCooldown.updateSelection(6);
                        SherifKillRange.updateSelection(1);
                        SherifKillCulteMember.updateSelection(1);

                        GuardianSpawnChance.updateSelection(20);
                        ShieldSettings.updateSelection(0);
                        GuardianShieldVisibility.updateSelection(0);
                        GuardianShieldVisibilitytry.updateSelection(2);
                        GuardianShieldSound.updateSelection(1);

                        MysticSpawnChance.updateSelection(20);
                        MysticSetCooldown.updateSelection(8);
                        MysticSetDuration.updateSelection(9);

                        SpySpawnChance.updateSelection(20);
                        SpyDuration.updateSelection(4);
                        SpyRange.updateSelection(1);

                        MentalistSpawnChance.updateSelection(20);
                        MentalistAbility.updateSelection(0);
                        AdminSetting.updateSelection(1);
                        AdminDuration.updateSelection(9);

                        SentinelSpawnChance.updateSelection(20);
                        ScanCooldown.updateSelection(7);
                        ScanDuration.updateSelection(8);
                        ScanAbility.updateSelection(2);

                        MateSpawnChance.updateSelection(20);

                        CopyCatSpawnChance.updateSelection(20);
                        CopyImp.updateSelection(2);
                        CopySpe.updateSelection(1);

                        ArsonistSpawnChance.updateSelection(20);
                        ArsonistFuelQT.updateSelection(3);
                        ArsonistCooldown.updateSelection(4);
                        ArsonistDuration.updateSelection(1);
                        ArsonistFailDuration.updateSelection(9);
                        AutoRefuel.updateSelection(0);

                        GhostSpawnChance.updateSelection(16);
                        HideSetCooldown.updateSelection(10);
                        HideSetDuration.updateSelection(14);
                        GhostCanVent.updateSelection(1);

                        WarSpawnChance.updateSelection(16);
                        WarCooldown.updateSelection(6);
                        War1.updateSelection(1);
                        War2.updateSelection(1);
                        War3.updateSelection(1);
                        War4.updateSelection(1);
                        WarCanVent.updateSelection(1);


                    }
                }
                else
                {
                    if (Challenger.IsrankedGame == true)
                    {
                        Challenger.isRankedGame = true;
                    }
                    if (Challenger.IsrankedGame == false)
                    {
                        Challenger.isRankedGame = false;
                    }

                    

                }
                    
            }
        }
    }
}