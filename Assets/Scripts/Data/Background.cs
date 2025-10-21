using static Lineage;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
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
    public List<Feature> features;
    public List<string> equipment;
    public Background(string nm)
    {
        this.backName = nm;
    }
    public override string ToString()
    {
        return backName;
    }
}