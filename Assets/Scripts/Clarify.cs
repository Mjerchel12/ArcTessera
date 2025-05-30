using UnityEngine;

public class Clarify : MonoBehaviour
{
    public GameObject clar;
    void OnMouseEnter()
    {
        clar.SetActive(true);
    }

    void OnMouseExit()
    {
        clar.SetActive(false);
    }
}
