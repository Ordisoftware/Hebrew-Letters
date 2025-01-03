﻿/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-08 </edited>
namespace Ordisoftware.Hebrew.Letters;

using Ordisoftware.Hebrew.Letters.Properties;

/// <summary>
/// Provides Settings helper.
/// </summary>
static class SettingsHelper
{

  static private bool Mutex;

  /// <summary>
  /// Indicates the main form instance.
  /// </summary>
  static private readonly MainForm MainForm = MainForm.Instance;

  /// <summary>
  /// The Settings extension method that restores the main form settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void RestoreMainForm(this Settings settings)
  {
    MainForm.Width = MainForm.MinimumSize.Width;
    MainForm.Height = MainForm.MinimumSize.Height;
    MainForm.WindowState = FormWindowState.Normal;
    MainForm.CenterToScreen();
    MainForm.EditScreenNone.Checked = false;
    MainForm.EditScreenTopLeft.Checked = false;
    MainForm.EditScreenTopRight.Checked = false;
    MainForm.EditScreenBottomLeft.Checked = false;
    MainForm.EditScreenBottomRight.Checked = false;
    MainForm.EditScreenCenter.Checked = true;
    MainForm.EditConfirmClosing.Checked = false;
    MainForm.EditShowTips.Checked = true;
    MainForm.EditESCtoExit.Checked = false;
    MainForm.EditSoundsEnabled.Checked = true;
    DisplayManager.AdvancedFormUseSounds = true;
    MainForm.EditUseAdvancedDialogBoxes.Checked = true;
    DisplayManager.FormStyle = MessageBoxFormStyle.Advanced;
    MainForm.EditShowSuccessDialogs.Checked = false;
    DisplayManager.ShowSuccessDialogs = false;
    settings.ApplicationVolume = 100;
    MediaMixer.SetApplicationVolume(Globals.ProcessId, settings.ApplicationVolume);
    MainForm.SetView(ViewMode.Analysis);
    settings.Store();
  }

  /// <summary>
  /// The Settings extension method that retrieves the given settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void Retrieve(this Settings settings)
  {
    if ( Mutex ) return;
    Mutex = true;
    try
    {
      var area = SystemInformation.WorkingArea;
      MainForm.Left = settings.MainFormLeft >= area.Left && settings.MainFormLeft <= area.Width
        ? settings.MainFormLeft
        : area.Left;
      MainForm.Top = settings.MainFormTop >= area.Top && settings.MainFormTop <= area.Height
        ? settings.MainFormTop
        : area.Top;
      MainForm.Width = settings.MainFormWidth >= MainForm.MinimumSize.Width && settings.MainFormWidth <= area.Width
        ? settings.MainFormWidth
        : MainForm.MinimumSize.Width;
      MainForm.Height = settings.MainFormHeight >= MainForm.MinimumSize.Height && settings.MainFormHeight <= area.Height
        ? settings.MainFormHeight
        : MainForm.MinimumSize.Height;
      MainForm.EditScreenNone.Checked = settings.MainFormPosition == ControlLocation.Loose;
      MainForm.EditScreenTopLeft.Checked = settings.MainFormPosition == ControlLocation.TopLeft;
      MainForm.EditScreenTopRight.Checked = settings.MainFormPosition == ControlLocation.TopRight;
      MainForm.EditScreenBottomLeft.Checked = settings.MainFormPosition == ControlLocation.BottomLeft;
      MainForm.EditScreenBottomRight.Checked = settings.MainFormPosition == ControlLocation.BottomRight;
      MainForm.EditScreenCenter.Checked = settings.MainFormPosition == ControlLocation.Center;
      MainForm.EditScreenPosition_Click(null, null);
      MainForm.WindowState = settings.MainFormState;
      //
      MainForm.EditConfirmClosing.Checked = settings.ConfirmClosing;
      MainForm.EditShowTips.Checked = settings.ShowTips;
      MainForm.EditESCtoExit.Checked = settings.ESCtoExit;
      MainForm.EditSoundsEnabled.Checked = settings.SoundsEnabled;
      MainForm.EditUseAdvancedDialogBoxes.Checked = settings.AdvancedDialogBoxes;
      MainForm.EditShowSuccessDialogs.Checked = settings.ShowSuccessDialogs;
      DisplayManager.ShowSuccessDialogs = settings.ShowSuccessDialogs;
      MainForm.EditDialogBoxesSettings_CheckedChanged(null, null);
      MainForm.EditCopyToClipboardCloseApp.Checked = settings.CopyToClipboardCloseApp;
    }
    finally
    {
      Mutex = false;
    }
  }

