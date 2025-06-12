using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StarSign", menuName = "ScriptableObjects/CO/StarSign")]
public class StarSign:ScriptableObject
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
}