using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker_Noble : Maker
{
    public static Maker_Noble Instance;

    public GameObject NOBLE;

    public StatMods NOBLE_MODS;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject SpawnNoble()
    {
        //create the noble
        GameObject newNoble = Instantiate(NOBLE);

        //get references to components
        NobleData data = newNoble.GetComponent<NobleData>();
        NobleDataHandler dataHandler = newNoble.GetComponent<NobleDataHandler>();
        CreatureInventory inventory = newNoble.GetComponent<CreatureInventory>();

        //init the new character
        dataHandler.InitNewCreature();

        //apply noble statmods
        data.ApplyStatMods(NOBLE_MODS);

        //set race
        data.SetSpecies("Human");

        //get and set random gender
        Gender randGender = Tables.Instance.GetRandomGender();
        data.SetGender(randGender);

        //get and set random name
        string randName = Tables.Instance.GetRandomName(data.myGender, data.mySpecies);
        data.SetName(randName);

        //get and set random portrait
        Sprite randPortrait = Tables.Instance.GetNoblePortrait(data.myGender, data.mySpecies);
        data.SetPortrait(randPortrait);

        //give 200 gold
        dataHandler.AdjustGold(200);

        //Make GameObject name useful
        newNoble.name = data.myTypeSingular + "(" + data.uniqueName + ")";

        return newNoble;
    }

    public void GenerateNobleForProvince(GameObject province)
    {
        GameObject newNoble = SpawnNoble();
        NobleDataHandler dataHandler = newNoble.GetComponent<NobleDataHandler>();
        dataHandler.AppointRuler(province);
        dataHandler.ChangeLocation(province);
    }

    public void PopulateNobles()
    {
        GameObject[] provinces = GameObject.FindGameObjectsWithTag("Province");
        foreach (GameObject province in provinces)
        {
            GenerateNobleForProvince (province);
        }
    }
}
