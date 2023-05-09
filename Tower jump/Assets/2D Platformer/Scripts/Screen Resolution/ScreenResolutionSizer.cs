using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class ScreenResolutionSizer : MonoBehaviour
{
    public float naturalObjectSize = 1.0f;
    public float screenResolutionWidth = 1080.0f;
    private float newSize;
    private float previousScreenWidth;

    void Start()
    {
        previousScreenWidth = 0f;
        // UpdateScale();
    }

    void LateUpdate()
    {
        if (Screen.width != previousScreenWidth)
        {
            previousScreenWidth = Screen.width;
            UpdateScale();
        }
    }

    void UpdateScale() // make player move slower aswell
    {
        // Resize
        float screenRatio = Screen.width / screenResolutionWidth;
        float newScale = naturalObjectSize / screenRatio;
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

        // Reposition
        float offset;
        offset = naturalObjectSize / newScale / 4;

        if (gameObject.tag == "Enemy") // Reposition spikes
        {
            transform.position += Vector3.down * offset / 1.5f;
        }

        if (gameObject.transform.position.x < 0) // Left side of screen
        {
            transform.position += Vector3.left * offset;
        } else if (gameObject.transform.position.x > 0) // Right side of screen
        {
            transform.position += Vector3.right * offset;
        }
    }
}
