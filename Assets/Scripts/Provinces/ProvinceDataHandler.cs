using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class ProvinceDataHandler : MonoBehaviour
{
    public ProvinceData data { get; private set; }

    private void Awake()
    {
        data = GetComponent<ProvinceData>();
    }

    public GameObject GetRandomExit()
    {
        if (data.exits.Count > 0)
        {
            // Get a random index within the range of the exits list
            int randomIndex = UnityEngine.Random.Range(0, data.exits.Count);

            // Return the random exit from the exits list
            return data.exits[randomIndex];
        }
        else
        {
            // The exits list is empty, return null
            return null;
        }
    }

    public void CreateProvinceMods(ProvinceModsTypes type)
    {
        switch (type)
        {
            case (ProvinceModsTypes.bandits):
                ProvinceMods newProvinceMods = gameObject.AddComponent<ProvinceMods_Bandits>();
                break;
            default: break;
        }

    }

    public void RemoveProvinceMods(ProvinceModsTypes type)
    {
        switch (type)
        {
            case (ProvinceModsTypes.bandits):
                Debug.Log("Before foreach loop");
                List<ProvinceMods> modsToRemove = new List<ProvinceMods>();
                foreach (ProvinceMods mod in data.mods)
                {
                    if (mod is ProvinceMods_Bandits)
                    {
                        modsToRemove.Add(mod);
                    }
                }
                Debug.Log("After foreach loop");

                foreach (ProvinceMods mod in modsToRemove)
                {
                    data.mods.Remove(mod);
                    Destroy(mod);
                }
                break;
        }
    }
}
