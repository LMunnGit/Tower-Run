using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private ScoreCounter scoreCounter;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>(); // add script
    }

    void Update()
    {
        scoreText.text = scoreCounter.score.ToString();
    }
}
