/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
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
/// <created> 2021-02 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static class ProcessLocksTable
  {

    static public readonly string TableName = nameof(ProcessLocksTable).Replace("Table", string.Empty);

    static private void Purge()
    {
      string sqlSelect = $"SELECT ProcessID, count(ProcessID) FROM {TableName} GROUP BY ProcessID";
      foreach ( var item in HebrewDatabase.Instance.Connection.Query<ProcessLock>(sqlSelect) )
      {
        if ( Process.GetProcesses().Any(p => p.Id == item.ProcessID) ) continue;
        string sqlDelete = $"SELECT ID FROM {TableName} WHERE ProcessID = (?)";
        var query = HebrewDatabase.Instance.Connection.Query<ProcessLock>(sqlDelete, item.ProcessID);
        HebrewDatabase.Instance.Connection.BeginTransaction();
        try
        {
          foreach ( ProcessLock row in query )
            HebrewDatabase.Instance.Connection.Delete(row);
          HebrewDatabase.Instance.Connection.Commit();
        }
        catch
        {
          HebrewDatabase.Instance.Connection.Rollback();
          throw;
        }
      }
    }

    static private string Convert(string name = null)
    {
      Purge();
      return name.IsNullOrEmpty() ? Globals.ApplicationCode : name;
    }

    static public bool IsLockedByCurrentProcess(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT Count(ProcessID) FROM {TableName} WHERE ProcessID = (?) AND Name = (?)";
      return HebrewDatabase.Instance.Connection.ExecuteScalar<long>(sql, Globals.ProcessId, name) > 0;
    }

    static public bool IsReadOnly(string name = null)
    {
      return GetCount() > 1;
    }

    static public long GetCount(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT Count(Name) FROM {TableName} WHERE Name = (?)";
      return HebrewDatabase.Instance.Connection.ExecuteScalar<long>(sql, name);
    }

    /*static public List<string> GetLockers(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT ProcessID FROM {TableName} WHERE Name = (?)";
      var dictionary = new Dictionary<string, int>();
      foreach ( var item in HebrewDatabase.Instance.Connection.Query<ProcessLock>(sql, name) )
      {
        var id = item.ProcessID;
        if ( id == Globals.ProcessId ) continue;
        var process = Process.GetProcesses().FirstOrDefault(p => p.Id == id);
        string processName = process?.ProcessName ?? "PID " + id;
        if ( dictionary.ContainsKey(processName) )
          dictionary[processName]++;
        else
          dictionary.Add(processName, 1);
      }
      return dictionary.Select(pair => $"{pair.Key} ({pair.Value})").ToList();
    }*/

    static public void Lock(string name = null)
    {
      if ( IsLockedByCurrentProcess(name) ) return;
      name = Convert(name);
      var item = new ProcessLock { ProcessID = Globals.ProcessId, Name = name };
      HebrewDatabase.Instance.Connection.Insert(item);
    }

    static public void Unlock(string name = null)
    {
      if ( !IsLockedByCurrentProcess(name) ) return;
      name = Convert(name);
      var item = new ProcessLock { ProcessID = Globals.ProcessId, Name = name };
      HebrewDatabase.Instance.Connection.Delete(item.ID);
    }

  }

}
