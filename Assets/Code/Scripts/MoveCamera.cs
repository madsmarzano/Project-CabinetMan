using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition; //referencing the CameraPosition GameObject that is a child of the Player

    private void LateUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
