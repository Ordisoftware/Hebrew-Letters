/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <edited> 2019-01 </edited>
using System;
using System.Data.Odbc;
using System.Windows.Forms;

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
      var connection = new OdbcConnection(Program.Settings.ConnectionString);
      connection.Open();
      try
      {
        var cmdCheckTable = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                            "WHERE type = 'table' AND name = 'Letters'", connection);
        int result = (int)cmdCheckTable.ExecuteScalar();
        if ( result == 0 )
        {
          var cmdCreateTable = new OdbcCommand(@"CREATE TABLE Letters 
                                                 ( 
                                                   Code text NOT NULL, 
                                                   Name text NOT NULL, 
                                                   Structure text NOT NULL, 
                                                   Function text NOT NULL, 
                                                   ValueSimple integer NOT NULL, 
                                                   ValueFull integer NOT NULL, 
                                                   CONSTRAINT Pk_Letters_Code PRIMARY KEY ( Code ) 
                                                 )", connection);
          cmdCreateTable.ExecuteNonQuery();
        }
        cmdCheckTable = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                        "WHERE type = 'table' AND name = 'Meanings'", connection);
        result = (int)cmdCheckTable.ExecuteScalar();
        if ( result == 0 )
        {
          var cmdCreateTable = new OdbcCommand(@"CREATE TABLE Meanings 
                                                 ( 
                                                   LetterCode text NOT NULL , 
                                                   Meaning text NOT NULL , 
                                                   FOREIGN KEY ( LetterCode ) REFERENCES Letters( Code ) 
                                                 )", connection);
          cmdCreateTable.ExecuteNonQuery();
        }
      }
      finally
      {
        connection.Close();
      }
    }

    /// <summary>
    /// Check if tables are empty or fill them with default values.
    /// </summary>
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
      for ( int index = 0; index < _Codes.Length; index++ )
      {
        var rowLetter = DataSet.Letters.NewLettersRow();
        rowLetter.Code = _Codes[index];
        rowLetter.ValueSimple = _ValuesSimple[index];
        rowLetter.ValueFull = _ValuesFull[index];
        rowLetter.Name = _Names[index];
        rowLetter.Structure = _Structures[index];
        rowLetter.Function = _Functions[index];
        foreach ( var meaning in GetMeanings(index) )
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