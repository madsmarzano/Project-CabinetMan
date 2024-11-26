using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// By Mads:
/// Handles the display of the item icons in the inventory UI.
/// It also allows you to scroll through the items in the inventory -- this might be removed if there's never a need to select an item.
/// </summary>

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

        if (!GameManager.instance.inventoryUpdated) //Another script has changed the inventory, indicating that the UI display needs to be updated.
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
                //Activate the inventory slot
                inventorySlot.gameObject.SetActive(true);
                //Replace the sprite image with the item icon
                uiImage.sprite = GameManager.instance.Inventory[i].itemIcon;
            }
            else
            {
                //Deactivate the inventory slot
                inventorySlot.gameObject.SetActive(false);
                //uiImage.sprite = null;
            }

            i++;
        }

        GameManager.instance.inventoryUpdated = true; //Indicates inventory is now up to date
    }
}
