using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEnabler : MonoBehaviour
{
[SerializeField] private EdgeCollider2D coll;

[SerializeField] private GameObject player;

// Disable collider on awake
void Awake()
{
 coll.enabled = false;
 player = GameObject.Find("Player");
}

void Update()
{
    // Enable collider if player is above it
    if (player.transform.position.y > transform.position.y + 0.5f)
    {
        coll.enabled = true;
    } else
    {
        coll.enabled = false;
    }
}
}
