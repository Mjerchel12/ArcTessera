using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemChoice", menuName = "ScriptableObjects/Item/ItemChoice")]
public class ItemChoice : Item
{
    public List<Item> choices;
}