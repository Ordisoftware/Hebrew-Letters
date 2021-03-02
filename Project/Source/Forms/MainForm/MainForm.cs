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
/// <created> 2016-04 </created>
/// <edited> 2021-02 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public MainForm Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MainForm()
    {
      Instance = new MainForm();
    }

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    private readonly Properties.Settings Settings = Program.Settings;

    /// <summary>
    /// INdicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    /// <summary>
    /// Indicate if database has been upgraded.
    /// </summary>
    private bool IsDBUpgraded;

    /// <summary>
    /// Indicate if data is read only.
    /// </summary>
    private bool IsReadOnly;

    /// <summary>
    /// Indicate the last term searched.
    /// </summary>
    private string LastTermSearched;

    /// <summary>
    /// Indicate if data has changed to refrech the analysis.
    /// </summary>
    private bool DataChanged;

    /// <summary>
    /// Indicate data edition mutex.
    /// </summary>
    private bool EditMutex;

    /// <summary>
    /// Indicate add new meaning mutex.
    /// </summary>
    private bool AddNewRowMutex;

    /// <summary>
    /// Enable double-buffering.
    /// </summary>
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000; // + WS_EX_COMPOSITED
        //cp.Style &= ~0x02000000;  // - WS_CLIPCHILDREN
        return cp;
      }
    }

    /// <summary>
    /// Clipboard monitoring.
    /// </summary>
    protected override void WndProc(ref Message m)
    {
      const int WM_DRAWCLIPBOARD = 0x308;
      switch ( m.Msg )
      {
        case WM_DRAWCLIPBOARD:
          CheckClipboardContentType();
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    /// <summary>
    /// Check clipboard content type.
    /// </summary>
    private void CheckClipboardContentType()
    {
      string str = Clipboard.GetText();
      if ( str.IsNullOrEmpty() )
      {
        LabelClipboardContentType.Text = SysTranslations.EmptySlot.GetLang().Trim('(', ')');
        ActionPaste.Enabled = false;
      }
      if ( HebrewAlphabet.IsValidHebrew(str) )
      {
        LabelClipboardContentType.Text = AppTranslations.ClipboardHebrew.GetLang(); ;
        ActionPaste.Enabled = true;
      }
      else
      if ( HebrewAlphabet.IsValidUnicode(str) )
      {
        LabelClipboardContentType.Text = AppTranslations.ClipboardUnicode.GetLang(); ;
        ActionPaste.Enabled = true;
      }
      else
      {
        LabelClipboardContentType.Text = AppTranslations.ClipboardUncertain.GetLang(); ;
        ActionPaste.Enabled = true;
      }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      Globals.ChronoLoadApp.Start();
      InitializeComponent();
      SoundItem.Initialize();
      Text = Globals.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      SystemManager.TryCatch(() => { Icon = new Icon(Globals.ApplicationIconFilePath); });
      CreateProvidersLinks();
      TextBoxEx.ActionUndo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionRedo.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionCut.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionPaste.Click += TextBoxData_ContextMenuAction_Click;
      TextBoxEx.ActionDelete.Click += TextBoxData_ContextMenuAction_Click;
      NativeMethods.ClipboardViewerNext = NativeMethods.SetClipboardViewer(Handle);
    }

    /// <summary>
    /// Create system information menu items.
    /// </summary>
    public void CreateSystemInformationMenu()
    {
      CommonMenusControl.Instance = new CommonMenusControl(ActionAbout_Click,
                                                           ActionWebCheckUpdate_Click,
                                                           ActionViewLog_Click,
                                                           ActionViewStats_Click);
      var menu = CommonMenusControl.Instance.MenuInformation;
      var list = new List<ToolStripItem>();
      foreach ( ToolStripItem item in menu.DropDownItems ) list.Add(item);
      menu.DropDownItems.Clear();
      ActionInformation.DropDownItems.Clear();
      ActionInformation.DropDownItems.AddRange(list.ToArray());
      CommonMenusControl.Instance.InitializeVersionNewsMenuItems(AppTranslations.NoticeNewFeatures);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Create providers and web links menu items.
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
    /// Create providers links menu items.
    /// </summary>
    private void CreateProvidersLinks()
    {
      ContextMenuSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        string str = HebrewAlphabet.ToUnicode(HebrewAlphabet.SetFinal(EditLetters.Input.Text, true));
        SystemManager.OpenWebLink(( (string)menuitem.Tag ).Replace("%WORD%", str));
        EditLetters.Focus();
      });
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      InitializeTheme();
      InitializeDialogsDirectory();
      ProcessLocksTable.Lock();
      LabelClipboardContentType.Left = ActionCopyToUnicode.Left + ActionCopyToUnicode.Width / 2
                                     - LabelClipboardContentType.Width / 2;
      EditLetters.Input.MaxLength = (int)Settings.HebrewTextBoxMaxLength;
      Program.Settings.CurrentView = ViewMode.Analyse;
      EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
      EditSentence_FontChanged(null, null);
      SystemManager.TryCatch(() => new System.Media.SoundPlayer(Globals.EmptySoundFilePath).Play());
      SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Process.GetCurrentProcess().Id,
                                                                   Settings.ApplicationVolume));
      StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
      Globals.ChronoLoadApp.Stop();
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
      Globals.ChronoLoadApp.Start();
      try
      {
        var Chrono = new Stopwatch();
        Chrono.Start();
        IsDBUpgraded = CreateSchemaIfNotExists();
        CreateDataIfNotExists(false);
        MeaningsTableAdapter.Fill(DataSet.Meanings);
        LettersTableAdapter.Fill(DataSet.Letters);
        Chrono.Stop();
        Settings.BenchmarkLoadData = Chrono.ElapsedMilliseconds;
        SystemManager.TryCatch(Settings.Save);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.ApplicationMustExit[Language.FR] + Globals.NL2 +
                                 SysTranslations.ContactSupport[Language.FR]);
        ex.Manage();
        Environment.Exit(-1);
      }
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
      TimerProcesses_Tick(null, null);
      Globals.IsReady = true;
      SelectLetter_SelectedIndexChanged(SelectLetter, EventArgs.Empty);
      UpdateButtons(SelectLetter);
      CheckClipboardContentType();
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
      // Parameters
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
    }

    /// <summary>
    /// Event handler. Called by MainForm for form shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      SystemManager.TryCatch(Settings.Save);
      if ( Globals.IsExiting ) return;
      if ( !Program.StartupWord.IsNullOrEmpty() )
      {
        ActionReset.Visible = true;
        EditLetters.Input.Text = Program.StartupWord;
        EditLetters.Input.SelectionStart = 0;
        EditLetters.Input.SelectionLength = 0;
        EditLetters.TextBox.Refresh();
      }
      else
        ActionReset.Visible = false;
      Globals.ChronoLoadApp.Stop();
      Settings.BenchmarkStartingApp = Globals.ChronoLoadApp.ElapsedMilliseconds;
      if ( IsDBUpgraded && DisplayManager.QueryYesNo(SysTranslations.AskToCheckParametersAfterDatabaseUpgraded.GetLang()) )
        SetView(ViewMode.Settings, false);
      else
        SetView(ViewMode.Analyse, false);
      if ( Settings.FirstLaunch )
      {
        Settings.FirstLaunch = false;
        SystemManager.TryCatch(Settings.Save);
        ActionShowMethodNotice.PerformClick();
      }
      Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                             AppTranslations.NoticeKeyboardShortcuts,
                                                             true, false, 340, 460, false, false);
      Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
      Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
      Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 10, 10);
      Globals.ChronoLoadApp.Stop();
      if ( Globals.SettingsUpgraded )
        SystemManager.TryCatch(() =>
        {
          var menuitem = CommonMenusControl.Instance
                                           .ActionViewVersionNews
                                           .DropDownItems
                                           .Cast<ToolStripItem>()
                                           .LastOrDefault();
          if ( menuitem != null ) menuitem.PerformClick();
        });
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( Globals.IsExiting ) return;
      if ( !Globals.IsReady ) return;
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
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.CurrentView = ViewMode.Analyse;
      Settings.Store();
      ProcessLocksTable.Unlock();
    }

    /// <summary>
    /// Event handler. Called by MainForm for form location and size changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_WindowsChanged(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      if ( !Globals.IsReady ) return;
      if ( !Visible ) return;
      if ( WindowState != FormWindowState.Normal ) return;
      EditScreenNone.PerformClick();
    }

    /// <summary>
    /// Session ending.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      Globals.IsExiting = true;
      Globals.IsSessionEnding = true;
      Globals.AllowClose = true;
      foreach ( Form form in Application.OpenForms )
        if ( form != this && form.Visible )
          try { form.Close(); }
          catch { }
      Close();
    }

    /// <summary>
    /// Update preferences menu state.
    /// </summary>
    private void TimerProcesses_Tick(object sender, EventArgs e)
    {
      //if ( !SQLiteOdbcHelper.CheckProcessConcurency() ) return;
      IsReadOnly = ProcessLocksTable.IsReadOnly();
      Text = Globals.AssemblyTitle;
      if ( IsReadOnly ) Text += " - " + AppTranslations.ReadOnly.GetLang();
      TextBoxPositive.ReadOnly = IsReadOnly;
      TextBoxNegative.ReadOnly = IsReadOnly;
      TextBoxVerb.ReadOnly = IsReadOnly;
      TextBoxStructure.ReadOnly = IsReadOnly;
      TextBoxFunction.ReadOnly = IsReadOnly;
      EditMeanings.ReadOnly = IsReadOnly;
      ActionAddMeaning.Enabled = !IsReadOnly;
      ActionDeleteMeaning.Enabled = !IsReadOnly;
      ActionPreferences.Enabled = !IsReadOnly;
      ActionRestoreDefaults.Enabled = !IsReadOnly;
      TimerProcesses.Enabled = IsReadOnly;
    }

    /// <summary>
    /// Timer event for tooltips.
    /// </summary>
    private void TimerTooltip_Tick(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      var item = (ToolStripItem)LastToolTip.Tag;
      var location = new Point(item.Bounds.Left, item.Bounds.Top + ActionExit.Height + 5);
      LastToolTip.Tag = sender;
      LastToolTip.Show(item.ToolTipText, ToolStrip, location, 3000);
      TimerTooltip.Enabled = false;
    }

    /// <summary>
    /// Show tooltip on mouse enter event.
    /// </summary>
    private void ShowToolTipOnMouseEnter(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      if ( !( sender is ToolStripItem ) ) return;
      if ( LastToolTip.Tag == sender ) return;
      LastToolTip.Tag = sender;
      if ( ( (ToolStripItem)sender ).ToolTipText == "" ) return;
      TimerTooltip.Enabled = true;
    }

    /// <summary>
    /// Hide tooltip on mouse leave event.
    /// </summary>
    private void ShowToolTipOnMouseLeave(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      TimerTooltip.Enabled = false;
      LastToolTip.Tag = null;
      LastToolTip.Hide(ToolStrip);
    }

    /// <summary>
    /// Event handler. Called by EditSentence for font changed.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void EditSentence_FontChanged(object sender, EventArgs e)
    {
      double top = ActionCopyToResult.Top;
      top += ActionCopyToResult.Height / 2;
      top -= EditSentence.Height / 2;
      EditSentence.Top = (int)Math.Round(top, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Event handler. Called by ActionViewAnalysis for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewAnalysis_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Analyse);
    }

    /// <summary>
    /// Event handler. Called by ActionViewLetters for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewLetters_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Settings);
    }

    /// <summary>
    /// Event handler. Called by ActionNewInstance for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionNewInstance_Click(object sender, EventArgs e)
    {
      SystemManager.RunShell(Process.GetCurrentProcess().MainModule.FileName);
    }

    /// <summary>
    /// Event handler. Called by ActionSearchTerm for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchTerm_Click(object sender, EventArgs e)
    {
      ActionViewLetters.PerformClick();
      var formSearch = new SearchTermBox();
      formSearch.EditTerm.Text = LastTermSearched;
      if ( formSearch.ShowDialog() != DialogResult.OK ) return;
      LastTermSearched = formSearch.EditTerm.Text.ToLower().RemoveDiacritics();
      if ( !SearchTermResultsBox.Run(LastTermSearched, out var code, out var meaning) ) return;

      LettersBindingSource.Position = LettersBindingSource.Find("Code", code);
      var prop = MeaningsBindingSource.GetItemProperties(null).Find("Meaning", true);
      int pos = MeaningsBindingSource.Find(prop, meaning);
      if ( pos >= 0 )
      {
        MeaningsBindingSource.Position = pos;
        EditMeanings.Focus();
      }
      else
      {
        check(Instance.TextBoxPositive);
        check(Instance.TextBoxNegative);
        check(Instance.TextBoxVerb);
        check(Instance.TextBoxStructure);
        check(Instance.TextBoxFunction);
      }
      void check(TextBox textbox) { if ( textbox.Text == meaning ) textbox.Focus(); }
    }

    /// <summary>
    /// Event handler. Called by ActionResetWinSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToRestoreWindowPosition.GetLang()) )
        Settings.RestoreMainForm();
    }

    /// <summary>
    /// Event handler. Called by SelectScreenPosition for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void EditScreenPosition_Click(object sender, EventArgs e)
    {
      DoScreenPosition(sender, e);
    }

    /// <summary>
    /// Event handler. Called by ActionShowKeyboardNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionShowKeyboardNotice_Click(object sender, EventArgs e)
    {
      Globals.NoticeKeyboardShortcutsForm.Popup();
    }

    /// <summary>
    /// Event handler. Called by ActionPreferences for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionPreferences_Click(object sender, EventArgs e)
    {
      if ( SystemManager.ApplicationInstancesCount > 1 )
      {
        ActionPreferences.Enabled = false;
        return;
      }
      try
      {
        PreferencesForm.Run();
        EditLetters.InputMaxLength = (int)Settings.HebrewTextBoxMaxLength;
        InitializeSpecialMenus();
        InitializeDialogsDirectory();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Event handler. Called by ActionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Event handler. Called by ActionExit for mouse up events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_MouseUp(object sender, MouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right )
        ActionExit_Click(ActionExit, null);
    }

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void ActionAbout_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionWebCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void ActionWebCheckUpdate_Click(object sender, EventArgs e)
    {
      var lastdone = Settings.CheckUpdateLastDone;
      bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup,
                                     ref lastdone,
                                     Settings.CheckUpdateAtStartupDaysInterval,
                                     e == null);
      Settings.CheckUpdateLastDone = lastdone;
      if ( exit )
        Close();
      else
      if ( Visible )
        BringToFront();
    }

    public void ActionViewLog_Click(object sender, EventArgs e)
    {
      DebugManager.TraceForm.Popup();
    }

    private void ActionViewStats_Click(object sender, EventArgs e)
    {
      StatisticsForm.Run();
    }

    private void EditShowSuccessDialogs_CheckedChanged(object sender, EventArgs e)
    {
      DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
    }

    private void ProcessHTMLBrowser(HTMLBrowserForm form)
    {
      if ( form.WindowState == FormWindowState.Minimized )
        form.WindowState = FormWindowState.Normal;
      form.Show();
      form.BringToFront();
    }

    private void ActionShowMethodNotice_Click(object sender, EventArgs e)
    {
      ProcessHTMLBrowser(Program.MethodNoticeForm);
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      ProcessHTMLBrowser(Program.GrammarGuideForm);
    }

    private void ActionOpenWebsiteURL_Click(object sender, EventArgs e)
    {
      string url = (string)( (ToolStripItem)sender ).Tag;
      SystemManager.OpenWebLink(url);
    }

    private void ActionRestoreDefaults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetData.GetLang()) )
      {
        string word = EditLetters.Input.Text;
        CreateDataIfNotExists(true);
        ActionClear.PerformClick();
        ActionReset.PerformClick();
        EditLetters.Input.Text = word;
        ApplicationStatistics.UpdateDBFileSizeRequired = true;
        ApplicationStatistics.UpdateDBMemorySizeRequired = true;
        UpdateButtons(null);
      }
    }

    private void EditGematriaSimple_TextChanged(object sender, EventArgs e)
    {
      var textbox = sender as TextBox;
      if ( textbox.Text == "0" ) textbox.Text = "";
    }

    private void ActionDelFirst_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text.Length < 1 ) return;
      EditLetters.Input.Text = EditLetters.Input.Text.Remove(EditLetters.Input.Text.Length - 1, 1);
      EditLetters.Focus(false);
      EditLetters.Input.SelectionStart = EditLetters.Input.TextLength;
    }

    private void ActionDelLast_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text.Length < 1 ) return;
      EditLetters.Input.Text = EditLetters.Input.Text.Remove(0, 1);
      EditLetters.Focus(false);
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      EditLetters.Input.Text = Program.StartupWord;
      EditLetters.Focus(false);
    }

    private void EditLetters_InputTextChanged(object sender, EventArgs e)
    {
      UpdateControls();
      DoAnalyse();
    }

    private void ActionSearchOnline_Click(object sender, EventArgs e)
    {
      ContextMenuSearchOnline.Show(ActionSearchOnline, new Point(0, ActionSearchOnline.Height));
    }

    private void UpdateControls()
    {
      bool enabled = EditLetters.Input.Text.Length >= 1;
      ActionReset.Enabled = !Program.StartupWord.IsNullOrEmpty();
      ActionClear.Enabled = enabled;
      ActionDelFirst.Enabled = enabled;
      ActionDelLast.Enabled = enabled;
      ActionCopyToHebrew.Enabled = enabled;
      ActionCopyToUnicode.Enabled = enabled;
      ActionCopyToMeanings.Enabled = enabled;
      ActionViewAllMeaningsList.Enabled = enabled;
      ActionScreenshot.Enabled = enabled;
      ActionSaveScreenshot.Enabled = enabled;
      ActionSearchOnline.Enabled = enabled;
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      EditLetters.Input.SelectAll();
      EditLetters.Input.Paste("");
      EditSentence.Text = "";
      EditGematriaSimple.Text = "";
      EditGematriaFull.Text = "";
      SelectAnalyze.Controls.Clear();
      UpdateControls();
      EditLetters.Focus();
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      EditLetters.Focus(true);
      TextBoxEx.ActionPaste.PerformClick();
    }

    private void ActionCopyToHebrew_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      string str = EditLetters.Input.Text;
      if ( EditCopyWithFinalLetter.Checked )
        str = HebrewAlphabet.SetFinal(str, true);
      Clipboard.SetText(str);
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditLetters.Focus(true);
    }

    private void ActionCopyToUnicode_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      string str = EditLetters.Input.Text;
      if ( EditCopyWithFinalLetter.Checked )
        str = HebrewAlphabet.SetFinal(str, true);
      Clipboard.SetText(HebrewAlphabet.ToUnicode(str));
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditLetters.Focus(true);
    }

    private void MeaningComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string str = "";
      foreach ( var control in SelectAnalyze.Controls )
        if ( control is ComboBox )
          str += ( ( control as ComboBox ).Text ?? "" ) + " ";
      str = str == "" ? "" : str.Remove(str.Length - 1, 1);
      EditSentence.Text = str;
    }

    private void EditSentence_TextChanged(object sender, EventArgs e)
    {
      ActionCopyToResult.Enabled = EditSentence.Text != "";
    }

    private void ActionViewAllMeaningsList_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      new ShowTextForm("", GetMeaningsText().Replace(Globals.NL, Globals.NL2), false, true, 600, 400, true, true).ShowDialog();
      EditLetters.Focus();
    }

    private string GetMeaningsText()
    {
      var list = SelectAnalyze.Controls
                              .OfType<Label>()
                              .Where(label => label.Text != "")
                              .Select(label => label.Text + " : " + string.Join(", ", (object[])( (ComboBox)label.Tag ).Tag));
      return string.Join(Globals.NL, list);
    }

    private void ActionCopyToMeanings_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      Clipboard.SetText(GetMeaningsText());
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditLetters.Focus();
    }

    private void ActionScreenshot_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      Clipboard.SetImage(this.GetBitmap());
      DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                        Globals.ScreenshotSoundFilePath);
      EditLetters.Focus();
    }

    private void ActionSaveScreenshot_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      string str = EditLetters.Input.Text;
      if ( EditCopyWithFinalLetter.Checked )
        str = HebrewAlphabet.SetFinal(str, true);
      SaveImageDialog.FileName = HebrewAlphabet.ToUnicode(str);
      for ( int index = 0; index < Program.ImageExportTargets.Count; index++ )
        if ( Program.ImageExportTargets.ElementAt(index).Key == Settings.ExportImagePreferredTarget )
          SaveImageDialog.FilterIndex = index + 1;
      if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return;
      string filePath = SaveImageDialog.FileName;
      var bitmap = this.GetBitmap();
      bitmap.Save(filePath, Program.ImageExportTargets.GetFormat(Path.GetExtension(filePath)));
      DisplayManager.ShowSuccessOrSound(SysTranslations.ViewSavedToFile.GetLang(filePath),
                                        Globals.ScreenshotSoundFilePath);
      if ( Settings.AutoOpenExportFolder )
        SystemManager.RunShell(Path.GetDirectoryName(filePath));
      if ( Settings.AutoOpenExportedFile )
        SystemManager.RunShell(filePath);
      EditLetters.Focus();
    }

    private void ActionCopyToResult_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text == "" ) return;
      Clipboard.SetText(EditSentence.Text);
      if ( EditCopyToClipboardCloseApp.Checked ) Close();
      EditSentence.Focus();
    }

    private void EditLetters_ViewLetterDetails(LettersControl sender, string code)
    {
      ActionViewLetters.PerformClick();
      SelectLetter.SelectedIndex = SelectLetter.FindStringExact(code);
    }

    public void EditDialogBoxesSettings_CheckedChanged(object sender, EventArgs e)
    {
      DisplayManager.AdvancedFormUseSounds = EditSoundsEnabled.Checked;
      DisplayManager.FormStyle = EditUseAdvancedDialogBoxes.Checked
                                 ? MessageBoxFormStyle.Advanced
                                 : MessageBoxFormStyle.System;
      switch ( DisplayManager.FormStyle )
      {
        case MessageBoxFormStyle.System:
          DisplayManager.IconStyle = EditSoundsEnabled.Checked
                                     ? MessageBoxIconStyle.ForceInformation
                                     : MessageBoxIconStyle.ForceNone;
          break;
        case MessageBoxFormStyle.Advanced:
          DisplayManager.IconStyle = MessageBoxIconStyle.ForceInformation;
          break;
      }

    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() )
        DataSet.RejectChanges();
      UpdateButtons(sender);
      EditMeanings.Focus();
    }

    private void ActionSave_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() )
        if ( IsReadOnly )
          DataSet.RejectChanges();
        else
        {
          TableAdapterManager.UpdateAll(DataSet);
          ApplicationStatistics.UpdateDBFileSizeRequired = true;
          ApplicationStatistics.UpdateDBMemorySizeRequired = true;
          DataChanged = true;
        }
      UpdateButtons(sender);
      EditMeanings.Focus();
    }

    private void ActionFirst_Click(object sender, EventArgs e)
    {
      SelectLetter.SelectedIndex = 0;
      EditMeanings.Focus();
    }

    private void ActionPrevious_Click(object sender, EventArgs e)
    {
      if ( SelectLetter.SelectedIndex > 0 ) SelectLetter.SelectedIndex--;
      if ( SelectLetter.SelectedIndex == 0 ) ActiveControl = ActionNext;
      EditMeanings.Focus();
    }

    private void ActionNext_Click(object sender, EventArgs e)
    {
      if ( SelectLetter.SelectedIndex < SelectLetter.Items.Count - 1 ) SelectLetter.SelectedIndex++;
      if ( SelectLetter.SelectedIndex == SelectLetter.Items.Count - 1 ) ActiveControl = ActionPrevious;
      EditMeanings.Focus();
    }

    private void ActionLast_Click(object sender, EventArgs e)
    {
      SelectLetter.SelectedIndex = SelectLetter.Items.Count - 1;
      EditMeanings.Focus();
    }

    private void SelectLetter_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( !SelectLetter.Enabled ) return;
      EditMutex = true;
      ActionFirst.Enabled = SelectLetter.SelectedIndex > 0;
      ActionPrevious.Enabled = ActionFirst.Enabled;
      ActionLast.Enabled = SelectLetter.SelectedIndex < SelectLetter.Items.Count - 1;
      ActionNext.Enabled = ActionLast.Enabled;
    }

    private void LettersBindingSource_PositionChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      EditMutex = false;
      UpdateButtons(sender);
    }

    private void ActionAddMeaning_Click(object sender, EventArgs e)
    {
      var row = DataSet.Meanings.NewMeaningsRow();
      row.ID = Guid.NewGuid().ToString();
      row.LetterCode = SelectLetter.Text;
      row.Meaning = "";
      DataSet.Meanings.AddMeaningsRow(row);
      MeaningsBindingSource.ResetBindings(false);
      MeaningsBindingSource.MoveLast();
      EditMeanings.BeginEdit(false);
      AddNewRowMutex = true;
      UpdateButtons(sender);
    }

    private void ActionDeleteMeaning_Click(object sender, EventArgs e)
    {
      if ( MeaningsBindingSource.Count < 1 ) return;
      int pos = MeaningsBindingSource.Position;
      MeaningsBindingSource.RemoveCurrent();
      EditMeanings.EndEdit();
      int count = MeaningsBindingSource.Count;
      if ( count > 1 )
        if ( pos >= count )
        {
          MeaningsBindingSource.MoveFirst();
          MeaningsBindingSource.MoveLast();
        }
        else
          MeaningsBindingSource.Position = pos;
      UpdateButtons(sender);
    }

    private bool TextBoxDataContextMenuMutex;

    private void TextBoxData_ContextMenuEditOpening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ( TextBoxDataContextMenuMutex ) return;
      TextBoxDataContextMenuMutex = true;
      var textbox = TextBoxEx.GetTextBox(sender);
      ( (ContextMenuStrip)sender ).Enabled = (string)textbox.Tag != "data" || !IsReadOnly;
    }

    private void TextBoxData_ContextMenuEditOpened(object sender, EventArgs e)
    {
      TextBoxDataContextMenuMutex = false;
    }

    private void TextBoxData_TextChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( EditMutex ) return;
      EditMutex = true;
      LettersBindingSource.EndEdit();
      if ( sender != null ) UpdateButtons(sender, true);
      EditMutex = false;
    }

    private void TextBoxData_Leave(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      TextBoxData_TextChanged(null, null);
      UpdateButtons(null);
    }

    private void TextBoxData_ContextMenuAction_Click(object sender, EventArgs e)
    {
      var textbox = TextBoxEx.GetTextBox(sender);
      if ( textbox != null )
        if ( textbox.Tag is string )
          if ( (string)textbox.Tag == "data" )
            TextBoxData_TextChanged(sender, e);
    }

    private void EditMeanings_KeyDown(object sender, KeyEventArgs e)
    {
      if ( ( e.Control && e.KeyCode == Keys.Insert ) || ( e.Control && e.KeyCode == Keys.Add ) )
        ActionAddMeaning.PerformClick();
      else
      if ( ( e.Control && e.KeyCode == Keys.Delete ) || ( e.Control && e.KeyCode == Keys.Subtract ) )
        ActionDeleteMeaning.PerformClick();
      else
      if ( e.KeyCode == Keys.F2 || ( e.KeyCode == Keys.Enter && !EditMeanings.IsCurrentCellInEditMode ) )
        EditMeanings.BeginEdit(false);
      else
        return;
      e.Handled = true;
      e.SuppressKeyPress = true;
    }

    private void EditMeanings_KeyUp(object sender, KeyEventArgs e)
    {
      if ( e.KeyCode == Keys.Enter )
      {
        if ( AddNewRowMutex && ( (string)EditMeanings.CurrentCell.Value ).IsNullOrEmpty() )
        {
          EditMeanings.BeginEdit(false);
          AddNewRowMutex = true;
        }
        else
        if ( DataSet.HasChanges() )
        {
          AddNewRowMutex = false;
          UpdateButtons(sender);
        }
      }
      else
      if ( e.KeyCode == Keys.Escape )
      {
        if ( ( (string)EditMeanings.CurrentCell.Value ).IsNullOrEmpty() )
        {
          EditMeanings.CancelEdit();
          EditMeanings.EndEdit();
          EditMeanings.Rows.Remove(EditMeanings.CurrentRow);
          if ( EditMeanings.Rows.Count > 0 )
            EditMeanings.Rows[EditMeanings.Rows.Count - 1].Selected = true;
          AddNewRowMutex = false;
          UpdateButtons(sender);
        }
        else
        {
          EditMeanings.CancelEdit();
          EditMeanings.EndEdit();
        }
      }
    }

    private void EditMeanings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( EditMeanings.IsCurrentCellInEditMode ) return;
      EditMeanings.BeginEdit(false);
    }

    private void EditMeanings_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      UpdateButtons(sender, true);
      AddNewRowMutex = false;
    }

    private void EditMeanings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      var cell = EditMeanings[e.ColumnIndex, e.ColumnIndex];
      var str = (string)cell.Value;
      if ( str.StartsWith(" ") || str.EndsWith(" ") )
        cell.Value = str.Trim();
      UpdateButtons(sender);
    }

    private void EditMeanings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      UpdateButtons(sender);
    }

    private void EditMeanings_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.FormattedValue == DBNull.Value || (string)e.FormattedValue == "" )
        e.Cancel = true;
      else
        UpdateButtons(sender);
    }

    private void UpdateButtons(object sender, bool forceEditMode = false)
    {
      try
      {
        forceEditMode = forceEditMode || EditMeanings.IsCurrentCellInEditMode || AddNewRowMutex;
        if ( SelectLetter.SelectedItem == null ) return;
        var row = (Data.DataSet.LettersRow)( (DataRowView)SelectLetter.SelectedItem ).Row;
        ActionAddMeaning.Enabled = !IsReadOnly && !forceEditMode;
        ActionDeleteMeaning.Enabled = !IsReadOnly && !forceEditMode && row.GetMeaningsRows().Length > 0;
        ActionSave.Enabled = ( DataSet.HasChanges() && !forceEditMode ) || ( forceEditMode && sender is TextBox );
        ActionUndo.Enabled = ActionSave.Enabled;
        Globals.AllowClose = !ActionSave.Enabled && !forceEditMode;
        SelectLetter.Enabled = Globals.AllowClose;
        ActionViewAnalysis.Enabled = Globals.AllowClose;
        ActionViewLetters.Enabled = Globals.AllowClose;
        ActionExit.Enabled = Globals.AllowClose;
        ActionSearchTerm.Enabled = Globals.AllowClose;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    private void EditMeanings_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.Exception is ArgumentOutOfRangeException || e.Exception is IndexOutOfRangeException )
      {
        DisplayManager.ShowError("public index error.");
        DataSet.RejectChanges();
        e.Exception.Manage();
        Application.Exit();
      }
      else
        e.Exception.Manage();
    }

    private void BindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      e.Exception.Manage();
      DataSet.RejectChanges();
    }

  }

}
