using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads:
/// 
/// Objects that trigger teleportation will have a trigger collider attached to them.
/// When the player collides with the trigger, their position is updated to the teleportPoint position. 
/// Currently only works when Player is bug-size.
/// 
/// </summary>

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //check if the player is bug-size 
            //if yes, proceed with teleportation
            ChangeScale sizeCheck = other.GetComponent<ChangeScale>();
            if (sizeCheck.currentSize == ChangeScale.Size.BUG)
            {
                other.transform.position = teleportPoint.position;
            }
        }
    }
}
