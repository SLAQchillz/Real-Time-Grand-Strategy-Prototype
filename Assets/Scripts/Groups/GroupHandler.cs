using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroupHandler : MonoBehaviour, IGroup, IHeartbeats
{
    #region Art Asset Definitions
    public Sprite uiGroupBoxFlagImage;
    #endregion

    #region Group Member Definitions
    public GameObject leader { get; private set; }
    private List<GameObject> members = new List<GameObject>();
    public List<GameObject> nonLeaderMembers = new List<GameObject>();
    #endregion

    #region State and Plan Definitions
    private IGroupState currentState;
    public IGroupPlan currentPlan { get; private set; }
    #endregion

    #region Location Definitions
    public GameObject location { get; private set; }
    #endregion

    #region Descriptor Variables
    public string groupDescriptor;
    //public string groupStateDescriptor;
    public string groupPlanDescriptor;
    #endregion

    #region Init
    public virtual void Start()
    {

    }
    #endregion

    #region Heartbeat
    public virtual void OnHeartbeat()
    {
        if (currentState != null)
        {
            currentState.PerformState();
        }
    }
    #endregion

    #region Group Management
    public virtual void FormGroup()
    {
        if (leader == null) { return; }

        location = leader.GetComponent<CharacterData>().location;
        location.GetComponent<ProvinceCharacterHandler>().AddGroupHere(gameObject);
        Heartbeat.Instance.Subscribe(this);
    }

    public virtual void SetLeader(GameObject newLeader)
    {
        leader = newLeader;
    }

    public virtual void Join(GameObject newMember)
    {
        members.Add(newMember);
        nonLeaderMembers.Add(newMember);
        newMember.GetComponent<CreatureLogicHandler>().TakeAction_JoinGroup(gameObject);
    }

    public virtual void Leave(GameObject formerMember)
    {
        members.Remove(formerMember);
        nonLeaderMembers.Remove(formerMember);
        formerMember.GetComponent<CreatureLogicHandler>().TakeAction_LeaveGroup();
    }

    public virtual void DisbandGroup()
    {
        for (int i = members.Count - 1; i >= 0; i--)
        {
            GameObject member = members[i];
            members.RemoveAt(i);
            CreatureLogicHandler logicHandler = member.GetComponent<CreatureLogicHandler>();
            logicHandler.TakeAction_LeaveGroup();
        }

        Heartbeat.Instance.Unsubscribe(this);
        location.GetComponent<ProvinceCharacterHandler>().RemoveGroupHere(gameObject);
        Destroy(gameObject);
    }
    #endregion

    #region Group State
    public virtual void ChangeGroupState(IGroupState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
    #endregion

    #region Group Plans
    public virtual void StartPlan_Hunting(GameObject target, int reward)
    {
        IGroupPlan newPlan = gameObject.AddComponent<GroupPlan_Hunt>();
        ChangeGroupPlan(newPlan);
        GroupPlan_Hunt newPlanHunt = newPlan as GroupPlan_Hunt;
        newPlanHunt.HuntTarget(target, reward);
    }
    
    private void ChangeGroupPlan(IGroupPlan newPlan)
    {
        if (currentPlan  != null)
        {
            currentPlan.EndPlan();
        }

        currentPlan = newPlan;
        currentPlan.StartPlan();
    }

    public virtual GroupPlan GetGroupPlan()
    {
        return currentPlan as GroupPlan;
    }
    #endregion

    #region Group Actions
    public virtual void GroupAction_AwaitOrders()
    {
        GroupState_AwaitingOrders newState = gameObject.AddComponent<GroupState_AwaitingOrders>();
        ChangeGroupState(newState);
    }

    public virtual void GroupAction_Banditry()
    {
        GroupState_Banditry newState = gameObject.AddComponent<GroupState_Banditry>();
        ChangeGroupState(newState);
    }

    public virtual void GroupAction_Disband()
    {
        DisbandGroup();
    }

    public virtual void GroupAction_DivideSpoils(int amount)
    {
        int share = amount / members.Count;
        
        foreach (GameObject member in members)
        {
            member.GetComponent<CreatureLogicHandler>().TakeAction_AdjustGold(share);
        }
    }

    public virtual void GroupAction_Hunt(GameObject target)
    {
        GroupState_Hunting newState = gameObject.AddComponent<GroupState_Hunting>();
        newState.SetTarget(target);
        ChangeGroupState(newState);
    }

    public virtual void GroupAction_WinCombat(GameObject loser)
    {
        Debug.Log(groupDescriptor + " has won a combat against " + loser.name);
    }

    public virtual void GroupAction_LoseCombat(GameObject winner)
    {

    }
    #endregion

    #region Value Gets
    public virtual List<GameObject> GetMembersAtLeader()
    {
        GameObject loc = leader.GetComponent<CreatureData>().location;
        List<GameObject> localMembers = new List<GameObject>();
        foreach (GameObject member in members)
        {
            if (member.GetComponent<CreatureData>().location == loc)
            {
                localMembers.Add(member);
            }
        }
        return localMembers;
    }
    public int GetNumberOfMembers()
    {
        return members.Count;
    }
    public List<GameObject> GetMembers() { return members; }

    public List<GameObject> GetNonLeaderMembers() { return nonLeaderMembers; }

    public string GetGroupStateDescriptor()
    {
        if (currentState != null)
        {
            return currentState.GetStateDescriptor();
        }
        else { return null; }
    }


    #endregion
}
