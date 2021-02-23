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
/// <edited> 2020-11 </edited>
using System;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// provide application statistics.
  /// </summary>
  public class ApplicationStatistics
  {

    static public ApplicationStatistics Instance
      = new ApplicationStatistics();

    public string StartingTime
      => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

    public string LoadDataTime
      => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

    public string DBLettersCount
      => MainForm.Instance.DataSet.Letters.Count().ToString();

    public string DBMeaningsCount
      => MainForm.Instance.DataSet.Meanings.Count().ToString();

    public string DBEngine
      => SQLiteOdbcHelper.EngineNameAndVersion;

    public string DBADOdotNETProvider
      => SQLiteOdbcHelper.ADOdotNETProviderName;

    public string DBFileSize
    {
      get
      {
        if ( UpdateDBFileSizeRequired )
        {
          UpdateDBFileSizeRequired = false;
          _DBFileSize = SystemManager.GetFileSize(Globals.DatabaseFilePath).FormatBytesSize().ToString();
        }
        return _DBFileSize;
      }
    }
    static private string _DBFileSize;
    static internal bool UpdateDBFileSizeRequired = true;

    public string DBMemorySize
    {
      get
      {
        if ( UpdateDBMemorySizeRequired )
        {
          UpdateDBMemorySizeRequired = false;
          _DBMemorySize = MainForm.Instance.DataSet.SizeOf().FormatBytesSize();
        }
        return _DBMemorySize;
      }
    }
    static private string _DBMemorySize;
    static internal bool UpdateDBMemorySizeRequired = true;

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
    static internal bool UpdateDBCommonFileSizeRequired = true;

  }

}
