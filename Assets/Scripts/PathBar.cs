using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PathBar:MonoBehaviour
{
    public Path path;
    public TextMeshProUGUI namePlace;
    public ForgeScript forge;
    public Button button;

    public void ChoosePath()
    {
        forge = GameObject.Find("PathsForgeScreen").GetComponent<ForgeScript>();
        forge.displayed = path;
        forge.scroll.transform.position = new Vector3(123f, forge.scroll.transform.position.y, forge.scroll.transform.position.z);

        forge.ShowPath(path);
    }
}