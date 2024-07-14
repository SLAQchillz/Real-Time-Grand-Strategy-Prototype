using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class CharacterMaker : MonoBehaviour
{
    #region GameObject Definitions
    //the Prefab we are working with
    public GameObject CharacterPrefab;

    //info panel 
    public TextMeshProUGUI prefabNameField;
    public TextMeshProUGUI characterCountField;
    public TextMeshProUGUI adventurerCountField;

    //character options
    public TMP_Dropdown characterClassDropdown;
    public TMP_Dropdown characterRaceDropdown;
    public TMP_Dropdown provinceDropdown;

    //base data SOs
    public StatMods fighterMods;
    public StatMods thiefMods;
    public StatMods clericMods;
    #endregion

    #region Selected Option Variables
    private CharacterClass selectedClass;
    private Species_Group_Adventurer selectedRace;

    private GameObject[] provinces;
    private GameObject selectedProvince;
    #endregion

    #region Init
    private void Start()
    {
        InitPanel();
        UpdatePanel();
    }

    void InitPanel()
    {
        InitCharacterClassDropdown();
        InitCharacterRaceDropdown();
        InitProvinceDropdown();
    }

    void InitCharacterClassDropdown()
    {
        // Get the names of the enum values
        var names = Enum.GetNames(typeof(CharacterClass));

        // Create a list of dropdown options from the names
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var name in names)
        {
            options.Add(new TMP_Dropdown.OptionData(name));
        }

        // Assign the options to the dropdown
        characterClassDropdown.options = options;

        // Register a callback for the onValueChanged event
        characterClassDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Initialize selectedValue to the first entry in the enum dynamically
        selectedClass = (CharacterClass)Enum.GetValues(typeof(CharacterClass)).GetValue(0);
    }

    void InitCharacterRaceDropdown()
    {
        var names = Enum.GetNames(typeof(Species_Group_Adventurer));

        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var name in names)
        {
            options.Add(new TMP_Dropdown.OptionData(name));
        }

        characterRaceDropdown.options = options;

        characterRaceDropdown.onValueChanged.AddListener(OnRaceDropdownValueChanged);

        selectedRace = (Species_Group_Adventurer)Enum.GetValues(typeof(Species_Group_Adventurer)).GetValue(0);
    }

    void InitProvinceDropdown()
    {
        provinces = GameObject.FindGameObjectsWithTag("Province");

        var options = new List<TMP_Dropdown.OptionData>();
        foreach (GameObject province in provinces)
        {
            options.Add(new TMP_Dropdown.OptionData(province.name));
        }

        provinceDropdown.options = options;

        provinceDropdown.onValueChanged.AddListener(OnProvinceDropdownValueChanged);

        selectedProvince = provinces[0];
    }
    #endregion

    #region Update Panel
    public void UpdatePanel()
    {
        characterCountField.text = Character.characterCount.ToString();
        adventurerCountField.text = Adventurer.adventurerCount.ToString();

        prefabNameField.text = CharacterPrefab.name;
    }

    IEnumerator UpdatePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UpdatePanel();
    }
    #endregion

    #region Setting Property Values
    void OnDropdownValueChanged(int index)
    {
        // Get the selected enum value
        selectedClass = (CharacterClass)index;
        //Debug.Log("Selected value: " + selectedClass);
    }

    void OnRaceDropdownValueChanged(int index)
    {
        selectedRace = (Species_Group_Adventurer)index;
        //Debug.Log("Selected value: " + selectedRace);
    }

    void OnProvinceDropdownValueChanged(int index)
    {
        selectedProvince = provinces[index];
    }
    #endregion

    #region Making the Character
    public void MakeCharacter()
    {
        //Make the character from Prefab
        GameObject newCharacter = Instantiate(CharacterPrefab);

        //Get Components
        AdventurerData ad = newCharacter.GetComponent<AdventurerData>();
        CharacterDataHandler cdh = newCharacter.GetComponent<CharacterDataHandler>();
        CreatureInventory ci = newCharacter.GetComponent<CreatureInventory>();

        //Init character
        cdh.InitNewCreature();

        //Set character class
        ad.SetCharacterClass(selectedClass);
        switch (selectedClass)
        {
            case (CharacterClass.Fighter):
                ad.ApplyStatMods(fighterMods); 
                break;
            case (CharacterClass.Thief):
                ad.ApplyStatMods(thiefMods);
                break;
            case (CharacterClass.Cleric): 
                ad.ApplyStatMods(clericMods);
                break;
            default: Debug.Log("Character Class assignment error"); break;
        }

        //Set race
        string species = selectedRace.ToString();
        ad.SetSpecies(species);

        //Determine and set random gender
        int rand = UnityEngine.Random.Range(0, 2);
        Gender newGender = new Gender();
        if (rand == 0) { newGender = Gender.Male; }
        else if (rand == 1) { newGender = Gender.Female; }
        ad.SetGender(newGender);

        //Get and set random name from table

        ad.SetName(Tables.Instance.GetRandomName(newGender, species));

        //Get and set a random portrait from table
        ad.SetPortrait(Tables.Instance.GetRandomPortrait(ad.myGender, ad.mySpecies));

        //give 15 gold to the character
        cdh.AdjustGold(15);

        //Move character to determined location
        cdh.ChangeLocation(selectedProvince);
        newCharacter.name = (ad.myTypeSingular + "(" + ad.uniqueName + ")");

        //Update Maker panel
        StartCoroutine(UpdatePanelAfterDelay(0.1f));
    }
    #endregion

}
