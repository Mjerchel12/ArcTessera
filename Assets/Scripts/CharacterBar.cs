using UnityEngine;

public class CharacterBar : MonoBehaviour
{
    internal MainMenu mm;
    public Character character;
    public void ChooseChar()
    {
        mm = GameObject.Find("Canvas").GetComponent<MainMenu>();
        mm.ShowSheet(this);
    }
    public void RemoveChar()
    {

    }
}
