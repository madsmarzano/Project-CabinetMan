using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : Interactable
{
    public override void OnCheck()
    {
        base.OnCheck();
        UIController.textDisplay.GetComponent<TextDisplay>().ChangeTextDisplay("This is just a test.");
        Debug.Log("CHECK OBJECT WAS TRIGGERED");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        Debug.Log("ITEM USED WAS TRIGGERED");
    }
}
