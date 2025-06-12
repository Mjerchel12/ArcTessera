using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Item/Consumable")]
public class Consumable : Item
{
    public Roll roll;
    public byte range;
    public byte maxRange;
}