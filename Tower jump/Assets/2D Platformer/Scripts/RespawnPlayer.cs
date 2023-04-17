using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
[SerializeField] PlayerController playerController;
[SerializeField] Transform player;

void RespawnPlayer()
{
    playerController.deathState = false;
    // spawn full floor at the closet platform to the players feet
    // play animation for player revive and for floor spawning
}
}
