using UnityEngine;

/// <summary>
/// By Mads:
/// 
/// Represents the player when they are in the air but not actively jumping.
/// They are still able to move on the X and Z axes.
/// </summary>
public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
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

        //Allow player to move while falling.
        player.Move();
    }

    public override void Update()
    {
        base.Update();

        if (InputManager.JumpPressed() && player.canJump)
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
