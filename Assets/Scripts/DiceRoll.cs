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
        SwitchTab();
        noti.Roll(x, 0, "Basic d" + x + " roll", 'n');
    }
}
