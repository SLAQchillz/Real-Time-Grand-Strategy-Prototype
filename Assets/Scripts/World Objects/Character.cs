using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Creature
{
    # region Static Definitions
    public static int characterCount { get; private set; }

    static Character()
    {
        characterCount = 0;
    }
    #endregion

    public override void Start()
    {
        base.Start();

        characterCount++;
        //Debug.Log(characterCount);
    }
}
