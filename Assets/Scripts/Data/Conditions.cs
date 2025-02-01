using System.Collections.Generic;

public class Conditions
{
    internal byte exhaustion;
    internal byte toxin;
    internal byte curse;
    internal List<string> conditions;
    internal List<DamageType> resistances;
    internal List<DamageType> immunities;
    internal List<DamageType> vulnerabilities;
}