using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        player.Move();
    }

    public override void Update()
    {
        base.Update();

        if (player.input.PressedJump && player.canJump)
        {
            player.data.jumpCount++;
            stateMachine.ChangeState(player.jumpState);
        }

        if (player.isGrounded)
        {
            stateMachine.ChangeState(player.landedState);
        }

        if (player.flightTimer == 0 && player.data.jumpCount > 2)
        {
            player.canJump = false;
        }
        else
        {
            player.canJump = true;
        }
    }
}
