using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
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

        //Slows the player down if they had been moving prior to becoming idle.
        if (player.rb.velocity.magnitude > 0)
        {
            player.rb.velocity = Vector3.Lerp(player.rb.velocity, Vector3.zero, player.data.slowDownSpeed * Time.deltaTime);
        }
    }

    public override void Update()
    {
        base.Update();
        if (input.xInputRaw != 0 || input.zInputRaw != 0)
        {
            stateMachine.ChangeState(player.movingState);
        }
    }
}
