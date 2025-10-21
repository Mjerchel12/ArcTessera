using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript:MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI sectext;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI fin;
    public TextMeshProUGUI only;
    public GameObject noti;
    public Button cancel;

    public void Roll(int x, int bonus, string desc, char f)
    {
        var rnd = new System.Random();
        int result = rnd.Next(1, x + 1);
        int secRes = 0;
        int final = 0;
        if (f=='f'||f=='d') { 
            secRes = rnd.Next(1, x + 1);
        }
        if (!noti.activeSelf) {
            noti.SetActive(true);
        }
        text.text = result.ToString();
        if (bonus != 0) { 
            text.text += " + " + bonus.ToString() + " = " +result+bonus;
        }
        if (secRes != 0)
        {
            sectext.text = secRes.ToString();
            if (bonus != 0)
            {
                sectext.text += " + " + bonus.ToString() + " = " + secRes + bonus;
            }
            if (f == 'f')
            {
                final = Math.Max(result, secRes) + bonus;
            }
            else if (f == 'd')
            {
                final = Math.Min(result, secRes) + bonus;
            }
        }
        else
        {
            final = result+bonus;
        }
        if(bonus ==0 && secRes == 0)
        {
            text.text = "";
        }
        if (secRes == 0&& bonus != 0)
        {
            only.text = text.text;
            text.text = "";
        }
        fin.text = final.ToString();
        this.desc.text = desc;
    }
    public void Cancel()
    {
        noti.SetActive(false);
    }
}