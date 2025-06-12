using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Conds", menuName = "ScriptableObjects/Characters/Conds")]
public class Conditions:ScriptableObject
{
    public byte exhaustion;
    public byte toxin;
    public byte curse;
    public List<string> conditions;
    public List<string> resistances;
    public List<string> immunities;
    public List<string> vulnerabilities;
}