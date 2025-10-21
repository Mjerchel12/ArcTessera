using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[CreateAssetMenu(fileName = "Repo", menuName = "ScriptableObjects/Repo")]
public class Repository : ScriptableObject{
    public List<Trait> traits = new List<Trait>()
    {
    };
    public List<LegFeature> legendaries = new List<LegFeature>()
    {
    };
    public List<Character> allCharacters = new List<Character>()
    {
    };
    public List<Element> attunements = new List<Element>()
    {
    };
    public List<StarSign> signs = new List<StarSign>()
    {
    };
    public List<Background> backs = new List<Background>()
    {
    };
    public List<Culture> cultures = new List<Culture>()
    {
    };
    public List<Lineage> lineages = new List<Lineage>()
    {
    };
    public List<Path> paths = new List<Path>()
    {
    };
    public List<Item> items = new List<Item>()
    {
    };
    public List<Armor> armors = new List<Armor>()
    {
    };
    public List<Consumable> consumables = new List<Consumable>()
    {
    };
    public List<Weapon> weapons = new List<Weapon>()
    {
    };
    public List<Spell> spells = new List<Spell>()
    {
    };
    public List<Maneuver> maneuvers = new List<Maneuver>()
    {
    };
}