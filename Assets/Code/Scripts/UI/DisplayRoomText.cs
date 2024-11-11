using UnityEngine;

public class DisplayRoomText : MonoBehaviour
{
    private void Start()
    {
        UIController.textDisplay.GetComponent<TextDisplay>().LoadRoomText();
    }
}
