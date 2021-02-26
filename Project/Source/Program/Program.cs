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
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
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
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Letters.shtml";
      Globals.AlternativeToURL = "";
      Globals.SettingsUpgraded = Settings.UpgradeRequired;
      Settings.CheckUpgradeRequired(ref Globals.SettingsUpgraded);
      Settings.UpgradeRequired = Globals.SettingsUpgraded;
      CheckSettingsReset();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      DebugManager.Enabled = Settings.DebuggerEnabled;
      DebugManager.TraceEnabled = Settings.TraceEnabled;
      Language lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
      Settings.LanguageSelected = lang;
      UpdateLocalization();
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Check if settings must be reseted.
    /// </summary>
    private static void CheckSettingsReset()
    {
      Settings.FirstLaunch = false;
      if ( Settings.LanguageSelected == Language.None )
        Settings.LanguageSelected = Languages.Current;
      Settings.Save();
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static internal void UpdateLocalization()
    {
      void updateForm(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
        resources.Apply(form.Controls);
      }
      void updateLabel(Label label, TextBox textbox, int dy)
      {
        label.Location = new Point(label.Location.X, textbox.Location.Y + dy);
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
        if ( form != MainForm.Instance && form != AboutBox.Instance
          && form != GrammarGuideForm && form != MethodNoticeForm )
          updateForm(form);
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