using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject gameOver;
    [SerializeField] private Transform button;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameOver.activeSelf == true)
        {
            if (Input.mousePosition.y > button.position.y + buttonExtraHeight)
            {
                Restart();
            }
        }
    }


}
