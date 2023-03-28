using HarmonyLib;
using InnerNet;
using static ChallengerMod.Unity;



namespace ChallengerMod
{
    
    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.Start))]
    public static class InnerNetClient_Start
    {
        static void Postfix()
        {
            if (ChallengerMod.Challenger.IntroSound == "1")
            {
                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.PlaySound(introOST, true, 0.33f);
            }
            ChallengerMod.Utility.Discord.DiscordData.Initialize();
        }

    }
    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.Update))] // Update MainMenu
    public static class InnerNetClient_Update
    {
        static void Postfix()
        {
            //NOT USED TO V5
        }

    }
    


    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.DisconnectInternal))]
    public static class InnerNetClient_DisconnectInternal
    {
        static void Postfix()
        {
            if (ChallengerMod.Challenger.IntroSound == "1")
            {
                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.PlaySound(introOST, true, 0.33f);
            }
            ChallengerMod.Utility.Discord.DiscordData.UpdateDetails(" ");
            ChallengerMod.Utility.Discord.DiscordData.UpdateState(" ");
            if (GLMod.GLMod.isLoggedIn() == true)
            {
                GLMod.GLMod.getRank();
                GLMod.GLMod.reloadItems();
            }
            GLMod.GLMod.step = 0;
        }

    }
    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.HandleDisconnect))]
    public static class InnerNetClient_disconnected
    {
        static void Postfix()
        {
            if (ChallengerMod.Challenger.IntroSound == "1")
            {
                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.PlaySound(introOST, true, 0.33f);
            }
            ChallengerMod.Utility.Discord.DiscordData.UpdateDetails(" ");
            ChallengerMod.Utility.Discord.DiscordData.UpdateState(" ");
            if (GLMod.GLMod.isLoggedIn() == true)
            {
                GLMod.GLMod.getRank();
                GLMod.GLMod.reloadItems();
            }
            GLMod.GLMod.step = 0;
        }

    }
    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.OnDisconnect))]
    public static class InnerNetClient_Forcedisconnected
    {
        static void Postfix()
        {
            
            if (ChallengerMod.Challenger.IntroSound == "1")
            {
                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.PlaySound(introOST, true, 0.33f);
            }
            ChallengerMod.Utility.Discord.DiscordData.UpdateDetails(" ");
            ChallengerMod.Utility.Discord.DiscordData.UpdateState(" ");
            if (GLMod.GLMod.isLoggedIn() == true)
            {
                GLMod.GLMod.getRank();
                GLMod.GLMod.reloadItems();
            }
            GLMod.GLMod.step = 0;
        }

    }
    

}