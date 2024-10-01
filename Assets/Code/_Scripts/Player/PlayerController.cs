namespace CabinetMan.Player
{
    using CabinetMan.Player.StateMachine;
    using CabinetMan.Player.States;
    using UnityEngine;

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

        [HideInInspector]
        public PlayerData data; // This is the main instance of PlayerData that is referenced.

        public PlayerData humanSizeData;
        public PlayerData bugSizeData;

        [HideInInspector]
        public PlayerIdleState idleState;
        public PlayerMovingState movingState;
        public PlayerJumpState jumpState;
        public PlayerInAirState inAirState;

        public bool isGrounded;
        public LayerMask ground;

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

            ground = LayerMask.GetMask("Ground");

            data = humanSizeData;

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
            return Physics.CheckSphere(transform.position - data.groundCheckOffset, data.groundCheckRadius, ground);
        }
    }
}
