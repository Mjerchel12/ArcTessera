using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "Repo", menuName = "ScriptableObjects/Repo")]
public class Repository : ScriptableObject{
    public List<Character> allCharacters = new List<Character>();
    private void Awake()
    {
        Debug.Log("wesz³o w awake");
        allCharacters.Add(new Character());
        allCharacters.Add(new Character());
    }
}