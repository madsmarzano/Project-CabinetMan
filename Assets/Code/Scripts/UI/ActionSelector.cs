using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    public int selectedAction = 0;
    public Vector3 originalSize;
    public float scaleUpSize = 0.1f;

    private void Awake()
    {
        originalSize = transform.GetChild(0).localScale;
    }

    private void Update()
    {
        int previousSelectedAction = selectedAction;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedAction >= transform.childCount - 1)
            {
                selectedAction = 0;
            }
            else
            {
                selectedAction++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedAction <= 0)
            {
                selectedAction = transform.childCount - 1;
            }
            else
            {
                selectedAction--;
            }
        }

        if (selectedAction != previousSelectedAction)
        {
            SelectAction();
        }

        if (Input.GetMouseButtonDown(0))
        {
            PerformAction(selectedAction);
        }
    }

    void SelectAction()
    {
        int i = 0;

        foreach (Transform item in transform)
        {
            if (i == selectedAction)
            {
                item.localScale += Vector3.one * scaleUpSize;
            }
            else
            {
                //return scale to original size
                item.localScale = originalSize;
            }
            i++;
        }
    }

    void PerformAction(int action)
    {
        switch (action)
        {
            case 0:
                break;
            case 1:
                UIController.inventory.SetActive(true);
                InventorySelector.state = InventorySelector.InventoryState.SELECTABLE; 
                break;
        }
    }
}
