using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMap : MonoBehaviour
{
    public GameObject mapCollectedUI;
    public int mapNumber;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //show the screen
            mapCollectedUI.SetActive(true);

            //show mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //indicate in game manager that the map has been collected
            if (mapNumber == 1)
            {
                GameManager.instance.firstMapCollected = true;
            }
            else if (mapNumber == 2)
            {
                GameManager.instance.secondMapCollected = true;
            }

            gameObject.SetActive(false);
        }
    }
}
