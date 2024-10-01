using CabinetMan.Player.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabinetMan.Player.States
{
    public class PlayerMovingState : PlayerGroundedState
    {
        public PlayerMovingState (PlayerController player) : base (player) { }

        float xInputRaw;
        float zInputRaw;

        public override void Enter()
        {
            base.Enter();
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

            if (xInput == 0 && zInput == 0)
            {
                player.PSM.ChangeState(player.idleState);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            MovePlayer();
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
