using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandedState : PlayerState
{
    public PlayerLandedState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.data.jumpCount = 0;
        player.flightTimer = 0;
        player.canJump = true;
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

        if (player.movementAxes.x != 0 || player.movementAxes.y != 0)
        {
            stateMachine.ChangeState(player.movingState);
        }
        else
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
