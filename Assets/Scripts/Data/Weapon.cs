using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Weapon : Item{
    public char BDscaling;
    public char GRscaling;
    public char MIscaling;
    public char SLscaling;
    public Roll attackOne;
    public Roll attackTwo;
    public byte stCost;
    public byte apCost;
    public byte range;
    public byte maxRange;
    public string skill;
    public string size;
    public List<string> traits;
    public bool balanced;
    public bool ranged;
    public bool thrown;
    public bool shield;

    public string material;
    public string style;

    public string ammo;
}