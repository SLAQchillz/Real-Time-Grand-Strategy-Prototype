using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Banditry : CharacterState
{
    public override void Enter(GameObject character)
    {
        base.Enter(character);

        SetStateDescriptor("Banditry");
    }

    public override void PerformState()
    {
        base.PerformState();
        
        Plan_Banditry plan = GetComponent<Plan_Banditry>();
        if (plan != null)
        {
            plan.daysBanditry++;
        }

        //Passive banditry logic
        //CharacterData data = GetComponent<CharacterData>();
        int odds = data.statPersonality + data.statCunning + data.statStrategy + data.statThievery;
        int d400 = Dice.Instance.Rolld(400);
        //Debug.Log("Odds of passive banditry are: " + odds);
        //Debug.Log("out of: 400");
        //Debug.Log(d400 + " was rolled");
        if (d400 < odds)
        {
            int coins = Dice.Instance.Rolld(15);
            CharacterDataHandler dataHandler = GetComponent<CharacterDataHandler>();
            //Debug.Log(gameObject.name + "succeeds at passive banditry and gained " + coins + " gold");
            dataHandler.AdjustGold(coins);
        }
        else
        {
            //Debug.Log("Banditry fails");
        }
    }
}
