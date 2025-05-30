using System.Collections.Generic;

internal class Feature
{
    internal string featName;
    internal string Desc;
    internal List<Feature> requiredFeatures;
    internal byte requiredLevel;
    internal byte uses;
    internal byte spent;
    internal Roll roll;
    internal byte APcost;
    internal bool isReaction;
    internal byte staminaCost;
}