using UnityEngine;

public class Player : MonoBehaviour
{
    public InputHandler inputHandler { get; private set; }

    public PlayerData playerData;

    [HideInInspector]
    public Rigidbody rb;

    //temporarily these live here, I think they will move once I figure out states
    protected float xInput;
    protected float zInput;
    protected float xInputRaw;
    protected float zInputRaw;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //using this temporarily to test out the movement using the input handler
        xInput = inputHandler.moveDir.x;
        xInputRaw = inputHandler.moveDirRaw.x;
        zInput = inputHandler.moveDir.z;
        zInputRaw = inputHandler.moveDirRaw.z;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float currentSpeed = rb.velocity.magnitude;

        //If no movement input, slow to a stop
        if (xInputRaw == 0 && zInputRaw == 0)
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, playerData.slowDownSpeed * Time.deltaTime);

        Vector3 moveForce = new Vector3(xInputRaw, 0, zInputRaw) * playerData.acceleration;

        //Stop applying force if player has reached their max speed
        bool isOverMaxSpeed = currentSpeed > playerData.maxSpeed;
        if (isOverMaxSpeed)
            moveForce = Vector3.zero;

        rb.AddForce(moveForce);
    }
}
