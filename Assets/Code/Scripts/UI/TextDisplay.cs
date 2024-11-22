using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// By Mads.
/// Script attached to the TextDisplay GameObject.
/// By default shows the "Room Text", which is set in the GameManager.
/// Includes the method ChangeText which can be accessed from other scripts to change the text for a brief amount of time before returning to default.
/// </summary>

public class TextDisplay : MonoBehaviour
{
    //a static reference to itself -- for easy access from other scripts
    public static TextDisplay Instance = null;

    private TMP_Text textComponent;

    [Tooltip("Amount of time that the text will display on the screen before returning to Default (Room Text)")]
    public float changedTextDisplayTime = 5f;

    public List <string> textQueue = new List<string>();
    public bool isDisplayingNewText = false;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void LoadRoomText() // By Miles -- Moved from TextHandler script (MM 11/11/24)
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

    /// <summary>
    /// By Mads:
    /// Changes the text in the TextDisplay for a set amount of time before returning to Default.
    /// </summary>
    /// <param name="newText">New text that is to be displayed on screen.</param>
    public void ChangeTextDisplay(string newText)
    {
        //Check if there is already temporary text on the screen
        if (isDisplayingNewText)
        {
            //Add text to a queue to process after the previous one has finished
            textQueue.Add(newText);
        }
        else
        {
            //Just process the text right away
            isDisplayingNewText = true;
            textComponent.text = newText;
            StartCoroutine(WaitForTextDisplayTime());
        }
    }

    public void ProcessTextQueue()
    {
        //Display text at the top of the queue.
        textComponent.text = textQueue[0];
        //Remove that text now that it has been used.
        textQueue.RemoveAt(0);
        StartCoroutine(WaitForTextDisplayTime());
    }

    /// <summary>
    /// Change the default text for the room you are currently in when this method is called.
    /// </summary>
    /// <param name="newText">Text you would like the default room text to be changed to.</param>
    public void ChangeRoomText(string newText)
    {
        //Get current scene number
        string sceneName = SceneManager.GetActiveScene().name;
        string roomNumber = sceneName.Substring(sceneName.Length - 1);
        int theNumber = int.Parse(roomNumber);

        //Change the default text for this room
        GameManager.instance.roomInfo[theNumber-1] = newText;
    }

    public IEnumerator WaitForTextDisplayTime()
    {
        yield return new WaitForSeconds(changedTextDisplayTime);
        //Check if there is still text in the queue
        if (textQueue.Count > 0)
        {
            ProcessTextQueue();
        }
        else
        {
            //Go back to default room text.
            isDisplayingNewText = false;
            GameManager.instance.interactionInProgress = false;
            LoadRoomText();
        }
    }
}
