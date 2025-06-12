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
    public CharacterBar character;
    GameObject dis;
    private void Start()
    {
        character.character = ScriptableObject.CreateInstance<Character>();
        character.character.co = ScriptableObject.CreateInstance<CharacterOptions>();
        character.character.att = ScriptableObject.CreateInstance<Attributes>();
        character.character.stats = ScriptableObject.CreateInstance<Statistics>();
        character.character.cons = ScriptableObject.CreateInstance<Conditions>();
        character.character.cmb = ScriptableObject.CreateInstance<Combat>();
        character.character.eq = ScriptableObject.CreateInstance<Equipment>();
        character.character.jo = ScriptableObject.CreateInstance<Journal>();
    }
    public void ChooseLineage()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Lineage chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text);
        Debug.Log(chosen);
        character.character.co.lineage = chosen;
        dis = Instantiate(displayLin, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.lineName;
        disScript.sizeAndClade.text = "<i>" + chosen.size + " " + chosen.clade + "</i>";
        disScript.vit.text = chosen.vitDiceQuantity + "d" + chosen.vitDice;
        disScript.stam.text = chosen.staminaBase.ToString();
        disScript.san.text = chosen.sanityBase.ToString();
        disScript.body.text = chosen.bodyBonus.ToString();
        disScript.grace.text = chosen.graceBonus.ToString();
        disScript.mind.text = chosen.mindBonus.ToString();
        disScript.soul.text = chosen.soulBonus.ToString();
        disScript.trade.text = chosen.tradeBonus.ToString();
        disScript.personality.text = chosen.personalityBonus.ToString();
        disScript.speed.text = chosen.speed.walk + "m";
        if(chosen.speed.swim != 0)
        {
            disScript.speed.text = disScript.speed.text + ", Swimming:" + chosen.speed.swim.ToString();
        }
        if (chosen.speed.fly != 0)
        {
            disScript.speed.text = disScript.speed.text + ", Flying:" + chosen.speed.fly.ToString();
        }
        if (chosen.speed.crawl != 0)
        {
            disScript.speed.text = disScript.speed.text + ", Crawling:" + chosen.speed.crawl.ToString();
        }
        if (chosen.speed.highLeap != 0)
        {
            disScript.speed.text = disScript.speed.text + ", High Leap:" + chosen.speed.highLeap.ToString();
        }
        if (chosen.speed.farLeap != 0)
        {
            disScript.speed.text = disScript.speed.text + ", Far Leap:" + chosen.speed.farLeap.ToString();
        }
        disScript.senses.text = chosen.senses;
        disScript.size.text = chosen.sizeSpan;
        disScript.lifespan.text = chosen.lifeSpan;
        disScript.skills.text = chosen.skillBonus.desc;
        foreach (Feature f in chosen.features) 
        { 
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
        }
    }
    public void ChooseCulture()
    {
        if (dis != null)
        {
            Destroy(dis);
        }
        Culture chosen = repo.cultures.First(item => item.cultName == dropCulture.options[dropCulture.value].text);
        character.character.co.culture = chosen;
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
        character.character.co.background = chosen;
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
        character.character.co.starsign = chosen;
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
        character.character.co.element = chosen;
        dis = Instantiate(displayAttune, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.elName;
    }
    public void SetLevel()
    {
        character.character.co.level = Convert.ToByte(inputLevel.text);
    }
    public void SetName()
    {
        character.character.jo.charName = inputName.text;
    }
}
