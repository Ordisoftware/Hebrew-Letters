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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly TranslationsDictionary ApplicationDescription = new()
  {
    [Language.EN] = "Lettriq letter-by-letter analyzer of Hebrew words",
    [Language.FR] = "Analyseur lettrique lettre-par-lettre des mots hébreux"
  };

  static public readonly TranslationsDictionary LettersWordMeaningsList = new()
  {
    [Language.EN] = "Meanings of the letters of the word",
    [Language.FR] = "Significations des lettres du mot"
  };

  static public readonly NullSafeDictionary<ViewMode, TranslationsDictionary> CurrentViewText = new()
  {
    [ViewMode.Analysis] = new TranslationsDictionary
    {
      [Language.EN] = "ANALYSIS",
      [Language.FR] = "ANALYSE"
    },
    [ViewMode.Letters] = new TranslationsDictionary
    {
      [Language.EN] = "LETTERS",
      [Language.FR] = "LETTRES"
    },
    [ViewMode.Notebook] = new TranslationsDictionary
    {
      [Language.EN] = "NOTEBOOK",
      [Language.FR] = "CARNET"
    },
  };


}
