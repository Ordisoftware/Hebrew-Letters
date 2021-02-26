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
/// <created> 2016-04 </created>
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

    static public readonly TranslationsDictionary ApplicationDescription
      = new TranslationsDictionary
      {
        [Language.EN] = "Lettriq letter-by-letter analyzer of Hebrew words",
        [Language.FR] = "Analyseur lettrique lettre-par-lettre des mots hébreux"
      };

    static public readonly TranslationsDictionary ReadOnly
      = new TranslationsDictionary
      {
        [Language.EN] = "Read only",
        [Language.FR] = "Lecture seule"
      };

  }

}
