using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMaze : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player;
    public Player playerController;

    private void Awake()
    {
        playerController = player.GetComponent<Player>();
    }

    private void Start()
    {
        int spawnIndex = SetSpawnPoint(GameManager.instance.previousScene);
        SpawnPlayer(spawnIndex);

        playerController.isInVent = true;
    }

    private int SetSpawnPoint(string previousScene)
    {
        int index = 0;
        switch (previousScene)
        {
            case "Room1":
                index = 0; break;
            case "Room5":
                index = 1; break;
            case "Room2":
                index = 2; break;
            case "Room3":
                index = 3; break;
            default:
                index = 4; break;
        }
        return index;
    }

    private void SpawnPlayer(int i)
    {
        player.transform.position = spawnPoints[i].transform.position;
        player.transform.forward = spawnPoints[i].transform.forward;
        Debug.Log("Spawning in at " + spawnPoints[i].name);
    }
}
