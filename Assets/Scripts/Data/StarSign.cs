using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
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
    public List<Feature> features;
    public StarSign(string nm)
    {
        this.signName = nm;
    }
    public override string ToString()
    {
        return signName;
    }
}