﻿using HarmonyLib;
using static ChallengerMod.HarmonyMain;
using static ChallengerMod.Set.Data;


namespace ChallengerMod
{
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionStartPatch
    {
        static void Postfix(VersionShower __instance)
        {





            if (Challenger.LangGameSet == 2f || (Playerlang == "French" && Challenger.LangGameSet == 0f))
            {
                __instance.text.text += "<size=1>\n\n\n\n</size>\n<size=2>Among Us <color=#DE6C13>CHALLENGER</size></color> <size=2><color=#0089EE>Version : (" + PrefixString + VersionString + SufixString + ")</color> <color=#6E40BB>''" + UpdateNameStringFR + "''</color></size>\n";

                __instance.text.text += "<size=0.2>\n</size><size=0.7><i>Ce mod n'est pas affilié à Among Us ou Innersloth LLC, le contenu qu'il contient n'est ni approuvé ni sponsorisé par Innersloth LLC. Des parties / composants contenus dans ce mod sont la propriété d'Innersloth LLC. © Innersloth LLC.</i></size>\n";
                __instance.text.text += "<size=0.7><color=#ffffff><i>Plusieurs parties du code source de ce Mod sont soumises au droit d'auteur, toute reproduction ou utilisation détournée sans l'accord préalable de ses propriétaires est interdite. le contenu protégé appartient à Oriana®.\n";
                __instance.text.text += "BepInEx et Reactor sont distribués avec une License LGPL-3.0, Submerged est distribué avec une License Custom (https://github.com/SubmergedAmongUs/Submerged). ";
                __instance.text.text += "Plus d'informations sur les Licenses & crédits sur Github.</i></color></size>\n";

                __instance.text.text += "<size=0.5>\n</size>";

                __instance.text.text += "<size=0.9> - Fondatrice / Conceptrice & Développeuse : <color=#FF2DE9>Lunastellia</color></size>\n";
                __instance.text.text += "<size=0.9> - Distribuer par <color=#4AB1DE>Oriana®</color> & <color=#4DA777>ModManager</color></size>\n";
                __instance.text.text += "<size=0.9> - Développeur GoodLoss (Serveur & Comptes Utilisateur) : <color=#F0EF86>Matux</color></size>\n";
                __instance.text.text += "<size=0.9> - graphiste : <color=#FF2DE9>Lunastellia</color> & <color=#FBAEFF>Asman</color></size>\n";
                __instance.text.text += "<size=0.9> - Compositeur Audio : <color=#38EEF7>Noé Guiton</color></size>\n";
            }
            else if (Challenger.LangGameSet == 3f || (ChallengerMod.Set.Data.Playerlang == "SChinese" && Challenger.LangGameSet == 0f))
            {
                __instance.text.text += "<size=1>\n\n\n\n\n\n</size>\n<size=2>Among Us <color=#DE6C13>挑战者</size></color> <size=2><color=#0089EE>版本 : (" + PrefixString + VersionString + SufixString + ")</color> <color=#6E40BB>''" + UpdateNameString + "''</color></size>\n";

                __instance.text.text += "<size=0.2>\n</size><size=0.7><i>此模组不隶属于Among Us或Innersloth LLC，其中包含的内容不被Innersloth LLC的认可或以其他方式赞助。这里包含的部分材料是Innersloth LLC的财产。©Innersloth LLC.</i></size>\n";
                __instance.text.text += "<size=0.7><color=#ffffff><i>此模组的源代码的某些部分受版权保护，未经这些所有者的事先同意，禁止任何复制或误用。受保护的内容属于Oriana®.\n";
                __instance.text.text += "BepInEx和Reactor根据LGPL-3.0许可证进行分发。潜艇地图根据定制许可证进行发布(https://github.com/SubmergedAmongUs/Submerged). ";
                __instance.text.text += "更多关于署名/许可证和制作者的信息，请参阅Github.</i></color></size>\n";

                __instance.text.text += "<size=0.5>\n</size>";

                __instance.text.text += "<size=0.9> - 创始人/游戏设计师和开发者 : <color=#FF2DE9>Lunastellia</color></size>\n";
                __instance.text.text += "<size=0.9> - 由 <color=#4AB1DE>Oriana®</color> 和 <color=#4DA777>ModManager</color>分发</size>\n";
                __instance.text.text += "<size=0.9> - GoodLoss开发者 (游戏服务器 & 账户) : <color=#F0EF86>Matux</color></size>\n";
                __instance.text.text += "<size=0.9> - 美工 : <color=#FF2DE9>Lunastellia</color> 和 <color=#FBAEFF>Asman</color></size>\n";
                __instance.text.text += "<size=0.9> - 音乐制作人 : <color=#38EEF7>Noé Guiton</color></size>\n";
                __instance.text.text += "<size=0.9> - 简体中文翻译 : <color=#770000>四个憨批汉化组 (https://amonguscn.club)</color></size>\n";

            }
            else
            {
                __instance.text.text += "<size=1>\n\n\n\n</size>\n<size=2>Among Us <color=#DE6C13>CHALLENGER</size></color> <size=2><color=#0089EE>Version : (" + PrefixString + VersionString + SufixString + ")</color> <color=#6E40BB>''" + UpdateNameString + "''</color></size>\n";

                __instance.text.text += "<size=0.2>\n</size><size=0.7><i>This mod is not affiliated with Among Us or Innersloth LLC, and the content contained therein is not endorsed or otherwise sponsored by Innersloth LLC. Portions of the materials contained herein are property of Innersloth LLC. © Innersloth LLC.</i></size>\n";
                __instance.text.text += "<size=0.7><color=#ffffff><i>Several parts of the source code of this Mod are subject to copyright, any reproduction or misuse without the prior consent of these owners is prohibited. the protected content belongs to Oriana®.\n";
                __instance.text.text += "BepInEx and Reactor is distributed under LGPL-3.0 License Submerged is distributed under custom License (https://github.com/SubmergedAmongUs/Submerged). ";
                __instance.text.text += "More information about Credits/licenses and creators on Github.</i></color></size>\n";

                __instance.text.text += "<size=0.5>\n</size>";

                __instance.text.text += "<size=0.9> - Founder / Game Designer & Developer : <color=#FF2DE9>Lunastellia</color></size>\n";
                __instance.text.text += "<size=0.9> - Distributed by <color=#4AB1DE>Oriana®</color> & <color=#4DA777>ModManager</color></size>\n";
                __instance.text.text += "<size=0.9> - GoodLoss Developer (GameServer & Account) : <color=#F0EF86>Matux</color></size>\n";
                __instance.text.text += "<size=0.9> - Graphic Designer : <color=#FF2DE9>Lunastellia</color> & <color=#FBAEFF>Asman</color></size>\n";
                __instance.text.text += "<size=0.9> - Music Composer : <color=#38EEF7>Noé Guiton</color></size>\n";
                //__instance.text.text += "<size=1 ❀♂ ◥ ▶ ☆ ♡ ♥ ❀ ★ ☆ ✿ 』→ ♫「 ♪»【 」⸻】ツ⭑« ッ♬↓《 》—    ☯ ❞ ┆ ☏┊ 〗● † --- ψ § </size>";
            }




        }


    }
}