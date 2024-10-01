using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CabinetMan.Player.StateMachine;

namespace CabinetMan.Player.States
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(PlayerController player) : base(player) { }

        protected float xInput;
        protected float zInput;
        protected bool jumped;

        public override void Enter()
        {
            base.Enter();
            player.flightTimer = 0;
            player.data.jumpCount = 0;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            xInput = player.input.moveDir.x;
            zInput = player.input.moveDir.z;
            jumped = player.input.PressedJump;

            if (jumped)
            {
                player.PSM.ChangeState(player.jumpState);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
