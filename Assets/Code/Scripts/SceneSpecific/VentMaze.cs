using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMaze : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player;
    public Player playerController;

    public GameObject spider;
    public Spider spiderController;

    private void Awake()
    {
        playerController = player.GetComponent<Player>();
        spiderController = spider.GetComponent<Spider>();
    }

    private void Start()
    {
        int spawnIndex = SetSpawnPoint(GameManager.instance.previousScene);
        SpawnPlayer(spawnIndex);
        SpawnSpider(spawnIndex);

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
        Debug.Log("Player spawned at " + spawnPoints[i].name);
    }

    private void SpawnSpider(int playerSpawnPoint)
    {
        //There are 5 total spawn-points the spider can pick at random to spawn in at
        //however it cannot choose the same point that the player is spawning into
        int spiderSpawnPoint = playerSpawnPoint;
        while (spiderSpawnPoint == playerSpawnPoint)
        {
            spiderSpawnPoint = Random.Range(0, 4);
        }

        Vector3 spiderSpawnPosition = new Vector3(
            spawnPoints[spiderSpawnPoint].transform.position.x,
            0.5f, //Height has to be higher than the spawn point for player
            spawnPoints[spiderSpawnPoint].transform.position.z);

        spider.transform.position = spiderSpawnPosition;
        spider.transform.forward = spawnPoints[spiderSpawnPoint].transform.forward;
        Debug.Log("Spider spawned at " + spawnPoints[spiderSpawnPoint].name);
    }
}
