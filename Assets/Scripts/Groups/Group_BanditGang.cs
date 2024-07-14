using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_BanditGang : GroupHandler
{
    public override void Start()
    {
        base.Start();

        groupDescriptor = "Bandit Gang";
    }

    public override void FormGroup()
    {
        base.FormGroup();

        //Debug.Log("Bandit Gang formed at " + location);
    }

    public void DetermineLeader()
    {
        GameObject bestBandit = null;
        int highestValue = 0;

        foreach (GameObject member in GetMembers())
        {
            //Debug.Log("member is " + member.name);
            CharacterData characterData = member.GetComponent<CharacterData>();
            int combinedValue = characterData.statCunning + characterData.statPersonality;

            if (combinedValue >= highestValue)
            {
                bestBandit = member;
                highestValue = combinedValue;
            }
        }

        // Set the leader and update the nonLeaderMembers list
        SetLeader(bestBandit);
        nonLeaderMembers.Remove(bestBandit);

        // Call the FormGroup method
        FormGroup();
    }

    public override void DisbandGroup()
    {
        foreach (GameObject member in GetMembers())
        {
            CreatureLogicHandler logicHandler = member.GetComponent<CreatureLogicHandler>();
            logicHandler.TakeAction_Flee(null);
        }

        base.DisbandGroup();
    }

    public override void GroupAction_LoseCombat(GameObject winner)
    {
        base.GroupAction_LoseCombat(winner);

        DisbandGroup();
    }
}
