using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupState_Hunting : GroupState
{
    public GameObject target;

    public override void Enter()
    {
        base.Enter();

        SetStateDescriptor("Hunting");

        if (target.GetComponent<Group_BanditGang>())
        {
            SetStateDescriptor("Hunting Bandits");
        }

        List<GameObject> localMembers = groupLogic.GetMembersAtLeader();
        foreach (GameObject member in localMembers)
        {
            member.GetComponent<CreatureLogicHandler>().TakeAction_Search(target);
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
