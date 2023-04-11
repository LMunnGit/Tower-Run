using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
private Rigidbody2D rb;
[SerializeField] private float speed;
[SerializeField] private float idle;
private int dir;
private bool isIdle;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    dir = 1;
    isIdle = false;
}

void Update()
{
    rb.MovePosition(transform.position + new Vector3(dir, 0f) * speed * Time.deltaTime);
    if (isIdle) // setup idle it dont work right now
    {
        StartCoroutine(Idle());
    }
}

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Wall")
    {
        dir *= -1;
        isIdle = true;
    }
}

IEnumerator Idle()
{
yield return new WaitForSeconds(idle);
isIdle = false;
yield break;
}
}
