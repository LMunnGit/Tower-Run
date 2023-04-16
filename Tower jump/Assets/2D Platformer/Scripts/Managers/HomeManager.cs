using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public GameObject home;
    public GameObject options;
    public GameObject score;

    void Start()
    {
        Time.timeScale = 0; 
    }

    public void StartGame()
    {
        if (!options.activeInHierarchy)
        {
            Time.timeScale = 1;
            home.SetActive(false);  
            score.SetActive(true);
        }
    } 

}
