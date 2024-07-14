using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Random Tables/Portraits", order = 1)]
public class Portraits : ScriptableObject
{
    public List<Sprite> PORTRAITS_M_HU;
    public List<Sprite> PORTRAITS_F_HU;

    public List<Sprite> availablePortraits_M_Hu { get; private set; }
    public List<Sprite> availablePortraits_F_Hu { get; private set; }

    public void InitPortraitLists()
    {
        availablePortraits_M_Hu = new List<Sprite>();
        availablePortraits_F_Hu = new List<Sprite>();

        availablePortraits_M_Hu = PORTRAITS_M_HU;
        availablePortraits_F_Hu = PORTRAITS_F_HU;
    }

    public Sprite GetRandomPortrait(Gender gender, string race)
    { 
        if (gender == Gender.Male && race == "Human")
        {
            if (availablePortraits_M_Hu.Count == 0)
            {
                availablePortraits_M_Hu = new List<Sprite>(PORTRAITS_M_HU);
            }

            int index = Random.Range(0, availablePortraits_M_Hu.Count);
            Sprite portrait = availablePortraits_M_Hu[index];
            availablePortraits_M_Hu.RemoveAt(index);
            return portrait;
        }

        if (gender == Gender.Female && race == "Human")
        {
            if (availablePortraits_F_Hu.Count == 0)
            {
                availablePortraits_F_Hu = new List<Sprite>(PORTRAITS_F_HU);
            }

            int index = Random.Range(0, availablePortraits_F_Hu.Count);
            Sprite portrait = availablePortraits_F_Hu[index];
            availablePortraits_F_Hu.RemoveAt(index);
            return portrait;
        }

        return null;
    }
}
