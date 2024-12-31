/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// Provides application statistics.
/// </summary>
class ApplicationStatistics
{

  static public readonly ApplicationStatistics Instance = new();

  public string StartingTime
    => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

  public string TranslateTime
    => Program.Settings.BenchmarkTranslate.FormatMilliseconds();

  public string LoadDataTime
    => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

  public string DBLettersCount
    => ApplicationDatabase.Instance.Letters?.Count.ToString() ?? SysTranslations.NullSlot.GetLang();

  public string DBMeaningsCount
    => ApplicationDatabase.Instance.Connection.CountRows(nameof(Letter.Meanings)).ToString();

  public string DBEngine
    => SQLiteNetORM.EngineNameAndVersion;

  public string DBProvider
    => SQLiteNetORM.ProviderName;

  public string DBFileSize
  {
    get
    {
      if ( UpdateDBFileSizeRequired )
      {
        UpdateDBFileSizeRequired = false;
        _DBFileSize = SystemManager.GetFileSize(Globals.ApplicationDatabaseFilePath).FormatBytesSize();
      }
      return _DBFileSize;
    }
  }
  static private string _DBFileSize;
  static internal bool UpdateDBFileSizeRequired { get; set; } = true;

  public string DBMemorySize
  {
    get
    {
      if ( UpdateDBMemorySizeRequired )
      {
        UpdateDBMemorySizeRequired = false;
        long size1 = ApplicationDatabase.Instance.Letters?.SizeOf() ?? 0;
        long size2 = ApplicationDatabase.Instance.Meanings?.SizeOf() ?? 0;
        _DBMemorySize = size1 > 0 && size2 > 0
          ? ( size1 + size2 ).FormatBytesSize()
          : size1 == 0 && size2 == 0
            ? SysTranslations.DatabaseTableClosed.GetLang()
            : "-";
      }
      return _DBMemorySize;
    }
  }
  static private string _DBMemorySize;
  static internal bool UpdateDBMemorySizeRequired { get; set; } = true;

  public string DBCommonFileSize
  {
    get
    {
      if ( UpdateDBCommonFileSizeRequired )
      {
        UpdateDBCommonFileSizeRequired = false;
        _DBCommonFileSize = SystemManager.GetFileSize(Globals.CommonDatabaseFilePath).FormatBytesSize();
      }
      return _DBCommonFileSize;
    }
  }
  static private string _DBCommonFileSize;
  static internal bool UpdateDBCommonFileSizeRequired { get; set; } = true;

  public string DBLettriqsMemorySize
  {
    get
    {
      if ( UpdateDBLettriqsMemorySizeRequired )
      {
        UpdateDBLettriqsMemorySizeRequired = false;
        long size1 = HebrewDatabase.Instance.TermsHebrew?.SizeOf() ?? 0;
        long size2 = HebrewDatabase.Instance.TermLettriqs?.SizeOf() ?? 0;
        long size3 = HebrewDatabase.Instance.TermAnalyzes?.SizeOf() ?? 0;
        _DBLettriqsMemorySize = size1 > 0 && size2 > 0 && size3 > 0
          ? ( size1 + size2 + size3 ).FormatBytesSize()
          : size1 == 0 && size2 == 0 && size3 == 0
            ? SysTranslations.DatabaseTableClosed.GetLang()
            : "-";
      }
      return _DBLettriqsMemorySize;
    }
  }
  static private string _DBLettriqsMemorySize;
  static internal bool UpdateDBLettriqsMemorySizeRequired { get; set; } = true;

}
