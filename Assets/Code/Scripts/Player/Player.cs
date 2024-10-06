using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public InputManager input;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public CapsuleCollider cc;

    [HideInInspector]
    public PlayerData data; // This is the main instance of PlayerData that is referenced.
    public PlayerData bugSizeData;
    public PlayerData humanSizeData;

    public bool isGrounded;
    public LayerMask ground;

    public float jumpTimer = 0;
    public bool canJump = true;

    public PlayerStateMachine stateMachine;

    #region Variables for Player States
    public PlayerGroundedState groundedState;
    public PlayerIdleState idleState;
    public PlayerMovingState movingState;
    public PlayerJumpingState jumpState;
    public PlayerFallingState fallingState;
    public PlayerLandedState landedState;

    #endregion

    public float flightTimer = 0f;

    private void Awake()
    {
        input = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();

        ground = LayerMask.GetMask("Ground");

        stateMachine = new PlayerStateMachine();

        groundedState = new PlayerGroundedState(this, input, stateMachine);
        idleState = new PlayerIdleState(this, input, stateMachine);
        movingState = new PlayerMovingState(this, input, stateMachine);
        jumpState = new PlayerJumpingState(this, input, stateMachine);
        fallingState = new PlayerFallingState(this, input, stateMachine);
        landedState = new PlayerLandedState(this, input, stateMachine);
    }

    private void Start()
    {
        //Set the player to be idle at the start of each scene.
        stateMachine.Initialize(idleState);

        data.jumpCount = 0;
    }

    private void Update()
    {
        stateMachine.currentState.Update();

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

    private bool GroundCheck()
    {
        return Physics.CheckSphere(transform.position - data.groundCheckOffset, data.groundCheckRadius, ground);
    }

    /// <summary>
    /// Moves the player along the x and/or z axes.
    /// Their velocity on either of these axes is limited to a specified maxSpeed set in PlayerData.
    /// </summary>
    public void Move()
    {
        Vector3 moveForce = new Vector3(input.xInputRaw, 0, input.zInputRaw) * data.acceleration;

        rb.AddForce(moveForce);

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limit velocity to max speed
        if (flatVel.magnitude > data.maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * data.maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
}
