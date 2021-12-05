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
/// <created> 2019-01 </created>
/// <edited> 2021-08 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  /// <summary>
  /// Processes the command key.
  /// </summary>
  /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    switch ( keyData )
    {
      // System close
      case Keys.Alt | Keys.Control | Keys.F4:
        ActionExit.PerformClick();
        return true;
      case Keys.Escape:
        if ( !EditESCtoExit.Checked || EditMeanings.IsCurrentCellInEditMode ) break;
        ActionExit.PerformClick();
        return true;
      // System tools
      case Keys.F9:
        ActionPreferences.PerformClick();
        return true;
      // Change view
      case Keys.Control | Keys.Shift | Keys.Tab:
        if ( Globals.AllowClose )
          SetView(Settings.CurrentView.Previous(ViewMode.Notebook));// TODO notebook remove when ready
        return true;
      case Keys.Control | Keys.Tab:
        if ( Globals.AllowClose )
          SetView(Settings.CurrentView.Next(ViewMode.Notebook));// TODO notebook remove when ready
        return true;
      case Keys.F1:
        ActionViewAnalysis.PerformClick();
        return true;
      case Keys.F2:
        ActionViewLetters.PerformClick();
        return true;
      case Keys.F3:
        if ( !Globals.IsDebugExecutable ) break; // TODO remove when ready
        ActionViewNotebook.PerformClick();
        return true;
      // Application functions
      case Keys.F5:
      case Keys.Control | Keys.F:
        ActionSearchTerm.PerformClick();
        return true;
      case Keys.Control | Keys.N:
        ActionNewInstance.PerformClick();
        return true;
      // Application menus
      case Keys.Alt | Keys.T:
        ActionTools.ShowDropDown();
        return true;
      case Keys.Alt | Keys.L:
        ActionWebLinks.ShowDropDown();
        return true;
      // System menus
      case Keys.Alt | Keys.S:
        ActionSettings.ShowDropDown();
        return true;
      case Keys.Alt | Keys.I:
        ActionInformation.ShowDropDown();
        return true;
      // Data edition
      case Keys.Control | Keys.S:
        ActionSave.PerformClick();
        return true;
      case Keys.Control | Keys.Back:
        ActionUndo.Focus();
        ActionUndo.PerformClick();
        return true;
    }
    // Letters navigation
    if ( Globals.AllowClose && Settings.CurrentView == ViewMode.Letters )
      switch ( keyData )
      {
        case Keys.Control | Keys.Home:
          LettersNavigator.ActionFirst.PerformClick();
          return true;
        case Keys.Control | Keys.End:
          LettersNavigator.ActionLast.PerformClick();
          return true;
        case Keys.Control | Keys.PageUp:
          LettersNavigator.ActionPrevious.PerformClick();
          return true;
        case Keys.Control | Keys.PageDown:
          LettersNavigator.ActionNext.PerformClick();
          return true;
      }
    return base.ProcessCmdKey(ref msg, keyData);
  }

}
