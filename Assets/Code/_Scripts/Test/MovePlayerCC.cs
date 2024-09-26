using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class MovePlayerCC : MonoBehaviour
{
    private CharacterController _cc;
    public float gravity = -9.8f;
    public float speed = 0.1f;

    public float JumpForce = 1.0f;

    public float sensTurn = 5.0f;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        //Reset mouse position
        transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        //Rotate player when mouse moves left and right
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensTurn, 0);

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 myDirection = new Vector3(deltaX, gravity, deltaZ);

        if (Input.GetButtonDown("Jump"))
        {
            myDirection.y += JumpForce;
        }

        //adjust for frame rate
        myDirection = myDirection * Time.deltaTime;

        //limit max speed
        myDirection = Vector3.ClampMagnitude(myDirection, speed);

        //control direction to match the game space instead of the object orientation
        Vector3 myPlayerDirection = transform.TransformDirection(myDirection);

        _cc.Move(myPlayerDirection);
    }
}
