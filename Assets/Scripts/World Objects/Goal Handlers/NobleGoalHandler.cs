using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleGoalHandler : CharacterGoalHandler
{
    public override void DetermineNewGoal()
    {
        base.DetermineNewGoal();

        //logic to determine new goals
        //for now, administer province
        StartGoal_ProvinceAdministration();
    }
}
