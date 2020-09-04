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
/// <edited> 2020-08 </edited>
using System;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public readonly TranslationsDictionary ApplicationDescription
      = new TranslationsDictionary
      {
        { Language.EN, "Lettriq letter-by-letter study and analysis of Hebrew words" },
        { Language.FR, "Étude et analyse lettrique lettre-par-lettre des mots hébreux" }
      };

    static public readonly TranslationsDictionary AskToRestoreLettersDefaults
      = new TranslationsDictionary
      {
        { Language.EN, "Letters will be restored to their default values." + Globals.NL2 +
                        "All additions will be lost." + Globals.NL2 +
                        Localizer.AskToContinue[Language.EN]
        },
        { Language.FR, "Les lettres vont être restaurées à leurs valeurs par défaut." + Globals.NL2 +
                        "Tous les ajouts seront perdus." + Globals.NL2 +
                        Localizer.AskToContinue[Language.FR]
        }
      };

  }

}
