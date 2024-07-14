using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPlan_Hunt : GroupPlan
{
    public GameObject target { get; private set; }

    private int reward;

    private bool isTargetFound;
    private bool isTargetDefeated;

    public override void StartPlan()
    {
        base.StartPlan();

        isTargetFound = false;
        isTargetDefeated = false;
    }

    public override void ReceiveStateDone(GameObject character)
    {
        base.ReceiveStateDone(character);

        if (!isTargetFound)
        {
            CharacterData data = character.GetComponent<CharacterData>();
            //Debug.Log(data.uniqueName + " has found the bandits!");
            isTargetFound = true;
            Combat.Instance.EnterCombat(gameObject, target);
        }
    }

    public void HuntTarget(GameObject newTarget, int newReward)
    {
        target = newTarget;
        groupLogic.GroupAction_Hunt(target);

        reward = newReward;
    }

    public override void OnCombatWon(GameObject defeated)
    {
        base.OnCombatWon(defeated);
        
        if (defeated == target)
        {
            isTargetDefeated = true;
            QuestComplete();
        }
    }

    public override void OnCombatLost(GameObject victor)
    {
        base.OnCombatLost(victor);
    }

    public void QuestComplete()
    {
        groupLogic.GroupAction_DivideSpoils(reward);
        groupLogic.GroupAction_AwaitOrders();
        EndPlan();
    }
}
