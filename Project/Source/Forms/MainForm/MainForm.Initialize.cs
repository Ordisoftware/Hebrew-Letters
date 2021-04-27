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
/// <created> 2019-01 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    /// <summary>
    /// Do constructor.
    /// </summary>
    private void DoConstructor()
    {

      Globals.ChronoStartingApp.Start();
      InitializeComponent();
      SoundItem.Initialize();
      Text = Globals.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      SystemManager.TryCatch(() => { Icon = new Icon(Globals.ApplicationIconFilePath); });
      ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
      CreateProvidersLinks();
      TextBoxEx.ActionUndo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionRedo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionCut.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionPaste.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionDelete.Click += TextBoxData_ContextMenuAction_Click;
      NativeMethods.ClipboardViewerNext = NativeMethods.SetClipboardViewer(Handle);
    }

    /// <summary>
    /// Create providers links menu items.
    /// </summary>
    private void CreateProvidersLinks()
    {
      ContextMenuSearchOnline.InitializeFromProviders(HebrewGlobals.WebProvidersWord, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        HebrewTools.OpenWordProvider((string)menuitem.Tag, EditLetters.Input.Text);
        EditLetters.Focus();
      });
    }

    /// <summary>
    /// Create system information menu items.
    /// </summary>
    public void CreateSystemInformationMenu()
    {
      CommonMenusControl.CreateInstance(ToolStrip,
                                        ref ActionInformation,
                                        AppTranslations.NoticeNewFeatures,
                                        ActionAbout_Click,
                                        ActionWebCheckUpdate_Click,
                                        ActionViewLog_Click,
                                        ActionViewStats_Click);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Initialize special menus.
    /// </summary>
    public void InitializeSpecialMenus()
    {
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
      if ( Settings.WebLinksMenuEnabled )
        ActionWebLinks.InitializeFromWebLinks(InitializeSpecialMenus);
    }

    /// <summary>
    /// Do Form Load event.
    /// </summary>
    private void DoFormLoad(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      InitializeTheme();
      InitializeDialogsDirectory();
      ProcessLocksTable.Lock();
      EditLetters.Input.MaxLength = (int)Settings.HebrewTextBoxMaxLength;
      Program.Settings.CurrentView = ViewMode.Analysis;
      EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
      EditSentence_FontChanged(null, null);
      SystemManager.TryCatch(() => new System.Media.SoundPlayer(Globals.EmptySoundFilePath).Play());
      SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
      StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
      Globals.ChronoStartingApp.Stop();
      var lastdone = Settings.CheckUpdateLastDone;
      bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup,
                                     ref lastdone,
                                     Settings.CheckUpdateAtStartupDaysInterval,
                                     true);
      Settings.CheckUpdateLastDone = lastdone;
      if ( exit )
      {
        SystemManager.Exit();
        return;
      }
      Globals.ChronoStartingApp.Start();
      try
      {
        Globals.ChronoLoadData.Start();
        CreateSchemaIfNotExists();
        CreateDataIfNotExists(false);
        MeaningsTableAdapter.Fill(DataSet.Meanings);
        LettersTableAdapter.Fill(DataSet.Letters);
        Globals.ChronoLoadData.Stop();
        Settings.BenchmarkLoadData = Globals.ChronoLoadData.ElapsedMilliseconds;
        SystemManager.TryCatch(Settings.Save);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.ApplicationMustExit.GetLang() + Globals.NL2 +
                                 SysTranslations.ContactSupport.GetLang());
        ex.Manage();
        Environment.Exit(-1);
      }
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
      TimerProcesses_Tick(null, null);
      Globals.IsReady = true;
      SelectLetter_SelectedIndexChanged(SelectLetter, EventArgs.Empty);
      LettersNavigator.Refresh();
      UpdateDataControls(SelectLetter);
    }

    /// <summary>
    /// Set the initial directories of dialog boxes.
    /// </summary>
    private void InitializeDialogsDirectory()
    {
      string directory = Settings.GetExportDirectory();
      SaveImageDialog.InitialDirectory = directory;
      SaveImageDialog.Filter = Program.ImageExportTargets.CreateFilters();
    }

    /// <summary>
    /// Set colors.
    /// </summary>
    internal void InitializeTheme()
    {
      // Analyser
      EditLetters.LettersBackColor = Settings.ColorLettersPanel;
      EditLetters.InputBackColor = Settings.ColorHebrewWordTextBox;
      SelectAnalyze.BackColor = Settings.ColorMeaningsPanel;
      EditSentence.BackColor = Settings.ColorSentenceTextBox;
      EditGematriaFull.BackColor = Settings.ColorGematriaTextBox;
      EditGematriaSimple.BackColor = Settings.ColorGematriaTextBox;
      // Data
      SelectLetter.BackColor = Settings.ColorLettersPanel == SystemColors.Window
                               ? Settings.ColorGematriaTextBox
                               : Settings.ColorLettersPanel;
      TextBoxName.BackColor = SelectLetter.BackColor;
      TextBoxValueSimple.BackColor = Settings.ColorGematriaTextBox;
      TextBoxValueFull.BackColor = Settings.ColorGematriaTextBox;
      TextBoxStructure.BackColor = Settings.ColorSentenceTextBox;
      TextBoxFunction.BackColor = Settings.ColorSentenceTextBox;
      TextBoxVerb.BackColor = Settings.ColorSentenceTextBox;
      TextBoxNegative.BackColor = Settings.ColorSentenceTextBox;
      TextBoxPositive.BackColor = Settings.ColorSentenceTextBox;
      EditMeanings.RowTemplate.DefaultCellStyle.BackColor = Settings.ColorSentenceTextBox;
      foreach ( DataGridViewRow row in EditMeanings.Rows )
        row.DefaultCellStyle.BackColor = Settings.ColorSentenceTextBox;
    }

    /// <summary>
    /// Do Form Shown event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void DoFormShown(object sender, EventArgs e)
    {
      SystemManager.TryCatch(Settings.Save);
      if ( Globals.IsExiting ) return;
      if ( !Program.StartupWord.IsNullOrEmpty() )
      {
        ActionReset.Visible = true;
        EditLetters.Input.Text = Program.StartupWord;
        EditLetters.Focus(LettersControlFocusSelect.None);
        EditLetters.TextBox.Refresh();
      }
      else
        ActionReset.Visible = false;
      ToolStrip.SetDropDownOpening();
      Globals.ChronoStartingApp.Stop();
      Settings.BenchmarkStartingApp = Globals.ChronoStartingApp.ElapsedMilliseconds;
      if ( Globals.IsDatabaseUpgraded && DisplayManager.QueryYesNo(SysTranslations.AskToCheckDataAfterDbUpgraded.GetLang()) )
        SetView(ViewMode.Data, false);
      else
        SetView(ViewMode.Analysis, false);
      if ( Settings.FirstLaunch )
      {
        Settings.FirstLaunch = false;
        SystemManager.TryCatch(Settings.Save);
        ActionShowMethodNotice.PerformClick();
      }
      Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                             AppTranslations.NoticeKeyboardShortcuts,
                                                             true, false, 340, 440, false, false);
      Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
      Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
      Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 10, 10);
      if ( Globals.IsSettingsUpgraded )
        SystemManager.TryCatch(() =>
        {
          CommonMenusControl.Instance
                            .ActionViewVersionNews
                            .DropDownItems
                            .Cast<ToolStripItem>()
                            .LastOrDefault()?
                            .PerformClick();
        });
    }

    /// <summary>
    /// Do Form Closing event.
    /// </summary>
    private void DoFormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( Globals.IsExiting ) return;
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing )
      {
        Globals.IsExiting = true;
        return;
      }
      if ( !Globals.AllowClose )
      {
        e.Cancel = true;
        return;
      }
      if ( EditConfirmClosing.Checked && !Globals.IsSessionEnding )
        if ( !DisplayManager.QueryYesNo(SysTranslations.AskToExitApplication.GetLang()) )
          e.Cancel = true;
        else
          Globals.IsExiting = true;
    }

    /// <summary>
    /// Do Form CLosed event.
    /// </summary>
    private void DoFormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.CurrentView = ViewMode.Analysis;
      Globals.IsExiting = true;
      Globals.IsSessionEnding = true;
      Globals.AllowClose = true;
      ProcessLocksTable.Unlock();
      Settings.Store();
      TimerTooltip.Stop();
      FormsHelper.CloseAll();
    }

    /// <summary>
    /// Do Session Ending event.
    /// </summary>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      if ( Globals.IsExiting || Globals.IsSessionEnding ) return;
      Close();
    }

  }

}
