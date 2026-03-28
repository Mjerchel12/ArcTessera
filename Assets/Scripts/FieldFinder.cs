using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class FieldFinder
{
    public static object FindField(object obj, string fieldName)
    {
        Type type = obj.GetType();

        FieldInfo field = type.GetField(fieldName);

        if (field != null)
        {
            object value = field.GetValue(obj);
            Debug.Log($"Zmienna '{fieldName}' = {value} (typ: {field.FieldType})");

            return value;
        }
        else
        {
            Debug.LogWarning($"Nie znaleziono zmiennej: {fieldName}");
            return null;
        }
    }
}