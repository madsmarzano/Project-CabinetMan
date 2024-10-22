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
    public PlayerGroundedState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
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
    }

    public override void Update()
    {
        base.Update();

        if (player.input.PressedJump)
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
