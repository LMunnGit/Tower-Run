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
//   Setup();
}

public void Setup()
{
        // Randomize starting chunk
    float rand = Random.value;
    if (rand > 0.5f)
    {
        chunkRight = true;
        startingChunkRight = true;
    } else 
    {
        chunkRight = false;
        startingChunkRight = false;
    }

    spawner.position = Vector3.zero;
    chunks.position = Vector3.zero;
    towerHeight = 0;
    chunkHeight = 0;
    spawner.position = new Vector2 (0, towerHeight);
    SpawnPlatform();
    spawner.position = new Vector2 (0, towerHeight);
    SpawnPlatform();
}

// When spawner passes the top set a new top
void Update()
{  

    if (camTop.position.y + 5f >= towerHeight)
    {
        spawner.position = new Vector2 (0, 0);
        SpawnPlatform();
    }

}

// Stay above the camera
void LateUpdate()
{

}

// Platform spawning script
void SpawnPlatform()
{
    if (chunkRight == true)
    {
        num = Random.Range(0, platformRight.Length);
        var platRight = Instantiate(platformRight[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        platRight.transform.parent = chunks.transform;
        if (chunkHeight > 1)
        {
            spawner.position = new Vector2 (0, 13.5f);    
        } else {
        spawner.position = new Vector2 (0, towerHeight);
        }
        platRight.transform.localPosition = new Vector2(x, spawner.position.y);

    } else if (chunkRight == false)
    {
        num = Random.Range(0, platformLeft.Length);
        var platLeft = Instantiate(platformLeft[num], new Vector3(x, 0, 0), Quaternion.identity, null);

        platLeft.transform.parent = chunks.transform;
         if (chunkHeight > 1)
        {
            spawner.position = new Vector2 (0, 13.5f);    
        } else {
        spawner.position = new Vector2 (0, towerHeight);
        }
        platLeft.transform.localPosition = new Vector2(x, spawner.position.y);

    }

    chunkRight = !chunkRight;
    chunkHeight++;
    towerHeight += chunkSize;
}

}
