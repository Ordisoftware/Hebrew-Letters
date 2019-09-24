/// <license>
/// This file is part of Ordisoftware Hebrew letters.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-09 </created>
/// <edited> 2019-09 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.HebrewLetters
{

  public partial class PreferencesForm : Form
  {

    static private bool LanguageChanged;

    static public void Run()
    {
      var form = new PreferencesForm();
      form.ShowDialog();
      while ( LanguageChanged )
      {
        LanguageChanged = false;
        form = new PreferencesForm();
        form.ShowDialog();
      }
    }

    private PreferencesForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      UpdateLanguagesButtons();
    }

    private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.Store();
    }

    private void UpdateLanguagesButtons()
    {
      if ( Program.Settings.Language == "en" )
      {
        ActionSelectLangEN.FlatAppearance.BorderSize = 1;
        ActionSelectLangFR.FlatAppearance.BorderSize = 0;
      }
      if ( Program.Settings.Language == "fr" )
      {
        ActionSelectLangFR.FlatAppearance.BorderSize = 1;
        ActionSelectLangEN.FlatAppearance.BorderSize = 0;
      }
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      Program.Settings.Language = "en";
      Program.ApplyCurrentLanguage();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      Program.Settings.Language = "fr";
      Program.ApplyCurrentLanguage();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

  }

}
