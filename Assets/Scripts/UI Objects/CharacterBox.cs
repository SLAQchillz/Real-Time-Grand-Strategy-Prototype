using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour, IHeartbeats
{
    public GameObject myCharacter { get; private set; }
    
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI classField;
    public TextMeshProUGUI raceField;
    public TextMeshProUGUI stateField;
    public Image portraitField;

    public void Start()
    {
        Heartbeat.Instance.Subscribe(this);
    }

    public void UpdateBox(GameObject character)
    {
        //Debug.Log("UpdateBox called with input " + character);
        myCharacter = character;
        //nameField.text = character.name;
        CharacterData ad = character.GetComponent<CharacterData>();
        //classField.text = ad.myClass.ToString();
        raceField.text = ad.mySpecies;
        if (character.GetComponent<ICharacterState>() != null)
        {
            stateField.text = character.GetComponent<ICharacterState>().GetStateDescriptor();
        }
        if (ad.myPortrait != null)
        {
            portraitField.sprite = ad.myPortrait;
        }
    }

    public void OpenCharacterInfoPanel()
    {
        CharacterInfoPanel cip = Godmode.Instance.characterInfoPanel.GetComponent<CharacterInfoPanel>();

        cip.gameObject.SetActive(true);
        cip.OpenPanel(myCharacter);
    }

    public void OnHeartbeat()
    {
        UpdateBox(myCharacter);
    }

    public void OnDestroy()
    {
        Heartbeat.Instance.Unsubscribe(this);
    }
}
