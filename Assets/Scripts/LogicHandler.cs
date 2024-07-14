using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicHandler<D, DH> : MonoBehaviour where D : Component where DH : Component
{
    protected D data;
    protected DH dataHandler;

    public virtual void Awake()
    {
        data = GetComponent<D>();
        dataHandler = GetComponent<DH>();
    }
}
