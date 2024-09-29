using Game.Player.StateMachine;
using UnityEngine;

namespace Game.Player.States
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(PlayerController player) : base(player) { }

        float xInputRaw;
        float zInputRaw;

        float jumpTimer = 0;

        public override void Enter()
        {
            base.Enter();
            jumpTimer = 0;
            player.data.jumpCount++;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            if (!player.input.HoldingJump)
            {
                player.PSM.ChangeState(player.inAirState);
            }

            //On player's second successive jump, trigger the flight-time countdown
            if (player.data.jumpCount == 2)
            {
                player.flightTimer = player.data.maxFlightTime;
            }

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();


            if (jumpTimer >= player.data.maxJumpFrames)
            {
                player.PSM.ChangeState(player.inAirState);
            }
            else
            {
                player.rb.AddForce(new Vector3(0, player.data.jumpForce, 0));
                jumpTimer++;
            }

        }

        public void MovePlayer()
        {
            float currentSpeed = player.rb.velocity.magnitude;

            Vector3 moveForce = new Vector3(xInputRaw, 0, zInputRaw) * player.data.moveForce;

            //Stop applying force if player has reached their max speed
            bool isOverMaxSpeed = currentSpeed > player.data.maxSpeed;
            if (isOverMaxSpeed)
                moveForce = Vector3.zero;

            player.rb.AddForce(moveForce);
        }
    }
}
