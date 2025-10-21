using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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
        var guy = Instantiate(pathDesc, scrollParent);
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

        //foreach (Feature f in p.features)
        //{
        //    guyChar.features.text = guyChar.features.text + f.featName + ", ";
        //    foreach (Feature l in f.subOptions)
        //    {
        //        Debug.Log(l.featName);
        //        if (l.subOptions.Count > 0)
        //        {
        //            Debug.Log(l.featName + "entered");
        //            var spec = Instantiate(specPrefab, parentObject);
        //            var specLab = spec.GetComponent<SpecFeature>();
        //            specLab.src = f.featName;
        //            specLab.l = l.subOptions;
        //            specLab.label.text = l.featName;
        //            var specDrop = spec.GetComponent<TMP_Dropdown>();
        //            specDrop.ClearOptions();
        //            specDrop.AddOptions(l.subOptions.ToStringList());
        //        }
        //    }
        //}
    }
}
