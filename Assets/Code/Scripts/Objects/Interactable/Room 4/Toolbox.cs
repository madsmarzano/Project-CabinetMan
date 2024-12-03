using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : Interactable
{
    [Header("Toolbox Properties")]
    public bool isOpen = false;

    public Transform drawer;
    public Vector3 drawerOpenPos;

    public GameObject roomCD;

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        //Drawer slides out
        drawer.localPosition = drawerOpenPos;
        //Spawn the CD
        roomCD.SetActive(true);
        //Change text
        TextDisplay.Instance.ChangeTextDisplay("There is a CD in this toolbox! And now it's floating in the middle of the room for some reason.");
        TextDisplay.Instance.ChangeRoomText("Let's grab the CD and get out of here!", 4);
        //Disable interaction with the toolbox
        interactionEnabled = false;
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        //No items are used on this object
        TextDisplay.Instance.ChangeTextDisplay("This toolbox doesn't need any of my items.");
    }

    public override void UniqueStart()
    {
        base.UniqueStart();
        InitializeToolbox();
    }

    public override void UniqueUpdate()
    {
        base.UniqueUpdate();
    }

    public void InitializeToolbox()
    {
        if (GameManager.instance.cdCollected[3])
        {
            interactionEnabled = false;
        }
        else
        {
            interactionEnabled = true;
        }
    }
}
