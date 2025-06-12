using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item/Item")]
public class Item:ScriptableObject{
    public string itemName;
    public string desc;
    public byte quantity;
}