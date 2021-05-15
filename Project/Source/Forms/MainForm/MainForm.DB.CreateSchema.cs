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
/// <edited> 2021-05 </edited>
using System;
using System.Data;
using SQLite;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    /// <summary>
    /// Indicate persistent database connection.
    /// </summary>
    private SQLiteConnection LockFileConnection;

    /// <summary>
    /// Check if tables and columns exists or create them.
    /// </summary>
    public void CreateSchemaIfNotExists()
    {
      SystemManager.TryCatchManage(() =>
      {
        LockFileConnection = ApplicationDatabase.Instance.Connection; //new SQLiteConnection(Globals.ApplicationSQLiteConnectionString);

        
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
        Globals.IsDatabaseUpgraded = b;*/
      });
    }

  }

}
