/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewLetters
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
      bool upgrade = Settings.UpgradeRequired;
      Settings.CheckUpgradeRequired(ref upgrade);
      Settings.UpgradeRequired = upgrade;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      ExceptionManager.Active = Settings.DebuggerEnabled;
      string lang = Settings.Language;
      Shell.CheckCommandLineArguments(args, ref lang);
      Settings.Language = lang;
      UpdateLocalization();
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static internal void UpdateLocalization()
    {
      Action<Label, TextBox, int> updateLabel = (label, textbox, dy) =>
      {
        label.Location = new Point(label.Location.X, textbox.Location.Y + dy);
      };
      Action<Form> updateForm = form =>
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
        resources.Apply(form.Controls);
      };
      string lang = "en-US";
      if ( Settings.Language == "fr" ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      AboutBox.Instance.Hide();
      foreach ( Form form in Application.OpenForms )
        if ( form != MainForm.Instance && form != AboutBox.Instance
          && form != GrammarGuideForm && form != MethodNoticeForm )
          updateForm(form);
      var temp = Settings.CurrentView;
      MainForm.Instance.SetView(ViewMode.Analyse);
      updateForm(MainForm.Instance);
      MainForm.Instance.SetView(ViewMode.Settings);
      updateForm(MainForm.Instance);
      MainForm.Instance.SetView(temp);
      updateLabel(MainForm.Instance.LabelGematria, MainForm.Instance.EditGematriaSimple, -19);
      updateLabel(MainForm.Instance.LabelGematriaSimple, MainForm.Instance.EditGematriaSimple, 3);
      updateLabel(MainForm.Instance.LabelGematriaFull, MainForm.Instance.EditGematriaFull, 3);
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = MethodNoticeForm;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      MainForm.Instance.InitializeSpecialMenus();
      AboutBox.Instance.AboutBox_Shown(null, null);
      GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
      MethodNoticeForm.HTMLBrowserForm_Shown(null, null);
      UndoRedoTextBox.Relocalize();
    }

  }

}
