using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void SpiderDeathReload()
    {
        SceneManager.LoadScene("Room4");
    }

    public void FanDeathReload()
    {
        GameManager.instance.previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Room4");
    }
    
}
