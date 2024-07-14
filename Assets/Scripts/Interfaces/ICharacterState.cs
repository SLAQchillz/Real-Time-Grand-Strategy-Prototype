using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{

    void Enter(GameObject character);

    void PerformState();

    string GetStateDescriptor();

    void Exit();
}
