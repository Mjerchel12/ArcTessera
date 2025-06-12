using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Jour", menuName = "ScriptableObjects/Characters/Jour")]
public class Journal:ScriptableObject
{
    public string charName;
    public byte age;
    public string genderIdentity;
    public string nationality;
    public string faith;
    public string appearance;
    public string homeTown;
    public string backstory;

    public string flaws;
    public string charTraits;
    public string bonds;
    public string goals;

    public string notes;
}