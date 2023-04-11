using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public TextMeshProUGUI button;
    // Exit game
    public void Exm()
    {
        Debug.Log("EXIT");
        SceneManager.LoadScene("HomeScreen");
        
    }


}
