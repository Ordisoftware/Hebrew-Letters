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
/// <created> 2019-01 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Data.Odbc;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  partial class MainForm : Form
  {

    private OdbcConnection LockFileConnection;

    /// <summary>
    /// Check if tables and columns exists or create them.
    /// </summary>
    public bool CreateSchemaIfNotExists()
    {
      bool upgraded = false;
      SystemManager.TryCatchManage(() =>
      {
        SQLiteOdbcHelper.CreateOrUpdateDSN();
        LockFileConnection = new OdbcConnection(Settings.ConnectionString);
        LockFileConnection.Open();
        if ( Program.Settings.VacuumAtStartup )
          Program.Settings.VacuumLastDone = LockFileConnection.Optimize(Program.Settings.VacuumLastDone);
        LockFileConnection.CheckTable(@"Letters",
                                      @"CREATE TABLE Letters
                                        ( 
                                          Code TEXT DEFAULT '' NOT NULL, 
                                          Name TEXT DEFAULT '' NOT NULL, 
                                          Hebrew TEXT DEFAULT '' NOT NULL, 
                                          Positive TEXT DEFAULT '' NOT NULL, 
                                          Negative TEXT DEFAULT '' NOT NULL, 
                                          Structure TEXT DEFAULT '' NOT NULL, 
                                          Function TEXT DEFAULT '' NOT NULL, 
                                          Verb TEXT DEFAULT '' NOT NULL,
                                          ValueSimple INTEGER DEFAULT 0 NOT NULL, 
                                          ValueFull INTEGER DEFAULT 0 NOT NULL, 
                                          PRIMARY KEY(Code) 
                                        )");
        string sqlMeanings = @"CREATE TABLE Meanings
                               (
                                 ID TEXT DEFAULT '' NOT NULL, 
                                 LetterCode TEXT DEFAULT '' NOT NULL,
                                 Meaning TEXT DEFAULT '' NOT NULL,
                                 FOREIGN KEY(LetterCode) REFERENCES Letters(Code)
                                 PRIMARY KEY(ID) 
                               )";
        LockFileConnection.CheckTable("Meanings", sqlMeanings);
        if ( !LockFileConnection.CheckColumn("Meanings", "ID") )
          try
          {
            if ( LockFileConnection.CheckTable("Meanings_Temp") )
              new OdbcCommand("DROP TABLE Meanings_Temp", LockFileConnection).ExecuteNonQuery();
            new OdbcCommand("ALTER TABLE Meanings RENAME TO Meanings_Temp", LockFileConnection).ExecuteNonQuery();
            LockFileConnection.CheckTable("Meanings", sqlMeanings);
            var reader = new OdbcCommand("SELECT * FROM Meanings_Temp", LockFileConnection).ExecuteReader();
            while ( reader.Read() )
            {
              var command = new OdbcCommand("INSERT INTO Meanings (ID, LetterCode, Meaning) " +
                                            "VALUES (?,?,?)", LockFileConnection);
              command.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString();
              command.Parameters.Add("@LetterCode", OdbcType.Text).Value = (string)reader["LetterCode"];
              command.Parameters.Add("@Meaning", OdbcType.Text).Value = (string)reader["Meaning"];
              command.ExecuteNonQuery();
            }
          }
          catch ( Exception ex )
          {
            ex.Manage();
          }
          finally
          {
            new OdbcCommand("DROP TABLE Meanings_Temp", LockFileConnection).ExecuteNonQuery();
          }
        string sqlColumn = "ALTER TABLE %TABLE% ADD COLUMN %COLUMN% TEXT DEFAULT '' NOT NULL";
        upgraded = !LockFileConnection.CheckColumn("Letters", "Hebrew", sqlColumn) || upgraded;
        upgraded = !LockFileConnection.CheckColumn("Letters", "Positive", sqlColumn) || upgraded;
        upgraded = !LockFileConnection.CheckColumn("Letters", "Negative", sqlColumn) || upgraded;
      });
      return upgraded;
    }

  }

}
