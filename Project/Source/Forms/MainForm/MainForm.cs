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
/// <edited> 2021-08 </edited>
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;
using Equin.ApplicationFramework;
using System.Globalization;

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
      InitializeComponent();
      DoConstructor();
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
      Globals.IsReadOnly = Interlocks.IsReadOnly();
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
      ActionNotebookDeleteSentence.Enabled = !Globals.IsReadOnly;
      ActionNotebookDeleteWord.Enabled = !Globals.IsReadOnly;
      ActionNotebookDeleteSentence.Enabled = !Globals.IsReadOnly;
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
      bool temp = Globals.IsReadOnly;
      //if ( Globals.ApplicationInstancesCount > 1 )
      //  ActionPreferences.Enabled = false;
      //else
      try
      {
        Globals.IsReadOnly = true;
        PreferencesForm.Run();
        EditWord.InputMaxLength = (int)Settings.HebrewTextBoxMaxLength;
        InitializeSpecialMenus();
        InitializeDialogsDirectory();
        //ClearLettersMeanings();
        //DoAnalyse();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        Globals.IsReadOnly = temp;
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
      SetView(ViewMode.Letters);
    }

    private bool ViewNotebookFirstTime = true;

    private void ActionViewNotebook_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Notebook);
      if ( ViewNotebookFirstTime )
      {
        ViewNotebookFirstTime = false;
        ActionNotebookClearLetter.PerformClick();
      }
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
      LettersBindingSource.Position = LettersBindingSource.IndexOf(DBApp.Letters.Find(l => l.Code == code));
      int pos = MeaningsBindingSource.IndexOf(DBApp.Meanings.Find(m => m.Text == meaning));
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

    private Font ContextMenuHebrewFont = new Font("Hebrew", 10);

    private void UpdateAnalysisControls()
    {
      bool enabled = EditWord.TextBox.Text.Length >= 1;
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
      if ( !Globals.IsDevExecutable ) return; // TODO remove when ready
      var word = EditWord.TextBox.Text;
      var sentence = EditSentence.Text.Trim();
      var combos = SelectAnalyze.Controls.OfType<ComboBox>().ToList();
      var lettriqs = from term in DBHebrew.TermsHebrew
                     from lettriq in term.Lettriqs
                     where term.Hebrew == word
                     select lettriq;
      var query = from lettriq in lettriqs
                  where lettriq.Sentence == sentence
                        || ( lettriq.Analyzes.Count == combos.Count
                          && lettriq.Analyzes.All(m => (string)combos[m.Position].SelectedItem == m.Meaning) )
                  select lettriq;
      ActionSaveTermLettriq.Enabled = !Globals.IsReadOnly
                                   && word != string.Empty
                                   && sentence != string.Empty
                                   && combos.All(c => c.SelectedIndex != -1) && !query.Any();
      ActionOpenTermLettriq.Enabled = lettriqs.Any();
      ContextMenuOpenTermLettriq.Items.Clear();
      foreach ( var item in lettriqs )
      {
        var menuitem = ContextMenuOpenTermLettriq.Items.Add(item.Sentence);
        menuitem.Tag = item;
        menuitem.Click += ContextMenuOpenTermLettriqItem_Click;
      }
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
      if ( EditWord.TextBox.Text.Length < 1 ) return;
      EditWord.TextBox.SelectionStart = EditWord.TextBox.TextLength - 1;
      EditWord.TextBox.SelectionLength = 1;
      EditWord.Focus(LettersControlFocusSelect.Keep);
      TextBoxEx.ActionDelete.PerformClick();
    }

    private void ActionDelLast_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text.Length < 1 ) return;
      EditWord.TextBox.SelectionStart = 0;
      EditWord.TextBox.SelectionLength = 1;
      EditWord.Focus(LettersControlFocusSelect.Keep);
      TextBoxEx.ActionDelete.PerformClick();
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      EditWord.TextBox.Text = Program.StartupWord;
      EditWord.Focus(LettersControlFocusSelect.None);
    }

    private void EditLetters_InputTextChanged(object sender, EventArgs e)
    {
      DoAnalyse();
      UpdateAnalysisControls();
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      EditWord.TextBox.SelectAll();
      EditWord.TextBox.Paste("");
      EditSentence.Text = "";
      EditGematriaSimple.Text = "";
      EditGematriaFull.Text = "";
      SelectAnalyze.Controls.Clear();
      UpdateAnalysisControls();
      EditWord.Focus();
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
      EditWord.Focus(LettersControlFocusSelect.All);
      TextBoxEx.ActionPaste.PerformClick();
    }

    private void ActionCopyToHebrew_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      string str = EditWord.TextBox.Text;
      if ( EditCopyWithFinalLetter.Checked )
        str = HebrewAlphabet.SetFinal(str, true);
      Clipboard.SetText(str);
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditWord.Focus(LettersControlFocusSelect.All);
    }

    private void ActionCopyToUnicode_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      string str = EditWord.TextBox.Text;
      if ( EditCopyWithFinalLetter.Checked )
        str = HebrewAlphabet.SetFinal(str, true);
      Clipboard.SetText(HebrewAlphabet.ToUnicode(str));
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditWord.Focus(LettersControlFocusSelect.All);
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
      UpdateAnalysisControls();
    }

    private void ActionCopyToResult_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text == "" ) return;
      Clipboard.SetText(EditSentence.Text);
      if ( EditCopyToClipboardCloseApp.Checked ) Close();
      EditSentence.Focus();
    }

    #endregion

    #region Analysis Load and Save

    private void ActionOpenTermLettriq_Click(object sender, EventArgs e)
    {
      ContextMenuOpenTermLettriq.Show(ActionOpenTermLettriq, new Point(0, ActionOpenTermLettriq.Height));
    }

    private void ContextMenuOpenTermLettriqItem_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var lettriq = (TermLettriq)menuitem.Tag;
      if ( EditSentence.Text.Trim() != string.Empty && EditSentence.Text != lettriq.Sentence )
        if ( !DisplayManager.QueryYesNo("Replace analysis?") )
          return;
      var list = SelectAnalyze.Controls.OfType<ComboBox>().ToList();
      foreach ( var meaning in lettriq.Analyzes )
        if ( meaning.Position < list.Count )
        {
          if ( list[meaning.Position].Items.Count == 0 )
            Combobox_Enter(list[meaning.Position], EventArgs.Empty);
          int index = list[meaning.Position].FindString(meaning.Meaning);
          list[meaning.Position].SelectedIndex = index;
        }
      EditSentence.Text = lettriq.Sentence;
      EditTranscription.Text = lettriq.Transcription;
      EditDictionary.Text = lettriq.Dictionary;
      EditMemo.Text = lettriq.Memo;
      //EditConcordance.Text = lettriq.ConcordanceID;
    }

    private void ActionSaveTermLettriq_Click(object sender, EventArgs e)
    {
      string hebrew = EditWord.TextBox.Text;
      var term = DBHebrew.TermsHebrew.Find(t => t.Hebrew == hebrew);
      if ( term == null )
      {
        term = new TermHebrew
        {
          ID = Guid.NewGuid().ToString(),
          Hebrew = hebrew,
          Unicode = HebrewAlphabet.ToUnicode(hebrew)
        };
        DBHebrew.TermsHebrew.Add(term);
        DBHebrew.Connection.Insert(term);
      }
      var lettriq = new TermLettriq
      {
        ID = Guid.NewGuid().ToString(),
        TermID = term.ID,
        //ConcordanceID = term.ConvertTo
        Sentence = EditSentence.Text,
        Transcription = EditTranscription.Text,
        Dictionary = EditDictionary.Text,
        Memo = EditMemo.Text
      };
      DBHebrew.TermLettriqs.Add(lettriq);
      DBHebrew.Connection.Insert(lettriq);
      int index = 0;
      foreach ( var item in SelectAnalyze.Controls.OfType<ComboBox>() )
      {
        var meaning = new TermAnalysis
        {
          ID = Guid.NewGuid().ToString(),
          LettriqID = lettriq.ID,
          Position = index++,
          Meaning = (string)item.SelectedItem
        };
        DBHebrew.TermAnalyzes.Add(meaning);
        DBHebrew.Connection.Insert(meaning);
      }
      DBHebrew.SaveLettriqs();
      UpdateAnalysisControls();
    }

    #endregion

    #region Analysis Copy and Screenshot

    private void ActionViewAllMeaningsList_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      new ShowTextForm(AppTranslations.LettersWordMeaningsList.GetLang(),
                       GetMeaningsText().Replace(Globals.NL, Globals.NL2),
                       false, true,
                       600, 400).ShowDialog();
      EditWord.Focus();
    }

    private string GetMeaningsText()
    {
      var list = SelectAnalyze.Controls
                              .OfType<ComboBox>()
                              .Select(combo =>
                              {
                                var letter = (Letter)combo.Tag;
                                var meanings = LettersMeanings[letter.ValueSimple];
                                return letter.Name + " : " + string.Join(", ", meanings);
                              });
      return string.Join(Globals.NL, list);
    }

    private void ActionCopyToMeanings_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      Clipboard.SetText(GetMeaningsText());
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      EditWord.Focus();
    }

    private void ActionScreenshot_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      Clipboard.SetImage(this.GetBitmap());
      DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                        Globals.ScreenshotSoundFilePath);
      EditWord.Focus();
    }

    private void ActionSaveScreenshot_Click(object sender, EventArgs e)
    {
      if ( EditWord.TextBox.Text == "" ) return;
      string str = EditWord.TextBox.Text;
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
      EditWord.Focus();
    }

    #endregion

    #region DB Errors

    private void EditMeanings_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.Exception is ArgumentOutOfRangeException || e.Exception is IndexOutOfRangeException )
      {
        DisplayManager.ShowError($"DB Index error.{Globals.NL2}{SysTranslations.ApplicationMustExit.GetLang()}");
        e.Exception.Manage();
        DBApp.Connection.Rollback();
        Application.Exit();
      }
      else
        e.Exception.Manage();
    }

    private void BindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      e.Exception.Manage();
      DBApp.Connection.Rollback();
    }

    #endregion

    #region Letter Update Data Controls

    private void UpdateDataControls(object sender, bool forceEditMode = false)
    {
      try
      {
        forceEditMode = forceEditMode || EditMeanings.IsCurrentCellInEditMode;
        if ( SelectLetter.SelectedItem == null ) return;
        var letter = ( (ObjectView<Letter>)SelectLetter.SelectedItem ).Object;
        ActionAddMeaning.Enabled = !Globals.IsReadOnly && !forceEditMode;
        ActionDeleteMeaning.Enabled = !Globals.IsReadOnly && !forceEditMode && letter.Meanings.Count > 0;
        ActionSave.Enabled = ( DBApp.IsInTransaction && !forceEditMode ) || ( forceEditMode && sender is TextBox );
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
      if ( Globals.IsReadOnly )
        DBApp.LoadAll();
      else
      {
        DBApp.SaveAll();
        ApplicationStatistics.UpdateDBFileSizeRequired = true;
        // TODO remove if no alternative ApplicationStatistics.UpdateDBMemorySizeRequired = true;
        DataChanged = true;
      }
      UpdateDataControls(sender);
      EditMeanings.Focus();
      ClearLettersMeanings();
      DoAnalyse();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      DBApp.LoadAll();
      LettersBindingSource.DataSource = DBApp.LettersAsBindingList;
      UpdateDataControls(sender);
      EditMeanings.Focus();
    }

    private void ActionRestoreDefaults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetData.GetLang()) )
      {
        string word = EditWord.TextBox.Text;
        DBApp.CreateDataIfNotExist(true);
        DBApp.LoadAll();
        LettersBindingSource.DataSource = DBApp.LettersAsBindingList;
        ActionClear.PerformClick();
        ActionReset.PerformClick();
        EditWord.TextBox.Text = word;
        ApplicationStatistics.UpdateDBFileSizeRequired = true;
        // TODO remove if no alternative ApplicationStatistics.UpdateDBMemorySizeRequired = true;
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
      UpdateDataControls(sender);
    }

    private void LettersBindingSource_PositionChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      UpdateDataControls(sender);
    }

    private void LettersNavigator_Navigated(object sender, EventArgs e)
    {
      EditMeanings.Focus();
      UpdateDataControls(sender);
    }

    #endregion

    #region Letter Data TextBoxes 

    private bool IsLetterEditing;

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

    private void TextBoxData_ContextMenuAction_Click(object sender, EventArgs e)
    {
      var textbox = TextBoxEx.GetTextBox(sender);
      if ( textbox != null )
        if ( textbox.Tag is string value )
          if ( value == "data" )
          {
            IsLetterEditing = true;
            TextBoxPositive_TextChanged(textbox, e);
          }
    }

    private void TextBoxData_KeyDown(object sender, KeyEventArgs e)
    {
      IsLetterEditing = true;
    }

    private void TextBoxPositive_TextChanged(object sender, EventArgs e)
    {
      if ( !IsLetterEditing ) return;
      if ( !( sender is TextBox textbox ) ) return;
      var letter = ( (ObjectView<Letter>)LettersBindingSource.Current ).Object;
      var binding = textbox.DataBindings[nameof(TextBox.Text)];
      string dataname = binding.BindingMemberInfo.BindingField;
      var type = letter.GetType();
      var prop = type.GetProperty(dataname);
      string value = (string)prop.GetValue(letter);
      if ( textbox.Text != value )
        DBApp.BeginTransaction();
      IsLetterEditing = false;
      UpdateDataControls(sender);
    }

    #endregion

    #region Letter Data Grid

    private void ActionAddMeaning_Click(object sender, EventArgs e)
    {
      string text = "";
      if ( DisplayManager.QueryValue("", ref text) != InputValueResult.Modified ) return;
      var meaning = new Meaning();
      meaning.ID = Guid.NewGuid().ToString();
      meaning.LetterCode = SelectLetter.Text;
      meaning.Text = text;
      DBApp.BeginTransaction();
      DBApp.Connection.Insert(meaning);
      DBApp.Meanings.Add(meaning);
      MeaningsBindingSource.Add(meaning);
      MeaningsBindingSource.MoveLast();
      UpdateDataControls(sender);
    }

    private void ActionDeleteMeaning_Click(object sender, EventArgs e)
    {
      if ( MeaningsBindingSource.Count < 1 ) return;
      int index = MeaningsBindingSource.Position;
      var meaning = (Meaning)MeaningsBindingSource.Current;
      DBApp.BeginTransaction();
      DBApp.Connection.Delete(meaning);
      DBApp.Meanings.Remove(meaning);
      MeaningsBindingSource.RemoveCurrent();
      int count = MeaningsBindingSource.Count;
      if ( count > 1 )
        if ( index >= count )
        {
          MeaningsBindingSource.MoveFirst();
          MeaningsBindingSource.MoveLast();
        }
        else
          MeaningsBindingSource.Position = index;
      UpdateDataControls(sender);
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

    private void EditMeanings_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( e.FormattedValue == DBNull.Value || (string)e.FormattedValue == "" )
        e.Cancel = true;
      else
        UpdateDataControls(sender);
    }

    private void EditMeanings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( Globals.IsReadOnly ) return;
      DBApp.BeginTransaction();
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
      /*if ( e.KeyCode == Keys.Enter )
      {
        if ( DataAddNewRowMutex && ( (string)EditMeanings.CurrentCell.Value ).IsNullOrEmpty() )
        {
          EditMeanings.BeginEdit(false);
          DataAddNewRowMutex = true;
        }
        else
        if ( false )//DataSet.HasChanges()
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
      }*/
    }

    #endregion

    #region Terms

    private void ListNotebookLetters_SelectionChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( DBHebrew.TermsHebrewAsBindingList == null ) return;
      if ( ListNotebookLetters.SelectedCells.Count > 0 )
      {
        string code = (string)ListNotebookLetters.SelectedCells[0].Value;
        DBHebrew.TermsHebrewAsBindingList.ApplyFilter(w => w.Hebrew.EndsWith(code));
        if ( ListNotebookWords.Rows.Count > 0 )
          ListNotebookWords.Rows[0].Selected = true;
      }
      else
        DBHebrew.TermsHebrewAsBindingList.RemoveFilter();
      ListNotebookWords.ClearSelection();
      ListNotebookWords_SelectionChanged(null, null);
    }

    // use dictionary filters word & sentence

    private void ListNotebookWords_SelectionChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( DBHebrew.TermLettriqsAsBindingList == null ) return;
      if ( ListNotebookWords.SelectedRows.Count > 0 )
      {

        string id = ( (ObjectView<TermHebrew>)ListNotebookWords.SelectedRows[0].DataBoundItem ).Object.ID;
        DBHebrew.TermLettriqsAsBindingList.ApplyFilter(s => s.TermID == id);
      }
      else
      if ( DBHebrew.TermsHebrewAsBindingList.Count == 0 )
        DBHebrew.TermLettriqsAsBindingList.ApplyFilter(s => s.TermID == "");
      else
        DBHebrew.TermLettriqsAsBindingList.RemoveFilter();
      ListNotebookSentences.ClearSelection();
    }

    private void ListNotebookWord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      var lettriq = ( (ObjectView<TermLettriq>)ListNotebookSentences[e.ColumnIndex, e.RowIndex].OwningRow.DataBoundItem ).Object;
      var word = DBHebrew.TermsHebrew.Find(t => t.ID == lettriq.TermID);
      if ( word == null ) return;
      bool b1 = EditWord.TextBox.Text != string.Empty;
      bool b2 = EditWord.TextBox.Text != word.Hebrew;
      if ( b1 && b2 && !DisplayManager.QueryOkCancel("Replace current analysis?") )
        return;
      SetView(ViewMode.Analysis);
      EditWord.TextBox.Text = word.Hebrew;
      var item = ContextMenuOpenTermLettriq.Items
                                           .Cast<ToolStripMenuItem>()
                                           .FirstOrDefault(mi => mi.Text == lettriq.Sentence);
      if ( item == null ) return;
      item.PerformClick();
    }

    private void ActionNotebookClearLetter_Click(object sender, EventArgs e)
    {
      ListNotebookLetters.ClearSelection();
      ListNotebookWords.ClearSelection();
    }

    private void ActionNotebookClearWord_Click(object sender, EventArgs e)
    {
      ListNotebookWords.ClearSelection();
    }

    private void ActionNotebookDeleteWord_Click(object sender, EventArgs e)
    {
      // TODO delete analysis, lettrisq and term
    }

    private void ActionNotebookDeleteSentence_Click(object sender, EventArgs e)
    {
      if ( !DisplayManager.QueryYesNo("Delete selected sentences?") ) return;
      var indexes = ListNotebookSentences.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Index).Reverse().ToList();
      foreach ( var index in indexes )
      {
        var item = ( (ObjectView<TermLettriq>)ListNotebookSentences.Rows[index].DataBoundItem ).Object;
        // TODO delete analysis
        DBHebrew.Connection.Delete(item);
        // TODO delete term if lettriqs is empty
        ListNotebookSentences.Rows.RemoveAt(index);
      }
    }

    private void ActionNotebookClearFilter_Click(object sender, EventArgs e)
    {
      EditNotebookFilterSentence.Text = string.Empty;
    }

    private void EditNotebookFilterSentence_TextChanged(object sender, EventArgs e)
    {
      if ( EditNotebookFilterSentence.Text != string.Empty )
      {
        string filter = EditNotebookFilterSentence.Text;
        DBHebrew.TermLettriqsAsBindingList.ApplyFilter(l => CultureInfo.CurrentCulture.CompareInfo.IndexOf(l.Sentence, filter, CompareOptions.IgnoreCase) >= 0);
      }
      else
        DBHebrew.TermLettriqsAsBindingList.RemoveFilter();
    }

    #endregion

  }

}
