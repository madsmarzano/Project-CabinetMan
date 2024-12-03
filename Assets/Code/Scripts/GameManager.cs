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
        "INSERT ROOM 5 INFO HERE",
        "INSERT ROOM 6 INFO HERE",
        "INSERT START SCENE TEXT"
    };

    public List<Item> Inventory = new List<Item>(); //List to store the items that are in the Player's inventory
    public List<Item> ItemsPickedUp = new List<Item>(); //List of all items that have been picked up, whether or not they are presently in inventory.
                                                        //This is the list that is referenced when loading rooms to determine which items are active.
    public bool inventoryUpdated;

    public bool interactionInProgress = false;

    [Header("General Puzzle Checks")]
    public bool[] cdCollected = new bool[5];

    [Header("Food Court Puzzle Checks")]
    public bool cdPurchased = false;

    [Header("Clothing Store Puzzle Checks")]
    public bool registerOpened = false;

    [Header("Music Store Puzzle Checks")]
    public bool posterChecked = false;
    public int cdInserted = 0;

    [Header("Vent Maze Puzzle Checks")]
    public bool visitedSecondFloor = false;

    [Header("Playplace Puzzle Checks")]
    public bool talkedToLittleGuy = false;
    public int ballpitPercentFull = 0;
    public bool ballpitFull = false;
    public bool[] dollyPlacedInChair = new bool[2];
    public bool dollyPuzzleComplete = false;
    public bool jungleGymOpen = false;
    public bool playplaceSpawnedCD = false;

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
