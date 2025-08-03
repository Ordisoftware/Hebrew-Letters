/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Updates localization strings to the whole application.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  [SuppressMessage("Major Code Smell", "S2589:Boolean expressions should not be gratuitous", Justification = "Analysis error")]
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
      MainForm.Instance.EditWord.CheckClipboardContentType();
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
