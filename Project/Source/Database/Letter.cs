/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-08 </edited>
namespace Ordisoftware.Hebrew.Letters;

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

[Serializable]
[Table("Letters")]
public class Letter : INotifyPropertyChanged
{

  [field: NonSerialized]
  public event PropertyChangedEventHandler PropertyChanged;

  protected void NotifyPropertyChanged(string p)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
  }

  [PrimaryKey]
  [NotNull]
  public string Code
  {
    get => _Code;
    set
    {
      if ( _Code == value ) return;
      _Code = value;
      NotifyPropertyChanged(nameof(Code));
    }
  }
  private string _Code;

  [NotNull]
  public string Name
  {
    get => _Name;
    set
    {
      if ( _Name == value ) return;
      _Name = value;
      NotifyPropertyChanged(nameof(Name));
    }
  }
  private string _Name;

  [NotNull]
  public string Hebrew
  {
    get => _Hebrew;
    set
    {
      if ( _Hebrew == value ) return;
      _Hebrew = value;
      NotifyPropertyChanged(nameof(Hebrew));
    }
  }
  private string _Hebrew;

  [NotNull]
  public string Positive
  {
    get => _Positive;
    set
    {
      if ( _Positive == value ) return;
      _Positive = value;
      NotifyPropertyChanged(nameof(Positive));
    }
  }
  private string _Positive;

  [NotNull]
  public string Negative
  {
    get => _Negative;
    set
    {
      if ( _Negative == value ) return;
      _Negative = value;
      NotifyPropertyChanged(nameof(Negative));
    }
  }
  private string _Negative;

  [NotNull]
  public string Structure
  {
    get => _Structure;
    set
    {
      if ( _Structure == value ) return;
      _Structure = value;
      NotifyPropertyChanged(nameof(Structure));
    }
  }
  private string _Structure;

  [NotNull]
  public string Function
  {
    get => _Function;
    set
    {
      if ( _Function == value ) return;
      _Function = value;
      NotifyPropertyChanged(nameof(Function));
    }
  }
  private string _Function;

  [NotNull]
  public string Verb
  {
    get => _Verb;
    set
    {
      if ( _Verb == value ) return;
      _Verb = value;
      NotifyPropertyChanged(nameof(Verb));
    }
  }
  private string _Verb;

  [NotNull]
  public int ValueSimple
  {
    get => _ValueSimple;
    set
    {
      if ( _ValueSimple == value ) return;
      _ValueSimple = value;
      NotifyPropertyChanged(nameof(ValueSimple));
    }
  }
  private int _ValueSimple;

  [NotNull]
  public int ValueFull
  {
    get => _ValueFull;
    set
    {
      if ( _ValueFull == value ) return;
      _ValueFull = value;
      NotifyPropertyChanged(nameof(ValueFull));
    }
  }
  private int _ValueFull;

  public List<Meaning> Meanings
    => ApplicationDatabase.Instance.Meanings.Where(item => item.LetterCode == Code).ToList();

}
