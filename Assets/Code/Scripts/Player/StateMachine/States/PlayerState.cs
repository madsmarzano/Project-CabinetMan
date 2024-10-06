using UnityEngine;

/// <summary>
/// By Mads:
/// 
/// This is the base state that all of the individual player states inherit from.
/// Sets up functions for entering and exiting states as well as recreating the Update and FixedUpdate functions.
/// </summary>

public class PlayerState
{
    protected Player player;
    protected InputManager input;
    protected PlayerStateMachine stateMachine;

    public PlayerState(Player player, InputManager input, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.input = input;
        this.stateMachine = stateMachine;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

}