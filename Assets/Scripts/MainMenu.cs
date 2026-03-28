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
    public GameObject paths;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    public GameObject step5;
    public GameObject sheet;

    public UnityEngine.UI.Button step2arrow;

    public ForgeScript forge;

    public Animator sheetAnimator;

    public CharacterBar cb;
    public CharCreator cc;

    private int x = 0;
    private int y = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        repo.allCharacters = FileHandler.ReadFromJson<Character>("characters.json");
        repo.traits = FileHandler.ReadFromJson<Trait>("traits.json");
        repo.legendaries = FileHandler.ReadFromJson<LegFeature>("legendaries.json");
        repo.attunements = FileHandler.ReadFromJson<Element>("attunements.json");
        repo.signs = FileHandler.ReadFromJson<StarSign>("starSigns.json");
        repo.backs = FileHandler.ReadFromJson<Background>("backgrounds.json");
        //repo.cultures = FileHandler.ReadFromJson<Culture>("cultures.json");
        repo.lineages = FileHandler.ReadFromJson<Lineage>("lineages.json");
        //repo.paths = FileHandler.ReadFromJson<Path>("paths.json");
        //repo.items = FileHandler.ReadFromJson<Item>("items.json");
        repo.armors = FileHandler.ReadFromJson<Armor>("armors.json");
        repo.consumables = FileHandler.ReadFromJson<Consumable>("consumables.json");
        repo.weapons = FileHandler.ReadFromJson<Weapon>("weapons.json");
        repo.focuses = FileHandler.ReadFromJson<Focus>("catalysts.json");
        repo.spells = FileHandler.ReadFromJson<Spell>("spells.json");
        repo.maneuvers = FileHandler.ReadFromJson<Maneuver>("maneuvers.json");

        foreach (Character c in repo.allCharacters)
        {
            Debug.Log("wesz這 w foreach");
            if (c != null)
            {
                var guy = Instantiate(charPrefab, parentObject);
                var guyChar = guy.GetComponent<CharacterBar>();
                guyChar.character = c;
                guyChar.namePlace.text = c.charName;
            }
        }
    }
    public void Close()
    {
        FileHandler.SaveToJson<Character>(repo.allCharacters, "characters.json");
        FileHandler.SaveToJson<Trait>(repo.traits, "traits.json");
        FileHandler.SaveToJson<LegFeature>(repo.legendaries, "legendaries.json");
        FileHandler.SaveToJson<Element>(repo.attunements, "attunements.json");
        FileHandler.SaveToJson<StarSign>(repo.signs, "starSigns.json");
        FileHandler.SaveToJson<Background>(repo.backs, "backgrounds.json");
        FileHandler.SaveToJson<Culture>(repo.cultures, "cultures.json");
        FileHandler.SaveToJson<Lineage>(repo.lineages, "lineages.json");
        FileHandler.SaveToJson<Path>(repo.paths, "paths.json");
        FileHandler.SaveToJson<Item>(repo.items, "items.json");
        FileHandler.SaveToJson<Armor>(repo.armors, "armors.json");
        FileHandler.SaveToJson<Consumable>(repo.consumables, "consumables.json");
        FileHandler.SaveToJson<Weapon>(repo.weapons, "weapons.json");
        FileHandler.SaveToJson<Focus>(repo.focuses, "catalysts.json");
        FileHandler.SaveToJson<Spell>(repo.spells, "spells.json");
        FileHandler.SaveToJson<Maneuver>(repo.maneuvers, "maneuvers.json");
        Application.Quit();
    }
    public void NewCharacter()
    {
        CharCreator cc=creator.GetComponent<CharCreator>();
        cc.StartCreating();
        Step1();
    }
    public void Back()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        settings.SetActive(false);
        sheet.SetActive(false);
        step1.SetActive(false);
        creator.SetActive(false);
        menu.SetActive(true);
        spec.SetActive(false);
    }
    public void Step1()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        marble.SetActive(true);
        paths.SetActive(false);
        step2.SetActive(false);
        creator.SetActive(true);
        step1.SetActive(true);
        spec.SetActive(false);
    }    
    public void Step2()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step1.SetActive(false);
        step3.SetActive(false);
        step2.SetActive(true);
        spec.SetActive(false);
    }
    public void ShowPaths()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        marble.SetActive(false);
        step1.SetActive(false);
        paths.SetActive(true);
        step3.SetActive(false);
        step2.SetActive(false);
        spec.SetActive(false);
        var cc = creator.GetComponent<CharCreator>();
        cc.displayed = "path";
        forge.Spawn();
    }
    public void ShowFeatures()
    {
        background.GetComponent<Image>().color = new Color32(0, 31, 138, 255);
        marble.SetActive(false);
        step1.SetActive(false);
        paths.SetActive(true);
        step3.SetActive(false);
        step2.SetActive(false);
        spec.SetActive(false);
        Debug.Log("Wesz這 w metode");
        var cc = creator.GetComponent<CharCreator>();
        cc.displayed = "feat";
        forge.SpawnFeatures();
        //foreach (var feature in repo.features) 
        //{
        //    Debug.Log("Wesz這 w foreach feature");
        //if (feature.requiredFeatures==null && feature.requiredFeatures.All(element => character.co.features.Contains(element)))
        //{
        //    Debug.Log("Wesz這 w if");
        //    var guy = Instantiate(charPrefab, parentObject);
        //    var guyChar = guy.GetComponent<Feature>();
        //    guyChar = feature;
        //    xf++;
        //    if (xf == 5)
        //    {
        //        xf = 0;
        //        yf++;
        //    }
        //}
        //}
    }
    public void Step3()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step2.SetActive(false);
        step4.SetActive(false);
        step3.SetActive(true);
        spec.SetActive(false);
        var IC = step3.GetComponent<InventoryChoosing>();
        IC.Spawn();
    }
    public void Step4()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step3.SetActive(false);
        step5.SetActive(false);
        step4.SetActive(true);
        spec.SetActive(false);
        var SC = step4.GetComponent<SpellsChoice>();
        SC.Spawn();
    }
    public void Step5()
    {
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        marble.SetActive(true);
        step4.SetActive(false);
        step5.SetActive(true);
        spec.SetActive(false);
    }
    public void Finalize(CharacterBar character)
    {
        marble.SetActive(false);
        background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        menu.SetActive(false);
        step5.SetActive(false);
        creator.SetActive(false);
        sheet.SetActive(true);
        Debug.Log(character.character);
        sheetManager.ShowSheet(character.character);
        spec.SetActive(false);
        repo.allCharacters.Add(character.character);
        var guy = Instantiate(charPrefab, parentObject);
        var guyChar = guy.GetComponent<CharacterBar>();
        guyChar.character = character.character;
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
        step5.SetActive(false);
        creator.SetActive(false);
        sheet.SetActive(true);
        Debug.Log(character.character);
        sheetManager.ShowSheet(character.character);
        spec.SetActive(false);
        sheetAnimator.SetTrigger("Start");
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
    private void Update()
    {
        if (cb.character.lineage.lineName == null || cb.character.culture.cultName == null || cb.character.starsign.signName == null || cb.character.element.elName == null || cb.character.background.backName == null ||
            cc.specFeats.Any(item => item.isNone))
        {
            step2arrow.interactable = false;
        }
        else
        {
            step2arrow.interactable = true;
        }
    }
}
