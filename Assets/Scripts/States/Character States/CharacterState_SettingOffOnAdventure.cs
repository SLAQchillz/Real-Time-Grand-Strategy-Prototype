using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_SettingOffOnAdventure : CharacterState, ICharacterState
{
    public override void Enter(GameObject character)
    {
        base.Enter(character);

        SetStateDescriptor("Setting out");
    }


    public override void PerformState()
    {
        base.PerformState();

        //Debug.Log(thisCharacter.name + " is still setting off on adventure"); 
    }
}
