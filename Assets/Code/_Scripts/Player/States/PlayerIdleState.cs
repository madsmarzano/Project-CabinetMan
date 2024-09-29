using UnityEngine;

namespace Game.Player.States
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState (PlayerController player) : base (player) { }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update ()
        {
            base.Update();

            if (xInput != 0 || zInput != 0)
                player.PSM.ChangeState(player.movingState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            //If player was moving prior to becoming idle, slow down to a stop
            if (player.rb.velocity.magnitude > 0)
            {
                player.rb.velocity = Vector3.Lerp(player.rb.velocity, Vector3.zero, player.data.slowDownSpeed * Time.deltaTime);
            }
        }

    }
}
