using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inventory"))
        {
            //Inactivate object
            other.gameObject.SetActive(false);

            //Add item to inventory list

        }
    }

}
