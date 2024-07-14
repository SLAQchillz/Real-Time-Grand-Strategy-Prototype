using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupState : MonoBehaviour, IGroupState
{
    public GroupHandler groupLogic { get; private set; }
    public string stateDescriptor { get; private set; }

    public virtual void Enter()
    {
        groupLogic = GetComponent<GroupHandler>();
    }

    public virtual void Exit()
    {
        Destroy(this);
    }

    public void SetStateDescriptor(string newString)
    {
        stateDescriptor = newString;
    }

    public virtual string GetStateDescriptor()
    {
        return stateDescriptor;
    }

    public virtual void PerformState()
    {
        
    }
}
