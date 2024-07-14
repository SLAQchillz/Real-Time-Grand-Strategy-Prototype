using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Random Tables/Names", order = 2)]

public class Names : ScriptableObject
{
    public string[] names = null;

    public string GetRandomName()
    {
        int index = Random.Range(0, names.Length);
        return names[index];
    }
}
