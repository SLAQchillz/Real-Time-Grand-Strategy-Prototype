using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Travelling : CharacterState, ICharacterState
{
    public GameObject currentLocation { get; private set; }
    public GameObject targetLocation { get; private set; }

    private int travelTime = 3;
    private int timeTraveled = 0;

    public override void Enter(GameObject character)
    {
        base.Enter(character);

        SetStateDescriptor("Traveling");
    }

    public void SetTargetLocation(GameObject newLoc)
    {
        targetLocation = newLoc;
    }

    public override void PerformState()
    {
        base.PerformState();

        if (timeTraveled >= travelTime)
        {
            Arrive();
        }
        else
        {
            timeTraveled++;
        }
    }

    public virtual void Arrive()
    {
        CharacterDataHandler dataHandler = GetComponent<CharacterDataHandler>();
        dataHandler.ChangeLocation(targetLocation);
        IPlan plan = GetComponent<IPlan>();
        if (plan != null)
        {
            plan.ReceiveStateDone(this);
        }
    }
}
