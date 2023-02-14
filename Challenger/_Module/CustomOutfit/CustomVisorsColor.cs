using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;


namespace ChallengerMod.Cosmetics
{


    [HarmonyPatch]
    public static class VisorColor
    {
        public static int MyColorID = 0;

        
        public static Color Default = Palette.VisorColor;
        public static Color Red = new Color(255f / 255f, 0f / 255f, 0f / 255f, 1);
        public static Color Orange = new Color(255f / 255f, 125f / 255f, 0f / 255f, 1);
        public static Color Yellow = new Color(255f / 255f, 255f / 255f, 0f / 255f, 1);
        public static Color Lime = new Color(0f / 255f, 255f / 255f, 0f / 255f, 1);
        public static Color Green = new Color(0f / 255f, 180f / 255f, 0f / 255f, 1);
        public static Color Cyan = new Color(0f / 255f, 255f / 255f, 255f / 255f, 1);
        public static Color Blue = new Color(100f / 255f, 100f / 255f, 255f / 255f, 1);
        public static Color Pink = new Color(255f / 255f, 100f / 255f, 255f / 255f, 1);
        public static Color Purple = new Color(180f / 255f, 70f / 255f, 220f / 255f, 1);
        public static Color White = new Color(225f / 255f, 225f / 255f, 225f / 255f, 1);
        public static Color Black = new Color(85f / 255f, 85f / 255f, 85f / 255f, 1);

    }
}