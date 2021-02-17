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
/// <edited> 2020-04 </edited>
using System;
using System.IO;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate file path of the letters meanings.
    /// </summary>
    static public string MeaningsFilePath
      => Path.Combine(Globals.DocumentsFolderPath, "Alphabet-{0}.txt");

    /// <summary>
    /// Indicate the grammar guide form.
    /// </summary>
    static public HTMLBrowserForm GrammarGuideForm
    {
      get
      {
        if ( _GrammarGuideForm == null )
          _GrammarGuideForm = new HTMLBrowserForm(HebrewTranslations.GrammarGuideTitle,
                                                  OnlineProviders.HebrewGrammarGuideFilePath,
                                                  nameof(Settings.GrammarGuideFormLocation),
                                                  nameof(Settings.GrammarGuideFormSize));
        return _GrammarGuideForm;
      }
    }
    static public HTMLBrowserForm _GrammarGuideForm;

    /// <summary>
    /// Indicate the method notice form.
    /// </summary>
    static public HTMLBrowserForm MethodNoticeForm
    {
      get
      {
        if ( _MethodGuideForm == null )
          _MethodGuideForm = new HTMLBrowserForm(HebrewTranslations.MethodNoticeTitle,
                                                 OnlineProviders.LettriqMethodNoticeFilePath,
                                                 nameof(Settings.MethodNoticeFormLocation),
                                                 nameof(Settings.MethodNoticeFormSize));
        return _MethodGuideForm;
      }
    }
    static public HTMLBrowserForm _MethodGuideForm;

    /// <summary>
    /// Indicate the command line argument for word used at startup.
    /// </summary>
    static public string StartupWord
    {
      // TODO move to cmdlineparser property
      get
      {
        if ( _StartupWord.IsNullOrEmpty() )
          try
          {
            _StartupWord = "";
            string word = ""; // TODO SystemManager.CommandLineOptions.Word;
            if ( word.IsNullOrEmpty() )
              if ( SystemManager.CommandLineArguments != null && SystemManager.CommandLineArguments.Length == 1 )
                word = SystemManager.CommandLineArguments[0];
            if ( !word.IsNullOrEmpty() )
              foreach ( char c in Localizer.RemoveDiacritics(word) )
              {
                string letter = Convert.ToString(c);
                if ( HebrewAlphabet.Codes.Contains(letter) )
                  _StartupWord += HebrewAlphabet.SetFinal(letter, false);
              }
          }
          catch ( Exception ex )
          {
            ex.Manage(ShowExceptionMode.None);
          }
        return _StartupWord;
      }
    }
    static public string _StartupWord;

  }

}
