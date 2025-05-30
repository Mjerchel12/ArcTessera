using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "Repo", menuName = "ScriptableObjects/Repo")]
public class Repository : ScriptableObject{
    public List<Character> allCharacters = new List<Character>();
    public List<Element> attunements = new List<Element>()
    {
        new Element("Stormy"),
        new Element("Wild"),
        new Element("Dry")
    };
public List<StarSign> signs = new List<StarSign>()
    {
        new StarSign("Wind"),
        new StarSign("Mountain"),
        new StarSign("Candle")
    };
public List<Background> backs = new List<Background>()
    {
        new Background("Physician"),
        new Background("Acolyte"),
        new Background("Soldier")
    };
public List<Culture> cultures = new List<Culture>()
    {
        new Culture("Militaristic"),
        new Culture("Arcane"),
        new Culture("Religious")
    };
public List<Lineage> lineages = new List<Lineage>()
    {
        new Lineage("Human"),
        new Lineage("Elf"),
        new Lineage("Dwarf")
    };
}