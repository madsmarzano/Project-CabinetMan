using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads:
/// This script is attached to an object that is picked up by the player to be added to their inventory.
/// Allows you to edit properties of the object in the inspector, and then creates a copy of the data to be stored in the GameManager when item is picked up.
/// </summary>

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemIcon;
    public string useWith;
    public bool isCD;

    private void Awake()
    {
        //Make sure the item's name matches its name in the hierarchy/inspector
        itemName = gameObject.name;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddToInventory();
            GameManager.instance.inventoryUpdated = false; //Makes sure UI gets updated
            gameObject.SetActive(false);
        }
    }

    public void AddToInventory()
    {
        if (GameManager.instance.Inventory.Count > 10)
        {
            //Player loses game due to having too many items
            Debug.Log("L");
        }
        else
        {
            GameManager.instance.Inventory.Add(new Item(itemName, itemIcon, useWith, isCD)); //Add to current inventory
            GameManager.instance.ItemsPickedUp.Add(new Item(itemName, itemIcon, useWith, isCD)); //Add to running items list
        }

        if (isCD)
        {
            //Get the number of the CD which corresponds with the Room Number
            //Should be the last character in the game object's name (i.e. "CD1" for the Food Court)
            string cdNumberString = itemName.Substring(itemName.Length - 1);
            int cdNumber = int.Parse(cdNumberString);
            //Bool stored in the GameManager is set to true, indicating a CD has been collected for the room
            GameManager.instance.cdCollected[cdNumber-1] = true;
        }
        
    }
}
