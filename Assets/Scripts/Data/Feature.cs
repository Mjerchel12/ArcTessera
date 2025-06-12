using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Feature", menuName = "ScriptableObjects/Features/Feature")]
public class Feature:ScriptableObject
{
    public string featName;
    public string desc;
    public List<Feature> requiredFeatures;
    public byte? requiredLevel;
    public byte? uses;
    internal byte spent=0;
    public Roll roll;
    public byte? APcost;
    public bool isReaction;
    public byte? staminaCost;
    public List<Feature> subOptions;
    public bool showOnSheet;
    public List<string> favors;
    public List<string> disfavors;
    public List<string> resistances;
    public List<string> vulnerabilities;
    public List<string> immunities;
    public List<string> bonuses;
    public List<sbyte> bonusNumb;
}