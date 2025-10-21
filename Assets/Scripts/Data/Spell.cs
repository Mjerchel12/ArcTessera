using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spell:Maneuver
{
    public byte manaCost;
    public List<Spell> spellOptions;
    public string catalyst;
    public bool S;
    public bool V;
    public bool M;
    public byte turns;
    public byte min;
    public byte hours;
}