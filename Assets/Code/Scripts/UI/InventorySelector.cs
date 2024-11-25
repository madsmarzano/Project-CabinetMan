using UnityEngine;
using UnityEngine.UI;

public class InventorySelector : MonoBehaviour
{
    public int selectedItem = 0;
    //public float itemScaleOriginal = 0f;
    public float itemScaleUpSize = 0.1f;

    private void Start()
    {
        //SelectItem();
        UpdateIcons();
    }

    private void Update()
    {

        HandleSelection();

        if (!GameManager.instance.inventoryUpdated)
        {
            UpdateIcons();
        }
    }

    void HandleSelection()
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
                item.localScale = Vector3.one;
            }
            i++;
        }
    }

    void UpdateIcons()
    {
        //Add the icon from the item added to the inventory into the corresponding spot in the UI
        int i = 0;
        foreach (Transform inventorySlot in transform)
        {
            Image uiImage = inventorySlot.GetComponent<Image>(); // get reference to the image in the UI
            if (i < GameManager.instance.Inventory.Count)
            {
                uiImage.sprite = GameManager.instance.Inventory[i].itemIcon;
            }
            else
            {
                uiImage.sprite = null;
            }

            i++;
        }

        GameManager.instance.inventoryUpdated = true;
    }
}
