using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

public GameObject home;
public GameObject options;
[SerializeField] AudioSource UIClick;
[SerializeField] AudioSource music;
[SerializeField] AudioSource[] SFX;
[SerializeField] Image musicRend;
[SerializeField] Image soundRend;
[SerializeField] Sprite[] soundImg;
[SerializeField] Sprite[] musicImg;
[SerializeField] ScoreManager scoreManager;
public int musicNum;
public int soundNum;
public bool isAudioPlaying;

void Start()
{
    soundNum = 0;
    musicNum = 0;
    isAudioPlaying = true;
}
// Open options
public void OpenOptions()
{
    options.SetActive(true); // enable options
    Time.timeScale = 0; // pause game
}

// Close options
public void CloseOptions()
{
    options.SetActive(false); // disable options
    if (!home.activeInHierarchy)
    {
        Time.timeScale = 1; // unpause game
    }
    UIClick.Play();
}

// Sound button
public void ToggleSound()
{
if (soundNum == 0)
{
    soundNum = 1;
} else
{
    soundNum = 0;
}
soundRend.sprite = soundImg[soundNum];
ToggleAudioSources(); // Mute/Unmute SFX
UIClick.Play();
}

// Music button
public void ToggleMusic()
{
if (musicNum == 0)
{
    musicNum = 1;
} else
{
    musicNum = 0;
}
musicRend.sprite = musicImg[musicNum];
music.mute = !music.mute; // Mute/Unmute Music
UIClick.Play();
}

// SFX
private void ToggleAudioSources()
    {
        isAudioPlaying = !isAudioPlaying;

        foreach (AudioSource audioSource in SFX)
        {
            if (isAudioPlaying)
            {
                audioSource.mute = false;
            }
            else
            {
                audioSource.mute = true;
            }
        }
    }

// Save audio settings
}


