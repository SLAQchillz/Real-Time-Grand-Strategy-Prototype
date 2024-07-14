using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tables : MonoBehaviour
{
    public static Tables Instance;

    public Names MALE_HUMAN;
    public Names FEMALE_HUMAN;
    public Portraits HUMAN_PORTRAITS;
    public Portraits NOBLE_PORTRAITS;
    public BaseValues_States BASE_STATE_VALUES;
    public BaseValues_Goals BASE_GOAL_VALUES;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Gender GetRandomGender()
    {
        int rand = UnityEngine.Random.Range(0, 2);
        Gender newGender = new Gender();
        if (rand == 0) { newGender = Gender.Male; }
        else if (rand == 1) { newGender = Gender.Female; }
        return newGender;
    }

    public string GetRandomName(Gender gender, string race)
    {
        if (gender == Gender.Male &&
            race == "Human")
        {
            string name = MALE_HUMAN.GetRandomName();
            return name;
        }
        else if (gender == Gender.Female &&
            race == "Human")
        {
            string name = FEMALE_HUMAN.GetRandomName();
            return name;
        }
        else { return null; }
    }

    public Sprite GetRandomPortrait(Gender gender, string race)
    {
        Sprite sprite = HUMAN_PORTRAITS.GetRandomPortrait(gender, race);
        return sprite;
    }

    public Sprite GetNoblePortrait(Gender gender, string race)
    {
        Sprite sprite = NOBLE_PORTRAITS.GetRandomPortrait(gender, race);
        return sprite;
    }
}
