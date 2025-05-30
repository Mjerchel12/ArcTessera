using System.Collections.Generic;

public class Element
{
    public string elName;
    public string desc;
    internal List<Feature> features;
    public Element(string nm)
    {
        this.elName = nm;
    }
}