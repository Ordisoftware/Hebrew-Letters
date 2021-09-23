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
/// <edited> 2021-08 </edited>
using System;
using System.Drawing;
using System.Threading.Tasks;
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
      new Task(InitializeIconsAndSound).Start();
      Interlocks.Take();
      SystemManager.TryCatch(() => { Icon = new Icon(Globals.ApplicationIconFilePath); });
      Text = Globals.AssemblyTitle;
      ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
      SystemEvents.SessionEnding += SessionEnding;
      TextBoxEx.ActionUndo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionRedo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionCut.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionPaste.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionDelete.Click += TextBoxData_ContextMenuAction_Click;
      NativeMethods.ClipboardViewerNext = NativeMethods.SetClipboardViewer(Handle);
      if ( !Globals.IsDebugExecutable ) // TODO remove when ready
      {
        ActionViewNotebook.Visible = false;
        ActionOpenTermLettriq.Visible = false;
        ActionSaveTermLettriq.Visible = false;
      }
      if ( !Globals.IsDebugExecutable ) // TODO remove when ready
      {
        ActionGematriaCombinations.Visible = false;
        ActionGematriaCombinations.Tag = int.MinValue;
        ActionGematriaCombinationsSeparator.Visible = false;
        ActionGematriaCombinationsSeparator.Tag = int.MinValue;
      }
    }

    /// <summary>
    /// Do Form Load event.
    /// </summary>
    private void DoFormLoad(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      EditConcordance.Minimum = HebrewAlphabet.ConcordanceFirst - 1;
      EditConcordance.Maximum = HebrewAlphabet.ConcordanceLast;
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
      InitializeTheme();
      InitializeDialogsDirectory();
      Program.Settings.CurrentView = ViewMode.Analysis;
      LoadData();
      Globals.IsReady = true;
      EditWord.Redraw();
      TimerProcesses_Tick(null, null);
      SelectLetter_SelectedIndexChanged(SelectLetter, EventArgs.Empty);
      LettersNavigator.Refresh();
      UpdateDataControls(SelectLetter);
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
    }

    /// <summary>
    /// Do Form Shown event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void DoFormShown(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      if ( !Program.StartupWord.IsNullOrEmpty() )
      {
        ActionReset.Visible = true;
        EditWord.TextBox.Text = Program.StartupWord;
        EditWord.Focus(LettersControlFocusSelect.None);
        EditWord.TextBox.Refresh();
      }
      else
        ActionReset.Visible = false;
      ToolStrip.SetDropDownOpening();
      EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
      EditWord.TextBox.MaxLength = (int)Settings.HebrewTextBoxMaxLength;
      EditSentence_FontChanged(null, null);
      Globals.ChronoStartingApp.Stop();
      if ( Globals.IsDatabaseUpgraded && DisplayManager.QueryYesNo(SysTranslations.AskToCheckDataAfterDbUpgraded.GetLang()) )
      {
        Globals.ChronoStartingApp.Start();
        SetView(ViewMode.Letters, false);
      }
      else
      {
        Globals.ChronoStartingApp.Start();
        SetView(ViewMode.Analysis, false);
      }
      if ( Settings.FirstLaunch )
      {
        Settings.FirstLaunch = false;
        ActionShowMethodNotice.PerformClick();
      }
      Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                             AppTranslations.NoticeKeyboardShortcuts,
                                                             true, false, 340, 450, false, false);
      Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
      Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
      Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 10, 10);
      Globals.ChronoStartingApp.Stop();
      Settings.BenchmarkStartingApp = Globals.ChronoStartingApp.ElapsedMilliseconds;
      SystemManager.TryCatch(Settings.Save);
      ProcessNewsAndCommandLine();
      if ( Globals.IsDebugExecutable ) // TODO remove when ready
        ActionViewNotebook.Visible = true;
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
      Interlocks.Release();
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

    /// <summary>
    /// WndProc override.
    /// </summary>
    protected override void WndProc(ref Message m)
    {
      switch ( m.Msg )
      {
        case NativeMethods.WM_QUERYENDSESSION:
          SessionEnding(this, null);
          break;
        case NativeMethods.WM_DRAWCLIPBOARD:
          CheckClipboardContentType();
          break;
        default:
          base.WndProc(ref m);
          break;
      }
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
    /// Initialize icons
    /// </summary>
    private void InitializeIconsAndSound()
    {
      SoundItem.Initialize();
      SystemManager.TryCatch(() => new System.Media.SoundPlayer(Globals.EmptySoundFilePath).Play());
      SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
    }

    /// <summary>
    /// Set colors.
    /// </summary>
    internal void InitializeTheme()
    {
      // Analyser
      EditWord.LettersBackColor = Settings.ColorLettersPanel;
      EditWord.InputBackColor = Settings.ColorHebrewWordTextBox;
      SelectAnalyze.BackColor = Settings.ColorMeaningsPanel;
      EditSentence.BackColor = Settings.ColorSentenceTextBox;
      EditGematriaFull.BackColor = Settings.ColorGematriaTextBox;
      EditGematriaSimple.BackColor = Settings.ColorGematriaTextBox;
      EditTranscription.BackColor = Settings.ColorHebrewWordTextBox;
      EditDictionary.BackColor = Settings.ColorHebrewWordTextBox;
      EditMemo.BackColor = Settings.ColorHebrewWordTextBox;
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
      // Notebook
      ListNotebookLetters.DefaultCellStyle.BackColor = Settings.ColorLettersPanel;
      ListNotebookWords.DefaultCellStyle.BackColor = Settings.ColorHebrewWordTextBox;
      ListNotebookLetters.SetBackColor(Settings.ColorLettersPanel);
      ListNotebookWords.SetBackColor(Settings.ColorHebrewWordTextBox);
    }

    /// <summary>
    /// Show news and process command line options.
    /// </summary>
    private void ProcessNewsAndCommandLine()
    {
      if ( Globals.IsSettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
        SystemManager.TryCatch(CommonMenusControl.Instance.ShowLastNews);
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

  }

}
