using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bolt"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Asteroids"))
        {
            Destroy(other.gameObject);
        }
    }
}
