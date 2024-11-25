using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// By Mads:
/// Logic for interaction with Little Guy.
/// Talk to him to learn that you need to fill up the ballpit before he gives you a CD.
/// Ballpit balls don't spawn until you talk to little guy (except for the one you get from dolly puzzle).
/// </summary>

public class LittleGuy : Interactable
{
    public GameObject[] scatteredBalls;
    public GameObject CD;

    public override void UniqueStart()
    {
        base.UniqueStart();
        InitializeLittleGuy();
    }

    public override void UniqueUpdate()
    {
        //If the CD has been collected in this room, change the room's default text
        if (GameManager.instance.cdCollected[4])
        {
            TextDisplay.Instance.ChangeRoomText("I don't think there's anything else I need to do in this room.");
        }
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;

        ChangeScale sizeCheck = player.GetComponent<ChangeScale>();
        if (sizeCheck.currentSize == ChangeScale.Size.HUMAN) //If Player is human-sized, little guy tells you to shrink down
        {
            TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"Yo! Big Guy! Get down here so I can talk to you!\"");
        }
        else //Player is bug-sized; regular interaction
        {
            if (GameManager.instance.talkedToLittleGuy == false)
            {
                //Initial interaction -- Get info on what to do
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"Hey bug-human thingy... I need your help.\"");
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"I wanna play in the ballpit SO BAD!!! But it's EMPTY!!!\"");
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"If you fill up the ballpit for me, I'll give you this cool CD I found!\"");

                TextDisplay.Instance.ChangeRoomText("I should look for the missing ballpit balls.");

                GameManager.instance.talkedToLittleGuy = true;

                //Make the collectable ballpit balls in the scene active
                foreach (GameObject p in scatteredBalls)
                {
                    p.SetActive(true);
                }
            }
            else if (GameManager.instance.talkedToLittleGuy && !GameManager.instance.ballpitFull)
            {
                //Slightly different text giving you a hint
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"If you find any balls, throw them in the ballpit for me, would ya?\"");
            }
            else if (GameManager.instance.ballpitFull && !GameManager.instance.playplaceSpawnedCD)
            {
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"YIPPEE!!!! Great work, bug! I left your reward in the ballpit.\"");
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"This is the BEST DAY OF MY LIFE!!!!\"");
                TextDisplay.Instance.ChangeRoomText("Let's grab that CD from the ballpit!");
                //spawn CD
                CD.SetActive(true);
                GameManager.instance.playplaceSpawnedCD = true;
            }
            else //This should be the last thing little guy can say to you 
            {
                TextDisplay.Instance.ChangeTextDisplay("Little Guy: \"I'm proud of you.\"");
            }
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
            TextDisplay.Instance.ChangeTextDisplay("I might crush this lil guy if I try to give him an item.");
        }
    }

    public void InitializeLittleGuy()
    {
        if (GameManager.instance.talkedToLittleGuy)
        {
            foreach (GameObject p in scatteredBalls)
            {
                p.SetActive(true);
            }
        }

        if (GameManager.instance.playplaceSpawnedCD && !GameManager.instance.cdCollected[4])
        {
            CD.SetActive(true);
        }
    }
}
