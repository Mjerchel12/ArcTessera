using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "ScriptableObjects/Item/Armor")]
public class Armor : Item{
    public string weightType;
    public byte weight;
    public byte defense;

    public bool stealthFavor;

    public string material;
    public string style;
}