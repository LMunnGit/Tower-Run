using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
public float score;
public float highScore = 0;
public bool newHighScore = false;

public void Score()
{
        if (score > highScore)
        {
            highScore = score;
            newHighScore = true;
            SaveSystem.SaveData(this);
            Debug.Log(highScore);
        } else if (score < highScore)
        {
            newHighScore = false;
            SaveSystem.SaveData(this);
        } else if (highScore == 0f)
        {
            newHighScore = true;
            SaveSystem.SaveData(this);
            highScore = score;
        }
}
}
