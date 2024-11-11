using System.Collections;
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
        textComponent.text = newText;
        StartCoroutine(WaitForTextDisplayTime());
    }

    public IEnumerator WaitForTextDisplayTime()
    {
        yield return new WaitForSeconds(changedTextDisplayTime);
        LoadRoomText();
    }
}
