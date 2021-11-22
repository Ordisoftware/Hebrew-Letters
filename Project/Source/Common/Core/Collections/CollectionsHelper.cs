﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
namespace Ordisoftware.Core;

using System;
using System.Linq;
using System.Collections.Generic;

static public class CollectionsHelper
{

  static public List<List<T>> Split<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
  {
    var slices = new List<List<T>> { new List<T>() };
    foreach ( var item in collection )
    {
      slices.Last().Add(item);
      if ( predicate(item) )
        slices.Add(new List<T>());
    }
    return slices;
  }
}
