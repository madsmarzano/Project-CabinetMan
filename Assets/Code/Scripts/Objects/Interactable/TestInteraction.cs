using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : Interactable
{
    public override void OnCheck()
    {
        base.OnCheck();
        Debug.Log("CHECK OBJECT WAS TRIGGERED");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        Debug.Log("ITEM USED WAS TRIGGERED");
    }
}
