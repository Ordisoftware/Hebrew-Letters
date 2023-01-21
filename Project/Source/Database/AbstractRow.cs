/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-12 </created>
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Hebrew.Letters;

[Serializable]
public abstract class AbstractRow : INotifyPropertyChanged
{

  [field: NonSerialized]
  public event PropertyChangedEventHandler PropertyChanged;

  protected void NotifyPropertyChanged(string property)
  {
    if ( !ApplicationDatabase.Instance.Loaded || !ApplicationDatabase.Instance.BindingsEnabled ) return;
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    ApplicationDatabase.Instance.AddToModified(this);
  }

}
