using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureData : ThingData
{
    #region Variables Derived From Other Objects
    public Sprite myPortrait { get; private set; }
    #endregion

    #region Base Characteristic Variables
    public string BASE_SPECIES;
    public CharacterSize BASE_SIZE;
    public bool IS_SENTIENT;
    public bool IS_SAPIENT;
    #endregion

    #region Individual Characteristics Derived From Bases
    public string mySpecies { get; private set; }
    public CharacterSize mySize { get; private set; }
    public bool isSentient { get; private set; }
    public bool isSapient { get; private set; }
    #endregion

    #region Individual Stats
    public int statPersonality { get; private set; }
    public int statUnarmed { get; private set; }
    public int statCunning { get; private set; }
    public int statWoodcraft { get; private set; }
    #endregion

    #region Individual Characteristic Variables
    public Gender myGender { get; private set; }
    public int myAge { get; private set; }
    #endregion

    #region Init
    public override void Start()
    {
        base.Start();

    }

    public override void InitToBaseCharacteristics()
    {
        base.InitToBaseCharacteristics();

        //if (mySpecies == null) { mySpecies = BASE_SPECIES; }
        mySpecies = BASE_SPECIES;
        mySize = BASE_SIZE;
        isSentient = IS_SENTIENT;
        isSapient = IS_SAPIENT;
    }
    #endregion


    #region Characteristic Setting
    public void SetPortrait(Sprite newPortrait)
    {
        myPortrait = newPortrait;
    }

    public void SetSpecies(string newSpecies)
    {
        //Debug.Log("newSpecies variable passed in with value of: " + newSpecies);
        mySpecies = newSpecies;
    }
    public void SetSize(CharacterSize newSize)
    {
        mySize = newSize;
    }

    public void SetIsSentient(bool newBool)
    {
        isSentient = newBool;
    }

    public void SetIsSapient(bool newBool)
    {
        isSapient = newBool;
    }

    public void SetGender (Gender newGender)
    {
        myGender = newGender;
    }

    public void SetAge(int newAge) 
    {
        myAge = newAge;
    }
    #endregion

    #region Stat Setting
    public void SetPersonality(int newPersonality) { statPersonality = newPersonality; }

    public void SetUnarmed(int newUnarmed) { statUnarmed = newUnarmed; }
    public void SetCunning (int newCunning) { statCunning = newCunning; }
    public void SetWoodcraft(int newWoodcraft) { statWoodcraft = newWoodcraft; }
    #endregion


    #region Stat Modifying
    public virtual void ApplyStatMods(StatMods mods)
    {
        statPersonality += mods.PersonalityMod;
        statUnarmed += mods.UnarmedMod;
        statCunning += mods.CunningMod;
        statWoodcraft += mods.WoodcraftMod;
    }
    #endregion
}
