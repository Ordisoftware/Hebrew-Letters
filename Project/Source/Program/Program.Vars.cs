/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Indicates the default Settings instance.
  /// </summary>
  static public readonly Properties.Settings Settings
    = Properties.Settings.Default;

  /// <summary>
  /// Indicates managed image export targets.
  /// </summary>
  static public readonly NullSafeOfStringDictionary<ImageExportTarget> ImageExportTargets
    = ExportHelper.CreateExportTargets<ImageExportTarget>().SetUnsupported(ImageExportTarget.GIF);

  /// <summary>
  /// Indicates application alphabet folder.
  /// </summary>
  static public string MeaningsFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "Alphabet");

  /// <summary>
  /// Indicates file path of the letters meanings.
  /// </summary>
  static public string MeaningsFilePath
    => Path.Combine(MeaningsFolderPath, $"Alphabet-Meanings-{Languages.CurrentCode}.txt");

  /// <summary>
  /// Indicates the grammar guide form.
  /// </summary>
  static public HTMLBrowserForm GrammarGuideForm
  {
    get
    {
      return _GrammarGuideForm ??= new HTMLBrowserForm(HebrewTranslations.GrammarGuideTitle,
                                                       HebrewGlobals.HebrewGrammarGuideFilePath,
                                                       nameof(Settings.GrammarGuideFormLocation),
                                                       nameof(Settings.GrammarGuideFormSize));
    }
  }
  static private HTMLBrowserForm _GrammarGuideForm;

  /// <summary>
  /// Indicates the method notice form.
  /// </summary>
  static public HTMLBrowserForm MethodNoticeForm
  {
    get
    {
      return _MethodGuideForm ??= new HTMLBrowserForm(HebrewTranslations.MethodNoticeTitle,
                                                      HebrewGlobals.LettriqMethodNoticeFilePath,
                                                      nameof(Settings.MethodNoticeFormLocation),
                                                      nameof(Settings.MethodNoticeFormSize));
    }
  }
  static private HTMLBrowserForm _MethodGuideForm;

  /// <summary>
  /// Indicates the command line argument for hebrew word used at startup.
  /// </summary>
  static public string StartupWord
  {
    get
    {
      if ( _StartupWordHebrew.IsNullOrEmpty() )
        try
        {
          string word = ApplicationCommandLine.Instance?.WordHebrew ?? string.Empty;
          if ( word.IsNullOrEmpty()
            && SystemManager.CommandLineArguments?.Length == 1
            && !SystemManager.CommandLineArguments[0].StartsWith("--", StringComparison.Ordinal) )
            word = SystemManager.CommandLineArguments[0];
          word = HebrewAlphabet.ContainsUnicode(word)
                 ? HebrewAlphabet.ToHebrewFont(word)
                 : HebrewAlphabet.OnlyHebrewFont(word);
          _StartupWordHebrew = new string(word.Where(c => c != ' ')
                                              .TakeLast((int)Settings.HebrewTextBoxMaxLength)
                                              .ToArray());
        }
        catch ( Exception ex )
        {
          MessageBox.Show(ex.Message, Globals.AssemblyTitle);
        }
      return _StartupWordHebrew;
    }
  }
  static private string _StartupWordHebrew = string.Empty;

}
