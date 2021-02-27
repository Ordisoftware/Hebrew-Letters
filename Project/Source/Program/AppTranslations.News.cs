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
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Letters
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class AppTranslations
  {

    static public readonly NullSafeDictionary<string, TranslationsDictionary> NoticeNewFeatures
      = new NullSafeDictionary<string, TranslationsDictionary>
      {

        ["5.0"] = new TranslationsDictionary
        {
          // TODO Amélioration de l'édition des données
          [Language.EN] = "Startup and combo boxes creation are optimized." + Globals.NL2 +
                          "Modification of the database is only possible by one instance at a time." + Globals.NL2 +
                          "New top menu icon to open a new window." + Globals.NL2 +
                          "New context menu on letters' buttons." + Globals.NL2 +
                          "New screenshot button." + Globals.NL2 +
                          "New usage statistics window." + Globals.NL2 +
                          "Rework of the preferences window design with more options." + Globals.NL2 +
                          "Fixed and improved copy, paste and delete for both Hebrew font chars and unicode." + Globals.NL2 +
                          "Incorporate common code written since more than one year for Hebrew Calendar." + Globals.NL2 +
                          "Added new in version in the Information menu." + Globals.NL2 +
                          "Modification and addition of web links and online providers for the study of words and verses of the Bible." + Globals.NL2 +
                          "Some improvements in appearance and function.",

          [Language.FR] = "La démarrage et la création des boites combos sont optimisé." + Globals.NL2 +
                          "La modification de la base de données est possible seulement par une seule instance à la fois." + Globals.NL2 +
                          "Nouvelle icône de menu principal pour ouvrir une nouvelle fenêtre." + Globals.NL2 +
                          "Nouveau menu contextuel pour les boutons des lettres." + Globals.NL2 +
                          "Nouveau bouton de capture d'écran." + Globals.NL2 +
                          "Nouvelle fenêtre de statistiques d'utilisation." + Globals.NL2 +
                          "Refonte de la fenêtre des préférences avec ajout d'options." + Globals.NL2 +
                          "Correction et amélioration du copier, coller et supprimer pour les caractères de police hébreu et Unicode." + Globals.NL2 +
                          "Incorporation du code commun écrit depuis plus d'un an pour Hebrew Calendar." + Globals.NL2 +
                          "Ajout des nouveautés de version dans le menu Information." + Globals.NL2 +
                          "Modification et ajouts de liens web et de fournisseurs en ligne pour l'étude des mots et des versets de la Bible." + Globals.NL2 +
                          "Quelques améliorations d'aspect et de fonctionnement."
        }
      };

  }

}
