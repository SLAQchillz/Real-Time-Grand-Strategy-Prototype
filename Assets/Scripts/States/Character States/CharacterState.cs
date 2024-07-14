using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour, ICharacterState
{
    public GameObject thisCharacter { get; private set; }
    public CreatureLogicHandler logicHandler { get; private set; }
    public CharacterData data { get; private set; }

    public string stateDescriptor { get; private set; }

    public virtual void Enter(GameObject character)
    {
        //Debug.Log(character.name + " has started state: " + this.name);
        thisCharacter = character;
        logicHandler = character.GetComponent<CreatureLogicHandler>();
        data = character.GetComponent<CharacterData>();
    }

    public virtual void Exit()
    {
        //Debug.Log(thisCharacter + " has left state: " + this);
        Destroy(this);
    }

    public virtual void PerformState()
    {

    }

    public void SetStateDescriptor(string newDescriptor)
    {
        stateDescriptor = newDescriptor;
    }

    public string GetStateDescriptor()
    {
        return stateDescriptor;
    }
}
