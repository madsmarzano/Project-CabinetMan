using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    public PlayerJumpingState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
    {
    }

    public float jumpTimer;

    public override void EnterState()
    {
        base.EnterState();
        player.data.jumpCount++;
        jumpTimer = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        //Jumping behavior
        if(jumpTimer >= player.data.maxJumpFrames)
        {
            jumpTimer = 0;
            stateMachine.ChangeState(player.fallingState);
        }
        else
        {
            player.rb.AddForce(new Vector3(0, player.data.jumpForce, 0));
            jumpTimer++;
        }

        //Allow player to move while jumping.
        player.Move();
    }

    public override void Update()
    {
        base.Update();

        if (!input.HoldingJump)
        {
            jumpTimer = 0;
            stateMachine.ChangeState(player.fallingState);
        }

        if (player.data.jumpCount == 2)
        {
            player.flightTimer = player.data.maxFlightTime;
        }
    }
}
