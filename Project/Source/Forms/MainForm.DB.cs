/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2019-08 </edited>
using System;
using System.Data.Odbc;
using System.Globalization;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide SQLite utilities methods.
  /// </summary>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Check if tables exists or create them.
    /// </summary>
    public void CreateDatabaseIfNotExists()
    {
      bool upgraded = false;
      var connection = new OdbcConnection(Program.Settings.ConnectionString);
      connection.Open();
      try
      {
        void checkTable(string table, string sql)
        {
          var command = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                        "WHERE type = 'table' AND name = '" + table + "'", connection);
          int result = (int)command.ExecuteScalar();
          if ( result == 0 )
          {
            var cmdCreateTable = new OdbcCommand(sql, connection);
            cmdCreateTable.ExecuteNonQuery();
          }
        }
        void checkColumn(string table, string column, string sql)
        {
          var command = new OdbcCommand("PRAGMA table_info(" + table + ")", connection);
          var reader = command.ExecuteReader();
          int nameIndex = reader.GetOrdinal("Name");
          bool b = false;
          while ( reader.Read() )
            if ( reader.GetString(nameIndex).Equals(column) )
            {
              b = true;
              break;
            }
          if ( !b )
          {
            var cmdCreateColumn = new OdbcCommand(sql, connection);
            cmdCreateColumn.ExecuteNonQuery();
            upgraded = true;
          }
        }
        checkTable("Letters", @"CREATE TABLE Letters
                                ( 
                                  Code TEXT NOT NULL, 
                                  Name TEXT NOT NULL, 
                                  Negative TEXT NOT NULL, 
                                  Positive TEXT NOT NULL, 
                                  Structure TEXT NOT NULL, 
                                  Function TEXT NOT NULL, 
                                  Verb TEXT NOT NULL,
                                  ValueSimple INTEGER NOT NULL, 
                                  ValueFull INTEGER NOT NULL, 
                                  CONSTRAINT Pk_Letter_Code PRIMARY KEY ( Code ) 
                                )");

        checkTable("Meanings", @"CREATE TABLE Meanings
                                 (
                                   LetterCode TEXT NOT NULL,
                                   Meaning TEXT NOT NULL,
                                   FOREIGN KEY(LetterCode) REFERENCES Letters(Code)
                                 )");
        checkColumn("Letters", "Negative", "ALTER TABLE Letters ADD COLUMN Negative TEXT;");
        checkColumn("Letters", "Positive", "ALTER TABLE Letters ADD COLUMN Positive TEXT;");
      }
      finally
      {
        connection.Close();
        if ( upgraded )
          if ( DisplayManager.QueryYesNo(Localizer.DatabaseChangedText.GetLang()) )
            SetView(ViewModeType.Settings);
      }
    }

    /// <summary>
    /// Check if tables must be filled with default values 
    /// if they are empty or not having 22 rows.
    /// </summary>
    /// <param name="reset">True if force the restoring of default values.</param>
    public void CreateDataIfNotExists(bool reset)
    {
      var connection = new OdbcConnection(Program.Settings.ConnectionString);
      connection.Open();
      var command = new OdbcCommand("SELECT count(*) FROM Letters", connection);
      if ( !reset && (int)command.ExecuteScalar() == 22 ) return;
      command = new OdbcCommand("DELETE FROM Meanings", connection);
      command.ExecuteNonQuery();
      command = new OdbcCommand("DELETE FROM Letters", connection);
      command.ExecuteNonQuery();
      connection.Close();
      MeaningsTableAdapter.Fill(DataSet.Meanings);
      LettersTableAdapter.Fill(DataSet.Letters);

      string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      if ( lang != "fr" && lang != "en" ) lang = "en";
      string data = System.IO.File.ReadAllText(Program.RootPath + "Project\\Data\\Alphabet-" + lang + ".txt",
                                               System.Text.Encoding.Default);
      int indexStart = 0;
      Func<string, string> getStrValue = (name) =>
      {
        int p = data.IndexOf(name, indexStart);
        string s = data.Substring(p + name.Length, data.IndexOf("\r\n", p) - p - name.Length);
        indexStart = data.IndexOf("\r\n", p) + 2;
        return s;
      };
      Func<string, int> getIntValue = (name) =>
      {
        return Convert.ToInt32(getStrValue(name));
      };
      for ( int index = 0; index < Letters.Codes.Length; index++ )
      {
        var rowLetter = DataSet.Letters.NewLettersRow();
        rowLetter.Code = Letters.Codes[index];
        rowLetter.Name = Letters.Names[index];
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
          rowMeaning.LetterCode = rowLetter.Code;
          rowMeaning.Meaning = meaning;
          DataSet.Meanings.AddMeaningsRow(rowMeaning);
        }
        DataSet.Letters.AddLettersRow(rowLetter);
      }
      TableAdapterManager.UpdateAll(DataSet);
    }

  }

}










