using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Armor : Item{
    public string weightType;
    public byte weight;
    public byte defense;

    public bool stealthFavor;

    public string material;
    public string style;
}