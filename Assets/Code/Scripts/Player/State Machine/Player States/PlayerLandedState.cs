using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandedState : PlayerState
{
    public PlayerLandedState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
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

        if (input.xInputRaw != 0 || input.zInputRaw != 0)
        {
            stateMachine.ChangeState(player.movingState);
        }
        else
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
