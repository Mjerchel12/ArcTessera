using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Att", menuName = "ScriptableObjects/Characters/Att")]
public class Attributes:ScriptableObject
{
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
}