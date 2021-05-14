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
/// <created> 2021-05 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  public delegate void LoadingDataEventHandler(Type type);
  public delegate void DataLoadedEventHandler();

  public class Database
  {

    static public readonly Database Instance = new Database();

    public SQLiteConnection Connection { get; private set; }
    public bool UseTransactionByDefault { get; set; } = true;

    public List<Letter> Letters { get; private set; }
    public List<Meaning> Meanings { get; private set; }

    public event LoadingDataEventHandler LoadingData;
    public event DataLoadedEventHandler DataLoaded;

    private Database()
    {
    }

    public void Open()
    {
      Connection = new SQLiteConnection(Globals.DatabaseFilePath);
      CreateTables();
      LoadData();
    }

    private void CreateTables()
    {
      Connection.CreateTable<Letter>();
      Connection.CreateTable<Meaning>();
    }

    private void LoadData()
    {
      Letters = ToListWithProgress(Connection.Table<Letter>());
      Meanings = ToListWithProgress(Connection.Table<Meaning>());
    }

     public List<T> ToListWithProgress<T>(TableQuery<T> query)
    {
      LoadingData?.Invoke(typeof(T));
      var result = query.ToList();
      DataLoaded?.Invoke();
      return result;
    }

    public void Close()
    {
      Connection.Close();
      Connection = null;
    }

    public void BeginTransaction() => Connection.BeginTransaction();

    public void Commit() => Connection.Commit();

    public void Rollback() => Connection.Rollback();

    public void UpdateAll() => UpdateAll(UseTransactionByDefault);

    public void UpdateAll(bool useTransaction)
    {
      if ( useTransaction ) Connection.BeginTransaction();
      try
      {
        Connection.UpdateAll(Letters);
        Connection.UpdateAll(Meanings);
        if ( useTransaction ) Connection.Commit();
      }
      catch ( Exception ex )
      {
        if ( useTransaction ) Connection.Rollback();
        throw;
      }
    }

  }

}

