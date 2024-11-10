using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads:
/// 
/// A general state that represents the player when they are on the ground.
/// The Player never actually enters this state. Other states such as Moving and Idle inherit from it.
/// </summary>

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.canChangeSize = true;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.canChangeSize = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();

        if (InputManager.JumpPressed())
        {
            player.data.jumpCount++;
            stateMachine.ChangeState(player.jumpState);
        }

        if (!player.isGrounded)
        {
            stateMachine.ChangeState(player.fallingState);
        }
    }
}
