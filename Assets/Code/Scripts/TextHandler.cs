using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public void TextLoader()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Active scene is " + sceneName);

        string roomNumber = sceneName.Substring(sceneName.Length - 1);
        Debug.Log("Scene number is " + roomNumber);

        int theNumber = int.Parse(roomNumber);
        Debug.Log("Scene integer is " + theNumber);

        //get the right text to show
        string roomText = "";
        roomText = GameManager.instance.roomInfo[theNumber - 1];
        GameObject.Find("RoomText").GetComponent<TextMeshProUGUI>().text = roomText;
	}
}
