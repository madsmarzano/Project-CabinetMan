using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads.
/// This script is the core of the Player controller. It uses a state machine to change between states such as Idle, Moving, Jumping, etc.
/// </summary>

public class Player : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public CapsuleCollider cc;

    //public Transform lookDir;
    //public Transform playerBase; // For use in checking for ground

    [HideInInspector]
    public PlayerData data; // This is the main instance of PlayerData that is referenced.

    [Header("Size-Specific Data")]
    public PlayerData bugSizeData;
    public PlayerData humanSizeData;

    [Header("Jumping and Movement")]
    public bool isGrounded;
    public LayerMask ground; //-- trying a different approach, I think this will be too confusing (MM 10/23/24)
    public float jumpTimer = 0;
    public float flightTimer = 0f; //Amount of the time the player can spend flying. 
    public float groundCheckLength;
    [HideInInspector] public Vector2 movementAxes;

    [Header("Player Abilities")]
    public bool canJump = true;
    public bool canChangeSize = true;

    [Header("Vent Stuff")]
    public bool isInVent = false;

    public PlayerStateMachine stateMachine;

    #region Variables for Player States
    public PlayerGroundedState groundedState;
    public PlayerIdleState idleState;
    public PlayerMovingState movingState;
    public PlayerJumpingState jumpState;
    public PlayerFallingState fallingState;
    public PlayerLandedState landedState;

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();

        //ground = LayerMask.GetMask("Ground");

        stateMachine = new PlayerStateMachine();

        //Create instances of each player state and store them in a variable for easy access.
        groundedState = new PlayerGroundedState(this, stateMachine);
        idleState = new PlayerIdleState(this, stateMachine);
        movingState = new PlayerMovingState(this, stateMachine);
        jumpState = new PlayerJumpingState(this, stateMachine);
        fallingState = new PlayerFallingState(this, stateMachine);
        landedState = new PlayerLandedState(this, stateMachine);
    }

    private void Start()
    {
        //Set the player to be idle at the start of each scene.
        stateMachine.Initialize(idleState);

        //data.jumpCount = 0;
    }

    private void Update()
    {
        stateMachine.currentState.Update();

        movementAxes = InputManager.GetMovementInputRaw();

        //Determines how long player can fly for.
        //Might move this into one of the states.
        if (flightTimer > 0f)
        {
            flightTimer -= Time.deltaTime;
        }
        else
        {
            flightTimer = 0f;
        }

        //transform.rotation = orientation.rotation;

        isGrounded = GroundCheck();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    public void SetPlayerDataForSize(int s)
    {
        //Takes the enum index as a parameter: 1 -- Human, 2 -- Bug
        if (s == 1)
        {
            data = humanSizeData;
        }
        else
        {
            data = bugSizeData;
        }
    }

    /// <summary>
    /// Checks beneath the Player for an object that has the "Ground" tag.
    /// </summary>
    /// <returns> True if ground is detected; false if ground is not detected.</returns>
    private bool GroundCheck()
    {
        Debug.DrawRay(transform.position, Vector3.down * groundCheckLength);
        return Physics.Raycast(transform.position, Vector3.down, data.height, ground);
        //return Physics.CheckSphere(transform.position - data.groundCheckOffset, data.groundCheckRadius, ground);
    }

    /// <summary>
    /// Moves the player along the x and/or z axes. 
    /// This function is called from all PlayerState scripts where the player is able to move on both axes.
    /// Their velocity on either of these axes is limited to a specified maxSpeed set in PlayerData.
    /// </summary>
    public void Move()
    {
        //Vector3 forward = Vector3.forward * Camera.main.transform.right;
        Vector3 moveDirection = Camera.main.transform.right * movementAxes.x + Camera.main.transform.forward * movementAxes.y;
        //Vector3 forward = new Vector3(Camera.main.transform.right.z, 0.0f, Camera.main.transform.forward.z);
        //Vector3 moveDirection = (forward * input.xInputRaw + Camera.main.transform.right * input.zInputRaw + Vector3.up * rb.velocity.y);
        //Vector3 moveDirection = transform.right * input.xInputRaw + transform.forward * input.zInputRaw;
        //Vector3 moveDirection = new Vector3(transform.right * input.xInputRaw, 0, input.zInputRaw) * data.acceleration;

        //cancel out y value so player doesn't fly away
        moveDirection.y *= 0;

        rb.AddForce(moveDirection.normalized * data.acceleration);

        //Get the velocity of the player on the x and z axes only
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limit velocity to max speed
        if (flatVel.magnitude > data.maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * data.maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
}
