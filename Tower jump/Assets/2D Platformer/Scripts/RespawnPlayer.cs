using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class RespawnPlayer : MonoBehaviour
{
[SerializeField] private PlayerController playerController;
[SerializeField] private Transform player;

void Respawn()
{
    playerController.deathState = false;
    // spawn full floor at the closet platform to the players feet
    // play animation for player revive and for floor spawning
}
}
