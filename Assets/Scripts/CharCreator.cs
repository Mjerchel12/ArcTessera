using System;
using TMPro;
using UnityEngine;
using System.Linq;

public class CharCreator : MonoBehaviour
{
    public Repository repo;

    public GameObject display;
    public TMP_Dropdown dropLineage;
    public TMP_Dropdown dropCulture;
    public TMP_Dropdown dropBack;
    public TMP_Dropdown dropSign;
    public TMP_Dropdown dropAttune;
    public TMP_InputField inputName;
    public TMP_InputField inputLevel;
    public Character character;
    public void ChooseLineage()
    {
        character.co.lineage = repo.lineages.FirstOrDefault(item => item.lineName == dropLineage.options[dropAttune.value].text);
    }
    public void ChooseCulture()
    {
        character.co.culture = repo.cultures.FirstOrDefault(item => item.cultName == dropCulture.options[dropAttune.value].text);
    }
    public void ChooseBack()
    {
        character.co.background = repo.backs.FirstOrDefault(item => item.backName == dropBack.options[dropAttune.value].text);
    }
    public void ChooseSign()
    {
        character.co.starsign = repo.signs.FirstOrDefault(item => item.signName == dropSign.options[dropAttune.value].text);
    }
    public void ChooseAttunement()
    {
        character.co.element = repo.attunements.FirstOrDefault(item => item.elName == dropAttune.options[dropAttune.value].text);
    }
    public void SetLevel()
    {
        character.co.level = Convert.ToByte(inputLevel.text);
    }
    public void SetName()
    {
        character.jo.name = inputName.text;
    }
}
