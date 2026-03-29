using System.Collections.Generic;

public class CharOption
{
    public byte id;
    public string opName;
    public string desc;
    public List<Feature> features;

    public override string ToString()
    {
        return opName;
    }
}