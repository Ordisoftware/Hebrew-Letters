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
/// <created> 2016-04 </created>
/// <edited> 2019-08 </edited>
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
        combobox.Items.Add(l.Positive);
        combobox.Items.Add(l.Negative);
        combobox.Items.Add(l.Verb);
        combobox.Items.Add(l.Structure);
        combobox.Items.Add(l.Function);
        SelectedMeanings += l.Name + ": ";
        SelectedMeanings += l.Positive + ", ";
        SelectedMeanings += l.Negative + ", ";
        SelectedMeanings += l.Verb + ", ";
        SelectedMeanings += l.Structure + ", ";
        SelectedMeanings += l.Function + ", ";
        foreach ( var meaning in l.GetMeaningsRows() )
        {
          combobox.Items.Add(meaning.Meaning);
          SelectedMeanings += meaning.Meaning + ", ";
        }
        dy += 30;
        try
        {
          SelectedMeanings = SelectedMeanings.Remove(SelectedMeanings.Length - 2, 1);
        }
        catch
        {
        }
        SelectedMeanings += Environment.NewLine;
      }
      EditGematria.Text = sum.ToString();
      ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;
    }

  }

}
