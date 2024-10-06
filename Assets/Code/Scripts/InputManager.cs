using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyCode _jump;

    public float xInput, xInputRaw;
    public float zInput, zInputRaw;

    public bool PressedJump;
    public bool HoldingJump;

    private void Start()
    {
        _jump = KeyCode.Space;
    }
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        xInputRaw = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxis("Vertical");
        zInputRaw = Input.GetAxisRaw("Vertical");

        PressedJump = CheckForKeyQuickPress(_jump);
        HoldingJump = CheckforKeyPress(_jump);
    }

    private bool CheckforKeyPress(KeyCode key)
    {
        if (Input.GetKey(key))
            return true;
        else if (Input.GetKeyDown(key))
            return true;
        else if (Input.GetKeyUp(key))
            return false;

        return false;
    }

    private bool CheckForKeyQuickPress(KeyCode key)
    {
        if (Input.GetKeyDown(key))
            return true;
        else if (Input.GetKeyUp(key))
            return false;

        return false;
    }
}
