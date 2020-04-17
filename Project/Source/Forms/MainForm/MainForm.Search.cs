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
/// <edited> 2020-04 </edited>
using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewLetters
{

  public partial class MainForm
  {

    private string LastTermSearched;

    private void DoSearch()
    {
      string letterName = "";
      var formSearch = new SearchMeaningBox();
      formSearch.EditTerm.Text = LastTermSearched;
      if ( formSearch.ShowDialog() != DialogResult.OK )
        return;
      Func<Data.DataSet.MeaningsRow[], string, bool> contains = (rows, str) =>
      {
        foreach ( var row in rows )
          if ( row.Meaning.ToLower().Contains(str) )
            return true;
        return false;
      };
      LastTermSearched = formSearch.EditTerm.Text;
      string term = LastTermSearched.ToLower();
      var query = from letter in DataSet.Letters
                  where letter.Function.ToLower().Contains(term)
                     || letter.Verb.ToLower().Contains(term)
                     || letter.Structure.ToLower().Contains(term)
                     || letter.Positive.ToLower().Contains(term)
                     || letter.Negative.ToLower().Contains(term)
                     || contains(letter.GetMeaningsRows(), term)
                  select letter;
      if ( query.Count() == 0 )
      {
        MessageBox.Show(Translations.TermNotFound.GetLang(formSearch.EditTerm.Text));
        return;
      }
      if ( query.Count() > 1 )
      {
        var formResults = new SearchTermResultsBox();
        foreach ( var row in query )
          formResults.Listbox.Items.Add(row.Name);
        formResults.Listbox.SelectedItem = formResults.Listbox.Items[0];
        if ( formResults.ShowDialog() == DialogResult.Cancel )
          return;
        letterName = formResults.Listbox.SelectedItem.ToString();
      }
      else
        letterName = query.First().Name;
      LettersBindingSource.Position = LettersBindingSource.Find("Name", letterName);
    }

  }

}
