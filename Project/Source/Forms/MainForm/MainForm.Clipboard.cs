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
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    /// <summary>
    /// Clipboard monitoring.
    /// </summary>
    protected override void WndProc(ref Message m)
    {
      const int WM_DRAWCLIPBOARD = 0x308;
      switch ( m.Msg )
      {
        case WM_DRAWCLIPBOARD:
          CheckClipboardContentType();
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    /// <summary>
    /// Check clipboard content type.
    /// </summary>
    internal void CheckClipboardContentType()
    {
      string strContent = Clipboard.GetText();
      ActionPaste.Enabled = !strContent.IsNullOrEmpty();
      if ( ActionPaste.Enabled )
      {
        var strLabel = HebrewAlphabet.IsValidUnicode(strContent)
                       ? HebrewTranslations.Unicode.GetLang()
                       : HebrewAlphabet.IsValidHebrew(strContent)
                         ? HebrewTranslations.Hebrew.GetLang()
                         : SysTranslations.Uncertain.GetLang();
        LabelClipboardContentType.Text = $"{strLabel}{Globals.NL}({strContent.Length})";
      }
      else
        LabelClipboardContentType.Text = SysTranslations.UnknownSlot.GetLang().Trim('(', ')').Titleize();
    }

  }

}
