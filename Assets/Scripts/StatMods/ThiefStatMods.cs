using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Classes/Thief", order = 2)]

public class ThiefStatMods : StatMods
{
    public int modCunning;
    public int modCCWeapon;
    public int modThievery;
    public int modClimbRopeUse;

    public override int CunningMod => modCunning;
    public override int CCWeaponMod => modCCWeapon;
    public override int ThieveryMod => modThievery;
    public override int ClimbRopeUseMod => modClimbRopeUse;
}
