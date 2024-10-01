using CabinetMan.Player.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabinetMan.Player.States
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerController player) : base(player) { }

        protected float xInput, xInputRaw;
        protected float zInput, zInputRaw;

        protected bool canJump;
        protected bool jumped;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            MovePlayer();
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            jumped = player.input.PressedJump;

            if (jumped && canJump)
            {
                player.PSM.ChangeState(player.jumpState);
            }

            if (player.isGrounded)
            {
                player.PSM.ChangeState(player.idleState); //change this to a landed state
            }

            if (player.flightTimer == 0 && player.data.jumpCount > 2)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
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
