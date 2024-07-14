using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupState_AwaitingOrders : GroupState
{
    public override void Enter()
    {
        base.Enter();

        SetStateDescriptor("Awaiting Orders");

        List<GameObject> localMembers = groupLogic.GetMembersAtLeader();
        foreach (GameObject member in localMembers)
        {
            member.GetComponent<CreatureLogicHandler>().TakeAction_AwaitOrders();
        }
    }
}
