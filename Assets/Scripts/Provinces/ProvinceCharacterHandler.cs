using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceCharacterHandler : MonoBehaviour, IHeartbeats
{
    #region Character Object Definitions
    public ProvinceData data { get; private set; }
    public ProvinceDataHandler dataHandler { get; private set; }
    
    public GameObject nobleHere { get; private set; }
    public List<GameObject> charactersHere = new List<GameObject>();
    public List<GameObject> groupsHere = new List<GameObject>();
    #endregion

    void Awake()
    {
        data = GetComponent<ProvinceData>();
        dataHandler = GetComponent<ProvinceDataHandler>();
    }

    void Start()
    {
        Heartbeat.Instance.Subscribe(this);
    }

    public void OnHeartbeat()
    {
        BanditGroupLogic();
    }

    #region Bandit Gang Logic
    void BanditGroupLogic()
    {
        if (CheckBanditGangHere() &&
            !data.hasBandits)
        {
            dataHandler.CreateProvinceMods(ProvinceModsTypes.bandits);
        }

        
        if(CheckBanditGangHere() == false &&
            data.hasBandits)
        {
            
            dataHandler.RemoveProvinceMods(ProvinceModsTypes.bandits);
        }
        

        if (!CheckBanditGangHere() && CheckMultipleBandits())
        {
            List<GameObject> banditCharacters = new List<GameObject>();
            foreach (GameObject character in charactersHere)
            {
                CreatureLogicHandler logicHandler = character.GetComponent<CreatureLogicHandler>();
                if (logicHandler.currentState is CharacterState_Banditry &&
                    logicHandler.inGroup == false)
                {
                    banditCharacters.Add(character);
                }
            }
            Maker_Group.Instance.SpawnGang(banditCharacters.ToArray());
        }    
    }

    public bool CheckBanditGangHere()
    {
        //see if this province already has a Bandit Gang
        if (groupsHere.Count > 0)
        {
            foreach (GameObject groupObject in groupsHere)
            {
                GroupHandler groupLogic = groupObject.GetComponent<GroupHandler>();
                if (groupLogic is Group_BanditGang)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public GameObject GetBanditGangHere()
    {
        if (groupsHere.Count > 0)
        {
            foreach (GameObject groupObject in groupsHere)
            {
                GroupHandler groupLogic = groupObject.GetComponent<GroupHandler>();
                if (groupLogic is Group_BanditGang)
                {
                    return groupObject;
                }
            }
        }

        return null;
    }

    bool CheckMultipleBandits()
    {
        //check if there are two or more unaffiliated bandits operating here
        List<GameObject> banditCharacters = new List<GameObject>();

        if (charactersHere.Count < 2)
        {
            return false;
        }
        
        foreach (GameObject character in charactersHere)
        {
            CreatureLogicHandler logicHandler = character.GetComponent<CreatureLogicHandler>();
            if (logicHandler.currentState is CharacterState_Banditry &&
                logicHandler.inGroup == false)
            {
                banditCharacters.Add(character);
            }
        }

        if (banditCharacters.Count >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Noble Logic
    public bool CheckNobleHere()
    {
        if (nobleHere != null)
        {
            return true;
        }
        return false;
    }

    public GameObject GetNobleHere()
    {
        return nobleHere;
    }
    #endregion

    #region Character Management Functions
    public void AddCharacterHere(GameObject character)
    {
        charactersHere.Add(character);
    }

    public void RemoveCharacterHere(GameObject character)
    {
        charactersHere.Remove(character);
    }

    public void AddGroupHere(GameObject group)
    {
        groupsHere.Add(group);
    }

    public void RemoveGroupHere(GameObject group)
    {
        groupsHere.Remove(group);
    }

    public void SetNoble(GameObject noble)
    {
        nobleHere = noble;
    }
    #endregion
}
