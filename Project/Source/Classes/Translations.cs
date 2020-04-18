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
/// <edited> 2004-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public string NewLine = HebrewCommon.Globals.NewLine;

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { "en", "Lettriq letter-by-letter study of hebrew words" },
        { "fr", "Étude lettrique lettre-par-lettre des mots hébreux" }
      };

    static public readonly Dictionary<string, string> MethodNoticeTitle
      = new Dictionary<string, string>()
      {
        { "en", "Lettriq analysis method notice" },
        { "fr", "Notice de la méthode d'analyse lettrique" }
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

  }

}
