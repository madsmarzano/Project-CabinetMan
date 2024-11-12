using UnityEngine;

/// <summary>
/// By Mads:
/// Testing a script that inherits from the Interactable class with unique logic for the action methods.
/// </summary>

public class TestInteraction : Interactable
{
    public override void OnCheck()
    {
        base.OnCheck();
        TextDisplay.Instance.ChangeTextDisplay("This is just a test"); //Changes the text on screen
        Debug.Log("CHECK OBJECT WAS TRIGGERED");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        foreach (Item item in GameManager.instance.Inventory)
        {
            if (item.useWith == gameObject.name)
            {
                Debug.Log("YOU USED THE ITEM!!!!!!!!");
            }
        }
        Debug.Log("ITEM USED WAS TRIGGERED");
    }
}
