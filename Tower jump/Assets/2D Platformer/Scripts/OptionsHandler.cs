using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : MonoBehaviour
{

public GameObject options;

// Open options
public void OpenOptions()
{
    options.SetActive(true);
    Time.timeScale = 0; // pause game
}

// Close options
public void CloseOptions()
{
    options.SetActive(false);
    Time.timeScale = 1; // unpause game
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
