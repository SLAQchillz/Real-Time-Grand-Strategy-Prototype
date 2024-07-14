using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_AwaitingOrders : CharacterState, ICharacterState
{
    public override void Enter(GameObject character)
    {
        base.Enter(character);

        SetStateDescriptor("Awaiting Orders");
    }
}
