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
    public PlatformSpawner platformSpawner;

    private void Start()
    {
        // Setup();
    }

    void Update()
    {

    }

    public void Setup()
    {

        SceneManager.LoadScene("Game");

        // Setup UI
        // home.SetActive(true);
        // options.SetActive(false);
        // gameOver.SetActive(false);
        // score.SetActive(false);

        // Player Spawn
        // playerController.deathState = false;

        // destroy old platforms
        // GameObject chunks = GameObject.Find("Chunks");
        // foreach (Transform child in chunks.transform)  
        // { 
        // GameObject.Destroy(child.gameObject);
        // }

        // platformSpawner.Setup(); // Spawn platforms
        // playerController.Spawn(); // Spawn player
    }    
}

