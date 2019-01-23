/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2013-04 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide hebrew letters dictionary singleton.
  /// </summary>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Indicate letters keyboard codes.
    /// </summary>
    private string[] _Codes = { "a", "b", "g", "d", "h", "v", "z", "x", "u", "y", "k", "l", "m", "n", "c", "i", "p", "j", "q", "r", ">", "t" };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    private int[] _ValuesSimple = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400 };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    private int[] _ValuesFull = { 111, 412, 83, 434, 6, 12, 67, 418, 419, 20, 100, 74, 90, 106, 120, 130, 81, 104, 186, 510, 360, 406 };

    /// <summary>
    /// Indicate letters names.
    /// </summary>
    private string[] _Names = { "Alef", "Bet", "Gimel", "Dalet", "Hé", "Vav", "Zayin", "Het", "Tet", "Youd", "Kaf", "Lamed", "Mem", "Noun", "Samech", "Ayin", "Pé", "Tsadé", "Qof", "Resh", "Shin", "Tav" };

    /// <summary>
    /// Indicates letters structures definitions.
    /// </summary>
    private string[] _Structures = { "Boeuf", "Maison", "Chameau", "Colonne", "Louange", "Clou", "Arme", "Bête", "Bouclier", "Main", "Paume", "Bâton", "Eaux", "Poisson", "Appui", "Oeil", "Bouche", "Hameçon", "Nuque", "Tête", "Dent", "Croix" };

    /// <summary>
    /// Indicates letters functions definitions.
    /// </summary>
    private string[] _Functions = { "Maître", "Passage", "Voyage", "Étudiant", "Joie", "Communication", "Nourriture", "Vitalité", "Beauté", "Amour", "Amusement", "Éducation", "Dualité", "Pouvoir", "Perfectionnement", "Apprivoisement", "Résurrection", "Ailes", "Sagesse", "Maturité", "Discrétion", "Offrande" };

    /// <summary>
    /// Indicates letters meanings definitions.
    /// </summary>
    private List<string>[] _Meanings = 
    {
      new List<string>() { "Principe originel", "miroir des mondes", "création du potentiel", "espace", "silence", "Adam (yod droit) et Ève (yod gauche)" },
      new List<string>() { "Porteur de la flamme", "demeure de l'énergie", "solitaire", "volonté", "temple", "foyer", "instruction" },
      new List<string>() { "Porteur en marche", "énergie en mouvement", "force", "berger", "témoignage", "histoire", "investissement", "temps" },
      new List<string>() { "Seuil", "sanctuaire", "accueil", "porte", "observation", "humilité", "déroulement", "errance", "faiblesse", "déséquilibre", "roi", "pauvre" },
      new List<string>() { "Souffle de vie", "rencontre", "présentation", "étonnement", "festivité", "équilibre" },
      new List<string>() { "Rayon de lumière", "union esprit-matière", "unité", "fusion", "médiation", "droiture", "cap", "direction", "expression", "enfant (fille)" },
      new List<string>() { "Équilibre", "détermination", "discernement", "sentiment", "action", "réussite", "futur", "enfant (fils)" },
      new List<string>() { "Équilibre", "soutien", "protection", "début", "engagement", "motivation", "fidélité", "incorruptibilité", "dualité" },
      new List<string>() { "Refuge", "barque", "voyage", "intériorité", "foyer", "sagesse", "puissance", "immortalité" },
      new List<string>() { "Flamme-énergie (Adam Y", "Ève X)", "noyau spirituel", "impulsion", "paix", "liberté", "germe", "pureté", "spermatozoïde" },
      new List<string>() { "Élan intérieur", "éveil du potentiel", "force", "croissance", "inclinaison", "courbure", "voute", "assimilation" },
      new List<string>() { "Élévation", "transmission", "regard", "position d'observation", "passif devient actif", "existence", "expérience", "orientation" },
      new List<string>() { "Formation", "transformation", "maturation", "salutation", "prière", "service", "origine", "reconnaissance", "inconscient" },
      new List<string>() { "Vie", "fécondité", "nourriture", "engendrement", "perpétuation", "nouveau-né", "chute" },
      new List<string>() { "Pulsions instinctives", "passions", "réconfort", "berceau", "autorité", "support du créé", "alliance", "ovule" },
      new List<string>() { "Prise de conscience", "soutien du créé", "source", "illumination", "croissance" },
      new List<string>() { "Libération", "expression", "verbe", "création", "réalisation du potentiel", "préparation à l'indépendance" },
      new List<string>() { "Destiné", "action vers but", "sublimation", "justesse", "refuge", "appui", "préparation départ", "élan extérieur", "vertu intérieure" },
      new List<string>() { "Début cycle", "départ", "lâcher prise", "vérité", "illumination", "différentiation entre réel et imaginaire" },
      new List<string>() { "Indépendance", "solitude", "discrétion", "clarté du mental", "changement", "renouveau", "incarnation", "destruction/début et génération/fin" },
      new List<string>() { "Force vitale", "chair", "puissance universelle", "changement", "dépassement", "amitié", "foyer", "famille" },
      new List<string>() { "Aboutissement", "perfection", "mystère", "synthèse", "fécondation", "matière", "union", "fusion (Aboulafia : signe", "symbole)" }
    };
    
  }

}
