using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "ScriptableObjects/Features/Spell")]
public class Spell:Maneuver
{
    public List<Spell> spellOptions;
    public byte spellForce;
}