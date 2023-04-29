using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
[SerializeField] private Transform player;
[SerializeField] private Transform cam;
[SerializeField] private Transform camTop;
[SerializeField] private Transform ground;
[SerializeField] public Transform spawner;
[SerializeField] public Transform chunks;
[SerializeField] private GameObject[] platformLeft;
[SerializeField] private GameObject[] platformRight;


public float towerHeight;
public float chunkSize;
public int chunkHeight;
public bool chunkRight;
public bool startingChunkRight;

public float x;
public int num;
private bool isSet = false;
public float down;

void Awake()
{
    Setup();
}

public void Setup()
{
        // Randomize starting chunk
    if (Random.value > 0.5f)
    {
        chunkRight = true;
        startingChunkRight = true;
    } else 
    {
        chunkRight = false;
        startingChunkRight = false;
    }

    // Setup
    float minus = chunkHeight;
    chunkHeight = 0;
    spawner.position = new Vector3(0, 0, 0);

    // Spawn first platform
    PlatformSetup();

    chunkRight = !chunkRight;
    chunkHeight++;

    spawner.position = new Vector3(0, chunkSize, 0);
    down = towerHeight;
    towerHeight = chunkSize;

    // Spawn second platform 
    PlatformSetup();

    chunkRight = !chunkRight;
    towerHeight = chunkSize * 2;

}

// When spawner passes the top set a new top
void Update()
{  

    if (spawner.position.y >= towerHeight)
    {
        SpawnPlatform();
        towerHeight += chunkSize;
    }

}

// Stay above the camera
void LateUpdate()
{
    if (PlatformSpawnPosition.isSet)
    {
        transform.position = new Vector2(camTop.position.x, camTop.position.y + 5f);
    }  
}

// First platforms
void PlatformSetup()
{
    if (chunkRight == true)
    {
        num = Random.Range(0, platformRight.Length);
        var platRight = Instantiate(platformRight[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        platRight.transform.position = spawner.position;
        platRight.transform.parent = chunks.transform;
    } else if (chunkRight == false)
    {
        num = Random.Range(0, platformLeft.Length);
        var platLeft = Instantiate(platformLeft[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        platLeft.transform.position = spawner.position;
        platLeft.transform.parent = chunks.transform;
    }
}

// Platform spawning script
void SpawnPlatform()
{
    if (chunkRight == true)
    {
        num = Random.Range(0, platformRight.Length);
        var platRight = Instantiate(platformRight[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        float minus = chunkHeight * chunkSize;
        platRight.transform.position = spawner.position + Vector3.down * minus;
        platRight.transform.parent = chunks.transform;
    } else if (chunkRight == false)
    {
        num = Random.Range(0, platformLeft.Length);
        var platLeft = Instantiate(platformLeft[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        float minus = chunkHeight * chunkSize;
        platLeft.transform.position = spawner.position + Vector3.down * minus;
        platLeft.transform.parent = chunks.transform;
    }

    chunkRight = !chunkRight;
    chunkHeight++;
}

}
