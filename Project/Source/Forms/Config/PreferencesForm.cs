/// <license>
/// This file is part of Ordisoftware Hebrew letters.
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
/// <created> 2019-09 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;
using Ordisoftware.HebrewCommon;

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
      TopMost = MainForm.Instance.TopMost;
      BringToFront();
      UpdateLanguagesButtons();
      EditVacuumAtStartup.Checked = Program.Settings.VacuumAtStartup;
      EditEnableDebugger.Checked = Program.Settings.DebuggerEnabled;
      EditCheckUpdateAtStartup.Checked = Program.Settings.CheckUpdateAtStartup;
      EditAutoSortAnalysisMeanings.Checked = Program.Settings.AutoSortAnalysisMeanings;
      EditFontSize.Value = Program.Settings.FontSizeSentence;
      EditMaxLength.Value = Program.Settings.HebrewTextBoxMaxLength;
    }

    private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
      Program.Settings.DebuggerEnabled = EditEnableDebugger.Checked;
      Program.Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Program.Settings.AutoSortAnalysisMeanings = EditAutoSortAnalysisMeanings.Checked;
      Program.Settings.FontSizeSentence = EditFontSize.Value;
      Program.Settings.HebrewTextBoxMaxLength = EditMaxLength.Value;
      Program.Settings.Save();
    }

    private void EditEnableDebugger_CheckedChanged(object sender, EventArgs e)
    {
      Core.Diagnostics.Debugger.Active = EditEnableDebugger.Checked;
    }

    private void UpdateLanguagesButtons()
    {
      if ( Program.Settings.Language == "en" )
      {
        ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangFR.BackColor = SystemColors.Control;
      }
      if ( Program.Settings.Language == "fr" )
      {
        ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangEN.BackColor = SystemColors.Control;
      }
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      string temp = MainForm.Instance.EditLetters.InputText;
      MainForm.Instance.ActionClear.PerformClick();
      Program.Settings.Language = "en";
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      MainForm.Instance.EditLetters.InputText = temp;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      string temp = MainForm.Instance.EditLetters.InputText;
      MainForm.Instance.ActionClear.PerformClick();
      Program.Settings.Language = "fr";
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      MainForm.Instance.EditLetters.InputText = temp;
      Close();
    }

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
    }

    private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Globals.AskToResetPreferences.GetLang()) ) return;
      Program.Settings.Reset();
      Program.Settings.Reload();
      Program.Settings.Language = Localizer.Language;
      Program.Settings.Store();
      PreferencesForm_Shown(null, null);
      MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)Program.Settings.FontSizeSentence);
      Program.GrammarGuideForm.CenterToMainForm();
      Program.MethodNoticeForm.CenterToMainForm();
      Close();
    }

  }

}
