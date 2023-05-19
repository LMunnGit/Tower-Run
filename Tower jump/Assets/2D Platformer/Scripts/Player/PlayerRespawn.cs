using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class PlayerRespawn : MonoBehaviour
{
[SerializeField] private PlayerController playerController;
[SerializeField] private Transform player;
[SerializeField] private GameObject[] respawnPlatform;
[SerializeField] private GameObject gameOver;
[SerializeField] private GameObject respawn;
[SerializeField] private  PlatformSpawner spawner;
private Transform highestPlatform;
private Vector3 highestPosition;

[SerializeField] private float spawnHeight;
[SerializeField] private float yOffsetThreshold = 1f; // adjust this value to set the Y offset threshold

void Awake()
{
    gameOver.SetActive(false);
    highestPosition = Vector3.zero;
}

void OnDrawGizmos()
{
    // Gizmos.DrawWireSphere(transform.position, 8.5f);
}

void Update()
{
    if (player.position.y > highestPosition.y)
    {
        highestPosition = player.position;
    }
}

public void Respawn()
{
Collider2D[] colliders = Physics2D.OverlapCircleAll(highestPosition, 8.5f);
    highestPlatform = null;

foreach(Collider2D coll in colliders)
{
        if (highestPlatform != null)
        {
            // make sure platform in under player
            if (coll.gameObject.transform.position.y < highestPosition.y && coll.gameObject.tag == "Platform")
            {
        if (coll.gameObject.transform.position.y >= highestPlatform.position.y)
        {
            highestPlatform = coll.gameObject.transform; // set highest platform
        }
        
        }
        
        } else {
            // make sure platform in under player
            if (coll.gameObject.transform.position.y < highestPosition.y && coll.gameObject.tag == "Platform")
            {
            highestPlatform = coll.gameObject.transform; // set first platform
            }
        }
    } 
    if (highestPlatform != null)
    {
        Debug.Log(highestPlatform.gameObject.name); // show platform name
        Destroy(highestPlatform.gameObject);
        RespawnPlayer(); // Respawn player 
    } else {
        Debug.Log("null"); // show null
    }
}

// After respawn
void RespawnPlayer()
{
    playerController.deathState = false;
    int debug = 0;
    float step = 1 * Time.deltaTime;

    // Reposition player
    while (transform.position.y < Mathf.Round(highestPlatform.transform.position.y + spawnHeight) && debug < 10000)
    {
    player.gameObject.transform.position = Vector3.MoveTowards(transform.position, Vector3.up * spawnHeight + highestPlatform.transform.position, step);
    debug++;
    }

    GameObject platform;
    if (spawner.chunkHeight >= spawner.stoneChunkStart + 2)
    {
        platform = respawnPlatform[1]; // stone
    } else {
        platform = respawnPlatform[0]; // grass
    }

    // Spawn Platforms
    Instantiate(platform, new Vector3(0f, highestPlatform.transform.position.y, transform.position.z), Quaternion.identity, null);

    // Find all GameObjects with the "enemy" tag
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    // Loop through all enemies
        foreach (GameObject enemy in enemies)
        {
            // Check if the enemy's Y position is less than the player's Y position plus the threshold
            if (enemy.transform.position.y < player.transform.position.y + yOffsetThreshold)
            {
                // Do something if the enemy is within range (e.g. attack the player)
                Destroy(enemy);
            }
        }

        respawn.SetActive(false);

    // play animation for player revive and for floor spawning
}

}