using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleData : CharacterData
{
    public GameObject provinceRuled { get; private set; }

    public void SetProvinceRuled(GameObject province)
    {
        provinceRuled = province;
    }

    public void ClearProvinceRuled()
    {
        provinceRuled = null;
    }
}
