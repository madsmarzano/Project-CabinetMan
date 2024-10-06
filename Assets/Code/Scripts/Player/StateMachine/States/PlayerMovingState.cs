/// <summary>
/// By Mads:
/// 
/// Represents the behavior of the player when they are on the ground and moving.
/// </summary>
public class PlayerMovingState : PlayerGroundedState
{
    public PlayerMovingState(Player player, InputManager input, PlayerStateMachine stateMachine) : base(player, input, stateMachine)
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
        player.Move(); //Move function is called from the Player class because many states use it. This might change.
    }

    public override void Update()
    {
        base.Update();

        //If no input is detected from the player, change to idle state
        if (input.xInputRaw == 0 && input.zInputRaw == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
