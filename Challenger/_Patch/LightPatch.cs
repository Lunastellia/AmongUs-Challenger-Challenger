using HarmonyLib;
using static ChallengerMod.Roles;


namespace ChallengerMod
{
	[HarmonyPatch(typeof(ShipStatus))]
	public class ShipStatusPatch
	{
		[HarmonyPatch(typeof(ShipStatus), "CalculateLightRadius")]
		public static class LightPatch
		{
			public static bool Prefix([HarmonyArgument(0)] GameData.PlayerInfo player, ShipStatus __instance, ref float __result)
			{
				

				if (Challenger.LobbyTimeStop == true) // Time Break
				{
					Challenger.LobbyCamOff = true;
					Challenger.LobbyAdminOff = true;
					Challenger.LobbyVitalOff = true;
					__result = 0f;
                    return false;
				}
				if (Challenger.LobbyTimeStop == false) // Time Normal
				{
					if (Challenger.LobbyLightOff == true || Cursed.NightEffect == true) // Shadow On
					{
						if (Nightwatch.Role != null && Nightwatch.LightBuff == true && (PlayerControl.LocalPlayer == Nightwatch.Role) // Light Nightwatch enabled
							|| (Assassin.Role != null && Assassin.StealVision == true && (PlayerControl.LocalPlayer == Assassin.Role)) // Assassin Steal
						 || (CopyCat.Role != null && CopyCat.copyRole == 10 && Nightwatch.LightBuff == true && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role)) // Light Nightwatch enabled
						{
							__result = 3.8f;
                            if ((ChallengerOS.Utils.Option.CustomOptionHolder.BarghestCamlight.getBool() == true)) // Enable
							{
								Challenger.LobbyAdminOff = false;
								Challenger.LobbyVitalOff = false;
								Challenger.LobbyCamOff = true;
								return false;
							}
							else
                            {
								Challenger.LobbyAdminOff = false;
								Challenger.LobbyVitalOff = false;
								Challenger.LobbyCamOff = false;
								return false;
							}
							
						}
						else // Light Nightwatch disabled or normal player
						{

							__result = 0.8f;
                            
                            if ((ChallengerOS.Utils.Option.CustomOptionHolder.BarghestCamlight.getBool() == true)) // disabled
							{
								Challenger.LobbyAdminOff = false;
								Challenger.LobbyVitalOff = false;
								Challenger.LobbyCamOff = true;
								return false;
							}
							else
                            {
								Challenger.LobbyAdminOff = false;
								Challenger.LobbyVitalOff = false;
								Challenger.LobbyCamOff = false;
								return false;
							}
							
						}


					}
					if (Challenger.LobbyLightOff == false) // Shadown Off
					{
						if (Nightwatch.Role != null && Nightwatch.LightBuff == true && (PlayerControl.LocalPlayer == Nightwatch.Role) // Light Nightwatch enabled
							|| (Assassin.Role != null && Assassin.StealVision == true && (PlayerControl.LocalPlayer == Assassin.Role)) // Assassin Steal
						 || (CopyCat.Role != null && CopyCat.copyRole == 10 && Nightwatch.LightBuff == true && CopyCat.CopyStart == true && PlayerControl.LocalPlayer == CopyCat.Role)) // Light Nightwatch enabled
						{
							Challenger.LobbyAdminOff = false;
							Challenger.LobbyVitalOff = false;
							Challenger.LobbyCamOff = false;
							__result = 3.8f;
                            return false;
						}
						else
						{
							Challenger.LobbyAdminOff = false;
							Challenger.LobbyVitalOff = false;
							Challenger.LobbyCamOff = false;
							return true; // Normal Radius
						}
					}
				}
				else
				{
					Challenger.LobbyAdminOff = false;
					Challenger.LobbyVitalOff = false;
					Challenger.LobbyCamOff = false;
					return true; // Normal Radius
				}


				Challenger.LobbyAdminOff = false;
				Challenger.LobbyVitalOff = false;
				Challenger.LobbyCamOff = false;
				return true;
			}

		}
		[HarmonyPostfix]
		[HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.IsGameOverDueToDeath))]
		public static void Postfix(ShipStatus __instance, ref bool __result)
		{
			//if (OutlawSettings.Outlaw != null)
			__result = false;
            
        }

	}
}