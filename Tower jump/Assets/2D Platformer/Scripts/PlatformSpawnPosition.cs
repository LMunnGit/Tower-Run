using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPosition : MonoBehaviour
{
public PlatformSpawner platformSpawner;
private Transform set;

void Awake()
{
    platformSpawner = GameObject.Find("Platform Spawner").GetComponent<PlatformSpawner>();
    set = platformSpawner.spawner;
}

void Update()
{
    //    transform.position = set.position;
}
}
