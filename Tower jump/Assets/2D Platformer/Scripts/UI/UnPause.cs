using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPause : MonoBehaviour
{
    private float fixedDeltaTime;

    void FixedUpdate()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
