using System.Collections;
using System.Collections.Generic;
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

    public override void OnCheck()
    {
        base.OnCheck();
        TextDisplay.Instance.ChangeTextDisplay("Two chairs facing each other... perfect for two friends to sit and have a tea party!");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
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
                }
                else
                {
                    TextDisplay.Instance.ChangeTextDisplay("Perfect! Let's find you a friend, Dolly.");
                }

                //Remove item from inventory
                GameManager.instance.Inventory.Remove(item);
                GameManager.instance.inventoryUpdated = false;

                //Disable further interaction with this chair
                interactionEnabled = false;
                break;
            }
            else
            {
                TextDisplay.Instance.ChangeTextDisplay("I don't have any items that I can use with this chair.");
            }
        }
    }
}
