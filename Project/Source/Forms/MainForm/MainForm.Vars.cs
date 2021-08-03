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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
using System.Collections.Generic;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    private readonly Properties.Settings Settings = Program.Settings;

    /// <summary>
    /// Indicate last showned menu tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    /// <summary>
    /// Indicate the last term searched.
    /// </summary>
    private string LastTermSearched;

    /// <summary>
    /// Indicate if data has changed to refresh the analysis.
    /// </summary>
    private bool DataChanged;

    /// <summary>
    /// Indicate if terms tables are readonly, else writable.
    /// </summary>
    private bool IsTermsReadOnly;

    public ApplicationDatabase DBApp = ApplicationDatabase.Instance;
    public HebrewDatabase DBHebrew = Globals.IsDevExecutable ? HebrewDatabase.Instance : null; // TODO remove when ready

    public BindingListView<Letter> LettersAsBindingList => ApplicationDatabase.Instance.LettersAsBindingList;

    public List<Letter> Letters => ApplicationDatabase.Instance.Letters;
    public List<Meaning> Meanings => ApplicationDatabase.Instance.Meanings;

    public List<TermHebrew> TermsHebrew => HebrewDatabase.Instance.TermsHebrew;
    public List<TermLettriq> TermLettriqs => HebrewDatabase.Instance.TermLettriqs;
    public List<TermAnalysis> TermAnalyzes => HebrewDatabase.Instance.TermAnalyzes;

    public BindingListView<TermHebrew> TermsHebrewAsBindingList => HebrewDatabase.Instance.TermsHebrewAsBindingList;
    public BindingListView<TermLettriq> TermLettriqsAsBindingList => HebrewDatabase.Instance.TermLettriqsAsBindingList;

  }

}
