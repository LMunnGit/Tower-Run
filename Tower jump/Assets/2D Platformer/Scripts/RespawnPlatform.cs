using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject plat;
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        plat.SetActive(true); // enable platform
        // enable collider and visuals
    }
}
