using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement")]
    public float acceleration = 15f;
    public float maxSpeed = 10f;
    [Tooltip("A higher value will cause the player to slow to a stop more quickly.")]
    public float slowDownSpeed = 3f;

}
