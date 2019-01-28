/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
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
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewLetters
{

  /// <summary>
  /// Provide hebrew letters default values.
  /// </summary>
  static public class Letters
  {

    /// <summary>
    /// Provide letter meaning translation
    /// </summary>
    public class MeaningTranslation : Dictionary<string, List<string>>
    {
    }

    /// <summary>
    /// Indicate letters keyboard codes.
    /// </summary>
    static public readonly string[] Codes = 
    {
      "a", "b", "g", "d", "h", "v", "z", "x", "u", "y", "k",
      "l", "m", "n", "c", "i", "p", "j", "q", "r", ">", "t"
    };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesSimple = 
    {
      1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20,
      30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400
    };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesFull = 
    {
      111, 412, 83, 434, 6, 12, 67, 418, 419, 20, 100,
      74, 90, 106, 120, 130, 81, 104, 186, 510, 360, 406
    };

    /// <summary>
    /// Indicate letters names.
    /// </summary>
    static public readonly string[] Names = 
    {
      "Alef", "Bet", "Gimel", "Dalet", "Hé", "Vav", "Zayin", "Het", "Tet", "Youd", "Kaf",
      "Lamed", "Mem", "Noun", "Samech", "Ayin", "Pé", "Tsadé", "Qof", "Resh", "Shin", "Tav"
    };

    /// <summary>
    /// Indicates letters structures definitions.
    /// </summary>
    static public readonly Dictionary<string, string[]> Structures = new Dictionary<string, string[]>()
    {
      { "en", new string[] { "Bull", "House", "Camel", "Column", "Praise", "Nail", "Weapon", "Creature", "Shield", "Hand", "Palm", "Stick", "Waters", "Fish", "Support", "Eye", "Mouth", "Hook", "Neck", "Head ", "Tooth", "Cross" } },
      { "fr", new string[] { "Taureau", "Maison", "Chameau", "Colonne", "Louange", "Clou", "Arme", "Créature", "Bouclier", "Main", "Paume", "Bâton", "Eaux", "Poisson", "Appui", "Oeil", "Bouche", "Hameçon", "Nuque", "Tête", "Dent", "Croix" } }
    };

    /// <summary>
    /// Indicates letters functions definitions.
    /// </summary>
    static public readonly Dictionary<string, string[]> Functions = new Dictionary<string, string[]>()
    {
      { "en", new string[] { "Master", "Passage", "Travel", "Student", "Joy", "Communication", "Food", "Vitality", "Beauty", "Love", "Fun", "Education", "Duality", "Power", "Perfecting", "Taming", "Resurrection", "Wings", "Wisdom", "Maturity", "Discretion", "Offering" } },
      { "fr", new string[] { "Maître", "Passage", "Voyage", "Étudiant", "Joie", "Communication", "Nourriture", "Vitalité", "Beauté", "Amour", "Amusement", "Éducation", "Dualité", "Pouvoir", "Perfectionnement", "Apprivoisement", "Résurrection", "Ailes", "Sagesse", "Maturité", "Discrétion", "Offrande" } }
    };

    /// <summary>
    /// Indicates letters functions definitions.
    /// </summary>
    static public readonly Dictionary<string, string[]> Verbs = new Dictionary<string, string[]>()
    {
      { "en", new string[] { "Plan", "Arrange", "Eloborate", "Emit", "Note", "Speak", "Persevere", "Grant", "Assemble", "Exist", "Spread", "Give", "Contribute", "Lead", "Gather", "Interact", "Protect", "Help", "Free", "Show", "Share", "Support" } },
      { "fr", new string[] { "Planifier", "Disposer", "Éloborer", "Émettre", "Constater", "Parler", "Persévérer", "Accorder", "Assembler", "Exister", "Répandre", "Donner", "Contribuer", "Diriger", "Rassembler", "Interagir", "Protéger", "Aider", "Libérer", "Montrer", "Partager", "Soutenir" } }
    };

    /// <summary>
    /// Indicates letters meanings definitions.
    /// </summary>
    static public readonly List<MeaningTranslation> Meanings = new List<MeaningTranslation>
    {
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Source", "Original principle", "Mirror", "Potential", "Space", "Distance", "Balance", "Silence", "Adam and Eve" } },
        { "fr", new List<string>() { "Source", "Principe originel", "Miroir", "Potentiel", "Espace", "Distance", "Équilibre", "Silence", "Adam et Ève" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Flame Bearer", "House", "Home", "Solitude", "Instruction", "Will" } },
        { "fr", new List<string>() { "Porteur de la flamme", "Demeure", "Foyer", "Solitude", "Instruction", "Volonté" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Bearer on the Move", "Energy in motion", "Time", "Shepherd", "Testimony", "History", "Investment", "Liberation" } },
        { "fr", new List<string>() { "Porteur en marche", "Énergie en mouvement", "Temps", "Berger", "Témoignage", "Histoire", "Investissement", "Libération" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Threshold", "Sanctuary", "Reception", "Door", "Humility", "Unfolding", "Wandering", "Weakness", "Imbalance", "Poverty" } },
        { "fr", new List<string>() { "Seuil", "Sanctuaire", "Accueil", "Porte", "Humilité", "Déroulement", "Errance", "Faiblesse", "Déséquilibre", "Pauvreté" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Breath", "Breathing", "Meeting", "Presentation", "Astonishment", "Celebration" } },
        { "fr", new List<string>() { "Souffle", "Respiration", "Rencontre", "Présentation", "Étonnement", "Festivité" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Ray of light", "Mediation", "Righteousness", "Cap", "Direction", "Expression", "Fusion", "Child (girl)" } },
        { "fr", new List<string>() { "Rayon de lumière", "Médiation", "Droiture", "Cap", "Direction", "Expression", "Fusion", "Enfant (fille)" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Balance", "Logic", "Discernment", "Sentiment", "Determination", "Action", "Success", "Revolt", "Child (son)" } },
        { "fr", new List<string>() { "Équilibre", "Logique", "Discernement", "Sentiment", "Détermination", "Action", "Réussite", "Révolte", "Enfant (fils)" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Expression", "Support", "Protection", "Start", "Commitment", "Motivation", "Loyalty", "Incorruptibility", "Duality" } },
        { "fr", new List<string>() { "Expression", "Soutien", "Protection", "Début", "Engagement", "Motivation", "Fidélité", "Incorruptibilité", "Dualité" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Refuge", "Journey", "Innerity", "Wisdom", "Power", "Eternity" } },
        { "fr", new List<string>() { "Refuge", "Voyage", "Intériorité", "Sagesse", "Puissance", "Éternité" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Sprout", "Energy", "Flame", "Spiritual Core", "Impulse", "Peace", "Blessing", "Freedom", "Structure", "Purity", "Giving", "Spermatozoa", "Adam XY, Eve XX" } },
        { "fr", new List<string>() { "Germe", "Énergie", "Flamme", "Noyau spirituel", "Impulsion", "Paix", "Bénédiction", "Liberté", "Structure", "Pureté", "Donner", "Spermatozoïde", "Adam XY, Ève XX" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Internal impuls", "Awakening", "Curvature", "Exchange", "Strength", "Power" } },
        { "fr", new List<string>() { "Élan intérieur", "Éveil", "Courbure", "Échange", "Force", "Puissance" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Elevation", "Transmission", "Look", "Observation", "Orientation", "Existence", "Experience", "Invention", "Passive becomes active" } },
        { "fr", new List<string>() { "Élévation", "Transmission", "Regard", "Observation", "Orientation", "Existence", "Expérience", "Invention", "Passif devient actif" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Formation", "Transformation", "Maturation", "Salutation", "Prayer", "Service", "Recognition", "Unconscious" } },
        { "fr", new List<string>() { "Formation", "Transformation", "Maturation", "Salutation", "Prière", "Service", "Reconnaissance", "Inconscient" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Life", "Fecundity", "Food", "Childhood", "Perpetuation", "Prodigy", "Intimate", "Hidden", "Fall", "Newborn" } },
        { "fr", new List<string>() { "Vie", "Fécondité", "Nourriture", "Engendrement", "Perpétuation", "Prodiges", "Intime", "Caché", "Chute", "Nouveau-né" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Instinctive impulses", "Passions", "Comfort", "Cradle", "Authority", "Support of the created", "Ossature", "Alliance", "Ovule" } },
        { "fr", new List<string>() { "Pulsions instinctives", "Passions", "Réconfort", "Berceau", "Autorité", "Support du créé", "Ossature", "Alliance", "Ovule" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Awareness", "Support of the created", "Vision", "Look", "Source", "Growth", "Help", "Illumination" } },
        { "fr", new List<string>() { "Prise de conscience", "Soutien du créé", "Vision", "Regard", "Source", "Croissance", "Aide", "Illumination" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Liberation", "Expression", "Verb", "Word", "Creation", "Assimilate", "Confidence", "Secrets", "Transgression", "Guilt", "Realization of potential", "Preparation to independence"  } },
        { "fr", new List<string>() { "Libération", "Expression", "Verbe", "Parole", "Création", "Assimiler", "Confiance", "Secrets", "Transgression", "Culpabilité", "Réalisation du potentiel", "Préparation à l'indépendance" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "External impulse", "Destiny", "Action", "Sublimation", "Accompaniment", "Support", "Start Preparation" } },
        { "fr", new List<string>() { "Élan extérieur", "Destiné", "Action", "Sublimation", "Justesse", "Appui", "Préparation départ" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Beginning of the cycle", "Departure", "Letting go", "Interrupting", "Truth", "Separating", "Discernment", "Differentiation between real and imaginary"  } },
        { "fr", new List<string>() { "Début du cycle", "Départ", "Lâcher prise", "Interrompre", "Vérité", "Séparer", "Discernement", "Différentiation entre réel et imaginaire" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Independence", "Discretion", "Intellect", "Mind", "Change", "Renewal", "Incarnation" } },
        { "fr", new List<string>() { "Indépendance", "Discrétion", "Intellect", "Mental", "Changement", "Renouveau", "Incarnation" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "Life Force", "Power", "Reflection", "Reduction", "Exceeding", "Flesh", "Friendship", "Focus", "Family" } },
        { "fr", new List<string>() { "Force vitale", "Puissance", "Réflexion", "Réduction", "Dépassement", "Chair", "Amitié", "Foyer", "Famille" } }
      },
      new MeaningTranslation()
      {
        { "en", new List<string>() { "End", "Finishing", "Perfection", "Music", "Gift", "Mystery", "Synthesis", "Material", "Substance", "Fertilization", "Union", "Fusion", "Sign"," Symbol"  } },
        { "fr", new List<string>() { "Fin", "Aboutissement", "Perfection", "Musique", "Don", "Mystère", "Synthèse", "Matière", "Substance", "Fécondation", "Union", "Fusion", "Signe", "Symbole" } }
      }
    };

  }

}