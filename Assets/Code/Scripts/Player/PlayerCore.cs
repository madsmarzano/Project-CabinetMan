using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [HideInInspector]
    public InputHandler input;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public CapsuleCollider cc;

    [HideInInspector]
    public PlayerData data; // This is the main instance of PlayerData that is referenced.
    public PlayerData bugSizeData;
    public PlayerData humanSizeData;

    public bool isGrounded;
    public LayerMask ground;

    private void Awake()
    {
        input = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();

        ground = LayerMask.GetMask("Ground");
    }

    public void SetPlayerDataForSize(int s)
    {
        //Takes the enum index as a parameter: 1 -- Human, 2 -- Bug
        if (s == 1)
        {
            data = humanSizeData;
        }
        else
        {
            data = bugSizeData;
        }
    }
}
