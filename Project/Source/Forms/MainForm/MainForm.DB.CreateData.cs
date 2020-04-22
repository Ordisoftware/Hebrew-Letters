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
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewLetters
{

  public partial class MainForm : Form
  {

    /// <summary>
    /// Check if tables must be filled with default values 
    /// if they are empty or not having 22 rows.
    /// </summary>
    /// <param name="reset">True if force the restoring of default values.</param>
    public void CreateDataIfNotExists(bool reset)
    {
      try
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
          string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
          if ( lang != "fr" && lang != "en" ) lang = "en";
          string data = File.ReadAllText(Program.MeaningsFilename.Replace("%LANG%", Localizer.Language),
                                         System.Text.Encoding.Default);
          int indexStart = 0;
          Func<string, string> getStrValue = (name) =>
          {
            int p = data.IndexOf(name, indexStart);
            string s = data.Substring(p + name.Length, data.IndexOf("\r\n", p) - p - name.Length);
            indexStart = data.IndexOf("\r\n", p) + 2;
            return s.Trim();
          };
          Func<string, int> getIntValue = (name) =>
          {
            return Convert.ToInt32(getStrValue(name));
          };
          for ( int index = 0; index < HebrewAlphabet.Codes.Length; index++ )
          {
            var rowLetter = DataSet.Letters.NewLettersRow();
            rowLetter.Code = HebrewAlphabet.Codes[index];
            rowLetter.Name = HebrewAlphabet.Names.GetLang()[index];
            rowLetter.Hebrew = HebrewAlphabet.HebrewFontNames[index];
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