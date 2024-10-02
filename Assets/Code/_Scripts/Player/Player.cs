using CabinetMan.Player.State;
using CabinetMan.Player.StateMachine;
using CabinetMan.Player.States;
using UnityEngine;

namespace CabinetMan.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Behaviors")]
        public PlayerMovement movement;
        //MouseLook script goes here
        
        [HideInInspector]
        public InputHandler input;

        [HideInInspector]
        public PlayerData data;

        [HideInInspector]
        public Rigidbody rb;

        [HideInInspector]
        public CapsuleCollider cc;

        public PlayerStateMachine stateMachine;

        public PlayerIdleState idleState;
        public PlayerMovingState movingState;
        public PlayerJumpingState jumpingState;
        public PlayerFallingState fallingState;
        public PlayerLandedState landedState;

        public bool isGrounded;
        public LayerMask ground;

        public float flightTimer = 0f;

        private void Awake()
        {
            movement = GetComponent<PlayerMovement>();
            input = GetComponent<InputHandler>();
            rb = GetComponent<Rigidbody>();
            cc = GetComponent<CapsuleCollider>();

            stateMachine = new PlayerStateMachine();

            idleState = new PlayerIdleState(this);
            movingState = new PlayerMovingState(this);
            jumpingState = new PlayerJumpingState(this);
            fallingState = new PlayerFallingState(this);
            landedState = new PlayerLandedState(this);

            ground = LayerMask.GetMask("Ground");

        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            stateMachine.currentState.Update();

            isGrounded = GroundCheck();

            //flight timer stuff
            if (flightTimer > 0f)
            {
                flightTimer -= Time.deltaTime;
            }
            else
            {
                flightTimer = 0f;
            }
        }

        private void FixedUpdate()
        {
            stateMachine.currentState.FixedUpdate();
        }

        private bool GroundCheck()
        {
            return Physics.CheckSphere(transform.position - data.groundCheckOffset, data.groundCheckRadius, ground);
        }

    }
}
