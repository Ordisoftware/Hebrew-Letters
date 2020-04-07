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
/// <created> 2016-04 </created>
/// <edited> 2020-03 </edited>
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewLetters
{

  public partial class MainForm
  {

    private void DoAnalyse()
    {
      string word = EditLetters.Input.Text;
      EditSentence.Text = "";
      EditGematria.Text = "";
      EditAnalyze.Controls.Clear();
      int sum = 0;
      int dy = 0;
      SelectedMeanings = "";
      for ( int pos = word.Length - 1; pos >= 0; pos-- )
      {
        var l = DataSet.Letters.FindByCode(Convert.ToString(word[pos]));
        if ( l == null ) continue;
        sum += l.ValueSimple;
        var label = new Label();
        label.Text = l.Name;
        label.AutoSize = false;
        label.Size = new Size(50, 13);
        label.Location = new Point(100, 20 + dy);
        label.TextAlign = ContentAlignment.TopRight;
        EditAnalyze.Controls.Add(label);
        var combobox = new ComboBox();
        combobox.DropDownStyle = ComboBoxStyle.DropDownList;
        combobox.Size = new Size(200, 21);
        combobox.Location = new Point(155, 16 + dy);
        combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
        EditAnalyze.Controls.Add(combobox);
        combobox.Items.Add(l.Positive.Trim());
        combobox.Items.Add(l.Negative.Trim());
        combobox.Items.Add(l.Verb.Trim());
        combobox.Items.Add(l.Structure.Trim());
        combobox.Items.Add(l.Function.Trim());
        SelectedMeanings += l.Name.Trim() + ": ";
        SelectedMeanings += l.Positive.Trim() + ", ";
        SelectedMeanings += l.Negative.Trim() + ", ";
        SelectedMeanings += l.Verb.Trim() + ",";
        SelectedMeanings += l.Structure.Trim() + ", ";
        SelectedMeanings += l.Function.Trim() + ", ";
        foreach ( var meaning in l.GetMeaningsRows() )
        {
          var str = meaning.Meaning.Trim();
          combobox.Items.Add(str);
          SelectedMeanings += str + ", ";
        }
        dy += 30;
        SelectedMeanings = SelectedMeanings.TrimEnd().TrimEnd(',') + Environment.NewLine;
      }
      EditGematria.Text = sum.ToString();
      ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;
    }

  }

}
