using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler<D, LH, I> : MonoBehaviour where D : Component  where LH : Component where I : Component
{
    protected D data;
    protected LH logicHandler;
    protected I inventory;

    public virtual void Awake()
    {
        data = GetComponent<D>();
        logicHandler = GetComponent<LH>();
        inventory = GetComponent<I>();
    }
}
