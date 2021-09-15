﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public class TorahCelebrationVerses : ProviderSettings
  {

    static public TorahCelebrationVerses Instance = new TorahCelebrationVerses();

    public NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>> Items
      = new NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>>();

    protected override void SetFilePath()
    {
      FilePath = HebrewGlobals.CelebrationVersesFilePath;
    }

    protected override void DoClear()
    {
      Items.Clear();
    }

    protected override void DoLoad(string line)
    {
      var parts = line.Split(':');
      if ( parts.Length < 2 ) return;
      var celebration = Enums.Parse<TorahCelebration>(parts[0].Trim());
      if ( Items[celebration] == null ) Items[celebration] = new List<Tuple<Books, string, string>>();
      var verses = parts[1].Split('-');
      if ( verses.Length < 2 ) return;
      var book = Enums.Parse<Books>(verses[0].Trim());
      string verse1 = verses[1].Trim();
      string verse2 = verses.Length > 2 ? verses[2].Trim() : string.Empty;
      Items[celebration].Add(new Tuple<Books, string, string>(book, verse1, verse2));
    }

    protected override void DoSave(StreamWriter stream)
    {
      foreach ( var kvp in Items )
        foreach ( var item in kvp.Value )
          stream.WriteLine($"{kvp.Key} : {item.Item1} - {item.Item2} - {item.Item3}");
    }

  }

}
