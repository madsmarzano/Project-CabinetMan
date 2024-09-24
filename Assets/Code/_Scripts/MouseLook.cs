using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public 

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation
        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation
        }
        else
        {
            //both horizontal and vertical
        }


    }
}
