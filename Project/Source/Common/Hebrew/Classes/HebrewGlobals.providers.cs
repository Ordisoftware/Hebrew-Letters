﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
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
/// <created> 2020-03 </created>
/// <edited> 2021-10 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provides hebrew global variables.
  /// </summary>
  static partial class HebrewGlobals
  {

    /// <summary>
    /// Indicates the application web providers folder.
    /// </summary>
    static public string WebProvidersFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "WebProviders");

    /// <summary>
    /// Indicates the file path of the online search word providers.
    /// </summary>
    static public string WebProvidersWordFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Word.txt");

    /// <summary>
    /// Indicates the file path of the online search concordance providers.
    /// </summary>
    static public string WebProvidersConcordanceFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Concordance.txt");

    /// <summary>
    /// Indicates the file path of the online bible verse providers.
    /// </summary>
    static public string WebProvidersBibleFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Bible.txt");

    /// <summary>
    /// Indicates the file path of the online study parashah providers.
    /// </summary>
    static public string WebProvidersParashahFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Parashah.txt");

    /// <summary>
    /// Indicates the file path of the online study parashah providers.
    /// </summary>
    static public string WebProvidersCelebrationFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Celebration.txt");

    /// <summary>
    /// Indicates the online search a word providers.
    /// </summary>
    static public OnlineProviders WebProvidersWord { get; private set; }

    /// <summary>
    /// Indicates the online search a concordance providers.
    /// </summary>
    static public OnlineProviders WebProvidersConcordance { get; private set; }

    /// <summary>
    /// Indicates the online bible verse providers.
    /// </summary>
    static public OnlineProviders WebProvidersBible { get; private set; }

    /// <summary>
    /// Indicates the online study parashah providers.
    /// </summary>
    static public OnlineProviders WebProvidersParashah { get; private set; }

    /// <summary>
    /// Indicates the online study celebration providers.
    /// </summary>
    static public OnlineProviders WebProvidersCelebration { get; private set; }

    /// <summary>
    /// Loads the providers files.
    /// </summary>
    static internal void LoadProviders()
    {
      const DataFileFolder folder = DataFileFolder.ApplicationDocuments;
      WebProvidersWord = Globals.CreateOnlineProviders(folder, WebProvidersWordFilePath);
      WebProvidersConcordance = Globals.CreateOnlineProviders(folder, WebProvidersConcordanceFilePath);
      WebProvidersBible = Globals.CreateOnlineProviders(folder, WebProvidersBibleFilePath);
      WebProvidersParashah = Globals.CreateOnlineProviders(folder, WebProvidersParashahFilePath);
      WebProvidersCelebration = Globals.CreateOnlineProviders(folder, WebProvidersCelebrationFilePath);
      Globals.LoadWebLinksProviders();
    }

  }

}
