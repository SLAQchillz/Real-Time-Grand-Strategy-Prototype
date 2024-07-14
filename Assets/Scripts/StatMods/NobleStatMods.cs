using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Classes/Noble", order = 4)]

public class NobleStatMods : StatMods
{
    public int modPersonality;
    public int modCunning;
    public int modArmorUse;
    public int modCCWeapon;
    public int modStrategy;
    public int modPolitics;
    public int modAdministration;

    public override int PersonalityMod => modPersonality;
    public override int CunningMod => modCunning;
    public override int ArmorUseMod => modArmorUse;
    public override int CCWeaponMod => modCCWeapon;
    public override int StrategyMod => modStrategy;
    public override int PoliticsMod => modPolitics;
    public override int AdministrationMod => modAdministration;
}
