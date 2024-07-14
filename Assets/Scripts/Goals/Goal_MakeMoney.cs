using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_MakeMoney : Goal, IGoal
{
    private int desiredGold = 50;

    void Start()
    {

    }

    public void PerformGoal()
    {
        Plan currentPlan = goalHandler.GetPlan();
        
        if (CheckConditions())
        {
            gameObject.GetComponent<CharacterGoalHandler>().CompleteGoal();
        }
        else if (currentPlan == null)
        {
            GetNewPlan();
        }
        else if (currentPlan != null)
        {
            currentPlan.PerformPlan();
        }
    }

    public bool CheckConditions()
    {
        if (gameObject.GetComponent<CreatureInventory>().myGold < desiredGold) 
        {
            return false;
        }
        else { return true; }
    }

    public void GetNewPlan()
    {
        Plan currentPlan = goalHandler.GetPlan();
        GameObject thisLocation = gameObject.GetComponent<CharacterData>().location;

        //if just starting this goal, look for work locally
        if (currentPlan == null)
        {
            goalHandler.PlanAction_LookForWork(thisLocation);
        }
        //if no work found, roll a die to see if you look for work nearby or turn to banditry
        else if (currentPlan is Plan_LookForWork &&
                                Dice.Instance.Rolld(100) > Tables.Instance.BASE_GOAL_VALUES.Banditry_Chance)
        {
            goalHandler.PlanAction_LookForWork(thisLocation.GetComponent<ProvinceDataHandler>().GetRandomExit());

            /*currentPlan = gameObject.AddComponent<Plan_LookForWork>();
            Plan_LookForWork plan = currentPlan as Plan_LookForWork;
            GameObject thisLoc = gameObject.GetComponent<CharacterData>().location;
            GameObject newLoc = thisLoc.GetComponent<ProvinceDataHandler>().GetRandomExit();
            plan.SetTargetLocation(newLoc);*/
        }
        else
        {
            goalHandler.PlanAction_Banditry();
        }
    }
}
