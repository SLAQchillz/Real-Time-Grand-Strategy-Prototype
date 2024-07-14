using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInventory : MonoBehaviour
{
    public int myGold { get; private set; }

    public void InitInventory()
    {
        myGold = 0;
    }

    public void SetGold(int amount)
    {
        myGold = amount;
    }
}
