using UnityEngine;
using System;
using TMPro;
using System.Collections;

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

    public Animator speedGroup;
    public bool speedShown=false;
    public GameObject speedArrow;

    public Animator condGroup;
    public bool condShown = false;
    public GameObject condArrow;

    public Animator equGroup;

    private Character character;

    public void ShowSheet(Character ch)
    {
        Debug.Log(ch);
        character = ch;
        nameLabel.text = ch.charName;
        descLabel.text = ch.lineage + " (" + ch.culture + ") Level " + ch.level +"\n"+ ch.desc;
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
    public void ShowSpeed()
    {
        speedArrow.transform.Rotate(new Vector3(0f, 0f, 180f));
        if (!speedShown) {
            speedGroup.SetTrigger("StartDown");
            speedShown = true;
            speedGroup.ResetTrigger("StartUp");
        }
        else
        {
            speedGroup.SetTrigger("StartUp");
            speedShown = false;
            speedGroup.ResetTrigger("StartDown");
        }
    }
    public void ShowCond()
    {
        condArrow.transform.Rotate(new Vector3(0f, 0f, 180f));
        if (!condShown)
        {
            condGroup.SetTrigger("StartDown");
            condShown = true;
            condGroup.ResetTrigger("StartUp");
        }
        else
        {
            condGroup.SetTrigger("StartUp");
            condShown = false;
            condGroup.ResetTrigger("StartDown");
        }
    }
    public void ShowEqu(int tab)
    {
        equGroup.SetInteger("anim", 1);
    }
    public void HideEqu()
    {
        equGroup.SetInteger("anim", 0);
    }
}

