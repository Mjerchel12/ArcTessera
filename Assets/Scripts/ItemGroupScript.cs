using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemGroupScript : MonoBehaviour
{
    public List<Item> items;
    public TMP_Dropdown drop;
    public Item chosen;
    public Repository repo;
    public AndItemScript parent;
    private void Start()
    {
        chosen = items.First(item => item.itemName == drop.options[drop.value].text);
    }
    public void Choose()
    {
        parent.RemoveGroup();
        chosen = items.First(item => item.itemName == drop.options[drop.value].text);
        parent.AddGroup();
        var ic = GameObject.Find("step.3").GetComponent<InventoryChoosing>();
        ic.labelPlace.text = chosen.itemName;
        ic.descPlace.text = chosen.GiveDesc();
    }
}