using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Characters/Stats")]
public class Statistics:ScriptableObject
{
    public Stat vitality;
    public Stat mana;
    public byte wounds;
    public byte AP;
    public byte Reactions;
    public byte speedBonus;
    public Stat stamina;
    public Stat sanity;
    public Speed speed;
    public Stat determination;
}