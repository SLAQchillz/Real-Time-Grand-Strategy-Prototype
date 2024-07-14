using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardClickHandler : MonoBehaviour, IClickable, ISelectable
{
    SelectionHandler sh;

    void Start()
    {
        sh = PlayerManager.Instance.GetComponent<SelectionHandler>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            sh.ClearSelected();
            GameObject pip = Godmode.Instance.provinceInfoPanel;
            pip.SetActive(false);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }

    #region Selection Related Functions
    public void ProcessSelect()
    {
        //this should never get called and is only here because of the Interface
    }
    public void ProcessUnselect()
    {
        //this gets called because of the interface, and could possibly be used
        //to play a sound fx or something
    }
    #endregion
}
