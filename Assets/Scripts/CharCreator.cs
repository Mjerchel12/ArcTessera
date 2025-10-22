using System;
using TMPro;
using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

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

    public List<Feature> chosenSubs;

    public ForgeScript fs;

    public void StartCreating()
    {
        character.character = new Character();
        character.character.level = 1;
        character.character.features = new List<Feature>();
        character.character.paths = new List<Path>();
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
        if(character.character.lineage != null)
        {
            foreach (Feature f in repo.lineages.First(item => item.lineName == character.character.lineage).features)
            {
                character.character.features.Remove(f);
                foreach (Feature l in f.subOptions)
                {
                    foreach(Feature r in l.subOptions)
                    {
                        character.character.features.Remove(r);
                    }
                }
            }
        }
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
            character.character.features.Add(f);
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
        if (character.character.culture != null)
        {
            foreach (Feature f in repo.cultures.First(item => item.cultName == character.character.culture).features)
            {
                character.character.features.Remove(f);
                foreach (Feature l in f.subOptions)
                {
                    foreach (Feature r in l.subOptions)
                    {
                        character.character.features.Remove(r);
                    }
                }
            }
        }
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
            character.character.features.Add(f);
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
            List<List<Item>> items = repo.Decode(f);
            foreach (List<Item> l in items)
            {
                foreach (Item item in l)
                {
                    disScript.items.text = disScript.items.text + item.itemName +", ";
                }
            }
        }
    }
    public void ChooseBack()
    {
        if (character.character.background != null)
        {
            foreach (Feature f in repo.backs.First(item => item.backName == character.character.background).features)
            {
                character.character.features.Remove(f);
                foreach (Feature l in f.subOptions)
                {
                    foreach (Feature r in l.subOptions)
                    {
                        character.character.features.Remove(r);
                    }
                }
            }
        }
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
            character.character.features.Add(f);
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
            List<List<Item>> items = repo.Decode(f);
            foreach (List<Item> l in items)
            {
                foreach (Item item in l)
                {
                    disScript.items.text = disScript.items.text + item.itemName + ", ";
                }
            }
        }
    }
    public void ChooseSign()
    {
        if (character.character.starsign != null)
        {
            foreach (Feature f in repo.signs.First(item => item.signName == character.character.starsign).features)
            {
                character.character.features.Remove(f);
                foreach (Feature l in f.subOptions)
                {
                    foreach (Feature r in l.subOptions)
                    {
                        character.character.features.Remove(r);
                    }
                }
            }
        }
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
            character.character.features.Add(f);
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
        if (character.character.element != null)
        {
            foreach (Feature f in repo.attunements.First(item => item.elName == character.character.element).features)
            {
                character.character.features.Remove(f);
                foreach (Feature l in f.subOptions)
                {
                    foreach (Feature r in l.subOptions)
                    {
                        character.character.features.Remove(r);
                    }
                }
            }
        }
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
            character.character.features.Add(f);
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
                    character.character.features.Remove(o);
                }
                Feature chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                character.character.features.Add(chosen);
                break;
            case "cul":
                List<Feature> culOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in culOptions)
                {
                    character.character.features.Remove(o);
                }
                Feature culChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                character.character.features.Add(culChosen);
                break;
            case "back":
                List<Feature> backOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in backOptions)
                {
                    character.character.features.Remove(o);
                }
                Feature backChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                character.character.features.Add(backChosen);
                break;
            case "sign":
                List<Feature> signOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in signOptions)
                {
                    character.character.features.Remove(o);
                }
                Feature signChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                character.character.features.Add(signChosen);
                break;
            case "attu":
                List<Feature> attuOptions = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in attuOptions)
                {
                    character.character.features.Remove(o);
                }
                Feature attuChosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                character.character.features.Add(attuChosen);
                break;
            case "path":
                List<Feature> pathOptions = repo.paths.First(item => item.pathName == fs.displayed.pathName)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in pathOptions)
                {
                    chosenSubs.Remove(o);
                }
                Feature pathChosen = repo.paths.First(item => item.pathName == fs.displayed.pathName)
                    .features.First(item => item.featName == src)
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                chosenSubs.Add(pathChosen);
                break;
        }
    }
}
