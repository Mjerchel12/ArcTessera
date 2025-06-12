using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skills/Skill")]
public class Skill : Stat, IDiceRoll{
    public bool favor;
    public bool disfavor;

    public byte Roll(){
        System.Random rnd = new System.Random();
        if (favor)
            return (byte)Mathf.Max((rnd.Next(1, 101) + current), (rnd.Next(1, 101) + current));
        else if (disfavor)
            return (byte)Mathf.Min((rnd.Next(1, 101) + current), (rnd.Next(1, 101) + current));
        else
            return (byte)(rnd.Next(1, 101) + current);
    }
}