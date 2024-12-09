using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScenes : MonoBehaviour
{
    private void Start()
    {
        //show cursor and unlock cursor -- MM 12/08/24
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
