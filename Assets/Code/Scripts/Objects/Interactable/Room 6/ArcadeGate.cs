using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGate : Interactable
{
    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("It's an old arcade... I think I see an exit all the way in the back!");
        TextDisplay.Instance.ChangeTextDisplay("Is there something I can do to open this gate?");
        TextDisplay.Instance.ChangeRoomText("I need to find a way to open the arcade gate.", 6);
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I'll probably need an item, but I need to find the device that's controlling this gate.");
    }

    public override void UniqueStart()
    {
        base.UniqueStart();
        if (GameManager.instance.cdInserted == 5)
        {
            interactionEnabled = false;
            gameObject.SetActive(false);
            TextDisplay.Instance.ChangeRoomText("The arcade gate is gone!", 6);
            TextDisplay.Instance.LoadRoomText();
        }
    }

    public override void UniqueUpdate()
    {
        base.UniqueUpdate();
    }
}
