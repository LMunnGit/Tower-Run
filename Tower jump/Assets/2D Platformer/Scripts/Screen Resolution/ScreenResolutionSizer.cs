using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionSizer : MonoBehaviour
{
    public GameObject gameObjectToScale;
    public float naturalObjectSize = 1.0f;
    public float screenResolutionWidth = 1080.0f;
    private float newSize;
    

    private float previousScreenWidth;

    void Start()
    {
        previousScreenWidth = Screen.width;
        UpdateScale();
    }

    void LateUpdate()
    {
        if (Screen.width != previousScreenWidth)
        {
            previousScreenWidth = Screen.width;
            UpdateScale();
        }
    }

    void UpdateScale()
    {
        float screenRatio = Screen.width / screenResolutionWidth;
        float newScale = naturalObjectSize / screenRatio;
        gameObjectToScale.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
