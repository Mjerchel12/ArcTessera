using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Path", menuName = "ScriptableObjects/CO/Path")]
internal class Path:ScriptableObject
{
    public string pathName;
    public string desc;
    public Path required;
    public Path secondRequired;
    public List<string> expertise;
    public List<Item> equipment;
    public Feature initFeature;
    public List<Feature> features;

    public Path()
    {
    }
}