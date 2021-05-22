/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-04 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Provide application statistics.
  /// </summary>
  class ApplicationStatistics
  {

    static public readonly ApplicationStatistics Instance
      = new ApplicationStatistics();

    public string StartingTime
      => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

    public string TranslateTime
      => Program.Settings.BenchmarkTranslate.FormatMilliseconds();

    public string LoadDataTime
      => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

    public string DBLettersCount
      => ApplicationDatabase.Instance.Letters.Count.ToString();

    public string DBMeaningsCount
      => ApplicationDatabase.Instance.Connection.GetRowsCount(nameof(Letter.Meanings)).ToString();

    public string DBEngine
      => SQLiteNetHelper.EngineNameAndVersion;

    public string DBProvider
      => SQLiteNetHelper.ProviderName;

    public string DBFileSize
    {
      get
      {
        if ( UpdateDBFileSizeRequired )
        {
          UpdateDBFileSizeRequired = false;
          _DBFileSize = SystemManager.GetFileSize(Globals.ApplicationDatabaseFilePath).FormatBytesSize().ToString();
        }
        return _DBFileSize;
      }
    }
    static private string _DBFileSize;
    static internal bool UpdateDBFileSizeRequired { get; set; } = true;

    /*public string DBMemorySize
    {
      get
      {
        if ( UpdateDBMemorySizeRequired )
        {
          UpdateDBMemorySizeRequired = false;
          _DBMemorySize = ( ApplicationDatabase.Instance.Letters.SizeOf() +
                            ApplicationDatabase.Instance.Meanings.SizeOf() ).FormatBytesSize();
        }
        return _DBMemorySize;
      }
    }
    static private string _DBMemorySize;
    static internal bool UpdateDBMemorySizeRequired { get; set; } = true;*/

    public string DBCommonFileSize
    {
      get
      {
        if ( UpdateDBCommonFileSizeRequired )
        {
          UpdateDBCommonFileSizeRequired = false;
          _DBCommonFileSize = SystemManager.GetFileSize(Globals.CommonDatabaseFilePath).FormatBytesSize().ToString();
        }
        return _DBCommonFileSize;
      }
    }
    static private string _DBCommonFileSize;
    static internal bool UpdateDBCommonFileSizeRequired { get; set; } = true;

  }

}
