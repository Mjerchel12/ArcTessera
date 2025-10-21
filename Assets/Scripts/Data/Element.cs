using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Element
{
    public string elName;
    public string desc;
    public List<Feature> features;
    public Element(string nm)
    {
        this.elName = nm;
    }
    public override string ToString()
    {
        return elName;
    }
}