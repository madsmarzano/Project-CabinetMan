using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads:
/// Logic for interaction with Little Guy.
/// Talk to him to learn that you need to fill up the ballpit before he gives you a CD.
/// Maybe the ballpit balls don't spawn until you talk to him first also?
/// </summary>

public class LittleGuy : Interactable
{

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;

        TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"Hey bug-human thingy... I need your help.\"");
        TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"I wanna play in the ballpit SO BAD!!! But it's EMPTY!!!\"");
        TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"If you fill up the ballpit for me, I'll give you this cool CD I found!\"");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
    }
}
