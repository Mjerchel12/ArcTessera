using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
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
    public List<DescString> traits;
    public bool balanced;
    public bool ranged;
    public bool thrown;
    public bool shield;

    public string material;
    public string style;

    public string ammo;
    public Weapon CopyWeapon(byte quant)
    {
        Weapon copy = new Weapon();
        foreach (var type in types)
        {
            copy.types.Add(type);
        }
        copy.itemName = itemName;
        copy.desc = desc;
        copy.quantity = quant;

        copy.BDscaling = BDscaling;
        copy.GRscaling = GRscaling;
        copy.MIscaling = MIscaling;
        copy.SLscaling = SLscaling;
        copy.attackOne = new Roll
        {
            diceQuantity = attackOne.diceQuantity,
            die = attackOne.die,
            bonus = attackOne.bonus,
            dmg = attackOne.dmg,
            type = attackOne.type,
            addDmg = attackOne.addDmg
        };
        copy.attackTwo = new Roll
        {
            diceQuantity = attackTwo.diceQuantity,
            die = attackTwo.die,
            bonus = attackTwo.bonus,
            dmg = attackTwo.dmg,
            type = attackTwo.type,
            addDmg = attackTwo.addDmg
        };
        copy.stCost = stCost;
        copy.apCost = apCost;
        copy.range = range;
        copy.maxRange = maxRange;
        copy.skill = skill;
        copy.size = size;
        foreach (var trait in traits)
        {
            copy.traits.Add(trait);
        }
        copy.balanced = balanced;
        copy.ranged = ranged;
        copy.thrown = thrown;
        copy.shield = shield;

        copy.material = material;
        copy.style = style;

        copy.ammo = ammo;
        return copy;
    }

    public override string GiveDesc()
    {
        string ret="";
        foreach (var type in types)
        {
            ret = "<b>" + type + "</b> " + ret;
        }
        ret = ret + "<b>Base Damage </b>" + attackOne.dmg + " " + attackOne.type + "/" + attackTwo.dmg + " " + attackTwo.type +"/n"
             + "<b>Stamina Cost </b>" + stCost + "/n"
             + "<b>AP Cost </b>" + apCost + "/n"
             + "<b>Skill </b>" + skill + "/n/n"
             + "<b>Body Scaling </b>" + BDscaling + "/n"
             + "<b>Grace Scaling </b>" + GRscaling + "/n";
        foreach (var trait in traits)
        {
            ret += "<b>" + trait.nam + "</b> " + trait.desc + "/n";
        }
        ret+="/n";
        return ret + desc;
    }
}