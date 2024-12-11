using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{

    public static GameObject interactionTarget = null;

    public void PerformAction(int action)
    {
        UIController.ResetToDefault();

        switch (action)
        {
            case 0:
                //Check action
                interactionTarget.GetComponent<Interactable>().OnCheck();
                break;
            case 1:
                //Use item action
                interactionTarget.GetComponent<Interactable>().OnItemUsed();
                break;
            case 2:
                //Do nothing action
                break;
        }
    }
}
