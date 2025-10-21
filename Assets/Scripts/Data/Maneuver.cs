using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Maneuver
{
    public string manName;
    public List<string> types;
    public string range;
    public byte APCost;
    public bool isReaction;
    public byte staminaCost;
    public string desc;
    public Roll rollHit;
}