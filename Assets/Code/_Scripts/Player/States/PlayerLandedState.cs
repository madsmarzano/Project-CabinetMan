using CabinetMan.Player.StateMachine;

namespace CabinetMan.Player.States
{
    public class PlayerLandedState : PlayerState
    {
        protected float xInputRaw, zInputRaw;
        public PlayerLandedState(Player player) : base(player) { }

        public override void EnterState()
        {
            base.EnterState();
            player.data.jumpCount = 0;
            player.flightTimer = 0;
        }

        public override void Update()
        {
            base.Update();

            xInputRaw = player.input.moveDirRaw.x;
            zInputRaw = player.input.moveDirRaw.z;

            if (xInputRaw != 0 || zInputRaw != 0)
            {
                player.stateMachine.ChangeState(player.movingState);
            }
            else
            {
                player.stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
