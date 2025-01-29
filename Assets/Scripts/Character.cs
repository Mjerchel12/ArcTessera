using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Character : MonoBehaviour
{
    internal CharacterOptions options;

    [Header("Attributes")]
    internal Stat body;
    internal Skill athletics;
    internal Skill strength;
    internal Skill vigor;
    internal Skill resistance;
    internal Skill endurance;
    internal Skill fortitude;
    internal Skill brawl;
    internal Skill melee;
    internal Skill throwing;

    internal Stat grace;
    internal Skill acrobatics;
    internal Skill marksmanship;
    internal Skill stealth;
    internal Skill dexterity;
    internal Skill martial;
    internal Skill polearms;
    internal Skill fencing;
    internal Skill dodge;
    internal Skill riding;

    internal Stat mind;
    internal Skill arcana;
    internal Skill manipulation;
    internal Skill nature;
    internal Skill religion;
    internal Skill survival;
    internal Skill lore;
    internal Skill investigation;
    internal Skill tactics;

    internal Stat soul;
    internal Skill composure;
    internal Skill intuition;
    internal Skill alertness;
    internal Skill spellslinging;
    internal Skill blessing;
    internal Skill witchcraft;
    internal Skill premonition;

    internal Stat trade;
    internal Skill medicine;
    internal Skill alchemy;
    internal Skill forgery;
    internal Skill craft;
    internal Skill burglary;
    internal Skill tinkering;

    internal Stat personality;
    internal Skill courtship;
    internal Skill persuasion;
    internal Skill performances;
    internal Skill business;
    internal Skill intimidation;

    [Header("Statistic")]
    internal Stat vitality;
    internal Stat mana;
    internal Stat wounds;
    internal Stat AP;
    internal byte speedBonus;
    internal Stat stamina;
    internal Stat sanity;
    internal Stat walk;
    internal Stat climb;
    internal Stat swim;
    internal Stat crawl;
    internal Stat highLeap;
    internal Stat farLeap;
    internal Stat determination;

    [Header("Conditions")]
    internal byte exhaustion;
    internal byte toxin;
    internal byte curse;
    internal List<string> conditions;

    [Header("Combat")]
    internal string currentStance;
    internal Weapon leftHand;
    internal Weapon rightHand;
    internal Armor armor;

    [Header("Equipment")]
    internal List<Weapon> weaponry;
    internal List<Armor> armory;
    internal List<Consumable> consumables;
    internal List<Item> other;

    [Header("Journal")]
    internal string charName;
    internal string surname;
    internal byte age;
    internal string nationality;
    internal string faith;
    internal string appearance;
    internal string homeTown;
    internal string backstory;

    internal List<string> flaws;
    internal List<string> charTraits;
    internal List<string> bonds;
    internal List<string> goals;

    internal List<string> notes;
}