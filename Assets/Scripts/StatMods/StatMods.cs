using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMods : ScriptableObject
{
    public virtual int PersonalityMod { get; }
    public virtual int UnarmedMod { get; }
    public virtual int CunningMod { get; }
    public virtual int WoodcraftMod { get; }
    public virtual int SagacityMod { get; }
    public virtual int SorceryMod { get; }
    public virtual int ArmorUseMod { get; }
    public virtual int CCWeaponMod { get; }
    public virtual int RangedWeaponMod { get; }
    public virtual int HealingMod { get; }
    public virtual int ThieveryMod { get; }
    public virtual int ClimbRopeUseMod { get; }
    public virtual int StrategyMod { get; }
    public virtual int PoliticsMod { get; }
    public virtual int AdministrationMod { get; }
}
