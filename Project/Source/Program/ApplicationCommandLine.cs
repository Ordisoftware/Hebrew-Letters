/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2021-02 </edited>
using System;
using CommandLine;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  public class ApplicationCommandLine : SystemCommandLine
  {
    [Option('h', "hebrew", Required = false, HelpText = "Hebrew word to analyse.")]
    public bool WordHebrew { get; set; }

    [Option('u', "unicode", Required = false, HelpText = "Unicode word to analyse.")]
    public bool WordUnicode { get; set; }
  }

}