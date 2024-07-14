using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GroupBox : MonoBehaviour, IHeartbeats
{
    public GameObject myGroup { get; private set; }

    public Image flagImage;
    public TextMeshProUGUI groupNameField;
    public TextMeshProUGUI leaderNameField;
    public TextMeshProUGUI groupStateField;
    public TextMeshProUGUI groupNumberField;
    public Image leaderPortrait;

    private bool hasGroup = false;

    void Start()
    {
        Heartbeat.Instance.Subscribe(this);
    }

    public void UpdateBox(GameObject groupObject)
    {
        if(groupObject == null)
        {
            Destroy(gameObject);
            return;
        }
        if (myGroup == null && hasGroup == true)
        {
            Destroy(gameObject);
        }
        if (groupObject == null && hasGroup == true)
        {
            Destroy(gameObject);
        }
        
        myGroup = groupObject;
        hasGroup = true;

        GroupHandler groupLogic = groupObject.GetComponent<GroupHandler>();

        flagImage.sprite = groupLogic.uiGroupBoxFlagImage;
        groupNameField.text = groupLogic.groupDescriptor;
        leaderNameField.text = groupLogic.leader.GetComponent<CharacterData>().uniqueName;
        if (groupLogic.leader.GetComponent<CharacterData>().myPortrait != null)
        {
            leaderPortrait.sprite = groupLogic.leader.GetComponent<CharacterData>().myPortrait;
        }
        groupStateField.text = groupLogic.GetGroupStateDescriptor();
        groupNumberField.text = groupLogic.GetMembers().Count.ToString();
    }
    public void OnHeartbeat()
    {
        UpdateBox(myGroup);
    }

    public void OnDestroy()
    {
        Heartbeat.Instance.Unsubscribe(this);
    }
}
