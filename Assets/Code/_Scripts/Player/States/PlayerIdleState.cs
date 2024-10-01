using CabinetMan.Player.StateMachine;
using UnityEngine;

namespace CabinetMan.Player.States
{
    public class PlayerIdleState : PlayerState
    {
        protected float xInput, zInput;

        public PlayerIdleState(Player player) : base(player) { }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void Update()
        {
            base.Update();
            xInput = player.input.moveDirRaw.x;
            zInput = player.input.moveDirRaw.z;

            if (xInput != 0 || zInput != 0)
                player.stateMachine.ChangeState(player.movingState);

            if (player.input.PressedJump)
                player.stateMachine.ChangeState(player.jumpingState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            //If player was moving prior to becoming idle, slow down to a stop
            if (player.rb.velocity.magnitude > 0)
            {
                player.movement.SlowDown(player.rb, player.data);
            }
        }
    }
}
