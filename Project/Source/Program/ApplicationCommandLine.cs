/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2012-2022 Olivier Rogier.
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
namespace Ordisoftware.Hebrew.Letters;

using CommandLine;

class ApplicationCommandLine : SystemCommandLine
{

  static public ApplicationCommandLine Instance
    => SystemManager.CommandLineOptions as ApplicationCommandLine;

  [Option("word", Required = false, HelpText = "Unicode chars or else Hebrew font chars word to analyse.")]
  public string WordHebrew { get; set; }

}
