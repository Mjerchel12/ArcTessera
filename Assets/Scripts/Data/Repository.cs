using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "Repo", menuName = "ScriptableObjects/Repo")]
public class Repository : ScriptableObject{
    public List<Character> allCharacters = new List<Character>();
    public List<Element> attunements = new List<Element>();
    public List<StarSign> signs = new List<StarSign>();
    public List<Background> backs = new List<Background>();
    public List<Culture> cultures = new List<Culture>();
    public List<Lineage> lineages = new List<Lineage>();
}