using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    GameObject gameController;
    void Awake()
    {
        gameController = GameObject.Find("Room Manager");

        ItemCheck();
    }

    public void ItemCheck()
    {
        GameObject check;
        foreach (Item item in GameManager.instance.Inventory)
        {
            check = GameObject.Find(item.itemname);
            if (check != null)
            {
                Destroy(check);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
