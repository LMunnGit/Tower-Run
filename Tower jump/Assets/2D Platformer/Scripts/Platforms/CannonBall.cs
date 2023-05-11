using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isUp;
    [SerializeField] private Rigidbody2D rb;
    private float dir;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isUp)
        {
            dir = 1f;
        } else
        {
            dir = -1f;
        }
        float step = speed * Time.deltaTime;
        Vector3 target = Vector3.up * dir;
        rb.MovePosition(transform.position + new Vector3(0f, speed * dir, 0f) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}


