using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lineage", menuName = "ScriptableObjects/CO/Lineage")]
public class Lineage:ScriptableObject
{
    public string lineName;
    public string size;
    public string clade;
    public byte vitDiceQuantity;
    public byte vitDice;
    public byte staminaBase;
    public byte sanityBase;
    public sbyte bodyBonus;
    public sbyte graceBonus;
    public sbyte mindBonus;
    public sbyte soulBonus;
    public sbyte tradeBonus;
    public sbyte personalityBonus;
    public Speed speed;
    public string senses;
    public string sizeSpan;
    public string lifeSpan;
    public SkillBonus skillBonus;
    public List<Feature> features;
    public Lineage(string nm, string size, string clade, byte vitDiceQuantity, byte vitDice, byte staminaBase, byte sanityBase, sbyte bodyBonus, sbyte graceBonus, sbyte mindBonus, sbyte soulBonus, sbyte tradeBonus, sbyte personalityBonus, Speed speed, string senses, string sizeSpan, string lifeSpan, SkillBonus skillBonus, List<Feature> features)
    {
        this.lineName = nm;
        this.size = size;
        this.clade = clade;
        this.vitDiceQuantity = vitDiceQuantity;
        this.vitDice = vitDice;
        this.staminaBase = staminaBase;
        this.sanityBase = sanityBase;
        this.bodyBonus = bodyBonus;
        this.graceBonus = graceBonus;
        this.mindBonus = mindBonus;
        this.soulBonus = soulBonus;
        this.tradeBonus = tradeBonus;
        this.personalityBonus = personalityBonus;
        this.speed = speed;
        this.senses = senses;
        this.sizeSpan = sizeSpan;
        this.lifeSpan = lifeSpan;
        this.skillBonus = skillBonus;
        this.features = features;
    }
}