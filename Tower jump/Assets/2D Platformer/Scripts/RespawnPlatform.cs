using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject plat;
    [SerializeField] float respawnTime;
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        plat.SetActive(true); // enable platform
        // enable collider and visuals
    }
}
