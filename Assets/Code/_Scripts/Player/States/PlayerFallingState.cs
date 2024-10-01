using CabinetMan.Player.StateMachine;

namespace CabinetMan.Player.States
{
    public class PlayerFallingState : PlayerState
    {
        public PlayerFallingState(Player player) : base(player) { }

        protected float xInput, xInputRaw;
        protected float zInput, zInputRaw;

        protected bool canJump;

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
            canJump = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (xInputRaw != 0 || zInputRaw != 0)
            {
                player.movement.Move(xInputRaw, zInputRaw, player.rb, player.data);
            }
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            if (player.input.PressedJump && canJump)
            {
                player.stateMachine.ChangeState(player.jumpingState);
            }

            if (player.isGrounded)
            {
                player.stateMachine.ChangeState(player.landedState);
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
    }
}
