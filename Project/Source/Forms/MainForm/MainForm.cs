/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.Linq;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public MainForm Instance { get; private set; }

    /// <summary>
    /// Last term searched.
    /// </summary>
    private string LastTermSearched;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MainForm()
    {
      Instance = new MainForm();
    }

    /// <summary>
    /// INdicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    /// <summary>
    /// Indicate if database has been upgraded.
    /// </summary>
    private bool IsDBUpgraded;

    /// <summary>
    /// Indicate the selected meanings text.
    /// </summary>
    private string SelectedMeanings;

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    private IntPtr ClipboardViewerNext;

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      Text = Globals.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      try { Icon = Icon.ExtractAssociatedIcon(Globals.IconFilename); }
      catch { }
      ClipboardViewerNext = SetClipboardViewer(Handle);
    }

    /// <summary>
    /// Create providers and web links menu items.
    /// </summary>
    internal void CreateProvidersAndWebLinks()
    {
      OnlineProviders.CreateWebLinksMenuItems(MenuWebLinks, ActionOpenWebLinkTemplateFolder.Image);
      OnlineProviders.CreateProvidersMenuItems(Globals.OnlineWordProviders, ContextMenuSearchOnline, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
        string str = HebrewAlphabet.ConvertToUnicode(EditLetters.Text);
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
      Program.Settings.Retrieve();
      if ( SystemHelper.CheckUpdate(Program.Settings.CheckUpdateAtStartup, true) )
      {
        Application.Exit();
        return;
      }
      try
      {
        EditSentence.Font = new Font("Microsoft Sans Serif", (float)Program.Settings.FontSizeSentence);
        IsDBUpgraded = CreateSchemaIfNotExists();
        CreateDataIfNotExists(false);
        LettersTableAdapter.Fill(DataSet.Letters);
        MeaningsTableAdapter.Fill(DataSet.Meanings);
        ComboBoxCode_SelectedIndexChanged(null, null);
        Globals.IsReady = true;
      }
      catch ( OdbcException ex )
      {
        ex.Manage();
        Application.Exit();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for form shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      if ( Program.StartupWord != null && Program.StartupWord != "" )
      {
        ActionReset.Visible = true;
        EditLetters.Text = Program.StartupWord;
        DoAnalyse();
      }
      else
        ActionReset.Visible = false;
      if ( IsDBUpgraded && DisplayManager.QueryYesNo(Globals.AskToCheckParametersAfterDatabaseUpgraded.GetLang()) )
        SetView(ViewMode.Settings, true);
      else
        SetView(ViewMode.Analyse, true);
      if ( Program.Settings.FirstLaunchV4 )
      {
        Program.Settings.FirstLaunchV4 = false;
        Program.Settings.Save();
        ActionShowMethodNotice.PerformClick();
      }
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
      LettersBindingSource.EndEdit();
      MeaningsBindingSource.EndEdit();
      if ( DataSet.HasChanges() )
        try
        {
          TableAdapterManager.UpdateAll(DataSet);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      if ( EditConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(Globals.AskToExitApplication.GetLang()) )
        {
          e.Cancel = true;
          Globals.IsExiting = true;
          return;
        }
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.Store();
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
    /// Clipboard monitoring.
    /// </summary>
    protected override void WndProc(ref Message m)
    {
      const int WM_DRAWCLIPBOARD = 0x308;
      switch ( m.Msg )
      {
        case WM_DRAWCLIPBOARD:
          string str = Clipboard.GetText();
          bool isValid = false;
          foreach ( char c in str )
            if ( c != ' ' && HebrewAlphabet.ConvertToKey(c) != ' ' )
            {
              isValid = true;
              break;
            }
          ActionPasteFromUnicode.Enabled = isValid;
          break;
        default:
          base.WndProc(ref m);
          break;
      }
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
      if ( DataSet.HasChanges() ) TableAdapterManager.UpdateAll(DataSet);
      SetView(ViewMode.Analyse);
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
        Action<TextBox> check = textbox => { if ( textbox.Text == meaning ) textbox.Focus(); };
        check(Instance.TextBoxPositive);
        check(Instance.TextBoxNegative);
        check(Instance.TextBoxVerb);
        check(Instance.TextBoxStructure);
        check(Instance.TextBoxFunction);
      }
    }

    /// <summary>
    /// Event handler. Called by ActionViewLetters for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewLetters_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() ) TableAdapterManager.UpdateAll(DataSet);
      SetView(ViewMode.Settings);
    }

    /// <summary>
    /// Event handler. Called by ActionResetWinSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Globals.AskToRestoreWindowPosition.GetLang()) )
        Program.Settings.RestoreMainForm();
    }

    /// <summary>
    /// Event handler. Called by SelectScreenPosition for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void EditScreenPosition_Click(object sender, EventArgs e)
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
      PreferencesForm.Run();
    }

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionAbout_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionHelp for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionHelp_Click(object sender, EventArgs e)
    {
      SystemHelper.RunShell(Globals.HelpFilename);
    }

    /// <summary>
    /// Event handler. Called by ActionApplicationHome for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionApplicationHome_Click(object sender, EventArgs e)
    {
      SystemHelper.OpenApplicationHome();
    }

    /// <summary>
    /// Event handler. Called by ActionContact for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionContact_Click(object sender, EventArgs e)
    {
      SystemHelper.OpenContactPage();
    }

    /// <summary>
    /// Event handler. Called by ActionCreateGitHubIssue for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCreateGitHubIssue_Click(object sender, EventArgs e)
    {
      SystemHelper.OpenGitHibIssuesPage();
    }

    /// <summary>
    /// Event handler. Called by ActionCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCheckUpdate_Click(object sender, EventArgs e)
    {
      SystemHelper.CheckUpdate(Program.Settings.CheckUpdateAtStartup, false);
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

    private void ActionOpenHebrewAlphabet_Click(object sender, EventArgs e)
    {
      string url = (string)( (ToolStripItem)sender ).Tag;
      SystemManager.OpenWebLink(url);
    }

    private void ActionOpenWebsiteURL_Click(object sender, EventArgs e)
    {
      string url = (string)( (ToolStripItem)sender ).Tag;
      SystemManager.OpenWebLink(url);
    }

    private void ActionRestoreDefaults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Translations.AskToRestoreLettersDefaults.GetLang()) )
      {
        string word = EditLetters.Text;
        CreateDataIfNotExists(true);
        ActionClear.PerformClick();
        ActionReset.PerformClick();
        EditLetters.Text = word;
      }
    }

    private void UpdateButtons()
    {
      try
      {
        if ( ComboBoxCode.SelectedItem == null ) return;
        var row = (Data.DataSet.LettersRow)( (DataRowView)ComboBoxCode.SelectedItem ).Row;
        ActionAddMeaning.Enabled = true;
        ActionDeleteMeaning.Enabled = row.GetMeaningsRows().Length > 0;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
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
      UpdateButtons();
    }

    private void EditMeanings_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      Globals.AllowClose = false;
    }

    private void EditMeanings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      Globals.AllowClose = true;
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

    private void ActionDelFirst_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Text.Length <= 1 ) return;
      EditLetters.Text = EditLetters.Text.Remove(EditLetters.Text.Length - 1, 1);
      EditLetters.Focus();
    }

    private void ActionDelLast_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Text.Length <= 1 ) return;
      EditLetters.Text = EditLetters.Text.Remove(0, 1);
      EditLetters.Focus();
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      EditLetters.Text = Program.StartupWord;
      EditLetters.Focus();
    }

    private void EditLetters_InputTextChanged(object sender, EventArgs e)
    {
      var enabled = EditLetters.Text != "";
      ActionDelFirst.Enabled = EditLetters.Text.Length > 1;
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
      EditLetters.Text = "";
      EditSentence.Text = "";
      EditGematria.Text = "";
      EditAnalyze.Controls.Clear();
      ActionCopyToClipboardMeanings.Enabled = false;
      EditLetters.Focus();
    }

    private void ActionPasteFromUnicode_Click(object sender, EventArgs e)
    {
      string str = Clipboard.GetText();
      EditLetters.Text = HebrewAlphabet.ConvertToHebrewFont(new string(str.ToArray())).Replace(" ", "");
      EditLetters.Focus();
    }

    private void ActionCopyToUnicode_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Text != "" )
        Clipboard.SetText(HebrewAlphabet.ConvertToUnicode(EditLetters.Text));
      EditLetters.Focus();
    }

    private void ActionCopyToClipboardMeanings_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Text != "" ) Clipboard.SetText(SelectedMeanings);
    }

    private void ActionCopyToClipboardResults_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text != "" ) Clipboard.SetText(EditSentence.Text);
      if ( SelectCloseApp.Checked ) Close();
    }

    private void ActionAnalyse_Click(object sender, EventArgs e)
    {
      DoAnalyse();
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

    private void EditSentence_TextChanged(object sender, EventArgs e)
    {
      ActionCopyToClipboardResult.Enabled = EditSentence.Text != "";
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
        DisplayManager.ShowError("Internal index error." + Environment.NewLine +
                                 "Application will exit." + Environment.NewLine + Environment.NewLine +
                                 e.Exception.InnerException?.Message ?? "Unknown.");
        DataSet.RejectChanges();
        Application.Exit();
      }
      else
        e.Exception.Manage();
    }

  }

}
