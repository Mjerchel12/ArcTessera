using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Lineage: CharOption
{
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
}