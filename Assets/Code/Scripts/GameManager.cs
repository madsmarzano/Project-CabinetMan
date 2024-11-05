using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public string previousScene = "";


    public List 
    [HideInInspector]
    public string[] roomInfo =
    {
        "INSERT ROOM 1 INFO HERE",
        "INSERT ROOM 2 INFO HERE",
        "INSERT ROOM 3 INFO HERE",
        "INSERT ROOM 4 INFO HERE",
        "INSERT ROOM 5 INFO HERE"
    };

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



}
