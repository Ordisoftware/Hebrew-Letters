/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Process startup method.
  /// </summary>
  [STAThread]
  static void Main(string[] args)
  {
    try
    {
      Globals.ChronoStartingApp.Start();
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml";
      Globals.AlternativeToURL = "";
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Language lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
      // No IPCAnswers
      // No IPCRequests
      bool upgrade = Settings.UpgradeRequired;
      Globals.IsSettingsUpgraded = upgrade;
      Settings.CheckUpgradeRequired(ref upgrade);
      Settings.UpgradeRequired = upgrade;
      Globals.IsSettingsUpgraded = Globals.IsSettingsUpgraded && !Settings.FirstLaunch;
      CheckSettingsReset();
      if ( lang != Language.None ) Settings.LanguageSelected = lang;
      SystemManager.TryCatch(Settings.Save);
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      DebugManager.TraceEnabled = Settings.TraceEnabled;
      DebugManager.Enabled = Settings.DebuggerEnabled;
      Globals.ChronoStartingApp.Stop();
      ProcessCommandLineOptions();
      Globals.ChronoStartingApp.Start();
      LoadingForm.Instance.Hidden = Settings.LoadingFormHidden;
      AboutBox.LicenseAsRTF = Properties.Resources.MPL_2_0;
      AboutBox.DescriptionText = AppTranslations.ApplicationDescription;
      AboutBox.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    Application.Run(MainForm.Instance);
  }

  /// <summary>
  /// Checks if settings must be reseted.
  /// </summary>
  private static void CheckSettingsReset(bool force = false)
  {
    var resetForceVersions = new bool[]
    {
    };
    try
    {
      // Check reset
      if ( force || resetForceVersions.Contains(true) )
      {
        if ( !force && !Settings.FirstLaunch )
          DisplayManager.ShowInformation(SysTranslations.UpgradeResetRequired.GetLang());
        Settings.Reset();
        Settings.LanguageSelected = Languages.Current;
        Settings.SetUpgradeFlagsOff();
      }
      if ( Settings.FirstLaunchV4 )
      {
        Settings.SetFirstAndUpgradeFlagsOff();
        Settings.FirstLaunch = true;
      }
      // Check language
      if ( Settings.LanguageSelected == Language.None )
        Settings.LanguageSelected = Languages.Current;
      // Force default view
      Settings.CurrentView = ViewMode.Analysis;
      // Check applications
      string pathWordsFolder = Path.Combine(Globals.CompanyProgramFilesFolderPath, "Hebrew Words", "Bin");
      string pathWordsOld = Path.Combine(pathWordsFolder, "Ordisoftware.HebrewWords.exe");
      string pathWordsDefault = (string)Settings.Properties["HebrewWordsExe"].DefaultValue;
      // Check applications : Words
      if ( !File.Exists(Settings.HebrewWordsExe) )
        if ( File.Exists(pathWordsOld) )
          Settings.HebrewWordsExe = pathWordsOld;
        else
        if ( File.Exists(pathWordsDefault) )
          Settings.HebrewWordsExe = pathWordsDefault;
      // Save settings
      SystemManager.TryCatch(Settings.Save);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Processes command line options.
  /// </summary>
  static private void ProcessCommandLineOptions()
  {
    try
    {
      if ( SystemManager.CommandLineOptions == null ) return;
      if ( SystemManager.CommandLineOptions.ResetSettings )
      {
        SystemManager.CleanAllLocalAppSettingsFolders();
        CheckSettingsReset(true);
      }
      else
      if ( !Settings.FirstLaunch && SystemManager.CommandLineOptions?.HideMainForm == true )
        Globals.ForceStartupHide = true;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Updates localization strings to the whole application.
  /// </summary>
  static public void UpdateLocalization()
  {
    Globals.ChronoTranslate.Restart();
    Task task = null;
    try
    {
      static void update(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        ComponentResourceManager resources = new(form.GetType());
        resources.ApplyResources(form.Controls);
      }
      string lang = "en-US";
      if ( Settings.LanguageSelected == Language.FR ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      task = new Task(HebrewGlobals.LoadProviders);
      task.Start();
      if ( Globals.IsReady )
      {
        MessageBoxEx.CloseAll();
        AboutBox.Instance.Hide();
        MainForm.Instance.PanelMainCenter.Visible = false;
        var temp = Settings.CurrentView;
        MainForm.Instance.SetView(ViewMode.Analysis);
        update(MainForm.Instance);
        MainForm.Instance.SetView(ViewMode.Letters);
        update(MainForm.Instance);
        MainForm.Instance.SetView(temp);
      }
      else
      {
        MainForm.Instance.SetView(ViewMode.Analysis, true);
        update(MainForm.Instance);
      }
      new Infralution.Localization.CultureManager().ManagedControl = StatisticsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = MethodNoticeForm;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      var formsToSkip = new Form[] { DebugManager.TraceForm, AboutBox.Instance, GrammarGuideForm, MethodNoticeForm };
      foreach ( Form form in Application.OpenForms.GetAll().Except(formsToSkip) )
      {
        update(form);
        if ( form is ShowTextForm formShowText )
          formShowText.Relocalize();
      }
      // Various updates
      if ( Globals.IsReady )
      {
        LoadingForm.Instance.Relocalize();
        TextBoxEx.Relocalize();
        AboutBox.Instance.AboutBox_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        MethodNoticeForm.HTMLBrowserForm_Shown(null, null);
      }
      MainForm.Instance.PanelGematria.Top = MainForm.Instance.PanelWordDetails.Top;
      MainForm.Instance.LabelClipboardContentType.Left = MainForm.Instance.ActionCopyToUnicode.Left
                                                       + MainForm.Instance.ActionCopyToUnicode.Width / 2
                                                       - MainForm.Instance.LabelClipboardContentType.Width / 2;
      MainForm.Instance.EditCopyToClipboardCloseApp.Left = MainForm.Instance.ActionCopyToResult.Left
                                                         + MainForm.Instance.ActionCopyToResult.Width + 5;
      MainForm.Instance.CheckClipboardContentType();
      task?.Wait();
      MainForm.Instance.CreateSystemInformationMenu();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      MainForm.Instance.PanelMainCenter.Visible = true;
      Globals.ChronoTranslate.Stop();
      Settings.BenchmarkTranslate = Globals.ChronoTranslate.ElapsedMilliseconds;
    }
  }

}
