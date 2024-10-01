using UnityEngine;

namespace CabinetMan.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public InputHandler input;
        [HideInInspector]
        public Rigidbody rb;
        [HideInInspector]
        public CapsuleCollider cc;

        [HideInInspector]
        public PlayerData data; // This is the main instance of PlayerData that is referenced.

        public PlayerData humanSizeData;
        public PlayerData bugSizeData;

        public float xInputRaw;
        public float zInputRaw;

        public float jumpTimer = 0;
        public bool canJump = true;

        public enum PlayerState
        {
            IDLE,
            MOVING, //Grounded
            JUMPING,
            FALLING, //In the air but not jumping
            LANDED, //Resets flightTimer and jumpCount, then transitions to a grounded state like IDLE or MOVING.
        }

        public PlayerState currentState;

        public bool isGrounded;
        public LayerMask ground;

        public float flightTimer = 0f;

        private void Awake()
        {
            input = GetComponent<InputHandler>();
            rb = GetComponent<Rigidbody>();
            cc = GetComponent<CapsuleCollider>();

            ground = LayerMask.GetMask("Ground");

            data = humanSizeData;

        }

        private void Start()
        {
            currentState = PlayerState.IDLE;

            data.jumpCount = 0;
        }

        private void Update()
        {
            //switch statement that handles transitions between states
            switch (currentState)
            {
                case PlayerState.IDLE:
                    IdleUpdate(); break;
                case PlayerState.MOVING:
                    MovingUpdate(); break;
                case PlayerState.JUMPING:
                    JumpingUpdate(); break;
                case PlayerState.FALLING:
                    FallingUpdate(); break;
                case PlayerState.LANDED:
                    LandedUpdate(); break;
            }

            //Probably should move this into one of the states eventually.
            if (flightTimer > 0f)
            {
                flightTimer -= Time.deltaTime;
            }
            else
            {
                flightTimer = 0f;
            }

            isGrounded = GroundCheck();

            xInputRaw = input.moveDirRaw.x;
            zInputRaw = input.moveDirRaw.z;
        }

        private void FixedUpdate()
        {
            switch (currentState)
            {
                case PlayerState.IDLE:
                    IdleFixedUpdate(); break;
                case PlayerState.MOVING:
                    MovingFixedUpdate(); break;
                case PlayerState.JUMPING:
                    JumpingFixedUpdate(); break;
                case PlayerState.FALLING:
                    FallingFixedUpdate(); break;
            }
        }

        private bool GroundCheck()
        {
            return Physics.CheckSphere(transform.position - data.groundCheckOffset, data.groundCheckRadius, ground);
        }

        public void Move()
        {
            float currentSpeed = rb.velocity.magnitude;

            Vector3 moveForce = new Vector3(xInputRaw, 0, zInputRaw) * data.moveForce;

            //Stop applying force if player has reached their max speed
            bool isOverMaxSpeed = currentSpeed > data.maxSpeed;
            if (isOverMaxSpeed)
                moveForce = Vector3.zero;

            rb.AddForce(moveForce);
        }


        //-----States-----
        public void IdleUpdate()
        {
            if (xInputRaw != 0 || zInputRaw != 0)
                currentState = PlayerState.MOVING;

            if (input.PressedJump)
            {
                data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }
        }

        public void IdleFixedUpdate()
        {
            if (rb.velocity.magnitude > 0)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, data.slowDownSpeed * Time.deltaTime);
            }
        }

        public void MovingUpdate()
        {
            if (xInputRaw == 0 && zInputRaw == 0)
                currentState = PlayerState.IDLE; //If no input from the player, switch to idle state

            if (input.PressedJump)
            {
                data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }
        }

        public void MovingFixedUpdate()
        {
            Move();
        }

        public void JumpingUpdate()
        {
            if (!input.HoldingJump)
            {
                jumpTimer = 0;
                currentState = PlayerState.FALLING;
            }

            if (data.jumpCount == 2)
            {
                flightTimer = data.maxFlightTime;
            }
        }

        public void JumpingFixedUpdate()
        {
            Move();

            if (jumpTimer >= data.maxJumpFrames)
            {
                jumpTimer = 0;
                currentState = PlayerState.FALLING;
            }
            else
            {
                rb.AddForce(new Vector3(0, data.jumpForce, 0));
                jumpTimer++;
            }
        }

        public void FallingUpdate()
        {
            if (input.PressedJump && canJump)
            {
                data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }

            if (isGrounded)
            {
                currentState = PlayerState.LANDED;
            }

            if (flightTimer == 0 && data.jumpCount > 2)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }

        public void FallingFixedUpdate()
        {
            Move();
        }

        public void LandedUpdate()
        {
            jumpTimer = 0;
            data.jumpCount = 0;
            flightTimer = 0;
            canJump = true;

            if (xInputRaw != 0 || zInputRaw != 0)
            {
                currentState = PlayerState.MOVING;
            }
            else
            {
                currentState = PlayerState.IDLE;
            }
        }
    }
}
