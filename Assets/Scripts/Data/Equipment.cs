using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equ", menuName = "ScriptableObjects/Characters/Equ")]
public class Equipment:ScriptableObject
{
    public List<Weapon> weaponry;
    public List<Armor> armory;
    public List<Consumable> consumables;
    public List<Item> other;
}