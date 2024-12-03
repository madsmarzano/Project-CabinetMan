using UnityEngine;

public class JungleGymGate : Interactable
{
    public GameObject jungleGymBarrier;
    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I wanna rip down these boards and play in here!! But I'd need the strength of a bear to be able to do that...");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        foreach (Item item in GameManager.instance.Inventory)
        {
            if (item.useWith == gameObject.name)
            {
                //Bear found
                //Remove item from inventory
                GameManager.instance.Inventory.Remove(item);
                GameManager.instance.inventoryUpdated = false;
                //Disable jungle gym barrier and gate;
                TextDisplay.Instance.ChangeTextDisplay("With Beary on my side, we can absolutely DESTROY this gate!");
                //TextDisplay.Instance.ChangeTextDisplay("Thanks Beary!");
                GameManager.instance.jungleGymOpen = true;
                jungleGymBarrier.SetActive(false);
                //gameObject.SetActive(false);
                return;
            }
        }
        TextDisplay.Instance.ChangeTextDisplay("I don't have any item that's as strong as a bear...");
    }

    public override void UniqueStart()
    {
        base.UniqueStart();
        InitializeJungleGym();
    }

    public override void UniqueUpdate()
    {
        base.UniqueUpdate();
        if(!GameManager.instance.interactionInProgress && GameManager.instance.jungleGymOpen)
        {
            gameObject.SetActive(false);
        }
    }

    private void InitializeJungleGym()
    {
        if (GameManager.instance.jungleGymOpen)
        {
            jungleGymBarrier.SetActive(false);
            interactionEnabled = false;
            gameObject.SetActive(false);
        }
    }
}
