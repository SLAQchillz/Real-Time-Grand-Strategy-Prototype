using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Plan_LookForWork : Plan
{
    public int daysLooking = 0;
    public int maxDays = 6;
    public GameObject targetLocation { get; private set; }

    public override void Start()
    {
        base.Start();

        //Debug.Log("targetLocation is " + targetLocation);
        //Debug.Log("my location is " + data.location);
        SetPlanDescriptor("Locating Work");

        if (data.location == targetLocation)
        {
            logicHandler.TakeAction_LookForWork();
        }
        else
        {
            //Debug.Log("I need to go somewhere else");
            logicHandler.TakeAction_TravelTo(targetLocation);
        }
    }

    public override void PerformPlan()
    {
        base.PerformPlan();

        if (daysLooking == maxDays)
        {   
            gameObject.GetComponent<IGoal>().GetNewPlan();
            EndPlan();
        }
    }

    public void SetTargetLocation(GameObject loc)
    {
        targetLocation = loc;
    }

    public override void ReceiveStateDone(ICharacterState doneState)
    {
        base.ReceiveStateDone(doneState);

        if (doneState as CharacterState_Travelling)
        {
            logicHandler.TakeAction_LookForWork();
        }
    }
}
