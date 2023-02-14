using HarmonyLib;


namespace ChallengerMod.GameStart
{
    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    public class GameStartManagerStartPatch
    {
        public static void Postfix(GameStartManager __instance)
        {
            

            ChallengerMod.Utility.Discord.DiscordData.UpdateDetails("Lobby");
            ChallengerMod.Utility.Discord.DiscordData.UpdateState(" ");

            
            if (GLMod.GLMod.isLoggedIn() == true)
            {
                GLMod.GLMod.getRank();
                GLMod.GLMod.reloadItems();
                //ChallengerMod.Cosmetiques.PlayerCosmetics.CheckForUnlock();

            }
        }
    }
}
