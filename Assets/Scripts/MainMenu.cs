using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SheetManager sheetManager;
    public GameObject menu;
    public GameObject creator;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    public GameObject step5;
    public GameObject sheet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Close()
    {
        Application.Quit();
    }
    public void NewCharacter()
    {
        menu.SetActive(false);
        step2.SetActive(false);
        creator.SetActive(true);
        step1.SetActive(true);
    }
    public void Back()
    {
        sheet.SetActive(false);
        step1.SetActive(false);
        creator.SetActive(false);
        menu.SetActive(true);        
    }
    public void Step2()
    {
        step1.SetActive(false);
        step3.SetActive(false);
        step2.SetActive(true);
    }
    public void Step3()
    {
        step2.SetActive(false);
        step4.SetActive(false);
        step3.SetActive(true);
    }
    public void Step4()
    {
        step3.SetActive(false);
        step5.SetActive(false);
        step4.SetActive(true);
    }
    public void Step5()
    {
        step4.SetActive(false);
        step5.SetActive(true);
    }
    public void Created()
    {
        step5.SetActive(false);
        creator.SetActive(false);
        sheet.SetActive(true);
    }
}
