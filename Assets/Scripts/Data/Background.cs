using static Lineage;
using System.Collections.Generic;

public class Background
{
    public string backName;
    public string desc;
    public byte bodyBonus;
    public byte graceBonus;
    public byte mindBonus;
    public byte soulBonus;
    public byte tradeBonus;
    public byte personalityBonus;
    public SkillBonus skillBonus;
    internal List<Feature> features;
    internal List<Item> equipment;
    public Background(string nm)
    {
        this.backName = nm;
    }
}