using UnityEngine;
[CreateAssetMenu(fileName = "Stat", menuName = "ScriptableObjects/Skills/Stat")]
public class Stat:ScriptableObject{
    public string statName;
    public string desc;
    public byte value;
    public byte bonus;
    public byte flaw;
    public byte max;
    public byte current;
}