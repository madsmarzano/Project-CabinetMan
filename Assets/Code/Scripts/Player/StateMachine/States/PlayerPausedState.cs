
using System.Diagnostics;
using UnityEngine;

public class PlayerPausedState : PlayerState
{
    public PlayerPausedState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        //Disable abilities
        player.canJump = false;
        player.canChangeSize = false;
        //Disable camera
        player.cameraEnabled = false;
        //Disable gravity on rigidbody
        player.rb.useGravity = false;

    }

    public override void ExitState()
    {
        base.ExitState();
        //Enable abilities
        player.canJump = true;
        player.canChangeSize = true;
        //Enable camera
        player.cameraEnabled = true;
        //Enable gravity on rigidbody
        player.rb.useGravity = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        //Slows the player down if they had been moving prior to becoming paused.
        if (player.rb.velocity.magnitude > 0)
        {
            player.rb.velocity = Vector3.Lerp(player.rb.velocity, Vector3.zero, player.data.slowDownSpeed * Time.deltaTime);
        }
    }

    public override void Update()
    {
        base.Update();
    }
}
