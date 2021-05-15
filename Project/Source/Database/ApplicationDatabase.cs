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
      CreateDataIfNotExists(false);
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
      /*if ( !LockFileConnection.CheckColumn("Meanings", "ID") )
        try
        {
          if ( LockFileConnection.CheckTable("Meanings_Temp") )
            new SQLiteCommand("DROP TABLE Meanings_Temp", LockFileConnection).ExecuteNonQuery();
          new SQLiteCommand("ALTER TABLE Meanings RENAME TO Meanings_Temp", LockFileConnection).ExecuteNonQuery();
          LockFileConnection.CheckTable("Meanings", sqlMeanings);
          var reader = new SQLiteCommand("SELECT * FROM Meanings_Temp", LockFileConnection).ExecuteReader();
          while ( reader.Read() )
          {
            var command = new SQLiteCommand("INSERT INTO Meanings (ID, LetterCode, Meaning) " +
                                          "VALUES (?,?,?)", LockFileConnection);
            command.Parameters.Add("@ID", DbType.String).Value = Guid.NewGuid().ToString();
            command.Parameters.Add("@LetterCode", DbType.String).Value = (string)reader["LetterCode"];
            command.Parameters.Add("@Meaning", DbType.String).Value = (string)reader["Meaning"];
            command.ExecuteNonQuery();
          }
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
        finally
        {
          new SQLiteCommand("DROP TABLE Meanings_Temp", LockFileConnection).ExecuteNonQuery();
        }
      string sqlColumn = "ALTER TABLE %TABLE% ADD COLUMN %COLUMN% TEXT DEFAULT '' NOT NULL";
      bool b = Globals.IsDatabaseUpgraded;
      b = !LockFileConnection.CheckColumn("Letters", "Hebrew", sqlColumn) || b;
      b = !LockFileConnection.CheckColumn("Letters", "Positive", sqlColumn) || b;
      b = !LockFileConnection.CheckColumn("Letters", "Negative", sqlColumn) || b;
      Globals.IsDatabaseUpgraded = b;
      });*/
      return false;
    }

    public void CreateDataIfNotExists(bool reset)
    {
      /*try
      {
        var connection = new OdbcConnection(Program.Settings.ConnectionString);
        connection.Open();
        var command = new OdbcCommand("SELECT count(*) FROM Letters", connection);
        if ( !reset && (int)command.ExecuteScalar() == 22 ) return;
        bool temp = Globals.IsReady;
        Globals.IsReady = false;
        try
        {
          command = new OdbcCommand("DELETE FROM Meanings", connection);
          command.ExecuteNonQuery();
          command = new OdbcCommand("DELETE FROM Letters", connection);
          command.ExecuteNonQuery();
          connection.Close();
          MeaningsTableAdapter.Fill(DataSet.Meanings);
          LettersTableAdapter.Fill(DataSet.Letters);
          string data = File.ReadAllText(string.Format(Program.MeaningsFilePath, Languages.CurrentCode.ToUpper()),
                                         System.Text.Encoding.Default);
          int indexStart = 0;
          string getStrValue(string name)
          {
            int p = data.IndexOf(name, indexStart);
            string s = data.Substring(p + name.Length, data.IndexOf("\r\n", p) - p - name.Length);
            indexStart = data.IndexOf("\r\n", p) + 2;
            return s.Trim();
          }
          int getIntValue(string name)
          {
            return Convert.ToInt32(getStrValue(name));
          }
          for ( int index = 0; index < HebrewAlphabet.Codes.Length; index++ )
          {
            var rowLetter = DataSet.Letters.NewLettersRow();
            rowLetter.Code = HebrewAlphabet.Codes[index];
            rowLetter.Name = HebrewAlphabet.Translitterations.GetLang()[index];
            rowLetter.Hebrew = HebrewAlphabet.Names[index];
            rowLetter.ValueSimple = getIntValue("ValueSimple: ");
            rowLetter.ValueFull = getIntValue("ValueFull: ");
            rowLetter.Positive = getStrValue("Positive: ");
            rowLetter.Negative = getStrValue("Negative: ");
            rowLetter.Verb = getStrValue("Verb: ");
            rowLetter.Structure = getStrValue("Structure: ");
            rowLetter.Function = getStrValue("Function: ");
            var meanings = getStrValue("Meanings: ").Split(',');
            foreach ( var meaning in meanings )
            {
              var rowMeaning = DataSet.Meanings.NewMeaningsRow();
              rowMeaning.ID = Guid.NewGuid().ToString();
              rowMeaning.LetterCode = rowLetter.Code;
              rowMeaning.Meaning = meaning.Trim();
              DataSet.Meanings.AddMeaningsRow(rowMeaning);
            }
            DataSet.Letters.AddLettersRow(rowLetter);
          }
          TableAdapterManager.UpdateAll(DataSet);
        }
        finally
        {
          command.Dispose();
          Globals.IsReady = temp;
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }*/
    }

  }

}
