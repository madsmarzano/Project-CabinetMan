using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement")]
    public float acceleration = 15f;
    public float maxSpeed = 10f;
    [Tooltip("A higher value will cause the player to slow to a stop more quickly.")]
    public float slowDownSpeed = 3f;

    [Header("Jumping and Flying")]
    public float jumpForce = 5f;
    public float maxJumpFrames = 10f;
    public float jumpCount;
    [Tooltip("Total time in seconds that player is able to fly.")]
    public float maxFlightTime = 5.0f;

    [Header("Ground/Slope/Step Checks")]
    public Vector3 groundCheckOffset = new Vector3(0, 1.5f, 0);
    public float groundCheckRadius = 0.95f;
    public float height;
    public bool enableGroundCheckGizmo;
    //public bool showStateInConsole;

}
