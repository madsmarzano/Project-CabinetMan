using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Mads.
/// Parent class for all vent-specific Player States.
/// Disables jumping/flying and size-changing.
/// </summary>

public class PlayerVentState : PlayerState
{
    public PlayerVentState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.canJump = false;
        player.canChangeSize = false;
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
    }
}
