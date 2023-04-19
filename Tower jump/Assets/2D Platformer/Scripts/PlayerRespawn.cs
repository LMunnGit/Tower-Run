using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class PlayerRespawn : MonoBehaviour
{
[SerializeField] private PlayerController playerController;
[SerializeField] private Transform player;

void Respawn()
{
    playerController.deathState = false;
    // spawn full floor at the closet platform to the players feet
    // play animation for player revive and for floor spawning
}

void FixedUpdate()
{
    if (Input.GetKeyDown(KeyCode.F)) // when f is pressed check platforms around player
    {
Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 8.5f);
foreach(Collider2D coll in colliders)
{
    Debug.Log(coll.gameObject.name);
}

}  
}

}