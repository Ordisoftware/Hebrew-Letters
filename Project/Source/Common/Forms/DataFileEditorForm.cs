﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public partial class DataFileEditorForm : Form
  {

    static public bool Run(string title, DataFile file)
    {
      var form = new DataFileEditorForm();
      form.Text = title;
      AddTab(form.TabControl, file);
      bool result = form.ShowDialog() == DialogResult.OK;
      if ( result ) file.ReLoad();
      return result;
    }

    static public bool Run(string title, IEnumerable<DataFile> files)
    {
      var form = new DataFileEditorForm();
      form.Text = title;
      foreach ( var item in files ) AddTab(form.TabControl, item);
      bool result = form.ShowDialog() == DialogResult.OK;
      if (result) foreach ( var item in files ) item.ReLoad();
      return result;
    }

    static void AddTab(TabControl tabcontrol, DataFile file)
    {
      if ( !File.Exists(file.Filename) )
      {
        DisplayManager.ShowError(Localizer.FileNotFound.GetLang(file.Filename));
        return;
      }
      var textbox = new UndoRedoTextBox();
      textbox.Font = new Font("Consolas", 9.75F);
      textbox.Multiline = true;
      textbox.WordWrap = false;
      textbox.ScrollBars = ScrollBars.Both;
      textbox.Dock = DockStyle.Fill;
      textbox.Text = File.ReadAllText(file.Filename);
      var tabpage = new TabPage(Path.GetFileName(file.Filename).Replace(".txt", ""));
      tabpage.Tag = file;
      tabpage.Controls.Add(textbox);
      tabcontrol.TabPages.Add(tabpage);
    }

    public DataFileEditorForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    private void EditProvidersForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void EditProvidersForm_Shown(object sender, EventArgs e)
    {
      UndoRedoTextBox textbox = (UndoRedoTextBox)TabControl.TabPages[0].Controls[0];
      textbox.Focus();
      textbox.SelectionStart = 0;
      textbox.SelectionLength = 0;
    }

    private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      UndoRedoTextBox textbox = (UndoRedoTextBox)TabControl.SelectedTab.Controls[0];
      textbox.Focus();
      textbox.SelectionLength = 0;
    }

    private void ActionReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Localizer.AskToLoadInstalledData.GetLang()) ) return;
      string filename = Localizer.UndefinedSlot.GetLang();
      foreach ( TabPage page in TabControl.TabPages )
        try
        {
          filename = ( (DataFile)page.Tag ).FilenameDefault;
          ( (TextBox)page.Controls[0] ).Text = File.ReadAllText(filename);
        }
        catch ( Exception ex )
        {
          string msg = Localizer.LoadFileError.GetLang(filename, ex.Message);
          DisplayManager.ShowError(msg);
        }
      EditProvidersForm_Shown(this, null);
    }

    private void ActionOK_Click(object sender, EventArgs e)
    {
      string filename = Localizer.UndefinedSlot.GetLang();
      foreach ( TabPage page in TabControl.TabPages )
        try
        {
          filename = ( (DataFile)page.Tag ).Filename;
          File.WriteAllText(filename, ( (TextBox)page.Controls[0] ).Text);
        }
        catch ( Exception ex )
        {
          string msg = Localizer.WriteFileError.GetLang(filename, ex.Message);
          DisplayManager.ShowError(msg);
        }
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

  }

}
