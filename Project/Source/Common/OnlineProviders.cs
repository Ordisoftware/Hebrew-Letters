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
/// <created> 2020-03 </created>
/// <edited> 2020-04 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Online providers list.
  /// </summary>
  public partial class OnlineProviders
  {

    /// <summary>
    /// Indicate items.
    /// </summary>
    public List<OnlineProviderItem> Items { get; private set; }

    /// <summary>
    /// Indicate the multilingual title of the list to create a folder
    /// </summary>
    private readonly Dictionary<string, string> Title = new Dictionary<string, string>();

    /// <summary>
    /// Indicate if a separator must be inserted before the folder
    /// </summary>
    private readonly bool SeparatorBeforeFolder;

    /// <summary>
    /// Static constructor.
    /// </summary>
    public OnlineProviders(string filename, bool showFileNotFound = true)
    {
      Items = new List<OnlineProviderItem>();
      if ( !File.Exists(filename) )
      {
        if ( showFileNotFound )
          DisplayManager.ShowError(FileNotFound.GetLang(filename));
        return;
      }
      try
      {
        var lines = File.ReadAllLines(filename);
        for ( int index = 0; index < lines.Length; index++ )
        {
          Action showError = () =>
          {
            DisplayManager.ShowError(ErrorMsg.GetLang(filename, index, lines[index]));
          };
          if ( lines[index].Trim() == "" )
            continue;
          if ( lines[index].Trim().StartsWith(";") )
            continue;
          if ( lines[index].Trim().StartsWith("FOLDER-SEPARATOR") )
            SeparatorBeforeFolder = true;
          else
          if ( lines[index].StartsWith("-") )
            Items.Add(new OnlineProviderItem("-"));
          else
          if ( lines[index].StartsWith("Lang/") )
          {
            var parts = lines[index].Split(new string[] { "/", " = " }, StringSplitOptions.None);
            if ( parts.Length == 3 )
              Title.Add(parts[1].Trim().ToLower(), parts[2].Trim());
            else
              showError();
          }
          else
          if ( lines[index].StartsWith("Name") )
          {
            var parts = lines[index].Split(new string[] { " = " }, StringSplitOptions.None);
            if ( parts.Length == 2 )
            {
              string name = parts[1].Trim();
              index++;
              if ( index >= lines.Length )
                showError();
              if ( lines[index].StartsWith("URL") )
              {
                parts = lines[index].Split(new string[] { " = " }, StringSplitOptions.None);
                if ( parts.Length == 2 )
                {
                  string url = parts[1].Trim();
                  Items.Add(new OnlineProviderItem(name, url));
                }
                else
                  showError();
              }
              else
                showError();
            }
            else
              showError();
          }
          else
            showError();
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
