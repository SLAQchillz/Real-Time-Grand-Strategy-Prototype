using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoPanel : MonoBehaviour
{
    public GameObject currentCharacter { get; private set; }

    public Image portraitImage;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI typeField;
    public TextMeshProUGUI classField;
    public TextMeshProUGUI raceField;
    public TextMeshProUGUI genderField;
    public TextMeshProUGUI locationField;
    public TextMeshProUGUI stateField;
    public TextMeshProUGUI goalField;
    public TextMeshProUGUI planField;
    public TextMeshProUGUI goldField;

    public void OpenPanel(GameObject character)
    {
        currentCharacter = character;
        UpdatePanel();
    }
    
    public void UpdatePanel()
    {
        CharacterData cd = currentCharacter.GetComponent<CharacterData>();
        CreatureInventory ci = currentCharacter.GetComponent<CreatureInventory>();
        CreatureLogicHandler clh = currentCharacter.GetComponent<CreatureLogicHandler>();

        nameField.text = cd.uniqueName;
        typeField.text = cd.myCharacterType.ToString();
        if (cd.myCharacterType == CharacterType.Adventurer)
        {
            classField.text = currentCharacter.GetComponent<AdventurerData>().myClass.ToString();
        }
        else { classField.text = "None"; }
        raceField.text = cd.mySpecies.ToString();
        genderField.text = cd.myGender.ToString();
        locationField.text = cd.location.name;
        stateField.text = clh.GetStateDescriptor();
        planField.text = clh.GetPlanDescriptor();
        //goalField.text = currentCharacter.GetComponent<CharacterGoalHandler>().myGoal.ToString();
        goldField.text = ci.myGold.ToString();
        portraitImage.sprite = cd.myPortrait;
    }
}
