using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoal 
{
    bool CheckConditions();
    void PerformGoal();
    void GetNewPlan();
    void EndGoal();

}
