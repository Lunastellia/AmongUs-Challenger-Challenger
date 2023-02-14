using System;

namespace ChallengerMod.GLLogin
{
    
    public class GLMod_Login
    {
        public static async void tryLogin()
        {
            if (SteamManager.Initialized)
            {
                if (GLMod.GLMod.token == null)
                {
                    try
                    {
                        await GLMod.GLMod.login();
                        if (!GLMod.GLMod.withUnityExplorer)
                        {
                            GLMod.GLMod.getRank();
                            GLMod.GLMod.reloadItems();
                            GLMod.GLMod.reloadDlcOwnerships();

                            if (!GLMod.GLMod.enabledServices.Contains("Tasks")) { GLMod.GLMod.enabledServices.Add("Tasks"); }
                            if (!GLMod.GLMod.enabledServices.Contains("TasksMax")) { GLMod.GLMod.enabledServices.Add("TasksMax"); }
                            if (!GLMod.GLMod.enabledServices.Contains("Exiled")) { GLMod.GLMod.enabledServices.Add("Exiled"); }
                            if (!GLMod.GLMod.enabledServices.Contains("BodyReported")) { GLMod.GLMod.enabledServices.Add("BodyReported"); }
                            if (!GLMod.GLMod.enabledServices.Contains("Emergencies")) { GLMod.GLMod.enabledServices.Add("Emergencies"); }
                            if (!GLMod.GLMod.enabledServices.Contains("Turns")) { GLMod.GLMod.enabledServices.Add("Turns"); }
                            if (!GLMod.GLMod.enabledServices.Contains("Votes")) { GLMod.GLMod.enabledServices.Add("Votes"); }
                            

                            SceneChanger.ChangeScene("MMOnline");

                        }
                    }
                    catch (Exception e)
                    {
                        GLMod.GLMod.log(e.Source.ToString() + " / " + e.InnerException.ToString() + " / " + e.Message.ToString());
                        SceneChanger.ChangeScene("MMOnline");
                    }
                }
            }
        }
    }
}