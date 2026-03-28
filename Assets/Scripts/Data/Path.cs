using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Path
{
    public string pathName;
    public string desc;
    public string required;
    public byte reqAdv;
    public string secondRequired;
    public byte secReqAdv;
    public List<string> expertise = new List<string>();
    public string equipmentDesc;
    public List<string> equipment = new List<string>();
    public Feature initFeature;
    public List<Feature> features = new List<Feature>();
    public List<string> spellTables = new List<string>();

    public Path()
    {
    }
}