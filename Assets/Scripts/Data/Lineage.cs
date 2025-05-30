using NUnit.Framework;
using System.Collections.Generic;

public class Lineage
{
    public string lineName;
    public string size;
    public string clade;
    public byte vitDiceQuantity;
    public byte vitDice;
    public byte staminaBase;
    public byte sanityBase;
    public byte bodyBonus;
    public byte graceBonus;
    public byte mindBonus;
    public byte soulBonus;
    public byte tradeBonus;
    public byte personalityBonus;
    public string speed;
    public string senses;
    public string sizeSpan;
    public string lifeSpan;
    public SkillBonus skillBonus;
    internal List<Feature> features;
    public Lineage(string nm)
    {
        this.lineName = nm;
    }
}
public class SkillBonus
{
}