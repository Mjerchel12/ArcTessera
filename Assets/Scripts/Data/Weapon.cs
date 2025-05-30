using System.Collections.Generic;

public class Weapon : Item{
    internal char BDscaling;
    internal char GRscaling;
    internal char MIscaling;
    internal char SLscaling;
    internal Roll attackOne;
    internal Roll attackTwo;
    internal byte stCost;
    internal byte apCost;
    internal byte range;
    internal byte maxRange;
    internal string skill;
    internal string size;
    internal string type;
    internal List<string> traits;
    internal bool balanced;
    internal bool ranged;
    internal bool simple;
    internal bool shield;

    internal string material;
    internal string style;
}