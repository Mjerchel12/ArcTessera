using Unity.Engine;

public class Damage : ScriptableObject{
    internal byte baseDmg;
    internal byte bonus;
    internal byte dmg;
    internal DamageType type;

    internal Damage addDmg;
}