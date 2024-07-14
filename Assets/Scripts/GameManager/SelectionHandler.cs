using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    #region Object Definitions
    public GameObject currentSelection { get; private set; }
    #endregion

    #region Logic Variables
    public bool canSelect { get; private set; }
    #endregion

    #region Init
    void Start()
    {
        InitSelect();
    }

    void InitSelect()
    {
        currentSelection = null;
        canSelect = true;
    }
    #endregion

    #region Selection Logic
    public void SetSelected(GameObject newObject)
    {
        ClearSelected();

        currentSelection = newObject;
        ISelectable selectable = currentSelection.GetComponent<ISelectable>();
        if (selectable != null)
        {
            selectable.ProcessSelect();
        }
    }

    public void ClearSelected()
    {
        if (currentSelection != null)
        {
            ISelectable selectable = currentSelection.GetComponent<ISelectable>();
            if (selectable != null)
            {
                selectable.ProcessUnselect();
            }
        }
        currentSelection = null;
    }
    #endregion
}

