using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected GameObject player;
    [SerializeField, Tooltip("Maximum distance the player needs to be from the object in order to interract with it.")]
    protected float interactionRange;
    [SerializeField]
    protected bool playerInRange = false;

    public bool interactionEnabled = true; //Allows interaction to be turned off if there is nothing else you can do with the object.
    //protected bool interactionMenuOpen = false;

    private void Awake()
    {
        //Get reference to the player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerInRange = CheckPlayerDistance();

        if (playerInRange)
        {
            //Display interaction prompt text on the screen
            UIController.interactPrompt.SetActive(true);
        }
        else
        {
            UIController.interactPrompt.SetActive(false);
        }

        if (playerInRange && InputManager.InteractPressed())
        {
            //Open the interaction menu
            UIController.interactionMenu.SetActive(true);
            UIController.inventory.SetActive(false);
            ActionSelector.interactionTarget = this.gameObject;
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
