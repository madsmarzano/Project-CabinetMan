using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextDisplay : MonoBehaviour
{
    private TMP_Text textComponent;

    public float changedTextDisplayTime = 5f;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    public void LoadRoomText()
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
        textComponent.text = roomText;
    }

    public void ChangeTextDisplay(string newText)
    {
        textComponent.text = newText;
        StartCoroutine(WaitForTextDisplayTime());
    }

    public IEnumerator WaitForTextDisplayTime()
    {
        yield return new WaitForSeconds(changedTextDisplayTime);
        LoadRoomText();
    }
}
