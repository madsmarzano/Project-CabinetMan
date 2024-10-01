using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

namespace CabinetMan.Player.StateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState currentState { get; private set; }

        public void Initialize(PlayerState startingState)
        {
            currentState = startingState;
            currentState.EnterState();
        }

        public void ChangeState(PlayerState newState)
        {
            currentState.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
    }
}
