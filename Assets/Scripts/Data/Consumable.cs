using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;
[Serializable]
public class Consumable : Item
{
    public Roll roll;
    public byte range;
    public byte maxRange;

    public Consumable CopyCons(byte quant)
    {
        Consumable copy = new Consumable();
        foreach (var type in types)
        {
            copy.types.Add(type);
        }
        copy.itemName = itemName;
        copy.desc = desc;
        copy.quantity = quant;

        copy.roll = new Roll()
        {
            diceQuantity = roll.diceQuantity,
            die = roll.die,
            bonus = roll.bonus,
            dmg = roll.dmg,
            type = roll.type,
            addDmg = roll.addDmg
        };
        copy.range = range;
        copy.maxRange = maxRange;

        return copy;
    }

    public override string GiveDesc()
    {
        return desc;
    }
}