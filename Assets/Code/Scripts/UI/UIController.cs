using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool showInventory;
    public bool inventoryToggleEnabled;
    public bool roomTextEnabled;

    public static GameObject roomText;
    public static GameObject inventory;
    public static GameObject actions;
    public static GameObject interactPrompt;
    public static GameObject interactionMenu;

    private void Awake()
    {
        roomText = transform.GetChild(0).gameObject;
        inventory = transform.GetChild(1).gameObject;
        actions = transform.GetChild(2).gameObject;
        interactPrompt = transform.GetChild(3).gameObject;
        interactionMenu = transform.GetChild(4).gameObject;
    }

    private void Start()
    {
        //inventory and actions are hidden at the start
        inventory.SetActive(false);
        actions.SetActive(false);
        interactPrompt.SetActive(false);
        interactionMenu.SetActive(false);
    }
    private void Update()
    {
        showInventory = !inventory.activeSelf; //should return the opposite of activeSelf I hope
        inventoryToggleEnabled = !interactionMenu.activeSelf;
        roomTextEnabled = !interactionMenu.activeSelf;
        roomText.SetActive(roomTextEnabled);

        if (InputManager.ToggledInventory() && inventoryToggleEnabled)
        {
            inventory.SetActive(showInventory);
        }

        //If inventory is active, click to open actions menu
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.activeSelf == true)
            {
                actions.SetActive(true);
            }
        }
    }
}
