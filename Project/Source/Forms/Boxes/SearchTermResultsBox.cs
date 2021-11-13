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
/// <created> 2020-03 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;
using System.Collections.Generic;

namespace Ordisoftware.Hebrew.Letters
{

  partial class SearchTermResultsBox : Form
  {

    class LetterItem
    {
      public Letter Letter;
      public override string ToString()
      {
        return Letter.Name;
      }
    }

    static public bool Run(string term, out string code, out string meaning)
    {
      static bool contains(List<Meaning> rows, string str)
      {
        foreach ( var row in rows )
          if ( row.Text.ToLower().RemoveDiacritics().Contains(str) )
            return true;
        return false;
      }
      code = "";
      meaning = "";
      var query = from letter in ApplicationDatabase.Instance.Letters
                  where letter.Function.ToLower().RemoveDiacritics().Contains(term)
                     || letter.Verb.ToLower().RemoveDiacritics().Contains(term)
                     || letter.Structure.ToLower().RemoveDiacritics().Contains(term)
                     || letter.Positive.ToLower().RemoveDiacritics().Contains(term)
                     || letter.Negative.ToLower().RemoveDiacritics().Contains(term)
                     || contains(letter.Meanings, term)
                  select letter;
      if ( !query.Any() )
      {
        DisplayManager.ShowInformation(SysTranslations.TermNotFound.GetLang(term));
        return false;
      }
      var form = new SearchTermResultsBox { Term = term };
      foreach ( var row in query )
        form.ListBoxLetters.Items.Add(new LetterItem() { Letter = row });
      form.ListBoxLetters.SelectedItem = form.ListBoxLetters.Items[0];
      if ( form.ListBoxLetters.Items.Count == 1 && form.ListBoxMeanings.Items.Count == 1 )
      {
        code = ( (LetterItem)form.ListBoxLetters.Items[0] ).Letter.Code;
        meaning = form.ListBoxMeanings.Items[0].ToString();
        return true;
      }
      else
      if ( form.ShowDialog() == DialogResult.OK )
      {
        code = ( (LetterItem)form.ListBoxLetters.SelectedItem ).Letter.Code;
        meaning = form.ListBoxMeanings.SelectedItem.ToString();
        return true;
      }
      return false;
    }

    private string Term;

    public SearchTermResultsBox()
    {
      InitializeComponent();
    }

    private void ListBoxLetters_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      ActionSearch.PerformClick();
    }

    private void ListBoxMeanings_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      ActionSearch.PerformClick();
    }

    private void ListBoxLetters_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBoxMeanings.Items.Clear();
      ActionSearch.Enabled = ListBoxLetters.SelectedItem != null;
      if ( !ActionSearch.Enabled ) return;
      var item = (LetterItem)ListBoxLetters.SelectedItem;
      void check(string meaning)
      {
        if ( meaning.ToLower().RemoveDiacritics().Contains(Term) ) ListBoxMeanings.Items.Add(meaning);
      }
      check(item.Letter.Positive);
      check(item.Letter.Negative);
      check(item.Letter.Verb);
      check(item.Letter.Structure);
      check(item.Letter.Function);
      foreach ( var itemMeaning in item.Letter.Meanings )
        check(itemMeaning.Text);
      ListBoxMeanings.SelectedItem = ListBoxMeanings.Items[0];
    }

    private void ListBoxMeanings_SelectedIndexChanged(object sender, EventArgs e)
    {
      ActionSearch.Enabled = ListBoxLetters.SelectedItem != null && ListBoxMeanings.SelectedItem != null;
    }

    private void ListBox_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.KeyCode == Keys.Left )
      {
        ListBoxLetters.Focus();
        e.Handled = true;
      }
      else
      if ( e.KeyCode == Keys.Right )
      {
        ListBoxMeanings.Focus();
        e.Handled = true;
      }
    }

    private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
      var listbox = sender as ListBox;
      if ( sender == null ) return;
      if ( e.Index < 0 ) return;
      bool selected = ( e.State & DrawItemState.Selected ) == DrawItemState.Selected;
      if ( selected )
        e = new DrawItemEventArgs(e.Graphics,
                                  e.Font,
                                  e.Bounds,
                                  e.Index,
                                  e.State ^ DrawItemState.Selected,
                                  e.ForeColor,
                                  listbox.Focused ? SystemColors.Highlight : SystemColors.ControlDark);

      e.DrawBackground();
      var brush = selected ? SystemBrushes.HighlightText : SystemBrushes.WindowText;
      e.Graphics.DrawString(listbox.Items[e.Index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
      e.DrawFocusRectangle();
    }

  }

}
