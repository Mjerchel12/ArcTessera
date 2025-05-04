using UnityEngine;
using System;
using TMPro;

public class SheetManager : MonoBehaviour
{
    public GameObject ap;
    public TextMeshProUGUI apLabel;
    public GameObject namePaper;
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI descLabel;
    public GameObject manaBar;
    public TextMeshProUGUI manaLabel;
    public GameObject redBar;
    public TextMeshProUGUI redLabel;
    public GameObject purpleBar;
    public TextMeshProUGUI purpleLabel;
    public GameObject greenBar;
    public TextMeshProUGUI greenLabel;
    public GameObject detBar;
    public TextMeshProUGUI detLabel;
    public GameObject shield;
    public TextMeshProUGUI shieldLabel;
    public GameObject wounds;
    public GameObject options;
    public TextMeshProUGUI backLabel;
    public TextMeshProUGUI signLabel;
    public TextMeshProUGUI attuLabel;
    public GameObject speeds;
    public GameObject languageBars;
    public GameObject condPoints;
    public GameObject attPaper;
    public GameObject equ;
    public GameObject buttons;
    public GameObject column;
    public GameObject greekStuff;

    public void ShowSheet(Character ch)
    {
        Debug.Log(ch);
        Debug.Log(ch.jo);
        Debug.Log(ch.jo.name);
        //nameLabel.text = ch.jo.name;
        //descLabel.text = ch.co.lineage.lineName + " (" + ch.co.culture.cultName + ") Level " + ch.co.level +"\n"+ ch.co.desc;
        //backLabel.text = ch.co.background.backName;
        //signLabel.text = ch.co.starsign.signName;
        //attuLabel.text = ch.co.element.elName;
    }
    public void RollDice(int bonus, char favor)
    {
        System.Random rnd = new System.Random();
        if(favor == 'n')
        {
            int result = rnd.Next(1,101)+bonus;
        }
        else if (favor == 'f')
        {
            int result = Math.Max(rnd.Next(1, 101) + bonus, rnd.Next(1, 101) + bonus);
        }
        else if (favor == 'd')
        {
            int result = Math.Min(rnd.Next(1, 101) + bonus, rnd.Next(1, 101) + bonus);
        }
    }
}

