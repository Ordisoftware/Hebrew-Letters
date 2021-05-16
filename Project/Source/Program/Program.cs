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
/// <edited> 2021-04 </edited>
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO.Pipes;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Ordisoftware.Core;

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
        Settings.Save();
        Globals.Settings = Settings;
        Globals.MainForm = MainForm.Instance;
        DebugManager.Enabled = Settings.DebuggerEnabled;
        DebugManager.TraceEnabled = Settings.TraceEnabled;
        UpdateLocalization();
        Globals.ChronoStartingApp.Stop();
        ProcessCommandLineOptions();
        Globals.ChronoStartingApp.Start();
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
        Settings.CurrentView = ViewMode.Analysis;
        if ( force /*|| Settings.UpgradeResetRequiredVx_y*/ )
        {
#pragma warning disable S2583 // Conditionally executed code should be reachable
          if ( !force && !Settings.FirstLaunch )
            DisplayManager.ShowInformation(SysTranslations.UpgradeResetRequired.GetLang());
#pragma warning restore S2583 // Conditionally executed code should be reachable
          Settings.Reset();
          Settings.LanguageSelected = Languages.Current;
          Settings.SetUpgradeFlagsOff();
        }
        if ( Settings.FirstLaunchV4 )
        {
          Settings.SetFirstAndUpgradeFlagsOff();
          Settings.FirstLaunch = true;
        }
        if ( Settings.LanguageSelected == Language.None )
          Settings.LanguageSelected = Languages.Current;
        Settings.Save();
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
      try
      {
        MainForm.Instance.PanelMainCenter.Visible = false;
        void update(Form form)
        {
          new Infralution.Localization.CultureManager().ManagedControl = form;
          ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
          resources.Apply(form.Controls);
        }
        void updateLabel(Label label, TextBox textbox, int dy)
        {
          label.Location = new System.Drawing.Point(label.Location.X, textbox.Location.Y + dy);
        }
        string lang = "en-US";
        if ( Settings.LanguageSelected == Language.FR ) lang = "fr-FR";
        var culture = new CultureInfo(lang);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        MessageBoxEx.CloseAll();
        AboutBox.Instance.Hide();
        var temp = Settings.CurrentView;
        MainForm.Instance.SetView(ViewMode.Analysis);
        update(MainForm.Instance);
        MainForm.Instance.SetView(ViewMode.Letters);
        update(MainForm.Instance);
        MainForm.Instance.SetView(temp);
        string tempLogTitle = DebugManager.TraceForm.Text;
        string tempLogContent = DebugManager.TraceForm.TextBox.Text;
        new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = DebugManager.TraceForm;
        new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
        new Infralution.Localization.CultureManager().ManagedControl = MethodNoticeForm;
        Infralution.Localization.CultureManager.ApplicationUICulture = culture;
        foreach ( Form form in Application.OpenForms )
        {
          if ( form != AboutBox.Instance && form != GrammarGuideForm && form != MethodNoticeForm )
            update(form);
          if ( form is ShowTextForm formShowText )
            formShowText.Relocalize();
        }
        // Various updates
        DebugManager.TraceForm.Text = tempLogTitle;
        DebugManager.TraceForm.AppendText(tempLogContent);
        LoadingForm.Instance.Relocalize();
        TextBoxEx.Relocalize();
        AboutBox.Instance.AboutBox_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        MethodNoticeForm.HTMLBrowserForm_Shown(null, null);
        MainForm.Instance.CreateSystemInformationMenu();
        MainForm.Instance.CheckClipboardContentType();
        updateLabel(MainForm.Instance.LabelGematria, MainForm.Instance.EditGematriaSimple, -19);
        updateLabel(MainForm.Instance.LabelGematriaSimple, MainForm.Instance.EditGematriaSimple, 3);
        updateLabel(MainForm.Instance.LabelGematriaFull, MainForm.Instance.EditGematriaFull, 3);
        MainForm.Instance.LabelClipboardContentType.Left = MainForm.Instance.ActionCopyToUnicode.Left
                                                         + MainForm.Instance.ActionCopyToUnicode.Width / 2
                                                         - MainForm.Instance.LabelClipboardContentType.Width / 2;
        MainForm.Instance.EditCopyToClipboardCloseApp.Left = MainForm.Instance.ActionCopyToResult.Left
                                                           + MainForm.Instance.ActionCopyToResult.Width + 5;
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
