using CabinetMan.Player.StateMachine;
using UnityEngine;

namespace CabinetMan.Player.State
{
    public class PlayerJumpingState : PlayerState
    {
        public PlayerJumpingState(Player player) : base(player) { }

        float xInputRaw;
        float zInputRaw;

        float jumpTimer = 0;

        public override void EnterState()
        {
            base.EnterState();
            jumpTimer = 0;
            player.data.jumpCount++;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            if (!player.input.HoldingJump)
            {
                player.stateMachine.ChangeState(player.fallingState);
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
                player.stateMachine.ChangeState(player.fallingState);
            }
            else
            {
                player.rb.AddForce(new Vector3(0, player.data.jumpForce, 0));
                jumpTimer++;
            }

            if (xInputRaw != 0 || zInputRaw != 0)
            {
                player.movement.Move(xInputRaw, zInputRaw, player.rb, player.data);
            }
            else
            {
                //player.movement.SlowDown(player.rb, player.data);
            }

        }
        }
}
