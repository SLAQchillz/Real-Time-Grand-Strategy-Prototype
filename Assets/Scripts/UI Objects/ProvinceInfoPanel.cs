using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceInfoPanel : MonoBehaviour, IHeartbeats
{
    public GameObject currentProvince { get; private set; }
    
    public TextMeshProUGUI provinceName;
    public TextMeshProUGUI numberCharactersHere;
    public Image noblePortrait;

    public GameObject characterBox;
    public GameObject groupBox;
    public GameObject boxGrid;
    public GameObject provinceModGrid;

    void Start()
    {
        Heartbeat.Instance.Subscribe(this);
    }
    public void OnHeartbeat()
    {
        UpdatePanel(currentProvince);
    }

    public void UpdatePanel(GameObject selectedProvince)
    {
        foreach (Transform child in boxGrid.transform)
        {
            Destroy(child.gameObject);
        }

        currentProvince = selectedProvince;
        provinceName.text = selectedProvince.name;

        ProvinceCharacterHandler pch = selectedProvince.GetComponent<ProvinceCharacterHandler>();
        numberCharactersHere.text = pch.charactersHere.Count.ToString();

        // Create group boxes
        foreach (GameObject group in pch.groupsHere)
        {
            GameObject box = Instantiate(groupBox);
            GroupBox boxScript = box.GetComponent<GroupBox>();
            box.transform.SetParent(boxGrid.transform, false);
            boxScript.UpdateBox(group);
        }

        // Create character boxes
        foreach (GameObject character in pch.charactersHere)
        {
            if (!character.GetComponent<CreatureLogicHandler>().inGroup  &&
                character.GetComponent<CharacterData>().myCharacterType == CharacterType.Adventurer)
            {
                GameObject box = Instantiate(characterBox);
                CharacterBox boxScript = box.GetComponent<CharacterBox>();
                //Debug.Log("boxScript is " + boxScript);
                box.transform.SetParent(boxGrid.transform, false);
                boxScript.UpdateBox(character);
            }
        }

        // Fill noble portrait
        GameObject noble = pch.GetNobleHere();
        if (noble != null)
        {
            CreatureData nobleData = noble.GetComponent<CreatureData>();
            noblePortrait.sprite = nobleData.myPortrait;
        }
    }

    public void OnDestroy()
    {
        Heartbeat.Instance.Unsubscribe(this);
    }
}
