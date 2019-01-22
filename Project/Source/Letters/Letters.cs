/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <created> 2012-10 </created>
/// <edited> 2013-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLettriq
{

  /// <summary>
  /// Provide hebrew letters dictionary singleton.
  /// </summary>
  [Serializable]
  public sealed partial class Letters : Dictionary<char, Letter>
  {

    static public Letters Instance;

    static Letters()
    {
      Instance = new Letters();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    private Letters()
    {
      for ( int i = 0; i < _Codes.Length; i++ )
        Add(_Codes[i],
                  new Letter()
                  {
                    Code = _Codes[i],
                    Value = _Values[i],
                    Name = _Names[i],
                    Structure = _Structures[i],
                    Function = _Functions[i],
                    Meanings = _Meanings[i]
                  });
    }

  }

}
