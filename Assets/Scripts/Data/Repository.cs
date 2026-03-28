using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using JetBrains.Annotations;
using System.Linq;
using System;

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
    public List<Focus> focuses = new List<Focus>()
    {
    };
    public List<Spell> spells = new List<Spell>()
    {
    };
    public List<Maneuver> maneuvers = new List<Maneuver>()
    {
    };

    public List<List<List<Item>>> Decode(string code)
    {
        Debug.Log("Decoding: " + code);
        string[] things = code.Split('/');
        var l = new List<List<List<Item>>>();
        foreach (string s in things)
        {
            Debug.Log("Decoding thing: " + s);
            List<List<Item>> l2 = new List<List<Item>>();
            string[] things2 = s.Split('&');
            foreach (string s2 in things2)
            {
                Debug.Log("Decoding subthing: " + s2);
                byte quant = 1;
                bool isGroup = false;
                string clean;
                try
                {
                    if (char.IsDigit(s2[0]))
                    {
                        Debug.Log("Numbero");
                        quant = Convert.ToByte(s2[0].ToString());
                    }
                }
                catch { Debug.Log("No number"); }

                try
                {
                    if (s2[2] == '#')
                    {
                        Debug.Log("Grupero");
                        isGroup = true;
                    }
                }
                catch { Debug.Log("No hashtag"); }

                try
                {
                    if (s2[1] == 'w')
                    {
                        Debug.Log("Weapon");
                        if (isGroup)
                        {
                            Debug.Log("WeaponGroup");
                            clean = s2.Substring(3);
                            List<Weapon> theseWeapons = weapons.Where(item => item.types.Contains(clean)).ToList();
                            List<Item> theseItems = new List<Item>();
                            foreach (Weapon weapon in theseWeapons)
                            {
                                theseItems.Add(weapon.CopyWeapon(1));
                            }
                            l2.Add(theseItems);
                        }
                        else
                        {
                            Debug.Log("WeaponElse");
                            clean = s2.Substring(3);
                            Weapon decoded = weapons.First(item => item.itemName == clean);
                            Item decoded2 = decoded.CopyWeapon(quant);
                            l2.Add(new List<Item> { decoded2 });
                        }
                    }
                    if (s2[1] == 'a')
                    {
                        Debug.Log("Armor");
                        if (isGroup)
                        {
                            Debug.Log("ArmorGroup");
                            clean = s2.Substring(3);
                            List<Armor> theseArmors = armors.Where(item => item.types.Contains(clean)).ToList();
                            List<Item> theseItems = new List<Item>();
                            foreach (Armor armor in theseArmors)
                            {
                                theseItems.Add(armor.CopyArmor(1));
                            }
                            l2.Add(theseItems);
                        }
                        else
                        {
                            Debug.Log("ArmorElse");
                            clean = s2.Substring(3);
                            Armor decoded = armors.First(item => item.itemName == clean);
                            Item decoded2 = decoded.CopyArmor(quant);
                            l2.Add(new List<Item> { decoded2 });
                        }
                    }
                    if (s2[1] == 'c')
                    {
                        Debug.Log("Cons");
                        if (isGroup)
                        {
                            Debug.Log("ConsGr");
                            clean = s2.Substring(3);
                            List<Consumable> theseCons = consumables.Where(item => item.types.Contains(clean)).ToList();
                            List<Item> theseItems = new List<Item>();
                            foreach (Consumable con in theseCons)
                            {
                                theseItems.Add(con.CopyCons(1));
                            }
                            l2.Add(theseItems);
                        }
                        else
                        {
                            Debug.Log("ConsE");
                            clean = s2.Substring(3);
                            Consumable decoded = consumables.First(item => item.itemName == clean);
                            Item decoded2 = decoded.CopyCons(quant);
                            l2.Add(new List<Item> { decoded2 });
                        }
                    }
                    if (s2[1] == 'f')
                    {
                        Debug.Log("Focus");
                        if (isGroup)
                        {
                            Debug.Log("FocusGr");
                            clean = s2.Substring(3);
                            List<Focus> theseFocs = focuses.Where(item => item.types.Contains(clean)).ToList();
                            List<Item> theseItems = new List<Item>();
                            foreach (Focus con in theseFocs)
                            {
                                theseItems.Add(con.CopyFocus(1));
                            }
                            l2.Add(theseItems);
                        }
                        else
                        {
                            Debug.Log("FocusE");
                            clean = s2.Substring(3);
                            Focus decoded = focuses.First(item => item.itemName == clean);
                            Item decoded2 = decoded.CopyFocus(quant);
                            l2.Add(new List<Item> { decoded2 });
                        }
                    }
                    if (s2[1] == 'i')
                    {
                        Debug.Log("Itemek");
                        if (isGroup)
                        {
                            Debug.Log("ItemekGr");
                            clean = s2.Substring(3);
                            List<Item> these = items.Where(item => item.types.Contains(clean)).ToList();
                            List<Item> theseItems = new List<Item>();
                            foreach (Item con in these)
                            {
                                theseItems.Add(con.Copy(1));
                            }
                            l2.Add(theseItems);
                        }
                        else
                        {
                            Debug.Log("ItemekE");
                            clean = s2.Substring(3);
                            Debug.Log(clean);
                            Item decoded = items.First(item => item.itemName == clean);
                            Item decoded2 = decoded.Copy(quant);
                            Debug.Log(decoded);
                            l2.Add(new List<Item> { decoded2 });
                        }
                    }
                }
                catch(Exception e)
                { Debug.Log("No thingo: " + e); }
            }
            l.Add(l2);
        }
        return l;
    }
}