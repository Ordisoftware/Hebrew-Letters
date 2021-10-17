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
/// <edited> 2021-08 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;
using Equin.ApplicationFramework;

namespace Ordisoftware.Hebrew.Letters
{

  class ApplicationDatabase : SQLiteDatabase
  {

    static new public ApplicationDatabase Instance { get; protected set; }

    static ApplicationDatabase()
    {
      Instance = new ApplicationDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    public List<Letter> Letters { get; private set; }
    public List<Meaning> Meanings { get; private set; }

    public BindingListView<Letter> LettersAsBindingList { get; private set; }

    private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
    {
    }

    public override void Open()
    {
      base.Open();
      if ( Program.Settings.VacuumAtStartup )
      {
        var dateNew = Connection.Optimize(Program.Settings.VacuumLastDone,
                                          Program.Settings.VacuumAtStartupDaysInterval);
        if ( Program.Settings.VacuumLastDone != dateNew )
        {
          HebrewDatabase.Instance.Connection.Optimize(dateNew, force: true);
          Program.Settings.VacuumLastDone = dateNew;
        }
      }
    }

    protected override void DoClose()
    {
      if ( Letters == null && Meanings == null ) return;
      if ( ClearListsOnCloseAndRelease )
      {
        Meanings?.Clear();
        Letters?.Clear();
      }
      Meanings = null;
      Letters = null;
    }

    protected override void CreateTables()
    {
      Connection.CreateTable<Letter>();
      Connection.CreateTable<Meaning>();
    }

    public override void LoadAll()
    {
      base.LoadAll();
      Letters = Connection.Table<Letter>().ToList();
      Meanings = Connection.Table<Meaning>().ToList();
      LettersAsBindingList = new BindingListView<Letter>(Letters);
    }

    protected override void DoSaveAll()
    {
      CheckAccess(Letters, nameof(Letters));
      CheckAccess(Meanings, nameof(Meanings));
      Connection.UpdateAll(Letters);
      Connection.UpdateAll(Meanings);
    }

    public void DeleteAll()
    {
      CheckConnected();
      CheckAccess(Letters, nameof(Letters));
      CheckAccess(Meanings, nameof(Meanings));
      Connection.DeleteAll<Meaning>();
      Connection.DeleteAll<Letter>();
      Meanings.Clear();
      Letters.Clear();
    }

    protected override void UpgradeSchema()
    {
      base.UpgradeSchema();
      if ( Connection.CheckTable(nameof(Meanings)) )
      {
        if ( !Connection.CheckColumn(nameof(Meanings), "ID") )
        {
          MeaningsUpgrade.AddID(Connection);
          Globals.IsDatabaseUpgraded = true;
        }
        string sqlColumn = "ALTER TABLE %TABLE% ADD COLUMN %COLUMN% TEXT DEFAULT '' NOT NULL";
        bool b = Globals.IsDatabaseUpgraded;
        b = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Hebrew), sqlColumn) || b;
        b = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Positive), sqlColumn) || b;
        b = !Connection.CheckColumn(nameof(Letters), nameof(Letter.Negative), sqlColumn) || b;
        Globals.IsDatabaseUpgraded = b;
      }
    }

    public override void CreateDataIfNotExist(bool reset = false)
    {
      base.CreateDataIfNotExist(reset);
      CheckAccess(Letters, nameof(Letters));
      CheckAccess(Meanings, nameof(Meanings));
      try
      {
        if ( !reset && Connection.GetRowsCount(nameof(Letters)) == 22 ) return;
        bool temp = Globals.IsReady;
        Globals.IsReady = false;
        BeginTransaction();
        try
        {
          DeleteAll();
          string data = File.ReadAllText(string.Format(Program.MeaningsFilePath, Languages.CurrentCode.ToUpper()),
                                         System.Text.Encoding.Default);
          int indexStart = 0;
          string getStrValue(string name)
          {
            int p = data.IndexOf(name, indexStart);
            string s = data.Substring(p + name.Length, data.IndexOf(Environment.NewLine, p) - p - name.Length);
            indexStart = data.IndexOf(Environment.NewLine, p) + 2;
            return s.Trim();
          }
          int getIntValue(string name)
          {
            return Convert.ToInt32(getStrValue(name));
          }
          for ( int index = 0; index < HebrewAlphabet.Codes.Length; index++ )
          {
            var rowLetter = new Letter();
            rowLetter.Code = HebrewAlphabet.Codes[index];
            rowLetter.Name = HebrewTranslations.Letters.GetLang()[index];
            rowLetter.Hebrew = HebrewAlphabet.Names[index];
            rowLetter.ValueSimple = getIntValue("ValueSimple: ");
            rowLetter.ValueFull = getIntValue("ValueFull: ");
            rowLetter.Positive = getStrValue("Positive: ");
            rowLetter.Negative = getStrValue("Negative: ");
            rowLetter.Verb = getStrValue("Verb: ");
            rowLetter.Structure = getStrValue("Structure: ");
            rowLetter.Function = getStrValue("Function: ");
            Letters.Add(rowLetter);
            Connection.Insert(rowLetter);
            foreach ( var meaning in getStrValue("Meanings: ").Split(',') )
            {
              var rowMeaning = new Meaning();
              rowMeaning.ID = Guid.NewGuid().ToString();
              rowMeaning.LetterCode = rowLetter.Code;
              rowMeaning.Text = meaning.Trim();
              Meanings.Add(rowMeaning);
              Connection.Insert(rowMeaning);
            }
          }
          Commit();
        }
        catch
        {
          Rollback();
          throw;
        }
        finally
        {
          Globals.IsReady = temp;
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
