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
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I don't see any way I can use an item right here to open it... but there must be a way.");
    }

    public override void UniqueStart()
    {
        base.UniqueStart();
        if (GameManager.instance.cdInserted == 5)
        {
            interactionEnabled = false;
            gameObject.SetActive(false);
        }
    }

    public override void UniqueUpdate()
    {
        base.UniqueUpdate();
    }
}
