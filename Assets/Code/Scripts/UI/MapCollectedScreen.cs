using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollectedScreen : MonoBehaviour
{
    public void CloseScreen()
    {
        //Hide and lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //deactivate object
        gameObject.SetActive(false);
    }
}
