using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerLogicHandler : CharacterLogicHandler
{
    public override void Start()
    {
        base.Start();

        TakeAction_SetOffOnAdventure();
    }
}
