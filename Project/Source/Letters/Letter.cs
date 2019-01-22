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
  /// Provide hebrew letter.
  /// </summary>
  [Serializable]
  public class Letter
  {

    /// <summary>
    /// Indicate letter keyboard code for font Hebrew.ttf from www.wingreek.com.
    /// </summary>
    public char Code { get; set; }

    /// <summary>
    /// Indicate letter value.
    /// </summary>
    public int Value { get; internal set; }

    /// <summary>
    /// Indicate letter name.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Indicates letter structure definition.
    /// </summary>
    public string Structure { get; set; }
    
    /// <summary>
    /// Indicates letter function definition.
    /// </summary>
    public string Function { get; set; }
    
    /// <summary>
    /// Indicates letter meanings definition. 
    /// </summary>
    public List<string> Meanings { get; set; }
    
    /// <summary>
    /// Constructor. 
    /// </summary>
    public Letter() { }

  }

}
