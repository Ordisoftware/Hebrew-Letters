/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2022-07 </edited>
namespace Ordisoftware.Hebrew.Letters;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  /// <summary>
  /// Creates system information menu items.
  /// </summary>
  public void CreateSystemInformationMenu()
  {
    CommonMenusControl.CreateInstance(ToolStrip,
                                      ref ActionInformation,
                                      AppTranslations.NoticeNewFeatures,
                                      ActionWebCheckUpdate_Click,
                                      ActionViewLog_Click,
                                      ActionViewStats_Click);
    InitializeSpecialMenus();
  }

  /// <summary>
  /// Initializes special menus.
  /// </summary>
  public void InitializeSpecialMenus()
  {
    CreateProvidersLinks();
    CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
    CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
    if ( Settings.WebLinksMenuEnabled )
      ActionWebLinks.CreateWebLinks(InitializeSpecialMenus);
  }

  static private readonly Image HebrewWordsIcon = CreateImage("hebrew_words16.ico");

  static private Image CreateImage(string fileName)
  {
    try
    {
      return Image.FromFile(Path.Combine(Globals.ProjectIconsApplicationsFolderPath, fileName));
    }
    catch ( Exception ex )
    {
      DebugManager.Trace(LogTraceEvent.Exception, new ExceptionInfo(null, ex).FullText);
      return null;
    }
  }

  /// <summary>
  /// Creates providers links menu items.
  /// </summary>
  private void CreateProvidersLinks()
  {
    EditWord.ContextMenuSearchOnline.Initialize(HebrewGlobals.WebProvidersWord,
      (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        HebrewTools.OpenWordProvider((string)menuitem.Tag, EditWord.TextBox.Text);
        EditWord.Focus();
      },
      () =>
      {
        var menuitem = new ToolStripMenuItem(HebrewGlobals.AppNameHebrewWords, HebrewWordsIcon);
        menuitem.Click += (sender, e) => HebrewTools.OpenHebrewWordsSearchWord(EditWord.InputText);
        if ( EditWord.ContextMenuSearchOnline.Items.Count > 0 )
          EditWord.ContextMenuSearchOnline.Items.Add(new ToolStripSeparator());
        EditWord.ContextMenuSearchOnline.Items.Add(menuitem);
      });
    ContextMenuOpenConcordance.Initialize(HebrewGlobals.WebProvidersConcordance, (sender, e) =>
    {
      if ( sender is not ToolStripMenuItem menuitem )
        return;
      if ( menuitem.GetCurrentParent() is ContextMenuStrip menu )
        if ( menu.SourceControl is not Button owner )
          return;
        else
        {
          var control = owner == ActionOpenConcordance ? EditConcordance : EditConcordanceRoot;
          HebrewTools.OpenWordConcordance((string)menuitem.Tag, (int)control.Value);
          EditWord.Focus();
        }
    }, null);
  }

}
