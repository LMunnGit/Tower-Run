using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
[SerializeField] private float speed;
[SerializeField] private float raySize;
private int dir;
private bool hit;

void Start()
{
    dir = 1;
}

void Update()
{
    if (hit == false)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right * dir, speed * Time.deltaTime);
    } else if (hit == true)
    {
        dir *= -1;
        hit = false;
    }
}

void FixedUpdate()
{
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + Vector3.right * raySize * dir, Vector2.right * dir); // check for collider
    Debug.DrawRay(transform.position + Vector3.right * raySize * dir, Vector2.right * dir, Color.white);

    if (hitInfo.collider != null)
    {
    if (hitInfo.collider.gameObject.tag == "Wall" && hitInfo.distance < 0.005f) // check if collider is wall
    {
        hit = true;
    } else
    {
        hit = false;
    }
    }
}

}
