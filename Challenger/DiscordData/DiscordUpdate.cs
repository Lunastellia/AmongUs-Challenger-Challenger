using UnityEngine;
using UnityEngine.UI;
using DiscordRPC;

namespace ChallengerMod.Utility.Discord
{

    public class DiscordData
    {
        public static DiscordRpcClient client;

       
        public static void Initialize()
        {
            client = new DiscordRpcClient("950185306521481256");


            client.OnReady += (sender, e) =>
            {
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
            };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = " ",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "orianachallenger",
                    LargeImageText = "Challenger",
                }
            });
        }
        public static void Update()
        {
            client.Invoke();
        }
        public static void UpdateState(string state)
        {
            client.UpdateState(state);
        }
        public static void UpdateDetails(string details)
        {
            client.UpdateDetails(details);
        }
        public static void UpdateIco(string ico, string icodesc)
        {
            client.UpdateSmallAsset(ico, icodesc);
        }
        
        public static void Deinitialize()
        {
            client.Dispose();
        }

    }
}


