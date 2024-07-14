using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat Instance;

    private GameObject attacker;
    private GameObject defender;
    private GameObject winner;
    private GameObject loser;

    private bool attackerIsGroup;
    private bool defenderIsGroup;

    private int attackerStrength;
    private int defenderStrength;

    #region Init
    private void Awake()
    {
        Instance = this;

        InitCombat();
    }

    void InitCombat()
    {
        winner = null;
        attacker = null; 
        defender = null;
        loser = null;
    }
    #endregion

    #region Combat Logic
    public void EnterCombat(GameObject newAttacker, GameObject newDefender)
    {
        attacker = newAttacker;
        defender = newDefender;
        
        // first we make sure this is a fight between things that can fight
        if (attacker == null || defender == null) { return; }

        else if (!attacker.GetComponent<Creature>() && !attacker.GetComponent<GroupHandler>()) { return; }
        else if (!defender.GetComponent<Creature>() && !defender.GetComponent<GroupHandler>()) { return; }

        //now we determine if the fighters are groups or individuals
        if (attacker.GetComponent<Creature>())
        {
            attackerIsGroup = false;
        }
        else
        {
            attackerIsGroup = true;
        }

        if (defender.GetComponent<Creature>())
        {
            defenderIsGroup = false;
        }
        else
        {
            defenderIsGroup = true;
        }

        CalculateStrength();

        DetermineWinner();

        Debug.Log("Attacker Strength is " + attackerStrength);
        Debug.Log("Defender Strength is " + defenderStrength);
        Debug.Log("Winner is " + winner.name);

        ProcessWin();
        ProcessLoss();

        InitCombat();
    }

    void DetermineWinner()
    {
        if (attackerStrength > defenderStrength)
        {
            winner = attacker;
            loser = defender;
        }
        else if (defenderStrength > attackerStrength)
        {
            winner = defender;
            loser = attacker;
        }
        else
        {
            if (Dice.Instance.Rolld(2) == 1)
            {
                winner = attacker;
                loser = defender;
            }
            else
            {
                winner = defender;
                loser = attacker;
            }
        }
    }

    void ProcessWin()
    {
        if (winner.GetComponent<Creature>())
        {
            winner.GetComponent<CreatureLogicHandler>().TakeAction_WinCombat(loser);
        }
        else if (winner.GetComponent<GroupHandler>())
        {
            winner.GetComponent<GroupHandler>().GroupAction_WinCombat(loser);
        }
        else
        {
            Debug.Log("Error in processing combat win");
        }
    }

    void ProcessLoss()
    {
        if (loser.GetComponent<Creature>())
        {
            loser.GetComponent<CreatureLogicHandler>().TakeAction_LoseCombat(null);
        }
        else if (loser.GetComponent<GroupHandler>())
        {
            loser.GetComponent<GroupHandler>().GroupAction_LoseCombat(winner);
        }
        else
        {
            Debug.Log("Error in processing combat loss");
        }
    }
    #endregion

    #region Combat Math
    void CalculateStrength()
    {
        if (attackerIsGroup)
        {
            attackerStrength = attacker.GetComponent<GroupHandler>().GetNumberOfMembers();
        }
        else if (!attackerIsGroup)
        {
            attackerStrength = 1;
        }

        if (defenderIsGroup)
        {
            defenderStrength = defender.GetComponent<GroupHandler>().GetNumberOfMembers();
        }
        else if (!defenderIsGroup)
        {
            defenderStrength = 1;
        }
    }
    #endregion
}
