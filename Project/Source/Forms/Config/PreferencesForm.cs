/// <license>
/// This file is part of Ordisoftware Hebrew letters.
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
/// <created> 2019-09 </created>
/// <edited> 2020-11 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
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

    private void PreferencesForm_Load(object sender, EventArgs e)
    {
      this.CenterToMainFormElseScreen();
    }

    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      TopMost = MainForm.Instance.TopMost;
      ActiveControl = ActionClose;
      BringToFront();
      UpdateLanguagesButtons();
      EditVacuumAtStartup.Checked = Program.Settings.VacuumAtStartup;
      EditDebuggerEnabled.Checked = Program.Settings.DebuggerEnabled;
      EditLogEnabled.Checked = Program.Settings.TraceEnabled;
      EditCheckUpdateAtStartup.Checked = Program.Settings.CheckUpdateAtStartup;
      EditAutoSortAnalysisMeanings.Checked = Program.Settings.AutoSortAnalysisMeanings;
      EditFontSize.Value = Program.Settings.FontSizeSentence;
      EditMaxLength.Value = Program.Settings.HebrewTextBoxMaxLength;
      EditWebLinksMenuEnabled.Checked = Program.Settings.WebLinksMenuEnabled;
      EditCheckUpdateAtStartupInterval.Value = Program.Settings.CheckUpdateAtStartupDaysInterval;
      EditUsageStatisticsEnabled.Checked = Program.Settings.UsageStatisticsEnabled;
      EditVolume.Value = Program.Settings.ApplicationVolume;
    }

    private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
      Program.Settings.DebuggerEnabled = EditDebuggerEnabled.Checked;
      Program.Settings.TraceEnabled = EditLogEnabled.Checked;
      Program.Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Program.Settings.AutoSortAnalysisMeanings = EditAutoSortAnalysisMeanings.Checked;
      Program.Settings.FontSizeSentence = EditFontSize.Value;
      Program.Settings.HebrewTextBoxMaxLength = EditMaxLength.Value;
      Program.Settings.WebLinksMenuEnabled = EditWebLinksMenuEnabled.Checked;
      Program.Settings.CheckUpdateAtStartupDaysInterval = (int)EditCheckUpdateAtStartupInterval.Value;
      Program.Settings.ApplicationVolume = EditVolume.Value;
      Program.Settings.UsageStatisticsEnabled = EditUsageStatisticsEnabled.Checked;
      Program.Settings.Save();
    }

    private void EditDebuggerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      if ( !EditDebuggerEnabled.Checked )
        EditLogEnabled.Checked = false;
      DebugManager.Enabled = EditDebuggerEnabled.Checked;
      EditLogEnabled.Enabled = DebugManager.Enabled;
    }

    private void EditLogEnabled_CheckedChanged(object sender, EventArgs e)
    {
      DebugManager.TraceEnabled = EditLogEnabled.Checked;
      MainForm.Instance.SystemInformationMenu.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      StatisticsForm.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    }

    private void EditUsageStatisticsEnabled_CheckedChanged(object sender, EventArgs e)
    {
      MainForm.Instance.SystemInformationMenu.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
      AboutBox.Instance.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
      StatisticsForm.Instance.Timer.Enabled = EditUsageStatisticsEnabled.Checked;
      if ( !EditUsageStatisticsEnabled.Checked )
        StatisticsForm.Instance.Close();
    }

    private void UpdateLanguagesButtons()
    {
      if ( Program.Settings.LanguageSelected == Language.EN )
      {
        ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangFR.BackColor = SystemColors.Control;
      }
      if ( Program.Settings.LanguageSelected == Language.FR )
      {
        ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangEN.BackColor = SystemColors.Control;
      }
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      if ( Program.Settings.LanguageSelected == Language.EN ) return;
      string temp = MainForm.Instance.EditLetters.Input.Text;
      MainForm.Instance.ActionClear.PerformClick();
      Program.Settings.LanguageSelected = Language.EN;
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      MainForm.Instance.EditLetters.Input.Text = temp;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      if ( Program.Settings.LanguageSelected == Language.FR ) return;
      string temp = MainForm.Instance.EditLetters.Input.Text;
      MainForm.Instance.ActionClear.PerformClick();
      Program.Settings.LanguageSelected = Language.FR;
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      MainForm.Instance.EditLetters.Input.Text = temp;
      Close();
    }

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
    }

    private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToResetPreferences.GetLang()) ) return;
      Program.Settings.Reset();
      Program.Settings.Reload();
      Program.Settings.LanguageSelected = Languages.Current;
      Program.Settings.Store();
      PreferencesForm_Shown(null, null);
      MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)Program.Settings.FontSizeSentence);
      Program.GrammarGuideForm.CenterToMainFormElseScreen();
      Program.MethodNoticeForm.CenterToMainFormElseScreen();
      Close();
    }

    private void EditVolume_ValueChanged(object sender, EventArgs e)
    {
      MediaMixer.SetApplicationVolume(System.Diagnostics.Process.GetCurrentProcess().Id, EditVolume.Value);
      LabelVolumeValue.Text = EditVolume.Value + "%";
    }

  }

}
