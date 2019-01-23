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
using System.Globalization;
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
    /// Return the meanings list of a letter.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    private List<string> GetMeanings(int index)
    {
      string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      if ( !_Meanings[index].ContainsKey(lang) ) lang = "en";
      // TODO remove
      lang = "fr";
      List<string> value;
      _Meanings[index].TryGetValue(lang, out value);
      return value;
    }

    private class Dico : Dictionary<string, List<string>>
    {
    }

    /// <summary>
    /// Indicates letters meanings definitions.
    /// </summary>
    private List<Dico> _Meanings = new List<Dico>
    {
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Principe originel", "Miroir", "Potentiel", "Espace", "Distance", "Équilibre", "Silence", "Ève et Adam" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Porteur de la flamme", "Demeure", "Foyer", "Solitude", "Instruction", "Volonté" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Porteur en marche", "Energie en mouvement", "Temps", "Berger", "Témoignage", "Histoire", "Investissement", "Libération" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Seuil", "Sanctuaire", "Accueil", "Porte", "Humilité", "Déroulement", "Errance", "Faiblesse", "Déséquilibre", "Pauvreté" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Souffle de vie", "Respiration", "Rencontre", "Présentation", "Etonnement", "Festivité" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Rayon de lumière", "Médiation", "Droiture", "Cap", "Direction", "Expression", "Fusion", "Enfant (fille)" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Équilibre", "Logique", "Discernement", "Sentiment", "Détermination", "Action", "Réussite", "Révolte", "Enfant (fils)" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Expression", "Soutien", "Protection", "Début", "Engagement", "Motivation", "Fidélité", "Incorruptibilité", "Dualité" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Refuge", "Voyage", "Intériorité", "Sagesse", "Puissance", "Eternité" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Germe", "Noyau spirituel", "Impulsion", "Paix", "Bénédiction", "Liberté", "Structure", "Pureté", "Donner", "Spermatozoïde", "Flamme-énergie (Adam XY, Ève XX)" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Élan intérieur", "Éveil", "Courbure", "Échange", "Force", "Puissance" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Élévation", "Transmission", "Regard", "Observation", "Orientation", "Existence", "Expérience", "Invention", "Passif devient actif" } }
      },
      new Dico()
      {
        { "en", new List<string>() { "" } },
        { "fr", new List<string>() { "Formation", "Transformation", "Maturation", "Salutation", "Prière", "Service", "Reconnaissance", "Origine", "Inconscient" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Vie", "Fécondité", "Nourriture", "Engendrement", "Perpétuation", "Prodiges", "Intime", "Caché", "Chute", "Nouveau-né" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Pulsions instinctives", "Passions", "Réconfort", "Berceau", "Autorité", "Support du créé", "Ossature", "Alliance", "Ovule" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Prise de conscience", "Soutien du créé", "Vision", "Regard", "Source", "Croissance", "Aide", "Illumination" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Libération", "Expression", "Verbe", "Parole", "Création", "Assimiler", "Confiance", "Secrets", "Transgression", "Culpabilité", "Réalisation du potentiel", "Préparation à l'indépendance" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Destiné", "Action", "Sublimation", "Justesse", "Appui", "Préparation départ", "Élan extérieur" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Début du cycle", "Départ", "Lâcher prise", "Interrompre", "Vérité", "Séparer", "Différentiation entre réel et imaginaire" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Indépendance", "Discrétion", "Intellect", "Clarté du mental", "Changement", "Renouveau", "Incarnation", "Changement" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Force vitale", "Puissance", "Réflexion", "Réduction", "Dépassement", "Chair", "Amitié", "Foyer", "Famille" } }
      },
      new Dico()
      {
        { "en", new List<string>() { ""  } },
        { "fr", new List<string>() { "Fin", "Aboutissement", "Perfection", "Musique", "Don", "Mystère", "Synthèse", "Matière", "Substance", "Fécondation", "Union", "Fusion", "Signe", "Symbole" } }
      }
    };

  }

}