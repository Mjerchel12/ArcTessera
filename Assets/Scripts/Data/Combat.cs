using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Combat", menuName = "ScriptableObjects/Characters/Combat")]
public class Combat:ScriptableObject
{
    public string currentStance;
    public Weapon leftHand;
    public Weapon rightHand;
    public Armor armor;
}