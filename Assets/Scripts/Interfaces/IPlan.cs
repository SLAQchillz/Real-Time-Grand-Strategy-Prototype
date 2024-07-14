using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlan
{
    void PerformPlan();

    void ReceiveStateDone(ICharacterState doneState);

    string GetPlanDescriptor();

    void EndPlan();
}
