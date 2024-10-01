using CabinetMan.Player.StateMachine;

namespace CabinetMan.Player.States
{
    /// <summary>
    /// By Mads: State that represents the player when they are on the ground and moving.
    /// Transitions to the idle state if no horizontal/vertical input is detected.
    /// Can also transition to Jumping state. 
    /// </summary>
    public class PlayerMovingState : PlayerState
    {
        public PlayerMovingState(Player player) : base (player) { }

        protected float xInputRaw;
        protected float zInputRaw;

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            if (xInputRaw == 0 && zInputRaw == 0)
            {
                //If no input from the player, change state to IDLE
                player.stateMachine.ChangeState(player.idleState);
            }

            if (player.input.PressedJump)
            {
                player.stateMachine.ChangeState(player.jumpingState);
            }

            if (!player.isGrounded)
            {
                player.stateMachine.ChangeState(player.fallingState);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            player.movement.Move(xInputRaw, zInputRaw, player.rb, player.data);
        }

    }
}
