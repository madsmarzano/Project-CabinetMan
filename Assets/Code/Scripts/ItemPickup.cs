using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Item"))
            {
            Debug.Log(col.name + "is a thing, yep.");

            col.GetComponent<MeshRenderer>().enabled = false;


        }
    }
}
