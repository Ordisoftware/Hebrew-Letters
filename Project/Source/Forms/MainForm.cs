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
/// <edited> 2019-01 </edited>
using Microsoft.Win32;
using Ordisoftware.Core;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
    /// Event handler. Called by ActionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_Click(object sender, EventArgs e)
    {
      Close();
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

    private void ActionCopyToClipboard_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(EditSentence.Text);
    }

    private void ActionAnalyse_Click(object sender, EventArgs e)
    {
      string word = EditLetters.Input.Text; // Letters.SwapFinale(panelLetters.Input.Text);
      EditAnalyse.Focus();
      EditAnalyse.Rows.Clear();
      EditSentence.Text = "";
      EditGematria.Text = "";
      int sum = 0;
      for ( int pos = word.Length - 1; pos >= 0; pos-- )
      {
        int index = EditAnalyse.Rows.Add();
        var l = DataSet.Letters.FindByCode(Convert.ToString(word[pos]));
        sum += l.ValueSimple;
        EditAnalyse[0, index].Value = l.Name;
        var cellComboBox = (DataGridViewComboBoxCell)EditAnalyse[1, index];
        cellComboBox.Items.Add(l.Verb);
        cellComboBox.Items.Add(l.Structure);
        cellComboBox.Items.Add(l.Function);
        foreach ( var meaning in l.GetMeaningsRows() )
          cellComboBox.Items.Add(meaning.Meaning);
      }
      EditGematria.Text = sum.ToString();
    }

    private void EditAnalyse_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      if ( EditAnalyse.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn )
      {
        EditAnalyse.BeginEdit(true);
        ( (ComboBox)EditAnalyse.EditingControl ).DroppedDown = true;
      }
    }

    private void EditAnalyse_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      /* bug -> background black
      var combobox = e.Control as ComboBox;
      if ( combobox != null )
      {
        combobox.SelectedIndexChanged += new EventHandler(ActionCreateSentence_Click);
        combobox.SelectedValueChanged += new EventHandler(ActionCreateSentence_Click);
      }*/
    }

    private void ActionCreateSentence_Click(object sender, EventArgs e)
    {
      string str = "";
      foreach ( DataGridViewRow row in EditAnalyse.Rows )
        str += ( row.Cells[1].EditedFormattedValue ?? "" ) + " ";
      str = str == "" ? "" : str.Remove(str.Length - 1, 1);
      EditSentence.Text = str;
    }
  }

}
