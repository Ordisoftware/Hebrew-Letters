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
using System.Collections;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLettriq
{

  /// <summary>
  /// Provide hebrew letters dictionary singleton.
  /// </summary>
  public partial class Letters
  {

    static internal Dictionary<char, char> FinaleEnable = new Dictionary<char, char>()
    { 
      { '!', 'k' }, { ',', 'm' }, { ']', 'n' }, { '[', 'p' }, { '/', 'j' } 
    };

    static internal Dictionary<char, char> FinaleDisable = new Dictionary<char, char>()
    { 
      { 'k', '!' }, { 'm', ',' }, { 'n', ']' }, { 'p', '[' }, { 'j', '/' } 
    };

    /// <summary>
    // Convert letters from www.fourmilab.ch/etexts/www/hebrew/Bible to the software codes letters.
    /// </summary>
    static public string SetFinale(string str, bool enable)
    {
      var array = new Dictionary<char, char>(enable ? FinaleEnable : FinaleDisable);
      str = str.Trim();
      if ( str.Length == 0 ) return str;
      char c = str[0];
      foreach (var v in array)
        if (c == v.Key)
        {
          c = v.Value;
          break;
        }
      str = c + str.Remove(0, 1);
      return str;
    }

    /// <summary>
    // Convert letters from www.fourmilab.ch/etexts/www/hebrew/Bible to font codes.
    /// </summary>
    static public char ConvertToKey(char c)
    {
      switch ( c )
      {
        case 'א': return 'a';
        case 'ב': return 'b';
        case 'ג': return 'g';
        case 'ד': return 'd';
        case 'ה': return 'h';
        case 'ו': return 'v';
        case 'ז': return 'z';
        case 'ח': return 'x';
        case 'ט': return 'u';
        case 'י': return 'y';
        case 'כ': return 'k';
        case 'ך': return '!';
        case 'ל': return 'l';
        case 'מ': return 'm';
        case 'ם': return ',';
        case 'נ': return 'n';
        case 'ן': return ']';
        case 'ס': return 'c';
        case 'ע': return 'i';
        case 'פ': return 'p';
        case 'ף': return '[';
        case 'צ': return 'j';
        case 'ץ': return '/';
        case 'ק': return 'q';
        case 'ר': return 'r';
        case 'ש': return '>';
        case 'ת': return 't';
        case ':': return '.';
        case '-': return ' '; //return '=';
        default: return c;
      }
    }

    /// <summary>
    // Get a letter from his value.
    /// </summary>
    /*static public char GetLetterFromNumber(int value)
    {
      switch ( value )
      {
        case 1: return 'a';
        case 2: return 'b';
        case 3: return 'g';
        case 4: return 'd';
        case 5: return 'h';
        case 6: return 'v';
        case 7: return 'z';
        case 8: return 'x';
        case 9: return 'u';
        case 10: return 'y';
        case 20: return 'k';
        case 30: return 'l';
        case 40: return 'm';
        case 50: return 'n';
        case 60: return 'c';
        case 70: return 'i';
        case 80: return 'p';
        case 90: return 'j';
        case 100: return 'q';
        case 200: return 'r';
        case 300: return '>';
        case 400: return 't';
        default: return '=';
      }
    }*/

  }

}
