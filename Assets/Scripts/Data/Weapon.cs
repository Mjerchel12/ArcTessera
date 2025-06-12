using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Item/Weapon")]
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
    public string type;
    public List<string> traits;
    public bool balanced;
    public bool ranged;
    public bool simple;
    public bool shield;

    public string material;
    public string style;

    public Item ammo;
}