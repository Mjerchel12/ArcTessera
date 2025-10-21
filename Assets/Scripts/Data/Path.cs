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
    public List<string> expertise;
    public List<string> equipment;
    public Feature initFeature;
    public List<Feature> features;

    public byte howAdvanced;

    public Path()
    {
    }
}