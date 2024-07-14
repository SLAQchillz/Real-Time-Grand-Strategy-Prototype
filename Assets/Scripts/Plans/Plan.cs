using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour, IPlan
{
    
    public CharacterData data;
    public CharacterLogicHandler logicHandler = null;
    public CharacterGoalHandler goalHandler;

    private string planDescriptor;

    public virtual void Awake()
    {
        data = GetComponent<CharacterData>();
        logicHandler = GetComponent<CharacterLogicHandler>();
        goalHandler = GetComponent<CharacterGoalHandler>();

        planDescriptor = "";
    }

    public virtual void Start()
    {
        logicHandler.SetCurrentPlan(this);
    }

    public virtual void PerformPlan()
    {

    }

    public virtual void EndPlan()
    {
        Destroy(this);
    }

    public virtual void ReceiveStateDone(ICharacterState doneState)
    {
        
    }

    public virtual void SetPlanDescriptor(string newVal) { planDescriptor = newVal; }
    public virtual string GetPlanDescriptor() {  return planDescriptor; }
}
