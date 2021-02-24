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
/// <edited> 2021-02 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  public partial class PreferencesForm : Form
  {

    static private readonly Properties.Settings Settings = Program.Settings;

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

    private bool IsReady;

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
      EditVacuumAtStartup.Checked = Settings.VacuumAtStartup;
      EditDebuggerEnabled.Checked = Settings.DebuggerEnabled;
      EditLogEnabled.Checked = Settings.TraceEnabled;
      EditCheckUpdateAtStartup.Checked = Settings.CheckUpdateAtStartup;
      EditAutoSortAnalysisMeanings.Checked = Settings.AutoSortAnalysisMeanings;
      EditFontSize.Value = Settings.FontSizeSentence;
      EditMaxLength.Value = Settings.HebrewTextBoxMaxLength;
      EditWebLinksMenuEnabled.Checked = Settings.WebLinksMenuEnabled;
      EditCheckUpdateAtStartupInterval.Value = Settings.CheckUpdateAtStartupDaysInterval;
      EditUsageStatisticsEnabled.Checked = Settings.UsageStatisticsEnabled;
      EditVolume.Value = Settings.ApplicationVolume;
      IsReady = true;
    }

    private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
      Settings.DebuggerEnabled = EditDebuggerEnabled.Checked;
      Settings.TraceEnabled = EditLogEnabled.Checked;
      Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Settings.AutoSortAnalysisMeanings = EditAutoSortAnalysisMeanings.Checked;
      Settings.FontSizeSentence = EditFontSize.Value;
      Settings.HebrewTextBoxMaxLength = EditMaxLength.Value;
      Settings.WebLinksMenuEnabled = EditWebLinksMenuEnabled.Checked;
      Settings.CheckUpdateAtStartupDaysInterval = (int)EditCheckUpdateAtStartupInterval.Value;
      Settings.ApplicationVolume = EditVolume.Value;
      Settings.UsageStatisticsEnabled = EditUsageStatisticsEnabled.Checked;
      Settings.Save();
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
      if ( Settings.LanguageSelected == Language.EN )
      {
        ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangFR.BackColor = SystemColors.Control;
      }
      if ( Settings.LanguageSelected == Language.FR )
      {
        ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangEN.BackColor = SystemColors.Control;
      }
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      if ( Settings.LanguageSelected == Language.EN ) return;
      string temp = MainForm.Instance.EditLetters.Input.Text;
      MainForm.Instance.ActionClear.PerformClick();
      Settings.LanguageSelected = Language.EN;
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      MainForm.Instance.EditLetters.Input.Text = temp;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      if ( Settings.LanguageSelected == Language.FR ) return;
      string temp = MainForm.Instance.EditLetters.Input.Text;
      MainForm.Instance.ActionClear.PerformClick();
      Settings.LanguageSelected = Language.FR;
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
      IsReady = false;
      var lastupdate = Settings.CheckUpdateLastDone;
      var lastvacuum = Settings.VacuumLastDone;
      Settings.Reset();
      Settings.Reload();
      Settings.CheckUpdateLastDone = lastupdate;
      Settings.VacuumLastDone = lastvacuum;
      Settings.LanguageSelected = Languages.Current;
      Settings.FirstLaunchV4 = false;
      Settings.FirstLaunchV5_0 = false;
      Settings.FirstLaunch = false;
      Settings.Store();
      PreferencesForm_Shown(null, null);
      MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
      Program.GrammarGuideForm.CenterToMainFormElseScreen();
      Program.MethodNoticeForm.CenterToMainFormElseScreen();
      IsReady = true;
      Close();
    }

    private void EditVolume_ValueChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      MediaMixer.SetApplicationVolume(System.Diagnostics.Process.GetCurrentProcess().Id, EditVolume.Value);
      LabelVolumeValue.Text = EditVolume.Value + "%";
      Settings.ApplicationVolume = EditVolume.Value;
      Settings.Save();
      DisplayManager.DoSound(Globals.ClipboardSoundFilePath);
    }

  }

}
