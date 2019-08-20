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
/// <created> 2012-10 </created>
/// <edited> 2019-08 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide hebrew letters default values.
  /// </summary>
  static public class Letters
  {

    /// <summary>
    /// Provide letter meaning translation
    /// </summary>
    public class MeaningTranslation : Dictionary<string, List<string>>
    {
    }

    /// <summary>
    /// Indicate letters keyboard codes.
    /// </summary>
    static public readonly string[] Codes = 
    {
      "a", "b", "g", "d", "h", "v", "z", "x", "u", "y", "k",
      "l", "m", "n", "c", "i", "p", "j", "q", "r", ">", "t"
    };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesSimple = 
    {
      1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20,
      30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400
    };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesFull = 
    {
      111, 412, 83, 434, 6, 12, 67, 418, 419, 20, 100,
      74, 90, 106, 120, 130, 81, 104, 186, 510, 360, 406
    };

    /// <summary>
    /// Indicate letters names.
    /// </summary>
    static public readonly string[] Names = 
    {
      "Alef", "Bet", "Gimel", "Dalet", "Hé", "Vav", "Zayin", "Het", "Tet", "Youd", "Kaf",
      "Lamed", "Mem", "Noun", "Samech", "Ayin", "Pé", "Tsadé", "Qof", "Resh", "Shin", "Tav"
    };

  }

}
