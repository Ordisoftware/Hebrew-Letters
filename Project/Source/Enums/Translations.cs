/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-09 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLetters
{

  static public class Translations
  {

    static public readonly string NewLine = NewLine;

    static public readonly Dictionary<string, string> ApplicationDescriptionText
      = new Dictionary<string, string>()
      {
        { "en", "A tool for the lettriq study of hebrew words" },
        { "fr", "Un outil pour l'étude lettrique des mots hébreux" }
      };

    static public readonly Dictionary<string, string> ExitApplicationText
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> CheckUpdateNoNewText
      = new Dictionary<string, string>()
      {
        { "en", "There is no new version available." },
        { "fr", "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> CheckUpdateResultText
      = new Dictionary<string, string>()
      {
        { "en", "A newer version is available : " },
        { "fr", "Une nouvelle version est disponible : " }
      };

    static public readonly Dictionary<string, string> CheckUpdateAskDownloadText
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
      };

    static public readonly Dictionary<string, string> DatabaseChangedText
      = new Dictionary<string, string>()
      {
        { "en", "Database upgraded." + NewLine + NewLine +
                "Do you want to open the parameters page to reset them?" },
        { "fr", "La base de données a été mise à jour." + NewLine + NewLine +
                "Voulez-vous ouvrir la page des paramètres pour les réinitialiser ?" }
      };

    static public readonly Dictionary<string, string> RestoreWinPosText
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre"  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> RestoreLettersDefaultText
      = new Dictionary<string, string>()
      {
        { "en", "This will restore all letters to default values." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cela va restaurer les lettres à leurs valeurs par défaut." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

  }

}
