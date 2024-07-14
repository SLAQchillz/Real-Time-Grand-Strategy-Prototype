using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceMods : MonoBehaviour
{
    public ProvinceData myData {  get; private set; }

    public virtual void SetData(ProvinceData data)
    {
        myData = data;
    }

    public virtual void Awake()
    {
        myData = GetComponent<ProvinceData>();
    }

    public virtual void Start()
    {
        myData.ApplyProvinceMods(this);
    }
    public virtual void OnDisable()
    {
        myData.RemoveProvinceMods(this);
    }
}
