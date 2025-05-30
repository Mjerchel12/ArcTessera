using System.Collections.Generic;

public class Culture
{
    public string cultName;
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
    public Culture(string nm)
    {
        this.cultName = nm;
    }
}