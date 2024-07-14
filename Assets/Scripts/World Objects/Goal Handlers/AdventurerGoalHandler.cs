using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerGoalHandler : CharacterGoalHandler
{
    public override void DetermineNewGoal()
    {
        base.DetermineNewGoal();

        //logic here to determine new goal - for now, Make Money
        StartGoal_MakeMoney();
    }
}
