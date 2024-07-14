using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Dice Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public int Rolld(int range)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(1, range + 1);
        return randomNumber;
    }
}
