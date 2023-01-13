using HarmonyLib;
using static ChallengerMod.Set.Data;
using static ChallengerMod.Roles;




namespace ChallengerMod
{



    [HarmonyPatch]
    public static class WinData
    {

        
        public static void _CrewmatesWinByTask()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = true;
            CursedWinthegame = false;
            _SetCrewmatesData();
            _SetSurvivorData();
            _SetMercenaryDataC();
            _SetCopyCatDataC();
            _SetRevengerDataC();
            
        }
        public static void _CrewmatesWinByKill()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = true;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;
            _SetCrewmatesData();
            _SetSurvivorData();
            _SetMercenaryDataC();
            _SetCopyCatDataC();
            _SetRevengerDataC();
        }
        public static void _InpostorWinBySab()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = true;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;
            _SetImpostorsData();
            _SetSurvivorData();
            _SetMercenaryDataI();
            _SetCopyCatDataI();
            _SetRevengerDataI();
        }
        public static void _InpostorWinByKill()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = true;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWinthegame = false;
            _SetImpostorsData();
            _SetSurvivorData();
            _SetMercenaryDataI();
            _SetCopyCatDataI();
            _SetRevengerDataI();
        }
        public static void _JesterWin()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = true;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            JesterWin = true;
            CursedWinthegame = false;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinJester.getBool() == true)
            {
                _SetSurvivorData();
            }
        }
        public static void _EaterWin()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = true;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            EaterWin = true;
            CursedWinthegame = false;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinEater.getBool() == true)
            {
                _SetSurvivorData();
            }
        }
        public static void _OutlawWin()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = true;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            OutlawWin = true;
            CursedWinthegame = false;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinOutlaw.getBool() == true)
            {
                _SetSurvivorData();
            }
        }
        public static void _CursedWin()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CursedWin = true;
            CursedWinthegame = true;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinCursed.getBool() == true)
            {
                _SetSurvivorData();
            }
        }
        public static void _ArsonistWin()
        {
            
            CulteWinthegame = false;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = true;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            ArsonistWin = true;
            CursedWinthegame = false;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinArsonist.getBool() == true)
            {
                _SetSurvivorData();
            }
        }
        public static void _CulteWin()
        {
            
            CulteWinthegame = true;
            EaterWinthegame = false;
            OutlawWinthegame = false;
            ArsonistWinthegame = false;
            JesterWinthegame = false;
            ImpostorWinthegame = false;
            ImpostorWinthegameBySab = false;
            CrewmateWinthegame = false;
            CrewmateWinthegamebyTask = false;
            CultistWin = true;
            CursedWinthegame = false;
            if (ChallengerOS.Utils.Option.CustomOptionHolder.SurvivorWinCulte.getBool() == true)
            {
                _SetSurvivorData();
            }
        }


        //SET
        public static void _SetMercenaryDataC()
        {
            if (Mercenary.Role != null && !Mercenary.isImpostor)
            {
                MercenaryWin = false;
                MercenaryCWin = true;
            }
            else
            {
                MercenaryWin = false;
                MercenaryCWin = false;
            }
        }
        public static void _SetMercenaryDataI()
        {
            if (Mercenary.Role != null && !Mercenary.isImpostor)
            {
                MercenaryWin = true;
                MercenaryCWin = false;
            }
            else
            {
                MercenaryWin = false;
                MercenaryCWin = false;
            }

        }
        public static void _SetCopyCatDataC()
        {
            if (CopyCat.Role != null && !CopyCat.isImpostor)
            {
                CopyCatWin = false;
                CopyCatCWin = true;
            }
            else
            {
                CopyCatWin = false;
                CopyCatCWin = false;
            }
        }
        public static void _SetCopyCatDataI()
        {
            if (CopyCat.Role != null && !CopyCat.isImpostor)
            {
                CopyCatWin = true;
                CopyCatCWin = false;
            }
            else
            {
                CopyCatWin = false;
                CopyCatCWin = false;
            }
        }
        public static void _SetRevengerDataC()
        {
            if (Revenger.Role != null && !Revenger.isImpostor)
            {
               RevengerWin = false;
               RevengerCWin = true;
            }
            else
            {
                RevengerWin = false;
                RevengerCWin = false;
            }
        }
        public static void _SetRevengerDataI()
        {
            if (Revenger.Role != null && Revenger.isImpostor)
            {
                RevengerWin = true;
                RevengerCWin = false;
            }
            else
            {
                RevengerWin = false;
                RevengerCWin = false;
            }
        }
        public static void _SetSurvivorData()
        {

        }
        public static void _SetCrewmatesData()
        {
            
        }
        public static void _SetImpostorsData()
        {
            
        }
    }
}