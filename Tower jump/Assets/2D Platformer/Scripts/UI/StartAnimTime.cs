using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimTime : MonoBehaviour
{
void Update()
{
    float animationSpeed = 1.0f; // Set the animation speed as desired.
    Animator animator = GetComponent<Animator>();
    animator.speed = animationSpeed;
    if (Time.timeScale == 0)
    {
            animator.Update(Time.unscaledDeltaTime); // Use unscaledDeltaTime to ensure the animation continues to update even when time scale is set to 0.
    }
}
}
