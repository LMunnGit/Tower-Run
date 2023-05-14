using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private Transform barrel;
    [SerializeField] private float shootTime;

    void Start()
    {
        StartCoroutine("ShootCannon");
    }

    IEnumerator ShootCannon()
    {
        while(true)
        {
        yield return new WaitForSeconds(shootTime);
        Instantiate(cannonBall, barrel);
        yield return null;
        }
    }
}
