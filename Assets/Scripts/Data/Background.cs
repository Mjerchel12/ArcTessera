using static Lineage;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Background", menuName = "ScriptableObjects/CO/Background")]
public class Background:ScriptableObject
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
    public List<Item> equipment;
    public Background(string nm)
    {
        this.backName = nm;
    }
}