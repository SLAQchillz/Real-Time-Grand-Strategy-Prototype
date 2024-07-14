using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroupPlan 
{
    void StartPlan();

    void PerformPlan();

    void ReceiveStateDone(GameObject character);

    void OnCombatWon(GameObject defeated);

    void OnCombatLost(GameObject victor);

    void EndPlan();
}
