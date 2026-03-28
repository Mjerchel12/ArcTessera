using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpecFeature : MonoBehaviour
{
    public string src;
    public TextMeshProUGUI label;
    public TMP_Dropdown drop;
    public List<Feature> l;
    public bool isNone = true;

    public void Choose()
    {
        var creator = GameObject.Find("CharCreator").GetComponent<CharCreator>();
        Debug.Log("czóz");
        if (drop.options[drop.value].text != "None")
        {
            Debug.Log("iw");
            Debug.Log(drop.options[drop.value].text);
            isNone = false;
            creator.ChooseSpec(drop.options[drop.value].text, l.First(item => item.featName == drop.options[drop.value].text).desc, src, label.text);
        }
        else
        {
            Debug.Log("elz");
            Debug.Log(drop.options[drop.value].text);
            isNone = true;
            creator.ChooseSpec("None", "None", src, label.text);
        }
        //l.Remove(l[0]);
        //drop.options.RemoveAt(0);
    }
}
