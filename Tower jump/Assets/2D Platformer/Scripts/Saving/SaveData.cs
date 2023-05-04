using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static float highScore;

    public SaveData(ScoreManager scoreManager)
    {
        highScore = scoreManager.highScore;
    }
}
