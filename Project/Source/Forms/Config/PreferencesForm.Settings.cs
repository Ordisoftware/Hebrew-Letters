/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Letters;

using System.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;

partial class PreferencesForm : Form
{

  private void LoadSettings()
  {
    SystemManager.TryCatch(() => LabelLastStartupCheckDate.Text = Settings.CheckUpdateLastDone.ToShortDateString() + " " + Settings.CheckUpdateLastDone.ToShortTimeString());
    SystemManager.TryCatch(() => LabelLastDBOptimizeDate.Text = Settings.VacuumLastDone.ToShortDateString() + " " + Settings.VacuumLastDone.ToShortTimeString());
    SystemManager.TryCatch(() => EditVacuumAtStartup.Checked = Settings.VacuumAtStartup);
    SystemManager.TryCatch(() => EditDebuggerEnabled.Checked = Settings.DebuggerEnabled);
    SystemManager.TryCatch(() => EditLogEnabled.Checked = Settings.TraceEnabled);
    SystemManager.TryCatch(() => EditCheckUpdateAtStartup.Checked = Settings.CheckUpdateAtStartup);
    SystemManager.TryCatch(() => EditAutoSortAnalysisMeanings.Checked = Settings.AutoSortAnalysisMeanings);
    SystemManager.TryCatch(() => EditFontSize.Value = Settings.FontSizeSentence);
    SystemManager.TryCatch(() => EditMaxLength.Value = Settings.HebrewTextBoxMaxLength);
    SystemManager.TryCatch(() => EditWebLinksMenuEnabled.Checked = Settings.WebLinksMenuEnabled);
    SystemManager.TryCatch(() => EditCheckUpdateAtStartupInterval.Value = Settings.CheckUpdateAtStartupDaysInterval);
    SystemManager.TryCatch(() => EditUsageStatisticsEnabled.Checked = Settings.UsageStatisticsEnabled);
    SystemManager.TryCatch(() => EditVolume.Value = Settings.ApplicationVolume);
    SystemManager.TryCatch(() => EditExportFolder.Text = Settings.ExportFolder);
    SystemManager.TryCatch(() => EditAutoOpenExportFolder.Checked = Settings.AutoOpenExportFolder);
    SystemManager.TryCatch(() => EditAutoOpenExportedFile.Checked = Settings.AutoOpenExportedFile);
    SystemManager.TryCatch(() => EditWindowsDoubleBufferingEnabled.Checked = Settings.WindowsDoubleBufferingEnabled);
    SystemManager.TryCatch(() => EditHebrewWordsPath.Text = Settings.HebrewWordsExe);
    SystemManager.TryCatch(() => EditCustomWebSearch.Text = Settings.CustomWebSearch);
    SystemManager.TryCatch(() => EditHebrewCharsInBold.Checked = Settings.LettersControlHebrewCharsInBold);
    EditImageExportFileFormat.Fill(Program.ImageExportTargets, Settings.ExportImagePreferredTarget);
    LoadColors();
  }

