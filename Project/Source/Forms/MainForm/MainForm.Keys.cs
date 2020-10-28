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
/// <created> 2019-01 </created>
/// <edited> 2020-10 </edited>
using System.Windows.Forms;

namespace Ordisoftware.Hebrew.Letters
{

  public partial class MainForm
  {

    /// <summary>
    /// Process the command key.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch ( keyData )
      {
        case Keys.Control | Keys.N:
          ActionNewInstance.PerformClick();
          return true;
        case Keys.F1:
          ActionViewAnalysis.PerformClick();
          return true;
        case Keys.F2:
          ActionViewLetters.PerformClick();
          return true;
        case Keys.F3:
        case Keys.Control | Keys.F:
          ActionSearchTerm.PerformClick();
          return true;
        case Keys.F8:
          ActionPreferences.PerformClick();
          return true;
        case Keys.F11:
          ActionHelp.PerformClick();
          return true;
        case Keys.F12:
          ActionAbout_Click(null, null);
          return true;
        case Keys.Escape:
          if ( EditESCtoExit.Checked )
            ActionExit.PerformClick();
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
