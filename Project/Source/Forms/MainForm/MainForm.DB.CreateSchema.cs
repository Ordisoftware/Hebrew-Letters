/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.Data.Odbc;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewLetters
{

  public partial class MainForm : Form
  {

    /// <summary>
    /// Check if tables and columns exists or create them.
    /// </summary>
    public bool CreateSchemaIfNotExists()
    {
      bool upgraded = false;
      var connection = new OdbcConnection(Program.Settings.ConnectionString);
      connection.Open();
      if ( Program.Settings.VacuumAtStartup )
      {
        connection.CheckIntegrity();
        connection.Vacuum();
      }
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
            if ( sql != "" )
            {
              var cmdCreateColumn = new OdbcCommand(sql, connection);
              cmdCreateColumn.ExecuteNonQuery();
            }
            upgraded = true;
          }
        }
        checkTable("Letters", @"CREATE TABLE Letters
                                ( 
                                  Code TEXT NOT NULL, 
                                  Name TEXT NOT NULL, 
                                  Hebrew TEXT NOT NULL, 
                                  Negative TEXT NOT NULL, 
                                  Positive TEXT NOT NULL, 
                                  Structure TEXT NOT NULL, 
                                  Function TEXT NOT NULL, 
                                  Verb TEXT NOT NULL,
                                  ValueSimple INTEGER NOT NULL, 
                                  ValueFull INTEGER NOT NULL, 
                                  CONSTRAINT Pk_Letter_Code PRIMARY KEY (Code) 
                                )");
        string sqlCreateMeanings = @"CREATE TABLE Meanings
                                     (
                                       ID TEXT NOT NULL, 
                                       LetterCode TEXT NOT NULL,
                                       Meaning TEXT DEFAULT '' NOT NULL,
                                       FOREIGN KEY(LetterCode) REFERENCES Letters(Code)
                                       CONSTRAINT Pk_Meaning_ID PRIMARY KEY ( ID ) 
                                     )";
        checkTable("Meanings", sqlCreateMeanings);
        checkColumn("Meanings", "ID", "");
        if ( upgraded )
          try
          {
            OdbcCommand command;
            try
            {
              command = new OdbcCommand("ALTER TABLE Meanings RENAME TO Meanings_Temp", connection);
              command.ExecuteNonQuery();
              checkTable("Meanings", sqlCreateMeanings);
              command = new OdbcCommand("SELECT * FROM Meanings_Temp", connection);
              var reader = command.ExecuteReader();
              while ( reader.Read() )
              {
                var cmd = new OdbcCommand("INSERT INTO Meanings (ID, LetterCode, Meaning) " +
                                          "VALUES (?,?,?)", connection);
                cmd.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString();
                cmd.Parameters.Add("@LetterCode", OdbcType.Text).Value = (string)reader["LetterCode"];
                cmd.Parameters.Add("@Meaning", OdbcType.Text).Value = (string)reader["Meaning"];
                cmd.ExecuteNonQuery();
              }
            }
            finally
            {
              new OdbcCommand("DROP TABLE Meanings_Temp", connection).ExecuteNonQuery();
            }
          }
          catch (Exception ex)
          {
            ex.Manage();
          }
        upgraded = false;
        checkColumn("Letters", "Hebrew", "ALTER TABLE Letters ADD COLUMN Hebrew TEXT DEFAULT '' NOT NULL");
        checkColumn("Letters", "Positive", "ALTER TABLE Letters ADD COLUMN Positive TEXT DEFAULT '' NOT NULL");
        checkColumn("Letters", "Negative", "ALTER TABLE Letters ADD COLUMN Negative TEXT DEFAULT '' NOT NULL");
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
      finally
      {
        connection.Close();
      }
      return upgraded;
    }

  }

}
