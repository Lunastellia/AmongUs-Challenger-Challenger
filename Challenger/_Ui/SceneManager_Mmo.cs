using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ChallengerMod.UI
{
    public static class ChallengerUI_MMO
    {
        

        public static void Initialize()
        {
           
                
                SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, loadSceneMode) =>
            
            {
                if (!scene.name.Equals("MMOnline")) return;
                if (!TryMoveObjects()) return;

                var _Editname = DestroyableSingleton<AccountManager>.Instance.accountTab.editNameScreen;
                var _NameText = Object.Instantiate(_Editname.nameText.gameObject);
                _NameText.transform.localScale = new Vector3(0f, 0f, 0f);
                _NameText.transform.localPosition = new Vector3(0f, 0f, 0f);
                _NameText.name = "DestroyedText";

                var _TextBox = _NameText.GetComponent<TextBoxTMP>();
                _TextBox.outputText.alignment = TextAlignmentOptions.CenterGeoAligned;
                _TextBox.outputText.transform.position = _NameText.transform.position;
                _TextBox.outputText.fontSize = 4f;

                _TextBox.OnChange.AddListener((Action)(() => {
                    SaveManager.PlayerName = _TextBox.text;
                }));
                _TextBox.OnEnter = _TextBox.OnFocusLost = _TextBox.OnChange;
                _TextBox.Pipe.GetComponent<TextMeshPro>().fontSize = 4f;

                

            }));
        }

        private static bool TryMoveObjects()
        {
            var _Move = new List<string>
            {
                "HostGameButton",
                "FindGameButton",
                "JoinGameButton",
                "HelpButton"
            };

           
            var _Ys = Vector3.up;
            var _Yo = Vector3.down * 1.5f;

            var gameObjects = _Move.Select(x => GameObject.Find("NormalMenu/" + x)).ToList();
            if (gameObjects.Any(x => x == null)) return false;

            for (var i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].transform.position = new Vector3(-100f, 0f, 0f);
            }

            

            return true;
        }
    }
}