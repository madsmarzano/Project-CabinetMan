using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentFan : MonoBehaviour
{
    public GameObject _player;
    public Player playerController;

    public Transform vortexStart;
    public Transform vortexEnd;
    public Transform vortexExit;

    public bool vortexActive;
    public bool vortexWaiting = false;
    public float vortexTimer = 0f;
    [Tooltip("Total amount of time in seconds that the vortex will last.")]
    public float vortexDuration = 5f;

    public float step; //distance the player moves per second when caught in the vortex

    public int exitClicks = 0;
    public bool lastClickedLeft = false;
    public bool lastClickedRight = false;

    //UI stuff
    public GameObject vortexUICanvas;
    public GameObject leftButtonUI;
    public GameObject rightButtonUI;

    private void Update()
    {
        if (vortexTimer > 0f)
        {
            //Move towards vortex end
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, vortexEnd.position, step * Time.deltaTime);

            //Tick down timer
            vortexTimer -= Time.deltaTime;
        }
        else if (vortexActive)
        {
            //Timer has reached 0 before player has been able to escape vortex
            //Trigger death screen; Player restarts from beginning of level 2

            SceneManager.LoadScene("FanDeath");

            //for now (REMOVE LATER)
            //ExitVortex();

        }
        else
        {
            vortexTimer = 0f;
            
        }

        //testing the exit condition
        if (vortexActive && Input.GetKeyDown(KeyCode.A))
        {
            if (lastClickedRight)
            {
                exitClicks++;
                lastClickedRight = false;
                lastClickedLeft = true;

                //UI
                leftButtonUI.SetActive(true);
                rightButtonUI.SetActive(false);
            }
            else if (!lastClickedLeft && !lastClickedRight)
            {
                exitClicks++;
                lastClickedLeft = true;

                //UI
                leftButtonUI.SetActive(true);
                rightButtonUI.SetActive(false);
            }
        }

        if (vortexActive && Input.GetKeyDown(KeyCode.D))
        {
            if (lastClickedLeft)
            {
                exitClicks++;
                lastClickedRight = true;
                lastClickedLeft = false;

                //UI
                leftButtonUI.SetActive(false);
                rightButtonUI.SetActive(true);
            }
            else if (!lastClickedLeft && !lastClickedRight)
            {
                exitClicks++;
                lastClickedRight = true;

                //UI
                leftButtonUI.SetActive(false);
                rightButtonUI.SetActive(true);
            }
        }

        if (vortexActive && exitClicks == 5)
        {
            vortexActive = false;
            //reset clicks
            exitClicks = 0;
            //end timer
            vortexTimer = 0f;
            ExitVortex();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if player has activated the trigger
        if (other.CompareTag("Player") && !vortexActive && !vortexWaiting)
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
        vortexActive = true;

        //Start the timer
        vortexTimer = vortexDuration;

        //Calculate the amount player will move per second 
        float distanceFromFan = Vector3.Distance(vortexStart.position, vortexEnd.position);
        step = distanceFromFan / vortexDuration;

        //Put player in Paused state
        playerController.stateMachine.ChangeState(playerController.pausedState);

        //Make player face the vent
        Camera.main.transform.forward = -vortexStart.forward;

        //Set the player's position to be the vortex start position
        _player.transform.position = vortexStart.position;
        
        //show UI
        vortexUICanvas.SetActive(true);
    }

    public void ExitVortex()
    {
        Debug.Log("Exiting Vortex");
        //Reset click variables
        lastClickedRight = false;
        lastClickedLeft = false;

        //Move player to the vortex exit point
        _player.transform.position = vortexExit.position;

        //Put player in Idle state
        playerController.stateMachine.ChangeState(playerController.idleState);

        //Deactivate UI
        vortexUICanvas?.SetActive(false);

        //Trigger wait time before the fan starts up again
        StartCoroutine(VortexWait());
    }

    public IEnumerator VortexWait()
    {
        vortexWaiting = true;
        yield return new WaitForSeconds(3f);
        vortexWaiting = false;
    }
}
