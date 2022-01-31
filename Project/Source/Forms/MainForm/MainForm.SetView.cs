/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  /// <summary>
  /// Provides view connector.
  /// </summary>
  private sealed class ViewConnector
  {

    /// <summary>
    /// The menu item.
    /// </summary>
    public ToolStripButton MenuItem;

    /// <summary>
    /// The panel.
    /// </summary>
    public Panel Panel;

    /// <summary>
    /// The focused control.
    /// </summary>
    public Control Focused;

  }

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
    var ViewPanels = new Dictionary<ViewMode, ViewConnector>()
    {
      {
        ViewMode.Analysis,
        new ViewConnector
        {
          MenuItem = ActionViewAnalysis,
          Panel = PanelViewAnalysis,
          Focused = EditWord
        }
      },
      {
        ViewMode.Letters,
        new ViewConnector
        {
          MenuItem = ActionViewLetters,
          Panel = PanelLettersInner,
          Focused = EditMeanings
        }
      },
      {
        ViewMode.Notebook,
        new ViewConnector
        {
          MenuItem = ActionViewNotebook,
          Panel = PanelViewNotebook,
          Focused = PanelViewNotebook
        }
      }
    };
    if ( Settings.CurrentView == view && !first ) return;
    if ( Settings.CurrentView == ViewMode.Letters )
      ViewPanels[Settings.CurrentView].Focused.Focus();
    ViewPanels[Settings.CurrentView].MenuItem.Checked = false;
    ViewPanels[Settings.CurrentView].Panel.Parent = null;
    ViewPanels[view].MenuItem.Checked = true;
    ViewPanels[view].Panel.Parent = PanelMainCenter;
    ViewPanels[view].Focused.Focus();
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
