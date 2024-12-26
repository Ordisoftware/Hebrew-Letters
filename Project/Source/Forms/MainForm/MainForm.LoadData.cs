/// <license>
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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private void LoadData()
  {
    Globals.ChronoLoadData.Start();
    try
    {
      DBApp.Open();
      LettersBindingSource.DataSource = DBApp.LettersAsBindingList;
      if ( ApplicationCommandLine.Instance.IsPreviewEnabled ) // TODO remove when ready
      {
        DBHebrew.TakeLettriqs();
        TermsBindingSource.DataSource = DBHebrew.TermsHebrewAsBindingList;
        LettriqsBindingSource.DataSource = DBHebrew.TermLettriqsAsBindingList;
      }
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(SysTranslations.ApplicationMustExit.GetLang() + Globals.NL2 +
                               SysTranslations.ContactSupport.GetLang());
      ex.Manage();
      Environment.Exit(-1);
    }
    finally
    {
      Globals.ChronoLoadData.Stop();
      Settings.BenchmarkLoadData = Globals.ChronoLoadData.ElapsedMilliseconds;
    }
  }

}
