using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
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
    public List<Feature> features;
    public string equipmentDesc;
    public List<string> equipment;
    public Culture(string nm)
    {
        this.cultName = nm;
    }
    public override string ToString()
    {
        return cultName;
    }
}