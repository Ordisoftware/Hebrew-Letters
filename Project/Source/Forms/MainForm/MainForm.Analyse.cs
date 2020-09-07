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
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  public class AnalysisItem
  {
    public Data.DataSet.LettersRow Letter { get; set; }
    public Label Label { get; set; }
    public ComboBox ComboBox { get; set; }
    public string Meaning;
  }

  public class AnalysisItems : List<AnalysisItem>
  {
    public IEnumerable<Label> Labels 
    {
      get
      {
        foreach ( var item in this )
          yield return item.Label;
      }
    }
    public IEnumerable<ComboBox> ComboBoxes
    {
      get
      {
        foreach ( var item in this )
          yield return item.ComboBox;
      }
    }
    public IEnumerable<string> Meanings
    {
      get
      {
        foreach ( var item in this )
          yield return item.Meaning;
      }
    }
  }

  public partial class MainForm
  {

    private AnalysisItems AnalysisItems = new AnalysisItems();

    private void DoAnalyse()
    {
      try
      {
        Cursor = Cursors.WaitCursor;
        EditSentence.Text = "";
        EditGematriaSimple.Text = "";
        EditGematriaFull.Text = "";

        EditAnalyze.Controls.Clear();

        string word = EditLetters.InputText;
        int sumSimple = 0;
        int sumFull = 0;
        int dy = 0;
        if ( AnalysisItems.Count > word.Length)
          AnalysisItems.RemoveRange(word.Length, AnalysisItems.Count - word.Length);
        if ( AnalysisItems.Count < word.Length )
          AnalysisItems.AddRange(Enumerable.Repeat(new AnalysisItem(), word.Length - AnalysisItems.Count));
        for ( int pos = word.Length - 1; pos >= 0; pos-- )
        {
          // Letter
          var letter = DataSet.Letters.FindByCode(Convert.ToString(word[pos]));
          if ( letter == null ) continue;
          var item = AnalysisItems[pos];
          sumSimple += letter.ValueSimple;
          sumFull += letter.ValueFull;
          if ( item.Letter != letter )
          {
            // Label
            var label = new Label();
            label.Text = letter.Name;
            label.AutoSize = false;
            label.Size = new Size(50, 13);
            label.Location = new Point(100, 20 + dy);
            label.TextAlign = ContentAlignment.TopRight;
            item.Label = label;
            // Combobox
            var combobox = new ComboBox();
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.Size = new Size(200, 21);
            combobox.Location = new Point(155, 16 + dy);
            combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
            item.ComboBox = combobox;
            // Meanings
            var meanings = new List<string>();
            Action<string> processMeaning = str =>
            {
              combobox.Items.Add(str);
              meanings.Add(str);
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
            item.Meaning = letter.Name + " : " + string.Join(", ", meanings);
          }
          // Loop
          dy += 30;
        }
        EditGematriaSimple.Text = sumSimple.ToString();
        EditGematriaFull.Text = sumFull.ToString();
        WordMeanings = string.Join(Globals.NL, AnalysisItems.Meanings);
        ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;

        EditAnalyze.Controls.AddRange(AnalysisItems.Labels.ToArray());
        EditAnalyze.Controls.AddRange(AnalysisItems.ComboBoxes.ToArray());
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
