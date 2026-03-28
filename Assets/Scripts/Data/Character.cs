using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class Character{

    [Header("Character Options")]
    public Lineage lineage;
    public Culture culture;
    public Background background;
    public StarSign starsign;
    public Element element;
    public byte level;
    public byte takenPerks;
    public string desc;
    public List<Feature> features = new List<Feature>();
    public List<Path> paths = new List<Path>();
    public List<Spell> spells = new List<Spell>();
    public List<Maneuver> maneuvers = new List<Maneuver>();
    public List<LegFeature> legFeatures = new List<LegFeature>();
    public byte talent;

    [Header("Attributes")]
    public Stat body;
    public Skill athletics;
    public Skill strength;
    public Skill vigor;
    public Skill resistance;
    public Skill endurance;
    public Skill fortitude;
    public Skill melee;
    public Skill throwing;

    public Stat grace;
    public Skill acrobatics;
    public Skill marksmanship;
    public Skill stealth;
    public Skill dexterity;
    public Skill martial;
    public Skill fencing;
    public Skill react;
    public Skill riding;

    public Stat mind;
    public Skill arcana;
    public Skill nature;
    public Skill religion;
    public Skill survival;
    public Skill lore;
    public Skill investigation;
    public Skill tactics;

    public Stat soul;
    public Skill willpower;
    public Skill intuition;
    public Skill alertness;
    public Skill spellcraft;
    public Skill fervor;

    public Stat trade;
    public Skill medicine;
    public Skill alchemy;
    public Skill forgery;
    public Skill craft;
    public Skill burglary;
    public Skill tinkering;
    public Skill performance;

    public Stat personality;
    public Skill courtship;
    public Skill manipulation;
    public Skill persuasion;
    public Skill business;
    public Skill intimidation;

    [Header("Statistic")]
    public Stat vitality;
    public Stat mana;
    public byte wounds;
    public byte AP;
    public byte reactions;
    public byte speedBonus;
    public Stat stamina;
    public Stat sanity;
    public Speed speed;
    public Stat determination;

    [Header("Conditions")]
    public byte exhaustion;
    public byte toxin;
    public byte curse;
    public List<string> conditions = new List<string>();
    public List<string> resistances = new List<string>();
    public List<string> immunities = new List<string>();
    public List<string> vulnerabilities = new List<string>();

    [Header("Combat")]
    public string currentStance;
    public List<string> knownStances = new List<string>();
    public string leftHand;
    public string rightHand;
    public string wornArmor;

    [Header("Equipment")]
    public List<Weapon> weaponry = new List<Weapon>();
    public List<Armor> armory = new List<Armor>();
    public List<Consumable> consumables = new List<Consumable>();
    public List<Focus> focuses = new List<Focus>();
    public List<Item> otherItems = new List<Item>();

    [Header("Journal")]
    public string charName;
    public byte age;
    public string genderIdentity;
    public string ethnicity;
    public string nationality;
    public string faith;
    public string appearance;
    public string homeTown;
    public string backstory;

    public string flaws;
    public string charTraits;
    public string bonds;
    public string goals;

    public string notes;
}