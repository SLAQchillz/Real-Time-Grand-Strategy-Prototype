using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Classes/Cleric", order = 3)]

public class ClericStatMods : StatMods
{
    public int modPersonality;
    public int modCCWeapon;
    public int modArmorUse;
    public int modSagacity;

    public override int PersonalityMod => modPersonality;
    public override int CCWeaponMod => modCCWeapon;
    public override int ArmorUseMod => modArmorUse;
    public override int SagacityMod => modSagacity;
}
