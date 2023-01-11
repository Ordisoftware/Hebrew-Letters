﻿/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Letters;

using SQLite;

[Serializable]
public class MeaningNoID : INotifyPropertyChanged
{

  [field: NonSerialized]
  public event PropertyChangedEventHandler PropertyChanged;

  protected void NotifyPropertyChanged(string property)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
  }

  [NotNull]
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
  [NotNull]
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

}

[Serializable]
[Table("Meanings")]
public class Meaning : MeaningNoID
{

  [PrimaryKey]
  [NotNull]
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
