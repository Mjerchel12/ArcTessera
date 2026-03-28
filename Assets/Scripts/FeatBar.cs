using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatBar : MonoBehaviour
{
    public Feature feat;
    public TextMeshProUGUI namePlace;
    public ForgeScript forge;
    public Button button;

    public void ChooseFeat()
    {
        forge = GameObject.Find("PathsForgeScreen").GetComponent<ForgeScript>();
        forge.displayedFeat = feat;
        forge.scroll.transform.position = new Vector3(123f, forge.scroll.transform.position.y, forge.scroll.transform.position.z);

        forge.ShowFeat(feat);
    }
}