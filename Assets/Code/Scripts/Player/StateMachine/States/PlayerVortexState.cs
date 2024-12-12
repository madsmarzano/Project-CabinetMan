using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Literally just a clone of the paused state

public class PlayerVortexState : PlayerState
{
    public PlayerVortexState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
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

        //turn off player light
        player.playerLight.SetActive(false);
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

        //turn on player light
        player.playerLight.SetActive(true);
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
