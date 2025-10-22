using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[Serializable]
public class Feature
{
    public string featName;
    public string desc;
    public string descOnSheet;
    public List<string> types;
    public List<string> requiredFeatures;
    public string range;
    public byte turns;
    public byte min;
    public byte hours;
    public byte requiredLevel;
    public string uses;
    public byte spent=0;
    public Roll roll;
    public byte ApCost;
    public bool isReaction;
    public byte staminaCost;
    public List<Feature> subOptions;
    public bool showOnSheet;
    public List<string> favors;
    public List<string> disfavors;
    public List<string> resistances;
    public List<string> vulnerabilities;
    public List<string> immunities;
    public List<string> bonuses;
    public List<sbyte> bonusNumb;
    public string addedStance;
    public bool freeTrait;
    public FeatureUpgrade up;
    public bool isSub;
    public override string ToString()
    {
        return featName;
    }
}
[Serializable]
public class FeatureUpgrade
{
    public byte level;
    public Feature changes;
}