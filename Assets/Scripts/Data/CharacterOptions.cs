using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CO", menuName = "ScriptableObjects/Characters/CO")]
public class CharacterOptions:ScriptableObject
{
    public Lineage lineage;
    public Culture culture;
    public Background background;
    public StarSign starsign;
    public Element element;
    public List<Trait> traits;
    public byte level;
    public string desc;
    public List<Feature> features;
    public List<Spell> spells;
    public List<Maneuver> maneuvers;
    public List<LegFeature> legFeatures;
    public byte Talent;
}