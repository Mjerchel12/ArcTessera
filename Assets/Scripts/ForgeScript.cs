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
    public GameObject specPrefab;
    public GameObject scroll;
    public GameObject pathDesc;
    public GameObject featDesc;
    public Repository repo;
    public CharacterBar cb;
    public Path displayed;
    public TextMeshProUGUI perks;
    public TextMeshProUGUI columnLabel;
    public GameObject column;
    public List<GameObject> pathsSpawned = new List<GameObject>();
    public List<GameObject> guysSpawned = new List<GameObject>();
    public void Spawn()
    {
        scroll.transform.position = new Vector3(329f, scroll.transform.position.y, scroll.transform.position.z);
        foreach (Path c in repo.paths)
        {
            Debug.Log("wesz³o w foreach");
            if (c != null && Check(c))
            {
                foreach(GameObject g in pathsSpawned)
                {
                    GameObject.Destroy(g);
                }
                var guy = Instantiate(choice, parent);
                var guyChar = guy.GetComponent<PathBar>();
                if (cb.character.paths.Any(item => item.pathName == c.pathName))
                {
                    ColorBlock colors = guyChar.button.colors;
                    colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
                    colors.pressedColor = new Color(0.7372549f, 0.2313726f, 0.2520266f);
                    guyChar.button.colors = colors;
                }
                else if (cb.character.level == cb.character.takenPerks)
                {
                    guyChar.button.interactable = false;
                }
                else
                {
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
    public bool Check(Path c)
    {
        bool canBeTaken = c.required == null || 
            (cb.character.paths.Any(item => item.pathName == c.required && item.howAdvanced >= c.reqAdv) && 
            cb.character.paths.Any(item => item.pathName == c.secondRequired && item.howAdvanced >= c.secReqAdv));

        return canBeTaken;
    }
    public void ShowPath(Path p)
    {
        foreach (GameObject g in guysSpawned)
        {
            GameObject.Destroy(g);
        }
        var guy = Instantiate(pathDesc, scrollParent);
        guysSpawned.Add(guy);
        var guyChar = guy.GetComponent<CharCreatorFeature>();
        guyChar.nameDisplay.text = p.pathName;
        guyChar.sizeAndClade.text = p.desc;
        foreach (var e in p.expertise)
        {
            guyChar.expertise.text += e + ", ";
        }
        guyChar.features.text = "<b>" + p.initFeature.featName + ",</b><br>";

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
            }
        }
        if (cb.character.paths.Any(item => item.pathName == displayed.pathName))
        {
            columnLabel.text = "Remove";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.highlightedColor = new Color(0.8784314f, 0.6431373f, 0.6478421f);
            butt.colors = colors;
        }
        else
        {
            columnLabel.text = "Select";
            var butt = column.GetComponent<Button>();
            ColorBlock colors = butt.colors;
            colors.highlightedColor = new Color(0.8396226f, 0.7084408f, 0.1782218f);
            butt.colors = colors;
        }
    }
    public void ChoosePath()
    {
        if (cb.character.paths.Any(item => item.pathName == displayed.pathName))
        {
            cb.character.paths.Remove(cb.character.paths.First(item => item.pathName == displayed.pathName));
            cb.character.takenPerks--;
        }
        else
        {
            cb.character.paths.Add(displayed);
            cb.character.takenPerks++;
        }
        Spawn();
    }
    private void Update()
    {
        perks.text = cb.character.takenPerks.ToString() + "/" + cb.character.level.ToString();
    }
}
