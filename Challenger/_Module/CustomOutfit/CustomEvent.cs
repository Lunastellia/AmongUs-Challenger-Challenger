using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ChallengerMod.Cosmetics
{

    [HarmonyPatch(typeof(HatsTab))]
    public static class HatsTabPatch
    {

        [HarmonyPostfix]
        [HarmonyPatch(nameof(HatsTab.Update))]
        public static void UpdatePostfix(HatsTab __instance)
        {
            if (GameObject.Find("Map_Disable"))
            {
                var Eventbutton = GameObject.Find("Map_Disable");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/HatsGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
            }
            if (GameObject.Find("Map_Lover"))
            {
                var Eventbutton = GameObject.Find("Map_Lover");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/HatsGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
            }
        }
    }
    [HarmonyPatch(typeof(VisorsTab))]
    public static class VisorsTabPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(VisorsTab.Update))]
        public static void UpdatePostfix(VisorsTab __instance)
        {
            if (GameObject.Find("Map_Disable"))
            {
                var Eventbutton = GameObject.Find("Map_Disable");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/VisorGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
            }
            if (GameObject.Find("Map_Lover"))
            {
                var Eventbutton = GameObject.Find("Map_Lover");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/VisorGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
            }
        }
    }
    [HarmonyPatch(typeof(SkinsTab))]
    public static class SkinsTabPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(SkinsTab.Update))]
        public static void UpdatePostfix(SkinsTab __instance)
        {
            if (GameObject.Find("Map_Disable"))
            {
                var Eventbutton = GameObject.Find("Map_Disable");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/SkinGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
            }
            if (GameObject.Find("Map_Lover"))
            {
                var Eventbutton = GameObject.Find("Map_Lover");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/SkinGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
            }
        }
    }
    [HarmonyPatch(typeof(PetsTab))]
    public static class PetsTabPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(PetsTab.Update))]
        public static void UpdatePostfix(PetsTab __instance)
        {
            if (GameObject.Find("Map_Disable"))
            {
                var Eventbutton = GameObject.Find("Map_Disable");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/PetsGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
            }
            if (GameObject.Find("Map_Lover"))
            {
                var Eventbutton = GameObject.Find("Map_Lover");

                var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/PetsGroup");
                if (ITN != null)
                {
                    if (ITN.activeSelf == true)
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                    }
                }
                var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
            }
        }
        [HarmonyPatch(typeof(NameplatesTab))]
        public static class NameplatesTabPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(NameplatesTab.Update))]
            public static void UpdatePostfix(NameplatesTab __instance)
            {
                if (GameObject.Find("Map_Disable"))
                {
                    var Eventbutton = GameObject.Find("Map_Disable");

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/NameplateGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }
                    }
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
                }
                if (GameObject.Find("Map_Lover"))
                {
                    var Eventbutton = GameObject.Find("Map_Lover");

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/NameplateGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }
                    }
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
                }
            }
        }
        [HarmonyPatch(typeof(CubesTab))]
        public static class CubeTabPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(CubesTab.Update))]
            public static void UpdatePostfix(CubesTab __instance)
            {
                if (GameObject.Find("Map_Disable"))
                {
                    var Eventbutton = GameObject.Find("Map_Disable");

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/CubeGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }
                    }
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }
                }
                if (GameObject.Find("Map_Lover"))
                {
                    var Eventbutton = GameObject.Find("Map_Lover");

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/CubeGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }
                    }
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }
                }
            }
        }
        [HarmonyPatch(typeof(PlayerTab))]
        public static class PlayerTabPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(PlayerTab.Update))]
            public static void UpdatePostfix(PlayerTab __instance)
            {


                if (GameObject.Find("MapTAB"))
                {

                    GameObject Eventbutton = GameObject.Find("MapTAB");
                    if (GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)"))
                    {
                        Eventbutton.transform.localScale = new Vector3(1f, 1f, 1f);
                        Eventbutton.transform.localPosition = new Vector3(-4f, 0f, 0f);
                    }
                    else
                    {
                        Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    var BTTN = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Tab Background");
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    SpriteTab.sprite = ChallengerMod.Unity.EV_TAB;
                    PassiveButton NewTABButton = BTTN.GetComponent<PassiveButton>();
                    NewTABButton.OnClick = new Button.ButtonClickedEvent();
                    NewTABButton.OnClick.AddListener((UnityEngine.Events.UnityAction)OnClick);
                    void OnClick()
                    {
                        GameObject HatsGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/HatsGroup");
                        if (HatsGroup != null) { HatsGroup.SetActive(false); }
                        GameObject PetsGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/PetsGroup");
                        if (PetsGroup != null) { PetsGroup.SetActive(false); }
                        GameObject ColorGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/ColorGroup");
                        if (ColorGroup != null) { ColorGroup.SetActive(false); }
                        GameObject SkinGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/SkinGroup");
                        if (SkinGroup != null) { SkinGroup.SetActive(false); }
                        GameObject VisorGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/VisorGroup");
                        if (VisorGroup != null) { VisorGroup.SetActive(false); }
                        GameObject CubeGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/CubeGroup");
                        if (CubeGroup != null) { CubeGroup.SetActive(false); }
                        GameObject NameplateGroup = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/NameplateGroup");
                        if (NameplateGroup != null) { NameplateGroup.SetActive(false); }
                        GameObject CosmicubeMenuHolder = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/CosmicubeMenuHolder");
                        if (CosmicubeMenuHolder != null) { CosmicubeMenuHolder.SetActive(false); }
                        GameObject CubeView = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/CubeView");
                        if (CubeView != null) { CubeView.SetActive(false); }
                        GameObject PlayerVoteArea = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/PlayerVoteArea");
                        if (PlayerVoteArea != null) { PlayerVoteArea.SetActive(false); }
                        GameObject PoolablePlayer = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/PoolablePlayer");
                        if (PoolablePlayer != null) { PoolablePlayer.SetActive(true); }
                        GameObject Gradient = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/Gradient");
                        if (Gradient != null) { Gradient.SetActive(true); }
                        GameObject Equip = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/Equip");
                        if (Equip != null) { Equip.SetActive(false); }
                        GameObject ItemName = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/Item Name");
                        if (ItemName != null) { ItemName.SetActive(false); }
                        GameObject EquippedText = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Background/RightPanel/EquippedText");
                        if (EquippedText != null) { EquippedText.SetActive(false); }

                        GameObject Map_Lover = GameObject.Find("Map_Lover");
                        Map_Lover.transform.localScale = new Vector3(2f, 2f, 2f);
                        Map_Lover.transform.localPosition = new Vector3(-2f, 1f, -50f);

                        GameObject Map_Disable = GameObject.Find("Map_Disable");
                        Map_Disable.transform.localScale = new Vector3(2f, 2f, 2f);
                        Map_Disable.transform.localPosition = new Vector3(-4f, 1f, -50f);
                    }



                }
                else
                {
                    GameObject TAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Header/Tabs/HatsTab");
                    GameObject PTAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Header/Tabs");
                    if (TAB != null && PTAB != null)
                    {
                        var NewTAB = UnityEngine.Object.Instantiate(TAB, null);
                        GameObject TABParent = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Header/Tabs");
                        NewTAB.transform.parent = TABParent.transform;
                        NewTAB.name = "MapTAB";
                    }
                }

                if (GameObject.Find("Map_Disable"))
                {

                    GameObject Eventbutton = GameObject.Find("Map_Disable");
                    var BTTN = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Tab Background");
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == false) { SpriteTab.sprite = ChallengerMod.Unity.EV_0_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_0_0; }

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/ColorGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }
                    }


                    PassiveButton NewTABButton = BTTN.GetComponent<PassiveButton>();
                    NewTABButton.OnClick = new Button.ButtonClickedEvent();
                    NewTABButton.OnClick.AddListener((UnityEngine.Events.UnityAction)OnClick);
                    void OnClick()
                    {
                        ChallengerMod.Challenger.EventActive = "Normal";
                        ChallengerMod.Challenger.UpdateEvent();
                        ChallengerMod.Challenger.LoverEvent = false;
                    }
                }
                else
                {
                    GameObject TAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Header/Tabs/HatsTab");
                    GameObject PTAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)");
                    if (TAB != null && PTAB != null)
                    {
                        var NewTAB = UnityEngine.Object.Instantiate(TAB, null);
                        NewTAB.transform.parent = PTAB.transform;
                        NewTAB.name = "Map_Disable";
                    }
                }


                if (GameObject.Find("Map_Lover"))
                {
                    GameObject Eventbutton = GameObject.Find("Map_Lover");
                    var BTTN = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Tab Background");
                    var Sprite = Eventbutton.transform.FindChild("Hat Button").transform.FindChild("Icon");
                    SpriteRenderer SpriteTab = Sprite.GetComponent<SpriteRenderer>();
                    if (ChallengerMod.Challenger.LoverEvent == true) { SpriteTab.sprite = ChallengerMod.Unity.EV_1_1; }
                    else { SpriteTab.sprite = ChallengerMod.Unity.EV_1_0; }

                    var ITN = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/ColorGroup");
                    if (ITN != null)
                    {
                        if (ITN.activeSelf == true)
                        {
                            Eventbutton.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        else
                        {
                            Eventbutton.transform.localScale = new Vector3(2f, 2f, 1f);
                        }

                    }

                    PassiveButton NewTABButton = BTTN.GetComponent<PassiveButton>();
                    NewTABButton.OnClick = new Button.ButtonClickedEvent();
                    NewTABButton.OnClick.AddListener((UnityEngine.Events.UnityAction)OnClick);
                    void OnClick()
                    {
                        ChallengerMod.Challenger.EventActive = "Lover";
                        ChallengerMod.Challenger.UpdateEvent();
                        ChallengerMod.Challenger.LoverEvent = true;
                    }
                }
                else
                {
                    GameObject TAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)/Header/Tabs/HatsTab");
                    GameObject PTAB = GameObject.Find("Main Camera/LobbyPlayerCustomizationMenu(Clone)");
                    if (TAB != null && PTAB != null)
                    {
                        var NewTAB = UnityEngine.Object.Instantiate(TAB, null);
                        NewTAB.transform.parent = PTAB.transform;
                        NewTAB.name = "Map_Lover";
                    }
                }

            }

        }
    }
}