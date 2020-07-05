﻿/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2020-07 </edited>
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewLetters
{

  public partial class MainForm
  {

    private void DoAnalyse()
    {
      try
      {
        Cursor = Cursors.WaitCursor;
        EditSentence.Text = "";
        EditGematriaSimple.Text = "";
        EditGematriaFull.Text = "";
        EditAnalyze.Controls.Clear();
        List<string> meaningsWord = new List<string>();
        string word = EditLetters.TextInput;
        int sumSimple = 0;
        int sumFull = 0;
        int dy = 0;
        for ( int pos = word.Length - 1; pos >= 0; pos-- )
        {
          // Letter
          var letter = DataSet.Letters.FindByCode(Convert.ToString(word[pos]));
          if ( letter == null ) continue;
          sumSimple += letter.ValueSimple;
          sumFull += letter.ValueFull;
          // Label
          var label = new Label();
          label.Text = letter.Name;
          label.AutoSize = false;
          label.Size = new Size(50, 13);
          label.Location = new Point(100, 20 + dy);
          label.TextAlign = ContentAlignment.TopRight;
          EditAnalyze.Controls.Add(label);
          // Combobox
          var combobox = new ComboBox();
          combobox.DropDownStyle = ComboBoxStyle.DropDownList;
          combobox.Size = new Size(200, 21);
          combobox.Location = new Point(155, 16 + dy);
          combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
          EditAnalyze.Controls.Add(combobox);
          // Meanings
          var meaningsLetter = new List<string>();
          Action<string> processMeaning = str =>
          {
            combobox.Items.Add(str);
            meaningsLetter.Add(str);
          };
          processMeaning(letter.Positive.Trim());
          processMeaning(letter.Negative.Trim());
          processMeaning(letter.Verb.Trim());
          processMeaning(letter.Structure.Trim());
          processMeaning(letter.Function.Trim());
          var list = letter.GetMeaningsRows().ToList();
          if ( Program.Settings.AutoSortAnalysisMeanings )
            list = list.OrderBy(m => m.Meaning).ToList();
          foreach ( var meaning in list )
            processMeaning(meaning.Meaning.Trim());
          // Loop
          dy += 30;
          meaningsWord.Add(letter.Name + " : " + string.Join(", ", meaningsLetter));
        }
        EditGematriaSimple.Text = sumSimple.ToString();
        EditGematriaFull.Text = sumFull.ToString();
        WordMeanings = string.Join(Environment.NewLine, meaningsWord);
        ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

  }

}
