using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseY = 1,
        MouseX = 2,
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor;
    public float sensitivityVert;

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation
            transform.Rotate(0, Input.GetAxis("Mouse Y") * sensitivityVert, 0);
        }
        else
        {
            //both
        }
    }
}
