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
/// <edited> 2021-04 </edited>
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm : Form
  {

    #region Singleton

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

    #endregion

    #region Form Management

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      DoConstructor();
      if ( !Globals.IsDevExecutable ) // TODO remove when ready
      {
        ActionGematriaCombinations.Visible = false;
        toolStripSeparator1.Visible = false; 
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      DoFormLoad(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      DoFormShown(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      DoFormClosing(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      DoFormClosed(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for windows changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_WindowsChanged(object sender, EventArgs e)
    {
      if ( !Visible ) return;
      if ( !Globals.IsReady ) return;
      if ( Globals.IsExiting ) return;
      if ( WindowState != FormWindowState.Normal ) return;
      EditScreenNone.PerformClick();
    }

    /// <summary>
    /// Event handler. Called by TimerProcesses for tick events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void TimerProcesses_Tick(object sender, EventArgs e)
    {
      Globals.IsReadOnly = ProcessLocksTable.IsReadOnly();
      Text = Globals.AssemblyTitle;
      if ( Globals.IsReadOnly ) Text += " - " + SysTranslations.ReadOnly.GetLang();
      TextBoxPositive.ReadOnly = Globals.IsReadOnly;
      TextBoxNegative.ReadOnly = Globals.IsReadOnly;
      TextBoxVerb.ReadOnly = Globals.IsReadOnly;
      TextBoxStructure.ReadOnly = Globals.IsReadOnly;
      TextBoxFunction.ReadOnly = Globals.IsReadOnly;
      EditMeanings.ReadOnly = Globals.IsReadOnly;
      ActionAddMeaning.Enabled = !Globals.IsReadOnly;
      ActionDeleteMeaning.Enabled = !Globals.IsReadOnly;
      ActionSettings.Enabled = !Globals.IsReadOnly;
      ActionPreferences.Enabled = !Globals.IsReadOnly;
      ActionRestoreDefaults.Enabled = !Globals.IsReadOnly;
      TimerProcesses.Enabled = Globals.IsReadOnly;
    }

    #endregion

    #region Top Menu Tooltips

    /// <summary>
    /// Event handler. Called by TimerTooltip for tick events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
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
    /// Event handler. Called by ShowToolTip for on mouse enter events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ShowToolTip_OnMouseEnter(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      if ( !( sender is ToolStripItem ) ) return;
      if ( LastToolTip.Tag == sender ) return;
      LastToolTip.Tag = sender;
      if ( ( (ToolStripItem)sender ).ToolTipText == string.Empty ) return;
      TimerTooltip.Enabled = true;
    }

    /// <summary>
    /// Event handler. Called by ShowToolTip for on mouse leave events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ShowToolTip_OnMouseLeave(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      TimerTooltip.Enabled = false;
      LastToolTip.Tag = null;
      LastToolTip.Hide(ToolStrip);
    }

    #endregion

    #region Menu System

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
        ClearLettersMeanings();
        DoAnalyse();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    #endregion

    #region Menu Settings

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
    /// Event handler. Called by EditScreenPosition for click events.
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
    /// Event handler. Called by EditDialogBoxesSettings for checked changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void EditDialogBoxesSettings_CheckedChanged(object sender, EventArgs e)
    {
      Settings.SoundsEnabled = EditSoundsEnabled.Checked;
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

    /// <summary>
    /// Event handler. Called by EditShowSuccessDialogs for checked changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void EditShowSuccessDialogs_CheckedChanged(object sender, EventArgs e)
    {
      Settings.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
      DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
    }

    #endregion

    #region Menu Information

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void ActionAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
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
      if ( exit ) Close();
    }

    /// <summary>
    /// Event handler. Called by ActionViewLog for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void ActionViewLog_Click(object sender, EventArgs e)
    {
      DebugManager.TraceForm.Popup();
    }

    /// <summary>
    /// Event handler. Called by ActionViewStats for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    public void ActionViewStats_Click(object sender, EventArgs e)
    {
      StatisticsForm.Run();
    }

    #endregion

    #region Menu Tools

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

    private void ActionGematriaCombinations_Click(object sender, EventArgs e)
    {
      int value = 0;
      if ( DisplayManager.QueryValue(LabelGematriaSimple.Text, ref value) != InputValueResult.Modified ) return;
      DisplayManager.Show(value.ToString());
    }

    #endregion

    #region Menu application

    /// <summary>
    /// Event handler. Called by ActionViewAnalysis for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewAnalysis_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Analysis);
    }

    /// <summary>
    /// Event handler. Called by ActionViewLetters for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewLetters_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Data);
    }

    /// <summary>
    /// Event handler. Called by ActionSearchTerm for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchTerm_Click(object sender, EventArgs e)
    {
      var tempView = Settings.CurrentView;
      ActionViewLetters.PerformClick();
      var formSearch = new SearchTermBox();
      formSearch.EditTerm.Text = LastTermSearched;
      if ( formSearch.ShowDialog() != DialogResult.OK )
      {
        SetView(tempView);
        return;
      }
      LastTermSearched = formSearch.EditTerm.Text.ToLower().RemoveDiacritics();
      if ( !SearchTermResultsBox.Run(LastTermSearched, out var code, out var meaning) )
      {
        SetView(tempView);
        return;
      }
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
    /// Event handler. Called by ActionNewInstance for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionNewInstance_Click(object sender, EventArgs e)
    {
      SystemManager.RunShell(Process.GetCurrentProcess().MainModule.FileName);
    }

    #endregion

    #region Update Analysis Controls

    private void UpdateAnalysisControls()
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

    private void EditSentence_FontChanged(object sender, EventArgs e)
    {
      double top = ActionCopyToResult.Top;
      top += ActionCopyToResult.Height / 2d;
      top -= EditSentence.Height / 2d;
      EditSentence.Top = (int)Math.Round(top, MidpointRounding.AwayFromZero);
    }

    private void EditGematria_TextChanged(object sender, EventArgs e)
    {
      var textbox = sender as TextBox;
      if ( textbox.Text == "0" ) textbox.Text = "";
    }

    #endregion

    #region Panel Letters

    private void EditLetters_ViewLetterDetails(LettersControl sender, string code)
    {
      ActionViewLetters.PerformClick();
      SelectLetter.SelectedIndex = SelectLetter.FindStringExact(code);
    }

    private void ActionDelFirst_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text.Length < 1 ) return;
      EditLetters.Input.SelectionStart = EditLetters.Input.TextLength - 1;
      EditLetters.Input.SelectionLength = 1;
      EditLetters.Focus(LettersControlFocusSelect.Keep);
      TextBoxEx.ActionDelete.PerformClick();
    }

    private void ActionDelLast_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text.Length < 1 ) return;
      EditLetters.Input.SelectionStart = 0;
      EditLetters.Input.SelectionLength = 1;
      EditLetters.Focus(LettersControlFocusSelect.Keep);
      TextBoxEx.ActionDelete.PerformClick();
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      EditLetters.Input.Text = Program.StartupWord;
      EditLetters.Focus(LettersControlFocusSelect.None);
    }

    private void EditLetters_InputTextChanged(object sender, EventArgs e)
    {
      UpdateAnalysisControls();
      DoAnalyse();
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      EditLetters.Input.SelectAll();
      EditLetters.Input.Paste("");
      EditSentence.Text = "";
      EditGematriaSimple.Text = "";
      EditGematriaFull.Text = "";
      SelectAnalyze.Controls.Clear();
      UpdateAnalysisControls();
      EditLetters.Focus();
    }

    private void ActionSearchOnline_Click(object sender, EventArgs e)
    {
      ContextMenuSearchOnline.Show(ActionSearchOnline, new Point(0, ActionSearchOnline.Height));
    }

    #endregion

    #region Copy and Paste

    private void LabelClipboardContentType_MouseHover(object sender, EventArgs e)
    {
      ToolTipClipboard.Show(Clipboard.GetText(), LabelClipboardContentType);
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      EditLetters.Focus(LettersControlFocusSelect.All);
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
      EditLetters.Focus(LettersControlFocusSelect.All);
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
      EditLetters.Focus(LettersControlFocusSelect.All);
    }

    #endregion

    #region User Analysis

    private void MeaningComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      EditSentence.Text = string.Join(" ", SelectAnalyze.Controls.OfType<ComboBox>().Select(c => c.Text));
    }

    private void EditSentence_TextChanged(object sender, EventArgs e)
    {
      ActionCopyToResult.Enabled = EditSentence.Text != "";
    }

    private void ActionCopyToResult_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text == "" ) return;
      Clipboard.SetText(EditSentence.Text);
      if ( EditCopyToClipboardCloseApp.Checked ) Close();
      EditSentence.Focus();
    }

    #endregion

    #region Analysis Copy and Screenshot

    private void ActionViewAllMeaningsList_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text == "" ) return;
      new ShowTextForm(AppTranslations.LettersWordMeaningsList.GetLang(),
                       GetMeaningsText().Replace(Globals.NL, Globals.NL2),
                       false, true,
                       600, 400).ShowDialog();
      EditLetters.Focus();
    }

    private string GetMeaningsText()
    {
      var list = SelectAnalyze.Controls
                              .OfType<ComboBox>()
                              .Select(combo =>
                              {
                                var letter = (Data.DataSet.LettersRow)combo.Tag;
                                var meanings = LettersMeanings[letter.ValueSimple];
                                return letter.Name + " : " + string.Join(", ", meanings);
                              });
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

    #endregion

    #region Letter Update Data Controls

    private void UpdateDataControls(object sender, bool forceEditMode = false)
    {
      try
      {
        forceEditMode = forceEditMode || EditMeanings.IsCurrentCellInEditMode || DataAddNewRowMutex;
        if ( SelectLetter.SelectedItem == null ) return;
        var row = (Data.DataSet.LettersRow)( (DataRowView)SelectLetter.SelectedItem ).Row;
        ActionAddMeaning.Enabled = !Globals.IsReadOnly && !forceEditMode;
        ActionDeleteMeaning.Enabled = !Globals.IsReadOnly && !forceEditMode && row.GetMeaningsRows().Length > 0;
        ActionSave.Enabled = ( DataSet.HasChanges() && !forceEditMode ) || ( forceEditMode && sender is TextBox );
        ActionUndo.Enabled = ActionSave.Enabled;
        Globals.AllowClose = !ActionSave.Enabled && !forceEditMode;
        SelectLetter.Enabled = Globals.AllowClose;
        LettersNavigator.Enabled = Globals.AllowClose;
        ActionViewAnalysis.Enabled = Globals.AllowClose;
        ActionViewLetters.Enabled = Globals.AllowClose;
        ActionExit.Enabled = Globals.AllowClose;
        ActionSearchTerm.Enabled = Globals.AllowClose;
        CommonMenusControl.Instance.ActionCheckUpdate.Enabled = Globals.AllowClose;
        AboutBox.Instance.ActionCheckUpdate.Enabled = Globals.AllowClose;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    #endregion

    #region Letter Data Save, Undo and Restore

    private void ActionSave_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() )
        if ( Globals.IsReadOnly )
          DataSet.RejectChanges();
        else
        {
          TableAdapterManager.UpdateAll(DataSet);
          ApplicationStatistics.UpdateDBFileSizeRequired = true;
          ApplicationStatistics.UpdateDBMemorySizeRequired = true;
          DataChanged = true;
        }
      UpdateDataControls(sender);
      EditMeanings.Focus();
      ClearLettersMeanings();
      DoAnalyse();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() )
        DataSet.RejectChanges();
      UpdateDataControls(sender);
      EditMeanings.Focus();
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
        UpdateDataControls(null);
        ClearLettersMeanings();
        DoAnalyse();
        EditMeanings.Focus();
      }
    }

    #endregion

    #region Letter Data Select

    private void SelectLetter_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( !SelectLetter.Enabled ) return;
      DataEditMutex = true;
    }

    private void LettersBindingSource_PositionChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      DataEditMutex = false;
      UpdateDataControls(sender);
    }

    private void LettersNavigator_Navigated(object sender, EventArgs e)
    {
      EditMeanings.Focus();
    }

    #endregion

    #region Letter Data TextBoxes 

    private bool TextBoxDataContextMenuMutex;

    private void TextBoxData_ContextMenuEditOpening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ( TextBoxDataContextMenuMutex ) return;
      TextBoxDataContextMenuMutex = true;
      var textbox = TextBoxEx.GetTextBox(sender);
      ( (ContextMenuStrip)sender ).Enabled = (string)textbox.Tag != "data" || !Globals.IsReadOnly;
    }

    private void TextBoxData_ContextMenuEditOpened(object sender, EventArgs e)
    {
      TextBoxDataContextMenuMutex = false;
    }

    private void TextBoxData_TextChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( DataEditMutex ) return;
      DataEditMutex = true;
      LettersBindingSource.EndEdit();
      if ( sender != null ) UpdateDataControls(sender, true);
      DataEditMutex = false;
    }

    private void TextBoxData_Leave(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      TextBoxData_TextChanged(null, null);
      UpdateDataControls(null);
    }

    private void TextBoxData_ContextMenuAction_Click(object sender, EventArgs e)
    {
      /*var textbox = TextBoxEx.GetTextBox(sender);
      if ( textbox != null )
        if ( textbox.Tag is string )
          if ( (string)textbox.Tag == "data" )
            ;// TextBoxData_TextChanged(sender, e);*/
    }

    #endregion

    #region Letter Data Grid

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
      DataAddNewRowMutex = true;
      UpdateDataControls(sender);
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
      UpdateDataControls(sender);
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
        if ( DataAddNewRowMutex && ( (string)EditMeanings.CurrentCell.Value ).IsNullOrEmpty() )
        {
          EditMeanings.BeginEdit(false);
          DataAddNewRowMutex = true;
        }
        else
        if ( DataSet.HasChanges() )
        {
          DataAddNewRowMutex = false;
          UpdateDataControls(sender);
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
          DataAddNewRowMutex = false;
          UpdateDataControls(sender);
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
      UpdateDataControls(sender, true);
      DataAddNewRowMutex = false;
    }

    private void EditMeanings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      var cell = EditMeanings[e.ColumnIndex, e.ColumnIndex];
      var str = (string)cell.Value;
      if ( str.StartsWith(" ") || str.EndsWith(" ") )
        cell.Value = str.Trim();
      UpdateDataControls(sender);
    }

    private void EditMeanings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      UpdateDataControls(sender);
    }

    private void EditMeanings_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.FormattedValue == DBNull.Value || (string)e.FormattedValue == "" )
        e.Cancel = true;
      else
        UpdateDataControls(sender);
    }

    #endregion

    #region DB Errors

    private void EditMeanings_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.Exception is ArgumentOutOfRangeException || e.Exception is IndexOutOfRangeException )
      {
        DisplayManager.ShowError($"DB Index error.{Globals.NL2}{SysTranslations.ApplicationMustExit.GetLang()}");
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

    #endregion

  }

}
