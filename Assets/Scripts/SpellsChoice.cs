using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellsChoice : MonoBehaviour
{
    public TextMeshProUGUI spellType;
    public TextMeshProUGUI displayedList;
    public TextMeshProUGUI talent;
    public TextMeshProUGUI spellCount;
    public Transform spellList;
    public Transform spellDisplay;
    public GameObject spellPrefab;
    public GameObject spellDescPrefab;
    public GameObject manDescPrefab;
    public GameObject spellOpPrefab;
    public Repository repo;
    public List<GameObject> spawnedGuys;
    public GameObject spawnedDisplay;
    public List<GameObject> spawnedOps;
    public CharacterBar cb;

    public GameObject manSquare;
    public GameObject expSquare;
    public GameObject techSquare;
    public GameObject spellSquare;

    public void Spawn()
    {
        List<string> tables = new List<string>();
        foreach (var path in cb.character.paths)
        {
            tables.AddRange(path.spellTables);
        }
        if (tables.Contains("Martial Maneuvers"))
        {
            manSquare.SetActive(true);
        }
        else
        {
            manSquare.SetActive(false);
        }
        if (tables.Contains("Roguish Exploits"))
        {
            expSquare.SetActive(true);
        }
        else
        {
            expSquare.SetActive(false);
        }
        if (tables.Contains("Monastic Techniques"))
        {
            techSquare.SetActive(true);
        }
        else
        {
            techSquare.SetActive(false);
        }
        if (tables.Contains("Spells"))
        {
            spellSquare.SetActive(true);
        }
        else
        {
            spellSquare.SetActive(false);
        }
    }
    public void SpawnManeuvers()
    {
        displayedList.text = "Martial Maneuvers";
        spellCount.text = cb.character.maneuvers.Count(item => item.types.Contains("Martial Maneuver")).ToString();
        foreach (GameObject go in spawnedGuys)
        {
            GameObject.Destroy(go);
        }
        GameObject.Destroy(spawnedDisplay);
        foreach (GameObject go in spawnedOps)
        {
            GameObject.Destroy(go);
        }
        foreach (Maneuver m in repo.maneuvers)
        {
            Debug.Log("wesz這 w foreach");
            if (m != null && m.types.Contains("Martial Maneuver") && Check(m))
            {
                Debug.Log("If");
                var guy = Instantiate(spellPrefab, spellList);
                var guyChar = guy.GetComponent<SpellBar>();
                if (cb.character.maneuvers.Contains(m))
                {
                    guyChar.isTaken = true;
                }
                if (guyChar.isTaken||spellCount.text==talent.text)
                {
                    Debug.Log("Green grey");
                    guyChar.greenButton.interactable = false;
                }
                else
                {
                    Debug.Log("Green else");
                    guyChar.greenButton.interactable = true;
                }
                if (!guyChar.isTaken)
                {
                    Debug.Log("Red grey");
                    guyChar.redButton.interactable = false;
                }
                else
                {
                    Debug.Log("Red else");
                    guyChar.redButton.interactable = true;
                }
                guyChar.spellName.text = m.manName;
                if (m.types.Contains("Simple"))
                {
                    guyChar.spellLevel.text = "I";
                }
                if (m.types.Contains("Greater"))
                {
                    guyChar.spellLevel.text = "II";
                }
                if (m.types.Contains("Master"))
                {
                    guyChar.spellLevel.text = "III";
                }
                if (guyChar.isTaken)
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
                }
                else
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                guyChar.type.SetActive(false);
                guyChar.man = m;
                spawnedGuys.Add(guy);
            }
        }
    }
    public void SpawnExploits()
    {
        displayedList.text = "Roguish Exploits";
        spellCount.text = cb.character.maneuvers.Count(item => item.types.Contains("Roguish Exploit")).ToString();
        foreach (GameObject go in spawnedGuys)
        {
            GameObject.Destroy(go);
        }
        GameObject.Destroy(spawnedDisplay);
        foreach (GameObject go in spawnedOps)
        {
            GameObject.Destroy(go);
        }
        foreach (Maneuver m in repo.maneuvers)
        {
            Debug.Log("wesz這 w foreach");
            if (m != null && m.types.Contains("Roguish Exploit") && Check(m))
            {
                Debug.Log("If");
                var guy = Instantiate(spellPrefab, spellList);
                var guyChar = guy.GetComponent<SpellBar>();
                if (cb.character.maneuvers.Contains(m))
                {
                    guyChar.isTaken = true;
                }
                if (guyChar.isTaken || spellCount.text == talent.text)
                {
                    Debug.Log("Green grey");
                    guyChar.greenButton.interactable = false;
                }
                else
                {
                    Debug.Log("Green else");
                    guyChar.greenButton.interactable = true;
                }
                if (!guyChar.isTaken)
                {
                    Debug.Log("Red grey");
                    guyChar.redButton.interactable = false;
                }
                else
                {
                    Debug.Log("Red else");
                    guyChar.redButton.interactable = true;
                }
                guyChar.spellName.text = m.manName;
                if (m.types.Contains("Simple"))
                {
                    guyChar.spellLevel.text = "I";
                }
                if (m.types.Contains("Greater"))
                {
                    guyChar.spellLevel.text = "II";
                }
                if (m.types.Contains("Master"))
                {
                    guyChar.spellLevel.text = "III";
                }
                if (guyChar.isTaken)
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
                }
                else
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                guyChar.type.SetActive(false);
                guyChar.man = m;
                spawnedGuys.Add(guy);
            }
        }
    }
    public void SpawnTechnique()
    {
        displayedList.text = "Monastic Techniques";
        spellCount.text = cb.character.maneuvers.Count(item => item.types.Contains("Monastic Technique")).ToString();
        foreach (GameObject go in spawnedGuys)
        {
            GameObject.Destroy(go);
        }
        GameObject.Destroy(spawnedDisplay);
        foreach (GameObject go in spawnedOps)
        {
            GameObject.Destroy(go);
        }
        foreach (Maneuver m in repo.maneuvers)
        {
            Debug.Log("wesz這 w foreach");
            if (m != null && m.types.Contains("Monastic Technique") && Check(m))
            {
                Debug.Log("If");
                var guy = Instantiate(spellPrefab, spellList);
                var guyChar = guy.GetComponent<SpellBar>();
                if (cb.character.maneuvers.Contains(m))
                {
                    guyChar.isTaken = true;
                }
                if (guyChar.isTaken || spellCount.text == talent.text)
                {
                    Debug.Log("Green grey");
                    guyChar.greenButton.interactable = false;
                }
                else
                {
                    Debug.Log("Green else");
                    guyChar.greenButton.interactable = true;
                }
                if (!guyChar.isTaken)
                {
                    Debug.Log("Red grey");
                    guyChar.redButton.interactable = false;
                }
                else
                {
                    Debug.Log("Red else");
                    guyChar.redButton.interactable = true;
                }
                guyChar.spellName.text = m.manName;
                if (m.types.Contains("Simple"))
                {
                    guyChar.spellLevel.text = "I";
                }
                if (m.types.Contains("Greater"))
                {
                    guyChar.spellLevel.text = "II";
                }
                if (m.types.Contains("Master"))
                {
                    guyChar.spellLevel.text = "III";
                }
                if (guyChar.isTaken)
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
                }
                else
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                guyChar.type.SetActive(false);
                guyChar.man = m;
                spawnedGuys.Add(guy);
            }
        }
    }
    public void SpawnSpells()
    {
        displayedList.text = "Spells";
        spellCount.text = cb.character.spells.Count().ToString();
        foreach (GameObject go in spawnedGuys)
        {
            GameObject.Destroy(go);
        }
        GameObject.Destroy(spawnedDisplay);
        foreach (GameObject go in spawnedOps)
        {
            GameObject.Destroy(go);
        }
        foreach (Spell m in repo.spells)
        {
            Debug.Log("wesz這 w foreach");
            if (Check(m))
            {
                Debug.Log("If");
                var guy = Instantiate(spellPrefab, spellList);
                var guyChar = guy.GetComponent<SpellBar>();
                if (cb.character.spells.Contains(m))
                {
                    guyChar.isTaken = true;
                }
                if (guyChar.isTaken || spellCount.text == talent.text)
                {
                    Debug.Log("Green grey");
                    guyChar.greenButton.interactable = false;
                }
                else
                {
                    Debug.Log("Green else");
                    guyChar.greenButton.interactable = true;
                }
                if (!guyChar.isTaken)
                {
                    Debug.Log("Red grey");
                    guyChar.redButton.interactable = false;
                }
                else
                {
                    Debug.Log("Red else");
                    guyChar.redButton.interactable = true;
                }
                guyChar.spellName.text = m.manName;
                if (m.types.Contains("Simple"))
                {
                    guyChar.spellLevel.text = "I";
                }
                if (m.types.Contains("Greater"))
                {
                    guyChar.spellLevel.text = "II";
                }
                if (m.types.Contains("Master"))
                {
                    guyChar.spellLevel.text = "III";
                }
                guyChar.type.SetActive(true);
                if (guyChar.isTaken)
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(0.232556f, 0.735849f, 0.247813f);
                }
                else
                {
                    guyChar.taken.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                if (m.types.Contains("Sorcery"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.sorc;
                }
                else if (m.types.Contains("Blessing"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.bless;
                }
                else if (m.types.Contains("Hex"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.hex;
                }
                else if (m.types.Contains("Divination"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.div;
                }
                else if (m.types.Contains("Illusion"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.ilu;
                }
                else if (m.types.Contains("Conjuration"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.con;
                }
                else if (m.types.Contains("Battle Magic"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.batt;
                }
                else if (m.types.Contains("Psionics"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.psi;
                }
                else if (m.types.Contains("Geomancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.geo;
                }
                else if (m.types.Contains("Pyromancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.fire;
                }
                else if (m.types.Contains("Hydromancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.water;
                }
                else if (m.types.Contains("Aeromancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.air;
                }
                else if (m.types.Contains("Necromancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.necro;
                }
                else if (m.types.Contains("Hemomancy"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.blood;
                }
                else if (m.types.Contains("Holy Magic"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.holy;
                }
                else if (m.types.Contains("Green Magic"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.green;
                }
                else if (m.types.Contains("Warp Magic"))
                {
                    guyChar.type.GetComponent<Image>().sprite = guyChar.warp;
                }
                spawnedGuys.Add(guy);
                guyChar.sp = m;
            }
        }
    }
    public bool Check(Maneuver m)
    {
        bool canBeTaken = (m.types.Contains("Simple") || (m.types.Contains("Greater") && cb.character.level>=4) || (m.types.Contains("Master") && cb.character.level >= 8));

        return canBeTaken;
    }
    public void Show(Maneuver m, Spell sp)
    {
        foreach (GameObject go in spawnedOps)
        {
            GameObject.Destroy(go);
        }
        Debug.Log("Show2");
        GameObject.Destroy(spawnedDisplay);
        if (sp.manName != "")
        {
            Debug.Log("elseSpell2");
            spawnedDisplay = Instantiate(spellDescPrefab, spellDisplay);
            var guyChar = spawnedDisplay.GetComponent<CharCreatorFeature>();
            guyChar.nameDisplay.text = sp.manName;
            foreach (string type in sp.types)
            {
                guyChar.sizeAndClade.text += type +" ";
            }
            foreach (Spell op in sp.spellOptions)
            {
                var opDis = Instantiate(spellOpPrefab, guyChar.spellOptions);
                spawnedOps.Add(opDis);
                var opDisChar = opDis.GetComponent<CharCreatorFeature>();
                opDisChar.nameDisplay.text = op.manName;
                foreach (string type in op.types)
                {
                    opDisChar.sizeAndClade.text += type +" ";
                }
                if (op.APCost == 0)
                {
                    opDisChar.APCost.text = "";
                }
                else
                {
                    opDisChar.APCost.text = "<b>AP Cost: </b> " + op.APCost.ToString();
                }
                if (op.staminaCost == 0)
                {
                    opDisChar.staminaCost.text = "";
                }
                else
                {
                    opDisChar.staminaCost.text = "<b>Stamina Cost: </b> " + op.staminaCost.ToString();
                }
                if (op.manaCost == 0)
                {
                    opDisChar.manaCost.text = "";
                }
                else
                {
                    opDisChar.manaCost.text = "<b>Magic Cost: </b> " + op.manaCost.ToString();
                }
                opDisChar.range.text = "<b>Range: </b> " + op.range;
                opDisChar.catalyst.text = "<b>Catalyst: </b> " + op.catalyst;
                if (op.turns != 0)
                {
                    opDisChar.duration.text = "<b>Duration: </b> " + op.turns;
                }
                else if (op.min != 0)
                {
                    opDisChar.duration.text = "<b>Duration: </b> " + op.min;
                }
                else
                {
                    opDisChar.duration.text = "<b>Duration: </b> " + op.hours;
                }
                opDisChar.desc.text = op.desc;
            }
        }
        else
        {
            Debug.Log("ifMan2");
            spawnedDisplay = Instantiate(manDescPrefab, spellDisplay);
            var guyChar = spawnedDisplay.GetComponent<CharCreatorFeature>();
            guyChar.nameDisplay.text = m.manName;
            foreach (string type in m.types)
            {
                guyChar.sizeAndClade.text += type +" ";
            }
            if (m.APCost == 0)
            {
                guyChar.APCost.text = "";
            }
            else
            {
                guyChar.APCost.text = "<b>AP Cost: </b> " + m.APCost.ToString();
            }
            if (m.staminaCost == 0)
            {
                guyChar.staminaCost.text = "";
            }
            else
            {
                guyChar.staminaCost.text = "<b>Stamina Cost: </b> " + m.staminaCost.ToString();
            }
            guyChar.range.text = "<b>Range: </b> " + m.range;
            guyChar.desc.text = m.desc; 
        }
    }
    private void Update()
    {
        talent.text = cb.character.talent.ToString();
        foreach(var guy in spawnedGuys)
        {
            if (guy != null)
            {
                var guyChar = guy.GetComponent<SpellBar>();
                if (guyChar.isTaken || spellCount.text == talent.text)
                {
                    Debug.Log("Green grey");
                    guyChar.greenButton.interactable = false;
                }
                else
                {
                    Debug.Log("Green else");
                    guyChar.greenButton.interactable = true;
                }
                if (!guyChar.isTaken)
                {
                    Debug.Log("Red grey");
                    guyChar.redButton.interactable = false;
                }
                else
                {
                    Debug.Log("Red else");
                    guyChar.redButton.interactable = true;
                }
            }
        }
    }
}
