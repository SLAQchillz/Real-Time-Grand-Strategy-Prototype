using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureLogicHandler : ThingLogicHandler, IHeartbeats
{
    #region GameObject Definitions
    public CharacterGoalHandler myGoalHandler { get; private set; }

    public ICharacterState currentState { get; private set; }
    public IPlan currentPlan { get; private set; }
    public GameObject myLord { get; private set; }
    public List<GameObject> myVassals { get; private set; }
    public GameObject myGroup { get; private set; }
    #endregion

    #region Relationship flags
    public bool hasLord { get; private set; }
    public bool inGroup { get; private set; }
    #endregion

    #region Stun flags
    private bool isStunned;
    private bool isFleeing;
    #endregion

    #region Init
    public override void Awake()
    {
        base.Awake();

        InitAll();
    }

    public virtual void InitAll()
    {   
        myGoalHandler = GetComponent<CharacterGoalHandler>();
        
        myLord = null;
        myVassals = new List<GameObject>();
        myGroup = null;

        hasLord = false;
        inGroup = false;

        isStunned = false;
        isFleeing = false;
    }

    public virtual void Start()
    {
        Heartbeat.Instance.Subscribe(this);
    }
    #endregion

    #region Heartbeats
    public virtual void OnHeartbeat()
    {
        if (currentState != null)
        {
            currentState.PerformState();
        }
        if (!inGroup && !isStunned)
        {
            CharacterGoalHandler goalHandler = GetComponent<CharacterGoalHandler>();
            IGoal myGoal = goalHandler.myGoal;
            myGoal.PerformGoal();
        }
    }
    #endregion

    #region Set Values Functions
    void ChangeCharacterState(ICharacterState characterState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = characterState;
        currentState.Enter(gameObject);
    }

    public void SetCurrentPlan(IPlan plan)
    {
        if (currentPlan != null)
        {
            currentPlan.EndPlan();
        }

        currentPlan = plan;
    }

    void SetLord(GameObject newLord)        { myLord = newLord; }

    void AddVassal(GameObject newVassal)    { myVassals.Add(newVassal); }

    void RemoveVassal(GameObject character) { myVassals.Remove(character); }

    void SetGroup (GameObject newGroup)     { myGroup = newGroup; }

    void SetInGroup (bool newVal)           { inGroup = newVal; } 

    void SetHasLord (bool newVal)           { hasLord = newVal; }

    void SetIsStunned (bool newVal)         { isStunned = newVal; }

    void SetIsFleeing (bool newVal)        { isFleeing = newVal; }
    #endregion

    #region Get Values Functions
    public string GetStateDescriptor() { return currentState.GetStateDescriptor(); }

    public string GetPlanDescriptor() { return currentPlan.GetPlanDescriptor(); }
    #endregion

    #region Effect Processing
    void Process_Stun()
    {
        if (isFleeing)
        {
            SetIsStunned(true);
        }

        if (!isFleeing)
        {
            SetIsStunned(false);
        }
    }
    #endregion

    #region Character Actions

    // BecomeLordTo and BecomeVassalTo should do the same things just called from either side
    public virtual void TakeAction_BecomeLordTo(GameObject newVassal)
    {
        AddVassal(newVassal);

        CreatureLogicHandler vassalLogic = newVassal.GetComponent<CreatureLogicHandler>();
        vassalLogic.TakeAction_BecomeVassalTo(gameObject);
    }

    public virtual void TakeAction_BecomeVassalTo(GameObject newLord)
    {
        //if I have a previous Lord, unvassalize from them
        if (myLord != null &&
            myLord != newLord)
        {
            TakeAction_NoLongerVassalTo(myLord);
        }
        
        SetLord(newLord);
        SetHasLord(true);
    }

    //NoLongerVassalTo should cover ending both sides of the relationship
    public virtual void TakeAction_NoLongerVassalTo(GameObject previousLord)
    {
        if (previousLord != null)
        {
            CharacterLogicHandler lordLogic = previousLord.GetComponent<CharacterLogicHandler>();
            lordLogic.RemoveVassal(gameObject);
        }
        
        SetHasLord(false);
    }

    //JoinGroup and LeaveGroup covers the character side of the relationship 
    public virtual void TakeAction_JoinGroup(GameObject newGroup)
    {
        if (inGroup &&
            myGroup != newGroup)
        {

        }
        
        SetGroup(newGroup);
        SetInGroup(true);
    }

    public virtual void TakeAction_LeaveGroup()
    {
        SetGroup(null);
        SetInGroup(false);
    }

    public void TakeAction_LookForWork()
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_LookingForWork>();
        ChangeCharacterState(newState);
    }

    public void TakeAction_TravelTo(GameObject destination)
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_Travelling>();
        ChangeCharacterState(newState);
        CharacterState_Travelling newTravelState = newState as CharacterState_Travelling;
        newTravelState.SetTargetLocation(destination);
    }

    public void TakeAction_Banditry()
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_Banditry>();
        ChangeCharacterState(newState);
    }

    public void TakeAction_SetOffOnAdventure()
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_SettingOffOnAdventure>();
        ChangeCharacterState(newState);
    }

    public void TakeAction_AwaitOrders()
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_AwaitingOrders>();
        ChangeCharacterState(newState);
    }

    public void TakeAction_Search(GameObject target)
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_Searching>();

        CharacterState_Searching newSearchState = newState as CharacterState_Searching;
        newSearchState.SetTarget(target);

        ChangeCharacterState(newState);
    }

    public virtual void TakeAction_WinCombat(GameObject loser)
    {
        Debug.Log(data.uniqueName + " has won a combat against " + loser.name);
    }

    public virtual void TakeAction_LoseCombat(GameObject winner)
    {
        Debug.Log(data.uniqueName + " has lost a combat against " + winner.name);
        TakeAction_Flee(null);
    }

    public virtual void TakeAction_Flee(GameObject destination)
    {
        ICharacterState newState = gameObject.AddComponent<CharacterState_Fleeing>();
        ChangeCharacterState(newState);
        CharacterState_Fleeing newFleeingState = newState as CharacterState_Fleeing;

        if (destination == null)
        {
            GameObject randLoc = data.location.GetComponent<ProvinceDataHandler>().GetRandomExit();
            newFleeingState.SetTargetLocation(randLoc);
        }
        else
        {
            newFleeingState.SetTargetLocation(destination);
        }

        if (GetComponent<CharacterGoalHandler>())
        {
            CharacterGoalHandler goalHandler = GetComponent<CharacterGoalHandler>();
            goalHandler.PlanAction_AbandonPlan();
        }

        SetIsFleeing(true);
        Process_Stun();
    }

    public virtual void TakeAction_StopFleeing()
    {
        SetIsFleeing(false);
        Process_Stun();
    }

    public virtual void TakeAction_AdjustGold(int amount)
    {
        CharacterDataHandler characterDataHandler = dataHandler as CharacterDataHandler;
        characterDataHandler.AdjustGold(amount);
    }

    public virtual void TakeAction_EndVassalQuest()
    {
        TakeAction_NoLongerVassalTo(myLord);
        TakeAction_SetOffOnAdventure();
        myGoalHandler.PlanAction_AbandonPlan();
    }
    #endregion
}
