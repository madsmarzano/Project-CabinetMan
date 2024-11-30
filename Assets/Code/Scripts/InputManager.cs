using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    //Creating KeyCode variables for each action that is tied to a key press
    //to make passing the key into functions easier. 
    private static KeyCode _jump;
    private static KeyCode _changeSize;
    private static KeyCode _inventory;
    private static KeyCode _interact;
    private static KeyCode _pause;

    //public bool UIselected; //used to select an item or action -- defaults to left mouse click

    public static Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public static Vector2 GetMovementInputRaw()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public static bool JumpPressed()
    {
        return Input.GetKeyDown(_jump);
    }

    public static bool JumpHeld()
    {
        if (Input.GetKey(_jump))
            return true;
        else if (Input.GetKeyDown(_jump))
            return true;
        else if (Input.GetKeyUp(_jump))
            return false;
        else return false;
    }

    public static bool SizeChangeTriggered()
    {
        return Input.GetKeyDown(_changeSize);
    }

    public static bool ToggledInventory()
    {
        return Input.GetKeyDown(_inventory);
    }

    public static bool InteractPressed()
    {
        return Input.GetKeyDown(_interact);
    }

    public static bool PausePressed()
    {
        return Input.GetKeyDown(_pause);
    }

    public static void SetDefaultKeyBinds()
    {
        _jump = KeyCode.Space;
        _changeSize = KeyCode.LeftShift;
        _inventory = KeyCode.Q;
        _interact = KeyCode.E;
        _pause = KeyCode.Escape;
    }
}
