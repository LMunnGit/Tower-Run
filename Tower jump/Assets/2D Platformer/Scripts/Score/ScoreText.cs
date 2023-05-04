using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreManager = GameObject.Find("Main Camera").GetComponent<ScoreManager>();
    }

    void Update()
    {
        scoreText.text = scoreManager.score.ToString(); 
    }

}