  /// <summary>
  /// The Settings extension method that stores the given settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void Store(this Settings settings)
  {
    if ( Mutex ) return;
    Mutex = true;
    try
    {
      var winState = MainForm.WindowState;
      if ( winState != FormWindowState.Minimized )
        settings.MainFormState = winState;
      if ( winState == FormWindowState.Normal )
      {
        settings.MainFormLeft = MainForm.Left;
        settings.MainFormTop = MainForm.Top;
        settings.MainFormWidth = MainForm.Width;
        settings.MainFormHeight = MainForm.Height;
      }
      if ( MainForm.EditScreenNone.Checked ) settings.MainFormPosition = ControlLocation.Loose;
      if ( MainForm.EditScreenTopLeft.Checked ) settings.MainFormPosition = ControlLocation.TopLeft;
      if ( MainForm.EditScreenTopRight.Checked ) settings.MainFormPosition = ControlLocation.TopRight;
      if ( MainForm.EditScreenBottomLeft.Checked ) settings.MainFormPosition = ControlLocation.BottomLeft;
      if ( MainForm.EditScreenBottomRight.Checked ) settings.MainFormPosition = ControlLocation.BottomRight;
      if ( MainForm.EditScreenCenter.Checked ) settings.MainFormPosition = ControlLocation.Center;
      //
      settings.ConfirmClosing = MainForm.EditConfirmClosing.Checked;
      settings.ShowTips = MainForm.EditShowTips.Checked;
      settings.ESCtoExit = MainForm.EditESCtoExit.Checked;
      settings.SoundsEnabled = MainForm.EditSoundsEnabled.Checked;
      settings.AdvancedDialogBoxes = MainForm.EditUseAdvancedDialogBoxes.Checked;
      settings.ShowSuccessDialogs = MainForm.EditShowSuccessDialogs.Checked;
      settings.CopyToClipboardCloseApp = MainForm.EditCopyToClipboardCloseApp.Checked;
      SystemManager.TryCatch(settings.Save);
    }
    finally
    {
      Mutex = false;
    }
  }

  /// <summary>
  /// Clears all upgrade required flags.
  /// </summary>
  static internal void SetUpgradeFlagsOff(this Settings settings)
  {
    settings.UpgradeRequired = false;
  }

  /// <summary>
  /// Clears all first launch and upgrade requires flags.
  /// </summary>
  static internal void SetFirstAndUpgradeFlagsOff(this Settings settings)
  {
    settings.SetUpgradeFlagsOff();
    settings.FirstLaunch = false;
    settings.FirstLaunchV4 = false;
  }

  /// <summary>
  /// Get the export directory.
  /// </summary>
  static internal string GetExportDirectory(this Settings settings)
  {
    string result = settings.ExportFolder.Replace("%USER_APP_DOCUMENTS%", Globals.UserDocumentsFolderPath);
    if ( !Directory.Exists(result) ) Directory.CreateDirectory(result);
    return result;
  }

  /// <summary>
  /// Gets the settings export directory.
  /// </summary>
  static internal string GetExportSettingsDirectory(this Settings settings)
  {
    string result = Path.Combine(settings.GetExportDirectory(), "Settings");
    if ( !Directory.Exists(result) ) Directory.CreateDirectory(result);
    return result;
  }

  /// <summary>
  /// Gets the backup directory.
  /// </summary>
  // TODO use when available
  //static internal string GetBackupDirectory(this Settings settings)
  //{
  //  string path = settings.BackupFolder.Replace("%USER_APP_DOCUMENTS%", Globals.UserDocumentsFolderPath);
  //  if ( !Directory.Exists(path) ) Directory.CreateDirectory(path);
  //  return path;
  //}

}
