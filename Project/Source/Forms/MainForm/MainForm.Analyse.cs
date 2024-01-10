/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2022-07 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  static private readonly int LettersMeaningsCount = HebrewAlphabet.ValuesSimple.Max() + 1;

  private readonly object[][] LettersMeanings = new object[LettersMeaningsCount][];

  private void ClearLettersMeanings()
  {
    for ( int index = 0; index < LettersMeanings.GetUpperBound(0); index++ )
      LettersMeanings[index] = null;
  }

  private void DoAnalyse()
  {
    try
    {
      SelectAnalyze.Controls.Clear();
      EditSentence.Text = string.Empty;
      EditWord.EditGematriaSimple.Text = string.Empty;
      EditWord.EditGematriaFull.Text = string.Empty;
      const int marginTop = 20;
      const int marginLeft = 5;
      const int marginCombo = 15;
      const int labelWidth = 50;
      const int comboWidth = 170;
      const int comboLeft = marginLeft + labelWidth + marginCombo;
      const int comboHeightDelta = -4;
      const int dummyDelta = 10;
      const int dummyHeightDelta = -2;
      const int deltaY = 30;
      int sumSimple = 0;
      int sumFull = 0;
      int dy = 0;
      string word = EditWord.TextBox.Text;
      for ( int pos = word.Length - 1, index = 0; pos >= 0; index++, pos-- )
      {
        int top = marginTop + dy;
        // Letter
        string theword = word[pos].ToString();
        var letter = DBApp.Letters.Find(l => l.Code == theword);
        if ( letter is null ) continue;
        sumSimple += letter.ValueSimple;
        sumFull += letter.ValueFull;
        // Label
        var label = new Label
        {
          TextAlign = ContentAlignment.TopRight,
          AutoSize = false,
          Width = labelWidth,
          Left = marginLeft,
          Top = top,
          Text = letter.Name,
          Cursor = Cursors.Hand
        };
        label.Click += LabelLetter_Click;
        SelectAnalyze.Controls.Add(label);
        // Combo box
        var combobox = new ComboBoxEx
        {
          Width = comboWidth,
          Left = comboLeft,
          Top = top + comboHeightDelta,
          DropDownStyle = ComboBoxStyle.DropDownList
        };
        combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
        combobox.Enter += Combobox_Enter;
        label.Tag = combobox;
        // Meanings
        if ( LettersMeanings[letter.ValueSimple] is null )
        {
          int indexMeaning = 0;
          var rowsMeanings = letter.Meanings.ToArray();
          LettersMeanings[letter.ValueSimple] = new object[rowsMeanings.Length + 6];
          LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Positive;
          LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Negative;
          LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Verb;
          LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Structure;
          LettersMeanings[letter.ValueSimple][indexMeaning++] = letter.Function;
          LettersMeanings[letter.ValueSimple][indexMeaning++] = Globals.ListSeparator;
          if ( Settings.AutoSortAnalysisMeanings )
            Array.Sort(rowsMeanings, (x, y) => x.Text.CompareTo(y.Text));
          foreach ( var meaning in rowsMeanings )
            LettersMeanings[letter.ValueSimple][indexMeaning++] = meaning.Text;
        }
        combobox.Tag = letter;
        SelectAnalyze.Controls.Add(combobox);
        // Loop
        dy += deltaY;
      }
      var dummy = new Label
      {
        AutoSize = false,
        Left = dummyDelta,
        Width = dummyDelta,
        Top = dy + dummyHeightDelta,
        Text = string.Empty
      };
      SelectAnalyze.Controls.Add(dummy);
      EditWord.EditGematriaSimple.Text = sumSimple.ToString();
      EditWord.EditGematriaFull.Text = sumFull.ToString();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  private void LabelLetter_Click(object sender, EventArgs e)
  {
    var label = (Label)sender;
    var combobox = (ComboBox)label.Tag;
    var letter = (Letter)combobox.Tag;
    ActionViewLetters.PerformClick();
    SelectLetter.SelectedIndex = SelectLetter.FindStringExact(letter.Code);
  }

  private void Combobox_Enter(object sender, EventArgs e)
  {
    var combobox = (ComboBox)sender;
    if ( combobox.Items.Count > 0 ) return;
    combobox.Items.AddRange(LettersMeanings[( (Letter)combobox.Tag ).ValueSimple]);
  }

}

/*
private AnalysisItems AnalysisItems = new AnalysisItems();

class AnalysisItem
{
  public Data.DataSet.LettersRow Letter;
  public Label Label;
  public ComboBox ComboBox;
  public string Meaning;
}

class AnalysisItems : List<AnalysisItem>
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
*/
