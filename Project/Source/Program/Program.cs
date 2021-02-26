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
/// <edited> 2021-02 </edited>
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
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings
      = Properties.Settings.Default;

    /// <summary>
    /// Process startup method.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml";
      Globals.AlternativeToURL = "";
      bool upgrade = Settings.UpgradeRequired;
      Globals.SettingsUpgraded = upgrade;
      Settings.CheckUpgradeRequired(ref upgrade);
      Settings.UpgradeRequired = upgrade;
      Globals.SettingsUpgraded = Globals.SettingsUpgraded && !Settings.FirstLaunch;
      CheckSettingsReset();
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      DebugManager.Enabled = Settings.DebuggerEnabled;
      DebugManager.TraceEnabled = Settings.TraceEnabled;
      Language lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
      Settings.LanguageSelected = lang;
      UpdateLocalization();
      ProcessCommandLineOptions();
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Bring to front the app in case of duplicate process start.
    /// </summary>
    /// <param name="ar"></param>
    static void IPCRequest(IAsyncResult ar)
    {
      var server = ar.AsyncState as NamedPipeServerStream;
      server.EndWaitForConnection(ar);
      var command = new BinaryFormatter().Deserialize(server) as string;
      if ( command == "BringToFront" )
        MainForm.Instance.SyncUI(() => MainForm.Instance.Popup());
      server.Close();
      SystemManager.CreateIPCServer(IPCRequest);
    }

    /// <summary>
    /// Check if settings must be reseted.
    /// </summary>
    private static void CheckSettingsReset(bool force = false)
    {
      if ( force /*|| Settings.UpgradeResetRequiredVx_y*/ )
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
      if ( Settings.LanguageSelected == Language.None )
        Settings.LanguageSelected = Languages.Current;
      Settings.Save();
    }

    /// <summary>
    /// Process command line options.
    /// </summary>
    static private void ProcessCommandLineOptions()
    {
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static public void UpdateLocalization()
    {
      void updateForm(Form form)
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
      MainForm.Instance.SetView(ViewMode.Analyse);
      updateForm(MainForm.Instance);
      MainForm.Instance.SetView(ViewMode.Settings);
      updateForm(MainForm.Instance);
      MainForm.Instance.SetView(temp);
      updateLabel(MainForm.Instance.LabelGematria, MainForm.Instance.EditGematriaSimple, -19);
      updateLabel(MainForm.Instance.LabelGematriaSimple, MainForm.Instance.EditGematriaSimple, 3);
      updateLabel(MainForm.Instance.LabelGematriaFull, MainForm.Instance.EditGematriaFull, 3);
      string tempLogTitle = DebugManager.TraceForm.Text;
      string tempLogContent = DebugManager.TraceForm.TextBox.Text;
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = MethodNoticeForm;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      foreach ( Form form in Application.OpenForms )
      {
        if ( form != Globals.MainForm && form != AboutBox.Instance
          && form != GrammarGuideForm && form != MethodNoticeForm )
          updateForm(form);
        if ( form is ShowTextForm formShowText )
          formShowText.Relocalize();
      }
      // Various updates
      DebugManager.TraceForm.Text = tempLogTitle;
      DebugManager.TraceForm.AppendText(tempLogContent);
      LoadingForm.Instance.Relocalize();
      UndoRedoTextBox.Relocalize();
      AboutBox.Instance.AboutBox_Shown(null, null);
      GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
      MethodNoticeForm.HTMLBrowserForm_Shown(null, null);
      MainForm.Instance.CreateSystemInformationMenu();
    }

  }

}