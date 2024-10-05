using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabinetMan.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerCore player;

        //these might get moved out of here 
        public float xInputRaw;
        public float zInputRaw;

        public float jumpTimer = 0;
        public bool canJump = true;

        public enum PlayerState
        {
            IDLE, //Grounded, not moving
            MOVING, //Grounded
            JUMPING,
            FALLING, //In the air but not jumping
            LANDED, //Resets flightTimer and jumpCount, then transitions to a grounded state like IDLE or MOVING.
        }

        public PlayerState currentState;

        public float flightTimer = 0f;

        private void Awake()
        {
            player = GetComponent<PlayerCore>();
        }

        private void Start()
        {
            currentState = PlayerState.IDLE;

            player.data.jumpCount = 0;
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

            //Determines how long player can fly for.
            if (flightTimer > 0f)
            {
                flightTimer -= Time.deltaTime;
            }
            else
            {
                flightTimer = 0f;
            }

            player.isGrounded = GroundCheck();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;
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
            return Physics.CheckSphere(player.transform.position - player.data.groundCheckOffset, player.data.groundCheckRadius, player.ground);
        }

        public void Move()
        {
            float currentSpeed = player.rb.velocity.magnitude;

            Vector3 moveForce = new Vector3(xInputRaw, 0, zInputRaw) * player.data.moveForce;

            //Stop applying force if player has reached their max speed
            bool isOverMaxSpeed = currentSpeed > player.data.maxSpeed;
            if (isOverMaxSpeed)
                moveForce = Vector3.zero;

            player.rb.AddForce(moveForce);
        }


        #region Methods for Individual States
        public void IdleUpdate()
        {
            if (xInputRaw != 0 || zInputRaw != 0)
                currentState = PlayerState.MOVING;

            if (player.input.PressedJump)
            {
                player.data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }
        }

        public void IdleFixedUpdate()
        {
            if (player.rb.velocity.magnitude > 0)
            {
                player.rb.velocity = Vector3.Lerp(player.rb.velocity, Vector3.zero, player.data.slowDownSpeed * Time.deltaTime);
            }
        }

        public void MovingUpdate()
        {
            if (xInputRaw == 0 && zInputRaw == 0)
                currentState = PlayerState.IDLE; //If no input from the player, switch to idle state

            if (player.input.PressedJump)
            {
                player.data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }
        }

        public void MovingFixedUpdate()
        {
            Move();
        }

        public void JumpingUpdate()
        {
            if (!player.input.HoldingJump)
            {
                jumpTimer = 0;
                currentState = PlayerState.FALLING;
            }

            if (player.data.jumpCount == 2)
            {
                flightTimer = player.data.maxFlightTime;
            }
        }

        public void JumpingFixedUpdate()
        {
            Move();

            if (jumpTimer >= player.data.maxJumpFrames)
            {
                jumpTimer = 0;
                currentState = PlayerState.FALLING;
            }
            else
            {
                player.rb.AddForce(new Vector3(0, player.data.jumpForce, 0));
                jumpTimer++;
            }
        }

        public void FallingUpdate()
        {
            if (player.input.PressedJump && canJump)
            {
                player.data.jumpCount++;
                currentState = PlayerState.JUMPING;
            }

            if (player.isGrounded)
            {
                currentState = PlayerState.LANDED;
            }

            if (flightTimer == 0 && player.data.jumpCount > 2)
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
            player.data.jumpCount = 0;
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

        #endregion
    }
}
