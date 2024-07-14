using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGoalHandler : GoalHandler<CharacterData, CharacterLogicHandler, CreatureInventory>
{
    public IGoal myGoal { get; private set; }
    private IPlan myPlan;

    #region
    public override void Awake()
    {
        base.Awake();

        InitReferences();
    }

    public virtual void InitReferences()
    {
        myGoal = null;
        myPlan = null;
    }
    #endregion

    public virtual void Start()
    {
        DetermineNewGoal();
    }

    public virtual void DetermineNewGoal()
    {
        //logic to decide which goal
    }

    public virtual void CompleteGoal()
    {
        Debug.Log(gameObject + " has completed a goal");
    }

    public virtual void PerformPlan()
    {
        myPlan.PerformPlan();
    }

    #region Action Methods
    public void PlanAction_AbandonPlan()
    {
        Plan oldPlan = myPlan as Plan;
        if (oldPlan != null)
        {
            oldPlan.EndPlan();
        }
    }
    
    public void PlanAction_LookForWork(GameObject location)
    {
        Plan newPlan = gameObject.AddComponent<Plan_LookForWork>();
        ChangePlan(newPlan);
        Plan_LookForWork plan = newPlan as Plan_LookForWork;
        plan.SetTargetLocation(location);
    }

    public void PlanAction_Banditry()
    {
        Plan newPlan = gameObject.AddComponent<Plan_Banditry>();
        ChangePlan(newPlan);
    }

    public void PlanAction_RestoreOrder()
    {
        Plan newPlan = gameObject.AddComponent<Plan_RestoreOrder>();
        ChangePlan(newPlan);
    }

    public void StartGoal_ProvinceAdministration()
    {
        IGoal newGoal = gameObject.AddComponent<Goal_ProvinceAdministration>();
        ChangeGoal(newGoal);
    }

    public void StartGoal_MakeMoney()
    {
        IGoal newGoal = gameObject.AddComponent<Goal_MakeMoney>();
        ChangeGoal(newGoal);
    }
    #endregion

    #region Set References
    private void ChangeGoal(IGoal goal)
    {
        myGoal = goal;
        //Debug.Log(gameObject.name + " has a new goal: " +  myGoal);
    }

    private void ChangePlan(IPlan plan)
    {
        if (myPlan != null)
        {
            Plan oldPlan = myPlan as Plan;
            oldPlan.EndPlan();
        }

        myPlan = plan;
    }
    #endregion

    #region Get References
    public virtual Goal GetGoal()
    {
        return myGoal as Goal;
    }

    public virtual Plan GetPlan()
    {
        return myPlan as Plan;
    }
    #endregion
}
