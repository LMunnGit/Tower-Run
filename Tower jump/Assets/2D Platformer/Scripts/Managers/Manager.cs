using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject gameOver;
    public GameObject score;
    public PlayerController playerController;
    public ScoreManager scoreManager;
    public PlatformSpawner platformSpawner;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;

    private void Start()
    {
         // Setup UI
        home.SetActive(true);
        options.SetActive(false);
        gameOver.SetActive(false);
        score.SetActive(false);

        // Player Spawn
        playerController.deathState = false;

        // destroy old platforms
        GameObject chunks = GameObject.Find("Chunks");
        foreach (Transform child in chunks.transform)  
        { 
        GameObject.Destroy(child.gameObject);
        }

        //LoadData();
        platformSpawner.Setup(); // Spawn platforms
        playerController.Spawn(); // Spawn player
        // Setup();
    }

    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        scoreManager.highScore = SaveData.highScore;
        Debug.Log(scoreManager.highScore);
    }

    void Update()
    {

    }

    public void Setup()
    {

        SceneManager.LoadScene("Game");

        LoadData();

        // Setup UI
        home.SetActive(true);
        Score.text = scoreManager.score.ToString();
        HighScore.text = scoreManager.highScore.ToString();
        options.SetActive(false);
        gameOver.SetActive(false);
        score.SetActive(false);

        // Player Spawn
        playerController.deathState = false;

        // destroy old platforms
        GameObject chunks = GameObject.Find("Chunks");
        foreach (Transform child in chunks.transform)  
        { 
        GameObject.Destroy(child.gameObject);
        }

        platformSpawner.Setup(); // Spawn platforms
        playerController.Spawn(); // Spawn player
    }    
}