  private void SaveSettings()
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
    Settings.ExportFolder = EditExportFolder.Text;
    Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
    Settings.AutoOpenExportedFile = EditAutoOpenExportedFile.Checked;
    Settings.WindowsDoubleBufferingEnabled = EditWindowsDoubleBufferingEnabled.Checked;
    Settings.HebrewWordsExe = EditHebrewWordsPath.Text;
    Settings.CustomWebSearch = EditCustomWebSearch.Text;
    Settings.LettersControlHebrewCharsInBold = EditHebrewCharsInBold.Checked;
    SaveColors();
    SystemManager.TryCatch(Settings.Save);
  }

  private void LoadColors()
  {
    SystemManager.TryCatch(() => EditLettersBack.BackColor = Settings.ColorLettersPanel);
    SystemManager.TryCatch(() => EditWordBack.BackColor = Settings.ColorHebrewWordTextBox);
    SystemManager.TryCatch(() => EditAnalyseBack.BackColor = Settings.ColorMeaningsPanel);
    SystemManager.TryCatch(() => EditEditableBack.BackColor = Settings.ColorSentenceTextBox);
    SystemManager.TryCatch(() => EditReadonlyBack.BackColor = Settings.ColorGematriaTextBox);
  }

  private void SaveColors()
  {
    Settings.ColorLettersPanel = EditLettersBack.BackColor;
    Settings.ColorHebrewWordTextBox = EditWordBack.BackColor;
    Settings.ColorMeaningsPanel = EditAnalyseBack.BackColor;
    Settings.ColorSentenceTextBox = EditEditableBack.BackColor;
    Settings.ColorGematriaTextBox = EditReadonlyBack.BackColor;
  }

  private void DoResetSettings()
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToResetPreferences.GetLang()) ) return;
    IsReady = false;
    long starttime = Settings.BenchmarkStartingApp;
    long loadtime = Settings.BenchmarkLoadData;
    var lastupdate = Settings.CheckUpdateLastDone;
    var lastvacuum = Settings.VacuumLastDone;
    Settings.Reset();
    Settings.SetFirstAndUpgradeFlagsOff();
    Settings.CheckUpdateLastDone = lastupdate;
    Settings.VacuumLastDone = lastvacuum;
    Settings.LanguageSelected = Languages.Current;
    Settings.BenchmarkStartingApp = starttime;
    Settings.BenchmarkLoadData = loadtime;
    Settings.RestoreMainForm();
    SystemManager.TryCatch(Settings.Save);
    MainForm.Instance.EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
    Program.GrammarGuideForm.CenterToMainFormElseScreen();
    Program.MethodNoticeForm.CenterToMainFormElseScreen();
    DoReset = true;
    IsReady = true;
    Close();
  }

  private void DoImportSettings()
  {
    OpenSettingsDialog.FileName = string.Empty;
    if ( OpenSettingsDialog.ShowDialog() != DialogResult.OK ) return;
    StatisticsForm.Instance.Hide();
    long starttime = Settings.BenchmarkStartingApp;
    long loadtime = Settings.BenchmarkLoadData;
    try
    {
      var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
      string context = Properties.Settings.Default.Context["GroupName"].ToString();
      var xmldata = XDocument.Load(OpenSettingsDialog.FileName);
      var settings = xmldata.XPathSelectElements("//" + context);
      var section = config.GetSectionGroup("userSettings").Sections[context].SectionInformation;
      section.SetRawXml(settings.Single().ToString());
      config.Save(ConfigurationSaveMode.Modified);
      ConfigurationManager.RefreshSection("userSettings");
      Settings.Reload();
      Settings.BenchmarkStartingApp = starttime;
      Settings.BenchmarkLoadData = loadtime;
      Settings.Retrieve();
      SystemManager.TryCatch(Settings.Save);
      Program.UpdateLocalization();
      Settings.SetFirstAndUpgradeFlagsOff();
      LanguageChanged = true;
      DoReset = true;
      Close();
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
      Settings.Reload();
    }
  }

  private void DoExportSettings()
  {
    SaveSettingsDialog.FileName = "Settings";
    if ( SaveSettingsDialog.ShowDialog() != DialogResult.OK ) return;
    TabControl.SelectedIndex = 0;
    SaveSettings();
    Settings.Store();
    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
    config.SaveAs(SaveSettingsDialog.FileName);
  }

  private void DoOpenTheme()
  {
    SystemManager.TryCatch(() => OpenThemeDialog.InitialDirectory = Settings.GetExportDirectory());
    if ( OpenThemeDialog.ShowDialog() != DialogResult.OK ) return;
    var items = new NullSafeOfStringDictionary<string>();
    if ( !items.LoadKeyValuePairs(OpenThemeDialog.FileName, "=") ) return;
    TabPageTheme.Controls.OfType<Panel>().ForEach(panel =>
    {
      string name = panel.Name.Substring(4);
      if ( items.TryGetValue(name, out var color) )
        panel.BackColor = ColorTranslator.FromHtml(color);
    });
    SaveColors();
    MainForm.Instance.InitializeTheme();
  }

  private void DoSaveTheme()
  {
    SystemManager.TryCatch(() =>
    {
      SaveThemeDialog.InitialDirectory = Settings.GetExportDirectory();
      SaveThemeDialog.FileName = "Theme.ini";
    });
    if ( SaveThemeDialog.ShowDialog() != DialogResult.OK ) return;
    var items = new List<string>();
    TabPageTheme.Controls.OfType<Panel>().ForEach(panel => items.Add(makeLine(panel)));
    File.WriteAllLines(SaveThemeDialog.FileName, items);
    //
    static string makeLine(Panel panel)
    {
      return panel.Name.Substring(4) + "=" + ColorTranslator.ToHtml(panel.BackColor);
    }
  }

  private void SetThemePastel()
  {
    EditLettersBack.BackColor = Color.LightYellow;
    EditWordBack.BackColor = Color.AliceBlue;
    EditAnalyseBack.BackColor = Color.MintCream;
    EditEditableBack.BackColor = SystemColors.Window;
    EditReadonlyBack.BackColor = Color.LavenderBlush;
    SaveColors();
    MainForm.Instance.InitializeTheme();
  }

  private void SetThemeSystem()
  {
    EditLettersBack.BackColor = SystemColors.Control;
    EditWordBack.BackColor = SystemColors.Window;
    EditAnalyseBack.BackColor = SystemColors.Window;
    EditEditableBack.BackColor = SystemColors.Window;
    EditReadonlyBack.BackColor = SystemColors.Control;
    SaveColors();
    MainForm.Instance.InitializeTheme();
  }

}
