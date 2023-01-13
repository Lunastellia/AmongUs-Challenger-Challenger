using System.Runtime.InteropServices;
using System.Text;


namespace ChallengerMod.Keydata
{

    public class Keyboard
    {
        const int KL_NAMELENGTH = 9;

        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(
              System.Text.StringBuilder pwszKLID);

        public static void Main()
        {
            StringBuilder name = new StringBuilder(KL_NAMELENGTH);

            GetKeyboardLayoutName(name);

            ChallengerMod.HarmonyMain.KeyboardData = "" + name;

        }
    }

}