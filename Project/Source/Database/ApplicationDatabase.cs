﻿/// <license>
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

namespace Ordisoftware.Hebrew.Letters
{

  public class ApplicationDatabase : SQLiteDatabase
  {

    static new public ApplicationDatabase Instance { get; protected set; }

    static ApplicationDatabase()
    {
      Instance = new ApplicationDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    public List<Letter> Letters { get; private set; }
    public List<Meaning> Meanings { get; private set; }

    private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
    {
    }

    public override bool Open()
    {
      bool result = base.Open();
      if ( Program.Settings.VacuumAtStartup )
        Program.Settings.VacuumLastDone = Connection.Optimize(Program.Settings.VacuumLastDone);
      return result;
    }

    protected override void CreateTables()
    {
      Connection.CreateTable<Letter>();
      Connection.CreateTable<Meaning>();
    }

    public override void LoadAll()
    {
      Letters = Load(Connection.Table<Letter>());
      Meanings = Load(Connection.Table<Meaning>());
    }

    protected override void DoSaveAll()
    {
      Connection.UpdateAll(Letters);
      Connection.UpdateAll(Meanings);
    }

    public override bool UpgradeSchema()
    {
      return false;
    }

  }

}