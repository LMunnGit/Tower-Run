using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Manager manager; 

    public float buttonExtraHeight;   

    void Awake()
    {
        gameOver.SetActive(false);
    }

    // Restart game
    private void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }



}
