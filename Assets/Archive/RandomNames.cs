using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Random Tables/Random Names", order = 3)]

public class RandomNames : ScriptableObject
{
    public string[] maleHumanNames;
    public string[] femaleHumanNames;
    public string[] maleDwarfNames;
    public string[] femaleDwarfNames;
    public string[] maleElfNames;
    public string[] femaleElfNames;
    public string[] maleHalflingNames;
    public string[] femaleHalflingNames;

    public string GetRandomName(Gender gender, string race)
    {
        string[] names = null;

        // Select the appropriate array based on gender and race
        if (gender == Gender.Male && race == "Human")
        {
            names = maleHumanNames;
        }
        else if (gender == Gender.Female && race == "Human")
        {
            names = femaleHumanNames;
        }
        else if (gender == Gender.Male && race == "Dwarf")
        {
            names = maleDwarfNames;
        }
        else if (gender == Gender.Female && race == "Dwarf")
        {
            names = femaleDwarfNames;
        }
        else if (gender == Gender.Male && race == "Elf")
        {
            names = maleElfNames;
        }
        else if (gender == Gender.Female && race == "Elf")
        {
            names = femaleElfNames;
        }
        else if (gender == Gender.Male && race == "Halfling")
        {
            names = maleHalflingNames;
        }
        else if (gender == Gender.Female && race == "Halfling")
        {
            names = femaleHalflingNames;
        }

        // Generate a random index into the selected array
        int index = Random.Range(0, names.Length);

        // Return the name at the generated index
        return names[index];
    }

}
