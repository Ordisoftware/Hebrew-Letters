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
/// <edited> 2022-07 </edited>
namespace Ordisoftware.Hebrew.Letters;

//using System.IO.Pipes;
//using System.Runtime.Serialization.Formatters.Binary;

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
    CommonMenusControl.PreviewFunctions = new()
    {
      [Language.EN] = "    • Notebook of analyzed words" + Globals.NL +
                      "    • Web links edition",
      [Language.FR] = "    • Carnet des mots analysés" + Globals.NL +
                      "    • Edition des liens web"
    };
    try
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.ChronoStartingApp.Start();
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml";
      Globals.AlternativeToURL = "";
      var lang = Settings.LanguageSelected;
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
      HebrewGlobals.GetHebrewCalendarExePath = () => string.Empty;
      HebrewGlobals.GetHebrewLettersExePath = () => Globals.ApplicationExeFullPath;
      HebrewGlobals.GetHebrewWordsExePath = () => Settings.HebrewWordsExe;
      HebrewGlobals.GetCustomWebSearchPattern = () => Settings.CustomWebSearch;
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
    SystemManager.Exit();
  }

  /// <summary>
  /// Checks if settings must be reseted.
  /// </summary>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "N/A")]
  private static void CheckSettingsReset(bool force = false)
  {
    var resetForceVersions = Array.Empty<bool>();
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
      CheckPreviewNotice();
      SystemManager.TryCatch(Settings.Save);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Checks if the app is in preview mode or not and display a notice if needed.
  /// </summary>
  static internal void CheckPreviewNotice()
  {
    if ( CommonMenusControl.PreviewFunctions is null ) return;
    if ( !SystemManager.CommandLineOptions.IsPreviewEnabled || Settings.PreviewModeNotified ) return;
    string msg = SysTranslations.AskForPreviewMode.GetLang(CommonMenusControl.PreviewFunctions[Languages.Current]);
    if ( !DisplayManager.QueryYesNo(msg) )
    {
      SystemManager.CommandLineOptions.WithPreview = false;
      SystemManager.CommandLineOptions.NoPreview = true;
    }
    Settings.PreviewModeNotified = true;
  }

  /// <summary>
  /// Processes command line options.
  /// </summary>
  static private void ProcessCommandLineOptions()
  {
    try
    {
      if ( SystemManager.CommandLineOptions is null ) return;
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
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  static public void UpdateLocalization()
  {
    Globals.ChronoTranslate.Restart();
    Task task = null;
    try
    {
      static void update(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        var resources = new ComponentResourceManager(form.GetType());
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
      new Infralution.Localization.CultureManager().ManagedControl = TranscriptionGuideForm;
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
        TranscriptionGuideForm.HTMLBrowserForm_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        MethodNoticeForm.HTMLBrowserForm_Shown(null, null);
      }
      MainForm.Instance.MinimumSize = new Size(MainForm.Instance.MinimumSize.Width, MainForm.Instance.MinimumSize.Height - MainForm.Instance.TabControl.DisplayRectangle.Y - 5);
      MainForm.Instance.Height -= MainForm.Instance.MinimumSize.Height;
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
