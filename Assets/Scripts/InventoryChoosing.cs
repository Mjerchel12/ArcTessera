using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryChoosing : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefabUp;
    public GameObject prefabItem;
    public GameObject prefabOption;
    public GameObject content;
    public List<GameObject> spawnedGuys;
    public Repository repo;
    public CharacterBar cb;
    public TextMeshProUGUI labelPlace;
    public TextMeshProUGUI descPlace;

    public void Spawn()
    {
        foreach (GameObject go in spawnedGuys)
        {
            GameObject.Destroy(go);
        }

        //foreach (string m in cb.character.paths[0].equipment)
        //{
        //    List<List<Item>> decoded = repo.Decode(m);
        //    Debug.Log("wesz這 w foreach");
        //    var guy = Instantiate(prefabUp, content.transform);
        //    var guyChar = guy.GetComponent<OrItemScript>();
        //    foreach (List<Item> litem in decoded) {
        //        Debug.Log("wesz這 w drugi foreach");
        //        var guy2 = Instantiate(prefab, content.transform);
        //        var guy2Char = guy2.GetComponent<AndItemScript>();
        //        foreach (Item item in litem)
        //        {
        //            Debug.Log("wesz這 w trzeci foreach");
        //            var guy3 = Instantiate(prefabItem, content.transform);
        //            var guy3Char = guy2.GetComponent<ItemScript>();
        //        }
        //    }
        //    //if (cb.character.maneuvers.Contains(m))
        //    //{
        //    //    guyChar.isTaken = true;
        //    //}
        //    //if (guyChar.isTaken || spellCount.text == talent.text)
        //    //{
        //    //    Debug.Log("Green grey");
        //    //    guyChar.greenButton.interactable = false;
        //    //}
        //    //else
        //    //{
        //    //    Debug.Log("Green else");
        //    //    guyChar.greenButton.interactable = true;
        //    //}
        //    //if (!guyChar.isTaken)
        //    //{
        //    //    Debug.Log("Red grey");
        //    //    guyChar.redButton.interactable = false;
        //    //}
        //    //else
        //    //{
        //    //    Debug.Log("Red else");
        //    //    guyChar.redButton.interactable = true;
        //    //}
        //    //guyChar.spellName.text = m.manName;
        //    //if (m.types.Contains("Simple"))
        //    //{
        //    //    guyChar.spellLevel.text = "I";
        //    //}
        //    //if (m.types.Contains("Greater"))
        //    //{
        //    //    guyChar.spellLevel.text = "II";
        //    //}
        //    //if (m.types.Contains("Master"))
        //    //{
        //    //    guyChar.spellLevel.text = "III";
        //    //}
        //    //if (guyChar.isTaken)
        //    //{
        //    //    guyChar.taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
        //    //}
        //    //else
        //    //{
        //    //    guyChar.taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        //    //}
        //    //guyChar.type.SetActive(false);
        //    //guyChar.man = m;
        //    spawnedGuys.Add(guy);
        //}
        Debug.Log("jeszcze nie foreach");
        foreach (string m in repo.cultures.First(item => item == cb.character.culture).equipment)
        {
            List<List<List<Item>>> decoded = repo.Decode(m);
            Debug.Log("wesz這 w foreach");
            Debug.Log(decoded);
            Debug.Log(decoded.Count);
            var guy = Instantiate(prefabUp, content.transform);
            var guyChar = guy.GetComponent<OrItemScript>();
            foreach (List<List<Item>> litem in decoded)
            {
                Debug.Log("wesz這 w drugi foreach");
                var guy2 = Instantiate(prefab, guyChar.content.transform);
                var guy2Char = guy2.GetComponent<AndItemScript>();
                guy2Char.up = guy;
                guyChar.lists.Add(guy2);
                foreach (List<Item> item in litem)
                {
                    Debug.Log("wesz這 w trzeci foreach");
                    if (item.Count == 1) {
                        var guy3 = Instantiate(prefabItem, guy2Char.content.transform);
                        var guy3Char = guy3.GetComponent<ItemScript>();
                        guy3Char.itemHere = item[0];
                        guy3Char.itemTaken.text = item[0].quantity.ToString();
                        guy3Char.itemMax.text = "/" + item[0].quantity.ToString();
                        guy3Char.up = guy2Char;
                        guy2Char.lists.Add(guy3);
                    }
                    else
                    {
                        var guy3 = Instantiate(prefabOption, guy2Char.content.transform);
                        var guy3Char = guy3.GetComponent<ItemGroupScript>();
                        Debug.Log(guy3Char);
                        Debug.Log(guy3Char.drop);
                        Debug.Log(item);
                        Debug.Log(item.ToStringList());
                        guy3Char.items = item;
                        guy3Char.drop.AddOptions(item.ToStringList());
                        guy3Char.parent = guy2Char;
                        guy2Char.lists.Add(guy3);
                    }
                }
            }
            spawnedGuys.Add(guy);
        }
    }
}
