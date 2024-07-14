using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Character
{
    public static int adventurerCount { get; private set; }

    static Adventurer()
    {
        adventurerCount = 0;
    }

    public override void Start()
    {
        base.Start();

        adventurerCount++;
    }
}
