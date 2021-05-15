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
/// <created> 2021-05 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Ordisoftware.Hebrew.Letters
{

  [Table("Letters")]
  [Serializable]
  public class Letter
  {
    [PrimaryKey]
    public string Code { get; set; }
    public string Name { get; set; }
    public string Hebrew { get; set; }
    public string Positive { get; set; }
    public string Negative { get; set; }
    public string Structure { get; set; }
    public string Function { get; set; }
    public string Verb { get; set; }
    public int ValueSimple { get; set; }
    public int ValueFull { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Meaning> Meanings { get; set; } = new List<Meaning>();
    //=> ApplicationDatabase.Instance.Meanings.Where(item => item.LetterCode == Code).ToList();
  }

}
