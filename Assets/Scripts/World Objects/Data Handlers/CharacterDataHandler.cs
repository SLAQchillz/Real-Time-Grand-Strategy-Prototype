using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataHandler : CreatureDataHandler
{
    public override void ChangeLocation(GameObject newLocation)
    {
        //Debug.Log("ChangeLocation ran from CDH");

        ProvinceCharacterHandler pch = null;
        if (data.location)
        {
            //Debug.Log("data.location is " + data.location);
            pch = data.location.GetComponent<ProvinceCharacterHandler>();
            pch.RemoveCharacterHere(gameObject);
        }
        
        base.ChangeLocation(newLocation);

        pch = newLocation.GetComponent<ProvinceCharacterHandler>();
        //Debug.Log("pch is " + pch);
        //Debug.Log("gameObject is " + gameObject);
        pch.AddCharacterHere(gameObject);
    }

    public virtual void AdjustGold(int amount)
    {
        inventory.SetGold(inventory.myGold + amount);
    }
}
