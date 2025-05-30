
public class Roll : IDiceRoll{
    internal byte diceQuantity;
    internal byte die;
    internal byte bonus;
    internal byte dmg;
    internal string type;

    internal byte addDmg;

    byte IDiceRoll.Roll()
    {
        throw new System.NotImplementedException();
    }
}