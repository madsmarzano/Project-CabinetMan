using UnityEngine;

/// <summary>
/// By Mads:
/// Interactable script for the interactable chairs in the Playplace.
/// If chair is empty and Player has a doll in inventory, doll is placed on the chair.
/// Once both chairs have a doll, ballpit balls spawn for the Player to collect.
/// </summary>

public class InteractableChairPP : Interactable
{
    public GameObject partnerChair; //Chair opposite to the one this script is attached to.
    public GameObject doll; //Doll that sits on the chair.
    public GameObject ballpitBalls;
    public int chairID; //Distinguishes one chair from the other; referenced in the GameManager when determining which chair a dolly has been placed in, if any.

    public override void UniqueStart()
    {
        base.UniqueStart();
        if (GameManager.instance.dollyPlacedInChair[chairID])
        {
            InitializeAsCompleted();
        }

    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("Two chairs facing each other... perfect for two friends to sit and have a tea party!");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;

        foreach (Item item in GameManager.instance.Inventory)
        {
            if (item.useWith == gameObject.name)
            {
                //Place Dolly on the chair
                doll.SetActive(true);

                //If partner chair also has a doll, spawn ballpit balls
                if (!partnerChair.GetComponent<InteractableChairPP>().interactionEnabled)
                {
                    TextDisplay.Instance.ChangeTextDisplay("The party has arrived!");
                    ballpitBalls.SetActive(true);
                    GameManager.instance.dollyPuzzleComplete = true;
                }
                else
                {
                    TextDisplay.Instance.ChangeTextDisplay("Perfect! Let's find you a friend, Dolly.");
                }

                //Remove item from inventory
                GameManager.instance.Inventory.Remove(item);
                GameManager.instance.inventoryUpdated = false;
                GameManager.instance.dollyPlacedInChair[chairID] = true;

                //Disable further interaction with this chair
                interactionEnabled = false;
                return;
            }
        }
        //Entire inventory was searched and no item was found.
        TextDisplay.Instance.ChangeTextDisplay("I don't have any items that I can use with this chair.");
    }

    /// <summary>
    /// Ensures that the if the puzzle is completed, all of the objects are in their completed state whenever the scene is loaded.
    /// </summary>
    private void InitializeAsCompleted()
    {
        doll.SetActive(true);
        interactionEnabled = false;
    }
}
