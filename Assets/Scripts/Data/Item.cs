using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item{
    public List<string> types = new List<string>();
    public string itemName;
    public string desc;
    public byte quantity;

    public Item Copy(byte quant)
    {
        Debug.Log("Copying item: " + itemName);
        Item copy = new Item();
        foreach (var type in types)
        {
            Debug.Log("Foreach copying item: " + itemName);
            copy.types.Add(type);
        }
        copy.itemName = itemName;
        copy.desc = desc;
        copy.quantity = quant;
        Debug.Log("Returning item: " + itemName);
        return copy;
    }
    public override string ToString()
    {
        return itemName;
    }
    public virtual string GiveDesc()
    {
        string ret="";
        foreach (var type in types)
        {
            ret += "<i>" + type + "</i>" + "/n";
        }
        return ret + desc;
    }
}