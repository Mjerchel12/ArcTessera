using UnityEngine;

[CreateAssetMenu(fileName = "Maneuver", menuName = "ScriptableObjects/Features/Maneuver")]
public class Maneuver:ScriptableObject
{
    public string manName;
    public string types;
    public byte APCost;
    public bool isReaction;
    public byte staminaCost;
    public string desc;
    public Roll rollHit;
}