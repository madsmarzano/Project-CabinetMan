using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(float xInput, float zInput, Rigidbody rb, PlayerData data)
    {
        float currentSpeed = rb.velocity.magnitude;

        Vector3 moveForce = new Vector3(xInput, 0, zInput) * data.moveForce;

        //Stop applying force if player has reached their max speed
        bool isOverMaxSpeed = currentSpeed > data.maxSpeed;
        if (isOverMaxSpeed)
            moveForce = Vector3.zero;

        rb.AddForce(moveForce);
    }

    public void SlowDown(Rigidbody rb, PlayerData data)
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, data.slowDownSpeed * Time.deltaTime);
        }
    }
}
