using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        TextLoader();
    }

    public void TextLoader()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Active scene is " + sceneName);

        string roomNumber = sceneName.Substring(sceneName.Length - 1);
        Debug.Log("Scene number is " + roomNumber);

        int theNumber = int.Parse(roomNumber);
        Debug.Log("Scene integer is " + theNumber);

        string textTest = " ";
        GameObject.Find("RoomText").GetComponent<TextMeshProUGUI>().text = textTest;
		GameObject.Find("RoomText").GetComponent<TextMeshProUGUI>().text = "This is a test.";
	}
}
