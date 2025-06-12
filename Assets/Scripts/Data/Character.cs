using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Characters/Character")]
public class Character : ScriptableObject{

    [Header("Character Options")]
    public CharacterOptions co;

    [Header("Attributes")]
    public Attributes att;

    [Header("Statistic")]
    public Statistics stats;

    [Header("Conditions")]
    public Conditions cons;

    [Header("Combat")]
    public Combat cmb;

    [Header("Equipment")]
    public Equipment eq;

    [Header("Journal")]
    public Journal jo;

}