using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentFan : MonoBehaviour
{
    public GameObject _player;
    public Player playerController;

    public Transform vortexStart;
    public Transform vortexEnd;
    public Transform vortexExit;

    public bool vortexActivated;
    public float vortexTimer = 0f;

    public float step; //distance the player moves per second when caught in the vortex

    private void Update()
    {
        if (vortexTimer > 0f)
        {
            //Move towards vortex end
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, vortexEnd.position, step * Time.deltaTime);

            //Tick down timer
            vortexTimer -= Time.deltaTime;
        }
        else if (vortexActivated)
        {
            //Timer has reached 0 before player has been able to escape vortex
            //Trigger death screen; Player restarts from beginning of level 2

            //putting this here for testing
            ExitVortex();
        }
        else
        {
            vortexTimer = 0f;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if player has activated the trigger
        if (other.CompareTag("Player") && !vortexActivated)
        {
            //Make sure this fan stores the reference of the Player 
            _player = other.gameObject;
            playerController = _player.GetComponent<Player>();
            //Start vortex state
            StartVortex();
        }
    }

    public void StartVortex()
    {
        vortexActivated = true;

        //Start the timer
        vortexTimer = 5f;

        //Calculate the amount player will move per second 
        float distanceFromFan = Vector3.Distance(vortexStart.position, vortexEnd.position);
        step = distanceFromFan / 5f;

        //Put player in Paused state
        playerController.stateMachine.ChangeState(playerController.pausedState);

        //Set the player's position to be the vortex start position
        _player.transform.position = vortexStart.position;
    }

    public void ExitVortex()
    {
        Debug.Log("Exiting Vortex");

        vortexActivated = false;
        //Move player to the vortex exit point
        _player.transform.position = vortexExit.position;

        //Put player in Idle state
        playerController.stateMachine.ChangeState(playerController.idleState);

        //Trigger some kind of wait time before the fan starts up again
    }
}
