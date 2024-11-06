using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// By Mads.
/// For use in the Spider's patrolling AI (and probably also chasing AI).
/// </summary>

public class BranchingPath : MonoBehaviour
{
    public float distanceFromSpider;
    public GameObject spider;
    public Spider spiderController;

    private void Awake()
    {
        spiderController = spider.GetComponent<Spider>();
    }

    private void Update()
    {
        distanceFromSpider = Vector3.Distance(transform.position, spider.transform.position);

        if (distanceFromSpider < 0.2f )
        {
            spiderController.branchDetected = true;
        }
        else if (!spiderController.branchDetected)
        {
            spiderController.branchDetected = false;
        }
    }
}
