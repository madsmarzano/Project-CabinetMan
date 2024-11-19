using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : Interactable
{
    public Transform teleportPoint;

    public override void OnCheck()
    {
        base.OnCheck();
        base.player.transform.position = teleportPoint.position;
        Camera.main.transform.forward = teleportPoint.forward;
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        TextDisplay.Instance.ChangeTextDisplay("I don't have an item I can use with this."); //Changes the text on screen
    }
}
