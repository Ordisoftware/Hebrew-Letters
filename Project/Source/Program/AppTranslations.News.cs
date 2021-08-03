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
/// <edited> 2021-08 </edited>
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

        /*["6.1"] = new TranslationsDictionary
        {
          [Language.EN] = "Added lettriqs notebook.",

          [Language.FR] = "Ajout d'un carnet des lettriques."
        },*/

        ["6.0"] = new TranslationsDictionary
        {
          [Language.EN] = "Some fixes and improvements." + Globals.NL +
                          "Overall performances are optimized." + Globals.NL +
                          "SQLite ODBC Driver is no more needed.",

          [Language.FR] = "Quelques corrections et améliorations." + Globals.NL +
                          "Les performances globales sont optimisées." + Globals.NL +
                          "Le pilote SQLite ODBC n'est plus nécessaire. "
        },

        ["5.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Added command-line options (see help FAQ)." + Globals.NL +
                          "Startup speed and analysis combo boxes creation are optimized." + Globals.NL +
                          "Data edition is only possible by one instance at a time." + Globals.NL +
                          "Data edition is improved to have save and cancel behavior." + Globals.NL +
                          "Improved and fixed copy, cut and paste for both Hebrew font chars and unicode." + Globals.NL +
                          "Analysis labels are clickable to switch to letter's details." + Globals.NL +
                          "Added New in version in the Information menu." + Globals.NL +
                          "Added link to online Shorashim roots database." + Globals.NL +
                          "New top menu icon to open a new window." + Globals.NL +
                          "New context menu on letters' buttons." + Globals.NL +
                          "New screenshot button." + Globals.NL +
                          "New usage statistics window." + Globals.NL +
                          "Rework of the preferences window design with more options." + Globals.NL +
                          "Some improvements in appearance and function." + Globals.NL +
                          "Incorporate common code written since more than one year for Hebrew Calendar." + Globals.NL +
                          "Modification and addition of web links and online providers for the study of words and verses of the Bible." + Globals.NL +
                          "Web links updated.",

          [Language.FR] = "Ajout d'options de ligne de commande (voir la FAQ de l'aide)." + Globals.NL +
                          "Le temps de démarrage et la création des boites combos d'analyse sont optimisé." + Globals.NL +
                          "L'édition des données est possible seulement par une seule instance à la fois." + Globals.NL +
                          "L'édition des données est améliorée pour avoir le comportement sauver et annuler." + Globals.NL +
                          "Amélioration et correction du copier, couper et coller pour les caractères de police hébreu et unicode." + Globals.NL +
                          "Les labels d'analyse sont cliquables pour basculer vers les détails de la lettre." + Globals.NL +
                          "Ajout des Nouveautés de version dans le menu Information." + Globals.NL +
                          "Ajout d'un lien vers une base de données en ligne de racines Shorashim." + Globals.NL +
                          "Nouvelle icône de menu principal pour ouvrir une nouvelle fenêtre." + Globals.NL +
                          "Nouveau menu contextuel pour les boutons des lettres." + Globals.NL +
                          "Nouveau bouton de capture d'écran." + Globals.NL +
                          "Nouvelle fenêtre de statistiques d'utilisation." + Globals.NL +
                          "Refonte de la fenêtre des préférences avec ajout d'options." + Globals.NL +
                          "Quelques améliorations d'aspect et de fonctionnement." + Globals.NL +
                          "Incorporation du code commun écrit depuis plus d'un an pour Hebrew Calendar." + Globals.NL +
                          "Modification et ajouts de liens web et de fournisseurs en ligne pour l'étude des mots et des versets de la Bible." + Globals.NL +
                          "Mise à jour des liens web."
        },

        ["4.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Added lettriq analysis method notice." + Globals.NL +
                          "Added grammar guide." + Globals.NL +
                          "Added web links menu." + Globals.NL +
                          "Added some preferences options." + Globals.NL +
                          "Added debugger and logger." + Globals.NL +
                          "General immprovements and some fixes.",

          [Language.FR] = "Ajout d'une notice de méthode d'analyse lettrique." + Globals.NL +
                          "Ajout d'un guide de grammaire." + Globals.NL +
                          "Ajout d'un menu de liens Web." + Globals.NL +
                          "Ajout de quelques options de préférences." + Globals.NL +
                          "Ajout d'un débogueur et d'un logguer" + Globals.NL +
                          "Améliorations générales et quelques corrections."
        },

        ["3.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Added search term button." + Globals.NL +
                          "Added copy to and paste from unicode chars buttons." + Globals.NL +
                          "Added online search button for several providers like Pealim and Wiktionary." + Globals.NL +
                          "Added some preferences options." + Globals.NL +
                          "Use advanced TextBox to allow copy, cut, paste, select all and delete." + Globals.NL +
                          "General immprovements and some fixes.",

          [Language.FR] = "Ajout d'un bouton de recherche de terme." + Globals.NL +
                          "Ajout de boutons pour copier et coller à partir de caractères Unicode." + Globals.NL +
                          "Ajout d'un bouton de recherche en ligne pour plusieurs fournisseurs comme Pealim et Wiktionary." + Globals.NL +
                          "Ajout de quelques options de préférences." + Globals.NL +
                          "Utilisation d'un TextBox avancé pour permettre de copier, couper, coller, tout sélectionner et supprimer." + Globals.NL +
                          "Améliorations générales et quelques corrections."
        },

        ["2.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Added copy list of meanings for current word." + Globals.NL +
                          "Improved meanings." + Globals.NL +
                          "Improved interface." + Globals.NL +
                          "Improved preferences.",

          [Language.FR] = "Ajout de la copie de la liste des significations du mot actuel." + Globals.NL +
                          "Significations améliorées." + Globals.NL +
                          "Interface améliorée." + Globals.NL +
                          "Préférences améliorées."
        },

        ["1.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Initial release with basic combo boxes.",

          [Language.FR] = "Version initiale avec boites combos de base."
        },

      };

  }

}
