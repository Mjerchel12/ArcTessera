using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using JetBrains.Annotations;
using System.Linq;

[CreateAssetMenu(fileName = "Repo", menuName = "ScriptableObjects/Repo")]
public class Repository : ScriptableObject{
    public List<Trait> traits = new List<Trait>()
    {
    };
    public List<LegFeature> legendaries = new List<LegFeature>()
    {
    };
    public List<Character> allCharacters = new List<Character>()
    {
    };
    public List<Element> attunements = new List<Element>()
    {
    };
    public List<StarSign> signs = new List<StarSign>()
    {
    };
    public List<Background> backs = new List<Background>()
    {
    };
    public List<Culture> cultures = new List<Culture>()
    {
    };
    public List<Lineage> lineages = new List<Lineage>()
    {
    };
    public List<Path> paths = new List<Path>()
    {
    };
    public List<Item> items = new List<Item>()
    {
    };
    public List<Armor> armors = new List<Armor>()
    {
    };
    public List<Consumable> consumables = new List<Consumable>()
    {
    };
    public List<Weapon> weapons = new List<Weapon>()
    {
    };
    public List<Spell> spells = new List<Spell>()
    {
    };
    public List<Maneuver> maneuvers = new List<Maneuver>()
    {
    };

    public List<List<Item>> Decode(string code)
    {
        string[] things = code.Split('/');
        var l = new List<List<Item>>();
        foreach (string s in things)
        {
            byte quant=1;
            byte numbInd;
            bool isGroup = false;
            string clean;
            if (char.IsDigit(s[0]))
            {
                quant = (byte)s[0];
                numbInd = quant;
            }
            if (s[4] == '#')
            {
                isGroup = true;
            }
            if (s[2] == 'w')
            {
                if (isGroup) {
                    clean = s.Substring(5);
                    List<Weapon> theseWeapons = weapons.Where(item => item.types.Contains(clean)).ToList();
                    List<Item> theseItems = new List<Item>();
                    foreach (Weapon weapon in theseWeapons)
                    {
                        theseItems.Add(weapon);
                    }
                    l.Add(theseItems);
                }
                else
                {
                    clean = s.Substring(4);
                    Item decoded = weapons.First(item => item.itemName == clean);
                    l.Add(new List<Item> { decoded });
                }
            }
            if (s[2] == 'a')
            {
                if (isGroup)
                {
                    clean = s.Substring(5);
                    List<Armor> theseArmors = armors.Where(item => item.types.Contains(clean)).ToList();
                    List<Item> theseItems = new List<Item>();
                    foreach (Armor armor in theseArmors)
                    {
                        theseItems.Add(armor);
                    }
                    l.Add(theseItems);
                }
                else
                {
                    clean = s.Substring(4);
                    Item decoded = armors.First(item => item.itemName == clean);
                    l.Add(new List<Item> { decoded });
                }
            }
            if (s[2] == 'c')
            {
                if (isGroup)
                {
                    clean = s.Substring(5);
                    List<Consumable> theseCons = consumables.Where(item => item.types.Contains(clean)).ToList();
                    List<Item> theseItems = new List<Item>();
                    foreach (Consumable con in theseCons)
                    {
                        theseItems.Add(con);
                    }
                    l.Add(theseItems);
                }
                else
                {
                    clean = s.Substring(4);
                    Item decoded = consumables.First(item => item.itemName == clean);
                    l.Add(new List<Item> { decoded });
                }
            }
            if (s[2] == 'i')
            {
                if (isGroup)
                {
                    clean = s.Substring(5);
                    List<Item> these = items.Where(item => item.types.Contains(clean)).ToList();
                    l.Add(these);
                }
                else
                {
                    clean = s.Substring(4);
                    Item decoded = items.First(item => item.itemName == clean);
                    l.Add(new List<Item> { decoded });
                }
            }
        }
        return l;
    }
}