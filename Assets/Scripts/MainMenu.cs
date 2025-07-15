using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MainMenu : MonoBehaviour
{
    public SheetManager sheetManager;

    public GameObject charPrefab;
    public RectTransform parentObject;

    public GameObject featPrefab;

    public GameObject featSpecPrefab;
    public RectTransform parentSpecObject;

    public Repository repo;
    public GameObject menu;
    public GameObject settings;
    public GameObject creator;
    public GameObject marble;
    public GameObject background;
    public GameObject step1;
    public GameObject spec;
    public GameObject levelUp;
    public GameObject paths;
    public GameObject pathsLv;
    public GameObject features;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    public GameObject step5;
    public GameObject sheet;

    public Animator sheetAnimator;
    
    private int x = 0;
    private int y = 0;

    private int xf = 0;
    private int yf = 0;

    private Character character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("wesz這 w start");
        
        foreach (Character c in repo.allCharacters)
        {
            Debug.Log("wesz這 w foreach");
            if (c != null)
            {
                var guy = Instantiate(charPrefab, parentObject);
                var guyChar = guy.GetComponent<CharacterBar>();
                guyChar.character = c;
            }
        }
    }
    public void Close()
    {
        Application.Quit();
    }
    public void NewCharacter()
    {
        character = new Character();
        Step1();
    }
    public void Back()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        settings.SetActive(false);
        sheet.SetActive(false);
        features.SetActive(false);
        step1.SetActive(false);
        creator.SetActive(false);
        menu.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void Step1()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        marble.SetActive(true);
        paths.SetActive(false);
        features.SetActive(false);
        step2.SetActive(false);
        creator.SetActive(true);
        step1.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void ChooseSpec()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        marble.SetActive(true);
        paths.SetActive(false);
        features.SetActive(false);
        step2.SetActive(false);
        creator.SetActive(true);
        step1.SetActive(false);
        levelUp.SetActive(false);
        spec.SetActive(true);
        foreach (var feat in character.co.lineage.features) { 
            if(feat.subOptions != null)
            {
                var bar = Instantiate(featSpecPrefab, parentSpecObject);
                var barScript = bar.GetComponent<SpecFeature>();
                barScript.source.text = character.co.lineage.lineName;
                barScript.featName.text = feat.featName;
            }
        }
    }
    public void Step2()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step1.SetActive(false);
        features.SetActive(false);
        step3.SetActive(false);
        step2.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void ShowPaths()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        marble.SetActive(false);
        step1.SetActive(false);
        paths.SetActive(true);
        features.SetActive(false);
        step3.SetActive(false);
        step2.SetActive(false);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void ShowPathsLv()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        marble.SetActive(false);
        step1.SetActive(false);
        pathsLv.SetActive(true);
        features.SetActive(false);
        step3.SetActive(false);
        step2.SetActive(false);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void ShowFeatures()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        marble.SetActive(false);
        step1.SetActive(false);
        paths.SetActive(false);
        features.SetActive(true);
        step3.SetActive(false);
        step2.SetActive(false);
        levelUp.SetActive(false);
        spec.SetActive(false);
        Debug.Log("Wesz這 w metode");
        foreach (var feature in repo.features) 
        {
            Debug.Log("Wesz這 w foreach feature");
            if (feature.requiredFeatures==null && feature.requiredFeatures.All(element => character.co.features.Contains(element)))
            {
                Debug.Log("Wesz這 w if");
                var guy = Instantiate(charPrefab, parentObject);
                var guyChar = guy.GetComponent<Feature>();
                guyChar = feature;
                xf++;
                if (xf == 5)
                {
                    xf = 0;
                    yf++;
                }
            }
        }
    }
    public void Step3()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step2.SetActive(false);
        features.SetActive(false);
        step4.SetActive(false);
        step3.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void Step4()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step3.SetActive(false);
        features.SetActive(false);
        step5.SetActive(false);
        step4.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void Step5()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step4.SetActive(false);
        features.SetActive(false);
        step5.SetActive(true);
        levelUp.SetActive(false);
        spec.SetActive(false);
    }
    public void Finalize(CharacterBar character)
    {
        this.character = character.character;
        marble.SetActive(false);
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        features.SetActive(false);
        step5.SetActive(false);
        creator.SetActive(false);
        sheet.SetActive(true);
        Debug.Log(character.character);
        sheetManager.ShowSheet(character.character);
        levelUp.SetActive(false);
        spec.SetActive(false);
        repo.allCharacters.Add(character.character);
        var guy = Instantiate(charPrefab, parentObject);
        var guyChar = guy.GetComponent<Character>();
        guyChar = character.character;
        x++;
        if (x == 5)
        {
            x = 0;
            y++;
        }
        sheetAnimator.SetTrigger("Start");
    }
    public void ShowSheet(CharacterBar character)
    {
        marble.SetActive(false);
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        features.SetActive(false);
        step5.SetActive(false);
        creator.SetActive(false);
        sheet.SetActive(true);
        Debug.Log(character.character);
        sheetManager.ShowSheet(character.character);
        levelUp.SetActive(false);
        pathsLv.SetActive(false);
        spec.SetActive(false);
        this.character = character.character;
        sheetAnimator.SetTrigger("Start");
    }
    public void LevelUp()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        sheet.SetActive(false);
        menu.SetActive(false);
        marble.SetActive(false);
        features.SetActive(false);
        step2.SetActive(false);
        creator.SetActive(true);
        levelUp.SetActive(true);
        pathsLv.SetActive(false);
        spec.SetActive(false);
    }
    public void Settings()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        menu.SetActive(false);
        settings.SetActive(true);
    }
    public void Language(string lang)
    {
        if (lang == "english") { }
        if (lang == "polish") { }
    }
}
