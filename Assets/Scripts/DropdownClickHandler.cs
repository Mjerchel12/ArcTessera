using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownClickHandler : MonoBehaviour, IPointerClickHandler
{
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(dropdown.options[dropdown.value].text != "None")
        {
            dropdown.onValueChanged.Invoke(dropdown.value);
        }
    }
}