using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterData : CreatureData
{
    #region Individual Characteristics
    public CharacterType myCharacterType;
    #endregion

    #region Individual Stats
    public int statSagacity { get; private set; }
    public int statSorcery { get; private set; }
    public int statArmorUse { get; private set; }
    public int statCCWeapon { get; private set; }
    public int statRangedWeapon { get; private set; }
    public int statHealing { get; private set; }
    public int statThievery { get; private set; }
    public int statClimbRopeUse { get; private set; }
    public int statStrategy { get; private set; }
    public int statPolitics { get; private set; }
    public int statAdministration { get; private set; }
    #endregion
    
    #region StatSetting
    public void SetSagacity(int newSagacity) { statSagacity = newSagacity; }
    public void SetSorcery(int newSorcery) { statSorcery = newSorcery; }
    public void SetArmorUse(int newArmorUse) { statArmorUse = newArmorUse; }
    public void SetCCWeapon(int newCCWeapon) { statCCWeapon = newCCWeapon; }
    public void SetRangedWeapon(int newRangedWeapon) { statRangedWeapon = newRangedWeapon; }
    public void SetHealing(int newHealing) { statHealing = newHealing; }
    public void SetThievery(int newThievery) { statThievery = newThievery; }
    public void SetClimbRopeUse(int newClimbRopeUse) { statClimbRopeUse = newClimbRopeUse; }
    public void SetStrategy(int newStrategy) { statStrategy = newStrategy; }
    public void SetPolitics(int newPolitics) { statPolitics = newPolitics; }
    public void SetAdministration(int newAdministration) { statAdministration = newAdministration; }
    #endregion

    #region Applying Stat Mods
    public override void ApplyStatMods(StatMods mods)
    {
        base.ApplyStatMods(mods);

        statSagacity += mods.SagacityMod;
        statSorcery += mods.SorceryMod;
        statArmorUse += mods.ArmorUseMod;
        statCCWeapon += mods.CCWeaponMod;
        statRangedWeapon += mods.RangedWeaponMod;
        statHealing += mods.HealingMod;
        statThievery += mods.ThieveryMod;
        statClimbRopeUse += mods.ClimbRopeUseMod;
        statStrategy += mods.StrategyMod;
        statPolitics += mods.PoliticsMod;
        statAdministration += mods.AdministrationMod;
    }
    #endregion
}
