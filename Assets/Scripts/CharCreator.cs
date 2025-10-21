using System;
using TMPro;
using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharCreator : MonoBehaviour
{
    public Repository repo;
    public GameObject equipPaper;
    public GameObject displayLin;
    public GameObject displayCul;
    public GameObject displayBack;
    public GameObject displaySign;
    public GameObject displayAttune;
    public GameObject displayFeature;
    public GameObject specNote;

    public TMP_Dropdown dropLineage;
    public TMP_Dropdown dropCulture;
    public TMP_Dropdown dropBack;
    public TMP_Dropdown dropSign;
    public TMP_Dropdown dropAttune;
    public TMP_InputField inputName;
    public TMP_InputField inputLevel;
    public CharacterBar character;

    public TextMeshProUGUI specName;
    public TextMeshProUGUI specDesc;

    public TextMeshProUGUI pointsToEx;
    public TextMeshProUGUI pointsToSkill;
    public TextMeshProUGUI pointsToAtt;

    GameObject dis;

    public GameObject specPrefab;
    public RectTransform parentObject;

    public string displayed;

    private void Start()
    {
        //character.character = ScriptableObject.CreateInstance<Character>();
        pointsToAtt.text = 20.ToString();
        pointsToSkill.text = 60.ToString();
        pointsToEx.text = 50.ToString();
        dropLineage.ClearOptions();
        dropLineage.AddOptions(repo.lineages.ToStringList());
        dropCulture.ClearOptions();
        dropCulture.AddOptions(repo.cultures.ToStringList());
        dropBack.ClearOptions();
        dropBack.AddOptions(repo.backs.ToStringList());
        dropSign.ClearOptions();
        dropSign.AddOptions(repo.signs.ToStringList());
        dropAttune.ClearOptions();
        dropAttune.AddOptions(repo.attunements.ToStringList());
    }
    public void ChooseLineage()
    {
        displayed = "lin";
        if (dis != null)
        {
            Destroy(dis);
        }
        Lineage chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text);
        Debug.Log(chosen);
        character.character.lineage = chosen.lineName;
        dis = Instantiate(displayLin, equipPaper.transform);
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
        if (chosen.speed.swim != 0)
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
        specNote.gameObject.SetActive(false);
        for (int i = parentObject.childCount - 1; i >= 0; i--)
        {
            Destroy(parentObject.GetChild(i).gameObject);
        }
        foreach (Feature f in chosen.features)
        {
            Debug.Log(f);
            Debug.Log(f.featName);
            Debug.Log(f.desc);
            Debug.Log(chosen);
            Debug.Log(chosen.features);
            Debug.Log(disScript);
            Debug.Log(disScript.features);
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
            foreach (Feature l in f.subOptions)
            {
                Debug.Log(l.featName);
                if (l.subOptions.Count > 0)
                {
                    Debug.Log(l.featName + "entered");
                    var spec = Instantiate(specPrefab, parentObject);
                    var specLab = spec.GetComponent<SpecFeature>();
                    specLab.src = f.featName;
                    specLab.l = l.subOptions;
                    specLab.label.text = l.featName;
                    var specDrop = spec.GetComponent<TMP_Dropdown>();
                    specDrop.ClearOptions();
                    specDrop.AddOptions(l.subOptions.ToStringList());
                }
            }
        }
    }
    public void ChooseCulture()
    {
        displayed = "cul";
        if (dis != null)
        {
            Destroy(dis);
        }
        Culture chosen = repo.cultures.First(item => item.cultName == dropCulture.options[dropCulture.value].text);
        character.character.culture = chosen.cultName;
        dis = Instantiate(displayCul, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.cultName;

        disScript.sizeAndClade.text = "<i>" + chosen.desc + "</i>";
        disScript.body.text = chosen.bodyBonus.ToString();
        disScript.grace.text = chosen.graceBonus.ToString();
        disScript.mind.text = chosen.mindBonus.ToString();
        disScript.soul.text = chosen.soulBonus.ToString();
        disScript.trade.text = chosen.tradeBonus.ToString();
        disScript.personality.text = chosen.personalityBonus.ToString();
        disScript.skills.text = chosen.skillBonus.desc;
        specNote.gameObject.SetActive(false);
        for (int i = parentObject.childCount - 1; i >= 0; i--)
        {
            Destroy(parentObject.GetChild(i).gameObject);
        }
        foreach (Feature f in chosen.features)
        {
            Debug.Log(f);
            Debug.Log(f.featName);
            Debug.Log(f.desc);
            Debug.Log(chosen);
            Debug.Log(chosen.features);
            Debug.Log(disScript);
            Debug.Log(disScript.features);
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
            foreach (Feature l in f.subOptions)
            {
                Debug.Log(l.featName);
                if (l.subOptions.Count > 0)
                {
                    Debug.Log(l.featName + "entered");
                    var spec = Instantiate(specPrefab, parentObject);
                    var specLab = spec.GetComponent<SpecFeature>();
                    specLab.src = f.featName;
                    specLab.l = l.subOptions;
                    specLab.label.text = l.featName;
                    var specDrop = spec.GetComponent<TMP_Dropdown>();
                    specDrop.ClearOptions();
                    specDrop.AddOptions(l.subOptions.ToStringList());
                }
            }
        }
        foreach (string f in chosen.equipment)
        {
            Debug.Log(f);
            Debug.Log(chosen);
            Debug.Log(disScript);
            disScript.items.text = disScript.items.text + f;
        }
    }
    public void ChooseBack()
    {
        displayed = "back";
        if (dis != null)
        {
            Destroy(dis);
        }
        Background chosen = repo.backs.First(item => item.backName == dropBack.options[dropBack.value].text);
        character.character.background = chosen.backName;
        dis = Instantiate(displayBack, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.backName;

        disScript.sizeAndClade.text = "<i>" + chosen.desc + "</i>";
        disScript.body.text = chosen.bodyBonus.ToString();
        disScript.grace.text = chosen.graceBonus.ToString();
        disScript.mind.text = chosen.mindBonus.ToString();
        disScript.soul.text = chosen.soulBonus.ToString();
        disScript.trade.text = chosen.tradeBonus.ToString();
        disScript.personality.text = chosen.personalityBonus.ToString();
        disScript.skills.text = chosen.skillBonus.desc;
        specNote.gameObject.SetActive(false);
        for (int i = parentObject.childCount - 1; i >= 0; i--)
        {
            Destroy(parentObject.GetChild(i).gameObject);
        }
        foreach (Feature f in chosen.features)
        {
            Debug.Log(f);
            Debug.Log(f.featName);
            Debug.Log(f.desc);
            Debug.Log(chosen);
            Debug.Log(chosen.features);
            Debug.Log(disScript);
            Debug.Log(disScript.features);
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
            foreach (Feature l in f.subOptions)
            {
                Debug.Log(l.featName);
                if (l.subOptions.Count > 0)
                {
                    Debug.Log(l.featName + "entered");
                    var spec = Instantiate(specPrefab, parentObject);
                    var specLab = spec.GetComponent<SpecFeature>();
                    specLab.src = f.featName;
                    specLab.l = l.subOptions;
                    specLab.label.text = l.featName;
                    var specDrop = spec.GetComponent<TMP_Dropdown>();
                    specDrop.ClearOptions();
                    specDrop.AddOptions(l.subOptions.ToStringList());
                }
            }
        }
        foreach (string f in chosen.equipment)
        {
            Debug.Log(f);
            Debug.Log(chosen);
            Debug.Log(disScript);
            disScript.items.text = disScript.items.text + f;
        }
    }
    public void ChooseSign()
    {
        displayed = "sign";
        if (dis != null)
        {
            Destroy(dis);
        }
        StarSign chosen = repo.signs.First(item => item.signName == dropSign.options[dropSign.value].text);
        character.character.starsign = chosen.signName;
        dis = Instantiate(displaySign, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.signName;

        disScript.sizeAndClade.text = "<i>" + chosen.desc + "</i>";
        disScript.body.text = chosen.bodyBonus.ToString();
        disScript.grace.text = chosen.graceBonus.ToString();
        disScript.mind.text = chosen.mindBonus.ToString();
        disScript.soul.text = chosen.soulBonus.ToString();
        disScript.trade.text = chosen.tradeBonus.ToString();
        disScript.personality.text = chosen.personalityBonus.ToString();
        specNote.gameObject.SetActive(false);
        for (int i = parentObject.childCount - 1; i >= 0; i--)
        {
            Destroy(parentObject.GetChild(i).gameObject);
        }
        foreach (Feature f in chosen.features)
        {
            Debug.Log(f);
            Debug.Log(f.featName);
            Debug.Log(f.desc);
            Debug.Log(chosen);
            Debug.Log(chosen.features);
            Debug.Log(disScript);
            Debug.Log(disScript.features);
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
            foreach (Feature l in f.subOptions)
            {
                Debug.Log(l.featName);
                if (l.subOptions.Count > 0)
                {
                    Debug.Log(l.featName + "entered");
                    var spec = Instantiate(specPrefab, parentObject);
                    var specLab = spec.GetComponent<SpecFeature>();
                    specLab.src = f.featName;
                    specLab.l = l.subOptions;
                    specLab.label.text = l.featName;
                    var specDrop = spec.GetComponent<TMP_Dropdown>();
                    specDrop.ClearOptions();
                    specDrop.AddOptions(l.subOptions.ToStringList());
                }
            }
        }
    }
    public void ChooseAttunement()
    {
        displayed = "attu";
        if (dis != null)
        {
            Destroy(dis);
        }
        Element chosen = repo.attunements.First(item => item.elName == dropAttune.options[dropAttune.value].text);
        character.character.element = chosen.elName;
        dis = Instantiate(displayAttune, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
        var disScript = dis.GetComponent<CharCreatorFeature>();
        disScript.nameDisplay.text = chosen.elName;

        disScript.sizeAndClade.text = "<i>" + chosen.desc + "</i>";
        specNote.gameObject.SetActive(false);
        for (int i = parentObject.childCount - 1; i >= 0; i--)
        {
            Destroy(parentObject.GetChild(i).gameObject);
        }
        foreach (Feature f in chosen.features)
        {
            Debug.Log(f);
            Debug.Log(f.featName);
            Debug.Log(f.desc);
            Debug.Log(chosen);
            Debug.Log(chosen.features);
            Debug.Log(disScript);
            Debug.Log(disScript.features);
            disScript.features.text = disScript.features.text + "<b>" + f.featName + ".</b> " + f.desc + "<br><br>";
            foreach (Feature l in f.subOptions)
            {
                Debug.Log(l.featName);
                if (l.subOptions.Count > 0)
                {
                    Debug.Log(l.featName + "entered");
                    var spec = Instantiate(specPrefab, parentObject);
                    var specLab = spec.GetComponent<SpecFeature>();
                    specLab.src = f.featName;
                    specLab.l = l.subOptions;
                    specLab.label.text = l.featName;
                    var specDrop = spec.GetComponent<TMP_Dropdown>();
                    specDrop.ClearOptions();
                    specDrop.AddOptions(l.subOptions.ToStringList());
                }
            }
        }
    }
    public void SetLevel()
    {
        character.character.level = Convert.ToByte(inputLevel.text);
    }
    public void SetName()
    {
        character.character.charName = inputName.text;
    }
    public void ChooseSpec(string specName, string specDesc, string src, string feat)
    {
        specNote.gameObject.SetActive(true);
        this.specName.text = specName;
        this.specDesc.text = specDesc;
        switch (displayed) {
            case "lin":
                Debug.Log(specName);
                Debug.Log(src);
                Debug.Log(feat);
                Debug.Log(repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text));
                Debug.Log(repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text).features.First(item => item.featName == src));
                Debug.Log(repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text).features.First(item => item.featName == src).subOptions.First(item => item.featName == feat));
                List<Feature> options = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in options)
                {
                    o.subChosen = false;
                }
                Feature chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                chosen.subChosen = true;
                break;
            case "cul":
                List<Feature> culOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in culOptions)
                {
                    o.subChosen = false;
                }
                Feature culChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                culChosen.subChosen = true;
                break;
            case "back":
                List<Feature> backOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in backOptions)
                {
                    o.subChosen = false;
                }
                Feature backChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                backChosen.subChosen = true;
                break;
            case "sign":
                List<Feature> signOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in signOptions)
                {
                    o.subChosen = false;
                }
                Feature signChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                signChosen.subChosen = true;
                break;
            case "attu":
                List<Feature> attuOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in attuOptions)
                {
                    o.subChosen = false;
                }
                Feature attuChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                attuChosen.subChosen = true;
                break;
        }
    }
}
