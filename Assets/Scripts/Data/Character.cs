using UnityEngine;

public class Character : MonoBehaviour{
    internal MainMenu mm;

    [Header("Character Options")]
    internal CharacterOptions co = new CharacterOptions();

    [Header("Attributes")]
    internal Attributes att = new Attributes();

    [Header("Statistic")]
    internal Statistics stats = new Statistics();

    [Header("Conditions")]
    internal Conditions cons = new Conditions();

    [Header("Combat")]
    internal Combat cmb = new Combat();

    [Header("Equipment")]
    internal Equipment eq = new Equipment();

    [Header("Journal")]
    internal Journal jo = new Journal();

    public Character()
    {
        Debug.Log("stworzone");
    }

    public void ChooseChar()
    {
        mm = GameObject.Find("Canvas").GetComponent<MainMenu>();
        mm.ShowSheet(this);
    }
}