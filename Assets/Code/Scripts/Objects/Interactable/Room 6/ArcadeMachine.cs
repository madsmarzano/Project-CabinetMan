using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : Interactable
{
    public Transform teleportPoint;

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.timesTeleported++;
        base.player.transform.position = teleportPoint.position;
        Camera.main.transform.forward = teleportPoint.forward;

        if (GameManager.instance.timesTeleported == 1)
        {
            TextDisplay.Instance.ChangeRoomText("More arcade? I was so close to the exit!",6);
            TextDisplay.Instance.LoadRoomText();
        }
        else if (GameManager.instance.timesTeleported > 6)
        {
            TextDisplay.Instance.ChangeRoomText("I won't give up!", 6);
            TextDisplay.Instance.LoadRoomText();
        }
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        TextDisplay.Instance.ChangeTextDisplay("I don't have an item I can use with this."); //Changes the text on screen
    }
}
