using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPosition : MonoBehaviour
{
public PlatformSpawner platformSpawner;
private Transform ground;
private Transform set;
public static bool isSet;

void Awake()
{
    platformSpawner = GameObject.Find("Platform Spawner").GetComponent<PlatformSpawner>();
    set = platformSpawner.spawner;
    ground = GameObject.Find("Ground").transform;
    isSet = false;
    Invoke("SetPosition", 0.05f);
}

public void SetPosition()
{
    transform.position = set.position;
    isSet = true;  
}


}
