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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public class HebrewDatabase : SQLiteDatabase
  {

    static new public HebrewDatabase Instance { get; protected set; }

    static HebrewDatabase()
    {
      Instance = new HebrewDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    //public List<ProcessLock> ProcessLocks { get; private set; }

    private HebrewDatabase() : base(Globals.CommonDatabaseFilePath)
    {
      Open();
    }

    protected override void CreateTables()
    {
      // TODO delete old on install new version or use upgrade event to add ID
      Connection.CreateTable<ProcessLock>();
    }

    protected override void LoadAll()
    {
      //Load(Connection.Table<ProcessLock>());
    }

    protected override void DoUpdateAll()
    {
      //UpdateProcessLocks();
    }

    public void UpdateProcessLocks()
    {
      //Connection.UpdateAll(ProcessLocks);
    }

  }

}
