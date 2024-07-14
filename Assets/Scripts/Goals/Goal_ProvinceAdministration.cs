using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ProvinceAdministration : Goal, IGoal
{
    public GameObject theProvince { get; private set; }

    public virtual void Start()
    {
        NobleData data = GetComponent<NobleData>();
        theProvince = data.provinceRuled;
    }

    public bool CheckConditions()
    {
        //ongoing goal for now
        return false;
    }

    public void GetNewPlan()
    {   
        ProvinceData data = theProvince.GetComponent<ProvinceData>();
        if (data.hasBandits)
        {
            goalHandler.PlanAction_RestoreOrder();
        }
    }

    public void PerformGoal()
    {
        Plan currentPlan = goalHandler.GetPlan();
        
        if (currentPlan == null)
        {
            GetNewPlan();
        }
        else
        {
            goalHandler.PerformPlan();
        }
    }
}
