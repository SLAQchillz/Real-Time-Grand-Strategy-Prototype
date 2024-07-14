using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Province Tiles", order = 1)]

public class Tiles : ScriptableObject
{
    public GameObject BANDIT_TILE;

    public GameObject GetBanditTile()
    {
        return BANDIT_TILE;
    }
}
