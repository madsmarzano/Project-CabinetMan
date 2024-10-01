using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabinetMan.Player.StateMachine
{
    public class PlayerState
    {
        protected Player player;
        protected PlayerData data;
        protected InputHandler input;
        public PlayerState(Player _player)
        {
            player = _player;
        }

        public virtual void EnterState() { }
        public virtual void ExitState() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}
