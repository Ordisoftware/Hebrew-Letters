/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-08 </edited>
using Microsoft.Win32;
using Ordisoftware.Core;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm : Form
  {

    /// <summary>
    /// INdicate filename of the help file.
    /// </summary>
    static public readonly string HelpFilename
      = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath.Replace("\\Debug\\", "\\").Replace("\\Release\\", "\\"))).FullName + Path.DirectorySeparatorChar
      + "Help" + Path.DirectorySeparatorChar
      + "index.htm";

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public readonly MainForm Instance;

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
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      Text = AboutBox.Instance.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      CreateDatabaseIfNotExists();
      CreateDataIfNotExists(false);
      MeaningsTableAdapter.Fill(DataSet.Meanings);
      LettersTableAdapter.Fill(DataSet.Letters);
      Program.Settings.Retrieve();
      SetView(Program.StartupWord == "" ? Program.Settings.CurrentView : ViewModeType.Analyse, true);
      if ( Program.StartupWord != "" )
      {
        EditLetters.Input.Text = Program.StartupWord;
        ActionAnalyse.PerformClick();
      }
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      CheckUpdate(true);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DataSet.HasChanges() ) TableAdapterManager.UpdateAll(DataSet);
      if ( EditConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(Localizer.ExitApplicationText.GetLang()) )
        {
          e.Cancel = true;
          return;
        }
    }

    /// <summary>
    /// Event handler. Called by MainForm_Form for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.Store();
    }

    /// <summary>
    /// Session ending.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Check if a newer version is available.
    /// </summary>
    private void CheckUpdate(bool auto)
    {
      try
      {
        string title = AboutBox.Instance.AssemblyTitle;
        string url = "http://www.ordisoftware.com/files/" + title.Replace(" ", "") + ".update";
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(url).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          string[] partsAssemblyVersion = AboutBox.Instance.AssemblyVersion.Split('.');
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Localizer.CheckUpdateNoNewText.GetLang());
          }
          else
            if ( DisplayManager.QueryYesNo(Localizer.CheckUpdateResultText.GetLang() + version + Environment.NewLine +
                                           Environment.NewLine +
                                           Localizer.CheckUpdateAskDownloadText.GetLang()) )
            AboutBox.Instance.OpenApplicationHome();
        }
      }
      catch
      {
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
    /// Event handler. Called by ActionViewSearch for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewSearch_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() ) TableAdapterManager.UpdateAll(DataSet);
      SetView(ViewModeType.Analyse);
    }

    /// <summary>
    /// Event handler. Called by ActionViewSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewSettings_Click(object sender, EventArgs e)
    {
      if ( DataSet.HasChanges() ) TableAdapterManager.UpdateAll(DataSet);
      SetView(ViewModeType.Settings);
    }

    /// <summary>
    /// Event handler. Called by ActionResetWinSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Localizer.RestoreWinPosText.GetLang()) )
        Program.Settings.RestoreMainForm();
    }

    /// <summary>
    /// Event handler. Called by EditScreenPosition for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void EditScreenPosition_Click(object sender, EventArgs e)
    {
      DoScreenPosition(sender, e);
    }

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
        AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionHelp for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionHelp_Click(object sender, EventArgs e)
    {
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = HelpFilename;
          process.Start();
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Event handler. Called by ActionApplicationHome for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionApplicationHome_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenApplicationHome();
    }

    /// <summary>
    /// Event handler. Called by ActionContact for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionContact_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenContactPage();
    }

    /// <summary>
    /// Event handler. Called by ActionCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCheckUpdate_Click(object sender, EventArgs e)
    {
      CheckUpdate(false);
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

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
      LettersBindingSource.EndEdit();
    }

    private void ActionAddMeaning_Click(object sender, EventArgs e)
    {
      var row = (DataRowView)meaningsBindingSource.AddNew();
      EditMeanings.BeginEdit(false);
    }

    private void ActionDeleteMeaning_Click(object sender, EventArgs e)
    {
      meaningsBindingSource.RemoveCurrent();
    }

    private void ActionReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Localizer.RestoreLettersDefaultText.GetLang()) )
        CreateDataIfNotExists(true);
    }

    private void PanelLetters_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ( e.KeyChar == '\r' ) ActionAnalyse.PerformClick();
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      EditLetters.Input.Text = "";
      ActionAnalyse.PerformClick();
    }

    private void ActionCopyToClipboardMeanings_Click(object sender, EventArgs e)
    {
      if ( EditLetters.Input.Text != "" ) Clipboard.SetText(Meanings);
    }

    private void ActionCopyToClipboardResults_Click(object sender, EventArgs e)
    {
      if ( EditSentence.Text != "") Clipboard.SetText(EditSentence.Text);
      if ( SelectCloseApp.Checked ) Close();
    }

    private string Meanings;

    private void ActionAnalyse_Click(object sender, EventArgs e)
    {
      string word = EditLetters.Input.Text; // Letters.SwapFinale(panelLetters.Input.Text);
      EditSentence.Text = "";
      EditGematria.Text = "";
      EditAnalyze.Controls.Clear();
      int sum = 0;
      int dy = 0;
      Meanings = "";
      for ( int pos = word.Length - 1; pos >= 0; pos-- )
      {
        var l = DataSet.Letters.FindByCode(Convert.ToString(word[pos]));
        sum += l.ValueSimple;
        var label = new Label();
        label.Text = l.Name;
        label.AutoSize = false;
        label.Size = new Size(50, 13);
        label.Location = new Point(100, 20 + dy);
        label.TextAlign = ContentAlignment.TopRight;
        EditAnalyze.Controls.Add(label);
        var combobox = new ComboBox();
        combobox.DropDownStyle = ComboBoxStyle.DropDownList;
        combobox.Size = new Size(200, 21);
        combobox.Location = new Point(155, 16 + dy);
        combobox.SelectedIndexChanged += MeaningComboBox_SelectedIndexChanged;
        EditAnalyze.Controls.Add(combobox);
        combobox.Items.Add(l.Positive);
        combobox.Items.Add(l.Negative);
        combobox.Items.Add(l.Verb);
        combobox.Items.Add(l.Structure);
        combobox.Items.Add(l.Function);
        Meanings += l.Name + ": ";
        Meanings += l.Positive + ", ";
        Meanings += l.Negative + ", ";
        Meanings += l.Verb + ", ";
        Meanings += l.Structure + ", ";
        Meanings += l.Function + ", ";
        foreach ( var meaning in l.GetMeaningsRows() )
        {
          combobox.Items.Add(meaning.Meaning);
          Meanings += meaning.Meaning + ", ";
        }
        dy += 30;
        try
        {
          Meanings = Meanings.Remove(Meanings.Length - 2, 1);
        }
        catch
        {
        }
        Meanings += Environment.NewLine;
      }
      EditGematria.Text = sum.ToString();
    }

    private void MeaningComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string str = "";
      foreach ( var control in EditAnalyze.Controls )
        if (control is ComboBox)
          str += ( (control as ComboBox).Text ?? "" ) + " ";
      str = str == "" ? "" : str.Remove(str.Length - 1, 1);
      EditSentence.Text = str;
    }

  }

}
