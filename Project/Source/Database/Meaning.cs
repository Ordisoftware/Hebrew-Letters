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
using System.ComponentModel;
using SQLite;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  [Serializable]
  [Table("Meanings")]
  public class Meaning : Meaning_No_ID
  {

    [PrimaryKey]
    public string ID
    {
      get => _ID;
      set
      {
        if ( _ID == value ) return;
        _ID = value;
        NotifyPropertyChanged(nameof(ID));
      }
    }
    private string _ID;

  }

  public class Meaning_No_ID : INotifyPropertyChanged
  {

    public string LetterCode
    {
      get => _LetterCode;
      set
      {
        if ( _LetterCode == value ) return;
        _LetterCode = value;
        NotifyPropertyChanged(nameof(LetterCode));
      }
    }
    private string _LetterCode;

    [Column("Meaning")]
    public string Text
    {
      get => _Text;
      set
      {
        if ( _Text == value ) return;
        _Text = value;
        NotifyPropertyChanged(nameof(Text));
      }
    }
    private string _Text;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string p)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }

  }

  static class MeaningsUpgrade
  {
    static public void AddID(SQLiteNetORM connection)
    {
      connection.Execute($@"PRAGMA foreign_keys = 0;");
      connection.DropTableIfExists(nameof(Meaning_No_ID));
      connection.RenameTableIfExists(nameof(ApplicationDatabase.Instance.Meanings), nameof(Meaning_No_ID));
      connection.CreateTable<Meaning>();
      var rows = connection.Table<Meaning_No_ID>();
      connection.BeginTransaction();
      foreach ( var row in rows )
        connection.Insert(new Meaning { ID = Guid.NewGuid().ToString(), LetterCode = row.LetterCode, Text = row.Text });
      connection.Commit();
      connection.DropTableIfExists(nameof(Meaning_No_ID));
      connection.Execute($@"PRAGMA foreign_keys = 1;");
    }
  }

}
