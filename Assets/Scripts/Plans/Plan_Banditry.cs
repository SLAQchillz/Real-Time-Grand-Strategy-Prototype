using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan_Banditry : Plan, IPlan
{
    public int daysBanditry;
    public override void Start()
    {
        base.Start();
        
        ProvinceCharacterHandler pch = data.location.GetComponent<ProvinceCharacterHandler>();
        if (pch.CheckBanditGangHere())
        {
            GameObject banditGang = pch.GetBanditGangHere();
            banditGang.GetComponent<Group_BanditGang>().Join(gameObject);
        }

        SetPlanDescriptor("Engaged in Banditry");

        logicHandler.TakeAction_Banditry();
    }
}
