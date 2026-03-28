using System;
using TMPro;
using UnityEngine;
using System.Linq;
public class ItemScript : MonoBehaviour
{
    public Item itemHere;
    public TextMeshProUGUI itemZone;
    public TextMeshProUGUI itemTaken;
    public TextMeshProUGUI itemMax;
    public GameObject itemIcon;
    public AndItemScript up;

    public void Add()
    {
        Debug.Log("Trying to add item: " + itemHere.itemName);
        Debug.Log(Int32.Parse(itemTaken.text));
        Debug.Log(Int32.Parse(itemMax.text.Substring(1)));
        Debug.Log(Int32.Parse(itemTaken.text) < Int32.Parse(itemMax.text.Substring(1)));
        if (Int32.Parse(itemTaken.text)< Int32.Parse(itemMax.text.Substring(1)))
        {
            Debug.Log("Ifing to add item: " + itemHere.itemName);
            int temp = Int32.Parse(itemTaken.text) + 1;
            itemTaken.text = temp.ToString();
            itemHere.quantity += 1;
            if(itemHere is Weapon)
            {
                Debug.Log("It's a weapon");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.weaponry
                    .Find(item => item.itemName == itemHere.itemName).quantity+=1;
            }
            else if (itemHere is Armor)
            {
                Debug.Log("It's an armor");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.armory
                    .Find(item => item.itemName == itemHere.itemName).quantity += 1;
            }
            else if (itemHere is Consumable)
            {
                Debug.Log("It's a consumable");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.consumables
                    .Find(item => item.itemName == itemHere.itemName).quantity += 1;
            }
            else if (itemHere is Focus)
            {
                Debug.Log("It's a focus");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.focuses
                    .Find(item => item.itemName == itemHere.itemName).quantity += 1;
            }
            else
            {
                Debug.Log("It's a thingy");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.otherItems
                    .Find(item => item.itemName == itemHere.itemName).quantity += 1;
            }
        }
    }
    public void Remove()
    {
        if (Int32.Parse(itemTaken.text) > 0)
        {
            int temp = Int32.Parse(itemTaken.text) - 1;
            itemTaken.text = temp.ToString();
            itemHere.quantity -= 1;
            if (itemHere is Weapon)
            {
                Debug.Log("It's a weapon");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.weaponry
                    .Find(item => item.itemName == itemHere.itemName).quantity -= 1;
            }
            else if (itemHere is Armor)
            {
                Debug.Log("It's an armor");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.armory
                    .Find(item => item.itemName == itemHere.itemName).quantity -= 1;
            }
            else if (itemHere is Consumable)
            {
                Debug.Log("It's a consumable");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.consumables
                    .Find(item => item.itemName == itemHere.itemName).quantity -= 1;
            }
            else if (itemHere is Focus)
            {
                Debug.Log("It's a focus");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.focuses
                    .Find(item => item.itemName == itemHere.itemName).quantity -= 1;
            }
            else
            {
                Debug.Log("It's a thingy");
                GameObject.Find("characterHolder").GetComponent<CharacterBar>().character.otherItems
                    .Find(item => item.itemName == itemHere.itemName).quantity -= 1;
            }
        }
    }
    public void Show()
    {
        var ic = GameObject.Find("step.3").GetComponent<InventoryChoosing>();
        ic.labelPlace.text = itemHere.itemName;
        ic.descPlace.text = itemHere.desc;
    }
}