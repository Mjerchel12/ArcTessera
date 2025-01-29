using Unity.Engine;

public class Weapon : Item{
    internal char BDscaling;
    internal char GRscaling;
    internal char MIscaling;
    internal char SLscaling;
    internal Damage baseDmgOne;
    internal Damage baseDmgTwo;
    internal Damage dmg;
    internal byte stCost;
    internal byte apCost;
    internal byte range;
    internal byte maxRange;
    internal string skill;
    internal string size;
    internal string type;
    internal List<Feature> features;
    internal bool balanced;
    internal bool ranged;
    internal bool simple;
    internal bool shield;

    internal Material material;
    internal Style style;
}