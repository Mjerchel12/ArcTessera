using System.Collections.Generic;

public class StarSign
{
    public string signName;
    public string desc;
    public byte bodyBonus;
    public byte graceBonus;
    public byte mindBonus;
    public byte soulBonus;
    public byte tradeBonus;
    public byte personalityBonus;
    internal List<Feature> features;
    public StarSign(string nm)
    {
        this.signName = nm;
    }
}