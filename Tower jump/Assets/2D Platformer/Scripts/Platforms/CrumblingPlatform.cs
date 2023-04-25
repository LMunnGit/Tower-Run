using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private RespawnPlatform script;

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

        script.StartCoroutine("Respawn");
        gameObject.SetActive(false); // disable platform
        yield break;

    }

}
