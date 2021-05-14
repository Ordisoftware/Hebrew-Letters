/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
using System.Linq;
using System.Collections.Generic;
using SQLite;

namespace Ordisoftware.Core
{

  public delegate void LoadingDataEventHandler(Type type);
  public delegate void DataLoadedEventHandler();

  public abstract class SQLiteDatabase
  {

    static public SQLiteDatabase Instance { get; protected set; }

    static public string ConnectionString { get; private set; }

    public SQLiteConnection Connection { get; private set; }

    public bool UseTransactionByDefault { get; set; } = true;

    public event Func<bool> CheckSchema;

    public event LoadingDataEventHandler LoadingData;

    public event DataLoadedEventHandler DataLoaded;

    private readonly Dictionary<string, object> Tables;

    protected SQLiteDatabase(string connectionString)
    {
      ConnectionString = connectionString;
      Tables = GetType().GetFields()
                        .Where(field => field.FieldType == typeof(List<>))
                        .Select(field => new { name = field.Name, instance = field.GetValue(null) })
                        .ToDictionary(pair => pair.name, pair => pair.instance);
    }

    public bool Open()
    {
      if ( Connection != null ) return false;
      
      Connection = new SQLiteConnection(ConnectionString);
      CreateTables();
      bool upgraded = CheckSchema?.Invoke() ?? false;
      LoadAll();
      return upgraded;
    }

    public void Close()
    {
      Connection.Close();
      Connection = null;
    }

    protected virtual void CreateTables()
    {
    }

    protected virtual void LoadAll()
    {
    }

    public List<T> Load<T>(TableQuery<T> query)
    {
      LoadingData?.Invoke(typeof(T));
      var result = query.ToList();
      DataLoaded?.Invoke();
      return result;
    }

    public void BeginTransaction()
    {
      Connection.BeginTransaction();
    }

    public void Commit()
    {
      Connection.Commit();
    }

    public void Rollback()
    {
      Connection.Rollback();
    }

    public void UpdateAll()
    {
      UpdateAll(UseTransactionByDefault);
    }

    public void UpdateAll(bool useTransaction)
    {
      if ( !useTransaction )
      {
        DoUpdateAll();
        return;
      }
      Connection.BeginTransaction();
      try
      {
        DoUpdateAll();
        Connection.Commit();
      }
      catch
      {
        Connection.Rollback();
        throw;
      }
    }

    protected virtual void DoUpdateAll()
    {
    }

  }

}
