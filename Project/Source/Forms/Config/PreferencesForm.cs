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
/// <created> 2019-09 </created>
/// <edited> 2021-02 </edited>
namespace Ordisoftware.Hebrew.Letters;

using KVPImageExportTarget = KeyValuePair<ImageExportTarget, string>;

partial class PreferencesForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static private bool LanguageChanged;
  static private bool DoReset;

  static public void Run()
  {
    var form = new PreferencesForm();
    form.ShowDialog();
    while ( LanguageChanged || DoReset )
    {
      LanguageChanged = false;
      DoReset = false;
      form = new PreferencesForm();
      form.ShowDialog();
    }
  }

  private readonly NullSafeOfStringDictionary<DataExportTarget> ExportTarget
    = ExportHelper.CreateExportTargets(DataExportTarget.XML);

  private bool IsReady;

  private PreferencesForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    SaveSettingsDialog.InitialDirectory = Program.Settings.GetExportDirectory();
    OpenSettingsDialog.InitialDirectory = SaveSettingsDialog.InitialDirectory;
    SaveSettingsDialog.Filter = ExportTarget.CreateFilters();
    OpenSettingsDialog.Filter = SaveSettingsDialog.Filter;
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
    LoadSettings();
    IsReady = true;
  }

  private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    if ( DoReset )
    {
      EditFontSize_ValueChanged(null, null);
      MainForm.Instance.InitializeTheme();
    }
    else
      SaveSettings();
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
    CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    StatisticsForm.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
  }

  private void EditUsageStatisticsEnabled_CheckedChanged(object sender, EventArgs e)
  {
    CommonMenusControl.Instance.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
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
    string temp = MainForm.Instance.EditWord.TextBox.Text;
    MainForm.Instance.ActionClear.PerformClick();
    Settings.LanguageSelected = Language.EN;
    Program.UpdateLocalization();
    UpdateLanguagesButtons();
    LanguageChanged = true;
    MainForm.Instance.EditWord.TextBox.Text = temp;
    MainForm.Instance.EditWord.Focus(LettersControlFocusSelect.Keep);
    Close();
  }

  private void ActionSelectLangFR_Click(object sender, EventArgs e)
  {
    if ( Settings.LanguageSelected == Language.FR ) return;
    string temp = MainForm.Instance.EditWord.TextBox.Text;
    MainForm.Instance.ActionClear.PerformClick();
    Settings.LanguageSelected = Language.FR;
    Program.UpdateLocalization();
    UpdateLanguagesButtons();
    LanguageChanged = true;
    MainForm.Instance.EditWord.TextBox.Text = temp;
    MainForm.Instance.EditWord.Focus(LettersControlFocusSelect.Keep);
    Close();
  }

  private void EditCheckUpdateAtStartup_CheckedChanged(object sender, EventArgs e)
  {
    EditCheckUpdateAtStartupInterval.Enabled = EditCheckUpdateAtStartup.Checked;
  }

  private void EditFontSize_ValueChanged(object sender, EventArgs e)
  {
    MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
  }

  private void EditVolume_ValueChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    MediaMixer.SetApplicationVolume(Globals.ProcessId, EditVolume.Value);
    LabelVolumeValue.Text = EditVolume.Value + "%";
    Settings.ApplicationVolume = EditVolume.Value;
    SystemManager.TryCatch(Settings.Save);
    DisplayManager.DoSound(Globals.ClipboardSoundFilePath);
  }

  private void EditAutoOpenExportedFile_CheckedChanged(object sender, EventArgs e)
  {
    if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
      EditAutoOpenExportFolder.Checked = false;
  }

  private void EditAutoOpenExportFolder_CheckedChanged(object sender, EventArgs e)
  {
    if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
      EditAutoOpenExportedFile.Checked = false;
  }
  private void EditImageExportFileFormat_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = ( (KVPImageExportTarget)e.ListItem ).Key.ToString();
  }

  private void EditImageExportFileFormat_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.ExportImagePreferredTarget = ( (KVPImageExportTarget)EditImageExportFileFormat.SelectedItem ).Key;
  }

  private void ActionSelectExportFolder_Click(object sender, EventArgs e)
  {
    SystemManager.TryCatch(() => FolderBrowserDialog.SelectedPath = Settings.GetExportDirectory());
    if ( FolderBrowserDialog.ShowDialog() == DialogResult.OK )
      EditExportFolder.Text = FolderBrowserDialog.SelectedPath;
  }

  private void ActionResetExportFolder_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditExportFolder.Text = (string)Settings.Properties[nameof(Settings.ExportFolder)].DefaultValue;
  }

  private void EditColor_Click(object sender, EventArgs e)
  {
    var panel = (Panel)sender;
    DialogColor.Color = panel.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    panel.BackColor = DialogColor.Color;
    SaveColors();
    MainForm.Instance.InitializeTheme();
  }

  private void ActionUseColorsPastel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    SetThemePastel();
  }

  private void ActionUseColorsSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    SetThemeSystem();
  }

  private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    DoResetSettings();
  }

  private void ActionImportSettings_Click(object sender, EventArgs e)
  {
    DoImportSettings();
  }

  private void ActionExportSettings_Click(object sender, EventArgs e)
  {
    DoExportSettings();
  }

  private void ActionOpenTheme_Click(object sender, EventArgs e)
  {
    DoOpenTheme();
  }

  private void ActionSaveTheme_Click(object sender, EventArgs e)
  {
    DoSaveTheme();
  }

}
