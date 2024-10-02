using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private KeyCode _jump;

    public Vector3 moveDir;
    public Vector3 moveDirRaw;

    public bool PressedJump;
    public bool HoldingJump;

    private void Start()
    {
        _jump = KeyCode.Space;
    }
    private void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirRaw = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

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
