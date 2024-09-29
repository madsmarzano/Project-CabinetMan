using Game.Player.StateMachine;
using Game.Player.States;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public PlayerStateMachine PSM;
        [HideInInspector]
        public InputHandler input;
        [HideInInspector]
        public Rigidbody rb;
        [HideInInspector]
        public CapsuleCollider cc;

        public PlayerData data;

        [HideInInspector]
        public PlayerIdleState idleState;
        public PlayerMovingState movingState;
        public PlayerJumpState jumpState;
        public PlayerInAirState inAirState;

        public bool isGrounded;

        public float flightTimer = 0f;

        private void Awake()
        {
            PSM = new PlayerStateMachine();
            input = GetComponent<InputHandler>();
            rb = GetComponent<Rigidbody>();
            cc = GetComponent<CapsuleCollider>();

            idleState = new PlayerIdleState(this);
            movingState = new PlayerMovingState(this);
            jumpState = new PlayerJumpState(this);
            inAirState = new PlayerInAirState(this);

        }

        private void Start()
        {
            PSM.Initialize(idleState);
        }

        private void Update()
        {
            PSM.currentState.Update();

            //Probably should move this into one of the states eventually.
            if (flightTimer > 0f)
            {
                flightTimer -= Time.deltaTime;
            }
            else
            {
                flightTimer = 0f;
            }

            isGrounded = GroundCheck();
        }

        private void FixedUpdate()
        {
            PSM.currentState.FixedUpdate();
        }

        private bool GroundCheck()
        {
            //Debug.DrawRay(transform.position, Vector3.down * 2.05f);
            return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2.05f);
        }
    }
}
