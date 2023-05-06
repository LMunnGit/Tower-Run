using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class HomeManager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject score;
    public ScoreCounter scoreCounter;
    public ScoreManager scoreManager;
    public AudioSource UIClick;
    private PlayerController playerController;
    private ScoreClimb scoreClimb;

    void Awake()
    {
        Time.timeScale = 0; 
        scoreClimb = GameObject.Find("ScoreCollider").GetComponent<ScoreClimb>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        if (!options.activeInHierarchy)
        {
            Time.timeScale = 1;
            playerController.deathState = false;
            home.SetActive(false); 
            score.SetActive(true);
            scoreManager.score = 0;
            scoreClimb.Setup();           
        }
    } 

}
