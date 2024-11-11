using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
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
        if (player.movementAxes.x != 0 || player.movementAxes.y != 0)
        {
            stateMachine.ChangeState(player.movingState);
        }
    }
}
