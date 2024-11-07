using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Creating KeyCode variables for each action that is tied to a key press
    //to make passing the key into functions easier. 
    private KeyCode _jump;
    private KeyCode _changeSize;
    private KeyCode _inventory;

    public float xInput, xInputRaw;
    public float zInput, zInputRaw;

    public bool PressedJump;
    public bool HoldingJump;
    public bool SizeChangeTriggered;

    public bool ToggledInventory;

    private void Start()
    {
        SetDefaultKeyBinds();
    }
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        xInputRaw = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxis("Vertical");
        zInputRaw = Input.GetAxisRaw("Vertical");

        PressedJump = CheckForKeyQuickPress(_jump);
        HoldingJump = CheckForKeyPress(_jump);

        SizeChangeTriggered = CheckForKeyQuickPress(_changeSize);

        ToggledInventory = CheckForKeyQuickPress(_inventory);
    }

    //Returns true if the key passed in as an argument is being held down
    private bool CheckForKeyPress(KeyCode key)
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

    private void SetDefaultKeyBinds()
    {
        _jump = KeyCode.Space;
        _changeSize = KeyCode.LeftShift;
        _inventory = KeyCode.Q;
    }
}
