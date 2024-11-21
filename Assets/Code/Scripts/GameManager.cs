using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public string previousScene = "";

    [HideInInspector]
    public string[] roomInfo =
    {
        "INSERT ROOM 1 INFO HERE",
        "INSERT ROOM 2 INFO HERE",
        "INSERT ROOM 3 INFO HERE",
        "INSERT ROOM 4 INFO HERE",
        "INSERT ROOM 5 INFO HERE"
    };

    public List <Item> Inventory = new List<Item>(); //List to store the items that are in the Player's inventory
    public List <Item> ItemsPickedUp = new List<Item>(); //List of all items that have been picked up, whether or not they are presently in inventory.
                                                         //This is the list that is referenced when loading rooms to determine which items are active.
    public bool inventoryUpdated;

    public bool interactionInProgress = false;

    [Header("Playplace Puzzle Checks")]
    public bool talkedToLittleGuy = false;
    public bool ballpitFull = false;
    public bool[] dollyPlacedInChair = new bool[2];
    public bool dollyPuzzleComplete;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //If the instance reference has already been set and this is NOT the instance
            //Destroy
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        inventoryUpdated = false;

        InputManager.SetDefaultKeyBinds();
    }



}
