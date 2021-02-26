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


    private string LastTermSearched;

    /// <summary>
    /// Indicate the selected meanings text.
    /// </summary>
    private string WordMeanings = "";

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
      UndoRedoTextBox.ActionUndo.Click += TextBoxData_ContextMenuAction_Click;
      UndoRedoTextBox.ActionRedo.Click += TextBoxData_ContextMenuAction_Click;
      UndoRedoTextBox.ActionCut.Click += TextBoxData_ContextMenuAction_Click;
      UndoRedoTextBox.ActionPaste.Click += TextBoxData_ContextMenuAction_Click;
      UndoRedoTextBox.ActionDelete.Click += TextBoxData_ContextMenuAction_Click;
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
        string str = HebrewAlphabet.ConvertToUnicode(EditLetters.Input.Text);
        SystemManager.OpenWebLink(( (string)menuitem.Tag ).Replace("%WORD%", str));
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
      ProcessLocksTable.Lock();
      Program.Settings.CurrentView = ViewMode.Analyse;
      EditSentence.Font = new Font("Microsoft Sans Serif", (float)Settings.FontSizeSentence);
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
      ComboBoxCode_SelectedIndexChanged(null, null);
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
      TimerProcesses_Tick(null, null);
      Globals.IsReady = true;
    }

    private bool IsReadOnly;

    /// <summary>
    /// Event handler. Called by MainForm for form shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      SystemManager.TryCatch(Settings.Save);
      if ( Globals.IsExiting ) return;
      if ( !Program.StartupWordHebrew.IsNullOrEmpty() )
      {
        ActionReset.Visible = true;
        EditLetters.Input.Text = Program.StartupWordHebrew;
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
      if ( Settings.FirstLaunchV4 )
      {
        Settings.FirstLaunchV4 = false;
        SystemManager.TryCatch(Settings.Save);
        ActionShowMethodNotice.PerformClick();
      }
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
      SystemManager.TryCatchManage(SaveData);
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing )
      {
        Globals.IsExiting = true;
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
    /// Event handler. Called by ActionViewAnalysis for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewAnalysis_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Analyse);
      foreach (Data.DataSet.LettersRow row in DataSet.Letters)
        LettersMeanings[row.ValueSimple] = null;
      DoAnalyse();
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
      if ( Globals.AllowClose )
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
      EditLetters.Focus();
    }

    private void ActionDelLast_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text.Length < 1 ) return;
      EditLetters.Input.Text = EditLetters.Input.Text.Remove(0, 1);
      EditLetters.Focus();
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      EditLetters.Input.Text = Program.StartupWordHebrew;
      EditLetters.Focus();
    }

    private void EditLetters_InputTextChanged(object sender, EventArgs e)
    {
      var enabled = EditLetters.Input.Text != "";
      ActionDelFirst.Enabled = EditLetters.Input.Text.Length >= 1;
      ActionDelLast.Enabled = ActionDelFirst.Enabled;
      ActionClear.Enabled = enabled;
      ActionCopyToUnicode.Enabled = enabled;
      ActionSearchOnline.Enabled = enabled;
      DoAnalyse();
    }

    private void ActionSearchOnline_Click(object sender, EventArgs e)
    {
      ContextMenuSearchOnline.Show(ActionSearchOnline, new Point(0, ActionSearchOnline.Height));
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      EditLetters.Input.SelectAll();
      EditLetters.Input.Paste("");
      EditSentence.Text = "";
      EditGematriaSimple.Text = "";
      EditGematriaFull.Text = "";
      EditAnalyze.Controls.Clear();
      ActionCopyToClipboardMeanings.Enabled = false;
      ActionSnapshot.Enabled = false;
      EditLetters.Focus();
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      ActiveControl = EditLetters.Input;
      EditLetters.Input.SelectAll();
      UndoRedoTextBox.ActionPaste.PerformClick();
    }

    private void ActionCopyToUnicode_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text != "" )
        Clipboard.SetText(HebrewAlphabet.ConvertToUnicode(EditLetters.Input.Text));
      EditLetters.Focus();
    }

    private void ActionCopyToClipboardMeanings_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text != "" )
      {
        var controls = EditAnalyze.Controls.OfType<Label>();
        var list = controls.Select(label => label.Text + " : " + string.Join(", ", (object[])( (ComboBox)label.Tag ).Tag));
        WordMeanings = string.Join(Globals.NL, list);
        Clipboard.SetText(WordMeanings);
        DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                          Globals.ClipboardSoundFilePath);
      }
    }

    private void ActionSnapshot_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text != "" )
      {
        Clipboard.SetImage(this.GetBitmap());
        DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                          Globals.SnapshotSoundFilePath);
      }
    }

    private void ActionCopyToClipboardResults_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text != "" ) Clipboard.SetText(EditSentence.Text);
      if ( EditCopyToClipboardCloseApp.Checked ) Close();
    }

    private void EditSentence_TextChanged(object sender, EventArgs e)
    {
      ActionCopyToClipboardResult.Enabled = EditSentence.Text != "";
    }

    private void EditLetters_ViewLetterDetails(LettersControl sender, string code)
    {
      ActionViewLetters.PerformClick();
      ComboBoxCode.SelectedIndex = ComboBoxCode.FindStringExact(code);
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

    private void EditShowSuccessDialogs_CheckedChanged(object sender, EventArgs e)
    {
      // TODO Settings.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
      DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
    }

    private void ComboBoxCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void ActionAddMeaning_Click(object sender, EventArgs e)
    {
      var row = DataSet.Meanings.NewMeaningsRow();
      row.ID = Guid.NewGuid().ToString();
      row.LetterCode = ComboBoxCode.Text;
      row.Meaning = "";
      DataSet.Meanings.AddMeaningsRow(row);
      MeaningsBindingSource.ResetBindings(false);
      MeaningsBindingSource.MoveLast();
      EditMeanings.BeginEdit(false);
      ActionAddMeaning.Enabled = false;
      ActionDeleteMeaning.Enabled = false;
      ToolStrip.Enabled = false;
      PanelLetter.Enabled = false;
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
      SaveData();
      UpdateButtons();
    }

    private void EditMeanings_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      Globals.AllowClose = false;
      ToolStrip.Enabled = false;
    }

    private void EditMeanings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      var cell = EditMeanings[e.ColumnIndex, e.ColumnIndex];
      cell.Value = ( (string)cell.Value ).Trim();
      SaveData();
      UpdateButtons();
      Globals.AllowClose = true;
      ToolStrip.Enabled = true;
    }

    private void EditMeanings_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if ( e.FormattedValue == DBNull.Value || (string)e.FormattedValue == "" )
      {
        e.Cancel = true;
        EditMeanings.BeginEdit(false);
      }
      else
      {
        ToolStrip.Enabled = true;
        PanelLetter.Enabled = true;
        UpdateButtons();
      }
    }

    private void MeaningComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string str = "";
      foreach ( var control in EditAnalyze.Controls )
        if ( control is ComboBox )
          str += ( ( control as ComboBox ).Text ?? "" ) + " ";
      str = str == "" ? "" : str.Remove(str.Length - 1, 1);
      EditSentence.Text = str;
    }

    private bool TextBoxDataContextMenuMutex;

    private void TextBoxData_ContextMenuEditOpening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ( TextBoxDataContextMenuMutex ) return;
      TextBoxDataContextMenuMutex = true;
      var textbox = UndoRedoTextBox.GetTextBox(sender);
      ( (ContextMenuStrip)sender ).Enabled = (string)textbox.Tag != "data" || !IsReadOnly;
    }

    private void TextBoxData_ContextMenuEditOpened(object sender, EventArgs e)
    {
      TextBoxDataContextMenuMutex = false;
    }

    private bool EditMutex;

    private void TextBoxData_TextChanged(object sender, EventArgs e)
    {
      if ( EditMutex ) return;
      EditMutex = true;
      LettersBindingSource.EndEdit();
      SaveData();
      EditMutex = false;
    }

    private void TextBoxData_Leave(object sender, EventArgs e)
    {
      TextBoxData_TextChanged(sender, e);
    }

    private void TextBoxData_ContextMenuAction_Click(object sender, EventArgs e)
    {
      var textbox = UndoRedoTextBox.GetTextBox(sender);
      if ( textbox != null )
        if ( textbox.Tag is string )
          if ( (string)textbox.Tag == "data" )
            TextBoxData_TextChanged(sender, e);
    }

    private void SaveData()
    {
      if ( DataSet.HasChanges() )
        if ( IsReadOnly )
          DataSet.RejectChanges();
        else
        {
          TableAdapterManager.UpdateAll(DataSet);
          ApplicationStatistics.UpdateDBFileSizeRequired = true;
          ApplicationStatistics.UpdateDBMemorySizeRequired = true;
        }
    }

    private void UpdateButtons()
    {
      try
      {
        if ( ComboBoxCode.SelectedItem == null ) return;
        var row = (Data.DataSet.LettersRow)( (DataRowView)ComboBoxCode.SelectedItem ).Row;
        ActionAddMeaning.Enabled = !IsReadOnly;
        ActionDeleteMeaning.Enabled = !IsReadOnly && row.GetMeaningsRows().Length > 0;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    private void BindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      e.Exception.Manage();
      DataSet.RejectChanges();
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

  }

}
