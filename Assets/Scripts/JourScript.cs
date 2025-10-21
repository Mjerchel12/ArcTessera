using System;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class JourScript : MonoBehaviour
{
    public CharacterBar character;
    public TMP_InputField inputApp;
    public TMP_InputField inputPer;
    public TMP_InputField inputBack;
    public TMP_InputField inputGoal;
    public TMP_InputField inputBond;
    public TMP_InputField inputFlaw;
    public TMP_InputField inputFaith;
    public TMP_InputField inputSex;
    public TMP_InputField inputTribe;
    public TMP_InputField inputState;
    public TMP_InputField inputTown;
    public TMP_InputField inputAge;
    public void SetAppearance()
    {
        character.character.appearance = inputApp.text;
    }
    public void SetPer()
    {
        character.character.charTraits = inputPer.text;
    }
    public void SetBack()
    {
        character.character.backstory = inputBack.text;
    }
    public void SetGoal()
    {
        character.character.goals = inputGoal.text;
    }
    public void SetBond()
    {
        character.character.bonds = inputBond.text;
    }
    public void SetFlaw()
    {
        character.character.flaws = inputFlaw.text;
    }
    public void SetFaith()
    {
        character.character.faith = inputFaith.text;
    }
    public void SetSex()
    {
        character.character.genderIdentity = inputSex.text;
    }
    public void SetTribe()
    {
        character.character.ethnicity = inputTribe.text;
    }
    public void SetState()
    {
        character.character.nationality = inputState.text;
    }
    public void SetTown()
    {
        character.character.homeTown = inputTown.text;
    }
    public void SetAge()
    {
        character.character.age = Convert.ToByte(inputAge.text);
    }
}
