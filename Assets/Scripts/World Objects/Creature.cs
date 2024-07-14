using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Thing
{
    # region Static Definitions
    public static int creatureCount { get; private set; }

    static Creature()
    {
        creatureCount = 0;
    }
    #endregion

    public override void Start()
    {
        base.Start();

        creatureCount++;
    }
}
