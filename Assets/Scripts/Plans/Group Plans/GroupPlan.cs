using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPlan : MonoBehaviour, IGroupPlan
{
    public GroupHandler groupLogic { get; private set; }

    public virtual void StartPlan()
    {
        groupLogic = GetComponent<GroupHandler>();
    }

    public virtual void PerformPlan()
    {
        
    }

    public virtual void ReceiveStateDone(GameObject character)
    {
        
    }

    public virtual void EndPlan()
    {
        Destroy(this);
    }

    public virtual void OnCombatWon(GameObject defeated)
    {
        
    }

    public virtual void OnCombatLost(GameObject victor)
    {
        
    }
}
