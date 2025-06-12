using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "ScriptableObjects/CO/Element")]
public class Element:ScriptableObject
{
    public string elName;
    public string desc;
    public List<Feature> features;
    public Element(string nm)
    {
        this.elName = nm;
    }
}