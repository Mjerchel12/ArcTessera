using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpecFeature : MonoBehaviour
{
    public TextMeshProUGUI source;
    public TextMeshProUGUI featName;
    public Feature feat;
    public List<Feature> features;
    public TMP_Dropdown drop;

    public void Choose()
    {
        var creator = GameObject.Find("CharCreator").GetComponent<CharCreator>();
        creator.ChooseSpec(drop);
    }
}
