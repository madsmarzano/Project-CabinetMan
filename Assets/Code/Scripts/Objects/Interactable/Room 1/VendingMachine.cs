using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : Interactable
{
    GameObject vendingCD;
    // Start is called before the first frame update
    public override void UniqueStart()
    {
        base.UniqueStart();
        vendingCD = GameObject.Find("CD1");
        if (GameManager.instance.cdPurchased == true)
        {
            vendingCD.SetActive(false);
            TextDisplay.Instance.ChangeRoomText("I've already gotten the CD from here.  I need to find where it belongs.", 1);
        }
    }
    public override void OnCheck()
    {
        base.OnCheck();

        if (GameManager.instance.cdPurchased == false)
        {
            GameManager.instance.interactionInProgress = true;
            TextDisplay.Instance.ChangeTextDisplay("There's a CD in that machine!  If I buy it maybe I can get it out.");
        }
        else if (GameManager.instance.cdPurchased == true)
        {
            GameManager.instance.interactionInProgress = true;
            TextDisplay.Instance.ChangeTextDisplay("There's only stale chips in here.");
        }
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

                TextDisplay.Instance.ChangeTextDisplay("The machine accepted the coin, and I got a CD!");
                vendingCD.transform.position = new Vector3(-7.046f, 0.596f, 14.607f);
                GameManager.instance.cdPurchased = true;
            }
            return;
        }
        TextDisplay.Instance.ChangeTextDisplay("I don't have any money to use in the vending machine.");
    }
}
