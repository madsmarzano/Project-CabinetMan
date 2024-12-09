using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// By Mads:
/// If particles are used in a scene, this script sets them active last in the execution order.
/// </summary>

public class SpawnParticles : MonoBehaviour
{
    public GameObject particles;
    private void Start()
    {
        particles.SetActive(true);
    }
}
