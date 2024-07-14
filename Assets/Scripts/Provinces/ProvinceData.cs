using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceData : MonoBehaviour
{
    public List<GameObject> exits;

    public List<ProvinceMods> mods;

    #region Province Mod Flags
    public bool hasBandits { get; private set; }
    #endregion

    #region Applying ProvinceMods modifiers
    public void ApplyProvinceMods(ProvinceMods thisProvinceMods)
    {
        // Use reflection to get the hasBandits field of the ProvinceMods object
        System.Reflection.FieldInfo hasBanditsField = thisProvinceMods.GetType().GetField("hasBandits");

        // Check if the hasBandits field exists
        if (hasBanditsField != null)
        {
            // Get the value of the hasBandits field
            bool hasBanditsValue = (bool)hasBanditsField.GetValue(thisProvinceMods);

            // Assign the value to the hasBandits field of the ProvinceData object
            hasBandits = hasBanditsValue;
        }

        mods.Add(thisProvinceMods);
    }

    public void RemoveProvinceMods(ProvinceMods thisProvinceMods)
    {
        // Use reflection to get the hasBandits field of the ProvinceMods object
        System.Reflection.FieldInfo hasBanditsField = thisProvinceMods.GetType().GetField("hasBandits");

        // Check if the hasBandits field exists
        if (hasBanditsField != null)
        {
            // Reverse or subtract the value set by the mod
            hasBandits = false;
        }

        mods.Remove(thisProvinceMods);
    }
    #endregion
}
