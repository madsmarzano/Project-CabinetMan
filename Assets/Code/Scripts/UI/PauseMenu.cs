using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool activeMenu;
    void Start()
    {
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);
        activeMenu = false;
    }

    void Update()
    {
        if (InputManager.PausePressed() && !activeMenu)
        {
            pauseMenu.SetActive(true);
            activeMenu = true;
            Time.timeScale = 0;
        }


    }
    
    public void Resume()
    {
             Time.timeScale = 1;
            pauseMenu.SetActive(false);
            activeMenu = false;
        Debug.Log("yeah");
    }


}
