using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupState_Banditry : GroupState
{
    public override void Enter()
    {
        base.Enter();

        SetStateDescriptor("Banditry");

        List<GameObject> localMembers = groupLogic.GetMembersAtLeader();
        foreach (GameObject member in localMembers)
        {
            member.GetComponent<CreatureLogicHandler>().TakeAction_Banditry();
        }
    }

    public override void PerformState()
    {
        base.PerformState();

        List<GameObject> localMembers = groupLogic.GetMembersAtLeader();
        foreach (GameObject member in localMembers)
        {
            if (member.GetComponent<CreatureLogicHandler>().currentState is not CharacterState_Banditry)
            {
                member.GetComponent<CreatureLogicHandler>().TakeAction_Banditry();
            }
        }
    }
}
