using System;
using TMPro;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public GameObject go;
    public NotificationScript noti;
    public void SwitchTab()
    {
        go.SetActive(!go.activeSelf);
    }
    public void Roll(int x)
    {
        var rnd = new System.Random();
        int result = rnd.Next(1, x);
        SwitchTab();
    }
}
