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
/// <edited> 2021-05 </edited>
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
                        "F1 : Analysis view" + Globals.NL +
                        "F2 : Settings view" + Globals.NL +
                        "F3 : Notebook view" + Globals.NL +
                        "F5 (or Ctrl + F) : Search" + Globals.NL +
                        "Ctrl + Home : First letter" + Globals.NL +
                        "Ctrl + End : Last letter" + Globals.NL +
                        "Ctrl + PageUp : Previous letter" + Globals.NL +
                        "Ctrl + PageDn : Next letter" + Globals.NL +
                        "Ctrl + Ins (or +) : Add meaning" + Globals.NL +
                        "Ctrl + Del (or -) : Delete meaning" + Globals.NL +
                        "Ctrl + S : Save changes" + Globals.NL +
                        "Ctrl + Back : Cancel changes" + Globals.NL +
                        "Ctrl + M : Lettriq analysis method notice" + Globals.NL +
                        "Ctrl + G : Grammar guide" + Globals.NL +
                        "Alt + N : New window" + Globals.NL +
                        "Alt + T : Tools menu" + Globals.NL +
                        "Alt + L : Web links menu" + Globals.NL +
                        "Alt + I : Information menu" + Globals.NL +
                        "Alt + S : Settings menu" + Globals.NL +
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
                        "F3 : Vue du carnet" + Globals.NL +
                        "F5 (ou Ctrl + F) : Recherche" + Globals.NL +
                        "Ctrl + Début : Première lettre" + Globals.NL +
                        "Ctrl + Fin : Dernière lettre" + Globals.NL +
                        "Ctrl + PagePrec : Letter précédente" + Globals.NL +
                        "Ctrl + PageSuiv : Letter suivante" + Globals.NL +
                        "Ctrl + Ins (ou +) : Ajoute une signification" + Globals.NL +
                        "Ctrl + Suppr (ou -) : Efface une signification" + Globals.NL +
                        "Ctrl + S : Sauve les changements" + Globals.NL +
                        "Ctrl + Back : Annule les changements" + Globals.NL +
                        "Ctrl + M : Notice de la méthode d'analyse lettrique" + Globals.NL +
                        "Ctrl + G : Guide de grammaire" + Globals.NL +
                        "Alt + N : Nouvelle fenêtre" + Globals.NL +
                        "Alt + T : Menu des outils" + Globals.NL +
                        "Alt + L : Menu des liens web" + Globals.NL +
                        "Alt + I : Menu des informations" + Globals.NL +
                        "Alt + S : Menu des paramètres" + Globals.NL +
                        "F9 : Préférences" + Globals.NL +
                        "F10 : Fenêtre du fichier log" + Globals.NL +
                        "F11 : Fenêtre des statistiques d'utilisation" + Globals.NL +
                        "Alt + F4 (ou Echap) : Ferme l'application" + Globals.NL +
                        "Ctrl + Alt + F4 : Ferme l'application",
      };

  }

}
