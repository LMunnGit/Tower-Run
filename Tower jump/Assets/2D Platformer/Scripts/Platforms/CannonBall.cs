using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isUp;
    private float rot;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isUp)
        {
            rot = 1f;
        } else
        {
            rot = -1f;
        }
        float step = speed * Time.deltaTime;
        Vector3 target = Vector3.up * rot * 10;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Add raycasting
    }


}
