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

//public class SaveAudio
// {
    // public static int musicToggle;
    // public static int soundToggle;
    // public static bool audio;

    // public SaveAudio(OptionsManager optionsManager)
    // {
        // musicToggle = optionsManager.musicNum;
        // soundToggle = optionsManager.soundNum;
        // audio = optionsManager.isAudioPlaying;
    // }

// }
