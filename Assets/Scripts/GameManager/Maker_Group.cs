using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker_Group : Maker
{
    public static Maker_Group Instance;
    
    public GameObject BANDIT_GANG;
    public GameObject ADVENTURING_PARTY;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnGang(params GameObject[] characters)
    {
        GameObject newGang = Instantiate(BANDIT_GANG);
        Group_BanditGang gangLogic = newGang.GetComponent<Group_BanditGang>();
        foreach (GameObject character in characters)
        {
            //Debug.Log(character.name + " is joining the bandit gang");
            gangLogic.Join(character);
        }
        gangLogic.DetermineLeader();
        gangLogic.GroupAction_Banditry();
    }

    public GameObject SpawnAdventuringParty(params GameObject[] characters)
    {
        GameObject newParty = Instantiate(ADVENTURING_PARTY);
        Group_AdventuringParty partyLogic = newParty.GetComponent<Group_AdventuringParty>();
        foreach (GameObject character in characters)
        {
            partyLogic.Join(character);
        }

        partyLogic.FormGroup();
        return newParty;
    }
}
