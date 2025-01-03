﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-09 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides system management.
/// </summary>
static public partial class SystemManager
{

  /// <summary>
  /// Checks the validity of the remote website SSL certificate.
  /// </summary>
  static public void CheckServerCertificate(string url, bool useGitHib, bool isGitHubContent)
  {
    var uri = new Uri(url);
    var certificate = useGitHib
      ? isGitHubContent
        ? GitHubUserContentSSLCertificate
          : GitHubSSLCertificate
      : AuthorWebsiteSSLCertificate;
    uri = new UriBuilder(uri.Scheme, uri.Host).Uri;
    string id = Guid.NewGuid().ToString();
    var point = ServicePointManager.FindServicePoint(uri);
    var request = WebRequest.Create(uri);
    request.ConnectionGroupName = id;
    request.Timeout = WebClientEx.DefaultTimeOutSeconds * 1000;
    using ( var response = request.GetResponse() ) { }
    point.CloseConnectionGroup(id);
    if ( /*certificate["Issuer"] != point.Certificate.Issuer
      ||*/ certificate["Subject"] != point.Certificate.Subject
      /*|| certificate["Serial"] != point.Certificate.GetSerialNumberString()
      || certificate["PublicKey"] != point.Certificate.GetPublicKeyString()*/ )
    {
      string str1 = certificate.Select(item => $"{item.Key} = {item.Value}").AsMultiLine();
      string str2 = $"Issuer = {point.Certificate.Issuer}{Globals.NL}" +
                    $"Subject = {point.Certificate.Subject}"/*{Globals.NL}" +
                    $"Serial = {point.Certificate.GetSerialNumberString()}{Globals.NL}" +
                    $"PublicKey {point.Certificate.GetPublicKeyString()}"*/;
      string msg = SysTranslations.WrongSSLCertificate.GetLang(uri.Host, str1, str2);
      throw new UnauthorizedAccessException(msg);
    }
    if ( DateTime.Now < Convert.ToDateTime(point.Certificate.GetEffectiveDateString())
      || DateTime.Now > Convert.ToDateTime(point.Certificate.GetExpirationDateString()) )
    {
      string msg = SysTranslations.ExpiredSSLCertificate.GetLang(uri.Host,
                                                                 point.Certificate.GetEffectiveDateString(),
                                                                 point.Certificate.GetExpirationDateString());
      throw new UnauthorizedAccessException(msg);
    }
  }

  /// <summary>
  /// Indicates the application website SSL certificate information.
  /// </summary>
  static private readonly NullSafeOfStringDictionary<string> AuthorWebsiteSSLCertificate = [];

  /// <summary>
  /// Indicates the GitHub website SSL certificate information.
  /// </summary>
  static private readonly NullSafeOfStringDictionary<string> GitHubSSLCertificate = [];

  /// <summary>
  /// Indicates the GitHub user content website SSL certificate information.
  /// </summary>
  static private readonly NullSafeOfStringDictionary<string> GitHubUserContentSSLCertificate = [];

  /// <summary>
  /// Loads the SSL certificate.
  /// </summary>
  static public void LoadSSLCertificate()
  {
    if ( Globals.IsVisualStudioDesigner ) return;
    if ( File.Exists(Globals.ApplicationHomeSSLFilePath) )
      AuthorWebsiteSSLCertificate.LoadKeyValuePairs(Globals.ApplicationHomeSSLFilePath, "=>");
    if ( File.Exists(Globals.GitHubSSLFilePath) )
      GitHubSSLCertificate.LoadKeyValuePairs(Globals.GitHubSSLFilePath, "=>");
    if ( File.Exists(Globals.GitHubUserContentSSLFilePath) )
      GitHubUserContentSSLCertificate.LoadKeyValuePairs(Globals.GitHubUserContentSSLFilePath, "=>");
  }

}
