using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Classes/Fighter", order = 1)]
public class FighterStatMods : StatMods
{
    public int modCCWeapon;
    public int modRangedWeapon;
    public int modArmorUse;
    public int modStrategy;

    public override int CCWeaponMod => modCCWeapon;
    public override int RangedWeaponMod => modRangedWeapon;
    public override int ArmorUseMod => modArmorUse;    
    public override int StrategyMod => modStrategy;
}
