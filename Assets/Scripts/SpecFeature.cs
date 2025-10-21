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

    public void Choose()
    {
        var creator = GameObject.Find("CharCreator").GetComponent<CharCreator>();
        creator.ChooseSpec(drop.options[drop.value].text, l.First(item => item.featName == drop.options[drop.value].text).desc, src, label.text);
    }
}
