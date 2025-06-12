using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillBonus", menuName = "ScriptableObjects/CO/SkillBonus")]
public class SkillBonus : ScriptableObject
{
    public List<string> bonusName;
    public List<byte> bonusNumb;
    public byte expertise;
    public string desc;
}