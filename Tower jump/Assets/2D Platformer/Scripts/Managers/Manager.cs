using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject gameOver;
    public GameObject score;
    void Start()
    {
        // Setup UI
        home.SetActive(true);
        options.SetActive(false);
        gameOver.SetActive(false);
        score.SetActive(false);
    }
    
}

