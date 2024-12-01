using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRegister : Interactable
{
    // Start is called before the first frame update
    public override void UniqueStart()
    {
        base.UniqueStart();
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("There's nothing else in here.");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I can't do anything else with this.");

    }
}
