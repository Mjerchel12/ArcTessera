using UnityEngine;

[CreateAssetMenu(fileName = "Roll", menuName = "ScriptableObjects/Roll")]
public class Roll : ScriptableObject{
    public byte diceQuantity;
    public byte die;
    public byte bonus;
    public byte dmg;
    public string type;

    public byte addDmg;

    byte DiceRoll()
    {
        throw new System.NotImplementedException();
    }
}