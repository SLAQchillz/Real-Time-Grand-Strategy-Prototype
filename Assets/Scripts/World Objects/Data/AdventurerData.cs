using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerData : CharacterData
{
    #region Individual Characteristics
    public CharacterClass myClass { get; private set; }
    #endregion

    public void SetCharacterClass(CharacterClass newClass)
    {
        myClass = newClass;
    }
}
