using System;
using System.Data;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellBar : MonoBehaviour
{
    public GameObject type;
    public GameObject taken;
    public Button greenButton;
    public Button redButton;
    public TextMeshProUGUI spellName;
    public TextMeshProUGUI spellLevel;
    public bool isTaken;
    public Sprite sorc;
    public Sprite bless;
    public Sprite hex;
    public Sprite div;
    public Sprite ilu;
    public Sprite con;
    public Sprite batt;
    public Sprite psi;
    public Sprite geo;
    public Sprite fire;
    public Sprite water;
    public Sprite air;
    public Sprite necro;
    public Sprite blood;
    public Sprite holy;
    public Sprite green;
    public Sprite warp;
    public Maneuver man;
    public Spell sp;
    public CharacterBar cb;
    public SpellsChoice sc;
    public void Accept()
    {
        cb = GameObject.Find("characterHolder").GetComponent<CharacterBar>();
        sc = GameObject.Find("step.4").GetComponent<SpellsChoice>();
        if (sp.manName != "")
        {
            cb.character.spells.Add(sp);
        }
        else
        {
            cb.character.maneuvers.Add(man);
        }
        int number = Int32.Parse(sc.spellCount.text) + 1;
        sc.spellCount.text = number.ToString();
        isTaken = true;
        taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
    }
    public void Remove()
    {
        cb = GameObject.Find("characterHolder").GetComponent<CharacterBar>();
        sc = GameObject.Find("step.4").GetComponent<SpellsChoice>();
        if (sp.manName != "")
        {
            cb.character.spells.Remove(cb.character.spells.First(item => item.manName == sp.manName));
        }
        else
        {
            cb.character.maneuvers.Remove(cb.character.maneuvers.First(item => item.manName == man.manName));
        }
        int number = Int32.Parse(sc.spellCount.text) - 1;
        sc.spellCount.text = number.ToString();
        isTaken = false;
        taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }
    public void Show()
    {
        sc = GameObject.Find("step.4").GetComponent<SpellsChoice>();
        Debug.Log("Show1");
        sc.Show(man, sp);
    }
}
