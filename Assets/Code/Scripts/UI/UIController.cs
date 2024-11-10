using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool showInventory;
    public static bool showInteractPrompt;
    public static bool showInteractionMenu;

    public GameObject roomText;
    public GameObject inventory;
    public GameObject actions;
    public GameObject interactPrompt;
    public GameObject interactionMenu;

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

        interactPrompt.SetActive(showInteractPrompt);
        interactionMenu.SetActive(showInteractionMenu);

        if (InputManager.ToggledInventory())
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
