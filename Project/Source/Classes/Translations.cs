/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2020 Olivier Rogier.
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

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public string NewLine { get { return Environment.NewLine; } }

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { "en", "Lettriq letter-by-letter study of hebrew words" },
        { "fr", "Étude lettrique lettre-par-lettre des mots hébreux" }
      };

    static public readonly Dictionary<string, string> AboutBoxTitle
      = new Dictionary<string, string>()
      {
        { "en", "About {0}" },
        { "fr", "À propos de {0}" }
      };

    static public readonly Dictionary<string, string> AboutBoxVersion
      = new Dictionary<string, string>()
      {
        { "en", "Version {0}" },
        { "fr", "Version {0}" }
      };

    static public readonly Dictionary<string, string> NotYetAvailable
      = new Dictionary<string, string>()
      {
        { "en", "Not yet available." },
        { "fr", "Pas encore disponible." }
      };

    static public readonly Dictionary<string, string> AskToExitApplication
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> NoNewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "There is no new version available." },
        { "fr", "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> NewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "A newer version is available : {0}" },
        { "fr", "Une nouvelle version est disponible : {0}" }
      };

    static public readonly Dictionary<string, string> AskToDownloadNewVersion
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
      };

    static public readonly Dictionary<string, string> FileNotFound
      = new Dictionary<string, string>()
      {
        { "en", "File not found: " + NewLine + NewLine + "{0}" },
        { "fr", "Fichier non trouvé :" + NewLine + NewLine + "{0}" }
      };

    static public readonly Dictionary<string, string> AskToRestoreWindowPosition
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre."  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open all \"{0]\" links?" },
        { "fr", "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { "en", "Preferences will be reseted to their default values." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToCheckLettersAfterDatabaseChanged
      = new Dictionary<string, string>()
      {
        { "en", "Database upgraded." + NewLine + NewLine +
                "Do you want to open the parameters page to check them?" },
        { "fr", "La base de données a été mise à jour." + NewLine + NewLine +
                "Voulez-vous ouvrir la page des paramètres pour les vérifier ?" }
      };

    static public readonly Dictionary<string, string> AskToRestoreLettersDefaults
      = new Dictionary<string, string>()
      {
        { "en", "Letters will be restored to their default values." + NewLine + NewLine +
                "All additions will be lost." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les lettres vont être restaurées à leurs valeurs par défaut." + NewLine + NewLine +
                "Tous les ajouts seront perdus." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> TermNotFound
      = new Dictionary<string, string>()
      {
        { "en", "{0} not found." },
        { "fr", "{0} non trouvé." }
      };

    static public readonly Dictionary<string, string> GrammarGuideTitle
      = new Dictionary<string, string>()
      {
        { "en", "Grammar guide" },
        { "fr", "Guide de grammaire" }
      };

    static public readonly Dictionary<string, string> MethodNoticeTitle
      = new Dictionary<string, string>()
      {
        { "en", "Lettriq analysis method notice" },
        { "fr", "Notice de la méthode d'analyse lettrique" }
      };

  }

}
