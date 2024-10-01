using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabinetMan.Player.StateMachine
{
    public class PlayerStateMachine
    {

        /// <summary>
        /// By Mads:
        /// Class that manages the transitions between states.
        /// </summary>
        public PlayerState currentState { get; private set; }

        public void Initialize(PlayerState startingState)
        {
            currentState = startingState;
            currentState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        // Will likely add in methods for Collisions and/or Triggers in the near future.

    }

    /// <summary>
    /// By Mads:
    /// This is a template class that all of the Player's states will be derived from.
    /// Gives derived scripts access to the PlayerController class.
    /// </summary>

    public class PlayerState
    {
        protected PlayerController player;

        public PlayerState(PlayerController playerController)
        {
            player = playerController;
        }

        //Using virtual methods instead of abstract methods so it's not mandatory that a derived class has to override them.
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }

    }
}
