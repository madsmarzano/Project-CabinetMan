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

        if (GameManager.instance.talkedToLittleGuy == false)
        {
            //Initial interaction -- Get info on what to do
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"Hey bug-human thingy... I need your help.\"");
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"I wanna play in the ballpit SO BAD!!! But it's EMPTY!!!\"");
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"If you fill up the ballpit for me, I'll give you this cool CD I found!\"");

            GameManager.instance.talkedToLittleGuy = true;
        }
        else if (GameManager.instance.talkedToLittleGuy && !GameManager.instance.ballpitFull)
        {
            //Slightly different text giving you a hint
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"There should be some ballpit balls scattered around here, idk.\"");
        }
        else if (GameManager.instance.ballpitFull)
        {
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"YIPPEE!!!! Great work, bug! I left your reward in the ballpit.\"");
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"This is the BEST DAY OF MY LIFE!!!!\"");
        }
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;

        if (GameManager.instance.talkedToLittleGuy == false)
        {
            TextDisplay.Instance.ChangeTextDisplay("I should try talking to this little guy...");
        }
        else
        {
            TextDisplay.Instance.ChangeTextDisplay("He doesn't seem to want any of my items.");
        }
    }
}
