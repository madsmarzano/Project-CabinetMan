using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Interactable
{
    public GameObject fish;
    public GameObject fishMachine;

    // Start is called before the first frame update
    public override void UniqueStart()
    {
        base.UniqueStart();
        fish = GameObject.Find("Fish");
        fishMachine = GameObject.Find("prop vending");

        if (GameManager.instance.cdInserted < 5)
        {
            fish.SetActive(false);
            fishMachine.SetActive(true);
        }
        else
        {
            fish.SetActive(true);
            fishMachine.SetActive(false);
        }

    }


    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("Behold the secret fish!");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I do not have a suitable offering for the fish.");
    }
}
