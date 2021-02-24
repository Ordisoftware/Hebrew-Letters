﻿/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  public partial class MainForm
  {

    private object[][] LettersMeanings = new object[400 + 1][];

    private void DoAnalyse()
    {
      try
      {
        EditAnalyze.Controls.Clear();
        EditSentence.Text = "";
        EditGematriaSimple.Text = "";
        EditGematriaFull.Text = "";
        int sumSimple = 0;
        int sumFull = 0;
        int dy = 0;
        string word = EditLetters.Input.Text;
        var meaningsWord = new string[EditLetters.Input.TextLength];
        for ( int pos = word.Length - 1, index = 0; pos >= 0; index++, pos-- )
        {
          // Letter
          var letter = DataSet.Letters.FindByCode(word[pos].ToString());
          if ( letter == null ) continue;
          sumSimple += letter.ValueSimple;
          sumFull += letter.ValueFull;
          // Label
          var label = new Label();
          label.TextAlign = ContentAlignment.TopRight;
          label.AutoSize = false;
          label.Width = 50;
          label.Height = 13;
          label.Left = 100;
          label.Top = 20 + dy;
          label.Text = letter.Name;
          EditAnalyze.Controls.Add(label);
          // Combobox
          var combobox = new ComboBox();
          label.Tag = combobox;
          combobox.Width = 200;
          combobox.Height = 21;
          combobox.Left = 155;
          combobox.Top = 16 + dy;
          combobox.DropDownStyle = ComboBoxStyle.DropDownList;
          combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
          combobox.Enter += Combobox_Enter;
          // Meanings
          if ( LettersMeanings[letter.ValueSimple] == null )
          {
            int indexMeaning = 0;
            var rowsMeanings = letter.GetMeaningsRows();
            LettersMeanings[letter.ValueSimple] = new object[rowsMeanings.Length + 5];
            LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Positive;
            LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Negative;
            LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Verb;
            LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Structure;
            LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Function;
            if ( Program.Settings.AutoSortAnalysisMeanings )
              Array.Sort(rowsMeanings, (x, y) => x.Meaning.CompareTo(y.Meaning));
            foreach ( var meaning in rowsMeanings )
              LettersMeanings[letter.ValueSimple][indexMeaning++] = meaning.Meaning;
          }
          combobox.Tag = LettersMeanings[letter.ValueSimple];
          EditAnalyze.Controls.Add(combobox);
          // Loop
          dy += 30;
        }
        EditGematriaSimple.Text = sumSimple.ToString();
        EditGematriaFull.Text = sumFull.ToString();
        ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;
        ActionSnapshot.Enabled = ActionCopyToClipboardMeanings.Enabled;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    private void Combobox_Enter(object sender, EventArgs e)
    {
      var combobox = (ComboBox)sender;
      if ( combobox.Items.Count > 0 ) return;
      combobox.Items.AddRange((object[])combobox.Tag);
    }

    /*
    private AnalysisItems AnalysisItems = new AnalysisItems();
   
    public class AnalysisItem
    {
      public Data.DataSet.LettersRow Letter;
      public Label Label;
      public ComboBox ComboBox;
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
    }*/

    /*private void DoAnalyse()
      {
        try
        {
          Cursor = Cursors.WaitCursor;
          EditSentence.Text = "";
          EditGematriaSimple.Text = "";
          EditGematriaFull.Text = "";

          EditAnalyze.Controls.Clear();

          string word = EditLetters.Input.Text;
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
              processMeaning(letter.Positive);
              processMeaning(letter.Negative);
              processMeaning(letter.Verb);
              processMeaning(letter.Structure);
              processMeaning(letter.Function);
              var list = letter.GetMeaningsRows().ToList();
              if ( Program.Settings.AutoSortAnalysisMeanings )
                list = list.OrderBy(m => m.Meaning).ToList();
              foreach ( var meaning in list )
                processMeaning(meaning.Meaning);
              item.Meaning = letter.Name + " : " + string.Join(", ", meanings);
            }
            // Loop
            dy += 30;
          }
          EditGematriaSimple.Text = sumSimple.ToString();
          EditGematriaFull.Text = sumFull.ToString();
          WordMeanings = string.Join(Globals.NL, AnalysisItems.Meanings);
          ActionCopyToClipboardMeanings.Enabled = EditAnalyze.Controls.Count > 0;
          ActionSnapshot.Enabled = ActionCopyToClipboardMeanings.Enabled;

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
      }*/

  }

}
