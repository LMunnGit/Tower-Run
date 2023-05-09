using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isUp;
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
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        float raySize = 0.2f;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, target); // check for collider
        Debug.DrawRay(transform.position, target * raySize, Color.white);

        if (hitInfo.collider != null)
    {
    if (hitInfo.distance < 0.05f && hitInfo.collider.gameObject.tag != "Enemy") // check for collision
    {
        Destroy(gameObject);
    }
    }
}

    

}

