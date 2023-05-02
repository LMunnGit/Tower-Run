using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPlatfromScript : MonoBehaviour
{
 // Find all objects with the "Platform" tag within the collider and destroy them
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Platform"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
