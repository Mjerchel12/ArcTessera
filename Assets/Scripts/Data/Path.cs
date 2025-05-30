using NUnit.Framework;
using System.Collections.Generic;

internal class Path
{
    internal string pathName;
    internal Path required;
    internal List<string> expertise;
    internal List<Item> equipment;
    internal Feature initFeature;
    internal List<Feature> features;

    internal class ItemChoice:Item
    {
        internal List<Item> choices;
    }
    public Path()
    {
    }
}