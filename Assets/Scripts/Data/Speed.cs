using UnityEngine;
[CreateAssetMenu(fileName = "Speed", menuName = "ScriptableObjects/CO/Speed")]
public class Speed:ScriptableObject
{
    public byte walk;
    public byte swim;
    public byte fly;
    public byte crawl;
    public byte highLeap;
    public byte farLeap;
}