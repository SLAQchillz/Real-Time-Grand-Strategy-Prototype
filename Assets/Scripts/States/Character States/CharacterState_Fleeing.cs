using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Fleeing : CharacterState_Travelling
{
    public override void Enter(GameObject character)
    {
        base.Enter(character);

        SetStateDescriptor("Fleeing");
    }

    public override void Arrive()
    {
        //Debug.Log("target province from fleeing state before base is " + targetLocation.name);
        base.Arrive();
        //Debug.Log("target province from fleeing state after base is " + targetLocation.name);

        logicHandler.TakeAction_StopFleeing();
    }
}
