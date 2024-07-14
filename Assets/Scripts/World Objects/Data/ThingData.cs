using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingData : MonoBehaviour
{
    #region External Object Definitions
    public GameObject location { get; private set; }
    #endregion

    #region Base Characteristic Definitions
    public string BASE_TYPE_SINGULAR;
    public string BASE_TYPE_PLURAL;
    #endregion

    #region Individual Characteristics Derived From Base
    public string myTypeSingular { get; private set; }
    public string myTypePlural { get; private set; }
    #endregion

    #region Inidividual Characteristic Definitions

    public string uniqueName { get; private set; }
    #endregion

    #region Init
    public virtual void Start()
    {
        //InitToBaseCharacteristics();
    }

    public virtual void InitAll()
    {
        InitToBaseCharacteristics();
        InitToBaseCharacteristics();
    }
    public virtual void InitToBaseCharacteristics()
    {
        myTypeSingular = BASE_TYPE_SINGULAR;
        myTypePlural = BASE_TYPE_PLURAL;
    }
    #endregion


    #region Characteristic Setting
    public void SetName(string newName)
    {
        uniqueName = newName;
    }
    #endregion

    #region External Object Setting
    public virtual void SetLocation(GameObject newLocation) { location = newLocation; }
    #endregion
}
