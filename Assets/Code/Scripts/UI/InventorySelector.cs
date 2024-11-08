using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelector : MonoBehaviour
{
    public int selectedItem = 0;
    //public float itemScaleOriginal = 0f;
    public float itemScaleUpSize = 0.1f;

    private void Start()
    {
        SelectItem();
    }

    private void Update()
    {
        int previousSelectedItem = selectedItem;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedItem >= transform.childCount - 1)
            {
                selectedItem = 0;
            }
            else
            {
                selectedItem++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedItem <= 0)
            {
                selectedItem = transform.childCount - 1;
            }
            else
            {
                selectedItem--;
            }
        }

        if (selectedItem != previousSelectedItem)
        {
            SelectItem();
        }
    }

    void SelectItem()
    {
        int i = 0;

        foreach (Transform item in transform)
        {
            if (i == selectedItem)
            {
                //somehow enable the item in that slot 
                //for now, just enlarge the icon to show its selected (scale up)
                item.localScale += Vector3.one * itemScaleUpSize;
            }
            else
            {
                //return scale to original size
                item.localScale = Vector3.one; ;
            }
            i++;
        }
    }
}
