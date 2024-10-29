using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// By Mads:
/// 
/// This script is attached to every vent that functions as a door to another room.
/// 
/// 
/// </summary>

public class DoorsMM : MonoBehaviour
{

    public int[,] roomGridArray =
    {
        { 0, 5, 2, 3 }, //Room1
        { 1, 3, 0, 0 }, //Room2
        { 0, 1, 2, 0 }, //Room3
        { 0, 0, 0, 0 }, //Room4 - unsure how entrances to the maze will work so currently it is all null
        { 1, 0, 2, 3 }  //Room5

    };

    private void OnTriggerEnter(Collider other)
    {

        //figure out scene we are currently in
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("The active scene name is " + sceneName);

        //convert scene name into an integer we can use
        //gets this number from the last character of the scene name
        string roomNumberString = sceneName.Substring(sceneName.Length - 1);
        Debug.Log("The active scene number is " + roomNumberString);

        //convert roomNumberString to an int
        int roomNumber;
        roomNumber = int.Parse(roomNumberString);

        //figure out where door leads
        int destination = 0;
        switch (this.name)
        {
            case "DoorN":
                destination = roomGridArray[roomNumber - 1, 0];
                break;
            case "DoorE":
                destination = roomGridArray[roomNumber - 1, 1];
                break;
            case "DoorS":
                destination = roomGridArray[roomNumber - 1, 2];
                break;
            case "DoorW":
                destination = roomGridArray[roomNumber - 1, 3];
                break;
        }

        if (destination == 0)
        {
            Debug.Log("No destination set.");
            return;
        }

        //convert the destination number to a room name
        string destinationString = destination.ToString();
        string nextScene = "Room" + destinationString;
        Debug.Log("Traveling to " + nextScene);

        //go to destination
        SceneManager.LoadScene(nextScene);
    }

}
