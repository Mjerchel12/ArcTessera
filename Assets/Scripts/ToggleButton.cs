using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color toggledColor;

    private bool isToggled = false;

    void Start()
    {
        button.onClick.AddListener(Toggle);
        UpdateButtonAppearance();
        Debug.Log("Start");
    }

    void Toggle()
    {
        Debug.Log("Toggle");
        isToggled = !isToggled;
        UpdateButtonAppearance();
        Debug.Log($"Button toggled: {isToggled}");
    }

    void UpdateButtonAppearance()
    {
        Debug.Log("Update");
        buttonImage.color = isToggled ? toggledColor : normalColor;
    }
}