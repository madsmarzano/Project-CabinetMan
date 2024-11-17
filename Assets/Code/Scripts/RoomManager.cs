using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    GameObject gameController;
    void Start()
    {
        gameController = GameObject.Find("Room Manager");

        ItemCheck();
    }

    public void ItemCheck()
    {
        GameObject check;
        if (GameManager.instance.Inventory.Count > 0)
        {
            foreach (Item item in GameManager.instance.Inventory)
            {
                check = GameObject.Find(item.itemname);
                if (check != null)
                {
                    Destroy(check);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
