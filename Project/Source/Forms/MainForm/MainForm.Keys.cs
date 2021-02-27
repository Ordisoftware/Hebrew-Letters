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
/// <edited> 2021-02 </edited>
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  partial class MainForm
  {

    /// <summary>
    /// Process the command key.
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
          if ( EditESCtoExit.Checked && !EditMeanings.IsCurrentCellInEditMode )
          {
            ActionExit.PerformClick();
            return true;
          }
          break;
        // System tools
        case Keys.F9:
          ActionPreferences.PerformClick();
          return true;
        // Change view
        case Keys.Control | Keys.Shift | Keys.Tab:
          SetView(Settings.CurrentView.Previous());
          return true;
        case Keys.Control | Keys.Tab:
          SetView(Settings.CurrentView.Next());
          return true;
        case Keys.F1:
          ActionViewAnalysis.PerformClick();
          return true;
        case Keys.F2:
          if ( ActiveControl == EditMeanings ) break;
          ActionViewLetters.PerformClick();
          return true;
        // Application functions
        case Keys.F3:
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
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
