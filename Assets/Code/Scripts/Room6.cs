using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6 : MonoBehaviour
{
    public GameObject firstMap;
    public Transform spawnPositionStart;
    public Transform spawnPositionVent;

    private void Start()
    {
        if (GameManager.instance.firstMapCollected)
        {
            firstMap.SetActive(false);
        }
    }

    public void DetermineSpawn()
    {
        if (GameManager.instance.previousScene == "StartScene")
        {
            transform.position = spawnPositionStart.position;
        }
        else
        {
            transform.position = spawnPositionVent.position;
        }
    }
}
