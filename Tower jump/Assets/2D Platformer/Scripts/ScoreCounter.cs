using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public float score; // player score
    public float scoreSize;

    private Transform scoreColl;

    void Awake()
    {
        // create score collider
        scoreColl = new GameObject().transform;

        // name score collider
        scoreColl.name = "ScoreCollider";

        // add collider
        scoreColl.gameObject.AddComponent<EdgeCollider2D>();

        // Size the collider
       

        // make collider a trigger
        scoreColl.GetComponent<EdgeCollider2D>().isTrigger = true;

        scoreColl.gameObject.AddComponent<ScoreClimb>();

    }

    void Update()
    {
              
    }
}
