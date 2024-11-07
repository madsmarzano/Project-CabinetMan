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

    public List<Item> CurrentInventory = new List<Item>();
    //List of all possible inventory items in the game
    public List<Item> InventoryItems = new List<Item>();
    //public Sprite[] inventorySprites;

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
        DontDestroyOnLoad(gameObject);;
    }

    private void LoadItems()
    {
        //CDs
        InventoryItems.Add(new Item("FoodCourtCD", 0, "CD Found in the Food Court"));
        InventoryItems.Add(new Item("ClothingSToreCD", 1, "CD Found in the Clothing Store"));
        InventoryItems.Add(new Item("MusicStoreCD", 2, "CD Found in the Music Store"));
        InventoryItems.Add(new Item("VentMazeCD", 0, "CD Found in the Vent System"));
        InventoryItems.Add(new Item("PlayplaceCD", 0, "CD Found in the Playplace"));

        //Everything else
    }



}
