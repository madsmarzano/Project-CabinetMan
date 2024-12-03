using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombox : Interactable
{
    public override void UniqueStart()
    {
        base.UniqueStart();
        if (GameManager.instance.cdInserted > 4)
        {
            TextDisplay.Instance.ChangeRoomText("There's no more CDs left to find.  Time to get out of here!", 3);
        }
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("A boombox.  Seems like it can hold a lot of CDs.");
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

                if (GameManager.instance.cdInserted == 4)
                {
                    GameManager.instance.cdInserted++;
                    TextDisplay.Instance.ChangeTextDisplay("Looks like that was the last one!  I wonder if that did anything somewhere else?");
                }

                else
                {
                    GameManager.instance.cdInserted++;
                    TextDisplay.Instance.ChangeTextDisplay("Looks like the CD fits!");
                }
            }
            return;
        }
        TextDisplay.Instance.ChangeTextDisplay("I can't use that with this.");
    }

}
