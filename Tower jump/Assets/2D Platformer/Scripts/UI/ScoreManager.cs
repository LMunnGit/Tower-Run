using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
public GameObject homeScore;
public TextMeshProUGUI Score;
public TextMeshProUGUI HighScore;
public float score;
public float highScore;

void Update()
{
        if (score > highScore)
        {
            highScore = score;
        } else if (highScore == 0f)
        {
            highScore = score;
        }

    // Set texts
    Score.text = score.ToString();
    HighScore.text = highScore.ToString();
}
}
