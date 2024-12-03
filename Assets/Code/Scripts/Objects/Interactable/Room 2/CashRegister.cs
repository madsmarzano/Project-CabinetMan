using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : Interactable
{
    GameObject openRegister;
    GameObject clothingCD;
    public override void UniqueStart()
    {
        base.UniqueStart();
        clothingCD = GameObject.Find("CD2");
        openRegister = GameObject.Find("OpenRegister");
        if (GameManager.instance.registerOpened == true)
        {
            gameObject.SetActive(false);
            openRegister.SetActive(true);
            TextDisplay.Instance.ChangeRoomText("I've already gotten the CD from here.  I need to find where it belongs.", 2);
        }
        else
        {
            clothingCD.SetActive(false);
            openRegister.SetActive(false);
        }
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("Looks like there's something in here.  I need the key.");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        
        foreach (Item item in GameManager.instance.Inventory)
        {
            if (item.useWith == gameObject.name)
            {
                //Remove item from inventory
                GameManager.instance.Inventory.Remove(item);
                GameManager.instance.inventoryUpdated = false;

                TextDisplay.Instance.ChangeTextDisplay("The key fits, and there's a CD inside!");
                clothingCD.SetActive(true);
                openRegister.SetActive(true);
                gameObject.SetActive(false);
                GameManager.instance.registerOpened = true;

            }
            return;
        }
        TextDisplay.Instance.ChangeTextDisplay("I don't have the key for this.");
    }
}
