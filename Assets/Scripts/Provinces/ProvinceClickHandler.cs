using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProvinceClickHandler : MonoBehaviour, IClickable, ISelectable
{
    #region Game Object Definitions
    SelectionHandler sh;
    #endregion

    #region Selection Logic Variables
    public bool canBeSelected { get; private set; }
    #endregion

    #region Init
    void Start()
    {
        sh = PlayerManager.Instance.GetComponent<SelectionHandler>();

        canBeSelected = true;
    }
    #endregion

    #region Click Input Interface
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("Left click");
            ProcessLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
    #endregion

    #region Left Click Processing
    private void ProcessLeftClick()
    {
        if (!canBeSelected)
        {
            return;
        }
        else if (sh.currentSelection == gameObject)
        {
            ClickedAndAlreadySelected();
        }
        else
        {
            ClickedNewSelection();
        }
    }

    private void ClickedNewSelection()
    {
        sh.SetSelected(gameObject);
        PerformEveryClick();
    }

    private void ClickedAndAlreadySelected()
    {
        PerformEveryClick();
    }
    #endregion

    #region Selection Related Functions
    public void ProcessSelect()
    {
        //Debug.Log(gameObject.name + "Selected");

        //turn on ProvinceInfoPanel object if not active, then 
        //call the UpdatePanel(gameObject) method in ProvinceInfoPanel
        GameObject pip = Godmode.Instance.provinceInfoPanel;
        pip.SetActive(true);
        pip.GetComponent<ProvinceInfoPanel>().UpdatePanel(gameObject);

    }

    private void PerformEveryClick()
    {
        //SoundManager.Instance.sh.Play(fxSelect);

        //do stuff every time the province is clicked while selected
    }

    public void ProcessUnselect()
    {
        //Debug.Log(gameObject.name + "Unselected");
        
        //ToggleBorderGlow();
    }
    #endregion
}
