using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spider : MonoBehaviour
{
    public GameObject player;

    [Header("Spider AI")]
    public bool wallDetected = false;
    public float wallCheckLength = 0.5f;
    public float patrolSpeed = 0.5f;
    public bool isTurning = false;


    private void Update()
    {
        wallDetected = CheckForWall();

        if (wallDetected && !isTurning)
        {
            Debug.Log("Spider Detected Wall");
            Turn();
        }
        else
        {
            Move();
        }
    }

    private bool CheckForWall()
    {
        Debug.DrawRay(transform.position, transform.forward * wallCheckLength);
        return Physics.Raycast(transform.position, transform.forward, wallCheckLength);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * patrolSpeed);
    }

    private void Turn()
    {
        isTurning = true;

        int turnDirection = 0; //Direction spider will turn: -1 -- Left; 1 -- Right

        //Check if Player is to the left or right of the Spider

        Vector3 spiderRight = transform.TransformDirection(Vector3.right);
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;

        if (Vector3.Dot(spiderRight, toPlayer) < 0)
        {
            turnDirection = -1;
        }
        else
        {
            turnDirection = 1;
        }

        //turnDirection = player.transform.position.x < transform.position.x ? -1 : 1;
        float targetAngle = 90f * turnDirection;

        //Rotate Spider based on turnDirection
        transform.Rotate(0f, targetAngle, 0f);

        isTurning = false;
    }
}
