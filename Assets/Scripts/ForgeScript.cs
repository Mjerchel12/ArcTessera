using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ForgeScript : MonoBehaviour
{
    public Transform parent;
    public Transform parentObject;
    public Transform scrollParent;
    public GameObject choice;
    public GameObject choice2;
    public GameObject specPrefab;
    public GameObject scroll;
    public GameObject pathDesc;
    public GameObject featDesc;
    public GameObject eye;
    public Repository repo;
    public CharacterBar cb;
    public CharCreator cc;
    public Path displayed;
    public Feature displayedFeat;
    public TextMeshProUGUI perks;
    public TextMeshProUGUI columnLabel;
    public GameObject column;
    public List<GameObject> pathsSpawned = new List<GameObject>();
    public List<GameObject> featsSpawned = new List<GameObject>();
    public List<GameObject> guysSpawned = new List<GameObject>();
    public List<GameObject> choicesSpawned = new List<GameObject>();

    public GameObject featuresSwitch;
    public GameObject pathsSwitch;

    public bool pathOn = false;

    public void Spawn()
    {
        cc.chosenSubs.Clear();
        displayed = null;
        displayedFeat = null;
        scroll.transform.position = new Vector3(346f, scroll.transform.position.y, scroll.transform.position.z);
        pathsSwitch.SetActive(false);
        featuresSwitch.SetActive(true);
        Debug.Log("Spawn");
        foreach (GameObject g in pathsSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (GameObject g in featsSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (Path c in repo.paths)
        {
            Debug.Log("wesz³o w foreach");
            if (c != null && Check(c))
            {
                Debug.Log("If");
                var guy = Instantiate(choice, parent);
                var guyChar = guy.GetComponent<PathBar>();
                if (cb.character.paths.Any(item => item.pathName == c.pathName))
                {
                    Debug.Log("If red");
                    ColorBlock colors = guyChar.button.colors;
                    colors.normalColor = new Color(1f, 0.4481132f, 0.4573112f);
                    colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
                    colors.pressedColor = new Color(0.7372549f, 0.2313726f, 0.2520266f);
                    guyChar.button.colors = colors;
                }
                else if (cb.character.level == cb.character.takenPerks)
                {
                    Debug.Log("Elif grey");
                    guyChar.button.interactable = false;
                }
                else
                {
                    Debug.Log("Else");
                    ColorBlock colors = guyChar.button.colors;
                    colors.highlightedColor = new Color(0.6414649f, 0.8773585f, 0.6498898f);
                    colors.pressedColor = new Color(0.232556f, 0.735849f, 0.247813f);
                    guyChar.button.colors = colors;
                }
                guyChar.namePlace.text = c.pathName;
                guyChar.path = c;
                pathsSpawned.Add(guy);
            }
        }
    }
    public void SpawnFeatures()
    {
        cc.chosenSubs.Clear();
        displayed = null;
        displayedFeat = null;
        scroll.transform.position = new Vector3(346f, scroll.transform.position.y, scroll.transform.position.z);
        pathsSwitch.SetActive(true);
        featuresSwitch.SetActive(false);
        Debug.Log("Spawn Feats");
        foreach (GameObject g in pathsSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (GameObject g in featsSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (Path c in cb.character.paths)
        {
            Debug.Log("wesz³o w foreach");
            foreach (Feature f in c.features)
            {
                if (c != null && CheckFeats(f))
                {
                    Debug.Log("If");
                    var guy = Instantiate(choice2, parent);
                    var guyChar = guy.GetComponent<FeatBar>();
                    guyChar.button.interactable = true;
                    if (cb.character.features.Any(item => item.featName == f.featName))
                    {
                        Debug.Log("If red");
                        ColorBlock colors = guyChar.button.colors;
                        colors.normalColor = new Color(1f, 0.4481132f, 0.4573112f);
                        colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
                        colors.pressedColor = new Color(0.7372549f, 0.2313726f, 0.2520266f);
                        guyChar.button.colors = colors;
                    }
                    else if (cb.character.level == cb.character.takenPerks)
                    {
                        Debug.Log("Elif grey");
                        guyChar.button.interactable = false;
                    }
                    else
                    {
                        Debug.Log("Else");
                        ColorBlock colors = guyChar.button.colors;
                        colors.highlightedColor = new Color(0.6414649f, 0.8773585f, 0.6498898f);
                        colors.pressedColor = new Color(0.232556f, 0.735849f, 0.247813f);
                        guyChar.button.colors = colors;
                    }
                    guyChar.namePlace.text = f.featName;
                    guyChar.feat = f;
                    featsSpawned.Add(guy);
                }
            }
        }
    }
    public bool Check(Path c)
    {
        Debug.Log("check");
        bool canBeTaken = c.required == "" || 
            (cb.character.paths.Any(item => item.pathName == c.required) && 
            cb.character.paths.Any(item => item.pathName == c.secondRequired));
        Debug.Log(c.required == "");
        Debug.Log(cb.character.paths.Any(item => item.pathName == c.required));
        Debug.Log(cb.character.paths.Any(item => item.pathName == c.secondRequired));
        Debug.Log(cb.character.paths.Any(item => item.pathName == c.required) &&
            cb.character.paths.Any(item => item.pathName == c.secondRequired));
        Debug.Log(canBeTaken);
        return canBeTaken;
    }
    public bool CheckFeats(Feature f)
    {
        Debug.Log("checkFeat");
        bool canBeTaken = (f.requiredFeatures.Count == 0 ||
            f.requiredFeatures.All(name => cb.character.features.Any(item => item.featName == name)) &&
            f.requiredLevel>=cb.character.level);
        return canBeTaken;
    }
    public void ShowPath(Path p)
    {
        cc.chosenSubs.Clear();
        displayed = p;
        foreach (GameObject g in choicesSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (GameObject g in guysSpawned)
        {
            GameObject.Destroy(g);
        }
        var guy = Instantiate(pathDesc, scrollParent);
        guysSpawned.Add(guy);
        var guyChar = guy.GetComponent<CharCreatorFeature>();
        guyChar.nameDisplay.text = p.pathName;
        guyChar.sizeAndClade.text = p.desc;
        guyChar.skills.text = "Skill set: ";
        foreach (var s in p.spellTables)
        {
            guyChar.skills.text += s + ", ";
        }
        guyChar.skills.text = guyChar.skills.text.Remove(guyChar.skills.text.Length - 2);
        foreach (var e in p.expertise)
        {
            guyChar.expertise.text += e + ", ";
        }
        guyChar.expertise.text = guyChar.expertise.text.Remove(guyChar.expertise.text.Length - 2);
        guyChar.features.text = "<b>" + p.initFeature.featName + "</b><br>" + p.initFeature.desc;
        guyChar.items.text = "You start with the following equipment, in addition to the equipment granted by all else: " + p.equipmentDesc;
        if (cb.character.paths.Any(item => item.pathName == displayed.pathName))
        {
            pathOn = true;
            columnLabel.text = "Remove";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.normalColor = new Color(1f, 0.4669811f, 0.4669811f);
            colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
            butt.colors = colors;   
        }
        else
        {
            pathOn = false;
            columnLabel.text = "Select";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            colors.highlightedColor = new Color(0.8396226f, 0.7084408f, 0.1782218f);
            butt.colors = colors;
        }
        foreach (Feature l in p.initFeature.subOptions)
        {
            Debug.Log(l.featName);
            if (l.subOptions.Count > 0)
            {
                Debug.Log(l.featName + "entered");
                var spec = Instantiate(specPrefab, parentObject);
                var specLab = spec.GetComponent<SpecFeature>();
                specLab.src = p.initFeature.featName;
                specLab.l = l.subOptions;
                specLab.label.text = l.featName;
                var specDrop = spec.GetComponent<TMP_Dropdown>();
                specDrop.ClearOptions();
                specDrop.AddOptions(l.subOptions.ToStringList());
                choicesSpawned.Add(spec);
                cc.chosenSubs.Add(specLab.l.First(item => item.featName == specLab.drop.options[specLab.drop.value].text));
            }
        }
    }
    public void ShowFeat(Feature f)
    {
        cc.chosenSubs.Clear();
        displayedFeat = f;
        foreach (GameObject g in choicesSpawned)
        {
            GameObject.Destroy(g);
        }
        foreach (GameObject g in guysSpawned)
        {
            GameObject.Destroy(g);
        }
        var guy = Instantiate(featDesc, scrollParent);
        guysSpawned.Add(guy);
        var guyChar = guy.GetComponent<CharCreatorFeature>();
        guyChar.nameDisplay.text = f.featName;
        guyChar.sizeAndClade.text = f.desc;
        if (cb.character.features.Any(item => item.featName == displayedFeat.featName))
        {
            pathOn = true;
            columnLabel.text = "Remove";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.normalColor = new Color(1f, 0.4669811f, 0.4669811f);
            colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
            butt.colors = colors;
        }
        else
        {
            pathOn = false;
            columnLabel.text = "Select";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            colors.highlightedColor = new Color(0.8396226f, 0.7084408f, 0.1782218f);
            butt.colors = colors;
        }
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
                choicesSpawned.Add(spec);
                cc.chosenSubs.Add(specLab.l.First(item => item.featName == specLab.drop.options[specLab.drop.value].text));
            }
        }
    }
    public void ChoosePath()
    {
        if(displayed != null)
        {
            if (cb.character.paths.Any(item => item.pathName == displayed.pathName))
            {
                pathOn = false;
                cb.character.paths.Remove(cb.character.paths.First(item => item.pathName == displayed.pathName));
                cb.character.features.Remove(cb.character.features.First(item => item == displayed.initFeature));
                foreach (var f in displayed.initFeature.subOptions)
                {
                    foreach (var b in f.subOptions)
                    {
                        cb.character.features.Remove(b);
                    }
                    cb.character.features.Remove(f);
                }
                foreach (var f in displayed.features)
                {
                    foreach (var b in f.subOptions)
                    {
                        cb.character.features.Remove(b);
                        foreach (var c in b.subOptions)
                        {
                            cb.character.features.Remove(c);
                        }
                    }
                    cb.character.features.Remove(f);
                }
                cb.character.takenPerks--;
            }
            else
            {
                Debug.Log("Adding path");
                pathOn = true;
                cb.character.paths.Add(displayed);
                cb.character.features.Add(displayed.initFeature);
                foreach (var f in cc.chosenSubs)
                {
                    cb.character.features.Add(f);
                }
                List<string> exes = new List<string>();
                foreach (string e in displayed.expertise)
                {
                    exes.Add(e.ToLower());
                }
                List<SkillScript> skills = FindObjectsByType<SkillScript>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(item => exes.Contains(item.skill)).ToList();
                Debug.Log(skills);
                foreach (var s in skills)
                {
                    Debug.Log(s);
                    s.expertise = true;
                }
                skills = FindObjectsByType<SkillScript>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(item => !exes.Contains(item.skill)).ToList();
                foreach (var s in skills)
                {
                    s.expertise = false;
                }
                cb.character.takenPerks++;
            }
            Spawn();
        }
        else if (displayedFeat != null)
        {
            if (cb.character.features.Any(item => item.featName == displayedFeat.featName))
            {
                pathOn = false;
                cb.character.features.Remove(cb.character.features.First(item => item.featName == displayedFeat.featName));
                
                foreach (var f in displayedFeat.subOptions)
                {
                    cb.character.features.Remove(f);
                    foreach (var c in f.subOptions)
                    {
                        cb.character.features.Remove(c);
                    }
                }
                cb.character.takenPerks--;
            }
            else
            {
                pathOn = true;
                cb.character.features.Add(displayedFeat);
                foreach (var f in cc.chosenSubs)
                {
                    cb.character.features.Add(f);
                }
                cb.character.takenPerks++;
            }
            SpawnFeatures();
        }
    }
    private void Update()
    {
        perks.text = cb.character.takenPerks.ToString() + "/" + cb.character.level.ToString();
    }
}
