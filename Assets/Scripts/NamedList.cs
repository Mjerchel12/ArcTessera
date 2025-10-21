using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;


public static class ListExtensions
{
    public static List<string> ToStringList<T>(this List<T> l)
    {
        List<string> strings = new List<string>();
        foreach(T item in l)
        {
            strings.Add(item.ToString());
        }
        return strings;
    }
}
