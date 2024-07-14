using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_AdventuringParty : GroupHandler
{
    public override void Start()
    {
        base.Start();

        groupDescriptor = "Adventuring Party";
    }

    #region Group Management
    public void DetermineLeader()
    {
        List<GameObject> theseMembers = GetMembers();
        //List<GameObject> theseNonLeaderMembers = theseMembers;

        
        GameObject bestLeader = null;
        int highestValue = 0;

        foreach (GameObject member in theseMembers)
        {
            //Debug.Log("member is " + member.name);
            CharacterData characterData = member.GetComponent<CharacterData>();
            int combinedValue = characterData.statStrategy + characterData.statPersonality;

            if (combinedValue >= highestValue)
            {
                bestLeader = member;
                highestValue = combinedValue;
            }
        }

        // Set the leader and update the nonLeaderMembers list
        SetLeader(bestLeader);
        //theseNonLeaderMembers.Remove(bestLeader);
    }

    public override void Join(GameObject newMember)
    {
        base.Join(newMember);

        DetermineLeader();
    }

    public override void Leave(GameObject formerMember)
    {
        base.Leave(formerMember);

        DetermineLeader();
    }
    #endregion

    #region Combat Logic
    public override void GroupAction_WinCombat(GameObject loser)
    {
        base.GroupAction_WinCombat(loser);

        if (currentPlan != null)
        {
            currentPlan.OnCombatWon(loser);
        }
    }

    public override void GroupAction_LoseCombat(GameObject winner)
    {
        base.GroupAction_LoseCombat(winner);

        if (currentPlan != null)
        {
            currentPlan.OnCombatLost(winner);
        }
    }
    #endregion
}
