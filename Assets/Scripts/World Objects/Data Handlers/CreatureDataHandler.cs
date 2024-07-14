using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureDataHandler : ThingDataHandler
{
    public CreatureInventory inventory { get; private set; }

    public override void Awake()
    {
        base.Awake();

        inventory = GetComponent<CreatureInventory>();
    }

    public virtual void InitNewCreature()
    {
        data.InitAll();
        inventory.InitInventory();
    }
}
