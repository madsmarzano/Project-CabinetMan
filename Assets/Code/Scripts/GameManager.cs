using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Current inventory
    public List<Item> CurrentInventory = new List<Item>();
    //All possible inventory items
    public List<Item> InventoryItems = new List<Item>();

    //Sprites for the items displayed in the UI
    //public Sprite[] itemSprites;
    //Tell the program where to find the sprite images 


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

        //LoadItems();
    }

    private void LoadItems()
    {
        //Load item sprites

        //CDs
        InventoryItems.Add(new Item("FoodCourtCD", "CD Found in the Food Court", false, true));
        InventoryItems.Add(new Item("ClothingStoreCD", "CD Found in the Clothing Store", false, true));
        InventoryItems.Add(new Item("MusicStoreCD", "CD Found in the Music Store", false, true));
        InventoryItems.Add(new Item("VentMazeCD", "CD Found in the Vent Maze", false, true));
        InventoryItems.Add(new Item("PlayplaceCD", "CD Found in the Playplace", false, true));

        //PuzzleItems

        //Etc


    }

}
