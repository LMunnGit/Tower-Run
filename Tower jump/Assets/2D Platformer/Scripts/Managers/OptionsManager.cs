using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{

public GameObject home;
public GameObject options;

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
}

// Sound button
public void ToggleSound()
{
Debug.Log("sound toggle");
}

// Music button
public void ToggleMusic()
{
Debug.Log("music toggle");
}
}
