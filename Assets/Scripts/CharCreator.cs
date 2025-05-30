using System;
using TMPro;
using UnityEngine;
using System.Linq;

public class CharCreator : MonoBehaviour
{
    public Repository repo;
    public GameObject equipPaper;
    public GameObject displayLin;
    public GameObject displayCul;
    public GameObject displayBack;
    public GameObject displaySign;
    public GameObject displayAttune;
    public TMP_Dropdown dropLineage;
    public TMP_Dropdown dropCulture;
    public TMP_Dropdown dropBack;
    public TMP_Dropdown dropSign;
    public TMP_Dropdown dropAttune;
    public TMP_InputField inputName;
    public TMP_InputField inputLevel;
    public Character character;
    GameObject dis;
    public void ChooseLineage()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Lineage chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text);
        character.co.lineage = chosen;
        dis = Instantiate(displayLin, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.lineName;
    }
    public void ChooseCulture()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Culture chosen = repo.cultures.First(item => item.cultName == dropCulture.options[dropCulture.value].text);
        character.co.culture = chosen;
        dis = Instantiate(displayCul, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.cultName;
    }
    public void ChooseBack()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Background chosen = repo.backs.First(item => item.backName == dropBack.options[dropBack.value].text);
        character.co.background = chosen;
        dis = Instantiate(displayBack, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.backName;
    }
    public void ChooseSign()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        StarSign chosen = repo.signs.First(item => item.signName == dropSign.options[dropSign.value].text);
        character.co.starsign = chosen;
        dis = Instantiate(displaySign, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.signName;
    }
    public void ChooseAttunement()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Element chosen = repo.attunements.First(item => item.elName == dropAttune.options[dropAttune.value].text);
        character.co.element = chosen;
        dis = Instantiate(displayAttune, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.elName;
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
