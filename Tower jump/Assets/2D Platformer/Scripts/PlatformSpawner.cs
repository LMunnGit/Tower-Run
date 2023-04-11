using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
[SerializeField] private Transform player;
[SerializeField] private Transform cam;
[SerializeField] private Transform spawner;
[SerializeField] private GameObject[] platformLeft;
[SerializeField] private GameObject[] platformRight;


public float towerHeight;
public float chunkSize;
public int chunkHeight;
public bool chunkRight;

public float x;
public int num;

void Start()
{
    // Randomize starting chunk
    if (Random.value > 0.5f)
    {
        chunkRight = true;
    } else 
    {
        chunkRight = false;
    }
    
    // Setup
    spawner.position = new Vector2(0, 0);
    SpawnPlatform();
    
    towerHeight = chunkSize;
    chunkHeight = 1;
    spawner.position = new Vector2(0, chunkSize);
    
}
void Update()
{   

    if (spawner.position.y >= towerHeight)
    {
        SpawnPlatform();
        towerHeight += chunkSize;
    }
}

// Platform spawning script
void SpawnPlatform()
{
    if (chunkRight == true)
    {
        num = Random.Range(0, platformRight.Length);
        Instantiate(platformRight[num], new Vector3(x, spawner.position.y, 0), Quaternion.identity, null);
    } else if (chunkRight == false)
    {
        num = Random.Range(0, platformLeft.Length);
        Instantiate(platformLeft[num], new Vector3(x, spawner.position.y, 0), Quaternion.identity, null);
    }
    chunkRight = !chunkRight;
    chunkHeight++;
}

}
