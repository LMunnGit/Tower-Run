using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
[SerializeField] private float speed;
private int dir;
// collision without rigidbody
void Start()
{
    dir = 1;
}

void Update()
{
    transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right * dir, speed * Time.deltaTime); // remove rigidbody
}

// for platform
void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Wall")
    {
        dir *= -1;
        Debug.Log("there");
    }
}
// for floor
void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.tag == "Wall")
    {
        dir *= -1;
    }
}
}
