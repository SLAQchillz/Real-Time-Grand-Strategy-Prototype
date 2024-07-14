using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleDataHandler : CharacterDataHandler
{
    public void AppointRuler(GameObject province)
    {
        NobleData nobleData = GetComponent<NobleData>();
        ProvinceCharacterHandler provinceCharacterHandler = province.GetComponent<ProvinceCharacterHandler>();
        
        if (province != null)
        {
            nobleData.SetProvinceRuled(province);
            provinceCharacterHandler.SetNoble(gameObject);
        }
        else if (province == null)
        {
            nobleData.ClearProvinceRuled();
        }
    }
}
