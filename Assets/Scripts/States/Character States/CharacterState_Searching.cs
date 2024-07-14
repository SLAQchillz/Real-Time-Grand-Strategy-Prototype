using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Searching : CharacterState
{
    private GameObject target;

    public int searchBonus { get; private set; }

    public override void Enter(GameObject character)
    {
        base.Enter(character);  

        searchBonus = 0;
    }

    public override void PerformState()
    {
        base.PerformState();

        //roll to see if search succeeds
        int odds = data.statWoodcraft + searchBonus;
        int roll = Dice.Instance.Rolld(100);
        //Debug.Log("Search odds are: " + odds);
        //Debug.Log("Search roll is " + roll);
        bool searchSuccess = roll < odds;
        if (!searchSuccess)
        {
            //Debug.Log("search failed");
        }
        if (searchSuccess)
        {
            Debug.Log("search succeeded");
        }

        if (searchSuccess)
        {
            if (logicHandler.inGroup)
            {
                GroupHandler groupHandler = logicHandler.myGroup.GetComponent<GroupHandler>();
                GroupPlan groupPlan = groupHandler.GetGroupPlan();
                if (groupPlan != null && groupPlan is GroupPlan_Hunt)
                {
                    groupPlan.ReceiveStateDone(gameObject);
                }
            }
            else
            {
                //solo search logic here
            }
        }

        //increment search bonus at end of heartbeat
        searchBonus = searchBonus + Tables.Instance.BASE_STATE_VALUES.Search_Increment_Bonus;
    }

    public void SetTarget(GameObject newTarget) { target = newTarget; }
    public GameObject GetTarget() { return target; }
}
