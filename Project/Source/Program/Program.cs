/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO.Pipes;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Ordisoftware.Core;
using System.IO;
using System.Threading.Tasks;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Provide Program class.
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
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Check if settings must be reseted.
    /// </summary>
    private static void CheckSettingsReset(bool force = false)
    {
      try
      {
        // Check reset
        if ( force
        /*|| Settings.UpgradeResetRequiredVx_y*/ )
        {
#pragma warning disable S2583 // Conditionally executed code should be reachable - irrelevant
          if ( !force && !Settings.FirstLaunch )
            DisplayManager.ShowInformation(SysTranslations.UpgradeResetRequired.GetLang());
#pragma warning restore S2583 // Conditionally executed code should be reachable - irrelevant
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
        // Check applications
        string pathWordsFolder = Path.Combine(Globals.CompanyProgramFilesFolderPath, "Hebrew Words", "Bin");
        string pathWordsOld = Path.Combine(pathWordsFolder, "Ordisoftware.HebrewWords.exe");
        string pathWordsDefault = (string)Settings.Properties["HebrewWordsExe"].DefaultValue;
        // Force default view
        Settings.CurrentView = ViewMode.Analysis;
        // Save settings
        SystemManager.TryCatch(Settings.Save);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Process command line options.
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
        if ( !Settings.FirstLaunch
          && SystemManager.CommandLineOptions != null
          && SystemManager.CommandLineOptions.HideMainForm )
          Globals.ForceStartupHide = true;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static public void UpdateLocalization()
    {
      Globals.ChronoTranslate.Restart();
      Task task = null;
      try
      {
        void update(Form form)
        {
          new Infralution.Localization.CultureManager().ManagedControl = form;
          ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
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
        new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
        new Infralution.Localization.CultureManager().ManagedControl = MethodNoticeForm;
        Infralution.Localization.CultureManager.ApplicationUICulture = culture;
        foreach ( Form form in Application.OpenForms )
        {
          if ( form != DebugManager.TraceForm && form != AboutBox.Instance && form != GrammarGuideForm && form != MethodNoticeForm )
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
        int top1 = MainForm.Instance.EditGematriaSimple.Top;
        int top2 = MainForm.Instance.EditGematriaFull.Top;
        int top0 = top1 - 19;
        int top1_3 = top2 + 3;
        int top2_3 = top2 + 3;
        MainForm.Instance.LabelGematria.Top = top0;
        MainForm.Instance.LabelGematriaSimple.Top = top1_3;
        MainForm.Instance.LabelGematriaFull.Top = top2_3;
        MainForm.Instance.LabelCondordance.Top = top0;
        MainForm.Instance.LabelTranscription.Top = top0;
        MainForm.Instance.LabelDictionary.Top = top0;
        MainForm.Instance.LabelMemo.Top = top2_3;

        MainForm.Instance.LabelGematria.Top = MainForm.Instance.EditGematriaSimple.Top - 19;
        MainForm.Instance.LabelGematriaSimple.Top = MainForm.Instance.EditGematriaSimple.Top + 3;
        MainForm.Instance.LabelGematriaFull.Top = MainForm.Instance.EditGematriaFull.Top + 3;
        MainForm.Instance.LabelCondordance.Top = MainForm.Instance.LabelGematria.Top;
        MainForm.Instance.LabelTranscription.Top = MainForm.Instance.LabelGematria.Top;
        MainForm.Instance.LabelDictionary.Top = MainForm.Instance.LabelGematria.Top;
        MainForm.Instance.LabelMemo.Top = MainForm.Instance.EditGematriaFull.Top + 3;

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

}
