using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingDataHandler : DataHandler<ThingData>
{

    #region Data Pass-Throughs
    public virtual void ChangeLocation(GameObject newLocation)
    {
        //any additional checks or logic
        data.SetLocation(newLocation);
    }
    #endregion
}
