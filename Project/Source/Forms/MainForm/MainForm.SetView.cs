/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2024 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private int SavedSelectionStart;
  private int SavedSelectionLength;
  private bool ViewNotebookFirstTime = true;

  /// <summary>
  /// Sets the view panel.
  /// </summary>
  /// <param name="view">The view mode.</param>
  /// <param name="first">true to first.</param>
  public void SetView(ViewMode view, bool first = false)
  {
    if ( Settings.CurrentView == view && !first ) return;
    if ( Settings.CurrentView == ViewMode.Letters )
      ViewConnectors[Settings.CurrentView].Focused.Focus();
    ViewConnectors[Settings.CurrentView].Component.Checked = false;
    ViewConnectors[Settings.CurrentView].Panel.Parent = null;
    ViewConnectors[view].Component.Checked = true;
    ViewConnectors[view].Panel.Parent = PanelMainCenter;
    ViewConnectors[view].Focused.Focus();
    Settings.CurrentView = view;
    LabelCurrentView.Text = AppTranslations.CurrentViewText[view].GetLang();
    if ( view == ViewMode.Analysis )
    {
      EditWord.TextBox.SelectionStart = SavedSelectionStart;
      EditWord.TextBox.SelectionLength = SavedSelectionLength;
      if ( DataChanged )
      {
        foreach ( var row in DBApp.Letters )
          LettersMeanings[row.ValueSimple] = null;
        DoAnalyse();
        DataChanged = false;
      }
    }
    else
    {
      SavedSelectionStart = EditWord.TextBox.SelectionStart;
      SavedSelectionLength = EditWord.TextBox.SelectionLength;
    }
    if ( view == ViewMode.Notebook && ViewNotebookFirstTime )
    {
      ViewNotebookFirstTime = false;
      ActionNotebookClearLetter.PerformClick();
    }
  }

}
