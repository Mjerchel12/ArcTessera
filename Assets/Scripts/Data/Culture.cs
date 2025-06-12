using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Culture", menuName = "ScriptableObjects/CO/Culture")]
public class Culture:ScriptableObject
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
    public List<Item> equipment;
    public Culture(string nm)
    {
        this.cultName = nm;
    }
}