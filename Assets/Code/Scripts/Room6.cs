using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6 : MonoBehaviour
{
    public GameObject firstMap;
    public Transform spawnPositionStart;
    public Transform spawnPositionVent;

    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        DetermineSpawn();

        if (GameManager.instance.firstMapCollected)
        {
            firstMap.SetActive(false);
        }
    }

    public void DetermineSpawn()
    {
        if (GameManager.instance.previousScene == "StartScene")
        {
            player.transform.position = spawnPositionStart.position;
        }
        else
        {
            player.transform.position = spawnPositionVent.position;
        }
    }
}
