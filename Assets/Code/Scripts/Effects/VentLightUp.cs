using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If the Player is bug-size, vents will light up to indicate to the player that they can access them.

public class VentLightUp : MonoBehaviour
{
    public GameObject player;
    public ChangeScale playerSize;

    public GameObject ventLight;

    public bool lightsOn;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSize = player.GetComponent<ChangeScale>();

        lightsOn = false;
        ventLight.SetActive(false);
    }

    private void Update()
    {
        if (playerSize.currentSize == ChangeScale.Size.BUG && !lightsOn)
        {
            ventLight.SetActive(true);
            lightsOn = true;
        }

        if (playerSize.currentSize == ChangeScale.Size.HUMAN && lightsOn)
        {
            ventLight.SetActive(false);
            lightsOn = false;
        }
    }
}
