using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject score;
    public ScoreCounter scoreCounter;
    private ScoreClimb scoreClimb;

    void Start()
    {
        Time.timeScale = 0; 
        scoreClimb = GameObject.Find("ScoreCollider").GetComponent<ScoreClimb>();
    }

    public void StartGame()
    {
        if (!options.activeInHierarchy)
        {
            Time.timeScale = 1;
            home.SetActive(false); 
            score.SetActive(true);
            scoreCounter.score = 0;
            scoreClimb.Setup();
        }
    } 

}
