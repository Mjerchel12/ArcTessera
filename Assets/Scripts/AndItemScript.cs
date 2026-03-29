using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AndItemScript : MonoBehaviour
{
    public GameObject content;
    public GameObject up;
    public List<GameObject> lists;
    public Button button;
    public Repository repo;
    public bool chosen;

    public void RemoveGroup()
    {
        var upScript = up.GetComponent<OrItemScript>();
        Character ch = GameObject.Find("characterHolder").GetComponent<CharacterBar>().character;
        foreach (var list in upScript.lists)
        {
            var listScript = list.GetComponent<AndItemScript>();
            if (listScript.chosen)
            {
                foreach (var it in listScript.lists)
                {
                    try
                    {
                        var itScript = it.GetComponent<ItemGroupScript>();
                        if (itScript.chosen is Weapon)
                        {
                            ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                            if (ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                            {
                                ch.weaponry.Remove(ch.weaponry.First(item => item.itemName == itScript.chosen.itemName));
                            }
                        }
                        else if (itScript.chosen is Armor)
                        {
                            ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                            if (ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                            {
                                ch.armory.Remove(ch.armory.First(item => item.itemName == itScript.chosen.itemName));
                            }
                        }
                        else if (itScript.chosen is Consumable)
                        {
                            ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                            if (ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                            {
                                ch.consumables.Remove(ch.consumables.First(item => item.itemName == itScript.chosen.itemName));
                            }
                        }
                        else if (itScript.chosen is Focus)
                        {
                            ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                            if (ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                            {
                                ch.focuses.Remove(ch.focuses.First(item => item.itemName == itScript.chosen.itemName));
                            }
                        }
                        else
                        {
                            ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                            if (ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                            {
                                ch.otherItems.Remove(ch.otherItems.First(item => item.itemName == itScript.chosen.itemName));
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
                listScript.chosen = false;
                listScript.button.GetComponent<Image>().color = Color.white;
            }
        }
    }
    public void AddGroup()
    {
        var upScript = up.GetComponent<OrItemScript>();
        Character ch = GameObject.Find("characterHolder").GetComponent<CharacterBar>().character;
        foreach (var it in lists)
        {
            var itScript = it.GetComponent<ItemGroupScript>();
            if (itScript.chosen is Weapon)
            {
                if (!ch.weaponry.Any(item => item.itemName == itScript.chosen.itemName))
                {
                    var weap = (Weapon)itScript.chosen;
                    ch.weaponry.Add(weap.CopyWeapon(itScript.chosen.quantity));
                }
                else
                {
                    ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                }
            }
            else if (itScript.chosen is Armor)
            {
                if (!ch.armory.Any(item => item.itemName == itScript.chosen.itemName))
                {
                    var arm = (Armor)itScript.chosen;
                    ch.armory.Add(arm.CopyArmor(itScript.chosen.quantity));
                }
                else
                {
                    ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                }
            }
            else if (itScript.chosen is Consumable)
            {
                if (!ch.consumables.Any(item => item.itemName == itScript.chosen.itemName))
                {
                    var con = (Consumable)itScript.chosen;
                    ch.consumables.Add(con.CopyCons(itScript.chosen.quantity));
                }
                else
                {
                    ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                }
            }
            else if (itScript.chosen is Focus)
            {
                if (!ch.focuses.Any(item => item.itemName == itScript.chosen.itemName))
                {
                    var foc = (Focus)itScript.chosen;
                    ch.focuses.Add(foc.CopyFocus(itScript.chosen.quantity));
                }
                else
                {
                    ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                }
            }
            else
            {
                if (!ch.otherItems.Any(item => item.itemName == itScript.chosen.itemName))
                {
                    ch.otherItems.Add(itScript.chosen.Copy(itScript.chosen.quantity));
                }
                else
                {
                    ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                }
            }
            chosen = true;
            button.GetComponent<Image>().color = new Color(0, 207, 10);
        }
    }

    public void Select()
    {
        var upScript = up.GetComponent<OrItemScript>();
        Character ch = GameObject.Find("characterHolder").GetComponent<CharacterBar>().character;
        foreach (var list in upScript.lists)
        {
            var listScript = list.GetComponent<AndItemScript>();
            if (listScript.chosen)
            {
                foreach (var it in listScript.lists)
                {
                    try
                    {
                        var itScript = it.GetComponent<ItemScript>();
                        if (itScript.itemHere is Weapon)
                        {
                            ch.weaponry.First(item => item.itemName == itScript.itemHere.itemName).quantity -= itScript.itemHere.quantity;
                            if(ch.weaponry.First(item => item.itemName == itScript.itemHere.itemName).quantity < 1)
                            {
                                ch.weaponry.Remove(ch.weaponry.First(item => item.itemName == itScript.itemHere.itemName));
                            }
                        }
                        else if (itScript.itemHere is Armor)
                        {
                            ch.armory.First(item => item.itemName == itScript.itemHere.itemName).quantity -= itScript.itemHere.quantity;
                            if (ch.armory.First(item => item.itemName == itScript.itemHere.itemName).quantity < 1)
                            {
                                ch.armory.Remove(ch.armory.First(item => item.itemName == itScript.itemHere.itemName));
                            }
                        }
                        else if (itScript.itemHere is Consumable)
                        {
                            ch.consumables.First(item => item.itemName == itScript.itemHere.itemName).quantity -= itScript.itemHere.quantity;
                            if (ch.consumables.First(item => item.itemName == itScript.itemHere.itemName).quantity < 1)
                            {
                                ch.consumables.Remove(ch.consumables.First(item => item.itemName == itScript.itemHere.itemName));
                            }
                        }
                        else if (itScript.itemHere is Focus)
                        {
                            ch.focuses.First(item => item.itemName == itScript.itemHere.itemName).quantity -= itScript.itemHere.quantity;
                            if (ch.focuses.First(item => item.itemName == itScript.itemHere.itemName).quantity < 1)
                            {
                                ch.focuses.Remove(ch.focuses.First(item => item.itemName == itScript.itemHere.itemName));
                            }
                        }
                        else
                        {
                            ch.otherItems.First(item => item.itemName == itScript.itemHere.itemName).quantity -= itScript.itemHere.quantity;
                            if (ch.otherItems.First(item => item.itemName == itScript.itemHere.itemName).quantity < 1)
                            {
                                ch.otherItems.Remove(ch.otherItems.First(item => item.itemName == itScript.itemHere.itemName));
                            }
                        }
                    }
                    catch
                    {
                        try
                        {
                            var itScript = it.GetComponent<ItemGroupScript>();
                            if (itScript.chosen is Weapon)
                            {
                                ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                                if (ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                                {
                                    ch.weaponry.Remove(ch.weaponry.First(item => item.itemName == itScript.chosen.itemName));
                                }
                            }
                            else if (itScript.chosen is Armor)
                            {
                                ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                                if (ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                                {
                                    ch.armory.Remove(ch.armory.First(item => item.itemName == itScript.chosen.itemName));
                                }
                            }
                            else if (itScript.chosen is Consumable)
                            {
                                ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                                if (ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                                {
                                    ch.consumables.Remove(ch.consumables.First(item => item.itemName == itScript.chosen.itemName));
                                }
                            }
                            else if (itScript.chosen is Focus)
                            {
                                ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;
                                if (ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                                {
                                    ch.focuses.Remove(ch.focuses.First(item => item.itemName == itScript.chosen.itemName));
                                }
                            }
                            else
                            {
                                ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity -= itScript.chosen.quantity;

                                if (ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity < 1)
                                {
                                    ch.otherItems.Remove(ch.otherItems.First(item => item.itemName == itScript.chosen.itemName));
                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                listScript.chosen = false;
                listScript.button.GetComponent<Image>().color = Color.white;
            }
        }
        foreach(var it in lists)
        {
            try
            {
                var itScript = it.GetComponent<ItemScript>();
                if (itScript.itemHere is Weapon)
                {
                    if (!ch.weaponry.Any(item => item.itemName == itScript.itemHere.itemName))
                    {
                        var weap = (Weapon)itScript.itemHere;
                        ch.weaponry.Add(weap.CopyWeapon(itScript.itemHere.quantity));
                    }
                    else
                    {
                        ch.weaponry.First(item => item.itemName == itScript.itemHere.itemName).quantity += itScript.itemHere.quantity;
                    }
                }
                else if (itScript.itemHere is Armor)
                {
                    if (!ch.armory.Any(item => item.itemName == itScript.itemHere.itemName))
                    {
                        var arm = (Armor)itScript.itemHere;
                        ch.armory.Add(arm.CopyArmor(itScript.itemHere.quantity));
                    }
                    else
                    {
                        ch.armory.First(item => item.itemName == itScript.itemHere.itemName).quantity += itScript.itemHere.quantity;
                    }
                }
                else if (itScript.itemHere is Consumable)
                {
                    if (!ch.consumables.Any(item => item.itemName == itScript.itemHere.itemName))
                    {
                        var con = (Consumable)itScript.itemHere;
                        ch.consumables.Add(con.CopyCons(itScript.itemHere.quantity));
                    }
                    else
                    {
                        ch.focuses.First(item => item.itemName == itScript.itemHere.itemName).quantity += itScript.itemHere.quantity;
                    }
                }
                else if (itScript.itemHere is Focus)
                {
                    if (!ch.focuses.Any(item => item.itemName == itScript.itemHere.itemName))
                    {
                        var foc = (Focus)itScript.itemHere;
                        ch.focuses.Add(foc.CopyFocus(itScript.itemHere.quantity));
                    }
                    else
                    {
                        ch.focuses.First(item => item.itemName == itScript.itemHere.itemName).quantity += itScript.itemHere.quantity;
                    }
                }
                else
                {
                    if (!ch.otherItems.Any(item => item.itemName == itScript.itemHere.itemName))
                    {
                        ch.otherItems.Add(itScript.itemHere.Copy(itScript.itemHere.quantity));
                    }
                    else
                    {
                        ch.otherItems.First(item => item.itemName == itScript.itemHere.itemName).quantity += itScript.itemHere.quantity;
                    }
                }
            }
            catch
            {
                var itScript = it.GetComponent<ItemGroupScript>();
                if (itScript.chosen is Weapon)
                {
                    if (!ch.weaponry.Any(item => item.itemName == itScript.chosen.itemName))
                    {
                        var weap = (Weapon)itScript.chosen;
                        ch.weaponry.Add(weap.CopyWeapon(itScript.chosen.quantity));
                    }
                    else
                    {
                        ch.weaponry.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                    }
                }
                else if (itScript.chosen is Armor)
                {
                    if (!ch.armory.Any(item => item.itemName == itScript.chosen.itemName))
                    {
                        var arm = (Armor)itScript.chosen;
                        ch.armory.Add(arm.CopyArmor(itScript.chosen.quantity));
                    }
                    else
                    {
                        ch.armory.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                    }
                }
                else if (itScript.chosen is Consumable)
                {
                    if (!ch.consumables.Any(item => item.itemName == itScript.chosen.itemName))
                    {
                        var con = (Consumable)itScript.chosen;
                        ch.consumables.Add(con.CopyCons(itScript.chosen.quantity));
                    }
                    else
                    {
                        ch.consumables.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                    }
                }
                else if (itScript.chosen is Focus)
                {
                    if (!ch.focuses.Any(item => item.itemName == itScript.chosen.itemName))
                    {
                        var foc = (Focus)itScript.chosen;
                        ch.focuses.Add(foc.CopyFocus(itScript.chosen.quantity));
                    }
                    else
                    {
                        ch.focuses.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                    }
                }
                else
                {
                    if (!ch.otherItems.Any(item => item.itemName == itScript.chosen.itemName))
                    {
                        ch.otherItems.Add(itScript.chosen.Copy(itScript.chosen.quantity));
                    }
                    else
                    {
                        ch.otherItems.First(item => item.itemName == itScript.chosen.itemName).quantity += itScript.chosen.quantity;
                    }
                }
            }
        }
        chosen = true;
        button.GetComponent<Image>().color = new Color(0, 207, 10);
    }
}
