using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer;

public class Manager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject gameOver;
    public GameObject score;
    public PlayerController playerController;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        // Setup UI
        home.SetActive(true);
        options.SetActive(false);
        gameOver.SetActive(false);
        score.SetActive(false);

        // Player Spawn
        playerController.deathState = false;
        playerController.Spawn();
    }    
}

