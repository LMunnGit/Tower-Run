using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static float highScore;
    public static float score;
    public static bool newHighScore;

    public SaveData(ScoreManager scoreManager)
    {
        highScore = scoreManager.highScore;
        score = scoreManager.score;
        newHighScore = scoreManager.newHighScore;
    }
}
