using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject creditsScreen;
    public bool activeMenu;
    public bool credits;
    void Start()
    {
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);
        creditsScreen = GameObject.Find("Credits");
        creditsScreen.SetActive(false);
        activeMenu = false;
        credits = false;
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

    public void Credits()
    {
        if (credits == false)
        {
            pauseMenu.SetActive(false);
            creditsScreen.SetActive(true);
            credits = true;
        }

        else
        {
            creditsScreen.SetActive(false);
            pauseMenu.SetActive(true);
            credits = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

}
