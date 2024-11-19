using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spider : MonoBehaviour
{
    public GameObject player;

    [Header("Spider AI")]
    public bool wallDetected = false;
    public bool branchDetected = false;
    public float wallCheckLength = 0.5f;
    public float patrolSpeed = 0.5f;
    public bool isTurning = false;

    public bool canTurnRight, canTurnLeft;


    private void Update()
    {
        wallDetected = CheckForward();

        if (wallDetected && !isTurning)
        {
            Debug.Log("Spider Detected Wall");
            Turn();
        }
        else if (branchDetected && !isTurning)
        {
            Debug.Log("Spider Reached a Branch");
            ChooseDirection();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * patrolSpeed);
    }

    private void Turn()
    {
        isTurning = true;

        //check if there is a wall to the left or to the right of the player
        canTurnRight = CheckRight();
        canTurnLeft = CheckLeft();

        float targetAngle;

        if (canTurnRight)
        {
            Debug.Log("Turning Right");
            targetAngle = 90f;
        }
        else if (canTurnLeft)
        {
            Debug.Log("Turning Left");
            targetAngle = -90f;
        }
        else
        {
            Debug.Log("Flipping");
            targetAngle = 180f;
        }

        //int turnDirection = 0; //Direction spider will turn: -1 -- Left; 1 -- Right
        //float targetAngle;

        //Check if Player is to the left or right of the Spider

        //Vector3 spiderRight = transform.TransformDirection(Vector3.right);
        //Vector3 toPlayer = (player.transform.position - transform.position).normalized;

        //turnDirection = player.transform.position.x < transform.position.x ? -1 : 1;
        //float targetAngle = 90f * turnDirection;

        //Rotate Spider
        transform.Rotate(0f, targetAngle, 0f);

        isTurning = false;
    }

    public void ChooseDirection()
    {
        isTurning = true;

        bool canMoveForward = (wallDetected == false);
        canTurnRight = CheckRight();
        canTurnLeft = CheckLeft();

        //check if player is to the right or to the left of the spider
        Vector3 spiderRight = transform.TransformDirection(Vector3.right);
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;

        float targetAngle;

        if (Vector3.Dot(spiderRight, toPlayer) > 0f && canTurnRight)
        {
            targetAngle = 90; // turn right
        }
        else if (Vector3.Dot(spiderRight, toPlayer)  < 0f && canTurnLeft)
        {
            targetAngle = -90; // turn left
        }
        else if (canMoveForward)
        {
            targetAngle = 0;
        }
        else if (canTurnRight)
        {
            targetAngle = 90;
        }
        else
        {
            targetAngle = -90;
        }

        transform.Rotate(0f, targetAngle, 0f);

        StartCoroutine(BranchExitTime());

        //isTurning = false;

    }

    public bool CheckForward()
    {
        Debug.DrawRay(transform.position, transform.forward * wallCheckLength);
        return Physics.Raycast(transform.position, transform.forward, wallCheckLength);
    }

    public bool CheckRight()
    {
        if (Physics.Raycast(transform.position, transform.right, wallCheckLength))
            return false; 
        else return true;
    }

    public bool CheckLeft()
    {
        if (Physics.Raycast(transform.position, -transform.right, wallCheckLength))
            return false;
        else return true;
    }

    public IEnumerator BranchExitTime()
    {
        yield return new WaitForSeconds(0.5f);
        branchDetected = false;
        isTurning = false;
    }
}
