using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_LookingForWork : CharacterState, ICharacterState
{
    public override void Enter(GameObject character)
    {
        base.Enter(character);

        //Debug.Log("LookingForWork state started");
        SetStateDescriptor("Looking for work");
    }

    public override void PerformState()
    {
        base.PerformState();
        
        //Debug.Log(thisCharacter.name + " is still looking for work");

        Plan_LookForWork plan = GetComponent<Plan_LookForWork>();
        if (plan != null && plan.daysLooking < plan.maxDays)
        {
            plan.daysLooking++;
        }
    }
}
