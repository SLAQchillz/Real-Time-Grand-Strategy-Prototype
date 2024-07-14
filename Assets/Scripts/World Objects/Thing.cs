using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    
    #region Static Definitions
    public static int thingCount { get; private set; }

    static Thing()
    {
        thingCount = 0;
    }
    #endregion

    /*
    #region Component Definitions
    public ThingData thingData { get; private set; }
    public ThingDataHandler thingDataHandler { get; private set; }
    public ThingLogicHandler thingLogicHandler { get; private set; }
    #endregion
    */

    #region Init
    public virtual void Awake()
    {
        //thingData = GetComponent<ThingData>();
        //thingDataHandler = GetComponent<ThingDataHandler>();
        //thingLogicHandler = GetComponent<ThingLogicHandler>();
    }

    public virtual void Start()
    {
        thingCount++;
    }
    #endregion
}
