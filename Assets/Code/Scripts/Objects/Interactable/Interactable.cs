using UnityEngine;

/// <summary>
/// By Mads:
/// This is a base script with logic that all interactable objects share (mostly UI stuff).
/// Includes virtual methods for OnCheck and OnItemUsed -- scripts that inherit from this class can override those methods to create their own logic.
/// WHEN WRITING CUSTOM LOGIC FOR INTERACTABLE ITEMS: Create a new script and have it inherit from "Interactable".
/// </summary>

public class Interactable : MonoBehaviour
{
    protected GameObject player;
    [SerializeField, Tooltip("Maximum distance the player needs to be from the object in order to interract with it.")]
    protected float interactionRange;
    [SerializeField]
    protected bool playerInRange = false;

    protected bool isActive = false;

    public bool interactionEnabled = true; //Allows interaction to be turned off if there is nothing else you can do with the object.
    public bool interactionPaused = false; //Pauses interactions on other objects while an interaction (such as text display) is occuring.

    private void Awake()
    {
        //Get reference to the player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //Pause interaction on an object while another object is being interacted with
        if (GameManager.instance.interactionInProgress)
        {
            interactionPaused = true;
        }
        else
        {
            interactionPaused = false;
        }

        //Check if player is in range of the object.
        playerInRange = CheckPlayerDistance();

        if (interactionEnabled && !interactionPaused)
        {
            if (playerInRange)
            {
                //Display interaction prompt text on the screen
                isActive = true;
                UIController.interactPrompt.SetActive(true);
            }
            else if (isActive)
            {
                if (UIController.interactionMenu.activeSelf)
                {
                    UIController.ResetToDefault();
                }
                UIController.interactPrompt.SetActive(false);
                isActive = false;
            }

            //If E is pressed, display the Interaction menu and hide the other UI stuff
            if (playerInRange && InputManager.InteractPressed())
            {
                //Open the interaction menu
                UIController.interactionMenu.SetActive(true);
                //Hide inventory and text display
                UIController.inventory.SetActive(false);
                UIController.textDisplay.SetActive(false);
                //Create a reference to the object you are interacting with in the Action Selector script
                //This is selecting an action from the Interaction Menu will call the OnCheck or OnItemUsed methods.
                ActionSelector.interactionTarget = this.gameObject;
            }
        }
        else if (isActive)
        {
            if (UIController.interactionMenu.activeSelf)
            {
                UIController.ResetToDefault();
            }
            UIController.interactPrompt.SetActive(false);
            isActive = false;
        }

        
    }

    /// <summary>
    /// Checks the distance between the Player and the object script is attached to and compares it to the interactionRange.
    /// </summary>
    /// <returns>True if player is in range, False if player is not in range.</returns>
    public bool CheckPlayerDistance()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= interactionRange;
    }

    public virtual void OnCheck() { }
    public virtual void OnItemUsed() { }
}
