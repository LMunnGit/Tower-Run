using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine("BreakPlatform");
        } // setup collision with only the top of the platform
    }

    IEnumerator BreakPlatform()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Shake");
        yield return new WaitForSeconds(1.5f);

        anim.SetTrigger("FastShake");
        yield return new WaitForSeconds(1f);

        Destroy(gameObject); // change to disable collider and visuals
        StartCoroutine("Respawn");
        yield break;

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4f);
        // enable collider and visuals
    }

}
