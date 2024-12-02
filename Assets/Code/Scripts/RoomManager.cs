using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    GameObject gameController;

    void Start()
    {
        ItemCheck();
    }

    public void ItemCheck()
    {
        GameObject check;

        //Check if an item has already been picked up.
        //If so, do not have it spawn in the room.
        if (GameManager.instance.ItemsPickedUp.Count > 0)
        {
            foreach (Item item in GameManager.instance.ItemsPickedUp)
            {
                check = GameObject.Find(item.itemname);
                if (check != null)
                {
                    Destroy(check);
                }
            }
        }
    }
}
