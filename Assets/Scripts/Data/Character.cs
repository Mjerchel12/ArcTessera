using UnityEngine;

public class Character : MonoBehaviour{
    internal MainMenu mm;

    [Header("Character Options")]
    internal CharacterOptions co;

    [Header("Attributes")]
    internal Attributes att;

    [Header("Statistic")]
    internal Statistics stats;

    [Header("Conditions")]
    internal Conditions cons;

    [Header("Combat")]
    internal Combat cmb;

    [Header("Equipment")]
    internal Equipment eq;

    [Header("Journal")]
    internal Journal jo;

    public void ChooseChar()
    {
        mm = GameObject.Find("Canvas").GetComponent<MainMenu>();
        mm.ShowSheet(this);
    }
}