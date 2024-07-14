using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroupState 
{
    void Enter();

    void PerformState();

    string GetStateDescriptor();

    void Exit();
}
