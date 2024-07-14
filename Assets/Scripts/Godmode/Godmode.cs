using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Godmode : MonoBehaviour
{
    public static Godmode Instance { get; private set; }

    public GameObject provinceInfoPanel;
    public GameObject characterInfoPanel;

    private void Awake()
    {
        Instance = this; 
    }
}
