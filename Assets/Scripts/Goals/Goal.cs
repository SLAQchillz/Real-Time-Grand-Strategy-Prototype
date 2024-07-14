using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public CharacterGoalHandler goalHandler { get; private set; }

    public virtual void Awake()
    {
        goalHandler = GetComponent<CharacterGoalHandler>();
    }

    public virtual void EndGoal()
    {
        Destroy(this);
    }
}
