using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
public float score;
public float highScore = 0;
public bool newHighScore = false;

void Update()
{
        if (score > highScore)
        {
            highScore = score;
            newHighScore = true;
            SaveSystem.SaveData(this);
            Debug.Log(highScore);
        } else if (highScore == 0f)
        {
            highScore = score;
        }
}
}
