using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler<D> : MonoBehaviour where D : Component
{
    protected D data;

    public virtual void Awake()
    {
        data = GetComponent<D>();
    }
}
