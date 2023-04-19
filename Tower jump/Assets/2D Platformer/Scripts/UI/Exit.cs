using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public TextMeshProUGUI button;
    [SerializeField] Manager manager;
    
    // Exit game
    public void Home()
    {
        manager.Setup();     
    }


}
