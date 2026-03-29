using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
    public List<SpecFeature> specFeats = new List<SpecFeature>();

    private CharOption ManageFeatures(CharOption charOp, IEnumerable<CharOption> repoList, TMP_Dropdown drop, string display)
    {
        if (charOp.opName != null)
        {
            foreach (Feature f in charOp.features)
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
        displayed = display;
        if (dis != null)
        {
            Destroy(dis);
        }
        CharOption chosen = repoList.First(item => item.opName == drop.options[drop.value].text);
        return chosen;
    }
    public void StartCreating()
    {
        character.character = new Character();
        character.character.level = 1;
        pointsToAtt.text = 20.ToString();
        pointsToSkill.text = 60.ToString();
        pointsToEx.text = 50.ToString();
        dropLineage.ClearOptions();
        dropLineage.AddOptions(new List<string>() { "None" });
        dropLineage.AddOptions(repo.lineages.ToStringList());
        dropCulture.ClearOptions();
        dropCulture.AddOptions(new List<string>() { "None" });
        dropCulture.AddOptions(repo.cultures.ToStringList());
        dropBack.ClearOptions();
        dropBack.AddOptions(new List<string>() { "None" });
        dropBack.AddOptions(repo.backs.ToStringList());
        dropSign.ClearOptions();
        dropSign.AddOptions(new List<string>() { "None" });
        dropSign.AddOptions(repo.signs.ToStringList());
        dropAttune.ClearOptions();
        dropAttune.AddOptions(new List<string>() { "None" });
        dropAttune.AddOptions(repo.attunements.ToStringList());

        //character.character.lineage = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text).lineName;
        //foreach (Feature f in repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text).features)
        //{
        //    character.character.features.Add(f);
        //}
        //Feature chosen = repo.lineages.First(item => item.lineName == dropLineage.options[dropLineage.value].text)
        //            .features.First(item => item.featName == src)
        //            .subOptions.First(item => item.featName == feat)
        //            .subOptions.First(item => item.featName == specName);
        //character.character.features.Add(chosen);

        //character.character.culture = repo.cultures.First(item => item.cultName == dropCulture.options[dropCulture.value].text).cultName;
        //foreach (Feature f in repo.cultures.First(item => item.cultName == dropCulture.options[dropCulture.value].text).features)
        //{
        //    character.character.features.Add(f);
        //}

        //character.character.background = repo.backs.First(item => item.backName == dropBack.options[dropBack.value].text).backName;
        //foreach (Feature f in repo.backs.First(item => item.backName == dropBack.options[dropBack.value].text).features)
        //{
        //    character.character.features.Add(f);
        //}

        //character.character.starsign = repo.signs.First(item => item.signName == dropSign.options[dropSign.value].text).signName;
        //foreach (Feature f in repo.signs.First(item => item.signName == dropSign.options[dropSign.value].text).features)
        //{
        //    character.character.features.Add(f);
        //}

        //character.character.element = repo.attunements.First(item => item.elName == dropAttune.options[dropAttune.value].text).elName;
        //foreach (Feature f in repo.attunements.First(item => item.elName == dropAttune.options[dropAttune.value].text).features)
        //{
        //    character.character.features.Add(f);
        //}
    }
    public void ChooseLineage()
    {
        if (dropLineage.options[dropLineage.value].text != "None")
        {
            Lineage chosen = (Lineage)ManageFeatures(character.character.lineage, repo.lineages, dropLineage, "lin");
            character.character.lineage = chosen;
            dis = Instantiate(displayLin, equipPaper.transform);
            var disScript = dis.GetComponent<CharCreatorFeature>();
            disScript.nameDisplay.text = chosen.opName;
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
            specFeats.Clear();
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
                        specFeats.Add(specLab);
                        specLab.src = f.featName;
                        specLab.l = l.subOptions;
                        specLab.label.text = l.featName;
                        var specDrop = spec.GetComponent<TMP_Dropdown>();
                        specDrop.ClearOptions();
                        specDrop.AddOptions(new List<string>() { "None" });
                        specDrop.AddOptions(l.subOptions.ToStringList());
                    }
                }
            }
        }
        else
        {
            character.character.lineage = null;
            if (dis != null)
            {
                Destroy(dis);
            }
            for (int i = parentObject.childCount - 1; i >= 0; i--)
            {
                Destroy(parentObject.GetChild(i).gameObject);
            }
        }
    }
    public void ChooseCulture()
    {
        if (dropCulture.options[dropCulture.value].text != "None")
        {

            Culture chosen = (Culture)ManageFeatures(character.character.culture, repo.cultures, dropCulture, "cul");
            character.character.culture = chosen;
            dis = Instantiate(displayCul, equipPaper.transform);
            var disScript = dis.GetComponent<CharCreatorFeature>();
            disScript.nameDisplay.text = chosen.opName;

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
            specFeats.Clear();
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
                        specFeats.Add(specLab);
                        specLab.src = f.featName;
                        specLab.l = l.subOptions;
                        specLab.label.text = l.featName;
                        var specDrop = spec.GetComponent<TMP_Dropdown>();
                        specDrop.ClearOptions();
                        specDrop.AddOptions(new List<string>() { "None" });
                        specDrop.AddOptions(l.subOptions.ToStringList());
                    }
                }
            }
            foreach (string f in chosen.equipment)
            {
                Debug.Log(f);
                Debug.Log(chosen);
                Debug.Log(disScript);
                disScript.items.text = chosen.equipmentDesc;
            }
            //dropCulture.options.RemoveAt(0);
        }
        else
            {
                character.character.culture = null;
                if (dis != null)
                {
                    Destroy(dis);
                }
                for (int i = parentObject.childCount - 1; i >= 0; i--)
                {
                    Destroy(parentObject.GetChild(i).gameObject);
                }
        }
    }
    public void ChooseBack()
    {
        if (dropBack.options[dropBack.value].text != "None")
        {
            Background chosen = (Background)ManageFeatures(character.character.background, repo.backs, dropBack, "back");
            character.character.background = chosen;
            dis = Instantiate(displayBack, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
            var disScript = dis.GetComponent<CharCreatorFeature>();
            disScript.nameDisplay.text = chosen.opName;

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
            specFeats.Clear();
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
                        specFeats.Add(specLab);
                        specLab.src = f.featName;
                        specLab.l = l.subOptions;
                        specLab.label.text = l.featName;
                        var specDrop = spec.GetComponent<TMP_Dropdown>();
                        specDrop.ClearOptions();
                        specDrop.AddOptions(new List<string>() { "None" });
                        specDrop.AddOptions(l.subOptions.ToStringList());
                    }
                }
            }
            foreach (string f in chosen.equipment)
            {
                Debug.Log(f);
                Debug.Log(chosen);
                Debug.Log(disScript);
                disScript.items.text = chosen.equipmentDesc;
            }
            //dropBack.options.RemoveAt(0);
        }
        else
        {
            character.character.background = null;
            if (dis != null)
            {
                Destroy(dis);
            }
            for (int i = parentObject.childCount - 1; i >= 0; i--)
            {
                Destroy(parentObject.GetChild(i).gameObject);
            }
        }
    }
    public void ChooseSign()
    {
        if (dropSign.options[dropSign.value].text != "None")
        {
            StarSign chosen = (StarSign)ManageFeatures(character.character.starsign, repo.signs, dropSign, "sign");
            character.character.starsign = chosen;
            dis = Instantiate(displaySign, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
            var disScript = dis.GetComponent<CharCreatorFeature>();
            disScript.nameDisplay.text = chosen.opName;

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
            specFeats.Clear();
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
                        specFeats.Add(specLab);
                        specLab.src = f.featName;
                        specLab.l = l.subOptions;
                        specLab.label.text = l.featName;
                        var specDrop = spec.GetComponent<TMP_Dropdown>();
                        specDrop.ClearOptions();
                        specDrop.AddOptions(new List<string>() { "None" });
                        specDrop.AddOptions(l.subOptions.ToStringList());
                    }
                }
            }
            //dropSign.options.RemoveAt(0);
        }
        else
        {
            character.character.starsign = null;
            if (dis != null)
            {
                Destroy(dis);
            }
            for (int i = parentObject.childCount - 1; i >= 0; i--)
            {
                Destroy(parentObject.GetChild(i).gameObject);
            }
        }
    }
    public void ChooseAttunement()
    {
        if (dropAttune.options[dropAttune.value].text != "None")
        {
            Element chosen = (Element)ManageFeatures(character.character.element, repo.attunements, dropAttune, "attu");
            character.character.element = chosen;
            dis = Instantiate(displayAttune, new Vector2(85f, 110f), Quaternion.identity, equipPaper.transform);
            var disScript = dis.GetComponent<CharCreatorFeature>();
            disScript.nameDisplay.text = chosen.opName;

            disScript.sizeAndClade.text = "<i>" + chosen.desc + "</i>";
            specNote.gameObject.SetActive(false);
            for (int i = parentObject.childCount - 1; i >= 0; i--)
            {
                Destroy(parentObject.GetChild(i).gameObject);
            }
            specFeats.Clear();
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
                        specFeats.Add(specLab);
                        specLab.src = f.featName;
                        specLab.l = l.subOptions;
                        specLab.label.text = l.featName;
                        var specDrop = spec.GetComponent<TMP_Dropdown>();
                        specDrop.ClearOptions();
                        specDrop.AddOptions(new List<string>() { "None" });
                        specDrop.AddOptions(l.subOptions.ToStringList());
                    }
                }
            }
            //dropAttune.options.Remove("None");
        }
        else
        {
            character.character.element = null;
            if (dis != null)
            {
                Destroy(dis);
            }
            for (int i = parentObject.childCount - 1; i >= 0; i--)
            {
                Destroy(parentObject.GetChild(i).gameObject);
            }
        }
    }
    public void SetLevel()
    {
        character.character.level = Convert.ToByte(inputLevel.text);
        if (fs.pathsSwitch.activeSelf)
        {
            fs.SpawnFeatures();
        }
        else
        {
            fs.Spawn();
        }
        if (character.character.level < 3)
        {
            character.character.talent = 3;
        }
        else if (character.character.level < 7)
        {
            character.character.talent = 4;
        }
        else if (character.character.level < 13)
        {
            character.character.talent = 5;
        }
        else
        {
            character.character.talent = 6;
        }
    }
    public void SetName()
    {
        character.character.charName = inputName.text;
    }
    public void ChooseSpec(string specName, string specDesc, string src, string feat)
    {
        if(specName == "None")
        {
            return;
        }
        specNote.gameObject.SetActive(true);
        this.specName.text = specName;
        this.specDesc.text = specDesc;
        switch (displayed) {
            case "lin":
                GetSubOptions(specName, src, feat, repo.lineages, dropLineage);
                break;
            case "cul":
                GetSubOptions(specName, src, feat, repo.cultures, dropCulture);
                break;
            case "back":
                GetSubOptions(specName, src, feat, repo.backs, dropBack);
                break;
            case "sign":
                GetSubOptions(specName, src, feat, repo.signs, dropSign);
                break;
            case "attu":
                GetSubOptions(specName, src, feat, repo.attunements, dropAttune);
                break;
            case "path":
                List<Feature> pathOptions = repo.paths.First(item => item.pathName == fs.displayed.pathName)
                    .initFeature
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in pathOptions)
                {
                    chosenSubs.Remove(o);
                    character.character.features.Remove(o);
                }
                Feature pathChosen = repo.paths.First(item => item.pathName == fs.displayed.pathName)
                    .initFeature
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                chosenSubs.Add(pathChosen);
                if (fs.pathOn)
                {
                    character.character.features.Add(pathChosen);
                }
                break;
            case "feat":
                List<Feature> featOptions = fs.displayedFeat
                    .subOptions.First(item => item.featName == feat)
                    .subOptions;
                foreach (var o in featOptions)
                {
                    chosenSubs.Remove(o);
                    character.character.features.Remove(o);
                }
                Feature featChosen = fs.displayedFeat
                    .subOptions.First(item => item.featName == feat)
                    .subOptions.First(item => item.featName == specName);
                chosenSubs.Add(featChosen);
                if (fs.pathOn)
                {
                    character.character.features.Add(featChosen);
                }
                break;
        }
    }

    private void GetSubOptions(string specName, string src, string feat, IEnumerable<CharOption> repoList, TMP_Dropdown drop)
    {
        List<Feature> options = repoList.First(item => item.opName == drop.options[drop.value].text)
                            .features.First(item => item.featName == src)
                            .subOptions.First(item => item.featName == feat)
                            .subOptions;
        foreach (var o in options)
        {
            character.character.features.Remove(o);
        }
        Feature chosen = repoList.First(item => item.opName == drop.options[drop.value].text)
            .features.First(item => item.featName == src)
            .subOptions.First(item => item.featName == feat)
            .subOptions.First(item => item.featName == specName);
        character.character.features.Add(chosen);
    }
}
