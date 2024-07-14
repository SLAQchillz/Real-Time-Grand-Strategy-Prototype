using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan_RestoreOrder : Plan
{
    public GameObject theProvince { get; private set; }
    public GameObject theBandits { get; private set; }
    public GameObject theParty { get; private set; }

    public List<GameObject> recruitedAdventurers = new List<GameObject>();

    private ProvinceData provinceData;
    private ProvinceCharacterHandler characterHandler;
    public override void Start()
    {
        base.Start();

        SetPlanDescriptor("Restoring Order");

        theProvince = GetComponent<NobleData>().provinceRuled;
        provinceData = theProvince.GetComponent<ProvinceData>();
        characterHandler = theProvince.GetComponent<ProvinceCharacterHandler>();

        GetBandits();
        theParty = null;

        PerformPlan();
    }

    void GetBandits()
    {
        theBandits = characterHandler.GetBanditGangHere();
    }

    public override void PerformPlan()
    {
        base.PerformPlan();

        //check to see if bandits still exist; if not, disband the party if it exists and end the plan
        if (!provinceData.hasBandits)
        {
            if (theParty != null)
            {
                GroupHandler partyLogic = theParty.GetComponent<GroupHandler>();
                
                for (int i = recruitedAdventurers.Count - 1; i >= 0; i--)
                {
                    GameObject adventurer = recruitedAdventurers[i];
                    recruitedAdventurers.RemoveAt(i);
                    CreatureLogicHandler logicHandler = adventurer.GetComponent<CreatureLogicHandler>();
                    logicHandler.TakeAction_EndVassalQuest();
                }

                partyLogic.GroupAction_Disband();
            }

            EndPlan();
            return;
        }

        //recruit any adventurers here looking for work
        RecruitAdventurers();
        

        if (theParty == null &&
            CountEligibleCharacters() >= 4)
        {
            Debug.Log("Eligible characters is " + CountEligibleCharacters());
            FormParty();
        }
    }

    void RecruitAdventurers()
    {
        foreach (GameObject character in characterHandler.charactersHere)
        {
            CreatureLogicHandler characterLogic = character.GetComponent<CreatureLogicHandler>();
            if (characterLogic.currentState is CharacterState_LookingForWork &&
                characterLogic.hasLord == false)
            {
                logicHandler.TakeAction_BecomeLordTo(character);
                characterLogic.TakeAction_AwaitOrders();
                recruitedAdventurers.Add(character);

                if (theParty != null)
                {
                    theParty.GetComponent<GroupHandler>().Join(character);
                }
            }
        }
    }

    void FormParty()
    {
        List<GameObject> newPartyMembers = new List<GameObject>();
        foreach (GameObject vassal in logicHandler.myVassals)
        {
            CreatureLogicHandler vassalLogic = vassal.GetComponent<CreatureLogicHandler>();
            if (vassalLogic.currentState is CharacterState_AwaitingOrders &&
                vassalLogic.inGroup == false)
            {
                newPartyMembers.Add(vassal);
            }
        }

        theParty = Maker_Group.Instance.SpawnAdventuringParty(newPartyMembers.ToArray());
        GroupHandler partyHandler = theParty.GetComponent<GroupHandler>();
        partyHandler.StartPlan_Hunting(theBandits, 50);
    }

    int CountEligibleCharacters()
    {
        int count = 0;
        foreach (GameObject character in characterHandler.charactersHere)
        {
            CreatureLogicHandler characterLogic = character.GetComponent<CreatureLogicHandler>();
            if (characterLogic.hasLord && logicHandler.myVassals.Contains(character) && characterLogic.currentState is CharacterState_AwaitingOrders)
            {
                count++;
            }
        }
        return count;
    }


}
