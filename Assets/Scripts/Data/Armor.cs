using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Armor : Item{
    public byte weight;
    public byte defense;

    public bool stealthDisFavor;

    public string material;
    public string style;

    public Armor CopyArmor(byte quant)
    {
        Armor copy = new Armor();
        foreach (var type in types)
        {
            copy.types.Add(type);
        }
        copy.itemName = itemName;
        copy.desc = desc;
        copy.quantity = quant;

        copy.weight = weight;
        copy.defense = defense;
        copy.stealthDisFavor = stealthDisFavor;
        copy.material = material;
        copy.style = style;
        return copy;
    }

    public override string GiveDesc()
    {
        string ret = "";
        foreach (var type in types)
        {
            ret += "<i>" + type;
        }
        return ret + " armor</i>" + "/n" + "<b>Defense:</b> " + defense + "/n" + "<b>Weight:</b> " + weight + "/n" + "<b>Stealth disfavor:</b> " + stealthDisFavor + "/n/n" + desc;
    }
}