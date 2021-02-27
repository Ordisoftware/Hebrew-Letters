/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class AppTranslations
  {

    static public readonly TranslationsDictionary NoticeKeyboardShortcutsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Keyboard shortcuts notice",
        [Language.FR] = "Notice des raccourcis clavier"
      };

    static public readonly TranslationsDictionary NoticeKeyboardShortcuts
      = new TranslationsDictionary
      {
        [Language.EN] = "Ctrl + Tab : Next view" + Globals.NL +
                        "Shift + Ctrl + Tab : Previous view" + Globals.NL +
                        "F1 : Analyse view" + Globals.NL +
                        "F2 : Settings view" + Globals.NL +
                        "F3 : Search term" + Globals.NL +
                        "Alt + T : Show tools menu" + Globals.NL +
                        "Alt + L : Show web links menu" + Globals.NL +
                        "Alt + I : Show information menu" + Globals.NL +
                        "Alt + S : Show settings menu" + Globals.NL +
                        "Ctrl + M : Open lettriq analysis method notice" + Globals.NL +
                        "Ctrl + G : Open grammar guide" + Globals.NL +
                        "Ctrl + L : Open Shorashon web page" + Globals.NL +
                        "F9 : Preferences" + Globals.NL +
                        "F10 : Log file window" + Globals.NL +
                        "F11 : Usage statistics window" + Globals.NL +
                        "F12 : About" + Globals.NL +
                        "Alt + F4 (ou Escape) : Exit application" + Globals.NL +
                        "Ctrl + Alt + F4 : Exit application",

        [Language.FR] = "Ctrl + Tab : Vue suivante" + Globals.NL +
                        "Maj + Ctrl + Tab : Vue précédente" + Globals.NL +
                        "F1 : Vue d'analyse" + Globals.NL +
                        "F2 : Vue des paramètres" + Globals.NL +
                        "F3 : Recherche d'un terme" + Globals.NL +
                        "Alt + T : Montre le menu des outils" + Globals.NL +
                        "Alt + L : Montre le menu des liens web" + Globals.NL +
                        "Alt + I : Montre le menu des informations" + Globals.NL +
                        "Alt + S : Montre le menu des paramètres" + Globals.NL +
                        "Ctrl + M : Ouvre la notice de la méthode d'analyse lettrique" + Globals.NL +
                        "Ctrl + G : Ouvre le guide de grammaire" + Globals.NL +
                        "Ctrl + L : Ouvre la page web Shorashon" + Globals.NL +
                        "F9 : Préférences" + Globals.NL +
                        "F10 : Fenêtre du fichier log" + Globals.NL +
                        "F11 : Fenêtre des statistiques d'utilisation" + Globals.NL +
                        "Alt + F4 (ou Echap) : Ferme l'application" + Globals.NL +
                        "Ctrl + Alt + F4 : Ferme l'application",
      };

  }

}
