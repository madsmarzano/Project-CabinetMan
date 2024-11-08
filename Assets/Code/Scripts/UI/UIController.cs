using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private InputManager input;

    public bool showInventory;

    public GameObject roomText;
    public GameObject inventory;
    public GameObject actions;

    private void Awake()
    {
        input = GetComponent<InputManager>();

        roomText = transform.GetChild(0).gameObject;
        inventory = transform.GetChild(1).gameObject;
        actions = transform.GetChild(2).gameObject;
    }

    private void Start()
    {
        //inventory and actions are hidden at the start
        inventory.SetActive(false);
        actions.SetActive(false);
    }
    private void Update()
    {
        showInventory = !inventory.activeSelf; //should return the opposite of activeSelf I hope

        if (input.ToggledInventory)
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
