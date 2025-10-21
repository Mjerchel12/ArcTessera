using System;
using UnityEngine;
[Serializable]
public class Consumable : Item
{
    public Roll roll;
    public byte range;
    public byte maxRange;
}